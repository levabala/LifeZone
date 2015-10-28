using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LifeZone
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer lifeTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer propertiesUpdate = new System.Windows.Forms.Timer();
        int lifetime = 0;
        List<Ball> balls = new List<Ball>();
        List<Food> foods = new List<Food>();
        int foodPerTick = 1;
        Matrix m = new Matrix();
        LifeParameters lifeparam = new LifeParameters();
        bool debug = false;
        bool parallel = true;
        bool evolution = true;
        float lifezoneBorderX, lifezoneBorderY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m.Translate(10, 100);
            Left = 0;
            Top = Screen.PrimaryScreen.WorkingArea.Height / 4;
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height / 1.6);
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Height * 1.2);
            evolution = EvolutionMode.Checked;
            lifezoneBorderX = Width;
            lifezoneBorderY = Height;
            for (int i = 0; i < 3; i++)
            {
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(5, (int)lifezoneBorderX - 5), new Random().Next(5, (int)lifezoneBorderY - 5))), lifezoneBorderX, lifezoneBorderY));
            }
            updateMatrix();            
            
            lifeTimer.Interval = 1;
            lifeTimer.Tick += lifeTimer_Tick;
            lifeTimer.Start();

            lifeparam.Show();            
        }

        private void updateEvolGraph()
        {
            float averSpeed = 0f;
            float averRotate = 0f;
            float minS = 1000000f;
            float maxS = 0f;
            float minR = 1000000f;
            float maxR = 0f;
            int activeCount = 0;
            Parallel.ForEach(balls, b =>
                {
                    if (b != null && !b.grudge && b.young)
                    {
                        float rs = b.rotateSpeed;
                        float s = b.speed;
                        averRotate += rs;
                        averSpeed += s;
                        if (s <= minS) minS = s;
                        if (s >= maxS) maxS = s;
                        if (rs <= minR) minR = rs;
                        if (rs >= maxR) maxR = rs;
                        activeCount++;
                    }
                });            
            averSpeed = averSpeed / activeCount;
            averRotate = averRotate / activeCount;
            
            lifeparam.averageMoving = averSpeed;
            lifeparam.averageRotate = averRotate;
            lifeparam.minR = minR;
            lifeparam.maxR = maxR;
            lifeparam.minS = minS;
            lifeparam.maxS = maxS;
            lifeparam.changeGraphEvol(0, averRotate);
            lifeparam.changeGraphEvol(1, averSpeed);            
        }

        void lifeTimer_Tick(object sender, EventArgs e)
        {
            if (!debug) lifeTick();
            else debugging();
        }

        public void lifeTick()
        {
            if (lifetime % 100 == 0) Text = lifetime + " ad.";
            int active = 0;
            int passive = 0;
            int old = 0;

            food();

            Parallel.ForEach(balls, b =>
            {
                if (b != null)
                {
                    if (!b.young) old++;
                    else if (b.grudge) passive++;
                    else active++;
                    if (b.readyToClone)
                    {
                        try
                        {
                            if (evolution) balls.Add(new Ball(b.position, lifezoneBorderX, lifezoneBorderY, b, b.partner));
                            else balls.Add(new Ball(b.position, lifezoneBorderX, lifezoneBorderY));
                            b.readyToClone = false;
                            b.size = b.size / 2;
                        }
                        catch (System.IndexOutOfRangeException)
                        {

                        }
                    }
                }
            });
            foreach (Ball b in balls) if (b != null && b.age >= b.lifetime) //Киллим старичков
                {
                    balls.Remove(b);
                    lifetime++;
                    lifeparam.total.Add(balls.Count);
                    lifeparam.actives.Add(active);
                    lifeparam.passives.Add(passive);
                    lifeparam.oldes.Add(old);
                    updateEvolGraph();
                    if (lifetime % 100 == 0 || !debug)
                    {
                        ActiveHabitants.Text = active.ToString();
                        SecludedHabitants.Text = passive.ToString();
                        OldHabitants.Text = old.ToString();
                        Total.Text = balls.Count.ToString();
                        
                        Invalidate();

                    }
                    return;
                }
            lifetime++;
            lifeparam.total.Add(balls.Count);
            lifeparam.actives.Add(active);
            lifeparam.passives.Add(passive);
            lifeparam.oldes.Add(old);
            updateEvolGraph();
            if (lifetime % 100 == 0 || !debug)
            {
                ActiveHabitants.Text = active.ToString();
                SecludedHabitants.Text = passive.ToString();
                OldHabitants.Text = old.ToString();
                Total.Text = balls.Count.ToString();
                
                Invalidate();
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (parallel) parallelPaint(e.Graphics);
            else unparallelPaint(e.Graphics);
        }

        public void unparallelPaint(Graphics e)
        {
            Graphics g = e;
            g.Transform = m;
            foreach (Ball b in balls)
            {
                b.balls = balls;
                b.lifeTick();
                Pen color = Pens.Red;
                if (b.grudge) color = Pens.Blue;
                if (!b.young) color = Pens.Black;
                g.DrawEllipse(color, b.position.endPoint.X, b.position.endPoint.Y, b.size, b.size);
            }
        }

        public void parallelPaint(Graphics e)
        {
            Graphics g = e;
            g.Transform = m;
            g.DrawLine(Pens.Black, new PointF(4f, 4f), new PointF(4f, lifezoneBorderY + 10f));
            g.DrawLine(Pens.Black, new PointF(4f, 4f), new PointF(lifezoneBorderX + 10f, 4f));
            g.DrawLine(Pens.Black, new PointF(4f, lifezoneBorderY + 10f), new PointF(lifezoneBorderX + 10f, lifezoneBorderY + 10f));
            g.DrawLine(Pens.Black, new PointF(lifezoneBorderX + 10f, 4f), new PointF(lifezoneBorderX + 10f, lifezoneBorderY + 10f));

            Parallel.ForEach(balls, b =>
            //foreach(Ball b in balls)
            {
                if (b != null)
                {
                    b.balls = balls;
                    b.lifeTick();
                }
            });

            foreach (Ball b in balls)
            {
                if (b != null)
                {
                    Pen color = Pens.Red;
                    if (b.grudge) color = Pens.Blue;
                    if (!b.young) color = Pens.Black;
                    g.DrawEllipse(color, b.position.endPoint.X, b.position.endPoint.Y, b.size, b.size);
                }
            }

            foreach (Food f in foods)
            {
                //g.DrawEllipse(Pens.Brown, f.pos.endPoint.X, f.pos.endPoint.Y, f.value, f.value);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            return; // отключение "фичи для Саввы"        //шарики. LifeZone
                                                          //шарики. статистика. LifeZone v2.0
                                                          //шарики. LifeZone v2.1
            Parallel.ForEach(balls, b =>
            {
                Vector v = new Vector(b.position.endPoint, e.Location);
                if (v.length < 500)
                {
                    b.followTheMouse = true;
                    b.mouse = e.Location;
                }
                else b.followTheMouse = false;
            });
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            balls.Add(new Ball(new Vector(new PointF(0, 0), new PointF(e.Location.X * m.OffsetX, e.Location.Y * m.OffsetY)), lifezoneBorderX, lifezoneBorderY));
        }

        //m  -  Matrix
        public void updateMatrix()
        {
            m.Reset();
            m.Translate(10, 100);
            float coffX = Width / lifezoneBorderX;  //the border of lifezone by X
            float coffY = Height / lifezoneBorderY;

            if (coffX >= coffY)
            {
                m.Scale(coffX, coffX);
            }
            else m.Scale(coffY, coffY);
            m.Scale(0.75f, 0.75f);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            updateMatrix();
        }

        public void debugging()
        {
            int a = 0;
            do
            {
                lifeTick();
                Parallel.ForEach(balls, b =>
                {
                    if (b != null)
                    {
                        b.balls = balls;
                        b.lifeTick();
                    }
                });
                a++;              
            } while (a < 400);
            Invalidate();
        }

        public void food()
        {
            for (int i = 0; i < foodPerTick; i++)
            {
                foods.Add(new Food((int)lifezoneBorderX, (int)lifezoneBorderY));
            }
            Parallel.ForEach(foods, f =>
            {
                f.lifeTime--;                
            });
            Parallel.ForEach(balls, b =>
            {
                if (b != null) b.foods = foods;
            });
            foreach(Food f in foods)
            {
                if (f.lifeTime <= 0)
                {
                    foods.Remove(f);
                    return;
                }                
            }
        }

        private void EvolutionMode_CheckedChanged(object sender, EventArgs e)
        {
            evolution = EvolutionMode.Checked;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (debug)
                {
                    debug = false;
                    label1.ForeColor = Color.SeaGreen;
                    label1.Text = "TEST";
                }
                else
                {
                    debug = true;
                    label1.ForeColor = Color.Red;
                    label1.Text = "DEBUG";
                }
            }
            else if (e.KeyCode == Keys.Oemplus)
            {
                m.Scale(1.1f, 1.1f);
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                m.Scale(0.9f, 0.9f);
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                m.Reset();
                m.Translate(10, 100);
            }
            else if (e.KeyCode == Keys.F)
            {
                if (this.FormBorderStyle == FormBorderStyle.None) this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                else this.FormBorderStyle = FormBorderStyle.None;
            }
            else if (e.KeyCode == Keys.S)
            {
                updateMatrix();
            }
            else if (e.KeyCode == Keys.O)
            {
                if (lifeparam == null)
                {
                    lifeparam = new LifeParameters();
                    lifeparam.Show();
                }
                else
                {
                    lifeparam.total = new List<int>();
                    lifeparam.actives = new List<int>();
                    lifeparam.passives = new List<int>();
                    lifeparam.oldes = new List<int>();
                }
            }
            else if (e.KeyCode == Keys.P)
            {
                if (!parallel)
                {
                    parallel = true;
                    Calctype.ForeColor = Color.SeaGreen;
                    Calctype.Text = "Paralleling";
                }
                else
                {
                    parallel = false;
                    Calctype.ForeColor = Color.Red;
                    Calctype.Text = "Unparalleling";
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(25, (int)lifezoneBorderX - 25), new Random().Next(25, (int)lifezoneBorderY - 25))), lifezoneBorderX, lifezoneBorderY));
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(25, (int)lifezoneBorderX - 25), new Random().Next(25, (int)lifezoneBorderY - 25))), lifezoneBorderX, lifezoneBorderY));
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(25, (int)lifezoneBorderX - 25), new Random().Next(25, (int)lifezoneBorderY - 25))), lifezoneBorderX, lifezoneBorderY));
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(25, (int)lifezoneBorderX - 25), new Random().Next(25, (int)lifezoneBorderY - 25))), lifezoneBorderX, lifezoneBorderY));
                balls.Add(new Ball(new Vector(new PointF(0f, 0f), new PointF(new Random().Next(25, (int)lifezoneBorderX - 25), new Random().Next(25, (int)lifezoneBorderY - 25))), lifezoneBorderX, lifezoneBorderY));
            }
            Invalidate();
        }
    }
}

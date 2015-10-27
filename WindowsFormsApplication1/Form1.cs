using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int speed;
        List<Ball> command1;
        List<Ball> command2;
        List<Ball> balls;
        Timer lifeTimer;
        Matrix m = new Matrix();
        float coffX = 0f;
        float coffY = 0f;
        bool debug = false;
        List<PointF> points = new List<PointF>();

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            coffX = this.Height;
            coffY = this.Height;
            speed = Speed.Value;
            command1 = new List<Ball>();
            command2 = new List<Ball>();            

            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                command1.Add(new Ball(rnd));
                command2.Add(new Ball(rnd));                
            }

            balls = updateListBalls(command1, command2);

            lifeTimer = new Timer();
            lifeTimer.Interval = 1;             
            lifeTimer.Tick += lifeTimer_Tick;
            lifeTimer.Start();

            
        }

        void lifeTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();         
        }        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {            
            speed = Speed.Value;            
            lifeTimer.Interval = speed;
            Text = speed.ToString();
        }

        private void LifeArea_Enter(object sender, EventArgs e)
        {

        }

        private void LifeArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            g.Transform = m;
            foreach (Ball b in command1)
            {
                b.go();
                g.DrawEllipse(Pens.Red, b.position.endPoint.X * coffY, b.position.endPoint.Y * coffY, b.size * coffY, b.size * coffY);                
            }
            foreach (Ball b in command2)
            {
                b.go();
                g.DrawEllipse(Pens.Red, b.position.endPoint.X * coffY, b.position.endPoint.Y * coffY, b.size * coffY, b.size * coffY);
            }
            foreach(PointF p in points){
                g.DrawEllipse(Pens.Black, p.X, p.Y, 10, 10);
            }
        }

        private List<Ball> updateListBalls(List<Ball> first, List<Ball> second)
        {
            List<Ball> result = new List<Ball>();
            foreach (Ball b in first) result.Add(b);
            foreach (Ball b in second) result.Add(b);
            return result;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (debug)
                {
                    lifeTimer.Start();
                    debug = false;
                    label1.ForeColor = Color.SeaGreen;
                    label1.Text = "TEST";
                }
                else
                {
                    lifeTimer.Stop();
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
            }
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (debug)
            {
                Graphics g = CreateGraphics();
                g.DrawEllipse(Pens.Black, e.X, e.Y, 10, 10);
                points.Add(new PointF(e.X, e.Y));
                foreach (Ball b in command1)
                {
                    b.moving.changeDirection(new Vector(b.position.endPoint, e.Location).alpha);
                }
                //Invalidate();
            }
        }
    }
}

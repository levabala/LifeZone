using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeZone
{
    public partial class LifeParameters : Form
    {
        public List<int> total = new List<int>();
        public List<int> passives = new List<int>();
        public List<int> actives = new List<int>();
        public List<int> oldes = new List<int>();
        float comprCoef = 1f;
        private int actComprTimes;
        private Timer t = new Timer();
        private float globalGraphCoef = 0.8f;
        public LifeParameters()
        {
            InitializeComponent();
        }

        private void LifeParameters_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            actComprTimes = 1;
            t.Interval = 1000;
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public List<int> compressLocal(List<int> list, int indexOfBiggest)
        {
            List<int> result = new List<int>();
            Random rnd = new Random();
            result.Add(list[indexOfBiggest]);
            for (int i = 0; i < list.Count-1; i += 2)
            {
                result.Add((list[i] + list[i + 1]) / 2);
            }
            return result;
        }

        public List<int> compressLocal(List<int> list)
        {
            List<int> result = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < list.Count - 2; i += 2)
            {
                result.Add((list[i] + list[i + 1]) / 2);
            }
            return result;
        } 

        private void LifeParameters_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            total = drawGraph(g, total, (Height - 100) / 5 + 10, Pens.SeaGreen, Brushes.SeaGreen, true);
            actives = drawGraph(g, actives, (Height - 100) / 5 * 2+ 10, Pens.Firebrick, Brushes.Firebrick, true);
            passives = drawGraph(g, passives, (Height - 100) / 5 * 3+ 10, Pens.Blue, Brushes.Blue, true);
            oldes = drawGraph(g, oldes, (Height - 100) / 5 * 4 + 10, Pens.Black, Brushes.Black, true);
        }

        private List<int> drawGraph(Graphics g, List<int> numbers, int graphX, Pen color, Brush textColor, bool absolute)
        {
            int index = 0;
            float hight = 0;
            float coff = ((float)Width-80) / (float)numbers.Count;
            List<int> newList = numbers;
            if (numbers.Count > 0)
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                    if (numbers[i] >= hight)
                    {
                        hight = numbers[i];
                        index = i;
                    }
                numbers = compressLocal(numbers, index);
                coff = ((float)Width - 80) / (float)numbers.Count;
                PointF[] points = new PointF[numbers.Count + 1];
                points[0] = new PointF(60, graphX);                   
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    float thishight = numbers[i] / globalGraphCoef;
                    if (thishight >= hight)
                    {
                        hight = thishight;
                        index = i;
                    }
                    //g.DrawLine(color, coff * i + 60, graphX, coff * i + 60, graphX - thishight);
                    points[i] = new PointF(coff * i + 60, graphX - thishight / globalGraphCoef);
                }
                points[points.Length - 2] = new PointF(coff * numbers.Count + 60, graphX);
                points[points.Length - 1] = new PointF(60, graphX);
                g.FillPolygon(textColor, points);
                //if (coff <= 0.5f) compressAbsolute(numbers, index);
                if (coff <= 0.1f) newList = compressLocal(numbers, index);
            }
            g.DrawLine(color, 10f, graphX - hight / globalGraphCoef, Width, graphX - hight / globalGraphCoef);
            g.DrawString((hight * globalGraphCoef).ToString() + "(max)", new Font("Arial", 8f), textColor, new PointF(0, graphX - hight / globalGraphCoef - 14));
            if (numbers.Count > 0)
            {
                g.DrawString(numbers[numbers.Count - 1].ToString() + "(now)", new Font("Arial", 8f), textColor, new PointF(0, graphX - numbers[numbers.Count - 1] / globalGraphCoef));
                g.DrawLine(Pens.LightSkyBlue, 10f, graphX - numbers[numbers.Count - 1] / globalGraphCoef, Width, graphX - numbers[numbers.Count - 1] / globalGraphCoef);
            }

            if (hight / globalGraphCoef > (Height - 100) / 5 + 30) globalGraphCoef += 0.1f;

            return newList;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            t.Interval = trackBar1.Value;

        }
    }
}

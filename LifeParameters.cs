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
        private int actComprTimes;
        private Timer t = new Timer();
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

        public List<int> compress(List<int> list, int indexOfBiggest)
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

        private void LifeParameters_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            totalDraw(g);
            activesDraw(g);
            passivesDraw(g);
            oldesDraw(g);
        }

        public void totalDraw(Graphics g)
        {
            int graphX = 250;
            float graphCoef = 0.8f;
            List<int> numbers = total;
            Pen color = Pens.SeaGreen;
            Brush textColor = Brushes.SeaGreen;

            int index = 0;
            float coff = 1f;
            float hight = 0;
            if (numbers.Count > Width - 10) coff = (float)Width / (float)numbers.Count;            
            for (int i = 0; i < numbers.Count; i++)
            {
                float thishight = numbers[i] / graphCoef;
                if (thishight >= hight) 
                {
                    hight = thishight;
                    index = i;
                }
                g.DrawLine(color, coff * i + 60, graphX, coff * i + 60, graphX - thishight);
            }
            if (coff <= 0.5f) numbers = compress(numbers, index);
            g.DrawLine(color, 10f, graphX-hight, Width, graphX-hight);            
            g.DrawString((hight* graphCoef).ToString() + "(max)", new Font("Arial", 8f),textColor, new PointF(0,graphX-hight-14));
            if (numbers.Count > 0)
            {
                g.DrawString(numbers[numbers.Count - 1].ToString() + "(now)", new Font("Arial", 8f), textColor, new PointF(0, graphX - numbers[numbers.Count - 1] / graphCoef));
                g.DrawLine(color, 10f, graphX - numbers[numbers.Count - 1] / graphCoef, Width, graphX - numbers[numbers.Count - 1] / graphCoef);
            }

            total = numbers;
        }

        public void passivesDraw(Graphics g)
        {
            int graphX = 400;
            float graphCoef = 0.8f;
            List<int> numbers = passives;
            Pen color = Pens.Blue;
            Brush textColor = Brushes.Blue;

            int index = 0;
            float coff = 1f;
            float hight = 0;
            if (numbers.Count > Width - 10) coff = (float)Width / (float)numbers.Count;
            for (int i = 0; i < numbers.Count; i++)
            {
                float thishight = numbers[i] / graphCoef;
                if (thishight >= hight)
                {
                    hight = thishight;
                    index = i;
                }
                g.DrawLine(color, coff * i + 60, graphX, coff * i + 60, graphX - thishight);
            }
            if (coff <= 0.5f) numbers = compress(numbers, index);
            g.DrawLine(color, 10f, graphX - hight, Width, graphX - hight);
            g.DrawString((hight * graphCoef).ToString() + "(max)", new Font("Arial", 8f), textColor, new PointF(0, graphX - hight - 14));
            if (numbers.Count > 0)
            {
                g.DrawString(numbers[numbers.Count - 1].ToString() + "(now)", new Font("Arial", 8f), textColor, new PointF(0, graphX - numbers[numbers.Count - 1] / graphCoef));
                g.DrawLine(color, 10f, graphX - numbers[numbers.Count - 1] / graphCoef, Width, graphX - numbers[numbers.Count - 1] / graphCoef);
            }

            passives = numbers;
        }

        public void activesDraw(Graphics g)
        {
            int graphX = 600;
            float graphCoef = 0.8f;
            List<int> numbers = actives;
            Pen color = Pens.Firebrick;
            Brush textColor = Brushes.Firebrick;

            int index = 0;
            float coff = 1f;
            float hight = 0;
            if (numbers.Count > Width - 10) coff = (float)Width / (float)numbers.Count;
            for (int i = 0; i < numbers.Count; i++)
            {
                float thishight = numbers[i] / graphCoef;
                if (thishight >= hight)
                {
                    hight = thishight;
                    index = i;
                }
                g.DrawLine(color, coff * i + 60, graphX, coff * i + 60, graphX - thishight);
            }
            if (coff <= 0.5f) numbers = compress(numbers, index);
            g.DrawLine(color, 10f, graphX - hight, Width, graphX - hight);
            g.DrawString((hight * graphCoef).ToString() + "(max)", new Font("Arial", 8f), textColor, new PointF(0, graphX - hight - 14));
            if (numbers.Count > 0)
            {
                g.DrawString(numbers[numbers.Count - 1].ToString() + "(now)", new Font("Arial", 8f), textColor, new PointF(0, graphX - numbers[numbers.Count - 1] / graphCoef));
                g.DrawLine(color, 10f, graphX - numbers[numbers.Count - 1] / graphCoef, Width, graphX - numbers[numbers.Count - 1] / graphCoef);
            }

            actives = numbers;
        }

        public void oldesDraw(Graphics g)
        {
            int graphX = 800;
            float graphCoef = 0.8f;
            List<int> numbers = oldes;
            Pen color = Pens.Black;
            Brush textColor = Brushes.Black;

            int index = 0;
            float coff = 1f;
            float hight = 0;
            if (numbers.Count > Width - 10) coff = (float)Width / (float)numbers.Count;
            for (int i = 0; i < numbers.Count; i++)
            {
                float thishight = numbers[i] / graphCoef;
                if (thishight >= hight)
                {
                    hight = thishight;
                    index = i;
                }
                g.DrawLine(color, coff * i + 60, graphX, coff * i + 60, graphX - thishight);
            }
            if (coff <= 0.5f) numbers = compress(numbers, index);
            g.DrawLine(color, 10f, graphX - hight, Width, graphX - hight);
            g.DrawString((hight * graphCoef).ToString() + "(max)", new Font("Arial", 8f), textColor, new PointF(0, graphX - hight - 14));
            if (numbers.Count > 0)
            {
                g.DrawString(numbers[numbers.Count - 1].ToString() + "(now)", new Font("Arial", 8f), textColor, new PointF(0, graphX - numbers[numbers.Count - 1] / graphCoef));
                g.DrawLine(color, 10f, graphX - numbers[numbers.Count - 1] / graphCoef, Width, graphX - numbers[numbers.Count - 1] / graphCoef);
            }

            oldes = numbers;
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

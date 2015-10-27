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
    public partial class Form2 : Form
    {
        Vector v = new Vector();
        Vector vR = new Vector();
        Matrix m = new Matrix();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            m.Translate(200, 200);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Transform = m;
            g.DrawLine(Pens.Red, new Point(0, -500), new Point(0, +500));
            g.DrawLine(Pens.Red, new Point(-500, 0), new Point(500, 0));
            g.DrawLine(Pens.Blue, v.startPoint, v.endPoint);
            g.DrawLine(Pens.Green, vR.startPoint, vR.endPoint);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            PointF dp = datapoint(e.Location);
            v = new Vector(new PointF(0f, 0f), dp);
            vR = new Vector(v.length,v.getAlpha(),new PointF(0f,0f));
            Text = v.getAlpha().ToString("f3") + "  " + v.length;
            Invalidate();
        }

        private PointF datapoint(PointF screenpoint)
        {
            Matrix mi = m.Clone();
            mi.Invert();
            PointF[] p = new PointF[]
            {
                screenpoint
            };
            mi.TransformPoints(p);            
            return p[0];
        }
    }
}

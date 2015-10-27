using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Vector
    {
        public float length, alpha;
        public PointF startPoint, endPoint;

        public Vector()
        {
            this.length = 0.001f;
            this.alpha = 0f;
            this.startPoint = new PointF(0f,0f);
            this.endPoint = new PointF(0.001f, 0.001f);
        }

        public Vector(float length, float alpha, PointF startPoint)
        {
            this.length = length;
            this.alpha = alpha;
            this.startPoint = startPoint;
            this.endPoint = this.getEndPoint();
        }

        public Vector(PointF startPoint, PointF endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.length = getLength();
            this.alpha = getAlpha();
        }

        public PointF getEndPoint()
        {
            PointF pf = new PointF((float)(this.length * Math.Cos(alpha) + this.startPoint.X), (float)(this.length * Math.Sin(alpha) + this.startPoint.Y));
            return pf;
        }

        public void changeDirection(float alpha)
        {
            this.alpha = alpha;
            this.getEndPoint();
        }

        public float getAlpha()
        {
            float dx = this.endPoint.X - this.startPoint.X;
            float dy = this.endPoint.Y - this.startPoint.Y;
            float angle = (float)Math.Atan(dy/dx);
            if ((dx < 0 && dy < 0) || (dx < 0 && dy >= 0)) angle = (float)(angle - Math.PI);
            return angle;
        }

        public float getAlpha(PointF endPoint, float length)
        {
            float dx = Math.Abs(this.endPoint.X - this.startPoint.X);
            float dy = Math.Abs(this.endPoint.Y - this.startPoint.Y);
            float angle = (float)Math.Atan(dx / dy);
            if (dx < 0) angle = (float)(angle - 3 * Math.PI);
            return angle;
        }

        public float getLength()
        {
            float lengthX = Math.Abs(this.endPoint.X - this.startPoint.X);
            float lengthY = Math.Abs(this.endPoint.Y - this.startPoint.Y);
            return (float)Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
        }

        public float getLength(PointF endPoint, PointF startPoint)
        {
            float lengthX = Math.Abs(endPoint.X - startPoint.X);
            float lengthY = Math.Abs(endPoint.Y - startPoint.Y);
            return (float)Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
        }

        public Vector sum(Vector a, Vector b)
        {
            Vector sumV = new Vector();
            sumV.startPoint = a.startPoint;
            sumV.endPoint = b.endPoint;
            sumV.length = getLength(sumV.endPoint, sumV.startPoint);
            sumV.alpha = getAlpha(sumV.endPoint, sumV.length);
            return sumV;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LifeZone
{
    class Food
    {
        public float lifeTime, value;
        public Vector pos;
        private Random rnd = new Random(DateTime.Now.Millisecond);

        public Food(int maximX, int maximY)
        {
            this.pos = new Vector(new PointF(0f,0f),new PointF((float)rnd.Next(20, maximX - 30),(float)rnd.Next(20, maximY - 30)));
            this.lifeTime = 1000;
            this.value = (float)rnd.NextDouble() * 5;
        }        
    }
}

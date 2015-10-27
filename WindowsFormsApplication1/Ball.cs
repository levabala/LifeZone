using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Ball
    {
        public float size, famine, xp, experience, speed, activity, age, visionBorder, danger, fear;
        public List<Ball> balls;
        private Random random;
        private List<Ball> command;        
        public Vector position, moving;
        //размер, голод, здоровье, опыт, скорость, активность, возраст, граница зрения, раздраженность, боязнь, x, y
        public Ball(Random rnd)
        {           
            this.size = 0.01f;
            this.famine = 0;
            this.xp = 100;
            this.experience = 0;
            this.speed = 0.1f;
            this.activity = 1;
            this.age = 0;
            this.visionBorder = 40;
            this.danger = 0;
            this.position = new Vector((float)rnd.Next(1, 400) / 1000, (float)rnd.Next(1, 15) / 1000, new PointF(0f, 0f));
            this.moving = new Vector(5f / 1000, 1f, this.position.endPoint);
            this.balls = new List<Ball>();
            this.random = rnd;
        }

        public string delegateMyself()
        {
            return "Hi! I am a Ball";
        }

        public void reloadBalls(List<Ball> lb)
        {
            lb.Remove(this);
            this.balls = lb;
        }

        public Vector groupping(List<Ball> command)
        {
            
            return new Vector();
        }        

        public void go()
        {
            this.position = this.position.sum(this.position, this.moving);
            this.moving = new Vector(this.moving.length, this.moving.alpha, this.position.endPoint);
        }

        public void move(Vector pos)
        {
            this.moving = new Vector(this.moving.length, pos.alpha, this.position.endPoint);
        }
    }
}

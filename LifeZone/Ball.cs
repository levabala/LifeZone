using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LifeZone
{    
    class Ball
    {
        public float size, famine, xp, experience, speed, activity, age, seezone, danger, fear, lifetime, yBorder, xBorder, rotateSpeed;
        //размер, голод, здоровье, опыт, скорость, активность, возраст, область зрения, боязнь, раздраженность, время жизни, зона жизни: до X и до Y
        public List<Ball> balls;
        public List<Food> foods;
        private Random random;
        private List<Ball> command;
        public Vector position, moving;
        public PointF mouse;
        public bool readyToClone, grudge, followTheMouse, young;
        public int friends;
        public Ball partner;
      
        public Ball(float bx, float by)
        {
            this.size = 10f;
            this.lifetime = 2000f;
            this.famine = 0;
            this.xp = 100;
            this.experience = 0;            
            this.activity = 1;
            this.age = 0;
            this.danger = 1;
            this.fear = 1;
            this.random = new Random(DateTime.Now.Millisecond);
            this.position = new Vector((float)this.random.Next(100, 1000), (float)this.random.Next(1, 15)/10, new PointF(0f, 0f));
            this.moving = new Vector(5f, 1f, this.position.endPoint);
            this.balls = new List<Ball>(); 
            this.foods = new List<Food>();
            this.readyToClone = false;
            this.grudge = false;
            this.seezone = 100f;
            this.friends = 0;
            this.xBorder = bx;
            this.yBorder = by;
            this.young = true;
            this.mouse = new PointF();
            this.speed = 5f + (float)(random.Next(-100, 100) / 10000);
            this.rotateSpeed = 0.1f + (float)(random.Next(-100, 100) / 10000);
        }

        public Ball(Vector posit, float bx, float by)
        {
            this.lifetime = 2000f;
            this.size = 10f;
            this.famine = 0;
            this.xp = 100;
            this.experience = 0;
            this.activity = 1;
            this.age = 0;
            this.danger = 1;
            this.fear = 1;
            this.position = posit;
            this.moving = new Vector(5f, 1f, this.position.endPoint);
            this.balls = new List<Ball>();
            this.foods = new List<Food>();
            this.random = new Random(DateTime.Now.Millisecond);
            this.readyToClone = false;
            this.grudge = false;
            this.seezone = 100f;
            this.friends = 0;
            this.xBorder = bx;
            this.yBorder = by;
            this.young = true;
            this.mouse = new PointF();
            this.speed = 5f + (float)(random.Next(-100, 100) / 10000);
            this.rotateSpeed = 0.1f + (float)(random.Next(-100, 100) / 10000);
        }

        public Ball(Vector posit, float bx, float by, Ball parent1, Ball parent2)
        {
            this.lifetime = 2000f;
            this.size = 10f;
            this.famine = 0;
            this.xp = 100;
            this.experience = 0;            
            this.activity = 1;
            this.age = 0;
            this.danger = 1;
            this.fear = 1;
            this.position = posit;
            this.moving = new Vector(5f, 1f, this.position.endPoint);
            this.balls = new List<Ball>();
            this.foods = new List<Food>();
            this.random = new Random(DateTime.Now.Millisecond);
            this.readyToClone = false;
            this.grudge = false;
            this.seezone = 100f;
            this.friends = 0;
            this.xBorder = bx;
            this.yBorder = by;
            this.young = true;
            this.mouse = new PointF();
            this.speed = (parent1.speed + parent2.speed) / 2 + (float)(random.NextDouble() - 0.5);
            this.rotateSpeed = (parent1.rotateSpeed + parent2.rotateSpeed)/2 + (float)(random.NextDouble() - 0.5)/10;
        }

        public string delegateMyself()
        {
            return "Hi! I am a Ball";
        }

        public void reloadBalls(List<Ball> lb)
        {  
            this.balls = lb;
        }

        public Vector groupping()
        {
            if (this.balls.Count <= 0) return new Vector();
            float avX = 0f;
            float avY = 0f;
            Parallel.ForEach(balls, b =>
            //foreach (Ball b in this.balls)
            {
                avX += b.position.endPoint.X;
                avY += b.position.endPoint.Y;
            });
            avX = avX / this.balls.Count;
            avY = avY / this.balls.Count;
            
            Vector rally = new Vector(this.position.endPoint, new PointF(avX, avY));
            this.move(rally);
            return new Vector();// rally;
        }

        public void go()
        {            
            this.position = this.position.sum(this.position, this.moving);
            this.moving = new Vector(this.moving.length, this.moving.alpha, this.position.endPoint);
            this.famine += 0.01f;
        }        

        public void move(Vector pos)
        {
            this.moving = new Vector(this.moving.length, pos.alpha, this.position.endPoint);
        }

        public void speedCalc()
        {
            this.moving.length = this.fear + this.danger;// +(float)(random.Next() - 0.5) * 2;
        }

        public void setMoveToClosest()
        {
            try
            {
                Vector dist = balls[0].position;
                Ball targetBall = balls[0];
                this.friends = 0;
                Parallel.ForEach(balls, b =>
                //foreach (Ball b in balls)
                {
                    if (b != null)
                    {
                        Vector thisDist = new Vector(this.position.endPoint, b.position.endPoint);
                        if (thisDist.length <= this.seezone)
                        {
                            this.friends++;
                        }
                        if (b.position != this.position && b.young && !b.grudge)
                        {
                            if (thisDist.length < dist.length)
                            {
                                dist = thisDist;
                                targetBall = b;
                            }
                        }
                    }
                });
                if (this.moving.alpha >= dist.alpha) this.moving.alpha -= this.rotateSpeed;
                else this.moving.alpha += this.rotateSpeed;
                if (this.size / 2 + targetBall.size / 2 >= dist.length)
                {
                    this.moving.length = -this.moving.length;
                    this.size += 0.1f;
                    if (this.size >= 20f)
                    {
                        this.readyToClone = true;
                        this.partner = targetBall;
                    }                    
                }
                this.fear += (float)this.friends / 200;
            }
            catch(NullReferenceException)
            {
                
            }
        }

        public void chaoticMovement()
        {
            this.moving.alpha += random.Next(0, 3140)/10000;
            this.moving.length = 2f;
            this.fear -= 0.01f;
            if (this.fear + this.danger <= 4)
            {
                this.moving.length = this.speed;
                this.grudge = false;
                this.fear = 1f;
            }
        }

        public void checkLifeBorders()
        {
            Vector bx1 = new Vector(new PointF(Math.Abs(this.position.endPoint.X), Math.Abs(this.position.endPoint.Y)), new PointF(xBorder-10, this.position.endPoint.Y));
            Vector bx2 = new Vector(new PointF(Math.Abs(this.position.endPoint.X), Math.Abs(this.position.endPoint.Y)), new PointF(0, this.position.endPoint.Y));
            Vector by1 = new Vector(new PointF(Math.Abs(this.position.endPoint.X), Math.Abs(this.position.endPoint.Y)), new PointF(this.position.endPoint.X, 0));
            Vector by2 = new Vector(new PointF(Math.Abs(this.position.endPoint.X), Math.Abs(this.position.endPoint.Y)), new PointF(this.position.endPoint.X, yBorder-10));
            if (this.size * 2 >= bx1.length)
            {
                this.moving.alpha = (float)Math.PI - bx1.alpha;
                this.moving.length = 5f;
            }
            if (this.size * 2 >= bx2.length)
            {
                this.moving.alpha = (float)Math.PI - bx2.alpha;
                this.moving.length = 5f;
            }
            if (this.size * 2 >= by1.length)
            {
                this.moving.alpha = by1.alpha + (float)Math.PI / 2;    //Тут почему-то всё ок...
                this.moving.length = 5f;
            }
            if (this.size * 2 >= by2.length)
            {
                this.moving.alpha = by2.alpha +(float)Math.PI * 1.5f;
                this.moving.length = 5f;
            }
        }

        public void followToMouse()
        {
            this.moving.alpha = new Vector(this.position.endPoint, mouse).alpha;
        }

        public void findFood()
        {
            if (this.foods.Count > 0)
            {
                Vector dist = new Vector(this.position.endPoint, this.foods[0].pos.endPoint);
            }
        }

        public void lifeTick()
        {
            if (this.age < this.lifetime * 0.6f)
            {
                if (this.famine < 5)
                {                    
                    speedCalc(); //Делаем непостоянность в движении и задаём скорость            
                    if (danger + fear < 5 && !grudge && young) setMoveToClosest(); //Находим наиблизлежащего и задаём направление к нему
                    else
                    {
                        this.grudge = true;
                        chaoticMovement(); //Ну а если все нам надоели - гулять!
                    }
                }
                else
                {
                    this.famine = 0f;
                }
            }
            else
            {
                this.speed = 1f;
                chaoticMovement();
                this.young = false;
            }
            if (followTheMouse) followToMouse();                
            checkLifeBorders();
            go();  //двигаемся
            this.age++;
        }
    }
}

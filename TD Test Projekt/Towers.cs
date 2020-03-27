using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class Towers : GameObject
    {
        protected Student target;
        protected int cost;
        protected int heal;

        protected float radius;

        public Student Target
        {
            get { return target; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public int Heal
        {
            get { return heal; }
        }

        public float Radius
        {
            get { return radius; }
        }

        public Towers(Texture2D texture, Vector2 position):base(texture,position)
        {
            radius = 1000;

        }

        public bool IsInRange(Vector2 position)
        {
            if (Vector2.Distance(center, position) <= radius)
                return true;
            return false;
        }


        public void GetClosestStudent(List<Student> students)
        {
            target = null;
            float shortestRange = radius;

            foreach (Student student in students)
            {
                if (Vector2.Distance(center, student.Center)< shortestRange)
                {
                    shortestRange = Vector2.Distance(center, student.Center);
                    target = student;
                }
            }
        }

        protected void FaceTarget()
        {
            Vector2 direction = center - target.Center;
            direction.Normalize();

            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (target != null)
                FaceTarget();
        }

    }
}

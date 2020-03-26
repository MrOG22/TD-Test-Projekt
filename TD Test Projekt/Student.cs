using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class Student : GameObject
    {
        float startHealth = 100;
        float currentHealth;
        bool isAlive = true;
        float speed = 0.5f;
        bool buffGiven = false;
        bool isHit = false;
        private Queue<Vector2> waypoints = new Queue<Vector2>();


        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }

        }

        public bool IsDead
        {
            get { return !isAlive; }
        }

        public bool BuffGiven
        {
            get { return buffGiven; }

        }

        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }

        public Student(Texture2D texture, Vector2 position, float health, bool buffGiven, float speed) : base(texture, position)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.buffGiven = buffGiven;
            this.speed = speed;

        }

        public void SetWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);
            this.position = this.waypoints.Dequeue();
        }


        public override void Update(GameTime gameTime)
        {
            //base.Update(gameTime);

            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < speed)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();
                    velocity = Vector2.Multiply(direction, speed);
                    position += velocity;

                }
            }

            else
                isAlive = false;

            base.Update(gameTime);
        }







    }

}

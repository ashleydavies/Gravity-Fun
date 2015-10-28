using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Demo {
    class Body {
        public static double G = 6.67e-11;

        protected Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }
        public Vector2 CenterOfMass { get { return Position + Size / 2; } }
        public Rectangle OccupiedRectangle { get { return new Rectangle(Position, Size); } }
        public Vector2 Size;
        public double Mass;
        public double Rotation;
        public Vector2 Acceleration;
        public Vector2 Velocity;
        public bool Anchored;
        private Vector2 Force;

        public Body(Vector2 Position, Vector2 Size, double Mass, double Rotation = 0) {
            this.Position = Position;
            this.Size = Size;
            this.Mass = Mass;
            this.Rotation = Rotation;

            this.Force = new Vector2(0, 0);
            this.Velocity = new Vector2(0, 0);
            this.Acceleration = new Vector2(0, 0);
        }

        public void Update(double dt) {
            if (!Anchored) {
                Acceleration = Force / Mass;

                Velocity += Acceleration * dt;
                Position += Velocity * dt;
            }
        }

        public void CalculateForce(double dt, List<Body> bodies) {
            if (!Anchored) {
                Vector2 ForceG = new Vector2(0, 0);
                Vector2 ForceN = new Vector2(0, 0);
                
                // Calculate the gravitation force
                foreach (Body body in bodies) {
                    double angle = (CenterOfMass - body.CenterOfMass).Angle;
                    double GMM = G * Mass * body.Mass;
                    double rS = Math.Pow((CenterOfMass - body.CenterOfMass).Length, 2);
                    if (rS != 0) {
                        ForceG += Vector2.FromPolar(angle, GMM / rS);
                    }
                }
                
                // Apply normal force
                foreach (Body body in bodies) {
                    if (body == this)
                        continue;
                    // Check if normal force is applicable
                    if (this.OccupiedRectangle.Intersects(body.OccupiedRectangle)) {
                        Debug.WriteLine("COLLISION");
                        // Neutralise any component of the force pointing at this body
                        double angle = (CenterOfMass - body.CenterOfMass).Angle;
                        ForceN += Vector2.FromPolar(-angle, ForceG.AngularComponent(angle).Length);

                        // If we're colliding, stop the velocity in that direction
                        Velocity = Velocity.SetAngle(-angle);

                        Debug.WriteLine(ForceN);
                    }
                }
                
                Force = ForceG;
                Force += ForceN;
            }
        }
    }
}

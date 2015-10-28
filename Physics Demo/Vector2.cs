using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Demo {
    class Vector2 {
        public readonly double X;
        public readonly double Y;
        public double Length {
            get {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }
        public double Angle {
            get {
                return -Math.Atan2(Y, X);
            }
        }

        public static Vector2 FromPolar(double angle, double magnitude) {
            return new Vector2(magnitude * -Math.Cos(angle), magnitude * Math.Sin(angle));
        }

        public Vector2(double X, double Y) {
            this.X = X;
            this.Y = Y;
        }

        public Vector2 Normalize() {
            return new Vector2(X / Length, Y / Length);
        }

        public Vector2 SetAngle(double angle) {
            return new Vector2( Length * Math.Cos(angle), Length * Math.Sin(angle) );
        }

        public Vector2 AngularComponent(double angle) {
            double m = Length * Math.Cos(angle);
            return new Vector2( m * Math.Cos(angle), m * Math.Sin(angle));
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, int s) {
            return new Vector2(v1.X * s, v1.Y * s);
        }

        public static Vector2 operator *(int s, Vector2 v1) {
            return new Vector2(v1.X * s, v1.Y * s);
        }

        public static Vector2 operator *(Vector2 v1, double s) {
            return new Vector2(v1.X * s, v1.Y * s);
        }

        public static Vector2 operator /(Vector2 v1, int s) {
            return new Vector2(v1.X / s, v1.Y / s);
        }

        public static Vector2 operator /(Vector2 v1, double s) {
            return new Vector2(v1.X / s, v1.Y / s);
        }

        public static Vector2 operator /(double s, Vector2 v1) {
            return new Vector2(v1.X / s, v1.Y / s);
        }

        public override string ToString() {
            return "Vec2[ " + X + ", " + Y + " ]";
        }
    }
}

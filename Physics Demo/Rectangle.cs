using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Physics_Demo {
    class Rectangle {
        public Vector2 Position;
        public Vector2 Size;

        public Rectangle(Vector2 Position, Vector2 Size) {
            this.Position = Position;
            this.Size = Size;
        }

        public bool Intersects(Rectangle other) {
            // Check corners of this rectangle to see if any are inside other's

            // A----B
            // |    |
            // C----D

            // A, B
            if (Position.X >= other.Position.X && Position.X <= other.Position.X + other.Size.X) {
                // A
                if (Position.Y >= other.Position.Y && Position.Y <= other.Position.Y + other.Size.Y) {
                    Debug.WriteLine("A");
                    return true;
                }
                // B
                else if (Position.Y + Size.Y >= other.Position.Y && Position.Y + Size.Y <= other.Position.Y + other.Size.Y) {
                    Debug.WriteLine("B");
                    return true;
                }
            }
            // C, D
            else if (Position.X + Size.X >= other.Position.X && Position.X + Size.X <= other.Position.X + other.Size.X) {
                // C
                if (Position.Y >= other.Position.Y && Position.Y <= other.Position.Y + other.Size.Y) {
                    Debug.WriteLine("C");
                    return true;
                }
                // D
                else if (Position.Y + Size.Y >= other.Position.Y && Position.Y + Size.Y <= other.Position.Y + other.Size.Y) {
                    Debug.WriteLine("D");
                    return true;
                }
            }

            return false;
        }
    }
}

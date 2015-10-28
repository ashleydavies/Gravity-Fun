using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Physics_Demo {
    class DrawableBody {
        public System.Windows.Shapes.Rectangle DrawRectangle;
        public Body Body;
        private readonly Canvas Canvas;

        public DrawableBody(Canvas Canvas, Body Body) {
            this.Canvas = Canvas;
            this.Body = Body;
            this.DrawRectangle = new System.Windows.Shapes.Rectangle();

            DrawRectangle.Fill = new SolidColorBrush(Colors.Black);

            Canvas.Children.Add(DrawRectangle);
        }

        public void Update() {
            Canvas.SetLeft(DrawRectangle, (double) Body.Position.X);
            Canvas.SetTop(DrawRectangle, (double) Body.Position.Y);

            DrawRectangle.Width = (double) Body.Size.X;
            DrawRectangle.Height = (double) Body.Size.Y;
            DrawRectangle.RenderTransform = new RotateTransform((double) Body.Rotation, (double) Body.Size.X / 2, (double) Body.Size.Y / 2);
        }
    }
}

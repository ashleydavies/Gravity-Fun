using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Physics_Demo {
    public partial class MainWindow : Window {
        private List<DrawableBody> DrawableBodies;
        private List<Body> Bodies;
        private Stopwatch Stopwatch;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Bodies = new List<Body>();
            DrawableBodies = new List<DrawableBody>();
            Stopwatch = new Stopwatch();
            /*
            Bodies.Add(new Body(
                new Vector2(30, 30),
                new Vector2(3, 3),
                1e11
            ));*/

            Bodies.Add(new Body(
                new Vector2(400, 350),
                new Vector2(1, 1),
                1e10
            ) { Velocity = new Vector2(0, 0) });
            /*
            Bodies.Add(new Body(
                new Vector2(180, 350),
                new Vector2(10, 10),
                1e2
            ) { Velocity = new Vector2(0, 11) });
            */
            Bodies.Add(new Body(
                new Vector2(500, 350),
                new Vector2(15, 15),
                1.499250375e12
            ) { Velocity = new Vector2(0, 0), Anchored = false });
            
            Bodies.ForEach(x => DrawableBodies.Add(new DrawableBody(Canvas, x)));

            Stopwatch.Start();

            CompositionTarget.Rendering += Rendering;
        }

        private TimeSpan lastTickTime;

        void Rendering(object sender, EventArgs e) {
            double dt = (double) Stopwatch.Elapsed.TotalSeconds / 1000;
            for (int i = 0; i < 10; i++) {
                Bodies.ForEach(x => x.Update(dt));
                Bodies.ForEach(x => x.CalculateForce(dt, Bodies));
                DrawableBodies.ForEach(x => x.Update());
            }
            lastTickTime = Stopwatch.Elapsed;
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            Body newPlanet = new Body(
                new Vector2(Mouse.GetPosition(this).X, Mouse.GetPosition(this).Y),
                new Vector2(5, 5),
                1e6
            ) { Velocity = new Vector2(0, 0) };
            Bodies.Add(newPlanet);
            DrawableBodies.Add(new DrawableBody(Canvas, newPlanet));

        }
    }
}

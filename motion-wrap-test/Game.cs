// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        Vector2 circlePos = new(100, 100);

        float circleRad = 50.0f;

        Vector2 ufoPos = new(200, 200);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("motion");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);

            MoveCircle();
            MoveUFO();

            DrawCircle();
            DrawUFO();
        }

        void MoveCircle()
        {

            // makes the circle chase the mouse at 200 pps
            Vector2 circleToMouse = Input.GetMousePosition() - circlePos;
            Vector2 circleVel = Vector2.Normalize(circleToMouse) * 200;

            // moves the circle at a stable amount (NOT SYNCED TO FPS (kinda))
            circlePos += circleVel * Time.DeltaTime;

            // makes the circle wrap
            // circle goes to 0 when it gets to the end of screen
            if (circlePos.X > Window.Width + circleRad)
            {
                circlePos.X = -circleRad;
            }
        }

        void DrawCircle()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.OffWhite;
            Draw.Circle(circlePos, circleRad);
        }

        void MoveUFO()
        {
            Vector2 ufoMotion = new Vector2();
            ufoMotion.X = 100 * MathF.Sin(Time.SecondsElapsed);
            ufoMotion.Y = 100 * MathF.Cos(3 * Time.SecondsElapsed);
            ufoPos = new Vector2(200, 200) + ufoMotion;
        }

        void DrawUFO()
        {
            Draw.LineSize = 0;
            Draw.FillColor = new Color("#66BFFE");
            Draw.Circle(ufoPos, 20);

            Draw.LineSize = 0;
            Draw.FillColor = new Color("#C77AFE");
            Draw.Ellipse(ufoPos + new Vector2(0, 20), new Vector2(100, 40));

            Vector2 bottomPos = ufoPos + new Vector2(0, 30);

            Draw.FillColor = new Color("#701F7E");
            Draw.Ellipse(bottomPos, new Vector2(70, 20));

            Draw.LineSize = 4;
            Draw.FillColor = Color.Clear;
            Draw.LineColor = Color.Green;

            Vector2 p1 = bottomPos;
            Vector2 p2 = bottomPos + new Vector2(20, 80);
            Vector2 p3 = bottomPos + new Vector2(-20, 80);

            Draw.Triangle(p1, p2, p3);
        }
    }

}

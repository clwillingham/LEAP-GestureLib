using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap;


namespace LEAPTest2
{
    class GestureListener : Listener
    {
        public delegate void GestureEvent(Gesture gesture);

        public event GestureEvent onGesture;

        public float sensitivity { get; set; }

        public GestureListener(int sensitivity)
        {
            this.sensitivity = sensitivity;
        }

        public override void OnConnect(Controller controller)
        {
            Console.WriteLine("Connected");
        }

        public override void OnDisconnect(Controller controller)
        {
            Console.WriteLine("Disconnected");
        }
        public override void OnExit(Controller controller)
        {
            Console.WriteLine("Exited");
        }
        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();
            // Get the first hand
            Hand hand = frame.Hands[0];

            // Check if the hand has any fingers
            FingerList fingers = hand.Fingers;
            if (!fingers.Empty)
            {
                // Calculate the hand's average finger tip position
                Vector avgPos = Vector.Zero;
                Vector avgVelocity = Vector.Zero;
                foreach (Finger finger in fingers)
                {
                    avgPos += finger.TipPosition;
                    avgVelocity += finger.TipVelocity;
                }
                avgPos /= fingers.Count;
                avgVelocity /= fingers.Count;
                List<Gesture.Direction> directions = new List<Gesture.Direction>();

                if (avgVelocity.y > sensitivity)
                {
                    directions.Add(Gesture.Direction.Up);
                }
                else if (avgVelocity.y < -sensitivity)
                {
                    directions.Add(Gesture.Direction.Down);
                }

                if (avgVelocity.x > sensitivity)
                {
                    directions.Add(Gesture.Direction.Right);
                }
                else if (avgVelocity.x < -sensitivity)
                {
                    directions.Add(Gesture.Direction.Left);
                }


                if (avgVelocity.z > sensitivity)
                {
                    directions.Add(Gesture.Direction.Backward);
                }
                else if (avgVelocity.z < -sensitivity)
                {
                    directions.Add(Gesture.Direction.Forward);
                }

                if (directions.Count > 0)
                {
                    Gesture gesture = new Gesture(directions.ToArray(), fingers.Count);
                    onGesture(gesture);
                }

                //Console.WriteLine("Hand has " + fingers.Count
                //            + " fingers, average finger tip Velocity: " + avgVelocity);
            }
        }
        public override void OnInit(Controller controller)
        {
            Console.WriteLine("Initialized");
        }
    }
}

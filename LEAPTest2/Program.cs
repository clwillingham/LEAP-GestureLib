using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEAPTest2
{
    class Program : Listener
    {
        static void Main(string[] args)
        {
            GestureListener listener = new GestureListener(1500);
            listener.onGesture += listener_onGesture;
            Controller controller = new Controller(listener);

            Console.ReadLine();
            Console.WriteLine("finished?"); // just making sure
            Console.ReadLine();

            controller.RemoveListener(listener);
            controller.Dispose();
        }

        static void listener_onGesture(Gesture gesture)
        {
            string gestures = "";
            foreach (Gesture.Direction direction in gesture.directions)
            {
                gestures += direction.ToString() + ", ";
            }
            Console.WriteLine("gestured " + gestures + " with " + gesture.fingers + " fingers.");
        }
    }
}

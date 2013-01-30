LEAP-GestureLib
===============

A simple .net library to handle basic gesture recognition for the LEAP motion sensor

This Library is nowhere near finished, and more of a concept than a full on gesture recognition library. my goal was to find a simple way to identify and describe common gestures (mostly swipes)

Basic usage: 

```C#
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
```
		
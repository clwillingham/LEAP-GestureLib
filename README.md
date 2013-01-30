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
short note about directions in a gesture object. at the moment a gesture has 6 directions (forward, backward, left, right, up, down).
a gesture can have combinations of directions if for instance you where to swipe  your hand forward and to the left, both forward and left would go into the directions object.

Whats next?
-----------
top priority is to have the events only trigger once per gesture. so that when you swipe your hand up, it triggers only one event, not 20.
after thats sorted out, next part would be tracking multiple hands.
not really sure what to do next, but i'm sure theres some cool stuff you could do with a system like this.
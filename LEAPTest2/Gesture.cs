using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap;

namespace LEAPTest2
{
    class Gesture
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down,
            Forward,
            Backward
        }
        public Direction[] directions { get; set; }
        public int fingers { get; set; }

        public Gesture(Direction[] directions, int fingers)
        {
            this.fingers = fingers;
            this.directions = directions;
        }

    }
}

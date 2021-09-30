using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Entities
{
    public class Plateau
    {
        public Plateau(int xPos,int yPos)
        {
            upperRightCoordinates = new Coordinate(xPos, yPos);
        }
        public Coordinate upperRightCoordinates { get; set; }
    }
}

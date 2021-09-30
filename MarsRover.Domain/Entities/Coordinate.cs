using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Entities
{
    public class Coordinate
    {
        public Coordinate()
        {

        }
        public Coordinate(int xPos,int yPos)
        {
            xPosition = xPos;
            yPosition = yPos;
        }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
    }
}

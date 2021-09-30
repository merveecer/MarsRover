using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Entities
{
    public class Rover
    {
        public Rover(int xPos,int yPos, string direction)
        {
            startPosition = new Coordinate(xPos, yPos);
            currentPosition = new Coordinate(xPos, yPos);
            Direction = direction;
        }

        public Coordinate currentPosition { get; set; }
        public Coordinate startPosition { get; set; }
        public int Id { get; set; }
        public string Instructions { get; set; }
        public string Direction { get; set; }
    }
}

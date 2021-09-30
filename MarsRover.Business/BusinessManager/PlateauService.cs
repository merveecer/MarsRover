using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.BusinessManager
{
    public class PlateauService : IPlateauService
    {
        public string[] TakePlateauCoordinate()
        {
            bool result = false;
            string input = "";
            string[] inputs;
            do
            {
                input = Console.ReadLine().Trim();
                inputs = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                result = ValidatePlateauCoordinate(inputs);
                if (!result) Console.WriteLine("Invalid Plateau Coordinates. Plateau must be in the upper-right of the coordinate system. Please enter coordinates again");
            }
            while (!result);

            return inputs;
        }
        public Plateau ConfigurePlateau(string[] plateauInfo)
        {
            var coordinate = new Coordinate(Convert.ToInt32(plateauInfo[0]), Convert.ToInt32(plateauInfo[1]));
            return CreatePlateau(coordinate);

        }
        public Plateau CreatePlateau(Coordinate upperRightCoordinate)
        {
            Plateau plateau = new Plateau(upperRightCoordinate.xPosition, upperRightCoordinate.yPosition);
            return plateau;
        }
        public bool ValidatePlateauCoordinate(string[] coordinate)
        {
            string allowedPostions = "123456789";
            if (coordinate.Length == 0 || coordinate.Length != 2)
                return false;
            if (!allowedPostions.Contains(coordinate[0]) || !allowedPostions.Contains(coordinate[1]))
                return false;
            return true;
        }
    }
}

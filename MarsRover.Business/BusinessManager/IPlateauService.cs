using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.Helper.Enums.Enums;

namespace MarsRover.Business.BusinessManager
{
    public interface IPlateauService
    {
        string[] TakePlateauCoordinate();

        Plateau ConfigurePlateau(string[] plateauInfo);
        Plateau CreatePlateau(Coordinate upperRightCoordinate);
        bool ValidatePlateauCoordinate(string[] coordinate);
    }
}

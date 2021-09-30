using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.Helper.Enums.Enums;

namespace MarsRover.Business.BusinessManager
{
    public interface IRoverService
    {
        string[] TakeRoverInformation(Plateau plateau);
        void SetRoverInstructions(ref Rover rover);
        void SetRoverDirection(ref Rover rover, string direction);

        Rover CreateRover(Coordinate initialCoordinate, string direction);
        Rover ConfigureRover(string[] information);
        bool Move(ref Rover rover, int directionIndex, Plateau plateau);
        int ChangeOrientation(char newDirection, int indexOfDirection);

        bool ApplyInstructions(ref Rover rover, Plateau plateau);
        void Execute(Rover firstRover, Rover secondRover, Plateau plateau);
        #region Validations and Controls
        bool ValidateInstructions(string instructions);
        bool ValidateRoverInputs(string[] roverInput);
        bool CheckRoverPosition(int xPosition, int yPosition, Plateau plateau);
        #endregion
    }
}

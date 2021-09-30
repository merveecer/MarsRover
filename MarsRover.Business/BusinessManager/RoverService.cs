using MarsRover.Domain.Entities;
using MarsRover.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.Helper.Enums.Enums;

namespace MarsRover.Business.BusinessManager
{
    public class RoverService : IRoverService
    {
        public string[] TakeRoverInformation(Plateau plateau)
        {
            bool result = false;
            bool isChecked = false;
            string input = "";
            string[] inputs;
            do
            {
                input = Console.ReadLine().Trim();
                inputs = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                result = ValidateRoverInputs(inputs);
                if (!result) Console.WriteLine("Invalid Rover Inputs. Please enter rover inputs again");
                isChecked = CheckRoverPosition(Convert.ToInt32(inputs[0]), Convert.ToInt32(inputs[1]), plateau);
                if (!isChecked) Console.WriteLine("The first position of the rover must be within the boundaries of the plateau. Please enter rover inputs again");

            }
            while (!result || !isChecked);
            return inputs;
        }
        public void SetRoverInstructions(ref Rover rover)
        {
            bool result = false;
            string instructions = "";
            do
            {
                instructions = Console.ReadLine().Trim();
                result = ValidateInstructions(instructions);
                if (!result) Console.WriteLine("Invalid Instruction. Please enter instruction again");
            }
            while (!result);

            rover.Instructions = instructions;
        }
        public void SetRoverDirection(ref Rover rover, string direction)
        {
            rover.Direction = direction;
        }

        public Rover CreateRover(Coordinate initialCoordinate, string direction)
        {
            Rover rover = new Rover(initialCoordinate.xPosition, initialCoordinate.yPosition, direction);
            return rover;
        }
        public Rover ConfigureRover(string[] information)
        {
            var coordinate = new Coordinate(Convert.ToInt32(information[0]), Convert.ToInt32(information[1]));
            var rover = CreateRover(coordinate, information[2]);

            SetRoverInstructions(ref rover);
            return rover;
        }
        public bool Move(ref Rover rover, int directionIndex, Plateau plateau)
        {
            switch (directionIndex)
            {
                case 0:
                    rover.currentPosition.yPosition++;
                    return CheckRoverPosition(rover.currentPosition.xPosition, rover.currentPosition.yPosition, plateau);

                case 1:
                    rover.currentPosition.xPosition--;
                    return CheckRoverPosition(rover.currentPosition.xPosition, rover.currentPosition.yPosition, plateau);

                case 2:
                    rover.currentPosition.yPosition--;
                    return CheckRoverPosition(rover.currentPosition.xPosition, rover.currentPosition.yPosition, plateau);

                case 3:
                    rover.currentPosition.xPosition++;
                    return CheckRoverPosition(rover.currentPosition.xPosition, rover.currentPosition.yPosition, plateau);

                default:
                    return false;

            }
        }
        public int ChangeOrientation(char newDirection, int indexOfDirection)
        {
            if (newDirection == 'L')
            {
                indexOfDirection = indexOfDirection + 1;
                if (indexOfDirection > 3)
                {
                    indexOfDirection = indexOfDirection % 4;
                }
                if (indexOfDirection < 0)
                {
                    if (indexOfDirection < -4)
                    {
                        indexOfDirection = indexOfDirection % 4;
                    }
                    indexOfDirection = indexOfDirection + 4;
                }
            }
            if (newDirection == 'R')
            {
                indexOfDirection = indexOfDirection - 1;
                if (indexOfDirection > 3)
                {
                    indexOfDirection = indexOfDirection % 4;
                }
                if (indexOfDirection < 0)
                {
                    if (indexOfDirection < -4)
                    {
                        indexOfDirection = indexOfDirection % 4;
                    }
                    indexOfDirection = indexOfDirection + 4;
                }
            }
            return indexOfDirection;

        }
        public bool ApplyInstructions(ref Rover rover, Plateau plateau)
        {
            var result = true;
            var directionEnum = Enums.GetValueFromDescription<Direction>(rover.Direction);
            int indexOfDirection = (int)directionEnum;
            foreach (var i in rover.Instructions)
            {
                switch (i)
                {
                    case 'M':
                        result = Move(ref rover, indexOfDirection, plateau);
                        if (!result) return result;
                        SetRoverDirection(ref rover, Helper.Helper.GetDirectionNameByIndex(indexOfDirection));
                        break;

                    case 'L':
                    case 'R':
                        indexOfDirection = ChangeOrientation(i, indexOfDirection);
                        break;
                    default:
                        break;
                }

            }
            return result;

        }
        public void Execute(Rover firstRover, Rover secondRover, Plateau plateau)
        {
            var result1 = ApplyInstructions(ref firstRover, plateau);
            var result2 = ApplyInstructions(ref secondRover, plateau);
            Console.WriteLine(result1 ? (firstRover.currentPosition.xPosition + " " + firstRover.currentPosition.yPosition + " " + firstRover.Direction) : "First Rover is overflowed");
            Console.WriteLine(result2 ? (secondRover.currentPosition.xPosition + " " + secondRover.currentPosition.yPosition + " " + secondRover.Direction) : "Second Rover is overflowed");
        }
        #region Validations and Controls
        public bool ValidateInstructions(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
                return false;
            string allowedInstructionLetter = "LMR";
            foreach (var letter in instructions)
            {
                if (!allowedInstructionLetter.Contains(letter))
                    return false;
            }
            return true;
        }
        public bool ValidateRoverInputs(string[] roverInput)
        {
            string allowedDirections = "NWSE";
            string allowedPostions = "0123456789";

            if (roverInput.Length == 0 || roverInput.Length != 3)
                return false;
            if (!allowedPostions.Contains(roverInput[0]) || !allowedPostions.Contains(roverInput[1]) || !allowedDirections.Contains(roverInput[2]))
                return false;
            return true;
        }
        public bool CheckRoverPosition(int xPosition, int yPosition, Plateau plateau)
        {
            return (xPosition > plateau.upperRightCoordinates.xPosition || yPosition > plateau.upperRightCoordinates.yPosition || xPosition < 0 || yPosition < 0) == true ? false : true;
        }
        #endregion
    }
}

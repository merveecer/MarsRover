using FluentAssertions;
using MarsRover.Business.BusinessManager;
using MarsRover.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MarsRover.UnitTest.UnitTests
{
    public partial class UnitTest
    {

        [Fact]
        public void CreateRover_ReturnsValidRover()
        {
            Coordinate roverCoordinate = new Coordinate();
            roverCoordinate.xPosition = 5;
            roverCoordinate.yPosition = 5;
            var sut = new RoverService();

            var result = sut.CreateRover(roverCoordinate, "N");

            result.currentPosition.xPosition.Should().Be(5);
            result.currentPosition.yPosition.Should().Be(5);
            result.startPosition.xPosition.Should().Be(5);
            result.startPosition.yPosition.Should().Be(5);
            result.Direction.Should().Be("N");
        }

        [Fact]
        public void Move_ReturnsInvalidRoverMoving()
        {
            Coordinate plateauCoordinate = new Coordinate();
            plateauCoordinate.xPosition = 5;
            plateauCoordinate.yPosition = 5;
            Coordinate roverCoordinate = new Coordinate();
            roverCoordinate.xPosition = 5;
            roverCoordinate.yPosition = 6;
            Rover rover = new Rover(roverCoordinate.xPosition, roverCoordinate.yPosition, "N");
            Plateau plateau = new Plateau(plateauCoordinate.xPosition, plateauCoordinate.yPosition);
            var sut = new RoverService();

            var result = sut.Move(ref rover, 0, plateau);

            result.Should().BeFalse();

        }
        [Fact]
        public void Execute_ReturnsSuccessfulForFirstRover()
        {
            Coordinate plateauCoordinate = new Coordinate();
            plateauCoordinate.xPosition = 5;
            plateauCoordinate.yPosition = 5;
            Coordinate roverCoordinate = new Coordinate();
            roverCoordinate.xPosition = 1;
            roverCoordinate.yPosition = 2;

            Rover rover = new Rover(roverCoordinate.xPosition, roverCoordinate.yPosition, "N");

            Plateau plateau = new Plateau(plateauCoordinate.xPosition, plateauCoordinate.yPosition);
            var sut = new RoverService();
            var input = new StringReader("LMLMLMLMM");
            Console.SetIn(input);
            sut.SetRoverInstructions(ref rover);
            var result = sut.ApplyInstructions(ref rover, plateau);

            result.Should().BeTrue();
            rover.currentPosition.xPosition.Should().Be(1);
            rover.currentPosition.yPosition.Should().Be(3);
            rover.Direction.Should().Be("N");

        }
        [Fact]
        public void Execute_ReturnsSuccessfulForSecondRover()
        {
            Coordinate plateauCoordinate = new Coordinate();
            plateauCoordinate.xPosition = 5;
            plateauCoordinate.yPosition = 5;
            Coordinate roverCoordinate = new Coordinate();
            roverCoordinate.xPosition = 3;
            roverCoordinate.yPosition = 3;


            Rover rover = new Rover(roverCoordinate.xPosition, roverCoordinate.yPosition, "E");
            Plateau plateau = new Plateau(plateauCoordinate.xPosition, plateauCoordinate.yPosition);
            var sut = new RoverService();
            var input = new StringReader("MMRMMRMRRM");
            Console.SetIn(input);
            sut.SetRoverInstructions(ref rover);
            var result = sut.ApplyInstructions(ref rover, plateau);

            result.Should().BeTrue();
            rover.currentPosition.xPosition.Should().Be(5);
            rover.currentPosition.yPosition.Should().Be(1);
            rover.Direction.Should().Be("E");

        }

    }
}

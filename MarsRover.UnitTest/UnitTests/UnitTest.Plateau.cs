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
        public void TakePlateauCoordinate_ReturnsTrue()
        {
            mockPlateauService.Setup(x => x.ValidatePlateauCoordinate(It.IsAny<string[]>())).Returns(true);
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("5 5");
            Console.SetIn(input);

            var sut = new PlateauService();

            var result = sut.TakePlateauCoordinate();

            result.Length.Should().BeGreaterThan(0);


        }
        [Fact]
        public void ConfigurePlateau_ReturnsTrue()
        {
            mockPlateauService.Setup(x => x.ValidatePlateauCoordinate(It.IsAny<string[]>())).Returns(true);
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("5 5");
            Console.SetIn(input);

            var sut = new PlateauService();

            var coordinateArray = sut.TakePlateauCoordinate();
            var result = sut.ConfigurePlateau(coordinateArray);

            result.Should().NotBeNull();
            result.upperRightCoordinates.xPosition.Should().Be(5);
            result.upperRightCoordinates.yPosition.Should().Be(5);


        }
        [Fact]
        public void ConfigurePlateau_ReturnsFalse()
        {
            mockPlateauService.Setup(x => x.ValidatePlateauCoordinate(It.IsAny<string[]>())).Returns(true);
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("5 2");
            Console.SetIn(input);

            var sut = new PlateauService();

            var coordinateArray = sut.TakePlateauCoordinate();
            var result = sut.ConfigurePlateau(coordinateArray);

            result.Should().NotBeNull();
            result.upperRightCoordinates.Should().NotBe(new Coordinate(5, 3));
        }
       
        
       

    }
}

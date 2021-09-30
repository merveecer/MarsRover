using MarsRover.Business.BusinessManager;
using MarsRover.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    class Program
    {
       
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            var roverService = _serviceProvider.GetService<IRoverService>();
            var plateauService = _serviceProvider.GetService<IPlateauService>();

            var plateauInfo= plateauService.TakePlateauCoordinate();
            var plateau=plateauService.ConfigurePlateau(plateauInfo);

            var firstRoverInfo = roverService.TakeRoverInformation(plateau);
            Rover firstRover = roverService.ConfigureRover(firstRoverInfo);

            var secondRoverInfo = roverService.TakeRoverInformation(plateau);
            Rover secondRover = roverService.ConfigureRover(secondRoverInfo);

            roverService.Execute(firstRover, secondRover,plateau);
            DisposeServices();
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IPlateauService,PlateauService>()
                .BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}

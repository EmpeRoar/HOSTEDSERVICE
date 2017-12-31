using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICEPROVIDER
{
    public class DataRefreshService : BackgroundService
    {
        private readonly IPokePerson _pokePerson;
        private readonly ILogger<DataRefreshService> _logger;
        public DataRefreshService(ILogger<DataRefreshService> logger, IPokePerson pokePerson)
        {
            _logger = logger;
            _pokePerson = pokePerson;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogCritical($"DataRefreshService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogCritical($" DataRefreshService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {

                _pokePerson.Poke(stoppingToken);
                //_personService.AddToDbBackground(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogCritical($"DataRefreshService background task is stopping.");
        }
    }
}

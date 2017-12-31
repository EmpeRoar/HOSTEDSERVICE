﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICEPROVIDER
{
    public class DataRefreshService : BackgroundService
    {
        private readonly ILogger<DataRefreshService> _logger;
        public DataRefreshService(ILogger<DataRefreshService> logger)
        {
            _logger = logger;


        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogDebug($"DataRefreshService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogDebug($" DataRefreshService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                //_personService.AddToDbBackground(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogDebug($"DataRefreshService background task is stopping.");
        }
    }
}

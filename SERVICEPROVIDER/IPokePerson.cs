using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SERVICEPROVIDER
{
    public interface IPokePerson
    {
        void Poke(CancellationToken stoppingToken);
    }
}

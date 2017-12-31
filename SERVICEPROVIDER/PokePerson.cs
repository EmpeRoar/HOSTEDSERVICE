using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SERVICEPROVIDER
{
    public class PokePerson : IPokePerson
    {
        IPersonService _personService;
        public PokePerson(IPersonService personService)
        {
            _personService = personService;
        }

        public int Poke(CancellationToken stoppingToken)
        {
            _personService.AddToDbBackground(stoppingToken);
            return 1;
        }
    }
}

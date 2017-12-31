using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SERVICEPROVIDER
{
    public interface IPersonService
    {
        int AddToDb();
        int AddToDbBackground(CancellationToken cancellationToken);

    }
}

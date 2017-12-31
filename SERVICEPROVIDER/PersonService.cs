using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SERVICEPROVIDER
{
    public class PersonService : IPersonService
    {
        readonly private IRandumNumberProviderService _rand;
        readonly private AppDbContext _dbContext;
        public PersonService(DbContextOptions<AppDbContext> connectionString, IRandumNumberProviderService rand)
        {
            _dbContext = new AppDbContext(connectionString);
            _rand = rand;
        }
        public int AddToDb()
        {
            var addedEntity = _dbContext.Entry(new DOMAIN.Person()
            {
                Name = _rand.GetRandomString(),
                Created = DateTime.Now
            });
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChangesAsync();

            return 1;
        }
        public int AddToDbBackground(CancellationToken cancellationToken)
        {
            var addedEntity = _dbContext.Entry(new DOMAIN.Person()
            {
                Name = _rand.GetRandomString(),
                Created = DateTime.Now
            });
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}

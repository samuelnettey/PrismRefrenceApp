using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismRefrenceApp.Services
{
    public class PersonRepository : IPersonRepository
    {
        int count = 0;

        public int SavePerson(Business.Person person)
        {
            count++;
            person.LastUpdated = DateTime.Now;
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismRefrenceApp.Business;

namespace PrismRefrenceApp.Infrastructure
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}

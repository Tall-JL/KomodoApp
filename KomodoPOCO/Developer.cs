using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoPOCO
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public bool AccessToPluralsight { get; set; }

        public Developer()
        {

        }

        public Developer(string firstName, string lastName, string id, bool accessToPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            AccessToPluralsight = accessToPluralsight;
        }
    }
}

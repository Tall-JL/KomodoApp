using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoPOCO
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public List<Developer> Devs { get; set; } = new List<Developer>();
        public string TeamId { get; set; }


        public DevTeam()
        {

        }

        public DevTeam(string teamName, List<Developer> devs, string teamId)
        {
            TeamName = teamName;
            Devs = devs;
            TeamId = teamId;
        }
    }
}

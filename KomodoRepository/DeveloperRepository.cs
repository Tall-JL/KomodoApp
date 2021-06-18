using System;
using System.Collections.Generic;
using System.Linq;
using KomodoPOCO;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepository
{
    public class DeveloperRepository
    {
        public List<Developer> _devTeam = new List<Developer>();

        //create
        public bool AddDevToTeam(Developer dev)
        {
            _devTeam.Add(dev);
            return true;
        }

        //read
        public List<Developer> GetDevTeam()
        {
            return _devTeam;
        }

        //update
        //unused
        public bool UpdateExistingDeveloper(string oldId, Developer newDev)
        {
            //find content
            Developer oldDev = GetDeveloperById(oldId);

            //update content

            if (oldDev != null)
            {
                oldDev.LastName = newDev.LastName;
                oldDev.Id = newDev.Id;
                oldDev.FirstName = newDev.FirstName;
                oldDev.AccessToPluralsight = newDev.AccessToPluralsight;

                return true;
            }
            else
            {
                return false;
            }

        }


        //delete
        public bool RemoveDevFromTeam(string id)
        {
            Developer dev = GetDeveloperById(id);

            if (id == null)
            {
                return false;
            }

            int count = _devTeam.Count;
            _devTeam.Remove(dev);

            if (count > _devTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //name search
        public Developer GetDeveloperById(string id)
        {

            foreach (Developer dev in _devTeam)
            {
                if (dev.Id.ToLower() == id.ToLower())
                {
                    return dev;
                }
            }

            return null;
        }
    }
}

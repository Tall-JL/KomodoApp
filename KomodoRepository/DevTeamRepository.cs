using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KomodoPOCO;
using System.Threading.Tasks;

namespace KomodoRepository
{
    public class DevTeamRepository
    {
        public List<DevTeam> _listOfTeams = new List<DevTeam>();

        public bool AddDevsToList(DevTeam devs)
        {
            _listOfTeams.Add(devs);
            return true;
        }

        public List<DevTeam> GetDevTeamList()
        {
            return _listOfTeams;
        }

        public bool UpdateExistingDevTeam(string oldTeam, DevTeam newDevTeamMember)
        {
            //find content
            DevTeam oldDevTeamMember = GetDevTeamById(oldTeam);



            //update content

            if (oldDevTeamMember != null)
            {
                oldDevTeamMember.Devs = newDevTeamMember.Devs;
                oldDevTeamMember.TeamId = newDevTeamMember.TeamId;
                oldDevTeamMember.TeamName = newDevTeamMember.TeamName;

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AddDevToATeam(Developer id, string teamId)
        {
            DevTeam teamOfDev = GetDevTeamById(teamId);
                        
            
                if(id != null)
                {
                    teamOfDev.Devs.Add(id);
                    return true;
                }
                else
                {
                    return false;
                }        
                      
        }


        public bool RemoveDevFromListofDevTeams(string teamId)
        {
            DevTeam devs = GetDevTeamById(teamId);

            if (teamId == null)
            {
                return false;
            }

            int count = _listOfTeams.Count;
            _listOfTeams.Remove(devs);

            if (count > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RemoveDevFromTeam(string id, string teamId)
        {
            DevTeam teamOfDev = GetDevTeamById(teamId);

            foreach (Developer developer in teamOfDev.Devs.ToList())
            {
                if (developer.Id == id)
                {
                    teamOfDev.Devs.Remove(developer);
                    return true;
                }

            }
            return false;
        }

        public DevTeam GetDevTeamById(string teamId)
        {

            foreach (DevTeam devs in _listOfTeams)
            {
                if (devs.TeamId == teamId)
                {
                    return devs;
                }
            }

            return null;
        }
    }
}

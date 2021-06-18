using System;
using System.Collections.Generic;
using KomodoPOCO;
using KomodoRepository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.UI
{
    public class ProgramUI
    {
        public DeveloperRepository _devDirect = new DeveloperRepository();
        public DevTeamRepository _devTeamDirect = new DevTeamRepository();
        public void Run()
        {
            SeedDevList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                "1. View developer teams\n" +
                "2. View developer directory\n" +
                "3. View devs on dev team\n" +
                "4. Add dev to team\n" +
                "5. Remove dev from team\n" +
                "6. Make new dev profile\n" +
                "7. Make new dev team\n" +
                "8. Delete dev\n" +
                "9. Delete dev team\n" +
                "10. Monthly Check\n" +
                "11. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewDevTeams();
                        break;

                    case "2":
                        DisplayDevDirectory();
                        break;

                    case "3":
                        ViewDevsOnTeam();
                        break;

                    case "4":
                        AddDevToATeam();
                        break;

                    case "5":
                        RemoveDevFromTeam();
                        break;

                    case "6":
                        MakeDevProfile();
                        break;

                    case "7":
                        MakeDevTeam();
                        break;

                    case "8":
                        DeleteDev();
                        break;

                    case "9":
                        RemoveDevTeam();
                        break;

                    case "10":
                        MonthlyCheck();
                        break;
                    case "11":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid number");
                        break;

                }


                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }



        }

        private void ViewDevTeams()
        {
            Console.Clear();

            List<DevTeam> devTeamDirectory = _devTeamDirect.GetDevTeamList();

            foreach (DevTeam devs in devTeamDirectory)
            {
                Console.WriteLine($"Team Name: {devs.TeamName}\n" +
                    $"Team ID: {devs.TeamId}\n");
            }
        }

        private void DisplayDevDirectory()
        {
            Console.Clear();

            List<Developer> devDirectory = _devDirect.GetDevTeam();

            foreach (Developer developer in devDirectory)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"ID: {developer.Id}\n" +
                    $"Access To Puralsight: {developer.AccessToPluralsight}\n");
            }
        }

        private bool MakeDevProfile()
        {
            Console.Clear();

            Developer newDev = new Developer();

            Console.WriteLine("Enter the first name of the developer:");
            newDev.FirstName = Console.ReadLine();


            Console.WriteLine("Enter the last name of the developer:");
            newDev.LastName = Console.ReadLine();


            Console.WriteLine("What is the developers ID number:");
            newDev.Id = Console.ReadLine();


            Console.WriteLine("Does the developer have access to Pluralsight (yes or no):");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if (pluralsightAccess == "yes")
            {
                newDev.AccessToPluralsight = true;
            }
            else
            {
                newDev.AccessToPluralsight = false;
            }

            bool success = _devDirect.AddDevToTeam(newDev);

            if (success)
            {
                Console.WriteLine($"New dev profile {newDev.FirstName} was created!");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to create!");
                return false;
            }

        }

        private bool AddDevToATeam()
        {
            Console.Clear();
            Developer devToAdd = new Developer();
            ViewDevTeams();

            Console.WriteLine("What is the team id: ");
            string teamId = Console.ReadLine();

            DisplayDevDirectory();

            Console.WriteLine("What is the ID of the dev you'd like to add: ");
            string id = Console.ReadLine();
            devToAdd = _devDirect.GetDeveloperById(id);

            bool wasAdded = _devTeamDirect.AddDevToATeam(devToAdd, teamId);

            if (wasAdded)
            {
                Console.WriteLine("Dev added to team successfully!");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to create!");
                return false;
            }
        }

        public void RemoveDevTeam()
        {
            ViewDevTeams();

            Console.WriteLine("\nEnter ID of the team you want to delete:");
            string input = Console.ReadLine();

            bool wasDeleted = _devTeamDirect.RemoveDevFromListofDevTeams(input);

            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted");
            }
            else
            {
                Console.WriteLine("Team could not be deleted");
            }
        }

        public void DeleteDev()
        {
            DisplayDevDirectory();

            Console.WriteLine("\nEnter ID of the dev you want to delete:");
            string input = Console.ReadLine();

            bool wasDeleted = _devDirect.RemoveDevFromTeam(input);

            if (wasDeleted)
            {
                Console.WriteLine("The dev was successfully deleted");
            }
            else
            {
                Console.WriteLine("Dev could not be deleted");
            }
        }

        public bool MakeDevTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("New dev team name: ");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("New dev team id: ");
            newTeam.TeamId = Console.ReadLine();

            bool success = _devTeamDirect.AddDevsToList(newTeam);

            if (success)
            {
                Console.WriteLine($"Dev team {newTeam.TeamName} has been created!");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to create!");
                return false;
            }
        }

        public void ViewDevsOnTeam()
        {
            Console.Clear();

            ViewDevTeams();

            Console.WriteLine("Enter dev team ID you'd like to view: \n");
            string input = Console.ReadLine();

            DevTeam listOfDevsOnTeam = _devTeamDirect.GetDevTeamById(input);

            foreach (Developer devs in listOfDevsOnTeam.Devs)
            {
                Console.WriteLine($"First Name: {devs.FirstName}\n" +
                    $"Last Name: {devs.LastName}\n" +
                    $"ID: {devs.Id}\n" +
                    $"Access To Puralsight: {devs.AccessToPluralsight}\n");
            }
        }

        public void RemoveDevFromTeam()
        {

            DisplayDevDirectory();

            Console.WriteLine("\nEnter ID of the dev to remove: ");
            string devId = Console.ReadLine();

            ViewDevTeams();

            Console.WriteLine("\nEnter dev team ID to remove from: ");
            string teamId = Console.ReadLine();

            bool wasDeleted = _devTeamDirect.RemoveDevFromTeam(devId, teamId);

            if (wasDeleted)
            {
                Console.WriteLine("The dev was removed from team");
            }
            else
            {
                Console.WriteLine("Dev could not be removed");
            }
        }

        //Runs but couldnt get to print more than one dev
        public bool MonthlyCheck()
        {
            Console.Clear();

            Console.WriteLine("These devIDs need Pluralsight access\n");


            foreach (var dev in _devDirect._devTeam)
            {
                if (dev.AccessToPluralsight == false)
                {
                    Console.WriteLine(dev.Id);

                    return true;
                }

            }
            return false;

        }

        //seed
        private void SeedDevList()
        {
            Developer dev1 = new Developer("Jack", "Jog", "32", false);
            Developer dev2 = new Developer("Tim", "Meat", "33", true);
            Developer dev3 = new Developer("Susan", "Johnson", "34", false);
            Developer dev4 = new Developer("Hilary", "Bast", "35", true);

            _devDirect.AddDevToTeam(dev1);
            _devDirect.AddDevToTeam(dev2);
            _devDirect.AddDevToTeam(dev3);
            _devDirect.AddDevToTeam(dev4);


            DevTeam devTeam2 = new DevTeam("Back End", new List<Developer> { dev1, dev2 }, "102");
            DevTeam devTeam3 = new DevTeam("Front End", new List<Developer> { dev3, dev4 }, "103");
            DevTeam devTeam4 = new DevTeam("UX", new List<Developer> { dev1, dev4 }, "104");
            DevTeam devTeam5 = new DevTeam("Mascots", new List<Developer> { dev1, dev3 }, "105");

            _devTeamDirect.AddDevsToList(devTeam2);
            _devTeamDirect.AddDevsToList(devTeam3);
            _devTeamDirect.AddDevsToList(devTeam4);
            _devTeamDirect.AddDevsToList(devTeam5);
        }
    }
}

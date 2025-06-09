using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__SQL.Agent
{
    internal class Agent
    {
        public  int Id { get; set; }
        public  string CodeName { get; set; }
        public  string RealName { get; set; }
        public string Location { get; set; }
        public  string Status { get; set; }
        public  int MissionsCompleated { get; set; }
       public Agent( int id,string codename, string realname, string location, string status, int missioncompleated)
        {
            Id = id;
            CodeName = codename;
            RealName = realname;
            Location = location;
            Status = status;
            MissionsCompleated = missioncompleated;

        }

        public void printDetails()
        {
            Console.WriteLine($"the ID: {Id}\n codename: {CodeName} \n RealName: {RealName}\n  Location: {Location}\n Status: {Status}\n MissionsCompleted: {MissionsCompleated}");

        }



    }

}

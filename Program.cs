using System;
using System.Collections.Generic;
using c__SQL.Agent;
using c__SQL.DAL;
using c__SQL.Models;

class Program
{
    static void Main()
    {
    
        AgentDAL newdal = new AgentDAL();
        List<Agent> FilteredagentList = newdal.GetAllAgents();

        Agent ag = new Agent(0, "jjd", "donald", "losangeles", "Active", 10);
        newdal.AddAgent(ag);
        newdal.DeleteAgent(32);
        newdal.SearchAgentsByCode("jjd");






    }
}

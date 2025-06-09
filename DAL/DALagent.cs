using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using c__SQL.Agent;
using c__SQL.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

class AgentDAL
{
    private string connStr = "server=localhost;user=root;password=;database=eagleeyedb";
    private MySqlConnection _conn;

    // Constructor
    public AgentDAL()
    {
        try
        {
            openConnection();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"MySQL Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }
    }

    public MySqlConnection openConnection()
    {
        if (_conn == null)
        {
            _conn = new MySqlConnection(connStr);
        }

        if (_conn.State != System.Data.ConnectionState.Open)
        {
            _conn.Open();
            Console.WriteLine("Connection successful.");
        }

        return _conn;
    }

    public void closeConnection()
    {
        if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
        {
            _conn.Close();
            _conn = null;
        }
    }



    // Methods
    public List<Agent> GetAllAgents(string query = "SELECT * FROM agents")
    {

        List<Agent> AgentList = new List<Agent>();
        MySqlCommand cmd = null;
        MySqlDataReader reader = null;

        try
        {
            openConnection();
            cmd = new MySqlCommand(query, _conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int Id = reader.GetInt32("ID");
                string CodeName = reader.GetString("codeName");
                string RealName = reader.GetString("realName");
                string Location = reader.GetString("location");
                string Status = reader.GetString("status");
                int MissionsCompleted = reader.GetInt32("missionsCompleted");



                Agent agent1 = new Agent(Id, CodeName, RealName, Location, Status, MissionsCompleted);
                AgentList.Add(agent1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching employees: {ex.Message}");
        }
        finally
        {
            if (reader != null && !reader.IsClosed)
                reader.Close();

            closeConnection();
        }


        return AgentList;
    }
    public void AddAgent(Agent newagent)
    {
        MySqlCommand cmd = null;
        string query = "INSERT INTO agents(codeName, realName, location, status, missionsCompleted) VALUES(@CodeName, @realName, @location, @status, @missionsCompleted)";
        MySqlCommand cmd = new MySqlCommand(query, _conn);
        cmd.Parameters.AddWithValue("@CodeName", newagent.CodeName);
        cmd.Parameters.AddWithValue("@realName", newagent.RealName);
        cmd.Parameters.AddWithValue("@location", newagent.Location);
        cmd.Parameters.AddWithValue("@status", newagent.Status);
        cmd.Parameters.AddWithValue("@missionsCompleted", newagent.MissionsCompleted);


        try
        {
            openConnection();
            cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching agnets: {ex.Message}");
        }

        closeConnection();
    }

    public void UpdateAgentLocation(int agentId, string newLocation)
    {
        MySqlCommand cmd = null;
        string query = $"UPDATE agents SET location = '{newLocation}' WHERE ID = {agentId};";
        ;

        try
        {
            openConnection();
            cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching agnets: {ex.Message}");
        }

        closeConnection();
    }

   public void DeleteAgent(int agentId)
    {
        MySqlCommand cmd = null;
        string query = $"DELETE FROM agents WHERE ID = {agentId};";
        ;

        try
        {
            openConnection();
            cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching agnets: {ex.Message}");
        }

        closeConnection();


    }

    public  void SearchAgentsByCode(string partialCode)
    {

        string query = $"SELECT * FROM agents WHERE codeName = '{partialCode}'";

        List<Agent> AgentList = new List<Agent>();
        MySqlCommand cmd = null;
        MySqlDataReader reader = null;
        Agent agent1 = null;

        try
        {
            openConnection();
            cmd = new MySqlCommand(query, _conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int Id = reader.GetInt32("ID");
                string CodeName = reader.GetString("codeName");
                string RealName = reader.GetString("realName");
                string Location = reader.GetString("location");
                string Status = reader.GetString("status");
                int MissionsCompleted = reader.GetInt32("missionsCompleted");



                agent1 = new Agent(Id, CodeName, RealName, Location, Status, MissionsCompleted);
            }

        }


        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching employees: {ex.Message}");
        }
        finally
        {
            if (reader != null && !reader.IsClosed)
                reader.Close();


            closeConnection();
        }
        Console.WriteLine("");
        Console.WriteLine($" the code name is: {agent1.CodeName} \n the real name is: {agent1.RealName} \n the location is: {agent1.Location} \n sum missions compleated: {agent1.MissionsCompleted}");




    }

    public Dictionary countagentbystatus()
    {

    }

}




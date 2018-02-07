using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

using System.Data;
using System.Data.SqlClient;
using Mono.Data.SqliteClient;

// For XML serialization
// using System.Xml.Serialization;

// [XmlRoot("GameData")]
public class GameData
{
    public static GameData Instance = new GameData();

    public int health;
    public int charisma;
    public int coins;
    public int activ;

    //private static string XMLFileName = "/GameData.xml";
    //private static string gameDataFile = Application.persistentDataPath + XMLFileName;

    //private static bool isLoaded;
    //public delegate void LoadEvent();
    //public static event LoadEvent OnLoad;

    //[XmlElement("GameLocation")]
    //public GameLocation locationID;

    //[XmlElement("Item")]
    //public ChestBox item = new ChestBox("ChestBox 3", "ASd", GameLocation.Location2);

    //[XmlArray("Rewards")]
    //public List<ChestBox> rewards = new List<ChestBox>();

    //[XmlArray("Items")]
    //public List<InventoryItem> items = new List<InventoryItem>();

    //[XmlArray("Pickups")]
    //public List<InventoryItem> pickups = new List<InventoryItem>();

    //public static void Save()
    //{
    //    // Save game state into XML
    //    var serializer = new XmlSerializer(typeof(GameData));
    //    var stream = new FileStream(gameDataFile, FileMode.Create);
    //    serializer.Serialize(stream, Instance);
    //    stream.Close();

    //    Debug.Log("Gameplay saved again: " + gameDataFile);
    //}

    //public static void Load()
    //{
    //    Debug.Log(gameDataFile);

    //    if (File.Exists(gameDataFile))
    //    {
    //        // Load info from XML
    //        var serializer = new XmlSerializer(typeof(GameData));
    //        var stream = new FileStream(gameDataFile, FileMode.Open);
    //        try
    //        {
    //            Instance = serializer.Deserialize(stream) as GameData;
    //            stream.Close();

    //            Debug.Log("Gameplay loaded: " + gameDataFile);
    //            Debug.Log(Instance.pickups.Count);

    //            isLoaded = true;
    //            if (OnLoad != null)
    //                OnLoad();
    //        }
    //        catch (SystemException e)
    //        {
    //            stream.Close();
    //            NewGame();
    //            Save();
    //        }
    //    }
    //    else
    //    {
    //        NewGame();
    //        Save();
    //    }
    //}

    //public static void NewGame()
    //{
    //    Instance.items.Clear();
    //    Instance.pickups.Clear();

    //    // list of InventorItems
    //    Instance.items.Add(new InventoryItem(0, 1, 10, "Sword of...", "Legendary something"));
    //    Instance.items.Add(new InventoryItem(1, 2, 5, "Armor", "ASidgoiasd"));
    //    Instance.items.Add(new InventoryItem(2, 1, 10, "Boots", "Info"));
    //    Instance.items.Add(new InventoryItem(3, 1, 10, "Whatever", "adsfhasdfsdf"));

    //    Instance.pickups.Add(new InventoryItem(4, 1, 12, "Item 4", "Description for item 4"));
    //    Instance.pickups.Add(new InventoryItem(5, 1, 7, "Item 5", "Description for item 5"));
    //    Instance.pickups.Add(new InventoryItem(7, 1, 7, "Item 6", "Description for item 6"));

    //    var c1 = new ChestBox("ChestBox 1", "Something 1", GameLocation.Location1);
    //    var c2 = new ChestBox("ChestBox 2", "Something 2", GameLocation.Location2);
    //    Instance.rewards.Add(c1);
    //    Instance.rewards.Add(c2);
    //}

    //public static void PickItem(InventoryItem item)
    //{
    //    Instance.pickups.Remove(item);
    //    Instance.items.Add(item);
    //}

    //public static void OnDataInit(LoadEvent callback)
    //{
    //    OnLoad += callback;

    //    if (isLoaded == true)
    //    {
    //        callback();
    //    }
    //    else
    //    {
    //        Debug.Log("Game Data Not loaded!");
    //    }
    //}

    //public static void RemoveCallback(LoadEvent callback)
    //{
    //    OnLoad -= callback;
    //}

    public static void Load()
    {
        // The name of the db.
        string dbName = "URI=file:Example.db";

        // Open the db connection.
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            // Create an sql command that creates a new table.
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS User_Config (Health INT, Charisma INT, Coins INT, Activ INT);";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT COUNT(*) AS InstanceCount FROM User_Config";
                using (IDataReader reader = command.ExecuteReader())
                {
                    int x = 0;
                    int y = 0;
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0).CompareTo(0) == 1) {
                            command.CommandText = "INSERT INTO User_Config (Health, Charisma, Coins, Activ) VALUES (100, 100, 0, 0);";
                            command.ExecuteNonQuery();
                        }
                    }
                    reader.Close();
                }

                command.CommandText = "SELECT Health, Charisma, Coins, Activ FROM User_Config";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Instance.health     = (int)reader["Health"];
                        Instance.charisma   = (int)reader["Charisma"];
                        Instance.coins      = (int)reader["Coins"];
                        Instance.activ      = (int)reader["Activ"];
                    }
                    reader.Close();
                }


                //command.CommandText = "CREATE TABLE IF NOT EXISTS highscore (name VARCHAR(20), score INT);";
                //command.ExecuteNonQuery();

                // Create test datasets
                //command.CommandText = "INSERT INTO highscore (name, score) VALUES ('Ash', 9000);";
                //command.ExecuteNonQuery();

                //command.CommandText = "insert into highscore (name, score) values ('Evil Dead', 12064);";
                //command.ExecuteNonQuery();

                //command.CommandText = "insert into highscore (name, score) values ('chainsaw', 15000);";
                //command.ExecuteNonQuery();

                // Read the datasets
                //command.CommandText = "select * from highscore order by score desc;";
                //using (IDataReader reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //        Debug.Log("Name: " + reader["name"] + "\tScore: " + reader["score"]);

                //    reader.Close();
                //}
            }
            connection.Close();
        }
    }
}

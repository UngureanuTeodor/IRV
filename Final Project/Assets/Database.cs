﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using Mono.Data.SqliteClient;

public class Database : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SimpleExampleScript();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SimpleExampleScript()
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
                // Drop the table if we call this mathode earlier.
                command.CommandText = "DROP TABLE IF EXISTS highscore;";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE highscore (name VARCHAR(20), score INT);";
                command.ExecuteNonQuery();


                // Create test datasets
                command.CommandText = "INSERT INTO highscore (name, score) VALUES ('Ash', 9000);";
                command.ExecuteNonQuery();

                command.CommandText = "insert into highscore (name, score) values ('Evil Dead', 12064);";
                command.ExecuteNonQuery();

                command.CommandText = "insert into highscore (name, score) values ('chainsaw', 15000);";
                command.ExecuteNonQuery();

                // Read the datasets
                command.CommandText = "select * from highscore order by score desc;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Debug.Log("Name: " + reader["name"] + "\tScore: " + reader["score"]);

                    reader.Close();
                }
            }
            connection.Close();
        }

    }
}

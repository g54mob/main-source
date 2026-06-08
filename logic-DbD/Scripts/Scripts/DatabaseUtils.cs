using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using UnityEngine;

public class DatabaseUtils
{
	public static SqliteConnection GetConnection(bool open = true, int level = -1)
	{
		return GetConnection($"Level {((level < 0) ? LevelManager.GetCurrLevel() : level)}", open);
	}

	public static SqliteConnection GetConnection(string path, bool open = true)
	{
		SqliteConnection sqliteConnection = new SqliteConnection("URI=file:" + Application.persistentDataPath + "/" + path);
		if (open)
		{
			sqliteConnection.Open();
		}
		return sqliteConnection;
	}

	public static void AddParameter(IDbCommand command, string paramName, object paramValue)
	{
		command.Parameters.Add(new SqliteParameter(paramName, paramValue));
	}

	public static HashSet<string> GetAllTableNames(IDbConnection connection = null)
	{
		bool flag = connection == null;
		if (flag)
		{
			connection = GetConnection();
		}
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "SELECT name \r\n                                         FROM sqlite_master\r\n                                         WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
		HashSet<string> hashSet = new HashSet<string>();
		using (IDataReader dataReader = dbCommand.ExecuteReader())
		{
			while (dataReader.Read())
			{
				hashSet.Add(dataReader.GetString(0));
			}
		}
		if (flag)
		{
			connection.Close();
		}
		return hashSet;
	}

	public static bool ContainsTable(string tableName, IDbConnection connection = null)
	{
		return GetAllTableNames(connection).Contains(tableName, StringComparer.OrdinalIgnoreCase);
	}

	public static void CreateTable(IDbConnection connection, string tableName, string fields)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (" + fields + ")";
		dbCommand.ExecuteNonQuery();
	}

	public static void AddSingleRowToTable(IDbConnection connection, string tableName, string fields, string value)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "INSERT INTO " + tableName + " (" + fields + ") VALUES (" + value + ")";
		dbCommand.ExecuteNonQuery();
	}

	public static void AddToTable(IDbConnection connection, string tableName, string fields, List<string> values)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "INSERT INTO " + tableName + " (" + fields + ") VALUES " + string.Join(",", values);
		dbCommand.ExecuteNonQuery();
	}

	public static void DeleteFromTable(IDbConnection connection, string tableName, string condition)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "DELETE FROM " + tableName + " WHERE " + condition + ";";
		dbCommand.ExecuteNonQuery();
	}

	public static void DropTable(string tableName, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = GetConnection();
		}
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "DROP TABLE " + tableName;
		dbCommand.ExecuteNonQuery();
		connection.Close();
	}

	public static void DropAllTables(string[] whitelist = null)
	{
		for (int i = 0; i <= 4; i++)
		{
			using IDbConnection connection = GetConnection(open: true, i);
			foreach (string allTableName in GetAllTableNames(connection))
			{
				Debug.Log(allTableName);
				DropTable(connection, allTableName);
			}
		}
		using IDbConnection connection2 = GetConnection(Save.SAVES_DATABASE);
		foreach (string allTableName2 in GetAllTableNames(connection2))
		{
			Debug.Log(allTableName2);
			if (whitelist == null || whitelist.Contains(allTableName2))
			{
				DropTable(connection2, allTableName2);
			}
		}
	}

	public static void DropTable(IDbConnection connection, string tableName)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "DROP TABLE " + tableName;
		dbCommand.ExecuteNonQuery();
	}

	public static Table GetTableData(string tableName)
	{
		string query = "SELECT * FROM " + tableName;
		SqliteConnection connection = GetConnection();
		Table tableFromQuery = GetTableFromQuery(connection, query);
		connection.Close();
		return tableFromQuery;
	}

	public static Table GetTableData(IDbConnection dbcon, string tableName, string orderCondition = null)
	{
		string text = "SELECT * FROM " + tableName;
		if (orderCondition != null)
		{
			text = text + " ORDER BY " + orderCondition;
		}
		return GetTableFromQuery(dbcon, text);
	}

	public static Table GetTableFromQuery(IDbConnection dbcon, string query)
	{
		IDbCommand dbCommand = dbcon.CreateCommand();
		dbCommand.CommandText = query;
		IDataReader dataReader = dbCommand.ExecuteReader();
		Table table = new Table(dataReader.FieldCount);
		for (int i = 0; i < dataReader.FieldCount; i++)
		{
			table.SetColumnName(i, dataReader.GetName(i));
		}
		while (dataReader.Read())
		{
			string[] array = new string[dataReader.FieldCount];
			for (int j = 0; j < dataReader.FieldCount; j++)
			{
				array[j] = dataReader[j]?.ToString() ?? "";
			}
			table.AddRow(array);
		}
		dataReader.Close();
		return table;
	}

	public static HashSet<string> GetTableColumnNames(IDbConnection connection, string tableName)
	{
		string commandText = "SELECT * FROM " + tableName;
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = commandText;
		IDataReader dataReader = dbCommand.ExecuteReader();
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < dataReader.FieldCount; i++)
		{
			hashSet.Add(dataReader.GetName(i));
		}
		return hashSet;
	}

	public static bool RenameTable(string oldName, string newName)
	{
		using IDbConnection dbConnection = GetConnection();
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "CREATE TABLE " + newName + " AS SELECT * FROM " + oldName;
		dbCommand.ExecuteNonQuery();
		DropTable(dbConnection, oldName);
		return true;
	}

	public static void Begin(IDbConnection connection)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "BEGIN TRANSACTION";
		dbCommand.ExecuteNonQuery();
	}

	public static void Rollback(IDbConnection connection)
	{
		Debug.Log("Rolling back query.");
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "ROLLBACK";
		dbCommand.ExecuteNonQuery();
	}

	public static void Commit(IDbConnection connection)
	{
		IDbCommand dbCommand = connection.CreateCommand();
		dbCommand.CommandText = "COMMIT";
		dbCommand.ExecuteNonQuery();
	}
}

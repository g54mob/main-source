using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class Level
{
	protected static void LoadSave()
	{
		string text = Save.DecodeString(Save.GLOBAL_SAVE.databaseCode);
		string text2 = Save.DecodeString(Save.GLOBAL_SAVE.saveCode);
		AnswerHandler.SetAnswer(text + " " + text2);
		Debug.Log("Culprit is " + text + " " + text2);
	}

	protected static bool Load(IDbConnection savesConnection, ICollection<string> everyone, bool hasLoad)
	{
		if (!hasLoad)
		{
			Debug.Log("hasLoad is false");
			return false;
		}
		HashSet<string> allTableNames = DatabaseUtils.GetAllTableNames(savesConnection);
		HashSet<string> allTableNames2 = DatabaseUtils.GetAllTableNames();
		foreach (string item in ReadOnlyTables.ReadOnlyTableNames())
		{
			ICollection<string> collection = allTableNames2;
			if (ReadOnlyTables.SaveRequiredTables().Contains(item))
			{
				collection = allTableNames;
			}
			else if (ReadOnlyTables.PostponedTableNames().Contains(item))
			{
				continue;
			}
			if (!collection.Contains(item))
			{
				Debug.Log("Does not contain " + item);
				return false;
			}
		}
		LoadSave();
		bool num = CreateTablesHelpers.LoadCollection(everyone, Save.EVERYONE_TABLE);
		if (!num)
		{
			Debug.Log("hasEveryone is false");
		}
		return num;
	}

	public static void SaveAppearances(Dictionary<string, Appearance> appearances)
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		if (DatabaseUtils.ContainsTable(Save.APPEARANCES_TABLE, connection))
		{
			DatabaseUtils.DropTable(connection, Save.APPEARANCES_TABLE);
		}
		DatabaseUtils.CreateTable(connection, Save.APPEARANCES_TABLE, "name TEXT, age INT, eye_color TEXT");
		DatabaseUtils.Begin(connection);
		List<string> list = new List<string>();
		foreach (string key in appearances.Keys)
		{
			list.Add($"('{key.ToUpperInvariant()}', {appearances[key]})");
		}
		DatabaseUtils.AddToTable(connection, Save.APPEARANCES_TABLE, "name, age, eye_color", list);
		DatabaseUtils.Commit(connection);
		connection.Close();
	}

	public static void LoadAppearances(IDbConnection connection, Dictionary<string, Appearance> appearances)
	{
		if (!DatabaseUtils.ContainsTable(Save.APPEARANCES_TABLE, connection))
		{
			Debug.Log(Save.APPEARANCES_TABLE + " not found!");
		}
		foreach (string[] row in DatabaseUtils.GetTableData(connection, Save.APPEARANCES_TABLE).GetRows())
		{
			appearances[row[0]] = new Appearance(int.Parse(row[1]), row[2]);
		}
	}

	protected static void SaveData(string firstName, string lastName, ICollection<string> everyone)
	{
		AnswerHandler.SetAnswer(firstName + " " + lastName);
		Save.SaveCulprit(firstName, lastName);
		CreateTablesHelpers.SaveCollection(everyone, Save.EVERYONE_TABLE);
	}

	protected static void SaveData(string firstName, string lastName, ICollection<string> everyone, Dictionary<string, Appearance> appearances)
	{
		SaveData(firstName, lastName, everyone);
		SaveAppearances(appearances);
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using UnityEngine;

public static class CreateTablesHelpers
{
	public delegate T GetNewID<T>();

	public static readonly System.Random RANDY = new System.Random();

	public static string[] maleNames;

	public static string[] femNames;

	public static string[] firstNames;

	public static string[] lastNames;

	public static string[] months;

	private static int[] AREA_CODES = new int[3] { 212, 646, 332 };

	public static void LoadNames()
	{
		maleNames = ToNameCase(ResourcesManager.ParseTextFile("Names/male-first-names"));
		femNames = ToNameCase(ResourcesManager.ParseTextFile("Names/female-first-names"));
		firstNames = maleNames.Concat(femNames).ToArray();
		lastNames = ToNameCase(ResourcesManager.ParseTextFile("Names/last-names"));
		months = new string[12]
		{
			"January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
			"November", "December"
		};
	}

	public static ICollection<T> Shuffle<T>(ICollection<T> collection)
	{
		return collection.OrderBy((T a) => RANDY.Next()).ToList();
	}

	public static void ShufflePopulateTable<T>(IDbConnection connection, string tableName, string[] fields, List<T> rows, bool commit = true)
	{
		PopulateTable(connection, tableName, fields, Shuffle(rows), commit);
	}

	public static void PopulateTable<T>(IDbConnection connection, string tableName, string[] fields, ICollection<T> rows, bool commit = true)
	{
		PopulateTable(connection, tableName, fields, rows, (T row) => row.ToString(), commit);
	}

	public static void PopulateTable<T>(IDbConnection connection, string tableName, string[] fields, ICollection<T> rows, Func<T, string> rowOutput, bool commit = true)
	{
		Debug.Log($"Adding {rows.Count} rows to {tableName}");
		if (commit)
		{
			DatabaseUtils.Begin(connection);
		}
		List<string> list = new List<string>();
		foreach (T row in rows)
		{
			list.Add("(" + rowOutput(row) + ")");
		}
		DatabaseUtils.AddToTable(connection, tableName, string.Join(", ", fields), list);
		if (commit)
		{
			DatabaseUtils.Commit(connection);
		}
	}

	public static string RemoveQuotations(string text)
	{
		if (text == null)
		{
			return "";
		}
		return text.Replace("\"", "———");
	}

	public static string RestoreQuotations(string text)
	{
		return text.Replace("———", "\"");
	}

	public static void GetSavedTable<T>(string tableName, string columnTypes, string[] columnNames, ICollection<T> table, Action<string[]> forEachRowOnSave, Action populateTable, Func<T, string> rowOutput)
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		if (DatabaseUtils.ContainsTable(tableName, connection))
		{
			foreach (string[] row in DatabaseUtils.GetTableData(connection, tableName).GetRows())
			{
				forEachRowOnSave(row);
			}
		}
		else
		{
			populateTable();
			DatabaseUtils.CreateTable(connection, tableName, columnTypes);
			PopulateTable(connection, tableName, columnNames, table, (T row) => rowOutput(row));
		}
		connection.Close();
	}

	public static bool LoadSavedTable(IDbConnection connection, string tableName, Action<string[]> rowToObject, string orderCondition = null)
	{
		if (!DatabaseUtils.ContainsTable(tableName, connection))
		{
			Debug.Log("Cannot find " + tableName);
			return false;
		}
		foreach (string[] row in DatabaseUtils.GetTableData(connection, tableName, orderCondition).GetRows())
		{
			rowToObject(row);
		}
		return true;
	}

	public static void SaveCollection(ICollection<string> collection, string tableName)
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		if (DatabaseUtils.ContainsTable(tableName, connection))
		{
			DatabaseUtils.DropTable(connection, tableName);
		}
		if (collection == null || collection.Count <= 0)
		{
			return;
		}
		DatabaseUtils.CreateTable(connection, tableName, "Name TEXT");
		DatabaseUtils.Begin(connection);
		List<string> list = new List<string>();
		foreach (string item in collection)
		{
			list.Add("(" + SqlRowStringFunc(item) + ")");
		}
		DatabaseUtils.AddToTable(connection, tableName, "Name", list);
		DatabaseUtils.Commit(connection);
		connection.Close();
	}

	public static bool LoadCollection(ICollection<string> collection, string tableName)
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		if (!DatabaseUtils.ContainsTable(tableName, connection))
		{
			Debug.Log(tableName + " not found, cannot load collection!");
			return false;
		}
		foreach (string[] row in DatabaseUtils.GetTableData(connection, tableName).GetRows())
		{
			collection.Add(row[0]);
		}
		connection.Close();
		return true;
	}

	public static string SqlRowStringFunc(string value)
	{
		return "'" + value + "'";
	}

	public static string[] ToNameCase(string[] names)
	{
		for (int i = 0; i < names.Length; i++)
		{
			string text = names[i].Trim();
			if (text != string.Empty)
			{
				names[i] = ToNameCase(text);
			}
		}
		return names;
	}

	public static string ToNameCase(string name)
	{
		return char.ToUpperInvariant(name[0]) + name.Substring(1).ToLowerInvariant();
	}

	public static (string, string) SetCulprit(string[] firstNames, string[] lastNames)
	{
		string randomValue = GetRandomValue(firstNames);
		string randomValue2 = GetRandomValue(lastNames);
		Debug.Log(randomValue + " " + randomValue2);
		AnswerHandler.SetAnswer(randomValue + " " + randomValue2);
		return (randomValue, randomValue2);
	}

	public static (string, string) GetCulprit(string[] firstNames, string[] lastNames)
	{
		string randomValue = GetRandomValue(firstNames);
		string randomValue2 = GetRandomValue(lastNames);
		Debug.Log(randomValue + " " + randomValue2);
		return (randomValue, randomValue2);
	}

	public static string GetRandomFirstName()
	{
		return GetRandomValue(firstNames);
	}

	public static string GetRandomLastName()
	{
		return GetRandomValue(lastNames);
	}

	public static T GetRandomValue<T>(ICollection<T> list, int end = 0)
	{
		return list.ElementAt(RANDY.Next((end == 0) ? list.Count : end));
	}

	public static bool IsPercentChance(short percent)
	{
		return percent > RANDY.Next(100) + 1;
	}

	public static int GetRandomTime(int startHour, int endHour, int startMinute = 0, int endMinute = 0)
	{
		int num = RANDY.Next(startHour * 60 + startMinute, endHour * 60 + endMinute);
		int num2 = num / 60;
		int num3 = num % 60;
		return num2 * 100 + num3;
	}

	public static int AddTime(int time, int minutes)
	{
		int num = time % 100 + time / 100 * 60;
		num += minutes;
		return num / 60 * 100 + num % 60;
	}

	public static int GetRandomDate(int startYear = 0, int endYear = 1998, int startMonth = 1, int endMonth = 12, int startDay = 1, int endDay = -1)
	{
		int num = RANDY.Next(startYear, endYear);
		int month = RANDY.Next(startMonth, endMonth + 1);
		int day = RANDY.Next(startDay, ((endDay == -1) ? GetMaxDays(month, num % 4 == 0) : endDay) + 1);
		return GetDate(num, month, day);
	}

	public static int GetDate(int year, int month, int day)
	{
		return year * 10000 + month * 100 + day;
	}

	public static int GetDate(DateTime date)
	{
		return GetDate(date.Year, date.Month, date.Day);
	}

	public static int GetMaxDays(int month, bool isLeapYear = false)
	{
		switch (month)
		{
		case 1:
			return 31;
		case 2:
			if (!isLeapYear)
			{
				return 28;
			}
			return 29;
		case 3:
			return 31;
		case 4:
			return 30;
		case 5:
			return 31;
		case 6:
			return 30;
		case 7:
			return 31;
		case 8:
			return 31;
		case 9:
			return 30;
		case 10:
			return 31;
		case 11:
			return 30;
		case 12:
			return 31;
		default:
			return 0;
		}
	}

	public static (string, string) GetName(string[] firstNames, string[] lastNames, ICollection<string> names)
	{
		string randomValue = GetRandomValue(firstNames);
		string randomValue2 = GetRandomValue(lastNames);
		names.Add(randomValue + " " + randomValue2);
		return (randomValue, randomValue2);
	}

	public static (string, string) GetName(string[] firstNames, string[] lastNames, string culpritName, string culpritLastName)
	{
		string randomValue = GetRandomValue(firstNames);
		string randomValue2 = GetRandomValue(lastNames);
		while (randomValue.Equals(culpritName) && randomValue2.Equals(culpritLastName))
		{
			randomValue = GetRandomValue(firstNames);
			randomValue2 = GetRandomValue(lastNames);
		}
		return (randomValue, randomValue2);
	}

	public static (string, string) GetName(string[] firstNames, string[] lastNames, string culpritName, string culpritLastName, ICollection<string> names)
	{
		return AddName(names, GetName(firstNames, lastNames, culpritName, culpritLastName));
	}

	public static (string, string) AddName(ICollection<string> names, (string, string) name)
	{
		names.Add(name.Item1 + " " + name.Item2);
		return name;
	}

	public static int GetUniqueId(ICollection<int> ids)
	{
		return GetUniqueValue(ids, GenerateSixDigitId);
	}

	private static int GenerateSixDigitId()
	{
		return RANDY.Next(10000, 100000);
	}

	public static T GetUniqueValue<T>(ICollection<T> ids, GetNewID<T> generateId)
	{
		T val = generateId();
		while (ids.Contains(val))
		{
			val = generateId();
		}
		ids.Add(val);
		return val;
	}

	public static string GetCollectionString<T>(ICollection<T> col)
	{
		return string.Join(", ", col);
	}

	public static string GeneratePhoneNumber()
	{
		return string.Concat(GetRandomValue(AREA_CODES) + "-", RANDY.Next(100, 1000).ToString(), "-", RANDY.Next(1000, 10000).ToString());
	}
}

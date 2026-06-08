using System.Collections.Generic;
using System.Data;

public class Level2 : Level
{
	public const int LEVEL_NUMBER = 2;

	protected static ICollection<string> everyone = new HashSet<string>();

	public static void Create(bool hasLoad)
	{
		using (IDbConnection savesConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(savesConnection, everyone, hasLoad))
			{
				return;
			}
		}
		DatabaseUtils.DropAllTables();
		int num = CreateTablesHelpers.RANDY.Next(250, 300);
		IDbConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.Begin(connection);
		DatabaseUtils.CreateTable(connection, "cops", "badge_number INT, first_name TEXT, last_name TEXT, guns_issued INT, security_level INT, PRIMARY KEY(badge_number)");
		DatabaseUtils.CreateTable(connection, "timesheet", "badge_number INT, checkin_time INT, checkout_time INT, FOREIGN KEY (badge_number) REFERENCES cops (badge_number)");
		HashSet<int> ids = new HashSet<int>();
		List<Cop> list = new List<Cop>();
		List<CheckoutTime> list2 = new List<CheckoutTime>();
		int uniqueId = CreateTablesHelpers.GetUniqueId(ids);
		var (text, text2) = CreateTablesHelpers.GetCulprit(CreateTablesHelpers.maleNames, CreateTablesHelpers.lastNames);
		list.Add(new Cop(uniqueId, text, text2, 1, 3));
		list2.Add(new CheckoutTime(uniqueId, CreateTablesHelpers.GetRandomTime(8, 9, 0, 30), CreateTablesHelpers.GetRandomTime(22, 24, 20)));
		for (int i = 0; i < 10; i++)
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, text, text2, everyone);
			string item = name.Item1;
			string item2 = name.Item2;
			uniqueId = CreateTablesHelpers.GetUniqueId(ids);
			int num2 = 3;
			int gunsIssued = 0;
			if (i < 5)
			{
				gunsIssued = 1;
				num2 = CreateTablesHelpers.RANDY.Next(0, 6);
				if (num2 == 3)
				{
					num2 = 5;
				}
			}
			list.Add(new Cop(uniqueId, item, item2, gunsIssued, num2));
			list2.Add(new CheckoutTime(uniqueId, CreateTablesHelpers.GetRandomTime(8, 9, 0, 30), CreateTablesHelpers.GetRandomTime(22, 24, 20)));
		}
		for (int j = 0; j < num; j++)
		{
			(string, string) name2 = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, text, text2, everyone);
			string item3 = name2.Item1;
			string item4 = name2.Item2;
			uniqueId = CreateTablesHelpers.GetUniqueId(ids);
			list.Add(new Cop(uniqueId, item3, item4, CreateTablesHelpers.RANDY.Next(0, 4), CreateTablesHelpers.RANDY.Next(0, 6)));
			list2.Add(new CheckoutTime(uniqueId, CreateTablesHelpers.GetRandomTime(8, 9, 0, 30), CreateTablesHelpers.GetRandomTime(16, 19, 30)));
		}
		string[] fields = new string[5] { "badge_number", "first_name", "last_name", "guns_issued", "security_level" };
		CreateTablesHelpers.ShufflePopulateTable(connection, "cops", fields, list, commit: false);
		string[] fields2 = new string[3] { "badge_number", "checkin_time", "checkout_time" };
		CreateTablesHelpers.ShufflePopulateTable(connection, "timesheet", fields2, list2, commit: false);
		DatabaseUtils.Commit(connection);
		connection.Close();
		Level.SaveData(text, text2, everyone);
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Level3 : Level
{
	public const int LEVEL_NUMBER = 3;

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
		IDbConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.Begin(connection);
		DatabaseUtils.CreateTable(connection, "attendees", "id INT, first_name TEXT, last_name TEXT, PRIMARY KEY(id)");
		DatabaseUtils.CreateTable(connection, "lotioncon", "attendee_id INT, bottles_brought INT, FOREIGN KEY (attendee_id) REFERENCES attendees (id)");
		DatabaseUtils.CreateTable(connection, "bureaucon", "attendee_id INT, forms_brought INT, FOREIGN KEY (attendee_id) REFERENCES attendees (id)");
		DatabaseUtils.CreateTable(connection, "lampcon", "attendee_id INT, lamps_brought INT, FOREIGN KEY (attendee_id) REFERENCES attendees (id)");
		DatabaseUtils.CreateTable(connection, "dumbcon", "attendee_id INT, dumbs_brought INT, FOREIGN KEY (attendee_id) REFERENCES attendees (id)");
		List<string> cons = new List<string> { "lampcon", "bureaucon" };
		cons = cons.OrderBy((string a) => CreateTablesHelpers.RANDY.Next()).ToList();
		cons.Add("dumbcon");
		cons.Insert(1, "lotioncon");
		Debug.Log("amount > average: " + cons[0]);
		Debug.Log("max < suspect max: " + cons[1]);
		Debug.Log("count > 300: " + cons[2]);
		int[] array = new int[4]
		{
			CreateTablesHelpers.RANDY.Next(250, 280),
			CreateTablesHelpers.RANDY.Next(250, 280),
			CreateTablesHelpers.RANDY.Next(301, 325),
			CreateTablesHelpers.RANDY.Next(250, 280)
		};
		Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
		dictionary.Add("lotioncon", new int[3] { 8, 3, 6 });
		dictionary.Add("bureaucon", new int[3] { 8, 3, 6 });
		dictionary.Add("lampcon", new int[3] { 6, 2, 4 });
		dictionary.Add("dumbcon", new int[1] { CreateTablesHelpers.RANDY.Next(8, 12) });
		Dictionary<string, int[]> dictionary2 = dictionary;
		dictionary = new Dictionary<string, int[]>();
		dictionary.Add("lotioncon", new int[3] { 13, 8, 13 });
		dictionary.Add("bureaucon", new int[3] { 13, 8, 13 });
		dictionary.Add("lampcon", new int[3] { 10, 6, 9 });
		dictionary.Add("dumbcon", new int[1] { (int)((double)dictionary2["dumbcon"][0] * 1.5 + 1.0) });
		Dictionary<string, int[]> dictionary3 = dictionary;
		Dictionary<string, int> suspectAmounts = new Dictionary<string, int>
		{
			{ "lotioncon", 8 },
			{ "bureaucon", 8 },
			{ "lampcon", 6 },
			{
				"dumbcon",
				dictionary2["dumbcon"][0]
			}
		};
		Dictionary<string, string[]> dictionary4 = new Dictionary<string, string[]>();
		dictionary4.Add("lotioncon", new string[2] { "attendee_id", "bottles_brought" });
		dictionary4.Add("bureaucon", new string[2] { "attendee_id", "forms_brought" });
		dictionary4.Add("lampcon", new string[2] { "attendee_id", "lamps_brought" });
		dictionary4.Add("dumbcon", new string[2] { "attendee_id", "dumbs_brought" });
		Dictionary<string, string[]> dictionary5 = dictionary4;
		List<Attendee> attendees = new List<Attendee>();
		List<List<int>> conventionsIds = new List<List<int>>();
		HashSet<int> ids = new HashSet<int>();
		int culpritId = CreateTablesHelpers.GetUniqueId(ids);
		var (culpritFirstName, culpritLastName) = CreateTablesHelpers.GetCulprit(CreateTablesHelpers.maleNames, CreateTablesHelpers.lastNames);
		attendees.Add(new Attendee(culpritId, culpritFirstName, culpritLastName));
		HashSet<int> suspectSameAmounts = new HashSet<int>();
		for (int num = 0; num < cons.Count; num++)
		{
			string text = cons[num];
			int max = dictionary3[text][(num != 3) ? num : 0];
			int avg = dictionary2[text][(num != 3) ? num : 0];
			int num2 = 0;
			if (num == 0 || num == 3)
			{
				num2 = suspectAmounts[text];
			}
			List<Contestant> list = GetContestants(array[num], avg, max, num2, num);
			if (num2 > 0)
			{
				list.Add(new Contestant(culpritId, num2));
			}
			CreateTablesHelpers.ShufflePopulateTable(connection, text, dictionary5[text], list, commit: false);
		}
		Debug.Log("suspectTableNotDumbcon count: " + suspectSameAmounts.Count);
		CreateTablesHelpers.ShufflePopulateTable(connection, "attendees", new string[3] { "id", "first_name", "last_name" }, attendees, commit: false);
		DatabaseUtils.Commit(connection);
		connection.Close();
		Level.SaveData(culpritFirstName, culpritLastName, everyone);
		void AddContestant(List<Contestant> contestants, List<int> contestantIds, int itemsOwned, int conventionIndex)
		{
			int num3 = CreateTablesHelpers.RANDY.Next(10);
			bool flag = num3 < conventionsIds.Count;
			int num4;
			if (flag)
			{
				List<int> list2 = conventionsIds[num3];
				do
				{
					num4 = list2[CreateTablesHelpers.RANDY.Next(list2.Count)];
				}
				while (contestantIds.Contains(num4) || num4 == culpritId || (conventionIndex == 3 && suspectSameAmounts.Contains(num4) && itemsOwned == suspectAmounts["dumbcon"]));
			}
			else
			{
				num4 = CreateTablesHelpers.GetUniqueId(ids);
			}
			if (conventionIndex == 0 && itemsOwned == suspectAmounts[cons[conventionIndex]])
			{
				suspectSameAmounts.Add(num4);
			}
			contestantIds.Add(num4);
			var (firstName, lastName) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, culpritFirstName, culpritLastName, everyone);
			contestants.Add(new Contestant(num4, itemsOwned));
			if (!flag)
			{
				attendees.Add(new Attendee(num4, firstName, lastName));
			}
		}
		List<Contestant> GetContestants(int tableLength, int num5, int maxValue, int suspectAmount, int conventionIndex)
		{
			List<Contestant> list2 = new List<Contestant>();
			List<int> list3 = new List<int>();
			int num3 = ((suspectAmount > 0) ? 1 : 0);
			int num4 = (tableLength + num3) * num5 - suspectAmount;
			for (int i = 0; i < tableLength; i++)
			{
				int num6 = CreateTablesHelpers.RANDY.Next(num5 - 2, maxValue);
				if (num4 - num6 < 0)
				{
					num6 = ((num4 > 0) ? num4 : 0);
				}
				num4 -= num6;
				AddContestant(list2, list3, num6, conventionIndex);
			}
			conventionsIds.Add(list3);
			return list2;
		}
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

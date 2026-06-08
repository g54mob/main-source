using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Level4 : Level
{
	public const int LEVEL_NUMBER = 4;

	protected static ICollection<string> everyone = new HashSet<string>();

	private static readonly Dictionary<string, float> MENU = new Dictionary<string, float>
	{
		{ "pineapple", 1.5f },
		{ "apple", 1.5f },
		{ "tomato", 1f },
		{ "orange", 1.25f },
		{ "watermelon", 1.5f },
		{ "cheese pizza", 1.75f },
		{ "pepperoni pizza", 2.25f },
		{ "mushroom pizza", 2f },
		{ "veggie pizza", 2f }
	};

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
		DatabaseUtils.CreateTable(connection, "receipts", "first_name TEXT, last_name TEXT, meal_number TEXT, dollars_tipped REAL, PRIMARY KEY(first_name, last_name, meal_number), FOREIGN KEY (meal_number) REFERENCES meals (number)");
		DatabaseUtils.CreateTable(connection, "meals", "number TEXT, item_purchased TEXT, FOREIGN KEY (item_purchased) REFERENCES menu (item)");
		HashSet<int> ids = new HashSet<int>();
		List<Receipt> list = new List<Receipt>();
		List<Meal> list2 = new List<Meal>();
		List<MenuItem> list3 = new List<MenuItem>();
		foreach (string key in MENU.Keys)
		{
			list3.Add(new MenuItem(key, MENU[key]));
		}
		(string, string) culprit = CreateTablesHelpers.GetCulprit(CreateTablesHelpers.maleNames, CreateTablesHelpers.lastNames);
		string item = culprit.Item1;
		string item2 = culprit.Item2;
		int uniqueId = CreateTablesHelpers.GetUniqueId(ids);
		string[] obj = new string[6] { "veggie pizza", "pineapple", "cheese pizza", "cheese pizza", "pineapple", "pineapple" };
		float num = 0.015f;
		float num2 = 0f;
		string[] array = obj;
		foreach (string text in array)
		{
			num2 += MENU[text];
			list2.Add(new Meal(uniqueId, text));
			Debug.Log($"Suspect price: {num2}");
		}
		list.Add(new Receipt(item, item2, uniqueId, num2 * num));
		int num3 = CreateTablesHelpers.RANDY.Next(200, 300);
		for (int j = 0; j < num3; j++)
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, item, item2, everyone);
			string item3 = name.Item1;
			string item4 = name.Item2;
			int uniqueId2 = CreateTablesHelpers.GetUniqueId(ids);
			int num4 = CreateTablesHelpers.RANDY.Next(1, 5);
			int tipPercent = getTipPercent(30, 10);
			float num5 = 0f;
			for (int k = 0; k < num4; k++)
			{
				MenuItem menuItem = list3[CreateTablesHelpers.RANDY.Next(list3.Count)];
				list2.Add(new Meal(uniqueId2, menuItem.item));
				num5 += MENU[menuItem.item];
			}
			list.Add(new Receipt(item3, item4, uniqueId2, num5 * ((float)tipPercent / 100f)));
		}
		CreateTablesHelpers.ShufflePopulateTable(connection, "receipts", new string[4] { "first_name", "last_name", "meal_number", "dollars_tipped" }, list, commit: false);
		list2 = list2.OrderBy((Meal a) => a.id).ToList();
		CreateTablesHelpers.PopulateTable(connection, "meals", new string[2] { "number", "item_purchased" }, list2, commit: false);
		DatabaseUtils.Commit(connection);
		connection.Close();
		Level.SaveData(item, item2, everyone);
	}

	public static void CreateMenuTable()
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		List<MenuItem> list = new List<MenuItem>();
		foreach (string key in MENU.Keys)
		{
			list.Add(new MenuItem(key, MENU[key]));
		}
		DatabaseUtils.CreateTable(connection, "menu", "item TEXT, price TEXT");
		CreateTablesHelpers.PopulateTable(connection, "menu", new string[2] { "item", "price" }, list);
	}

	private static int getTipPercent(int lowTipPercent, int highTipPercent)
	{
		int num = CreateTablesHelpers.RANDY.Next(100);
		if (num < lowTipPercent)
		{
			return CreateTablesHelpers.RANDY.Next(4, 15);
		}
		if (num >= 100 - highTipPercent)
		{
			return CreateTablesHelpers.RANDY.Next(25, 40);
		}
		return CreateTablesHelpers.RANDY.Next(15, 25);
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

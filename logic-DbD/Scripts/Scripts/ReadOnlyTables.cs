using System.Collections.Generic;
using System.Linq;

public static class ReadOnlyTables
{
	public static ICollection<string> ReadOnlyTableNames()
	{
		ICollection<string> first = CoreTableNames();
		ICollection<string> second = PostponedTableNames();
		return new HashSet<string>(first.Union(second));
	}

	public static ICollection<string> CoreTableNames()
	{
		return LevelManager.GetCurrLevel() switch
		{
			0 => new HashSet<string> { "suspects" }, 
			1 => new HashSet<string> { "teachers" }, 
			2 => new HashSet<string> { "cops", "timesheet" }, 
			3 => new HashSet<string> { "attendees", "lotioncon", "bureaucon", "lampcon", "dumbcon" }, 
			4 => new HashSet<string> { "credits" }, 
			_ => new HashSet<string>(), 
		};
	}

	public static ICollection<string> PostponedTableNames()
	{
		switch (LevelManager.GetCurrLevel())
		{
		case 4:
			return new HashSet<string> { "menu" };
		case 5:
			return new HashSet<string> { "movies", "stars", "nutrition_facts", "order_74b8s", "order_43q7p", "order_67s9b" };
		case 8:
		{
			HashSet<string> tableList2 = new HashSet<string> { "card_drawings", "bigball_bets", "winners", "past_forecasts", "flights", "games_history" };
			AddTables(ref tableList2, new string[8] { "alin", "lzar", "mail", "clwn", "pyup", "nmby", "wthr", "sprt" }, new string[2] { "prices", "trans" });
			return tableList2;
		}
		case 7:
		{
			HashSet<string> tableList = new HashSet<string> { "students" };
			AddTables(ref tableList, new string[3] { "econ", "phil", "sci" }, new string[4] { "hwk", "attendance", "seats", "scores" });
			return tableList;
		}
		case 6:
			return new HashSet<string> { "election_results", "rentals", "drivers", "heroes", "champions", "patriots" };
		default:
			return new HashSet<string>();
		}
	}

	public static ICollection<string> SaveRequiredTables()
	{
		switch (LevelManager.GetCurrLevel())
		{
		case 5:
			return new HashSet<string> { "movies", "stars" };
		case 8:
		{
			HashSet<string> tableList2 = new HashSet<string> { "games_history", "card_drawings", "bigball_bets", "winners", "past_forecasts", "flights", "ponzi_scams" };
			AddTables(ref tableList2, new string[8] { "alin", "lzar", "mail", "clwn", "pyup", "nmby", "wthr", "sprt" }, new string[2] { "prices", "trans" });
			return tableList2;
		}
		case 7:
		{
			HashSet<string> tableList = new HashSet<string> { "students" };
			AddTables(ref tableList, new string[3] { "econ", "phil", "sci" }, new string[3] { "attendance", "seats", "scores" });
			return tableList;
		}
		case 6:
			return new HashSet<string> { "rentals", "drivers", "heroes", "champions", "patriots" };
		default:
			return new HashSet<string>();
		}
	}

	public static void AddTables(ref HashSet<string> tableList, string[] prefixes, string[] suffixes)
	{
		foreach (string text in prefixes)
		{
			foreach (string text2 in suffixes)
			{
				tableList.Add(text + "_" + text2);
			}
		}
	}

	public static ICollection<string> GeneratedTableNames()
	{
		return LevelManager.GetCurrLevel() switch
		{
			5 => new HashSet<string> { "reviews_" }, 
			8 => new HashSet<string> { "packages_", "seats_", "nimby_sold_" }, 
			6 => new HashSet<string> { "members_", "payup_" }, 
			_ => new HashSet<string>(), 
		};
	}

	public static bool IsGeneratedTable(string tableName)
	{
		ICollection<string> collection = GeneratedTableNames();
		if (collection == null)
		{
			return false;
		}
		foreach (string item in collection)
		{
			if (tableName.StartsWith(item))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsPostponedTableName(string tableName)
	{
		return PostponedTableNames().Contains(tableName);
	}

	public static bool IsReadOnlyTable(string tableName)
	{
		return ReadOnlyTableNames().Contains(tableName);
	}

	public static bool PostponeTable(string tableName)
	{
		if (PostponedTableNames() != null)
		{
			return PostponedTableNames().Contains(tableName);
		}
		return false;
	}
}

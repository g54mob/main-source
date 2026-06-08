using System.Collections.Generic;
using System.Data;

public class Level0 : Level
{
	public const int LEVEL_NUMBER = 0;

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
		string tableName = "suspects";
		string text = "suspect_number";
		string text2 = "first_name";
		string text3 = "last_name";
		string text4 = "occupation";
		List<Suspect> list = new List<Suspect>();
		string[] firstNames = new string[3] { "Jeff", "John", "Burt" };
		string[] lastNames = new string[1] { "Painterson" };
		var (text5, text6) = CreateTablesHelpers.GetCulprit(firstNames, lastNames);
		AddSuspect(list, 17432, "Jay", "Thompson", "Child");
		AddSuspect(list, 17433, "Laura", "Stevens", "Retired");
		AddSuspect(list, 17434, "Leonard", "Burns", "Banker");
		AddSuspect(list, 17435, text5, text6, "Painter");
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text3 + " TEXT, " + text4 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[4] { text, text2, text3, text4 }, list);
		connection.Close();
		Level.SaveData(text5, text6, everyone);
	}

	private static void AddSuspect(List<Suspect> suspects, int number, string first, string last, string job)
	{
		suspects.Add(new Suspect(number, first, last, job));
		CreateTablesHelpers.AddName(everyone, (first, last));
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

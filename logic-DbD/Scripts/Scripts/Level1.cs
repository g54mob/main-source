using System.Collections.Generic;
using System.Data;

public class Level1 : Level
{
	public const int LEVEL_NUMBER = 1;

	protected static ICollection<string> everyone = new HashSet<string>();

	protected static Dictionary<string, Appearance> appearances = new Dictionary<string, Appearance>();

	public static void Create(bool hasLoad)
	{
		using (IDbConnection dbConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(dbConnection, everyone, hasLoad))
			{
				Level.LoadAppearances(dbConnection, appearances);
				return;
			}
		}
		DatabaseUtils.DropAllTables();
		int num = CreateTablesHelpers.RANDY.Next(75, 120);
		IDbConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.CreateTable(connection, "teachers", "first_name TEXT, last_name TEXT, date_joined INT, date_of_birth INT, eye_color TEXT, height INT, weight INT");
		string[] list = CreateTablesHelpers.ToNameCase(ResourcesManager.ParseTextFile("Names/eye-colors"));
		List<Teacher> list2 = new List<Teacher>();
		string[] firstNames = new string[4] { "Eustace", "Barbara", "Margaret", "Eleanor" };
		string[] lastNames = new string[4] { "Cranberry", "Maybelline", "Wallace", "Monroe" };
		var (text, text2) = CreateTablesHelpers.GetCulprit(firstNames, lastNames);
		list2.Add(new Teacher(text, text2, 19801024, 19260617, "Green", 61, 110));
		for (int i = 0; i < num; i++)
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, text, text2, everyone);
			string item = name.Item1;
			string item2 = name.Item2;
			int randomDate = CreateTablesHelpers.GetRandomDate(1930, 1958);
			int age = 1998 - randomDate / 10000;
			string randomValue = CreateTablesHelpers.GetRandomValue(list);
			list2.Add(new Teacher(item, item2, CreateTablesHelpers.GetRandomDate(1978), randomDate, randomValue, CreateTablesHelpers.RANDY.Next(60, 72), CreateTablesHelpers.RANDY.Next(110, 200)));
			appearances[(item + " " + item2).ToUpperInvariant()] = new Appearance(age, randomValue);
		}
		string[] fields = new string[7] { "first_name", "last_name", "date_joined", "date_of_birth", "eye_color", "height", "weight" };
		CreateTablesHelpers.ShufflePopulateTable(connection, "teachers", fields, list2);
		connection.Close();
		Level.SaveData(text, text2, everyone, appearances);
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}

	public static Appearance GetAppearance(string name)
	{
		if (!appearances.ContainsKey(name))
		{
			return null;
		}
		return appearances[name];
	}
}

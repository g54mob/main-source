using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class WikiLevel : Level
{
	private enum ExpenseSize
	{
		Small = 0,
		Medium = 1,
		Large = 2,
		Extreme = 3
	}

	protected static ICollection<string> everyone = new HashSet<string>();

	public const int LEVEL_NUMBER = 6;

	public static Dictionary<string, string> guildNameMap;

	private static Dictionary<string, string> payupProfiles;

	private static Dictionary<string, Character> characters;

	private static Dictionary<string, HashSet<GuildMember>> guildMembers;

	private static Dictionary<string, List<BankTransaction>> payupAccounts;

	private static Dictionary<string, HashSet<string>> membersToGuilds;

	private static Dictionary<savelives.Tiers, List<Person>> donationTiers;

	private static List<Rental> rentals;

	private static List<Driver> drivers;

	private static Person culprit;

	private static Dictionary<string, ExpenseSize> expenses;

	private static readonly Dictionary<ExpenseSize, Func<int>> expenseCalculations = new Dictionary<ExpenseSize, Func<int>>
	{
		[ExpenseSize.Small] = () => CreateTablesHelpers.RANDY.Next(5, 15),
		[ExpenseSize.Medium] = () => CreateTablesHelpers.RANDY.Next(5, 10) * 5,
		[ExpenseSize.Large] = () => CreateTablesHelpers.RANDY.Next(15, 20) * 5,
		[ExpenseSize.Extreme] = () => CreateTablesHelpers.RANDY.Next(5, 10) * 100
	};

	private static readonly string driverMessage = "Thanks for being a driver for clowncar.com!";

	public static void LoadWebsites()
	{
		LoadGuildProfiles();
		LoadCharacters();
	}

	public static void LoadSuspectWebsites()
	{
		(string, string) tuple = CreateTablesHelpers.GetCulprit(new string[4] { "Justin", "Jordan", "James", "Joseph" }, CreateTablesHelpers.lastNames);
		string item = tuple.Item1;
		string item2 = tuple.Item2;
		string[] suspectNeighborhoods = new string[2] { "Coal Mining District", "Refineries" };
		bool isChamp = CreateTablesHelpers.IsPercentChance(50);
		Dictionary<string, (int, int)> obj = new Dictionary<string, (int, int)>
		{
			["Central Park East"] = (2500, 3400),
			["Central Park West"] = (2700, 3500),
			["Poverty Bay"] = (2200, 3500),
			["Harlem"] = (1700, 2300),
			["Zorantown"] = (4000, 5000),
			["Parking District"] = (3500, 4500),
			["Soho"] = (3300, 4500),
			["Noho"] = (2400, 3100),
			["Occupied Yargoslavia"] = (800, 1500),
			["Coal Mining District"] = (1000, 1800),
			["Refineries"] = (900, 1600),
			["Lower Zorangeles"] = (3000, 4000),
			["Little Yargoslavia"] = (1300, 2000)
		};
		LoadRentals(obj);
		LoadDrivers(nameCollisions: LoadDonations(item, item2, isChamp), neighborhoods: obj.Keys, culpritFirstName: item, culpritLastName: item2, suspectNeighborhoods: suspectNeighborhoods, isChamp: isChamp);
		SetSuspect(item, item2, isChamp, suspectNeighborhoods);
		SaveTables();
	}

	public static void SaveTables()
	{
		IDbConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		DatabaseUtils.Begin(connection);
		CreateDriversTable(clowncar.TABLE_NAME, connection);
		CreateRentalsTable(rent4ever.TABLE_NAME, connection);
		string[] tABLE_NAMES = savelives.TABLE_NAMES;
		foreach (string text in tABLE_NAMES)
		{
			savelives.Tiers tier = savelives.GetTier(text);
			CreateDonorsTable(text, tier, connection);
			Debug.Log($"{text} count -> {donationTiers[tier].Count}");
		}
		DatabaseUtils.Commit(connection);
		Debug.Log($"drivers count -> {drivers.Count}");
		Debug.Log($"rentals count -> {rentals.Count}");
	}

	public static void SetSuspect(string culpritFirstName, string culpritLastName, bool isChamp, string[] suspectNeighborhoods)
	{
		string randomValue = CreateTablesHelpers.GetRandomValue(suspectNeighborhoods);
		rentals.Add(new Rental(1, 1, randomValue, 1100, "Not Available"));
		drivers.Add(new Driver(culpritFirstName, culpritLastName, randomValue));
		string account = "jmeister";
		if (isChamp)
		{
			AddTransaction(19980210, CreateTablesHelpers.GetRandomTime(9, 19), account, "savelivesDOTgov", -10, "Donation");
		}
		savelives.Tiers key = (isChamp ? savelives.Tiers.Champions : savelives.Tiers.Patriots);
		culprit = new Person(culpritFirstName, culpritLastName);
		donationTiers[key].Add(culprit);
		string neighborhood = "Little Yargoslavia";
		rentals.Add(new Rental(1, 1, neighborhood, 1600, "Not Available"));
		(string, string) name = ("Joseph", "Budd");
		drivers.Add(new Driver(name.Item1, name.Item2, neighborhood));
		donationTiers[savelives.Tiers.Champions].Add(new Person(name.Item1, name.Item2));
		CreateTablesHelpers.AddName(everyone, name);
		donationTiers[key] = donationTiers[key].OrderBy((Person m) => CreateTablesHelpers.RANDY.Next()).ToList();
		drivers = drivers.OrderBy((Driver m) => m.neighborhood).ToList();
		rentals = rentals.OrderBy((Rental m) => m.neighborhood).ToList();
	}

	public static void LoadRentals(Dictionary<string, (int, int)> neighborhoods)
	{
		rentals = new List<Rental>();
		int num = 1200;
		Dictionary<int, double> dictionary = new Dictionary<int, double>
		{
			[1] = 1.0,
			[2] = 1.3,
			[3] = 1.5
		};
		string account = "rent4ever";
		string[] list = new string[11]
		{
			"Monthly rent", "Monthly rent for {1}", "monthly rent for {1}", "pay {1} rent", "rent4ever.com payment", "{1} rent", "rent payment", "{1} rent payment", "{1}", "rent4ever.com payment for {1}",
			"rent"
		};
		foreach (string key in neighborhoods.Keys)
		{
			int num2 = CreateTablesHelpers.RANDY.Next(60, 70);
			for (int i = 0; i < num2; i++)
			{
				int randomValue = CreateTablesHelpers.GetRandomValue(dictionary.Keys);
				int bathrooms = ((randomValue == 1) ? 1 : CreateTablesHelpers.RANDY.Next(randomValue - 1, randomValue));
				int minValue = neighborhoods[key].Item1 / 100;
				int maxValue = neighborhoods[key].Item2 / 100;
				int num3 = (int)((double)CreateTablesHelpers.RANDY.Next(minValue, maxValue) * dictionary[randomValue] * 100.0);
				string text;
				if (key == "Occupied Yargoslavia" && num3 <= num)
				{
					text = "Available";
				}
				else
				{
					text = (CreateTablesHelpers.IsPercentChance(40) ? "Not Available" : "Available");
					if (text == "Not Available")
					{
						string account2 = GeneratePayupUsername();
						for (int j = CreateTablesHelpers.RANDY.Next(1, 6); j <= 6; j++)
						{
							AddTransaction(CreateTablesHelpers.GetDate(1998, j, CreateTablesHelpers.RANDY.Next(1, 5)), CreateTablesHelpers.GetRandomTime(9, 19), account, account2, num3, CreateTablesHelpers.GetRandomValue(list).Replace("{1}", CreateTablesHelpers.months[j - 1]));
						}
					}
				}
				rentals.Add(new Rental(randomValue, bathrooms, key, num3, text));
			}
		}
	}

	public static void LoadDrivers(ICollection<string> neighborhoods, string culpritFirstName, string culpritLastName, ICollection<string> nameCollisions, string[] suspectNeighborhoods, bool isChamp)
	{
		drivers = new List<Driver>();
		string account = "clowncar";
		bool flag = false;
		for (int i = 0; i < CreateTablesHelpers.RANDY.Next(250, 300); i++)
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, culpritFirstName, culpritLastName, everyone);
			string item = name.Item1;
			string item2 = name.Item2;
			string randomValue = CreateTablesHelpers.GetRandomValue(neighborhoods);
			if (suspectNeighborhoods.Contains(randomValue) && nameCollisions.Contains(item + " " + item2))
			{
				i--;
				continue;
			}
			if (suspectNeighborhoods.Contains(randomValue) && !flag)
			{
				donationTiers[isChamp ? savelives.Tiers.Patriots : savelives.Tiers.Champions].Add(new Person(item, item2));
				flag = true;
			}
			drivers.Add(new Driver(item, item2, randomValue));
			string account2 = GeneratePayupUsername(item, item2);
			for (int j = CreateTablesHelpers.RANDY.Next(2, 7); j <= 6; j++)
			{
				int date = CreateTablesHelpers.GetDate(1998, j, 1);
				int date2 = CreateTablesHelpers.GetDate(1998, j, 15);
				AddTransaction(date, CreateTablesHelpers.GetRandomTime(9, 10), account, account2, -CreateTablesHelpers.RANDY.Next(400, 700), driverMessage);
				AddTransaction(date2, CreateTablesHelpers.GetRandomTime(9, 10), account, account2, -CreateTablesHelpers.RANDY.Next(400, 700), driverMessage);
			}
		}
	}

	public static ICollection<string> LoadDonations(string culpritFirstName, string culpritLastName, bool isChamp)
	{
		donationTiers = new Dictionary<savelives.Tiers, List<Person>>
		{
			[savelives.Tiers.Champions] = new List<Person>(),
			[savelives.Tiers.Heroes] = new List<Person>(),
			[savelives.Tiers.Patriots] = new List<Person>()
		};
		ICollection<string> collection = new HashSet<string>();
		Dictionary<savelives.Tiers, int> dictionary = new Dictionary<savelives.Tiers, int>
		{
			[savelives.Tiers.Champions] = CreateTablesHelpers.RANDY.Next(75, 100),
			[savelives.Tiers.Heroes] = CreateTablesHelpers.RANDY.Next(40, 50),
			[savelives.Tiers.Patriots] = CreateTablesHelpers.RANDY.Next(100, 125)
		};
		string account = "savelivesDOTgov";
		string[] list = new string[18]
		{
			"Donation", "True heroes", "You guys are the best", "Making the world a better place", "Selfless heroes", "Zoran bless", "Want to help", "a small donation", "thanks", "doing this for tax purposes",
			"donating to save lives", "We need more people like these", "Thanks for what you do", "Thank you all", "Humble donation", "For the troops", "Fighting the good fight", "Stay alive soldiers!"
		};
		for (int i = 0; i < CreateTablesHelpers.RANDY.Next(150, 200); i++)
		{
			string account2 = GeneratePayupUsername();
			for (int j = 1; j < CreateTablesHelpers.RANDY.Next(5); j++)
			{
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), account, account2, CreateTablesHelpers.IsPercentChance(70) ? CreateTablesHelpers.RANDY.Next(3, 20) : (CreateTablesHelpers.RANDY.Next(20, 30) * 5), CreateTablesHelpers.GetRandomValue(list));
			}
		}
		foreach (savelives.Tiers key in donationTiers.Keys)
		{
			for (int k = 0; k < dictionary[key]; k++)
			{
				var (text, text2) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, culpritFirstName, culpritLastName, everyone);
				if ((isChamp && key == savelives.Tiers.Champions) || key == savelives.Tiers.Patriots)
				{
					collection.Add(text + " " + text2);
				}
				donationTiers[key].Add(new Person(text, text2));
				string account3 = GeneratePayupUsername(text, text2);
				int num = CreateTablesHelpers.RANDY.Next(1, 5);
				for (int l = 1; l <= num; l++)
				{
					AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), account, account3, (int)(key + 1) / num, CreateTablesHelpers.GetRandomValue(list));
				}
			}
		}
		return collection;
	}

	public static bool ContainsAccount(string account)
	{
		if (payupAccounts != null)
		{
			return payupAccounts.ContainsKey(account);
		}
		return false;
	}

	public static void LoadCharacters()
	{
		IDbConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		string text = "descriptions";
		Dictionary<string, HashSet<string>> possibleDescriptions = GetPossibleDescriptions();
		Dictionary<string, string> dictionary = LoadDescriptions(connection, text);
		bool flag = dictionary.Count > 0;
		guildMembers = new Dictionary<string, HashSet<GuildMember>>();
		GuildMember item = new GuildMember("xCalibur32", Character.GetClassString(Character.Class.Warrior));
		guildMembers["$"] = new HashSet<GuildMember> { item };
		guildMembers["LLM"] = new HashSet<GuildMember> { item };
		membersToGuilds = new Dictionary<string, HashSet<string>>();
		characters = new Dictionary<string, Character>();
		foreach (string[] item2 in ResourcesManager.GetCSV("Names/players"))
		{
			string text2 = item2[0];
			string text3 = item2[1].Trim();
			Character character = ((text3.Length <= 0) ? new Character(text2) : new Character(ParsePlayerClass(text3), text2));
			string payupAccount = item2[3].Trim();
			characters.Add(text2, character);
			string[] array = item2[2].Split(' ');
			string[] array2 = array;
			foreach (string text4 in array2)
			{
				if (text4.Length != 0)
				{
					if (!guildMembers.ContainsKey(text4))
					{
						guildMembers[text4] = new HashSet<GuildMember>();
					}
					guildMembers[text4].Add(new GuildMember(text2, Character.GetClassString(character.type)));
					if (!membersToGuilds.ContainsKey(text2))
					{
						membersToGuilds[text2] = new HashSet<string>();
					}
					membersToGuilds[text2].Add(text4);
				}
			}
			string text5 = ((array.Length != 0 && array[0].Length > 0) ? array[0] : "NONE");
			if (!flag && possibleDescriptions.ContainsKey(text5))
			{
				string description = GetDescription(possibleDescriptions[text5], payupAccount, text5);
				dictionary.Add(text2, description);
			}
		}
		if (!flag)
		{
			SaveDescriptions(connection, dictionary, text);
		}
		SetPlayerAppearances(characters);
		SetPlayerDescriptions(dictionary);
		newhampshire_player.SetPlayers(characters, dictionary);
		connection.Close();
	}

	public static Dictionary<string, string> LoadDescriptions(IDbConnection connection, string descriptionsTable)
	{
		Dictionary<string, string> descriptions = new Dictionary<string, string>();
		if (CreateTablesHelpers.LoadSavedTable(connection, descriptionsTable, AddDescription))
		{
			Debug.Log($"descriptions count -> {descriptions.Keys.Count}");
		}
		return descriptions;
		void AddDescription(string[] row)
		{
			descriptions.Add(row[0], row[1]);
		}
	}

	public static void SaveDescriptions(IDbConnection connection, Dictionary<string, string> descriptions, string descriptionsTableName)
	{
		string fields = "username TEXT, description TEXT";
		string[] fields2 = new string[2] { "username", "description" };
		DatabaseUtils.CreateTable(connection, descriptionsTableName, fields);
		CreateTablesHelpers.PopulateTable(connection, descriptionsTableName, fields2, descriptions.Keys, (string row) => "'" + row + "', '" + descriptions[row] + "'");
		Debug.Log($"descriptions count -> {descriptions.Keys.Count}");
		connection.Close();
	}

	public static void LoadCharacterTransactions()
	{
		payupAccounts = new Dictionary<string, List<BankTransaction>> { ["xCalibur177"] = new List<BankTransaction>() };
		payupProfiles = new Dictionary<string, string> { ["xCalibur32"] = "xCalibur177" };
		foreach (string[] item in ResourcesManager.GetCSV("Names/players"))
		{
			GeneratePayupTransactions(username: item[0], payupAccount: item[3].Trim());
		}
		AddNonPlayerPayupTransactions();
	}

	private static void AddNonPlayerPayupTransactions()
	{
		string[] array = new string[5] { "cashboys", "llm", "rareclub", "safelysold", "xCalibur177" };
		foreach (string text in array)
		{
			switch (text)
			{
			case "xCalibur177":
				AddTransaction(19980618, 1820, text, "smartsue", -20, "makemoney");
				AddTransaction(19980625, CreateTablesHelpers.GetRandomTime(9, 19), text, "jessblue", 80, "For your stuff");
				AddTransaction(19980622, CreateTablesHelpers.GetRandomTime(9, 19), text, "cashboys", -80, "Buying more weapons");
				AddTransaction(19980620, CreateTablesHelpers.GetRandomTime(9, 19), text, "cashboys", -100, "Buying weapons");
				AddTransaction(19980622, CreateTablesHelpers.GetRandomTime(9, 19), text, "cashboys", 120, "Selling some drops");
				AddTransaction(19980610, CreateTablesHelpers.GetRandomTime(9, 19), text, "mrpeasant", -10, "Trade offer");
				AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), text, "leeroy", 10, "3 packs of gum");
				AddTransaction(19980504, CreateTablesHelpers.GetRandomTime(9, 19), text, "safelysold", -70, "buying uncommon axe");
				AddTransaction(19980622, CreateTablesHelpers.GetRandomTime(9, 19), text, "kad", -15, "GREAT DEALS");
				AddTransaction(19980618, CreateTablesHelpers.GetRandomTime(9, 19), text, "kad", -20, "hope this is what I owe");
				AddTransaction(19980512, CreateTablesHelpers.GetRandomTime(9, 19), text, "leeroy", 50, "for you");
				AddTransaction(19980613, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 25, "as promised");
				break;
			case "cashboys":
				AddTransaction(19980426, CreateTablesHelpers.GetRandomTime(9, 19), text, "bettyboo", 50, "babyBoo member fee");
				AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), text, "bettyboo", 20, "for month of May");
				AddTransaction(19980602, CreateTablesHelpers.GetRandomTime(9, 19), text, "bettyboo", 250, "inventory access");
				AddTransaction(19980602, CreateTablesHelpers.GetRandomTime(9, 19), text, "bettyboo", 20, "for month of June");
				AddTransaction(19980514, CreateTablesHelpers.GetRandomTime(9, 19), text, "robertsmith", 50, "First member payment!");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "robertsmith", 50, "bobert June payment");
				AddTransaction(19980611, CreateTablesHelpers.GetRandomTime(9, 19), text, "robertsmith", 50, "small donation!");
				AddTransaction(19980627, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", -250, "buying mace + sword for guild");
				AddTransaction(19980428, CreateTablesHelpers.GetRandomTime(9, 19), text, "blabby", 50, "entrance fee");
				AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), text, "blabby", 20, "may pay");
				AddTransaction(19980603, CreateTablesHelpers.GetRandomTime(9, 19), text, "blabby", 20, "june pay");
				AddTransaction(19980515, CreateTablesHelpers.GetRandomTime(9, 19), text, "avacados", 50, "joining fee!");
				AddTransaction(19980416, CreateTablesHelpers.GetRandomTime(9, 19), text, "cashmoney", 250, "Ensuring the guild has enough");
				AddTransaction(19980423, CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", 100, "first payment");
				AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", 100, "second payment");
				AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", 100, "third payment");
				AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", -150, "buying grinch weapons");
				AddTransaction(19980419, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 50, "member fee");
				AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 20, "first month payment");
				AddTransaction(19980520, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 120, "donation");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 20, "second month payment");
				AddTransaction(19980611, CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 250, "donation");
				AddTransaction(19980419, CreateTablesHelpers.GetRandomTime(9, 19), text, "jmeister", 50, "Buying membership");
				AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), text, "jmeister", 100, "Monthly fee + donation");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "jmeister", 150, "Monthly fee + donation");
				AddTransaction(19980425, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 50, "membership for BUDDY");
				AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 20, "May fee for BUDDY");
				AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 30, "donation for weapons");
				AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 30, "more donations");
				AddTransaction(19980520, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 30, "another donation");
				AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 20, "June fee for BUDDY");
				AddTransaction(19980610, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 30, "ANOTHER donation");
				AddTransaction(19980620, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 30, "yet another donation");
				AddTransaction(19980620, CreateTablesHelpers.GetRandomTime(9, 19), text, "joebudd", 100, "Buying");
				AddTransaction(19980516, CreateTablesHelpers.GetRandomTime(9, 19), text, "mrpeasant", 50, "Membership for peasant100");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "mrpeasant", 20, "peasant100 June payment");
				AddTransaction(19980424, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 50, "Membership");
				AddTransaction(19980427, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 200, "payup access");
				AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 20, "May");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 20, "June");
				AddTransaction(19980429, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 300, "buying weapons");
				AddTransaction(19980507, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 150, "buying weapons");
				AddTransaction(19980513, CreateTablesHelpers.GetRandomTime(9, 19), text, "unobiggs", 250, "Membership for biggun");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "unobiggs", 20, "June fee");
				AddTransaction(19980621, CreateTablesHelpers.GetRandomTime(9, 19), text, "sodawoman", 50, "First time fee");
				AddTransaction(19980611, CreateTablesHelpers.GetRandomTime(9, 19), text, "yungtrader", 50, "BECOMING A CASH BOY");
				AddTransaction(19980520, CreateTablesHelpers.GetRandomTime(9, 19), text, "xCalibur177", 50, "Member fee");
				AddTransaction(19980606, CreateTablesHelpers.GetRandomTime(19, 23), text, "xCalibur177", 20, "June payment! Almost forgot :)");
				AddTransaction(19980426, CreateTablesHelpers.GetRandomTime(9, 19), text, "potatoboy", 50, "Becoming member");
				AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), text, "potatoboy", 200, "Elite access and may payment");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "potatoboy", 20, "June");
				AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), text, "ladyluck", 50, "member");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "ladyluck", 20, "payment");
				AddTransaction(19980425, CreateTablesHelpers.GetRandomTime(9, 19), text, "bugeater", 50, "Membership fee");
				AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), text, "bugeater", 20, "Monthly payment");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "bugeater", 20, "Monthly payment");
				AddTransaction(19980428, CreateTablesHelpers.GetRandomTime(9, 19), text, "bettyboo", -50, "Buying daggers");
				AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), text, "monstor", 50, "Becoming member");
				AddTransaction(19980602, CreateTablesHelpers.GetRandomTime(9, 19), text, "monstor", 20, "for june");
				AddTransaction(19980508, CreateTablesHelpers.GetRandomTime(9, 19), text, "goodchap", 50, "membership!");
				AddTransaction(19980602, CreateTablesHelpers.GetRandomTime(9, 19), text, "goodchap", 20, "Renewing membership for June");
				AddTransaction(19980620, CreateTablesHelpers.GetRandomTime(9, 19), text, "hatter", 50, "Membership fee for hathair");
				AddTransaction(19980504, CreateTablesHelpers.GetRandomTime(9, 19), text, "chasesmith", 50, "Cash Boy membership");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "chasesmith", 20, "Cash Boy payment June");
				AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), text, "meepers", 50, "Becoming cash boy");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "meepers", 20, "June");
				AddTransaction(19980520, CreateTablesHelpers.GetRandomTime(9, 19), text, "phillip11", 50, "phi11ip Membership");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "phillip11", 20, "Recurring payment (June)");
				AddTransaction(19980625, CreateTablesHelpers.GetRandomTime(9, 19), text, "watergun", 50, "Membership payment here?");
				AddTransaction(19980620, CreateTablesHelpers.GetRandomTime(9, 19), text, "nightblank", 50, "Want to be member (blankie1)");
				AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 19), text, "pay2play", 250, "Premium membership");
				AddTransaction(19980428, CreateTablesHelpers.GetRandomTime(9, 19), text, "pastabro", 50, "Membership fee");
				AddTransaction(19980504, CreateTablesHelpers.GetRandomTime(9, 19), text, "pastabro", 20, "Monthly fee");
				AddTransaction(19980606, CreateTablesHelpers.GetRandomTime(9, 19), text, "pastabro", 20, "Monthly fee");
				AddTransaction(19980629, CreateTablesHelpers.GetRandomTime(9, 19), text, "vendetta", 50, "membership");
				AddTransaction(19980424, CreateTablesHelpers.GetRandomTime(9, 19), text, "nepolitan", 50, "Cash Boys membership for nepo");
				AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), text, "nepolitan", 20, "May fee");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "nepolitan", 20, "June fee");
				AddTransaction(19980621, CreateTablesHelpers.GetRandomTime(9, 19), text, "nepolitan", 180, "Inventory + payup access");
				AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), text, "sarahtiss", 70, "June + Membership fee");
				AddTransaction(19980610, CreateTablesHelpers.GetRandomTime(9, 19), text, "safelysold", -300, "uncommon weapons");
				AddTransaction(19980627, CreateTablesHelpers.GetRandomTime(9, 19), text, "nepolitan", 100, "Buying some weapons");
				break;
			case "safelysold":
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "sweetie9", 80, "buying uncommon dagger + axe");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "sweetie9", 300, "buying a rare!");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "sunnyday", 50, "buying poisoned sword");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "jump4joy", 10, "buying starting wep");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "fasttrack", 40, "buying rusted stuff");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "happycat", 400, "buying the good stuff");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "sweetie9", 80, "buying more weapons");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "shireborn", 50, "buying some maces");
				break;
			case "rareclub":
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "merchMan", 400, "Cant believe this is for sale");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "merchMan", 300, "rare effects");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "merchMan", 50, "buying poisoned sword");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "hfrick", 210, "calling dibs on the sword");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "hfrick", 400, "buying the good stuff");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "rockfella", 125, "crazy deal for rares");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "rockfella", 580, "rare poisoned weps");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "rockfella", 500, "rare electrics");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "purplefella", 50, "rusted stuff");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "barron", 850, "buying back rare sword");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "barron", -1300, "pawning some rares");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 400, "Rare");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "moneyman", 50, "buying some maces");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", -100, "selling some non rares");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "grinch", 200, "snagging the rare");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "wond3rful", 300, "valuable rare");
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), text, "purplefella", 150, "rare rusted mace");
				AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 150, "i need this");
				AddTransaction(19980604, CreateTablesHelpers.GetRandomTime(9, 19), text, "fatcat", 150, "i also need this");
				break;
			case "llm":
				AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), text, "smartsue", -20, "your commission");
				AddTransaction(19980508, CreateTablesHelpers.GetRandomTime(9, 19), text, "happycat", 200, "this is for huberts axe");
				AddTransaction(19980505, CreateTablesHelpers.GetRandomTime(9, 19), text, "stocknbonds", 150, "Buying axe");
				AddTransaction(19980403, CreateTablesHelpers.GetRandomTime(9, 19), text, "jimmyJohn", -10, "Nice job! Here you go");
				AddTransaction(19980401, CreateTablesHelpers.GetRandomTime(9, 19), text, "happycat", 100, "I need these uncommons");
				AddTransaction(19980401, CreateTablesHelpers.GetRandomTime(9, 19), text, "yungtrader", 85, "Two weapons");
				AddTransaction(19980610, CreateTablesHelpers.GetRandomTime(9, 19), text, "henryf", 220, "Nice rare");
				AddTransaction(19980606, CreateTablesHelpers.GetRandomTime(9, 19), text, "bovinewar", 30, "great pitch");
				AddTransaction(19980608, CreateTablesHelpers.GetRandomTime(9, 19), text, "chasan", 70, "How did you know I wanted this");
				AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), text, "chasan", 40, "Great lore knowledge! Thanks for selling");
				AddTransaction(19980310, CreateTablesHelpers.GetRandomTime(9, 19), text, "nirpg", 40, "Great deal, thanks");
				AddTransaction(19980224, CreateTablesHelpers.GetRandomTime(9, 19), text, "hearto", 120, "Thanks for keeping this for me");
				AddTransaction(19980210, CreateTablesHelpers.GetRandomTime(9, 19), text, "apero", 40, "BUYING WHAT YOU GOT");
				AddTransaction(19980314, CreateTablesHelpers.GetRandomTime(9, 19), text, "happyb", 20, "using this for peaceful purposes");
				AddTransaction(19980214, CreateTablesHelpers.GetRandomTime(9, 19), text, "shireborn", -5, "commission");
				AddTransaction(19980210, CreateTablesHelpers.GetRandomTime(9, 19), text, "meepers", 25, "Great deals!");
				AddTransaction(19980320, CreateTablesHelpers.GetRandomTime(9, 19), text, "shopkeepr1", -8, "commission");
				AddTransaction(19980314, CreateTablesHelpers.GetRandomTime(9, 19), text, "hfrick", 80, "Thanks shopkeepr");
				AddTransaction(19980125, CreateTablesHelpers.GetRandomTime(9, 19), text, "shopkeepr1", -4, "commission");
				AddTransaction(19980121, CreateTablesHelpers.GetRandomTime(9, 19), text, "bovinewar", 40, "Didnt even know I wanted this!");
				AddTransaction(19980120, CreateTablesHelpers.GetRandomTime(9, 19), text, "shopkeepr1", -12, "commission");
				AddTransaction(19980117, CreateTablesHelpers.GetRandomTime(9, 19), text, "sunnyday", 120, "Cant believe you have this");
				AddTransaction(19980215, CreateTablesHelpers.GetRandomTime(9, 19), text, "shopkeepr1", -3, "commission");
				AddTransaction(19980122, CreateTablesHelpers.GetRandomTime(9, 19), text, "chasan", 30, "good starter weapon!");
				break;
			}
		}
	}

	private static void GeneratePayupTransactions(string payupAccount, string username)
	{
		if (payupAccount.Length <= 0)
		{
			return;
		}
		payupProfiles[username] = payupAccount;
		switch (username)
		{
		case "goldtooth":
			AddTransaction(19980629, 1245, payupAccount, "fatcat", 820, "Buying your axe!");
			AddTransaction(19980628, 1740, payupAccount, "sefrgswrg", -2150, "rare burning sword");
			AddTransaction(19980624, 1521, payupAccount, "rareclub", -300, "rare burning dagger");
			AddTransaction(19980601, 915, payupAccount, "rent4ever", -1600, "second rent payment");
			AddTransaction(19980516, 1319, payupAccount, "rareclub", -800, "rare poison axe");
			AddTransaction(19980501, 903, payupAccount, "rent4ever", -1600, "first rent payment");
			AddTransaction(19980516, 1319, payupAccount, "rareclub", -400, "rare mace");
			return;
		case "sefrgswrg":
			AddTransaction(19980628, 1520, payupAccount, "cashboys", -1800, "");
			AddTransaction(19980627, 1120, payupAccount, "galpal", 20, "Drinks for yesterday");
			AddTransaction(19980627, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "jeffp", -35, "Payback");
			AddTransaction(19980608, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "jeffp", 700, "Rent split");
			AddTransaction(19980603, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -1700, "Monthly rent");
			AddTransaction(19980627, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "tomhsu", -80, "Thanks for the help");
			AddTransaction(19980505, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "jeffp", 700, "Rent split");
			AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -1700, "Monthly rent");
			AddTransaction(19980405, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "xXxFighterxXx", 180, "Medical bills for mom");
			AddTransaction(19980401, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -1700, "First rent payment");
			return;
		case "jmeister":
		{
			AddTransaction(19980603, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "murkyb", 20, "Tip");
			AddTransaction(19980412, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "jeffp", 5, "Thanks!");
			AddTransaction(19980605, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "emilek", 1300, "Last time I`m doing this");
			AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "emilek", 1500, "You owe me");
			AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 419, driverMessage);
			AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 400, driverMessage);
			AddTransaction(19980515, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 413, driverMessage);
			AddTransaction(19980503, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "pinkle", 10, "Had to ride again, thanks!");
			AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 417, driverMessage);
			AddTransaction(19980415, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 410, driverMessage);
			AddTransaction(19980421, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "pinkle", 15, "Fun ride! Thanks");
			AddTransaction(19980401, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 470, driverMessage);
			AddTransaction(19980315, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 413, driverMessage);
			AddTransaction(19980308, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "arture1", 12, "thanks for the ride");
			AddTransaction(19980317, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "bigman", 3, "10% Tip");
			AddTransaction(19980301, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 340, driverMessage);
			int num = 1265;
			AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -num, "june rent4ever.com rent payment");
			AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -num, "may rent4ever.com payment");
			AddTransaction(19980403, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -num, "april rent4ever.com payment");
			AddTransaction(19980301, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -num, "march rent4ever.com payment");
			AddTransaction(19980201, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -num, "first rent4ever.com payment");
			AddTransaction(19980512, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -30, "Donation");
			AddTransaction(19980514, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -25, "Donation");
			AddTransaction(19980514, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -20, "Donation");
			AddTransaction(19980606, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -20, "Donation");
			AddTransaction(19980420, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -29, "Donation");
			AddTransaction(19980627, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -31, "Donation");
			AddTransaction(19980409, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -17, "Donation");
			AddTransaction(19980501, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -15, "Donation");
			AddTransaction(19980401, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -12, "Donation");
			AddTransaction(19980201, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -24, "Donation");
			AddTransaction(19980225, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -20, "Donation");
			AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "clowner", 400, "Thanks for the referral");
			return;
		}
		case "BUDDY":
			AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -15, "You are heroes!!");
			AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -25, "Donation");
			AddTransaction(19980610, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -150, "Doing my part");
			AddTransaction(19980607, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "degabo", 15, "You the best");
			AddTransaction(19980603, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "bigman", 5, "25% Tip");
			AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 10), payupAccount, "clowncar", 640, driverMessage);
			AddTransaction(19980601, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -1840, "rent4ever.com payment for June");
			AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "johnfrog", 850, "Rent + Electricity");
			AddTransaction(19980508, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "forrunner", -20, "Bagel and coffee");
			AddTransaction(19980502, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rent4ever", -1840, "rent4ever.com payment for May");
			AddTransaction(19980510, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "savelivesDOTgov", -100, "Doing what I can");
			GenerateRandomPayupTransactions(5, payupAccount);
			return;
		}
		if (membersToGuilds.ContainsKey(username) && membersToGuilds[username].Contains("KAD"))
		{
			string[] list = new string[9] { "tithe", "for the holy weapons", "thank you knight", "for our mission", "advancing our cause", "Keep on shining", "for the holy mission", "knightly contribution", "a small price to pay" };
			for (int i = 0; i < CreateTablesHelpers.RANDY.Next(0, 3); i++)
			{
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 3, 6, 12), CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "kad", CreateTablesHelpers.RANDY.Next(3, 20), CreateTablesHelpers.GetRandomValue(list));
			}
		}
		else if (membersToGuilds.ContainsKey(username) && membersToGuilds[username].Contains("SAFE"))
		{
			string[] list2 = new string[6] { "buying weapons", "buying", "trading for some weapons", "buying weps", "accept my offer", "transferring funds" };
			for (int j = 0; j < CreateTablesHelpers.RANDY.Next(0, 3); j++)
			{
				AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 1, 6), CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "safelysold", CreateTablesHelpers.RANDY.Next(5, 31) * 5, CreateTablesHelpers.GetRandomValue(list2));
			}
		}
		else
		{
			if (username == "grinch")
			{
				AddTransaction(19980615, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rockfella", 150, "as agreed on");
				AddTransaction(19980624, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "eatbug", -30, "buying your cheap weps");
				AddTransaction(19980629, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "moneyman", 300, "election donation!");
				AddTransaction(19980616, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "rockfella", 50, "forgot about this");
				AddTransaction(19980616, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "fatcat", 80, "buy some weps with this :)");
				AddTransaction(19980624, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "jmeister", -100, "here you go buddy");
			}
			else if (username == "moneyman")
			{
				AddTransaction(19980616, CreateTablesHelpers.GetRandomTime(9, 19), payupAccount, "fatcat", 500, "Thanks for the rares!");
			}
			GenerateRandomPayupTransactions(3, payupAccount);
		}
	}

	private static void GenerateRandomPayupTransactions(int times, string payupAccount)
	{
		for (int i = 0; i < times; i++)
		{
			AddRandomTransaction(payupAccount);
		}
	}

	private static void AddRandomTransaction(string payupAccount)
	{
		string randomValue = CreateTablesHelpers.GetRandomValue(expenses.Keys);
		int num = expenseCalculations[expenses[randomValue]]();
		AddTransaction(CreateTablesHelpers.GetRandomDate(1998, 1998, 2, 6), price: num * (CreateTablesHelpers.RANDY.Next(0, 2) * 2 - 1), time: CreateTablesHelpers.GetRandomTime(9, 19), account1: payupAccount, account2: GeneratePayupUsername(), note: randomValue);
	}

	private static void ParsePayupTransactions()
	{
		expenses = new Dictionary<string, ExpenseSize>();
		foreach (string[] item in ResourcesManager.GetCSV("Names/payup"))
		{
			string key = item[0];
			string size = item[1];
			expenses[key] = GetExpenseEnum(size);
		}
	}

	private static ExpenseSize GetExpenseEnum(string size)
	{
		return size.Trim() switch
		{
			"S" => ExpenseSize.Small, 
			"M" => ExpenseSize.Medium, 
			"L" => ExpenseSize.Large, 
			"X" => ExpenseSize.Extreme, 
			_ => throw new ArgumentException("size=" + size + " not supported."), 
		};
	}

	private static List<Vote> GetCashBoysVotes()
	{
		List<Vote> list = new List<Vote>();
		AddVote(list, "grinch", "grinch", 1318);
		AddVote(list, "moneyman", "grinch", 2123);
		AddVote(list, "fatcat", "grinch", 2341);
		AddVote(list, "jmeister", "grinch", 552);
		AddVote(list, "biggun", "grinch", 404);
		AddVote(list, "BUDDY", "grinch", 619);
		AddVote(list, "babyBoo", "grinch", 240);
		AddVote(list, "bobert", "bobert", 377);
		AddVote(list, "chaserrr", "bobert", 418);
		AddVote(list, "xCalibur32", "bobert", 280);
		AddVote(list, "peasant100", "bobert", 21);
		AddVote(list, "eatbug", "bobert", 412);
		AddVote(list, "nepo", "bobert", 641);
		AddVote(list, "SMARTY", "bobert", 55);
		AddVote(list, "monstor", "bobert", 182);
		AddVote(list, "Blabby", "bobert", 104);
		AddVote(list, "chapstick", "bobert", 87);
		AddVote(list, "hathair", "bobert", 110);
		AddVote(list, "phi11ip", "bobert", 94);
		AddVote(list, "meep", "bobert", 114);
		AddVote(list, "pay2play", "bobert", 858);
		AddVote(list, "watergun", "bobert", 43);
		AddVote(list, "tissues400", "bobert", 97);
		AddVote(list, "blankie1", "bobert", 149);
		AddVote(list, "vendetta", "bobert", 352);
		AddVote(list, "tissues400", "bobert", 188);
		AddVote(list, "yungtrader", "bobert", 94);
		AddVote(list, "sevenup", "bobert", 166);
		AddVote(list, "pastabro", "bobert", 143);
		return list;
		static void AddVote(List<Vote> votes, string player, string votedFor, int value)
		{
			int vote_weighted = (int)Math.Round((double)value / 10.0);
			votes.Add(new Vote(player, votedFor, value, vote_weighted));
		}
	}

	private static string GeneratePayupUsername(string firstName, string lastName)
	{
		string text = firstName.ToLowerInvariant();
		string text2 = lastName;
		if (CreateTablesHelpers.IsPercentChance(50))
		{
			text2 = text2.ToLowerInvariant();
		}
		return text[0] + text2;
	}

	private static string GeneratePayupUsername()
	{
		string randomFirstName = CreateTablesHelpers.GetRandomFirstName();
		string randomLastName = CreateTablesHelpers.GetRandomLastName();
		return GeneratePayupUsername(randomFirstName, randomLastName);
	}

	private static void AddTransaction(int date, int time, string account1, string account2, int price, string note)
	{
		if (!payupAccounts.ContainsKey(account1))
		{
			payupAccounts[account1] = new List<BankTransaction>();
		}
		if (!payupAccounts.ContainsKey(account2))
		{
			payupAccounts[account2] = new List<BankTransaction>();
		}
		payupAccounts[account1].Add(new BankTransaction(date, time, account2, price, note));
		payupAccounts[account2].Add(new BankTransaction(date, time, account1, -price, note));
	}

	public static string GetDescription(HashSet<string> possibleDescriptions, string payupAccount, string guild)
	{
		string text = CreateTablesHelpers.GetRandomValue(possibleDescriptions);
		if (payupAccount.Length > 0 && guild != "KAD")
		{
			text = text + "\n<color=#3F58CC><link>payup.com/pay/" + payupAccount + "</link></color>";
		}
		return text;
	}

	public static Dictionary<string, HashSet<string>> GetPossibleDescriptions()
	{
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
		foreach (string[] item2 in ResourcesManager.GetCSV("Names/player_descriptions"))
		{
			string key = item2[0];
			string item = item2[1];
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new HashSet<string>();
			}
			dictionary[key].Add(item);
		}
		return dictionary;
	}

	public static bool LoadWebsiteDownloads(IDbConnection connection)
	{
		drivers = new List<Driver>();
		rentals = new List<Rental>();
		donationTiers = new Dictionary<savelives.Tiers, List<Person>>();
		if (!CreateTablesHelpers.LoadSavedTable(connection, clowncar.TABLE_NAME, LoadDriver) || !CreateTablesHelpers.LoadSavedTable(connection, rent4ever.TABLE_NAME, LoadRental))
		{
			return false;
		}
		Debug.Log($"drivers count -> {drivers.Count}");
		Debug.Log($"rentals count -> {rentals.Count}");
		string[] tABLE_NAMES = savelives.TABLE_NAMES;
		foreach (string text in tABLE_NAMES)
		{
			savelives.Tiers tier = savelives.GetTier(text);
			donationTiers[tier] = new List<Person>();
			if (!CreateTablesHelpers.LoadSavedTable(connection, text, LoadSupporter))
			{
				return false;
			}
			Debug.Log($"{text} count -> {donationTiers[tier].Count}");
			void LoadSupporter(string[] row)
			{
				donationTiers[tier].Add(Person.BuildFromRow(row));
			}
		}
		return true;
		static void LoadDriver(string[] row)
		{
			drivers.Add(Driver.BuildFromRow(row));
		}
		static void LoadRental(string[] row)
		{
			rentals.Add(Rental.BuildFromRow(row));
		}
	}

	public static bool LoadGeneratedWebsiteDownloads(IDbConnection connection)
	{
		ICollection<string> accountNames = new HashSet<string>();
		if (!CreateTablesHelpers.LoadSavedTable(connection, payup_account.ACCOUNTS_NAME, delegate(string[] row)
		{
			accountNames.Add(row[0]);
		}))
		{
			return false;
		}
		payupAccounts = new Dictionary<string, List<BankTransaction>>();
		foreach (string item in accountNames)
		{
			string account = item;
			payupAccounts[account] = new List<BankTransaction>();
			if (!CreateTablesHelpers.LoadSavedTable(connection, payup_account.GetTableName(account), AddPayup))
			{
				return false;
			}
			void AddPayup(string[] row)
			{
				payupAccounts[account].Add(BankTransaction.BuildFromRow(row));
			}
		}
		Debug.Log($"accounts count -> {payupAccounts.Keys.Count}");
		return true;
	}

	public static void Create(bool hasLoad)
	{
		using (IDbConnection dbConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(dbConnection, everyone, hasLoad) && LoadWebsiteDownloads(dbConnection) && LoadGeneratedWebsiteDownloads(dbConnection))
			{
				return;
			}
		}
		DatabaseUtils.DropAllTables();
		ParsePayupTransactions();
		LoadCharacterTransactions();
		LoadSuspectWebsites();
		CreateDamageLogTable(DamageLogGenerator.Generate(characters, membersToGuilds));
		AddSpecialNames();
		SavePayupTransactions();
		Level.SaveData(culprit.firstName, culprit.lastName, everyone);
	}

	private static void SavePayupTransactions()
	{
		IDbConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		DatabaseUtils.Begin(connection);
		foreach (string key in payupAccounts.Keys)
		{
			CreatePayupAccountTable(key, connection, commit: false);
		}
		DatabaseUtils.Commit(connection);
		SavePayupAccounts(connection);
		connection.Close();
	}

	public static void SavePayupAccounts(IDbConnection connection)
	{
		string fields = "name TEXT";
		string[] fields2 = new string[1] { "name" };
		DatabaseUtils.CreateTable(connection, payup_account.ACCOUNTS_NAME, fields);
		CreateTablesHelpers.PopulateTable(connection, payup_account.ACCOUNTS_NAME, fields2, payupAccounts.Keys, CreateTablesHelpers.SqlRowStringFunc);
		Debug.Log($"accounts count -> {payupAccounts.Keys.Count}");
	}

	private static void AddSpecialNames()
	{
		CreateTablesHelpers.AddName(everyone, ("James", "Jonathan"));
		CreateTablesHelpers.AddName(everyone, ("Robert", "Smith"));
		CreateTablesHelpers.AddName(everyone, ("Jeffery", "Kennedy"));
	}

	private static List<string> LoadGuildProfiles()
	{
		guildNameMap = new Dictionary<string, string>();
		List<string> list = new List<string>();
		List<string[]> cSV = ResourcesManager.GetCSV("Names/guilds");
		Dictionary<string, GuildProfile> dictionary = new Dictionary<string, GuildProfile>();
		foreach (string[] item in cSV)
		{
			string text = item[0];
			string text2 = item[1];
			string description = item[2];
			string joining = item[3];
			dictionary.Add(text, new GuildProfile(text, text2, description, joining));
			list.Add(text);
			guildNameMap[text] = text2;
		}
		guild_profile.SetProfiles(dictionary);
		return list;
	}

	private static Character.Class ParsePlayerClass(string playerClass)
	{
		return playerClass switch
		{
			"Wa" => Character.Class.Warrior, 
			"Wi" => Character.Class.Wizard, 
			"B" => Character.Class.Bard, 
			_ => Character.Class.Rogue, 
		};
	}

	public static void CreateVotesTable(string tableName)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string text = "username";
		string text2 = "inventory_worth";
		string text3 = "candidate_voted";
		string text4 = "weighted_vote";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " INT, " + text3 + " TEXT, " + text4 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[4] { text, text2, text3, text4 }, GetCashBoysVotes());
	}

	public static void CreateGuildMembersTable(string guild, string tableName)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string text = "player_name";
		string text2 = "class";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, PRIMARY KEY(" + text + ")");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { text, text2 }, guildMembers[guild].OrderBy((GuildMember row) => row.username).ToList());
	}

	public static void CreateDamageLogTable(List<DamageLog> damageLog)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string tableName = "damage_log";
		string text = "time";
		string text2 = "character_damaged";
		string text3 = "damage_taken";
		string text4 = "weapon_used";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text4 + " TEXT, " + text3 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[4] { text, text2, text4, text3 }, damageLog);
	}

	public static void CreatePayupAccountTable(string account, IDbConnection connection = null, bool commit = true)
	{
		bool flag = connection == null;
		if (flag)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "time";
		string text3 = "payup_account";
		string text4 = "amount";
		string text5 = "note";
		DatabaseUtils.CreateTable(connection, payup_account.GetTableName(account), text + " INT, " + text2 + " INT, " + text3 + " TEXT, " + text4 + " INT, " + text5 + " TEXT");
		List<BankTransaction> list = payupAccounts[account];
		if (flag)
		{
			list = (from row in list
				orderby row.date descending, row.time descending
				select row).ToList();
		}
		CreateTablesHelpers.PopulateTable(connection, payup_account.GetTableName(account), new string[5] { text, text2, text3, text4, text5 }, list, commit);
		if (flag)
		{
			connection.Close();
		}
	}

	public static void CreateDriversTable(string tableName, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "first_name";
		string text2 = "last_name";
		string text3 = "neighborhood";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, drivers, commit: false);
	}

	public static void CreateRentalsTable(string tableName, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "neighborhood";
		string text2 = "bedrooms";
		string text3 = "bathrooms";
		string text4 = "monthly_rent";
		string text5 = "availability";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " INT, " + text3 + " INT, " + text4 + " INT, " + text5 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[5] { text, text2, text3, text4, text5 }, rentals, commit: false);
	}

	public static void CreateDonorsTable(string tableName, savelives.Tiers tier, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "first_name";
		string text2 = "last_name";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { text, text2 }, donationTiers[tier], commit: false);
	}

	private static void SetPlayerAppearances(Dictionary<string, Character> characters)
	{
		characters["xCalibur32"] = new Character(Character.Class.Warrior, 2, 3);
		characters["SMARTY"] = new Character(Character.Class.Wizard, 2, 1);
		characters["hampman"] = new Character(Character.Class.Warrior, 1, 2);
	}

	private static void SetPlayerDescriptions(Dictionary<string, string> descriptions)
	{
		descriptions["xCalibur32"] = "I mostly play this game for the trading. Also trying to join as many guilds as I can!\n\nMember of Lore Lovin' Merchants, CA$H BOY$, and Knights Against Darkness\n\nSend me an offer!\n<color=#3F58CC><link>payup.com/pay/xCalibur177</link></color>";
		descriptions["dannysue"] = "Founder of the Legends of New Hampshire wiki. If you'd like to join our guild, please contribute to our wiki page!";
		descriptions["jeffre"] = "I'm the main editor of newhampshire.wiki! Someone please help us I spend all of my time in the game researching for the page and it has consumed my life. This game isn't even fun for me anymore.";
		descriptions["GuildMaster1"] = "NOT taking any new guild applications currently. Also PLEASE do not send me messages if there's something wrong with guildsofnewhampshire.net and I am in-game. I will take care of it later.";
		descriptions["frogboy"] = "Always roleplaying, always in-character. Founder of the New Hampshire RP Club. Join us for roleplaying sessions every Tuesday! Send me a message (but not when I'm in-game, I will be in-character)";
		descriptions["merchMan"] = "Founder of the Rare Weapon Club. If you're looking to join, let me know which rare weapon you own.\n\n<color=#3F58CC><link>payup.com/pay/merchmister</link></color>";
		descriptions["wizKid"] = "I am the Grand Wizard of the Wise Wizards Guild. Are you worthy of joining our secret society of Wizards? Find me at night at New Shire City. Make sure you are not being followed. The verification process will start there.";
		descriptions["sefrgswrg"] = "Member of Peace Lovers and Bards Only!\nOccasional trader. Hang out with me in New Shire City!\n\n<color=#3F58CC><link>payup.com/pay/sefrgswrg</link></color>";
		descriptions["goldtooth"] = "Collector of the rarest weapons of New Hampshire! Send me an offer if you have a rare weapon you'd like to sell\n\n<color=#3F58CC><link>payup.com/pay/goldtooth</link></color>";
		descriptions["grinch"] = "Current president of THE CA$H BOY$, member of the Rare Weapons Club.\n\nConstantly trading, send me an offer!\n\n<color=#3F58CC><link>payup.com/pay/grinch</link></color>";
		descriptions["jmeister"] = "PROUD CA$H BOY\n\nAlways buying, send me an offer!\n<color=#3F58CC><link>payup.com/pay/jmeister</link></color>";
		descriptions["BUDDY"] = "Part of THE CA$H BOY$. Mostly spend my time trading.\n\n<color=#3F58CC><link>payup.com/pay/joebudd</link></color>";
		descriptions["peasant100"] = "Always looking for a good offer! Trying to own a rare weapon one day.\n\n<color=#3F58CC><link>payup.com/pay/mrpeasant</link></color>";
		descriptions["fatcat"] = "Buying any and all rare weapons. Part of the Cash Boys and Rare Weapons Club.\n\nPayup account: <color=#3F58CC><link>payup.com/pay/fatcat</link></color>";
		descriptions["bobert"] = "Just trying to help players in this game any way I can. Let me know if you want to fight some monsters in this game!\n\nTrades here: <color=#3F58CC><link>payup.com/pay/robertsmith</link></color>";
		descriptions["moneyman"] = "Prolific trader and important member of THE CA$H BOY$ and Rare Weapons Club.\nOffers here -> <color=#3F58CC><link>payup.com/pay/moneyman</link></color>";
		descriptions["potatoboy"] = "BUYING WEAPONS!!! GOOD OFFERS ONLY!!!\n\n<color=#3F58CC><link>payup.com/pay/potatoboy</link></color>";
		descriptions["monstor"] = "SELLING RARE DAGGER!\n\nOFFERS HERE: <color=#3F58CC><link>payup.com/pay/monstor</link></color>";
		descriptions["chaserrr"] = "I trade sometimes but I mostly play this game for fun. If you have an offer send it here: <color=#3F58CC><link>payup.com/pay/chasesmith</link></color>";
		descriptions["avacados"] = "Temporarily going to stop playing this game. Sorry friends :(";
		descriptions["luckylady777"] = "i am a very good player\n\n<color=#3F58CC><link>payup.com/pay/ladyluck</link></color>";
		descriptions["Blabby"] = "Please stop targeting me in the Dark Forests. I do not have a lot!";
		descriptions["pastabro"] = "Love playing with my bros! Member of the CA$H BOY$ and Bards Only. Trading? Go to <color=#3F58CC><link>payup.com/pay/plover</link></color>";
		descriptions["biggun"] = "Whattup everyone, im the best member of the CA$H BOY$. Catch me with an offer at <color=#3F58CC><link>payup.com/pay/unobiggs</link></color>\n(unobiggs is my nickname)";
		descriptions["babyBoo"] = "Trying to buy a rusted dagger?\n\nSend money to <color=#3F58CC><link>payup.com/pay/bettyboo</link></color>";
		descriptions["thecashboy"] = "Currently inactive. Founder of THE CA$H BOY$.\n\nPayup: <color=#3F58CC><link>payup.com/pay/cashmoney</link></color>";
		descriptions["hampman"] = "Your resident lore and sales expert. Looking for a good trading opportunity? Join the Lore Lovin' Merchants! Pass the LSAT at lsat.net\n\nSend me an offer here: <color=#3F58CC><link>payup.com/pay/teddyh</link></color>";
		descriptions["shopkeepr1"] = "Lore expert. Prolific trader. Member of Lore Lovin' Merchants. Named after my favorite New Hampshire character!\n\n<color=#3F58CC><link>payup.com/pay/shopkeep</link></color>";
		descriptions["jimmyJohn"] = "Getting into the trading community for this game! Currently a member of Lore Lovin' Merchants. Currently in the market to buy, send me any good offers!\n\n<color=#3F58CC><link>payup.com/pay/jamesjohn</link></color>";
		descriptions["kingmaker"] = "I love writing New Hampshire fanfiction! Member of Lore Lovin' Merchants. Selling custom stories of your character: <color=#3F58CC><link>payup.com/pay/queengreen</link></color>";
		descriptions["poorMAN"] = "I am not a rich man. I live in squalor, send me a donation please.\n\n<color=#3F58CC><link>payup.com/pay/jeffkenn</link></color>";
		descriptions["SMARTY"] = "Anyone want to buy an axe? Let me know!\n\n<color=#3F58CC><link>payup.com/pay/smartsue</link></color>";
		descriptions["shireborn"] = "Selling a RARE rusted dagger! Only fifty dollars, offers here: <color=#3F58CC><link>payup.com/pay/shireborn</link></color>";
		descriptions["bigNHfan"] = "Self proclaimed New Hampshire nerd. Send me an offer!\n\n<color=#3F58CC><link>payup.com/pay/bigburt</link></color>";
		descriptions["shiresire43"] = "Looking to join new guilds! Currently a member of LLM.\n\n<color=#3F58CC><link>payup.com/pay/shiresire</link></color>";
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

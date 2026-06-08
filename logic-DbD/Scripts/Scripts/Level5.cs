using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using UnityEngine;

public class Level5 : Level
{
	public const int LEVEL_NUMBER = 5;

	protected static ICollection<string> everyone = new HashSet<string>();

	private static List<DatingProfile> stars;

	private static List<Movie> movies;

	private static Dictionary<string, List<Review>> usersMovieReviews;

	private static Dictionary<string, List<Watch>> userWatchlists;

	private static readonly int SUSPECT_RATED_DATE = 19980624;

	private static readonly int SUSPECT_RATED_TIME = 1612;

	private static List<string> q3Responses = new List<string> { "Happiness", "Strength", "Money", "Love" };

	private static string[] suspectFoods = new string[2] { "Falafels", "Hummus" };

	private static string[] SINGLE_VISIT_SITES = new string[9] { "placeholder.com", "helpme.net", "moonhoax.net", "parking.gov", "pizzaslices.net", "potatoman.com", "legendsofnewhampshire.com", "smoothieworld.net", "errandboy.com" };

	private static DatingProfile suspect;

	private static string suspectIP;

	protected static Dictionary<string, Appearance> appearances = new Dictionary<string, Appearance>();

	public static void LoadWebsites()
	{
		LoadProfiles();
	}

	public static bool LoadWebsiteDownloads(IDbConnection connection)
	{
		movies = new List<Movie>();
		stars = new List<DatingProfile>();
		DatabaseUtils.Begin(connection);
		bool result = CreateTablesHelpers.LoadSavedTable(connection, mmdb.TABLE_NAME, LoadMovie) && CreateTablesHelpers.LoadSavedTable(connection, selectyourstar.TABLE_NAME, LoadDatingProfile) && LoadGeneratedWebsiteDownloads(connection);
		Debug.Log($"movies count -> {movies.Count}");
		Debug.Log($"stars count -> {stars.Count}");
		DatabaseUtils.Commit(connection);
		return result;
		static void LoadDatingProfile(string[] row)
		{
			stars.Add(DatingProfile.BuildFromRow(row));
		}
		static void LoadMovie(string[] row)
		{
			movies.Add(Movie.BuildFromRow(row));
		}
	}

	public static bool LoadGeneratedWebsiteDownloads(IDbConnection connection)
	{
		Dictionary<string, List<Review>> reviews = new Dictionary<string, List<Review>>();
		foreach (string[] item in ResourcesManager.GetCSV("Names/profiles"))
		{
			string username = item[0];
			reviews[username] = new List<Review>();
			if (!CreateTablesHelpers.LoadSavedTable(connection, mmdb_profile.REVIEWS_PREFIX + username, AddReview))
			{
				Debug.Log("Does not contain " + mmdb_profile.REVIEWS_PREFIX + username);
				return false;
			}
			void AddReview(string[] row)
			{
				reviews[username].Add(Review.BuildFromRow(row));
			}
		}
		usersMovieReviews = reviews;
		return true;
	}

	public static void Create(bool hasLoad)
	{
		using (IDbConnection dbConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(dbConnection, everyone, hasLoad) && LoadWebsiteDownloads(dbConnection))
			{
				suspectIP = Save.GetLevel5SuspectIP();
				Level.LoadAppearances(dbConnection, appearances);
				return;
			}
		}
		DatabaseUtils.DropAllTables();
		CreateWebsiteDownloads();
		int num = CreateTablesHelpers.RANDY.Next(25, 30);
		HashSet<string> ips = new HashSet<string>();
		IDbConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.Begin(connection);
		DatabaseUtils.CreateTable(connection, "web_searches", "ip_address TEXT, search_history TEXT, date_visited INT, time_visited INT");
		List<SearchHistory> list = new List<SearchHistory>();
		AddSuspectWebsites(GetUniqueIP(ips), list);
		List<string> profileNames = mmdb_profile.GetProfileNames();
		profileNames.Remove("ribbit78");
		profileNames.Remove("MolemanFan");
		profileNames.Remove("trueh8r");
		for (int i = 0; i < num; i++)
		{
			string uniqueIP = GetUniqueIP(ips);
			int num2 = CreateTablesHelpers.RANDY.Next(10, 25);
			while (num2 > 0)
			{
				HashSet<string> times = new HashSet<string>();
				HashSet<string> logins = new HashSet<string>();
				num2 -= AddRandomWebsite(uniqueIP, list, times, logins, profileNames);
			}
			switch (i)
			{
			case 1:
				list.Add(new SearchHistory(uniqueIP, "rateyourdictator.gov", 19980624, 1739));
				break;
			case 2:
				list.Add(new SearchHistory(uniqueIP, "rateyourdictator.gov", 19980624, 2019));
				break;
			case 3:
				list.Add(new SearchHistory(uniqueIP, "errandboy.com", 19980614, 1219));
				list.Add(new SearchHistory(uniqueIP, "errandboy.com/order/43q7p", 19980614, 1243));
				break;
			case 4:
				list.Add(new SearchHistory(uniqueIP, "errandboy.com", 19980623, 1432));
				list.Add(new SearchHistory(uniqueIP, "errandboy.com/order/67s9b", 19980623, 1443));
				break;
			}
		}
		string[] fields = new string[4] { "ip_address", "search_history", "date_visited", "time_visited" };
		list = (from a in list
			orderby a.date, a.time
			select a).ToList();
		CreateTablesHelpers.PopulateTable(connection, "web_searches", fields, list, commit: false);
		DatabaseUtils.Commit(connection);
		connection.Close();
		Level.SaveData(suspect.firstName, suspect.lastName, everyone, appearances);
	}

	public static Appearance GetAppearance(string name)
	{
		if (!appearances.ContainsKey(name))
		{
			return null;
		}
		return appearances[name];
	}

	private static void LoadProfiles()
	{
		List<string[]> cSV = ResourcesManager.GetCSV("Names/profiles");
		Dictionary<string, ProfileSettings> dictionary = new Dictionary<string, ProfileSettings>();
		foreach (string[] item in cSV)
		{
			string key = item[0];
			string bio = item[1];
			string image = item[2];
			string movieReviewed = item[3];
			string rating = item[4];
			string review = item[5];
			dictionary[key] = new ProfileSettings(image, bio, rating, review, movieReviewed);
		}
		mmdb_profile.SetProfiles(dictionary);
	}

	private static void LoadProfileDownloads(IDbConnection connection, List<string> juneHorror, string redHerringSuspectFilm, List<string> moviesFromDirectorsWithAwards, List<string> moviesOverAverageReviewsNoAward, List<string> suspectPerfectMovies)
	{
		List<string[]> cSV = ResourcesManager.GetCSV("Names/profiles");
		usersMovieReviews = new Dictionary<string, List<Review>>();
		userWatchlists = new Dictionary<string, List<Watch>>();
		foreach (string[] item in cSV)
		{
			string text = item[0];
			_ = item[1];
			_ = item[2];
			string text2 = item[3];
			string rating = item[4];
			_ = item[5];
			usersMovieReviews[text] = new List<Review>
			{
				new Review(text2, rating)
			};
			userWatchlists[text] = new List<Watch>();
			HashSet<string> hashSet = new HashSet<string> { text2 };
			if (text == mmdb_profile.SUSPECT_PROFILE)
			{
				AddSuspectMMDB(hashSet, redHerringSuspectFilm, moviesFromDirectorsWithAwards, juneHorror, moviesOverAverageReviewsNoAward, suspectPerfectMovies);
				CreateReviewsTable(text, connection, commit: false);
			}
			else if (text == "MolemanFan")
			{
				usersMovieReviews[text].Add(new Review("Moleman - The First Case", 10.0));
				usersMovieReviews[text].Add(new Review("Molemen", 10.0));
				usersMovieReviews[text].Add(new Review("Moles: Are they Real?", 10.0));
				usersMovieReviews[text].Add(new Review("Gone From Greenpoint", 10.0));
				usersMovieReviews[text].Add(new Review("Broken in Billsburg", 10.0));
				usersMovieReviews[text].Add(new Review("Killed in Kips Bay", 10.0));
				usersMovieReviews[text].Add(new Review("Forgotten in Flushing", 10.0));
				usersMovieReviews[text].Add(new Review("Wanted in West Virginia", 10.0));
				usersMovieReviews[text].Add(new Review("Haunted By Harlem", 10.0));
				usersMovieReviews[text].Add(new Review("No More Moles", 0.0));
				userWatchlists[text].Add(new Watch("Mad Moles"));
				userWatchlists[text].Add(new Watch("The Yargoslavian Question"));
				CreateReviewsTable(text, connection, commit: false);
			}
			else if (text == "trueh8r")
			{
				HashSet<string> hashSet2 = new HashSet<string>();
				for (int i = 0; i < 10; i++)
				{
					string randomValue = CreateTablesHelpers.GetRandomValue(moviesFromDirectorsWithAwards);
					if (!hashSet2.Contains(randomValue) && !(randomValue == "Moleman - The First Case"))
					{
						Debug.Log(randomValue);
						hashSet2.Add(randomValue);
						usersMovieReviews[text].Add(new Review(randomValue, CreateTablesHelpers.RANDY.Next(1, 9)));
					}
				}
				CreateReviewsTable(text, connection, commit: false);
			}
			else
			{
				for (int j = 0; j < CreateTablesHelpers.RANDY.Next(30, 100); j++)
				{
					string uniqueValue = CreateTablesHelpers.GetUniqueValue(hashSet, GenerateMovieTitle);
					double rating2 = (double)(CreateTablesHelpers.RANDY.Next(0, 100) * 10) / 100.0;
					usersMovieReviews[text].Add(new Review(uniqueValue, rating2));
				}
				usersMovieReviews[text] = usersMovieReviews[text].OrderBy((Review a) => CreateTablesHelpers.RANDY.Next()).ToList();
				for (int num = 0; num < CreateTablesHelpers.RANDY.Next(10, 30); num++)
				{
					string uniqueValue2 = CreateTablesHelpers.GetUniqueValue(hashSet, GenerateMovieTitle);
					userWatchlists[text].Add(new Watch(uniqueValue2));
				}
				CreateReviewsTable(text, connection, commit: false);
			}
		}
	}

	public static void CreateWebsiteDownloads()
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		DatabaseUtils.Begin(connection);
		List<string[]> cSV = ResourcesManager.GetCSV("Names/movies");
		string randomValue = CreateTablesHelpers.GetRandomValue(suspectFoods);
		(List<Movie>, List<string>, List<string>, List<string>, List<string>) tuple = ParseMovies(cSV);
		movies = tuple.Item1;
		List<string> item = tuple.Item2;
		List<string> item2 = tuple.Item3;
		List<string> item3 = tuple.Item4;
		List<string> item4 = tuple.Item5;
		movies = movies.OrderBy((Movie m) => m.title).ToList();
		CreateMovieTable(connection, commit: false);
		CreateTablesHelpers.GetRandomValue(item);
		(string, string) culprit = CreateTablesHelpers.GetCulprit(CreateTablesHelpers.femNames, CreateTablesHelpers.lastNames);
		suspect = new DatingProfile(culprit.Item1, culprit.Item2, q2: CreateTablesHelpers.GetRandomValue(item2), number: CreateTablesHelpers.GeneratePhoneNumber(), age: 20, q1: randomValue, q3: "Happiness");
		Debug.Log($"suspect: {suspect}");
		item2.Remove(suspect.q2);
		string randomValue2 = CreateTablesHelpers.GetRandomValue(item2);
		(List<DatingProfile>, List<string>) tuple2 = CreateGetStars(cSV, randomValue, randomValue2, item3);
		stars = tuple2.Item1;
		List<string> item5 = tuple2.Item2;
		stars = stars.OrderBy((DatingProfile a) => CreateTablesHelpers.RANDY.Next()).ToList();
		CreateStarsTable(connection, commit: false);
		Debug.Log($"stars count -> {stars.Count}");
		LoadProfileDownloads(connection, item, randomValue2, item3, item4, item5);
		DatabaseUtils.Commit(connection);
	}

	public static void CreateReviewsTable(string username, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string tableName = mmdb_profile.REVIEWS_PREFIX + username;
		DatabaseUtils.CreateTable(connection, tableName, "title TEXT, rating REAL, PRIMARY KEY(title)");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { "title", "rating" }, usersMovieReviews[username], commit);
	}

	public static void CreateWatchlistTable(string username, bool commit = true)
	{
		string tableName = "watchlist_" + username;
		SqliteConnection connection = DatabaseUtils.GetConnection();
		DatabaseUtils.CreateTable(connection, tableName, "title TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[1] { "title" }, userWatchlists[username], commit);
	}

	public static void CreateMovieTable(IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		DatabaseUtils.CreateTable(connection, mmdb.TABLE_NAME, "title TEXT, director TEXT, genre TEXT, year INT, month TEXT, rating REAL, ratings INT");
		CreateTablesHelpers.PopulateTable(connection, mmdb.TABLE_NAME, new string[7] { "title", "director", "genre", "year", "month", "rating", "ratings" }, movies, commit);
	}

	public static void CreateStarsTable(IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		DatabaseUtils.CreateTable(connection, selectyourstar.TABLE_NAME, "first_name TEXT, last_name TEXT, number TEXT, age INT, q1 TEXT, q2 TEXT, q3 TEXT");
		CreateTablesHelpers.PopulateTable(connection, selectyourstar.TABLE_NAME, new string[7] { "first_name", "last_name", "number", "age", "q1", "q2", "q3" }, stars, commit);
	}

	public static void CreateNutritionFactsTable()
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string tableName = "nutrition_facts";
		string text = "food_name";
		string text2 = "nutrient";
		string text3 = "nutrient_quantity";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, GetNutritionFactsTable());
	}

	public static void CreateOrdersTable(string tableName)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string text = "item_name";
		string text2 = "weight_in_grams";
		string text3 = "price";
		string text4 = "shipping_fee";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " INT, " + text3 + " REAL, " + text4 + " REAL");
		List<Order> rows = PopulateOrdersTable(tableName);
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[4] { text, text2, text3, text4 }, rows);
	}

	public static List<Order> PopulateOrdersTable(string tableName)
	{
		if (tableName == "order_74b8s")
		{
			return new List<Order>
			{
				new Order("NutUp", 50, 19.99, 0.49),
				new Order("NutUp", 50, 19.99, 0.49),
				new Order("NutUp", 50, 19.99, 0.49),
				new Order("Epazote", 50, 9.99, 0.99),
				new Order("Fermented Honey", 100, 4.99, 0.99),
				new Order("Bananas", 100, 0.99, 0.99),
				new Order("Bananas", 100, 0.99, 0.99),
				new Order("Bananas", 100, 0.99, 0.99),
				new Order("Bananas", 100, 0.99, 0.99),
				new Order("Kapow Fruit Mix", 100, 9.99, 0.99),
				new Order("Blue Tumeric", 200, 2.99, 1.49),
				new Order("Fennel", 100, 12.99, 0.99),
				new Order("Borage", 25, 1.99, 0.25),
				new Order("Wart Fungus", 50, 4.99, 0.49),
				new Order("Blessed Cinnamon", 100, 1.99, 0.99),
				new Order("Sweet Seaweed", 100, 3.99, 0.99)
			};
		}
		if (tableName == "order_67s9b")
		{
			return new List<Order>
			{
				new Order("NutUp", 50, 19.99, 0.49),
				new Order("Pepperoni Pizza", 350, 13.99, 3.49),
				new Order("Orange Soda", 150, 2.99, 1.49),
				new Order("Chicken Wings", 150, 2.99, 1.49),
				new Order("Fermented Honey", 100, 4.99, 0.99)
			};
		}
		return new List<Order>
		{
			new Order("NutUp", 50, 19.99, 0.49),
			new Order("NutUp", 50, 19.99, 0.49),
			new Order("NutUp", 50, 19.99, 0.49),
			new Order("NutUp", 50, 19.99, 0.49),
			new Order("Epazote", 50, 9.99, 0.49),
			new Order("Fish Eyes", 100, 4.99, 0.99),
			new Order("Fermented Honey", 100, 4.99, 0.99)
		};
	}

	public static List<NutrientFact> GetNutritionFactsTable()
	{
		return new List<NutrientFact>
		{
			new NutrientFact("NutUp", "bioflavenoids", 100),
			new NutrientFact("NutUp", "caretenoids", 100),
			new NutrientFact("NutUp", "gammatoids", 100),
			new NutrientFact("NutUp", "tocopheral", 10),
			new NutrientFact("NutUp", "guletanoids", 10),
			new NutrientFact("Kapow Fruit Mix", "bioflavenoids", 25),
			new NutrientFact("Kapow Fruit Mix", "caretenoids", 10),
			new NutrientFact("Kapow Fruit Mix", "gammatoids", 25),
			new NutrientFact("Kapow Fruit Mix", "tocopheral", 5),
			new NutrientFact("Kapow Fruit Mix", "guletanoids", 5),
			new NutrientFact("Bananas", "bioflavenoids", 5),
			new NutrientFact("Bananas", "caretenoids", 5),
			new NutrientFact("Bananas", "gammatoids", 5),
			new NutrientFact("Bananas", "tocopheral", 0),
			new NutrientFact("Bananas", "guletanoids", 0),
			new NutrientFact("Spinach", "bioflavenoids", 3),
			new NutrientFact("Spinach", "caretenoids", 3),
			new NutrientFact("Spinach", "gammatoids", 0),
			new NutrientFact("Spinach", "tocopheral", 3),
			new NutrientFact("Spinach", "guletanoids", 3),
			new NutrientFact("Borage", "bioflavenoids", 32),
			new NutrientFact("Borage", "caretenoids", 0),
			new NutrientFact("Borage", "gammatoids", 0),
			new NutrientFact("Borage", "tocopheral", 16),
			new NutrientFact("Borage", "guletanoids", 0),
			new NutrientFact("Epazote", "bioflavenoids", 30),
			new NutrientFact("Epazote", "caretenoids", 30),
			new NutrientFact("Epazote", "gammatoids", 30),
			new NutrientFact("Epazote", "tocopheral", 0),
			new NutrientFact("Epazote", "guletanoids", 0),
			new NutrientFact("Fennel", "bioflavenoids", 17),
			new NutrientFact("Fennel", "caretenoids", 6),
			new NutrientFact("Fennel", "gammatoids", 0),
			new NutrientFact("Fennel", "tocopheral", 3),
			new NutrientFact("Fennel", "guletanoids", 1),
			new NutrientFact("Berry Lotus", "bioflavenoids", 0),
			new NutrientFact("Berry Lotus", "caretenoids", 0),
			new NutrientFact("Berry Lotus", "gammatoids", 3),
			new NutrientFact("Berry Lotus", "tocopheral", 3),
			new NutrientFact("Berry Lotus", "guletanoids", 3),
			new NutrientFact("Blessed Cinnamon", "bioflavenoids", 2),
			new NutrientFact("Blessed Cinnamon", "caretenoids", 2),
			new NutrientFact("Blessed Cinnamon", "gammatoids", 0),
			new NutrientFact("Blessed Cinnamon", "tocopheral", 2),
			new NutrientFact("Blessed Cinnamon", "guletanoids", 0),
			new NutrientFact("Fermented Honey", "bioflavenoids", 25),
			new NutrientFact("Fermented Honey", "caretenoids", 25),
			new NutrientFact("Fermented Honey", "gammatoids", 5),
			new NutrientFact("Fermented Honey", "tocopheral", 7),
			new NutrientFact("Fermented Honey", "guletanoids", 2),
			new NutrientFact("Blue Tumeric", "bioflavenoids", 25),
			new NutrientFact("Blue Tumeric", "caretenoids", 15),
			new NutrientFact("Blue Tumeric", "gammatoids", 0),
			new NutrientFact("Blue Tumeric", "tocopheral", 1),
			new NutrientFact("Blue Tumeric", "guletanoids", 1),
			new NutrientFact("Wart Fungus", "bioflavenoids", 22),
			new NutrientFact("Wart Fungus", "caretenoids", 4),
			new NutrientFact("Wart Fungus", "gammatoids", 0),
			new NutrientFact("Wart Fungus", "tocopheral", 2),
			new NutrientFact("Wart Fungus", "guletanoids", 0),
			new NutrientFact("Fish Eyes", "bioflavenoids", 35),
			new NutrientFact("Fish Eyes", "caretenoids", 0),
			new NutrientFact("Fish Eyes", "gammatoids", 0),
			new NutrientFact("Fish Eyes", "tocopheral", 0),
			new NutrientFact("Fish Eyes", "guletanoids", 35),
			new NutrientFact("Sweet Seaweed", "bioflavenoids", 2),
			new NutrientFact("Sweet Seaweed", "caretenoids", 0),
			new NutrientFact("Sweet Seaweed", "gammatoids", 0),
			new NutrientFact("Sweet Seaweed", "tocopheral", 1),
			new NutrientFact("Sweet Seaweed", "guletanoids", 0)
		};
	}

	private static (List<DatingProfile>, List<string>) CreateGetStars(List<string[]> rawMovies, string suspectFood, string redHerringSuspectFilm, List<string> moviesFromDirectorsWithAwards)
	{
		string[] array = ResourcesManager.ParseTextFile("Names/foods");
		List<DatingProfile> list = new List<DatingProfile>();
		HashSet<string> numbers = new HashSet<string> { suspect.number };
		int num = CreateTablesHelpers.RANDY.Next(900, 1000);
		for (int i = 0; i < num; i++)
		{
			var (first, last) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, suspect.firstName, suspect.lastName);
			list.Add(GenerateRandomProfile(numbers, first, last, array, rawMovies));
		}
		list.Add(GenerateRandomProfile(numbers, "Maria", "Ada", array, rawMovies, 29));
		list.Add(GenerateRandomProfile(numbers, "Steven", "Rafael", array, rawMovies, 27));
		list.Add(suspect);
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>(moviesFromDirectorsWithAwards);
		string text = ((suspectFoods[0] == suspect.q1) ? suspectFoods[1] : suspectFoods[0]);
		for (int j = 0; j < 2; j++)
		{
			string randomValue = CreateTablesHelpers.GetRandomValue(list3);
			list2.Add(randomValue);
			list3.Remove(randomValue);
			list.Add(GenerateDupeProfile(numbers, 20, (j == 0) ? suspectFood : text, randomValue, suspect.q3));
		}
		q3Responses.Remove(suspect.q3);
		list.Add(GenerateDupeProfile(numbers, CreateTablesHelpers.RANDY.Next(35, 40), text, redHerringSuspectFilm, CreateTablesHelpers.GetRandomValue(q3Responses)));
		list.Add(GenerateDupeProfile(numbers, 21, text, suspect.q2, CreateTablesHelpers.GetRandomValue(q3Responses)));
		list.Add(GenerateDupeProfile(numbers, CreateTablesHelpers.RANDY.Next(25, 30), suspect.q1, suspect.q2, CreateTablesHelpers.GetRandomValue(q3Responses)));
		list.Add(GenerateDupeProfile(numbers, 24, CreateTablesHelpers.GetRandomValue(array), suspect.q2, suspect.q3));
		list.Add(GenerateDupeProfile(numbers, 20, CreateTablesHelpers.GetRandomValue(array), redHerringSuspectFilm, CreateTablesHelpers.GetRandomValue(q3Responses)));
		list.Add(GenerateDupeProfile(numbers, 20, "PB&J", redHerringSuspectFilm, CreateTablesHelpers.GetRandomValue(q3Responses)));
		list.Add(GenerateDupeProfile(numbers, 27, "PB&J", redHerringSuspectFilm, suspect.q3));
		return (list, list2);
	}

	private static DatingProfile GenerateRandomProfile(HashSet<string> numbers, string first, string last, string[] food, List<string[]> rawMovies, int givenAge = -1)
	{
		CreateTablesHelpers.AddName(everyone, (first, last));
		int age = ((givenAge == -1) ? CreateTablesHelpers.RANDY.Next(18, 45) : givenAge);
		appearances[(first + " " + last).ToUpperInvariant()] = new Appearance(age);
		return new DatingProfile(first, last, CreateTablesHelpers.GetUniqueValue(numbers, CreateTablesHelpers.GeneratePhoneNumber), age, CreateTablesHelpers.GetRandomValue(food), CreateTablesHelpers.GetRandomValue(rawMovies)[0], CreateTablesHelpers.GetRandomValue(q3Responses));
	}

	private static DatingProfile GenerateDupeProfile(HashSet<string> numbers, int age, string q1, string q2, string q3)
	{
		var (text, text2) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, suspect.firstName, suspect.lastName, everyone);
		appearances[(text + " " + text2).ToUpperInvariant()] = new Appearance(age);
		return new DatingProfile(text, text2, CreateTablesHelpers.GetUniqueValue(numbers, CreateTablesHelpers.GeneratePhoneNumber), age, q1, q2, q3);
	}

	private static (List<Movie>, List<string>, List<string>, List<string>, List<string>) ParseMovies(List<string[]> rawMovies)
	{
		List<Movie> list = new List<Movie>();
		List<string> list2 = new List<string>();
		HashSet<string> ids = new HashSet<string>();
		List<string> list3 = new List<string>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		while (list.Count < rawMovies.Count)
		{
			string uniqueValue = CreateTablesHelpers.GetUniqueValue(ids, GetDirectorName);
			int num5 = ((CreateTablesHelpers.RANDY.Next(100) > 75) ? CreateTablesHelpers.RANDY.Next(1, 4) : CreateTablesHelpers.RANDY.Next(4, 7));
			bool flag = false;
			int num6 = 0;
			List<string> list4 = new List<string>();
			while (num6 <= num5 && num4 < rawMovies.Count)
			{
				Movie movie = ParseMovie(rawMovies[num4], uniqueValue);
				if (movie.year == 1998 && movie.month == "June" && movie.genre == "Horror")
				{
					list2.Add(movie.title);
				}
				if (double.Parse(movie.rating) >= 8.5)
				{
					flag = true;
				}
				list4.Add(movie.title);
				list.Add(movie);
				num6++;
				num4++;
			}
			num3++;
			if (flag)
			{
				list3.AddRange(list4);
				num += num6;
				num2++;
			}
			else
			{
				dictionary[uniqueValue] = list4;
			}
		}
		List<string[]> list5 = (from a in ResourcesManager.GetCSV("Names/movies_favs")
			orderby CreateTablesHelpers.RANDY.Next()
			select a).ToList();
		List<string> list6 = new List<string>();
		int num7 = Mathf.FloorToInt((float)num / (float)num2);
		int num8 = CreateTablesHelpers.RANDY.Next(3, num7 - 1);
		string uniqueValue2 = CreateTablesHelpers.GetUniqueValue(ids, GetDirectorName);
		for (num4 = 0; num4 < num8; num4++)
		{
			list.Add(ParseMovie(list5[num4], uniqueValue2, suspect: true));
			list6.Add(list5[num4][0]);
		}
		List<string> item = new List<string>();
		Debug.Log($"Movies Count={list.Count}, " + $"Movies From Winners={num}, " + $"Medal Winners={num2}, " + $"Average Movies from Medal Winners={num7}");
		return (list, list2, list6, list3, item);
	}

	private static Movie ParseMovie(string[] rawMovie, string director, bool suspect = false)
	{
		string text = rawMovie[0];
		string genre = rawMovie[1].Trim();
		int num = -1;
		string text2 = null;
		double num2 = -1.0;
		int num3 = -1;
		for (int i = 2; i < rawMovie.Length; i++)
		{
			if (rawMovie.Length > i)
			{
				string text3 = rawMovie[i].Trim();
				switch (i)
				{
				case 2:
					num = int.Parse(text3);
					break;
				case 3:
					text2 = text3;
					break;
				case 4:
					num2 = double.Parse(text3);
					break;
				case 5:
					num3 = int.Parse(text3);
					break;
				}
			}
		}
		if (num <= 0)
		{
			num = CreateTablesHelpers.RANDY.Next(1992, 1999);
		}
		if (text2 == null)
		{
			text2 = ((num != 1998) ? CreateTablesHelpers.GetRandomValue(CreateTablesHelpers.months) : CreateTablesHelpers.GetRandomValue(CreateTablesHelpers.months, 6));
		}
		if (num2 <= 0.0)
		{
			if (suspect)
			{
				num2 = CreateTablesHelpers.RANDY.Next(1, 80);
			}
			else
			{
				int num4 = CreateTablesHelpers.RANDY.Next(100);
				num2 = ((num4 < 30) ? ((double)CreateTablesHelpers.RANDY.Next(50, 98)) : ((num4 >= 90) ? ((double)CreateTablesHelpers.RANDY.Next(10, 30)) : ((double)CreateTablesHelpers.RANDY.Next(30, 50))));
			}
			if (text == "Frogs: The Croak Begins")
			{
				num2 = 95.0;
			}
			num2 *= 0.1;
		}
		if (num3 <= 0)
		{
			num3 = CreateTablesHelpers.RANDY.Next(200, 20000);
		}
		return new Movie(text, director, genre, num, text2, num2, num3);
	}

	private static string GetDirectorName()
	{
		string randomValue = CreateTablesHelpers.GetRandomValue(CreateTablesHelpers.firstNames);
		string randomValue2 = CreateTablesHelpers.GetRandomValue(CreateTablesHelpers.lastNames);
		CreateTablesHelpers.AddName(everyone, (randomValue, randomValue2));
		return randomValue + " " + randomValue2;
	}

	private static int AddRandomWebsite(string ip, List<SearchHistory> searches, HashSet<string> times, HashSet<string> logins, List<string> profileNames)
	{
		int num = CreateTablesHelpers.RANDY.Next(100);
		int randomDate;
		int num2;
		do
		{
			randomDate = CreateTablesHelpers.GetRandomDate(1998, 1998, 6, 6, 1, 30);
			num2 = ((CreateTablesHelpers.RANDY.Next(100) > 20) ? CreateTablesHelpers.GetRandomTime(8, 24) : CreateTablesHelpers.GetRandomTime(0, 8));
		}
		while (times.Contains(randomDate.ToString() + num2));
		times.Add(randomDate.ToString() + num2);
		if (num <= 55)
		{
			searches.Add(new SearchHistory(ip, CreateTablesHelpers.GetRandomValue(SINGLE_VISIT_SITES), randomDate, num2));
			return 1;
		}
		if (num <= 58)
		{
			List<string> list = new List<string> { "frogs", "salamanders", "caecilians" };
			if (num % 4 == 1)
			{
				searches.Add(new SearchHistory(ip, "frogblog.net/" + CreateTablesHelpers.GetRandomValue(list), randomDate, num2));
				return 1;
			}
			int num3 = 0;
			int num4 = CreateTablesHelpers.RANDY.Next(list.Count);
			for (int i = 0; i <= num4; i++)
			{
				num3 += 2;
				string randomValue = CreateTablesHelpers.GetRandomValue(list);
				searches.Add(new SearchHistory(ip, "frogblog.net", randomDate, num2));
				num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(1, 3));
				if (num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
				{
					return num3 - 1;
				}
				times.Add(randomDate.ToString() + num2);
				searches.Add(new SearchHistory(ip, "frogblog.net/" + randomValue, randomDate, num2));
				num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(3, 6));
				if (num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
				{
					return num3;
				}
				times.Add(randomDate.ToString() + num2);
				list.Remove(randomValue);
			}
			return num3;
		}
		if (num <= 64)
		{
			searches.Add(new SearchHistory(ip, "mmdb.com", randomDate, num2));
			if (profileNames.Count > 0 && !logins.Contains(ip))
			{
				num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(1, 3));
				if (num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
				{
					return 1;
				}
				times.Add(randomDate.ToString() + num2);
				searches.Add(new SearchHistory(ip, "mmdb.com/login", randomDate, num2));
				num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(1, 3));
				if (num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
				{
					return 2;
				}
				times.Add(randomDate.ToString() + num2);
				searches.Add(new SearchHistory(ip, "mmdb.com/profile/" + profileNames[0], randomDate, num2));
				logins.Add(ip);
				profileNames.RemoveAt(0);
				return 3;
			}
			return 1;
		}
		if (num <= 80)
		{
			searches.Add(new SearchHistory(ip, "molemanfans.net", randomDate, num2));
			num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(1, 3));
			if (num % 2 == 1 || num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
			{
				return 1;
			}
			times.Add(randomDate.ToString() + num2);
			searches.Add(new SearchHistory(ip, "molemanfans.net/test", randomDate, num2));
			num2 = CreateTablesHelpers.AddTime(num2, CreateTablesHelpers.RANDY.Next(4, 7));
			if (num2 >= 2400 || times.Contains(randomDate.ToString() + num2))
			{
				return 2;
			}
			times.Add(randomDate.ToString() + num2);
			searches.Add(new SearchHistory(ip, "molemanfans.net/test/" + CreateTablesHelpers.GetRandomValue(molemanfans.MOLEMANS), randomDate, num2));
			return 3;
		}
		if (num <= 83)
		{
			int num5 = 1;
			searches.Add(new SearchHistory(ip, "selectyourstar.com", randomDate, num2));
			if (randomDate <= 19980607)
			{
				if (num % 2 == 0)
				{
					searches.Add(new SearchHistory(ip, "selectyourstar.com/submit", randomDate, num2));
					num5++;
					if (num % 3 < 1)
					{
						searches.Add(new SearchHistory(ip, "selectyourstar.com/success", randomDate, num2));
						num5++;
					}
				}
			}
			else if (num == 87)
			{
				searches.Add(new SearchHistory(ip, "selectyourstar.com/submit", randomDate, num2));
				num5++;
			}
			return num5;
		}
		if (randomDate == SUSPECT_RATED_DATE && num2 <= SUSPECT_RATED_TIME)
		{
			return 0;
		}
		searches.Add(new SearchHistory(ip, "rateyourdictator.gov", randomDate, num2));
		return 1;
	}

	private static void AddSuspectMMDB(HashSet<string> movieTitles, string redHerringSuspectFilm, List<string> moviesFromDirectorsWithAwards, List<string> juneHorror, List<string> moviesOverAverageReviewsNoAward, List<string> suspectPerfectMovies)
	{
		string sUSPECT_PROFILE = mmdb_profile.SUSPECT_PROFILE;
		string text = "Frogs: The Croak Begins";
		movieTitles.Add(text);
		movieTitles.Add(suspect.q2);
		movieTitles.Add(redHerringSuspectFilm);
		string rating = "10.0";
		usersMovieReviews[sUSPECT_PROFILE].Add(new Review(redHerringSuspectFilm, rating));
		usersMovieReviews[sUSPECT_PROFILE].Add(new Review(suspect.q2, rating));
		usersMovieReviews[sUSPECT_PROFILE].Add(new Review(text, rating));
		foreach (string suspectPerfectMovie in suspectPerfectMovies)
		{
			if (!movieTitles.Contains(suspectPerfectMovie))
			{
				usersMovieReviews[sUSPECT_PROFILE].Add(new Review(suspectPerfectMovie, "10.0"));
				moviesFromDirectorsWithAwards.Remove(suspectPerfectMovie);
				movieTitles.Add(suspectPerfectMovie);
			}
		}
		AddPerfectRating(sUSPECT_PROFILE, moviesFromDirectorsWithAwards, movieTitles, 3);
		for (int i = 0; i < CreateTablesHelpers.RANDY.Next(120, 150); i++)
		{
			string uniqueValue = CreateTablesHelpers.GetUniqueValue(movieTitles, GenerateMovieTitle);
			double rating2 = (double)(CreateTablesHelpers.RANDY.Next(0, 98) * 10) / 100.0;
			usersMovieReviews[sUSPECT_PROFILE].Add(new Review(uniqueValue, rating2));
		}
		usersMovieReviews[sUSPECT_PROFILE] = usersMovieReviews[sUSPECT_PROFILE].OrderBy((Review a) => CreateTablesHelpers.RANDY.Next()).ToList();
		userWatchlists[sUSPECT_PROFILE].Add(new Watch(suspect.q3));
		for (int num = 0; num < CreateTablesHelpers.RANDY.Next(40, 50); num++)
		{
			string uniqueValue2 = CreateTablesHelpers.GetUniqueValue(movieTitles, GenerateMovieTitle);
			if (!juneHorror.Contains(uniqueValue2))
			{
				userWatchlists[sUSPECT_PROFILE].Add(new Watch(uniqueValue2));
			}
		}
	}

	private static void AddPerfectRating(string suspectUsername, List<string> movies, ICollection<string> movieTitles, int times)
	{
		for (int i = 0; i < times; i++)
		{
			string randomValue;
			do
			{
				randomValue = CreateTablesHelpers.GetRandomValue(movies);
			}
			while (movieTitles.Contains(randomValue));
			movies.Remove(randomValue);
			movieTitles.Add(randomValue);
			usersMovieReviews[suspectUsername].Add(new Review(randomValue, "10.0"));
		}
	}

	private static void AddSuspectWebsites(string suspectIP, List<SearchHistory> searches)
	{
		Debug.Log("SELECT * FROM web_searches WHERE ip_address=\"" + suspectIP + "\"");
		Level5.suspectIP = suspectIP;
		Save.SetLevel5SuspectIP(suspectIP);
		searches.Add(new SearchHistory(suspectIP, "helpme.net", 19980602, 300));
		searches.Add(new SearchHistory(suspectIP, "smoothieworld.net", 19980603, 1031));
		searches.Add(new SearchHistory(suspectIP, "errandboy.com", 19980603, 1045));
		searches.Add(new SearchHistory(suspectIP, "errandboy.com/order/74b8s", 19980603, 1056));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com", 19980605, 312));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com/submit", 19980605, 315));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com/success", 19980605, 322));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net", 19980606, 905));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net/frogs", 19980606, 907));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net", 19980606, 912));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net/membership", 19980606, 913));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com", 19980612, 2100));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net", 19980613, 1250));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net/frogs", 19980613, 1252));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net", 19980613, 1310));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net/salamanders", 19980613, 1311));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net", 19980613, 1316));
		searches.Add(new SearchHistory(suspectIP, "frogblog.net/caecilians", 19980613, 1317));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com/login", 19980622, 1520));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com/profile/ribbit78", 19980622, 1524));
		searches.Add(new SearchHistory(suspectIP, "jimsbirthday.net", 19980624, 1310));
		searches.Add(new SearchHistory(suspectIP, "rateyourdictator.gov", 19980624, 1554));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com", 19980624, 1630));
		searches.Add(new SearchHistory(suspectIP, "molemanfans.net", 19980624, 1638));
		searches.Add(new SearchHistory(suspectIP, "molemanfans.net/test", 19980624, 1640));
		searches.Add(new SearchHistory(suspectIP, "molemanfans.net/test/pathetic", 19980624, 1645));
		searches.Add(new SearchHistory(suspectIP, "selectyourstar.com", 19980625, 2100));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com", 19980626, 1223));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com/profile/trueh8r", 19980626, 1230));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com/login", 19980626, 1240));
		searches.Add(new SearchHistory(suspectIP, "mmdb.com/profile/ribbit78", 19980626, 1241));
	}

	public static string GetSuspectIP()
	{
		return suspectIP;
	}

	private static string GetUniqueIP(ICollection<string> ips)
	{
		string text = GenerateIP();
		while (ips.Contains(text))
		{
			text = GenerateIP();
		}
		ips.Add(text);
		return text;
	}

	private static string GenerateIP()
	{
		string text = "10";
		for (int i = 0; i < 3; i++)
		{
			text = text + "." + CreateTablesHelpers.RANDY.Next(0, 256);
		}
		return text;
	}

	private static string GenerateMovieTitle()
	{
		return CreateTablesHelpers.GetRandomValue(movies).title;
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

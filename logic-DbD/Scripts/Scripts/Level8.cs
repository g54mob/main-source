using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using UnityEngine;

public class Level8 : Level
{
	protected class SpecialTraders
	{
		public const string ZORAN_FIRM = "PonziScam";

		public const string IPO_ISSUER = "Broker Holdings";

		public const string HEINRICH = "The Heinrich Foundation";

		public const string LZPPP = "LZPPP";

		public const string STI = "Suit & Tie";

		public const string CLOWN_CAPITAL = "Clown Capital";
	}

	protected static ICollection<string> everyone = new HashSet<string>();

	private static readonly HashSet<string> TICKERS = new HashSet<string> { "ALIN", "LZAR", "MAIL", "CLWN", "PYUP", "NMBY", "SPRT", "WTHR" };

	public const int LEVEL_NUMBER = 8;

	public const int AMOUNT_WAGERED = 250;

	public const int YEAR = 365;

	private static List<Game> d_games;

	private static List<CardDrawing> d_cards;

	private static List<PredictionRate> d_predictions;

	private static List<Winner> d_winners;

	private static List<WeatherForecast> d_forecasts;

	private static Dictionary<int, Flight> d_flights;

	private static Dictionary<int, List<Seat>> d_flightSeats;

	private static Dictionary<string, NimbyPurchase> d_nimbyPurchases;

	private static Dictionary<string, Trader> d_traders;

	private static Dictionary<string, Trader> d_specialTraders = new Dictionary<string, Trader>(StringComparer.OrdinalIgnoreCase)
	{
		{
			"LZPPP",
			new Trader("LZPPP", "lzppp.com", "The Los Zorangeles Private Pension Plan is responsible for managing the largest private investment fund in Calizorania, focusing entirely on domestic investment.")
		},
		{
			"Suit & Tie",
			new Trader("Suit & Tie", "sti.com", "Suit & Tie Investments was founded by two genius traders, one of which only wears a suit and the other only wears a tie.")
		},
		{
			"PonziScam",
			new Trader("PonziScam", "ponziscam.com", "Owned and operated by the humble PonziScam family.")
		},
		{
			"Broker Holdings",
			new Trader("Broker Holdings", "broker.com", "Broker Holdings is <i>broker.com</i>'s special management firm that handles company registration to <i>broker.com</i> and is responsible for distributing the first issue of company shares to the public.")
		},
		{
			"The Heinrich Foundation",
			new Trader("The Heinrich Foundation", "", "A holding company for the generous and wonderful Gert Heinrich.")
		},
		{
			"Clown Capital",
			new Trader("Clown Capital", "clowncar.com", "Founded by the creators of Clown Car. We transfer the skills learned from Clown School into quality investments.")
		}
	};

	private static HashSet<string> d_retailInvestors;

	private static HashSet<string> d_institutionalInvestors;

	private static Dictionary<string, List<Transaction>> d_stockTransactions;

	private static Dictionary<string, List<Price>> d_stockPrices;

	private static int d_seasonWagered;

	private static DateTime d_flightDate;

	private static int d_flightQuarter;

	private static int d_flightYear;

	private static int d_suitFlightNum;

	private static (string, string) d_culpritName;

	private static (string, string) d_tieName;

	private static (string, string) d_suitName;

	private static HashSet<int> d_uncleGames;

	private static HashSet<string> d_lzStocks = new HashSet<string> { "LZAR", "MAIL", "CLWN", "NMBY", "WTHR" };

	private static HashSet<int> d_otherCloudyUncles;

	private const int ROWS = 21;

	private static readonly string[] COLUMNS = new string[6] { "A", "B", "C", "D", "E", "F" };

	private const int WEEK = 7;

	private const string SUIT_DESTINATION = "Flushing";

	private const string HOME = "Los Zorangeles";

	private const int GAME_SEASONS = 35;

	private const int GAMES_IN_SEASON = 7;

	private const int BUCKET_SCORE = 5;

	private const int RUN_SCORE = 8;

	private const int CONDITION_3_SCORE = 35;

	private const int GAME_START_YEAR = 1989;

	public static void LoadWebsites()
	{
		GenerateBrokerTraders();
	}

	public static void InitParams()
	{
		d_games = new List<Game>();
		d_cards = new List<CardDrawing>();
		d_predictions = new List<PredictionRate>();
		d_winners = new List<Winner>();
		d_culpritName = CreateTablesHelpers.GetCulprit(new string[1] { "Zoran" }, new string[1] { "PonziScam" });
		everyone.Add("Zoran PonziScam");
		d_forecasts = new List<WeatherForecast>();
		d_flights = new Dictionary<int, Flight>();
		d_nimbyPurchases = new Dictionary<string, NimbyPurchase>();
		d_stockTransactions = new Dictionary<string, List<Transaction>>();
		d_stockPrices = new Dictionary<string, List<Price>>();
		d_flightQuarter = CreateTablesHelpers.RANDY.Next(1, 4);
		d_flightYear = CreateTablesHelpers.RANDY.Next(1994, 1997);
		d_tieName = (CreateTablesHelpers.GetRandomValue(new string[3] { "Teddy", "Tony", "Trent" }), CreateTablesHelpers.GetRandomValue(new string[3] { "Toobles", "Tublar", "Tubey" }));
		everyone.Add(d_tieName.Item1 + " " + d_tieName.Item2);
		d_suitName = (CreateTablesHelpers.GetRandomValue(new string[3] { "Melissa", "Karen", "Samantha" }), CreateTablesHelpers.GetRandomValue(new string[3] { "Stool", "Steep", "Salerno" }));
		everyone.Add(d_suitName.Item1 + " " + d_suitName.Item2);
		d_flightSeats = new Dictionary<int, List<Seat>>();
		d_uncleGames = new HashSet<int>();
		d_otherCloudyUncles = new HashSet<int>();
		GenerateStockHistory("ALIN", 61.32, 3659, isGreen: true);
		GenerateStockHistory("LZAR", 13.45, 2934, isGreen: true);
		GenerateStockHistory("MAIL", 17.09, 3365, isGreen: false);
		GenerateStockHistory("CLWN", 2.22, 2938, isGreen: true);
		GenerateStockHistory("PYUP", 3.19, 3316, isGreen: false);
		GenerateStockHistory("NMBY", 33.58, 1471, isGreen: true);
		GenerateStockHistory("SPRT", 183.09, 3653, isGreen: false);
		GenerateStockHistory("WTHR", 2.73, 3657, isGreen: false);
	}

	public static bool LoadWebsiteDownloads(IDbConnection connection)
	{
		d_forecasts = new List<WeatherForecast>();
		d_flights = new Dictionary<int, Flight>();
		d_games = new List<Game>();
		if (LoadAllInDownloads(connection) && LoadBrokersDownloads(connection) && CreateTablesHelpers.LoadSavedTable(connection, skiesforetold.TABLE_NAME, LoadForecasts) && CreateTablesHelpers.LoadSavedTable(connection, lzairlines_departures.TABLE_NAME, LoadFlights))
		{
			return CreateTablesHelpers.LoadSavedTable(connection, bigball_stats.TABLE_NAME, LoadGames);
		}
		return false;
		static void LoadFlights(string[] row)
		{
			d_flights.Add(int.Parse(row[4]), Flight.BuildFromRow(row));
		}
		static void LoadForecasts(string[] row)
		{
			d_forecasts.Add(WeatherForecast.BuildFromRow(row));
		}
		static void LoadGames(string[] row)
		{
			d_games.Add(Game.BuildFromRow(row));
		}
	}

	public static bool LoadAllInDownloads(IDbConnection connection)
	{
		d_cards = new List<CardDrawing>();
		d_winners = new List<Winner>();
		d_predictions = new List<PredictionRate>();
		if (CreateTablesHelpers.LoadSavedTable(connection, allin_howto.CARD_TABLE, LoadCardDrawings) && CreateTablesHelpers.LoadSavedTable(connection, allin_howto.BETS_TABLE, LoadBets))
		{
			return CreateTablesHelpers.LoadSavedTable(connection, allin_winners.TABLE_NAME, LoadWinners);
		}
		return false;
		static void LoadBets(string[] row)
		{
			d_predictions.Add(PredictionRate.BuildFromRow(row));
		}
		static void LoadCardDrawings(string[] row)
		{
			d_cards.Add(CardDrawing.BuildFromRow(row));
		}
		static void LoadWinners(string[] row)
		{
			d_winners.Add(Winner.BuildFromRow(row));
		}
	}

	public static bool LoadBrokersDownloads(IDbConnection connection)
	{
		d_stockPrices = new Dictionary<string, List<Price>>();
		d_stockTransactions = new Dictionary<string, List<Transaction>>();
		foreach (string tICKER in TICKERS)
		{
			string ticker = tICKER;
			d_stockPrices[ticker] = new List<Price>();
			d_stockTransactions[ticker] = new List<Transaction>();
			if (!CreateTablesHelpers.LoadSavedTable(connection, broker.GetPriceTableName(ticker), LoadPrices) || !CreateTablesHelpers.LoadSavedTable(connection, broker.GetTransactionTableName(ticker), LoadTransactions))
			{
				return false;
			}
			void LoadPrices(string[] row)
			{
				d_stockPrices[ticker].Add(Price.BuildFromRow(row));
			}
			void LoadTransactions(string[] row)
			{
				d_stockTransactions[ticker].Add(Transaction.BuildFromRow(row));
			}
		}
		return true;
	}

	public static bool LoadGeneratedWebsiteDownloads(IDbConnection connection)
	{
		HashSet<string> allTableNames = DatabaseUtils.GetAllTableNames(connection);
		Debug.Log(string.Join(",", allTableNames));
		d_flightSeats = new Dictionary<int, List<Seat>>();
		foreach (int key in d_flights.Keys)
		{
			int flightNumber = key;
			string tableName = lzairlines_checkin.GetTableName(flightNumber);
			if (allTableNames.Contains(tableName))
			{
				d_flightSeats[flightNumber] = new List<Seat>();
				if (!CreateTablesHelpers.LoadSavedTable(connection, tableName, LoadSeats))
				{
					return false;
				}
			}
			void LoadSeats(string[] row)
			{
				d_flightSeats[flightNumber].Add(Seat.BuildFromRow(row));
			}
		}
		ICollection<Person> nimbyPurchases = new HashSet<Person>();
		if (!CreateTablesHelpers.LoadSavedTable(connection, Save.NIMBY_TABLE, LoadPurchase))
		{
			return false;
		}
		d_nimbyPurchases = new Dictionary<string, NimbyPurchase>();
		foreach (Person item in nimbyPurchases)
		{
			d_nimbyPurchases[item.firstName] = CreateNimby(item.lastName);
		}
		return true;
		void LoadPurchase(string[] row)
		{
			nimbyPurchases.Add(Person.BuildFromRow(row));
		}
	}

	public static void SaveGeneratedWebsiteDownloads()
	{
		IDbConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		DatabaseUtils.Begin(connection);
		foreach (string tICKER in TICKERS)
		{
			CreatePriceTable(tICKER, broker.GetPriceTableName(tICKER), connection, commit: false);
			CreateTransactionsTable(tICKER, broker.GetTransactionTableName(tICKER), connection, commit: false);
		}
		CreateGamesTable(bigball_stats.TABLE_NAME, connection, commit: false);
		CreateFlightsTable(lzairlines_departures.TABLE_NAME, connection, commit: false);
		CreateWeatherTable(skiesforetold.TABLE_NAME, connection, commit: false);
		CreateCardDrawingsTable(allin_howto.CARD_TABLE, connection, commit: false);
		CreatePredictionsTable(allin_howto.BETS_TABLE, connection, commit: false);
		CreateWinnersTable(allin_winners.TABLE_NAME, connection, commit: false);
		CreateSeatMapTable(d_suitFlightNum, connection, commit: false);
		CreateNimbyPurchasesTable(connection);
		DatabaseUtils.Commit(connection);
		connection.Close();
	}

	public static void CreateNimbyPurchasesTable(IDbConnection connection)
	{
		Debug.Log("Creating " + Save.NIMBY_TABLE);
		string text = "tableName";
		string text2 = "buyer";
		DatabaseUtils.CreateTable(connection, Save.NIMBY_TABLE, text + " TEXT, " + text2 + " TEXT");
	}

	public static void SaveNimbyPurchase(string tableName, string buyer)
	{
		IDbConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		string text = "tableName";
		string text2 = "buyer";
		Debug.Log("ADDING " + tableName + ", " + buyer);
		CreateTablesHelpers.PopulateTable(connection, Save.NIMBY_TABLE, new string[2] { text, text2 }, new Person[1]
		{
			new Person(tableName, buyer)
		});
		connection.Close();
	}

	public static void PrintContents()
	{
		foreach (string key in d_stockPrices.Keys)
		{
			Debug.Log($"d_stockPrices[{key}] count -> {d_stockPrices[key].Count}");
		}
		foreach (string key2 in d_stockTransactions.Keys)
		{
			Debug.Log($"d_stockTransactions[{key2}] count -> {d_stockTransactions[key2].Count}");
		}
		Debug.Log($"d_games count -> {d_games.Count}");
		Debug.Log($"d_flights count -> {d_flights.Count}");
		Debug.Log($"d_forecasts count -> {d_forecasts.Count}");
		Debug.Log($"d_cards count -> {d_cards.Count}");
		Debug.Log($"d_predictions count -> {d_predictions.Count}");
		Debug.Log($"d_winners count -> {d_winners.Count}");
		Debug.Log($"everyone count -> {everyone.Count}");
		Debug.Log($"d_flightSeats.Keys count -> {d_flightSeats.Keys.Count}");
		Debug.Log($"d_nimbyPurchases.Keys count -> {d_nimbyPurchases.Keys.Count}");
		Debug.Log($"d_suitFlightNum -> {d_suitFlightNum}");
		Debug.Log($"d_suitName -> {d_suitName}");
		Debug.Log($"d_tieName -> {d_tieName}");
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		HashSet<string> allTableNames = DatabaseUtils.GetAllTableNames(connection);
		Debug.Log(string.Join(",", allTableNames));
		((IDbConnection)connection).Close();
	}

	public static void Create(bool hasLoad)
	{
		using (IDbConnection dbConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(dbConnection, everyone, hasLoad) && LoadWebsiteDownloads(dbConnection) && LoadGeneratedWebsiteDownloads(dbConnection))
			{
				string item = Save.DecodeString(Save.GLOBAL_SAVE.s1);
				string item2 = Save.DecodeString(Save.GLOBAL_SAVE.s2);
				d_suitName = (item, item2);
				string item3 = Save.DecodeString(Save.GLOBAL_SAVE.t1);
				string item4 = Save.DecodeString(Save.GLOBAL_SAVE.t2);
				d_tieName = (item3, item4);
				PrintContents();
				return;
			}
		}
		DatabaseUtils.DropAllTables(new string[1] { Save.SAVED_TRADERS_TABLE });
		InitParams();
		GenerateGames();
		GenerateCardDrawings();
		GenerateWinners(GeneratePredictions());
		GenerateWeather();
		GenerateFlights();
		GenerateSeatMap();
		d_flightSeats.Add(d_suitFlightNum, GenerateSeatMap(isSuitFlight: true));
		SaveGeneratedWebsiteDownloads();
		PrintContents();
		Save.SaveSuitTie(d_suitName.Item1, d_suitName.Item2, d_tieName.Item1, d_tieName.Item2);
		Level.SaveData(d_culpritName.Item1, d_culpritName.Item2, everyone);
	}

	private static void GenerateStockHistory(string stock, double finalPrice, int days, bool isGreen)
	{
		Dictionary<string, int> debters = new Dictionary<string, int>();
		Dictionary<string, int> holders = new Dictionary<string, int>();
		Dictionary<string, DateTime> holdersLastTransaction = new Dictionary<string, DateTime>();
		DateTime date = new DateTime(1998, 7, 3);
		Dictionary<int, double> priceCache = new Dictionary<int, double>();
		List<Transaction> transactions = new List<Transaction>();
		List<Price> prices = new List<Price>();
		int heinrichQuantity = 0;
		int lzpppQuantity = 0;
		GenerateHistory(finalPrice, 1.0, date, CreateTablesHelpers.GetRandomTime(8, 17));
		double num = GenerateHistory(finalPrice, GetModifier(isGreen ? CreateTablesHelpers.RANDY.Next(-40, 0) : CreateTablesHelpers.RANDY.Next(1, 42)), date.AddDays(-1.0), CreateTablesHelpers.GetRandomTime(8, 18));
		HashSet<DateTime> hashSet = new HashSet<DateTime>();
		if (stock == "ALIN")
		{
			for (int i = 0; i < CreateTablesHelpers.RANDY.Next(32, 35); i++)
			{
				int year = CreateTablesHelpers.RANDY.Next(1988, 1994);
				int month = CreateTablesHelpers.RANDY.Next(1, 13);
				int day = CreateTablesHelpers.RANDY.Next(1, CreateTablesHelpers.GetMaxDays(month) + 1);
				hashSet.Add(new DateTime(year, month, day));
			}
			int year2 = CreateTablesHelpers.RANDY.Next(1994, 1997);
			int month2 = CreateTablesHelpers.RANDY.Next(1, 13);
			int day2 = CreateTablesHelpers.RANDY.Next(1, CreateTablesHelpers.GetMaxDays(month2) + 1);
			hashSet.Add(new DateTime(year2, month2, day2));
		}
		HashSet<DateTime> hashSet2 = new HashSet<DateTime>();
		if (d_lzStocks.Contains(stock))
		{
			for (int j = 0; j < CreateTablesHelpers.RANDY.Next(25, 30); j++)
			{
				int num2 = CreateTablesHelpers.RANDY.Next(1988, 1993);
				int month3 = CreateTablesHelpers.RANDY.Next(1, (num2 == 1993) ? 9 : 13);
				int day3 = CreateTablesHelpers.RANDY.Next(1, CreateTablesHelpers.GetMaxDays(month3) + 1);
				hashSet2.Add(new DateTime(num2, month3, day3));
			}
		}
		for (int k = 2; k < days; k++)
		{
			int num3 = CreateTablesHelpers.RANDY.Next(1, 4);
			List<int> list = new List<int>();
			for (int l = 0; l < num3; l++)
			{
				list.Add(CreateTablesHelpers.GetRandomTime(8, 18));
			}
			list.Sort();
			for (int m = 0; m < num3; m++)
			{
				double percent = (CreateTablesHelpers.IsPercentChance(50) ? CreateTablesHelpers.RANDY.Next(1, 42) : CreateTablesHelpers.RANDY.Next(-40, 0));
				DateTime dateTime = date.AddDays(-k);
				num = GenerateHistory(num, GetModifier(percent), dateTime, list[m], m, hashSet.Contains(dateTime), hashSet2.Contains(dateTime));
			}
		}
		int date2 = CreateTablesHelpers.GetDate(date.AddDays(-days));
		int time = 900;
		int num4 = 0;
		if (d_lzStocks.Contains(stock))
		{
			int randomTime = CreateTablesHelpers.GetRandomTime(8, 10);
			int num5 = 19930903;
			int time2 = randomTime;
			int randomTime2 = CreateTablesHelpers.GetRandomTime(8, 10);
			int num6 = 19931025;
			int time3 = randomTime2;
			if (priceCache.ContainsKey(num5) && priceCache.ContainsKey(num6))
			{
				KeyValuePair<string, int> keyValuePair = holders.Aggregate((KeyValuePair<string, int> keyValuePair3, KeyValuePair<string, int> r) => (keyValuePair3.Value <= r.Value) ? r : keyValuePair3);
				int num7 = keyValuePair.Value - lzpppQuantity;
				Debug.Log($"Biggest holder value={keyValuePair.Value}, LZPPP is holding onto {-lzpppQuantity} shares for {stock}");
				transactions.Add(new Transaction(num5, time2, num7, "Suit & Tie", "LZPPP"));
				int randomTime3 = CreateTablesHelpers.GetRandomTime(10, 13);
				transactions.Add(new Transaction(num5, randomTime3, num7, CreateTablesHelpers.GetRandomValue(d_institutionalInvestors), "Suit & Tie"));
				prices.Add(new Price(num5, randomTime3, priceCache[num5]));
				string randomValue = CreateTablesHelpers.GetRandomValue(d_institutionalInvestors);
				transactions.Add(new Transaction(num6, time3, num7, "Suit & Tie", randomValue));
				prices.Add(new Price(num6, time3, priceCache[num6]));
				UpdateDictionary(debters, randomValue, num7);
				transactions.Add(new Transaction(num6, CreateTablesHelpers.GetRandomTime(10, 13), num7, "LZPPP", "Suit & Tie"));
				transactions.Add(new Transaction(date2, time, num7 + lzpppQuantity, "LZPPP", "Broker Holdings"));
				while (num7 > 0)
				{
					int year3 = 1993;
					int month4 = 11;
					int day4 = CreateTablesHelpers.RANDY.Next(25, CreateTablesHelpers.GetMaxDays(month4) + 1);
					string randomValue2 = CreateTablesHelpers.GetRandomValue(d_institutionalInvestors);
					DateTime dateTime2 = new DateTime(year3, month4, day4);
					int date3 = CreateTablesHelpers.GetDate(dateTime2);
					int randomTime4 = CreateTablesHelpers.GetRandomTime(9, 14);
					int num8 = GetQuantity("LZPPP", randomValue2, priceCache[date3]);
					if (num8 > num7)
					{
						num8 = num7;
					}
					transactions.Add(new Transaction(date3, randomTime4, num8, randomValue2, "LZPPP"));
					prices.Add(new Price(date3, randomTime4, priceCache[date3]));
					if (!holdersLastTransaction.ContainsKey(randomValue2) || holdersLastTransaction[randomValue2] < dateTime2)
					{
						holdersLastTransaction[randomValue2] = dateTime2;
					}
					UpdateDictionary(holders, randomValue2, num7);
					num7 -= num8;
				}
			}
		}
		bool flag = false;
		num = Math.Round(num * 0.95, 2, MidpointRounding.AwayFromZero);
		foreach (string key in debters.Keys)
		{
			if (debters[key] > 0)
			{
				flag = true;
				int num9 = debters[key];
				if (!(stock == "CLWN") || !(key == "Clown Capital"))
				{
					transactions.Add(new Transaction(date2, time, num9, key, "Broker Holdings"));
					num4 += num9;
					UpdateDictionary(holders, key, num9);
				}
			}
		}
		if (stock == "CLWN")
		{
			transactions.Add(new Transaction(date2, time, num4 / 4, "Clown Capital", "Broker Holdings"));
		}
		else if (stock == "ALIN")
		{
			KeyValuePair<string, int> keyValuePair2 = holders.Aggregate((KeyValuePair<string, int> keyValuePair3, KeyValuePair<string, int> r) => (keyValuePair3.Value <= r.Value) ? r : keyValuePair3);
			if (keyValuePair2.Key != "PonziScam")
			{
				int quantity = keyValuePair2.Value - holders["PonziScam"] + CreateTablesHelpers.RANDY.Next(50, 100);
				transactions.Add(new Transaction(date2, time, quantity, "PonziScam", "Broker Holdings"));
			}
			transactions.Add(new Transaction(date2, time, heinrichQuantity, "The Heinrich Foundation", "Broker Holdings"));
		}
		if (flag)
		{
			prices.Add(new Price(date2, time, num));
		}
		for (int num10 = 0; num10 < 15; num10++)
		{
			if (holders.Count <= 0)
			{
				break;
			}
			string randomValue3 = CreateTablesHelpers.GetRandomValue(holders.Keys);
			if (d_retailInvestors.Contains(randomValue3))
			{
				int num11 = holders[randomValue3];
				if (num11 >= 1)
				{
					holders.Remove(randomValue3);
					string randomValue4 = CreateTablesHelpers.GetRandomValue(holders.Keys);
					DateTime dateTime3 = holdersLastTransaction[randomValue3];
					int num12 = CreateTablesHelpers.RANDY.Next(dateTime3.Year, date.Year);
					int num13 = CreateTablesHelpers.RANDY.Next((num12 != dateTime3.Year) ? 1 : dateTime3.Month, (num12 == date.Year) ? (date.Month + 1) : 13);
					int day5 = CreateTablesHelpers.RANDY.Next((num12 != dateTime3.Year || num13 != dateTime3.Month) ? 1 : dateTime3.Day, (num12 == date.Year && num13 == date.Month) ? date.Day : CreateTablesHelpers.GetMaxDays(num13));
					int date4 = CreateTablesHelpers.GetDate(new DateTime(num12, num13, day5));
					int randomTime5 = CreateTablesHelpers.GetRandomTime(17, 18);
					transactions.Add(new Transaction(date4, randomTime5, num11, randomValue4, randomValue3));
					prices.Add(new Price(date4, randomTime5, priceCache[date4]));
				}
			}
		}
		d_stockTransactions[stock] = (from tran in transactions
			orderby CreateTablesHelpers.RANDY.Next()
			orderby tran.date descending, tran.time descending
			select tran).ToList();
		d_stockPrices[stock] = (from price in prices
			orderby price.date descending, price.time descending
			select price).ToList();
		double GenerateHistory(double previousPrice, double modifier, DateTime dateTime4, int time4, int transactionNumber = 0, bool isPonziScam = false, bool isLZPPP = false)
		{
			if (d_lzStocks.Contains(stock) && dateTime4.Year == 1993 && dateTime4.Month == 10 && dateTime4.Day >= 18 && dateTime4.Day <= 24 && transactionNumber == 0)
			{
				modifier = ((dateTime4.Day != 18) ? ((double)CreateTablesHelpers.RANDY.Next(20, 40) / 100.0 + 1.0) : ((double)CreateTablesHelpers.RANDY.Next(20, 40) / 10.0));
			}
			double num14 = Math.Round(previousPrice * modifier, 2, MidpointRounding.AwayFromZero);
			if (num14 == previousPrice)
			{
				num14 = ((num14 != 0.01) ? (num14 + (CreateTablesHelpers.IsPercentChance(50) ? 0.01 : (-0.01))) : (num14 + 0.01));
			}
			int date5 = CreateTablesHelpers.GetDate(dateTime4);
			string text;
			string text2;
			if (isPonziScam && transactionNumber == 0)
			{
				if (dateTime4.Year > 1993)
				{
					string randomValue5 = CreateTablesHelpers.GetRandomValue(d_retailInvestors);
					text = "PonziScam";
					text2 = randomValue5;
				}
				else
				{
					string obj = (CreateTablesHelpers.IsPercentChance(70) ? "The Heinrich Foundation" : CreateTablesHelpers.GetRandomValue(d_institutionalInvestors));
					text2 = "PonziScam";
					text = obj;
				}
			}
			else
			{
				int num15 = (isPonziScam ? 1 : 0);
				if (!isLZPPP || transactionNumber != num15)
				{
					(text2, text) = GetTransactionParties();
				}
				else
				{
					text2 = (CreateTablesHelpers.IsPercentChance(75) ? "LZPPP" : CreateTablesHelpers.GetRandomValue(d_institutionalInvestors));
					text = ((text2 == "LZPPP") ? CreateTablesHelpers.GetRandomValue(d_institutionalInvestors) : "LZPPP");
				}
			}
			int num16 = GetQuantity(text, text2, num14);
			transactions.Add(new Transaction(date5, time4, num16, text2, text));
			prices.Add(new Price(date5, time4, num14));
			priceCache[date5] = num14;
			if (text == "The Heinrich Foundation")
			{
				heinrichQuantity += num16;
			}
			else if (text2 == "LZPPP" || text == "LZPPP")
			{
				lzpppQuantity += ((text2 == "LZPPP") ? (-num16) : num16);
				if (text2 == "LZPPP")
				{
					UpdateDictionary(debters, text, num16);
					UpdateDictionary(holders, text, -num16);
					if (!holdersLastTransaction.ContainsKey(text2))
					{
						holdersLastTransaction[text2] = dateTime4;
					}
					if (!holdersLastTransaction.ContainsKey(text))
					{
						holdersLastTransaction[text] = dateTime4;
					}
					return num14;
				}
			}
			else
			{
				UpdateDictionary(holders, text, -num16);
				UpdateDictionary(debters, text, num16);
				if (!holdersLastTransaction.ContainsKey(text))
				{
					holdersLastTransaction[text] = dateTime4;
				}
			}
			UpdateDictionary(holders, text2, num16);
			if (!holdersLastTransaction.ContainsKey(text2))
			{
				holdersLastTransaction[text2] = dateTime4;
			}
			if (debters.ContainsKey(text2))
			{
				debters[text2] -= num16;
				if (debters[text2] <= 0)
				{
					debters.Remove(text2);
				}
			}
			return num14;
		}
		static double GetModifier(double num14)
		{
			return num14 / 1000.0 + 1.0;
		}
		static int GetQuantity(string seller, string buyer, double price)
		{
			if (d_retailInvestors.Contains(seller) || d_retailInvestors.Contains(buyer))
			{
				return CreateTablesHelpers.RANDY.Next(1, Math.Max(1, (int)(1000.0 / price)));
			}
			return CreateTablesHelpers.RANDY.Next((int)(100.0 / price), (int)(1000.0 / price)) * 10;
		}
		(string, string) GetTransactionParties()
		{
			Dictionary<string, Trader> dictionary = new Dictionary<string, Trader>(d_traders);
			string text = ((debters.Keys.Count > 10) ? CreateTablesHelpers.GetRandomValue(debters.Keys) : CreateTablesHelpers.GetRandomValue(d_traders.Keys));
			dictionary.Remove(text);
			string randomValue5 = CreateTablesHelpers.GetRandomValue(dictionary.Keys);
			return (text, randomValue5);
		}
		static void UpdateDictionary(Dictionary<string, int> dictionary, string key, int num14)
		{
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] += num14;
			}
			else
			{
				dictionary.Add(key, num14);
			}
		}
	}

	public static void CreateTransactionsTable(string stock, string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "time";
		string text3 = "quantity";
		string text4 = "buyer";
		string text5 = "seller";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " INT, " + text3 + " INT, " + text4 + " TEXT, " + text5 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[5] { text, text2, text3, text4, text5 }, d_stockTransactions[stock], commit);
	}

	public static void CreatePriceTable(string stock, string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "time";
		string text3 = "price";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text3 + " REAL");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, d_stockPrices[stock], commit);
	}

	private static void ParseBrokersFile()
	{
		d_traders = new Dictionary<string, Trader>(StringComparer.OrdinalIgnoreCase);
		d_institutionalInvestors = new HashSet<string>();
		List<string[]> list = ResourcesManager.GetCSV("Names/broker-traders").ToList();
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i];
			string text = array[0];
			string website = array[1];
			string bio = array[2].Trim('\r', '\n');
			Trader value = new Trader(text, website, bio);
			d_traders.Add(text, value);
			d_institutionalInvestors.Add(text);
		}
	}

	private static Trader CreateTrader(string name)
	{
		string bio = "<i>No description provided</i>";
		return new Trader(name, "", bio);
	}

	private static void GenerateBrokerTraders()
	{
		d_retailInvestors = new HashSet<string>();
		ParseBrokersFile();
		string text = "Name";
		CreateTablesHelpers.GetSavedTable(Save.SAVED_TRADERS_TABLE, text + " TEXT", new string[1] { text }, d_retailInvestors, LoadRetailInvestors, SaveRetailInvestors, CreateTablesHelpers.SqlRowStringFunc);
		Debug.Log("d_retailInvestors=" + string.Join(",", d_retailInvestors));
		static void LoadRetailInvestors(string[] row)
		{
			string text2 = row[0];
			d_traders.Add(text2, CreateTrader(text2));
			d_retailInvestors.Add(text2);
			everyone.Add(text2);
		}
		static void SaveRetailInvestors()
		{
			for (int i = 0; i < 50; i++)
			{
				(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, everyone);
				string item = name.Item1;
				string item2 = name.Item2;
				string text2 = item + " " + item2;
				if (!d_traders.ContainsKey(text2))
				{
					d_traders.Add(text2, CreateTrader(text2));
					d_retailInvestors.Add(text2);
				}
			}
		}
	}

	public static Trader GetTrader(string firmName)
	{
		if (d_traders.ContainsKey(firmName))
		{
			return d_traders[firmName];
		}
		if (d_specialTraders.ContainsKey(firmName))
		{
			return d_specialTraders[firmName];
		}
		return null;
	}

	public static List<FamilyMember> GenerateFamilyTree()
	{
		List<string[]> list = ResourcesManager.GetCSV("Names/family-tree").ToList();
		List<FamilyMember> list2 = new List<FamilyMember>();
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i];
			string text = array[0];
			string text2 = array[1];
			string mom = array[2];
			string dad = array[3];
			string born = ((array.Length > 5) ? array[4] : array[4].Trim('\r', '\n'));
			string death = ((array.Length > 5) ? array[5].Trim('\r', '\n') : "NULL");
			if (array.Length <= 5)
			{
				everyone.Add(text + " " + text2);
			}
			FamilyMember item = new FamilyMember(text, text2, mom, dad, born, death);
			list2.Add(item);
		}
		return list2.OrderBy((FamilyMember familyMember) => familyMember.lastName).ToList();
	}

	public static void CreateFamilyTreeTable(string tableName)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string text = "name";
		string text2 = "mother";
		string text3 = "father";
		string text4 = "birthday";
		string text5 = "deathday";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " TEXT, " + text4 + " INT, " + text5 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[5] { text, text2, text3, text4, text5 }, GenerateFamilyTree());
	}

	public static string GetBuyerName(string address)
	{
		string text;
		if (address == "771 graveyard")
		{
			text = d_tieName.Item1 + " " + d_tieName.Item2;
		}
		else if (address == "412 bleecker")
		{
			text = d_suitName.Item1 + " " + d_suitName.Item2;
		}
		else if (CreateTablesHelpers.IsPercentChance(60))
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, everyone);
			string item = name.Item1;
			string item2 = name.Item2;
			text = item + " " + item2;
		}
		else
		{
			text = (CreateTablesHelpers.IsPercentChance(25) ? "Peter Morganholt" : ((!CreateTablesHelpers.IsPercentChance(25)) ? "Hilbert Ponzi-Scam" : "Columbia Stevenson"));
			everyone.Add(text);
		}
		return text;
	}

	public static NimbyPurchase CreateNimby(string buyer)
	{
		string text = "Debbie Nimby";
		return new NimbyPurchase(buyer, text);
	}

	public static void AddNimbyPurchase(string tableName, string address)
	{
		if (!d_nimbyPurchases.ContainsKey(tableName))
		{
			string buyerName = GetBuyerName(address);
			d_nimbyPurchases[tableName] = CreateNimby(buyerName);
			SaveNimbyPurchase(tableName, buyerName);
		}
	}

	public static void CreateNimbyPurchaseTable(string tableName, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "purchased_by";
		string text2 = "broker";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { text, text2 }, new NimbyPurchase[1] { d_nimbyPurchases[tableName] });
	}

	public static Flight GetFlight(int flightNum)
	{
		if (!d_flights.ContainsKey(flightNum))
		{
			return null;
		}
		return d_flights[flightNum];
	}

	public static List<Seat> GenerateSeatMap(bool isSuitFlight = false)
	{
		List<Seat> list = new List<Seat>();
		string[] cOLUMNS = COLUMNS;
		foreach (string text in cOLUMNS)
		{
			for (int j = 1; j <= 21; j++)
			{
				if ((text == "B" || text == "E") && j <= 4)
				{
					continue;
				}
				string firstName;
				string lastName;
				if (isSuitFlight && ((text == "F" && j >= 5 && j <= 8) || (text == "E" && j == 6)))
				{
					if (text == "E" && j == 6)
					{
						firstName = "Mona";
						lastName = "Freeman";
						everyone.Add("Mona Freeman");
					}
					else if (text == "F" && j == 6)
					{
						(firstName, lastName) = d_suitName;
					}
					else if (text == "F" && j == 5)
					{
						firstName = "Ford";
						lastName = "Schwartz";
						everyone.Add("Ford Schwartz");
					}
					else if (text == "F" && j == 8)
					{
						firstName = "John";
						lastName = "Winkler";
						everyone.Add("John Winkler");
					}
					else
					{
						firstName = "UNRESERVED";
						lastName = "";
					}
				}
				else if (!CreateTablesHelpers.IsPercentChance(10))
				{
					(firstName, lastName) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, d_suitName.Item1, d_suitName.Item2, everyone);
				}
				else
				{
					firstName = "UNRESERVED";
					lastName = "";
				}
				list.Add(new Seat(firstName, lastName, $"{text}{j}"));
			}
		}
		return list;
	}

	public static void CreateSeatMapTable(int flightNum, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		if (!d_flightSeats.ContainsKey(flightNum))
		{
			IDbConnection connection2 = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
			d_flightSeats.Add(flightNum, GenerateSeatMap());
			SaveSeatMapTable(flightNum, connection2, commit);
			connection2.Close();
		}
		SaveSeatMapTable(flightNum, connection, commit);
	}

	private static void SaveSeatMapTable(int flightNum, IDbConnection connection = null, bool commit = true)
	{
		string tableName = lzairlines_checkin.GetTableName(flightNum);
		string text = "first_name";
		string text2 = "last_name";
		string text3 = "seat";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, d_flightSeats[flightNum], commit);
	}

	public static void GenerateFlights()
	{
		int flightNumber = CreateTablesHelpers.RANDY.Next(30000, 31000);
		int[] list = new int[12]
		{
			730, 800, 1000, 1200, 1215, 1420, 1510, 1830, 2000, 2024,
			2115, 2135
		};
		DateTime dateTime = new DateTime(1990, 7, 1);
		for (int i = 0; i < 418; i++)
		{
			HashSet<string> hashSet = new HashSet<string> { "Flushing", "Greenpoint", "Coney Island" };
			HashSet<int> obj = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7 };
			int randomValue = CreateTablesHelpers.GetRandomValue(obj);
			obj.Remove(randomValue);
			int randomValue2 = CreateTablesHelpers.GetRandomValue(obj);
			obj.Remove(randomValue2);
			int randomValue3 = CreateTablesHelpers.GetRandomValue(obj);
			if (dateTime <= d_flightDate && d_flightDate < dateTime.AddDays(7.0))
			{
				hashSet.Remove("Flushing");
			}
			for (int j = 1; j <= 7; j++)
			{
				bool flag = j == randomValue || j == randomValue2 || j == randomValue3;
				if (hashSet.Count > 0 && flag && dateTime != d_flightDate)
				{
					string randomValue4 = CreateTablesHelpers.GetRandomValue(hashSet);
					int num = GenerateFlightNumber();
					if (d_otherCloudyUncles.Contains(CreateTablesHelpers.GetDate(dateTime)) && randomValue4 == "Flushing")
					{
						continue;
					}
					d_flights.Add(num, new Flight(CreateTablesHelpers.GetDate(dateTime), CreateTablesHelpers.GetRandomValue(list), "Los Zorangeles", randomValue4, num));
					num = GenerateFlightNumber();
					d_flights.Add(num, new Flight(CreateTablesHelpers.GetDate(dateTime.AddDays(3.0)), CreateTablesHelpers.GetRandomValue(list), randomValue4, "Los Zorangeles", num));
					hashSet.Remove(randomValue4);
				}
				dateTime = dateTime.AddDays(1.0);
				if (dateTime == d_flightDate)
				{
					d_suitFlightNum = GenerateFlightNumber();
					Debug.Log($"Suit flight number is {d_suitFlightNum}");
					d_flights.Add(d_suitFlightNum, new Flight(CreateTablesHelpers.GetDate(d_flightDate), 1420, "Los Zorangeles", "Flushing", d_suitFlightNum));
					int num2 = GenerateFlightNumber();
					d_flights.Add(num2, new Flight(CreateTablesHelpers.GetDate(dateTime.AddDays(3.0)), CreateTablesHelpers.GetRandomValue(list), "Flushing", "Los Zorangeles", num2));
				}
			}
		}
		int GenerateFlightNumber()
		{
			flightNumber += CreateTablesHelpers.RANDY.Next(3, 10);
			return flightNumber;
		}
	}

	public static void CreateFlightsTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "time";
		string text3 = "departing";
		string text4 = "arriving";
		string text5 = "flight_number";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " INT, " + text3 + " TEXT, " + text4 + " TEXT, " + text5 + " TEXT");
		List<Flight> rows = (from flight in d_flights.Values.ToList()
			orderby flight.date descending
			select flight).ToList();
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[5] { text, text2, text3, text4, text5 }, rows, commit);
	}

	public static void GenerateWeather()
	{
		DateTime date = new DateTime(1990, 5, 22);
		for (int i = 0; i <= 2961; i++)
		{
			int fahrenheit = GetWeatherTemp(date.Month);
			int date2 = CreateTablesHelpers.GetDate(date);
			string forecast = ((!d_uncleGames.Contains(date2)) ? CreateTablesHelpers.GetRandomValue(new string[4] { "PARTLY CLOUDY", "RAINING", "CLEAR SKIES", "VERY CLOUDY" }) : ((!d_otherCloudyUncles.Contains(date2) && date2 != CreateTablesHelpers.GetDate(d_flightDate)) ? CreateTablesHelpers.GetRandomValue(new string[3] { "RAINING", "CLEAR SKIES", "VERY CLOUDY" }) : "PARTLY CLOUDY"));
			d_forecasts.Add(new WeatherForecast(date2, forecast, fahrenheit));
			date = date.AddDays(1.0);
		}
		static int GetWeatherTemp(int month)
		{
			return month switch
			{
				1 => CreateTablesHelpers.RANDY.Next(33, 53), 
				2 => CreateTablesHelpers.RANDY.Next(30, 58), 
				3 => CreateTablesHelpers.RANDY.Next(37, 60), 
				4 => CreateTablesHelpers.RANDY.Next(41, 65), 
				5 => CreateTablesHelpers.RANDY.Next(50, 71), 
				6 => CreateTablesHelpers.RANDY.Next(60, 83), 
				7 => CreateTablesHelpers.RANDY.Next(63, 88), 
				8 => CreateTablesHelpers.RANDY.Next(60, 80), 
				9 => CreateTablesHelpers.RANDY.Next(55, 74), 
				10 => CreateTablesHelpers.RANDY.Next(40, 65), 
				11 => CreateTablesHelpers.RANDY.Next(38, 60), 
				_ => CreateTablesHelpers.RANDY.Next(32, 52), 
			};
		}
	}

	public static void CreateWeatherTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "forecast";
		string text3 = "fahrenheit";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text3 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, d_forecasts, commit);
	}

	public static bool HasPackage(string name)
	{
		if (!name.Equals(d_tieName.Item1 + " " + d_tieName.Item2, StringComparison.OrdinalIgnoreCase))
		{
			return name.Equals(d_suitName.Item1 + " " + d_suitName.Item2, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	public static string GetSuitName()
	{
		if (d_suitName.Item1 == null || d_suitName.Item2 == null)
		{
			Debug.Log($"ERROR - NULL SUIT NAME, CURRENT LEVEL {LevelManager.GetCurrLevel()}");
			return null;
		}
		return d_suitName.Item1 + " " + d_suitName.Item2;
	}

	public static string GetTieName()
	{
		if (d_suitName.Item1 == null || d_suitName.Item2 == null)
		{
			Debug.Log($"ERROR - NULL TIE NAME, CURRENT LEVEL {LevelManager.GetCurrLevel()}");
			return null;
		}
		return d_tieName.Item1 + " " + d_tieName.Item2;
	}

	public static List<PackageTracking> GetPackages(string name)
	{
		if (name.Equals(d_tieName.Item1 + " " + d_tieName.Item2, StringComparison.OrdinalIgnoreCase))
		{
			if (LevelManager.GetCurrLevel() == 8)
			{
				if (HintManager.GetHintState() == 6)
				{
					HintManager.SetHintState(8, 8);
				}
				else if (HintManager.GetHintState() == 5)
				{
					HintManager.SetHintState(8, 7, resetHintState: false);
				}
			}
			return new List<PackageTracking>
			{
				new PackageTracking("INCOMING", "771 Graveyard St.", "RECIEVED"),
				new PackageTracking("OUTGOING", "1874 Alpine Rd.", "DELIVERED"),
				new PackageTracking("OUTGOING", "144 Capstone St.", "RECIEVED"),
				new PackageTracking("OUTGOING", "193 Neptune Ave", "RECIEVED"),
				new PackageTracking("INCOMING", "771 Graveyard St.", "IN TRANSIT"),
				new PackageTracking("INCOMING", "771 Graveyard St.", "DELIVERED"),
				new PackageTracking("OUTGOING", "589 Purring Rd.", "DELIVERED")
			};
		}
		if (name.Equals(d_suitName.Item1 + " " + d_suitName.Item2, StringComparison.OrdinalIgnoreCase))
		{
			if (LevelManager.GetCurrLevel() == 8)
			{
				if (HintManager.GetHintState() == 7)
				{
					HintManager.SetHintState(8, 8);
				}
				else if (HintManager.GetHintState() == 5)
				{
					HintManager.SetHintState(8, 6, resetHintState: false);
				}
			}
			return new List<PackageTracking>
			{
				new PackageTracking("OUTGOING", "193 Neptune Ave", "RECIEVED"),
				new PackageTracking("OUTGOING", "6793 Cortland St.", "RECIEVED"),
				new PackageTracking("OUTGOING", "2211 Central Park Rd.", "RECIEVED"),
				new PackageTracking("INCOMING", "412 Bleecker St.", "RECIEVED"),
				new PackageTracking("INCOMING", "412 Bleecker St.", "DELIVERED"),
				new PackageTracking("OUTGOING", "794 Westwood Av.", "IN TRANSIT")
			};
		}
		return new List<PackageTracking>();
	}

	public static void CreatePackagesTable(string name, string tableName, IDbConnection connection = null)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "delivery_type";
		string text2 = "address";
		string text3 = "status";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, GetPackages(name));
	}

	public static void CreateWinnersTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "first_name";
		string text2 = "last_name";
		string text3 = "amount_won";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " REAL");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, d_winners, commit);
	}

	public static void GenerateWinners(float winningsMultiplier)
	{
		float num = 250f * winningsMultiplier;
		float num2 = num;
		d_winners.Add(new Winner(d_tieName.Item1, d_tieName.Item2, num2));
		while (num2 < 5000000f)
		{
			(string, string) name = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, d_tieName.Item1, d_tieName.Item2, everyone);
			string item = name.Item1;
			string item2 = name.Item2;
			float num3 = GetPayout();
			if (num3 != num)
			{
				d_winners.Add(new Winner(item, item2, num3));
				num2 += num3;
			}
		}
		d_winners = d_winners.OrderByDescending((Winner winner) => winner.amountWon).ToList();
		static float GetPayout()
		{
			int num4 = CreateTablesHelpers.RANDY.Next(100);
			if (num4 <= 1)
			{
				return CreateTablesHelpers.RANDY.Next(20, 40) * 5000;
			}
			if (num4 <= 12)
			{
				return CreateTablesHelpers.RANDY.Next(200, 1900) * 50;
			}
			if (num4 <= 22)
			{
				return CreateTablesHelpers.RANDY.Next(40, 400) * 25;
			}
			if (num4 <= 50)
			{
				return CreateTablesHelpers.RANDY.Next(4, 40) * 25;
			}
			return CreateTablesHelpers.RANDY.Next(1, 10) * 10;
		}
	}

	public static void CreatePredictionsTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "season";
		string text2 = "code";
		string text3 = "payout_rate";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text3 + " REAL");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, d_predictions, commit);
	}

	public static float GeneratePredictions()
	{
		string[] array = new string[4] { "A", "B", "C", "D" };
		float[] array2 = new float[5] { 1.5f, 1.6f, 1.8f, 2.5f, 3.5f };
		float[] array3 = new float[8] { 2f, 3f, 4f, 5f, 7f, 8f, 9f, 10f };
		float[] list = array2.Union(array3).ToArray();
		(float, float, float) tuple = (CreateTablesHelpers.GetRandomValue(new float[3] { 1.5f, 1.6f, 1.8f }), CreateTablesHelpers.GetRandomValue(new float[4] { 7f, 8f, 9f, 10f }), CreateTablesHelpers.GetRandomValue(new float[3] { 3f, 4f, 5f }));
		float num = tuple.Item1 * tuple.Item2 * tuple.Item3;
		for (int i = 1; i <= 35; i++)
		{
			float num2 = 1f;
			string[] array4 = array;
			foreach (string arg in array4)
			{
				for (int k = 0; k < 9; k++)
				{
					string text = $"{arg}{k}";
					float num3 = 0f;
					if (i == d_seasonWagered)
					{
						switch (text)
						{
						case "A3":
							(num3, _, _) = tuple;
							break;
						case "C7":
							num3 = tuple.Item2;
							break;
						case "B2":
							num3 = tuple.Item3;
							break;
						default:
							num3 = CreateTablesHelpers.GetRandomValue(list);
							break;
						}
					}
					else
					{
						switch (text)
						{
						case "A3":
						case "C7":
						case "B2":
							num3 = ((!(text == "A3")) ? CreateTablesHelpers.GetRandomValue(array3) : CreateTablesHelpers.GetRandomValue(array2));
							if (text == "C7" && num2 * num3 == num)
							{
								num3 = ((num3 == 2f) ? 3f : 2f);
							}
							num2 *= num3;
							break;
						default:
							num3 = CreateTablesHelpers.GetRandomValue(list);
							break;
						}
					}
					d_predictions.Add(new PredictionRate(i, text, num3));
				}
			}
			if (i != d_seasonWagered)
			{
				var (firstName, lastName) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, d_tieName.Item1, d_tieName.Item2, everyone);
				d_winners.Add(new Winner(firstName, lastName, (int)num2 * 250));
			}
		}
		return num;
	}

	public static void CreateCardDrawingsTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "week";
		string text2 = "card1";
		string text3 = "card2";
		string text4 = "card3";
		string text5 = "card4";
		string text6 = "card5";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " TEXT, " + text3 + " TEXT, " + text4 + " TEXT, " + text5 + " TEXT, " + text6 + " TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[6] { text, text2, text3, text4, text5, text6 }, d_cards, commit);
	}

	public static void GenerateCardDrawings()
	{
		Dictionary<int, HashSet<string>> cardPossibilites = new Dictionary<int, HashSet<string>>();
		for (int i = 0; i < 340; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				cardPossibilites[j] = new HashSet<string>
				{
					"A", "2", "3", "4", "5", "6", "7", "8", "9", "10",
					"J", "Q", "K"
				};
			}
			string card = GetCard();
			string card2 = GetCard();
			string card3 = GetCard();
			string card4 = GetCard();
			string card5 = GetCard();
			d_cards.Add(new CardDrawing(i, card, card2, card3, card4, card5));
		}
		string GetCard()
		{
			int randomValue = CreateTablesHelpers.GetRandomValue(cardPossibilites.Keys);
			string randomValue2 = CreateTablesHelpers.GetRandomValue(cardPossibilites[randomValue]);
			cardPossibilites[randomValue].Remove(randomValue2);
			return randomValue switch
			{
				0 => randomValue2 + " Hearts", 
				1 => randomValue2 + " Diamonds", 
				2 => randomValue2 + " Spades", 
				_ => randomValue2 + " Clubs", 
			};
		}
	}

	private static void GenerateGames()
	{
		(bool, bool, bool)[] conditions = GetSeasonConditions();
		for (int i = 1; i <= 35; i++)
		{
			GenerateGame(i, conditions);
		}
		static (bool, bool, bool)[] GetSeasonConditions()
		{
			(bool, bool, bool)[] array = new(bool, bool, bool)[35];
			List<int> list = Enumerable.Range(0, 35).ToList();
			d_seasonWagered = CreateTablesHelpers.RANDY.Next(20, 25);
			Debug.Log($"Season wagered on: {d_seasonWagered}");
			array[d_seasonWagered - 1] = (true, true, true);
			list.Remove(d_seasonWagered - 1);
			new List<int>();
			for (int j = 0; j < 6; j++)
			{
				int num = j switch
				{
					0 => 3, 
					1 => 3, 
					2 => 2, 
					3 => 8, 
					4 => 9, 
					_ => 8, 
				};
				for (int k = 0; k < num; k++)
				{
					int randomValue = CreateTablesHelpers.GetRandomValue(list);
					list.Remove(randomValue);
					if (j == 0 || j == 3 || j == 5)
					{
						array[randomValue].Item1 = true;
					}
					if (j == 1 || j == 3 || j == 4)
					{
						array[randomValue].Item2 = true;
					}
					if (j == 2 || j == 4 || j == 5)
					{
						array[randomValue].Item3 = true;
					}
				}
			}
			return array;
		}
	}

	private static void GenerateGame(int season, (bool, bool, bool)[] conditions)
	{
		string noBucketTeam = GetNoBucketTeam();
		HashSet<(string, string)> hashSet = new HashSet<(string, string)>
		{
			("Molemen", "Uncles"),
			("Molemen", "Pierogi"),
			("Froggies", "Molemen"),
			("Froggies", "Pierogi"),
			("Froggies", "Uncles"),
			("Uncles", "Pierogi")
		};
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		(bool, bool, bool) tuple = conditions[season - 1];
		bool item = tuple.Item1;
		bool item2 = tuple.Item2;
		bool item3 = tuple.Item3;
		int num = (item2 ? CreateTablesHelpers.RANDY.Next(0, 3) : (-1));
		bool flag = false;
		for (int num2 = 0; num2 < 6; num2++)
		{
			int game = num2 + 1;
			(string, string) randomValue = CreateTablesHelpers.GetRandomValue(hashSet);
			var (text, text2) = randomValue;
			hashSet.Remove(randomValue);
			int num3;
			int num4;
			if (!(text == "Uncles"))
			{
				num3 = ((text2 == "Uncles") ? 1 : 0);
				if (num3 == 0)
				{
					num4 = 0;
					goto IL_0126;
				}
			}
			else
			{
				num3 = 1;
			}
			num4 = ((num == 0) ? 1 : 0);
			goto IL_0126;
			IL_0126:
			bool isUnclesWinGame = (byte)num4 != 0;
			var (num5, num6) = GetFinalScores(season, game, text, text2, noBucketTeam, item, item2, item3, isUnclesWinGame);
			if (!item3 && (num5 > 35 || num6 > 35))
			{
				flag = true;
			}
			if (num3 != 0 && num >= 0)
			{
				num--;
			}
			(int, int, int) tuple4 = GetGameDate(season, game);
			int item4 = tuple4.Item1;
			int item5 = tuple4.Item2;
			int item6 = tuple4.Item3;
			int date = CreateTablesHelpers.GetDate(item4, item5, item6);
			d_games.Add(new Game(date, season, game, text, num5));
			d_games.Add(new Game(date, season, game, text2, num6));
			if (num3 != 0)
			{
				if ((season + 2) % 4 == d_flightQuarter && item4 == d_flightYear)
				{
					d_flightDate = new DateTime(item4, item5, item6);
					Debug.Log($"Flight date is {d_flightDate}");
				}
				else if (CreateTablesHelpers.IsPercentChance(15) && item4 > 1991 && d_otherCloudyUncles.Count < 6)
				{
					d_otherCloudyUncles.Add(date);
				}
				d_uncleGames.Add(date);
			}
			string key = ((num5 > num6) ? text : text2);
			dictionary.TryGetValue(key, out var value);
			dictionary[key] = value + 1;
		}
		string text3 = "";
		string text4 = "";
		int num7 = -1;
		int num8 = -1;
		foreach (string key2 in dictionary.Keys)
		{
			if (dictionary[key2] > num7)
			{
				if (num7 != -1)
				{
					num8 = num7;
					text4 = text3;
				}
				num7 = dictionary[key2];
				text3 = key2;
			}
			else if (dictionary[key2] > num8)
			{
				num8 = dictionary[key2];
				text4 = key2;
			}
		}
		int num9;
		int num10;
		if (!(text3 == "Uncles"))
		{
			num9 = ((text4 == "Uncles") ? 1 : 0);
			if (num9 == 0)
			{
				num10 = 0;
				goto IL_0326;
			}
		}
		else
		{
			num9 = 1;
		}
		num10 = ((num == 0) ? 1 : 0);
		goto IL_0326;
		IL_0326:
		bool isUnclesWinGame2 = (byte)num10 != 0;
		var (num11, num12) = GetFinalScores(season, 7, text3, text4, noBucketTeam, item, item2, item3, isUnclesWinGame2);
		if (num11 <= 35 && num12 <= 35 && !item3 && !flag)
		{
			if (num11 > num12)
			{
				num11 = 36;
			}
			else
			{
				num12 = 36;
			}
		}
		(int, int, int) tuple6 = GetGameDate(season, 7);
		int item7 = tuple6.Item1;
		int item8 = tuple6.Item2;
		int item9 = tuple6.Item3;
		int date2 = CreateTablesHelpers.GetDate(item7, item8, item9);
		d_games.Add(new Game(date2, season, 7, text3, num11));
		d_games.Add(new Game(date2, season, 7, text4, num12));
		if (num9 != 0)
		{
			d_uncleGames.Add(date2);
		}
		static int GetFinalScore(string team, string text5, bool condition1, bool condition2, bool condition3)
		{
			int num13 = ((!condition1 || !(team == text5)) ? CreateTablesHelpers.RANDY.Next(1, (team == "Uncles") ? 3 : 5) : 0);
			int num14 = CreateTablesHelpers.RANDY.Next((team == "Uncles") ? 2 : (condition3 ? ((35 - num13 * 5) / 8) : 5));
			return num13 * 5 + num14 * 8;
		}
		static (int, int) GetFinalScores(int num15, int num16, string team1, string team2, string text5, bool condition1, bool condition2, bool condition3, bool flag2)
		{
			int num13 = GetFinalScore(team1, text5, condition1, condition2, condition3);
			int num14 = GetFinalScore(team2, text5, condition1, condition2, condition3);
			if (condition2 && flag2)
			{
				if (team1 == "Uncles" && num13 <= num14 + 5)
				{
					(num13, num14) = GetCondition2GameScore(num13, num14, team2);
				}
				else if (team2 == "Uncles" && num14 <= num13 + 5)
				{
					(num14, num13) = GetCondition2GameScore(num14, num13, team1);
				}
			}
			else if (!condition2)
			{
				if (team1 == "Uncles" && num13 > num14 + 5)
				{
					(num13, num14) = GetCondition2FalseScore(team1, team2, num13, num14);
				}
				else if (team2 == "Uncles" && num14 > num13 + 5)
				{
					(num14, num13) = GetCondition2FalseScore(team2, team1, num14, num13);
				}
			}
			else if (num13 == num14 && condition3)
			{
				if (num13 + 8 > 35)
				{
					if (CreateTablesHelpers.IsPercentChance(50))
					{
						num13 -= 8;
					}
					else
					{
						num14 -= 8;
					}
				}
				else if (CreateTablesHelpers.IsPercentChance(50))
				{
					num13 += 8;
				}
				else
				{
					num14 += 8;
				}
			}
			return (num13, num14);
			(int, int) GetCondition2FalseScore(string uncles, string otherTeam, int unclesScore, int otherScore)
			{
				if (condition1 && uncles == text5)
				{
					while (unclesScore > otherScore + 5)
					{
						otherScore += 5;
					}
				}
				else if (condition1 && otherTeam == text5)
				{
					if (condition3 && otherScore + 5 > 35)
					{
						otherScore -= 8;
						unclesScore = otherScore + 5;
					}
					else
					{
						unclesScore = otherScore + 5;
					}
				}
				else
				{
					unclesScore = otherScore + 5;
				}
				return (unclesScore, otherScore);
			}
			(int, int) GetCondition2GameScore(int unclesScore, int otherScore, string nonUncle)
			{
				if (unclesScore <= otherScore + 5)
				{
					int num17 = CreateTablesHelpers.RANDY.Next(1, 3);
					int num18 = CreateTablesHelpers.RANDY.Next(1, 3);
					if (condition1 && text5 == "Uncles")
					{
						unclesScore = 8 * (num17 + 2);
						otherScore = 8 * CreateTablesHelpers.RANDY.Next(num17) + 10;
					}
					else if (condition1 && text5 == nonUncle)
					{
						unclesScore = 8 * num17 + 5 * num18;
						otherScore = 8 * CreateTablesHelpers.RANDY.Next(num17);
					}
					else
					{
						unclesScore = 8 * num17 + 5 * num18;
						otherScore = 8 * CreateTablesHelpers.RANDY.Next(num17) + 5 * CreateTablesHelpers.RANDY.Next(num18 + 1);
					}
				}
				if (condition3 && unclesScore > 35)
				{
					unclesScore -= 8;
					otherScore -= 8;
				}
				return (unclesScore, otherScore);
			}
		}
		static (int, int, int) GetGameDate(int num14, int num17)
		{
			int num13 = 1989 + (int)Math.Round((double)num14 / 4.0, MidpointRounding.AwayFromZero);
			int num15 = ((num14 + 2) % 4) switch
			{
				0 => 1, 
				1 => 4, 
				2 => 7, 
				_ => 10, 
			};
			int num16 = 0;
			if (num17 >= 1)
			{
				num16 += 9;
			}
			if (num17 >= 2)
			{
				num16 += 5;
			}
			if (num17 >= 3)
			{
				num16 += 9;
			}
			if (num17 >= 4)
			{
				num16 += 5;
			}
			if (num17 >= 5)
			{
				num16 += 9;
			}
			if (num17 >= 6)
			{
				num16 += 5;
			}
			if (num17 >= 7)
			{
				num16 += 17;
			}
			int maxDays = CreateTablesHelpers.GetMaxDays(num15, num13 % 4 == 0);
			if (num16 > maxDays)
			{
				num15++;
				num16 -= maxDays;
			}
			return (num13, num15, num16);
		}
		static string GetNoBucketTeam()
		{
			return CreateTablesHelpers.RANDY.Next(8) switch
			{
				0 => "Molemen", 
				1 => "Froggies", 
				2 => "Pierogi", 
				_ => "Uncles", 
			};
		}
	}

	public static void CreateGamesTable(string tableName, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string text = "date";
		string text2 = "season";
		string text3 = "game";
		string text4 = "team";
		string text5 = "final_score";
		DatabaseUtils.CreateTable(connection, tableName, text + " INT, " + text2 + " INT, " + text3 + " INT, " + text4 + " TEXT, " + text5 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[5] { text, text2, text3, text4, text5 }, d_games, commit);
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}

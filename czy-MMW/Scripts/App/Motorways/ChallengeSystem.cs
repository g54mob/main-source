using System;
using System.Collections.Generic;
using Factory;

namespace Motorways
{
	public class ChallengeSystem : ICreatedInScopeHandler
	{
		public enum LeaderboardWeek
		{
			WeekA = 0,
			WeekB = 1
		}

		[Flags]
		public enum RefreshOverridesDetails
		{
			None = 0,
			NewDailyChallenge = 1,
			NewWeeklyChallenge = 2
		}

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ChallengeSystem");

		[Dependency]
		private ChallengeDatabase _challengeDatabase;

		[Dependency]
		private MapDatabase _mapDatabase;

		[Dependency]
		private ChallengeOverrides _challengeOverrides;

		private TimeSpan _debugTimeOffset;

		private WeeklyChallengeBlock _weeklyChallengeBlock;

		private MapChallenge _cachedDailyChallenge;

		private MapChallenge _cachedWeeklyChallenge;

		public const int DaysPerWeek = 7;

		public const int SecondsPerDay = 86400;

		public const int NumberOfChallengesPerWeeklyChallenge = 3;

		public const int NumberOfChallengesPerDailyChallenge = 2;

		public const DayOfWeek ExpertModeDailyChallengeDay = DayOfWeek.Saturday;

		public const int MaxGenerationIterationAttempts = 50;

		private static readonly DateTime WeeklyChallengeEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public const ulong WeeklyChallengeSeedSalt = 1354843751uL;

		public MapChallenge DailyChallenge
		{
			get
			{
				if (TryGetPrecalculatedDailyChallenge(out var result))
				{
					return result;
				}
				int currentTimestamp = CurrentTimestamp;
				if (_weeklyChallengeBlock == null || currentTimestamp >= _weeklyChallengeBlock.weeklyChallenge.TimeEnd)
				{
					_weeklyChallengeBlock = GenerateWeeklyChallengeBlock();
				}
				MapChallenge mapChallenge = null;
				for (int i = 0; i < _weeklyChallengeBlock.dailyChallenges.Length; i++)
				{
					if (currentTimestamp < _weeklyChallengeBlock.dailyChallenges[i].TimeEnd)
					{
						mapChallenge = _weeklyChallengeBlock.dailyChallenges[i];
						break;
					}
				}
				if (!Diagnostics.Verify(mapChallenge != null, "Unable to find a valid MapChallenge. This shouldn't be possible."))
				{
					mapChallenge = _weeklyChallengeBlock.dailyChallenges[_weeklyChallengeBlock.dailyChallenges.Length - 1];
				}
				return mapChallenge;
			}
		}

		public MapChallenge WeeklyChallenge
		{
			get
			{
				if (TryGetPrecalculatedWeeklyChallenge(out var result))
				{
					return result;
				}
				if (_weeklyChallengeBlock == null || _weeklyChallengeBlock.weeklyChallenge.HasExpired())
				{
					_weeklyChallengeBlock = GenerateWeeklyChallengeBlock();
				}
				return _weeklyChallengeBlock.weeklyChallenge;
			}
		}

		public int CurrentTimestamp => ToTimestamp(DateTimeNow);

		private DateTime DateTimeNow => GameDateTime.UtcNow + _debugTimeOffset;

		public YearOfChallenges GetYearOfChallengesForYear(int year)
		{
			foreach (YearOfChallenges precalculatedChallenge in _challengeDatabase.precalculatedChallenges)
			{
				if (precalculatedChallenge.year == year)
				{
					return precalculatedChallenge;
				}
			}
			return null;
		}

		private bool TryGetPrecalculatedDailyChallenge(out MapChallenge result)
		{
			DateTime dateTimeNow = DateTimeNow;
			dateTimeNow = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);
			int num = ToTimestamp(dateTimeNow);
			int num2 = ToTimestamp(dateTimeNow.AddDays(1.0));
			if (_cachedDailyChallenge != null && _cachedDailyChallenge.TimeStart == num)
			{
				result = _cachedDailyChallenge;
				return true;
			}
			if (_challengeOverrides.TryGetDailyChallenge(num, num2, out var result2))
			{
				result = result2;
				_cachedDailyChallenge = result;
				return true;
			}
			YearOfChallenges yearOfChallengesForYear = GetYearOfChallengesForYear(dateTimeNow.Year);
			if (yearOfChallengesForYear == null)
			{
				result = null;
				return false;
			}
			PrecalculatedTimedChallengeData challengesOnDay = yearOfChallengesForYear.GetChallengesOnDay(dateTimeNow);
			MapDefinition mapByName = _mapDatabase.MapLibrary.GetMapByName(challengesOnDay.city.ToString());
			result = MapChallenge.CreateDailyChallenge(this, mapByName, challengesOnDay.challenges, num, num2, (ulong)num);
			_cachedDailyChallenge = result;
			return true;
		}

		private bool TryGetPrecalculatedWeeklyChallenge(out MapChallenge result)
		{
			DateTime dateTime = StartOfWeek(DateTimeNow);
			int num = ToTimestamp(dateTime);
			int num2 = ToTimestamp(dateTime.AddDays(7.0));
			if (_cachedWeeklyChallenge != null && _cachedWeeklyChallenge.TimeStart == num)
			{
				result = _cachedWeeklyChallenge;
				return true;
			}
			if (_challengeOverrides.TryGetWeeklyChallenge(num, num2, out var result2))
			{
				result = result2;
				_cachedWeeklyChallenge = result;
				return true;
			}
			YearOfChallenges yearOfChallengesForYear = GetYearOfChallengesForYear(dateTime.Year);
			if (yearOfChallengesForYear == null)
			{
				result = null;
				return false;
			}
			PrecalculatedTimedChallengeData challengesOnWeekOfDay = yearOfChallengesForYear.GetChallengesOnWeekOfDay(dateTime);
			MapDefinition mapByName = _mapDatabase.MapLibrary.GetMapByName(challengesOnWeekOfDay.city.ToString());
			result = MapChallenge.CreateWeeklyChallenge(this, mapByName, challengesOnWeekOfDay.challenges, num, num2, (ulong)num);
			_cachedWeeklyChallenge = result;
			return true;
		}

		public bool AreChallengesUnlocked(ActivePlayer player)
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				return false;
			}
			if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
			{
				return true;
			}
			if (_challengeDatabase.qualifyingAchievementsToUnlockTimedChallenges == null || _challengeDatabase.qualifyingAchievementsToUnlockTimedChallenges.Length == 0)
			{
				return true;
			}
			MotorwaysAchievementData[] qualifyingAchievementsToUnlockTimedChallenges = _challengeDatabase.qualifyingAchievementsToUnlockTimedChallenges;
			foreach (MotorwaysAchievementData motorwaysAchievementData in qualifyingAchievementsToUnlockTimedChallenges)
			{
				if (player.IsAchievementCompleted(motorwaysAchievementData.GetId()))
				{
					return true;
				}
			}
			return false;
		}

		public List<MotorwaysGameJournalSave> GetActiveDailyChallengeSaves(ActivePlayer player, bool localOnly = false)
		{
			List<MotorwaysGameJournalSave> list = new List<MotorwaysGameJournalSave>();
			if (IsSaveAnInProgressDailyChallenge(player.LocalSavedGame))
			{
				list.Add((MotorwaysGameJournalSave)player.LocalSavedGame);
			}
			if (!localOnly)
			{
				foreach (IGameJournalSave foreignSavedGame in player.ForeignSavedGames)
				{
					if (IsSaveAnInProgressDailyChallenge(foreignSavedGame))
					{
						list.Add((MotorwaysGameJournalSave)foreignSavedGame);
					}
				}
			}
			return list;
		}

		public List<MotorwaysGameJournalSave> GetActiveWeeklyChallengeSaves(ActivePlayer player, bool localOnly = false)
		{
			List<MotorwaysGameJournalSave> list = new List<MotorwaysGameJournalSave>();
			if (IsSaveAnInProgressWeeklyChallenge(player.LocalSavedGame))
			{
				list.Add((MotorwaysGameJournalSave)player.LocalSavedGame);
			}
			if (!localOnly)
			{
				foreach (IGameJournalSave foreignSavedGame in player.ForeignSavedGames)
				{
					if (IsSaveAnInProgressWeeklyChallenge(foreignSavedGame))
					{
						list.Add((MotorwaysGameJournalSave)foreignSavedGame);
					}
				}
			}
			return list;
		}

		public bool IsSaveAnInProgressDailyChallenge(IGameJournalSave save)
		{
			if (save is MotorwaysGameJournalSave { ChallengeType: MapChallenge.ChallengeType.Daily } motorwaysGameJournalSave)
			{
				return motorwaysGameJournalSave.ChallengeEndTime == DailyChallenge.TimeEnd;
			}
			return false;
		}

		public bool IsSaveAnInProgressWeeklyChallenge(IGameJournalSave save)
		{
			if (save is MotorwaysGameJournalSave { ChallengeType: MapChallenge.ChallengeType.Weekly } motorwaysGameJournalSave)
			{
				return motorwaysGameJournalSave.ChallengeEndTime == WeeklyChallenge.TimeEnd;
			}
			return false;
		}

		public void DebugChangeTimeOffset(TimeSpan timespan)
		{
			_debugTimeOffset += timespan;
		}

		public static int ToTimestamp(DateTime dateTime)
		{
			return (int)((dateTime.Ticks - 621355968000000000L) / 10000000);
		}

		public static DateTime ToDateTime(int unixTime)
		{
			return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
		}

		public static LeaderboardWeek GetLeaderboardWeek(int unixTime)
		{
			if (WeeksSinceEpoch(ToDateTime(unixTime)) % 2 != 0L)
			{
				return LeaderboardWeek.WeekB;
			}
			return LeaderboardWeek.WeekA;
		}

		public static DateTime GetStartOfLastOccurence(DayOfWeek day)
		{
			DateTime utcToday = GameDateTime.UtcToday;
			TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
			for (int i = 0; i < 7; i++)
			{
				if (utcToday.DayOfWeek == day)
				{
					return utcToday;
				}
				utcToday -= timeSpan;
			}
			Log.Error($"Failed to calculate the last occurence of {day} - Defaulting to today");
			return GameDateTime.UtcToday;
		}

		public void OnCreatedInScope(IScope scope)
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				_challengeOverrides.Initialize(this, _challengeDatabase, _mapDatabase);
				RefreshOverridesFromServer();
			}
		}

		public void RefreshOverridesFromServer(Action<ChallengeOverrides.RefreshResult, RefreshOverridesDetails> callback = null)
		{
			_challengeOverrides.RefreshOverridesFromServer(delegate(ChallengeOverrides.RefreshResult result)
			{
				RefreshOverridesDetails refreshOverridesDetails = RefreshOverridesDetails.None;
				if (result == ChallengeOverrides.RefreshResult.Success)
				{
					if (_cachedDailyChallenge != null && _challengeOverrides.TryGetDailyChallenge(_cachedDailyChallenge.TimeStart, _cachedDailyChallenge.TimeEnd, out var result2) && !result2.Equals(_cachedDailyChallenge))
					{
						_cachedDailyChallenge = result2;
						refreshOverridesDetails |= RefreshOverridesDetails.NewDailyChallenge;
					}
					if (_cachedWeeklyChallenge != null && _challengeOverrides.TryGetWeeklyChallenge(_cachedWeeklyChallenge.TimeStart, _cachedWeeklyChallenge.TimeEnd, out var result3) && !result3.Equals(_cachedWeeklyChallenge))
					{
						_cachedWeeklyChallenge = result3;
						refreshOverridesDetails |= RefreshOverridesDetails.NewWeeklyChallenge;
					}
				}
				callback?.Invoke(result, refreshOverridesDetails);
			});
		}

		public static MapDefinition.CityNames GetCityName(MapDefinition mapDefinition)
		{
			if (!Enum.TryParse<MapDefinition.CityNames>(mapDefinition.cityName, out var result))
			{
				return MapDefinition.CityNames.None;
			}
			return result;
		}

		public static DateTime StartOfWeek(DateTime dateTime)
		{
			int num = FloorMod((int)(dateTime.DayOfWeek - 1), 7);
			return dateTime.Date - TimeSpan.FromDays(num);
		}

		public static DateTime GetStartOfLastOccurence(LeaderboardWeek leaderboardWeek)
		{
			DateTime dateTime = StartOfWeek(GameDateTime.UtcNow);
			LeaderboardWeek leaderboardWeek2 = GetLeaderboardWeek(ToTimestamp(dateTime));
			if (leaderboardWeek != leaderboardWeek2)
			{
				return dateTime.Subtract(TimeSpan.FromDays(7.0));
			}
			return dateTime;
		}

		public static int FloorMod(int x, int m)
		{
			return (x % m + m) % m;
		}

		private static TimeSpan TimeSinceWeeklyChallengeEpoch(DateTime dateTime)
		{
			return StartOfWeek(dateTime) - WeeklyChallengeEpoch;
		}

		public static ulong WeeksSinceEpoch(DateTime dateTime)
		{
			return (ulong)(TimeSinceWeeklyChallengeEpoch(StartOfWeek(dateTime)).Days / 7);
		}

		private static ulong GetWeeklySeed(DateTime dateTime)
		{
			ulong num = WeeksSinceEpoch(dateTime);
			return num * 7 * 86400 * 1354843751 + num;
		}

		private WeeklyChallengeBlock GenerateWeeklyChallengeBlock()
		{
			ulong weeklySeed = GetWeeklySeed(DateTimeNow);
			PseudorandomGenerator pseudorandomGenerator = new PseudorandomGenerator
			{
				Seed = weeklySeed
			};
			WeeklyChallengeBlock weeklyChallengeBlock = new WeeklyChallengeBlock();
			weeklyChallengeBlock.weeklyChallenge = GenerateWeeklyMapChallenge(pseudorandomGenerator.ULong());
			List<MapDefinition> list = new List<MapDefinition>();
			for (int i = 0; i < weeklyChallengeBlock.dailyChallenges.Length; i++)
			{
				if (list.Count == 0)
				{
					list.AddRange(_mapDatabase.MapLibrary.Maps);
					list.Remove(weeklyChallengeBlock.weeklyChallenge.mapDefinition);
					list.Shuffle(pseudorandomGenerator);
				}
				int index = list.Count - 1;
				MapDefinition mapDefinition = list[index];
				list.RemoveAt(index);
				ChallengeData[] result = null;
				int num = 0;
				uint num2 = 0u;
				while (result == null && num < 50)
				{
					num2 = (uint)pseudorandomGenerator.Seed;
					TryGenerateChallenges(pseudorandomGenerator, mapDefinition, _challengeDatabase, new List<ChallengeData>(), 2, out result);
					num++;
				}
				int num3 = weeklyChallengeBlock.weeklyChallenge.TimeStart + i * 86400;
				int timeEnd = num3 + 86400;
				MapChallenge mapChallenge = MapChallenge.CreateDailyChallenge(this, mapDefinition, result, num3, timeEnd, num2);
				weeklyChallengeBlock.dailyChallenges[i] = mapChallenge;
			}
			return weeklyChallengeBlock;
		}

		public MapChallenge GenerateDailyMapChallenge(ulong seed, List<ChallengeData> mustHaveChallenges = null)
		{
			PseudorandomGenerator pseudorandomGenerator = new PseudorandomGenerator
			{
				Seed = seed
			};
			DateTime date = DateTimeNow.Date;
			DateTime dateTime = date + TimeSpan.FromDays(1.0);
			int timeStart = ToTimestamp(date);
			int timeEnd = ToTimestamp(dateTime);
			int num = 0;
			MapChallenge mapChallenge = null;
			if (mustHaveChallenges == null)
			{
				mustHaveChallenges = new List<ChallengeData>();
			}
			List<MapDefinition> list = new List<MapDefinition>(_mapDatabase.MapLibrary.Maps);
			while (mapChallenge == null && num < 50)
			{
				MapDefinition mapDefinition = list[pseudorandomGenerator.Int(list.Count)];
				TryGenerateMapChallenge(pseudorandomGenerator, mapDefinition, MapChallenge.ChallengeType.Daily, mustHaveChallenges, 2 + mustHaveChallenges.Count, timeStart, timeEnd, (uint)seed, out mapChallenge);
				num++;
			}
			return mapChallenge;
		}

		public MapChallenge GenerateWeeklyMapChallenge(ulong seed)
		{
			PseudorandomGenerator pseudorandomGenerator = new PseudorandomGenerator
			{
				Seed = seed
			};
			DateTime dateTime = StartOfWeek(DateTimeNow.Date);
			DateTime dateTime2 = dateTime + TimeSpan.FromDays(7.0);
			int timeStart = ToTimestamp(dateTime);
			int timeEnd = ToTimestamp(dateTime2);
			int num = 0;
			MapChallenge mapChallenge = null;
			List<ChallengeData> list = new List<ChallengeData>();
			List<MapDefinition> list2 = new List<MapDefinition>(_mapDatabase.MapLibrary.Maps);
			while (mapChallenge == null && num < 50)
			{
				MapDefinition mapDefinition = list2[pseudorandomGenerator.Int(list2.Count)];
				List<ChallengeData> validChallengesForCity = GetValidChallengesForCity(mapDefinition, _challengeDatabase.wildcardChallenges);
				list.Clear();
				list.Add(validChallengesForCity[pseudorandomGenerator.Int(validChallengesForCity.Count)]);
				TryGenerateMapChallenge(pseudorandomGenerator, mapDefinition, MapChallenge.ChallengeType.Weekly, list, 3, timeStart, timeEnd, (uint)seed, out mapChallenge);
				num++;
			}
			if (!Diagnostics.Verify(mapChallenge != null, "Unable randomly generate a Weekly challenge after {0} iteration attempts", num))
			{
				return null;
			}
			ChallengeData challengeData = mapChallenge.challenges[0];
			mapChallenge.challenges[0] = mapChallenge.challenges[1];
			mapChallenge.challenges[1] = challengeData;
			return mapChallenge;
		}

		private bool TryGenerateMapChallenge(PseudorandomGenerator rand, MapDefinition mapDefinition, MapChallenge.ChallengeType challengeType, List<ChallengeData> mustHaveChallenges, int numberOfChallenges, int timeStart, int timeEnd, uint seed, out MapChallenge mapChallenge)
		{
			if (!TryGenerateChallenges(rand, mapDefinition, _challengeDatabase, mustHaveChallenges, numberOfChallenges, out var result))
			{
				mapChallenge = null;
				return false;
			}
			switch (challengeType)
			{
			case MapChallenge.ChallengeType.Daily:
				mapChallenge = MapChallenge.CreateDailyChallenge(this, mapDefinition, result, timeStart, timeEnd, seed);
				return true;
			case MapChallenge.ChallengeType.Weekly:
				mapChallenge = MapChallenge.CreateWeeklyChallenge(this, mapDefinition, result, timeStart, timeEnd, seed);
				return true;
			default:
				Diagnostics.FailAssert($"Invalid ChallengeType for MapChallenge: {challengeType}, expected Daily Challenge or Weekly Challenge");
				mapChallenge = null;
				return false;
			}
		}

		public static bool TryGenerateChallenges(PseudorandomGenerator rand, MapDefinition cityName, ChallengeDatabase challengeDatabase, List<ChallengeData> mustHaveChallenges, int numberOfChallenges, out ChallengeData[] result)
		{
			List<ChallengeData> mapChallenges = GetValidChallengesForCity(cityName, challengeDatabase.regularChallenges);
			if (!Diagnostics.Verify(numberOfChallenges <= mustHaveChallenges.Count + mapChallenges.Count, "We do not have enough challenges"))
			{
				result = null;
				return false;
			}
			mapChallenges.Shuffle(rand);
			List<ChallengeData> list = new List<ChallengeData>(numberOfChallenges);
			list.AddRange(mustHaveChallenges);
			int mapChallengeIndex = 0;
			while (list.Count < numberOfChallenges && mapChallengeIndex < mapChallenges.Count)
			{
				if (!list.Exists((ChallengeData challenge) => challenge.IsIncompatibleWith(mapChallenges[mapChallengeIndex])))
				{
					list.Add(mapChallenges[mapChallengeIndex]);
				}
				int num = mapChallengeIndex + 1;
				mapChallengeIndex = num;
			}
			if (!Diagnostics.Verify(list.Count == numberOfChallenges, "Not enough valid results to fill result array"))
			{
				result = null;
				return false;
			}
			result = list.ToArray();
			return true;
		}

		public static List<ChallengeData> GetValidChallengesForCity(MapDefinition map, List<ChallengeData> source)
		{
			List<ChallengeData> list = new List<ChallengeData>();
			foreach (ChallengeData item in source)
			{
				if (item.IsCompatibleWith(map))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public bool TryGetChallenge(MapChallenge.ChallengeType type, out MapChallenge result)
		{
			switch (type)
			{
			case MapChallenge.ChallengeType.Daily:
				result = DailyChallenge;
				return true;
			case MapChallenge.ChallengeType.Weekly:
				result = WeeklyChallenge;
				return true;
			case MapChallenge.ChallengeType.None:
				result = null;
				return false;
			default:
				Diagnostics.FailAssert("Unhandled challenge type: {0}. Dev needs to add an entry in the switch case above.");
				result = null;
				return false;
			}
		}
	}
}

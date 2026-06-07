using System;
using System.Collections.Generic;
using Motorways.Leaderboards;
using UnityEngine;

namespace Motorways
{
	public class MapChallenge : IEquatable<MapChallenge>
	{
		public enum ChallengeType
		{
			None = 0,
			Daily = 1,
			Weekly = 2,
			Mystery = 3,
			City = 4
		}

		public const int NoChallengeIndex = -1;

		public const int AnyChallengeIndex = -2;

		private readonly ChallengeSystem _challengeSystem;

		public ChallengeType type;

		public int cityChallengeIndex = -1;

		public readonly MapDefinition mapDefinition;

		public readonly ChallengeData[] challenges;

		public ulong seed;

		private int _timeStart;

		private int _timeEnd;

		public int TimeStart => _timeStart;

		public int TimeEnd => _timeEnd;

		public int SecondsLeft => _timeEnd - _challengeSystem.CurrentTimestamp;

		public DateTimeOffset StartOfChallenge
		{
			get
			{
				if (type == ChallengeType.Daily || type == ChallengeType.Weekly)
				{
					return DateTimeOffset.FromUnixTimeSeconds(TimeStart);
				}
				return DateTimeOffset.UtcNow;
			}
		}

		public static MapChallenge CreateCityChallenge(ChallengeSystem challengeSystem, int cityChallengeIndex, MapDefinition mapDefinition, ChallengeData[] challenges, ulong seed = 0uL)
		{
			return new MapChallenge(challengeSystem, ChallengeType.City, cityChallengeIndex, mapDefinition, challenges, 0, 0, seed);
		}

		public static MapChallenge CreateDailyChallenge(ChallengeSystem challengeSystem, MapDefinition mapDefinition, ChallengeData[] challenges, int timeStart, int timeEnd, ulong seed)
		{
			return new MapChallenge(challengeSystem, ChallengeType.Daily, -1, mapDefinition, challenges, timeStart, timeEnd, seed);
		}

		public static MapChallenge CreateWeeklyChallenge(ChallengeSystem challengeSystem, MapDefinition mapDefinition, ChallengeData[] challenges, int timeStart, int timeEnd, ulong seed)
		{
			return new MapChallenge(challengeSystem, ChallengeType.Weekly, -1, mapDefinition, challenges, timeStart, timeEnd, seed);
		}

		public static MapChallenge CreateMysteryChallenge(ChallengeSystem challengeSystem, ChallengeDatabase challengeDatabase)
		{
			MapChallenge mapChallenge = null;
			if (!FeatureToggle.IsFeatureEnabled(Feature.RandomChallengesAreExpert))
			{
				mapChallenge = ((!Random.Bool()) ? challengeSystem.GenerateDailyMapChallenge((uint)UnityEngine.Random.Range(0, 100000)) : challengeSystem.GenerateWeeklyMapChallenge((uint)UnityEngine.Random.Range(0, 100000)));
			}
			else
			{
				List<ChallengeData> list = new List<ChallengeData>();
				list.Add(challengeDatabase.expertModeChallenge);
				mapChallenge = challengeSystem.GenerateDailyMapChallenge((uint)UnityEngine.Random.Range(0, 100000), list);
			}
			mapChallenge.type = ChallengeType.Mystery;
			mapChallenge._timeStart = 0;
			mapChallenge._timeEnd = 0;
			return mapChallenge;
		}

		public static MapChallenge RebuildMysteryChallenge(ChallengeSystem challengeSystem, MapDefinition mapDefinition, ChallengeData[] challenges, ulong seed)
		{
			return new MapChallenge(challengeSystem, ChallengeType.Mystery, -1, mapDefinition, challenges, 0, 0, seed);
		}

		private MapChallenge(ChallengeSystem challengeSystem, ChallengeType type, int cityChallengeIndex, MapDefinition mapDefinition, ChallengeData[] challenges, int timeStart, int timeEnd, ulong seed)
		{
			_challengeSystem = challengeSystem;
			this.type = type;
			this.cityChallengeIndex = cityChallengeIndex;
			this.mapDefinition = mapDefinition;
			this.challenges = challenges;
			this.seed = seed;
			_timeStart = timeStart;
			_timeEnd = timeEnd;
		}

		public bool HasExpired()
		{
			if (_challengeSystem.CurrentTimestamp - _timeStart > 0)
			{
				return SecondsLeft < 0;
			}
			return true;
		}

		public bool HasExpiredWithGracePeriod()
		{
			if (_challengeSystem.CurrentTimestamp - _timeStart > 0)
			{
				return SecondsLeft + 3600 < 0;
			}
			return true;
		}

		public static LeaderboardId GetLeaderboardIdForTimedChallenge(ChallengeType challengeType, int challengeStartTime)
		{
			switch (challengeType)
			{
			case ChallengeType.Daily:
				return new DailyLeaderboardId(challengeStartTime);
			case ChallengeType.Weekly:
				return new WeeklyLeaderboardId(challengeStartTime);
			default:
				Diagnostics.FailAssert("Invalid challenge type for leaderboard: {0}", challengeType);
				return null;
			}
		}

		public bool Equals(MapChallenge mapChallenge)
		{
			if (mapChallenge == null)
			{
				return false;
			}
			if (this == mapChallenge)
			{
				return true;
			}
			if (GetType() != mapChallenge.GetType())
			{
				return false;
			}
			bool flag = challenges.Length == mapChallenge.challenges.Length;
			for (int i = 0; i < challenges.Length; i++)
			{
				if (challenges[i] != mapChallenge.challenges[i])
				{
					flag = false;
					break;
				}
			}
			if (type == mapChallenge.type && cityChallengeIndex == mapChallenge.cityChallengeIndex && mapDefinition == mapChallenge.mapDefinition && flag && seed == mapChallenge.seed && _timeStart == mapChallenge._timeStart)
			{
				return _timeEnd == mapChallenge._timeEnd;
			}
			return false;
		}
	}
}

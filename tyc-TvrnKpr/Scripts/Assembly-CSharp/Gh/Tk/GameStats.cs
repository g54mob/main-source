using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using LitJson;

namespace Gh.Tk
{
	[Serializable]
	public class GameStats : IPersistable
	{
		[Serializable]
		public class StatReport : IPersistable
		{
			public string id;

			public Dictionary<string, int> stats;

			public string[] statReportsConfirmed;
		}

		private static float _timePlayedPartial;

		private static float _sessionLength;

		private Dictionary<string, int> _gameStats;

		[JsonIgnore]
		[IgnoreDataMember]
		public static Tavern CurrentTavern { get; set; }

		public static event EventHandler<EventArgs<(string key, int value)>> StatChangedGlobal
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<(string key, int value)>> StatChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void Init()
		{
		}

		public static void IncrementGameStat(string key)
		{
		}

		public static void IncrementGameStat(string key, int value)
		{
		}

		public static void ReportStatsToServer()
		{
		}

		public static int GetProfileGameStatValue(string key)
		{
			return 0;
		}

		public static int GetTavernStatValue(string key)
		{
			return 0;
		}

		public static void LogSecondsPlayedToProfile()
		{
		}

		private static string GetCurrentPlayModeString()
		{
			return null;
		}

		public static void RecordSessionLength()
		{
		}

		public static void ResetAllStats()
		{
		}

		public void IncrementStat(string key)
		{
		}

		public void IncrementStat(string key, int value)
		{
		}

		public void ReplaceStat(string key, int value)
		{
		}

		public int GetStatValue(string key)
		{
			return 0;
		}

		public GameStats CloneFast()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}

		public void ResetStats()
		{
		}
	}
}

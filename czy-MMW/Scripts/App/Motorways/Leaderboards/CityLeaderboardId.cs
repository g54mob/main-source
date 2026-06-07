using System;

namespace Motorways.Leaderboards
{
	public class CityLeaderboardId : LeaderboardId
	{
		public const string CityIdPrefix = "map";

		public MapDefinition.CityNames City { get; }

		public CityGameMode Mode { get; }

		public int CityChallengeIndex { get; }

		public override bool IsRecurringLeaderboard => false;

		public CityLeaderboardId(MapDefinition.CityNames city, CityGameMode mode, int cityChallengeIndex)
		{
			City = city;
			Mode = mode;
			CityChallengeIndex = cityChallengeIndex;
			_serializedString = Serialize();
		}

		public static bool IsCityLeaderboardId(string leaderboardIdString)
		{
			return leaderboardIdString.StartsWith("map");
		}

		public new static CityLeaderboardId Deserialize(string leaderboardIdString)
		{
			if (!IsCityLeaderboardId(leaderboardIdString))
			{
				LeaderboardId.Log.Error("Invalid CityLeaderboardId string prefix: " + leaderboardIdString);
				return null;
			}
			int num = "map".Length + 1;
			if (leaderboardIdString.Length < num)
			{
				LeaderboardId.Log.Error("Too few characters for CityLeaderboardId string: " + leaderboardIdString);
				return null;
			}
			string[] array = leaderboardIdString.Substring(num).Split('_');
			int num2 = array.Length;
			if (num2 < 2 || num2 > 3)
			{
				LeaderboardId.Log.Error("Invalid component count for CityLeaderboardId: " + leaderboardIdString);
				return null;
			}
			if (!Enum.TryParse<MapDefinition.CityNames>(array[0], ignoreCase: true, out var result))
			{
				LeaderboardId.Log.Error("Failed to parse city string from CityLeaderboardId: " + leaderboardIdString);
				return null;
			}
			if (!Enum.TryParse<CityGameMode>(array[1], ignoreCase: true, out var result2))
			{
				LeaderboardId.Log.Error("Failed to parse game mode string from CityLeaderboardId: " + leaderboardIdString);
				return null;
			}
			int result3 = -1;
			if (num2 == 3)
			{
				string text = array[2];
				if (text.Length != 10)
				{
					LeaderboardId.Log.Error("Failed to parse city challenge string from CityLeaderboardId: " + leaderboardIdString);
					return null;
				}
				if (!int.TryParse(text.Substring(text.Length - 1, 1), out result3))
				{
					LeaderboardId.Log.Error("Failed to parse city challenge index from CityLeaderboardId: " + leaderboardIdString);
					return null;
				}
			}
			return new CityLeaderboardId(result, result2, result3);
		}

		private string Serialize()
		{
			string text = City.ToString().ToLower();
			string text2 = Mode.ToString().ToLower();
			if (Mode == CityGameMode.CityChallenge)
			{
				return string.Format("{0}_{1}_{2}_challenge{3}", "map", text, text2, CityChallengeIndex);
			}
			return "map_" + text + "_" + text2;
		}
	}
}

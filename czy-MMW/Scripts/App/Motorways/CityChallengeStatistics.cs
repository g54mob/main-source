using System;
using System.Collections.Generic;

namespace Motorways
{
	public class CityChallengeStatistics
	{
		private int _bestScore;

		public string CityId { get; private set; }

		public GameMode Mode { get; private set; }

		public int ChallengeIndex { get; private set; }

		public int BestScore
		{
			get
			{
				return _bestScore;
			}
			set
			{
				if (_bestScore != value)
				{
					_bestScore = value;
					this.DataChanged?.Invoke();
				}
			}
		}

		public event Action DataChanged;

		public void Merge(CityChallengeStatistics otherStatistics)
		{
			if (otherStatistics.BestScore > BestScore)
			{
				BestScore = otherStatistics.BestScore;
			}
		}

		public CityChallengeStatistics(string cityId, GameMode mode, int challengeIndex, int bestScore = 0)
		{
			CityId = cityId;
			Mode = mode;
			ChallengeIndex = challengeIndex;
			BestScore = bestScore;
		}

		public static CityChallengeStatistics InitFromJson(JSON.Dictionary jsonDictionary)
		{
			string cityId = jsonDictionary.GetString("CityId");
			GameMode mode = (GameMode)jsonDictionary.GetInt("Mode");
			int challengeIndex = jsonDictionary.GetInt("ChallengeIndex");
			int bestScore = jsonDictionary.GetInt("BestScore");
			return new CityChallengeStatistics(cityId, mode, challengeIndex, bestScore);
		}

		public object ToJson()
		{
			return new Dictionary<string, object>
			{
				["CityId"] = CityId,
				["Mode"] = (int)Mode,
				["ChallengeIndex"] = ChallengeIndex,
				["BestScore"] = BestScore
			};
		}
	}
}

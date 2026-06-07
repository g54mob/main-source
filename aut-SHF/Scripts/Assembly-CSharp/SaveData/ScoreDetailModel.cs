using System;

namespace SaveData
{
	[Serializable]
	public class ScoreDetailModel
	{
		public eScoreRecord key;

		public int score;

		public bool ascensionBonus;

		public float bonusIncrease;

		public ScoreDetailModel(eScoreRecord key, int score, bool ascensionBonus = false, float bonusIncrease = 1f)
		{
		}
	}
}

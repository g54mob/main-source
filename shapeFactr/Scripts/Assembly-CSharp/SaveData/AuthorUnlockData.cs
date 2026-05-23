using System;

namespace SaveData
{
	[Serializable]
	public class AuthorUnlockData
	{
		public eWriterId writerId;

		public int clearAscension;

		public int playCount;

		public int exp;

		public int level;

		public bool waitAscensionUpEvent;

		public bool firstHeroChoice;

		public int maxScore;

		public int tempMaxScore;

		public int clearLastBossAscension;

		public AuthorUnlockData(MstWriterDataEntities entity)
		{
		}

		public void AddExp(int exp)
		{
		}

		private void LevelUp()
		{
		}

		public void UpdateTempMaxScore(int score)
		{
		}

		public void ApplyMaxScore()
		{
		}
	}
}

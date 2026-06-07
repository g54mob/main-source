using System;

namespace ModApi.Levels.Scores
{
	public class LevelScore
	{
		public DateTime DateTime { get; }

		public float Score { get; }

		public LevelScore(float score, DateTime dateTime)
		{
			Score = score;
			DateTime = dateTime;
		}
	}
}

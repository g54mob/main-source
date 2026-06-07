using System;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class SaveClass_GlobalState
	{
		public float moneyAmount;

		public int xp;

		public int shopLevel;

		public int shopScore;

		public Date date;

		public float normalizedTime;

		public DayTime dayTime;

		public bool isDay;

		public SaveClass_GlobalState()
		{
			moneyAmount = GameStateSettings.DefaultMoneyAmount;
			xp = 0;
			shopLevel = 1;
			shopScore = ScoreSettings.BaseScore;
			date = DayCycleSettings.StartDate;
			normalizedTime = 0f;
		}
	}
}

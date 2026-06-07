using System;

namespace Motorways
{
	[Serializable]
	public class MonthOfDailyChallenges
	{
		public string name;

		public PrecalculatedTimedChallengeData[] dailyChallenges;

		public int month;
	}
}

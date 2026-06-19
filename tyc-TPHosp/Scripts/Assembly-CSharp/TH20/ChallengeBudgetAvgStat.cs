namespace TH20
{
	public struct ChallengeBudgetAvgStat
	{
		public LevelStatsDatabase.Stat Stat;

		public float AvgValue;

		public ChallengeBudgetAvgStat(LevelStatsDatabase.Stat stat, float avgValue)
		{
			Stat = stat;
			AvgValue = avgValue;
		}
	}
}

namespace CTS.Core
{
	public abstract class StatisticData : ScriptableStringKey, IStatistic
	{
		public IStatistic DefaultStat { get; private set; }

		public float FloatValue => DefaultStat.FloatValue;

		public abstract IStatistic CreateStatistic();

		private void Awake()
		{
			DefaultStat = CreateStatistic();
		}
	}
}

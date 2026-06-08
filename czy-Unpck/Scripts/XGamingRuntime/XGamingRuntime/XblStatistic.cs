using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblStatistic
	{
		public string StatisticName { get; private set; }

		public string StatisticType { get; private set; }

		public string Value { get; private set; }

		internal XblStatistic(XGamingRuntime.Interop.XblStatistic interopStatistic)
		{
			StatisticName = interopStatistic.statisticName.GetString();
			StatisticType = interopStatistic.statisticType.GetString();
			Value = interopStatistic.value.GetString();
		}
	}
}

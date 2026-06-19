using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblStatistic
	{
		public string StatisticName { get; }

		public string StatisticType { get; }

		public string Value { get; }

		internal XblStatistic(XGamingRuntime.Interop.XblStatistic interopStatistic)
		{
			StatisticName = interopStatistic.statisticName.GetString();
			StatisticType = interopStatistic.statisticType.GetString();
			Value = interopStatistic.value.GetString();
		}
	}
}

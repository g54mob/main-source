using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblUserStatisticsResult
	{
		public ulong XboxUserId { get; }

		public XblServiceConfigurationStatistic[] ServiceConfigStatistics { get; }

		internal XblUserStatisticsResult(XGamingRuntime.Interop.XblUserStatisticsResult interopResult)
		{
			XboxUserId = interopResult.xboxUserId;
			ServiceConfigStatistics = interopResult.GetServiceConfigStatistics((XGamingRuntime.Interop.XblServiceConfigurationStatistic scs) => new XblServiceConfigurationStatistic(scs));
		}
	}
}

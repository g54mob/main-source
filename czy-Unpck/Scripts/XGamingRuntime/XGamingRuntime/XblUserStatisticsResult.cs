using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblUserStatisticsResult
	{
		public ulong XboxUserId { get; private set; }

		public XblServiceConfigurationStatistic[] ServiceConfigStatistics { get; private set; }

		internal XblUserStatisticsResult(XGamingRuntime.Interop.XblUserStatisticsResult interopResult)
		{
			XboxUserId = interopResult.xboxUserId;
			ServiceConfigStatistics = interopResult.GetServiceConfigStatistics((XGamingRuntime.Interop.XblServiceConfigurationStatistic scs) => new XblServiceConfigurationStatistic(scs));
		}
	}
}

using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblUserStatisticsResult
	{
		public ulong XboxUserId { get; private set; }

		public XblServiceConfigurationStatistic[] ServiceConfigStatistics { get; private set; }

		internal XblUserStatisticsResult(XblUserStatisticsResultInternal interopResult)
		{
		}
	}
}

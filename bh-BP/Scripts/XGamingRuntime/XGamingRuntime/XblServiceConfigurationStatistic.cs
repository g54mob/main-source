using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblServiceConfigurationStatistic
	{
		public string ServiceConfigurationId { get; private set; }

		public XblStatistic[] Statistics { get; private set; }

		internal XblServiceConfigurationStatistic(XblServiceConfigurationStatisticInternal interopStatistic)
		{
		}
	}
}

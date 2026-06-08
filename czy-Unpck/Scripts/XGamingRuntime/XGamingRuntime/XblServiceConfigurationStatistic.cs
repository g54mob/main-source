using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblServiceConfigurationStatistic
	{
		public string ServiceConfigurationId { get; private set; }

		public XblStatistic[] Statistics { get; private set; }

		internal XblServiceConfigurationStatistic(XGamingRuntime.Interop.XblServiceConfigurationStatistic interopStatistic)
		{
			ServiceConfigurationId = Converters.ByteArrayToString(interopStatistic.serviceConfigurationId);
			Statistics = interopStatistic.GetStatistics((XGamingRuntime.Interop.XblStatistic s) => new XblStatistic(s));
		}
	}
}

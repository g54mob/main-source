using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblRequestedStatistics
	{
		public string ServiceConfigurationId { get; }

		public string[] Statistics { get; }

		private XblRequestedStatistics(string serviceConfigurationId, string[] statistics)
		{
			ServiceConfigurationId = serviceConfigurationId;
			Statistics = statistics;
		}

		public static int Create(string serviceConfigurationId, string[] statistics, out XblRequestedStatistics requestedStatistics)
		{
			if (!XGamingRuntime.Interop.XblRequestedStatistics.ValidateFields(serviceConfigurationId))
			{
				requestedStatistics = null;
				return -2147024809;
			}
			requestedStatistics = new XblRequestedStatistics(serviceConfigurationId, statistics);
			return 0;
		}
	}
}

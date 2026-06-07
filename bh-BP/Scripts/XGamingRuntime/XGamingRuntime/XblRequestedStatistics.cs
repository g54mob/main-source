namespace XGamingRuntime
{
	public class XblRequestedStatistics
	{
		public string ServiceConfigurationId { get; private set; }

		public string[] Statistics { get; private set; }

		private XblRequestedStatistics(string serviceConfigurationId, string[] statistics)
		{
		}

		public static int Create(string serviceConfigurationId, string[] statistics, out XblRequestedStatistics requestedStatistics)
		{
			requestedStatistics = null;
			return 0;
		}
	}
}

namespace XGamingRuntime.Interop
{
	public struct XblRequestedStatistics
	{
		public unsafe fixed sbyte serviceConfigurationId[40];

		public unsafe sbyte** statistics;

		public uint statisticsCount;
	}
}

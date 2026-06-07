namespace XGamingRuntime.Interop
{
	public struct XblServiceConfigurationStatistic
	{
		public unsafe fixed sbyte serviceConfigurationId[40];

		public unsafe XblStatistic* statistics;

		public uint statisticsCount;
	}
}

namespace XGamingRuntime.Interop
{
	public struct XblUserStatisticsResult
	{
		public ulong xboxUserId;

		public unsafe XblServiceConfigurationStatistic* serviceConfigStatistics;

		public uint serviceConfigStatisticsCount;
	}
}

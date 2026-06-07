namespace XGamingRuntime.Interop
{
	public struct XblStatisticChangeEventArgs
	{
		public ulong xboxUserId;

		public unsafe fixed sbyte serviceConfigurationId[40];

		public XblStatistic latestStatistic;
	}
}

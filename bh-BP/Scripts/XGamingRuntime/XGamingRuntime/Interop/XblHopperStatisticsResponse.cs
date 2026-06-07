namespace XGamingRuntime.Interop
{
	public struct XblHopperStatisticsResponse
	{
		public unsafe sbyte* hopperName;

		public long estimatedWaitTime;

		public uint playersWaitingToMatch;
	}
}

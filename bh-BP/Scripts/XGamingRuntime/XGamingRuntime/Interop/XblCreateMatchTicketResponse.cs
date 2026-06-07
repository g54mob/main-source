namespace XGamingRuntime.Interop
{
	public struct XblCreateMatchTicketResponse
	{
		public unsafe fixed sbyte matchTicketId[40];

		public long estimatedWaitTime;
	}
}

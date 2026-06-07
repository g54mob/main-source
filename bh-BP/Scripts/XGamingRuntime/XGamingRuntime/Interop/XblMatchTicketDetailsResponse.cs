namespace XGamingRuntime.Interop
{
	public struct XblMatchTicketDetailsResponse
	{
		public XblTicketStatus matchStatus;

		public long estimatedWaitTime;

		public XblPreserveSessionMode preserveSession;

		public XblMultiplayerSessionReference ticketSession;

		public XblMultiplayerSessionReference targetSession;

		public unsafe sbyte* ticketAttributes;
	}
}

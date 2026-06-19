using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingTicketStatusChangedStateChange : PFMatchmakingStateChange
	{
		public PFMatchmakingTicketHandle Ticket { get; set; }

		internal unsafe PFMatchmakingTicketStatusChangedStateChange(PFMatchmakingStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFMatchmakingStateChange* stateChangeId)
			: base((PFMatchmakingStateChangeType)stateChangeUnion.stateChange.stateChangeType, stateChangeId)
		{
			PlayFab.Multiplayer.Interop.PFMatchmakingTicketStatusChangedStateChange ticketStatusChanged = stateChangeUnion.ticketStatusChanged;
			Ticket = new PFMatchmakingTicketHandle(ticketStatusChanged.ticket);
		}
	}
}

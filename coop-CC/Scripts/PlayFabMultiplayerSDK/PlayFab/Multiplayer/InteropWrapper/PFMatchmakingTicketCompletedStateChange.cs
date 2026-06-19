using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingTicketCompletedStateChange : PFMatchmakingStateChange
	{
		public int Result { get; set; }

		public PFMatchmakingTicketHandle Ticket { get; set; }

		public object AsyncContext { get; set; }

		internal unsafe PFMatchmakingTicketCompletedStateChange(PFMatchmakingStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFMatchmakingStateChange* stateChangeId)
			: base((PFMatchmakingStateChangeType)stateChangeUnion.stateChange.stateChangeType, stateChangeId)
		{
			PlayFab.Multiplayer.Interop.PFMatchmakingTicketCompletedStateChange ticketCompleted = stateChangeUnion.ticketCompleted;
			Result = ticketCompleted.result;
			Ticket = new PFMatchmakingTicketHandle(ticketCompleted.ticket);
			AsyncContext = null;
			if (ticketCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(ticketCompleted.asyncContext));
				AsyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}

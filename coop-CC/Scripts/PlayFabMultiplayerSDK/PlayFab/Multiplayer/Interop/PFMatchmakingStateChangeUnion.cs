using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct PFMatchmakingStateChangeUnion
	{
		[FieldOffset(0)]
		internal readonly PFMatchmakingStateChange stateChange;

		[FieldOffset(0)]
		internal readonly PFMatchmakingTicketCompletedStateChange ticketCompleted;

		[FieldOffset(0)]
		internal readonly PFMatchmakingTicketStatusChangedStateChange ticketStatusChanged;
	}
}

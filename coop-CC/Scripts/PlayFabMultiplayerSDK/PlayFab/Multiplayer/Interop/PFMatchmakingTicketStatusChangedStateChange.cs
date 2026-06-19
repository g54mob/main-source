using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct PFMatchmakingTicketStatusChangedStateChange
	{
		[FieldOffset(0)]
		public PFMatchmakingStateChange __AnonymousBase_1;

		[FieldOffset(8)]
		public unsafe PFMatchmakingTicket* ticket;
	}
}

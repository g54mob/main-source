using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct PFMatchmakingTicketCompletedStateChange
	{
		[FieldOffset(0)]
		public PFMatchmakingStateChange __AnonymousBase_1;

		[FieldOffset(4)]
		public int result;

		[FieldOffset(8)]
		public unsafe PFMatchmakingTicket* ticket;

		[FieldOffset(16)]
		public unsafe void* asyncContext;
	}
}

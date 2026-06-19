using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingTicketHandle
	{
		internal unsafe IntPtr InteropHandleIntPtr => (IntPtr)InteropHandle;

		internal unsafe PFMatchmakingTicket* InteropHandle { get; set; }

		internal unsafe PFMatchmakingTicketHandle(PFMatchmakingTicket* interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal unsafe static int WrapAndReturnError(int error, PFMatchmakingTicket* interopHandle, out PFMatchmakingTicketHandle handle)
		{
			if (LobbyError.SUCCEEDED(error))
			{
				handle = new PFMatchmakingTicketHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return error;
		}
	}
}

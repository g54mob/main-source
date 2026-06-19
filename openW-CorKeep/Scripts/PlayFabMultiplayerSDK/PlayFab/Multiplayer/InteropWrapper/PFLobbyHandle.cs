using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyHandle
	{
		internal unsafe IntPtr InteropHandleIntPtr => (IntPtr)InteropHandle;

		internal unsafe PFLobby* InteropHandle { get; set; }

		internal unsafe PFLobbyHandle(PFLobby* interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal unsafe static int WrapAndReturnError(int error, PFLobby* interopHandle, out PFLobbyHandle handle)
		{
			if (LobbyError.SUCCEEDED(error))
			{
				handle = new PFLobbyHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return error;
		}
	}
}

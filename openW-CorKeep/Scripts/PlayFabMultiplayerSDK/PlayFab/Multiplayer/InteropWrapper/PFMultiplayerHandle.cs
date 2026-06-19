using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMultiplayerHandle
	{
		internal unsafe PlayFab.Multiplayer.Interop.PFMultiplayer* InteropHandle { get; set; }

		internal unsafe PFMultiplayerHandle(PlayFab.Multiplayer.Interop.PFMultiplayer* interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal unsafe static int WrapAndReturnError(int error, PlayFab.Multiplayer.Interop.PFMultiplayer* interopHandle, out PFMultiplayerHandle handle)
		{
			if (LobbyError.SUCCEEDED(error))
			{
				handle = new PFMultiplayerHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return error;
		}
	}
}

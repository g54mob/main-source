using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(513)]
	public struct LobbyCreated_t
	{
		public const int k_iCallback = 513;

		public EResult m_eResult;

		public ulong m_ulSteamIDLobby;
	}
}

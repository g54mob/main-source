using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 1, Size = 18)]
	[CallbackIdentity(340)]
	public struct GameConnectedChatLeave_t
	{
		public const int k_iCallback = 340;

		public CSteamID m_steamIDClanChat;

		public CSteamID m_steamIDUser;

		public bool m_bKicked;

		public bool m_bDropped;
	}
}

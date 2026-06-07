using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 20)]
	[CallbackIdentity(338)]
	public struct GameConnectedClanChatMsg_t
	{
		public const int k_iCallback = 338;

		public CSteamID m_steamIDClanChat;

		public CSteamID m_steamIDUser;

		public int m_iMessageID;
	}
}

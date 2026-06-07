using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	[CallbackIdentity(1108)]
	public struct UserStatsUnloaded_t
	{
		public const int k_iCallback = 1108;

		public CSteamID m_steamIDUser;
	}
}

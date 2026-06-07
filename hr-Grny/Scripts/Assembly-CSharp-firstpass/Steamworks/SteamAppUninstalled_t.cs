using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(3902)]
	public struct SteamAppUninstalled_t
	{
		public const int k_iCallback = 3902;

		public AppId_t m_nAppID;
	}
}

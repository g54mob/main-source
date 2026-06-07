using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(3901)]
	public struct SteamAppInstalled_t
	{
		public const int k_iCallback = 3901;

		public AppId_t m_nAppID;
	}
}

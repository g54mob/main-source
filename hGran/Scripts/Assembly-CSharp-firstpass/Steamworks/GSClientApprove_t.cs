using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(201)]
	public struct GSClientApprove_t
	{
		public const int k_iCallback = 201;

		public CSteamID m_SteamID;

		public CSteamID m_OwnerSteamID;
	}
}

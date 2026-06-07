using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 128)]
	[CallbackIdentity(332)]
	public struct GameServerChangeRequested_t
	{
		public const int k_iCallback = 332;

		public string m_rgchServer;

		public string m_rgchPassword;
	}
}

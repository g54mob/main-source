using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 1)]
	public struct SteamShutdown_t
	{
		public const int k_iCallback = 704;
	}
}

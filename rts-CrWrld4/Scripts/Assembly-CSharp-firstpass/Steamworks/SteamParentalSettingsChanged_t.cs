using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SteamParentalSettingsChanged_t
	{
		public const int k_iCallback = 5001;
	}
}

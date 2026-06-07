using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 1)]
	[CallbackIdentity(702)]
	public struct LowBatteryPower_t
	{
		public const int k_iCallback = 702;

		public byte m_nMinutesBatteryLeft;
	}
}

using System.Runtime.InteropServices;

namespace Kongregate
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ItemInstanceType
	{
		internal uint UserId;

		internal ulong Id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal byte[] Identifier;

		[MarshalAs(UnmanagedType.I1)]
		internal bool Consumable;
	}
}

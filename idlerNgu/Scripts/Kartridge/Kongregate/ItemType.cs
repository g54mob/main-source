using System.Runtime.InteropServices;

namespace Kongregate
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ItemType
	{
		internal ulong Id;

		internal uint Price;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal byte[] Identifier;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal byte[] Name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal byte[] Description;
	}
}

using System.Runtime.InteropServices;

namespace Utf8Json.Internal.DoubleConversion
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 8)]
	internal struct UnionDoubleULong
	{
		[FieldOffset(0)]
		public double d;

		[FieldOffset(0)]
		public ulong u64;
	}
}

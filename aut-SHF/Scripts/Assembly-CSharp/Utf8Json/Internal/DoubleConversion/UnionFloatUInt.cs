using System.Runtime.InteropServices;

namespace Utf8Json.Internal.DoubleConversion
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 4)]
	internal struct UnionFloatUInt
	{
		[FieldOffset(0)]
		public float f;

		[FieldOffset(0)]
		public uint u32;
	}
}

using System.Runtime.InteropServices;

namespace MLAPI.Serialization
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct UIntFloat
	{
		[FieldOffset(0)]
		public float floatValue;

		[FieldOffset(0)]
		public uint uintValue;

		[FieldOffset(0)]
		public double doubleValue;

		[FieldOffset(0)]
		public ulong ulongValue;
	}
}

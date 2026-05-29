using System.Runtime.InteropServices;

namespace FishNet.Serializing.Helping
{
	[StructLayout((LayoutKind)2)]
	internal struct UIntDouble
	{
		[FieldOffset(0)]
		public double DoubleValue;

		[FieldOffset(0)]
		public ulong LongValue;
	}
}

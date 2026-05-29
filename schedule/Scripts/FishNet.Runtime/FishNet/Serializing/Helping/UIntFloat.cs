using System.Runtime.InteropServices;

namespace FishNet.Serializing.Helping
{
	[StructLayout((LayoutKind)2)]
	internal struct UIntFloat
	{
		[FieldOffset(0)]
		public float FloatValue;

		[FieldOffset(0)]
		public uint UIntValue;
	}
}

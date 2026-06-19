using System.Runtime.InteropServices;
using FullSerializerSave;

namespace TH20
{
	[StructLayout(LayoutKind.Explicit)]
	[fsObject(Converter = typeof(UnionByteFloatArrayConverter))]
	public struct UnionByteFloatArray
	{
		[FieldOffset(0)]
		public byte[] Bytes;

		[FieldOffset(0)]
		public float[] Floats;
	}
}

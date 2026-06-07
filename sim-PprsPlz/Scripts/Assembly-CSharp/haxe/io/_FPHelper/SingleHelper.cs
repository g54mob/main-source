using System.Runtime.InteropServices;

namespace haxe.io._FPHelper
{
	[StructLayout((LayoutKind)2)]
	public struct SingleHelper
	{
		[FieldOffset(0)]
		public int i;

		[FieldOffset(0)]
		public float f;

		public SingleHelper(float f)
		{
			i = 0;
			this.f = 0f;
		}
	}
}

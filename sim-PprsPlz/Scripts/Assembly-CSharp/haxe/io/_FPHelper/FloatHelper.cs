using System.Runtime.InteropServices;

namespace haxe.io._FPHelper
{
	[StructLayout((LayoutKind)2)]
	public struct FloatHelper
	{
		[FieldOffset(0)]
		public long i;

		[FieldOffset(0)]
		public double f;

		public FloatHelper(double f)
		{
			i = 0L;
			this.f = 0.0;
		}
	}
}

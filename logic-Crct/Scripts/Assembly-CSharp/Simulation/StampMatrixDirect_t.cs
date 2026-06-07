using System.Runtime.InteropServices;

namespace Simulation
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 16)]
	public struct StampMatrixDirect_t
	{
		[FieldOffset(0)]
		public int i;

		[FieldOffset(4)]
		public bool constant;

		[FieldOffset(8)]
		public double ri_val;
	}
}

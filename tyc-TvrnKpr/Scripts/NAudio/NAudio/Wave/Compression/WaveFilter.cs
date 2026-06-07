using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	[StructLayout((LayoutKind)0)]
	public class WaveFilter
	{
		public int StructureSize;

		public int FilterTag;

		public int Filter;

		public int[] Reserved;
	}
}

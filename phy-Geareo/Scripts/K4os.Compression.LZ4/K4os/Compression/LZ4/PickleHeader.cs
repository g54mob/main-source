using System.Runtime.InteropServices;

namespace K4os.Compression.LZ4
{
	[StructLayout((LayoutKind)0, Pack = 1, Size = 8)]
	internal readonly struct PickleHeader
	{
		public ushort DataOffset { get; }

		public ushort Flags { get; }

		public int ResultLength { get; }

		public bool IsCompressed => false;

		public PickleHeader(ushort dataOffset, int resultLength, bool compressed)
		{
			DataOffset = 0;
			Flags = 0;
			ResultLength = 0;
		}
	}
}

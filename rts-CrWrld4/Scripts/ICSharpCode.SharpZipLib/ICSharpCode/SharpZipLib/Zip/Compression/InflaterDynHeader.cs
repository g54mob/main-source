using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	internal class InflaterDynHeader
	{
		private static readonly int[] repMin;

		private static readonly int[] repBits;

		private static readonly int[] BL_ORDER;

		private byte[] blLens;

		private byte[] litdistLens;

		private InflaterHuffmanTree blTree;

		private int mode;

		private int lnum;

		private int dnum;

		private int blnum;

		private int num;

		private int repSymbol;

		private byte lastLen;

		private int ptr;

		public bool Decode(StreamManipulator input)
		{
			return false;
		}

		public InflaterHuffmanTree BuildLitLenTree()
		{
			return null;
		}

		public InflaterHuffmanTree BuildDistTree()
		{
			return null;
		}
	}
}

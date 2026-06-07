using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class InflaterHuffmanTree
	{
		private const int MAX_BITLEN = 15;

		private short[] tree;

		public static InflaterHuffmanTree defLitLenTree;

		public static InflaterHuffmanTree defDistTree;

		static InflaterHuffmanTree()
		{
		}

		public InflaterHuffmanTree(byte[] codeLengths)
		{
		}

		private void BuildTree(byte[] codeLengths)
		{
		}

		public int GetSymbol(StreamManipulator input)
		{
			return 0;
		}
	}
}

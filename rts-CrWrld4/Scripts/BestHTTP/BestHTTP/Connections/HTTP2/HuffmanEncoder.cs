namespace BestHTTP.Connections.HTTP2
{
	internal static class HuffmanEncoder
	{
		public struct TableEntry
		{
			public uint Code;

			public byte Bits;

			public byte GetBitAtIdx(byte idx)
			{
				return 0;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public struct TreeNode
		{
			public ushort NextZeroIdx;

			public ushort NextOneIdx;

			public ushort Value;

			public override string ToString()
			{
				return null;
			}
		}

		public const ushort EOS = 256;

		private static TableEntry[] StaticTable;

		private static TreeNode[] HuffmanTree;

		public static TreeNode GetRoot()
		{
			return default(TreeNode);
		}

		public static TreeNode GetNext(TreeNode current, byte bit)
		{
			return default(TreeNode);
		}

		public static TableEntry GetEntryForCodePoint(ushort codePoint)
		{
			return default(TableEntry);
		}
	}
}

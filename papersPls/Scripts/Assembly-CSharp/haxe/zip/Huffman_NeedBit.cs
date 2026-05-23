namespace haxe.zip
{
	public sealed class Huffman_NeedBit : Huffman
	{
		public readonly Huffman left;

		public readonly Huffman right;

		public Huffman_NeedBit(Huffman left, Huffman right)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}

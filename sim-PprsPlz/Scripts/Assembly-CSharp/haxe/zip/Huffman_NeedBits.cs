namespace haxe.zip
{
	public sealed class Huffman_NeedBits : Huffman
	{
		public readonly int n;

		public readonly Array table;

		public Huffman_NeedBits(int n, Array table)
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

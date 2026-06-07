using haxe.io;

namespace format.png
{
	public sealed class Chunk_CPalette : Chunk
	{
		public readonly Bytes b;

		public Chunk_CPalette(Bytes b)
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

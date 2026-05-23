using haxe.io;

namespace format.png
{
	public sealed class Chunk_CUnknown : Chunk
	{
		public readonly string id;

		public readonly Bytes data;

		public Chunk_CUnknown(string id, Bytes data)
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

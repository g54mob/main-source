using haxe.io;

namespace app.vis
{
	public sealed class Alloc_EXISTING : Alloc
	{
		public readonly Bytes bytes;

		public Alloc_EXISTING(Bytes bytes)
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

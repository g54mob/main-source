namespace haxe
{
	public sealed class StackItem_FilePos : StackItem
	{
		public readonly StackItem s;

		public readonly string file;

		public readonly int line;

		public readonly object column;

		public StackItem_FilePos(StackItem s, string file, int line, object column)
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

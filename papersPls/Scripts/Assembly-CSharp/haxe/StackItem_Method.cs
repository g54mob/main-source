namespace haxe
{
	public sealed class StackItem_Method : StackItem
	{
		public readonly string classname;

		public readonly string method;

		public StackItem_Method(string classname, string method)
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

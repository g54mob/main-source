namespace data
{
	public sealed class Op_SETFACT : Op
	{
		public readonly string factPath;

		public readonly string value;

		public Op_SETFACT(string factPath, string value)
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

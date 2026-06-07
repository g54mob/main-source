namespace test.auto
{
	public sealed class AuditKind_PAPERINNERIMAGE : AuditKind
	{
		public readonly EReg paperIdEReg;

		public AuditKind_PAPERINNERIMAGE(EReg paperIdEReg)
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

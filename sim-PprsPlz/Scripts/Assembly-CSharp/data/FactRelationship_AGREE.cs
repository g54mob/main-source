namespace data
{
	public sealed class FactRelationship_AGREE : FactRelationship
	{
		public readonly bool clearedConfusion;

		public FactRelationship_AGREE(bool clearedConfusion)
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

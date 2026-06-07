namespace data
{
	public sealed class Reveal_ONDESK : Reveal
	{
		public readonly int deskX;

		public readonly int deskY;

		public Reveal_ONDESK(int deskX, int deskY)
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

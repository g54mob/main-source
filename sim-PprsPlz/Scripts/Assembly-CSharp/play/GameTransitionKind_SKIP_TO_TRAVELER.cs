namespace play
{
	public sealed class GameTransitionKind_SKIP_TO_TRAVELER : GameTransitionKind
	{
		public readonly string travelerId;

		public readonly int forceDayId;

		public GameTransitionKind_SKIP_TO_TRAVELER(string travelerId, int forceDayId)
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

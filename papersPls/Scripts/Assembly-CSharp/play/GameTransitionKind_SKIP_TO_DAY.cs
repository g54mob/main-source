namespace play
{
	public sealed class GameTransitionKind_SKIP_TO_DAY : GameTransitionKind
	{
		public readonly int dayId;

		public GameTransitionKind_SKIP_TO_DAY(int dayId)
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

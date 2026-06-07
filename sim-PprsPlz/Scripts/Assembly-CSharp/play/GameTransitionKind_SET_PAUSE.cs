namespace play
{
	public sealed class GameTransitionKind_SET_PAUSE : GameTransitionKind
	{
		public readonly bool pause;

		public GameTransitionKind_SET_PAUSE(bool pause)
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

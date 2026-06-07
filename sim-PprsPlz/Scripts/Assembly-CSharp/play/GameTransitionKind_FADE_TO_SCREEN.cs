namespace play
{
	public sealed class GameTransitionKind_FADE_TO_SCREEN : GameTransitionKind
	{
		public readonly string name;

		public readonly bool instant;

		public GameTransitionKind_FADE_TO_SCREEN(string name, bool instant)
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

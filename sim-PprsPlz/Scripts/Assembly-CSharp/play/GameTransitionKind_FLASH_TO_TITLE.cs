namespace play
{
	public sealed class GameTransitionKind_FLASH_TO_TITLE : GameTransitionKind
	{
		public readonly double duration;

		public GameTransitionKind_FLASH_TO_TITLE(double duration)
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

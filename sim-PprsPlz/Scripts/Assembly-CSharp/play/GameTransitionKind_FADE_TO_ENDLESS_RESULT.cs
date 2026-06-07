using play.day;

namespace play
{
	public sealed class GameTransitionKind_FADE_TO_ENDLESS_RESULT : GameTransitionKind
	{
		public readonly EndlessResult endlessResult;

		public GameTransitionKind_FADE_TO_ENDLESS_RESULT(EndlessResult endlessResult)
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

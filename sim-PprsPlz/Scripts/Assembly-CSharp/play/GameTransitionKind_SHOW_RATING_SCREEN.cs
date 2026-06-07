using haxe.lang;

namespace play
{
	public sealed class GameTransitionKind_SHOW_RATING_SCREEN : GameTransitionKind
	{
		public readonly Function doneFunc;

		public GameTransitionKind_SHOW_RATING_SCREEN(Function doneFunc)
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

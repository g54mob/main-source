using play.save;

namespace play
{
	public sealed class GameTransitionKind_LOAD_TO_SCREEN : GameTransitionKind
	{
		public readonly SaveHeader saveHeader;

		public readonly string screenName;

		public GameTransitionKind_LOAD_TO_SCREEN(SaveHeader saveHeader, string screenName)
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

using app.plat;

namespace play
{
	public sealed class GameTransitionKind_REQUEST_PLATFORM_CHANGE : GameTransitionKind
	{
		public readonly PlatformKind newPlatformKind;

		public GameTransitionKind_REQUEST_PLATFORM_CHANGE(PlatformKind newPlatformKind)
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

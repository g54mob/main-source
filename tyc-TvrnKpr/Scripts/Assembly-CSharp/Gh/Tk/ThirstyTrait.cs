namespace Gh.Tk
{
	public class ThirstyTrait : ActorTrait
	{
		protected ThirstyTrait()
		{
		}

		public ThirstyTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

namespace Gh.Tk
{
	public class DarkVisionTrait : ActorTrait
	{
		protected DarkVisionTrait()
		{
		}

		public DarkVisionTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

namespace Gh.Tk
{
	public class HalflingTrait : RaceTrait
	{
		protected HalflingTrait()
		{
		}

		public HalflingTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

namespace Gh.Tk
{
	public class OrcTrait : RaceTrait
	{
		protected OrcTrait()
		{
		}

		public OrcTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

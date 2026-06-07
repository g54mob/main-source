namespace Gh.Tk
{
	public class HumanTrait : RaceTrait
	{
		protected HumanTrait()
		{
		}

		public HumanTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

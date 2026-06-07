namespace Gh.Tk
{
	public class DwarfTrait : RaceTrait
	{
		protected DwarfTrait()
		{
		}

		public DwarfTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

namespace Gh.Tk
{
	public class ElfTrait : RaceTrait
	{
		protected ElfTrait()
		{
		}

		public ElfTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

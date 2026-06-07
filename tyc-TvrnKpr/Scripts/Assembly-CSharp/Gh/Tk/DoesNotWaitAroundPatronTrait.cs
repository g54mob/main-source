namespace Gh.Tk
{
	[TraitRarityConfig(0.15f, null)]
	[TraitRarityConfig(0.3f, "elf")]
	[TraitRarityConfig(0.03f, "orc")]
	public class DoesNotWaitAroundPatronTrait : PatronTrait
	{
		protected DoesNotWaitAroundPatronTrait()
		{
		}

		public DoesNotWaitAroundPatronTrait(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

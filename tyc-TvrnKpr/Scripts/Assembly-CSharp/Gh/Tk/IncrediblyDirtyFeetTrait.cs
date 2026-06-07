namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitRarityConfig(0.01f, "halfling")]
	[TraitRarityConfig(0.05f, "orc")]
	[TraitRarityConfig(0f, "elf")]
	public class IncrediblyDirtyFeetTrait : PatronTrait
	{
		protected IncrediblyDirtyFeetTrait()
		{
		}

		public IncrediblyDirtyFeetTrait(Patron owner)
		{
		}
	}
}

namespace Gh.Tk
{
	[TraitRarityConfig(0.03f, null)]
	[TraitRarityConfig(0.01f, "halfling")]
	[TraitRarityConfig(0.05f, "orc")]
	[TraitRarityConfig(0.05f, "elf")]
	public class DogsbodyNotAffectedByItemWeightTrait : DogsbodyTraitBase
	{
		protected DogsbodyNotAffectedByItemWeightTrait()
		{
		}

		public DogsbodyNotAffectedByItemWeightTrait(Staff owner)
		{
		}
	}
}

using System;

namespace Gh.Tk
{
	[TraitNotValidWith(new Type[] { typeof(ComedianTrait) })]
	[TraitNotValidWith(new Type[] { typeof(HagglerTrait) })]
	[TraitRarityConfig(0.05f, null)]
	[TraitRarityConfig(0.15f, "orc")]
	[TraitRarityConfig(0.01f, "elf")]
	[TraitRarityConfig(0.01f, "halfling")]
	[TraitStaffTierRestriction(2, 3)]
	public class MultiOrderServerTrait : ServerTraitBase
	{
		protected MultiOrderServerTrait()
		{
		}

		public MultiOrderServerTrait(Staff owner)
		{
		}
	}
}

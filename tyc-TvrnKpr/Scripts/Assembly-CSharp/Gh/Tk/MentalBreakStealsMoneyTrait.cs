using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.3f, "dwarf")]
	[TraitRarityConfig(0.8f, "human")]
	[TraitRarityConfig(0.03f, "orc")]
	[TraitRarityConfig(0.01f, "elf")]
	[TraitRarityConfig(0.05f, null)]
	[TraitNotValidWith(new Type[] { typeof(CannotBeBribedTrait) })]
	public class MentalBreakStealsMoneyTrait : MentalBreakTraitBase
	{
		protected MentalBreakStealsMoneyTrait()
		{
		}

		public MentalBreakStealsMoneyTrait(Staff owner)
		{
		}

		protected override void TriggerInternal()
		{
		}
	}
}

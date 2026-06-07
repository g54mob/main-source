using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, "orc")]
	[TraitRarityConfig(0f, "elf")]
	[TraitRarityConfig(0f, null)]
	[TraitNotValidWith(new Type[] { typeof(EasilyBoredTrait) })]
	public class NaturallyContentTrait : StaffTrait
	{
		protected NaturallyContentTrait()
		{
		}

		public NaturallyContentTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}
	}
}

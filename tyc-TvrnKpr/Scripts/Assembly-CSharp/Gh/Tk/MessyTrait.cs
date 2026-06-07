using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.05f, "orc")]
	[TraitRarityConfig(0.05f, "halfling")]
	[TraitRarityConfig(0.005f, "elf")]
	[TraitRarityConfig(0.03f, null)]
	[TraitNotValidWith(new Type[] { typeof(DirtDodgerTrait) })]
	public class MessyTrait : StaffTrait
	{
		protected MessyTrait()
		{
		}

		public MessyTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}
	}
}

using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(MentalBreakStealsMoneyTrait),
		typeof(EasilyBribedTrait)
	})]
	public class CannotBeBribedTrait : StaffTrait
	{
		protected CannotBeBribedTrait()
		{
		}

		public CannotBeBribedTrait(Staff owner)
		{
		}
	}
}

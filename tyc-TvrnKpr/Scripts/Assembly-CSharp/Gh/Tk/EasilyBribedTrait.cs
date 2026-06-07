using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[] { typeof(CannotBeBribedTrait) })]
	public class EasilyBribedTrait : StaffTrait
	{
		protected EasilyBribedTrait()
		{
		}

		public EasilyBribedTrait(Staff owner)
		{
		}
	}
}

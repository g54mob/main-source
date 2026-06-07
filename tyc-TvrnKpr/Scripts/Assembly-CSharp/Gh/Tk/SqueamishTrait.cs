using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.05f, null)]
	[TraitNotValidWith(new Type[] { typeof(IronWillTrait) })]
	public class SqueamishTrait : StaffTrait
	{
		protected SqueamishTrait()
		{
		}

		public SqueamishTrait(Staff owner)
		{
		}
	}
}

using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.05f, null)]
	[TraitNotValidWith(new Type[] { typeof(FastWorkerTrait) })]
	public class SlowpokeTrait : StaffSpeedTrait
	{
		private static float _slowPokeWorkSpeedModifier;

		private static float _slowPokeMoveSpeedModifier;

		protected SlowpokeTrait()
			: base(0f, 0f)
		{
		}

		public SlowpokeTrait(Staff owner)
			: base(0f, 0f)
		{
		}
	}
}

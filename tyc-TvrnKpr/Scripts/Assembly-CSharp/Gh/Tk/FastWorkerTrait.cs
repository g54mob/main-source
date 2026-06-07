using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.03f, null)]
	[TraitNotValidWith(new Type[] { typeof(SlowpokeTrait) })]
	public class FastWorkerTrait : StaffSpeedTrait
	{
		private static float _fastWorkerWorkSpeedModifier;

		private static float _fastWorkerMoveSpeedModifier;

		protected FastWorkerTrait()
			: base(0f, 0f)
		{
		}

		public FastWorkerTrait(Staff owner)
			: base(0f, 0f)
		{
		}
	}
}

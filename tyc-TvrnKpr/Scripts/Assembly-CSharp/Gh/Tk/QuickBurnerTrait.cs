using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.03f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(UndeadTrait),
		typeof(FastWorkerTrait)
	})]
	public class QuickBurnerTrait : StaffTrait
	{
		private ActorStat _energyStat;

		protected QuickBurnerTrait()
		{
		}

		public QuickBurnerTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}
	}
}

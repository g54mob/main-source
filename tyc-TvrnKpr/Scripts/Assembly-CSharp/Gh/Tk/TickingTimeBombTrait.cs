using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitNotValidWith(new Type[] { typeof(IronWillTrait) })]
	public class TickingTimeBombTrait : StaffTrait
	{
		[PersistenceOptIn]
		private float _secondsUntilNextCheck;

		protected TickingTimeBombTrait()
		{
		}

		public TickingTimeBombTrait(Staff owner)
		{
		}

		public override void Update()
		{
		}
	}
}

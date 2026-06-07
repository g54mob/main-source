using System;

namespace Gh.Tk
{
	public class BreakAfterAmountOfUses : AttachedBehaviour, IPersistable
	{
		[PersistenceOptIn]
		public BreakUsageAmount usagesAmountBeforeBreaking;

		[PersistenceOptIn]
		public float damagePerUse;

		public override void Start()
		{
		}

		private void RecalculateDamagePerUse()
		{
		}

		private void OnPropUsed(object sender, EventArgs e)
		{
		}

		protected int GetUsesUntilBreaking()
		{
			return 0;
		}
	}
}

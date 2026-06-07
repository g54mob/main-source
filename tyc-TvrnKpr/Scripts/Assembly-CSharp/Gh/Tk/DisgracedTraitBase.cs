namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitStaffTierRestriction(2, 3)]
	public abstract class DisgracedTraitBase : SkillTraitBase
	{
		[PersistenceOptIn]
		private int _eventId;

		protected DisgracedTraitBase()
		{
		}

		public DisgracedTraitBase(Staff owner)
		{
		}

		protected abstract string GetReputationCategory();

		public override void OnHired()
		{
		}

		public override void OnFired()
		{
		}
	}
}

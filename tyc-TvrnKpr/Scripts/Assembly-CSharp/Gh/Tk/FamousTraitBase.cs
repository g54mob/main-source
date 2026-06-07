namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitStaffTierRestriction(2, 3)]
	public abstract class FamousTraitBase : SkillTraitBase
	{
		[PersistenceOptIn]
		private int _eventId;

		protected FamousTraitBase()
		{
		}

		public FamousTraitBase(Staff owner)
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

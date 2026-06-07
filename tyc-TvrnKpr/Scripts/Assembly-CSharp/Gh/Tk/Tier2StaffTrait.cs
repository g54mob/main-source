namespace Gh.Tk
{
	public class Tier2StaffTrait : TierTraitBase
	{
		protected Tier2StaffTrait()
		{
		}

		public Tier2StaffTrait(Staff owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

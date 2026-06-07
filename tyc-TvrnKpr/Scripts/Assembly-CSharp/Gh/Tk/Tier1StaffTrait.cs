namespace Gh.Tk
{
	public class Tier1StaffTrait : TierTraitBase
	{
		protected Tier1StaffTrait()
		{
		}

		public Tier1StaffTrait(Staff owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

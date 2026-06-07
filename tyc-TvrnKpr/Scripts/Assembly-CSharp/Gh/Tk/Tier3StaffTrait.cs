namespace Gh.Tk
{
	public class Tier3StaffTrait : TierTraitBase
	{
		protected Tier3StaffTrait()
		{
		}

		public Tier3StaffTrait(Staff owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}

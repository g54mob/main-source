namespace Gh.Tk
{
	[TraitRarityConfig(0.8f, null)]
	[TraitStaffTierRestriction(2, 3)]
	public class CleansToAPolishJanitorTrait : JanitorTraitBase
	{
		protected CleansToAPolishJanitorTrait()
		{
		}

		public CleansToAPolishJanitorTrait(Staff owner)
		{
		}

		public override void OnPropCleaned(Prop prop)
		{
		}
	}
}

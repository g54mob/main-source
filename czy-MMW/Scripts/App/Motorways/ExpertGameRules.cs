namespace Motorways
{
	public class ExpertGameRules : GameRules
	{
		public override bool CanBuildingsDemolishUnusedRoads
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.ExpertNoDemolish))
				{
					return false;
				}
				return true;
			}
		}

		public override bool RoadsBecomePermanentOverTime => true;

		public override int GetNumberOfUpgradeOptionsPerWeek()
		{
			return 9;
		}
	}
}

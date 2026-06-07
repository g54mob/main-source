using NodeCanvas.Framework;

namespace Campaign
{
	public class CheckCampaignVariableBool : ConditionTask
	{
		public GameplayVariable variable;

		public bool value;

		public Comparison comparison;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}

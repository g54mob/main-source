using NodeCanvas.Framework;

namespace Campaign
{
	public class CheckCampaignVariableString : ConditionTask
	{
		public GameplayVariable variable;

		public string value;

		public Comparison comparison;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		protected bool isEmpty()
		{
			return false;
		}
	}
}

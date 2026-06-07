using NodeCanvas.Framework;

namespace Campaign
{
	public class CheckCampaignVariableFloat : ConditionTask
	{
		public GameplayVariable variable;

		public float value;

		public Comparison comparison;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		protected bool LessThan()
		{
			return false;
		}

		protected bool GreaterThan()
		{
			return false;
		}

		protected bool LessOrEqual()
		{
			return false;
		}

		protected bool GreaterOrEqual()
		{
			return false;
		}
	}
}

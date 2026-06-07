using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "WindowCleanlinessBarRule", menuName = "Brewery/Bar Rules/Window Cleanliness Rule")]
	public class WindowCleanlinessBarRule : BarRuleBase
	{
		private static readonly string[] DirtyWindowKeys;

		private const string FailDirty = "DIRTY";

		public override RuleStatus Evaluate(BarRuleContext context)
		{
			return default(RuleStatus);
		}

		public override string GetComplaintMessage(RuleStatus status)
		{
			return null;
		}

		public override string GetStatusMessage(RuleStatus status)
		{
			return null;
		}
	}
}

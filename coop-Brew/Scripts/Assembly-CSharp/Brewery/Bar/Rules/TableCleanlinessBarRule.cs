using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "TableCleanlinessBarRule", menuName = "Brewery/Bar Rules/Table Cleanliness Rule")]
	public class TableCleanlinessBarRule : BarRuleBase
	{
		private static readonly string[] DirtyTableKeys;

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

namespace Brewery.Bar.Rules
{
	public interface IBarRule
	{
		string RuleName { get; }

		float Weight { get; }

		RuleStatus Evaluate(BarRuleContext context);

		string GetComplaintMessage(RuleStatus status);
	}
}

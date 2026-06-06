namespace Brewery.Bar.Rules
{
	public struct RuleStatus
	{
		public bool IsSatisfied;

		public float SatisfactionLevel;

		public string FailureReason;

		public bool IsApplicable;

		public string NotApplicableReason;

		public static RuleStatus Satisfied()
		{
			return default(RuleStatus);
		}

		public static RuleStatus Failed(string reason)
		{
			return default(RuleStatus);
		}

		public static RuleStatus Partial(float level, string reason = null)
		{
			return default(RuleStatus);
		}

		public static RuleStatus NotApplicable(string reason)
		{
			return default(RuleStatus);
		}
	}
}

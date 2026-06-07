using System;

namespace Brewery.Bar
{
	[Serializable]
	public struct RuleStatusInfo
	{
		public string RuleName;

		public bool IsSatisfied;

		public float SatisfactionLevel;

		public string StatusMessage;

		public string ComplaintMessage;

		public bool IsApplicable;

		public string NotApplicableReason;
	}
}

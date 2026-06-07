namespace Brewery.Utils
{
	public struct MultiStepSummary
	{
		public TimerBreakdown[] stepBreakdowns;

		public string[] stepNames;

		public float totalBaseDuration;

		public float totalEffectiveDuration;

		public float totalSkillSavings;

		public float totalBuffSavings;

		public float TotalSavings => 0f;
	}
}

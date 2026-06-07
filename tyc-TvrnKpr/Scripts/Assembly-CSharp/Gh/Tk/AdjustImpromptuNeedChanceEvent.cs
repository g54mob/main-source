namespace Gh.Tk
{
	public class AdjustImpromptuNeedChanceEvent : SimpleTimelineEvent
	{
		public bool ForcePercentage { get; set; }

		public string NeedType { get; set; }

		public float Percentage { get; set; }

		protected AdjustImpromptuNeedChanceEvent()
		{
		}

		public AdjustImpromptuNeedChanceEvent(string needType, int percentage, float durationInDaysF, string timelineTitleKey = null, string timelineIcon = null)
		{
		}

		public static float AdjustChance(float chance, string needType)
		{
			return 0f;
		}
	}
}

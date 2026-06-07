namespace Gh.Tk.Story.GameModifiers
{
	public class SuspendRandomGroupRequestsModifierNode : TemporaryGameModifierNode
	{
		public bool deleteExistingRequestsInTimeFrame;

		private float GetRemainingDurationInDaysF(ActiveStory story)
		{
			return 0f;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public static bool IsSuspended(int hoursFromNow)
		{
			return false;
		}
	}
}

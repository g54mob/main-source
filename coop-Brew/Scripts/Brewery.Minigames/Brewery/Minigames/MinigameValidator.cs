namespace Brewery.Minigames
{
	public static class MinigameValidator
	{
		public static bool ValidateSubmission(MinigameSubmission sub, MinigameSessionData session, int currentStepIndex, double currentServerTime, double lastSubmissionTime, MinigameConfig config, out string rejectReason)
		{
			rejectReason = null;
			return false;
		}
	}
}

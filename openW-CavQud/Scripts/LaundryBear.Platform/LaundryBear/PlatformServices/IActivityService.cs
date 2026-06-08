namespace LaundryBear.PlatformServices
{
	public interface IActivityService
	{
		event ActivityRequestEventHandler ActivityRequestEvent;

		void StartActivity(IUser user, string activityID);

		void EndActivity(IUser user, string activityID, ActivityEndType endType);

		void ResumeActivity(IUser user, string activityID);

		void ResumeActivity(IUser user, string activityID, string[] subactivitiesInProgress, string[] subactivitiesCompleted);

		void TerminateActivity(IUser user, string activityID);

		void UpdateActivityAvailability(IUser user, string[] activityID, ActivityAvailability availability);
	}
}

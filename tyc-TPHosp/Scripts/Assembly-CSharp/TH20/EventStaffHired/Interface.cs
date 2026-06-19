namespace TH20.EventStaffHired
{
	public interface Interface : IGameEventCallback
	{
		void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee);
	}
}

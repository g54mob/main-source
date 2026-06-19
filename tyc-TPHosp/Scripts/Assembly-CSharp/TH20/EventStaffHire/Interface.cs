namespace TH20.EventStaffHire
{
	public interface Interface : IGameEventCallback
	{
		void OnStaffHireEvent(JobApplicant applicant);
	}
}

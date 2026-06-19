namespace TH20.EventStaffHire
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(JobApplicant applicant)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnStaffHireEvent(applicant);
			});
		}
	}
}

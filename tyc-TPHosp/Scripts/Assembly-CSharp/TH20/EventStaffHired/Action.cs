namespace TH20.EventStaffHired
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(Staff staff, JobApplicant applicant, int fee)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnStaffHiredEvent(staff, applicant, fee);
			});
		}
	}
}

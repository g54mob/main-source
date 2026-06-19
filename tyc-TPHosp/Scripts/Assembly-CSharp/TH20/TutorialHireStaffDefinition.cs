namespace TH20
{
	public class TutorialHireStaffDefinition : TutorialModeDefinition
	{
		public StaffDefinition.Type StaffType;

		public PingInit HiresPing;

		public PingInit StaffTabPing;

		public PingInit HireButtonPing;

		public bool ShowHubMenuArrow;

		public override TutorialMode Create()
		{
			return new TutorialModeHireStaff(this);
		}
	}
}

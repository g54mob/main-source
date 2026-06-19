namespace TH20
{
	public class NotificationStaff : NotificationGenericDecision
	{
		private readonly Staff _staff;

		public Staff Staff => _staff;

		public NotificationStaff(NotificationMessages.Definition definition, ResponseDelegate responseDelegate, Staff staff)
			: base(definition, responseDelegate, staff.Level)
		{
			_staff = staff;
		}

		public override Character GetCharacter()
		{
			return _staff;
		}
	}
}

using I2.Loc;

namespace TH20
{
	public class StaffResignationSuccessNotificationUI : StaffNotificationUI
	{
		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			Staff staff = ((NotificationStaff)message).Staff;
			SetStaff(staff);
			if (_messageText != null)
			{
				_messageText.text = ScriptLocalization.Notification.StaffResignation_Message_CS.Replace("{[STAFF]}", GameStringUtils.StaffTitle(staff));
			}
		}
	}
}

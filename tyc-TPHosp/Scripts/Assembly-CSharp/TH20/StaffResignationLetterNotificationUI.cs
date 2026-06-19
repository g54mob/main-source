using I2.Loc;

namespace TH20
{
	public class StaffResignationLetterNotificationUI : StaffNotificationUI
	{
		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			Staff staff = ((NotificationStaff)message).Staff;
			SetStaff(staff);
			string text = ScriptLocalization.Notification.StaffHasResigned_CS.Replace("{[STAFF]}", GameStringUtils.StaffTitle(staff));
			text += $"\n\n{GameStringUtils.GetStaffRecordText(staff)}";
			int staffThreatingToLeave = staff.Level.WorkLifeBalanceManager.StaffThreatingToLeave;
			if (staffThreatingToLeave != 0)
			{
				text += "\n\n";
				text += ScriptLocalization.Notification.StaffVeryUnhapppyNote_CS.Replace("{0}", $"{staffThreatingToLeave}");
			}
			if (_messageText != null)
			{
				_messageText.text = text.Replace("\\n", "\n");
			}
		}
	}
}

using System.Collections.Generic;
using I2.Loc;

namespace TH20
{
	public class StaffResignationWarningNotificationUI : StaffNotificationUI
	{
		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			Staff staff = ((NotificationStaff)message).Staff;
			SetStaff(staff);
			StaffThreatingToLeaveComponent component = staff.GetComponent<StaffThreatingToLeaveComponent>();
			List<string> topComplaints = staff.GetComponent<StaffHappinessComponent>().GetTopComplaints(3, showHidden: false);
			string text = string.Empty;
			if (topComplaints.Count != 0)
			{
				foreach (string item in topComplaints)
				{
					text += item;
					text += "\n";
				}
			}
			string text2 = LocalisedString.Replace(ScriptLocalization.Notification.StaffResignationWarning_Message_CS, new SubPair[3]
			{
				new SubPair("{[STAFF]}", GameStringUtils.StaffTitle(staff)),
				new SubPair("{[COMPLAINTS]}", text),
				new SubPair("{[DAYS]}", component.Challenge.Definition.TimeLength)
			});
			int staffThreatingToLeave = level.WorkLifeBalanceManager.StaffThreatingToLeave;
			if (staffThreatingToLeave != 0)
			{
				string text3 = ScriptLocalization.Notification.StaffResignationWarning_MessageNote_CS;
				LocalisationParams.Set("COUNT", staffThreatingToLeave);
				LocalisationParams.Localise(ref text3);
				text2 += "\n\n";
				text2 += text3;
			}
			if (_messageText != null)
			{
				_messageText.text = text2;
			}
		}
	}
}

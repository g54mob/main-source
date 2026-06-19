using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class InboxStaffResignationLetterContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		public void SetupWarning(Level level, NotificationMessage message)
		{
			Staff staff = ((NotificationStaff)message).Staff;
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
			_messageText.text = text2.Replace("\\n", "\n");
		}

		public void SetupSuccess(NotificationMessage message)
		{
			Staff staff = ((NotificationStaff)message).Staff;
			_messageText.text = ScriptLocalization.Notification.StaffResignation_Message_CS.Replace("{[STAFF]}", GameStringUtils.StaffTitle(staff)).Replace("\\n", "\n");
		}

		public void SetupFailed(NotificationMessage message)
		{
			Staff staff = ((NotificationStaff)message).Staff;
			string text = ScriptLocalization.Notification.StaffHasResigned_CS.Replace("{[STAFF]}", GameStringUtils.StaffTitle(staff));
			text += $"\n\n{GameStringUtils.GetStaffRecordText(staff)}";
			int staffThreatingToLeave = staff.Level.WorkLifeBalanceManager.StaffThreatingToLeave;
			if (staffThreatingToLeave != 0)
			{
				text += "\n\n";
				text += ScriptLocalization.Notification.StaffVeryUnhapppyNote_CS.Replace("{0}", $"{staffThreatingToLeave}");
			}
			_messageText.text = text.Replace("\\n", "\n");
		}
	}
}

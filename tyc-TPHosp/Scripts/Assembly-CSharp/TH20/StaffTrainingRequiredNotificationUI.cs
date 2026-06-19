using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class StaffTrainingRequiredNotificationUI : StaffNotificationUI
	{
		[SerializeField]
		private TMP_Text _promotionText;

		[SerializeField]
		private TMP_Text _staffReadyForPromotion;

		[SerializeField]
		private QualificationIcons _qualificationIcons;

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			NotificationStaffTrainingRequired notificationStaffTrainingRequired = (NotificationStaffTrainingRequired)message;
			Staff staff = notificationStaffTrainingRequired.Staff;
			int num = Mathf.Min(staff.Rank + 1, 4);
			StaffRank staffRank = staff.Definition._rank[num];
			string translation = staff.RankDefinition.GetTitleLocalised(staff.Gender).Translation;
			string translation2 = staffRank.GetTitleLocalised(staff.Gender).Translation;
			string benefitsText = StaffRank.GetBenefitsText(staff.RankDefinition, staffRank);
			List<Room> list = new List<Room>();
			SetStaff(staff);
			level.WorldState.GetRoomsOfType(RoomDefinition.Type.Training, includeClosed: true, list);
			if (_messageText != null)
			{
				_messageText.text = notificationStaffTrainingRequired.GetMessageText();
			}
			_promotionText.text = LocalisedString.Replace(ScriptLocalization.Notification.StaffTrainingRequired_Message_CS, new SubPair[3]
			{
				new SubPair("{[RANK]}", translation),
				new SubPair("{[NEXTRANK]}", translation2),
				new SubPair("{[BENEFITS]}", benefitsText)
			});
			if (list.Count == 0)
			{
				_choiceButtons[0].interactable = false;
				_staffReadyForPromotion.text = ScriptLocalization.Notification.StaffTrainingRequired_NoTrainingRoom_CS;
			}
			else
			{
				string text = string.Empty;
				int num2 = level.CharacterManager.GetNumberOfStaffReadyForTraining() - 1;
				if (num2 != 0)
				{
					text = ScriptLocalization.Notification.StaffTrainingRequired_OtherStaff_CS;
					LocalisationParams.Set("COUNT", num2);
					LocalisationParams.Localise(ref text);
				}
				int num3 = 0;
				foreach (Room item in list)
				{
					RoomLogicTrainingRoom component = item.GetComponent<RoomLogicTrainingRoom>();
					if (component != null && component.IsAvailable)
					{
						num3++;
					}
				}
				if (num3 <= 0)
				{
					_choiceButtons[0].interactable = false;
				}
				string arg = LocalisedString.Replace(ScriptLocalization.Notification.StaffTrainingRequired_AvailableRooms_CS, new SubPair[2]
				{
					new SubPair("{[COUNT]}", num3.ToString()),
					new SubPair("{[TOTAL]}", list.Count.ToString())
				});
				_staffReadyForPromotion.text = $"{text}\n{arg}";
			}
			_qualificationIcons.UpdateFrom(staff.Qualifications, staff.MaxQualifications, level.CharacterManager.StaffMembers);
		}
	}
}

using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class InboxStaffTrainingRequiredContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		[SerializeField]
		private TMP_Text _promotionText;

		[SerializeField]
		private TMP_Text _staffReadyForPromotion;

		[SerializeField]
		private QualificationIcons _qualificationIcons;

		public void Setup(NotificationStaffTrainingRequired message, Level level, ButtonAnimator[] choiceButtonAnimators)
		{
			Staff staff = message.Staff;
			int num = staff.Rank + 1;
			if (num >= 5)
			{
				num = 4;
			}
			StaffRank staffRank = staff.Definition._rank[num];
			string translation = staff.RankDefinition.GetTitleLocalised(staff.Gender).Translation;
			string translation2 = staffRank.GetTitleLocalised(staff.Gender).Translation;
			string benefitsText = StaffRank.GetBenefitsText(staff.RankDefinition, staffRank);
			List<Room> list = new List<Room>();
			level.WorldState.GetRoomsOfType(RoomDefinition.Type.Training, includeClosed: true, list);
			_messageText.text = message.GetMessageText().Replace("\\n", "\n");
			_promotionText.text = LocalisedString.Replace(ScriptLocalization.Notification.StaffTrainingRequired_Message_CS, new SubPair[3]
			{
				new SubPair("{[RANK]}", translation),
				new SubPair("{[NEXTRANK]}", translation2),
				new SubPair("{[BENEFITS]}", benefitsText)
			});
			if (list.Count == 0)
			{
				choiceButtonAnimators[0].CurrentState = ButtonAnimator.State.Unselectable;
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
					choiceButtonAnimators[0].CurrentState = ButtonAnimator.State.Unselectable;
				}
				string arg = LocalisedString.Replace(ScriptLocalization.Notification.StaffTrainingRequired_AvailableRooms_CS, new SubPair[2]
				{
					new SubPair("{[COUNT]}", num3.ToString()),
					new SubPair("{[TOTAL]}", list.Count.ToString())
				});
				_staffReadyForPromotion.text = $"{text}\n{arg}";
				if (staff.CurrentMode == Staff.Mode.Trained)
				{
					choiceButtonAnimators[0].CurrentState = ButtonAnimator.State.Unselectable;
				}
			}
			_qualificationIcons.UpdateFrom(staff.Qualifications, staff.MaxQualifications, level.CharacterManager.StaffMembers);
		}
	}
}

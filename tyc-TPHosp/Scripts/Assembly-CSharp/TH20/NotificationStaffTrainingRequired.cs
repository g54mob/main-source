using System;

namespace TH20
{
	public class NotificationStaffTrainingRequired : NotificationStaff
	{
		public NotificationStaffTrainingRequired(NotificationMessages.Definition definition, Staff staff)
			: base(definition, null, staff)
		{
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.StaffPromotion);
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			_delegate = OnDecision;
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)System.Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)System.Delegate.Combine(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffDestroyed = (Action<Staff>)System.Delegate.Combine(characterEvents3.OnStaffDestroyed, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)System.Delegate.Combine(characterEvents4.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)System.Delegate.Combine(characterEvents5.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
		}

		protected override void UnregisterEvents()
		{
			base.UnregisterEvents();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)System.Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)System.Delegate.Remove(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffDestroyed = (Action<Staff>)System.Delegate.Remove(characterEvents3.OnStaffDestroyed, new Action<Staff>(OnStaffNoLongerEmployed));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)System.Delegate.Remove(characterEvents4.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)System.Delegate.Remove(characterEvents5.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
		}

		public override string GetMessageText()
		{
			int num = MathUtils.Clamp(base.Staff.Rank + 1, 0, base.Staff.Definition._rank.Length);
			Character.Sex gender = base.Staff.Gender;
			StaffRank staffRank = base.Staff.Definition._rank[num];
			return base.Definition.GetTextStringForGender(gender).Replace("{[NAME]}", base.Staff.Name).Replace("{[RANK]}", staffRank.GetTitleLocalised(gender).Translation);
		}

		private void OnStaffNoLongerEmployed(Staff staff)
		{
			if (staff == base.Staff)
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnStaffStartLearning(Staff staff, RoomLogicTrainingRoom room)
		{
			if (staff == base.Staff)
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			if (staff == base.Staff && staff.IsFullyTrained)
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnDecision(int choice)
		{
			if (choice == 0)
			{
				InboxMenu inboxMenu = _level.HUD.FindMenu<InboxMenu>();
				if (inboxMenu != null)
				{
					inboxMenu.CloseMenu();
				}
				_level.HUD.CreateMenu<TrainingMenu>().Setup(_level, null, base.Staff, null);
			}
		}
	}
}

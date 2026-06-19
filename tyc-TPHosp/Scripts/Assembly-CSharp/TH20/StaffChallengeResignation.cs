using System;
using System.Collections.Generic;
using I2.Loc;

namespace TH20
{
	public class StaffChallengeResignation : LevelObjective
	{
		private NotificationMessage _introMessage;

		public Staff Staff { get; private set; }

		public StaffChallengeResignation(Level level, ObjectiveDefinition definition, Staff staff)
			: base(level, string.Empty, definition, isVisible: true, isDiscovered: true, isReplayable: false, startImmediately: false)
		{
			Staff = staff;
			DisplayIntroMessage();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffInvalid));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffInvalid));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents3.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			Notifications notifications = base.Level.Notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
		}

		private void OnNotificationRemoved(NotificationMessage message)
		{
			if (message == _introMessage)
			{
				_introMessage = null;
				Start();
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffInvalid));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffInvalid));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents3.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			Notifications notifications = base.Level.Notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			Staff.RemoveComponents<StaffThreatingToLeaveComponent>();
			if (_introMessage != null)
			{
				base.Level.Notifications.Remove(_introMessage);
				_introMessage = null;
			}
			base.Destroy();
		}

		public override string GetTitleText()
		{
			return LocalisedString.Replace(base.Definition.NameLocalised.Translation, "{[STAFF]}", Staff.Name);
		}

		public override void OnMouseSelect()
		{
			base.Level.BuildEvents.OnCursorSelectObject.InvokeSafe(Staff);
		}

		private void OnStaffInvalid(Staff staff)
		{
			if (staff == Staff)
			{
				if (_introMessage != null)
				{
					base.Level.Notifications.Remove(_introMessage);
					_introMessage = null;
				}
				Abandon();
			}
		}

		private void OnCharacterDestroyed(Character character)
		{
			if (character == Staff)
			{
				Abandon();
			}
		}

		private void DisplayIntroMessage()
		{
			_introMessage = new NotificationStaff(Staff.Definition.ResignationWarningMessage.Instance, null, Staff);
			base.Level.Notifications.Send(_introMessage);
			List<string> topComplaints = Staff.GetComponent<StaffHappinessComponent>().GetTopComplaints(3, showHidden: false);
			string message = LocalisedString.Replace(ScriptLocalization.Advisor.Staff_Resignation_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", GameStringUtils.StaffTitle(Staff)),
				new SubPair("{[COMPLAINTS]}", GameStringUtils.MakeStringFromList(topComplaints))
			});
			base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
			{
				Message = message,
				Duration = 10f,
				CameraTrackObject = Staff.GetCameraTrackObject(),
				UserCanDismiss = true
			}, interrupt: true, Advisor.PriorityLevel.High);
		}

		protected override void DisplayCompletedMessage(bool success)
		{
			base.DisplayCompletedMessage(success);
			if (!success)
			{
				Staff.Resign();
				return;
			}
			base.Level.Notifications.Send(new NotificationStaff(Staff.Definition.ResignationSuccessMessage.Instance, null, Staff));
			base.Level.CharacterEvents.OnStaffStopThreateningToLeave.InvokeSafe(Staff);
		}

		public override void GiveRewards(CompletionType completionType)
		{
			RewardUtils.GiveAllRewards(this, GetRewards(completionType), base.Level.Metagame, Staff);
		}

		public override bool ShouldAddToExpiredObjectivesList()
		{
			return false;
		}

		public override bool CanDismiss()
		{
			return false;
		}
	}
}

#define LOG_LEVEL_VERBOSE
using System;

namespace TH20
{
	public class StaffChallenge : LevelObjective
	{
		private NotificationStaffChallenge _introMessage;

		private NotificationStaffChallenge _outroMessage;

		private readonly StaffChallengeManager _staffChallengeManager;

		public Staff Staff { get; private set; }

		public new StaffChallengeDefinition Definition { get; private set; }

		public StaffChallenge(Level level, StaffChallengeManager manager, StaffChallengeDefinition definition, Staff staff)
			: base(level, string.Empty, definition, isVisible: true, isDiscovered: true, isReplayable: false, startImmediately: false)
		{
			Staff = staff;
			Definition = definition;
			_staffChallengeManager = manager;
			DisplayIntroMessage();
			Staff.GetOrAddComponent<StaffChallengeComponent>().Setup(this);
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
		}

		public override void RestoreFromSave()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			if (_introMessage != null)
			{
				_introMessage.RestoreResponseDelegate(IntroMessageResponse);
			}
			if (_outroMessage != null)
			{
				_outroMessage.RestoreResponseDelegate(OutroMessageResponse);
			}
			base.RestoreFromSave();
		}

		public override void Destroy()
		{
			if (_introMessage != null)
			{
				base.Level.Notifications.Remove(_introMessage);
			}
			if (_outroMessage != null)
			{
				base.Level.Notifications.Remove(_outroMessage);
			}
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents2.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			Staff.RemoveComponents<StaffChallengeComponent>();
			base.Destroy();
		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			_staffChallengeManager.OnChallengeFinished(this);
		}

		public string GetStaffName()
		{
			return Staff.Name;
		}

		public override string GetTitleText()
		{
			return LocalisedString.Replace(Definition.NameLocalised.Translation, "{[STAFF]}", GetStaffName());
		}

		public override void OnMouseSelect()
		{
			base.Level.BuildEvents.OnCursorSelectObject.InvokeSafe(Staff);
		}

		private void OnStaffFired(Staff staff)
		{
			if (staff == Staff)
			{
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
			NotificationMessages.Definition introMessage = _staffChallengeManager.Configuration.IntroMessage;
			_introMessage = new NotificationStaffChallenge(introMessage, this, NotificationStaffChallenge.MessageType.Intro, IntroMessageResponse, base.Level);
			base.Level.Notifications.Send(_introMessage);
		}

		private void IntroMessageResponse(int response)
		{
			_introMessage = null;
			if (response == 0)
			{
				Start();
			}
			else
			{
				Abandon();
			}
		}

		protected override void DisplayCompletedMessage(bool success)
		{
			NotificationMessages.Definition definition = (success ? _staffChallengeManager.Configuration.SuccessMessage : _staffChallengeManager.Configuration.FailureMessage);
			NotificationStaffChallenge.MessageType type = (success ? NotificationStaffChallenge.MessageType.Success : NotificationStaffChallenge.MessageType.Failure);
			if (_outroMessage != null)
			{
				Logging.Warning(LogChannels.Challenge, "WARNING - Staff Challenge - is trying to display a new outro message, but apparently we already have one displayed!");
				return;
			}
			_outroMessage = new NotificationStaffChallenge(definition, this, type, OutroMessageResponse, base.Level);
			base.Level.Notifications.Send(_outroMessage);
		}

		private void OutroMessageResponse(int response)
		{
			if (_outroMessage == null)
			{
				Logging.Warning(LogChannels.Challenge, "WARNING - Staff Challenge - has no outro message, but apparently we have a response from one");
				return;
			}
			_outroMessage = null;
			GiveRewards(base.CompletionResult);
			ReadyToDestroy();
		}

		public override void GiveRewards(CompletionType completionType)
		{
			RewardUtils.GiveAllRewards(this, GetRewards(completionType), base.Level.Metagame, Staff);
		}

		public override string GetObjectiveMenuItemTooltip()
		{
			return base.GetObjectiveMenuItemTooltip().Replace("{[STAFF]}", GetStaffName());
		}

		public override bool ShouldAddToExpiredObjectivesList()
		{
			return false;
		}

		public override bool CanDismiss()
		{
			return true;
		}

		public override bool GiveRewardOnComplete()
		{
			return false;
		}

		public override bool ReadyToDestroyOnComplete()
		{
			if (base.CompletionResult != CompletionType.Abandoned)
			{
				return base.CompletionResult == CompletionType.Invalid;
			}
			return true;
		}
	}
}

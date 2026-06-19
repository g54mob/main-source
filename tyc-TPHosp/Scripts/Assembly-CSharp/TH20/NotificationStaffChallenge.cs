using System;
using I2.Loc;

namespace TH20
{
	public class NotificationStaffChallenge : NotificationStaff
	{
		public enum MessageType
		{
			Intro = 0,
			Success = 1,
			Failure = 2
		}

		private readonly MessageType _type;

		private readonly StaffChallenge _challenge;

		public StaffChallenge Challenge => _challenge;

		public NotificationStaffChallenge(NotificationMessages.Definition definition, StaffChallenge challenge, MessageType type, ResponseDelegate responseDelegate, Level level)
			: base(definition, responseDelegate, challenge.Staff)
		{
			_type = type;
			_challenge = challenge;
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffDestroyed = (Action<Staff>)System.Delegate.Combine(characterEvents.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
		}

		protected override void UnregisterEvents()
		{
			base.UnregisterEvents();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffDestroyed = (Action<Staff>)System.Delegate.Remove(characterEvents.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
		}

		private void OnStaffDestroyed(Staff staff)
		{
			if (staff == GetCharacter())
			{
				_challenge.Abandon();
			}
		}

		public override string GetTitleText()
		{
			return string.Format("{0}\n{1}", _challenge.GetStaffName(), (_challenge.Staff.RankDefinition != null) ? _challenge.Staff.RankDefinition.GetTitleLocalised(_challenge.Staff.Gender).Translation : "");
		}

		public override string GetTooltipText()
		{
			return ScriptLocalization.Notification.StaffChallenge_TooltipText_CS.Replace("{[NAME]}", _challenge.GetStaffName());
		}

		public override string GetMessageText()
		{
			return GetFlavourText();
		}

		public string GetFlavourText()
		{
			string text = string.Empty;
			switch (_type)
			{
			case MessageType.Intro:
				text = _challenge.Definition.IntroMessageTextLocalised.Translation;
				break;
			case MessageType.Success:
				text = _challenge.Definition.OutroMessageSuccessTextLocalised.Translation;
				break;
			case MessageType.Failure:
				text = _challenge.Definition.OutroMessageFailedTextLoaclised.Translation;
				break;
			}
			text = text.Replace("{[STAFF]}", _challenge.GetStaffName());
			return text.Replace("\\n", "\n");
		}

		public string GetChallengeText()
		{
			switch (_type)
			{
			case MessageType.Intro:
			case MessageType.Success:
				return _challenge.Definition.GetDescriptionString(_challenge, _challenge.Definition.CompletionRewards);
			case MessageType.Failure:
				return _challenge.Definition.GetDescriptionString(_challenge, _challenge.Definition.FailRewards);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}

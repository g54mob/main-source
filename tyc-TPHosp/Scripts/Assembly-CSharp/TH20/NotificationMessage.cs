using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public abstract class NotificationMessage : MustCallDestroy
	{
		public delegate void ResponseDelegate(int response);

		protected readonly Level _level;

		protected readonly NotificationMessages.Definition _definition;

		private readonly float _timeCreated;

		protected ResponseDelegate _delegate;

		public NotificationMessages.Definition Definition => _definition;

		public ResponseDelegate Delegate
		{
			get
			{
				return _delegate;
			}
			set
			{
				_delegate = value;
			}
		}

		public bool HasTimedOut
		{
			get
			{
				if (_definition.TimeoutInSeconds != 0)
				{
					return GetTime() - _timeCreated >= (float)_definition.TimeoutInSeconds;
				}
				return false;
			}
		}

		protected NotificationMessage(NotificationMessages.Definition definition, Level level)
		{
			_level = level;
			_definition = definition;
			_timeCreated = GetTime();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		protected virtual void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)System.Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientTimeTunnel = (Action<Patient>)System.Delegate.Combine(characterEvents2.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
		}

		protected virtual void UnregisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)System.Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientTimeTunnel = (Action<Patient>)System.Delegate.Remove(characterEvents2.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		public void RestoreResponseDelegate(ResponseDelegate responseDelegate)
		{
			_delegate = responseDelegate;
		}

		private void OnCharacterDestroyed(Character character)
		{
			if (GetCharacter() == character)
			{
				_level.Notifications.Remove(this);
			}
		}

		private float GetTime()
		{
			if (!_definition.UseScaledTime)
			{
				return GameTime.unscaledTime - (float)_level.GameTime.PausedDuration;
			}
			return GameTime.time;
		}

		public virtual string GetTitleText()
		{
			return Definition.GetTitleString();
		}

		public virtual string GetTooltipText()
		{
			return Definition.GetTitleString();
		}

		public virtual string GetMessageText()
		{
			return Definition.GetTextString();
		}

		public abstract Character GetCharacter();
	}
}

using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class HoverMenuCharacter : HoverMenuBase
	{
		public virtual void Setup(Character character, Level level)
		{
			Setup((ICursorSelectable)character, level);
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
			base.Destroy();
		}

		private void OnCharacterDestroyed(Character character)
		{
			if (character == _objectSelected)
			{
				CloseMenu();
			}
		}
	}
}

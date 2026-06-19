using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class SelectMenuCharacter : SelectMenuBase
	{
		protected Character _character;

		public virtual void Setup(Character character, Level level)
		{
			Setup((ICursorSelectable)character, level);
			_character = character;
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
			if (character == _character)
			{
				CloseMenu();
			}
		}

		protected void VaccinateCharacter(Character character)
		{
			List<ChallengeEpidemic> activeChallengesOfType = base.Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				activeChallengesOfType[0].VaccinateCharacter(character);
			}
		}

		protected void UpdateVaccinationButton(GameObject button, Character character)
		{
			bool isActive = true;
			List<ChallengeEpidemic> activeChallengesOfType = character.Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count < 1 || !activeChallengesOfType[0].VaccinesAvailable() || activeChallengesOfType[0].IsVaccinated(character) || !ChallengeEpidemic.IsInfectableEver(character))
			{
				isActive = false;
			}
			GameObjectUtils.SetActive(button, isActive);
		}
	}
}

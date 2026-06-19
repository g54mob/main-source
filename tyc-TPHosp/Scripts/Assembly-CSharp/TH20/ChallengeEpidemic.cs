#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using I2.Loc;

namespace TH20
{
	public class ChallengeEpidemic : Challenge
	{
		private class IsInfectedParams
		{
			public bool IsInfected;
		}

		private readonly ChallengeEpidemicConfig _config;

		private int _numberInfected;

		private int _numberCured;

		private int _numberOfVaccines;

		private int _numberLeftHospitalInfected;

		private bool _showStatusIconsAfterLoad;

		private bool _finished;

		private readonly List<Character> _vaccinated;

		private readonly IsInfectedParams _isInfectedParams = new IsInfectedParams();

		private SubGoalEpidemic _subGoal;

		public int NumberCured => _numberCured;

		public int NumberOfVaccines => _numberOfVaccines;

		public ChallengeEpidemic(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeEpidemicConfig>();
			_vaccinated = new List<Character>();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_showStatusIconsAfterLoad = true;
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Remove(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
			base.Destroy();
		}

		protected override void OnChallengeStarted()
		{
			Logging.Info(LogChannels.Objective, "Starting epidemic challenge");
			List<Character> list = new List<Character>(base.Level.CharacterManager.AllCharacters);
			CharacterStatusEffectDefinition instance = _config.InfectionStatusEffect.Instance;
			list.RemoveAll(CharacterIsExcluded);
			for (int i = 0; i < _config.NumberOfPeopleInitiallyInfected; i++)
			{
				if (list.Count != 0)
				{
					int index = RandomUtils.GlobalRandomInstance.Next(list.Count);
					Character character = list[index];
					list.RemoveAt(index);
					if (character.ModifiersComponent != null)
					{
						character.ModifiersComponent.AddStatusEffect(instance);
					}
				}
			}
			_numberOfVaccines = _config.NumberOfVaccines;
			_subGoal = SubGoals[0] as SubGoalEpidemic;
			if (_subGoal != null)
			{
				_subGoal.UpdateProgress();
			}
			base.OnChallengeStarted();
		}

		private static bool CharacterIsExcluded(Character character)
		{
			if (character is Staff)
			{
				return true;
			}
			if (character is Visitor)
			{
				return true;
			}
			if (character.ReasonForLeaving != Character.ReasonForLeavingHospital.None)
			{
				return true;
			}
			if (character.ModifiersComponent != null)
			{
				return !IsInfectableEver(character);
			}
			return true;
		}

		public static bool CharacterCantBeVaccinated(Character character)
		{
			if (character.ModifiersComponent != null && !(character is GuestTrainer) && !(character is Visitor))
			{
				return !IsInfectableEver(character);
			}
			return true;
		}

		public static bool IsInfectableEver(Character character)
		{
			if (character.GetComponent<GhostComponent>() == null)
			{
				return character.GetComponent<RoboJanitorComponent>() == null;
			}
			return false;
		}

		protected override void OnFinish(CompletionType completionType)
		{
			CharacterStatusEffectDefinition instance = _config.InfectionStatusEffect.Instance;
			foreach (Character allCharacter in base.Level.CharacterManager.AllCharacters)
			{
				if (IsInfected(allCharacter))
				{
					PlayCuredEffect(allCharacter, cured: true);
				}
				if (allCharacter.ModifiersComponent != null)
				{
					allCharacter.ModifiersComponent.RemoveStatusEffect(instance);
				}
				if (IsVaccinated(allCharacter))
				{
					base.Level.StatusIconManager.DestroyStatusIcon(allCharacter);
				}
			}
			Logging.Info(LogChannels.Objective, "Finished epidemic challenge");
			if (completionType == CompletionType.Abandoned)
			{
				ChallengeRewardOption challengeReward = GetConfig<ChallengeConfig>().Reward.FindRewardForScore(CalculateChallengeScore());
				base.Level.Notifications.Send(new NotificationChallenge(challengeReward, this, null, base.Level));
			}
			base.OnFinish(completionType);
		}

		protected override void OnChallengeFinished()
		{
			if (base.CompletionResult != CompletionType.Invalid)
			{
				base.CompletionResult = ((CalculateChallengeScore() == 0) ? CompletionType.Successful : CompletionType.Failed);
			}
			base.OnChallengeFinished();
		}

		protected override void UpdateChallenge(float timeDelta)
		{
			base.UpdateChallenge(timeDelta);
			if (_showStatusIconsAfterLoad && _vaccinated != null)
			{
				foreach (Character item in _vaccinated)
				{
					base.Level.StatusIconManager.ShowStatusIcon(item, StatusIcon.Type.Vaccinated);
				}
				_showStatusIconsAfterLoad = false;
			}
			if (_numberInfected == 0 || _numberOfVaccines == 0 || _numberLeftHospitalInfected >= _config.NumberAllowedToLeaveHospital || _numberInfected > _numberOfVaccines)
			{
				_finished = true;
				FinishChallenge();
			}
		}

		protected override int CalculateChallengeScore()
		{
			if (base.CompletionResult == CompletionType.Abandoned || base.CompletionResult == CompletionType.Invalid || (!_finished && base.CompletionResult == CompletionType.Incomplete))
			{
				return 3;
			}
			if (_numberLeftHospitalInfected >= _config.NumberAllowedToLeaveHospital)
			{
				return 2;
			}
			if (_numberInfected == 0)
			{
				return 0;
			}
			if (_numberInfected > _numberOfVaccines)
			{
				return 1;
			}
			return 0;
		}

		public bool VaccinesAvailable()
		{
			return _numberOfVaccines > 0;
		}

		public bool IsVaccinated(Character character)
		{
			return _vaccinated.Contains(character);
		}

		private bool IsInfected(Character character)
		{
			_isInfectedParams.IsInfected = false;
			if (character.ModifiersComponent != null)
			{
				character.ModifiersComponent.IterateModifiersOfType(_isInfectedParams, delegate(IsInfectedParams p, CharacterModifierInfected _)
				{
					p.IsInfected = true;
				});
			}
			return _isInfectedParams.IsInfected;
		}

		public void AddInfection(Character character)
		{
			_numberInfected++;
			if (_subGoal != null)
			{
				_subGoal.UpdateProgress();
			}
		}

		public void RemoveInfection()
		{
			if (!_finished)
			{
				_numberInfected--;
				if (_subGoal != null)
				{
					_subGoal.UpdateProgress();
				}
			}
		}

		public void VaccinateCharacter(Character character)
		{
			if (CharacterCantBeVaccinated(character) || IsVaccinated(character))
			{
				return;
			}
			_vaccinated.Add(character);
			bool flag = IsInfected(character);
			if (flag)
			{
				_numberCured++;
				if (character.ModifiersComponent != null)
				{
					character.ModifiersComponent.RemoveStatusEffect(_config.InfectionStatusEffect.Instance);
				}
				base.Level.CharacterEvents.OnCharacterVaccinated.InvokeSafe();
			}
			PlayCuredEffect(character, flag);
			_numberOfVaccines--;
			if (_subGoal != null)
			{
				_subGoal.UpdateProgress();
			}
			base.Level.StatusIconManager.ShowStatusIcon(character, StatusIcon.Type.Vaccinated);
		}

		private static void PlayCuredEffect(Character character, bool cured)
		{
			AnimationParticleEventListener component = character.GameObject.GetComponent<AnimationParticleEventListener>();
			if (component != null)
			{
				component.SpawnFX(cured ? "InjectC" : "Inject");
			}
			AudioManager.Instance.Play(cured ? "InjectPatientCured" : "InjectPatient", character.GameObject);
		}

		private void OnCharacterDestroyed(Character character)
		{
			_vaccinated.Remove(character);
		}

		private void OnCharacterLeftHospital(Character character)
		{
			if (IsInfected(character))
			{
				_numberLeftHospitalInfected++;
				if (_subGoal != null)
				{
					_subGoal.UpdateProgress();
				}
				if (_config.AdvisorMessageInfectedLeftHospital.Term != null)
				{
					base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
					{
						LocalisedMessage = _config.AdvisorMessageInfectedLeftHospital,
						Duration = 10f,
						UserCanDismiss = true
					}, interrupt: true, Advisor.PriorityLevel.High);
				}
			}
		}

		public override string GetScoreText()
		{
			string text = ScriptLocalization.Challenges.Epidemic_Score_CS;
			LocalisationParams.Set("CURED", _numberCured);
			LocalisationParams.Set("VACCINES", _numberOfVaccines);
			LocalisationParams.Set("INFECTED", _numberInfected);
			return LocalisationParams.Localise(ref text);
		}

		public string GetProgressText()
		{
			if (_challengeState == ChallengeState.InProgress || _challengeState == ChallengeState.WaitingToStart)
			{
				return LocalisedString.Replace(ScriptLocalization.Challenges_SubGoals.Epidemic_CS, new SubPair[3]
				{
					new SubPair("{[COUNT]}", _numberInfected.ToString()),
					new SubPair("{[VACCINES]}", _numberOfVaccines.ToString()),
					new SubPair("{[ESCAPED]}", _numberLeftHospitalInfected.ToString())
				});
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}

		public override bool CanDismiss()
		{
			return !IsComplete();
		}
	}
}

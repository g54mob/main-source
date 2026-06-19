#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class UIPinSelectMenu : Selectable
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Menu")]
			public Vector2 OffsetFromParent;

			public SharedInstance<AnimationProperties> OpenAnimationProperties;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Patients")]
			[InspectorRange(0f, 5f)]
			public int LeadingHurtIndicators = 1;

			[InspectorRange(0f, 5f)]
			public int LeadingAlmostDeadIndicators = 1;

			public Sprite PatientHealthySprite;

			public Sprite PatientHurtSprite;

			public Sprite PatientAlmostDeadSprite;

			public Sprite PatientDeadSprite;

			public Sprite PatientCollectedSprite;
		}

		private class PatientIndicator
		{
			public enum EHealthLevel
			{
				Healthy = 0,
				Hurt = 1,
				AlmostDead = 2
			}

			private Config _config;

			private Image _icon;

			public PatientIndicator(Image icon, Config config, int index)
			{
				_icon = icon;
				_config = config;
				if (_icon != null && _config != null)
				{
					_icon.overrideSprite = _config.PatientHealthySprite;
				}
			}

			public void SetHealthLevel(EHealthLevel level)
			{
				switch (level)
				{
				case EHealthLevel.Healthy:
					_icon.overrideSprite = _config.PatientHealthySprite;
					break;
				case EHealthLevel.Hurt:
					_icon.overrideSprite = _config.PatientHurtSprite;
					break;
				case EHealthLevel.AlmostDead:
					_icon.overrideSprite = _config.PatientAlmostDeadSprite;
					break;
				default:
					_icon.overrideSprite = _config.PatientHealthySprite;
					break;
				}
			}

			public void SetCollected()
			{
				_icon.overrideSprite = _config.PatientCollectedSprite;
			}

			public void SetDead()
			{
				_icon.overrideSprite = _config.PatientDeadSprite;
			}
		}

		public Action OnSelectMenuClosed;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _distanceText;

		[SerializeField]
		private TMP_Text _severityText;

		[SerializeField]
		private TMP_Text _timeRemainingText;

		[SerializeField]
		private ProgressBarMaskable _patientsRemainingBar;

		[SerializeField]
		private Image[] _patientIndicators;

		[SerializeField]
		private Image[] _graceIndicators;

		[SerializeField]
		private Button _dispatchButton;

		[SerializeField]
		private GameObject _tutorialCircle;

		[SerializeField]
		private GameObject _progressPointer;

		private const float PatientIndicatorTickTime = 1f;

		private Level _level;

		private EmergencyDispatchMenu _emergencyDispatchMenu;

		private RectTransformAnimator _rectTransformAnimator;

		private Config _config;

		private UIMapPin _parentPin;

		private ChallengeAmbulanceEmergency _ambulanceEmergency;

		private PlayerAmbulanceDepartment _playerAmbulanceDepartment;

		private PatientIndicator[] _activePatientIndicators;

		private const int SecondsPerMin = 60;

		public void Setup(EmergencyDispatchMenu emergencyDispatchMenu, ChallengeAmbulanceEmergency ambulanceEmergency, EmergencyPin parent)
		{
			_emergencyDispatchMenu = emergencyDispatchMenu;
			_rectTransformAnimator = _emergencyDispatchMenu.RectTransformAnimator;
			_config = _emergencyDispatchMenu.Definition.UIPinSelectConfig.Instance;
			_level = _emergencyDispatchMenu?.Level;
			_ambulanceEmergency = ambulanceEmergency;
			_parentPin = parent;
			_playerAmbulanceDepartment = _emergencyDispatchMenu?.Level?.ChallengeManager?.PlayerAmbulanceDepartment;
			_patientsRemainingBar.Progress = Mathf.Clamp(1f - _ambulanceEmergency.DeathClockRemaining, 0f, 1f);
			base.transform.localPosition = _parentPin.transform.localPosition;
			Vector3 vector = base.transform.localPosition + _config.OffsetFromParent.to_xy0();
			vector.y = ((vector.y > _parentPin.DispatchMap.MapMask.position.y) ? _parentPin.DispatchMap.MapMask.position.y : vector.y);
			AnimationProperties instance = _config.OpenAnimationProperties.Instance;
			if (instance != null)
			{
				_rectTransformAnimator.Animate(instance.Curve, (RectTransform)base.transform, vector, Quaternion.identity, instance.Duration, instance.InterruptOtherAnimations);
			}
			else
			{
				Logging.Error(LogChannels.GUI, "Missing Animation Data: Skipping Animation");
				base.transform.localPosition = vector;
			}
			RegisterEvents();
			SetupTotalPatientIndicators();
			DisplayEmergencyInformation();
		}

		public void Update()
		{
			DisplayUpdateInformation();
		}

		public void CloseMenu()
		{
			_emergencyDispatchMenu.HideAmbulanceSelectionMenu();
			OnSelectMenuClosed.InvokeSafe();
			Logging.Info("Closing UI Pin Select Menu.");
			UnityEngine.Object.Destroy(base.gameObject);
		}

		protected override void OnDestroy()
		{
			_parentPin = null;
			_ambulanceEmergency = null;
			UnregisterEvents();
			base.OnDestroy();
		}

		private void RegisterEvents()
		{
			_dispatchButton.onClick.AddListener(DispatchButtonClick);
			if (_level != null)
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientsCollected = (Action<int>)Delegate.Combine(characterEvents.OnPatientsCollected, new Action<int>(OnPatientsCollected));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Combine(characterEvents2.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
				ChallengeEvents challengeEvents = _level.ChallengeEvents;
				challengeEvents.OnChallengeFinished = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeFinished, new Action<Challenge>(OnChallengeFinished));
			}
			if (_ambulanceEmergency != null)
			{
				ChallengeAmbulanceEmergency ambulanceEmergency = _ambulanceEmergency;
				ambulanceEmergency.OnDeathClockTick = (Action)Delegate.Combine(ambulanceEmergency.OnDeathClockTick, new Action(OnDeathClockTick));
			}
		}

		private void UnregisterEvents()
		{
			_dispatchButton.onClick.RemoveListener(DispatchButtonClick);
			if (_level != null)
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Remove(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollected));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientDiedAtScene = (Action<bool, string>)Delegate.Remove(characterEvents2.OnPatientDiedAtScene, new Action<bool, string>(OnPatientDiedAtScene));
				ChallengeEvents challengeEvents = _level.ChallengeEvents;
				challengeEvents.OnChallengeFinished = (Action<Challenge>)Delegate.Remove(challengeEvents.OnChallengeFinished, new Action<Challenge>(OnChallengeFinished));
			}
			if (_ambulanceEmergency != null)
			{
				ChallengeAmbulanceEmergency ambulanceEmergency = _ambulanceEmergency;
				ambulanceEmergency.OnDeathClockTick = (Action)Delegate.Remove(ambulanceEmergency.OnDeathClockTick, new Action(OnDeathClockTick));
			}
		}

		private void DisplayEmergencyInformation()
		{
			if (_ambulanceEmergency != null)
			{
				int num = Mathf.RoundToInt(_ambulanceEmergency.CalculateDistance(_playerAmbulanceDepartment.Config.Location));
				_titleText.text = _ambulanceEmergency.Definition.NameLocalised.Translation;
				_severityText.text = _ambulanceEmergency.Definition.SeverityDisplayValue.ToString();
				_distanceText.text = $"{_ambulanceEmergency.Definition.Location.Instance.Name.Translation}: {GameStringUtils.GetEmergencyDistanceString(num)}";
				DisplayUpdateInformation();
			}
		}

		private void DisplayUpdateInformation()
		{
			int num = Mathf.Clamp((int)_ambulanceEmergency.DeathClockRemainingAsSeconds, 0, int.MaxValue);
			int num2 = num / 60;
			if (num2 > 0)
			{
				_timeRemainingText.text = LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Minutes_CS").Replace("{[MINUTES]}", num2.ToString()) + " ";
				num %= 60;
				_timeRemainingText.text += LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Seconds_CS").Replace("{[SECONDS]}", num.ToString());
			}
			else
			{
				_timeRemainingText.text = LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Seconds_CS").Replace("{[SECONDS]}", num.ToString());
			}
			_patientsRemainingBar.Progress = Mathf.Clamp(1f - _ambulanceEmergency.DeathClockRemaining, 0f, 1f);
			if (_patientsRemainingBar.Progress < 0.075f)
			{
				_progressPointer.SetActive(value: false);
			}
		}

		private void SetupTotalPatientIndicators()
		{
			if (_ambulanceEmergency.TotalPatients > _patientIndicators.Length)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "The amount of patient indicators does not match the amount of patients. UIPinSelectMenu.SetupTotalPatientIndicators();");
				return;
			}
			_activePatientIndicators = new PatientIndicator[_ambulanceEmergency.TotalPatients];
			for (int i = 0; i < _patientIndicators.Length; i++)
			{
				if (i >= _ambulanceEmergency.TotalPatients)
				{
					_patientIndicators[i].gameObject.SetActive(value: false);
					continue;
				}
				_patientIndicators[i].gameObject.SetActive(value: true);
				_activePatientIndicators[i] = new PatientIndicator(_patientIndicators[i], _config, i);
			}
			for (int j = 0; j < _graceIndicators.Length; j++)
			{
				_graceIndicators[j].gameObject.SetActive(j < _ambulanceEmergency.OriginalDeathClockTicksBeforeFirstDeath);
			}
			RefreshPatientIndicators();
		}

		private void RefreshPatientIndicators()
		{
			if (_ambulanceEmergency == null)
			{
				return;
			}
			int patientsRemaining = _ambulanceEmergency.PatientsRemaining;
			int wouldBeDeadPatients = _ambulanceEmergency.WouldBeDeadPatients;
			int patientsCollected = _ambulanceEmergency.PatientsCollected;
			int num = wouldBeDeadPatients + _ambulanceEmergency.DeathClockTicksBeforeFirstDeath - _config.LeadingHurtIndicators - _config.LeadingAlmostDeadIndicators;
			int num2 = wouldBeDeadPatients + _ambulanceEmergency.DeathClockTicksBeforeFirstDeath - _config.LeadingAlmostDeadIndicators;
			for (int i = 0; i < _activePatientIndicators.Length; i++)
			{
				if (i < patientsRemaining)
				{
					if (i >= num2)
					{
						_activePatientIndicators[i].SetHealthLevel(PatientIndicator.EHealthLevel.AlmostDead);
					}
					else if (i >= num)
					{
						_activePatientIndicators[i].SetHealthLevel(PatientIndicator.EHealthLevel.Hurt);
					}
					else
					{
						_activePatientIndicators[i].SetHealthLevel(PatientIndicator.EHealthLevel.Healthy);
					}
				}
				else if (i < patientsRemaining + patientsCollected)
				{
					_activePatientIndicators[i].SetCollected();
				}
				else
				{
					_activePatientIndicators[i].SetDead();
				}
			}
		}

		private void OnDeathClockTick()
		{
			RefreshPatientIndicators();
		}

		private void OnPatientsCollected(List<Patient> patients, string ID)
		{
			RefreshPatientIndicators();
		}

		private void OnPatientsCollected(int patientCount)
		{
			RefreshPatientIndicators();
		}

		private void OnPatientDiedAtScene(bool playerDispatched, string ID)
		{
			RefreshPatientIndicators();
		}

		private void OnChallengeFinished(Challenge challenge)
		{
			if (challenge is ChallengeAmbulanceEmergency challengeAmbulanceEmergency && challengeAmbulanceEmergency.EmergencyID == _ambulanceEmergency.EmergencyID)
			{
				CloseMenu();
			}
		}

		private void DispatchButtonClick()
		{
			if (_emergencyDispatchMenu != null)
			{
				_level.ChallengeManager.OnOpenSatNavSubMenu.InvokeSafe(param: true);
				_emergencyDispatchMenu.ShowAmbulanceSelectionMenu(_ambulanceEmergency);
			}
		}

		public void CircleDispatchButton(bool active)
		{
			GameObjectUtils.SetActive(_tutorialCircle, active);
		}
	}
}

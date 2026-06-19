#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	public class EmergencyDispatchMenu : AnimatedMenuBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Configs")]
			public SharedInstance<UIPinSelectMenu.Config> UIPinSelectConfig;

			public SharedInstance<AmbulanceSelectionMenu.Config> AmbulanceSelectionMenuConfig;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Prefabs")]
			public GameObject HospitalPinPrefab;

			public GameObject EmergencyPinPrefab;

			public GameObject AmbulancePinPrefab;

			public GameObject RouteRendererPrefab;

			public GameObject EmergencyPinSelectPrefab;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Map")]
			public Dictionary<string, Sprite> LevelIdsAndMaps;

			public Vector2 DisplayPosition;

			public Vector2 HiddenPosition;

			public SharedInstance<AnimationProperties> OpenMapAnimationProperties;

			public SharedInstance<AnimationProperties> CloseMapAnimationProperties;

			public float MapScrollRate = 5f;

			public Bounds MapScrollMargin;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Emergencies")]
			public Sprite[] MinorEmergencySeveritySprites;

			public Sprite[] MajorEmergencySeveritySprites;

			public Sprite[] MinorRoadEmergencySeveritySprites;

			public Sprite[] MajorRoadEmergencySeveritySprites;

			public Sprite[] MinorAirEmergencySeveritySprites;

			public Sprite[] MajorAirEmergencySeveritySprites;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Rescues")]
			public Sprite[] MinorRescueSeveritySprites;

			public Sprite[] MajorRescueSeveritySprites;

			public Sprite[] MinorRoadRescueSeveritySprites;

			public Sprite[] MajorRoadRescueSeveritySprites;

			public Sprite[] MinorAirRescueSeveritySprites;

			public Sprite[] MajorAirRescueSeveritySprites;
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Ambulance Menu")]
		[SerializeField]
		private EmergencyDispatchMap _dispatchMap;

		[SerializeField]
		private UISelectionTarget _mapSelectionTarget;

		[SerializeField]
		private AmbulanceSelectionMenu _ambulanceSelectionMenu;

		[SerializeField]
		private RectTransformAnimator _rectTransformAnimator;

		[SerializeField]
		private DynamicButton _toggleHelp;

		[SerializeField]
		private GameObject _helpPanel;

		private Config _config;

		private Level _level;

		private ChallengeManager _challengeManager;

		private TopDownCameraLogic _cameraLogic;

		private List<ChallengeAmbulanceEmergency> _ambulanceEmergencyChallenges;

		private bool _isAnimatingOut;

		public Config Definition => _config;

		public Level Level => _level;

		public AmbulanceSelectionMenu AmbulanceSelectionMenu => _ambulanceSelectionMenu;

		public RectTransformAnimator RectTransformAnimator => _rectTransformAnimator;

		public RectTransform EmergencyPinMenuRect => (RectTransform)_config.EmergencyPinSelectPrefab.transform;

		public EmergencyDispatchMap EmergencyDispatchMap => _dispatchMap;

		public void Setup(Level level)
		{
			_level = level;
			_config = _level.Config.GetEmergencyUIConfig();
			if (_level == null)
			{
				Logging.Error("Level is null in Ambulance Dispatch Menu");
				return;
			}
			_challengeManager = _level.ChallengeManager;
			if (_challengeManager != null)
			{
				_ambulanceEmergencyChallenges = _challengeManager.GetActiveChallengesOfType<ChallengeAmbulanceEmergency>();
			}
			base.transform.localPosition = _config.HiddenPosition;
			_cameraLogic = _level.CameraLogic;
			_dispatchMap.Setup(this);
			RegisterEvents();
			Initialise();
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		public override void CloseMenu()
		{
			if (!_isAnimatingOut)
			{
				AnimateOut();
			}
			else
			{
				CloseImmediately();
			}
		}

		public void ShowAmbulanceSelectionMenu(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_ambulanceSelectionMenu != null)
			{
				_ambulanceSelectionMenu.OpenSelectionMenu(ambulanceEmergency);
			}
		}

		public void PeekSelectionMenu()
		{
			if (_ambulanceSelectionMenu != null)
			{
				_ambulanceSelectionMenu.PeekSelectionMenu();
			}
		}

		public void PeekSelectionMenu(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_ambulanceSelectionMenu != null)
			{
				_ambulanceSelectionMenu.PeekSelectionMenu(ambulanceEmergency);
			}
		}

		public void HideAmbulanceSelectionMenu()
		{
			if (_ambulanceSelectionMenu != null)
			{
				_ambulanceSelectionMenu.CloseSelectionMenu();
			}
		}

		private void OnMapTargetSelected(BaseEventData eventData)
		{
			_dispatchMap.SetSelectedMapPin(null);
		}

		private void RegisterEvents()
		{
			if (_level == null)
			{
				Logging.Error("Level is null when trying to register events.");
				return;
			}
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeStarted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeStarted, new Action<Challenge>(OnChallengeStarted));
			ChallengeEvents challengeEvents2 = _level.ChallengeEvents;
			challengeEvents2.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents2.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			UISelectionTarget mapSelectionTarget = _mapSelectionTarget;
			mapSelectionTarget.OnSelected = (Action<BaseEventData>)Delegate.Combine(mapSelectionTarget.OnSelected, new Action<BaseEventData>(OnMapTargetSelected));
			foreach (ChallengeAmbulanceEmergency ambulanceEmergencyChallenge in _ambulanceEmergencyChallenges)
			{
				RegisterEmergencyEvents(ambulanceEmergencyChallenge);
			}
		}

		private void RegisterEmergencyEvents(ChallengeAmbulanceEmergency emergency)
		{
			emergency.OnAmbulanceAssigned = (Action<Ambulance>)Delegate.Combine(emergency.OnAmbulanceAssigned, new Action<Ambulance>(OnAmbulanceAssigned));
			emergency.OnAmbulanceDepartHospital = (Action<Ambulance>)Delegate.Combine(emergency.OnAmbulanceDepartHospital, new Action<Ambulance>(OnAmbulanceDepartHospital));
			emergency.OnAmbulanceArriveEmergency = (Action<Ambulance>)Delegate.Combine(emergency.OnAmbulanceArriveEmergency, new Action<Ambulance>(OnAmbulanceArriveEmergency));
			emergency.OnAmbulanceArriveHospital = (Action<Ambulance>)Delegate.Combine(emergency.OnAmbulanceArriveHospital, new Action<Ambulance>(OnAmbulanceArriveHospital));
			emergency.OnAllPatientsCollected = (Action<ChallengeAmbulanceEmergency>)Delegate.Combine(emergency.OnAllPatientsCollected, new Action<ChallengeAmbulanceEmergency>(OnAllPatientsCollected));
			emergency.OnAllAmbulancesReturned = (Action<ChallengeAmbulanceEmergency>)Delegate.Combine(emergency.OnAllAmbulancesReturned, new Action<ChallengeAmbulanceEmergency>(OnAllAmbulancesReturned));
			emergency.OnAmbulanceUnassigned = (Action<Ambulance>)Delegate.Combine(emergency.OnAmbulanceUnassigned, new Action<Ambulance>(OnAmbulanceUnassigned));
		}

		private void UnregisterEvents()
		{
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeStarted = (Action<Challenge>)Delegate.Remove(challengeEvents.OnChallengeStarted, new Action<Challenge>(OnChallengeStarted));
			ChallengeEvents challengeEvents2 = _level.ChallengeEvents;
			challengeEvents2.OnChallengeCompleted = (Action<Challenge>)Delegate.Remove(challengeEvents2.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			_toggleHelp.onPrimaryDown.RemoveAllListeners();
			foreach (ChallengeAmbulanceEmergency ambulanceEmergencyChallenge in _ambulanceEmergencyChallenges)
			{
				ambulanceEmergencyChallenge.OnAmbulanceAssigned = (Action<Ambulance>)Delegate.Remove(ambulanceEmergencyChallenge.OnAmbulanceAssigned, new Action<Ambulance>(OnAmbulanceAssigned));
				ambulanceEmergencyChallenge.OnAmbulanceDepartHospital = (Action<Ambulance>)Delegate.Remove(ambulanceEmergencyChallenge.OnAmbulanceDepartHospital, new Action<Ambulance>(OnAmbulanceDepartHospital));
				ambulanceEmergencyChallenge.OnAmbulanceArriveEmergency = (Action<Ambulance>)Delegate.Remove(ambulanceEmergencyChallenge.OnAmbulanceArriveEmergency, new Action<Ambulance>(OnAmbulanceArriveEmergency));
				ambulanceEmergencyChallenge.OnAmbulanceArriveHospital = (Action<Ambulance>)Delegate.Remove(ambulanceEmergencyChallenge.OnAmbulanceArriveHospital, new Action<Ambulance>(OnAmbulanceArriveHospital));
				ambulanceEmergencyChallenge.OnAllPatientsCollected = (Action<ChallengeAmbulanceEmergency>)Delegate.Remove(ambulanceEmergencyChallenge.OnAllPatientsCollected, new Action<ChallengeAmbulanceEmergency>(OnAllPatientsCollected));
				ambulanceEmergencyChallenge.OnAllAmbulancesReturned = (Action<ChallengeAmbulanceEmergency>)Delegate.Remove(ambulanceEmergencyChallenge.OnAllAmbulancesReturned, new Action<ChallengeAmbulanceEmergency>(OnAllAmbulancesReturned));
				ambulanceEmergencyChallenge.OnAmbulanceUnassigned = (Action<Ambulance>)Delegate.Remove(ambulanceEmergencyChallenge.OnAmbulanceUnassigned, new Action<Ambulance>(OnAmbulanceUnassigned));
			}
			if (_isAnimatingOut)
			{
				RectTransformAnimator rectTransformAnimator = _rectTransformAnimator;
				rectTransformAnimator.OnAnimationFinished = (Action<RectTransform>)Delegate.Remove(rectTransformAnimator.OnAnimationFinished, new Action<RectTransform>(CloseAnimationFinished));
			}
		}

		private void Initialise()
		{
			if (_cameraLogic != null)
			{
				_cameraLogic.SetFixedTransform(_cameraLogic.CameraComponent.transform);
			}
			if (_ambulanceSelectionMenu != null)
			{
				_ambulanceSelectionMenu.Setup(_level, _config.AmbulanceSelectionMenuConfig.Instance, _challengeManager.PlayerAmbulanceDepartment, _rectTransformAnimator);
			}
			_helpPanel.SetActive(value: false);
			_toggleHelp.onPrimaryDown.AddListener(delegate
			{
				_helpPanel.SetActive(!_helpPanel.activeSelf);
			});
			RefreshMap();
			AnimateIn();
		}

		private void RefreshMap()
		{
			_dispatchMap.RemoveAllMapPins();
			SetupHospitalsOnMap();
			SetupEmergenciesOnMap();
			SetupEmergencyRoutesOnMap();
		}

		private void AnimateIn()
		{
			if (!(_rectTransformAnimator == null))
			{
				if (_config.OpenMapAnimationProperties?.Instance == null)
				{
					Logging.Error(LogChannels.GUI, "Missing Animation Data: Skipping Animation");
					base.transform.localPosition = _config.DisplayPosition;
				}
				else
				{
					AnimationProperties instance = _config.OpenMapAnimationProperties.Instance;
					_rectTransformAnimator.Animate(instance.Curve, (RectTransform)base.transform, _config.DisplayPosition, Quaternion.identity, instance.Duration, instance.InterruptOtherAnimations);
				}
			}
		}

		private void AnimateOut()
		{
			if (_rectTransformAnimator == null)
			{
				Logging.Error(LogChannels.GUI, "Missing Animation Script: Skipping Animation");
				CloseMenuImmediately();
				return;
			}
			if (_config.CloseMapAnimationProperties?.Instance == null)
			{
				Logging.Error(LogChannels.GUI, "Missing Animation Data: Skipping Animation");
				CloseMenuImmediately();
				return;
			}
			AnimationProperties instance = _config.CloseMapAnimationProperties.Instance;
			_rectTransformAnimator.Animate(instance.Curve, (RectTransform)base.transform, _config.HiddenPosition, Quaternion.identity, instance.Duration, instance.InterruptOtherAnimations);
			_isAnimatingOut = true;
			RectTransformAnimator rectTransformAnimator = _rectTransformAnimator;
			rectTransformAnimator.OnAnimationFinished = (Action<RectTransform>)Delegate.Combine(rectTransformAnimator.OnAnimationFinished, new Action<RectTransform>(CloseAnimationFinished));
		}

		public void CloseImmediately()
		{
			CloseAnimationFinished((RectTransform)base.transform);
		}

		public void CloseAnimationFinished(RectTransform target)
		{
			if (!(target != (RectTransform)base.transform))
			{
				RectTransformAnimator rectTransformAnimator = _rectTransformAnimator;
				rectTransformAnimator.OnAnimationFinished = (Action<RectTransform>)Delegate.Remove(rectTransformAnimator.OnAnimationFinished, new Action<RectTransform>(CloseAnimationFinished));
				_isAnimatingOut = false;
				if (_cameraLogic != null)
				{
					_cameraLogic.SetFixedTransform(null);
				}
				UnregisterEvents();
				_level.HospitalHUDManager.ResumeSuspendedMenus();
				base.CloseMenu();
			}
		}

		private void OnDestroy()
		{
			_dispatchMap.RemoveAllMapPins();
			UnregisterEvents();
		}

		private void OnLocalize()
		{
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				if (base.isActiveAndEnabled)
				{
					CloseMenu();
				}
				else
				{
					CloseImmediately();
				}
			}
		}

		private void OnChallengeStarted(Challenge challenge)
		{
			if (challenge is ChallengeAmbulanceEmergency challengeAmbulanceEmergency)
			{
				_ambulanceEmergencyChallenges.Add(challengeAmbulanceEmergency);
				RegisterEmergencyEvents(challengeAmbulanceEmergency);
				_dispatchMap.InstantiateEmergencyPin(challengeAmbulanceEmergency);
			}
		}

		private void OnChallengeCompleted(Challenge challenge)
		{
			if (challenge is ChallengeAmbulanceEmergency emergency)
			{
				_dispatchMap.RemoveEmergencyPin(emergency);
			}
		}

		private void OnAmbulanceAssigned(Ambulance ambulance)
		{
			if (ambulance.CurrentRoute != null)
			{
				_dispatchMap.PlaceAmbulanceRouteOnMap(ambulance);
			}
		}

		private void OnAmbulanceDepartHospital(Ambulance ambulance)
		{
			if (ambulance.CurrentRoute != null)
			{
				_dispatchMap.InstantiateAmbulancePin(ambulance);
			}
		}

		private void OnAmbulanceArriveEmergency(Ambulance ambulance)
		{
		}

		private void OnAmbulanceArriveHospital(Ambulance ambulance)
		{
			_dispatchMap.RemoveAmbulancePin(ambulance);
		}

		private void OnAllPatientsCollected(ChallengeAmbulanceEmergency emergency)
		{
			_dispatchMap.SetEmergencyPinActive(emergency, active: false);
		}

		private void OnAllAmbulancesReturned(ChallengeAmbulanceEmergency emergency)
		{
		}

		private void OnAmbulanceUnassigned(Ambulance ambulance)
		{
			_dispatchMap.RemoveRouteIfNoLongerInUse(ambulance);
		}

		private void SetupHospitalsOnMap()
		{
			_dispatchMap.InstantiateHospitalPin(_challengeManager.PlayerAmbulanceDepartment);
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _challengeManager.RivalAmbulanceDepartments)
			{
				_dispatchMap.InstantiateHospitalPin(rivalAmbulanceDepartment);
			}
		}

		private void SetupEmergenciesOnMap()
		{
			foreach (ChallengeAmbulanceEmergency item in _challengeManager.GetActiveChallengesOfType<ChallengeAmbulanceEmergency>())
			{
				if (!item.PatientsCollectedAndAmbulancesReturned)
				{
					_dispatchMap.InstantiateEmergencyPin(item);
				}
			}
		}

		private void SetupEmergencyRoutesOnMap()
		{
			List<Ambulance> list = new List<Ambulance>();
			list.AddRange(_challengeManager.PlayerAmbulanceDepartment.Ambulances);
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _challengeManager.RivalAmbulanceDepartments)
			{
				list.AddRange(rivalAmbulanceDepartment.Ambulances);
			}
			foreach (Ambulance item in list)
			{
				if (item.CurrentRoute != null)
				{
					_dispatchMap.PlaceAmbulanceRouteOnMap(item);
					if (item.IsOnWorldMap)
					{
						_dispatchMap.InstantiateAmbulancePin(item);
					}
				}
			}
		}
	}
}

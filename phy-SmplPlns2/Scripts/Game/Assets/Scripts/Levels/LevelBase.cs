using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Environment.Water;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.Discoverables;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.Maps;
using Assets.Scripts.Flight.Simulation;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Input;
using Assets.Scripts.UI;
using Jundroo.Common.Threading.Tasks;
using Jundroo.SocialPlatforms;
using Rewired;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Levels
{
	[Obfuscation(Exclude = true)]
	public abstract class LevelBase : MonoBehaviour
	{
		public string AircraftId;

		public bool AllowAutopilot;

		public bool AutoPilotDisablesSomeAchievements = true;

		public float InitialSpeed;

		public float InitialThrottle;

		public bool PositionAircraftOnGround = true;

		public bool ShowSignedAirspeedSpeed;

		public Transform StartPosition;

		public bool StartTimerWithThrottle = true;

		public float TimeOfDay;

		private const string _baseDescriptionData = "Visit https://www.SimplePlanes.com to check out all the amazing aircraft people have shared for others to download.";

		private const string _youtubeTags = "SimplePlanes, SimpleRockets, X-Plane, Jundroo, Flight Simulator, Radio Control";

		private Color _arrowDefaultColor;

		private MeshRenderer _arrowMeshRenderer;

		private float _arrowScale = 1f;

		private List<(AircraftScript Aircraft, AudioSource[] AudioSources)> _audioSources = new List<(AircraftScript, AudioSource[])>();

		[SerializeField]
		private bool _disableCountermeasures;

		private float _elapsedTime;

		private bool _firstFrame = true;

		private FlightSceneScript _flightScene;

		private bool _miniMapHiddenBecauseOfDialogs;

		private Dictionary<string, SingleSoundManager> _soundManagers;

		private DateTime? _startTime;

		private bool _timerPaused = true;

		private Transform _worldRigidbodiesContainer;

		public static LevelBase CurrentLevel { get; set; }

		public bool ApplicationQuitting { get; private set; }

		public Transform Arrow { get; set; }

		public Transform ArrowContainer { get; set; }

		public bool ArrowEnabled { get; set; }

		public Vector3? ArrowTarget { get; set; }

		public bool AutopilotEnabled
		{
			get
			{
				AiManagerScript instance = AiManagerScript.Instance;
				if ((object)instance == null)
				{
					return false;
				}
				return instance.PlayerAiScript?.InputOverrideEnabled == true;
			}
		}

		public GameObjectPool<Transform> BulletHitEffectPool { get; private set; }

		public virtual bool CanStartTimer
		{
			get
			{
				if (!Started)
				{
					return false;
				}
				if (StartTimerWithThrottle)
				{
					AircraftScript aircraftScript = _flightScene.LocalPlayer?.Aircraft;
					if (aircraftScript == null)
					{
						return false;
					}
					return aircraftScript.Controls.Throttle > 0f;
				}
				return true;
			}
		}

		public bool ChallengeAchievementsDisabled
		{
			get
			{
				if (AutoPilotDisablesSomeAchievements)
				{
					return AiManagerScript.Instance.HasPlayerBeenAiControllable;
				}
				return false;
			}
		}

		public bool DisableCountermeasures
		{
			get
			{
				return _disableCountermeasures;
			}
			set
			{
				_disableCountermeasures = value;
			}
		}

		public float ElapsedTime => _elapsedTime;

		public FlightUIScript FlightUI { get; set; }

		public virtual bool HideKneeboardOnStart => false;

		public LevelLoaderScript LevelLoader { get; private set; }

		public float LevelTime { get; set; }

		public MessageManager MessageManager => _flightScene.FlightUI.MessageManager;

		public Transform SceneRoot { get; set; }

		public float? SeaLevel => 0f;

		public bool ShowEnemyDamageMessages { get; set; }

		public bool Started { get; private set; }

		public virtual StartLocationData StartLocation
		{
			get
			{
				if (StartPosition != null)
				{
					return new StartLocationData
					{
						InitialVelocity = StartPosition.transform.forward * InitialSpeed,
						InitialThrottle = InitialThrottle,
						Position = StartPosition.transform.position,
						Rotation = StartPosition.transform.rotation.eulerAngles,
						StartOnGround = PositionAircraftOnGround,
						LocationType = StartLocationType.Temp
					};
				}
				if (SceneRoot != null)
				{
					MapStartLocation componentInChildren = SceneRoot.gameObject.GetComponentInChildren<MapStartLocation>();
					if (componentInChildren != null)
					{
						return new StartLocationData
						{
							InitialVelocity = componentInChildren.transform.forward * InitialSpeed,
							InitialThrottle = 0f,
							Position = Utility.ConvertFloatingOriginToAbsolutePosition(componentInChildren.transform.position),
							Rotation = componentInChildren.transform.rotation.eulerAngles,
							StartOnGround = componentInChildren.StartOnGround,
							LocationType = StartLocationType.Temp
						};
					}
				}
				return null;
			}
		}

		public Terrain Terrain { get; set; }

		public float TimeCountdown { get; set; }

		public bool TimeEnabled { get; set; }

		public WaterSplashManager WaterSplashManager { get; set; }

		public GameObject WaterVolume { get; set; }

		public WindGizmoScript WindGizmo { get; set; }

		public Transform WindGizmoContainer { get; set; }

		public bool WindGizmoEnabled { get; set; }

		public Transform WorldRigidbodiesContainer
		{
			get
			{
				return _worldRigidbodiesContainer;
			}
			set
			{
				_worldRigidbodiesContainer = value;
			}
		}

		protected AircraftScript PrimaryLocalPlayerAircraft { get; private set; }

		public LevelBase()
		{
			_soundManagers = new Dictionary<string, SingleSoundManager>();
			TimeCountdown = 0f;
		}

		public static string FormatTime(float time)
		{
			time = Mathf.Max(time, 0f);
			int num = (int)time / 60;
			int num2 = (int)time % 60;
			return num + ":" + num2.ToString("D2");
		}

		public static string GetInputName(string inputName, Pole axisContribution)
		{
			if (GameInputs.Instance.FindById(inputName) is GameInput gameInput)
			{
				bool flag = SocialExt.IsSteam && (SocialExt.Steam.IsRunningOnSteamDeck() || SocialExt.Steam.IsRunningInBigPicture());
				string text = (flag ? gameInput.GetControllerBindingText(axisContribution) : gameInput.GetKeyboardPrimaryBindingText(axisContribution));
				if (string.IsNullOrEmpty(text))
				{
					text = (flag ? gameInput.GetKeyboardPrimaryBindingText(axisContribution) : gameInput.GetControllerBindingText(axisContribution));
				}
				return PrettyPrintInput(text);
			}
			return "Not assigned";
		}

		public static List<StartLocationData> GetMapStartLocations()
		{
			if (CurrentLevel != null)
			{
				return (from x in CurrentLevel.gameObject.GetComponentsInChildren<MapStartLocation>(includeInactive: true)
					select new StartLocationData(x.LocationName, x.LocationName, AreaNameScript.FindClosestAreaName(x.transform.position, mustBeWithinArea: true) ?? "Unknown", StartLocationType.Default, Utility.ConvertFloatingOriginToAbsolutePosition(x.transform.position), x.transform.rotation.eulerAngles, x.transform.forward * x.InitialSpeed, x.StartOnGround)).ToList();
			}
			return new List<StartLocationData>();
		}

		public static string PrettyPrintInput(string inputName)
		{
			string text = inputName;
			Match match = new Regex("[a-z][A-Z]").Match(inputName);
			if (match.Success)
			{
				text = text.Insert(match.Index + 1, " ");
			}
			return text;
		}

		public float GetElevationAboveGroundLevel(Vector3 worldPosition)
		{
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(new Vector3(worldPosition.x, worldPosition.y + 1f, worldPosition.z), -Vector3.up, out hitInfo, float.PositiveInfinity, 9437200))
			{
				return worldPosition.y - hitInfo.point.y;
			}
			return GetElevationAboveSeaLevel(worldPosition.y + GameWorld.Instance.FloatingOriginOffset.y);
		}

		public float GetElevationAboveSeaLevel(float worldPosition)
		{
			return worldPosition - GameWorld.Instance.SeaLevel.GetValueOrDefault();
		}

		public StartLocationData GetInitialStartingLocation()
		{
			return StartLocation ?? FlightSceneScript.Instance.StartLocationManager.GetCurrentStartLocation();
		}

		public SingleSoundManager GetSingleSoundManager(string soundResource, AudioMixerGroup mixerGroup, bool isRemote = false, bool isFaded = true, float minDist = -1f, float maxDist = -1f)
		{
			if (!_soundManagers.TryGetValue(soundResource, out var value))
			{
				value = SingleSoundManager.Create(soundResource, base.transform, 0.8f, mixerGroup, isRemote, isFaded, minDist, maxDist);
				_soundManagers[soundResource] = value;
			}
			return value;
		}

		public virtual void OnPartEnterThermal(PartScript partScript, ThermalVolumeScript thermalVolumeScript)
		{
		}

		public virtual void OnPartEnterWater(PartScript part)
		{
		}

		public virtual void OnPartExitedWater(PartScript part)
		{
		}

		public void PauseTimer(bool timerPaused)
		{
			_timerPaused = timerPaused;
		}

		public void ResetTimer()
		{
			_startTime = null;
			_elapsedTime = 0f;
		}

		public void SetArrowTarget(Vector3? arrowTarget, float arrowScale = 1f, Color? color = null)
		{
			if (arrowTarget.HasValue)
			{
				ArrowEnabled = true;
			}
			else
			{
				ArrowEnabled = false;
			}
			if (color.HasValue)
			{
				_arrowMeshRenderer.material.color = color.Value;
			}
			else
			{
				_arrowMeshRenderer.material.color = _arrowDefaultColor;
			}
			ArrowTarget = arrowTarget;
			_arrowScale = arrowScale;
		}

		public void ShowLogMessage(string message, float time = 7f)
		{
			FlightSceneScript.Instance.FlightUI.ShowLogMessage(message, time);
		}

		public void ShowMessage(string message, float time = 7f)
		{
			FlightSceneScript.Instance.FlightUI.ShowMessage(message, time);
		}

		public void ToggleAutopilot()
		{
			if (AllowAutopilot)
			{
				AiManagerScript instance = AiManagerScript.Instance;
				if (instance.PlayerAiScript == null)
				{
					instance.SetPlayerAsAiControllable(null);
					instance.PlayerAiScript.UseWaterAvoidance = false;
				}
				else
				{
					instance.PlayerAiScript.InputOverrideEnabled = !instance.PlayerAiScript.InputOverrideEnabled;
				}
				bool inputOverrideEnabled = instance.PlayerAiScript.InputOverrideEnabled;
				string arg = (inputOverrideEnabled ? "enabled" : "disabled");
				string arg2 = string.Empty;
				string empty = string.Empty;
				if (inputOverrideEnabled)
				{
					arg2 = "Wing Leveling Mode";
				}
				FlightSceneScript.Instance.FlightUI.ShowMessage($"Autopilot {arg}. {arg2}{empty}");
			}
			else
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Autopilot disabled for current level.");
			}
		}

		protected virtual void Awake()
		{
			AudioManager.ClearTrackedSounds();
			PauseManager.Reset();
			LevelLoader = UnityEngine.Object.FindFirstObjectByType<LevelLoaderScript>();
			ApplicationQuitting = false;
			ShowEnemyDamageMessages = true;
			_flightScene = FlightSceneScript.Instance;
			_flightScene.FlightSceneLoaded += OnFlightSceneLoaded;
			_flightScene.PlayerAircraftLoaded += OnPlayerAircraftLoaded;
			_flightScene.PlayerAircraftUnloaded += OnPlayerAircraftUnloaded;
			OnAwake();
		}

		protected virtual void FirstFrameLateUpdate()
		{
		}

		protected virtual void FixedUpdate()
		{
			if (Started)
			{
				OnFixedUpdate();
			}
		}

		protected virtual void LateUpdate()
		{
			if (!Started)
			{
				return;
			}
			foreach (SingleSoundManager value in _soundManagers.Values)
			{
				value.NewFrame();
			}
			if (TimeEnabled)
			{
				if (!_startTime.HasValue)
				{
					if (CanStartTimer)
					{
						_startTime = DateTime.Now;
						_timerPaused = false;
					}
				}
				else
				{
					float elapsedTime = ElapsedTime;
					string text = null;
					text = ((!(TimeCountdown > 0f)) ? FormatTime(elapsedTime) : FormatTime(TimeCountdown - elapsedTime));
					FlightUI.SetTimeText(text);
				}
			}
			if (WindGizmoEnabled)
			{
				if (ArrowContainer.gameObject.activeSelf)
				{
					ArrowContainer.gameObject.SetActive(value: false);
				}
				float magnitude = FlightSceneScript.Instance.WindManager.WindVelocity.magnitude;
				if (magnitude > 0f)
				{
					WindGizmoContainer.gameObject.SetActive(value: true);
					WindGizmo.SetWindDirection(FlightSceneScript.Instance.WindManager.WindVelocity.normalized);
					WindGizmo.SetWindSpeed(magnitude);
				}
				else
				{
					WindGizmoContainer.gameObject.SetActive(value: false);
				}
			}
			else
			{
				if (WindGizmoContainer.gameObject.activeSelf)
				{
					WindGizmoContainer.gameObject.SetActive(value: false);
				}
				ArrowContainer.gameObject.SetActive(ArrowEnabled);
				if (ArrowEnabled && ArrowTarget.HasValue)
				{
					Vector3 normalized = (ArrowTarget.Value - PrimaryLocalPlayerAircraft.Position).normalized;
					Arrow.rotation = Quaternion.LookRotation(normalized);
					Arrow.localScale = new Vector3(_arrowScale, _arrowScale, _arrowScale);
				}
			}
			if (Game.Instance.UserInterface.AllowKeyboardInputs && GameInputs.Instance.Pause.GetButtonDownIfEnabled())
			{
				if (FlightUI.MultiplayerState == FlightUIScript.MultiplayerStateType.SinglePlayer)
				{
					StartCoroutine(TogglePauseStateAtEndOfFrame());
				}
				else
				{
					FlightUI.ShowMessage("Pause is disabled in multiplayer.");
				}
			}
			if (_firstFrame)
			{
				FirstFrameLateUpdate();
				_firstFrame = false;
			}
			OnLateUpdate();
		}

		protected virtual void OnApplicationQuit()
		{
			ApplicationQuitting = true;
		}

		protected virtual void OnAwake()
		{
		}

		protected virtual void OnDestroy()
		{
			_flightScene.FlightSceneLoaded -= OnFlightSceneLoaded;
			_flightScene.PlayerAircraftLoaded -= OnPlayerAircraftLoaded;
			_flightScene.PlayerAircraftUnloaded -= OnPlayerAircraftUnloaded;
		}

		protected virtual void OnFixedUpdate()
		{
		}

		protected virtual void OnFlightSceneLoaded()
		{
		}

		protected virtual void OnLateUpdate()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void Start()
		{
			PauseManager.RequestPauseChange(paused: false, userInitiated: false);
			Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickEnabled.Value = false;
			ArrowContainer.gameObject.SetActive(ArrowEnabled);
			_arrowMeshRenderer = Arrow.transform.Find("Mesh").GetComponent<MeshRenderer>();
			_arrowDefaultColor = _arrowMeshRenderer.material.color;
			BulletHitEffectPool = new GameObjectPool<Transform>(GameObjectPool.DefaultParent, 10, "Flight/Combat/BulletCollisionParticleSystem", 2f);
			FlightUI.ShowSignedAirspeedSpeeds = ShowSignedAirspeedSpeed;
			OnStart();
		}

		protected virtual void Update()
		{
			if (!Started)
			{
				return;
			}
			if (!PauseManager.Paused && !_timerPaused)
			{
				_elapsedTime += Time.deltaTime;
			}
			bool allowKeyboardInputs = Game.Instance.UserInterface.AllowKeyboardInputs;
			if (allowKeyboardInputs && GameInputs.Instance.ToggleAutopilot.GetButtonDownIfEnabled())
			{
				ToggleAutopilot();
			}
			if (GameInputs.Instance.ToggleSlowMotion.GetButtonDownIfEnabled() && allowKeyboardInputs)
			{
				if (FlightUI.MultiplayerState == FlightUIScript.MultiplayerStateType.SinglePlayer)
				{
					PauseManager.ToggleSlowMotion();
				}
				else
				{
					FlightUI.ShowMessage("Slow motion disabled in multiplayer.");
				}
			}
			if (GameInputs.Instance.ToggleFastForward.GetButtonDownIfEnabled() && allowKeyboardInputs)
			{
				if (FlightUI.MultiplayerState == FlightUIScript.MultiplayerStateType.SinglePlayer)
				{
					PauseManager.ToggleFastForward();
				}
				else
				{
					FlightUI.ShowMessage("Fast forward disabled in multiplayer.");
				}
			}
			if (allowKeyboardInputs && GameInputs.Instance.SelfDestruct.GetButtonDownIfEnabled())
			{
				Vector3 vector = PrimaryLocalPlayerAircraft.MainCockpit.transform.forward * -2f + PrimaryLocalPlayerAircraft.MainCockpit.transform.up * -1f;
				ExplosionScript.CreateExplosion(PrimaryLocalPlayerAircraft, PrimaryLocalPlayerAircraft.MainCockpit.transform.position + vector, PrimaryLocalPlayerAircraft.MainCockpit.Body.RigidBody.velocity, 100f);
			}
			if (!PauseManager.Paused)
			{
				LevelTime += Time.unscaledDeltaTime;
			}
			OnUpdate();
		}

		private async void OnFlightSceneLoaded(object sender, EventArgs e)
		{
			_ = 3;
			try
			{
				FlightScenePlayer localPlayer = await UniTaskEx.WaitUntilNotNull(() => FlightSceneScript.Instance.LocalPlayer);
				localPlayer.AircraftEntered += OnPrimaryLocalPlayerEnteredAircraft;
				localPlayer.AircraftExited += OnPrimaryLocalPlayerExitedAircraft;
				localPlayer.StartLocation = CurrentLevel.GetInitialStartingLocation();
				PositionResult positionResult = await PositionUtility.PositionAtLocation(localPlayer.StartLocation, localPlayer, allowRepositioning: true, floatOriginToLocation: true);
				if (positionResult == PositionResult.Occupied)
				{
					positionResult = await PositionUtility.PositionAtLocation(localPlayer.StartLocation, localPlayer, allowRepositioning: false, floatOriginToLocation: true);
				}
				if (positionResult != PositionResult.Success)
				{
					Debug.LogError($"Repositioning on flight scene load failed with result: {positionResult}");
					PositionUtility.ShowPositionResultErrorDialog(positionResult, localPlayer.StartLocation.DisplayName);
					positionResult = await PositionUtility.PositionAtLocation(FlightSceneScript.Instance.StartLocationManager.Locations.FirstOrDefault((StartLocationData x) => x.StartOnGround == true && !x.IsDynamicLocation), localPlayer, allowRepositioning: false, floatOriginToLocation: true);
					if (positionResult != PositionResult.Success)
					{
						Debug.LogError($"Final repositioning attempt on flight scene load failed with result: {positionResult}");
					}
				}
				localPlayer.SpawnAircraft();
				OnFlightSceneLoaded();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("An error occurred loading the flight scene.");
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "An error occurred loading the flight scene.");
			}
			Started = true;
		}

		private void OnPlayerAircraftLoaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			_audioSources.Add((e.Aircraft, e.Aircraft.transform.GetComponentsInChildren<AudioSource>(includeInactive: true)));
		}

		private void OnPlayerAircraftUnloaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			for (int num = _audioSources.Count - 1; num >= 0; num--)
			{
				AircraftScript item = _audioSources[num].Aircraft;
				bool flag = false;
				if (item == e.Aircraft)
				{
					flag = true;
				}
				else if (item == null)
				{
					flag = true;
					Debug.LogError("A dead aircraft was found in the list of player aircraft audio sources.");
				}
				if (flag)
				{
					_audioSources.RemoveAt(num);
				}
			}
		}

		private void OnPrimaryLocalPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			PrimaryLocalPlayerAircraft = e.Aircraft;
		}

		private void OnPrimaryLocalPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			PrimaryLocalPlayerAircraft = null;
		}

		private IEnumerator TogglePauseStateAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			PauseManager.RequestPauseChange(!PauseManager.Paused, userInitiated: true);
		}
	}
}

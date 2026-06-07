using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Assets.Scripts.XR;
using Beautify.Universal;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest;
using WaveHarmonic.Crest.Internal;

namespace Assets.Scripts.Flight.Cameras
{
	[Obfuscation(Exclude = true)]
	public class CameraManagerScript : MonoBehaviour, IInputHandler
	{
		public delegate void SwitchedToNewViewModeHandler(CameraController oldController, CameraController newController);

		public class FovChangedEventArgs : EventArgs
		{
			public CameraManagerScript CameraManager { get; }

			public float NewFov { get; }

			public FovChangedEventArgs(CameraManagerScript cameraManager, float newFov)
			{
				CameraManager = cameraManager;
				NewFov = newFov;
			}
		}

		public class DopplerFixChangedEventArgs : EventArgs
		{
			public bool Enabled { get; }

			public DopplerFixChangedEventArgs(bool enabled)
			{
				Enabled = enabled;
			}
		}

		public const float InteractablePartTooltipDelay = 0.5f;

		private const float AutoSwitchAutoDisableTime = 1f;

		private const float AutoSwitchCameraCooldownTime = 30f;

		private static readonly WaitForFixedUpdate _WaitForFixedUpdate = new WaitForFixedUpdate();

		private AircraftScript _aircraft;

		private AudioLowPassFilter _audioLPF;

		private AudioSource _audioShore;

		private AudioSource _audioUnderwater;

		private AudioSource _audioWaves;

		private bool _autoSwitchCameraEnabled;

		private float _autoSwitchCameraEnabledTimeEnabled;

		private float _autoSwitchCameraLastTime = float.MinValue;

		private List<CameraController> _cameraControllers = new List<CameraController>();

		private Dictionary<int, IInteractablePartModifier> _capturedInputModifiers;

		private ChaseCameraController _chaseCamera;

		private CockpitCameraController _cockpitCamera;

		private CameraController _currentCameraController;

		private List<CameraController> _customCameras = new List<CameraController>();

		private CameraController _defaultController;

		[SerializeField]
		private AudioListenerVelocityProxy _dopplerFix;

		[SerializeField]
		private Vector3 _firstPersonShadowCascades = new Vector3(0.0025f, 0.02f, 0.15f);

		[SerializeField]
		private Volume _globalVolume;

		private IInteractablePartModifier _hoveredModifier;

		private float _hoveredModifierElapsedTime;

		private bool _isPrimaryLocalPlayerRepositioning;

		private CameraController _killCamPreviousController;

		[SerializeField]
		private Camera _mainCamera;

		private int _mainCameraCullingMask;

		private int? _mainCameraXRCullingMask;

		private CameraController _orbitCamera;

		[SerializeField]
		private Camera _overlayCamera;

		private List<IOverlayCameraRequirement> _overlayCameraRequirements;

		private PartTooltipScript _partTooltip;

		private Coroutine _postFixedUpdateCoroutine;

		private SortedList<int, CameraController> _potentialCockpitCameras;

		private CameraController _repositionCamera;

		private int _updateFrameCount = 1;

		public static CameraManagerScript Instance { get; private set; }

		public static bool PreventZoom { get; set; }

		public Transform CameraFocalPosition { get; set; }

		public Transform CameraPosition { get; set; }

		public Transform CameraTransform { get; private set; }

		public ChaseCameraController ChaseCamera => _chaseCamera;

		public CameraController Controller => _currentCameraController;

		public float CurrentCameraFieldOfView
		{
			get
			{
				if (_currentCameraController is FirstPersonCharacterCameraController)
				{
					return Game.Instance.Settings.Gameplay.Camera.FieldOfViewCharacterFPV;
				}
				return Game.Instance.Settings.Gameplay.Camera.FieldOfView;
			}
		}

		public Vector3 FirstPersonShadowCascades => _firstPersonShadowCascades;

		public bool IsKillCam => _currentCameraController is KillCameraController;

		public Camera MainCamera => _mainCamera;

		public float SharedCameraDistance { get; set; }

		public Quaternion SharedCameraRotation { get; set; }

		public XRCameraManagerScript XRCameraManager { get; private set; }

		public event EventHandler<EventArgs> DopplerFixChanged;

		public event EventHandler<EventArgs> FovChanged;

		public event SwitchedToNewViewModeHandler SwitchedToNewViewMode;

		public event SwitchedToNewViewModeHandler SwitchingToNewViewMode;

		public void AddCamera(CameraController tournamentCamera)
		{
			_cameraControllers.Add(tournamentCamera);
		}

		public void AddYawToCurrentCamera(float yaw)
		{
			SharedCameraRotation *= Quaternion.AngleAxis(yaw, Vector3.up);
			_currentCameraController.AddYaw(yaw);
			_currentCameraController.Update(1);
		}

		public void AircraftRepositioned()
		{
			_currentCameraController?.AircraftRepositioned();
		}

		public void AllowAutoSwitch()
		{
			_autoSwitchCameraEnabled = base.enabled;
			_autoSwitchCameraEnabledTimeEnabled = Time.time;
		}

		public void EnableTargetingPodEffect(bool enable)
		{
			if (_globalVolume.profile.TryGet<Beautify.Universal.Beautify>(out var component))
			{
				component.tintColor.overrideState = enable;
				component.tintColor.value = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
				component.tonemapBrightnessPost.overrideState = enable;
				component.tonemapBrightnessPost.value = 1f;
			}
			else
			{
				Debug.Log("Cannot find beautify volume component");
			}
		}

		public void EnterKillCam(PartScript part)
		{
			_killCamPreviousController = _currentCameraController;
			SelectCamera(new KillCameraController(this, part, centerOnRigidBody: true));
		}

		public void ExitKillCam()
		{
			if (IsKillCam)
			{
				if (_cameraControllers.Contains(_killCamPreviousController))
				{
					SelectCamera(_killCamPreviousController);
				}
				else
				{
					ForceCockpitView();
				}
			}
		}

		public void ExitKillCam(float delay)
		{
			StartCoroutine(ExitKillCamDelayed(delay));
		}

		public void ForceCockpitView(bool saveAsDefault = true, bool displayMessage = false)
		{
			CameraController currentCockpitCamera = GetCurrentCockpitCamera();
			SelectCamera(currentCockpitCamera ?? _defaultController, saveAsDefault, displayMessage);
		}

		public IInteractablePartModifier GetInteractablePart(Vector2 screenPosition, int raycastDistance = 1000)
		{
			Ray ray = MainCamera.ScreenPointToRay(screenPosition);
			int layerMask = 65536;
			if (Physics.Raycast(ray, out var hitInfo, raycastDistance, layerMask, QueryTriggerInteraction.Collide))
			{
				return hitInfo.collider?.GetComponentInParent<IInteractablePartModifier>();
			}
			return null;
		}

		public void HandleInput(InputEvent e)
		{
			IInteractablePartModifier interactablePart = GetInteractablePart(e.Position);
			if (e.InputButton == InputButton.Primary && _capturedInputModifiers.TryGetValue(e.InputButtonIndex, out var value))
			{
				if (!value.HandleInput(e, value == interactablePart) || e.InputState == InputState.End)
				{
					_capturedInputModifiers.Remove(e.InputButtonIndex);
				}
				return;
			}
			bool flag = false;
			if (interactablePart != null && !interactablePart.InteractionDisabled && e.InputState == InputState.Begin && e.InputButton == InputButton.Primary && !_capturedInputModifiers.ContainsValue(interactablePart) && interactablePart.HandleInput(e, isPartStillTarget: true))
			{
				_capturedInputModifiers[e.InputButtonIndex] = interactablePart;
				flag = true;
				SetHoveredModifier(null);
				_hoveredModifierElapsedTime = 0f;
			}
			if (!flag)
			{
				_currentCameraController?.HandleInput(e);
			}
		}

		public void HandlePinch(PinchEvent e)
		{
			if (!PreventZoom && _capturedInputModifiers.Count == 0)
			{
				_currentCameraController?.HandlePinch(e);
			}
		}

		public void HandleScroll(MouseScrollEvent e)
		{
			if (!PreventZoom)
			{
				_currentCameraController?.HandleScroll(e);
			}
		}

		public void OnPrimaryLocalPlayerRepositionBegin()
		{
			SelectCamera(_repositionCamera, saveAsDefault: false);
			UpdateCamera();
			_isPrimaryLocalPlayerRepositioning = true;
		}

		public void OnPrimaryLocalPlayerRepositionEnd()
		{
			_isPrimaryLocalPlayerRepositioning = false;
			_currentCameraController = null;
			RestoreDefaultCamera();
			if (_currentCameraController == null)
			{
				SelectCamera(_defaultController, saveAsDefault: false);
			}
		}

		public CameraController RegisterCustomCameraVantage(CameraVantageScript cameraVantageScript)
		{
			CameraController cameraController = null;
			if (cameraVantageScript.ViewMode == ViewMode.FirstPerson)
			{
				CockpitSoundScript component = cameraVantageScript.gameObject.GetComponent<CockpitSoundScript>();
				cameraController = new FirstPersonCameraController(this, cameraVantageScript, component);
			}
			else if (cameraVantageScript.ViewMode == ViewMode.Chase)
			{
				cameraController = new ChaseCameraController(this, centerOnRigidBody: false, 10f, cameraVantageScript);
			}
			else if (cameraVantageScript.ViewMode == ViewMode.Orbit)
			{
				cameraController = new OrbitCameraController(this, centerOnRigidBody: false, cameraVantageScript);
			}
			else if (cameraVantageScript.ViewMode == ViewMode.FlyBy)
			{
				cameraController = new FlyByCameraController(this, cameraVantageScript);
			}
			else if (cameraVantageScript.ViewMode == ViewMode.TargetingPod)
			{
				cameraController = new TargetingPodCameraController(this, cameraVantageScript);
			}
			if (cameraController != null)
			{
				_cameraControllers.Add(cameraController);
				_customCameras.Add(cameraController);
				UpdateCustomCameraNames();
				int i = cameraVantageScript.Data.CockpitCameraPriority;
				if (i >= 0)
				{
					for (; _potentialCockpitCameras.ContainsKey(i); i++)
					{
					}
					_potentialCockpitCameras.Add(i, cameraController);
				}
			}
			return cameraController;
		}

		public void RegisterOverlayCameraRequirement(IOverlayCameraRequirement requirement)
		{
			if (!_overlayCameraRequirements.Contains(requirement))
			{
				_overlayCameraRequirements.Add(requirement);
				UpdateOverlayCamera();
			}
		}

		public void RestoreDefaultCamera()
		{
			string text = PlayerPrefs.GetString(GameInputs.Instance.NextView.Id);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text == "Cockpit View")
			{
				ForceCockpitView();
				return;
			}
			foreach (CameraController cameraController in _cameraControllers)
			{
				if (cameraController.Name == text)
				{
					SelectCamera(cameraController);
					break;
				}
			}
		}

		public void SelectCameraType<T>() where T : CameraController
		{
			if (typeof(T) == typeof(CockpitCameraController))
			{
				ForceCockpitView(saveAsDefault: false);
				return;
			}
			foreach (CameraController cameraController in _cameraControllers)
			{
				if (cameraController.GetType() == typeof(T))
				{
					SelectCamera(cameraController, saveAsDefault: false);
					break;
				}
			}
		}

		public void SetCameraFov(float fov)
		{
			if (!Game.Instance.XRDeviceManager.HmdActive && MainCamera.fieldOfView != fov)
			{
				MainCamera.fieldOfView = fov;
				this.FovChanged?.Invoke(this, new FovChangedEventArgs(this, fov));
			}
		}

		public void SetEnabled(bool enabled)
		{
			base.gameObject.SetActive(enabled);
		}

		public void SwitchToCamera(CameraController cameraController)
		{
			SelectCamera(cameraController, saveAsDefault: false, displayMessage: true);
		}

		public void SwitchToDefaultCamera()
		{
			SelectCamera(_defaultController, saveAsDefault: false, displayMessage: true);
		}

		public void SwitchToNextViewMode(bool displayMessage, bool saveAsDefault)
		{
			AdvanceToNextCamera(displayMessage, saveAsDefault, 1);
		}

		public void SwitchToPreviousViewMode()
		{
			AdvanceToNextCamera(displayMessage: true, saveAsDefault: true, -1);
		}

		public void SwitchToViewMode(string viewName, bool displayMessage, bool saveAsDefault)
		{
			if (viewName == "Cockpit View")
			{
				ForceCockpitView(saveAsDefault, displayMessage);
				return;
			}
			CameraController cameraController = _currentCameraController;
			do
			{
				int num = GetCameraControllerIndex(cameraController) + 1;
				num %= _cameraControllers.Count;
				cameraController = _cameraControllers[num];
			}
			while (cameraController.Name != viewName && cameraController != _currentCameraController);
			if (cameraController.Name == viewName && cameraController.IsActive)
			{
				SelectCamera(cameraController, saveAsDefault, displayMessage);
			}
		}

		public void UnregisterCustomCameraVantage(CameraController cameraController)
		{
			_cameraControllers.Remove(cameraController);
			_customCameras.Remove(cameraController);
			int num = _potentialCockpitCameras.IndexOfValue(cameraController);
			if (num >= 0)
			{
				_potentialCockpitCameras.RemoveAt(num);
			}
		}

		public void UnregisterOverlayCameraRequirement(IOverlayCameraRequirement requirement)
		{
			if (_overlayCameraRequirements.Remove(requirement))
			{
				UpdateOverlayCamera();
			}
		}

		protected virtual void Awake()
		{
			SetCameraFov(CurrentCameraFieldOfView);
			CameraTransform = base.transform;
			XRCameraManager = GetComponent<XRCameraManagerScript>();
			XRCameraManager.OnXrCamerasEnabledChanged += OnXRStateChanged;
			_mainCameraCullingMask = _mainCamera.cullingMask;
			_mainCamera.cullingMask = 0;
			Camera camera = XRCameraManager?.MainCamera;
			if (camera != null)
			{
				_mainCameraXRCullingMask = camera.cullingMask;
				camera.cullingMask = 0;
			}
			StartCoroutine(DelayedCameraEnable());
			Instance = this;
			GameWorld.Instance.FloatingOriginChanged += FloatingOriginChanged;
			GameState.Instance.MapLocationChanged += MapLocationChanged;
			AudioListener[] componentsInChildren = GetComponentsInChildren<AudioListener>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].velocityUpdateMode = AudioVelocityUpdateMode.Fixed;
			}
			_partTooltip = UnityEngine.Object.Instantiate(Resources.Load<PartTooltipScript>("Flight/Gui/InteractablePartTooltip"));
			_partTooltip.name = "PartTooltip_Mouse";
			_partTooltip.Initialize(isXRTooltip: false);
			_potentialCockpitCameras = new SortedList<int, CameraController>();
			_capturedInputModifiers = new Dictionary<int, IInteractablePartModifier>();
			_overlayCameraRequirements = new List<IOverlayCameraRequirement>();
			_repositionCamera = new OrbitCameraController(this, centerOnRigidBody: false, () => FlightSceneScript.Instance.LocalPlayer?.RepositionTarget, () => (IRigidBody)null);
			ReinitializeCameras(null, null);
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded += OnPlayerLoaded;
				instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
				instance.RaiseLocalPlayerLoaded(OnPlayerLoaded);
				instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
				_audioShore = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_audioShore, AudioStore.ShoreAmbience, AudioStore.ShoreAmbience.Resource, loop: true, autoPlay: true, 0f);
				_audioShore.volume = 0f;
				_audioShore.Play();
				_audioUnderwater = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_audioUnderwater, AudioStore.UnderwaterAmbience, AudioStore.UnderwaterAmbience.Resource, loop: true, autoPlay: true, 0f);
				_audioUnderwater.volume = 0f;
				_audioUnderwater.Play();
				_audioWaves = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_audioWaves, AudioStore.WaterAmbience, AudioStore.WaterAmbience.Resource, loop: true, autoPlay: true, 0f);
				_audioWaves.volume = 0f;
				_audioWaves.Play();
				_audioLPF = base.gameObject.AddComponent<AudioLowPassFilter>();
			}
		}

		protected virtual void LateUpdate()
		{
			if (_autoSwitchCameraEnabled && (object)_aircraft != null && Time.time >= _autoSwitchCameraLastTime + 30f)
			{
				Vector3 vector = _aircraft.OrientedCenterOfMassRigidBodies.InverseTransformDirection(_currentCameraController.AngularVelocity);
				if (new Vector3(vector.x, vector.y, 0f).magnitude > 2f)
				{
					AutoSwitchCamera();
				}
			}
			if (_autoSwitchCameraEnabled && Time.time >= _autoSwitchCameraEnabledTimeEnabled + 1f)
			{
				_autoSwitchCameraEnabled = false;
			}
			UpdateCamera();
			_currentCameraController.LateUpdate();
			if (ManagerBehaviour<WaterRenderer>.Instance != null)
			{
				float viewerHeightAboveWater = ManagerBehaviour<WaterRenderer>.Instance.ViewerHeightAboveWater;
				float viewerDistanceToShoreline = ManagerBehaviour<WaterRenderer>.Instance.ViewerDistanceToShoreline;
				_audioUnderwater.volume = ((viewerHeightAboveWater < 0f) ? 0.5f : 0f);
				float b = 0.5f * Mathf.Clamp01(100f / (Mathf.Abs(viewerDistanceToShoreline) * viewerHeightAboveWater));
				_audioShore.volume = Mathf.Lerp(_audioShore.volume, b, Time.deltaTime);
				b = 0.5f * Mathf.Clamp01(2f * Mathf.Clamp01(viewerDistanceToShoreline / 50f) / viewerHeightAboveWater);
				_audioWaves.volume = Mathf.Lerp(_audioWaves.volume, b, Time.deltaTime);
				AudioMixing.IsUnderwater = viewerHeightAboveWater < 0f;
				b = new Vector3(0f, viewerHeightAboveWater, Mathf.Max(0f, 0f - viewerDistanceToShoreline)).magnitude;
				b = ((viewerHeightAboveWater < 0f) ? 22000f : (1300000f / (b + 60f)));
				_audioLPF.cutoffFrequency = b;
			}
			_updateFrameCount = 1;
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (_capturedInputModifiers.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, IInteractablePartModifier> capturedInputModifier in _capturedInputModifiers)
			{
				InputEvent e = new InputEvent
				{
					InputButton = InputButton.Primary,
					InputButtonIndex = capturedInputModifier.Key,
					InputState = InputState.End
				};
				capturedInputModifier.Value.HandleInput(e, isPartStillTarget: false);
			}
			_capturedInputModifiers.Clear();
		}

		protected virtual void OnDestroy()
		{
			GameWorld.Instance.FloatingOriginChanged -= FloatingOriginChanged;
			GameState.Instance.MapLocationChanged -= MapLocationChanged;
			if (XRCameraManager != null)
			{
				XRCameraManager.OnXrCamerasEnabledChanged -= OnXRStateChanged;
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
			foreach (CameraController cameraController in _cameraControllers)
			{
				cameraController.OnDestroy();
			}
			Instance = null;
		}

		protected virtual void OnDisable()
		{
			if (_postFixedUpdateCoroutine != null)
			{
				StopCoroutine(_postFixedUpdateCoroutine);
				_postFixedUpdateCoroutine = null;
			}
			Game.Instance.Settings.Gameplay.Camera.FieldOfView.Changed -= OnFieldOfViewSettingChanged;
			Game.Instance.Settings.Gameplay.Camera.FieldOfViewCharacterFPV.Changed -= OnFieldOfViewSettingChanged;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		protected virtual void OnEnable()
		{
			if (_postFixedUpdateCoroutine != null)
			{
				StopCoroutine(_postFixedUpdateCoroutine);
				_postFixedUpdateCoroutine = null;
			}
			_postFixedUpdateCoroutine = StartCoroutine(PostFixedUpdate());
			_currentCameraController?.UpdateCursor();
			Game.Instance.Settings.Gameplay.Camera.FieldOfView.Changed += OnFieldOfViewSettingChanged;
			Game.Instance.Settings.Gameplay.Camera.FieldOfViewCharacterFPV.Changed += OnFieldOfViewSettingChanged;
		}

		protected virtual IEnumerator PostFixedUpdate()
		{
			while (true)
			{
				yield return _WaitForFixedUpdate;
				UpdateCamera();
			}
		}

		protected virtual void Start()
		{
			PreventZoom = false;
			CameraFocalPosition = base.transform.parent.Find("CameraTarget");
			SharedCameraRotation = Quaternion.Euler(15f, -70f, 0f);
			SharedCameraDistance = 20f;
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				GameInputs instance = GameInputs.Instance;
				if (instance.NextView.GetButtonDownIfEnabled())
				{
					SwitchToNextViewMode(displayMessage: true, saveAsDefault: true);
				}
				else if (instance.PreviousView.GetButtonDownIfEnabled())
				{
					SwitchToPreviousViewMode();
				}
				else if (instance.CockpitView.GetButtonDownIfEnabled())
				{
					SwitchToViewMode("Cockpit View", displayMessage: true, saveAsDefault: true);
				}
				else if (instance.ChaseView.GetButtonDownIfEnabled())
				{
					SwitchToViewMode("Chase View", displayMessage: true, saveAsDefault: true);
				}
				else if (instance.OrbitView.GetButtonDownIfEnabled())
				{
					SwitchToViewMode("Orbit View", displayMessage: true, saveAsDefault: true);
				}
				else if (instance.FlybyView.GetButtonDownIfEnabled())
				{
					SwitchToViewMode("Fly-By View", displayMessage: true, saveAsDefault: true);
				}
				else if (instance.CustomCamera1.GetButtonDownIfEnabled())
				{
					SwitchToCustomCameraByIndex(0);
				}
				else if (instance.CustomCamera2.GetButtonDownIfEnabled())
				{
					SwitchToCustomCameraByIndex(1);
				}
				else if (instance.CustomCamera3.GetButtonDownIfEnabled())
				{
					SwitchToCustomCameraByIndex(2);
				}
				else if (instance.CustomCamera4.GetButtonDownIfEnabled())
				{
					SwitchToCustomCameraByIndex(3);
				}
			}
			if (XRCameraManager.XrCamerasEnabled)
			{
				Camera planeCamera = XRCameraManager.PlaneCamera;
				bool activeSelf = planeCamera.gameObject.activeSelf;
				if (!_currentCameraController.RequiresPlaneCamera)
				{
					float num = GameWorld.Instance.SeaLevel.GetValueOrDefault() - GameWorld.Instance.FloatingOriginOffset.y;
					if (base.transform.position.y < num + 10f && GameWorld.Instance.SeaLevel.HasValue)
					{
						planeCamera.gameObject.SetActive(value: false);
					}
					else if (!activeSelf)
					{
						planeCamera.gameObject.SetActive(value: true);
					}
				}
				else if (!activeSelf)
				{
					planeCamera.gameObject.SetActive(value: true);
				}
			}
			UpdateOverlayCamera();
			UpdateTooltip();
		}

		private void AdvanceToNextCamera(bool displayMessage, bool saveAsDefault, int direction)
		{
			if (_cameraControllers.Count == 0)
			{
				SelectCamera(null, saveAsDefault: false);
				return;
			}
			if (IsKillCam)
			{
				ExitKillCam();
				return;
			}
			CameraController cameraController = _currentCameraController;
			GetCurrentCockpitCamera();
			do
			{
				int num = GetCameraControllerIndex(cameraController) + direction;
				if (num < 0)
				{
					num = _cameraControllers.Count - 1;
				}
				else if (num >= _cameraControllers.Count)
				{
					num = 0;
				}
				cameraController = _cameraControllers[num];
			}
			while (!cameraController.IsActive && cameraController != _currentCameraController);
			SelectCamera(cameraController, saveAsDefault: true, displayMessage: true);
		}

		private void AutoSwitchCamera()
		{
			FlightSceneScript.Instance.FlightUI.ShowMessage("Orbit View (Auto Switch)", 1f);
			SelectCamera(_orbitCamera ?? _defaultController, saveAsDefault: false);
			_autoSwitchCameraLastTime = Time.time;
		}

		private IEnumerator DelayedCameraEnable()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			_mainCamera.cullingMask = _mainCameraCullingMask;
			if (_mainCameraXRCullingMask.HasValue)
			{
				XRCameraManager.MainCamera.cullingMask = _mainCameraXRCullingMask.Value;
			}
		}

		private IEnumerator ExitKillCamDelayed(float delay)
		{
			yield return new WaitForSeconds(delay * PauseManager.SlowMotionSpeed);
			ExitKillCam();
		}

		private void FloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			Vector3 vector = e.OldFloatingOriginOffset - e.NewFloatingOriginOffset;
			base.transform.position += vector;
			CameraFocalPosition.position += vector;
		}

		private int GetCameraControllerIndex(CameraController cameraController)
		{
			for (int i = 0; i < _cameraControllers.Count; i++)
			{
				if (cameraController == _cameraControllers[i])
				{
					return i;
				}
			}
			return 0;
		}

		private CameraController GetCurrentCockpitCamera()
		{
			if (_cockpitCamera?.Cockpit?.HasCamera == true)
			{
				return _cockpitCamera;
			}
			foreach (CameraController value in _potentialCockpitCameras.Values)
			{
				if (value.IsActive && (value is FirstPersonCharacterCameraController || (value.CameraVantage != null && value.CameraVantage.isActiveAndEnabled)))
				{
					return value;
				}
			}
			return null;
		}

		private void MapLocationChanged(object sender, MapLocationChangedEventArgs e)
		{
			if (_currentCameraController != null)
			{
				_currentCameraController.Update(1);
			}
		}

		private void OnFieldOfViewSettingChanged(object sender, SettingChangedEventArgs<float> e)
		{
			SetCameraFov(CurrentCameraFieldOfView);
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				e.Player.IKPostUpdate += OnPlayerSeatedIKPostUpdate;
				ReinitializeCameras(e.Player, e.Aircraft);
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				e.Player.IKPostUpdate -= OnPlayerSeatedIKPostUpdate;
				ReinitializeCameras(e.Player, null);
			}
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				ReinitializeCameras(e.Player, null);
			}
		}

		private void OnPlayerSeatedIKPostUpdate(object sender, FlightScenePlayerEventArgs e)
		{
			if (_currentCameraController is FirstPersonCharacterCameraController && e.Player.CurrentIKSeat != null && e.Player.CurrentIKSeat.Data.FPVTracking)
			{
				UpdateCamera();
			}
		}

		private void OnXRStateChanged(bool xrEnabled)
		{
			if (xrEnabled)
			{
				_currentCameraController?.OnXREnabled();
			}
			else
			{
				_currentCameraController?.OnXRDisabled();
			}
		}

		private void ReinitializeCameras(FlightScenePlayer player, AircraftScript aircraft)
		{
			if (this == null)
			{
				return;
			}
			SelectCamera(null, saveAsDefault: false);
			foreach (CameraController cameraController in _cameraControllers)
			{
				cameraController.OnDestroy();
			}
			_cameraControllers.Clear();
			_customCameras.Clear();
			_potentialCockpitCameras.Clear();
			_defaultController = null;
			_cockpitCamera = null;
			_chaseCamera = null;
			_orbitCamera = null;
			_aircraft = aircraft;
			if (player == null || player.IsUnloaded)
			{
				_orbitCamera = new OrbitCameraController(this, centerOnRigidBody: false, () => CameraFocalPosition, () => (IRigidBody)null);
				_cameraControllers.Add(_orbitCamera);
				_defaultController = _orbitCamera;
			}
			else if (aircraft == null)
			{
				_orbitCamera = new OrbitCameraController(this, centerOnRigidBody: false, () => player.AvatarCameraTarget, () => (IRigidBody)null);
				_cameraControllers.Add(_orbitCamera);
				_defaultController = _orbitCamera;
				base.transform.forward = player.AvatarCameraTarget.transform.forward;
				FirstPersonCharacterCameraController firstPersonCharacterCameraController = new FirstPersonCharacterCameraController(this, centerOnRigidBody: false, () => player.AvatarFpvCameraTarget, () => (IRigidBody)null);
				firstPersonCharacterCameraController.MouseLook = true;
				_cameraControllers.Add(firstPersonCharacterCameraController);
				_potentialCockpitCameras.Add(5, firstPersonCharacterCameraController);
			}
			else
			{
				PartScript mainCockpit = aircraft.MainCockpit;
				_cockpitCamera = new CockpitCameraController(this, mainCockpit);
				_chaseCamera = new ChaseCameraController(this, centerOnRigidBody: true, mainCockpit.Aircraft.Aircraft.Size.z * 1.2f, mainCockpit);
				_orbitCamera = new OrbitCameraController(this, centerOnRigidBody: true, mainCockpit);
				FlyByCameraController item = new FlyByCameraController(this, mainCockpit);
				if (_cockpitCamera.Cockpit.HasCamera)
				{
					_cameraControllers.Add(_cockpitCamera);
				}
				else
				{
					_cockpitCamera = null;
				}
				_cameraControllers.Add(_chaseCamera);
				_cameraControllers.Add(_orbitCamera);
				_cameraControllers.Add(item);
				if (aircraft.MainSeat?.GetModifier<SeatScript>() != null)
				{
					CockpitSoundScript modifier = aircraft.MainSeat.GetModifier<CockpitSoundScript>();
					FirstPersonCharacterCameraController firstPersonCharacterCameraController2 = new FirstPersonCharacterCameraController(this, centerOnRigidBody: false, () => player.AvatarFpvCameraTarget, () => (IRigidBody)null, cockpitMode: true, modifier);
					_cameraControllers.Add(firstPersonCharacterCameraController2);
					_potentialCockpitCameras.Add(5, firstPersonCharacterCameraController2);
				}
				bool flag = XRCameraManager.XrCamerasEnabled || Game.Instance.Device.IsVRExclusiveBuild;
				_defaultController = (flag ? (_cockpitCamera ?? _orbitCamera) : _chaseCamera);
				base.transform.forward = aircraft.OrientedCenterOfMassRigidBodies.forward;
			}
			string text = PlayerPrefs.GetString(GameInputs.Instance.NextView.Id);
			if (!string.IsNullOrEmpty(text))
			{
				if (text == "Cockpit View")
				{
					ForceCockpitView();
				}
				else
				{
					foreach (CameraController cameraController2 in _cameraControllers)
					{
						if (cameraController2.Name == text)
						{
							SelectCamera(cameraController2);
							break;
						}
					}
				}
			}
			if (_currentCameraController == null)
			{
				SelectCamera(_defaultController, saveAsDefault: false);
			}
		}

		private void SelectCamera(CameraController cameraController, bool saveAsDefault = true, bool displayMessage = false)
		{
			if (_isPrimaryLocalPlayerRepositioning || _currentCameraController == cameraController)
			{
				return;
			}
			CameraController currentCameraController = _currentCameraController;
			this.SwitchingToNewViewMode?.Invoke(currentCameraController, cameraController);
			if (_currentCameraController != null)
			{
				_currentCameraController.IsSelected = false;
				_currentCameraController.OnDeselected();
			}
			_currentCameraController = cameraController;
			SetCameraFov(CurrentCameraFieldOfView);
			if (_currentCameraController != null)
			{
				_currentCameraController.IsSelected = true;
				_currentCameraController.OnSelected();
				AudioMixing.IsInCockpit = _currentCameraController.IsCockpitAudio;
				if (_dopplerFix.enabled != cameraController.RequiresDopplerFix)
				{
					_dopplerFix.enabled = cameraController.RequiresDopplerFix;
					this.DopplerFixChanged?.Invoke(this, new DopplerFixChangedEventArgs(_dopplerFix.enabled));
				}
				GameState.Instance.RaiseAircraftViewChanged(_currentCameraController.Name);
				if (displayMessage)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage(_currentCameraController.Name, 1f);
				}
				if (saveAsDefault)
				{
					string value = _currentCameraController.Name;
					if (GetCurrentCockpitCamera() == cameraController)
					{
						value = "Cockpit View";
					}
					PlayerPrefs.SetString(GameInputs.Instance.NextView.Id, value);
				}
			}
			this.SwitchedToNewViewMode?.Invoke(currentCameraController, _currentCameraController);
		}

		private void SetHoveredModifier(IInteractablePartModifier interactablePart)
		{
			if (_hoveredModifier != interactablePart)
			{
				if (_partTooltip.Visible)
				{
					_partTooltip.HideTooltip();
				}
				if (_hoveredModifier != null)
				{
					_hoveredModifier.IsOutlined = false;
				}
				if (interactablePart != null)
				{
					interactablePart.IsOutlined = true;
				}
			}
			_hoveredModifier = interactablePart;
		}

		private void SwitchToCustomCameraByIndex(int customCameraIndex)
		{
			CameraController cameraController = ((_customCameras.Count > customCameraIndex) ? _customCameras[customCameraIndex] : null);
			if (cameraController != null)
			{
				SelectCamera(cameraController, saveAsDefault: true, displayMessage: true);
			}
		}

		private void UpdateCamera()
		{
			_currentCameraController.Update(_updateFrameCount);
			_updateFrameCount++;
			_ = GameWorld.Instance;
			if (_currentCameraController.IsActive)
			{
				AudioMixing.IsInCockpit = _currentCameraController.IsCockpitAudio;
			}
			else
			{
				SwitchToNextViewMode(displayMessage: true, saveAsDefault: false);
			}
		}

		private void UpdateCustomCameraNames()
		{
			int num = 0;
			foreach (CameraController customCamera in _customCameras)
			{
				string value = customCamera.CameraVantage?.Data?.Name;
				if (string.IsNullOrWhiteSpace(value))
				{
					value = $"Camera {++num}";
				}
				customCamera.Name = value;
			}
		}

		private void UpdateOverlayCamera()
		{
			bool flag = _overlayCamera.enabled;
			bool flag2 = false;
			for (int i = 0; i < _overlayCameraRequirements.Count; i++)
			{
				flag2 |= _overlayCameraRequirements[i].IsOverlayCamRequired;
			}
			if (flag != flag2)
			{
				_overlayCamera.enabled = flag2;
			}
		}

		private void UpdateTooltip()
		{
			if (XRCameraManager.XrCamerasEnabled || !InputWrapper.Player.controllers.hasMouse || _capturedInputModifiers.Count > 0)
			{
				SetHoveredModifier(null);
				return;
			}
			Vector2 mouseScreenPosition = InputWrapper.MouseScreenPosition;
			IInteractablePartModifier interactablePartModifier = GetInteractablePart(mouseScreenPosition);
			if (interactablePartModifier != null && interactablePartModifier.InteractionDisabled)
			{
				interactablePartModifier = null;
			}
			if (interactablePartModifier != null && interactablePartModifier == _hoveredModifier)
			{
				_hoveredModifierElapsedTime += Time.unscaledDeltaTime;
			}
			else
			{
				_hoveredModifierElapsedTime = Mathf.Max(0f, Mathf.Min(0.5f, _hoveredModifierElapsedTime) - Time.unscaledDeltaTime);
			}
			SetHoveredModifier(interactablePartModifier);
			if (_hoveredModifier == null || !(_hoveredModifierElapsedTime >= 0.5f))
			{
				return;
			}
			string text = _hoveredModifier.OnHover();
			if (!_partTooltip.Visible)
			{
				PartTooltipPosition tooltipPosition = interactablePartModifier.GetTooltipPosition();
				if ((object)tooltipPosition.TargetRenderer == null)
				{
					_partTooltip.ShowTooltip(text, MainCamera, tooltipPosition.TargetTransform, Vector3.up, tooltipPosition.OffsetDistance);
				}
				else
				{
					_partTooltip.ShowTooltip(text, MainCamera, tooltipPosition.TargetRenderer, Vector3.up, tooltipPosition.OffsetDistance);
				}
			}
			else
			{
				_partTooltip.Text = text;
			}
		}
	}
}

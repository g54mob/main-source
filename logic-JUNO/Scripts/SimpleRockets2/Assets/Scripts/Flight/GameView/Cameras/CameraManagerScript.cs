using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Cameras;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Effects;
using Assets.Scripts.Flight.UI;
using BeautifyEffect;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.GameView;
using ModApi.Flight.GameView.Events;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public class CameraManagerScript : MonoBehaviour, IGameCamera, IGameViewObject, ICameraTarget
	{
		public delegate void CameraModeChangedHandler(CameraMode newMode, CameraMode oldMode);

		public delegate void CameraModeEvent(CameraMode cameraMode);

		public class DefaultCameraModes
		{
			public CameraMode ModeFlyByCinematic { get; internal set; }

			public CameraMode ModeFlyByStationary { get; internal set; }

			public CameraMode ModeOrbitChaseView { get; internal set; }

			public CameraMode ModeOrbitSR1View { get; internal set; }

			public CameraMode ModeOrbitPlanetAligned { get; internal set; }

			public CameraMode ModeOrbitSpaceAligned { get; internal set; }
		}

		private const float AutoSwitchAutoDisableTime = 1f;

		private const float AutoSwitchCameraCooldownTime = 30f;

		private static readonly WaitForFixedUpdate _WaitForFixedUpdate = new WaitForFixedUpdate();

		private float _atmosCutoff;

		private bool _autoSwitchCameraEnabled = true;

		private float _autoSwitchCameraEnabledTimeEnabled;

		private float _autoSwitchCameraLastTime = float.MinValue;

		private List<CameraMode> _cameraModes = new List<CameraMode>();

		private List<Camera> _cameras = new List<Camera>();

		private ICameraShake _cameraShake;

		private bool _cameraSubmerged;

		private List<Camera> _configurableFovCameras = new List<Camera>();

		private CameraMode _currentCameraMode;

		private CameraMode _defaultCameraMode;

		[SerializeField]
		private Camera _farCamera;

		private IGameView _gameView;

		private ImageEffectsScript _imageEffects;

		private InputResponder _inputResponder;

		private CameraMode _killCamPreviousMode;

		[SerializeField]
		private Camera _nearCamera;

		private List<CameraOffset> _positionOffsets = new List<CameraOffset>();

		private List<CameraOffset> _rotationOffsets = new List<CameraOffset>();

		private AudioSource _seaAmbientSound;

		private ShadowQualitySettings _shadowQuality;

		private int _updateFrameCount = 1;

		public static CameraManagerScript Instance { get; private set; }

		public double AltitudeAboveSeaLevel => CurrentCameraController?.AltitudeAsl ?? 0.0;

		public PositionBiomeData CameraBiomeData { get; private set; }

		public IReadOnlyList<CameraMode> CameraModes => _cameraModes;

		public Transform CameraPosition { get; set; }

		ICameraShake IGameCamera.CameraShake => _cameraShake;

		Transform ICameraTarget.CameraTarget => base.transform;

		Vector3d IGameCamera.CameraTargetPlanetPosition => CurrentCameraController.Target.CameraTargetPlanetPosition;

		Vector3 ICameraTarget.CameraTargetPlanetPosition => (Vector3)_gameView.ReferenceFrame.FrameToPlanetPosition(base.transform.position);

		public Transform CameraTransform { get; private set; }

		public CameraController CurrentCameraController => _currentCameraMode?.CameraController;

		public DefaultCameraModes DefaultModes { get; private set; } = new DefaultCameraModes();

		public bool Enabled { get; set; } = true;

		Camera IGameCamera.FarCamera => _farCamera;

		public float FieldOfView
		{
			get
			{
				return _configurableFovCameras[0].fieldOfView;
			}
			set
			{
				foreach (Camera configurableFovCamera in _configurableFovCameras)
				{
					configurableFovCamera.fieldOfView = value;
				}
			}
		}

		public float FieldOfViewDefault => Game.Instance.Settings.Game.General.FieldOfView;

		Vector3 IGameCamera.FramePosition => base.transform.position;

		Vector3 IGameViewObject.FramePosition => base.transform.position;

		GameObject IGameViewObject.GameObject => base.gameObject;

		public string GameViewName => "Camera Manager";

		public ImageEffectsScript ImageEffects => _imageEffects;

		public bool IsCameraUnderWater => _cameraSubmerged;

		public bool IsKillCam => CurrentCameraController is KillCameraController;

		bool IGameViewObject.IsLoadedInGameView => true;

		bool IGameCamera.IsOffCenter => CurrentCameraController.IsOffCenter;

		bool IGameViewObject.IsPhysicsEnabled => false;

		Camera IGameCamera.NearCamera => _nearCamera;

		IOrbitNode ICameraTarget.OrbitNode => Target.OrbitNode;

		Vector3d IGameCamera.PlanetPosition => CurrentCameraController.PlanetPosition;

		public List<CameraOffset> PositionOffsets => _positionOffsets;

		public bool PreventZoom { get; set; }

		public List<CameraOffset> RotationOffsets => _rotationOffsets;

		public float SharedCameraDistance { get; set; }

		public Quaternion SharedCameraRotation { get; set; }

		public bool ShouldUpdate => !Game.Instance.FlightScene.ViewManager.MapViewManager.IsInForeground;

		public ICameraTarget Target { get; set; }

		ICameraTarget IGameCamera.Target => CurrentCameraController.Target;

		Transform IGameCamera.Transform => base.transform;

		public event CameraModeEvent CameraEnabledStateChanged;

		public event CameraModeChangedHandler CameraModeChanged;

		public event EventHandler<CameraUnderwaterStateChangedEventArgs> CameraUnderWaterStateChanged;

		public event CameraModeEvent CustomCameraModeAdded;

		public event CameraModeEvent CustomCameraModeRemoved;

		event GameViewObjectHandler IGameViewObject.LoadedIntoGameView
		{
			add
			{
				LoadedIntoGameView += value;
			}
			remove
			{
				LoadedIntoGameView -= value;
			}
		}

		event GameViewObjectHandler IGameViewObject.UnloadedFromGameView
		{
			add
			{
				UnloadedFromGameView += value;
			}
			remove
			{
				UnloadedFromGameView -= value;
			}
		}

		event GameViewObjectHandler IGameViewObject.UnloadingFromGameView
		{
			add
			{
				UnloadingFromGameView += value;
			}
			remove
			{
				UnloadingFromGameView -= value;
			}
		}

		private event GameViewObjectHandler LoadedIntoGameView;

		private event GameViewObjectHandler UnloadedFromGameView;

		private event GameViewObjectHandler UnloadingFromGameView;

		public CameraMode AddCameraMode(CameraMode cameraMode)
		{
			_cameraModes.Add(cameraMode);
			return cameraMode;
		}

		public void AllowAutoSwitch()
		{
			_autoSwitchCameraEnabled = base.enabled;
			_autoSwitchCameraEnabledTimeEnabled = Time.time;
		}

		public void EnterKillCam(IPartScript part)
		{
			_killCamPreviousMode = _currentCameraMode;
			CameraMode cameraMode = new CameraMode("Kill Cam", new KillCameraController(this, part, centerOnRigidBody: true), 0);
			SelectCameraMode(cameraMode, saveAsDefault: false);
		}

		public void ExitKillCam()
		{
			if (IsKillCam)
			{
				if (_cameraModes.Contains(_killCamPreviousMode))
				{
					SelectCameraMode(_killCamPreviousMode);
				}
				else
				{
					SelectCameraMode(_defaultCameraMode);
				}
			}
		}

		public void ExitKillCam(float delay)
		{
			StartCoroutine(ExitKillCamDelayed(delay));
		}

		Transform IGameViewObject.LoadIntoGameView(IGameView gameView)
		{
			this.LoadedIntoGameView?.Invoke(this);
			_gameView = gameView;
			Initialize();
			return base.transform.parent;
		}

		public void OnControllerEnabledChanged(CameraController cameraController)
		{
			foreach (CameraMode cameraMode in cameraController.CameraModes)
			{
				this.CameraEnabledStateChanged?.Invoke(cameraMode);
			}
		}

		void IGameViewObject.OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			CurrentCameraController.OnReferenceFrameRecentered(referenceFrame, positionDelta, velocityDelta);
			UpdateCamera(recenteringReferenceFrame: true);
		}

		void IGameViewObject.RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			CurrentCameraController.RecalculateFrameState(referenceFrame);
		}

		void IGameCamera.Recenter(bool immediate)
		{
			CurrentCameraController.Recenter(immediate);
		}

		public CameraController RegisterCustomCameraVantage(CameraVantageScript cameraVantageScript)
		{
			CameraController cameraController = null;
			if (cameraVantageScript.ViewMode == ViewMode.FirstPerson)
			{
				cameraController = new FirstPersonCameraController(this, cameraVantageScript);
			}
			if (cameraController != null)
			{
				cameraController.StaticTarget = cameraVantageScript;
				cameraController.IsCustom = true;
				CameraMode cameraMode = new CameraMode(cameraVantageScript.PartScript.Data.Name, cameraController, 0);
				cameraMode.Dirt = cameraVantageScript.Data.DirtIntensity;
				cameraMode.IsHidden = cameraVantageScript.Data.IsHidden;
				cameraMode.NightVision = (cameraVantageScript.Data.IsNight ? cameraVantageScript.Data.NightVisionColor : Color.black);
				AddCameraMode(cameraMode);
				RecalculateCustomCameraPrefixes();
				this.CustomCameraModeAdded?.Invoke(cameraMode);
			}
			else
			{
				Debug.LogError($"Unsupported custom camera vantage type: {cameraVantageScript.ViewMode}");
			}
			return cameraController;
		}

		void IGameCamera.RegisterPositionOffset(CameraOffset offset)
		{
			if (!_positionOffsets.Contains(offset))
			{
				_positionOffsets.Add(offset);
			}
		}

		void IGameCamera.RegisterRotationOffset(CameraOffset offset)
		{
			if (!_rotationOffsets.Contains(offset))
			{
				_rotationOffsets.Add(offset);
			}
		}

		public void RestoreDefaultCamera()
		{
			string lastCameraName = GetDefaultCamera();
			CameraMode cameraMode = _cameraModes.Where((CameraMode x) => x.Name == lastCameraName).FirstOrDefault();
			if (cameraMode != null && cameraMode.CameraController.AllowDefault)
			{
				SelectCameraMode(cameraMode);
			}
		}

		void IGameCamera.Rotate(Vector2 delta)
		{
			CurrentCameraController.Rotate(delta);
		}

		public Ray ScreenPointToRay(Vector2 screenPoint)
		{
			return Utilities.ScreenPointToRay(_nearCamera, screenPoint);
		}

		public void SelectCameraMode(CameraMode cameraMode, bool saveAsDefault = true, bool displayMessage = false)
		{
			if (_currentCameraMode == cameraMode)
			{
				return;
			}
			if (cameraMode == null)
			{
				cameraMode = _currentCameraMode;
			}
			CameraMode currentCameraMode = _currentCameraMode;
			if (_currentCameraMode != null)
			{
				_currentCameraMode.IsSelected = false;
				_currentCameraMode.CameraController.OnDeselected();
			}
			_currentCameraMode = cameraMode;
			_currentCameraMode.CameraController.OnSelected(cameraMode.SubMode);
			_currentCameraMode.IsSelected = true;
			if (displayMessage)
			{
				DisplayCameraSwitchMessage(_currentCameraMode);
			}
			if (saveAsDefault && cameraMode.CameraController.AllowDefault)
			{
				SetDefaultCameraMode(_currentCameraMode);
			}
			Beautify beautify = ImageEffects.Beautify;
			bool eyeAdaptation = (beautify.nightVision = _currentCameraMode.NightVision.maxColorComponent > 0f);
			beautify.eyeAdaptation = eyeAdaptation;
			beautify.lut = !beautify.nightVision;
			beautify.nightVisionColor = _currentCameraMode.NightVision;
			beautify.lensDirt = _currentCameraMode.Dirt > 0f;
			beautify.lensDirtIntensity = _currentCameraMode.Dirt;
			if (!Game.Instance.Settings.Quality.ImageEffects.Enabled.Value)
			{
				if (beautify.nightVision)
				{
					Game.Instance.FlightScene?.FlightSceneUI?.ShowMessage("Image Effects in Settings -> Quality must be enabled to view this camera in night vision mode.");
				}
				if (beautify.lensDirt)
				{
					Game.Instance.FlightScene?.FlightSceneUI?.ShowMessage("Image Effects in Settings -> Quality must be enabled to view the dirt in this camera.");
				}
			}
			this.CameraModeChanged?.Invoke(_currentCameraMode, currentCameraMode);
		}

		public void SetEnabled(bool enabled)
		{
			base.gameObject.SetActive(enabled);
		}

		void IGameViewObject.SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason)
		{
		}

		public void SwitchToNextViewMode(bool saveAsDefault, bool displayMessage, bool forward = true)
		{
			if (IsKillCam)
			{
				ExitKillCam();
				return;
			}
			CameraMode cameraMode = _currentCameraMode;
			do
			{
				int cameraModeIndex = GetCameraModeIndex(cameraMode);
				cameraModeIndex += (forward ? 1 : (-1));
				if (cameraModeIndex < 0)
				{
					cameraModeIndex = _cameraModes.Count - 1;
				}
				else if (cameraModeIndex >= _cameraModes.Count)
				{
					cameraModeIndex = 0;
				}
				cameraMode = _cameraModes[cameraModeIndex];
			}
			while (!cameraMode.CameraController.Enabled);
			SelectCameraMode(cameraMode, saveAsDefault, displayMessage);
		}

		void IGameViewObject.UnloadFromGameView(bool flightEnd)
		{
			this.UnloadingFromGameView?.Invoke(this);
			this.UnloadedFromGameView?.Invoke(this);
		}

		public void UnRegisterCustomCameraVantage(CameraVantageScript cameraVantageScript)
		{
			foreach (CameraMode cameraMode in _cameraModes)
			{
				CameraController cameraController = cameraMode.CameraController;
				if (cameraController.IsCustom && cameraController.StaticTarget == cameraVantageScript)
				{
					if (_currentCameraMode == cameraMode)
					{
						SwitchToNextViewMode(saveAsDefault: false, displayMessage: false);
						Game.Instance?.FlightScene?.FlightSceneUI?.ShowMessage("Auto-switching camera: " + _currentCameraMode.Name, devlog: false, 1f);
					}
					_cameraModes.Remove(cameraMode);
					this.CustomCameraModeRemoved?.Invoke(cameraMode);
					RecalculateCustomCameraPrefixes();
					break;
				}
			}
		}

		void IGameCamera.UnregisterPositionOffset(CameraOffset offset)
		{
			if (_rotationOffsets.Contains(offset))
			{
				_rotationOffsets.Remove(offset);
			}
		}

		void IGameCamera.UnregisterRotationOffset(CameraOffset offset)
		{
			if (_rotationOffsets.Contains(offset))
			{
				_rotationOffsets.Remove(offset);
			}
		}

		public void UpdateCamera(bool recenteringReferenceFrame = false)
		{
			if (ShouldUpdate)
			{
				CurrentCameraController.Update(_updateFrameCount);
				CurrentCameraController.PostUpdate(recenteringReferenceFrame);
				if (!recenteringReferenceFrame)
				{
					UpdateUnderWaterEffects();
				}
				_updateFrameCount++;
			}
		}

		public void UpdateLevelOfDetail(double distanceSquared)
		{
		}

		void IGameCamera.Zoom(float zoomPercentage)
		{
			CurrentCameraController.Zoom(zoomPercentage);
		}

		protected virtual void OnDestroy()
		{
			foreach (CameraController item in _cameraModes.Select((CameraMode x) => x.CameraController).Distinct())
			{
				item.OnDestroy();
			}
			Game.Instance.AudioPlayer.SetLowpassValues(null, null);
			Shader.DisableKeyword("UNDERWATER");
			Instance = null;
		}

		private static void DisplayCameraSwitchMessage(CameraMode cameraMode)
		{
			Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"{cameraMode.DisplayPrefix}{cameraMode.Name}", devlog: false, 1f);
		}

		private void Awake()
		{
			CameraTransform = base.transform;
			Instance = this;
			GetComponent<AudioListener>().velocityUpdateMode = AudioVelocityUpdateMode.Fixed;
			_inputResponder = new InputResponder("FlightCamera");
			_inputResponder.IsResponding = () => ShouldUpdate;
			_inputResponder.OnBeginPinch = OnBeginPinch;
			_inputResponder.OnScroll = OnScroll;
			_inputResponder.OnEndPinch = OnEndPinch;
			_inputResponder.OnPinch = OnPinch;
			_inputResponder.OnBeginDrag = OnBeginDrag;
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnEndDrag = OnEndDrag;
			_inputResponder.OnPointerDown = OnPointerDown;
			_inputResponder.OnPointerUp = OnPointerUp;
			_inputResponder.OnPointerClick = OnPointerClick;
			_cameraShake = CameraTransform.gameObject.AddMissingComponent<CameraShakeScript>();
			Game.Instance.FlightScene.FlightSceneUI.AddInputResponder(_inputResponder);
			_imageEffects = GetComponent<ImageEffectsScript>();
			_shadowQuality = Game.Instance.QualitySettings.Shadows;
			CameraBiomeData = new PositionBiomeData();
			if (!CurrentDevice.HasAnyFlag(DeviceFlags.LowRam))
			{
				_seaAmbientSound = _nearCamera.gameObject.AddComponent<AudioSource>();
				_seaAmbientSound.spatialBlend = 0f;
				_seaAmbientSound.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetGameMixerGroup();
				_seaAmbientSound.clip = Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/waterSound");
				_seaAmbientSound.loop = true;
			}
		}

		private IEnumerator ExitKillCamDelayed(float delay)
		{
			yield return new WaitForSeconds(delay / (float)Game.Instance.FlightScene.TimeManager.SlowMotion.TimeMultiplier);
			ExitKillCam();
		}

		private int GetCameraModeIndex(CameraMode cameraMode)
		{
			for (int i = 0; i < _cameraModes.Count; i++)
			{
				if (cameraMode == _cameraModes[i])
				{
					return i;
				}
			}
			return 0;
		}

		private string GetDefaultCamera()
		{
			return null;
		}

		private void Initialize()
		{
			ICraftScript craftScript = Game.Instance.FlightScene.CraftNode.CraftScript;
			base.transform.forward = craftScript.ActiveCommandPod.PilotSeatOrientation.forward;
			SharedCameraRotation = Quaternion.Euler(15f, -70f, 0f);
			SharedCameraDistance = 20f;
			_cameras.AddRange(base.transform.GetComponentsInChildren<Camera>());
			SceneCameraScript[] array = UnityEngine.Object.FindObjectsOfType<SceneCameraScript>();
			foreach (SceneCameraScript sceneCameraScript in array)
			{
				if (sceneCameraScript.UseConfigurableFOV)
				{
					_configurableFovCameras.Add(sceneCameraScript.Camera);
				}
			}
			OrbitCameraController orbitCameraController = new OrbitCameraController(this);
			orbitCameraController.SetRotation(new Vector3(30f, 70f, 0f));
			float zoom = Mathf.Max(craftScript.Data.Size.magnitude, 15f) * 1.5f;
			orbitCameraController.SetZoom(zoom);
			_defaultCameraMode = new CameraMode("Orbit - Planet Aligned", orbitCameraController, 0);
			DefaultModes.ModeOrbitPlanetAligned = AddCameraMode(_defaultCameraMode);
			OrbitCameraController orbitCameraController2 = new OrbitCameraController(this);
			orbitCameraController2.SetRotation(new Vector3(0f, 30f, 0f));
			DefaultModes.ModeOrbitSpaceAligned = AddCameraMode(new CameraMode("Orbit - Space Aligned", orbitCameraController2, 1));
			OrbitCameraController orbitCameraController3 = new OrbitCameraController(this);
			orbitCameraController3.DefaultRotation = new Vector3(10f, 0f, 0f);
			orbitCameraController3.SetRotation(orbitCameraController3.DefaultRotation.Value);
			orbitCameraController3.SetZoom(20f);
			DefaultModes.ModeOrbitChaseView = AddCameraMode(new CameraMode("Chase View", orbitCameraController3, 2));
			OrbitCameraController orbitCameraController4 = new OrbitCameraController(this);
			orbitCameraController4.DefaultRotation = new Vector3(0f, 0f, 0f);
			orbitCameraController4.SetRotation(orbitCameraController4.DefaultRotation.Value);
			orbitCameraController4.SetZoom(zoom);
			DefaultModes.ModeOrbitSR1View = AddCameraMode(new CameraMode("2D View", orbitCameraController4, 3));
			FlyByCameraController cameraController = new FlyByCameraController(this);
			DefaultModes.ModeFlyByCinematic = AddCameraMode(new CameraMode("Fly By - Cinematic", cameraController, 1));
			DefaultModes.ModeFlyByStationary = AddCameraMode(new CameraMode("Fly By - Stationary", cameraController, 0));
			RestoreDefaultCamera();
			if (_currentCameraMode == null)
			{
				SelectCameraMode(_defaultCameraMode);
			}
			Shader.DisableKeyword("UNDERWATER");
		}

		private void LateUpdate()
		{
			if (_autoSwitchCameraEnabled && Time.time >= _autoSwitchCameraLastTime + 30f)
			{
				Vector3 vector = Game.Instance.FlightScene.CraftNode.CraftScript.ActiveCommandPod.PilotSeatOrientation.InverseTransformDirection(CurrentCameraController.AngularVelocity);
				if (new Vector3(vector.x, vector.y, 0f).magnitude > 2f)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Orbit View (Auto Switch)", devlog: false, 1f);
					SelectCameraMode(_defaultCameraMode, saveAsDefault: false);
					_autoSwitchCameraLastTime = Time.time;
				}
			}
			if (_autoSwitchCameraEnabled && Time.time >= _autoSwitchCameraEnabledTimeEnabled + 1f)
			{
				_autoSwitchCameraEnabled = false;
			}
			if (CurrentCameraController.IsCustom || CurrentCameraController is FlyByCameraController)
			{
				QualitySettings.shadowDistance = _shadowQuality.MaxShadowDistance;
			}
			else
			{
				float num = Mathf.Abs(base.transform.localPosition.z);
				float num2 = 1f - Mathf.Clamp01((num - 10f) / 200f);
				QualitySettings.shadowDistance = Mathf.Lerp(_shadowQuality.MaxShadowDistance, _shadowQuality.MinShadowDistance, num2 * (float)_shadowQuality.ShadowLerp);
			}
			_updateFrameCount = 1;
		}

		private void OnApplicationFocus(bool focus)
		{
			CurrentCameraController?.OnApplicaitionFocus(focus);
		}

		private bool OnBeginDrag(PointerEventData eventData)
		{
			return CurrentCameraController.OnBeginDrag(eventData);
		}

		private bool OnBeginPinch(PinchEventData eventData)
		{
			return CurrentCameraController.OnBeginPinch(eventData);
		}

		private bool OnDrag(PointerEventData eventData)
		{
			return CurrentCameraController.OnDrag(eventData);
		}

		private bool OnEndDrag(PointerEventData eventData)
		{
			return CurrentCameraController.OnEndDrag(eventData);
		}

		private bool OnEndPinch(PinchEventData eventData)
		{
			return CurrentCameraController.OnEndPinch(eventData);
		}

		private bool OnPinch(PinchEventData eventData)
		{
			return CurrentCameraController.OnPinch(eventData);
		}

		private bool OnPointerClick(PointerEventData eventData)
		{
			return CurrentCameraController.OnPointerClick(eventData);
		}

		private bool OnPointerDown(PointerEventData eventData)
		{
			return CurrentCameraController.OnPointerDown(eventData);
		}

		private bool OnPointerUp(PointerEventData eventData)
		{
			return CurrentCameraController.OnPointerUp(eventData);
		}

		private bool OnScroll(PointerEventData eventData)
		{
			return CurrentCameraController.OnScroll(eventData);
		}

		private void RecalculateCustomCameraPrefixes()
		{
			IEnumerable<CameraMode> enumerable = _cameraModes.Where((CameraMode x) => x.CameraController.IsCustom);
			int num = 1;
			int num2 = enumerable.Count();
			foreach (CameraMode item in enumerable)
			{
				if (!item.IsHidden)
				{
					item.DisplayPrefix = $"Camera {num} of {num2} - ";
					num++;
				}
			}
		}

		private void SetCameraFov(float fov)
		{
			foreach (Camera camera in _cameras)
			{
				camera.fieldOfView = fov;
			}
		}

		private void SetDefaultCameraMode(CameraMode cameraMode)
		{
			PlayerPrefs.SetString(Game.Instance.Inputs.NextCameraMode.Id, cameraMode.Name);
		}

		private void Start()
		{
			_imageEffects.Underwater.quadDrops.layer = 4;
			_imageEffects.Underwater.audioSourceCamera.volume = 0.1f;
		}

		private void UpdateUnderWaterEffects()
		{
			IPlanetData planetData = Game.Instance.FlightScene.CraftNode.Parent.PlanetData;
			bool hasWater = planetData.HasWater;
			bool flag = hasWater && CurrentCameraController.AltitudeAsl <= 0.05000000074505806;
			bool flag2 = _currentCameraMode.Name == "First Person";
			float num = (planetData.AtmosphereData.HasPhysicsAtmosphere ? Mathf.Clamp01((float)CurrentCameraController.AltitudeAsl / Mathf.Max(1f, (float)planetData.AtmosphereData.Height)) : 1f);
			float num2 = ((!Game.Instance.Settings.Game.Audio.SpaceMuffle || num == 0f) ? 22000f : Mathf.Min(22000f, 200f / (num * num)));
			if (num2 > 600f && flag2)
			{
				num2 = 600f;
			}
			if (_cameraSubmerged != flag || Mathf.Abs(_atmosCutoff - num2) > _atmosCutoff * 0.05f)
			{
				_atmosCutoff = num2;
				Game.Instance.AudioPlayer.SetLowpassValues(flag ? 500f : num2, flag ? new float?(2f) : (flag2 ? new float?(1.5f) : ((float?)null)));
			}
			if (_cameraSubmerged != flag)
			{
				_cameraSubmerged = flag;
				if (_cameraSubmerged)
				{
					Shader.EnableKeyword("UNDERWATER");
				}
				else
				{
					Shader.DisableKeyword("UNDERWATER");
				}
				this.CameraUnderWaterStateChanged?.Invoke(this, new CameraUnderwaterStateChangedEventArgs(_cameraSubmerged));
			}
			if (_imageEffects.Underwater.UnderWater != flag)
			{
				_imageEffects.Underwater.EnableWater(flag, 0);
			}
			if (!(_seaAmbientSound != null))
			{
				return;
			}
			float num3 = 0f;
			if (hasWater)
			{
				num3 = ((!flag) ? (0.5f * Mathf.Pow(1f - MathUtils.PercentBetween((float)Game.Instance.FlightScene.ViewManager.GameView.Planet.QuadSphere.ClosestWaterQuadToCameraSqr, 0f, 40000f), 2f)) : (0.5f / Mathf.Max(0f, 0f - (float)CurrentCameraController.AltitudeAsl)));
			}
			if (num3 > 0.01f)
			{
				if (!_seaAmbientSound.isPlaying)
				{
					_seaAmbientSound.Play();
				}
				_seaAmbientSound.volume = num3;
			}
			else if (_seaAmbientSound.isPlaying)
			{
				_seaAmbientSound.Stop();
			}
		}
	}
}

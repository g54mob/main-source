using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AwesomeTechnologies.VegetationSystem;
using DV;
using DV.Common;
using DV.Customization.Gadgets;
using DV.DopplerEffects;
using DV.Highlighting;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.TerrainSystem;
using DV.UI;
using DV.UI.ContextMenu;
using DV.Utils;
using DV.VFX;
using DV.WorldTools;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using VLB;

[ExecuteAfter(typeof(ExternalCamera))]
public class PlayerCameraSwitcher : SingletonBehaviour<PlayerCameraSwitcher>
{
	private delegate void Toggle(bool enabled);

	public enum CameraView
	{
		None = 0,
		InTransition = 1,
		FirstPerson = 2,
		External = 3,
		LoadingWorld = 4
	}

	public enum ViewRequestor
	{
		None = 0,
		PlayerInput = 1,
		PauseMenu = 2
	}

	private const float EXT_CAM_TRANSITION_STATIC_VALUE = 0.3f;

	private const float EXT_CAM_TRANSITION_DYNAMIC_VALUE_PER_100m = 0.1f;

	private const CameraView INITIAL_VIEW = CameraView.FirstPerson;

	[NonSerialized]
	public CameraView beforePhotoModeView;

	[NonSerialized]
	public CameraView requestedView;

	[NonSerialized]
	public CameraView currentView;

	[NonSerialized]
	public ViewRequestor lastRequestor;

	[NonSerialized]
	public bool currentPause;

	[NonSerialized]
	public bool requestedPause;

	private List<MonoBehaviour> playerScripts;

	private List<Toggle> toggleDelegates;

	[NonSerialized]
	public ExternalCamera externalCamera;

	private DistantTerrain distTerrain;

	private RailwayMeshGenerator meshGen;

	private TeleportPointerController teleportPointerController;

	private NonVRPointerLogic nonVRPointerLogic;

	private bool externalCameraFollowCar;

	private GameParams gameParams;

	private Streamer farStreamer;

	public static bool IsInFirstPerson
	{
		get
		{
			if (!SingletonBehaviour<PlayerCameraSwitcher>.Instance)
			{
				return true;
			}
			return SingletonBehaviour<PlayerCameraSwitcher>.Instance.currentView == CameraView.FirstPerson;
		}
	}

	public GameObject HiddenItem { get; private set; }

	public int HiddenItemSlot { get; private set; }

	public event Action RequestedViewChanged;

	public event Action RequestedPauseChanged;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		if (VRManager.IsVREnabled())
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		gameParams = Globals.G.GameParams;
		externalCamera = GetComponentInChildren<ExternalCamera>(includeInactive: true);
		currentView = CameraView.FirstPerson;
		requestedView = CameraView.FirstPerson;
		GameObject[] array = GameObject.FindGameObjectsWithTag(Streamer.STREAMERTAG);
		foreach (GameObject gameObject in array)
		{
			string text = gameObject.name;
			if (text == "[far]")
			{
				farStreamer = gameObject.GetComponent<Streamer>();
			}
		}
		if (!farStreamer)
		{
			Debug.LogError("Couldn't find far streamer object!");
		}
		if ((bool)PlayerManager.PlayerTransform)
		{
			PlayerChanged();
		}
		else
		{
			PlayerManager.PlayerChanged += PlayerChanged;
		}
		_ = (bool)SingletonBehaviour<AppUtil>.Instance;
		SetupListeners(on: true);
		if (!externalCamera.cam)
		{
			externalCamera.cam = externalCamera.GetComponent<Camera>();
		}
		externalCamera.locoSelect = true;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		PlayerManager.PlayerChanged -= PlayerChanged;
		if (!VRManager.IsVREnabled())
		{
			SetupListeners(on: false);
			ItemScrolling.staticScrollingAllowed = true;
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.InvertMouseY, SetInvertedYExternal);
			gameParams.PropertyChanged += OnGameParamChanged;
			return;
		}
		if (!UnloadWatcher.isUnloading && (bool)teleportPointerController)
		{
			teleportPointerController.Teleported -= OnTeleported;
		}
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.InvertMouseY, SetInvertedYExternal);
		gameParams.PropertyChanged -= OnGameParamChanged;
	}

	private void OnGameParamChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "FreeCamAllowed" && !gameParams.FreeCamAllowed && externalCamera.IsOn)
		{
			ExternalCamToggle();
		}
	}

	private void SetInvertedYExternal()
	{
		externalCamera.invertedY = GamePreferences.Get<bool>(Preferences.InvertMouseY);
	}

	private void PlayerChanged()
	{
		playerScripts = new List<MonoBehaviour>();
		toggleDelegates = new List<Toggle>();
		teleportPointerController = PlayerManager.PlayerCamera.GetComponentInChildren<TeleportPointerController>(includeInactive: true);
		nonVRPointerLogic = teleportPointerController.GetComponent<NonVRPointerLogic>();
		playerScripts.Add(PlayerManager.PlayerTransform.GetComponent<CameraAnchorLeanCrouch>());
		playerScripts.AddRange(PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>(includeInactive: true).gameObject.GetComponents<MonoBehaviour>());
		playerScripts.Add(PlayerManager.PlayerTransform.GetComponent<HUDTurntableContextMenuProvider>());
		playerScripts.Add(PlayerManager.PlayerTransform.GetComponent<CameraSmoothing>());
		playerScripts.Add(PlayerManager.PlayerTransform.GetComponent<LocomotionInputWrapper>());
		playerScripts.Add(PlayerManager.PlayerTransform.GetComponentInChildren<GadgetHandNonVR>());
		toggleDelegates.Add(delegate(bool e)
		{
			ItemScrolling.staticScrollingAllowed = e;
		});
		UpdateVolumetricCamera();
		PlayerManager.PlayerChanged -= PlayerChanged;
	}

	private IEnumerator Start()
	{
		SetInvertedYExternal();
		while (!WorldStreamingInit.IsStreamingDone)
		{
			yield return null;
		}
		VegetationSystemPro vegetationSystemPro = UnityEngine.Object.FindObjectOfType<VegetationSystemPro>();
		if ((bool)vegetationSystemPro)
		{
			vegetationSystemPro.AddCamera(externalCamera.cam);
		}
		distTerrain = UnityEngine.Object.FindObjectOfType<DistantTerrain>();
		meshGen = SingletonBehaviour<RailwayMeshGenerator>.Instance;
	}

	private void Update()
	{
		if (PlayerManager.PlayerCamera == null || SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			return;
		}
		if (currentView != CameraView.InTransition && currentView != requestedView)
		{
			if (currentView == CameraView.FirstPerson && requestedView == CameraView.External)
			{
				InternalToExternal();
			}
			else if (currentView == CameraView.External && requestedView == CameraView.FirstPerson)
			{
				StartCoroutine(ExternalToInternal());
			}
			else if (currentView == CameraView.None && requestedView == CameraView.FirstPerson)
			{
				EnableFirstPersonCam();
				currentView = CameraView.FirstPerson;
			}
		}
		if (currentPause != requestedPause)
		{
			currentPause = requestedPause;
			if (requestedPause)
			{
				SingletonBehaviour<AppUtil>.Instance.RequestPause(this, paused: true);
			}
			else
			{
				SingletonBehaviour<AppUtil>.Instance.RemovePauseRequest(this);
			}
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.FirstPersonCam) && requestedView != CameraView.FirstPerson)
		{
			ExternalCamToggle();
		}
		if (gameParams.FreeCamAllowed && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers) && !SingletonBehaviour<BedSleepingController>.Instance.IsSleeping)
		{
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.ExternalCamFollow))
			{
				externalCameraFollowCar = true;
				if (requestedView != CameraView.External)
				{
					ExternalCamToggle();
				}
				else if ((bool)PlayerManager.Car && externalCamera.CurrentCar != PlayerManager.Car)
				{
					externalCamera.SwitchFlyToOrbital(PlayerManager.Car);
				}
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.ExternalCamUnfollow))
			{
				externalCameraFollowCar = false;
				if (requestedView != CameraView.External)
				{
					ExternalCamToggle();
				}
				else
				{
					externalCamera.SwitchOrbitalToFly();
				}
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.PhotoMode))
			{
				PhotoModeToggle();
			}
		}
		if (externalCamera.IsOn && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Hotbar) && externalCamera.PhotoMode)
		{
			RequestPause(!currentPause);
		}
	}

	private void LateUpdate()
	{
		if (!(PlayerManager.PlayerCamera == null) && externalCamera.IsOn)
		{
			teleportPointerController.manualUpdate = true;
			if (gameParams.FreeCamDashAllowed && !externalCamera.CurrentCar && !InputManager.NewPlayer.GetButton(InputManager.Actions.ContextMenu) && !externalCamera.freeOrbitPressed)
			{
				nonVRPointerLogic.externalCameraMode = true;
				teleportPointerController.transform.SetPositionAndRotation(externalCamera.transform.position, externalCamera.transform.rotation);
				teleportPointerController.DoTeleportLogic();
			}
			else
			{
				teleportPointerController.EnsureUnhover();
			}
		}
	}

	private void OnTeleported()
	{
		if (externalCamera.IsOn)
		{
			if (!PlayerManager.Car || !PlayerManager.Car.cabTeleportDestination)
			{
				PlayerManager.PlayerCamera.transform.rotation = externalCamera.transform.rotation;
				PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>().ForceLookRotationNoTilt(externalCamera.transform.rotation);
			}
			ExternalCamToggle();
		}
	}

	public void PhotoModeToggle()
	{
		externalCameraFollowCar = false;
		externalCamera.PhotoMode = !externalCamera.PhotoMode;
		bool photoMode = externalCamera.PhotoMode;
		if (photoMode)
		{
			beforePhotoModeView = ((currentView == CameraView.InTransition) ? CameraView.FirstPerson : currentView);
		}
		RequestView(photoMode ? CameraView.External : beforePhotoModeView, ViewRequestor.PlayerInput);
		RequestPause(photoMode && GamePreferences.Get<bool>(Preferences.PhotomodeAutopause));
		SingletonBehaviour<AGeneralHighlighter>.Instance.RefreshConditions();
	}

	private void ExternalCamToggle()
	{
		externalCamera.PhotoMode = false;
		SingletonBehaviour<AGeneralHighlighter>.Instance.RefreshConditions();
		RequestView((requestedView == CameraView.External) ? CameraView.FirstPerson : CameraView.External, ViewRequestor.PlayerInput);
		RequestPause(paused: false);
	}

	public void RequestView(CameraView view, ViewRequestor requestor = ViewRequestor.None)
	{
		if (requestedView != view)
		{
			if (view != CameraView.FirstPerson && !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.ExternalCam))
			{
				return;
			}
			requestedView = view;
			this.RequestedViewChanged?.Invoke();
		}
		lastRequestor = requestor;
	}

	public void RequestPause(bool paused)
	{
		if (requestedPause != paused)
		{
			requestedPause = paused;
			this.RequestedPauseChanged?.Invoke();
		}
	}

	private IEnumerator ExternalToInternal()
	{
		Camera playerCam = PlayerManager.PlayerCamera;
		bool needsLoadingScreen = !IsLoaded(playerCam.transform.position) && (!PlayerManager.Car || !externalCamera.CurrentCar || externalCamera.CurrentCar.trainset != PlayerManager.Car.trainset);
		if (needsLoadingScreen)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.StartLoading();
		}
		PlayerManager.PlayerCameraOverride = null;
		currentView = CameraView.InTransition;
		yield return DisableExternalCam();
		if (needsLoadingScreen)
		{
			playerCam.GetComponent<AudioListener>().enabled = true;
		}
		if ((bool)distTerrain)
		{
			distTerrain.trackingReference = playerCam.transform;
		}
		if ((bool)meshGen)
		{
			meshGen.chunkReference = playerCam.transform;
		}
		if ((bool)SingletonBehaviour<TerrainHoleManager>.Instance)
		{
			SingletonBehaviour<TerrainHoleManager>.Instance.playerCamera = playerCam;
		}
		UpdateVolumetricCamera();
		Vector3 pos = playerCam.transform.position;
		while (needsLoadingScreen && !IsLoaded(pos))
		{
			yield return null;
		}
		if (needsLoadingScreen)
		{
			yield return SingletonBehaviour<FpsStabilityMeasurer>.Instance.WaitForStableFps();
		}
		EnableFirstPersonCam();
		SetPlayerScripts(enabled: true);
		currentView = CameraView.FirstPerson;
		teleportPointerController.transform.localPosition = Vector3.zero;
		teleportPointerController.transform.localEulerAngles = Vector3.zero;
		teleportPointerController.manualUpdate = false;
		teleportPointerController.Teleported -= OnTeleported;
		nonVRPointerLogic.externalCameraMode = false;
		RequestPause(paused: false);
		CustomFirstPersonController component = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
		if (component.capsule.isGrounded)
		{
			component.m_Jumping = false;
		}
		if (needsLoadingScreen)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.FinishLoading();
		}
	}

	private bool IsLoaded(Vector3 pos)
	{
		if (SingletonBehaviour<TerrainGrid>.Instance == null || SingletonBehaviour<TerrainGrid>.Instance.IsInLoadedRegion(pos))
		{
			if (!(farStreamer == null))
			{
				return farStreamer.IsSceneLoaded(pos);
			}
			return true;
		}
		return false;
	}

	private void InternalToExternal()
	{
		PlayerManager.PlayerCameraOverride = externalCamera.cam;
		currentView = CameraView.InTransition;
		DisableFirstPersonCam();
		SetPlayerScripts(enabled: false);
		if ((bool)distTerrain)
		{
			distTerrain.trackingReference = externalCamera.transform;
		}
		if ((bool)meshGen)
		{
			meshGen.chunkReference = externalCamera.transform;
		}
		if ((bool)SingletonBehaviour<TerrainHoleManager>.Instance)
		{
			SingletonBehaviour<TerrainHoleManager>.Instance.playerCamera = externalCamera.cam;
		}
		teleportPointerController.Teleported += OnTeleported;
		UpdateVolumetricCamera();
		EnableExternalCam();
		currentView = CameraView.External;
	}

	private void EnableExternalCam()
	{
		Camera playerCamera = PlayerManager.PlayerCamera;
		externalCamera.gameObject.SetActive(value: true);
		externalCamera.TurnOn(playerCamera.transform.position, playerCamera.transform.rotation, externalCameraFollowCar);
		externalCamera.cam.renderingPath = playerCamera.renderingPath;
		externalCamera.cam.allowHDR = playerCamera.allowHDR;
		externalCamera.cam.allowMSAA = playerCamera.allowMSAA;
		externalCamera.cam.fieldOfView = playerCamera.fieldOfView;
		externalCamera.fpsController = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
		externalCamera.fpsController.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Locked, 1);
		PostProcessLayer component = playerCamera.GetComponent<PostProcessLayer>();
		PostProcessLayer component2 = externalCamera.cam.GetComponent<PostProcessLayer>();
		if (component.enabled)
		{
			component2.antialiasingMode = component.antialiasingMode;
		}
		else
		{
			component2.enabled = false;
		}
	}

	private IEnumerator DisableExternalCam()
	{
		if (externalCamera.IsOn)
		{
			SingletonBehaviour<DopplerStopRequests>.Instance.AddBlockRequest(this);
			float num = Vector3.Distance(PlayerManager.PlayerCamera.transform.position, externalCamera.transform.position);
			float transitionTime = 0.3f + 0.1f * num * 0.01f;
			externalCamera.TurnOff(transitionTime);
			while (externalCamera.IsOn)
			{
				yield return null;
			}
			if (externalCamera.gameObject.TryGetComponent<CameraGraphicsUpdater>(out var component))
			{
				component.ExpectedDisable = true;
			}
			externalCamera.gameObject.SetActive(value: false);
			externalCamera.fpsController.m_MouseLook.RemoveRequest(this);
			SingletonBehaviour<DopplerStopRequests>.Instance.RemoveBlockRequest(this);
			SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
		}
	}

	private void EnableFirstPersonCam()
	{
		Camera playerCamera = PlayerManager.PlayerCamera;
		playerCamera.enabled = true;
		playerCamera.GetComponent<AudioListener>().enabled = true;
		playerCamera.GetComponent<StreamingController>().enabled = true;
		Transform playerTransform = PlayerManager.PlayerTransform;
		CustomFirstPersonController component = playerTransform.GetComponent<CustomFirstPersonController>();
		component.enabled = true;
		if ((bool)HiddenItem)
		{
			HiddenItem.gameObject.SetActive(value: true);
			SingletonBehaviour<Inventory>.Instance.EquipItem(HiddenItem, HiddenItemSlot, 0);
			HiddenItem = null;
			HiddenItemSlot = -1;
		}
		component.GetComponent<PlayerScreenspaceMouse>().enabled = true;
		Canvas[] componentsInChildren = playerTransform.GetComponentsInChildren<Canvas>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
		}
	}

	private void DisableFirstPersonCam()
	{
		Camera playerCamera = PlayerManager.PlayerCamera;
		playerCamera.enabled = false;
		playerCamera.GetComponent<AudioListener>().enabled = false;
		playerCamera.GetComponent<StreamingController>().enabled = false;
		Transform playerTransform = PlayerManager.PlayerTransform;
		CustomFirstPersonController component = playerTransform.GetComponent<CustomFirstPersonController>();
		component.enabled = false;
		component.GetComponent<PlayerScreenspaceMouse>().enabled = false;
		HiddenItem = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0);
		if ((bool)HiddenItem)
		{
			HiddenItemSlot = SingletonBehaviour<Inventory>.Instance.IndexOf(HiddenItem);
			SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: false, 0);
			HiddenItem.gameObject.SetActive(value: false);
		}
		Canvas[] componentsInChildren = playerTransform.GetComponentsInChildren<Canvas>(includeInactive: true);
		foreach (Canvas canvas in componentsInChildren)
		{
			if (!canvas.name.Contains("Main Menu"))
			{
				canvas.enabled = false;
			}
		}
	}

	private void UpdateVolumetricCamera()
	{
		Config.Instance.fadeOutCameraTransform = PlayerManager.ActiveCamera.transform;
	}

	private void SetPlayerScripts(bool enabled)
	{
		playerScripts?.ForEach(delegate(MonoBehaviour script)
		{
			if ((bool)script)
			{
				script.enabled = enabled;
			}
		});
		toggleDelegates?.ForEach(delegate(Toggle del)
		{
			del?.Invoke(enabled);
		});
	}

	public void EnterFreeCam()
	{
		if (!externalCamera.IsOn || !(externalCamera.CurrentCar == null))
		{
			if (externalCamera.IsOn)
			{
				externalCamera.SwitchOrbitalToFly();
				return;
			}
			externalCameraFollowCar = false;
			ExternalCamToggle();
		}
	}

	public void EnterOrbitCam()
	{
		if (!externalCamera.IsOn || !externalCamera.IsOrbitingPlayerCar)
		{
			if (externalCamera.IsOn)
			{
				externalCamera.FindPlayerCar();
				return;
			}
			externalCameraFollowCar = true;
			ExternalCamToggle();
		}
	}

	public void EnterPlayerCam()
	{
		if (requestedView != CameraView.FirstPerson)
		{
			ExternalCamToggle();
		}
	}
}

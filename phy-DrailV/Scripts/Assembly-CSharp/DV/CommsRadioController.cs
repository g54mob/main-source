using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.UI;
using DV.UI.Inventory;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class CommsRadioController : MonoBehaviour
	{
		private const float AUDIO_SOURCE_MAX_DISTANCE = 10f;

		private const float CAR_AUDIO_SOURCE_MIN_DISTANCE = 10f;

		public LaserBeamLineRenderer laserBeam;

		public RerailController rerailControl;

		public JunctionRemoteLogic switchControl;

		public CommsRadioCarDeleter deleteControl;

		public CommsRadioCrewVehicle crewVehicleControl;

		public CommsRadioCarSpawner carSpawnerControl;

		public CommsRadioCargoLoader cargoLoaderControl;

		public CommsRadioPaintjob carPaintjobControl;

		public CommsRadioDamage carDamageControl;

		public CommsRadioStartup carStartupControl;

		public CommsRadioLight commsRadioLight;

		[Header("Buttons")]
		public GameObject buttonA;

		public GameObject buttonB;

		public GameObject buttonSide;

		[Header("Sounds")]
		public AudioClip selectionAction;

		private List<ICommsRadioMode> allModes;

		private int activeModeIndex;

		private ItemBase commsItem;

		private ItemScrolling scrolling;

		private Grabber nonVrGrabber;

		private AGrabHandler nonVrGrabHandler;

		private bool isNonVr;

		private bool preventUpdate = true;

		private HashSet<int> disabledModeIndices = new HashSet<int>();

		public ICommsRadioMode CurrentActiveMode { get; private set; }

		public event Action<ICommsRadioMode> ModeChanged;

		private void Awake()
		{
			if (switchControl == null || rerailControl == null || deleteControl == null || crewVehicleControl == null || carSpawnerControl == null || cargoLoaderControl == null || carPaintjobControl == null || carDamageControl == null || carStartupControl == null || commsRadioLight == null)
			{
				Debug.LogError("Not all mode references were set! Can't function properly!", this);
				return;
			}
			if (buttonA == null || buttonB == null || buttonSide == null)
			{
				Debug.LogError("Button references not set! CommsRadioController can't function properly!", this);
				return;
			}
			if (laserBeam == null)
			{
				Debug.LogError("laserBeam reference isn't set, can't control its on/off state!");
				return;
			}
			if (selectionAction == null)
			{
				Debug.LogError("selectionAction not set, can't play that sound!", this);
			}
			laserBeam.EnableBeam(enableBeam: false);
			allModes = new List<ICommsRadioMode> { switchControl, rerailControl, deleteControl, crewVehicleControl, carSpawnerControl, carStartupControl, cargoLoaderControl, carPaintjobControl, carDamageControl, commsRadioLight };
		}

		private void Start()
		{
			commsItem = GetComponent<ItemBase>();
			if (commsItem == null)
			{
				Debug.LogError("Can't get ItemBase attached to CommsRadioController, so it can't function properly!", this);
				return;
			}
			activeModeIndex = 0;
			SetMode(allModes[activeModeIndex]);
			UpdateModesAvailability();
			Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
			isNonVr = !VRManager.IsVREnabled();
			if (isNonVr)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(InitializeNonVr());
			}
			else
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingVR>();
				SetupListeners(on: true);
			}
			if (TutorialHelper.InRestrictedMode)
			{
				for (int i = 1; i < allModes.Count; i++)
				{
					disabledModeIndices.Add(i);
				}
			}
		}

		private IEnumerator InitializeNonVr()
		{
			nonVrGrabHandler = GetComponent<AGrabHandler>();
			if (nonVrGrabHandler == null)
			{
				Debug.LogError("Couldn't extract AGrabHandler from CommsRadioController!");
			}
			while (PlayerManager.PlayerCamera == null)
			{
				yield return null;
			}
			while (!SingletonBehaviour<HotbarController>.Instance)
			{
				yield return null;
			}
			nonVrGrabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
			if (nonVrGrabber == null)
			{
				Debug.LogError("Couldn't extract Grabber from player", this);
			}
			scrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			Transform signalOrigin = PlayerManager.PlayerCamera.transform;
			foreach (ICommsRadioMode allMode in allModes)
			{
				allMode.OverrideSignalOrigin(signalOrigin);
			}
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				CurrentActiveMode?.Disable();
			}
		}

		private void OnDestroy()
		{
			Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SwitchModeAllowed" || e.PropertyName == "CommsRadioSandboxCheatMode" || e.PropertyName == "CommsRadioCheatMode")
			{
				UpdateModesAvailability();
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				commsItem.Grabbed += OnGrabStart;
				commsItem.Ungrabbed += OnGrabEnd;
				commsItem.Used += OnUse;
				scrolling.Scrolled += OnScrolled;
				buttonA.GetComponent<ButtonBase>().Used += OnActionA;
				buttonB.GetComponent<ButtonBase>().Used += OnActionB;
				buttonSide.GetComponent<ButtonBase>().Used += OnUse;
				return;
			}
			commsItem.Grabbed -= OnGrabStart;
			commsItem.Ungrabbed -= OnGrabEnd;
			commsItem.Used -= OnUse;
			if ((bool)scrolling)
			{
				scrolling.Scrolled -= OnScrolled;
			}
			buttonA.GetComponent<ButtonBase>().Used -= OnActionA;
			buttonB.GetComponent<ButtonBase>().Used -= OnActionB;
			buttonSide.GetComponent<ButtonBase>().Used -= OnUse;
		}

		private void BigInventoryToggled(bool on)
		{
			CheckState();
		}

		private void OnScrolled(ScrollAction direction)
		{
			if (direction.IsPositive())
			{
				OnActionB();
			}
			else
			{
				OnActionA();
			}
		}

		private void OnUse()
		{
			if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
			{
				CurrentActiveMode.OnUse();
			}
		}

		private void OnGrabStart(ControlImplBase _)
		{
			SingletonBehaviour<InventoryViewBase>.Instance.inventoryUI.OpenedOrClosed += BigInventoryToggled;
			CheckState();
		}

		private void OnGrabEnd(ControlImplBase _)
		{
			SingletonBehaviour<InventoryViewBase>.Instance.inventoryUI.OpenedOrClosed -= BigInventoryToggled;
			CheckState();
		}

		private void CheckState()
		{
			bool flag = commsItem.IsGrabbed() && !SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpen;
			ToggleState(flag);
		}

		private void ToggleState(bool on)
		{
			if (on)
			{
				EnableModeUpdate(enableUpdate: true);
				CurrentActiveMode.Enable();
				laserBeam.SetBeamColor(CurrentActiveMode.GetLaserBeamColor());
				laserBeam.EnableBeam(enableBeam: true);
			}
			else
			{
				CurrentActiveMode.Disable();
				laserBeam.EnableBeam(enableBeam: false);
				EnableModeUpdate(enableUpdate: false);
			}
		}

		private void Update()
		{
			if (!preventUpdate && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				CurrentActiveMode.OnUpdate();
			}
		}

		private void EnableModeUpdate(bool enableUpdate)
		{
			preventUpdate = !enableUpdate;
		}

		private void SetNextMode()
		{
			int num = allModes.Count;
			while (true)
			{
				activeModeIndex = (activeModeIndex + 1) % allModes.Count;
				if (!disabledModeIndices.Contains(activeModeIndex))
				{
					break;
				}
				num--;
				if (num < 0)
				{
					Debug.LogError("Unexpected state: infinite loop prevention, all modes are disabled!");
					break;
				}
			}
			SetMode(allModes[activeModeIndex]);
		}

		private void SetPreviousMode()
		{
			int num = allModes.Count;
			while (true)
			{
				activeModeIndex = ((activeModeIndex <= 0) ? (allModes.Count - 1) : (activeModeIndex - 1));
				if (!disabledModeIndices.Contains(activeModeIndex))
				{
					break;
				}
				num--;
				if (num < 0)
				{
					Debug.LogError("Unexpected state: infinite loop prevention, all modes are disabled!");
					break;
				}
			}
			SetMode(allModes[activeModeIndex]);
		}

		private void SetMode(ICommsRadioMode newMode)
		{
			if (CurrentActiveMode != null)
			{
				CurrentActiveMode.Disable();
			}
			CurrentActiveMode = newMode;
			if (commsItem.IsGrabbed())
			{
				CurrentActiveMode.Enable();
			}
			CurrentActiveMode.SetStartingDisplay();
			laserBeam.SetBeamColor(CurrentActiveMode.GetLaserBeamColor());
			this.ModeChanged?.Invoke(CurrentActiveMode);
		}

		public void OnActionA()
		{
			switch (CurrentActiveMode.ButtonBehaviour)
			{
			case ButtonBehaviourType.Regular:
				SetPreviousMode();
				if (selectionAction != null)
				{
					selectionAction.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				break;
			case ButtonBehaviourType.Override:
				if (CurrentActiveMode.ButtonACustomAction() && selectionAction != null)
				{
					selectionAction.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				break;
			case ButtonBehaviourType.Ignore:
				break;
			}
		}

		public void OnActionB()
		{
			switch (CurrentActiveMode.ButtonBehaviour)
			{
			case ButtonBehaviourType.Regular:
				SetNextMode();
				if (selectionAction != null)
				{
					selectionAction.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				break;
			case ButtonBehaviourType.Override:
				if (CurrentActiveMode.ButtonBCustomAction() && selectionAction != null)
				{
					selectionAction.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				break;
			case ButtonBehaviourType.Ignore:
				break;
			}
		}

		public void UpdateModesAvailability()
		{
			GameParams gameParams = Globals.G.GameParams;
			bool switchModeAllowed = gameParams.SwitchModeAllowed;
			int num = allModes.IndexOf(switchControl);
			if (switchModeAllowed)
			{
				disabledModeIndices.Remove(num);
			}
			else
			{
				disabledModeIndices.Add(num);
				if (activeModeIndex == num)
				{
					SetNextMode();
				}
			}
			bool flag = SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode.Equals("FreeRoam");
			bool num2 = (gameParams.CommsRadioSandboxCheatMode && flag) || gameParams.CommsRadioCheatMode;
			int num3 = allModes.IndexOf(carSpawnerControl);
			int num4 = allModes.IndexOf(cargoLoaderControl);
			if (num2)
			{
				disabledModeIndices.Remove(num3);
				disabledModeIndices.Remove(num4);
			}
			else
			{
				disabledModeIndices.Add(num3);
				disabledModeIndices.Add(num4);
				if (activeModeIndex == num3 || activeModeIndex == num4)
				{
					SetNextMode();
				}
			}
			int num5 = allModes.IndexOf(carPaintjobControl);
			if (num2)
			{
				disabledModeIndices.Remove(num5);
			}
			else
			{
				disabledModeIndices.Add(num5);
				if (activeModeIndex == num5)
				{
					SetNextMode();
				}
			}
			int num6 = allModes.IndexOf(carDamageControl);
			if (num2)
			{
				disabledModeIndices.Remove(num6);
			}
			else
			{
				disabledModeIndices.Add(num6);
				if (activeModeIndex == num6)
				{
					SetNextMode();
				}
			}
			int num7 = allModes.IndexOf(carStartupControl);
			if (num2)
			{
				disabledModeIndices.Remove(num7);
			}
			else
			{
				disabledModeIndices.Add(num7);
				if (activeModeIndex == num7)
				{
					SetNextMode();
				}
			}
			bool num8 = SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode.Equals("Career");
			int num9 = allModes.IndexOf(crewVehicleControl);
			if (num8)
			{
				disabledModeIndices.Remove(num9);
				return;
			}
			disabledModeIndices.Add(num9);
			if (activeModeIndex == num9)
			{
				SetNextMode();
			}
		}

		public static void PlayAudioFromRadio(AudioClip clip, Transform sourceTransform)
		{
			if (!(clip == null))
			{
				clip.Play(sourceTransform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, sourceTransform);
			}
		}

		public static void PlayAudioFromCar(AudioClip clip, TrainCar audioOriginCar, bool parentToWorld = false)
		{
			if (!(clip == null) && !(audioOriginCar == null))
			{
				Transform parent = (parentToWorld ? WorldMover.OriginShiftParent : audioOriginCar.transform);
				clip.Play(audioOriginCar.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, parent);
			}
		}

		public void ActivateMode(Type type)
		{
			foreach (ICommsRadioMode allMode in allModes)
			{
				if (!allMode.GetType().IsAssignableFrom(type))
				{
					continue;
				}
				int num = allModes.IndexOf(allMode);
				if (num >= 0)
				{
					bool flag = disabledModeIndices.Count == allModes.Count;
					if (disabledModeIndices.Remove(num) && flag)
					{
						SetNextMode();
					}
				}
				break;
			}
		}

		public void ActivateMode<T>() where T : ICommsRadioMode
		{
			ActivateMode(typeof(T));
		}

		public void DeactivateMode(Type type)
		{
			foreach (ICommsRadioMode allMode in allModes)
			{
				if (!allMode.GetType().IsAssignableFrom(type))
				{
					continue;
				}
				int num = allModes.IndexOf(allMode);
				if (num >= 0)
				{
					disabledModeIndices.Add(num);
					if (activeModeIndex == num)
					{
						SetNextMode();
					}
				}
				break;
			}
		}

		public void DeactivateMode<T>() where T : ICommsRadioMode
		{
			DeactivateMode(typeof(T));
		}

		public bool IsModeActivated(Type type)
		{
			foreach (ICommsRadioMode allMode in allModes)
			{
				if (allMode.GetType().IsInstanceOfType(type))
				{
					int num = allModes.IndexOf(allMode);
					if (num >= 0)
					{
						return !disabledModeIndices.Contains(num);
					}
					break;
				}
			}
			return false;
		}

		public bool IsModeActivated<T>() where T : ICommsRadioMode
		{
			return IsModeActivated(typeof(T));
		}

		public void ReactivateModes()
		{
			disabledModeIndices.Clear();
			UpdateModesAvailability();
		}
	}
}

using System;
using System.Collections.Generic;
using FuryStudios.FurySDK.Settings;
using Placemaker.Graphs;
using Placemaker.SceneProcessing;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class UiMaster : UIBehaviour, IOnScenePostProcess
	{
		public enum MenuState
		{
			Nothing = 0,
			Loading = 1,
			SideMenu = 2,
			SaveMenu = 4,
			FocusCard = 8,
			SunButton = 16,
			MouseAndTouch = 32,
			Gamepad = 64,
			Credits = 128,
			ControlLegend = 256,
			Settings = 512,
			ControlBinding = 1024,
			ControlListening = 2048,
			DialogWindow = 4096,
			KeyInputBlockingMask = 6029,
			CloseWhenClosingEverything = 8094
		}

		public interface IUiSetup
		{
			void OnStart(UiMaster master);

			void OnSetup(UiMaster master);
		}

		public interface IUiDimensionsChange
		{
			void OnDimensionsChange(UiMaster master);
		}

		public static UiMaster instance;

		public WorldMaster worldMaster;

		public SaveMenu saveMenu;

		public SettingsMenu settingsMenu;

		public SideMenu sideMenu;

		public PaletteMenu paletteMenu;

		public Dim dim;

		public GameViewRect gameViewRect;

		public LoadingUi loadingUi;

		public EventSystem eventSystem;

		public PinnedUiMobile pinnedUiMobile;

		public PlatformSettings furyPlatformSettings;

		public OrbitalCamera orbitalCamera;

		public MasterClicker masterClicker;

		public ActionInputManager actionInputManager;

		public GamepadScreenCursor gamepadScreenCursor;

		public InputModeManager inputModeManager;

		public ControlLegend controlLegend;

		public CommandFeedbacker undoFeedbacker;

		public CommandFeedbacker redoFeedbacker;

		public GamepadXboxDialog gamepadDisconnected;

		public GamepadXboxDialog gamepadConnected;

		public GamepadXboxDialog gamepadSuspended;

		[SerializeField]
		private GridButtons gridButton;

		[SerializeField]
		private ShadingButtons shadingButtons;

		[SerializeField]
		private Transform dimSibling;

		[SerializeField]
		private Transform loadingCanvas;

		[SerializeField]
		private MenuMusic newGameMusic;

		[SerializeField]
		private MenuMusic loadGameMusic;

		[NonSerialized]
		private List<IUiSetup> uiSetups;

		[SerializeField]
		private bool hasStarted;

		[NonSerialized]
		private bool hasSetup;

		public MenuState menuState;

		public Action<MenuState, MenuState> onMenuStateChange;

		[NonSerialized]
		private static List<UpdateState> states;

		public static System.Action onUpdate;

		public static System.Action onDimensionsChange0;

		public static System.Action onDimensionsChange1;

		public static System.Action onScaleChange;

		private Rect lastSafeArea;

		private int lastScreenWidth;

		private int lastScreenHeight;

		private float lastDpi;

		private ScreenOrientation lastOrientation;

		public float gamepadCursorSensitivity;

		public List<BaseButton> lockedButtons;

		public Player player;

		[SerializeField]
		private bool reinitializing;

		public GameObject prefabRewiredInputManager;

		public System.Action onSettingsLoaded;

		public Color messageColorWarning;

		public Color messageColorInfo;

		[SerializeField]
		private TextMeshProUGUI xboxUsername;

		[SerializeField]
		private float updateUiAfterScalingFrameCount;

		public HoverData hoverData => null;

		public ClickEffect clickEffect => null;

		public Maker maker => null;

		public Graph graph => null;

		public VoxelBobEffect voxelBobEffect => null;

		public bool CanTakeKeyInput()
		{
			return false;
		}

		public bool GamepadCursorShouldWork()
		{
			return false;
		}

		public void MaybeSetup()
		{
		}

		private void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void OnControllerDisconnect(ControllerStatusChangedEventArgs args)
		{
		}

		private void ControllerSetup(out bool joystickFound)
		{
			joystickFound = default(bool);
		}

		public static void SubscribeToSafeArea(RectTransform fullRect)
		{
		}

		private static void ApplySafeAreaToRt(RectTransform rt)
		{
		}

		public void Update()
		{
		}

		private void MaybeOnScreenChange()
		{
		}

		private void UpdateLastScreenValues()
		{
		}

		public static void AddState(UpdateState state)
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}

		public void AddMenuStateState(UpdateState updateState, MenuState menuState)
		{
		}

		public void SubscribeToMenuState(Action<MenuState, MenuState> onMenuStateChange)
		{
		}

		public void LoadMetaSave(MetaSave metaSave)
		{
		}

		public void CloseEverything()
		{
		}

		public void ResetUsersUIChoises()
		{
		}

		public void StartNew()
		{
		}

		public bool LoadString(string saveString)
		{
			return false;
		}

		public void StartFinishLoading(bool playNewSound = false)
		{
		}

		public Vector2 GetSmoothAxis2D(string nameX, string nameY)
		{
			return default(Vector2);
		}

		public void UpdateAntialiasing()
		{
		}

		public void UpdateVSync()
		{
		}

		public void UpdateFullScreen()
		{
		}

		private void CheckForNonLocalizedText()
		{
		}

		public string DefaultPath(string folderName)
		{
			return null;
		}
	}
}

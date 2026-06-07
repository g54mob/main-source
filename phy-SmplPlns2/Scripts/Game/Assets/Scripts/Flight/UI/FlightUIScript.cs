using System;
using Assets.Scripts.Analysis.Analytics;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat.Predictor;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Flight.UI.Events;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Flight.UI.Targeting;
using Assets.Scripts.GuiNew;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Lobbies;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Activity;
using Assets.Scripts.UI.Sharing;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.DevConsole;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class FlightUIScript : MonoBehaviour, IScreenshotDialogHandler, IFlightUI
	{
		public enum ActionButtonMode
		{
			Hidden = 0,
			Connect = 1,
			Launch = 2,
			Elevator = 3,
			GrabBlueprint = 4
		}

		public enum MultiplayerStateType
		{
			Server = 0,
			Client = 1,
			SinglePlayer = 2
		}

		public const string SelectedClassName = "btn-flight-selected";

		private CameraManagerScript _cameraScript;

		private ActionButtonMode _catapultButtonMode;

		private Widget _catapultConnectButton;

		private Widget _catapultLaunchButton;

		private WidgetContext _context;

		private AircraftControls _controls;

		private TextWidget _demoAirspaceWarningThreat;

		private TextWidget _demoAirspaceWarningWarning;

		private Widget _flapsSlider;

		private FlightFlyouts _flyouts;

		private bool _flyoutsClosedFrame;

		private Widget _grabBlueprintButton;

		private AircraftScript _localPlayerAircraft;

		private Widget _mainUI;

		private float _minTimeOfNextReload;

		private BoolSetting _mouseAsJoystickSetting;

		private MouseAsJoystickWidget _mouseAsJoystickWidget;

		private MultiplayerStateType _multiplayerState = MultiplayerStateType.SinglePlayer;

		private string _nudgeClass;

		private Widget _nudgingPanels;

		[SerializeField]
		private PredictorControllerScriptFlat _predictor;

		private Widget _recenterButton;

		[SerializeField]
		private FlightScreenInputScript _screenInput;

		private TargetingPodCameraController _targetingPodCameraController;

		private Widget _targetingPodDisabled;

		private TargetingScriptJuicy _targetingSystem;

		private Widget _triggerElevatorButton;

		private Widget _trimSlider;

		private bool _visible = true;

		private Widget _vtolSlider;

		[SerializeField]
		private XrUiScript _xrUiScript;

		public static bool UIHidden { get; set; }

		public ActivationPanelScript ActivationPanel { get; private set; }

		public ActivityManagerUIScript ActivityManagerUI { get; private set; }

		public IFlightFlyouts Flyouts => _flyouts;

		public InstrumentPanelScript InstrumentPanel { get; private set; }

		public bool IsPointerInsideGameView => _screenInput.IsPointerInside;

		public float LoadCraftCooldown => Mathf.Max(0f, _minTimeOfNextReload - Time.unscaledTime);

		public Camera MainCamera { get; private set; }

		public MessageManager MessageManager { get; private set; }

		public bool MouseAsJoystick
		{
			get
			{
				return Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickEnabled.Value;
			}
			set
			{
				Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickEnabled.Value = value;
			}
		}

		public MultiplayerStateType MultiplayerState => _multiplayerState;

		public IRadioPanel RadioPanel { get; private set; }

		public Widget RootWidget => _context.Root;

		public Camera SceneCamera => MainCamera;

		public bool ShowSignedAirspeedSpeeds { get; set; }

		public TargetingScript TargetingSystem => _targetingSystem;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible != value)
				{
					_visible = value;
					Widget root = _context.Root;
					CanvasGroup canvasGroup = root.gameObject.AddMissingComponent<CanvasGroup>();
					canvasGroup.interactable = value;
					canvasGroup.blocksRaycasts = value;
					root.Opacity = (value ? 1f : 0f);
				}
			}
		}

		public XrUiScript XrUiScript => _xrUiScript;

		private bool RestartMenuVisible
		{
			get
			{
				return _context.Root.FindWidget("restart-menu").Visible;
			}
			set
			{
				Widget widget = _context.Root.FindWidget("restart-menu");
				if (value)
				{
					widget.Show(force: true);
				}
				else
				{
					widget.Hide(null, force: true);
				}
			}
		}

		public event Action CatapultButtonClicked;

		public event Action ElevatorButtonClicked;

		public event Action GrabBlueprintButtonClicked;

		public event EventHandler<MultiplayerStateChangedEventArgs> MultiplayerStateChanged;

		public void DisableHighlight()
		{
			throw new NotImplementedException();
		}

		public string GetExitConfirmationMessage()
		{
			return MultiplayerState switch
			{
				MultiplayerStateType.Server => "Are you sure you want to exit? This will shut down the server, and all connected players will be disconnected.", 
				MultiplayerStateType.Client => "Are you sure you want to leave the server and return to the main menu?", 
				_ => "Are you sure you want to exit and return to the main menu?", 
			};
		}

		public void HighlightUiElement(string name, Vector2 offset, Vector2 size)
		{
			throw new NotImplementedException();
		}

		void IScreenshotDialogHandler.OnScreenshotDialogActivated(bool activated)
		{
		}

		public void OnTargetingPodCameraModeChanged(TargetingPodCameraController targetingPodCameraController)
		{
			_targetingPodCameraController = targetingPodCameraController;
			_targetingPodDisabled.Visible = targetingPodCameraController != null && !targetingPodCameraController.IsActive;
		}

		public bool OnToggleDamageVisualizer()
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraftScript != null)
			{
				aircraftScript.TogglePartDamageVisualizer();
			}
			return aircraftScript?.DamageVisualizerEnabled ?? false;
		}

		public void RepositionAndUprightCraft()
		{
			if (!Game.Instance.CurrentLevel.IsSandbox)
			{
				return;
			}
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			AircraftScript currentOrPreviousAircraft = localPlayer.CurrentOrPreviousAircraft;
			if (!currentOrPreviousAircraft.CriticallyDamaged)
			{
				float valueOrDefault = (localPlayer.Aircraft?.MainCockpit?.GetAltitudeAgl(1f)).GetValueOrDefault();
				StartLocation startLocation = new StartLocation(localPlayer.GlobalPosition, new Vector3(0f, localPlayer.Rotation.y, 0f), 0f, valueOrDefault < 10f);
				if (localPlayer.Aircraft == null)
				{
					localPlayer.EnterPreviousAircraft();
				}
				PositionUtility.PositionAtAvailableLocation(startLocation, currentOrPreviousAircraft, allowRepositioning: false, floatOriginToLocation: true);
				ShowMessage("Repositioned and uprighted your craft");
			}
			else
			{
				ShowMessage("You cannot reposition your craft because it's destroyed.");
			}
		}

		public void Restart()
		{
			RestartAsync().Forget();
		}

		public void RestartHere()
		{
			if (Game.Instance.CurrentLevel.IsSandbox)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				FlightScenePlayer localPlayer = instance.LocalPlayer;
				AircraftScript aircraft = localPlayer.Aircraft;
				float valueOrDefault = (localPlayer.Aircraft?.MainCockpit?.GetAltitudeAgl(1f)).GetValueOrDefault();
				StartLocationData startingLocationOverride = instance.StartLocationManager.CreateTempStartingLocation("Restart Here", localPlayer.GlobalPosition, new Vector3(0f, localPlayer.Rotation.y, 0f), (valueOrDefault > 10f) ? aircraft.Velocity : Vector3.zero, valueOrDefault < 10f);
				Restart(startingLocationOverride);
			}
		}

		public void SetActionMode(ActionButtonMode mode)
		{
			if (_catapultButtonMode != mode)
			{
				_catapultLaunchButton.Visible = mode == ActionButtonMode.Launch;
				_catapultConnectButton.Visible = mode == ActionButtonMode.Connect;
				_triggerElevatorButton.Visible = mode == ActionButtonMode.Elevator;
				_grabBlueprintButton.Visible = mode == ActionButtonMode.GrabBlueprint;
				_catapultButtonMode = mode;
			}
		}

		public void SetDemoRestrictedAirspaceWarningVisibility(int level = 0)
		{
			switch (level)
			{
			case 0:
				_demoAirspaceWarningWarning.Hide();
				_demoAirspaceWarningThreat.Hide();
				break;
			case 1:
				_demoAirspaceWarningWarning.Show();
				_demoAirspaceWarningThreat.Hide();
				break;
			default:
				_demoAirspaceWarningWarning.Hide();
				_demoAirspaceWarningThreat.Show();
				break;
			}
		}

		void IScreenshotDialogHandler.SetSceneUIVisibility(bool visible)
		{
			Visible = visible;
		}

		public void SetTimeText(string text)
		{
			if (Game.Instance.XRDeviceManager.HmdActive)
			{
				XrUiScript.SetTimeText(text);
				return;
			}
			throw new NotImplementedException();
		}

		public void ShowActivationPanel()
		{
			InstrumentPanel.Widget.Hide();
			ActivationPanel.Widget.Show();
		}

		public void ShowInstrumentPanel()
		{
			ActivationPanel.Widget.Hide();
			InstrumentPanel.Widget.Show();
		}

		public void ShowLogMessage(string message, float time = 7f, bool highlighted = false)
		{
			MessageManager.ShowMessage(message, time, logMessage: true, highlighted);
		}

		void IScreenshotDialogHandler.ShowMessage(string message, float time)
		{
			ShowMessage(message, time);
		}

		public void ShowMessage(string message, float time = 7f, bool highlighted = false)
		{
			MessageManager.ShowMessage(message, time, logMessage: false, highlighted);
		}

		protected virtual void LateUpdate()
		{
			if (DebugInput.GetKeyDown(KeyCode.L) && DebugInput.GetKey(KeyCode.LeftControl))
			{
				BodyDragPhysics.EnableDragLift = !BodyDragPhysics.EnableDragLift;
				Debug.Log($"Body Drag Lift set to {BodyDragPhysics.EnableDragLift}");
			}
			_context?.LateUpdate();
			MessageManager.Update();
			_recenterButton.Visible = _cameraScript.Controller.IsRecenterAvailable;
		}

		protected virtual void OnDestroy()
		{
			if (Game.Instance.XRDeviceManager != null)
			{
				Game.Instance.XRDeviceManager.HmdActiveChanged -= OnHmdActiveChanged;
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.FlightSceneLoaded -= OnFlightSceneLoaded;
			instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
			instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			Game.Instance.NetworkGameManager.RemotePlayerJoined -= OnRemotePlayerJoined;
		}

		protected virtual void Start()
		{
			_cameraScript = FlightSceneScript.Instance.CameraScript;
			MainCamera = _cameraScript.MainCamera;
			_screenInput.InputHandler = _cameraScript;
			_context = Game.Instance.UserInterface.CreateContext(GetComponent<RectTransform>(), this);
			_context.LoadWidgetFromXml("Xml/Flight/FlightUI", null);
			Widget root = _context.Root;
			root.EventHandler = this;
			_mainUI = root.FindWidget("main-ui");
			_targetingPodDisabled = root.FindWidget("targeting-pod-disabled");
			RadioPanel = root.FindWidgetComponent<RadioPanelScript>("radio-panel");
			InstrumentPanel = root.FindWidgetComponent<InstrumentPanelScript>("instrument-panel");
			InstrumentPanel.Initialize(this, root);
			ActivationPanel = root.FindWidgetComponent<ActivationPanelScript>("activation-panel");
			ActivationPanel.Initialize(this, root);
			_flapsSlider = _context.Root.FindWidget("slider-flaps");
			_trimSlider = _context.Root.FindWidget("slider-trim");
			_vtolSlider = _context.Root.FindWidget("slider-vtol");
			Widget widget = root.FindWidget("targeting");
			_targetingSystem = widget.gameObject.AddComponent<TargetingScriptJuicy>();
			_targetingSystem.Initialize(this, root);
			MessageManager = new MessageManager(root.FindWidget("message-parent"));
			_catapultLaunchButton = root.FindWidget("catapult-launch-button");
			_catapultConnectButton = root.FindWidget("catapult-connect-button");
			_triggerElevatorButton = root.FindWidget("trigger-elevator-button");
			_grabBlueprintButton = root.FindWidget("grab-blueprint-button");
			_recenterButton = root.FindWidget("recenter-view-button");
			_flyouts = new FlightFlyouts(this, root);
			_flyouts.SelectedFlyoutChanged += SelectedFlyoutChanged;
			if (!Game.Instance.CurrentLevel.IsSandbox)
			{
				_context.Root.ExecuteOnWidgetsOfClass("sandbox-only", delegate(Widget x)
				{
					x.AddClass("disabled");
				});
			}
			if (!Game.Instance.Device.IsVRBuild || (SocialExt.IsSteam && SocialExt.Steam.IsRunningOnSteamDeck()))
			{
				_context.Root.ExecuteOnWidgetsOfClass("vr-only", delegate(Widget x)
				{
					x.AddClass("disabled");
				});
			}
			if (Device.IsDemoBuild)
			{
				_demoAirspaceWarningWarning = _context.Root.FindWidget<TextWidget>("demo-restricted-airspace-warning");
				_demoAirspaceWarningThreat = _context.Root.FindWidget<TextWidget>("demo-restricted-airspace-threat");
			}
			_predictor.Initialize(MainCamera, TargetingSystem, root);
			_mouseAsJoystickWidget = root.FindWidgetComponent<MouseAsJoystickWidget>("mouse-as-joystick");
			_mouseAsJoystickWidget.SetVisibility(visible: false);
			_mouseAsJoystickSetting = Game.Instance.Settings.Gameplay.Flight.MouseAsJoystickEnabled;
			ActivityManagerUI = root.FindWidgetComponent<ActivityManagerUIScript>("activity-manager-ui");
			_nudgingPanels = _context.Root.FindWidget("nudging-panels");
			OnHmdActiveChanged(Game.Instance.XRDeviceManager.HmdActive);
			Game.Instance.XRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
			UnityAnalytics.RestartTimer();
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.FlightSceneLoaded += OnFlightSceneLoaded;
			instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
			instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
			Game.Instance.NetworkGameManager.RemotePlayerJoined += OnRemotePlayerJoined;
			RefreshMultiplayerState(forceRefresh: true);
			DevConsoleApi.RegisterCommand("teleport", delegate(Vector3 position)
			{
				PositionUtility.TeleportPlayer(position, Vector3.zero, Vector3.zero);
			});
		}

		protected virtual void Update()
		{
			_localPlayerAircraft = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				GameInputs instance = GameInputs.Instance;
				if (instance.ToggleActivationPanel.GetButtonDownIfEnabled())
				{
					ToggleActivationPanel();
				}
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || instance.FlightToggleMenu.GetButtonDownIfEnabled())
				{
					if (Visible)
					{
						ToggleMenu();
					}
					else
					{
						Visible = true;
					}
				}
				else if (instance.Restart.GetButtonDownIfEnabled())
				{
					Restart();
				}
				else if (instance.RestartHere.GetButtonDownIfEnabled())
				{
					RestartHere();
				}
				else if (instance.RepositionAndUprightCraft.GetButtonDownIfEnabled())
				{
					RepositionAndUprightCraft();
				}
				else if (instance.ScreenshotMode.GetButtonDownIfEnabled())
				{
					Visible = !Visible;
				}
				else if (instance.ToggleWindSettings.GetButtonDownIfEnabled())
				{
					if (Game.Instance.CurrentLevel.IsSandbox)
					{
						Flyouts.Settings.Widget.GetComponentInChildren<SettingsPanelScript>(includeInactive: true).ToggleWindSettings();
					}
				}
				else if (instance.DamageVisualizer.GetButtonDownIfEnabled())
				{
					OnToggleDamageVisualizer();
				}
				else if (instance.LoadClipboardAircraft.GetButtonDownIfEnabled())
				{
					FlightSceneScript.Instance.LoadAircraftFromClipboardOrUrl();
				}
				if (_cameraScript.Controller.IsRecenterAvailable && instance.CameraRecenter.GetButtonDownIfEnabled())
				{
					_cameraScript.Controller.RecenterView();
				}
				if (DebugInput.GetKeyDown(KeyCode.M) && DebugInput.GetKey(KeyCode.LeftControl) && DebugInput.GetKey(KeyCode.LeftShift))
				{
					_multiplayerState = _multiplayerState switch
					{
						MultiplayerStateType.Server => MultiplayerStateType.Client, 
						MultiplayerStateType.Client => MultiplayerStateType.SinglePlayer, 
						MultiplayerStateType.SinglePlayer => MultiplayerStateType.Server, 
						_ => throw new NotImplementedException(), 
					};
					OnMultiplayerStateChanged();
					Debug.Log($"Changed multiplayer state to {_multiplayerState}");
				}
			}
			if (PauseManager.Paused)
			{
				Physics.SyncTransforms();
			}
			if (_targetingPodCameraController != null)
			{
				_targetingPodDisabled.Visible = !_targetingPodCameraController.IsTargetingPodActive;
			}
			_context.Root.EnableClass("craft-destroyed", FlightSceneScript.Instance.LocalPlayer?.CurrentOrPreviousAircraft?.CriticallyDamaged == true);
			UpdateMouseLook();
			UpdateMouseAsJoystick();
			_flyoutsClosedFrame = false;
		}

		private void CalibrateGyro()
		{
			throw new NotImplementedException();
		}

		private void OnCatapultButtonClicked(Widget widget)
		{
			this.CatapultButtonClicked?.Invoke();
		}

		private void OnChangeViewClicked(Widget widget)
		{
			if (widget.PointerEventData.pointerId == -2)
			{
				_cameraScript.SwitchToPreviousViewMode();
			}
			else
			{
				_cameraScript.SwitchToNextViewMode(displayMessage: true, saveAsDefault: true);
			}
		}

		private void OnEnterExitCraftClicked(Widget widget)
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if ((object)localPlayer.Aircraft != null)
			{
				localPlayer.ExitAircraft();
			}
			else
			{
				localPlayer.EnterPreviousAircraft();
			}
		}

		private void OnFlightSceneLoaded(object sender, EventArgs e)
		{
		}

		private void OnGrabBlueprintButtonClicked(Widget widget)
		{
			this.GrabBlueprintButtonClicked?.Invoke();
		}

		private void OnHmdActiveChanged(bool active)
		{
			if (Game.Instance.Device.IsAndroidVRBuild)
			{
				base.gameObject.SetActive(!active);
			}
		}

		private void OnMenuClicked(Widget widget)
		{
			Flyouts.Selected = Flyouts.Menu;
		}

		private void OnMultiplayerStateChanged()
		{
			_context.Root.ExecuteOnWidgetsOfClass("client-only", delegate(Widget x)
			{
				x.Visible = _multiplayerState == MultiplayerStateType.Client;
			});
			_context.Root.ExecuteOnWidgetsOfClass("server-only", delegate(Widget x)
			{
				x.Visible = _multiplayerState == MultiplayerStateType.Server;
			});
			_context.Root.ExecuteOnWidgetsOfClass("host-only", delegate(Widget x)
			{
				x.Visible = _multiplayerState == MultiplayerStateType.Server || _multiplayerState == MultiplayerStateType.SinglePlayer;
			});
			_context.Root.ExecuteOnWidgetsOfClass("single-player-only", delegate(Widget x)
			{
				x.Visible = _multiplayerState == MultiplayerStateType.SinglePlayer;
			});
			_context.Root.ExecuteOnWidgetsOfClass("multi-player-only", delegate(Widget x)
			{
				x.Visible = _multiplayerState != MultiplayerStateType.SinglePlayer;
			});
			if (_multiplayerState != MultiplayerStateType.SinglePlayer)
			{
				if (PauseManager.FastForwardEnabled)
				{
					PauseManager.SetFastForward(enabled: false);
				}
				if (PauseManager.SlowMotionEnabled)
				{
					PauseManager.SetSlowMotion(enabled: false);
				}
				if (PauseManager.Paused)
				{
					PauseManager.RequestPauseChange(paused: false, userInitiated: false);
				}
			}
			PauseManager.AllowTimeScaleChanges = _multiplayerState == MultiplayerStateType.SinglePlayer;
			this.MultiplayerStateChanged?.Invoke(this, new MultiplayerStateChangedEventArgs
			{
				MultiplayerState = _multiplayerState
			});
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				InstrumentPanel.Widget.Show(force: true);
				_context.Root.FindWidget("analog-sticks").Visible = (TouchControlsType)Game.Instance.Settings.Gameplay.General.TouchControlsType != TouchControlsType.Off;
				_flapsSlider.Visible = e.Aircraft.RequiresFlapsSlider;
				_trimSlider.Visible = e.Aircraft.RequiresTrimSlider;
				_vtolSlider.Visible = e.Aircraft.RequiresVtolSlider;
				_controls = e.Aircraft.Controls;
				_context.Root.RemoveClass("avatar");
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				if (_controls != null)
				{
					_controls.MouseAxis = Vector2.zero;
					_controls = null;
				}
				ActivationPanel.Widget.Hide(null, force: true);
				InstrumentPanel.Widget.Hide(null, force: true);
				_flapsSlider.Hide(null, force: true);
				_trimSlider.Hide(null, force: true);
				_vtolSlider.Hide(null, force: true);
				_context.Root.AddClass("avatar");
			}
		}

		private void OnRecenterViewClicked(Widget widget)
		{
			_cameraScript.Controller.RecenterView();
		}

		private void OnRemotePlayerJoined(object sender, NetworkPlayerEventArgs e)
		{
			RefreshMultiplayerState(forceRefresh: false);
		}

		private void OnRepositionHereClicked(Widget widget)
		{
			RepositionAndUprightCraft();
			RestartMenuVisible = false;
		}

		private void OnRestartClicked(Widget widget)
		{
			Restart();
			RestartMenuVisible = false;
		}

		private void OnRestartHereClicked(Widget widget)
		{
			RestartHere();
			RestartMenuVisible = false;
		}

		private void OnRestartMenuClicked(Widget widget)
		{
			RestartMenuVisible = !RestartMenuVisible;
		}

		private void OnTriggerElevatorButtonClicked(Widget widget)
		{
			this.ElevatorButtonClicked?.Invoke();
		}

		private void RefreshMultiplayerState(bool forceRefresh)
		{
			MultiplayerStateType multiplayerStateType = MultiplayerStateType.SinglePlayer;
			SteamLobbyManager steamLobbyManager = Game.Instance.NetworkGameManager.SteamLobbyManager;
			if (steamLobbyManager != null && steamLobbyManager.IsInLobby)
			{
				multiplayerStateType = ((!steamLobbyManager.IsLobbyOwner) ? MultiplayerStateType.Client : MultiplayerStateType.Server);
			}
			else
			{
				NetworkPlayerScript networkPlayerScript = Game.Instance.NetworkGameManager?.LocalPlayer;
				multiplayerStateType = ((!(networkPlayerScript != null)) ? ((Game.Instance.NetworkGameManager.RemotePlayers.Count > 0) ? MultiplayerStateType.Client : MultiplayerStateType.SinglePlayer) : ((!networkPlayerScript.IsHostStarted) ? MultiplayerStateType.Client : MultiplayerStateType.Server));
			}
			if (_multiplayerState != multiplayerStateType || forceRefresh)
			{
				_multiplayerState = multiplayerStateType;
				OnMultiplayerStateChanged();
			}
		}

		private void Restart(StartLocationData startingLocationOverride)
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if (localPlayer.IsLoadingCraft)
			{
				Debug.LogError("Restart canceled because the player is currently loading a craft");
				return;
			}
			if (LoadCraftCooldown > 0f)
			{
				ShowMessage("You cannot restart your craft yet");
				return;
			}
			if (MultiplayerState != MultiplayerStateType.SinglePlayer)
			{
				_minTimeOfNextReload = Time.unscaledTime + 5f;
			}
			PauseManager.RequestPauseChange(paused: false, userInitiated: false);
			localPlayer.DespawnAircraft();
			if (startingLocationOverride != null)
			{
				localPlayer.StartLocation = startingLocationOverride;
			}
			else
			{
				StartLocationData currentStartLocation = FlightSceneScript.Instance.StartLocationManager.GetCurrentStartLocation();
				if (currentStartLocation != null)
				{
					localPlayer.StartLocation = currentStartLocation;
				}
			}
			localPlayer.SpawnAircraft();
		}

		private async UniTask RestartAsync()
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			StartLocationData startingLocationOverride = null;
			if (localPlayer.NetworkedActivity != null)
			{
				startingLocationOverride = await localPlayer.NetworkedActivity.RequestSpawnLocation(localPlayer);
			}
			Restart(startingLocationOverride);
		}

		private void SelectedFlyoutChanged(IFlyout flyout)
		{
			if (flyout == null)
			{
				_flyoutsClosedFrame = true;
			}
			else
			{
				_flyoutsClosedFrame = false;
			}
			string text = flyout?.Widget?.Data ?? null;
			if (_nudgeClass != text)
			{
				if (!string.IsNullOrWhiteSpace(_nudgeClass))
				{
					_nudgingPanels.EnableClass(_nudgeClass, enabled: false);
				}
				_nudgeClass = text;
				if (!string.IsNullOrWhiteSpace(_nudgeClass))
				{
					_nudgingPanels.EnableClass(_nudgeClass, enabled: true);
				}
			}
		}

		private void ShowTutorialStuff()
		{
		}

		private void ToggleActivationPanel()
		{
			if (ActivationPanel.Widget.Visible)
			{
				ShowInstrumentPanel();
			}
			else
			{
				ShowActivationPanel();
			}
		}

		private void ToggleMenu()
		{
			Flyouts.ToggleFlyout(Flyouts.Menu);
		}

		private void UpdateMouseAsJoystick()
		{
			if (!Application.isFocused)
			{
				return;
			}
			bool flag = MouseAsJoystick;
			bool flag2 = false;
			bool allowKeyboardInputs = Game.Instance.UserInterface.AllowKeyboardInputs;
			if (!_mouseAsJoystickSetting.Value)
			{
				MouseAsJoystick = false;
				flag = false;
			}
			else if (_localPlayerAircraft != null)
			{
				if (GameInputs.Instance.ToggleMouseJoystick.GetButtonDownIfEnabled() && allowKeyboardInputs && Game.Instance.UserInterface.FindGameObjectAtPosition(UnityEngine.Input.mousePosition)?.GetComponent<ButtonWidget>() == null)
				{
					MouseAsJoystick = !flag;
					flag2 = !flag;
					flag = !flag;
					if (LevelBase.CurrentLevel != null)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("Mouse as Joystick " + (flag ? "Enabled" : "Disabled"));
					}
				}
			}
			else if (flag)
			{
				MouseAsJoystick = false;
				flag = false;
			}
			if (flag2)
			{
				string dialogUserPrefKey = "MouseAsJoystickDialogDismissed";
				if (!Game.Instance.Settings.App.UserPrefs.GetBool(dialogUserPrefKey))
				{
					bool wasPaused = PauseManager.Paused;
					if (!wasPaused)
					{
						PauseManager.RequestPauseChange(paused: true, userInitiated: true);
					}
					MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
					messageDialogScript.Title = "Mouse as Joystick Enabled";
					messageDialogScript.MessageText = "You have enabled 'Mouse as Joystick' mode, which allows you to use the mouse cursor to control your craft's movement as if it was a joystick. This functionality is toggled with a <color=#FFFFFF><u>right mouse button click</u></color> by default.\n\nThe virtual joystick is centered when the mouse cursor is in the center of your screen. Moving the mouse up or down will provide pitch input and moving the mouse left or right will provide roll input.\n\nYou can disable this functionality now if you would prefer. It can always be re-enabled in the game settings under 'Game -> Flight -> Mouse As Joystick'. You can permanently dismiss this dialog by clicking 'Don't Show Again'.";
					messageDialogScript.ExtraWide = true;
					messageDialogScript.CancelButtonText = "Disable Feature";
					messageDialogScript.CancelClicked += delegate(MessageDialogScript d)
					{
						_mouseAsJoystickSetting.Value = false;
						MouseAsJoystick = false;
						d.Close();
					};
					messageDialogScript.MiddleButtonText = "Okay";
					messageDialogScript.MiddleClicked += delegate(MessageDialogScript d)
					{
						d.Close();
					};
					messageDialogScript.OkayButtonText = "Don't Show Again";
					messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
					{
						Game.Instance.Settings.App.UserPrefs.SetBool(dialogUserPrefKey, value: true);
						Game.Instance.Settings.App.Save();
						d.Close();
					};
					messageDialogScript.Closed += delegate
					{
						if (!wasPaused)
						{
							PauseManager.RequestPauseChange(paused: false, userInitiated: true);
						}
					};
				}
			}
			_mouseAsJoystickWidget.SetVisibility(flag && allowKeyboardInputs && Visible);
			if (_controls != null)
			{
				if (flag)
				{
					_controls.MouseAxis = InputWrapper.GetMouseAsJoystickAxis();
					_mouseAsJoystickWidget.UpdateFromMouse(UnityEngine.Input.mousePosition, _controls.MouseAxis);
				}
				else
				{
					_controls.MouseAxis = Vector3.zero;
				}
			}
		}

		private void UpdateMouseLook()
		{
			if (_cameraScript.Controller is FirstPersonCharacterCameraController { IsCockpitMode: false } firstPersonCharacterCameraController)
			{
				bool buttonDownIfEnabled = GameInputs.Instance.ToggleMouseLook.GetButtonDownIfEnabled();
				if ((!firstPersonCharacterCameraController.MouseLook) ? (buttonDownIfEnabled || (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && Flyouts.Selected == null) || _flyoutsClosedFrame) : (buttonDownIfEnabled || (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && Flyouts.Selected == Flyouts.Menu)))
				{
					firstPersonCharacterCameraController.MouseLook = !firstPersonCharacterCameraController.MouseLook;
				}
			}
		}
	}
}

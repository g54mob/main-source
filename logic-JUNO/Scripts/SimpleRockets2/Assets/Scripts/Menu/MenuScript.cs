using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Input;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using Assets.Scripts.Web;
using Jundroo.Services;
using ModApi.CelestialData;
using ModApi.Craft;
using ModApi.Planet;
using ModApi.State;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class MenuScript : MonoBehaviour
	{
		private static bool _firstMenuStart = true;

		private AboutPageScript _aboutPage;

		private CraftScript _craft;

		[SerializeField]
		private GameMenuScript _gameMenu;

		[SerializeField]
		private MenuAnimationScript _menuAnimation;

		[SerializeField]
		private ObjectViewerScript _objectViewer;

		private bool _playButtonClicked;

		private bool _suppressDialogBasedServiceInitialization;

		public static bool DisplayInProgressFlightDialog { get; set; }

		public static string ErrorDialogMessage { get; set; }

		public static bool PreviousCrashDetected { get; set; }

		public static bool SkipMainMenu { get; set; }

		public CraftScript Craft => _craft;

		public FlightStateData FlightStateData { get; private set; }

		public MenuAnimationScript MenuAnimationScript => _menuAnimation;

		public bool MissingFiles { get; private set; }

		public ObjectViewerScript ObjectViewer => _objectViewer;

		public SolarSystemDataScript SolarSystemData { get; private set; }

		public void LoadSelectedCraft(bool previewObject = true)
		{
			CraftDesigns craftDesigns = Game.Instance.CraftDesigns;
			GameState gameState = Game.Instance.GameState;
			if (!craftDesigns.HasCraft(gameState.SelectedCraftDesignId))
			{
				gameState.SelectedCraftDesignId = CraftDesigns.NewCraftId;
			}
			Action failureCallback = delegate
			{
				if (gameState.SelectedCraftDesignId != CraftDesigns.NewCraftId)
				{
					gameState.SelectedCraftDesignId = CraftDesigns.NewCraftId;
					LoadSelectedCraft();
				}
			};
			Game.Instance.CraftLoader.LoadCraftInteractive(gameState.SelectedCraftDesignId, delegate(CraftData craftData)
			{
				try
				{
					CraftScript craftScript = CraftBuilder.CreateCraftScript(craftData, createBodyScripts: false);
					SetCraft(craftScript);
					if (previewObject)
					{
						_objectViewer.PreviewObject(_craft?.gameObject, 0f, destroyWhenFinished: false);
					}
					if (Game.Instance.GameState.Mode == GameStateMode.Career && !Game.Instance.GameState.MenuTutorialComplete)
					{
						craftScript.gameObject.SetActive(value: false);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					failureCallback();
				}
			}, failureCallback);
		}

		public void OnCreditsClicked()
		{
			if (_aboutPage == null)
			{
				GameObject gameObject = UiUtilities.CreateUiGameObject("About", base.transform);
				_aboutPage = gameObject.AddComponent<AboutPageScript>();
				Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Menu/About", _aboutPage, delegate(IXmlLayoutController x)
				{
					_aboutPage.OnLayoutRebuilt((XmlLayoutController)x);
				});
			}
			_aboutPage.Show();
		}

		public void SetCraft(CraftScript craftScript)
		{
			if (_craft != null)
			{
				_craft.Unload();
				_craft = null;
			}
			_craft = craftScript;
			_menuAnimation.OnCraftLoaded(_craft);
			_gameMenu.OnCraftLoaded(_craft);
		}

		public void ShowListView(ListViewModel viewModel)
		{
			ListViewDialogScript listViewDialogScript = (UnityEngine.Object.Instantiate(Resources.Load("Ui/Prefabs/Dialog")) as GameObject).AddComponent<ListViewDialogScript>();
			listViewDialogScript.Initialize(viewModel, ObjectViewer);
			listViewDialogScript.transform.SetParent(base.transform, worldPositionStays: false);
			_gameMenu.gameObject.SetActive(value: false);
			if (listViewDialogScript.PreviewEnabled)
			{
				_objectViewer.Camera.clearFlags = CameraClearFlags.Color;
			}
			listViewDialogScript.Closed += delegate
			{
				_gameMenu.gameObject.SetActive(value: true);
				_objectViewer.Camera.clearFlags = CameraClearFlags.Depth;
				_objectViewer.PreviewObject(_craft?.gameObject, 0f, destroyWhenFinished: false);
			};
		}

		protected virtual void Awake()
		{
			Game.Loop.CreateGenericLoop();
			try
			{
				LoadSolarSystemData();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Failed to load game state.");
				ErrorDialogMessage = "Loading the save failed!\nCheck the log for more info";
				Game.Instance.GameState = Game.Instance.GameStateManager.CreateDefaultGameStateSet();
				LoadSolarSystemData();
			}
			_gameMenu.Initialize(this);
		}

		protected virtual void OnDestroy()
		{
			PreviousCrashDetected = false;
		}

		protected virtual async void Start()
		{
			if (!string.IsNullOrEmpty(Game.Instance.UrlHandler.PendingUrl) || Game.Instance.Settings.Game.General.SkipMainMenu.Value || Application.isEditor)
			{
				SkipMainMenu = true;
			}
			if (!MissingFiles && !PreviousCrashDetected)
			{
				bool num = Game.Instance.GameState?.IsDefault ?? true;
				if (!num)
				{
					LoadSelectedCraft(SkipMainMenu);
				}
				string planetName = (num ? "Droo" : Game.Instance.GameState.SelectedLaunchLocation?.PlanetName);
				_gameMenu.ShowMenuPlanet(planetName);
			}
			if (SkipMainMenu)
			{
				_playButtonClicked = true;
				_menuAnimation.ShowMainMenu(show: false, 0f, OnMenuVisible);
				if (PreviousCrashDetected)
				{
					ShowPreviousCrashDetectedDialog();
				}
				else if (!Game.Instance.GameStateManager.HasLoadableGameStates())
				{
					ShowNewGameDialog(allowCancel: false);
				}
			}
			SkipMainMenu = true;
			if (_firstMenuStart)
			{
				_firstMenuStart = false;
				if (Game.Instance.Device.IsEducationBuild)
				{
					Game.Instance.Settings.UserLogOut();
					Debug.Log("Legendary Status: true");
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					messageDialogScript.MessageText = "This is the education version of Juno: New Origins.\n\nClick OKAY to confirm that you are not running the game on a personally owned device.";
					messageDialogScript.CancelButtonText = "MORE INFO";
					messageDialogScript.CancelClicked += delegate
					{
						WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Education/MoreInfo");
					};
				}
			}
			if (!string.IsNullOrWhiteSpace(ErrorDialogMessage))
			{
				string errorDialogMessage = ErrorDialogMessage;
				ErrorDialogMessage = null;
				await Game.Instance.UserInterface.CreateErrorDialog(errorDialogMessage);
			}
		}

		protected virtual void Update()
		{
			if (DebugInput.GetKeyUp(KeyCode.R) && DebugInput.GetKey(KeyCode.LeftShift) && !Game.Instance.UserInterface.AnyDialogsOpen)
			{
				_menuAnimation.ShowMainMenu(!_menuAnimation.MainMenuVisible);
			}
			else if (!_playButtonClicked && InputWrapper.GetAnyKeyboardOrControllerButtonDown())
			{
				OnPlayButtonClicked();
			}
		}

		private void LoadSolarSystemData()
		{
			FlightStateData = Game.Instance.GameState.LoadFlightStateData();
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			PlanetarySystemFileData planetarySystem = FlightStateData.PlanetarySystem;
			CelestialFile file = celestialDatabase.GetFile(FlightStateData.PlanetarySystemFileReference);
			if (planetarySystem == null || file == null)
			{
				Debug.LogError("The current flight state's planetary system could not be found.");
			}
			else if (celestialDatabase.IsMissingFiles(planetarySystem))
			{
				Debug.LogError("The current flight state's planetary system '" + planetarySystem.Name + "' (" + planetarySystem.FileId.ToString() + ") is missing required files.");
				celestialDatabase.LogMissingFiles(CelestialFileType.PlanetarySystem, FlightStateData.PlanetarySystemFileReference);
			}
			else
			{
				SolarSystemData = SolarSystemDataScript.CreateFromFile(file, createTerrainData: false, applyScaleAndOverrides: true);
			}
			MissingFiles = SolarSystemData == null;
			if (!MissingFiles)
			{
				try
				{
					Game.Instance.GameState.InitializeDefaultSandboxLaunchLocations(SolarSystemData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private async void OnMenuVisible()
		{
			if (_suppressDialogBasedServiceInitialization)
			{
				return;
			}
			try
			{
				await ServicesCommon.InitializeDialogBasedServicesIfNecessary();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnPlayButtonClicked()
		{
			_playButtonClicked = true;
			_aboutPage?.Close();
			_menuAnimation.ShowMainMenu(show: false, 1f, OnMenuVisible);
			if (PreviousCrashDetected)
			{
				ShowPreviousCrashDetectedDialog();
			}
			else if (DisplayInProgressFlightDialog)
			{
				DisplayInProgressFlightDialog = false;
				ShowInProgressFlightDialog();
			}
			else if (!Game.Instance.GameStateManager.HasLoadableGameStates())
			{
				ShowNewGameDialog(allowCancel: false);
			}
		}

		private void ShowInProgressFlightDialog()
		{
			ModApi.Ui.MessageDialogScript d = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			d.MessageText = "A previous in-progress flight was detected. Would you like to keep this flight or revert your game to the state it was in before this flight launched?";
			d.OkayButtonText = "Undo Flight";
			d.CancelButtonText = "Keep Flight";
			d.OkayClicked += delegate
			{
				d.Close();
				Game.Instance.GameStateManager.RestoreGameStateTag(Game.Instance.GameState.Id, "PreFlight");
				Game.Instance.SceneManager.LoadMenu();
			};
			d.CancelClicked += delegate
			{
				d.Close();
			};
		}

		private void ShowNewGameDialog(bool allowCancel = true)
		{
			if (!allowCancel)
			{
				_suppressDialogBasedServiceInitialization = true;
			}
			_gameMenu.TopPanelVisible = false;
			NewGameDialogScript.Create(_gameMenu.transform, allowCancel).Closed += delegate
			{
				_gameMenu.TopPanelVisible = true;
			};
		}

		private void ShowPreviousCrashDetectedDialog()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
			messageDialogScript.MessageText = "A possible crash has been detected on the previous run. This was likely caused by your device running out of memory when trying to load crafts and/or planets.\n\nTo prevent further crashes, the loading of the selected craft and launch location will be skipped. You may want to consider selecting a different craft, planetary system, clearing out crafts in flight, or adjusting your quality settings to reduce memory usage before continuing.";
			messageDialogScript.OkayButtonText = "OK";
		}
	}
}

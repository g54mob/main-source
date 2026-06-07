using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Menu.ListView.Career;
using Assets.Scripts.Menu.Tutorial;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Settings;
using Assets.Scripts.Ui.Sharing.Download;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Web;
using ModApi;
using ModApi.CelestialData;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State;
using ModApi.State;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using Web.Client.Models;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Menu
{
	public class GameMenuScript : MonoBehaviour
	{
		private static string _whatsNewDownloadText;

		private XmlElement _activeCraftsButton;

		private int _availableTechNodes;

		private XmlElement _bottomPanel;

		private TextMeshProUGUI _buttonTextCareer;

		private Color _buttonTextCareerInitialColor;

		private TextMeshProUGUI _buttonTextTechTree;

		[SerializeField]
		private Camera _camera;

		private XmlElement _companyNameText;

		private XmlElement _fileMenu;

		[SerializeField]
		private GameObject _gameMenuControllerGameObject;

		[SerializeField]
		private Light _light;

		private MenuScript _menu;

		private XmlElement _missingFilesDownloadButton;

		private XmlElement _missingFilesLoadingImage;

		private XmlElement _missingFilesPanel;

		private Guid? _missingFilesPlanetarySystemId;

		private TextMeshProUGUI _missingFilesStatusLabel;

		private XmlElement _modsButton;

		[SerializeField]
		private MenuPlanetScript _planet;

		private List<PlanetNode> _planetNodes;

		private TextMeshProUGUI _rocketText;

		private TextMeshProUGUI _textActiveCrafts;

		private TextMeshProUGUI _textActiveJobs;

		private TextMeshProUGUI _textCraftMass;

		private TextMeshProUGUI _textCraftPrice;

		private TextMeshProUGUI _textMoney;

		private TextMeshProUGUI _textTechPoints;

		private XmlElement _topPanel;

		private XmlElement _whatsNewPanel;

		private TextMeshProUGUI _whatsNewText;

		public static bool IsFreemiumEnabled
		{
			get
			{
				bool result = false;
				if (Game.Instance.InAppPurchases.EnabledInBuild)
				{
					result = !Game.Instance.InAppPurchases.Features.CareerBundle.Unlocked || !Game.Instance.InAppPurchases.Features.SandboxBundle.Unlocked || !Game.Instance.InAppPurchases.Features.RemoveAds.Unlocked;
				}
				return result;
			}
		}

		public static bool ShowModsMenu { get; set; }

		public bool TopPanelVisible
		{
			get
			{
				return _topPanel.Visible;
			}
			set
			{
				if (value)
				{
					_topPanel.Show();
				}
				else
				{
					_topPanel.Hide();
				}
			}
		}

		public void HideWhatsNewPanel()
		{
			if (_whatsNewPanel.Visible)
			{
				_whatsNewPanel.Hide();
			}
		}

		public void HighlightText(TextMeshProUGUI text)
		{
			float t = (1f + Mathf.Sin(Time.time * 4f)) * 0.5f;
			text.color = Color.Lerp("#00b7ed".ToColor(), "#abb4be".ToColor(), t);
		}

		public void Initialize(MenuScript menuScript)
		{
			_menu = menuScript;
			XmlLayout xmlLayout = _gameMenuControllerGameObject.AddComponent<XmlLayout>();
			XmlLayoutController xmlLayoutController = _gameMenuControllerGameObject.AddComponent<XmlLayoutController>();
			xmlLayoutController.EventTarget = this;
			xmlLayoutController.OnLayoutRebuilt = delegate(XmlLayoutController x)
			{
				OnLayoutRebuilt(x.xmlLayout);
			};
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Menu/MenuUi", xmlLayout);
		}

		public void OnActiveCraftsButtonClicked()
		{
			ActiveCraftsViewModel activeCraftsViewModel = new ActiveCraftsViewModel(_menu.FlightStateData, _menu.SolarSystemData, _planetNodes);
			activeCraftsViewModel.Closed += OnActiveCraftsListViewClosed;
			_menu.ShowListView(activeCraftsViewModel);
		}

		public void OnContractsButtonClicked()
		{
			_fileMenu.Hide();
			UserInterface userInterface = Game.Instance.UserInterface as UserInterface;
			CareerDialogScript dialog = userInterface.CreateCareerDialog();
			dialog.Contracts.ContractStatusChanged += delegate
			{
				UpdateStats();
			};
			dialog.Closed += delegate
			{
				if (dialog.RequiresSceneReload)
				{
					Game.Instance.SceneManager.ReloadCurrentScene();
				}
				else
				{
					UpdateStats();
				}
			};
		}

		public void OnCraftLoaded(CraftScript craftScript)
		{
			UpdateStats();
		}

		public void OnCreditsButtonClicked()
		{
			_fileMenu.Hide();
			_menu.OnCreditsClicked();
		}

		public void OnLoadGameButtonClicked()
		{
			_fileMenu.Hide();
			LoadGameViewModel viewModel = new LoadGameViewModel();
			_menu.ShowListView(viewModel);
		}

		public void OnMenuButtonClicked(XmlElement button)
		{
			ToggleFileMenu();
		}

		public void OnNewGameButtonClicked()
		{
			_fileMenu.Hide();
			NewGameDialogScript.Create(base.transform.parent, allowCancel: true);
		}

		public void ShowMenuPlanet(string planetName)
		{
			if (planetName == null)
			{
				if (Game.Instance.GameState.LaunchLocations.All((LaunchLocation x) => string.IsNullOrWhiteSpace(x.PlanetName)))
				{
					Debug.LogError("The planetary system has no valid launch locations.");
					Game.Instance.UserInterface.CreateErrorDialog("The planetary system has no valid launch locations.");
				}
				else
				{
					Debug.LogError("No launch location selected.");
					Game.Instance.UserInterface.CreateErrorDialog("No launch location selected.");
				}
				return;
			}
			if (_planetNodes == null)
			{
				_planetNodes = FlightState.LoadPlanetNodes(_menu.FlightStateData, _menu.SolarSystemData, includeLockedPlanets: true);
			}
			IPlanetNode planetNode = _planetNodes[0].FindPlanet(planetName);
			if (planetNode == null)
			{
				Debug.LogError("Unable to find planet '" + planetName + "' while trying to load the launch location cubemap.");
				return;
			}
			if (!_planet.IsInitialized)
			{
				_planet.Initialize(_light, _camera);
			}
			_planet.SetPlanetData(planetNode.PlanetData);
		}

		protected virtual void Update()
		{
			if (!Game.Instance.UserInterface.AnyDialogsOpen && !Game.Instance.UserInterface.IsTextInputFocused)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					if (Device.IsAndroidBuild)
					{
						ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript.MessageText = "Exit Game?";
						messageDialogScript.OkayButtonText = "Exit";
						messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
						{
							d.Close();
							Application.Quit();
						};
					}
					else
					{
						ToggleFileMenu();
					}
				}
				if (Game.Instance.Inputs.OpenPhotoLibrary.GetButtonDown())
				{
					PhotoLibraryDialogScript.Create(base.transform, PhotoLibraryDialogScript.PhotoLibraryDialogMode.ViewOnly);
				}
			}
			if (_menu.MissingFiles)
			{
				_missingFilesLoadingImage.rectTransform.Rotate(0f, 0f, -180f * Time.unscaledDeltaTime);
			}
			if ((Game.Instance.GameState.Career?.Contracts.NumContractsNotSeen ?? 0) > 0)
			{
				HighlightText(_buttonTextCareer);
			}
			else
			{
				_buttonTextCareer.color = _buttonTextCareerInitialColor;
			}
			if (_availableTechNodes > 0)
			{
				HighlightText(_buttonTextTechTree);
			}
		}

		private static string ScaleLowerCase(string s, float scale = 0.75f)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			if (s != null)
			{
				for (int i = 0; i < s.Length; i++)
				{
					if (!flag && char.IsLower(s[i]))
					{
						flag = true;
						stringBuilder.Append($"<size={(int)(scale * 100f)}%>");
					}
					else if (flag && !char.IsLower(s[i]))
					{
						flag = false;
						stringBuilder.Append("</size>");
					}
					stringBuilder.Append(s[i]);
				}
			}
			return stringBuilder.ToString();
		}

		private IEnumerator DownloadWhatsNewText()
		{
			_whatsNewDownloadText = string.Empty;
			string url = $"{Game.SimpleRocketsWebsiteUrl}/Releases/ClientWhatsNew?version={Game.Version}&store={Device.StoreId}";
			WebRequest request = WebRequest.Create(url);
			while (!request.IsDone)
			{
				yield return new WaitForEndOfFrame();
			}
			if (request.Error != null)
			{
				_whatsNewDownloadText = "Could not get the what's new text...Try again later.";
			}
			else
			{
				try
				{
					ClientResponse clientResponse = WebUtility.CreateClientResponse(request.Text);
					if (new Version(clientResponse.GetValue("Version")) <= Game.Version)
					{
						_whatsNewDownloadText = clientResponse.GetValue("Description");
					}
					else
					{
						Game.Instance.Settings.ShowWhatsNew = true;
						_whatsNewDownloadText = "A new version of Juno: New Origins is now available. Please update to get the new features and bug fixes.";
					}
				}
				catch (Exception)
				{
					_whatsNewDownloadText = "Could not get the What's New text. Please, try again later.";
				}
			}
			SetWhatsNewText(_whatsNewDownloadText);
		}

		private void OnActiveCraftsListViewClosed(ListViewModel model)
		{
			model.Closed -= OnActiveCraftsListViewClosed;
			UpdateStats();
		}

		private void OnBuildButtonClicked()
		{
			Game.Instance.BeginDesign(saveGameState: true);
		}

		private void OnCompanyNameClicked()
		{
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog(base.transform);
			inputDialogScript.InputText = Game.Instance.GameState.CompanyName;
			inputDialogScript.MessageText = "Enter Company Name";
			inputDialogScript.OkayClicked += OnCompanyNameEdited;
		}

		private void OnCompanyNameEdited(ModApi.Ui.InputDialogScript inputDialog)
		{
			Game.Instance.GameState.CompanyName = inputDialog.InputText;
			UpdateCompanyName();
			Game.Instance.GameState.Save();
			inputDialog.Close();
		}

		private void OnDownloadButtonClicked()
		{
			_fileMenu.Hide();
			WebUtility.OpenUrl(string.Format($"{Game.SimpleRocketsWebsiteUrl}/Crafts/Game?mobile={0}", Device.IsMobileBuild));
		}

		private void OnDownloadMissingFilesClicked()
		{
			if (_missingFilesPlanetarySystemId.HasValue)
			{
				_missingFilesDownloadButton.gameObject.SetActive(value: false);
				DownloadCelestialContentViewModel viewModel = new DownloadCelestialContentViewModel(_missingFilesPlanetarySystemId.Value, CelestialFileType.PlanetarySystem, skipSizeDialog: true, delegate(DownloadCelestialContentViewModel.DownloadCelestialContentSuccessful x)
				{
					x.ReloadScene();
				});
				DownloadContentDialogScript.Create(null, viewModel).Closed += delegate
				{
					_missingFilesDownloadButton.gameObject.SetActive(value: true);
				};
			}
		}

		private void OnExitButtonClicked()
		{
			Game.Quit();
		}

		private void OnFileMenuCloseClicked()
		{
			_fileMenu.SetActive(active: false);
		}

		private void OnLaunchButtonClicked()
		{
			if (_menu.Craft == null)
			{
				_menu.LoadSelectedCraft();
				return;
			}
			PlayViewModel viewModel = new PlayViewModel(_menu.Craft, _menu, PlayViewModelType.Default);
			_menu.ShowListView(viewModel);
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			if (_menu.MissingFiles)
			{
				xmlLayout.XmlElement.AddClass("missing-files");
			}
			_fileMenu = xmlLayout.GetElementById("file-menu");
			_topPanel = xmlLayout.GetElementById("top-panel");
			_bottomPanel = xmlLayout.GetElementById("bottom-panel");
			_whatsNewPanel = xmlLayout.GetElementById("whats-new");
			_whatsNewText = xmlLayout.GetElementById<TextMeshProUGUI>("whats-new-text");
			if (_whatsNewText != null)
			{
				_whatsNewText.gameObject.AddComponent<LinkTextScript>();
			}
			_companyNameText = xmlLayout.GetElementById("company-text");
			UpdateCompanyName();
			_rocketText = xmlLayout.GetElementById<TextMeshProUGUI>("rocket-text");
			xmlLayout.GetElementById<TextMeshProUGUI>("version-number-text").text = string.Format("v" + Game.Instance.VersionWithSuffix);
			_modsButton = xmlLayout.GetElementById("menu-button-mods");
			if (_modsButton != null && !Game.Instance.ModManagerScript.HasModSupport)
			{
				_modsButton.Hide();
			}
			_activeCraftsButton = xmlLayout.GetElementById("active-crafts-button");
			_missingFilesPanel = xmlLayout.GetElementById("missing-files-panel");
			_missingFilesLoadingImage = _missingFilesPanel.GetElementByInternalId("loading-image");
			_missingFilesStatusLabel = _missingFilesPanel.GetElementByInternalId<TextMeshProUGUI>("label-status");
			_missingFilesDownloadButton = _missingFilesPanel.GetElementByInternalId("download-button");
			NotificationPanelScript notificationPanelScript = xmlLayout.GetElementById("notification-panel").gameObject.AddComponent<NotificationPanelScript>();
			notificationPanelScript.Initialize(xmlLayout);
			XmlElement elementById = xmlLayout.GetElementById("notification-button");
			XmlElement elementById2 = xmlLayout.GetElementById("notification-button-image");
			NotificationButtonScript notificationButton = elementById.gameObject.AddComponent<NotificationButtonScript>();
			notificationButton.Initialize(elementById2.gameObject, notificationPanelScript);
			elementById2.AddOnClickEvent(delegate
			{
				notificationButton.OnClick();
			});
			if (IsFreemiumEnabled)
			{
				xmlLayout.GetElementById("upgrade-button").SetActive(active: true);
			}
			foreach (XmlElement item in xmlLayout.GetElementsByClass("career-mode"))
			{
				item.SetActive(Game.IsCareer);
			}
			foreach (XmlElement item2 in xmlLayout.GetElementsByClass("sandbox-mode"))
			{
				item2.SetActive(!Game.IsCareer);
			}
			_textTechPoints = xmlLayout.GetElementById<TextMeshProUGUI>("tech-points-text");
			_textActiveCrafts = xmlLayout.GetElementById<TextMeshProUGUI>("active-crafts-text");
			_textActiveJobs = xmlLayout.GetElementById<TextMeshProUGUI>("active-jobs-text");
			_textMoney = xmlLayout.GetElementById<TextMeshProUGUI>("money-text");
			_textCraftPrice = xmlLayout.GetElementById<TextMeshProUGUI>("craft-price-text");
			_textCraftMass = xmlLayout.GetElementById<TextMeshProUGUI>("craft-mass-text");
			_buttonTextTechTree = xmlLayout.GetElementById<TextMeshProUGUI>("tech-tree-button-text");
			_buttonTextCareer = xmlLayout.GetElementById<TextMeshProUGUI>("career-button-text");
			_buttonTextCareerInitialColor = _buttonTextCareer.color;
			UpdateStats();
		}

		private void OnLoadCraftButtonClicked()
		{
			CraftDesignsViewModel craftDesignsViewModel = new CraftDesignsViewModel();
			bool refreshSelectedCraftOnCancel = false;
			craftDesignsViewModel.OnUserCanceled = delegate
			{
				if (refreshSelectedCraftOnCancel)
				{
					_menu.LoadSelectedCraft();
				}
			};
			craftDesignsViewModel.OnCraftDeleted = delegate(string craftId)
			{
				if (Game.Instance.GameState.SelectedCraftDesignId == craftId)
				{
					refreshSelectedCraftOnCancel = true;
				}
			};
			craftDesignsViewModel.OnCraftSelected = delegate(string craftId, CraftScript craftScript)
			{
				_menu.SetCraft(craftScript);
				Game.Instance.GameState.SelectedCraftDesignId = craftId;
				_menu.ObjectViewer.DestroyWhenFinished = false;
			};
			_menu.ShowListView(craftDesignsViewModel);
		}

		private void OnModsButtonClicked()
		{
			ModsViewModel viewModel = new ModsViewModel();
			_menu.ShowListView(viewModel);
		}

		private void OnPlanetStudioButtonClicked()
		{
			Game.Instance.SceneManager.LoadPlanetStudio();
		}

		private void OnRoadmapButtonClicked()
		{
			_fileMenu.Hide();
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Feedback/Roadmap");
		}

		private void OnSettingsButtonClicked()
		{
			_fileMenu.Hide();
			SettingsDialogScript.Create();
		}

		private void OnTechTreeButtonClicked()
		{
			Game.Instance.SceneManager.LoadTechTree();
		}

		private void OnTitleScreenButtonClicked()
		{
			_menu.MenuAnimationScript.ShowMainMenu(show: true);
		}

		private void OnUpgradeButtonClicked(XmlElement button)
		{
			Game.Instance.InAppPurchases.CreatePurchaseDialog(null);
		}

		private void OnWhatsNewButtonClicked()
		{
			_fileMenu.Hide();
			Game.Instance.Settings.ShowWhatsNew = !_whatsNewPanel.Visible;
			if (!Game.Instance.Settings.ShowWhatsNew)
			{
				Game.Instance.Settings.Save();
			}
			_whatsNewPanel.ToggleVisibility();
		}

		private IEnumerator QueryServerForMissingFiles()
		{
			FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
			GameMenuScript gameMenuScript = this;
			PlanetarySystemFileData planetarySystem = flightStateData.PlanetarySystem;
			gameMenuScript._missingFilesPlanetarySystemId = ((planetarySystem != null) ? new Guid?(planetarySystem.FileId) : flightStateData.PlanetarySystemFileReference.FileId);
			if (!_missingFilesPlanetarySystemId.HasValue)
			{
				UpdateMissingFilesDialog("The planetary system id could not be determined for this flight state. Unable to download the missing planetary system files from the website. Please use the file menu to load another game or create a new game.", showLoading: false, showDownload: false);
				yield break;
			}
			WebsiteRequest request = GetRequiredResources.CreateRequest(_missingFilesPlanetarySystemId.Value);
			request.SendRequest();
			yield return new WaitUntil(() => request.IsDone);
			if (!request.Success)
			{
				Debug.LogError(request.Error ?? "Web request failed");
				UpdateMissingFilesDialog("Unable to download the missing planetary system files from the website. Please use the file menu to load another game or create a new game.", showLoading: false, showDownload: false);
				yield break;
			}
			ResourceInfoResult resourceInfoResult = new ResourceInfoResult(request.Response);
			if (resourceInfoResult.Resources.Count == 0)
			{
				UpdateMissingFilesDialog("Unable to find the missing planetary system files on the website. Please use the file menu to load another game or create a new game.", showLoading: false, showDownload: false);
				yield break;
			}
			int num = 0;
			int num2 = 0;
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			foreach (ResourceInfoResult.ResourceInfo resource in resourceInfoResult.Resources)
			{
				if (!resource.Exists)
				{
					UpdateMissingFilesDialog("Unable to find all of the missing planetary system files on the website. Please use the file menu to load another game or create a new game.", showLoading: false, showDownload: false);
					yield break;
				}
				if (celestialDatabase.GetFile(Guid.Parse(resource.Hash)) == null)
				{
					num++;
					num2 += resource.Size;
				}
			}
			if (num == 0)
			{
				UpdateMissingFilesDialog("An error occurred trying to determine the missing planetary system files. Please use the file menu to load another game or create a new game.", showLoading: false, showDownload: false);
				yield break;
			}
			UpdateMissingFilesDialog("Click the download button below to begin downloading the missing files from the Juno: New Origins website. Alternatively, use the file menu to load another game or create a new game." + Environment.NewLine + Environment.NewLine + $"Download {num} files" + Environment.NewLine + "Estimated download size: " + Utilities.FormatMemorySize(num2) + "." + Environment.NewLine + Environment.NewLine, showLoading: false, showDownload: true);
		}

		private void SetWhatsNewText(string text)
		{
			if (_whatsNewText != null)
			{
				_whatsNewText.text = text;
				if (Game.Instance.Settings.ShowWhatsNew && Game.Instance.GameStateManager.HasLoadableGameStates())
				{
					_whatsNewPanel.Show();
				}
			}
		}

		private void ShowPlanetarySystemUpgradePrompt(PlanetarySystemFileData planetarySystem)
		{
			Version planetarySystemDeclinedUpgradeVersion = Game.Instance.GameState.UserSettings.PlanetarySystemDeclinedUpgradeVersion;
			if (planetarySystemDeclinedUpgradeVersion != null && planetarySystemDeclinedUpgradeVersion >= planetarySystem.UpgradeVersion.Version)
			{
				return;
			}
			if (planetarySystem.UpgradeVersion.FileId == new Guid("46fd03ba-01bc-0658-24bf-e7ba85c01175"))
			{
				UpgradePlanetarySystem(planetarySystem);
				return;
			}
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = $"A new version of the planetary system is available. Would you like to upgrade to version {planetarySystem.UpgradeVersion.Version}?";
			messageDialogScript.OkayButtonText = "UPGRADE";
			messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				GameState gameState = Game.Instance.GameState;
				gameState.UserSettings.PlanetarySystemDeclinedUpgradeVersion = planetarySystem.UpgradeVersion.Version;
				gameState.UserSettings.Save();
			};
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				UpgradePlanetarySystem(planetarySystem);
			};
		}

		private void Start()
		{
			if (_whatsNewDownloadText != null)
			{
				SetWhatsNewText(_whatsNewDownloadText);
			}
			else if (_whatsNewText != null)
			{
				StartCoroutine(DownloadWhatsNewText());
			}
			if (_menu.MissingFiles)
			{
				StartCoroutine(QueryServerForMissingFiles());
				return;
			}
			if (Game.Instance.GameState.IsDefault)
			{
				_bottomPanel.Hide();
				if (Game.Instance.GameStateManager.HasLoadableGameStates())
				{
					ToggleFileMenu();
				}
			}
			PlanetarySystemFileData planetarySystem = Game.Instance.CelestialDatabase.GetPlanetarySystem(_menu.SolarSystemData?.Id ?? Guid.Empty);
			if (planetarySystem == null)
			{
				Debug.LogError("Unable to find the current planetary system.");
			}
			else if (planetarySystem.UpgradeVersion != null)
			{
				ShowPlanetarySystemUpgradePrompt(planetarySystem);
			}
			if (ShowModsMenu)
			{
				OnModsButtonClicked();
				ShowModsMenu = false;
			}
			MenuTutorialPanelScript menuTutorialPanelScript = MenuTutorialPanelScript.ShowTutorial();
			if (menuTutorialPanelScript != null)
			{
				menuTutorialPanelScript.GameMenu = this;
			}
			else
			{
				CareerState career = Game.Instance.GameState.Career;
				if (career != null)
				{
					career.Contracts.PopulateContracts();
					_availableTechNodes = (Game.Instance.GameState.Career?.TechTree?.NumTechNodesPlayerCanAfford).GetValueOrDefault();
				}
			}
			MenuSceneLoadParameters menuSceneLoadParameters = Game.Instance.SceneManager.MenuSceneLoadParameters;
			if (menuSceneLoadParameters != null && menuSceneLoadParameters.OpenResumeCraftsListView)
			{
				OnActiveCraftsButtonClicked();
			}
			if (Game.Instance.GameState.NotSupported)
			{
				Game.Instance.UserInterface.CreateMessageDialog("This game state is outdated and is no longer supported. Please start a new game from the main menu.");
			}
		}

		private void ToggleFileMenu()
		{
			if (_fileMenu.Visible)
			{
				_fileMenu.Hide();
				return;
			}
			_fileMenu.Show();
			if (_menu.MissingFiles)
			{
				_missingFilesPanel.Hide();
			}
		}

		private void UpdateCompanyName()
		{
			_companyNameText.SetText(ScaleLowerCase(Game.Instance.GameState.CompanyName));
		}

		private void UpdateMissingFilesDialog(string statusText, bool showLoading, bool showDownload)
		{
			_missingFilesLoadingImage.gameObject.SetActive(showLoading);
			_missingFilesStatusLabel.SetText(statusText);
			_missingFilesDownloadButton.gameObject.SetActive(showDownload);
		}

		private void UpdateStats()
		{
			_activeCraftsButton.gameObject.SetActive(value: true);
			int num = _menu.FlightStateData.CraftNodes.Where((ICraftNodeData x) => x.HasCommandPod).Count();
			_activeCraftsButton.SetActive(num > 0);
			GameState gameState = Game.Instance.GameState;
			if (gameState.Career != null)
			{
				int num2 = (int)gameState.Career.TechTree.GetItemValue("MaxActiveCrafts").ValueAsFloat;
				_textTechPoints.text = $"{gameState.Career.TechTree.ResearchPoints}";
				_textActiveCrafts.text = $"{num} / {num2}";
				_textActiveJobs.text = $"{gameState.Career.Contracts.Active.Count} / {gameState.Career.Contracts.Active.Count + gameState.Career.Contracts.Generated.Count}";
				_textMoney.text = Units.GetMoneyString(gameState.Career.Money) ?? "";
			}
			if (_menu.Craft != null)
			{
				_textCraftPrice.text = Units.GetMoneyString(_menu.Craft.Data.Price) ?? "";
				_textCraftMass.text = Units.GetMassString(_menu.Craft.Mass) ?? "";
				_rocketText.text = ScaleLowerCase(_menu.Craft.Data.Name);
			}
		}

		private void UpgradePlanetarySystem(PlanetarySystemFileData planetarySystem)
		{
			try
			{
				GameState gameState = Game.Instance.GameState;
				Game.Instance.GameStateManager.CreateGameStateTag(gameState.Id, "PlanetarySystem_Upgrade_Backup");
				FlightStateData flightStateData = gameState.LoadFlightStateData();
				flightStateData.ChangePlanetarySystem(Game.Instance.CelestialDatabase.GetFile(planetarySystem.UpgradeVersion.FileId), useFilePath: false);
				flightStateData.Save();
				gameState.UserSettings.PlanetarySystemDeclinedUpgradeVersion = null;
				gameState.UserSettings.Save();
				Game.Instance.SceneManager.LoadMenu();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Game.Instance.UserInterface.CreateMessageDialog("An error occurred trying to upgrade the planetary system.");
			}
		}
	}
}

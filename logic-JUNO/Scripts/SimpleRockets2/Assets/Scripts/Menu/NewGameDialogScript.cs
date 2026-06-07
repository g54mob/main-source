using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Packages.SocialPlatforms;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Menu.ListView.Career;
using Assets.Scripts.PlanetStudio.UI;
using Assets.Scripts.State;
using Assets.Scripts.Tools;
using ModApi.Audio;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Services.Purchasing;
using ModApi.State;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class NewGameDialogScript : DialogScript
	{
		private bool _allowCancel;

		private bool _careerMode;

		private string _careerModePath = "Default";

		private TextMeshProUGUI _careerNameText;

		private XmlElement _careerSelectorPanel;

		private XmlElement _descriptionCareer;

		private XmlElement _descriptionSandbox;

		private XmlElement _form;

		private XmlElement _loading;

		private TMP_InputField _nameInput;

		private XmlElement _panel;

		private XmlElement _planetarySystemButton;

		private TextMeshProUGUI _planetarySystemButtonText;

		private XmlElement _planetarySystemPanel;

		private XmlElement _validationText;

		public CelestialFile PlanetarySystem { get; private set; }

		public static NewGameDialogScript Create(Transform parent, bool allowCancel)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Menu/NewGameDialog", parent, delegate(NewGameDialogScript d, IXmlLayoutController c)
			{
				d._allowCancel = allowCancel;
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public void OnCancelButtonClicked()
		{
			Close();
		}

		public void OnGameTypeChanged(bool careerMode)
		{
			UpdateGameType(careerMode);
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.ButtonClicked);
		}

		public void OnOkayButtonClicked()
		{
			string text = _nameInput.text ?? string.Empty;
			text = text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				_validationText.SetAndApplyAttribute("text", "Please enter a Company Name above.");
				_validationText.Show();
				return;
			}
			if (PlanetarySystem == null)
			{
				_validationText.SetAndApplyAttribute("text", "Please select a planetary system.");
				_validationText.Show();
				return;
			}
			_validationText.enabled = false;
			Game.Instance.GameState.Save();
			CelestialFileReference planetarySystemFileReference = GetPlanetarySystemFileReference(_careerMode ? _careerModePath : null);
			GameState gameState = Game.Instance.GameStateManager.CreateNewGameStateSet(planetarySystemFileReference, (!_careerMode) ? GameStateMode.Sandbox : GameStateMode.Career, _careerModePath);
			gameState.CompanyName = text;
			gameState.Save();
			Game.Instance.GameState = gameState;
			_loading.Show();
			_form.Hide();
			Close();
			if (!_careerMode && PlanetarySystem.Id != Game.Instance.CelestialDatabase.DefaultPlanetarySystemV1Id && PlanetarySystem.Id != Game.Instance.CelestialDatabase.DefaultPlanetarySystemV2Id)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CreateNonStockSystemSandbox);
			}
			if (Game.Instance.Analytics.Enabled)
			{
				try
				{
					Dictionary<string, object> eventData = new Dictionary<string, object> { 
					{
						"GameMode",
						gameState.Mode.ToString()
					} };
					Game.Instance.Analytics.LogEvent("NewGameStarted", eventData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			PartViewerScript.RegeneratePartIcons = true;
			Game.Instance.SceneManager.LoadMenu();
		}

		protected override void Start()
		{
			base.Start();
			_loading.Hide();
			_nameInput.onValueChanged.AddListener(delegate
			{
				_validationText.Hide();
			});
			SetDefaultPlanetarySystem();
			if (SocialExt.IsSteamDeckOrBigPicture)
			{
				StartCoroutine(SelectNameInputDelayedCoroutine(2.5f));
			}
			else if (!Game.Instance.Device.IsMobileBuild)
			{
				_nameInput.Select();
			}
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
			{
				OnOkayButtonClicked();
			}
		}

		private CelestialFileReference GetPlanetarySystemFileReference(string careerFolder)
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			if (string.IsNullOrEmpty(careerFolder))
			{
				if (PlanetarySystem.Id == celestialDatabase.DefaultPlanetarySystemV1Id)
				{
					return CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV1Id);
				}
				if (PlanetarySystem.Id == celestialDatabase.DefaultPlanetarySystemV2Id)
				{
					return CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV2Id);
				}
				if (PlanetarySystem.Path.InGameData)
				{
					return CelestialFileReference.CreateWithFileId(null, PlanetarySystem);
				}
				return CelestialFileReference.CreateWithFilePath(null, PlanetarySystem);
			}
			string stringAttribute = CareerState.GetCareerInfoXml(careerFolder).GetStringAttribute("solarSystemId", celestialDatabase.DefaultPlanetarySystemV2Id.ToString());
			return CelestialFileReference.CreateWithFileId(null, new Guid(stringAttribute));
		}

		private void OnCareerSelectorButtonClicked()
		{
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			if (features.IsFeatureUnlocked(features.CareerBundle, "unlock this setting.", features.CareerBundle))
			{
				CareerSelectorViewModel careerSelectorViewModel = new CareerSelectorViewModel();
				Game.Instance.UserInterface.CreateListView(careerSelectorViewModel);
				careerSelectorViewModel.Closed += delegate(ListViewModel l)
				{
					string careerModePath = l.ListView.SelectedItem?.ItemModel as string;
					_careerModePath = careerModePath;
					_careerNameText.text = _careerModePath;
				};
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_form = xmlLayout.GetElementById("form");
			_loading = xmlLayout.GetElementById("loading");
			_nameInput = xmlLayout.GetElementById<TMP_InputField>("name-input");
			_validationText = xmlLayout.GetElementById("validation-text");
			_descriptionCareer = xmlLayout.GetElementById("description-career");
			_descriptionSandbox = xmlLayout.GetElementById("description-sandbox");
			_planetarySystemPanel = xmlLayout.GetElementById("planetary-system-panel");
			_planetarySystemButton = xmlLayout.GetElementById("planetary-system-button");
			_planetarySystemButtonText = _planetarySystemButton.GetComponentInChildren<TextMeshProUGUI>();
			_careerSelectorPanel = xmlLayout.GetElementById("career-selector-panel");
			_careerNameText = xmlLayout.GetElementById<TextMeshProUGUI>("career-name-text");
			_careerNameText.text = _careerModePath;
			xmlLayout.GetElementById("cancel-button").SetActive(_allowCancel);
			_panel.SetAttribute("active", "false");
			UpdateGameType(careerMode: true);
		}

		private void OnPlanetarySystemButtonClicked()
		{
			PlanetarySystemListViewModel planetarySystemListViewModel = new PlanetarySystemListViewModel(PlanetarySystem);
			Game.Instance.UserInterface.CreateListView(planetarySystemListViewModel);
			planetarySystemListViewModel.Closed += delegate(ListViewModel l)
			{
				OnPlanetarySystemChanged((CelestialFile)(l.ListView.SelectedItem?.ItemModel));
			};
		}

		private void OnPlanetarySystemChanged(CelestialFile planetarySystem)
		{
			if (planetarySystem != null)
			{
				PlanetarySystemFileData planetarySystem2 = Game.Instance.CelestialDatabase.GetPlanetarySystem(planetarySystem.Id);
				_planetarySystemButtonText.text = planetarySystem2.Name;
				PlanetarySystem = planetarySystem;
			}
		}

		private IEnumerator SelectNameInputDelayedCoroutine(float delayInSeconds)
		{
			yield return new WaitForSeconds(delayInSeconds);
			_nameInput.Select();
		}

		private void SetDefaultPlanetarySystem()
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			OnPlanetarySystemChanged(celestialDatabase.GetFile(celestialDatabase.DefaultPlanetarySystemV2Id));
		}

		private void UpdateGameType(bool careerMode)
		{
			if (!(_descriptionSandbox != null))
			{
				return;
			}
			_careerMode = careerMode;
			if (_careerMode)
			{
				_descriptionCareer.Show();
				_descriptionSandbox.Hide();
				_planetarySystemPanel.Hide();
				SetDefaultPlanetarySystem();
				if (CareerState.GetAvailableCareerFolders().Count > 1)
				{
					if (Game.Instance.Device.IsFreemiumBuild && Game.Instance.Settings.NumberOfApplicationRuns < 2)
					{
						_careerSelectorPanel.Hide();
					}
					else
					{
						_careerSelectorPanel.Show();
					}
				}
			}
			else
			{
				_descriptionCareer.Hide();
				_descriptionSandbox.Show();
				_planetarySystemPanel.Show();
				_careerSelectorPanel.Hide();
			}
		}
	}
}

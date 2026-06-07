using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SteamIntegrations;
using TMPro;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UIScripts.UIReferences;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class ScenarioSelectorPanel : UIPanel
	{
		public enum Radioactivity
		{
			None = 0,
			Lower = 1,
			Low = 2,
			Normal = 3,
			Severe = 4,
			Extreme = 5
		}

		public enum Limit
		{
			Fifty = 0,
			OneHundred = 1,
			TwoHundred = 2,
			FiveHundred = 3,
			No = 4
		}

		public static string DefaultSimulationSettingsPath;

		[SerializeField]
		private ScenariosEditor scenarioEditorPanel;

		[SerializeField]
		private GameObject scenarioItemPrefab;

		[SerializeField]
		private Transform scenariosHolder;

		[SerializeField]
		private Transform challengesHolder;

		[SerializeField]
		private TextMeshProUGUI listTitle;

		[SerializeField]
		private List<GameObject> showWithScenarios = new List<GameObject>();

		[SerializeField]
		private List<GameObject> showWithChallenges = new List<GameObject>();

		[SerializeField]
		private TooltipTrigger pelletWarning;

		[SerializeField]
		private GameObject toSubscribedWorkshopItemButton;

		[SerializeField]
		private GameObject toSharedWorkshopItemButton;

		[SerializeField]
		private GameObject shareOnWorkshopButton;

		[SerializeField]
		private RawImage preview;

		[SerializeField]
		private Texture defaultPreview;

		[SerializeField]
		private GameObject noPreviewDisclaimer;

		[SerializeField]
		private TextMeshProUGUI scenarioName;

		[SerializeField]
		private TextMeshProUGUI scenarioDesc;

		[SerializeField]
		private TextMeshProUGUI starOneDesc;

		[SerializeField]
		private TextMeshProUGUI starTwoDesc;

		[SerializeField]
		private TextMeshProUGUI starThreeDesc;

		[SerializeField]
		private GameObject highScoreSection;

		[SerializeField]
		private TextMeshProUGUI highscore;

		[SerializeField]
		private TextMeshProUGUI championName;

		[SerializeField]
		private Image oneStarStar;

		[SerializeField]
		private Image twoStarStar;

		[SerializeField]
		private Image threeStarStar;

		[SerializeField]
		private BibiteGenePreviewer championPreview;

		[SerializeField]
		private Button startChallengeButton;

		[SerializeField]
		private GameObject noChampionSection;

		[SerializeField]
		private GameObject championSection;

		[SerializeField]
		private SettingDropdownReference sizeDropdownRef;

		[SerializeField]
		private SettingDropdownReference densityDropdownRef;

		[SerializeField]
		private SettingDropdownReference fertilityDropdownRef;

		[SerializeField]
		private SettingDropdownReference radioactivityDropdownRef;

		[SerializeField]
		private SettingDropdownReference limitDropdownRef;

		[SerializeField]
		private GameObject tpsSettingsPanel;

		[SerializeField]
		private GameObject tpsSettingsHolder;

		private FloatSettingDropdown sizeDropdown = new FloatSettingDropdown(ScenarioIndependentSettings.Instance.SimulationSize);

		private FloatSettingDropdown densityDropdown = new FloatSettingDropdown(ScenarioIndependentSettings.Instance.biomassDensity);

		private FloatSettingDropdown fertilityDropdown = new FloatSettingDropdown(ScenarioIndependentSettings.Instance.pelletGrowth);

		private List<ISettingHandle> settings;

		private EnumDropdown<Radioactivity> radioactivityDropdown = new EnumDropdown<Radioactivity>
		{
			name = "Radioactivity",
			defaultValue = Radioactivity.Normal,
			helperText = "Determines the background radiation level.\nThis will determine the minimum mutation level of the bibites independently of their genetic mutability"
		};

		private EnumDropdown<Limit> limitDropdown = new EnumDropdown<Limit>
		{
			name = "Limit Bibites",
			defaultValue = Limit.No,
			helperText = "Do you want to put a cap on how many bibites can exist at once?\nThis can help keep performances at a manageable level."
		};

		private List<ScenarioItemReference> items = new List<ScenarioItemReference>();

		public ScenarioItemReference selectedItem;

		public static string scenarioTitle;

		public static string scenarioDescription;

		public static bool scenarioHasIMG;

		public static bool scenarioIsOfficial;

		public static BibiteTemplate selectedChampion;

		public static Texture2D tex;

		private string defaultPath;

		private static IntSetting simTPS;

		private static IntSetting brainTPS;

		private static IntSetting decayTPS;

		private static IntSetting visionLookupFactor;

		private static IntSetting visionSensingFactor;

		private static LogIntSettingSlider simTPSSlider;

		private static LogIntSettingSlider brainTPSSlider;

		private static LogIntSettingSlider decayTPSSlider;

		private static LogIntSettingSlider visionLookupSlider;

		private static LogIntSettingSlider visionSensesSlider;

		private bool showingChallenges;

		private bool isChallenge;

		private bool steamEnabled;

		private SettingsGroupHandle tpsSettings = new SettingsGroupHandle
		{
			Settings = new List<ISettingHandle> { simTPSSlider, brainTPSSlider, decayTPSSlider, visionLookupSlider, visionSensesSlider }
		};

		public override void InitPanel()
		{
			defaultPath = Path.Combine(Application.persistentDataPath, DefaultSimulationSettingsPath);
			tex = new Texture2D(400, 400);
			tpsSettings.AssignHolder(tpsSettingsHolder);
			tpsSettings.CreateUIElements();
			sizeDropdown.InitUIElement(sizeDropdownRef);
			densityDropdown.InitUIElement(densityDropdownRef);
			fertilityDropdown.InitUIElement(fertilityDropdownRef);
			radioactivityDropdown.InitUIElement(radioactivityDropdownRef, OnRadioactivityChange);
			limitDropdown.InitUIElement(limitDropdownRef, OnLimitChange);
			settings = new List<ISettingHandle> { sizeDropdown, densityDropdown, fertilityDropdown, tpsSettings };
			simTPS.DefaultValue = UserSettings.simTPSDefault.val;
			brainTPS.DefaultValue = UserSettings.brainTPSDefault.val;
			decayTPS.DefaultValue = UserSettings.decayTPSDefault.val;
			visionLookupFactor.DefaultValue = UserSettings.visionLookupTPSDefault.val;
			visionSensingFactor.DefaultValue = UserSettings.visionSensesTPSDefault.val;
			ScenarioIndependentSettings.Instance.SimulationSize.OnChange.AddListener(UpdatePelletEstimation);
			ScenarioIndependentSettings.Instance.biomassDensity.OnChange.AddListener(UpdatePelletEstimation);
			steamEnabled = SteamManager.Initialized;
			if (!steamEnabled)
			{
				toSharedWorkshopItemButton.SetActive(value: false);
				toSubscribedWorkshopItemButton.SetActive(value: false);
				shareOnWorkshopButton.SetActive(value: false);
			}
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			championPreview.InitializePreview();
			ReloadList();
		}

		public void ReloadList()
		{
			items.ForEach(delegate(ScenarioItemReference i)
			{
				UnityEngine.Object.Destroy(i.gameObject);
			});
			items.Clear();
			foreach (string item in (IEnumerable<string>)Directory.GetFiles(defaultPath, "*.zip"))
			{
				CreateScenarioItem(item);
			}
			if (SteamManager.Initialized && SteamWorkshopManager.instance.scenarioItems != null)
			{
				foreach (WorkshopItem scenarioItem in SteamWorkshopManager.instance.scenarioItems)
				{
					CreateScenarioItem(scenarioItem.itemPath, scenarioItem);
				}
			}
			foreach (ScenarioItemReference item2 in items.OrderByDescending((ScenarioItemReference i) => i.rank))
			{
				item2.transform.SetAsFirstSibling();
			}
			SwitchList(scenario: true);
			tpsSettings.ResetValue();
		}

		public void CreateScenarioItem(string path, WorkshopItem item = null)
		{
			ScenarioItemReference component = UnityEngine.Object.Instantiate(scenarioItemPrefab, scenariosHolder).GetComponent<ScenarioItemReference>();
			FileInfo file = new FileInfo(path);
			if ((item == null) ? component.InitScenarioItem(file, this) : component.InitScenarioItemAsExternalWorkshopItem(file, this, item))
			{
				items.Add(component);
				if (component.isChallenge)
				{
					component.transform.SetParent(challengesHolder);
				}
			}
			else
			{
				UnityEngine.Object.Destroy(component.gameObject);
			}
		}

		public void SwitchList(bool scenario)
		{
			UpdateShowingList(scenario);
			SelectScenarioItem(null);
			if (!scenario)
			{
				selectedChampion = null;
				noChampionSection.SetActive(value: true);
				championSection.SetActive(value: false);
				startChallengeButton.interactable = false;
			}
		}

		public void UpdateShowingList(bool isScenario)
		{
			showingChallenges = !isScenario;
			scenariosHolder.gameObject.SetActive(isScenario);
			challengesHolder.gameObject.SetActive(!isScenario);
			listTitle.text = (isScenario ? "Scenarios" : "Challenges");
			showWithScenarios.ForEach(delegate(GameObject o)
			{
				o.SetActive(isScenario);
			});
			showWithChallenges.ForEach(delegate(GameObject o)
			{
				o.SetActive(!isScenario);
			});
		}

		public void SelectScenarioFromName(string selectedScenarioName)
		{
			ScenarioItemReference scenarioItemReference = items.FirstOrDefault((ScenarioItemReference i) => i.scenarioName == selectedScenarioName);
			if (scenarioItemReference != null)
			{
				SelectScenarioItem(scenarioItemReference);
			}
		}

		public void SelectScenarioItem(ScenarioItemReference item)
		{
			if (item == null)
			{
				item = (from i in items
					where i.isOfficial && i.isChallenge == showingChallenges
					orderby i.rank
					select i).First();
			}
			selectedItem = item;
			UpdateShowingList(!selectedItem.isChallenge);
			FileInfo info = item.info;
			using (ZipArchive zipArchive = ZipFile.Open(info.FullName, ZipArchiveMode.Read))
			{
				JObject jObject = SaveSystem.ReadJObjectFromArchive(zipArchive.GetEntry("scenario.info"));
				scenarioTitle = jObject["name"].ToString();
				scenarioDescription = jObject["desc"].ToString();
				scenarioIsOfficial = jObject["isOfficial"]?.ToObject<bool>() ?? false;
				scenarioName.text = scenarioTitle;
				scenarioDesc.text = scenarioDescription;
				isChallenge = false;
				if (jObject["isChallenge"] != null)
				{
					isChallenge = jObject["isChallenge"].ToObject<bool>();
				}
				Utility.Version version = Utility.Version.Parse(jObject["version"].ToString());
				ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault((ZipArchiveEntry e) => e.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase));
				zipArchive.GetEntry("img.png");
				scenarioHasIMG = zipArchiveEntry != null;
				if (scenarioHasIMG)
				{
					byte[] data = SaveSystem.ReadFileFromArchive(zipArchiveEntry);
					preview.texture = tex;
					tex.LoadImage(data);
					noPreviewDisclaimer.SetActive(value: false);
				}
				else
				{
					preview.texture = defaultPreview;
					noPreviewDisclaimer.SetActive(value: true);
				}
				SerializationHelper.DeserializeScenario(SaveSystem.GetSettingsOfSave(zipArchive), version, checkForModifiers: true);
				if (item.isExternal)
				{
					foreach (BibiteSettings bibite in ScenarioSettings.Instance.bibites)
					{
						if (bibite.isExternal)
						{
							bibite.filePath = Path.Combine(item.workshopItem.contentPath, bibite.filePath);
						}
					}
				}
				else
				{
					SaveSystem.CheckTemplatesOfArchive(zipArchive);
				}
				if (isChallenge)
				{
					DateTime lastWriteTime = File.GetLastWriteTime(info.FullName);
					if (scenarioIsOfficial && lastWriteTime > AppInitializer.lastOfficialScenariosImportTime + TimeSpan.FromSeconds(1.0))
					{
						ClosePanel();
						AppInitializer.ReImportOfficialScenarios();
						return;
					}
					ScenarioSettings.Instance.challengeParameters.star1Desc = jObject["star1"].ToString();
					ScenarioSettings.Instance.challengeParameters.star2Desc = jObject["star2"].ToString();
					ScenarioSettings.Instance.challengeParameters.star3Desc = jObject["star3"].ToString();
					ScenarioSettings.Instance.challengeParameters.challengeName = scenarioTitle;
					ScenarioSettings.Instance.challengeParameters.challengeDesc = scenarioDescription;
					starOneDesc.text = jObject["star1"].ToString();
					starTwoDesc.text = jObject["star2"].ToString();
					starThreeDesc.text = jObject["star3"].ToString();
					ChallengeScoreInfo highScoreOfChallenge = ChallengesProgress.GetHighScoreOfChallenge(scenarioTitle);
					bool flag = highScoreOfChallenge.starAttained > 0;
					oneStarStar.color = (flag ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
					twoStarStar.color = ((highScoreOfChallenge.starAttained > 1) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
					threeStarStar.color = ((highScoreOfChallenge.starAttained > 2) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
					highScoreSection.SetActive(flag);
					highscore.text = highScoreOfChallenge.score.ToString("F0");
					championName.text = highScoreOfChallenge.championName;
				}
				else
				{
					highScoreSection.SetActive(value: false);
				}
			}
			if (steamEnabled)
			{
				toSharedWorkshopItemButton.SetActive(item.isShared);
				toSubscribedWorkshopItemButton.SetActive(item.isExternal);
				shareOnWorkshopButton.SetActive(!item.isShared && !item.isExternal && !item.isOfficial);
			}
			UpdatePelletEstimation();
		}

		public void SelectChampion()
		{
			BibiteTemplateSelectorPanel.instance.OpenWithCallBacks(OnChampionSelected);
		}

		private void OnChampionSelected(BibiteTemplate champion)
		{
			selectedChampion = champion;
			if (champion != null)
			{
				championPreview.UpdateTemplate(champion);
				ScenarioSettings.Instance.challengeParameters.championSettings.fullPath = champion.fullPath;
				ScenarioSettings.Instance.challengeParameters.championSettings.filePath = champion.filePath;
				ScenarioSettings.Instance.challengeParameters.championSettings.templateName = champion.name;
			}
			noChampionSection.SetActive(champion == null);
			championSection.SetActive(champion != null);
			startChallengeButton.interactable = champion != null;
		}

		public void NewScenario()
		{
			SelectScenarioFromName("Default");
			scenarioTitle = "New Scenario";
			scenarioDescription = "";
			EditScenario();
		}

		public void NewChallenge()
		{
			SelectScenarioFromName("Default");
			scenarioTitle = "New Challenge";
			scenarioDescription = "";
			ScenarioSettings.Instance.challengeParameters = new ChallengeParameters();
			EditScenario();
		}

		public void EditScenario()
		{
			ClosePanel();
			scenarioEditorPanel.OpenPanel();
		}

		public void OpenSaveFolder()
		{
			string text = defaultPath;
			Process.Start("explorer.exe", "/root," + text.Replace("/", "\\"));
		}

		public void GoToWorkshopPageOfSelectedItem()
		{
			if (!(selectedItem == null) && selectedItem.workshopItem != null && steamEnabled)
			{
				WorkshopItemsPanel.instance.OpenPanelWithItemSelected(selectedItem.workshopItem);
			}
		}

		public void ShareSelectedItemToWorkshop()
		{
			if (!(selectedItem == null) && steamEnabled)
			{
				WorkshopItemsPanel.instance.ShareNewItemFromPath(selectedItem.info.FullName);
			}
		}

		private void UpdatePelletEstimation()
		{
			int num = ScenarioSettings.Instance.PelletNumberEstimation();
			int num2 = (ScenarioSettings.Instance.pelletCollision.val ? 5000 : 15000);
			if (num > num2)
			{
				pelletWarning.UpdateText("Potentially high number of pellets", "This simulation will contain an estimated " + num.ScientificFormat(1) + " pellets. This is considered a high number and could lead to low framerate depending on your computer. \n\rConsider selecting a smaller simulation or lowering the biomass density. Otherwise start at your discretion.");
				pelletWarning.gameObject.SetActive(value: true);
			}
			else
			{
				pelletWarning.gameObject.SetActive(value: false);
			}
		}

		public void StartSim(bool customScenario = false)
		{
			SimulationManager.gameName = scenarioTitle;
			if (UserSettings.AnalyticsConsent.val)
			{
				AnalyticsService.Instance.RecordEvent(new CustomEvent("ScenarioStarted")
				{
					{ "Name", scenarioTitle },
					{
						"IsOfficial",
						scenarioIsOfficial && !customScenario
					}
				});
			}
			GameManager.StartGame();
		}

		public void StartChallenge(bool asChallenge)
		{
			if (selectedChampion != null)
			{
				BibiteSettings championSettings = ScenarioSettings.Instance.challengeParameters.championSettings;
				championSettings.filePath = selectedChampion.filePath;
				championSettings.fullPath = selectedChampion.fullPath;
				ScenarioSettings.Instance.bibites.Add(championSettings);
			}
			if (!asChallenge)
			{
				ScenarioSettings.Instance.challengeParameters = null;
			}
			StartSim();
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(tex);
			foreach (ISettingHandle setting in settings)
			{
				setting.ReleaseDependencies();
			}
			ScenarioIndependentSettings.Instance.SimulationSize.OnChange.RemoveListener(UpdatePelletEstimation);
			ScenarioIndependentSettings.Instance.biomassDensity.OnChange.RemoveListener(UpdatePelletEstimation);
		}

		private void OnRadioactivityChange(Radioactivity radioactivity)
		{
			FloatSetting backgroundMutationChance = ScenarioSettings.Instance.backgroundMutationChance;
			FloatSetting backgroundMutationVariance = ScenarioSettings.Instance.backgroundMutationVariance;
			List<IRevertableAction> list = new List<IRevertableAction>();
			switch (radioactivity)
			{
			case Radioactivity.None:
				list.Add(backgroundMutationChance.SetValueNonRevertable(0f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0f));
				break;
			case Radioactivity.Lower:
				list.Add(backgroundMutationChance.SetValueNonRevertable(0.15f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0.01f));
				break;
			case Radioactivity.Low:
				list.Add(backgroundMutationChance.SetValueNonRevertable(0.5f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0.015f));
				break;
			case Radioactivity.Normal:
				list.Add(backgroundMutationChance.SetValueNonRevertable(1f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0.025f));
				break;
			case Radioactivity.Severe:
				list.Add(backgroundMutationChance.SetValueNonRevertable(2f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0.075f));
				break;
			case Radioactivity.Extreme:
				list.Add(backgroundMutationChance.SetValueNonRevertable(4f));
				list.Add(backgroundMutationVariance.SetValueNonRevertable(0.15f));
				break;
			}
			if (radioactivityDropdown.initialized)
			{
				UINavigationManager.AddRevertableActionToStack(new RevertableGroupAction(list));
			}
		}

		private void OnLimitChange(Limit limit)
		{
			BoolSetting limitBibiteBirth = ScenarioIndependentSettings.Instance.limitBibiteBirth;
			IntSetting bibiteLimit = ScenarioIndependentSettings.Instance.bibiteLimit;
			List<IRevertableAction> list = new List<IRevertableAction>();
			switch (limit)
			{
			case Limit.No:
				list.Add(limitBibiteBirth.SetValueNonRevertable(_value: false));
				list.Add(bibiteLimit.SetValueNonRevertable(50));
				break;
			case Limit.Fifty:
				list.Add(limitBibiteBirth.SetValueNonRevertable(_value: true));
				list.Add(bibiteLimit.SetValueNonRevertable(50));
				break;
			case Limit.OneHundred:
				list.Add(limitBibiteBirth.SetValueNonRevertable(_value: true));
				list.Add(bibiteLimit.SetValueNonRevertable(100));
				break;
			case Limit.TwoHundred:
				list.Add(limitBibiteBirth.SetValueNonRevertable(_value: true));
				list.Add(bibiteLimit.SetValueNonRevertable(200));
				break;
			case Limit.FiveHundred:
				list.Add(limitBibiteBirth.SetValueNonRevertable(_value: true));
				list.Add(bibiteLimit.SetValueNonRevertable(500));
				break;
			}
			if (limitDropdown.initialized)
			{
				UINavigationManager.AddRevertableActionToStack(new RevertableGroupAction(list));
			}
		}

		public void SetTPSSettingsAsDefault()
		{
			UserSettings.simTPSDefault.SetValue(simTPS.val);
			UserSettings.brainTPSDefault.SetValue(brainTPS.val);
			UserSettings.decayTPSDefault.SetValue(decayTPS.val);
			UserSettings.visionLookupTPSDefault.SetValue(visionLookupFactor.val);
			UserSettings.visionSensesTPSDefault.SetValue(visionSensingFactor.val);
			simTPS.DefaultValue = simTPS.val;
			brainTPS.DefaultValue = brainTPS.val;
			decayTPS.DefaultValue = decayTPS.val;
			visionLookupFactor.DefaultValue = visionLookupFactor.val;
			visionSensingFactor.DefaultValue = visionSensingFactor.val;
			simTPSSlider.PositionDefaultPointer();
			brainTPSSlider.PositionDefaultPointer();
			decayTPSSlider.PositionDefaultPointer();
			visionLookupSlider.PositionDefaultPointer();
			visionSensesSlider.PositionDefaultPointer();
		}

		static ScenarioSelectorPanel()
		{
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			DefaultSimulationSettingsPath = "Scenarios" + directorySeparatorChar;
			simTPS = ScenarioIndependentSettings.Instance.simTPS;
			brainTPS = ScenarioIndependentSettings.Instance.brainTPS;
			decayTPS = ScenarioIndependentSettings.Instance.decayTPS;
			visionLookupFactor = ScenarioIndependentSettings.Instance.visionLookupUpdateFactor;
			visionSensingFactor = ScenarioIndependentSettings.Instance.visionSenseUpdateFactor;
			simTPSSlider = new LogIntSettingSlider(simTPS, 2f);
			brainTPSSlider = new LogIntSettingSlider(brainTPS, 2f);
			decayTPSSlider = new LogIntSettingSlider(decayTPS, 2f);
			visionLookupSlider = new LogIntSettingSlider(visionLookupFactor, 2f);
			visionSensesSlider = new LogIntSettingSlider(visionSensingFactor, 2f);
		}
	}
}

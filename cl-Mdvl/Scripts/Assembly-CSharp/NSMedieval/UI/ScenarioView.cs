using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.GameDifficulty;
using NSMedieval.GameEventSystem;
using NSMedieval.Modding;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.UI.ScenarioEditor;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ScenarioView : GameStartView
	{
		[Header("Scenario Specific")]
		[SerializeField]
		private ScenarioEditView scenarioEditView;

		[SerializeField]
		private LayoutGroupView scenariosTabGroup;

		[SerializeField]
		private TMP_Text scenarioSummary;

		[SerializeField]
		private TMP_Text scenarioDetails;

		[SerializeField]
		private Transform customDivider;

		[SerializeField]
		private ModManipulationLayout modManipulationLayout;

		[SerializeField]
		private SoundButton createNewButton;

		[SerializeField]
		private SoundButton getWorkshopModsButton;

		[SerializeField]
		private ToggleButtonItemView scenarioDetailsToggle;

		[SerializeField]
		private ToggleButtonItemView gameParametersToggle;

		[SerializeField]
		private GameParametersLayoutItemView gameParametersLayoutItemView;

		[SerializeField]
		private Image scenarioImage;

		private GameParametersInstance gameParametersInstance;

		private readonly List<LayoutGroupItemView> scenarioTabs = new List<LayoutGroupItemView>();

		private int index = -1;

		private List<Scenario> scenarios;

		private Scenario selectedScenario;

		private int customStartIndex;

		private StringBuilder detailsSB = new StringBuilder();

		public override void Show()
		{
			base.Show();
			Repository<ScenarioRepository, Scenario>.Instance.Reload();
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(Initialize);
			base.MoreInfoPanel.Show();
		}

		private void Initialize()
		{
			customDivider.gameObject.SetActive(value: false);
			scenarios = new List<Scenario>();
			scenarios.AddRange(Repository<ScenarioRepository, Scenario>.Instance.GetDefaultScenarios());
			foreach (Scenario userScenario in Repository<ScenarioRepository, Scenario>.Instance.GetUserScenarios())
			{
				if (!ApplicationVersionUtils.IsValidScenarioVersion(userScenario.ModifiedOnVersion) || userScenario.LocKeys == null)
				{
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("obsolete_scenario_message").Replace("<preset_name>", userScenario.GetID());
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
					continue;
				}
				userScenario.TryMigrate();
				if (userScenario.VillagerConstraints.NumberOfVillagers >= 1)
				{
					scenarios.Add(userScenario);
				}
			}
			customStartIndex = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultScenarios().Count;
			this.index = ((this.index != -1) ? this.index : 0);
			scenarioTabs.SetAllActive(active: false);
			int num = 0;
			foreach (Scenario scenario in scenarios)
			{
				int index = num;
				LayoutGroupItemView next = scenarioTabs.GetNext(scenariosTabGroup);
				next.SetText(base.Localize.GetText(LocKeyUtils.GetName(scenario.LocKeys)));
				if (index == customStartIndex)
				{
					customDivider.gameObject.SetActive(value: true);
					customDivider.SetSiblingIndex(index);
				}
				next.GetComponent<SoundButton>().AddCleanListener(delegate
				{
					LoadScenarioDetails(index);
				});
				num++;
			}
			LoadScenarioDetails(this.index);
		}

		protected override void OnClickNext()
		{
			if (!(selectedScenario == null))
			{
				MonoSingleton<BlackBarMessageController>.Instance.HideAllMessages();
				base.StartController.SelectedScenario = selectedScenario;
				base.StartController.SelectedGameParameters = gameParametersInstance;
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.ChangeScenarioFromHomeScene(selectedScenario);
				base.OnClickNext();
			}
		}

		protected override void OnClickPrevious()
		{
			MonoSingleton<BlackBarMessageController>.Instance.HideAllMessages();
			base.OnClickPrevious();
		}

		private void LoadScenarioDetails(int index)
		{
			if (index < 0 || index >= scenarios.Count)
			{
				this.index = 0;
				Show();
				return;
			}
			scenarioImage.sprite = AssetUtils.GetSprite(scenarios[index].ImageId);
			gameParametersToggle.Initialize(OnGameParametersToggle);
			scenarioDetailsToggle.Initialize(OnScenarioDetailsToggle);
			InitializeScenarioDetails(index);
			if (index < customStartIndex)
			{
				modManipulationLayout.gameObject.SetActive(value: false);
			}
			else
			{
				if (index >= scenarios.Count)
				{
					return;
				}
				if (!MonoSingleton<ModManager>.Instance.GetScenarioModInstance(scenarios[index].GetID(), out var scenarioModInstance))
				{
					modManipulationLayout.gameObject.SetActive(value: false);
					return;
				}
				ModdingUtils.OnWorkshopShowPreview(scenarioModInstance, modManipulationLayout, delegate
				{
					scenarioEditView.EditScenario(selectedScenario);
				});
			}
		}

		private void InitGameParameters()
		{
			gameParametersInstance = new GameParametersInstance(selectedScenario.GameParameters);
			gameParametersLayoutItemView.Initialize(gameParametersInstance);
			gameParametersLayoutItemView.gameObject.SetActive(value: false);
		}

		private void InitializeScenarioDetails(int index)
		{
			this.index = index;
			for (int i = 0; i < scenarioTabs.Count; i++)
			{
				scenarioTabs[i].GroupItems[2].SetActive(this.index == i);
			}
			bool isEnabled;
			if (this.index >= scenarios.Count)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ScenarioView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Scenarios have ");
					messageBuilder.AppendFormatted(scenarios.Count);
					messageBuilder.AppendLiteral(" entries but index is ");
					messageBuilder.AppendFormatted(this.index);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				int num = 0;
				{
					foreach (Scenario scenario2 in scenarios)
					{
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ScenarioView.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Existing scenario ");
							messageBuilder2.AppendFormatted(num);
							messageBuilder2.AppendLiteral(": ");
							messageBuilder2.AppendFormatted(LocKeyUtils.GetName(scenario2.LocKeys));
						}
						Log.Info(messageBuilder2);
						num++;
					}
					return;
				}
			}
			Scenario scenario = (selectedScenario = scenarios[this.index]);
			InitGameParameters();
			detailsSB.Clear();
			detailsSB.AppendLine("<style=AltColorParagraphTitle>" + base.Localize.GetText(LocKeyUtils.GetName(scenario.LocKeys)).ToUpper() + "</style>");
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine(base.Localize.GetText(LocKeyUtils.GetInfo(scenario.LocKeys)) ?? "");
			detailsSB.AppendLine();
			string locKey = (string.IsNullOrEmpty(scenario.Difficulty) ? "scenario_difficulty_standard" : scenario.Difficulty);
			detailsSB.AppendFormat("scenario_additional_info".ToLocalized(), locKey.ToLocalized(), UiUtils.GetLocalizedSeason(scenario.StartSeason), scenario.VillagerConstraints.NumberOfVillagers);
			scenarioSummary.SetText(detailsSB.ToString());
			detailsSB.Clear();
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("<style=AlmParagraph>" + base.Localize.GetText("menu_starting_conditions") + "</style>");
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("starting_season").ToUpper() + "</b></style>");
			detailsSB.AppendLine("<style=Desc>" + UiUtils.GetLocalizedSeason(scenario.StartSeason) + "</style>");
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("starting_hour").ToUpper() + "</b></style>");
			detailsSB.AppendLine($"<style=Desc>{scenario.StartHour}</style>");
			if (!string.IsNullOrEmpty(scenario.StartEventId))
			{
				GameEvent byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID(scenario.StartEventId);
				if (byID != null)
				{
					detailsSB.AppendLine(string.Empty);
					detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("starting_event").ToUpper() + "</b></style>");
					detailsSB.AppendLine("<style=Desc>" + LocKeyUtils.GetName(byID.LocKeys).ToLocalized(BodyType.None) + "</style>");
				}
			}
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("scenario_condition_MapTypes").ToUpper() + "</b></style>");
			foreach (string startMapType in scenario.StartMapTypes)
			{
				NSMedieval.Model.MapNew.Map byID2 = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(startMapType);
				if (byID2 == null)
				{
					FVLogWarningInterpolationHandler messageBuilder3 = new FVLogWarningInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ScenarioView.cs");
					if (isEnabled)
					{
						messageBuilder3.AppendLiteral("Map type ");
						messageBuilder3.AppendFormatted(startMapType);
						messageBuilder3.AppendLiteral(" not found.");
					}
					Log.Warning(messageBuilder3);
				}
				else
				{
					detailsSB.AppendLine("<style=Desc><b>  - " + LocKeyUtils.GetName(byID2.LocKeys).ToLocalized() + "</b></style>");
				}
			}
			SerializableIdValuePair[] startingResources = scenario.StartingResources;
			if (startingResources != null && startingResources.Length != 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("<style=Altcolor><b>" + base.Localize.GetText("hud_lb_resources").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.StartingResources.Aggregate(detailsSB, (StringBuilder stringBuilder, SerializableIdValuePair item) => stringBuilder.AppendLine(TextFormatting.GetFormatedItemCount(item.Value, ResourceUtils.GetLocalizedResourceName(item.Id))));
			}
			SerializableIdValuePair[] startingEquipment = scenario.StartingEquipment;
			if (startingEquipment != null && startingEquipment.Length != 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("menu_equipment").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.StartingEquipment.Aggregate(detailsSB, (StringBuilder stringBuilder, SerializableIdValuePair item) => stringBuilder.AppendLine(TextFormatting.GetFormatedItemCount(item.Value, ResourceUtils.GetLocalizedResourceName(item.Id, showQuality: true, showMaterial: true))));
			}
			SerializableIdValuePair[] startingStructurePiles = scenario.StartingStructurePiles;
			if (startingStructurePiles != null && startingStructurePiles.Length != 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("menu_structure_piles").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.StartingStructurePiles.Aggregate(detailsSB, (StringBuilder stringBuilder, SerializableIdValuePair item) => stringBuilder.AppendLine(TextFormatting.GetFormatedItemCount(item.Value, BuildingUtils.GetLocalizedName(item.Id))));
			}
			ScenarioAnimalData[] startingAnimals = scenario.StartingAnimals;
			if (startingAnimals != null && startingAnimals.Length != 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("menu_animals").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.StartingAnimals.Aggregate(detailsSB, (StringBuilder stringBuilder, ScenarioAnimalData item) => stringBuilder.AppendLine(TextFormatting.GetFormatedItemCount(item.Count, AnimalUtils.GetLocalizedName(item.ID)) + " (" + base.Localize.GetText("general_" + item.BodyType.ToString().ToLower() + "_animal") + ", " + base.Localize.GetText("animal_type_" + item.AnimalType.ToString().ToLower()) + ")"));
			}
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("villager_constraints").ToUpper() + "</b></style><style=Desc>");
			detailsSB.AppendLine(string.Format("{0}: ({1})", base.Localize.GetText("number_of_villagers"), scenario.VillagerConstraints.NumberOfVillagers));
			detailsSB.AppendLine(string.Format("{0}: ({1}{2} ", base.Localize.GetText("villager_constraint_age_range"), scenario.VillagerConstraints.AgeRange.Min, base.Localize.GetText("general_age_short")) + string.Format("- {0}{1})", scenario.VillagerConstraints.AgeRange.Max, base.Localize.GetText("general_age_short")));
			detailsSB.AppendLine(string.Format("{0}: ({1}{2} ", base.Localize.GetText("villager_constraint_height_range"), scenario.VillagerConstraints.HeightRange.Min, base.Localize.GetText("general_cm")) + string.Format("- {0}{1})", scenario.VillagerConstraints.HeightRange.Max, base.Localize.GetText("general_cm")));
			detailsSB.AppendLine(string.Format("{0}: ({1}{2} ", base.Localize.GetText("villager_constraint_weight_range"), scenario.VillagerConstraints.WeightRange.Min, base.Localize.GetText("general_kg")) + string.Format("- {0}{1})", scenario.VillagerConstraints.WeightRange.Max, base.Localize.GetText("general_kg")));
			detailsSB.AppendLine(string.Format("{0}/{1}: ({2}% ", base.Localize.GetText("gender_male"), base.Localize.GetText("gender_female"), 100 - scenario.VillagerConstraints.ForceBodyType) + $"/ {scenario.VillagerConstraints.ForceBodyType}%)");
			detailsSB.AppendLine(string.Format("{0}/{1}: ({2}% ", base.Localize.GetText("general_christian"), base.Localize.GetText("general_pagan"), 100 - scenario.VillagerConstraints.ForceReligion) + $"/ {scenario.VillagerConstraints.ForceReligion}%)");
			if (scenario.VillagerConstraints.DefaultClothes.Count > 0)
			{
				detailsSB.AppendLine(base.Localize.GetText("general_clothes") + ":");
				detailsSB = scenario.VillagerConstraints.DefaultClothes.Aggregate(detailsSB, (StringBuilder stringBuilder, string item) => stringBuilder.AppendLine("<indent=5%>" + base.Localize.GetText(ResourceUtils.GetLocalizedResourceName(item, showQuality: true, showMaterial: true)) + "</indent>"));
			}
			if (scenario.VillagerConstraints.OverrideStats.Count > 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("override_stats").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.VillagerConstraints.OverrideStats.Aggregate(detailsSB, (StringBuilder stringBuilder, GameEvent.StatSetting item) => stringBuilder.AppendLine($"{base.Localize.GetText($"menu_{item.Stat}")} ({item.ValueRange.Min}-{item.ValueRange.Max})"));
			}
			if (scenario.VillagerConstraints.ForcedPerks.Count > 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("force_perks_chance").ToUpper() + "</b></style><style=Desc>");
				foreach (SerializableIdValuePair forcedPerk in scenario.VillagerConstraints.ForcedPerks)
				{
					Perk byID3 = Repository<PerkRepository, Perk>.Instance.GetByID(forcedPerk.Id);
					if (byID3 == null)
					{
						FVLogWarningInterpolationHandler messageBuilder3 = new FVLogWarningInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ScenarioView.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Perk ");
							messageBuilder3.AppendFormatted(forcedPerk.Id);
							messageBuilder3.AppendLiteral(" not found.");
						}
						Log.Warning(messageBuilder3);
					}
					else
					{
						detailsSB.AppendLine(string.Format("{0} ({1}%)", base.Localize.GetText(LocKeyUtils.GetName(byID3.LocKeys) ?? ""), forcedPerk.Value));
					}
				}
			}
			List<string> technologyUnlocked = scenario.TechnologyUnlocked;
			if (technologyUnlocked != null && technologyUnlocked.Count > 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("unlocked_tech").ToUpper() + "</b></style><style=Desc>");
				detailsSB = scenario.TechnologyUnlocked.Aggregate(detailsSB, (StringBuilder stringBuilder, string item) => stringBuilder.AppendLine(base.Localize.GetText("research_name_" + item) ?? ""));
			}
			Scenario.FactionFriendlinessOverride[] factionFriendlinessOverrides = scenario.FactionFriendlinessOverrides;
			if (factionFriendlinessOverrides != null && factionFriendlinessOverrides.Length != 0)
			{
				detailsSB.AppendLine(string.Empty);
				detailsSB.AppendLine("</style><style=Altcolor><b>" + base.Localize.GetText("faction_alignment_overrides").ToUpper() + "</b></style><style=Desc>");
				Scenario.FactionFriendlinessOverride[] factionFriendlinessOverrides2 = scenario.FactionFriendlinessOverrides;
				for (int num2 = 0; num2 < factionFriendlinessOverrides2.Length; num2++)
				{
					Scenario.FactionFriendlinessOverride factionFriendlinessOverride = factionFriendlinessOverrides2[num2];
					if (factionFriendlinessOverride.FactionTypeId == "non_partisan")
					{
						continue;
					}
					FactionType byID4 = Repository<FactionTypeRepository, FactionType>.Instance.GetByID(factionFriendlinessOverride.FactionTypeId);
					if (byID4 == null)
					{
						FVLogWarningInterpolationHandler messageBuilder3 = new FVLogWarningInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ScenarioView.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Faction type ");
							messageBuilder3.AppendFormatted(factionFriendlinessOverride.FactionTypeId);
							messageBuilder3.AppendLiteral(" not found.");
						}
						Log.Warning(messageBuilder3);
					}
					else
					{
						string arg = LocKeyUtils.GetName(byID4.LocKeys).ToLocalized();
						detailsSB.AppendLine($"{arg} ({factionFriendlinessOverride.FriendlinessRange.Min}, {factionFriendlinessOverride.FriendlinessRange.Max})");
					}
				}
			}
			detailsSB.Append("</style>");
			detailsSB.AppendLine(string.Empty);
			detailsSB.AppendLine("<style=Altcolor><b>" + base.Localize.GetText("menu_allowed_objectives") + "</b></style><style=Desc>");
			foreach (string allowedObjective in scenario.AllowedObjectives)
			{
				Objective byID5 = Repository<ObjectiveRepository, Objective>.Instance.GetByID(allowedObjective);
				if (!(byID5 == null) && !byID5.HideInScenario)
				{
					detailsSB.AppendLine(byID5.GetNameLocalized() ?? "");
				}
			}
			detailsSB.Append("</style>");
			detailsSB.AppendLine(string.Empty);
			OnScenarioDetailsToggle(isExpanded: false);
		}

		private void OnModsChanged()
		{
			if ((bool)this && base.gameObject.activeInHierarchy)
			{
				index = Mathf.Clamp(index - 1, 0, scenarios.Count - 1);
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(Show);
			}
		}

		private void Start()
		{
			createNewButton.onClick.AddListener(OnCreateNewClick);
			MonoSingleton<ModManager>.Instance.ModsChangedEvent += OnModsChanged;
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				getWorkshopModsButton.gameObject.SetActive(value: false);
				modManipulationLayout.gameObject.SetActive(value: false);
			}
			else
			{
				getWorkshopModsButton.gameObject.SetActive(value: true);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<ModManager>.IsInstantiated())
			{
				MonoSingleton<ModManager>.Instance.ModsChangedEvent -= OnModsChanged;
			}
		}

		private void OnScenarioDetailsToggle(bool isExpanded)
		{
			scenarioDetails.gameObject.SetActive(isExpanded);
			if (isExpanded)
			{
				scenarioDetails.SetText(detailsSB.ToString());
			}
		}

		private void OnGameParametersToggle(bool isExpanded)
		{
			gameParametersLayoutItemView.gameObject.SetActive(isExpanded);
		}

		private void OnCreateNewClick()
		{
			if (ModdingUtils.RootFolderAccessible())
			{
				scenarioEditView.CreateScenario();
			}
		}

		private void OnWorkshopClick()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.GetMods(new string[1] { ModTag.Scenario.ToString() });
		}

		private void OnEulaStatusChanged(bool accepted)
		{
			if (accepted)
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
				modManipulationLayout.gameObject.SetActive(value: true);
				getWorkshopModsButton.AddCleanListener(OnWorkshopClick);
				OnWorkshopClick();
				Initialize();
			}
		}

		private void OnEnable()
		{
			MonoSingleton<ModManager>.Instance.ModsChangedEvent += Show;
			if (MonoSingleton<EulaManager>.Instance.EulaAccepted)
			{
				modManipulationLayout.gameObject.SetActive(value: true);
				getWorkshopModsButton.AddCleanListener(OnWorkshopClick);
			}
			else
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent += OnEulaStatusChanged;
				modManipulationLayout.gameObject.SetActive(value: false);
				getWorkshopModsButton.AddCleanListener(MonoSingleton<EulaManager>.Instance.ShowPrompt);
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<ModManager>.IsInstantiated())
			{
				MonoSingleton<ModManager>.Instance.ModsChangedEvent -= Show;
			}
			if (MonoSingleton<EulaManager>.IsInstantiated())
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
			}
		}
	}
}

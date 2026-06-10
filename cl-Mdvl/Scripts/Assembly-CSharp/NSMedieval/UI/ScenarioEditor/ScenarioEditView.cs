using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.GameDifficulty;
using NSMedieval.GameEventSystem;
using NSMedieval.Modding;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditView : GameStartView
	{
		[SerializeField]
		private GameObject[] contentPanels;

		[SerializeField]
		private CustomGrouppedToggle[] contentToggles;

		[SerializeField]
		private TMP_InputField nameInputField;

		[SerializeField]
		private TMP_InputField infoInputField;

		[SerializeField]
		private TMP_InputField narrativeInputField;

		[SerializeField]
		private TMP_Dropdown startSeasonDropDown;

		[SerializeField]
		private ScenarioEditIntView startHourView;

		[SerializeField]
		private TMP_Dropdown startEventDropDown;

		[SerializeField]
		private TMP_Dropdown startEventScheduleDropDown;

		[SerializeField]
		private TMP_Dropdown difficultyDropDown;

		[SerializeField]
		private TMP_Text requiredLegendLabel;

		[SerializeField]
		[Header("Groups")]
		private RectTransform contentGroup;

		[SerializeField]
		private Transform mapTypeGroup;

		[SerializeField]
		private Transform resourcesGroup;

		[SerializeField]
		private Transform equipmentGroup;

		[SerializeField]
		private Transform structurePilesGroup;

		[SerializeField]
		private Transform animalsGroup;

		[SerializeField]
		private Transform villagerGroup;

		[SerializeField]
		private Transform perksGroup;

		[SerializeField]
		private Transform statsGroup;

		[SerializeField]
		private Transform clothesGroup;

		[SerializeField]
		private Transform technologyGroup;

		[SerializeField]
		[Header("Buttons")]
		private SoundButton addConditionButton;

		[SerializeField]
		private AddConditionsView addConditionsView;

		[SerializeField]
		[Header("Prefabs")]
		private ScenarioEditEntryView editViewPrefab;

		[SerializeField]
		private ScenarioEditIntView editIntViewPrefab;

		[SerializeField]
		private ScenarioEditIntRangeView editIntRangeViewViewPrefab;

		[SerializeField]
		private ScenarioEditListView editListViewPrefab;

		[SerializeField]
		private ScenarioEditIntIconView editIntIconViewPrefab;

		[SerializeField]
		private ScenarioEditResourceView editResourceViewPrefab;

		[SerializeField]
		private ScenarioEditStructurePileView editStructurePileViewPrefab;

		[SerializeField]
		private ScenarioEditEquipmentView editEquipmentViewPrefab;

		[SerializeField]
		private ScenarioEditAnimalView editAnimalViewPrefab;

		[SerializeField]
		private GameParametersLayoutItemView gameParametersLayoutItemView;

		[SerializeField]
		private ObjectiveSelectionView objectiveSelectionView;

		private GenerationSettings constants;

		private Dictionary<ScenarioEditEntryView, string> clothesEntries;

		private Dictionary<VillagerConstraint, ScenarioEditEntryView> constraintEntries;

		private Dictionary<ScenarioEditEntryView, SerializableIdValuePair> equipmentEntries;

		private Dictionary<ScenarioEditEntryView, Perk> perkEntries;

		private Dictionary<ScenarioEditEntryView, SerializableIdValuePair> resourceEntries;

		private Dictionary<ScenarioEditEntryView, StatType> statEntries;

		private Dictionary<ScenarioEditEntryView, SerializableIdValuePair> structurePileEntries;

		private Dictionary<ScenarioEditEntryView, string> technologyEntries;

		private Dictionary<ScenarioEditEntryView, ScenarioAnimalData> animalEntries;

		private Dictionary<ScenarioEditEntryView, string> mapentries;

		private Scenario.WorkerConstraints workerConstraints;

		private Scenario selectedScenario;

		private ScenarioSaveData saveData;

		private GameParametersInstance gameParametersInstance;

		private HashSet<string> allowedObjectives;

		private readonly List<string> startEventIds = new List<string>();

		private readonly List<string> startEventScheduleIds = new List<string>();

		private readonly List<string> difficultyIds = new List<string> { "scenario_difficulty_VeryEasy", "scenario_difficulty_standard", "scenario_difficulty_Difficult" };

		public List<VillagerConstraint> Constraints { get; private set; }

		public List<string> ClothesDistinctIDs { get; private set; }

		public List<Perk> Perks { get; private set; }

		public List<string> Resources { get; private set; }

		public List<string> ProtoEquipments { get; private set; }

		public List<string> StructurePiles { get; private set; }

		public List<string> Animals { get; private set; }

		public List<string> Technology { get; private set; }

		public List<StatType> StatOverrides { get; private set; }

		public List<string> MapTypes { get; private set; }

		public void CreateScenario()
		{
			ShowScreen(this);
			OnShowScreen();
			base.NextButton.interactable = false;
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				Load(Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario());
			});
		}

		public void EditScenario(Scenario scenario)
		{
			ShowScreen(this);
			OnShowScreen();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				Load(scenario);
			});
		}

		public override void Hide()
		{
			foreach (KeyValuePair<VillagerConstraint, ScenarioEditEntryView> constraintEntry in constraintEntries)
			{
				UnityEngine.Object.Destroy(constraintEntry.Value.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, Perk> perkEntry in perkEntries)
			{
				UnityEngine.Object.Destroy(perkEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, StatType> statEntry in statEntries)
			{
				UnityEngine.Object.Destroy(statEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, SerializableIdValuePair> resourceEntry in resourceEntries)
			{
				UnityEngine.Object.Destroy(resourceEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, SerializableIdValuePair> equipmentEntry in equipmentEntries)
			{
				UnityEngine.Object.Destroy(equipmentEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, SerializableIdValuePair> structurePileEntry in structurePileEntries)
			{
				UnityEngine.Object.Destroy(structurePileEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, string> technologyEntry in technologyEntries)
			{
				UnityEngine.Object.Destroy(technologyEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, string> mapentry in mapentries)
			{
				UnityEngine.Object.Destroy(mapentry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, string> clothesEntry in clothesEntries)
			{
				UnityEngine.Object.Destroy(clothesEntry.Key.gameObject);
			}
			foreach (KeyValuePair<ScenarioEditEntryView, ScenarioAnimalData> animalEntry in animalEntries)
			{
				UnityEngine.Object.Destroy(animalEntry.Key.gameObject);
			}
			constraintEntries.Clear();
			perkEntries.Clear();
			statEntries.Clear();
			resourceEntries.Clear();
			equipmentEntries.Clear();
			structurePileEntries.Clear();
			technologyEntries.Clear();
			mapentries.Clear();
			clothesEntries.Clear();
			animalEntries.Clear();
			selectedScenario = null;
			Refresh();
			base.Hide();
		}

		protected override void Awake()
		{
			base.Awake();
			nameInputField.onEndEdit.AddListener(OnMustHaveEdit);
			infoInputField.onEndEdit.AddListener(OnMustHaveEdit);
			narrativeInputField.onEndEdit.AddListener(OnMustHaveEdit);
			addConditionButton.onClick.AddListener(OnAddConditionButtonClick);
		}

		private void Start()
		{
			saveData = new ScenarioSaveData();
			constants = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings;
			constraintEntries = new Dictionary<VillagerConstraint, ScenarioEditEntryView>();
			perkEntries = new Dictionary<ScenarioEditEntryView, Perk>();
			statEntries = new Dictionary<ScenarioEditEntryView, StatType>();
			resourceEntries = new Dictionary<ScenarioEditEntryView, SerializableIdValuePair>();
			equipmentEntries = new Dictionary<ScenarioEditEntryView, SerializableIdValuePair>();
			structurePileEntries = new Dictionary<ScenarioEditEntryView, SerializableIdValuePair>();
			technologyEntries = new Dictionary<ScenarioEditEntryView, string>();
			mapentries = new Dictionary<ScenarioEditEntryView, string>();
			clothesEntries = new Dictionary<ScenarioEditEntryView, string>();
			animalEntries = new Dictionary<ScenarioEditEntryView, ScenarioAnimalData>();
			int num = 0;
			CustomGrouppedToggle[] array = contentToggles;
			foreach (CustomGrouppedToggle obj in array)
			{
				int i2 = num;
				obj.onValueChanged.AddListener(delegate(bool isOn)
				{
					if (isOn)
					{
						OnContentToggleValueChange(i2);
					}
				});
				num++;
			}
			OnContentToggleValueChange(0);
		}

		private void OnShowScreen()
		{
			requiredLegendLabel.SetText("(" + base.Localize.GetText("general_required_fields_symbol") + " - " + base.Localize.GetText("general_required_fields_info") + ")");
			startSeasonDropDown.ClearOptions();
			startSeasonDropDown.AddOptions(GetSeasonOptions());
			startEventDropDown.ClearOptions();
			startEventDropDown.AddOptions(GetStartEventOptions());
			startEventScheduleDropDown.ClearOptions();
			startEventScheduleDropDown.AddOptions(GetStartEventScheduleOptions());
			difficultyDropDown.ClearOptions();
			difficultyDropDown.AddOptions(GetDifficultyOptions());
			Perks = new List<Perk>(Repository<PerkRepository, Perk>.Instance.GetAvailableOnStartPerks());
			Resources = new List<string>();
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!allItem.HasQuality && !allItem.IsBuildingStructure && allItem.SortingGroup != "CarcassHuman" && allItem.SortingGroup != "CarcassAnimal" && !allItem.UniqueResource)
				{
					Resources.Add(allItem.GetID());
				}
			}
			ClothesDistinctIDs = new List<string>();
			ProtoEquipments = new List<string>();
			Resource[] protoItems = Repository<ResourceRepository, Resource>.Instance.ProtoItems;
			foreach (Resource resource in protoItems)
			{
				if (resource.SortingGroup == "ApparelClothing")
				{
					ClothesDistinctIDs.Add(resource.GetID());
				}
				else
				{
					ProtoEquipments.Add(resource.GetID());
				}
			}
			StructurePiles = new List<string>();
			foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.StructurePilesCache)
			{
				if (!item.HasQuality && !(item.ProtoId != string.Empty) && !LockedBuildingsManager.DefaultLockedBuildings.Contains(item.GetID()))
				{
					StructurePiles.Add(item.GetID());
				}
			}
			StatsModel byID = Repository<StatsModelRepository, StatsModel>.Instance.GetByID("worker");
			StatOverrides = new List<StatType>(from stat in byID.Stats
				where !stat.HideInScenarioEditor
				select stat.Type);
			Technology = new List<string>(from tech in Repository<ResearchRepository, ResearchModel>.Instance.GetAllItems()
				select tech.GetID());
			MapTypes = new List<string>(Repository<WorldMapSettingsData, WorldMapSettings>.Instance.GetData<WorldMapSettings>().StartMapTypes);
			Constraints = new List<VillagerConstraint>(((VillagerConstraint[])Enum.GetValues(typeof(VillagerConstraint))).Where((VillagerConstraint constraint) => constraint != VillagerConstraint.NumberOfVillagers));
			Animals = new List<string>();
			foreach (Animal allItem2 in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				Animals.Add(allItem2.GetID());
			}
		}

		private void Load(Scenario scenario)
		{
			selectedScenario = scenario;
			nameInputField.text = LocKeyUtils.GetName(scenario.LocKeys);
			infoInputField.text = LocKeyUtils.GetInfo(scenario.LocKeys);
			narrativeInputField.text = LocKeyUtils.GetDescription(scenario.LocKeys);
			startSeasonDropDown.value = scenario.StartSeason;
			startHourView.SetDefaults("starting_hour".ToLocalized(), new IntRange(1, 23), scenario.StartHour);
			AddConstraint(VillagerConstraint.NumberOfVillagers, scenario.VillagerConstraints.NumberOfVillagers);
			AddConstraint(VillagerConstraint.Age, scenario.VillagerConstraints.AgeRange);
			AddConstraint(VillagerConstraint.Height, scenario.VillagerConstraints.HeightRange);
			AddConstraint(VillagerConstraint.Weight, scenario.VillagerConstraints.WeightRange);
			AddConstraint(VillagerConstraint.ForceGender, scenario.VillagerConstraints.ForceBodyType);
			AddConstraint(VillagerConstraint.ForceReligion, scenario.VillagerConstraints.ForceReligion);
			foreach (string defaultClothe in scenario.VillagerConstraints.DefaultClothes)
			{
				AddClothesConstraint(VillagerConstraint.DefaultClothes, defaultClothe);
			}
			SerializableIdValuePair[] startingResources = scenario.StartingResources;
			foreach (SerializableIdValuePair serializableIdValuePair in startingResources)
			{
				AddResource(serializableIdValuePair.Id, (int)serializableIdValuePair.Value);
			}
			startingResources = scenario.StartingEquipment;
			foreach (SerializableIdValuePair serializableIdValuePair2 in startingResources)
			{
				AddEquipment(serializableIdValuePair2.Id, (int)serializableIdValuePair2.Value);
			}
			startingResources = scenario.StartingStructurePiles;
			foreach (SerializableIdValuePair serializableIdValuePair3 in startingResources)
			{
				AddStructurePile(serializableIdValuePair3.Id, (int)serializableIdValuePair3.Value);
			}
			foreach (SerializableIdValuePair forcedPerk in scenario.VillagerConstraints.ForcedPerks)
			{
				Perk byID = Repository<PerkRepository, Perk>.Instance.GetByID(forcedPerk.Id);
				if (!(byID == null))
				{
					AddPerk(byID, (int)forcedPerk.Value);
				}
			}
			foreach (GameEvent.StatSetting overrideStat in scenario.VillagerConstraints.OverrideStats)
			{
				AddStatOverride(overrideStat.Stat, new IntRange((int)overrideStat.ValueRange.Min, (int)overrideStat.ValueRange.Max));
			}
			ScenarioAnimalData[] startingAnimals = scenario.StartingAnimals;
			foreach (ScenarioAnimalData data in startingAnimals)
			{
				AddAnimalData(data);
			}
			foreach (string item in scenario.TechnologyUnlocked)
			{
				OnAddTechnology(item);
			}
			foreach (string startMapType in scenario.StartMapTypes)
			{
				OnAddMapType(startMapType);
			}
			OnMustHaveEdit(null);
			gameParametersInstance = GetGameParameters(scenario);
			gameParametersLayoutItemView.Initialize(gameParametersInstance);
			allowedObjectives = new HashSet<string>(scenario.AllowedObjectives);
			objectiveSelectionView.Initialize(allowedObjectives, OnAllowedObjectivesChange);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(Refresh);
		}

		private static GameParametersInstance GetGameParameters(Scenario scenario)
		{
			if (scenario.GameParameters != null)
			{
				return new GameParametersInstance(scenario.GameParameters);
			}
			return new GameParametersInstance(Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters());
		}

		private void OnAllowedObjectivesChange(string id, bool allowed)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!allowed)
			{
				if (!allowedObjectives.Contains(id))
				{
					return;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ScenarioEditView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing objective '");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral("' ");
				}
				Log.Debug(messageBuilder);
				allowedObjectives.Remove(id);
			}
			else
			{
				allowedObjectives.Add(id);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ScenarioEditView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Allowed objectives: ");
				messageBuilder.AppendFormatted(string.Join(", ", allowedObjectives));
				messageBuilder.AppendLiteral(" ");
			}
			Log.Debug(messageBuilder);
		}

		private void OnContentToggleValueChange(int index)
		{
			for (int i = 0; i < contentPanels.Length; i++)
			{
				contentPanels[i].SetActive(i == index);
			}
		}

		private List<TMP_Dropdown.OptionData> GetSeasonOptions()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (Season season in Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().Seasons)
			{
				list.Add(new TMP_Dropdown.OptionData(base.Localize.GetText("general_" + season.Name)));
			}
			return list;
		}

		private List<TMP_Dropdown.OptionData> GetStartEventOptions()
		{
			startEventIds.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			startEventIds.Add(string.Empty);
			list.Add(new TMP_Dropdown.OptionData("general_none".ToLocalized()));
			foreach (GameEvent allItem in Repository<GameEventSettingsRepository, GameEvent>.Instance.GetAllItems())
			{
				if (!allItem.HideInScenario)
				{
					startEventIds.Add(allItem.GetID());
					list.Add(new TMP_Dropdown.OptionData(LocKeyUtils.GetName(allItem.LocKeys).ToLocalized(BodyType.None)));
				}
			}
			return list;
		}

		private List<TMP_Dropdown.OptionData> GetStartEventScheduleOptions()
		{
			startEventScheduleIds.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (StartingEventSchedule allItem in Repository<StartingEventsRepository, StartingEventSchedule>.Instance.GetAllItems())
			{
				startEventScheduleIds.Add(allItem.GetID());
				list.Add(new TMP_Dropdown.OptionData(LocKeyUtils.GetName(allItem.LocKeys).ToLocalized()));
			}
			return list;
		}

		private List<TMP_Dropdown.OptionData> GetDifficultyOptions()
		{
			difficultyDropDown.ClearOptions();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (string difficultyId in difficultyIds)
			{
				string text = difficultyId.ToLocalized();
				int num = text.IndexOf("(", StringComparison.CurrentCulture);
				text = ((num > 0) ? text.Substring(0, num) : text);
				list.Add(new TMP_Dropdown.OptionData(text));
			}
			return list;
		}

		private void OnMustHaveEdit(string arg0)
		{
			base.NextButton.interactable = AreInpuFieldsValid();
		}

		private bool AreInpuFieldsValid()
		{
			if (nameInputField.text.Trim() != string.Empty && infoInputField.text.Trim() != string.Empty)
			{
				return narrativeInputField.text.Trim() != string.Empty;
			}
			return false;
		}

		private void Refresh()
		{
			resourcesGroup.gameObject.SetActive(resourceEntries.Count > 0);
			equipmentGroup.gameObject.SetActive(equipmentEntries.Count > 0);
			structurePilesGroup.gameObject.SetActive(structurePileEntries.Count > 0);
			technologyGroup.gameObject.SetActive(technologyEntries.Count > 0);
			mapTypeGroup.gameObject.SetActive(mapentries.Count > 0);
			villagerGroup.gameObject.SetActive(constraintEntries.Count > 0);
			perksGroup.gameObject.SetActive(perkEntries.Count > 0);
			statsGroup.gameObject.SetActive(statEntries.Count > 0);
			clothesGroup.gameObject.SetActive(clothesEntries.Count > 0);
			animalsGroup.gameObject.SetActive(animalEntries.Count > 0);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(contentGroup);
			});
		}

		private void OnAddResource(string id)
		{
			AddResource(id, 10);
		}

		private void AddResource(string id, int value)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			if (!(byID == null))
			{
				ScenarioEditResourceView component = UnityEngine.Object.Instantiate(editResourceViewPrefab, resourcesGroup).GetComponent<ScenarioEditResourceView>();
				component.SetDefaults(byID, new IntRange(1, 1000), value);
				resourceEntries.Add(component, new SerializableIdValuePair(id, value));
				OnResourceValueChanged(id, value, component);
				component.ValueChanged += OnResourceValueChanged;
				component.DeleteEntry += OnResourceEntryItemDelete;
				Resources.Remove(id);
				Refresh();
			}
		}

		private void OnResourceValueChanged(string resourceId, int value, ScenarioEditEntryView entryView)
		{
			resourceEntries[entryView] = new SerializableIdValuePair(resourceId, value);
		}

		private void OnResourceEntryItemDelete(ScenarioEditEntryView obj)
		{
			if (obj is ScenarioEditResourceView scenarioEditResourceView)
			{
				scenarioEditResourceView.ValueChanged -= OnResourceValueChanged;
				scenarioEditResourceView.DeleteEntry -= OnResourceEntryItemDelete;
				Resources.Add(resourceEntries[obj].Id);
				resourceEntries.Remove(obj);
				UnityEngine.Object.Destroy(scenarioEditResourceView.gameObject);
				Refresh();
			}
		}

		private void OnAddStructurePile(string stricturePileId)
		{
			AddStructurePile(stricturePileId, 1);
		}

		private void AddStructurePile(string stricturePileId, int value)
		{
			ScenarioEditStructurePileView component = UnityEngine.Object.Instantiate(editStructurePileViewPrefab, structurePilesGroup).GetComponent<ScenarioEditStructurePileView>();
			component.ValueChanged += OnStructurePileChanged;
			component.DeleteEntry += OnStructurePileItemDelete;
			structurePileEntries.Add(component, new SerializableIdValuePair(stricturePileId, value));
			component.SetDefaults(stricturePileId, new IntRange(1, 10), value);
			OnStructurePileChanged(stricturePileId, value, component);
			StructurePiles.Remove(stricturePileId);
			Refresh();
		}

		private void OnStructurePileChanged(string id, int value, ScenarioEditEntryView entryView)
		{
			structurePileEntries[entryView] = new SerializableIdValuePair(id, value);
		}

		private void OnStructurePileItemDelete(ScenarioEditEntryView entryView)
		{
			if (entryView is ScenarioEditStructurePileView scenarioEditStructurePileView)
			{
				scenarioEditStructurePileView.ValueChanged -= OnStructurePileChanged;
				scenarioEditStructurePileView.DeleteEntry -= OnStructurePileItemDelete;
				StructurePiles.Add(scenarioEditStructurePileView.StructurePileID);
				structurePileEntries.Remove(entryView);
				UnityEngine.Object.Destroy(scenarioEditStructurePileView.gameObject);
				Refresh();
			}
		}

		private static List<string> GetAllStructurePiles()
		{
			return (from building in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems()
				where building.CanBeMoved
				select building.GetID()).ToList();
		}

		private void OnAddEquipment(string equipmentProtoId)
		{
			AddEquipment(equipmentProtoId, 1);
		}

		private void AddEquipment(string equipmentProtoId, int value)
		{
			ScenarioEditEquipmentView component = UnityEngine.Object.Instantiate(editEquipmentViewPrefab, equipmentGroup).GetComponent<ScenarioEditEquipmentView>();
			component.ValueChanged += OnEquipmentValueChanged;
			component.DeleteEntry += OnEquipmentEntryItemDelete;
			equipmentEntries.Add(component, new SerializableIdValuePair(equipmentProtoId, value));
			component.SetDefaults(equipmentProtoId, new IntRange(1, 10), value);
			Refresh();
		}

		private void OnEquipmentValueChanged(string resourceId, int value, ScenarioEditEntryView entryView)
		{
			equipmentEntries[entryView] = new SerializableIdValuePair(resourceId, value);
		}

		private void OnEquipmentEntryItemDelete(ScenarioEditEntryView obj)
		{
			if (obj is ScenarioEditEquipmentView scenarioEditEquipmentView)
			{
				scenarioEditEquipmentView.DeleteEntry -= OnEquipmentEntryItemDelete;
				scenarioEditEquipmentView.ValueChanged -= OnEquipmentValueChanged;
				equipmentEntries.Remove(obj);
				UnityEngine.Object.Destroy(obj.gameObject);
				Refresh();
			}
		}

		private void OnAddMapType(string mapId)
		{
			NSMedieval.Model.MapNew.Map byID = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(mapId);
			if (!(byID == null))
			{
				ScenarioEditEntryView component = UnityEngine.Object.Instantiate(editViewPrefab, mapTypeGroup).GetComponent<ScenarioEditEntryView>();
				component.DeleteEntry += OnMapEntryItemDelete;
				component.SetDefaults(base.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)));
				mapentries.Add(component, mapId);
				MapTypes.Remove(mapId);
				Refresh();
			}
		}

		private void OnMapEntryItemDelete(ScenarioEditEntryView obj)
		{
			if ((object)obj != null)
			{
				string item = mapentries[obj];
				obj.DeleteEntry -= OnTechnologyEntryItemDelete;
				UnityEngine.Object.Destroy(obj.gameObject);
				mapentries.Remove(obj);
				MapTypes.Add(item);
				Refresh();
			}
		}

		private void OnAddTechnology(string tech)
		{
			ResearchModel byID = Repository<ResearchRepository, ResearchModel>.Instance.GetByID(tech);
			if (!(byID == null))
			{
				ScenarioEditEntryView component = UnityEngine.Object.Instantiate(editViewPrefab, technologyGroup).GetComponent<ScenarioEditEntryView>();
				component.DeleteEntry += OnTechnologyEntryItemDelete;
				component.SetDefaults(base.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)));
				technologyEntries.Add(component, tech);
				Technology.Remove(tech);
				Refresh();
			}
		}

		private void OnTechnologyEntryItemDelete(ScenarioEditEntryView obj)
		{
			if ((object)obj != null)
			{
				string item = technologyEntries[obj];
				obj.DeleteEntry -= OnTechnologyEntryItemDelete;
				UnityEngine.Object.Destroy(obj.gameObject);
				technologyEntries.Remove(obj);
				Technology.Add(item);
				Refresh();
			}
		}

		private void AddConstraint(VillagerConstraint constraint, int value)
		{
			ScenarioEditIntView viewItem = UnityEngine.Object.Instantiate(editIntViewPrefab, villagerGroup).GetComponent<ScenarioEditIntView>();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				switch (constraint)
				{
				case VillagerConstraint.NumberOfVillagers:
					viewItem.ValueChanged += OnVillagersNumberValueChanged;
					viewItem.SetDefaults(base.Localize.GetText("number_of_villagers"), new IntRange(1, 10), value);
					OnVillagersNumberValueChanged(value, viewItem);
					viewItem.DeleteButton.gameObject.SetActive(value: false);
					break;
				case VillagerConstraint.ForceGender:
					viewItem.ValueChanged += OnVillagersGenderValueChanged;
					viewItem.DeleteEntry += OnConstraintEntryItemDelete;
					viewItem.SetDefaults(base.Localize.GetText("gender_male") + "/" + base.Localize.GetText("gender_female"), new IntRange(0, 100), value, "%");
					viewItem.SetInfo("scenario_edit_gender_title", "scenario_edit_gender_key");
					OnVillagersGenderValueChanged(value, viewItem);
					viewItem.DeleteButton.gameObject.SetActive(value: false);
					break;
				case VillagerConstraint.ForceReligion:
					viewItem.ValueChanged += OnVillagersReligionValueChanged;
					viewItem.DeleteEntry += OnConstraintEntryItemDelete;
					viewItem.SetDefaults(base.Localize.GetText("general_christian") + "/" + base.Localize.GetText("general_pagan"), new IntRange(0, 100), value, "%");
					viewItem.SetInfo("scenario_edit_religion_title", "scenario_edit_religion_key");
					OnVillagersReligionValueChanged(value, viewItem);
					viewItem.DeleteButton.gameObject.SetActive(value: false);
					break;
				default:
					UnityEngine.Object.Destroy(viewItem.gameObject);
					throw new ArgumentOutOfRangeException("constraint", constraint, null);
				}
				constraintEntries[constraint] = viewItem;
				if (Constraints.Contains(constraint))
				{
					Constraints.Remove(constraint);
				}
			});
		}

		private void AddConstraint(VillagerConstraint constraint, IntRange range)
		{
			ScenarioEditIntRangeView component = UnityEngine.Object.Instantiate(editIntRangeViewViewPrefab, villagerGroup).GetComponent<ScenarioEditIntRangeView>();
			switch (constraint)
			{
			case VillagerConstraint.Age:
				component.ValueChanged += OnVillagersAgeValueChanged;
				component.DeleteEntry += OnConstraintEntryItemDelete;
				component.SetDefaults(base.Localize.GetText("villager_constraint_age_range"), constants.AgeRange, range);
				OnVillagersAgeValueChanged(range, component);
				component.DeleteButton.gameObject.SetActive(value: false);
				break;
			case VillagerConstraint.Height:
				component.ValueChanged += OnVillagersHeightValueChanged;
				component.DeleteEntry += OnConstraintEntryItemDelete;
				component.SetDefaults(base.Localize.GetText("villager_constraint_height_range"), constants.HeightRange, range);
				OnVillagersHeightValueChanged(range, component);
				component.DeleteButton.gameObject.SetActive(value: false);
				break;
			case VillagerConstraint.Weight:
				component.ValueChanged += OnVillagersWeightValueChanged;
				component.DeleteEntry += OnConstraintEntryItemDelete;
				component.SetDefaults(base.Localize.GetText("villager_constraint_weight_range"), constants.WeightRange, range);
				OnVillagersWeightValueChanged(range, component);
				component.DeleteButton.gameObject.SetActive(value: false);
				break;
			default:
				UnityEngine.Object.Destroy(component.gameObject);
				throw new ArgumentOutOfRangeException("constraint", constraint, null);
			}
			constraintEntries[constraint] = component;
			if (Constraints.Contains(constraint))
			{
				Constraints.Remove(constraint);
			}
		}

		private void AddDefaultClothes(string itemId)
		{
			_ = ProductQuality.Good.ToString().ToLower() + "_" + itemId;
			AddClothesConstraint(VillagerConstraint.DefaultClothes, itemId);
		}

		private void AddClothesConstraint(VillagerConstraint constraint, string itemId)
		{
			if (constraint == VillagerConstraint.DefaultClothes)
			{
				ScenarioEditEquipmentView component = UnityEngine.Object.Instantiate(editEquipmentViewPrefab, clothesGroup).GetComponent<ScenarioEditEquipmentView>();
				component.ValueChanged += OnVillagersClothesValueChanged;
				component.DeleteEntry += OnClothesEntryItemDelete;
				clothesEntries.Add(component, itemId);
				component.SetDefaults(itemId, new IntRange(1, 1), 1);
				Refresh();
			}
		}

		private void OnClothesEntryItemDelete(ScenarioEditEntryView view)
		{
			ScenarioEditEquipmentView scenarioEditEquipmentView = (ScenarioEditEquipmentView)view;
			scenarioEditEquipmentView.ValueChanged -= OnVillagersClothesValueChanged;
			clothesEntries.Remove(scenarioEditEquipmentView);
			workerConstraints.DefaultClothes = clothesEntries.Values.ToList();
			UnityEngine.Object.Destroy(scenarioEditEquipmentView.gameObject);
			Refresh();
		}

		private void OnAddConstraint(VillagerConstraint constraint)
		{
			switch (constraint)
			{
			case VillagerConstraint.NumberOfVillagers:
			{
				int value3 = 3;
				AddConstraint(constraint, value3);
				break;
			}
			case VillagerConstraint.Age:
			{
				IntRange range3 = new IntRange(22, 44);
				AddConstraint(constraint, range3);
				break;
			}
			case VillagerConstraint.Height:
			{
				IntRange range2 = new IntRange(160, 180);
				AddConstraint(constraint, range2);
				break;
			}
			case VillagerConstraint.Weight:
			{
				IntRange range = new IntRange(60, 100);
				AddConstraint(constraint, range);
				break;
			}
			case VillagerConstraint.ForceGender:
			{
				int value2 = 50;
				AddConstraint(constraint, value2);
				break;
			}
			case VillagerConstraint.ForceReligion:
			{
				int value = 50;
				AddConstraint(constraint, value);
				break;
			}
			case VillagerConstraint.DefaultClothes:
			{
				string itemId = "winter_clothes";
				AddClothesConstraint(constraint, itemId);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("constraint", constraint, null);
			}
			if (constraint != VillagerConstraint.NumberOfVillagers && constraint != VillagerConstraint.DefaultClothes && Constraints.Contains(constraint))
			{
				Constraints.Remove(constraint);
			}
			Refresh();
		}

		private void OnVillagersReligionValueChanged(int value, ScenarioEditEntryView view)
		{
			workerConstraints.ForceReligion = value;
		}

		private void OnVillagersClothesValueChanged(string value, int i, ScenarioEditEntryView view)
		{
			if (view is ScenarioEditEquipmentView)
			{
				clothesEntries[view] = value;
				if (workerConstraints.DefaultClothes == null)
				{
					workerConstraints.DefaultClothes = new List<string>();
				}
				workerConstraints.DefaultClothes = clothesEntries.Values.ToList();
			}
		}

		private void OnVillagersNumberValueChanged(int value, ScenarioEditEntryView view)
		{
			workerConstraints.NumberOfVillagers = value;
		}

		private void OnVillagersAgeValueChanged(IntRange intRange, ScenarioEditEntryView view)
		{
			workerConstraints.AgeRange = intRange;
		}

		private void OnVillagersHeightValueChanged(IntRange intRange, ScenarioEditEntryView view)
		{
			workerConstraints.HeightRange = intRange;
		}

		private void OnVillagersWeightValueChanged(IntRange value, ScenarioEditEntryView view)
		{
			workerConstraints.WeightRange = value;
		}

		private void OnVillagersGenderValueChanged(int value, ScenarioEditEntryView view)
		{
			workerConstraints.ForceBodyType = value;
		}

		private void OnConstraintEntryItemDelete(ScenarioEditEntryView view)
		{
			VillagerConstraint key = constraintEntries.First((KeyValuePair<VillagerConstraint, ScenarioEditEntryView> item) => item.Value == view).Key;
			switch (key)
			{
			case VillagerConstraint.NumberOfVillagers:
				ResetConstraint(key);
				return;
			case VillagerConstraint.Age:
				((ScenarioEditIntRangeView)view).ValueChanged -= OnVillagersAgeValueChanged;
				break;
			case VillagerConstraint.Height:
				((ScenarioEditIntRangeView)view).ValueChanged -= OnVillagersHeightValueChanged;
				break;
			case VillagerConstraint.Weight:
				((ScenarioEditIntRangeView)view).ValueChanged -= OnVillagersWeightValueChanged;
				break;
			case VillagerConstraint.ForceGender:
				((ScenarioEditIntView)view).ValueChanged -= OnVillagersGenderValueChanged;
				break;
			case VillagerConstraint.ForceReligion:
				((ScenarioEditIntView)view).ValueChanged -= OnVillagersReligionValueChanged;
				break;
			case VillagerConstraint.ForcedPerks:
				return;
			default:
				throw new ArgumentOutOfRangeException();
			case VillagerConstraint.DefaultClothes:
			case VillagerConstraint.OverrideStats:
				break;
			}
			view.DeleteEntry -= OnConstraintEntryItemDelete;
			UnityEngine.Object.Destroy(view.gameObject);
			constraintEntries.Remove(key);
			ResetConstraint(key);
			Constraints.Add(key);
			Refresh();
		}

		private void ResetConstraint(VillagerConstraint constraint)
		{
			switch (constraint)
			{
			case VillagerConstraint.NumberOfVillagers:
				workerConstraints.NumberOfVillagers = 3;
				break;
			case VillagerConstraint.Age:
				workerConstraints.AgeRange = constants.AgeRange;
				break;
			case VillagerConstraint.Height:
				workerConstraints.HeightRange = constants.HeightRange;
				break;
			case VillagerConstraint.Weight:
				workerConstraints.WeightRange = constants.WeightRange;
				break;
			case VillagerConstraint.ForceGender:
				workerConstraints.ForceBodyType = 50;
				break;
			case VillagerConstraint.ForceReligion:
				workerConstraints.ForceReligion = 50;
				break;
			case VillagerConstraint.DefaultClothes:
				workerConstraints.DefaultClothes = new List<string> { "good_linen_winter_clothes" };
				break;
			case VillagerConstraint.ForcedPerks:
				workerConstraints.ForcedPerks = new List<SerializableIdValuePair>();
				break;
			case VillagerConstraint.OverrideStats:
				workerConstraints.OverrideStats = new List<GameEvent.StatSetting>();
				break;
			default:
				throw new ArgumentOutOfRangeException("constraint", constraint, null);
			}
		}

		private void AddPerk(Perk perk, int value)
		{
			ScenarioEditIntIconView component = UnityEngine.Object.Instantiate(editIntIconViewPrefab, perksGroup).GetComponent<ScenarioEditIntIconView>();
			component.ValueChanged += OnVillagersPerkValueChanged;
			component.DeleteEntry += PerkEntryItemDelete;
			perkEntries.Add(component, perk);
			component.SetDefaults(perk.IconPath, string.Empty, base.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys)) ?? "", new IntRange(0, 100), value, "%");
			OnVillagersPerkValueChanged(value, component);
			Perks.Remove(perk);
			Refresh();
		}

		private void OnAddPerk(Perk perk)
		{
			int value = 50;
			AddPerk(perk, value);
		}

		private void OnVillagersPerkValueChanged(int value, ScenarioEditEntryView view)
		{
			if (view is ScenarioEditIntIconView)
			{
				if (workerConstraints.ForcedPerks == null)
				{
					workerConstraints.ForcedPerks = new List<SerializableIdValuePair>();
				}
				string perkName = perkEntries[view].GetID();
				PurgePerk(perkName);
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					workerConstraints.ForcedPerks.Add(new SerializableIdValuePair(perkName, value));
				});
			}
		}

		private void PerkEntryItemDelete(ScenarioEditEntryView view)
		{
			if (view is ScenarioEditIntIconView scenarioEditIntIconView)
			{
				Perk perk = perkEntries[view];
				PurgePerk(perk.GetID());
				scenarioEditIntIconView.ValueChanged -= OnVillagersPerkValueChanged;
				scenarioEditIntIconView.DeleteEntry -= PerkEntryItemDelete;
				UnityEngine.Object.Destroy(scenarioEditIntIconView.gameObject);
				perkEntries.Remove(view);
				perksGroup.gameObject.SetActive(perkEntries.Count > 0);
				Perks.Add(perk);
				Refresh();
			}
		}

		private void PurgePerk(string perkId)
		{
			SerializableIdValuePair serializableIdValuePair = workerConstraints.ForcedPerks.FirstOrDefault((SerializableIdValuePair pair) => pair.Id == perkId);
			if (serializableIdValuePair != null && serializableIdValuePair.Id != null)
			{
				workerConstraints.ForcedPerks.Remove(serializableIdValuePair);
			}
		}

		private void OnAddStatOverride(StatType statType)
		{
			AddStatOverride(statType);
		}

		private void AddStatOverride(StatType statType, IntRange range = null)
		{
			ScenarioEditIntRangeView component = UnityEngine.Object.Instantiate(editIntRangeViewViewPrefab, statsGroup).GetComponent<ScenarioEditIntRangeView>();
			component.ValueChanged += OnVillagerStatValueChanged;
			component.DeleteEntry += OnStatEntryItemDelete;
			statEntries[component] = statType;
			Stat stat = Repository<StatsModelRepository, StatsModel>.Instance.GetByID("worker")?.GetByType(statType);
			if (!(stat == null))
			{
				IntRange intRange = range ?? new IntRange((int)stat.InitialValueRange.Min, (int)stat.InitialValueRange.Max);
				IntRange minMaxRange = new IntRange((int)stat.Min.First().BaseValue, (int)stat.Max.First().BaseValue);
				string localizedName = StatUtils.GetLocalizedName(stat);
				component.SetDefaults(localizedName, minMaxRange, intRange);
				OnVillagerStatValueChanged(intRange, component);
				StatOverrides.Remove(statType);
				Refresh();
			}
		}

		private void OnVillagerStatValueChanged(IntRange value, ScenarioEditEntryView view)
		{
			if (view is ScenarioEditIntRangeView)
			{
				if (workerConstraints.OverrideStats == null)
				{
					workerConstraints.OverrideStats = new List<GameEvent.StatSetting>();
				}
				StatType stat = statEntries[view];
				GameEvent.StatSetting item = workerConstraints.OverrideStats.FirstOrDefault((GameEvent.StatSetting statSetting) => statSetting.Stat == stat);
				if (workerConstraints.OverrideStats.Contains(item))
				{
					workerConstraints.OverrideStats.Remove(item);
				}
				FloatRange valueRange = new FloatRange(value.Min, value.Max);
				workerConstraints.OverrideStats.Add(new GameEvent.StatSetting(stat.ToString(), valueRange));
			}
		}

		private void OnStatEntryItemDelete(ScenarioEditEntryView view)
		{
			if (view is ScenarioEditIntRangeView scenarioEditIntRangeView)
			{
				StatType stat = statEntries[view];
				scenarioEditIntRangeView.ValueChanged -= OnVillagerStatValueChanged;
				scenarioEditIntRangeView.DeleteEntry -= OnStatEntryItemDelete;
				UnityEngine.Object.Destroy(scenarioEditIntRangeView.gameObject);
				statEntries.Remove(view);
				StatOverrides.Add(stat);
				GameEvent.StatSetting item = workerConstraints.OverrideStats.FirstOrDefault((GameEvent.StatSetting s) => s.Stat == stat);
				workerConstraints.OverrideStats.Remove(item);
				Refresh();
			}
		}

		private void OnAddAnimal(string animalId)
		{
			AddAnimal(animalId, 1);
		}

		private void AddAnimal(string animalId, int value)
		{
			GetAnimalView().SetDefaults(animalId, new IntRange(1, 10), value);
			Refresh();
		}

		private void AddAnimalData(ScenarioAnimalData data)
		{
			GetAnimalView().SetData(data);
			Refresh();
		}

		private ScenarioEditAnimalView GetAnimalView()
		{
			ScenarioEditAnimalView component = UnityEngine.Object.Instantiate(editAnimalViewPrefab, animalsGroup).GetComponent<ScenarioEditAnimalView>();
			component.ValueChanged += OnAnimalValueChanged;
			component.DeleteEntry += OnAnimalEntryItemDelete;
			return component;
		}

		private void OnAnimalValueChanged(ScenarioAnimalData data, ScenarioEditEntryView entryView)
		{
			animalEntries[entryView] = data;
		}

		private void OnAnimalEntryItemDelete(ScenarioEditEntryView obj)
		{
			if (obj is ScenarioEditAnimalView scenarioEditAnimalView)
			{
				scenarioEditAnimalView.DeleteEntry -= OnAnimalEntryItemDelete;
				scenarioEditAnimalView.ValueChanged -= OnAnimalValueChanged;
				animalEntries.Remove(obj);
				UnityEngine.Object.Destroy(obj.gameObject);
				Refresh();
			}
		}

		private void OnAddConditionButtonClick()
		{
			addConditionsView.ShowGroup(ScenarioConditionGroup.Root);
		}

		protected override void OnClickNext()
		{
			nameInputField.text = nameInputField.text.Replace("\r", string.Empty).Replace("\n", string.Empty);
			if (!AreInpuFieldsValid())
			{
				return;
			}
			if (selectedScenario == null)
			{
				Log.Error("No selected scenario, this should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ScenarioEditView.cs");
				return;
			}
			bool flag = selectedScenario.GetID() == Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario().GetID();
			string text = nameInputField.text.TrimStart().TrimEnd().ToLower()
				.Replace(" ", "_");
			saveData.ID = (flag ? ("custom_scenario_" + text) : selectedScenario.GetID());
			saveData.LocKeys = GetLocKeys();
			saveData.ImageId = selectedScenario.ImageId;
			saveData.StartHour = startHourView.GetValue();
			saveData.StartSeason = startSeasonDropDown.value;
			saveData.StartEventId = startEventIds[startEventDropDown.value];
			saveData.StartingEventScheduleId = startEventScheduleIds[startEventScheduleDropDown.value];
			saveData.Difficulty = difficultyIds[difficultyDropDown.value];
			saveData.VillagerConstraints = workerConstraints;
			saveData.TechnologyUnlocked = technologyEntries.Values.ToList();
			saveData.StartMapTypes = mapentries.Values.ToList();
			saveData.StartingResources = resourceEntries.Values.ToList();
			saveData.StartingEquipment = equipmentEntries.Values.ToList();
			saveData.StartingStructurePiles = structurePileEntries.Values.ToList();
			saveData.StartingAnimals = animalEntries.Values.ToArray();
			saveData.ModifiedOnGameVersion = Application.version;
			saveData.GameParameters = gameParametersInstance.ToIdValuePairs;
			saveData.AllowedObjectives = new List<string>(allowedObjectives);
			if (flag)
			{
				ModdingUtils.CreateNewScenario(saveData);
			}
			else
			{
				ModdingUtils.UpdateScenario(selectedScenario.GetID(), saveData);
			}
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(base.OnClickNext);
			LocKeys[] GetLocKeys()
			{
				return new LocKeys[1]
				{
					new LocKeys("English", nameInputField.text, infoInputField.text, narrativeInputField.text)
				};
			}
		}

		private void OnEnable()
		{
			addConditionsView.AddConstraint += OnAddConstraint;
			addConditionsView.AddPerk += OnAddPerk;
			addConditionsView.AddStatOverride += OnAddStatOverride;
			addConditionsView.AddResource += OnAddResource;
			addConditionsView.AddEquipment += OnAddEquipment;
			addConditionsView.AddStructurePile += OnAddStructurePile;
			addConditionsView.AddTechnology += OnAddTechnology;
			addConditionsView.AddMapType += OnAddMapType;
			addConditionsView.AddClothes += AddDefaultClothes;
			addConditionsView.AddAnimal += OnAddAnimal;
		}

		private void OnDisable()
		{
			addConditionsView.AddConstraint -= OnAddConstraint;
			addConditionsView.AddEquipment -= OnAddEquipment;
			addConditionsView.AddStructurePile -= OnAddStructurePile;
			addConditionsView.AddPerk -= OnAddPerk;
			addConditionsView.AddStatOverride -= OnAddStatOverride;
			addConditionsView.AddResource -= OnAddResource;
			addConditionsView.AddTechnology -= OnAddTechnology;
			addConditionsView.AddMapType -= OnAddMapType;
			addConditionsView.AddClothes -= AddDefaultClothes;
			addConditionsView.AddAnimal -= OnAddAnimal;
		}
	}
}

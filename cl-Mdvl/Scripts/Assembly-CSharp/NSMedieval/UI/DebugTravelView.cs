using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using Repository.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class DebugTravelView : ClosableUIView
	{
		[SerializeField]
		private SoundButton generateButton;

		[SerializeField]
		private SoundButton backButton;

		[SerializeField]
		private SoundButton saveButton;

		[SerializeField]
		private SoundButton loadButton;

		[SerializeField]
		private SoundButton spawnPointsButton;

		[SerializeField]
		private SoundButton exitSecondMapButton;

		[SerializeField]
		private SpawnPointEditorView spawnPointEditorView;

		[Header("Map Settings")]
		[SerializeField]
		private TMP_Dropdown mapTypeDropDown;

		[SerializeField]
		private TMP_Dropdown mapSizeDropDown;

		[SerializeField]
		private TMP_InputField mapSeedInput;

		[SerializeField]
		private SoundButton mapSeedRandomizeButton;

		[NonSerialized]
		private Dictionary<string, int> indexOfMapType;

		[Header("Scroll Settings")]
		[SerializeField]
		private LayoutGroupView workersGroup;

		[SerializeField]
		private LayoutGroupView animalsGroup;

		[SerializeField]
		private Toggle spawnLootOnLoadToggle;

		[SerializeField]
		private Toggle startEventOnLoadToggle;

		[NonSerialized]
		private List<TravelWorkerEntry> workerEntries;

		[NonSerialized]
		private List<TravelWorkerEntry> prisonerEntries;

		[NonSerialized]
		private List<TravelAnimalEntry> animalEntries;

		[SerializeField]
		private GameObject mapTypeParent;

		[SerializeField]
		private GameObject mapTypePrefab;

		[NonSerialized]
		private List<SecondMapTypeLayoutItemView> mapTypeLayoutItems;

		[SerializeField]
		private LayoutGroupView savesGroup;

		[NonSerialized]
		private List<LayoutGroupItemView> savesLayoutItems;

		[NonSerialized]
		private List<SecondMapSaveFileView> saveFileViews;

		[SerializeField]
		private GameObject saveFilePrefab;

		[SerializeField]
		private TMP_InputField saveFilenameInput;

		[SerializeField]
		private SearchFilterView searchFilterView;

		private Dictionary<int, SecondMapType> secondMapTypesByIndex;

		private SecondMapSaveInfo selectedSave;

		private SecondMapSaveInfo saveToOverwrite;

		private string creator = string.Empty;

		private List<HumanoidInstance> workers;

		private List<HumanoidInstance> prisoners;

		private List<AnimalInstance> animals;

		private List<ResourceInstance> resources;

		private MapSize selectedMapSize;

		private string selectedMapType;

		private string selectedMapSeed;

		private const int MinWorkersCount = 1;

		private int maxWorkersCount;

		private int maxAnimalsCount;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private HashSet<CreatureBase> creaturesCanGoToEdge;

		private void Awake()
		{
			workers = new List<HumanoidInstance>();
			prisoners = new List<HumanoidInstance>();
			animals = new List<AnimalInstance>();
			resources = new List<ResourceInstance>();
			savesLayoutItems = new List<LayoutGroupItemView>();
			saveFileViews = new List<SecondMapSaveFileView>();
			creaturesCanGoToEdge = new HashSet<CreatureBase>();
			indexOfMapType = new Dictionary<string, int>();
		}

		private void OnEnable()
		{
			if (workerEntries == null)
			{
				workerEntries = new List<TravelWorkerEntry>();
			}
			if (prisonerEntries == null)
			{
				prisonerEntries = new List<TravelWorkerEntry>();
			}
			if (animalEntries == null)
			{
				animalEntries = new List<TravelAnimalEntry>();
			}
			if (mapTypeLayoutItems == null)
			{
				mapTypeLayoutItems = new List<SecondMapTypeLayoutItemView>();
			}
		}

		public override void Show()
		{
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			DisableInput();
			base.Show();
			map = VillageManager.ActiveVillage.Map;
			maxWorkersCount = 0;
			using PooledList<CreatureBase> pooledList = ListPool<CreatureBase>.GetJanitor();
			List<HumanoidInstance> list = new List<HumanoidInstance>(GlobalSaveController.CurrentVillageData.Workers);
			list.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item in list)
			{
				TravelWorkerEntry at = workerEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at.gameObject.SetActive(value: true);
				HumanoidInstance humanoid = item;
				at.SetData(humanoid, OnWorkerToggle);
				pooledList.Add(item);
			}
			List<HumanoidInstance> list2 = new List<HumanoidInstance>();
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC != null && !nPC.HasDisposed && !nPC.HasFainted && nPC.ActiveBehaviour is CaptiveNpcBehaviour { Owner: null })
				{
					list2.Add(nPC);
				}
			}
			list2.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item2 in list2)
			{
				TravelWorkerEntry at2 = workerEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at2.gameObject.SetActive(value: true);
				at2.SetData(item2, OnWorkerToggle);
				pooledList.Add(item2);
			}
			workerEntries.SetActiveFromIndex(maxWorkersCount, active: false);
			maxAnimalsCount = 0;
			pooledList.AddRange(MonoSingleton<AnimalManager>.Instance.Animals.Keys);
			GetCreaturesCanGoToMapEdge(pooledList, creaturesCanGoToEdge);
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (IsAnimalAvailableForCaravanForming(key))
				{
					TravelAnimalEntry at3 = animalEntries.GetAt(animalsGroup, maxAnimalsCount);
					at3.SetData(key, this);
					bool flag = key.IsFormingCaravan();
					bool flag2 = creaturesCanGoToEdge.Contains(key);
					string tooltipKey = string.Empty;
					string bbtKey = string.Empty;
					if (flag)
					{
						tooltipKey = "caravan_animal_already_forming";
						bbtKey = "caravan_animal_already_forming";
					}
					else if (!flag2)
					{
						tooltipKey = "caravan_animal_stuck";
						bbtKey = "caravan_animal_stuck";
					}
					at3.SetClickable(flag2 && !flag, tooltipKey, bbtKey);
					maxAnimalsCount++;
				}
			}
			animalEntries.SetActiveFromIndex(maxAnimalsCount, active: false);
			UpdatedWorkersCount();
			InitMapTypeFlags();
		}

		private void DisableInput()
		{
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: true);
		}

		private void EnableInput()
		{
			MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: false);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
		}

		private void OnSearchApplied(string[] keywords)
		{
			foreach (SecondMapSaveFileView saveFileView in saveFileViews)
			{
				bool flag = true;
				foreach (string value in keywords)
				{
					flag &= saveFileView.Profile.Name.ToLower().Contains(value);
				}
				saveFileView.gameObject.SetActive(flag);
			}
		}

		private void OnCancelSearch()
		{
			foreach (SecondMapSaveFileView saveFileView in saveFileViews)
			{
				saveFileView.gameObject.SetActive(value: true);
			}
		}

		private void OnFilterApplied(int filterIndex)
		{
			foreach (SecondMapSaveFileView saveFileView in saveFileViews)
			{
				if (filterIndex == 0)
				{
					saveFileView.gameObject.SetActive(value: true);
				}
				else
				{
					saveFileView.gameObject.SetActive(saveFileView.Profile.Type == secondMapTypesByIndex[filterIndex]);
				}
			}
		}

		private void SetupSearchFilter()
		{
			secondMapTypesByIndex = new Dictionary<int, SecondMapType>();
			int num = 0;
			List<string> list = new List<string>();
			foreach (SecondMapType value in Enum.GetValues(typeof(SecondMapType)))
			{
				secondMapTypesByIndex.Add(num++, value);
				if (value == SecondMapType.None)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("filter_all_items"));
				}
				else
				{
					list.Add(value.ToString());
				}
			}
			searchFilterView.SetupFilters(list);
			searchFilterView.OnSearchKeywords += OnSearchApplied;
			searchFilterView.OnCancelSearch += OnCancelSearch;
			searchFilterView.OnFilterChanged += OnFilterApplied;
		}

		protected void Start()
		{
			MonoSingleton<SpawnPointManager>.Instance.LoadSpawnPoints();
			selectedMapSeed = new System.Random().Next().ToString();
			mapSeedInput.text = selectedMapSeed;
			if (generateButton != null)
			{
				generateButton.onClick.RemoveAllListeners();
				generateButton.onClick.AddListener(GenerateMap);
			}
			if (backButton != null)
			{
				backButton.onClick.RemoveAllListeners();
				backButton.onClick.AddListener(CloseView);
			}
			if (saveButton != null)
			{
				saveButton.onClick.RemoveAllListeners();
				saveButton.onClick.AddListener(SaveMap);
			}
			if (loadButton != null)
			{
				loadButton.onClick.RemoveAllListeners();
				loadButton.onClick.AddListener(LoadMap);
			}
			if (spawnPointsButton != null)
			{
				spawnPointsButton.onClick.RemoveAllListeners();
				spawnPointsButton.onClick.AddListener(OpenSpawnPointsView);
			}
			if (exitSecondMapButton != null)
			{
				exitSecondMapButton.onClick.RemoveAllListeners();
				exitSecondMapButton.onClick.AddListener(ExitSecondMap);
			}
			mapSeedRandomizeButton.onClick.AddListener(RandomizeSeed);
			mapSeedInput.onValueChanged.AddListener(OnSeedEdit);
			mapSizeDropDown.ClearOptions();
			mapSizeDropDown.AddOptions((from item in GetMapSizes()
				select new TMP_Dropdown.OptionData(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(item.LocKeys)))).ToList());
			selectedMapSize = GetMapSizes().FirstOrDefault();
			SetupSearchFilter();
			PopulateMapTypeDropDown();
			RefreshSavesList();
		}

		private void PopulateMapTypeDropDown()
		{
			mapTypeDropDown.onValueChanged.RemoveAllListeners();
			mapTypeDropDown.ClearOptions();
			mapTypeDropDown.AddOptions(GetMapTypes());
			mapTypeDropDown.onValueChanged.AddListener(OnMapTypeDropdownChanged);
			selectedMapType = indexOfMapType.FirstOrDefault().Key;
			string text = selectedMapType;
			if (text != null && indexOfMapType != null && indexOfMapType.ContainsKey(text))
			{
				mapTypeDropDown.SetValueWithoutNotify(indexOfMapType[text]);
			}
		}

		private void OnMapTypeDropdownChanged(int selectedIndex)
		{
			if (selectedIndex != -1)
			{
				string key = indexOfMapType.FirstOrDefault((KeyValuePair<string, int> item) => item.Value == selectedIndex).Key;
				selectedMapType = key;
			}
		}

		public void AddWorker(HumanoidInstance humanoidInstance)
		{
			workers.Add(humanoidInstance);
		}

		public void AddPrisoner(HumanoidInstance creatureInstance)
		{
			prisoners.Add(creatureInstance);
		}

		public void AddAnimal(AnimalInstance animalInstance)
		{
			animals.Add(animalInstance);
		}

		public void RemoveWorker(HumanoidInstance humanoidInstance)
		{
			workers.Remove(humanoidInstance);
		}

		public void RemovePrisoner(HumanoidInstance creatureInstance)
		{
			prisoners.Remove(creatureInstance);
		}

		public void RemoveAnimal(AnimalInstance animalInstance)
		{
			animals.Remove(animalInstance);
		}

		private List<TMP_Dropdown.OptionData> GetMapTypes()
		{
			indexOfMapType.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			int num = 0;
			foreach (NSMedieval.Model.MapNew.Map allItem in Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetAllItems())
			{
				indexOfMapType.Add(allItem.GetID(), num++);
				list.Add(new TMP_Dropdown.OptionData(base.Localize.GetText(LocKeyUtils.GetName(allItem.LocKeys))));
			}
			return list;
		}

		private List<MapSize> GetMapSizes()
		{
			List<MapSize> list = new List<MapSize>();
			foreach (MapSize allItem in Repository<MapSizeRepository, MapSize>.Instance.GetAllItems())
			{
				list.Add(allItem);
			}
			return list;
		}

		private void OnSeedEdit(string newSeed)
		{
			selectedMapSeed = newSeed;
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetSeedFromHomeScene(selectedMapSeed.GetHashCode(), 0.35f);
		}

		private void RandomizeSeed()
		{
			System.Random random = new System.Random();
			selectedMapSeed = random.Next().ToString();
			mapSeedInput.text = selectedMapSeed;
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetSeedFromHomeScene(selectedMapSeed.GetHashCode(), 0.2f);
		}

		private void InitMapTypeFlags()
		{
			if (mapTypeLayoutItems.Count > 0)
			{
				return;
			}
			foreach (SecondMapType value in Enum.GetValues(typeof(SecondMapType)))
			{
				if (value != SecondMapType.None)
				{
					SecondMapTypeLayoutItemView component = UnityEngine.Object.Instantiate(mapTypePrefab, mapTypeParent.transform).GetComponent<SecondMapTypeLayoutItemView>();
					component.SetData(value.ToString(), selected: false);
					component.SetText(value.ToString());
					component.SetType(value);
					mapTypeLayoutItems.Add(component);
				}
			}
		}

		private int GetMapTypeFlags()
		{
			SecondMapType secondMapType = SecondMapType.None;
			foreach (SecondMapTypeLayoutItemView mapTypeLayoutItem in mapTypeLayoutItems)
			{
				if (mapTypeLayoutItem.Toggle.isOn)
				{
					secondMapType |= mapTypeLayoutItem.MapType;
				}
			}
			return (int)secondMapType;
		}

		private void SaveMap()
		{
			if (!string.IsNullOrEmpty(saveFilenameInput.text))
			{
				List<SpawnPoint> spawnPointsForSave = GetSpawnPointsForSave();
				if (spawnPointsForSave == null || spawnPointsForSave.Count == 0)
				{
					Log.Error("No spawn points found! Aborting save process.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\DebugTravelView.cs");
					return;
				}
				VillageSaveInfo villageSaveInfo = MonoSingleton<GlobalSaveController>.Instance.DebugSaveSecondVillage(saveFilenameInput.text);
				SecondMapSaveInfo secondMapSaveInfo = new SecondMapSaveInfo();
				secondMapSaveInfo.RawType = GetMapTypeFlags();
				secondMapSaveInfo.Name = saveFilenameInput.text;
				secondMapSaveInfo.FileName = villageSaveInfo.FileName;
				secondMapSaveInfo.SetSpawnPoints(spawnPointsForSave);
				secondMapSaveInfo.Id = saveFilenameInput.text;
				secondMapSaveInfo.HasHostiles = CheckHasHostiles(secondMapSaveInfo);
				Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Add(secondMapSaveInfo);
				Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Serialize();
				RefreshSavesList();
			}
		}

		private static bool CheckHasHostiles(SecondMapSaveInfo info)
		{
			if (!info.AllSpawnPoints.Any((SpawnPoint spawnPoint) => spawnPoint.Type == SpawnPointType.EnemyAnimal || spawnPoint.Type == SpawnPointType.EnemyArcher || spawnPoint.Type == SpawnPointType.EnemyGeneral) && !MonoSingleton<AnimalManager>.Instance.HasHostileAnimals())
			{
				return MonoSingleton<NPCManager>.Instance.HasHostileNPCs();
			}
			return true;
		}

		private void LoadMap()
		{
			if (!(selectedSave == null))
			{
				string startEvent = null;
				if (startEventOnLoadToggle.isOn)
				{
					startEvent = selectedSave.Type switch
					{
						SecondMapType.Ambush => "game_event_ambush", 
						SecondMapType.Attack => "game_event_attack_camp", 
						SecondMapType.Settlement => "game_event_attack_camp", 
						_ => null, 
					};
				}
				MonoSingleton<TravelManager>.Instance.DebugLoadVillage(selectedSave, workers, prisoners, animals, resources, startEvent, randomizeSpawn: true, spawnLootOnLoadToggle.isOn);
			}
		}

		private void GenerateMap()
		{
			selectedMapSize = GetMapSizes()[mapSizeDropDown.value];
			MonoSingleton<TravelManager>.Instance.GenerateVillage(workers, animals, selectedMapSize, selectedMapType, selectedMapSeed);
		}

		private void RefreshSavesList()
		{
			foreach (SecondMapSaveFileView saveFileView in saveFileViews)
			{
				saveFileView.gameObject.SetActive(value: false);
			}
			int num = 0;
			List<SecondMapSaveInfo> list = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetAllItems().ToList();
			list.Sort((SecondMapSaveInfo saveA, SecondMapSaveInfo saveB) => string.Compare(saveA.Name, saveB.Name, StringComparison.CurrentCulture));
			foreach (SecondMapSaveInfo item in list)
			{
				SecondMapSaveFileView secondMapSaveFileView;
				if (num >= saveFileViews.Count)
				{
					secondMapSaveFileView = UnityEngine.Object.Instantiate(saveFilePrefab, savesGroup.transform).GetComponent<SecondMapSaveFileView>();
					saveFileViews.Add(secondMapSaveFileView);
				}
				else
				{
					secondMapSaveFileView = saveFileViews[num];
				}
				secondMapSaveFileView.gameObject.SetActive(value: true);
				secondMapSaveFileView.Setup(item, OverwriteProfile, DeleteProfile, SetSelectedProfile, null);
				num++;
			}
		}

		private void OverwriteProfile(SecondMapSaveInfo saveInfo)
		{
			saveToOverwrite = saveInfo;
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", OnOverWriteConfirmed),
				new KeyValuePair<string, Action>("general_no", OnOverWriteCanceled)
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("Overwrite save?", buttonActions), handleInput: false);
		}

		private List<SpawnPoint> GetSpawnPointsForSave()
		{
			if (MonoSingleton<SpawnPointManager>.Instance.SpawnPoints != null && MonoSingleton<SpawnPointManager>.Instance.SpawnPoints.Count > 0)
			{
				return MonoSingleton<SpawnPointManager>.Instance.SpawnPoints;
			}
			if (MonoSingleton<TravelManager>.Instance.SaveInfo != null && MonoSingleton<TravelManager>.Instance.SaveInfo.AllSpawnPoints.Any())
			{
				return MonoSingleton<TravelManager>.Instance.SaveInfo.AllSpawnPoints.ToList();
			}
			if (saveToOverwrite != null && saveToOverwrite.AllSpawnPoints.Any())
			{
				return saveToOverwrite.AllSpawnPoints.ToList();
			}
			return null;
		}

		private void OnOverWriteConfirmed()
		{
			List<SpawnPoint> spawnPointsForSave = GetSpawnPointsForSave();
			if (spawnPointsForSave == null || spawnPointsForSave.Count == 0)
			{
				Log.Error("No spawn points found! Aborting save process.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\DebugTravelView.cs");
				return;
			}
			MonoSingleton<GlobalSaveController>.Instance.DeleteSaveFile(saveToOverwrite);
			VillageSaveInfo villageSaveInfo = MonoSingleton<GlobalSaveController>.Instance.DebugSaveSecondVillage(saveToOverwrite.Name);
			int mapTypeFlags = GetMapTypeFlags();
			saveToOverwrite.RawType = ((mapTypeFlags == 0) ? saveToOverwrite.RawType : mapTypeFlags);
			saveToOverwrite.Name = saveToOverwrite.Name;
			saveToOverwrite.FileName = villageSaveInfo.FileName;
			saveToOverwrite.SetSpawnPoints(spawnPointsForSave);
			saveToOverwrite.Id = saveToOverwrite.Name;
			saveToOverwrite.HasHostiles = CheckHasHostiles(saveToOverwrite);
			Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Replace(saveToOverwrite);
			saveToOverwrite = null;
			Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Serialize();
			RefreshProfiles();
			RefreshSavesList();
		}

		private void OnOverWriteCanceled()
		{
			saveToOverwrite = null;
		}

		private void SetSelectedProfile(SecondMapSaveInfo saveInfo)
		{
			selectedSave = saveInfo;
			RefreshProfiles();
		}

		private void DeleteProfile(SecondMapSaveInfo saveInfo)
		{
			if (selectedSave == saveInfo)
			{
				selectedSave = null;
			}
			MonoSingleton<GlobalSaveController>.Instance.DeleteSaveFile(saveInfo);
			Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Remove(saveInfo);
			Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.Serialize();
			RefreshProfiles();
			RefreshSavesList();
		}

		private void RefreshProfiles()
		{
			foreach (SecondMapSaveFileView saveFileView in saveFileViews)
			{
				saveFileView.SetSelected(saveFileView.Profile == selectedSave);
			}
		}

		private void OpenSpawnPointsView()
		{
			if (!(spawnPointEditorView == null))
			{
				CloseView();
				spawnPointEditorView.ShowView();
			}
		}

		private void CloseView()
		{
			EnableInput();
			MonoSingleton<UIClosableController>.Instance.CloseAll();
		}

		private void ExitSecondMap()
		{
			MonoSingleton<TravelManager>.Instance.LoadOriginalVillage();
		}

		private void OnWorkerToggle(bool selected, HumanoidInstance humanoidInstance)
		{
			bool flag = humanoidInstance.IsCaptive();
			bool isEnabled;
			if (selected)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\DebugTravelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding ");
					messageBuilder.AppendFormatted(humanoidInstance.Info.GetFullName());
				}
				Log.Info(messageBuilder);
				if (flag)
				{
					AddPrisoner(humanoidInstance);
				}
				else
				{
					AddWorker(humanoidInstance);
				}
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\DebugTravelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(humanoidInstance.Info.GetFullName());
				}
				Log.Info(messageBuilder);
				if (flag)
				{
					RemovePrisoner(humanoidInstance);
				}
				else
				{
					RemoveWorker(humanoidInstance);
				}
			}
			UpdatedWorkersCount();
		}

		private void GetCreaturesCanGoToMapEdge(IEnumerable<CreatureBase> creaturesList, HashSet<CreatureBase> creaturesCanGoToEdge)
		{
			creaturesCanGoToEdge.Clear();
			using PooledHashSet<uint> pooledHashSet = HashSetPool<uint>.GetJanitor();
			map.RegionAreaManager.GetAreasTouchingEdge(pooledHashSet);
			PathTraversalProvider pathTraversalProvider = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map").GenerateTraversalProvider();
			foreach (CreatureBase creatures in creaturesList)
			{
				if (CombatUtils.IsNullOrDisposed(creatures))
				{
					continue;
				}
				uint area = creatures.GetNode().Area;
				PathTraversalProvider traversalProvider = ((creatures is AnimalInstance) ? pathTraversalProvider : ((!(creatures is HumanoidInstance humanoidInstance) || !(humanoidInstance.ActiveBehaviour is PrisonerBehaviour)) ? creatures.PathTraversalProvider : pathTraversalProvider));
				foreach (uint item in pooledHashSet)
				{
					if (PathfinderUtil.IsAreaReachable(traversalProvider, map, item, area))
					{
						creaturesCanGoToEdge.Add(creatures);
						break;
					}
				}
			}
		}

		private static bool IsAnimalAvailableForCaravanForming(AnimalInstance animal)
		{
			if (animal == null || animal.HasDied || animal.HasDisposed)
			{
				return false;
			}
			if (animal.AnimalType != AnimalType.Pet && animal.AnimalType != AnimalType.Domestic)
			{
				return false;
			}
			return true;
		}

		public void UpdatedWorkersCount()
		{
			int num = workerEntries.Count((TravelWorkerEntry we) => we.isActiveAndEnabled && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			int num2 = workerEntries.Count((TravelWorkerEntry we) => we.isActiveAndEnabled && we.IsSelectedForCaravan && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			bool flag = num - num2 != 1;
			foreach (TravelWorkerEntry workerEntry in workerEntries)
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = workerEntry.Humanoid.ActiveBehaviour as CaptiveNpcBehaviour;
				bool flag2 = captiveNpcBehaviour != null;
				if (flag2 && !captiveNpcBehaviour.Shackled)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText("cant_add_prisoner_caravan");
					workerEntry.SetClickable(clickable: false, text, text);
				}
				else if (!creaturesCanGoToEdge.Contains(workerEntry.Humanoid))
				{
					string text2 = MonoSingleton<LocalizationController>.Instance.GetText(flag2 ? "caravan_prisoner_stuck" : "caravan_worker_stuck");
					workerEntry.SetClickable(clickable: false, text2, text2);
				}
				else if (workerEntry.Humanoid.IsFormingCaravan())
				{
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText(flag2 ? "caravan_prisoner_already_forming" : "caravan_worker_already_forming");
					workerEntry.SetClickable(clickable: false, text3, text3);
				}
				else if (!workerEntry.IsWorkerAble)
				{
					string text4 = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_able");
					workerEntry.SetClickable(clickable: false, text4, text4);
				}
				else if (!workerEntry.IsSelectedForCaravan)
				{
					bool clickable = flag || !(workerEntry.Humanoid.ActiveBehaviour is WorkerBehaviour);
					workerEntry.SetClickable(clickable, string.Empty, string.Empty);
				}
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class TSPlayerTutorialManager : MonoBehaviour
{
	private static TSPlayerTutorialManager _localInstance;

	public bool isFirstTime;

	public List<CollectableItemData> starterPack = new List<CollectableItemData>();

	public TutorialData tutorialData;

	[HideInInspector]
	public TutorialUI tutorialUI;

	[HideInInspector]
	public MissionsPanel missionsPanel;

	public bool startOnAwake = true;

	[Space(10f)]
	private TaskGroup currentTaskGroup;

	private List<TaskData> activeTasks = new List<TaskData>();

	private bool isInitialized;

	private int currentGroupIndex;

	private Dictionary<TaskData, TutorialTask> taskDataToTutorialTask = new Dictionary<TaskData, TutorialTask>();

	public List<CollectableItemData> craftableItemsToLearnOnTutorialComplete = new List<CollectableItemData>();

	private Dictionary<string, (int progress, bool completed)> runtimeTaskProgress = new Dictionary<string, (int, bool)>();

	private TsPlayerNetworkHelper networkHelper;

	private NetworkIdentity networkIdentity;

	private string playerSteamID;

	public static TSPlayerTutorialManager LocalInstance => _localInstance;

	public static TSPlayerTutorialManager Instance => _localInstance;

	private void Awake()
	{
		networkHelper = GetComponent<TsPlayerNetworkHelper>();
		networkIdentity = GetComponent<NetworkIdentity>();
	}

	private void OnDestroy()
	{
		if (_localInstance == this)
		{
			_localInstance = null;
		}
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(PushProgressToInventorySaver);
		}
	}

	private void Start()
	{
		if (networkIdentity != null && !networkIdentity.isLocalPlayer)
		{
			base.enabled = false;
			return;
		}
		_localInstance = this;
		TaskEventManager.OnCollectableEarned.AddListener(IncreaseCollectable);
		TaskEventManager.OnResearchTaskCompleted.AddListener(IncreaseResearch);
		TaskEventManager.OnReachSomewhereTaskCompleted.AddListener(IncreaseReachSomewhere);
		TaskEventManager.OnBuildTaskCompleted.AddListener(IncreaseBuild);
		TaskEventManager.OnInteractTaskCompleted.AddListener(IncreaseInteract);
		TaskEventManager.OnLootTaskCompleted.AddListener(IncreaseLoot);
		TaskEventManager.OnCombatTaskCompleted.AddListener(IncreaseCombat);
		TaskEventManager.OnCraftTaskCompleted.AddListener(IncreaseCraft);
		TaskEventManager.OnPlaceObjectTaskCompleted.AddListener(IncreasePlaceObject);
		TaskEventManager.OnBuildObjectTaskCompleted.AddListener(IncreaseBuildObject);
		TaskEventManager.OnCollectDirtyWaterTaskCompleted.AddListener(IncreaseCollectDirtyWater);
		TaskEventManager.OnAddFuelOnWaterPurifierTaskCompleted.AddListener(IncreaseAddFuelOnWaterPurifier);
		TaskEventManager.OnCollectCleanWaterTaskCompleted.AddListener(IncreaseCollectCleanWater);
		TaskEventManager.OnCookTaskCompleted.AddListener(IncreaseCook);
		TaskEventManager.OnCollectOreTaskCompleted.AddListener(IncreaseCollectOre);
		TaskEventManager.OnMeltOreTaskCompleted.AddListener(IncreaseMeltOre);
		TaskEventManager.OnCollectIngotTaskCompleted.AddListener(IncreaseCollectIngot);
		TaskEventManager.OnOpenBuildCanvasTaskCompleted.AddListener(IncreaseOpenBuildCanvas);
		TaskEventManager.OnAddWaterToTrainTaskCompleted.AddListener(IncreaseAddWaterToTrain);
		TaskEventManager.OnAddFuelToTrainTaskCompleted.AddListener(IncreaseAddFuelToTrain);
		TaskEventManager.OnPressGasPedalTaskCompleted.AddListener(IncreasePressGasPedal);
		TaskEventManager.OnReleaseBrakeTaskCompleted.AddListener(IncreaseReleaseBrake);
		TaskEventManager.OnMoveTheTrainTaskCompleted.AddListener(IncreaseMoveTheTrain);
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(PushProgressToInventorySaver);
		}
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		StartCoroutine(WaitForSteamIDAndInitialize());
	}

	private string GetTaskKey(int groupIndex, int taskIndex)
	{
		return $"{groupIndex}_{taskIndex}";
	}

	private (int progress, bool completed) GetTaskProgress(int groupIndex, int taskIndex)
	{
		string taskKey = GetTaskKey(groupIndex, taskIndex);
		if (runtimeTaskProgress.TryGetValue(taskKey, out (int, bool) value))
		{
			return value;
		}
		return (progress: 0, completed: false);
	}

	private void SetTaskProgress(int groupIndex, int taskIndex, int progress, bool completed)
	{
		string taskKey = GetTaskKey(groupIndex, taskIndex);
		runtimeTaskProgress[taskKey] = (progress, completed);
	}

	private (int progress, bool completed) GetTaskProgress(TaskData taskData)
	{
		int taskGroupIndex = GetTaskGroupIndex(taskData);
		int taskIndex = GetTaskIndex(taskData, taskGroupIndex);
		if (taskGroupIndex >= 0 && taskIndex >= 0)
		{
			return GetTaskProgress(taskGroupIndex, taskIndex);
		}
		return (progress: 0, completed: false);
	}

	private void SetTaskProgress(TaskData taskData, int progress, bool completed)
	{
		int taskGroupIndex = GetTaskGroupIndex(taskData);
		int taskIndex = GetTaskIndex(taskData, taskGroupIndex);
		if (taskGroupIndex >= 0 && taskIndex >= 0)
		{
			SetTaskProgress(taskGroupIndex, taskIndex, progress, completed);
		}
	}

	private bool IsTaskCompleted(TaskData taskData)
	{
		return GetTaskProgress(taskData).completed;
	}

	private int GetCurrentProgress(TaskData taskData)
	{
		return GetTaskProgress(taskData).progress;
	}

	private IEnumerator WaitForSteamIDAndInitialize()
	{
		float elapsed = 0f;
		float timeout = 30f;
		while (elapsed < timeout && (networkHelper == null || string.IsNullOrEmpty(networkHelper.steamID)))
		{
			elapsed += Time.deltaTime;
			yield return null;
		}
		playerSteamID = ((networkHelper != null) ? networkHelper.steamID : "");
		if (string.IsNullOrEmpty(playerSteamID))
		{
			Debug.LogWarning("[TutorialManager] steamID timeout sonrası hala boş, save verisi olmadan başlatılıyor.");
		}
		else if (!NetworkServer.active)
		{
			elapsed = 0f;
			timeout = 10f;
			while (elapsed < timeout && (!(InventorySaver.Instance != null) || !InventorySaver.Instance.GetPlayerTutorialData(playerSteamID).HasValue))
			{
				elapsed += Time.deltaTime;
				yield return null;
			}
		}
		yield return LocalizationSettings.InitializationOperation;
		InitializeTutorial();
	}

	public void InitializeTutorial()
	{
		tutorialUI = Object.FindObjectOfType<TutorialUI>();
		missionsPanel = Object.FindObjectOfType<MissionsPanel>();
		if (tutorialData == null || (tutorialUI == null && missionsPanel == null))
		{
			Debug.LogError("Tutorial Data veya Tutorial UI atanmamış!");
			return;
		}
		isInitialized = true;
		currentGroupIndex = 0;
		LoadProgressFromInventorySaver();
		SyncCommonTasksFromNetwork();
		if (tutorialData.taskGroups.Count > 0)
		{
			StartTaskGroup(0);
		}
	}

	public void StartTaskGroup(int groupIndex)
	{
		if (groupIndex >= tutorialData.taskGroups.Count)
		{
			return;
		}
		currentTaskGroup = tutorialData.taskGroups[groupIndex];
		currentGroupIndex = groupIndex;
		activeTasks.Clear();
		taskDataToTutorialTask.Clear();
		if (tutorialUI != null)
		{
			tutorialUI.SetTitle(currentTaskGroup.GetLocalizedGroupName());
		}
		List<TutorialTask> list = new List<TutorialTask>();
		bool flag = false;
		for (int i = 0; i < currentTaskGroup.tasks.Count; i++)
		{
			TaskData taskData = currentTaskGroup.tasks[i];
			(int progress, bool completed) taskProgress = GetTaskProgress(groupIndex, i);
			int item = taskProgress.progress;
			bool item2 = taskProgress.completed;
			TutorialTask tutorialTask = ConvertToTutorialTask(taskData, item, item2);
			taskDataToTutorialTask[taskData] = tutorialTask;
			list.Add(tutorialTask);
			if (!item2)
			{
				activeTasks.Add(taskData);
				flag = true;
			}
		}
		if (!flag)
		{
			if (currentGroupIndex + 1 < tutorialData.taskGroups.Count)
			{
				StartTaskGroup(currentGroupIndex + 1);
			}
			else
			{
				CompleteTutorial();
			}
			return;
		}
		if (tutorialUI != null)
		{
			tutorialUI.ShowAllGroupTasks(list);
		}
		if (tutorialUI != null)
		{
			tutorialUI.ShowTutorial();
		}
		if (missionsPanel != null)
		{
			missionsPanel.ShowAllGroupTasks(list);
		}
		if (missionsPanel != null)
		{
			missionsPanel.ShowTutorial();
		}
	}

	private TutorialTask ConvertToTutorialTask(TaskData taskData, int currentProgress, bool isCompleted)
	{
		return new TutorialTask
		{
			taskText = GetTaskText(taskData),
			maxProgress = taskData.neededCount,
			currentProgress = currentProgress,
			isCompleted = isCompleted,
			description = GetTaskDescription(taskData),
			triggerType = TutorialTriggerType.Manual,
			dependentTaskIndex = -1,
			targetPosition = Vector3.zero,
			triggerRadius = 2f,
			targetObjectTag = ""
		};
	}

	private string GetTaskText(TaskData taskData)
	{
		string localizedCustomTaskTitle = taskData.GetLocalizedCustomTaskTitle();
		if (!string.IsNullOrEmpty(localizedCustomTaskTitle))
		{
			return localizedCustomTaskTitle;
		}
		return taskData.type switch
		{
			TaskType.Collectable => "Collect " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "items"), 
			TaskType.Research => "Research " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "technology"), 
			TaskType.ReachSomewhere => "Reach " + (taskData.reachAdress ?? "destination"), 
			TaskType.Interact => "Interact with " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "object"), 
			TaskType.Build => "Build " + (taskData.buildingData?.GetLocalizedDisplayName() ?? "structure"), 
			TaskType.Combat => $"Defeat {taskData.zombiesCount} zombies", 
			TaskType.Loot => "Loot " + taskData.collectableItem?.GetLocalizedDisplayName(), 
			TaskType.Craft => "Craft " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "item"), 
			TaskType.PlaceObject => "Place " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "object"), 
			TaskType.BuildObject => "Build " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "structure"), 
			TaskType.CollectDirtyWater => "Collect Dirty Water", 
			TaskType.AddFuelOnWaterPurifier => "Add Fuel to Water Purifier", 
			TaskType.CollectCleanWater => "Collect Clean Water", 
			TaskType.Cook => "Cook " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "food"), 
			TaskType.CollectOre => "Collect " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "ore"), 
			TaskType.MeltOre => "Melt " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "ore"), 
			TaskType.CollectIngot => "Collect " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "ingot"), 
			TaskType.OpenBuildCanvas => "Open Build Canvas", 
			TaskType.AddWaterToTrain => "Add Water to Train", 
			TaskType.AddFuelToTrain => "Add Fuel to Train", 
			TaskType.PressGasPedal => "Press Gas Pedal", 
			TaskType.ReleaseBrake => "Release Brake", 
			TaskType.MoveTheTrain => "Move the Train", 
			_ => "Complete task", 
		};
	}

	private string GetTaskDescription(TaskData taskData)
	{
		return taskData.type switch
		{
			TaskType.Collectable => string.Format("Collect {0} {1}", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "items"), 
			TaskType.Research => "Research " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "technology"), 
			TaskType.ReachSomewhere => "Go to " + (taskData.reachAdress ?? "the marked location"), 
			TaskType.Interact => "Interact with " + (taskData.collectableItem?.GetLocalizedDisplayName() ?? "the object"), 
			TaskType.Build => string.Format("Build {0} {1}", taskData.neededCount, taskData.buildingData?.GetLocalizedDisplayName() ?? "structures"), 
			TaskType.Combat => $"Defeat {taskData.zombiesCount} zombies", 
			TaskType.Loot => "Loot " + taskData.collectableItem?.GetLocalizedDisplayName(), 
			TaskType.Craft => string.Format("Craft {0} {1}", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "items"), 
			TaskType.PlaceObject => string.Format("Place {0} {1} on the train", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "objects"), 
			TaskType.BuildObject => string.Format("Build {0} {1} on the train", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "structures"), 
			TaskType.CollectDirtyWater => $"Collect dirty water {taskData.neededCount} times from water sources", 
			TaskType.AddFuelOnWaterPurifier => $"Add {taskData.neededCount} fuel to the water purifier", 
			TaskType.CollectCleanWater => $"Collect clean water {taskData.neededCount} times from water sources", 
			TaskType.Cook => string.Format("Cook {0} {1} on the grill", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "food items"), 
			TaskType.CollectOre => string.Format("Collect {0} {1} from ore nodes", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "ore"), 
			TaskType.MeltOre => string.Format("Melt {0} {1} in the furnace", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "ore"), 
			TaskType.CollectIngot => string.Format("Collect {0} {1} from the furnace", taskData.neededCount, taskData.collectableItem?.GetLocalizedDisplayName() ?? "ingot"), 
			TaskType.OpenBuildCanvas => "Press the build key to open the build canvas", 
			TaskType.AddWaterToTrain => "Add water to the train's water tank", 
			TaskType.AddFuelToTrain => "Add fuel to the train's fuel tank", 
			TaskType.PressGasPedal => "Press the gas pedal to start the train", 
			TaskType.ReleaseBrake => "Release the brake to allow the train to move", 
			TaskType.MoveTheTrain => "Get the train moving with fuel, water, gas and brake released", 
			_ => "Complete the task", 
		};
	}

	private void OnLocaleChanged(Locale newLocale)
	{
		RefreshAllTaskTexts();
	}

	public void RefreshAllTaskTexts()
	{
		if (!isInitialized)
		{
			return;
		}
		if (tutorialUI != null && currentTaskGroup != null)
		{
			tutorialUI.SetTitle(currentTaskGroup.GetLocalizedGroupName());
		}
		foreach (KeyValuePair<TaskData, TutorialTask> item in taskDataToTutorialTask)
		{
			TaskData key = item.Key;
			TutorialTask value = item.Value;
			if (key != null && value != null)
			{
				value.taskText = GetTaskText(key);
				value.description = GetTaskDescription(key);
			}
		}
		if (tutorialUI != null)
		{
			tutorialUI.RefreshTaskTexts();
		}
		if (missionsPanel != null)
		{
			missionsPanel.RefreshTaskTexts();
		}
	}

	public void CompleteTask(TaskData taskData)
	{
		int taskGroupIndex = GetTaskGroupIndex(taskData);
		int taskIndex = GetTaskIndex(taskData, taskGroupIndex);
		if (GetTaskProgress(taskGroupIndex, taskIndex).completed)
		{
			return;
		}
		SetTaskProgress(taskGroupIndex, taskIndex, taskData.neededCount, completed: true);
		if (taskDataToTutorialTask.ContainsKey(taskData))
		{
			TutorialTask tutorialTask = taskDataToTutorialTask[taskData];
			tutorialTask.isCompleted = true;
			if (tutorialUI != null)
			{
				tutorialUI.CompleteTask(tutorialTask);
			}
			if (missionsPanel != null)
			{
				missionsPanel.CompleteTask(tutorialTask);
			}
			if (Singleton<UserMessagePanelCenter>.Instance != null)
			{
				Singleton<UserMessagePanelCenter>.Instance.SendMessageToPanel("Mission Completed\n" + tutorialTask.taskText);
			}
		}
		activeTasks.Remove(taskData);
		if (taskData.isCommonTask && taskGroupIndex >= 0 && taskIndex >= 0)
		{
			TsPlayerNetworkHelper localPlayerNetworkHelper = GetLocalPlayerNetworkHelper();
			if (localPlayerNetworkHelper != null)
			{
				localPlayerNetworkHelper.CmdCompleteCommonTask(taskGroupIndex, taskIndex);
			}
			else
			{
				Debug.LogWarning("Could not find local player to send common task completion!");
			}
		}
		PushProgressToInventorySaver();
		if (IsTaskGroupCompleted())
		{
			CompleteTaskGroup();
		}
	}

	public void UpdateTaskProgress(TaskData taskData, int progress)
	{
		int taskGroupIndex = GetTaskGroupIndex(taskData);
		int taskIndex = GetTaskIndex(taskData, taskGroupIndex);
		bool item = GetTaskProgress(taskGroupIndex, taskIndex).completed;
		int num = Mathf.Max(taskData.neededCount, 1);
		SetTaskProgress(taskGroupIndex, taskIndex, progress, item);
		if (taskDataToTutorialTask.ContainsKey(taskData))
		{
			TutorialTask tutorialTask = taskDataToTutorialTask[taskData];
			tutorialTask.currentProgress = progress;
			if (tutorialUI != null)
			{
				tutorialUI.UpdateTaskProgress(tutorialTask);
			}
			if (missionsPanel != null)
			{
				missionsPanel.UpdateTaskProgress(tutorialTask);
			}
		}
		if (taskData.isCommonTask && taskGroupIndex >= 0 && taskIndex >= 0)
		{
			TsPlayerNetworkHelper localPlayerNetworkHelper = GetLocalPlayerNetworkHelper();
			if (localPlayerNetworkHelper != null)
			{
				localPlayerNetworkHelper.CmdUpdateCommonTaskProgress(taskGroupIndex, taskIndex, progress);
			}
		}
		PushProgressToInventorySaver();
		if (progress >= num && !item)
		{
			CompleteTask(taskData);
		}
	}

	public void IncreaseCollectable(CollectableItemData collectableData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Collectable && item.collectableItem == collectableData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseResearch(CollectableItemData researchData)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Research && item.collectableItem == researchData)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseBuild(CollectableItemData buildData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Build && item.buildingData == buildData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseInteract(CollectableItemData interactData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Interact && item.collectableItem == interactData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCombat(int zombieKillCount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Combat)
			{
				int progress = GetCurrentProgress(item) + zombieKillCount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseReachSomewhere(string reachAddress)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.ReachSomewhere && item.reachAdress == reachAddress)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseLoot(CollectableItemData interactData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Loot && item.collectableItem == interactData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCraft(CollectableItemData craftedData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Craft && item.collectableItem == craftedData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreasePlaceObject(CollectableItemData placedData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.PlaceObject && item.collectableItem == placedData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseBuildObject(CollectableItemData buildData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.BuildObject && item.collectableItem == buildData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCollectDirtyWater(int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.CollectDirtyWater)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseAddFuelOnWaterPurifier(CollectableItemData fuelData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.AddFuelOnWaterPurifier)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCollectCleanWater(int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.CollectCleanWater)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCook(CollectableItemData cookedData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.Cook && item.collectableItem == cookedData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCollectOre(CollectableItemData oreData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.CollectOre && item.collectableItem == oreData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseMeltOre(CollectableItemData oreData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.MeltOre && item.collectableItem == oreData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseCollectIngot(CollectableItemData ingotData, int amount = 1)
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.CollectIngot && item.collectableItem == ingotData)
			{
				int progress = GetCurrentProgress(item) + amount;
				UpdateTaskProgress(item, progress);
			}
		}
	}

	public void IncreaseOpenBuildCanvas()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.OpenBuildCanvas)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseAddWaterToTrain()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.AddWaterToTrain)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseAddFuelToTrain()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.AddFuelToTrain)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreasePressGasPedal()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.PressGasPedal)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseReleaseBrake()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.ReleaseBrake)
			{
				CompleteTask(item);
			}
		}
	}

	public void IncreaseMoveTheTrain()
	{
		foreach (TaskData item in activeTasks.ToList())
		{
			if (item.type == TaskType.MoveTheTrain)
			{
				CompleteTask(item);
			}
		}
	}

	private bool IsTaskGroupCompleted()
	{
		if (currentTaskGroup == null)
		{
			return false;
		}
		for (int i = 0; i < currentTaskGroup.tasks.Count; i++)
		{
			if (!GetTaskProgress(currentGroupIndex, i).completed)
			{
				return false;
			}
		}
		return true;
	}

	private void CompleteTaskGroup()
	{
		if (currentGroupIndex + 1 < tutorialData.taskGroups.Count)
		{
			StartCoroutine(TransitionToNextGroup());
		}
		else
		{
			CompleteTutorial();
		}
	}

	private IEnumerator TransitionToNextGroup()
	{
		yield return new WaitForSeconds(2f);
		if (tutorialUI != null)
		{
			tutorialUI.HideTutorial();
		}
		if (missionsPanel != null)
		{
			missionsPanel.HideTutorial();
		}
		float num = ((tutorialUI != null) ? tutorialUI.slideSpeed : ((missionsPanel != null) ? missionsPanel.slideSpeed : 0.5f));
		float num2 = ((tutorialUI != null) ? tutorialUI.fadeDuration : ((missionsPanel != null) ? missionsPanel.fadeDuration : 0.4f));
		yield return new WaitForSeconds(num + num2 + 0.5f);
		StartTaskGroup(currentGroupIndex + 1);
	}

	private void CompleteTutorial()
	{
		if (tutorialUI != null)
		{
			tutorialUI.HideTutorial();
		}
		if (missionsPanel != null)
		{
			missionsPanel.HideTutorial();
		}
		isInitialized = false;
	}

	private void DebugCompleteCurrentTask()
	{
		if (activeTasks.Count > 0)
		{
			CompleteTask(activeTasks[0]);
		}
	}

	public void SkipToNextTask()
	{
		if (activeTasks.Count > 0)
		{
			TaskData taskData = activeTasks[0];
			int taskGroupIndex = GetTaskGroupIndex(taskData);
			int taskIndex = GetTaskIndex(taskData, taskGroupIndex);
			SetTaskProgress(taskGroupIndex, taskIndex, taskData.neededCount, completed: false);
			CompleteTask(taskData);
		}
		else if (currentTaskGroup != null)
		{
			CompleteTaskGroup();
		}
		else
		{
			Debug.Log("No active tasks or task groups to skip");
		}
	}

	public void ResetTutorial()
	{
		runtimeTaskProgress.Clear();
		activeTasks.Clear();
		taskDataToTutorialTask.Clear();
		currentTaskGroup = null;
		currentGroupIndex = 0;
		isInitialized = false;
		if (tutorialUI != null)
		{
			tutorialUI.HideTutorial();
		}
		if (missionsPanel != null)
		{
			missionsPanel.HideTutorial();
		}
		if (InventorySaver.Instance != null && !string.IsNullOrEmpty(playerSteamID))
		{
			PlayerTutorialSaveData playerTutorialSaveData = new PlayerTutorialSaveData
			{
				hasData = false,
				currentGroupIndex = 0,
				taskEntries = new List<TutorialTaskEntry>()
			};
			if (NetworkServer.active)
			{
				InventorySaver.Instance.SavePlayerTutorial(playerSteamID, playerTutorialSaveData);
			}
			else
			{
				InventorySaver.Instance.CmdSyncTutorialProgress(playerTutorialSaveData);
			}
		}
	}

	public void ResetForNewGame()
	{
		ResetTutorial();
	}

	public PlayerTutorialSaveData CollectTutorialSaveData()
	{
		PlayerTutorialSaveData result = new PlayerTutorialSaveData
		{
			hasData = true,
			currentGroupIndex = currentGroupIndex,
			taskEntries = new List<TutorialTaskEntry>()
		};
		if (tutorialData == null)
		{
			return result;
		}
		for (int i = 0; i < tutorialData.taskGroups.Count; i++)
		{
			TaskGroup taskGroup = tutorialData.taskGroups[i];
			for (int j = 0; j < taskGroup.tasks.Count; j++)
			{
				var (progress, completed) = GetTaskProgress(i, j);
				result.taskEntries.Add(new TutorialTaskEntry
				{
					groupIndex = i,
					taskIndex = j,
					progress = progress,
					completed = completed
				});
			}
		}
		return result;
	}

	private void LoadProgressFromInventorySaver()
	{
		if (tutorialData == null || InventorySaver.Instance == null || string.IsNullOrEmpty(playerSteamID))
		{
			return;
		}
		PlayerTutorialSaveData? playerTutorialData = InventorySaver.Instance.GetPlayerTutorialData(playerSteamID);
		if (!playerTutorialData.HasValue || !playerTutorialData.Value.hasData)
		{
			return;
		}
		PlayerTutorialSaveData value = playerTutorialData.Value;
		runtimeTaskProgress.Clear();
		foreach (TutorialTaskEntry taskEntry in value.taskEntries)
		{
			SetTaskProgress(taskEntry.groupIndex, taskEntry.taskIndex, taskEntry.progress, taskEntry.completed);
		}
		currentGroupIndex = value.currentGroupIndex;
	}

	private void PushProgressToInventorySaver()
	{
		if (!(tutorialData == null) && !(InventorySaver.Instance == null) && !string.IsNullOrEmpty(playerSteamID))
		{
			PlayerTutorialSaveData playerTutorialSaveData = CollectTutorialSaveData();
			if (NetworkServer.active)
			{
				InventorySaver.Instance.SavePlayerTutorial(playerSteamID, playerTutorialSaveData);
			}
			else
			{
				InventorySaver.Instance.CmdSyncTutorialProgress(playerTutorialSaveData);
			}
		}
	}

	private TsPlayerNetworkHelper GetLocalPlayerNetworkHelper()
	{
		if (TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			return TrainGameManager.Instance.mainPlayer.GetComponent<TsPlayerNetworkHelper>();
		}
		return null;
	}

	private int GetTaskGroupIndex(TaskData taskData)
	{
		if (tutorialData == null)
		{
			return -1;
		}
		for (int i = 0; i < tutorialData.taskGroups.Count; i++)
		{
			if (tutorialData.taskGroups[i].tasks.Contains(taskData))
			{
				return i;
			}
		}
		return -1;
	}

	private int GetTaskIndex(TaskData taskData, int groupIndex)
	{
		if (tutorialData == null || groupIndex < 0 || groupIndex >= tutorialData.taskGroups.Count)
		{
			return -1;
		}
		return tutorialData.taskGroups[groupIndex].tasks.IndexOf(taskData);
	}

	public void CompleteCommonTaskFromNetwork(int groupIndex, int taskIndex)
	{
		CompleteCommonTask(groupIndex, taskIndex);
	}

	public void UpdateCommonTaskProgressFromNetwork(int groupIndex, int taskIndex, int progress)
	{
		UpdateCommonTaskProgress(groupIndex, taskIndex, progress);
	}

	public void CompleteCommonTask(int groupIndex, int taskIndex)
	{
		if (tutorialData == null || groupIndex < 0 || groupIndex >= tutorialData.taskGroups.Count)
		{
			return;
		}
		TaskGroup taskGroup = tutorialData.taskGroups[groupIndex];
		if (taskIndex < 0 || taskIndex >= taskGroup.tasks.Count)
		{
			return;
		}
		TaskData taskData = taskGroup.tasks[taskIndex];
		if (!taskData.isCommonTask)
		{
			Debug.LogWarning($"CompleteCommonTask called for non-common task: Group {groupIndex}, Task {taskIndex}");
		}
		else
		{
			if (GetTaskProgress(groupIndex, taskIndex).completed)
			{
				return;
			}
			SetTaskProgress(groupIndex, taskIndex, taskData.neededCount, completed: true);
			if (taskDataToTutorialTask.ContainsKey(taskData))
			{
				TutorialTask tutorialTask = taskDataToTutorialTask[taskData];
				tutorialTask.isCompleted = true;
				tutorialTask.currentProgress = taskData.neededCount;
				if (tutorialUI != null)
				{
					tutorialUI.CompleteTask(tutorialTask);
				}
				if (missionsPanel != null)
				{
					missionsPanel.CompleteTask(tutorialTask);
				}
				if (Singleton<UserMessagePanelCenter>.Instance != null)
				{
					Singleton<UserMessagePanelCenter>.Instance.SendMessageToPanel("Mission Completed\n" + tutorialTask.taskText);
				}
			}
			activeTasks.Remove(taskData);
			if (IsTaskGroupCompleted())
			{
				CompleteTaskGroup();
			}
		}
	}

	public void UpdateCommonTaskProgress(int groupIndex, int taskIndex, int progress)
	{
		if (tutorialData == null || groupIndex < 0 || groupIndex >= tutorialData.taskGroups.Count)
		{
			return;
		}
		TaskGroup taskGroup = tutorialData.taskGroups[groupIndex];
		if (taskIndex < 0 || taskIndex >= taskGroup.tasks.Count)
		{
			return;
		}
		TaskData taskData = taskGroup.tasks[taskIndex];
		if (!taskData.isCommonTask)
		{
			return;
		}
		var (num, flag) = GetTaskProgress(groupIndex, taskIndex);
		if (progress <= num || flag)
		{
			return;
		}
		SetTaskProgress(groupIndex, taskIndex, progress, completed: false);
		if (taskDataToTutorialTask.ContainsKey(taskData))
		{
			TutorialTask tutorialTask = taskDataToTutorialTask[taskData];
			tutorialTask.currentProgress = progress;
			if (tutorialUI != null)
			{
				tutorialUI.UpdateTaskProgress(tutorialTask);
			}
			if (missionsPanel != null)
			{
				missionsPanel.UpdateTaskProgress(tutorialTask);
			}
		}
		if (progress >= taskData.neededCount)
		{
			CompleteCommonTask(groupIndex, taskIndex);
		}
	}

	private void SyncCommonTasksFromNetwork()
	{
		if (tutorialData == null || InventorySaver.Instance == null)
		{
			return;
		}
		foreach (TutorialTaskEntry syncedCommonTask in InventorySaver.Instance.syncedCommonTasks)
		{
			if (syncedCommonTask.groupIndex >= tutorialData.taskGroups.Count)
			{
				continue;
			}
			TaskGroup taskGroup = tutorialData.taskGroups[syncedCommonTask.groupIndex];
			if (syncedCommonTask.taskIndex < taskGroup.tasks.Count && taskGroup.tasks[syncedCommonTask.taskIndex].isCommonTask)
			{
				var (num, flag) = GetTaskProgress(syncedCommonTask.groupIndex, syncedCommonTask.taskIndex);
				if (syncedCommonTask.progress > num || (syncedCommonTask.completed && !flag))
				{
					SetTaskProgress(syncedCommonTask.groupIndex, syncedCommonTask.taskIndex, syncedCommonTask.progress, syncedCommonTask.completed);
				}
			}
		}
	}
}

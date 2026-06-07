#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Commands.ToolsCommands;
using Data.FactoryFloor.Resources;
using Data.Notifications;
using Data.Operator;
using Data.Statistics;
using Data.Variables.Recipes;
using Events.FactoryFloor;
using Logic.Factory.Blueprint;
using Presentation.UI.Overlays.Notifications;
using SRDebugger;
using SRDebugger.Internal;
using SRF.Service;
using StompyRobot.SROptions;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting;
using Utils;

[Preserve]
public class SROptions : INotifyPropertyChanged
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
	public sealed class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
	{
		public DisplayNameAttribute(string displayName)
			: base(displayName)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public sealed class IncrementAttribute : SRDebugger.IncrementAttribute
	{
		public IncrementAttribute(double increment)
			: base(increment)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public sealed class NumberRangeAttribute : SRDebugger.NumberRangeAttribute
	{
		public NumberRangeAttribute(double min, double max)
			: base(min, max)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
	public sealed class SortAttribute : SRDebugger.SortAttribute
	{
		public SortAttribute(int priority)
			: base(priority)
		{
		}
	}

	private const string CATEGORY_FACTORY_FLOOR = "Factory Floor";

	private const string CATEGORY_CAMERA = "Camera";

	private const string CATEGORY_UPDATE_FREQUENCIES = "Update Frequencies";

	private const string CATEGORY_SETTINGS = "Player Settings";

	private const string CATEGORY_UI = "UI Settings";

	private const string CATEGORY_SAVEGAME = "Save game";

	private const string CATEGORY_QUESTS = "Quests";

	private const string CATEGORY_ANALYTICS = "Analytics";

	private const string CATEGORY_DATASHARDS = "Data Shards";

	private const string CATEGORY_TECHTREE = "Tech Tree";

	private const string CATEGORY_OBJECTIVES = "Objectives";

	private const string CATEGORY_RANK = "Rank";

	private const string CATEGORY_EXPANSION_PERMITS = "Expansion Permits";

	private const string CATEGORY_DAYNIGHTCYCLE = "Day Night Cycle";

	private const string CATEGORY_MAXLOCKEDBUILDINGSTAGES = "Max Locked Building Stages";

	private const string CATEGORY_LOCKED_RECIPES = "Unlocked Recipes";

	private const string CATEGORY_AUTOSPAWNER = "Auto Spawner";

	private const string CATEGORY_STEAMACHIEVEMENTS = "STEAM ACHIEVEMENTS";

	private int _cameraZoomLimitMin = SROptionsReferences.Instance.CameraZoomLimitMin.Value;

	private int _cameraZoomLimitMax = SROptionsReferences.Instance.CameraZoomLimitMax.Value;

	private int _rawResourceAmount = SROptionsReferences.Instance.RawResourceAmount.Value;

	private int _globalUpdateMultiplier = SROptionsReferences.Instance.GlobalUpdateMultiplier.Value;

	private int _conveyorUpdateFrequency = SROptionsReferences.Instance.ConveyorUpdateFrequency.Value;

	private int _extractorUpdateFrequency = SROptionsReferences.Instance.ExtractorUpdateFrequency.Value;

	private int _furnaceUpdateFrequency = SROptionsReferences.Instance.FurnaceUpdateFrequency.Value;

	private int _cutterUpdateFrequency = SROptionsReferences.Instance.CutterUpdateFrequency.Value;

	private int _stamperUpdateFrequency = SROptionsReferences.Instance.StamperUpdateFrequency.Value;

	private int _assemblerUpdateFrequency = SROptionsReferences.Instance.AssemblerUpdateFrequency.Value;

	private int _splitterUpdateFrequency = SROptionsReferences.Instance.SplitterUpdateFrequency.Value;

	private int _painterUpdateFrequency = SROptionsReferences.Instance.PainterUpdateFrequency.Value;

	private int _balanceInterval;

	private int _balanceValue;

	private int _xpToAdd = 1;

	private int _datashardsToAdd = 1;

	private int _expansionPermitsToAdd = 1;

	private int _expansionPermitsToRemove = 1;

	private static SROptions _current;

	[Category("Save game")]
	public string FeatureFlagsEnabled => SROptionsReferences.Instance.FeatureFlags.Current.ToString();

	[Category("Save game")]
	public string CurrentlyEnabledInputMaps => SROptionsReferences.Instance.GetCurrentlyEnabledInputMaps();

	[Category("Camera")]
	[SRDebugger.NumberRange(30.0, 600.0)]
	public int CameraZoomLimitMin
	{
		get
		{
			return _cameraZoomLimitMin;
		}
		set
		{
			_cameraZoomLimitMin = value;
			SROptionsReferences.Instance.CameraZoomLimitMin.SetValue(value);
			OnPropertyChanged("CameraZoomLimitMin");
		}
	}

	[Category("Camera")]
	[SRDebugger.NumberRange(0.0, 30.0)]
	public int CameraZoomLimitMax
	{
		get
		{
			return _cameraZoomLimitMax;
		}
		set
		{
			_cameraZoomLimitMax = value;
			SROptionsReferences.Instance.CameraZoomLimitMax.SetValue(value);
			OnPropertyChanged("CameraZoomLimitMax");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int RawResourceAmount
	{
		get
		{
			return _rawResourceAmount;
		}
		set
		{
			_rawResourceAmount = value;
			SROptionsReferences.Instance.RawResourceAmount.SetValue(value);
			OnPropertyChanged("RawResourceAmount");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 64.0)]
	public int GlobalUpdateMultiplier
	{
		get
		{
			return _globalUpdateMultiplier;
		}
		set
		{
			_globalUpdateMultiplier = value;
			SROptionsReferences.Instance.GlobalUpdateMultiplier.SetValue(value);
			OnPropertyChanged("GlobalUpdateMultiplier");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int ConveyorUpdateFrequency
	{
		get
		{
			return _conveyorUpdateFrequency;
		}
		set
		{
			_conveyorUpdateFrequency = value;
			SROptionsReferences.Instance.ConveyorUpdateFrequency.SetValue(value);
			OnPropertyChanged("ConveyorUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int ExtractorUpdateFrequency
	{
		get
		{
			return _extractorUpdateFrequency;
		}
		set
		{
			_extractorUpdateFrequency = value;
			SROptionsReferences.Instance.ExtractorUpdateFrequency.SetValue(value);
			OnPropertyChanged("ExtractorUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int FurnaceUpdateFrequency
	{
		get
		{
			return _furnaceUpdateFrequency;
		}
		set
		{
			_furnaceUpdateFrequency = value;
			SROptionsReferences.Instance.FurnaceUpdateFrequency.SetValue(value);
			OnPropertyChanged("FurnaceUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int CutterUpdateFrequency
	{
		get
		{
			return _cutterUpdateFrequency;
		}
		set
		{
			_cutterUpdateFrequency = value;
			SROptionsReferences.Instance.CutterUpdateFrequency.SetValue(value);
			OnPropertyChanged("CutterUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int StamperUpdateFrequency
	{
		get
		{
			return _stamperUpdateFrequency;
		}
		set
		{
			_stamperUpdateFrequency = value;
			SROptionsReferences.Instance.StamperUpdateFrequency.SetValue(value);
			OnPropertyChanged("StamperUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int AssemblerUpdateFrequency
	{
		get
		{
			return _assemblerUpdateFrequency;
		}
		set
		{
			_assemblerUpdateFrequency = value;
			SROptionsReferences.Instance.AssemblerUpdateFrequency.SetValue(value);
			OnPropertyChanged("AssemblerUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int SplitterUpdateFrequency
	{
		get
		{
			return _splitterUpdateFrequency;
		}
		set
		{
			_splitterUpdateFrequency = value;
			SROptionsReferences.Instance.SplitterUpdateFrequency.SetValue(value);
			OnPropertyChanged("SplitterUpdateFrequency");
		}
	}

	[Category("Update Frequencies")]
	[SRDebugger.NumberRange(0.0, 512.0)]
	public int PainterUpdateFrequency
	{
		get
		{
			return _painterUpdateFrequency;
		}
		set
		{
			_painterUpdateFrequency = value;
			SROptionsReferences.Instance.PainterUpdateFrequency.SetValue(value);
			OnPropertyChanged("PainterUpdateFrequency");
		}
	}

	[Category("Analytics")]
	[SRDebugger.Increment(15.0)]
	public int BalanceInterval
	{
		get
		{
			return _balanceInterval;
		}
		set
		{
			_balanceInterval = value;
			OnPropertyChanged("BalanceInterval");
		}
	}

	[Category("Analytics")]
	public int BalanceValue
	{
		get
		{
			return _balanceValue;
		}
		set
		{
			_balanceValue = value;
			OnPropertyChanged("BalanceValue");
		}
	}

	[Category("Rank")]
	public int XPToAdd
	{
		get
		{
			return _xpToAdd;
		}
		set
		{
			_xpToAdd = Mathf.Max(0, value);
			OnPropertyChanged("XPToAdd");
		}
	}

	[Category("Data Shards")]
	public int DataShardsToAdd
	{
		get
		{
			return _datashardsToAdd;
		}
		set
		{
			_datashardsToAdd = Mathf.Max(0, value);
			OnPropertyChanged("DataShardsToAdd");
		}
	}

	[Category("Expansion Permits")]
	public int ExpansionPermitsToAdd
	{
		get
		{
			return _expansionPermitsToAdd;
		}
		set
		{
			_expansionPermitsToAdd = Mathf.Max(0, value);
			OnPropertyChanged("ExpansionPermitsToAdd");
		}
	}

	[Category("Expansion Permits")]
	public int ExpansionPermitsToRemove
	{
		get
		{
			return _expansionPermitsToRemove;
		}
		set
		{
			_expansionPermitsToRemove = Mathf.Max(0, value);
			OnPropertyChanged("ExpansionPermitsToRemove");
		}
	}

	public static SROptions Current => _current;

	public event SROptionsPropertyChanged PropertyChanged;

	private event PropertyChangedEventHandler InterfacePropertyChangedEventHandler;

	event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
	{
		add
		{
			InterfacePropertyChangedEventHandler += value;
		}
		remove
		{
			InterfacePropertyChangedEventHandler -= value;
		}
	}

	[Category("STEAM ACHIEVEMENTS")]
	public void ClearAllStatsAndAchievements()
	{
		SROptionsReferences.Instance.SteamAchievementsManager.TestClearStatsAndAchievements();
	}

	[Category("STEAM ACHIEVEMENTS")]
	public void PrintAllStats()
	{
		SROptionsReferences.Instance.SteamAchievementsManager.TestPrintAllStats();
	}

	[Category("Auto Spawner")]
	public void AutoFillIslandWithFactoryObject()
	{
		Vector3Int position = new Vector3Int(Mathf.RoundToInt(SROptionsReferences.Instance.CameraView.transform.position.x), 0, Mathf.RoundToInt(SROptionsReferences.Instance.CameraView.transform.position.z));
		if (!SROptionsReferences.Instance.IslandLayer.TryGetIslandAtWorldPosition(position, out var islandObject))
		{
			return;
		}
		this.Log($"Autospawn on island {islandObject.Position}", "AutoFillIslandWithFactoryObject", 67);
		List<FactoryObjectData> autoSpawnerList = SROptionsReferences.Instance.AutoSpawnerList;
		int num = 0;
		int x = islandObject.Size.x;
		int y = islandObject.Size.y;
		for (int i = 0; i < x; i++)
		{
			for (int j = 0; j < y; j++)
			{
				Vector3Int position2 = islandObject.Position + new Vector3Int(i, 0, j) - new Vector3Int(islandObject.Size.x / 2, 0, islandObject.Size.y / 2);
				FactoryObjectData factoryObjectData = autoSpawnerList[num % autoSpawnerList.Count];
				List<Vector3Int> relativePositions = new List<Vector3Int>(factoryObjectData.RelativePositions);
				new PlaceBlueprintCommand(SROptionsReferences.Instance.FactoryLayer, SROptionsReferences.Instance.TerrainLayer, position2, 0, new Blueprint(position2, 0, new List<BlueprintElement>
				{
					new BlueprintElement(relativePositions, factoryObjectData, 0, mirrored: false)
				}), SROptionsReferences.Instance.CreateFactoryObjectEvent, SROptionsReferences.Instance.GridLocator, SROptionsReferences.Instance.FactoryObjectsRemoveViewsEvent, SROptionsReferences.Instance.AudioManagerLocator).TryDo();
				num++;
			}
		}
	}

	[Category("Unlocked Recipes")]
	public void UnlockAllRecipes()
	{
		foreach (RecipeData recipe in SROptionsReferences.Instance.RecipeDatabase.Recipes)
		{
			SROptionsReferences.Instance.UnlockedRecipesPersistentSO.TryUnlockRecipe(recipe);
		}
	}

	[Category("Max Locked Building Stages")]
	public void IncreaseGreyMaxLockedBuildingStage()
	{
		SROptionsReferences.Instance.GreyMaxLockedBuildingStageData.Apply(SROptionsReferences.Instance.GreyMaxLockedBuildingStageData.MaxLockedBuildingStage + 1);
	}

	[Category("Max Locked Building Stages")]
	public void IncreaseBlueMaxLockedBuildingStage()
	{
		SROptionsReferences.Instance.BlueMaxLockedBuildingStageData.Apply(SROptionsReferences.Instance.BlueMaxLockedBuildingStageData.MaxLockedBuildingStage + 1);
	}

	[Category("Max Locked Building Stages")]
	public void IncreaseYellowMaxLockedBuildingStage()
	{
		SROptionsReferences.Instance.YellowMaxLockedBuildingStageData.Apply(SROptionsReferences.Instance.YellowMaxLockedBuildingStageData.MaxLockedBuildingStage + 1);
	}

	[Category("Quests")]
	public void FinishOnboarding()
	{
		SROptionsReferences.Instance.QuestManager.SetShouldAutoCompleteAll();
	}

	[Category("Quests")]
	public void CompleteActiveObjectives()
	{
		SROptionsReferences.Instance.QuestManager.SetShouldAutoCompleteOnce();
	}

	[Category("Quests")]
	public void CompleteCurrentQuest()
	{
		SROptionsReferences.Instance.QuestManager.SetShouldAutoCompleteRemainingSubQuests();
	}

	[Category("Save game")]
	public void AutoSave()
	{
		SROptionsReferences.Instance.AutoSaveService.AutoSave();
	}

	[Category("Save game")]
	public void DebugLogFeatureFlags()
	{
		Debug.Log(FeatureFlagsEnabled);
	}

	[Category("Save game")]
	public void UnlockAllOperators()
	{
		SROptionsReferences.Instance.LockedFactoryObjectsPersistentSO.UnlockAll();
	}

	[Category("Save game")]
	public void LockAllOperators()
	{
		SROptionsReferences.Instance.LockedFactoryObjectsPersistentSO.LockAll();
	}

	[Category("Save game")]
	public void UnlockAllTools()
	{
		SROptionsReferences.Instance.LockedFactoryToolsPersistentSO.UnlockAll();
	}

	[Category("Save game")]
	public void LockAllTools()
	{
		SROptionsReferences.Instance.LockedFactoryToolsPersistentSO.DebugLockAll();
	}

	[Category("Save game")]
	public void UnlockAllIslands()
	{
		SROptionsReferences.Instance.UnlockedIslandsPersistentSO.UnlockAll();
	}

	[Category("Save game")]
	public void UnlockBlueprints()
	{
		SROptionsReferences.Instance.UnlockBlueprints.Unlock();
	}

	[Category("Camera")]
	public void SaveCameraTransform()
	{
		PlayerPrefs.SetFloat("OriginX", SROptionsReferences.Instance.CameraView.transform.position.x);
		PlayerPrefs.SetFloat("OriginY", SROptionsReferences.Instance.CameraView.transform.position.y);
		PlayerPrefs.SetFloat("OriginZ", SROptionsReferences.Instance.CameraView.transform.position.z);
		PlayerPrefs.SetFloat("CameraZoomPercentage", SROptionsReferences.Instance.CameraView.CurrentZoomPercentage);
		PlayerPrefs.SetFloat("CameraPitchRotation", SROptionsReferences.Instance.CameraView.CameraPitchRotation);
		PlayerPrefs.SetFloat("OriginYawRotation", SROptionsReferences.Instance.CameraView.OriginYawRotation);
	}

	[Category("Camera")]
	public void LoadCameraTransform()
	{
		Vector3 position = new Vector3(PlayerPrefs.GetFloat("OriginX"), PlayerPrefs.GetFloat("OriginY"), PlayerPrefs.GetFloat("OriginZ"));
		float zoomPercentage = PlayerPrefs.GetFloat("CameraZoomPercentage");
		float targetPitch = PlayerPrefs.GetFloat("CameraPitchRotation");
		float targetYaw = PlayerPrefs.GetFloat("OriginYawRotation");
		SROptionsReferences.Instance.CameraView.LerpToTarget(position, zoomPercentage, targetYaw, targetPitch, blockInput: false);
	}

	[Category("Camera")]
	public void ToggleCameraController()
	{
		SROptionsReferences.Instance.CameraControllerSwitcher.ToggleCamera();
	}

	[Category("Camera")]
	public void ToggleWindParticleSystems()
	{
		foreach (ParticleSystem windParticleSystem in SROptionsReferences.Instance.WindParticleSystems)
		{
			windParticleSystem.gameObject.SetActive(!windParticleSystem.gameObject.activeInHierarchy);
		}
	}

	[Category("Factory Floor")]
	public void UnlockEVERYTHING()
	{
		SROptionsReferences.Instance.LockedFactoryObjectsPersistentSO.UnlockAll();
		SROptionsReferences.Instance.LockedFactoryToolsPersistentSO.UnlockAll();
		SROptionsReferences.Instance.UnlockedIslandsPersistentSO.UnlockAll();
		SROptionsReferences.Instance.QuestManager.SetShouldAutoCompleteAll();
		ResourceDataSO greyDataShardResource = SROptionsReferences.Instance.GreyDataShardResource;
		ResourceDataSO blueDataShardResource = SROptionsReferences.Instance.BlueDataShardResource;
		ResourceDataSO yellowDataShardResource = SROptionsReferences.Instance.YellowDataShardResource;
		ResourceDataSO redDataShardResource = SROptionsReferences.Instance.RedDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(new List<ResourceDataSO> { greyDataShardResource, blueDataShardResource, yellowDataShardResource, redDataShardResource }, 999999);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(greyDataShardResource.ID, 999999u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(blueDataShardResource.ID, 999999u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(yellowDataShardResource.ID, 999999u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(redDataShardResource.ID, 999999u);
		SROptionsReferences.Instance.AddXPEvent.Fire(999999, XPEarnedSource.Cheat);
		SROptionsReferences.Instance.TechTreeManager.DebugUnlockAllNodes();
	}

	[Category("Factory Floor")]
	public void SaveLevel()
	{
		SROptionsReferences.Instance.LoadFactoryFloor.SaveLevel();
	}

	[Category("Factory Floor")]
	public void LoadLevel()
	{
		SROptionsReferences.Instance.LoadFactoryFloor.LoadLevel();
	}

	[Category("Factory Floor")]
	public void ClearLevel()
	{
		SaveSystem.DeleteDirectory(SaveSystem.CreateFullLevelsSavePath("Level"));
		SROptionsReferences.Instance.FactoryClearer.ClearLevel();
		LoadLevel();
	}

	[Category("Factory Floor")]
	public void FillAllBuildings()
	{
		SROptionsReferences.Instance.UpgradeAllBuildingsEvent.Fire();
	}

	[Category("Factory Floor")]
	public void ValidateFactoryObjectViews()
	{
		SROptionsReferences.Instance.FactoryValidateViews.DoValidate();
	}

	[Category("UI Settings")]
	public void ShowBasicNotification()
	{
		InGameNotificationDto inGameNotificationDto = new InGameNotificationDto("Example Notification", null, delegate
		{
		}, InGameNotificationType.Basic, "click me");
		SROptionsReferences.Instance.InGameNotificationUI.ShowNotification(inGameNotificationDto);
	}

	[Category("UI Settings")]
	public void ShowGNNGateProgressNotification()
	{
		InGameNotificationDto inGameNotificationDto = new InGameNotificationDto(InGameNotificationType.GnnGateProgress);
		SROptionsReferences.Instance.InGameNotificationUI.ShowNotification(inGameNotificationDto);
	}

	[Category("UI Settings")]
	public void ShowMonumentNotification()
	{
		InGameNotificationDto inGameNotificationDto = new InGameNotificationDto("Grey Nexus completed !", SROptionsReferences.Instance.GreyMonumentImage, delegate
		{
		}, InGameNotificationType.Monument, "InGameNotification.ButtonActivate");
		SROptionsReferences.Instance.InGameNotificationUI.ShowNotification(inGameNotificationDto);
	}

	[Category("UI Settings")]
	public void ShowChargeNotificationPopup()
	{
		SROptionsReferences.Instance.NotificationEvent.Fire(new GenericNotificationData(SROptionsReferences.Instance.ChargeNotificationSprite, "MonumentPanel.YellowChargeAvailablePopUp"));
	}

	[Category("Tech Tree")]
	public void UnlockNextNode()
	{
		SROptionsReferences.Instance.TechTreeManager.DebugUnlockNextNode();
	}

	[Category("Tech Tree")]
	public void UnlockAllNodes()
	{
		SROptionsReferences.Instance.TechTreeManager.DebugUnlockAllNodes();
	}

	[Category("Tech Tree")]
	public void RefreshTechTree()
	{
		SROptionsReferences.Instance.TechTreeManager.RefreshTree();
	}

	[Category("Objectives")]
	public void SkipIntro()
	{
		SROptionsReferences.Instance.IntroManagerLocator.IntroManager.DebugSkipIntro();
	}

	[Category("Objectives")]
	public void ResetClaimedObjectives()
	{
		SROptionsReferences.Instance.ObjectivesPersistentSO.ResetToDefaults();
	}

	[Category("Player Settings")]
	public void SetLowGFXQuality()
	{
		QualitySettings.SetQualityLevel(2, applyExpensiveChanges: true);
		Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasing = AntialiasingMode.FastApproximateAntialiasing;
	}

	[Category("Player Settings")]
	public void SetMediumGFXQuality()
	{
		QualitySettings.SetQualityLevel(1, applyExpensiveChanges: true);
		UniversalAdditionalCameraData component = Camera.main.GetComponent<UniversalAdditionalCameraData>();
		component.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
		component.antialiasingQuality = AntialiasingQuality.Medium;
	}

	[Category("Player Settings")]
	public void SetHighGFXQuality()
	{
		QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
		UniversalAdditionalCameraData component = Camera.main.GetComponent<UniversalAdditionalCameraData>();
		component.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
		component.antialiasingQuality = AntialiasingQuality.High;
	}

	[Category("Analytics")]
	public void SendBalanceDataForCubesProduced()
	{
		Debug.Log("*** SendBalanceDataForCubesProduced " + _balanceInterval + " / " + _balanceValue);
		if (_balanceInterval % 15 != 0)
		{
			Debug.LogError("The interval should be a multiple of 15");
			return;
		}
		if (_balanceValue == 0)
		{
			Debug.LogError("The value should be more than 0");
			return;
		}
		List<(string, float)> list = new List<(string, float)>();
		list.Add(($"Balance:{_balanceInterval}:Produced:{BehaviourStatisticType.CubesProduced}", _balanceValue));
		SROptionsReferences.Instance.AnalyticsQueueEvent.Fire(list);
	}

	[Category("Rank")]
	public void Add100XP()
	{
		SROptionsReferences.Instance.AddXPEvent.Fire(100, XPEarnedSource.Cheat);
	}

	[Category("Rank")]
	public void AddSomeXP()
	{
		SROptionsReferences.Instance.AddXPEvent.Fire(XPToAdd, XPEarnedSource.Cheat);
	}

	[Category("Rank")]
	public void ResetXP()
	{
		SROptionsReferences.Instance.RankConfig.ResetXP();
	}

	[Category("Data Shards")]
	public void Add100DataShards()
	{
		ResourceDataSO greyDataShardResource = SROptionsReferences.Instance.GreyDataShardResource;
		ResourceDataSO blueDataShardResource = SROptionsReferences.Instance.BlueDataShardResource;
		ResourceDataSO yellowDataShardResource = SROptionsReferences.Instance.YellowDataShardResource;
		ResourceDataSO redDataShardResource = SROptionsReferences.Instance.RedDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(new List<ResourceDataSO> { greyDataShardResource, blueDataShardResource, yellowDataShardResource, redDataShardResource }, 100);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(greyDataShardResource.ID, 100u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(blueDataShardResource.ID, 100u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(yellowDataShardResource.ID, 100u);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(redDataShardResource.ID, 100u);
	}

	[Category("Data Shards")]
	public void AddGreyDataShards()
	{
		ResourceDataSO greyDataShardResource = SROptionsReferences.Instance.GreyDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(greyDataShardResource, DataShardsToAdd);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(greyDataShardResource.ID, (uint)DataShardsToAdd);
	}

	[Category("Data Shards")]
	public void AddBlueDataShards()
	{
		ResourceDataSO blueDataShardResource = SROptionsReferences.Instance.BlueDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(blueDataShardResource, DataShardsToAdd);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(blueDataShardResource.ID, (uint)DataShardsToAdd);
	}

	[Category("Data Shards")]
	public void AddYellowDataShards()
	{
		ResourceDataSO yellowDataShardResource = SROptionsReferences.Instance.YellowDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(yellowDataShardResource, DataShardsToAdd);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(yellowDataShardResource.ID, (uint)DataShardsToAdd);
	}

	[Category("Data Shards")]
	public void AddRedDataShards()
	{
		ResourceDataSO redDataShardResource = SROptionsReferences.Instance.RedDataShardResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.AddResources(redDataShardResource, DataShardsToAdd);
		SROptionsReferences.Instance.StatisticsSO.AddDeliveredStatistic(redDataShardResource.ID, (uint)DataShardsToAdd);
	}

	[Category("Expansion Permits")]
	public void AddExpansionPermits()
	{
		AddCurrencyEventDto data = new AddCurrencyEventDto(SROptionsReferences.Instance.ExpansionPermitResource, ExpansionPermitsToAdd);
		SROptionsReferences.Instance.AddCurrencyEvent.Fire(data);
	}

	[Category("Expansion Permits")]
	public void RemoveExpansionPermits()
	{
		NonShapeResourceDataSO expansionPermitResource = SROptionsReferences.Instance.ExpansionPermitResource;
		SROptionsReferences.Instance.CurrencyPersistentSO.RemoveResources(expansionPermitResource, ExpansionPermitsToRemove);
	}

	[Category("Day Night Cycle")]
	public void SetCycleActive()
	{
		SROptionsReferences.Instance.DayNightCycleStateSO.SetValue(0);
	}

	[Category("Day Night Cycle")]
	public void SetFixedDay()
	{
		SROptionsReferences.Instance.DayNightCycleStateSO.SetValue(1);
	}

	[Category("Day Night Cycle")]
	public void SetFixedSunset()
	{
		SROptionsReferences.Instance.DayNightCycleStateSO.SetValue(2);
	}

	[Category("Day Night Cycle")]
	public void SetFixedNight()
	{
		SROptionsReferences.Instance.DayNightCycleStateSO.SetValue(3);
	}

	[Category("Day Night Cycle")]
	public void SetFixedSunrise()
	{
		SROptionsReferences.Instance.DayNightCycleStateSO.SetValue(4);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void OnStartup()
	{
		_current = new SROptions();
		SRServiceManager.GetService<InternalOptionsRegistry>().AddOptionContainer(Current);
	}

	public void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, propertyName);
		}
		if (this.InterfacePropertyChangedEventHandler != null)
		{
			this.InterfacePropertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

using System;
using System.Collections.Generic;
using FullInspector;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SkipStateManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class SkipState
		{
			public class LevelData
			{
				public int StarRating;

				public SharedInstance<LevelConfig> Level;
			}

			public string Name;

			public int Silver;

			public SharedInstance<LevelConfig> CurrentLevel;

			public LevelData[] UnlockedLevels;

			public SharedInstance<RoomDefinition>[] UnlockedRooms;

			public SharedInstance<RoomItemDefinition>[] UnlockedItems;

			public SharedInstance<RoomItemUpgradeDefinition>[] UnlockedUpgrades;

			public SharedInstance<ResearchProjectDefinition>[] UnlockedResearch;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public List<SharedInstance<SkipState>> SkipStates = new List<SharedInstance<SkipState>>();

			public GameObject DebugMenu;

			public GameObject DebugMenuButton;
		}

		private readonly Config _config;

		private readonly App _app;

		private readonly Metagame _metagame;

		private SkipState _skipStateLoading;

		public SkipStateManager(Config config, App app, Metagame metagame)
		{
			_app = app;
			_config = config;
			_metagame = metagame;
			ConsoleCommandsDatabase.RegisterCommand("LoadSkipState", "Loads a skip state", "LoadSkipState <name>", CommandLoad);
			ConsoleCommandsDatabase.RegisterCommand("SaveSkipState", "Saves a skip state", "SaveSkipState <name>", CommandSave);
			foreach (SharedInstance<SkipState> skipState in _config.SkipStates)
			{
				RegisterLoadCommand(skipState);
			}
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("LoadSkipState");
			base.Destroy();
		}

		private ConsoleCommandResult CommandSave(string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("Missing name parameter");
			}
			string text = args[0];
			for (int i = 1; i < args.Length; i++)
			{
				text = text + " " + args[i];
			}
			foreach (SharedInstance<SkipState> skipState in _config.SkipStates)
			{
				if (skipState.Instance != null && skipState.Instance.Name == text)
				{
					Save(skipState.Instance);
					return ConsoleCommandResult.Succeeded();
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void RegisterLoadCommand(SharedInstance<SkipState> skipState)
		{
			if (skipState.Instance != null)
			{
				string text = $"LoadSkipState {skipState.Instance.Name}";
				ConsoleCommandsDatabase.RegisterCommand(text, "Loads a skip state", text, CommandLoad);
			}
		}

		private ConsoleCommandResult CommandLoad(string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("Missing name parameter");
			}
			string text = args[0];
			for (int i = 1; i < args.Length; i++)
			{
				text = text + " " + args[i];
			}
			foreach (SharedInstance<SkipState> skipState in _config.SkipStates)
			{
				if (skipState.Instance != null && skipState.Instance.Name == text)
				{
					Load(skipState.Instance);
					return ConsoleCommandResult.Succeeded();
				}
			}
			return ConsoleCommandResult.Failed($"Skip state {text} does not exists");
		}

		private SharedInstance_TH20TH20_SkipStateManager_SkipState CreateNewSkipState(string name)
		{
			return null;
		}

		private void Load(SkipState skipState)
		{
			if (skipState.CurrentLevel == null)
			{
				DoLoad(skipState, null);
				return;
			}
			MetagameMap metagameMap = _app.MetagameMap;
			_skipStateLoading = skipState;
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			if (metagameMap.IsVisible)
			{
				metagameMap.Close(skipState.CurrentLevel.Instance, ignoreSave: true);
			}
			else
			{
				_app.LoadLevel(skipState.CurrentLevel.Instance, null, ignoreSave: true);
			}
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			DoLoad(_skipStateLoading, level);
			_skipStateLoading = null;
		}

		private void DoLoad(SkipState skipState, Level level)
		{
			_metagame.Reset();
			if (skipState.CurrentLevel != null)
			{
				MetagameMap metagameMap = _app.MetagameMap;
				LevelConfig instance = skipState.CurrentLevel.Instance;
				_metagame.MakeHospitalPlayable(instance);
				MapPinHospital pinForLevel = metagameMap.MapUI.GetPinForLevel(instance);
				if (pinForLevel != null)
				{
					metagameMap.CameraLogic.TrackObject(pinForLevel.transform);
				}
				level?.WorldState.SetupAvailableItems(_metagame);
			}
			_metagame.AwardSilver(skipState.Silver);
			if (skipState.UnlockedLevels != null)
			{
				SkipState.LevelData[] unlockedLevels = skipState.UnlockedLevels;
				foreach (SkipState.LevelData levelData in unlockedLevels)
				{
					if (levelData != null)
					{
						for (int j = 0; j < levelData.StarRating; j++)
						{
							_metagame.AwardStar((MetagameHospitalRecord.StarIndex)j, levelData.Level.Instance, debug: true);
						}
						_metagame.MakeHospitalPlayable(levelData.Level.Instance);
					}
				}
			}
			if (skipState.UnlockedRooms != null)
			{
				SharedInstance<RoomDefinition>[] unlockedRooms = skipState.UnlockedRooms;
				foreach (SharedInstance<RoomDefinition> sharedInstance in unlockedRooms)
				{
					if (sharedInstance != null)
					{
						_metagame.AwardSilver(sharedInstance.Instance.SilverCost());
						_metagame.UnlockItem(sharedInstance.Instance, spendSilver: false, showMessage: false);
					}
				}
			}
			if (skipState.UnlockedItems != null)
			{
				SharedInstance<RoomItemDefinition>[] unlockedItems = skipState.UnlockedItems;
				foreach (SharedInstance<RoomItemDefinition> sharedInstance2 in unlockedItems)
				{
					if (sharedInstance2 != null)
					{
						_metagame.AwardSilver(sharedInstance2.Instance.SilverCost());
						_metagame.UnlockItem(sharedInstance2.Instance, spendSilver: false, showMessage: false);
					}
				}
			}
			if (skipState.UnlockedUpgrades != null)
			{
				SharedInstance<RoomItemUpgradeDefinition>[] unlockedUpgrades = skipState.UnlockedUpgrades;
				foreach (SharedInstance<RoomItemUpgradeDefinition> sharedInstance3 in unlockedUpgrades)
				{
					if (sharedInstance3 != null)
					{
						_metagame.AwardSilver(sharedInstance3.Instance.SilverCost());
						_metagame.UnlockItem(sharedInstance3.Instance, spendSilver: false, showMessage: false);
					}
				}
			}
			if (skipState.UnlockedResearch == null)
			{
				return;
			}
			SharedInstance<ResearchProjectDefinition>[] unlockedResearch = skipState.UnlockedResearch;
			foreach (SharedInstance<ResearchProjectDefinition> sharedInstance4 in unlockedResearch)
			{
				if (sharedInstance4 != null)
				{
					RewardUtils.GiveAllRewards(null, sharedInstance4.Instance.Rewards, _metagame);
				}
			}
		}

		private void Save(SkipState skipState)
		{
			Level currentLevel = _metagame.CurrentLevel;
			List<SkipState.LevelData> list = new List<SkipState.LevelData>();
			List<SharedInstance<RoomDefinition>> list2 = new List<SharedInstance<RoomDefinition>>();
			List<SharedInstance<RoomItemDefinition>> list3 = new List<SharedInstance<RoomItemDefinition>>();
			List<SharedInstance<RoomItemUpgradeDefinition>> list4 = new List<SharedInstance<RoomItemUpgradeDefinition>>();
			List<SharedInstance<ResearchProjectDefinition>> list5 = new List<SharedInstance<ResearchProjectDefinition>>();
			if (currentLevel != null)
			{
				skipState.CurrentLevel = SharedInstanceUtils.GetSharedInstance(currentLevel.Config);
				foreach (ResearchProjectDefinition completedResearchProject in _metagame.CompletedResearchProjects)
				{
					list5.Add(SharedInstanceUtils.GetSharedInstance(completedResearchProject));
				}
			}
			skipState.Silver = _metagame.TotalSilver();
			foreach (LevelConfig visibleLevel in _metagame.VisibleLevels)
			{
				MetagameHospitalRecord hospitalRecord = _metagame.GetHospitalRecord(visibleLevel);
				list.Add(new SkipState.LevelData
				{
					Level = SharedInstanceUtils.GetSharedInstance(visibleLevel),
					StarRating = (hospitalRecord?.TotalStars() ?? 0)
				});
			}
			foreach (ISilverUnlockToken silverUnlockable in _metagame.SilverUnlockables)
			{
				if (silverUnlockable is RoomDefinition)
				{
					list2.Add(SharedInstanceUtils.GetSharedInstance(silverUnlockable as RoomDefinition));
				}
				else if (silverUnlockable is RoomItemDefinition)
				{
					RoomItemDefinition roomItemDefinition = (RoomItemDefinition)silverUnlockable;
					if (!roomItemDefinition.InitiallyAvailable || roomItemDefinition.SilverCost() != 0)
					{
						list3.Add(SharedInstanceUtils.GetSharedInstance(roomItemDefinition));
					}
				}
				else if (silverUnlockable is RoomItemUpgradeDefinition)
				{
					list4.Add(SharedInstanceUtils.GetSharedInstance(silverUnlockable as RoomItemUpgradeDefinition));
				}
			}
			skipState.UnlockedLevels = list.ToArray();
			skipState.UnlockedRooms = list2.ToArray();
			skipState.UnlockedItems = list3.ToArray();
			skipState.UnlockedUpgrades = list4.ToArray();
			skipState.UnlockedResearch = list5.ToArray();
		}

		public void ShowDebugMenu(Transform root, Action closeFunc)
		{
			Transform parent = UnityEngine.Object.Instantiate(_config.DebugMenu, root).transform.FindChildRecursively("Content");
			for (int i = 0; i < _config.SkipStates.Count; i++)
			{
				SharedInstance<SkipState> skipState = _config.SkipStates[i];
				GameObject gameObject = UnityEngine.Object.Instantiate(_config.DebugMenuButton, parent);
				TMP_Text componentInChildren = gameObject.GetComponentInChildren<TMP_Text>();
				Button componentInChildren2 = gameObject.GetComponentInChildren<Button>();
				string name = skipState.Instance.Name;
				componentInChildren.text = name;
				componentInChildren2.onClick.AddListener(delegate
				{
					closeFunc.InvokeSafe();
					Load(skipState.Instance);
				});
			}
		}
	}
}

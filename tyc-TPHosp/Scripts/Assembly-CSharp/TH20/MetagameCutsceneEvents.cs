using System.Collections.Generic;
using FullInspector;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardStar;
using UnityConsole;

namespace TH20
{
	public class MetagameCutsceneEvents : MustCallDestroy, TH20.EventAwardStar.Interface, IGameEventCallback, TH20.EventAwardRemixBadge.Interface
	{
		private readonly List<MetagameCutsceneInstance> _cutsceneList = new List<MetagameCutsceneInstance>();

		private List<MetagamePostCutsceneEventDefinition> _postCutsceneList = new List<MetagamePostCutsceneEventDefinition>();

		[DontSave]
		private MetagameMap _metagameMap;

		[DontSave]
		private Metagame _metagame;

		[DontSave]
		private MetagameCutsceneConfig _config;

		public bool IsCutscenePending => _cutsceneList.Count > 0;

		public MetagameCutsceneEvents(Metagame metagame)
		{
			ConsoleCommandsDatabase.RegisterCommand("AddTestCutsceneEvent", "Adds a cutscene event to the queue. Run ProcessCutsceneEvent to execute the cutscene", "AddTestCutsceneEvent", Debug_AddTestCutsceneEvent);
			ConsoleCommandsDatabase.RegisterCommand("AddUnlockCutsceneEvent", "Adds a cutscene event to the queue. Run ProcessCutsceneEvent to execute the cutscene", "AddUnlockCutsceneEvent 901", Debug_UnlockTestCutsceneEvent);
			_metagame = metagame;
			_metagame.OnStarAwarded.AddAndDontSave(this);
			_metagame.OnRemixBadgeAwarded.AddAndDontSave(this);
			if (!DebugVars.EnableHandsOnDemo.Value)
			{
				SubmitCutsceneEvent(_metagame.MetagameConfig.CutsceneConfig.Instance.GameIntro);
			}
		}

		public void RestoreFromSave(Metagame metagame)
		{
			ConsoleCommandsDatabase.RegisterCommand("AddTestCutsceneEvent", "Adds a cutscene event to the queue. Run ProcessCutsceneEvent to execute the cutscene", "AddTestCutsceneEvent", Debug_AddTestCutsceneEvent);
			ConsoleCommandsDatabase.RegisterCommand("AddUnlockCutsceneEvent", "Adds a cutscene event to the queue. Run ProcessCutsceneEvent to execute the cutscene", "AddUnlockCutsceneEvent 901", Debug_UnlockTestCutsceneEvent);
			_metagame = metagame;
			_metagame.OnStarAwarded.AddAndDontSave(this);
			_metagame.OnRemixBadgeAwarded.AddAndDontSave(this);
			if (_postCutsceneList == null)
			{
				_postCutsceneList = new List<MetagamePostCutsceneEventDefinition>();
			}
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("AddTestCutsceneEvent");
			ConsoleCommandsDatabase.UnRegisterCommand("AddUnlockCutsceneEvent");
			_metagame.OnStarAwarded.Remove(this);
			_metagame.OnRemixBadgeAwarded.Remove(this);
			base.Destroy();
		}

		public void Initialise(MetagameMap metagameMap)
		{
			_metagameMap = metagameMap;
			_config = _metagameMap.Metagame.MetagameConfig.CutsceneConfig.Instance;
			SubmitUnseenLevelUnlockEvents();
			foreach (MetagameCutsceneInstance cutscene in _cutsceneList)
			{
				cutscene.RestoreFromSave(metagameMap);
			}
		}

		public void SubmitCutsceneEvent(MetagameCutsceneDefinition definition)
		{
			if (definition != null)
			{
				_cutsceneList.Add(definition.CreateCutsceneInstance(_metagameMap));
			}
		}

		public void SubmitPostCutsceneEvent(MetagamePostCutsceneEventDefinition definition)
		{
			if (definition != null)
			{
				_postCutsceneList.Add(definition);
			}
		}

		public void FlushCutsceneEvents(ref List<MetagameCutsceneInstance> cutsceneList)
		{
			cutsceneList.AddRange(_cutsceneList);
			_cutsceneList.Clear();
		}

		public void FlushPostCutsceneEvents(ref List<MetagamePostCutsceneEventDefinition> postCutsceneList)
		{
			postCutsceneList.AddRange(_postCutsceneList);
			_postCutsceneList.Clear();
		}

		private ConsoleCommandResult Debug_AddTestCutsceneEvent(string[] args)
		{
			SubmitCutsceneEvent(new MetagameCutsceneTestDefinition());
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UnlockTestCutsceneEvent(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Need a LevelId argument: AddUnlockCutsceneEvent 901");
			}
			if (_metagameMap.Metagame.MetagameConfig._levelList.Instance.GetLevelConfigByID(args[0]) == null)
			{
				return ConsoleCommandResult.Failed("No level config found!");
			}
			int key = int.Parse(args[0]);
			if (!_config.HospitalUnlockedCutscenes.TryGetValue(key, out var value))
			{
				return ConsoleCommandResult.Failed("No cutscene event found for this level!");
			}
			SubmitCutsceneEvent(value);
			return ConsoleCommandResult.Succeeded();
		}

		public void CheckForPendingCutsceneEvents()
		{
			if (!_metagame.App.UserProfile.HasSeenSandboxCutscene && _metagame.IsSandboxUnlocked())
			{
				_metagame.CutsceneEvents.SubmitCutsceneEvent(_config.SandboxUnlockCutscene);
				_metagame.App.UserProfile.IsSandboxUnlocked = true;
			}
			if (!_metagame.App.UserProfile.HasSeenCollaborativeProjectCutscene && _metagame.IsCollaborativePortfolioUnlocked() && PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.Superbug))
			{
				_metagame.CutsceneEvents.SubmitCutsceneEvent(_config.CollaborativePortfolioUnlockCutscene);
				_metagame.App.UserProfile.IsCollaborativeProjectsUnlocked = true;
			}
		}

		public void CheckForPendingPostCutsceneEvents()
		{
			if (!_metagame.HasSeenBigfootCompleteEvent && _metagame.IsBigfootDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.BigfootCompletePostCutsceneEvent.Instance);
				_metagame.HasSeenBigfootCompleteEvent = true;
			}
			if (!_metagame.HasSeenJungleCompleteEvent && _metagame.IsJungleDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.JungleCompletePostCutsceneEvent.Instance);
				_metagame.HasSeenJungleCompleteEvent = true;
			}
			if (!_metagame.HasSeenCloseEncountersCompleteEvent && _metagame.IsCloseEncountersDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.CloseEncountersCompletePostCutsceneEvent.Instance);
				_metagame.HasSeenCloseEncountersCompleteEvent = true;
			}
			if (!_metagame.HasSeenRemixRegion1UnlockEvent && _metagame.IsRemixRegion1Unlocked())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.RemixRegion1PostCutsceneEvent.Instance);
				_metagame.HasSeenRemixRegion1UnlockEvent = true;
			}
			if (!_metagame.HasSeenOffTheGridCompleteEvent && _metagame.IsOffTheGridDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.OffTheGridPostCutsceneEvent.Instance);
				_metagame.HasSeenOffTheGridCompleteEvent = true;
			}
			if (!_metagame.HasSeenCultureShockCompleteEvent && _metagame.IsCultureShockDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.CultureShockPostCutsceneEvent.Instance);
				_metagame.HasSeenCultureShockCompleteEvent = true;
			}
			if (!_metagame.HasSeenTimeTravelCompleteEvent && _metagame.IsTimeTravelDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.TimeTravelPostCutsceneEvent.Instance);
				_metagame.HasSeenTimeTravelCompleteEvent = true;
			}
			if (!_metagame.HasSeenEmergencyPostCutsceneEvent && _metagame.IsSpeedyRecoveryDLCCompleted())
			{
				_metagame.CutsceneEvents.SubmitPostCutsceneEvent(_config.EmergencyPostCutsceneEvent.Instance);
				_metagame.HasSeenEmergencyPostCutsceneEvent = true;
			}
		}

		public void SubmitCutsceneEventForLevel(LevelConfig levelConfig)
		{
			if (levelConfig != null)
			{
				int key = int.Parse(levelConfig.UniqueId);
				if (_config.HospitalUnlockedCutscenes.TryGetValue(key, out var value) && (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.DLCPurchase) || !value.DLCPackRequired.NotNull()) && (value.DLCPackRequired.IsNull() || DLCUtils.IsDLCInstalled(value.DLCPackRequired.Instance)))
				{
					_metagame.CutsceneEvents.SubmitCutsceneEvent(value);
					_metagame.SeenCutscene(levelConfig);
				}
			}
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			if (!debug)
			{
				SubmitUnseenLevelUnlockEvents();
			}
		}

		public void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			if (!debug)
			{
				SubmitUnseenLevelUnlockEvents();
			}
		}

		private void SubmitUnseenLevelUnlockEvents()
		{
			foreach (SharedInstance<LevelConfig> level in _metagame.MetagameConfig._levelList.Instance.Levels)
			{
				if (level.Instance.IsPlayable(_metagame) && !_metagame.HasSeenUnlockCutscene(level.Instance))
				{
					int key = int.Parse(level.Instance.UniqueId);
					if (_config.HospitalUnlockedCutscenes.TryGetValue(key, out var value) && (value.DLCPackRequired.IsNull() || DLCUtils.IsDLCInstalled(value.DLCPackRequired.Instance)))
					{
						_metagame.CutsceneEvents.SubmitCutsceneEvent(value);
						_metagame.SeenCutscene(level.Instance);
					}
				}
			}
		}
	}
}

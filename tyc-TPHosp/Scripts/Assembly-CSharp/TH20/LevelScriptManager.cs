using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class LevelScriptManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public ExternalBehavior LevelObjectiveScript;

			public List<SharedInstance<ObjectiveDefinition>> OnlineChallenges;
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly ObjectiveEvents _objectiveEvents;

		private readonly StaffChallengeManager _staffChallengeManager;

		public readonly List<LevelObjective> ActiveObjectives = new List<LevelObjective>();

		public readonly List<StaffChallenge> StaffChallenges = new List<StaffChallenge>();

		public readonly List<OnlineChallengeObjective> OnlineChallenges = new List<OnlineChallengeObjective>();

		private readonly List<int> _expiredTasks = new List<int>();

		private readonly Dictionary<string, bool> _expiredObjectives = new Dictionary<string, bool>();

		[DontSave]
		private GameObject _gameObject;

		[DontSave]
		private LevelScriptBehaviorTree _behaviorTree;

		public OnlineChallengeObjective ActiveOnlineChallenge { get; private set; }

		public LevelScriptManager(Config config, Level level, StaffChallengeManager.Config staffChallengeConfig)
		{
			_config = config;
			_level = level;
			_objectiveEvents = _level.ObjectiveEvents;
			_staffChallengeManager = new StaffChallengeManager(level, staffChallengeConfig);
			if (_config.OnlineChallenges != null && PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				foreach (SharedInstance<ObjectiveDefinition> onlineChallenge in _config.OnlineChallenges)
				{
					OnlineChallengeDefinition definition = onlineChallenge.Instance as OnlineChallengeDefinition;
					CreateOnlineChallenge(onlineChallenge.name, definition);
				}
			}
			Initialise();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_staffChallengeManager.RestoreFromSave();
			foreach (LevelObjective activeObjective in ActiveObjectives)
			{
				activeObjective.RestoreFromSave();
			}
			foreach (StaffChallenge staffChallenge in StaffChallenges)
			{
				staffChallenge.RestoreFromSave();
			}
			foreach (OnlineChallengeObjective onlineChallenge in OnlineChallenges)
			{
				onlineChallenge.RestoreFromSave();
			}
			Initialise();
		}

		private void Initialise()
		{
			_gameObject = new GameObject("LevelScriptManager");
			if (_config.LevelObjectiveScript != null)
			{
				StartLevelScript();
			}
			ConsoleCommandsDatabase.RegisterCommand("CompleteAllLevelObjectives", "CompleteAllLevelObjectives", "CompleteAllLevelObjectives", Debug_CompleteAllLevelObjectives);
			ConsoleCommandsDatabase.RegisterCommand("CompleteOneLevelObjective", "CompleteOneLevelObjective", "CompleteOneLevelObjective", Debug_CompleteOneLevelObjective);
			ConsoleCommandsDatabase.RegisterCommand("CompleteCollaborativeObjective", "CompleteCollaborativeObjective", "CompleteCollaborativeObjective", Debug_CompleteCollaborativeObjective);
			ConsoleCommandsDatabase.RegisterCommand("FailCollaborativeObjective", "FailCollaborativeObjective", "FailCollaborativeObjective", Debug_FailedCollaborativeObjective);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("CompleteAllLevelObjectives");
			ConsoleCommandsDatabase.UnRegisterCommand("CompleteOneLevelObjective");
			ConsoleCommandsDatabase.UnRegisterCommand("CompleteCollaborativeObjective");
			ConsoleCommandsDatabase.UnRegisterCommand("FailCollaborativeObjective");
			for (int num = ActiveObjectives.Count - 1; num >= 0; num--)
			{
				ActiveObjectives[num].Destroy();
			}
			for (int num2 = StaffChallenges.Count - 1; num2 >= 0; num2--)
			{
				StaffChallenges[num2].Destroy();
			}
			for (int num3 = OnlineChallenges.Count - 1; num3 >= 0; num3--)
			{
				OnlineChallenges[num3].Destroy();
			}
			_staffChallengeManager.Destroy();
			Object.Destroy(_gameObject);
			base.Destroy();
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			BehaviorManager.instance.Tick(_behaviorTree);
			for (int i = 0; i < ActiveObjectives.Count; i++)
			{
				ActiveObjectives[i].Update(timeDelta, unscaledTimeDelta);
			}
			_staffChallengeManager.Update();
			for (int j = 0; j < StaffChallenges.Count; j++)
			{
				StaffChallenges[j].Update(timeDelta, unscaledTimeDelta);
			}
			for (int k = 0; k < OnlineChallenges.Count; k++)
			{
				OnlineChallenges[k].Update(timeDelta, unscaledTimeDelta);
			}
		}

		private void StartLevelScript()
		{
			_behaviorTree = _gameObject.AddComponent<LevelScriptBehaviorTree>();
			_behaviorTree.Level = _level;
			_behaviorTree.Manager = this;
			_behaviorTree.BehaviorName = "LevelScript";
			_behaviorTree.StartWhenEnabled = true;
			_behaviorTree.ExternalBehavior = _config.LevelObjectiveScript;
		}

		public void SetActiveOnlineChallenge(OnlineChallengeObjective levelObjective)
		{
			if (levelObjective == null)
			{
				if (ActiveOnlineChallenge != null && ActiveOnlineChallenge.State != Objective.ObjectiveState.Unstarted)
				{
					ActiveOnlineChallenge.Reset();
				}
				ActiveOnlineChallenge = null;
			}
			else
			{
				ActiveOnlineChallenge = levelObjective;
			}
			_objectiveEvents.OnActiveOnlineChallengeChanged.InvokeSafe();
		}

		public void AddExpiredTask(int taskID)
		{
			_expiredTasks.AddUnique(taskID);
		}

		public bool HasTaskExpired(int taskID)
		{
			return _expiredTasks.Contains(taskID);
		}

		public bool HasObjectiveExpired(string uniqueReference, out bool success)
		{
			return _expiredObjectives.TryGetValue(uniqueReference, out success);
		}

		public int GetNumDiscoveredOnlineChallenges()
		{
			int num = 0;
			for (int i = 0; i < OnlineChallenges.Count; i++)
			{
				if (OnlineChallenges[i].State != Objective.ObjectiveState.Undiscovered)
				{
					num++;
				}
			}
			return num;
		}

		public void CreateObjective(string uniqueReference, ObjectiveDefinition definition, bool isVisible, bool isDiscovered, bool isReplayable, bool startImmediately, bool canDismiss = false)
		{
			foreach (LevelObjective activeObjective in ActiveObjectives)
			{
				if (activeObjective.UniqueReference == uniqueReference)
				{
					return;
				}
			}
			LevelObjective levelObjective = new LevelObjective(_level, uniqueReference, definition, isVisible, isDiscovered, isReplayable, startImmediately, canDismiss);
			AddObjective(levelObjective);
		}

		public void CreateOnlineChallenge(string uniqueReference, OnlineChallengeDefinition definition)
		{
			OnlineChallengeObjective levelObjective = new OnlineChallengeObjective(_level, uniqueReference, definition);
			AddObjective(levelObjective);
		}

		public void AddObjective(LevelObjective levelObjective)
		{
			levelObjective.Initialise();
			if (levelObjective is OnlineChallengeObjective item)
			{
				OnlineChallenges.Add(item);
			}
			else if (levelObjective is StaffChallenge item2)
			{
				StaffChallenges.Add(item2);
			}
			else
			{
				ActiveObjectives.Add(levelObjective);
			}
		}

		public void DestroyObjective(Objective objective)
		{
			if (objective is OnlineChallengeObjective)
			{
				if (objective.CompletionResult != Objective.CompletionType.Successful)
				{
					SetActiveOnlineChallenge(null);
				}
			}
			else if (objective is ResearchProjectObjective)
			{
				objective.Destroy();
			}
			else if (objective is StaffChallenge)
			{
				StaffChallenge staffChallenge = (StaffChallenge)objective;
				StaffChallenges.Remove(staffChallenge);
				staffChallenge.Destroy();
			}
			else if (objective is LevelObjective)
			{
				DestroyLevelObjective((LevelObjective)objective);
			}
		}

		public void DestroyLevelObjective(LevelObjective levelObjective, bool bRemoveFromExpiredObjectivesList = false)
		{
			if (levelObjective == null)
			{
				return;
			}
			ActiveObjectives.Remove(levelObjective);
			if (!bRemoveFromExpiredObjectivesList)
			{
				if (levelObjective.ShouldAddToExpiredObjectivesList())
				{
					_expiredObjectives.Add(levelObjective.UniqueReference, levelObjective.CompletionResult == Objective.CompletionType.Successful);
				}
			}
			else
			{
				_expiredObjectives.Remove(levelObjective.UniqueReference);
			}
			levelObjective.Destroy();
		}

		private ConsoleCommandResult Debug_CompleteAllLevelObjectives(string[] args)
		{
			if (!_level.MetagameMap.IsTransitioning)
			{
				LevelObjective[] array = ActiveObjectives.ToArray();
				foreach (LevelObjective levelObjective in array)
				{
					if (levelObjective.IsVisible && levelObjective.State == Objective.ObjectiveState.Active)
					{
						levelObjective.ForceSuccess();
					}
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_CompleteOneLevelObjective(string[] args)
		{
			if (!_level.MetagameMap.IsTransitioning)
			{
				LevelObjective[] array = ActiveObjectives.ToArray();
				foreach (LevelObjective levelObjective in array)
				{
					if (levelObjective.IsVisible && levelObjective.State == Objective.ObjectiveState.Active)
					{
						levelObjective.ForceSuccess();
						break;
					}
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_CompleteCollaborativeObjective(string[] args)
		{
			if (!_level.MetagameMap.IsTransitioning && _level.Metagame.CollaborativePortfolio.PortfolioDataController != null)
			{
				CollaborativePortfolioData portfolioData = _level.Metagame.CollaborativePortfolio.PortfolioDataController.PortfolioData;
				if (portfolioData != null && portfolioData.ActiveObjective != null)
				{
					portfolioData.ActiveObjective.ForceSuccess();
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_FailedCollaborativeObjective(string[] args)
		{
			if (!_level.MetagameMap.IsTransitioning && _level.Metagame.CollaborativePortfolio.PortfolioDataController != null)
			{
				CollaborativePortfolioData portfolioData = _level.Metagame.CollaborativePortfolio.PortfolioDataController.PortfolioData;
				if (portfolioData != null && portfolioData.ActiveObjective != null && portfolioData.ActiveObjective != null)
				{
					if (portfolioData.ActiveObjective.Definition.IsTimed)
					{
						portfolioData.ActiveObjective.ForceFail();
						return ConsoleCommandResult.Succeeded();
					}
					return ConsoleCommandResult.Failed("Can only fail timed objectives");
				}
			}
			return ConsoleCommandResult.Failed("Failed to fail!");
		}

		public bool IsObjectiveActive(ObjectiveDefinition definition)
		{
			foreach (LevelObjective activeObjective in ActiveObjectives)
			{
				if (activeObjective.Definition == definition)
				{
					return true;
				}
			}
			return false;
		}

		public Objective GetActiveObjectiveByUniqueReference(string uniqueReference)
		{
			return ActiveObjectives.Find((LevelObjective item) => item.UniqueReference == uniqueReference);
		}

		public T GetObjective<T>() where T : Objective
		{
			foreach (LevelObjective activeObjective in ActiveObjectives)
			{
				if (activeObjective is T result)
				{
					return result;
				}
			}
			return null;
		}
	}
}

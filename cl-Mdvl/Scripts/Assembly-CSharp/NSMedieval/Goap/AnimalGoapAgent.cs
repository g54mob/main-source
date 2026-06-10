using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;

namespace NSMedieval.Goap
{
	public class AnimalGoapAgent : Agent, IFormCaravanGoapAgent
	{
		private const string RopedGoal = "RopedFollowGoal";

		private AnimalInstance animal;

		private ScheduleData currentScheduleData;

		private Goal exclusiveGoal;

		private CaravanInstance preparingForCaravan;

		public CaravanInstance PreparingForCaravan => preparingForCaravan;

		private HourType CurrentHourType { get; set; } = HourType.None;

		public AnimalGoapAgent(AnimalInstance animal)
			: base(animal)
		{
			this.animal = animal;
			RefreshWorkHour(forceRefresh: true);
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			this.animal.AnimalTypeChangedEvent += OnAnimalTypeChanged;
			this.animal.PetOwnerChangedEvent += OnPetOwnerChanged;
		}

		public override void Dispose()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			if (animal != null)
			{
				animal.AnimalTypeChangedEvent -= OnAnimalTypeChanged;
				animal.PetOwnerChangedEvent -= OnPetOwnerChanged;
			}
			animal = null;
			exclusiveGoal = null;
			preparingForCaravan = null;
			base.Dispose();
		}

		public AgentGoalInitializer GetGoalInitializer()
		{
			return base.GoalInitializer;
		}

		public void SetExclusiveGoal(string goalName)
		{
			if (base.GoalScheduler.GetFromPool(goalName) == null)
			{
				GoalPriorityData goalPriorityData = new GoalPriorityData((Goal)GoalsMap.Constuctors[goalName].Invoke(new object[1] { this }), 100f);
				if (!goalPriorityData.Goal.AgentTypeCheck())
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Invalid agent type for goal: ");
						messageBuilder.AppendFormatted(this);
					}
					Log.Error(messageBuilder);
					return;
				}
				base.GoalScheduler.AddToPool(goalPriorityData);
			}
			exclusiveGoal = base.GoalScheduler.GetFromPool(goalName);
			Abort();
		}

		public void ClearExclusiveGoal()
		{
			if (GetCurrentGoal() == exclusiveGoal)
			{
				Abort();
			}
			exclusiveGoal = null;
		}

		private void OnHourUpdate()
		{
			RefreshWorkHour(forceRefresh: false);
		}

		public override void StartTicker()
		{
			if (!base.IsTickActive)
			{
				base.StartTicker();
			}
		}

		public override AnimatedAgentView GetView()
		{
			return animal.GetAgentView<AnimatedAgentView>();
		}

		public void StartCaravanFormation(CaravanInstance caravan)
		{
			preparingForCaravan = caravan;
			if (animal.HasFainted)
			{
				ForceNextGoal("FaintGoal");
				return;
			}
			AnimalInstance animalInstance = (AnimalInstance)base.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(animalInstance))
			{
				return;
			}
			WalkableModel walkableModel = animalInstance.WalkableModel;
			if (animalInstance.PathTraversalProvider is TagTraversalProvider tagTraversalProvider)
			{
				if ((tagTraversalProvider.NotWalkableTags & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					animalInstance.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map_no_ladder"));
				}
				else
				{
					animalInstance.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map"));
				}
			}
			foreach (HumanoidInstance item in caravan.Workers.Shuffle())
			{
				if (CombatUtils.IsNullOrDisposed(item) && PathfinderUtil.IsPathPossible(animalInstance, item.GetNode()))
				{
					animalInstance.RopeTo(item);
					return;
				}
			}
			animalInstance.SetWalkableModel(walkableModel);
		}

		public void ClearCaravanFormingData()
		{
			preparingForCaravan = null;
			RefreshWorkHour(forceRefresh: false);
			Abort();
		}

		internal override void OnGoalEnded(Goal goal, GoalCondition condition)
		{
			animal?.DropStorage();
			base.OnGoalEnded(goal, condition);
			if (goal == exclusiveGoal)
			{
				exclusiveGoal = null;
			}
		}

		public void AttendPlayerTriggeredEvent(string goalId)
		{
			animal.RopeTo(null);
			SetExclusiveGoal(goalId);
		}

		public void LeavePlayerTriggeredEvent()
		{
			RefreshWorkHour(forceRefresh: false);
			Abort();
		}

		public override void Tick(float deltaTime)
		{
			if (base.AgentOwner == null || base.AgentOwner.HasDisposed || base.HasDisposed)
			{
				base.Tick(deltaTime);
				return;
			}
			if (base.IsGoalPreparing)
			{
				base.Tick(deltaTime);
				return;
			}
			if (animal.RopedTo() != null)
			{
				if (exclusiveGoal == null || !exclusiveGoal.Id.Equals("RopedFollowGoal"))
				{
					Abort();
					SetExclusiveGoal("RopedFollowGoal");
					return;
				}
			}
			else if (exclusiveGoal != null && exclusiveGoal.Id.Equals("RopedFollowGoal"))
			{
				ClearExclusiveGoal();
			}
			if (exclusiveGoal != null && exclusiveGoal.CanStart() && GetCurrentGoal() != exclusiveGoal)
			{
				if (GetCurrentGoal() != null)
				{
					Abort();
				}
				ForceNextGoal(exclusiveGoal);
			}
			base.Tick(deltaTime);
		}

		private void OnAnimalTypeChanged(AnimalInstance instance, AnimalType animalType)
		{
			if (instance == animal)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Animal (");
					messageBuilder.AppendFormatted(instance.Id);
					messageBuilder.AppendLiteral(") Type Changed to ");
					messageBuilder.AppendFormatted(animalType);
				}
				Log.Info(messageBuilder);
				RefreshWorkHour(forceRefresh: true);
			}
		}

		private void OnPetOwnerChanged(AnimalInstance animal, CreatureBase petOwner)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(32, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Pet owner of (");
				messageBuilder.AppendFormatted(animal.Id);
				messageBuilder.AppendLiteral(") Type Changed to ");
				messageBuilder.AppendFormatted(petOwner);
			}
			Log.Info(messageBuilder);
			RefreshWorkHour(forceRefresh: true);
		}

		private void RefreshWorkHour(bool forceRefresh)
		{
			if (animal.Blueprint == null || animal.ScheduleConfig == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Schedule not found for animal ");
					messageBuilder.AppendFormatted(animal.Id);
				}
				Log.Error(messageBuilder);
				return;
			}
			if (animal.PetOwner != null)
			{
				Agent goapAgent = animal.PetOwner.GetGoapAgent();
				if (goapAgent != null && goapAgent is WorkerGoapAgent workerGoapAgent)
				{
					ChangeCurrentHourType(workerGoapAgent.CurrentHourType, forceRefresh);
					return;
				}
			}
			int num = GlobalSaveController.CurrentVillageData.DateAndTime.HoursSinceDay % animal.ScheduleConfig.Config.Length;
			HourType newHourType = (HourType)animal.ScheduleConfig.Config[num];
			ChangeCurrentHourType(newHourType, forceRefresh);
		}

		private void ChangeCurrentHourType(HourType newHourType, bool forceRefresh)
		{
			if (forceRefresh || newHourType != CurrentHourType)
			{
				if (newHourType == HourType.PlayerTriggeredEvent || newHourType == HourType.RoleJob)
				{
					newHourType = HourType.Any;
				}
				CurrentHourType = newHourType;
				if (CurrentHourType == HourType.None)
				{
					Log.Error("Hour type is none!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
					return;
				}
				ClearWorkHourEffectors();
				currentScheduleData = GetCurrentWorkHourData();
				ApplyWorkHourEffectors();
				RefreshHourGoals();
				RefreshDisableThreshold();
			}
		}

		private void ClearWorkHourEffectors()
		{
			if (currentScheduleData.ActiveEffectors != null)
			{
				string[] activeEffectors = currentScheduleData.ActiveEffectors;
				foreach (string name in activeEffectors)
				{
					animal.Stats.EndEffector(name);
				}
			}
		}

		private void ApplyWorkHourEffectors()
		{
			if (currentScheduleData.ActiveEffectors != null)
			{
				string[] activeEffectors = currentScheduleData.ActiveEffectors;
				foreach (string effectorId in activeEffectors)
				{
					animal.Stats.StartEffector(effectorId);
				}
			}
		}

		private void RefreshDisableThreshold()
		{
			string settingsParameter = currentScheduleData.GetSettingsParameter(ScheduleDataSettingsType.GoalSettings, "DisableBelow", "Priority");
			if (!string.IsNullOrEmpty(settingsParameter) && float.TryParse(settingsParameter, out var result))
			{
				base.GoalExecutionManager.SetStartableGoalMaximumPriority(result);
			}
			else
			{
				base.GoalExecutionManager.SetStartableGoalMaximumPriority(float.MaxValue);
			}
		}

		private void RefreshHourGoals()
		{
			ScheduleData.GoalPriority[] goals = currentScheduleData.Goals;
			base.GoalScheduler.DisableAllGoals();
			for (int i = 0; i < goals.Length; i++)
			{
				string goal = goals[i].Goal;
				if (!base.GoalScheduler.ExistInPool(goal))
				{
					bool isEnabled;
					if (!GoalsMap.Constuctors.ContainsKey(goal))
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Goal '");
							messageBuilder.AppendFormatted(goal);
							messageBuilder.AppendLiteral("' exists in scheduled data but not found in code!");
						}
						Log.Warning(messageBuilder);
						continue;
					}
					GoalPriorityData goalPriorityData = new GoalPriorityData((Goal)GoalsMap.Constuctors[goal].Invoke(new object[1] { this }), goals[i].Priority);
					if (!goalPriorityData.Goal.AgentTypeCheck())
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Invalid agent type for goal: ");
							messageBuilder2.AppendFormatted(this);
						}
						Log.Error(messageBuilder2);
						continue;
					}
					base.GoalScheduler.AddToPool(goalPriorityData);
				}
				base.GoalScheduler.SetBasePriority(goal, goals[i].Priority);
				base.GoalScheduler.EnableGoal(goal);
			}
		}

		private ScheduleData GetCurrentWorkHourData()
		{
			ScheduleModel scheduleModel = animal.ScheduleModel;
			if (scheduleModel == null)
			{
				Log.Error("AnimalGoapAgent: ScheduleModel not found.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\AnimalGoapAgent.cs");
				return default(ScheduleData);
			}
			return scheduleModel.GetScheduleData(CurrentHourType);
		}
	}
}

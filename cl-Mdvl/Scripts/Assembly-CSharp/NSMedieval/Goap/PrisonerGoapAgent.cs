using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.View;
using NSMedieval.WorldMap;

namespace NSMedieval.Goap
{
	public class PrisonerGoapAgent : Agent, IFormCaravanGoapAgent
	{
		private HumanoidInstance humanoid;

		private ScheduleModel scheduleModelCache;

		private ScheduleConfig scheduleConfigCache;

		private ScheduleData currentScheduleData;

		private CaravanInstance preparingForCaravan;

		public HourType CurrentHourType { get; private set; } = HourType.None;

		public CaravanInstance PreparingForCaravan => preparingForCaravan;

		private ScheduleModel ScheduleModel
		{
			get
			{
				if (scheduleModelCache == null || scheduleModelCache.GetID() != humanoid.CurrentHumanType.ScheduleModelId)
				{
					scheduleModelCache = Repository<ScheduleModelRepository, ScheduleModel>.Instance.GetByID(humanoid.CurrentHumanType.ScheduleModelId);
				}
				return scheduleModelCache;
			}
		}

		private ScheduleConfig ScheduleConfig
		{
			get
			{
				if (humanoid.CurrentHumanType?.ScheduleConfigId == null)
				{
					return null;
				}
				if (scheduleConfigCache == null || scheduleConfigCache.GetID() != humanoid.CurrentHumanType.ScheduleConfigId)
				{
					scheduleConfigCache = Repository<ScheduleConfigRepository, ScheduleConfig>.Instance.GetByID(humanoid.CurrentHumanType.ScheduleConfigId);
				}
				return scheduleConfigCache;
			}
		}

		public PrisonerGoapAgent(HumanoidInstance humanoid)
			: base(humanoid, new NPCGoalExecutionManager(humanoid))
		{
			this.humanoid = humanoid;
			RefreshWorkHour();
			currentScheduleData = GetCurrentWorkHourData();
		}

		public override void Dispose()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= HandleHourChanged;
			}
			base.Dispose();
			humanoid = null;
			scheduleConfigCache = null;
			scheduleModelCache = null;
			preparingForCaravan = null;
		}

		public override void StartTicker()
		{
			base.StartTicker();
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += HandleHourChanged;
		}

		public override void StopTicker()
		{
			base.StopTicker();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= HandleHourChanged;
			}
		}

		internal override void OnGoalEnded(Goal goal, GoalCondition condition)
		{
			humanoid.DropStorage();
			base.OnGoalEnded(goal, condition);
		}

		public void StartCaravanFormation(CaravanInstance caravan)
		{
			if (!humanoid.HasFainted)
			{
				preparingForCaravan = caravan;
				humanoid.RopeTo(preparingForCaravan.Workers.FirstOrDefault());
			}
		}

		public void ClearCaravanFormingData()
		{
			preparingForCaravan = null;
			RefreshWorkHour();
			Abort();
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}

		public float GetJobPriority(JobType job)
		{
			string goalId = Repository<JobRepository, Job>.Instance.GetByJobType(job).Goals.FirstOrDefault((string g) => g != string.Empty);
			return base.GoalScheduler.GetJobPriority(goalId);
		}

		public void ChangeJobPriority(JobType job, int priority)
		{
			string[] goals = Repository<JobRepository, Job>.Instance.GetByJobType(job).Goals;
			foreach (string goalId in goals)
			{
				base.GoalScheduler.ModifyJobPriority(goalId, (float)((double)priority * 0.1));
			}
			RefreshActiveJobs();
		}

		public void RefreshActiveJobs()
		{
			if (humanoid.CaptiveLabourerBehaviour == null)
			{
				return;
			}
			JobType activeJobCombination = humanoid.CaptiveLabourerBehaviour.ActiveJobCombination;
			JobType[] allJobTypes = EnumValues.AllJobTypes;
			foreach (JobType jobType in allJobTypes)
			{
				if (jobType != JobType.None && (activeJobCombination & jobType) == 0)
				{
					ForbidJob(jobType);
				}
			}
			allJobTypes = EnumValues.AllJobTypes;
			foreach (JobType jobType2 in allJobTypes)
			{
				if (jobType2 != JobType.None && (activeJobCombination & jobType2) != JobType.None)
				{
					AllowJob(jobType2);
				}
			}
		}

		private void ForbidJob(JobType job)
		{
			string[] goals = Repository<JobRepository, Job>.Instance.GetByJobType(job).Goals;
			foreach (string id in goals)
			{
				base.GoalScheduler.DisableGoal(id);
			}
		}

		private void AllowJob(JobType job)
		{
			string[] goals = Repository<JobRepository, Job>.Instance.GetByJobType(job).Goals;
			foreach (string goal in goals)
			{
				if (currentScheduleData.Goals == null || currentScheduleData.Goals.Any((ScheduleData.GoalPriority item) => item.Goal.Equals(goal)))
				{
					base.GoalScheduler.EnableGoal(goal);
				}
			}
		}

		private void HandleHourChanged()
		{
			RefreshWorkHour();
		}

		public void RefreshWorkHour(bool forceRefresh = false)
		{
			if (humanoid == null || humanoid.HasDisposed || humanoid.HasDied)
			{
				return;
			}
			if (humanoid.CaptiveLabourerBehaviour != null && humanoid.CaptiveLabourerBehaviour.ForcedWorkHour != HourType.None)
			{
				ChangeCurrentHourType(humanoid.CaptiveLabourerBehaviour.ForcedWorkHour);
			}
			else if (ScheduleConfig == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\PrisonerGoapAgent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Schedule not found for animal ");
					messageBuilder.AppendFormatted(humanoid.Id);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				int num = GlobalSaveController.CurrentVillageData.DateAndTime.HoursSinceDay % ScheduleConfig.Config.Length;
				HourType newHourType = (HourType)ScheduleConfig.Config[num];
				ChangeCurrentHourType(newHourType, forceRefresh);
			}
		}

		public void ChangeCurrentHourType(HourType newHourType, bool forceRefresh = false)
		{
			if (forceRefresh || newHourType != CurrentHourType)
			{
				CurrentHourType = newHourType;
				currentScheduleData = GetCurrentWorkHourData();
				RefreshHourGoals();
			}
		}

		private ScheduleData GetCurrentWorkHourData()
		{
			if (ScheduleModel == null)
			{
				Log.Error("PrisonerGoapAgent: ScheduleModel not found.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\PrisonerGoapAgent.cs");
				return default(ScheduleData);
			}
			return ScheduleModel.GetScheduleData(CurrentHourType);
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
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(56, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\PrisonerGoapAgent.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Goal '");
							messageBuilder.AppendFormatted(goal);
							messageBuilder.AppendLiteral("' exists in ");
							messageBuilder.AppendFormatted(currentScheduleData);
							messageBuilder.AppendLiteral(" scheduled data but not found in code!");
						}
						Log.Warning(messageBuilder);
						continue;
					}
					GoalPriorityData goalPriorityData = new GoalPriorityData((Goal)GoalsMap.Constuctors[goal].Invoke(new object[1] { this }), goals[i].Priority);
					if (!goalPriorityData.Goal.AgentTypeCheck())
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(39, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\PrisonerGoapAgent.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Invalid agent type for goal ");
							messageBuilder2.AppendFormatted(goalPriorityData.Goal.Id);
							messageBuilder2.AppendLiteral(": ");
							messageBuilder2.AppendFormatted(this);
							messageBuilder2.AppendLiteral(", agent: ");
							messageBuilder2.AppendFormatted(base.AgentOwner);
						}
						Log.Error(messageBuilder2);
						continue;
					}
					if (!goalPriorityData.Goal.ShouldBeAdded())
					{
						FVLogInfoInterpolationHandler messageBuilder3 = new FVLogInfoInterpolationHandler(65, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Agent\\PrisonerGoapAgent.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Skipping goal '");
							messageBuilder3.AppendFormatted(goalPriorityData.GoalId);
							messageBuilder3.AppendLiteral("' because ShouldBeAdded() returned false (agent: ");
							messageBuilder3.AppendFormatted(base.AgentOwner);
							messageBuilder3.AppendLiteral(")");
						}
						Log.Info(messageBuilder3);
						continue;
					}
					base.GoalScheduler.AddToPool(goalPriorityData);
				}
				base.GoalScheduler.SetBasePriority(goal, goals[i].Priority);
				base.GoalScheduler.EnableGoal(goal);
			}
			RefreshActiveJobs();
		}
	}
}

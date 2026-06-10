using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.Serialization;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("CaptiveLabourerBehaviour", "")]
	public class CaptiveLabourerBehaviour : CaptiveNpcBehaviour
	{
		[SerializeField]
		private JobType activeJobCombination;

		[SerializeField]
		private JobTypeIntDictionary jobPriorities;

		public JobType ActiveJobCombination => activeJobCombination;

		public HourType ForcedWorkHour { get; internal set; } = HourType.None;

		protected override string HumanTypeId => "captive_labourer";

		public override BehaviourType BehaviourType => BehaviourType.CaptiveLabourer;

		public uint LastTimeVisitedByWarden { get; private set; }

		protected override void OnBeforeFirstActivate()
		{
			if (activeJobCombination == JobType.None)
			{
				foreach (Job captiveLabourerJob in Repository<JobRepository, Job>.Instance.GetCaptiveLabourerJobs())
				{
					activeJobCombination |= captiveLabourerJob.JobType;
				}
			}
			InitJobPriorities();
			InitJobConfig();
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			string id = (base.Humanoid.IsLeaving ? "enemy_friendly" : base.HumanType.WalkableModelFriendlyBlueprintId);
			base.Humanoid.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(id));
			base.Humanoid.SetCombatAiAgent("BlankNPCAgent");
			base.PrisonerAgent.RefreshActiveJobs();
		}

		public void ForceWorkHour(HourType hourType)
		{
			if (!base.Humanoid.HasDisposed && base.PrisonerAgent != null && hourType != ForcedWorkHour)
			{
				ForcedWorkHour = hourType;
				base.PrisonerAgent.RefreshWorkHour();
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return new PrisonerGoapAgent(base.Humanoid);
		}

		public override string GetGoapAgentId()
		{
			return "prisoner";
		}

		public override string GetMultiselectName()
		{
			return "captive_labourer";
		}

		public CaptiveLabourerBehaviour()
		{
		}

		public void OnWardenForceLabour(WorkerBehaviour workerBehaviour)
		{
			bool isEnabled;
			if (workerBehaviour == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\CaptiveLabourerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.Humanoid.GetFullName());
					messageBuilder.AppendLiteral(" - warden not found. This should not happen.");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (!workerBehaviour.HumanoidRoleOwner.HasRole("warden"))
			{
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\CaptiveLabourerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(base.Humanoid.GetFullName());
					messageBuilder2.AppendLiteral(" - warden not found ");
				}
				Log.Debug(messageBuilder2);
				return;
			}
			if (workerBehaviour.WorkerGoapAgent.CurrentHourType == HourType.RoleJob)
			{
				LastTimeVisitedByWarden = GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal;
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\CaptiveLabourerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(base.Humanoid.GetFullName());
					messageBuilder2.AppendLiteral(" - visited by warden at ");
					messageBuilder2.AppendFormatted(LastTimeVisitedByWarden);
					messageBuilder2.AppendLiteral(" ");
				}
				Log.Debug(messageBuilder2);
			}
			base.Humanoid.Stats.StartEffectors(MonoSingleton<RoleManager>.Instance.GetLabourerProximityInteractEffectors());
		}

		protected override ProximityBehaviour GetProximityBehaviour()
		{
			return new CaptiveNpcBehaviourProximity(base.Humanoid);
		}

		public bool IsJobActive(JobType jobType)
		{
			return (activeJobCombination & jobType) == jobType;
		}

		public int GetJobPriorityTruncated(JobType jobType)
		{
			float jobPriority = base.PrisonerAgent.GetJobPriority(jobType);
			return Mathf.RoundToInt((jobPriority - (float)(int)jobPriority) * 10f);
		}

		private void InitJobConfig()
		{
			foreach (Job workerJob in Repository<JobRepository, Job>.Instance.GetWorkerJobs())
			{
				UpdateJobSettings(workerJob.JobType);
			}
		}

		private void InitJobPriorities()
		{
			if (jobPriorities == null)
			{
				jobPriorities = SerializableDictionary<JobType, int>.CreateNew<JobTypeIntDictionary>();
			}
			foreach (KeyValuePair<JobType, int> item in JobUtils.UpdatePrioritiesDictionary(jobPriorities, base.Humanoid).Dictionary)
			{
				RegisterJobPriority(item.Key, item.Value, !IsJobActive(item.Key));
			}
		}

		public void ModifyJobPriority(JobType jobType, int valueToAdd, bool removeJob)
		{
			int value = GetJobPriorityTruncated(jobType) + valueToAdd - 5;
			jobPriorities.Dictionary[jobType] = value;
			RegisterJobPriority(jobType, valueToAdd, removeJob);
		}

		private void RegisterJobPriority(JobType jobType, int jobPriority, bool removeJob)
		{
			if (removeJob)
			{
				RemoveActiveJob(jobType);
			}
			else
			{
				AddActiveJob(jobType);
			}
			base.PrisonerAgent.ChangeJobPriority(jobType, jobPriority);
		}

		private void AddActiveJob(JobType jobType)
		{
			if (!activeJobCombination.HasFlag(jobType))
			{
				activeJobCombination |= jobType;
				UpdateJobSettings(jobType);
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JobConfigUpdated(base.Humanoid);
				MonoSingleton<ProductionManager>.Instance.UpdateAllProductionStates();
			}
		}

		public void RemoveActiveJob(JobType jobType)
		{
			if (activeJobCombination.HasFlag(jobType))
			{
				activeJobCombination ^= jobType;
				base.PrisonerAgent.RefreshActiveJobs();
				UpdateJobSettings(jobType);
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JobConfigUpdated(base.Humanoid);
				MonoSingleton<ProductionManager>.Instance.UpdateAllProductionStates();
			}
		}

		private void UpdateJobSettings(JobType jobType)
		{
			Job byJobType = Repository<JobRepository, Job>.Instance.GetByJobType(jobType);
			if (!activeJobCombination.HasFlag(jobType) && byJobType?.Goals?.Contains(base.GoapAgent?.CurrentGoalName) == true)
			{
				base.GoapAgent?.Abort();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.WriteEnum("activeJobCombination", activeJobCombination);
			serializer.Write("jobPriorities", jobPriorities);
		}

		public CaptiveLabourerBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			activeJobCombination = deserializer.ReadEnum("activeJobCombination", JobType.None);
			jobPriorities = deserializer.ReadObject<JobTypeIntDictionary>("jobPriorities");
		}
	}
}

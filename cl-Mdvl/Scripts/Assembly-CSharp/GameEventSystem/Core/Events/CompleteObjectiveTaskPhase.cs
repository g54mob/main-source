using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Objectives;
using NSMedieval.Serialization;
using Objectives;

namespace GameEventSystem.Core.Events
{
	[FVSerializableKey("CompleteObjectiveTaskPhase", "")]
	public class CompleteObjectiveTaskPhase : SingleExecutePhaseBase
	{
		private readonly string objectiveId;

		private readonly string taskId;

		public CompleteObjectiveTaskPhase(string objectiveId, string taskId)
		{
			this.objectiveId = objectiveId;
			this.taskId = taskId;
		}

		protected override void Execute()
		{
			CompleteObjectiveTask();
		}

		private void CompleteObjectiveTask()
		{
			ObjectiveInstance activeObjective = MonoSingleton<ObjectiveManager>.Instance.ActiveObjective;
			bool isEnabled;
			if (activeObjective == null)
			{
				Log.Debug("ActiveObjective is null.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\CompleteObjectiveTaskPhase.cs");
			}
			else if (string.IsNullOrEmpty(objectiveId))
			{
				Log.Debug("Given objectiveId is null or empty.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\CompleteObjectiveTaskPhase.cs");
			}
			else if (objectiveId != activeObjective.BlueprintId)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\CompleteObjectiveTaskPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ActiveObjective's objectiveId is not ");
					messageBuilder.AppendFormatted(objectiveId);
					messageBuilder.AppendLiteral(". It's ");
					messageBuilder.AppendFormatted(activeObjective.BlueprintId);
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\CompleteObjectiveTaskPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Completing task ");
					messageBuilder.AppendFormatted(taskId);
				}
				Log.Debug(messageBuilder);
				activeObjective.SetTaskCompleted(taskId, taskCompleted: true);
				MonoSingleton<ObjectiveManager>.Instance.ScheduleCheckObjective(ObjectiveTaskRequirementType.All);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("objectiveId", objectiveId);
			serializer.Write("taskId", taskId);
		}

		public CompleteObjectiveTaskPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			objectiveId = deserializer.ReadString("objectiveId");
			taskId = deserializer.ReadString("taskId");
		}
	}
}

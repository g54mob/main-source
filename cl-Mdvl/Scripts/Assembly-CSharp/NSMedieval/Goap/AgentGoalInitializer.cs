using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;

namespace NSMedieval.Goap
{
	public class AgentGoalInitializer
	{
		private readonly ThreadSequenceExecutor goalInitExecutor;

		private Goal goalToStart;

		private Goal preparingGoal;

		internal Goal GoalToStart => goalToStart;

		internal bool IsSequenceExecuting => goalInitExecutor.IsSequenceExecuting;

		public Goal PreparingGoal => preparingGoal;

		public event Action<ThreadSequenceJobCompleteStatus, Goal> OnInitSequenceFailedEvent;

		public AgentGoalInitializer()
		{
			goalInitExecutor = new ThreadSequenceExecutor();
			goalInitExecutor.CompletedListenerEvent += GoalInitSequenceDone;
		}

		internal void Reset()
		{
			goalToStart = null;
			goalInitExecutor.Abort();
		}

		internal void StartGoalInitSequence(Goal goal)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(42, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\AgentGoalInitializer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting goal init sequence: ");
				messageBuilder.AppendFormatted(goal.GetType().Name);
				messageBuilder.AppendLiteral(" for agent '");
				messageBuilder.AppendFormatted(goal.AgentOwner);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			goal.ClearTargets();
			preparingGoal = goal;
			ThreadSequenceExecuteStatus threadSequenceExecuteStatus = goalInitExecutor.ExecuteSequence(goal.InitJob);
			switch (threadSequenceExecuteStatus)
			{
			case ThreadSequenceExecuteStatus.NothingToDo:
				goalToStart = goal;
				preparingGoal = null;
				return;
			case ThreadSequenceExecuteStatus.Started:
				return;
			}
			FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\AgentGoalInitializer.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Error starting goal '");
				messageBuilder2.AppendFormatted(goal.Id);
				messageBuilder2.AppendLiteral("' init sequence. Status: ");
				messageBuilder2.AppendFormatted(threadSequenceExecuteStatus);
			}
			Log.Warning(messageBuilder2);
			if (threadSequenceExecuteStatus == ThreadSequenceExecuteStatus.Aborting)
			{
				preparingGoal = null;
			}
		}

		private void GoalInitSequenceDone(ThreadSequenceJobCompleteStatus status, ThreadSequenceJob job)
		{
			preparingGoal = null;
			ThreadSequenceGoalJob threadSequenceGoalJob = (ThreadSequenceGoalJob)job;
			if (threadSequenceGoalJob.Goal != null && threadSequenceGoalJob.Goal.Agent != null && !threadSequenceGoalJob.Goal.Agent.HasDisposed)
			{
				switch (status)
				{
				case ThreadSequenceJobCompleteStatus.Abort:
					OnInitSequenceFailed(status, threadSequenceGoalJob.Goal);
					break;
				default:
					OnInitSequenceFailed(status, threadSequenceGoalJob.Goal);
					break;
				case ThreadSequenceJobCompleteStatus.Success:
					goalToStart = threadSequenceGoalJob.Goal;
					break;
				}
			}
		}

		private void OnInitSequenceFailed(ThreadSequenceJobCompleteStatus status, Goal goal)
		{
			preparingGoal = null;
			this.OnInitSequenceFailedEvent?.Invoke(status, goal);
			for (int i = 0; i < 5; i++)
			{
				try
				{
					goal.ClearTargets(extraSafety: true);
					break;
				}
				catch
				{
				}
			}
		}
	}
}

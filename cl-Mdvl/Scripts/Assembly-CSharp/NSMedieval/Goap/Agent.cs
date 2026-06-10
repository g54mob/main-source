using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Goap
{
	public abstract class Agent : IGameDisposable, IDisposable
	{
		private const int MaxAllowedConsecutiveGoalFailure = 5;

		private IGoapAgentOwner agentOwner;

		private Goal currentGoal;

		private Goal goalToForceStart;

		private Goal lastForceStartedGoal;

		private AgentGoalInitializer goalInitializer;

		private GoalExecutionManager goalExecutionManager;

		private float delayNextTick;

		private Goal lastFailedGoal;

		private int consecutiveGoalFailCount;

		private bool isTickActive;

		public GoalScheduler GoalScheduler => goalExecutionManager?.GoalScheduler;

		public bool HasDisposed { get; private set; }

		public bool IsTickActive => isTickActive;

		public IGoapAgentOwner AgentOwner => agentOwner;

		public string CurrentGoalName
		{
			get
			{
				if (currentGoal == null)
				{
					return string.Empty;
				}
				return currentGoal.Id;
			}
		}

		public bool IsGoalPreparing => goalInitializer.IsSequenceExecuting;

		public string PreparingGoalName => goalInitializer.PreparingGoal?.Id ?? string.Empty;

		public GoalExecutionManager GoalExecutionManager => goalExecutionManager;

		public float NextTickDelayTime => delayNextTick;

		internal Goal GoalToStart => goalInitializer.GoalToStart;

		internal Goal LastForceStartedGoal => lastForceStartedGoal;

		protected AgentGoalInitializer GoalInitializer => goalInitializer;

		public event Action<IGameDisposable> OnDisposedEvent;

		protected Agent(IGoapAgentOwner owner, GoalExecutionManager customExecutionManager = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating new agent '");
				messageBuilder.AppendFormatted(GetType().Name);
				messageBuilder.AppendLiteral("' for owner '");
				messageBuilder.AppendFormatted(owner);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			agentOwner = owner;
			goalInitializer = new AgentGoalInitializer();
			goalInitializer.OnInitSequenceFailedEvent += GoalInitSequenceFailed;
			goalExecutionManager = customExecutionManager ?? new GoalExecutionManager(owner);
			delayNextTick = 0.5f;
			if (!owner.IsInIncognitoMode())
			{
				MonoSingleton<GoapController>.Instance.OnStartTicker += StartTicker;
			}
		}

		public abstract AnimatedAgentView GetView();

		public void ForceNextGoal(Goal goal)
		{
			if (HasDisposed || goalInitializer == null || !goal.CanStart(isForced: true) || !CanGoalStart(goal) || (goalToForceStart != null && goalToForceStart.Id.Equals(goal.Id)))
			{
				return;
			}
			bool isEnabled;
			if (goalToForceStart != null && IsGoalPreparing)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(116, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to force start goal '");
					messageBuilder.AppendFormatted(goalToForceStart.Id);
					messageBuilder.AppendLiteral("' while other goal was being prepared! This is un-safe behaviour, so it has been disabled");
				}
				Log.Warning(messageBuilder);
			}
			else if (currentGoal != null && currentGoal == goal && currentGoal.State != GoalState.Ended)
			{
				string t = goal?.Id ?? string.Empty;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(106, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to force goal '");
					messageBuilder.AppendFormatted(t);
					messageBuilder.AppendLiteral("' while it's already been running. This is un-safe behaviour, so it has been disabled");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				goalToForceStart = goal;
				lastForceStartedGoal = goalToForceStart;
				StartGoalInitSequence(goal);
			}
		}

		public Goal ForceNextGoal(string goalId)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ForceNextGoal '");
				messageBuilder.AppendFormatted(goalId);
				messageBuilder.AppendLiteral("' for agent ");
				messageBuilder.AppendFormatted(agentOwner);
			}
			Log.Trace(messageBuilder);
			if (goalToForceStart != null && goalToForceStart.Id.Equals(goalId))
			{
				return goalToForceStart;
			}
			Goal fromPool = goalExecutionManager.GoalScheduler.GetFromPool(goalId);
			if (fromPool == null)
			{
				return null;
			}
			ForceNextGoal(fromPool);
			if (goalToForceStart != fromPool)
			{
				return null;
			}
			return fromPool;
		}

		public void Abort()
		{
			goalInitializer?.Reset();
			goalToForceStart = null;
			if (currentGoal != null && currentGoal.State == GoalState.Running)
			{
				currentGoal.CurrentAction?.Complete(ActionCompletionStatus.Jump);
				currentGoal?.EndGoalWith(GoalCondition.Incompletable);
				currentGoal = null;
				consecutiveGoalFailCount = 0;
			}
		}

		public void DelayNextTick(float time)
		{
			delayNextTick = time;
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				GoalToStart?.ForceStop();
				goalToForceStart?.ForceStop();
				if (!LoadingController.IsLeavingMainScene && !MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition)
				{
					currentGoal?.EndGoalWith(GoalCondition.Incompletable);
				}
				currentGoal?.ForceStop();
				StopTicker();
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				GoalScheduler?.Dispose();
				goalExecutionManager?.Reset();
				goalExecutionManager?.Dispose();
				goalExecutionManager = null;
				goalInitializer.Reset();
				goalInitializer = null;
				goalToForceStart = null;
				lastFailedGoal = null;
				currentGoal = null;
				lastForceStartedGoal = null;
				agentOwner = null;
				this.OnDisposedEvent = null;
			}
		}

		public Goal GetCurrentGoal()
		{
			return currentGoal;
		}

		public virtual void StopTicker()
		{
			if (IsTickActive)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StopTicker of agent '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("' for owner '");
					messageBuilder.AppendFormatted(AgentOwner);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				isTickActive = false;
				Abort();
			}
		}

		public virtual void StartTicker()
		{
			if (!IsTickActive)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(36, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StartTicker of agent '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("' for owner '");
					messageBuilder.AppendFormatted(AgentOwner);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				MonoSingleton<GoapController>.Instance.OnStartTicker -= StartTicker;
				if (!HasDisposed)
				{
					isTickActive = true;
				}
			}
		}

		internal virtual void OnGoalEnded(Goal goal, GoalCondition condition)
		{
			if (lastForceStartedGoal == goal)
			{
				lastForceStartedGoal = null;
			}
			if (condition != GoalCondition.Succeeded && goal != null)
			{
				if (lastFailedGoal == goal)
				{
					consecutiveGoalFailCount = ((!(goal.TotalTickingTime <= 5f)) ? 1 : (consecutiveGoalFailCount + 1));
				}
				else
				{
					lastFailedGoal = goal;
					consecutiveGoalFailCount = 1;
				}
			}
			else
			{
				lastFailedGoal = null;
				consecutiveGoalFailCount = 0;
			}
			if (goal != null && !goal.IsExemptFromConsecutiveFailsDisable && consecutiveGoalFailCount >= 5)
			{
				string t = goal.CurrentAction?.Id;
				ActionCompletionStatus t2 = goal.CurrentAction?.CompletionStatus ?? ActionCompletionStatus.None;
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(98, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Goal consecutive failure ");
					messageBuilder.AppendFormatted(consecutiveGoalFailCount);
					messageBuilder.AppendLiteral(" detected! Condition: ");
					messageBuilder.AppendFormatted(condition);
					messageBuilder.AppendLiteral(" Action: ");
					messageBuilder.AppendFormatted(t);
					messageBuilder.AppendLiteral("/");
					messageBuilder.AppendFormatted(t2);
					messageBuilder.AppendLiteral(" Goal: ");
					messageBuilder.AppendFormatted(goal.Id);
					messageBuilder.AppendLiteral(", will be disabled for 5 seconds. ");
					messageBuilder.AppendFormatted(agentOwner);
				}
				Log.Warning(messageBuilder);
				goal.HandleConsecutiveFail();
				GoalScheduler.DisableGoal(goal.Id);
				consecutiveGoalFailCount = 0;
				MonoSingleton<TaskController>.Instance.WaitFor(5f).Then(delegate
				{
					if (!HasDisposed)
					{
						GoalScheduler.EnableGoal(goal.Id);
					}
				});
			}
			DelayNextTick(0.01f);
			if (condition != GoalCondition.Succeeded)
			{
				DelayNextTick(0.5f);
			}
			if (currentGoal != null && MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.OnGoalEnded(this, currentGoal.Id, condition);
			}
			((agentOwner as IPathfindingAgent)?.PathDriver)?.Abort();
			goalExecutionManager?.Reset();
			if (goalToForceStart == goal)
			{
				goalToForceStart = null;
			}
		}

		public virtual void Tick(float deltaTime)
		{
			if (!isTickActive)
			{
				return;
			}
			if (agentOwner == null || agentOwner.HasDisposed || HasDisposed)
			{
				isTickActive = false;
				return;
			}
			using (ProfilerSampleJanitor.Begin("Agent.Tick"))
			{
				if (delayNextTick > 0f)
				{
					delayNextTick -= Time.unscaledDeltaTime;
				}
				else
				{
					if (deltaTime <= 0.001f || IsGoalPreparing)
					{
						return;
					}
					if (goalInitializer.GoalToStart != null)
					{
						using (ProfilerSampleJanitor.Begin("StartNextGoal"))
						{
							StartNextGoal();
						}
						if (agentOwner == null || agentOwner.HasDisposed)
						{
							isTickActive = false;
							return;
						}
					}
					bool isEnabled;
					if (currentGoal == null)
					{
						if (IsGoalPreparing)
						{
							return;
						}
						Goal nextToStart = goalExecutionManager.GetNextToStart();
						if (nextToStart == null)
						{
							if (this is CombatAiAgent)
							{
								return;
							}
							if (this is WorkerGoapAgent workerGoapAgent)
							{
								if (workerGoapAgent.CurrentHourType != HourType.Draft)
								{
									FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(71, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
									if (isEnabled)
									{
										messageBuilder.AppendLiteral("Could not find any startable goals for worker: '");
										messageBuilder.AppendFormatted(agentOwner);
										messageBuilder.AppendLiteral("' CURRENT_HOUR ");
										messageBuilder.AppendFormatted(workerGoapAgent.CurrentHourType);
										messageBuilder.AppendLiteral(" GCONT: ");
										messageBuilder.AppendFormatted(workerGoapAgent.GoalScheduler?.EnabledGoals?.Count);
									}
									Log.Warning(messageBuilder);
								}
							}
							else
							{
								FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
								if (isEnabled)
								{
									messageBuilder2.AppendLiteral("Could not find any startable goals for agent: ");
									messageBuilder2.AppendFormatted(agentOwner);
								}
								Log.Trace(messageBuilder2);
							}
						}
						else
						{
							StartGoalInitSequence(nextToStart);
						}
						return;
					}
					if (currentGoal.State != GoalState.Running)
					{
						currentGoal = null;
						return;
					}
					try
					{
						currentGoal.Tick(deltaTime);
					}
					catch (Exception t)
					{
						FVLogErrorInterpolationHandler messageBuilder3 = new FVLogErrorInterpolationHandler(45, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Got exception while ticking goal '");
							messageBuilder3.AppendFormatted(currentGoal?.Id);
							messageBuilder3.AppendLiteral("' A: '");
							messageBuilder3.AppendFormatted(agentOwner);
							messageBuilder3.AppendLiteral("' E: ");
							messageBuilder3.AppendFormatted(t);
						}
						Log.Error(messageBuilder3);
						messageBuilder3 = new FVLogErrorInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("End action: ");
							messageBuilder3.AppendFormatted(currentGoal?.CurrentAction?.Id);
						}
						Log.Error(messageBuilder3);
						try
						{
							currentGoal.EndGoalWith(GoalCondition.Error);
						}
						catch
						{
						}
						currentGoal = null;
						return;
					}
					Goal goal = currentGoal;
					if (goal != null && goal.State == GoalState.Running)
					{
						Goal goal2 = goalExecutionManager.CheckForInterruption(currentGoal);
						if (goal2 != null)
						{
							StartGoalInitSequence(goal2);
						}
					}
				}
			}
		}

		protected virtual bool CanGoalStart(Goal goal)
		{
			return true;
		}

		private void StartNextGoal()
		{
			if (goalInitializer.GoalToStart == null)
			{
				Log.Error("This line should never be reached! You fucked something up horribly", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				return;
			}
			Goal goalToStart = goalInitializer.GoalToStart;
			bool isEnabled;
			if (currentGoal != null && currentGoal.State == GoalState.Running)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(64, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Starting next goal ");
					messageBuilder.AppendFormatted(goalInitializer.GoalToStart.Id);
					messageBuilder.AppendLiteral(", but there was goal ");
					messageBuilder.AppendFormatted(currentGoal.Id);
					messageBuilder.AppendLiteral(" already running, agent ");
					messageBuilder.AppendFormatted(agentOwner);
				}
				Log.Trace(messageBuilder);
				currentGoal.EndGoalWith(GoalCondition.Incompletable);
			}
			if (HasDisposed || goalInitializer == null)
			{
				return;
			}
			if (goalInitializer.GoalToStart == null && currentGoal != null)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Agent.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Current goal cleared 'goalToStart'. ");
					messageBuilder2.AppendFormatted(currentGoal.Id);
					messageBuilder2.AppendLiteral(" Starting goal: ");
					messageBuilder2.AppendFormatted(goalToStart?.Id);
				}
				Log.Warning(messageBuilder2);
			}
			currentGoal = goalToStart;
			currentGoal.Start();
			goalInitializer.Reset();
			goalExecutionManager.Reset();
			MonoSingleton<GoapController>.Instance.OnGoalStarted(this, currentGoal);
		}

		private void StartGoalInitSequence(Goal goalToStart)
		{
			using (ProfilerSampleJanitor.Begin("Start Goal Init Sequence"))
			{
				MonoSingleton<GoapController>.Instance.OnNextGoalPlanned(this, goalToStart);
				goalInitializer.StartGoalInitSequence(goalToStart);
			}
		}

		protected virtual void GoalInitSequenceFailed(ThreadSequenceJobCompleteStatus status, Goal goal)
		{
			if (goal == goalToForceStart)
			{
				goalToForceStart = null;
				lastForceStartedGoal = null;
			}
		}

		public override string ToString()
		{
			return AgentOwner.GetGoapAgentID();
		}
	}
}

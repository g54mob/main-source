using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Goap
{
	public abstract class Goal
	{
		private readonly string id;

		private GoalState state;

		private readonly GoalInterruptMode interruptMode;

		private readonly List<GoapAction> actions = new List<GoapAction>();

		private int currentActionIndex;

		private int forcedNextActionIndex;

		private bool shouldStartNextAction;

		private Dictionary<TargetIndex, List<TargetObject>> targetsQueue = new Dictionary<TargetIndex, List<TargetObject>>();

		private Dictionary<TargetIndex, TargetObject> currentTarget = new Dictionary<TargetIndex, TargetObject>();

		private ThreadSequenceGoalJob initJob;

		private Agent agent;

		private float totalTickingTime;

		private PreferredReservableHandler preferredReservableHandler;

		private int startGoalFrameTime;

		private ConstructionJobManager constructionJobManagerCached;

		protected static WorldDate DateTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		protected ConstructionJobManager ConstructionJobManager
		{
			get
			{
				if (constructionJobManagerCached == null)
				{
					constructionJobManagerCached = AgentOwner.Map.BuildingsManagerMain.ConstructionJobManager;
				}
				return constructionJobManagerCached;
			}
		}

		public string Id => id;

		public GoapAction CurrentAction
		{
			get
			{
				if (actions.Count <= 0 || currentActionIndex <= -1 || currentActionIndex >= actions.Count)
				{
					return null;
				}
				return actions[currentActionIndex];
			}
		}

		public GoapAction NextAction
		{
			get
			{
				if (actions.Count <= 1 || currentActionIndex <= -1 || currentActionIndex + 1 >= actions.Count)
				{
					return null;
				}
				return actions[currentActionIndex + 1];
			}
		}

		public GoalState State
		{
			get
			{
				return state;
			}
			protected set
			{
				state = value;
			}
		}

		public GoalInterruptMode InterruptMode => interruptMode;

		public Agent Agent => agent;

		public IGoapAgentOwner AgentOwner => agent?.AgentOwner;

		public float TotalTickingTime => totalTickingTime;

		public float StartGoalFrameTime => startGoalFrameTime;

		internal PreferredReservableHandler PreferredReservableHandler => preferredReservableHandler;

		internal ThreadSequenceGoalJob InitJob => initJob;

		internal GoapAction ForcedNextAction
		{
			get
			{
				if (actions.Count <= 0 || forcedNextActionIndex <= -1 || forcedNextActionIndex >= actions.Count)
				{
					return null;
				}
				return actions[forcedNextActionIndex];
			}
		}

		public virtual bool IsExemptFromConsecutiveFailsDisable => false;

		private event Action<GoalCondition> OnGoalEndedEvent;

		public Goal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
		{
			this.id = id;
			agent = selfAgent;
			this.interruptMode = interruptMode;
			initJob = new ThreadSequenceGoalJob(this);
			preferredReservableHandler = new PreferredReservableHandler(AgentOwner);
		}

		public virtual void Dispose()
		{
			agent = null;
		}

		public virtual void Start()
		{
			State = GoalState.Running;
			totalTickingTime = 0f;
			startGoalFrameTime = Time.frameCount;
		}

		protected virtual void OnTick()
		{
		}

		public abstract bool CanStart(bool isForced = false);

		public abstract bool AgentTypeCheck();

		public virtual bool CanBeInterrupted()
		{
			return interruptMode != GoalInterruptMode.Never;
		}

		public virtual bool ShouldBeAdded()
		{
			return true;
		}

		public virtual void HandleConsecutiveFail()
		{
		}

		public TargetObject GetTarget(TargetIndex index)
		{
			return currentTarget.GetValueOrDefault(index);
		}

		public bool TryGetTarget(TargetIndex index, out TargetObject target)
		{
			return currentTarget.TryGetValue(index, out target);
		}

		public bool HasTarget(TargetIndex index)
		{
			return currentTarget.ContainsKey(index);
		}

		public List<TargetObject> GetTargetQueue(TargetIndex index)
		{
			if (!targetsQueue.ContainsKey(index))
			{
				targetsQueue[index] = new List<TargetObject>();
			}
			return targetsQueue[index];
		}

		public virtual void EndGoalWith(GoalCondition condition)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(40, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Goal '");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral("' ended with condition: ");
				messageBuilder.AppendFormatted(condition);
				messageBuilder.AppendLiteral(", agent '");
				messageBuilder.AppendFormatted((AgentOwner as HumanoidInstance)?.GetFullName());
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			State = GoalState.Ended;
			if (CurrentAction != null && !CurrentAction.HasCompleted)
			{
				CurrentAction.Complete(ActionCompletionStatus.Fail);
			}
			this.OnGoalEndedEvent?.Invoke(condition);
			this.OnGoalEndedEvent = null;
			Agent?.OnGoalEnded(this, condition);
			currentActionIndex = -1;
			forcedNextActionIndex = -1;
			actions.Clear();
			ClearTargets();
		}

		public void ForceStop()
		{
			State = GoalState.Ended;
			this.OnGoalEndedEvent = null;
			currentActionIndex = -1;
			forcedNextActionIndex = -1;
			actions.Clear();
			targetsQueue.Clear();
			currentTarget.Clear();
			preferredReservableHandler = null;
			initJob = null;
			agent = null;
		}

		internal void JumpToAction(GoapAction action)
		{
			if (State != GoalState.Running || action == null)
			{
				return;
			}
			if (!actions.Contains(action))
			{
				Log.Error("Can not JumpToAction, because it is not in actions list", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				return;
			}
			if (CurrentAction != null && !CurrentAction.HasCompleted)
			{
				CurrentAction.Complete(ActionCompletionStatus.Jump);
				GoapAction currentAction = CurrentAction;
				if (currentAction != null && currentAction.WaitingForAnimation)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(96, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Tried to jump over action '");
						messageBuilder.AppendFormatted(CurrentAction.Id);
						messageBuilder.AppendLiteral("' while it's waiting for animation to finish. This could be a problem");
					}
					Log.Trace(messageBuilder);
					MonoSingleton<TaskController>.Instance.WaitUntil((float time) => !CurrentAction.WaitingForAnimation).Then(delegate
					{
						forcedNextActionIndex = actions.IndexOf(action);
						ReadyForNextAction();
					});
					return;
				}
			}
			forcedNextActionIndex = actions.IndexOf(action);
			ReadyForNextAction();
		}

		internal void ReadyForNextAction()
		{
			shouldStartNextAction = true;
		}

		internal void SelectTarget(TargetIndex index, TargetObject target)
		{
			if (target.IsInitialized)
			{
				List<TargetObject> targetQueue = GetTargetQueue(index);
				if (targetQueue == null || targetQueue.Count == 0 || !targetQueue.Contains(target))
				{
					Log.Error("Tried to select non-existing target!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
					return;
				}
				targetQueue.Remove(target);
				SetTarget(index, target);
			}
		}

		internal bool SelectNextTarget(TargetIndex index)
		{
			List<TargetObject> targetQueue = GetTargetQueue(index);
			if (targetQueue == null || targetQueue.Count == 0)
			{
				SetTarget(index, default(TargetObject));
				return false;
			}
			TargetObject target = targetQueue[0];
			SelectTarget(index, target);
			return true;
		}

		internal void SetSelectedTargetReachablePosition(TargetIndex index, Vec3Int pos)
		{
			if (GetTarget(index).IsInitialized)
			{
				currentTarget[index] = new TargetObject(currentTarget[index].ObjectInstance, pos);
			}
		}

		internal void ClearTargetsQueue(TargetIndex index)
		{
			List<TargetObject> targetQueue = GetTargetQueue(index);
			if (targetQueue == null || targetQueue.Count == 0)
			{
				return;
			}
			foreach (TargetObject item in targetQueue)
			{
				ReleaseTargetReservation(item);
			}
			targetQueue.Clear();
		}

		internal void Tick(float deltaTime)
		{
			if (State != GoalState.Running)
			{
				Log.Warning("Tried to tick goal that is not running", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				return;
			}
			totalTickingTime += deltaTime;
			if (actions.Count == 0)
			{
				currentActionIndex = -1;
				forcedNextActionIndex = -1;
				shouldStartNextAction = false;
				using (ProfilerSampleJanitor.Begin("SetupActions"))
				{
					SetupActions();
					return;
				}
			}
			if (shouldStartNextAction)
			{
				using (ProfilerSampleJanitor.Begin("TryStartNextAction"))
				{
					TryStartNextAction();
					return;
				}
			}
			if (CurrentAction == null)
			{
				ReadyForNextAction();
				return;
			}
			using (ProfilerSampleJanitor.Begin("CheckEndOrFail"))
			{
				if (CheckEndOrFail())
				{
					return;
				}
			}
			using (ProfilerSampleJanitor.Begin("ActionPreTick"))
			{
				if (ActionPreTick())
				{
					return;
				}
			}
			CurrentAction.Tick(deltaTime);
			OnTick();
		}

		internal Dictionary<TargetIndex, List<TargetObject>> GetQueues()
		{
			return targetsQueue;
		}

		internal void AddEndListener(Action<GoalCondition> listener)
		{
			OnGoalEndedEvent += listener;
		}

		internal void RemoveEndListener(Action<GoalCondition> listener)
		{
			OnGoalEndedEvent -= listener;
		}

		internal virtual void ClearTargets(bool extraSafety = false)
		{
			foreach (KeyValuePair<TargetIndex, List<TargetObject>> item in targetsQueue.Where((KeyValuePair<TargetIndex, List<TargetObject>> pair) => pair.Value != null && pair.Value.Count > 0).ToList())
			{
				if (extraSafety)
				{
					TargetObject[] array = item.Value.ToArray();
					foreach (TargetObject target in array)
					{
						ReleaseTargetReservation(target);
					}
				}
				else
				{
					foreach (TargetObject item2 in item.Value.IterateInReverseDynamic())
					{
						ReleaseTargetReservation(item2);
					}
				}
				item.Value.Clear();
			}
			if (currentTarget.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<TargetIndex, TargetObject> item3 in new Dictionary<TargetIndex, TargetObject>(currentTarget))
			{
				ReleaseTargetReservation(item3.Value);
			}
			currentTarget.Clear();
		}

		internal void ForceTarget(TargetIndex index, TargetObject target)
		{
			SetTarget(index, target);
		}

		protected abstract IEnumerable<GoapAction> GetNextAction();

		protected void AddInitStep(ThreadSequenceStep step)
		{
			initJob.AddStep(step);
		}

		internal void QueueTarget(TargetIndex index, TargetObject target)
		{
			if (!target.IsInitialized)
			{
				return;
			}
			if (index == TargetIndex.None)
			{
				Log.Error("Can not queue target index None!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				return;
			}
			if (!targetsQueue.ContainsKey(index))
			{
				targetsQueue[index] = new List<TargetObject>();
			}
			targetsQueue[index].Add(target);
		}

		protected void QueueTargets(TargetIndex index, IEnumerable<TargetObject> targets)
		{
			if (index == TargetIndex.None)
			{
				Log.Error("Can not queue target index None!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
			}
			else
			{
				if (targets == null)
				{
					return;
				}
				if (targetsQueue.ContainsKey(index))
				{
					List<TargetObject> list = targetsQueue[index];
					if (list != null && list.Count > 0)
					{
						List<TargetObject> list2 = targetsQueue[index];
						{
							foreach (TargetObject target in targets)
							{
								list2.Add(target);
							}
							return;
						}
					}
				}
				if (targets is List<TargetObject> value)
				{
					targetsQueue[index] = value;
				}
				else
				{
					targetsQueue[index] = targets.ToList();
				}
			}
		}

		protected void SetTarget(TargetIndex index, TargetObject target, bool ignoreReservations = false)
		{
			if (index == TargetIndex.None)
			{
				Log.Error("Can not set target index None!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				return;
			}
			if (currentTarget.ContainsKey(index) && !ignoreReservations)
			{
				ReleaseTargetReservation(currentTarget[index]);
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(35, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Set target ");
				messageBuilder.AppendFormatted(index);
				messageBuilder.AppendLiteral(" = (obj: '");
				messageBuilder.AppendFormatted(target.ObjectInstance);
				messageBuilder.AppendLiteral("', pos: '");
				messageBuilder.AppendFormatted(target.ReachablePosition);
				messageBuilder.AppendLiteral("') '");
				messageBuilder.AppendFormatted(AgentOwner);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			currentTarget[index] = target;
		}

		protected bool ReserveAndSelectFirstTargetFromQueue(TargetIndex index)
		{
			while (SelectNextTarget(index))
			{
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(GetTarget(index).GetAsReservable(), AgentOwner))
				{
					ClearTargetsQueue(index);
					return true;
				}
			}
			currentTarget[index] = default(TargetObject);
			return false;
		}

		protected bool ReserveAsMuchAsPossible(TargetIndex index)
		{
			List<TargetObject> targetQueue = GetTargetQueue(index);
			bool result = false;
			foreach (var (targetObject, index2) in targetQueue.IterateInReverseDynamicWithIndex())
			{
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(targetObject.GetAsReservable(), AgentOwner))
				{
					result = true;
				}
				else
				{
					targetQueue.RemoveAt(index2);
				}
			}
			return result;
		}

		private void SetupActions()
		{
			bool isEnabled;
			try
			{
				foreach (GoapAction item in GetNextAction())
				{
					if (item.CompleteMode == ActionCompleteMode.None)
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Action '");
							messageBuilder.AppendFormatted(item);
							messageBuilder.AppendLiteral("' complete mode set to None! Changing to instant");
						}
						Log.Warning(messageBuilder);
						item.CompleteMode = ActionCompleteMode.Instant;
					}
					item.SetGoal(this);
					actions.Add(item);
				}
			}
			catch (Exception t)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Exception in SetupActions for agent '");
					messageBuilder2.AppendFormatted(Agent);
					messageBuilder2.AppendLiteral("' ");
					messageBuilder2.AppendFormatted(t);
				}
				Log.Error(messageBuilder2);
			}
		}

		private void TryStartNextAction()
		{
			if (State != GoalState.Running || AgentOwner.HasDisposed)
			{
				return;
			}
			shouldStartNextAction = false;
			if (forcedNextActionIndex > -1)
			{
				currentActionIndex = forcedNextActionIndex;
				forcedNextActionIndex = -1;
			}
			else
			{
				currentActionIndex++;
			}
			bool isEnabled;
			if (currentActionIndex >= actions.Count)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TryStartNextAction ended goal '");
					messageBuilder.AppendFormatted(Id);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
				EndGoalWith(GoalCondition.Succeeded);
				return;
			}
			GoapAction currentAction = CurrentAction;
			CheckEndOrFail();
			if (CurrentAction != null)
			{
				try
				{
					CurrentAction.Init();
				}
				catch (Exception t)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(46, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Exception while INITing goal action ");
						messageBuilder2.AppendFormatted(id);
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(CurrentAction?.Id);
						messageBuilder2.AppendLiteral(" IDX ");
						messageBuilder2.AppendFormatted(currentActionIndex);
						messageBuilder2.AppendLiteral(" E: ");
						messageBuilder2.AppendFormatted(t);
					}
					Log.Error(messageBuilder2);
					EndGoalWith(GoalCondition.Error);
					return;
				}
			}
			if (CurrentAction != null && CurrentAction == currentAction && State == GoalState.Running && currentAction.CompleteMode == ActionCompleteMode.Instant && !currentAction.HasCompleted)
			{
				CurrentAction.Complete(ActionCompletionStatus.Success);
			}
		}

		private bool CheckEndOrFail()
		{
			if (CurrentAction.HasCompleted && CurrentAction.WaitingForAnimation)
			{
				return false;
			}
			foreach (Func<GoalCondition> endingCondition in CurrentAction.EndingConditions)
			{
				GoalCondition goalCondition = endingCondition();
				if (goalCondition != GoalCondition.OnGoing && goalCondition != GoalCondition.None)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(51, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Goal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("CheckEndOrFail ended goal '");
						messageBuilder.AppendFormatted(Id);
						messageBuilder.AppendLiteral("' on condition function ");
						messageBuilder.AppendFormatted(endingCondition);
					}
					Log.Trace(messageBuilder);
					EndGoalWith(goalCondition);
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		private bool ActionPreTick()
		{
			GoapAction currentAction = CurrentAction;
			foreach (Action preTickAction in currentAction.PreTickActions)
			{
				preTickAction();
				if (currentAction != CurrentAction)
				{
					return true;
				}
			}
			return state == GoalState.Ended;
		}

		private void ReleaseTargetReservation(TargetObject target)
		{
			if (target.IsInitialized && target.ObjectInstance is IReservable && MonoSingleton<ReservationManager>.IsInstantiated())
			{
				MonoSingleton<ReservationManager>.Instance.ReleaseObject(target.GetAsReservable(), AgentOwner);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.Goap
{
	public class GoapAction
	{
		public delegate void ActionCallback();

		public delegate void ActionCompleteCallback(ActionCompletionStatus status);

		public delegate void ActionTickCallback(float delta);

		private string id;

		private Goal goal;

		private ActionCompleteMode completeMode = ActionCompleteMode.Instant;

		private List<Action> preTickActions = new List<Action>();

		private List<Func<GoalCondition>> endingConditions = new List<Func<GoalCondition>>();

		private float totalTickingTime;

		private int actionStartFrameTime;

		private bool hasCompleted;

		private bool completeCallbackExecuted;

		private int waitingForAnimation;

		private float duration;

		private ActionCompletionStatus completionStatus;

		public IGoapAgentOwner AgentOwner => goal?.Agent?.AgentOwner;

		public string Id => id;

		public Goal Goal => goal;

		public float TotalTickingTime => totalTickingTime;

		public float ActionStartFrameTime => actionStartFrameTime;

		public bool HasCompleted => hasCompleted;

		public bool WaitingForAnimation => waitingForAnimation > 0;

		public ActionCompletionStatus CompletionStatus => completionStatus;

		public ActionCompleteMode CompleteMode
		{
			get
			{
				return completeMode;
			}
			internal set
			{
				completeMode = value;
			}
		}

		public ActionCallback OnInit
		{
			set
			{
				OnInitEvent += value;
			}
		}

		public ActionCallback OnPreInit
		{
			set
			{
				OnPreInitEvent += value;
			}
		}

		public ActionCallback OnPostInit
		{
			set
			{
				OnPostInitEvent += value;
			}
		}

		public Action OnPreTick
		{
			set
			{
				PreTickActions.Add(value);
			}
		}

		public ActionTickCallback OnTick
		{
			set
			{
				OnTickEvent += value;
			}
		}

		public ActionCompleteCallback OnComplete
		{
			set
			{
				OnCompleteEvent += value;
			}
		}

		public float Duration
		{
			get
			{
				return duration;
			}
			internal set
			{
				duration = value;
			}
		}

		internal List<Action> PreTickActions => preTickActions;

		internal List<Func<GoalCondition>> EndingConditions => endingConditions;

		private event ActionCallback OnPreInitEvent;

		private event ActionCallback OnInitEvent;

		private event ActionCallback OnPostInitEvent;

		private event ActionTickCallback OnTickEvent;

		private event ActionCompleteCallback OnCompleteEvent;

		public GoapAction(string id)
		{
			this.id = id;
		}

		public void AddPreTickAction(Action action)
		{
			preTickActions.Add(action);
		}

		public void AddGoalEndingCondition(Func<GoalCondition> func)
		{
			endingConditions.Add(func);
		}

		public void Init()
		{
			hasCompleted = false;
			totalTickingTime = 0f;
			actionStartFrameTime = Time.frameCount;
			completeCallbackExecuted = false;
			this.OnPreInitEvent?.Invoke();
			if (!hasCompleted)
			{
				this.OnInitEvent?.Invoke();
			}
			if (!hasCompleted)
			{
				this.OnPostInitEvent?.Invoke();
			}
		}

		public void Tick(float deltaTime)
		{
			if (hasCompleted)
			{
				if (!WaitingForAnimation)
				{
					Complete(CompletionStatus);
				}
			}
			else if (CompleteMode == ActionCompleteMode.Delay && TotalTickingTime >= duration)
			{
				Complete(ActionCompletionStatus.Success);
			}
			else if (completeMode == ActionCompleteMode.Instant)
			{
				Log.Warning("Tried to tick instant goal action!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoapAction.cs");
				Complete(ActionCompletionStatus.Error);
			}
			else
			{
				this.OnTickEvent?.Invoke(deltaTime);
				totalTickingTime += deltaTime;
			}
		}

		public void Complete(ActionCompletionStatus status)
		{
			if (completeCallbackExecuted)
			{
				return;
			}
			hasCompleted = true;
			completionStatus = status;
			if (WaitingForAnimation && Goal.State != GoalState.Ended)
			{
				return;
			}
			completeCallbackExecuted = true;
			this.OnCompleteEvent?.Invoke(status);
			if (status == ActionCompletionStatus.Fail || status == ActionCompletionStatus.Error)
			{
				if (Goal.ForcedNextAction == null || goal.ForcedNextAction == this)
				{
					Goal.EndGoalWith(GoalCondition.Incompletable);
				}
			}
			else
			{
				goal.ReadyForNextAction();
			}
		}

		internal void SetGoal(Goal goal)
		{
			this.goal = goal;
		}

		internal void AnimationBlockCompletition()
		{
			waitingForAnimation++;
		}

		internal void AnimationUnblockCompletition()
		{
			waitingForAnimation--;
		}
	}
}

using System;
using System.Collections;

namespace CTS.BBT.AI
{
	public class WorkerChoreHub : WorkerChore
	{
		public static readonly Func<WorkerChoreHub, Type, bool> HasActionOfType = (WorkerChoreHub hub, Type type) => hub.Action.GetType() == type;

		public AgentHubAction Action { get; }

		private WorkerChoreHub()
			: base(ChoreCategory.Default)
		{
		}

		public WorkerChoreHub(ChoreCategory p_category, AgentHubAction action, RoomObject target = null)
			: base(p_category, target)
		{
			Action = action;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return Action.CanBePerformed(p_agentRef);
		}

		public override string GetDisplayName()
		{
			return Action.GetDisplayName();
		}

		public override void OnStart()
		{
			Action.Priority = Priority;
			Action.Stopped = false;
			Action.SetAgent(base.ActionAgent);
			Action.OnStart();
			AgentAction.LinkCancellationOneSide(Action, this);
			if (base.Stopped)
			{
				CancelAction("Chore hub is stopped");
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!Action.Completed)
			{
				CancelAction("Action isn't complete and shouldn't be in wait routine");
			}
			yield return Action.WaitForRoutine();
		}

		public override IEnumerator ActionRoutine()
		{
			yield return Action.ActionRoutine();
		}

		public override void OnComplete()
		{
			base.OnComplete();
			Action.OnComplete();
		}

		public override void OnCancel()
		{
			base.OnCancel();
			Action.CancelAction("Cancelled from chore hub");
		}

		protected override void OnStopped()
		{
			Action.OnStoppedInternal();
		}

		protected override void OnDestroy()
		{
		}

		public override void ClearAgent()
		{
			base.ClearAgent();
			Action.ClearAgent();
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			Action.OnRemovedFromQueue();
		}
	}
}

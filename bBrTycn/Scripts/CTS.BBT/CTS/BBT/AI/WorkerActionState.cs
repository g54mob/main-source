namespace CTS.BBT.AI
{
	internal sealed class WorkerActionState<T> : WorkerState where T : Agent
	{
		private readonly AgentAction<T> _action;

		public WorkerActionState(AgentAction<T> p_action)
		{
			_action = p_action;
		}

		public override void OnStateEnter()
		{
			if (_action != null)
			{
				base.parent.ActionPlayer.CurrentAction?.CancelAction("Cancelled from another action starting");
				base.parent.ActionPlayer.Play(_action);
			}
		}

		public override void SpreadUpdate()
		{
		}

		public override void Update()
		{
			if (base.parent.ActionPlayer.CurrentAction == null)
			{
				base.fsm.SetState<WorkerIdleState>();
			}
		}

		private void PlayAction(AgentAction action)
		{
			if (!(action is WorkerAction p_action))
			{
				if (action is AgentAction<Agent> p_action2)
				{
					base.fsm.SetState(new WorkerActionState<Agent>(p_action2));
				}
			}
			else
			{
				base.fsm.SetState(new WorkerActionState<Worker>(p_action));
			}
		}

		public override void OnStateExit()
		{
			base.parent.ActionPlayer.CurrentAction?.CancelAction("Exit action state");
		}
	}
}

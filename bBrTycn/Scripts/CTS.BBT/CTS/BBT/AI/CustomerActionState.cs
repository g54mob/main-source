namespace CTS.BBT.AI
{
	internal sealed class CustomerActionState<T> : CustomerState where T : Agent
	{
		private readonly AgentAction<T> _action;

		public CustomerActionState(AgentAction<T> p_action)
		{
			_action = p_action;
		}

		public override void OnStateEnter()
		{
			if (_action != null)
			{
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
				base.fsm.SetState<CustomerIdleState>();
			}
		}

		public override void OnStateExit()
		{
			base.parent.ActionPlayer.CurrentAction?.CancelAction("exited action state");
		}
	}
}

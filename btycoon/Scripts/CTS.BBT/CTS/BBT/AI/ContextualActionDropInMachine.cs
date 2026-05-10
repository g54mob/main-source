namespace CTS.BBT.AI
{
	public class ContextualActionDropInMachine : ContextualAction<MachineBase>
	{
		private ActionHubDropInMachine _action;

		public override void Setup()
		{
			_action = new ActionHubDropInMachine(contextActor);
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return false;
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			if (!p_worker.IsEngaged)
			{
				return false;
			}
			return _action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(_action, EActionPriority.Player);
		}
	}
}

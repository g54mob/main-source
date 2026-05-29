namespace CTS.BBT.AI
{
	public class ActionHubDropInMachine : AgentHubAction
	{
		private Agent _victim;

		private readonly MachineBase _machine;

		private readonly AgentActionWakeUpAgent _wakeUpAction;

		private readonly WorkerActionLoadMachine _loadMachine;

		public ActionHubDropInMachine(MachineBase machine)
		{
			_machine = machine;
			AgentActionDropOnGround action = new AgentActionDropOnGround(_machine.LoadingPosition.Position);
			AddScoredAction(action, CalculateDropOnGround);
			_wakeUpAction = new AgentActionWakeUpAgent(null);
			AddScoredAction(_wakeUpAction, CalculateWakeUp);
			_loadMachine = new WorkerActionLoadMachine(_machine, null);
			AddScoredAction(_loadMachine, CalculateLoadInMachine);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return _machine.HasAVictim;
		}

		private int CalculateDropOnGround(Agent agent)
		{
			return -1;
		}

		private int CalculateWakeUp(Agent agent)
		{
			if (!_victim)
			{
				return -1;
			}
			if (_victim.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>())
			{
				_wakeUpAction.Target = _victim;
				return 80;
			}
			return -1;
		}

		private int CalculateLoadInMachine(Agent agent)
		{
			if (!_victim)
			{
				return -1;
			}
			if (_victim.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() || _victim.ActionPlayer.HasAnyActionOfType<AgentActionWakeUpAgent>())
			{
				_loadMachine.Victim = (Customer)_victim;
				return 60;
			}
			return -1;
		}
	}
}

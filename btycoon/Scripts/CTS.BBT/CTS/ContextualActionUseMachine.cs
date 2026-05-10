using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	internal class ContextualActionUseMachine : ContextualAction<MachineBase>
	{
		private WorkerActionLoadMachine _loadMachine;

		private AgentActionUseMachine _useMachine;

		private bool _load;

		public override void Setup()
		{
			_loadMachine = new WorkerActionLoadMachine(contextActor, null);
			_useMachine = new AgentActionUseMachine(contextActor);
			_load = false;
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return contextActor.HasAVictim;
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			if (!contextActor.CanBeUsed(p_worker))
			{
				return false;
			}
			if (_useMachine.CanBePerformed(p_worker))
			{
				return true;
			}
			if (!contextActor.IsAvailable)
			{
				return false;
			}
			if (!p_worker.ControlledHuman)
			{
				return false;
			}
			if (p_worker.ControlledHuman.HasTag(BBTAgentTags.NoReview))
			{
				return false;
			}
			_loadMachine.Victim = p_worker.ControlledHuman;
			if (!_loadMachine.CanBePerformed(p_worker))
			{
				return false;
			}
			if (contextActor.HasAVictim)
			{
				return false;
			}
			contextActor.SetVictim(p_worker.ControlledHuman);
			_load = _useMachine.CanBePerformed(p_worker);
			contextActor.SetVictim(null);
			return _load;
		}

		protected override void Execution(Worker p_worker)
		{
			if (_load)
			{
				p_worker.ActionPlayer.ForceAction(_loadMachine, EActionPriority.Player);
				p_worker.ActionPlayer.AddAction(_useMachine);
			}
			else
			{
				p_worker.ActionPlayer.ForceAction(_useMachine, EActionPriority.Player);
			}
		}
	}
}

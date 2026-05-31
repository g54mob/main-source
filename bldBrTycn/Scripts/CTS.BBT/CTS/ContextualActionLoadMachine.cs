using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	internal class ContextualActionLoadMachine : ContextualAction<MachineBase>
	{
		private WorkerActionLoadMachine _loadMachine;

		public override void Setup()
		{
			_loadMachine = new WorkerActionLoadMachine(contextActor, null);
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
			if (!p_worker.ControlledHuman)
			{
				return false;
			}
			if (p_worker.ControlledHuman.HasTag(BBTAgentTags.NoReview))
			{
				return false;
			}
			if (contextActor.TryGetComponent<Cell>(out var component) && component.IsReserved)
			{
				return false;
			}
			_loadMachine.Victim = p_worker.ControlledHuman;
			return _loadMachine.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			_loadMachine.Victim = p_worker.ControlledHuman;
			p_worker.ActionPlayer.ForceAction(_loadMachine, EActionPriority.Player);
		}
	}
}

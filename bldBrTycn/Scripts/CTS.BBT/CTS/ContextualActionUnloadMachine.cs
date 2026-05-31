using System;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	[Serializable]
	internal class ContextualActionUnloadMachine : ContextualAction<MachineBase>
	{
		private WorkerActionUnloadMachine _action;

		public override void Setup()
		{
			_action = new WorkerActionUnloadMachine(contextActor);
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

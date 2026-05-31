using System;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	[Serializable]
	internal sealed class ContextualActionTheDipBodyDrop : ContextualAction<TheDip>
	{
		private WorkerActionTheDipBodyDrop _action;

		public override void Setup()
		{
			_action = new WorkerActionTheDipBodyDrop(contextActor);
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return false;
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			return _action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(_action, EActionPriority.Player);
			Setup();
		}
	}
}

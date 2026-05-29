using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionWipeMemory : ContextualAction<Customer>
	{
		private WorkerActionWipeMemory _action;

		public override void Setup()
		{
			_action = new WorkerActionWipeMemory(contextActor);
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

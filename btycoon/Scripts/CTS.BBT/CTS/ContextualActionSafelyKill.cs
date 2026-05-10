using System;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	[Serializable]
	public class ContextualActionSafelyKill : ContextualAction<Customer>
	{
		private ActionHubKillSafely _action = new ActionHubKillSafely();

		public override void Setup()
		{
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			_action.Target = contextActor;
			return _action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(_action, EActionPriority.Player);
			_action = new ActionHubKillSafely();
			_action.Target = contextActor;
		}
	}
}

using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal class ContextualActionSuckBlood : ContextualAction<Customer>
	{
		protected AgentActionSuckBlood action;

		public override void Setup()
		{
			action = new AgentActionSuckBlood(contextActor);
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			return action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(action, EActionPriority.Player);
			Setup();
		}
	}
}

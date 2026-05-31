using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	internal class ContextualActionWakeUp : ContextualAction<Customer>
	{
		public override void Setup()
		{
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			return contextActor.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>();
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(new AgentActionWakeUpAgent(contextActor), EActionPriority.Player);
		}
	}
}

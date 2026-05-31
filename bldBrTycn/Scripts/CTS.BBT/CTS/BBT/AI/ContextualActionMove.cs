using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionMove : ContextualAction<ContextualActionsInput>
	{
		public override void Setup()
		{
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
			return contextActor.SelectionHitPoint.HasValue;
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(new AgentActionMove(contextActor.SelectionHitPoint.Value, playBlockedAction: true), EActionPriority.Player);
		}
	}
}

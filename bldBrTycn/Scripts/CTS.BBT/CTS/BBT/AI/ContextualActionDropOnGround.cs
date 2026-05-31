using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionDropOnGround : ContextualAction<ContextualActionsInput>
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
			if (!contextActor.SelectionHitPoint.HasValue)
			{
				return false;
			}
			if (contextActor.SelectionHitPoint.HasValue)
			{
				return p_worker.ObjectHolding.IsCurrentlyHolding;
			}
			return false;
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(new AgentActionDropOnGround(contextActor.SelectionHitPoint.Value), EActionPriority.Player);
		}
	}
}

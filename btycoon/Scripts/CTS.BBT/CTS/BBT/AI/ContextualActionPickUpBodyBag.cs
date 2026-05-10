using System;
using CTS.Core.Pooling;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionPickUpBodyBag : ContextualAction<BodyBag>
	{
		private AgentActionPickUpBodyBag _action;

		public override void Setup()
		{
			_action = new AgentActionPickUpBodyBag(contextActor);
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			_action.Item = new PooledRef<Item>(contextActor);
			return _action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(_action, EActionPriority.Player);
			Setup();
		}
	}
}

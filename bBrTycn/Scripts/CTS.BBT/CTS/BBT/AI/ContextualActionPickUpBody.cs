using System;
using CTS.Core;

namespace CTS.BBT.AI
{
	[Serializable]
	internal class ContextualActionPickUpBody : ContextualAction<Customer>
	{
		private AgentActionPickUpBody _pickupAction;

		public override void Setup()
		{
			_pickupAction = new AgentActionPickUpBody(contextActor);
		}

		public override bool CanBePerformed(Worker worker)
		{
			if (!worker.IsEngaged)
			{
				return false;
			}
			if (contextActor.ContextActorData.TryGetChore<WorkerChorePickUpBody>(out var outChore) && outChore.Status > AgentAction.EStatus.Wait)
			{
				return false;
			}
			return _pickupAction.CanBePerformed(worker);
		}

		protected override void Execution(Worker worker)
		{
			if (contextActor.ContextActorData.TryGetChore<WorkerChorePickUpBody>(out var outChore))
			{
				if (outChore.Status <= AgentAction.EStatus.Wait)
				{
					outChore.CancelAction("another agent got the chore");
					MonoSingleton<ChoreList>.Instance.RemoveChore(outChore);
					worker.ActionPlayer.ForceAction(outChore, EActionPriority.Player);
				}
			}
			else
			{
				worker.ActionPlayer.ForceAction(_pickupAction, EActionPriority.Player);
				Setup();
			}
		}
	}
}

using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class ContextualActionDeliverOrder : ContextualAction<Customer>
	{
		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.DrinkServed);
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			if (contextActor.CurrentOrder == null)
			{
				return false;
			}
			if (!contextActor.GroupData.AssignedTable)
			{
				return false;
			}
			if (contextActor.GroupData.AssignedTable.ContextActorData.TryGetChore<WorkerChorePlateDelivery>(out var outChore))
			{
				return outChore.CanBePerformed(p_worker);
			}
			return false;
		}

		protected override void Execution(Worker p_worker)
		{
			if (contextActor.GroupData.AssignedTable.ContextActorData.TryGetChore<WorkerChorePlateDelivery>(out var outChore) && !(outChore.ActionAgent == p_worker))
			{
				outChore.CancelAction("another worker got the chore");
				p_worker.ActionPlayer.ForceAction(outChore, EActionPriority.Player);
			}
		}
	}
}

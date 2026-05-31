using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class ContextualActionTakeOrder : ContextualAction<Customer>
	{
		public override void Setup()
		{
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
			if (contextActor.GroupData.AssignedTable.ContextActorData.TryGetChore(out var outChore, WorkerChoreHub.HasActionOfType, typeof(ActionHubGroupOrder)))
			{
				return outChore.CanBePerformed(p_worker);
			}
			return false;
		}

		protected override void Execution(Worker p_worker)
		{
			if (contextActor.GroupData.AssignedTable.ContextActorData.TryGetChore(out var outChore, WorkerChoreHub.HasActionOfType, typeof(ActionHubGroupOrder)) && !(outChore.ActionAgent == p_worker))
			{
				outChore.CancelAction("another agent got the chore");
				p_worker.ActionPlayer.ForceAction(outChore, EActionPriority.Player);
			}
		}
	}
}

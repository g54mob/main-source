using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Draft
{
	public class DraftOrderEquip : DraftOrder
	{
		private ResourcePileInstance pile;

		private WorkerGoapAgent agent;

		public DraftOrderEquip(ResourcePileInstance pile)
			: base(DraftOrderType.EquipItem)
		{
			this.pile = pile;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			agent = instance.GetGoapAgent() as WorkerGoapAgent;
			if (agent.CurrentGoalName.Equals("EquipGoal"))
			{
				agent.Abort();
			}
			return true;
		}

		public override void Execute(HumanoidInstance instance)
		{
			if (!pile.HasDisposed && pile.GetStoredResource() != null)
			{
				if (instance.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					instance.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
				}
				instance.Inventory.ClearEquipOrders();
				MonoSingleton<ResourcePileController>.Instance.EquipOrderUpdate(pile, instance, active: true);
				instance.WorkerBehaviour.ShowPathDestinationLine(pile.GetPosition());
				agent.ForceNextGoal("EquipGoal");
			}
		}
	}
}

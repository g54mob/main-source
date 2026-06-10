using NSMedieval.State;

namespace NSMedieval
{
	public class InteractedWithEquipment : EventInteraction
	{
		public InteractedWithEquipment()
		{
			base.InteractionType = EventInteractionType.InteractedWithEquipment;
		}

		public override bool IsPossible(CreatureBase agent, int agentUniqueId, out CreatureBase target)
		{
			target = GlobalSaveController.CurrentVillageData.GetWorkerByCreationID(agentUniqueId);
			if (target == null || target == agent)
			{
				return false;
			}
			return IsPossible(agent, target);
		}

		public override bool IsPossible(CreatureBase agent, CreatureBase target)
		{
			if (!(agent is HumanoidInstance) || !(target is HumanoidInstance))
			{
				return false;
			}
			return true;
		}
	}
}

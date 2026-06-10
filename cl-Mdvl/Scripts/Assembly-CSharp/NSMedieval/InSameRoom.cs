using NSMedieval.State;

namespace NSMedieval
{
	public class InSameRoom : EventInteraction
	{
		public InSameRoom()
		{
			base.InteractionType = EventInteractionType.InSameRoom;
		}

		public override bool IsPossible(CreatureBase agent, out CreatureBase target)
		{
			target = agent.GetRandomFromSameRoom<HumanoidInstance>();
			if (target == null)
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

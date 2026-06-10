using NSMedieval.State;

namespace NSMedieval
{
	public class DidActivityTogether : EventInteraction
	{
		public DidActivityTogether()
		{
			base.InteractionType = EventInteractionType.DidActivityTogether;
		}

		public override bool IsPossible(CreatureBase agent, out CreatureBase target)
		{
			target = agent.GetClosestWithSameGoal<HumanoidInstance>();
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

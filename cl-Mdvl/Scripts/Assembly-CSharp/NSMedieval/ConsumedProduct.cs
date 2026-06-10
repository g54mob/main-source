using NSMedieval.State;

namespace NSMedieval
{
	public class ConsumedProduct : EventInteraction
	{
		public ConsumedProduct()
		{
			base.InteractionType = EventInteractionType.ConsumedProduct;
		}

		public override bool IsPossible(CreatureBase agent, CreatureBase target)
		{
			if (agent == target)
			{
				return false;
			}
			if (!(agent is HumanoidInstance) || !(target is HumanoidInstance))
			{
				return false;
			}
			return true;
		}
	}
}

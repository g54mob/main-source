using NSMedieval.State;

namespace NSMedieval
{
	public class WitnessedActivity : EventInteraction
	{
		public WitnessedActivity()
		{
			base.InteractionType = EventInteractionType.WitnessedActivity;
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

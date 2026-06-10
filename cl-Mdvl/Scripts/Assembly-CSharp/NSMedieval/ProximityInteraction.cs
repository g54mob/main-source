using NSMedieval.State;
using NSMedieval.Village;

namespace NSMedieval
{
	public abstract class ProximityInteraction
	{
		public ProximityInteractionType InteractionType { get; protected set; }

		public virtual bool IsPossible(CreatureBase agent, CreatureBase target)
		{
			return false;
		}

		public virtual bool IsPossible(CreatureBase agent, WorldObject target)
		{
			return false;
		}

		public virtual bool Execute(CreatureBase agent, CreatureBase target)
		{
			agent.OnProximityEvent(target);
			target.OnProximityEvent(agent);
			return true;
		}

		public virtual bool Execute(CreatureBase agent, WorldObject target)
		{
			return true;
		}
	}
}

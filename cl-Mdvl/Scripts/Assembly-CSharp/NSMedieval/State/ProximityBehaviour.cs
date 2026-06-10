using NSMedieval.Village;

namespace NSMedieval.State
{
	public abstract class ProximityBehaviour
	{
		protected HumanoidInstance HumanoidInstance;

		protected ProximityBehaviour(HumanoidInstance humanoidInstance)
		{
			HumanoidInstance = humanoidInstance;
		}

		public void SetHumanoidInstance(HumanoidInstance humanoid)
		{
			HumanoidInstance = humanoid;
		}

		public abstract void HandleOnWorldObjectEnterProximity(WorldObject worldObject);

		public abstract void HandleOnWorldObjectExitProximity(WorldObject worldObject);

		public abstract void HandleOnCreatureEnterProximity(CreatureBase creature);
	}
}

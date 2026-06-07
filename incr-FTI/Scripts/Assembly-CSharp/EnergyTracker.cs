public class EnergyTracker : CountableState
{
	public ItemType energyType;

	public float energyPerSecond;

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(energyType);
	}

	public EnergyTracker(ItemType t)
	{
		energyType = t;
	}

	public void UpdateSimulation()
	{
		TryAdd(energyPerSecond * TimeManager.SimulationDelta);
	}
}

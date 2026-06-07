public class AutoHarvestState : StateManager
{
	public BuildingState building;

	public ResourceState resource;

	public ItemState harvestedItem;

	public const float baseProductionSpeed = 1f;

	public const float outputsProducedPerUnit = 1f;

	public const float inputsConsumedPerUnit = 1f;

	public override EntityId AsEntity()
	{
		return EntityId.FromBuilding(building.type);
	}

	public override void CalcPotentialWorkPerSimulationPass()
	{
		potentialWorkUnits = (double)TimeManager.SimulationDelta * building.currentCount;
	}

	public void Load(BuildingState buildingState, ResourceState source, ItemState destination)
	{
		building = buildingState;
		resource = source;
		harvestedItem = destination;
		RemoveSelfFromRequesters();
		input.Clear();
		inputCount = 0;
		AddInput(source, 1.0, 1f);
		output.Clear();
		outputCount = 0;
		AddOutput(destination, 1.0, 1f);
	}
}

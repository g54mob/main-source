using Unity.Entities;

public struct DurabilityCD : IComponentData, IQueryTypeParameter
{
	public int maxDurability;

	public float repairCostMultiplier;

	public float reinforceCostMultiplier;

	public bool IsReinforced(int amount)
	{
		return amount > maxDurability;
	}
}

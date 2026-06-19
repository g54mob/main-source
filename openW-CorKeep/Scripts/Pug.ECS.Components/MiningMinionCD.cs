using Unity.Entities;

public struct MiningMinionCD : IComponentData, IQueryTypeParameter
{
	public int damage;

	public float damageMultiplier;
}

using Unity.Entities;
using Unity.Mathematics;

public struct DropsLootWhenDamagedCD : IComponentData, IQueryTypeParameter
{
	public int damageToDealToDropLoot;

	public int minHealthToDropLoot;

	public ObjectID dropsLoot;

	public bool instantiateEntity;

	public float2 minSpawnOffset;

	public float2 maxSpawnOffset;

	public float2 dropLootPosition;

	public int maxLimitToDropInNearbyArea;
}

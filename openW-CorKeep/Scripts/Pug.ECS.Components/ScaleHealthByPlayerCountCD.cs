using Unity.Entities;

public struct ScaleHealthByPlayerCountCD : IComponentData, IQueryTypeParameter
{
	public int initialMaxHealth;

	public float scalingFactor;
}

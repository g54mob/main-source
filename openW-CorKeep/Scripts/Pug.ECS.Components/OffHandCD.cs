using Unity.Entities;

public struct OffHandCD : IComponentData, IQueryTypeParameter
{
	public OffHandMechanic mechanic;

	public float mechanicValue;

	public float mechanicMultiplier;
}

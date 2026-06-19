using Unity.Entities;

public struct PortalCD : IComponentData, IQueryTypeParameter
{
	public float accumulationTimer;
}

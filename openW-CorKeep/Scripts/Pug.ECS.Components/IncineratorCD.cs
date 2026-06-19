using Unity.Entities;

public struct IncineratorCD : IComponentData, IQueryTypeParameter
{
	public float defaultIncinerationTime;
}

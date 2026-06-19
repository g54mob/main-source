using Unity.Entities;

public struct KeepAreaLoadedCD : IComponentData, IQueryTypeParameter
{
	public float KeepLoadedRadius;

	public float StartLoadRadius;

	public float ImmediateLoadRadius;
}

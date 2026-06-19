using Unity.Entities;

public struct RandomWalkGravityWellCD : IComponentData, IQueryTypeParameter
{
	public uint attractMask;

	public float radius;

	public float timer;
}

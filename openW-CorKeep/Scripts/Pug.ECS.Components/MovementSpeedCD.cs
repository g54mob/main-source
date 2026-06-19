using Unity.Entities;
using Unity.NetCode;

public struct MovementSpeedCD : IComponentData, IQueryTypeParameter
{
	public float speed;

	[GhostField]
	public float originalSpeed;
}

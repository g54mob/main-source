using Unity.Entities;
using Unity.NetCode;

public struct ProjectileSetupCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int damage;

	public float directionRadians;

	[GhostField]
	public bool isMagic;
}

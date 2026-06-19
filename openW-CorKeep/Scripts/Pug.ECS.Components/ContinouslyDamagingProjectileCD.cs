using Unity.Entities;
using Unity.NetCode;

public struct ContinouslyDamagingProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer attackCooldown;

	public float attackEveryXSecond;
}

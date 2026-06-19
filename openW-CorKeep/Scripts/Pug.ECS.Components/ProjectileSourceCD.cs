using Unity.Entities;
using Unity.NetCode;

public struct ProjectileSourceCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int weaponLevel;

	[GhostField]
	public bool shotFromReinforcedWeapon;

	[GhostField]
	public sbyte sequenceExplosionTotalExplosions;
}

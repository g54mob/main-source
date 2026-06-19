using Unity.Entities;
using Unity.NetCode;

public struct BeamWeaponAttackCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer beamWeaponActiveTimer;

	[GhostField]
	public TickTimer specialAttackCooldown;

	[GhostField]
	public NetworkTick lastContiniousActivateTick;
}

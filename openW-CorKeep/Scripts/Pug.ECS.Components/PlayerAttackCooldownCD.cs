using Unity.Entities;
using Unity.NetCode;

public struct PlayerAttackCooldownCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer cooldown;
}

using Unity.Entities;
using Unity.NetCode;

public struct PlayerInvincibilityCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool isInvincible;
}

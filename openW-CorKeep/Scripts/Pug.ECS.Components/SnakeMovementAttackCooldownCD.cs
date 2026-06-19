using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SnakeMovementAttackCooldownCD : IComponentData, IQueryTypeParameter
{
	public float attackCooldown;
}

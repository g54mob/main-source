using Unity.Entities;

public struct PlayerGhostExtrapolated : IComponentData, IQueryTypeParameter
{
	public Entity playerGhost;
}

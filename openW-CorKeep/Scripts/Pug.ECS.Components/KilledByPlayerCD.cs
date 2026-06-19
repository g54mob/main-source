using Unity.Entities;

public struct KilledByPlayerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public Entity playerEntity;

	public bool shouldPullLootToPlayer;

	public bool killedByPlayerExplosion;
}

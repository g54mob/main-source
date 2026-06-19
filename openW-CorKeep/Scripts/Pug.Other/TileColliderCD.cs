using Unity.Entities;

public struct TileColliderCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float despawnTimestamp;

	public bool isShoreLine;

	public bool needsRefreshfromAdjacentTileChange;
}

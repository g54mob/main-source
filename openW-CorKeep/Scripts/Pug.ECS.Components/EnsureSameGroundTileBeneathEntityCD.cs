using PugTilemap;
using Unity.Entities;

public struct EnsureSameGroundTileBeneathEntityCD : IComponentData, IQueryTypeParameter
{
	public TileType tileType;

	public Tileset fallbackTileset;

	public int delayCounter;

	public bool continouslyCheck;

	public float continousUpdateTimer;

	public bool disabled;

	public bool ignoreCheckingWhileInState;

	public StateID stateToIgnore;
}

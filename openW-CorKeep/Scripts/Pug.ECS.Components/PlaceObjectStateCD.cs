using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;

public struct PlaceObjectStateCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectToPlace;

	public TileType placeOnTileType;

	public bool placeOnAnyTileset;

	public Tileset placeOnTileset;

	public float placeDuration;

	public float minCooldown;

	public float maxCooldown;

	public bool onlyPlaceWhenInCombatWithPlayer;

	public int maxObjectsToPlace;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;
}

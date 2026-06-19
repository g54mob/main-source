using PugTilemap;
using UnityEngine;

public class PlaceObjectStateAuthoring : MonoBehaviour
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
}

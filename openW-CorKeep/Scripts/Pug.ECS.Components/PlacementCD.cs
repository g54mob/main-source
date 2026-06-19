using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct PlacementCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool canPlaceObject;

	[GhostField]
	public int3 bestPositionToPlaceAt;

	[GhostField]
	public TickTimer timeSincePlaced;

	[GhostField]
	public int3 positionLastPlacedAt;

	[GhostField]
	public TileType previouslyPlacedTileType;

	[GhostField]
	public int currentPrefabVariation;

	[GhostField]
	public bool placeObjectOnWall;

	[GhostField]
	public int2 wallSideToPlaceObject;

	[GhostField]
	public TickTimer tilePlacementTimer;

	[GhostField]
	public Entity waterSourceEntity;

	[GhostField]
	public Entity entityToPaint;

	[GhostField]
	public TileCD tileToPaint;

	[GhostField]
	public bool canPlaceGround;

	[GhostField]
	public bool canPlaceRoofHole;

	[GhostField]
	public int rotationVariationToPlace;

	[GhostField]
	public int nonRotationVariationToPlace;

	public bool canPlaceOnWalkableTiles;

	public bool isWalkableTile;

	public bool canPlaceOnWater;

	public bool canBePlacedOnLava;

	public bool canPlaceOnPit;

	public bool canPlaceOnSideOfWall;

	public bool canBePlacedOnPlayer;

	public bool canBePlacedOnBlockingObjects;

	public bool canBePlacedOnLowColliders;

	public bool blockedByObjectsOnWalls;
}

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class PlaceableObjectAuthoring : MonoBehaviour
{
	public Vector2Int prefabTileSize = Vector2Int.one;

	public Vector2Int prefabCornerOffset;

	public bool centerIsAtEntityPosition;

	public bool objectCanBeToggledToNewNonRotationOption;

	[ShowIf("objectCanBeToggledToNewNonRotationOption")]
	public int toggledToNewNonRotationOptions;

	public int variationToPlace;

	public bool canBePlacedOnPlayer;

	public bool canBePlacedOnAnyWalkableTile = true;

	public bool canBePlacedOnWater;

	public bool canBePlacedOnLava;

	public bool canBePlacedOnPit;

	public bool canBePlacedOnBlockingObjects;

	public bool canBePlacedOnLowColliders;

	public bool dontDestroyObjectIfInvalidPlacement;

	public bool canBePlacedOnImmuneTiles;

	public bool dontBlockRoots;

	public List<ObjectID> canBePlacedOnObjects;

	public List<ObjectID> canNotBePlacedOnObjects;

	[Header("Wall side placement settings:")]
	public bool hasVariationsThatCanBePlacedOnWalls;

	public bool canPlaceOnSideOfWall;

	public bool wallSideVariationStartsOnIndex1;

	public bool blocksHangingWallObjects;

	public bool appearInMapUI;

	public Color mapColor;

	public bool alignWithPlayerDirection;

	public DisplayPlaceableType displayPlaceableType;
}

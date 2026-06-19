using Pug.Conversion;
using PugFlora;

public class PlaceableObjectConverter : SingleAuthoringComponentConverter<PlaceableObjectAuthoring>
{
	protected override void Convert(PlaceableObjectAuthoring authoring)
	{
		if (!authoring.dontBlockRoots)
		{
			EnsureHasComponent<BlocksFlora>();
		}
		SetProperty("PlaceableObject/placeableObject");
		SetProperty("PlaceableObject/variationToPlace", authoring.variationToPlace);
		if (authoring.canBePlacedOnAnyWalkableTile)
		{
			SetProperty("PlaceableObject/canBePlacedOnAnyWalkableTile");
		}
		if (authoring.canBePlacedOnWater)
		{
			SetProperty("PlaceableObject/canBePlacedOnWater");
		}
		if (authoring.canBePlacedOnLava)
		{
			SetProperty("PlaceableObject/canBePlacedOnLava");
		}
		if (authoring.canBePlacedOnPit)
		{
			SetProperty("PlaceableObject/canBePlacedOnPit");
		}
		if (authoring.canBePlacedOnPlayer)
		{
			SetProperty("PlaceableObject/canBePlacedOnPlayer");
		}
		if (authoring.canBePlacedOnBlockingObjects)
		{
			SetProperty("PlaceableObject/canBePlacedOnBlockingObjects");
		}
		if (authoring.canBePlacedOnLowColliders)
		{
			SetProperty("PlaceableObject/canBePlacedOnLowColliders");
		}
		if (authoring.canBePlacedOnImmuneTiles)
		{
			SetProperty("PlaceableObject/canBePlacedOnImmuneTiles");
		}
		if (authoring.hasVariationsThatCanBePlacedOnWalls)
		{
			SetProperty("PlaceableObject/hasVariationsThatCanBePlacedOnWalls");
		}
		if (authoring.canPlaceOnSideOfWall)
		{
			SetProperty("PlaceableObject/canPlaceOnSideOfWall");
		}
		if (authoring.wallSideVariationStartsOnIndex1)
		{
			SetProperty("PlaceableObject/wallSideVariationStartsOnIndex1");
		}
		if (authoring.blocksHangingWallObjects)
		{
			SetProperty("PlaceableObject/blocksHangingWallObjects");
		}
		if (authoring.alignWithPlayerDirection)
		{
			SetProperty("PlaceableObject/alignWithPlayerDirection");
		}
		if (authoring.displayPlaceableType != DisplayPlaceableType.Default)
		{
			SetProperty("PlaceableObject/displayPlaceableType", authoring.displayPlaceableType);
		}
		if (authoring.canBePlacedOnObjects.Count > 0)
		{
			SetPropertyList("PlaceableObject/canBePlacedOnObjects", authoring.canBePlacedOnObjects.ToArray());
		}
		if (authoring.canNotBePlacedOnObjects.Count > 0)
		{
			SetPropertyList("PlaceableObject/canNotBePlacedOnObjects", authoring.canNotBePlacedOnObjects.ToArray());
		}
		if (authoring.objectCanBeToggledToNewNonRotationOption)
		{
			SetProperty("PlaceableObject/objectCanBeToggledToNewNonRotationOption");
			SetProperty("PlaceableObject/toggledToNewNonRotationOptions", authoring.toggledToNewNonRotationOptions);
		}
	}
}

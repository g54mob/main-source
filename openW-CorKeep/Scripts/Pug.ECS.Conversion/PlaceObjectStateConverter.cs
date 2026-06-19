using Pug.Conversion;

public class PlaceObjectStateConverter : SingleAuthoringComponentConverter<PlaceObjectStateAuthoring>
{
	protected override void Convert(PlaceObjectStateAuthoring authoring)
	{
		AddComponentData(new PlaceObjectStateCD
		{
			objectToPlace = authoring.objectToPlace,
			placeOnTileType = authoring.placeOnTileType,
			placeOnAnyTileset = authoring.placeOnAnyTileset,
			placeOnTileset = authoring.placeOnTileset,
			placeDuration = authoring.placeDuration,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			onlyPlaceWhenInCombatWithPlayer = authoring.onlyPlaceWhenInCombatWithPlayer,
			maxObjectsToPlace = authoring.maxObjectsToPlace
		});
	}
}

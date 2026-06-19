using Pug.Conversion;

public class DirectionBasedOnVariationConverter : SingleAuthoringComponentConverter<DirectionBasedOnVariationAuthoring>
{
	protected override void Convert(DirectionBasedOnVariationAuthoring authoring)
	{
		AddComponentData(new DirectionBasedOnVariationCD
		{
			direction = authoring.direction,
			alsoUpdateCollider = authoring.alsoUpdateCollider,
			alignWithNearbyAffectorsWhenPlaced = authoring.alignWithNearbyAffectorsWhenPlaced
		});
	}
}

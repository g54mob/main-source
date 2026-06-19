using Pug.Conversion;

public class ChangeVariationWhenObjectNearbyConverter : SingleAuthoringComponentConverter<ChangeVariationWhenObjectNearbyAuthoring>
{
	protected override void Convert(ChangeVariationWhenObjectNearbyAuthoring authoring)
	{
		AddComponentData(new ChangeVariationWhenObjectNearbyCD
		{
			objectID = authoring.objectID,
			objectNearbySpecificVariation = authoring.objectNearbySpecificVariation,
			objectNearbyVariation = authoring.objectNearbyVariation,
			offset = authoring.offset,
			radius = authoring.radius,
			variationToChangeTo = authoring.variationToChangeTo,
			triggerActivateAnimation = authoring.triggerActivateAnimation,
			ignorePlayerFaction = authoring.ignorePlayerFaction,
			dontRevertToOriginalVariation = authoring.dontRevertToOriginalVariation
		});
	}
}

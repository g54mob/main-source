using Pug.Conversion;

public class ChangeVariationWhenPlayerHoldObjectNearbyConverter : SingleAuthoringComponentConverter<ChangeVariationWhenPlayerHoldObjectNearbyAuthoring>
{
	protected override void Convert(ChangeVariationWhenPlayerHoldObjectNearbyAuthoring authoring)
	{
		AddComponentData(new ChangeVariationWhenPlayerHoldObjectNearbyCD
		{
			objectID = authoring.objectID,
			offset = authoring.offset,
			radius = authoring.radius,
			variationToChangeTo = authoring.variationToChangeTo,
			alsoRemoveCollider = authoring.alsoRemoveCollider
		});
		EnsureHasComponent<ResetColliderCD>();
	}
}

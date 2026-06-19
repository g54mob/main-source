using Pug.Conversion;

public class ChangeVariationWhenTookDamageConverter : SingleAuthoringComponentConverter<ChangeVariationWhenTookDamageAuthoring>
{
	protected override void Convert(ChangeVariationWhenTookDamageAuthoring authoring)
	{
		AddComponentData(new ChangeVariationWhenTookDamageCD
		{
			variationToChangeTo = authoring.variationToChangeTo
		});
	}
}

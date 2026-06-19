using Pug.Conversion;

public class AuraDistanceOverrideConverter : SingleAuthoringComponentConverter<AuraDistanceOverrideAuthoring>
{
	protected override void Convert(AuraDistanceOverrideAuthoring authoring)
	{
		AddComponentData(new AuraDistanceOverrideCD
		{
			distance = authoring.distance
		});
	}
}

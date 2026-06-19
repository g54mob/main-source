using Pug.Conversion;

public class ImmunityZoneAuthoringConverter : SingleAuthoringComponentConverter<ImmunityZoneAuthoring>
{
	protected override void Convert(ImmunityZoneAuthoring authoring)
	{
		AddComponentData(new ImmunityZoneCD
		{
			radius = authoring.radius,
			radiusSq = authoring.radius * authoring.radius,
			offset = authoring.tileOffset,
			useRectangularBounds = authoring.useRectangularBounds,
			rectangularWidth = authoring.rectangularWidth,
			rectangularHeight = authoring.rectangularHeight
		});
	}
}

using Pug.Conversion;

public class FlowerConverter : SingleAuthoringComponentConverter<FlowerAuthoring>
{
	protected override void Convert(FlowerAuthoring authoring)
	{
		AddComponentData(new FlowerCD
		{
			plantID = authoring.plantID,
			plantVariation = authoring.plantVariation
		});
	}
}

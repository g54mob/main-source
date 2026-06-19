using Pug.Conversion;

public class OffHandConverter : SingleAuthoringComponentConverter<OffHandAuthoring>
{
	protected override void Convert(OffHandAuthoring authoring)
	{
		AddComponentData(new OffHandCD
		{
			mechanic = authoring.mechanic,
			mechanicValue = authoring.mechanicValue,
			mechanicMultiplier = authoring.mechanicMultiplier
		});
	}
}

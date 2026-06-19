using Pug.Conversion;

public class GrowingPlantConverter : SingleAuthoringComponentConverter<GrowingPlantAuthoring>
{
	protected override void Convert(GrowingPlantAuthoring authoring)
	{
		EnsureHasComponent<GrowingPlantCD>();
	}
}

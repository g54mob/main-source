using Pug.Conversion;

public class SoulsConverter : SingleAuthoringComponentConverter<SoulsAuthoring>
{
	protected override void Convert(SoulsAuthoring authoring)
	{
		EnsureHasComponent<SoulsInfoCD>();
		EnsureHasBuffer<CollectedSoulsBuffer>();
		EnsureHasBuffer<SoulsConditionsBuffer>();
		EnsureHasComponent<CollectedAndEnabledSoulsMask>();
	}
}

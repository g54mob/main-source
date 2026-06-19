using Pug.Conversion;

public class AlwaysDropVariationZeroConverter : SingleAuthoringComponentConverter<AlwaysDropVariationZeroAuthoring>
{
	protected override void Convert(AlwaysDropVariationZeroAuthoring authoring)
	{
		EnsureHasComponent<AlwaysDropVariationZeroCD>();
	}
}

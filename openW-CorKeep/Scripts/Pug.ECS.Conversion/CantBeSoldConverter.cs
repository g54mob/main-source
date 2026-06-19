using Pug.Conversion;

public class CantBeSoldConverter : SingleAuthoringComponentConverter<CantBeSoldAuthoring>
{
	protected override void Convert(CantBeSoldAuthoring authoring)
	{
		EnsureHasComponent<CantBeSoldCD>();
	}
}

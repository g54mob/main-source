using Pug.Conversion;

public class NameConverter : SingleAuthoringComponentConverter<NameAuthoring>
{
	protected override void Convert(NameAuthoring authoring)
	{
		EnsureHasComponent<NameCD>();
	}
}

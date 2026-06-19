using Pug.Conversion;

public class AnvilConverter : SingleAuthoringComponentConverter<AnvilAuthoring>
{
	protected override void Convert(AnvilAuthoring authoring)
	{
		EnsureHasComponent<AnvilCD>();
	}
}

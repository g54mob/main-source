using Pug.Conversion;

public class WorldInfoConverter : SingleAuthoringComponentConverter<WorldInfoAuthoring>
{
	protected override void Convert(WorldInfoAuthoring authoring)
	{
		EnsureHasComponent<WorldInfoCD>();
	}
}

using Pug.Conversion;

public class TheCoreConverter : SingleAuthoringComponentConverter<TheCoreAuthoring>
{
	protected override void Convert(TheCoreAuthoring authoring)
	{
		EnsureHasComponent<TheCoreCD>();
	}
}

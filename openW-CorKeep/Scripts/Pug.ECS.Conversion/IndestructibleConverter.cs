using Pug.Conversion;

public class IndestructibleConverter : SingleAuthoringComponentConverter<IndestructibleAuthoring>
{
	protected override void Convert(IndestructibleAuthoring authoring)
	{
		EnsureHasComponent<IndestructibleCD>();
	}
}

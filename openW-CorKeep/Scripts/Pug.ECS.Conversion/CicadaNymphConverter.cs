using Pug.Conversion;

public class CicadaNymphConverter : SingleAuthoringComponentConverter<CicadaNymphAuthoring>
{
	protected override void Convert(CicadaNymphAuthoring authoring)
	{
		EnsureHasComponent<CicadaNymphCD>();
	}
}

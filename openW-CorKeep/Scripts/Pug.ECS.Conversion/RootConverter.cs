using Pug.Conversion;

public class RootConverter : SingleAuthoringComponentConverter<RootAuthoring>
{
	protected override void Convert(RootAuthoring authoring)
	{
		EnsureHasComponent<RootCD>();
	}
}

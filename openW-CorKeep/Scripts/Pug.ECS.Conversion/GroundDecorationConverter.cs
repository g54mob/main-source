using Pug.Conversion;

public class GroundDecorationConverter : SingleAuthoringComponentConverter<GroundDecorationAuthoring>
{
	protected override void Convert(GroundDecorationAuthoring authoring)
	{
		EnsureHasComponent<GroundDecorationCD>();
	}
}

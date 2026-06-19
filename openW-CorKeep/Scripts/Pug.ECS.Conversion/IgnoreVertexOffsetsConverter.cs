using Pug.Conversion;

public class IgnoreVertexOffsetsConverter : SingleAuthoringComponentConverter<IgnoreVertexOffsetsAuthoring>
{
	protected override void Convert(IgnoreVertexOffsetsAuthoring authoring)
	{
		EnsureHasComponent<IgnoreVertexOffsetsCD>();
	}
}

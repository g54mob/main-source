using Pug.Conversion;

public class CherryBlossomTreeConverter : SingleAuthoringComponentConverter<CherryBlossomTreeAuthoring>
{
	protected override void Convert(CherryBlossomTreeAuthoring authoring)
	{
		EnsureHasComponent<CherryBlossomTreeCD>();
	}
}

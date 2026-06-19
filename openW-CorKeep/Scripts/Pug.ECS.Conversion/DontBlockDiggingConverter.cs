using Pug.Conversion;

public class DontBlockDiggingConverter : SingleAuthoringComponentConverter<DontBlockDiggingAuthoring>
{
	protected override void Convert(DontBlockDiggingAuthoring authoring)
	{
		EnsureHasComponent<DontBlockDiggingCD>();
	}
}

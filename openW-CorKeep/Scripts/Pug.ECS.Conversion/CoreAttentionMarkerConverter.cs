using Pug.Conversion;

public class CoreAttentionMarkerConverter : SingleAuthoringComponentConverter<CoreAttentionMarkerAuthoring>
{
	protected override void Convert(CoreAttentionMarkerAuthoring authoring)
	{
		EnsureHasComponent<CoreAttentionMarkerCD>();
	}
}

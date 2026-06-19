using Pug.Conversion;

public class ConvertToTileConverter : SingleAuthoringComponentConverter<ConvertToTileAuthoring>
{
	protected override void Convert(ConvertToTileAuthoring authoring)
	{
		EnsureHasComponent<ConvertToTileCD>();
	}
}

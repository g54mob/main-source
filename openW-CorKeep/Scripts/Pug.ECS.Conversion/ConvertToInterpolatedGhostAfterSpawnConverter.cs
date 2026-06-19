using Pug.Conversion;

public class ConvertToInterpolatedGhostAfterSpawnConverter : SingleAuthoringComponentConverter<ConvertToInterpolatedGhostAfterSpawnAuthoring>
{
	protected override void Convert(ConvertToInterpolatedGhostAfterSpawnAuthoring authoring)
	{
		EnsureHasComponent<ConvertToInterpolatedGhostCD>();
	}
}

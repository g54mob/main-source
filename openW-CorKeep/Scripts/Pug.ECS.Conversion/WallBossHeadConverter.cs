using Pug.Conversion;

public class WallBossHeadConverter : SingleAuthoringComponentConverter<WallBossHeadAuthoring>
{
	protected override void Convert(WallBossHeadAuthoring authoring)
	{
		EnsureHasComponent<WallBossHeadCD>();
	}
}

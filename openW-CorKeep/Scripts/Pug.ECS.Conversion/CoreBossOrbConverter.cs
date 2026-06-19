using Pug.Conversion;

public class CoreBossOrbConverter : SingleAuthoringComponentConverter<CoreBossOrbAuthoring>
{
	protected override void Convert(CoreBossOrbAuthoring authoring)
	{
		EnsureHasComponent<CoreBossOrbCD>();
	}
}

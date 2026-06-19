using Pug.Conversion;

public class BossLarvaSpawnStateConverter : SingleAuthoringComponentConverter<BossLarvaSpawnStateAuthoring>
{
	protected override void Convert(BossLarvaSpawnStateAuthoring authoring)
	{
		EnsureHasComponent<BossLarvaSpawnStateCD>();
	}
}

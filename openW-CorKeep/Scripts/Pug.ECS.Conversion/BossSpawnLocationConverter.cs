using Pug.Conversion;

public class BossSpawnLocationConverter : SingleAuthoringComponentConverter<BossSpawnLocationAuthoring>
{
	protected override void Convert(BossSpawnLocationAuthoring authoring)
	{
		AddComponentData(new BossSpawnLocationCD
		{
			bossID = authoring.bossID
		});
	}
}

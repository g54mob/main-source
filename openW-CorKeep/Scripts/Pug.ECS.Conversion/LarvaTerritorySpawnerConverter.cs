using Pug.Conversion;

public class LarvaTerritorySpawnerConverter : SingleAuthoringComponentConverter<LarvaTerritorySpawnerAuthoring>
{
	protected override void Convert(LarvaTerritorySpawnerAuthoring authoring)
	{
		AddComponentData(new LarvaTerritorySpawnerCD
		{
			size = authoring.size
		});
	}
}

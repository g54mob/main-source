using Pug.Conversion;

public class BossConverter : SingleAuthoringComponentConverter<BossAuthoring>
{
	protected override void Convert(BossAuthoring authoring)
	{
		AddComponentData(new BossCD
		{
			chestToSpawn = authoring.chestToSpawn,
			spawnOptionalChest = authoring.spawnOptionalChest,
			optionalChestVersion = authoring.optionalChestVersion,
			chestSpawnOffset = authoring.chestSpawnOffset
		});
		EnsureHasComponent<SummonedEnemyCD>();
		EnsureHasComponent<DontOverrideInDungeonGenerationCD>();
		if (authoring.isMainStoryBoss)
		{
			base.PropertiesBuilder.SetProperty(base.ObjectIndex, "isMainStoryBoss");
		}
	}
}

using Pug.Conversion;

public class SummonAreaConverter : SingleAuthoringComponentConverter<SummonAreaAuthoring>
{
	protected override void Convert(SummonAreaAuthoring authoring)
	{
		AddComponentData(new SummonAreaCD
		{
			bossToSummon = authoring.bossToSummon,
			optionalBossToSummon = authoring.optionalBossToSummon,
			anticipationTime = authoring.anticipationTime,
			spawnTime = authoring.spawnTime,
			distanceToDestroyTilesOnSpawn = authoring.distanceToDestroyTilesOnSpawn,
			internalState = authoring.internalState,
			internalTimer = authoring.internalTimer,
			spawnOffset = authoring.spawnOffset,
			dontOffsetSpawnItemLocation = authoring.dontOffsetSpawnItemLocation,
			overrideDistanceSqToCheckSummoningItem = authoring.overrideDistanceToCheckSummoningItem * authoring.overrideDistanceToCheckSummoningItem,
			overrideDistanceSqToCheckForExistingBoss = authoring.overrideDistanceToCheckForExistingBoss * authoring.overrideDistanceToCheckForExistingBoss
		});
		EnsureHasComponent<DontOverrideInDungeonGenerationCD>();
	}
}

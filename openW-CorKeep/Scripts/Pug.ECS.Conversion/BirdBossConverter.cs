using Pug.Conversion;

public class BirdBossConverter : SingleAuthoringComponentConverter<BirdBossAuthoring>
{
	protected override void Convert(BirdBossAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<BirdBossHasAppearedCD>();
		EnsureHasComponent<BirdBossFlyingAboveStateCD>();
		AddComponentData(new BirdBossAppearStateCD
		{
			landDuration = authoring.landDuration
		});
		AddComponentData(new BirdBossSpawnBeamsStateCD
		{
			durationUntilBeamSpawn = authoring.beamSpawn.durationUntilSpawn,
			durationAfterBeamSpawn = authoring.beamSpawn.durationAfterSpawn,
			minCooldown = authoring.beamSpawn.minCooldown,
			maxCooldown = authoring.beamSpawn.maxCooldown
		});
		AddComponentData(new BirdBossSpawnStonesStateCD
		{
			durationBeforeLeaveStonesSpawnState = authoring.durationBeforeLeaveStonesSpawnState,
			durationBeforeStartingToSpawnStones = authoring.durationBeforeStartingToSpawnStones,
			durationUntilStonesSpawn = authoring.stoneSpawn.durationUntilSpawn,
			durationAfterStonesSpawn = authoring.stoneSpawn.durationAfterSpawn,
			minCooldown = authoring.stoneSpawn.minCooldown,
			maxCooldown = authoring.stoneSpawn.maxCooldown
		});
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<IsInCombatCD>();
	}
}

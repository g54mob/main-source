using Pug.Conversion;

public class OctopusBossConverter : SingleAuthoringComponentConverter<OctopusBossAuthoring>
{
	protected override void Convert(OctopusBossAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<OctopusBossCD>();
		EnsureHasComponent<OctopusBossHasAppearedCD>();
		EnsureHasComponent<OctopusBossLurkingBelowStateCD>();
		AddComponentData(new OctopusBossAppearStateCD
		{
			appearDuration = authoring.appearDuration
		});
		AddComponentData(new OctopusBossSpawnTentaclesStateCD
		{
			durationBeforeLeaveSpawnState = authoring.durationBeforeLeaveTentacleSpawnState,
			durationBeforeStartingToSpawn = authoring.durationBeforeStartingToSpawnTentacles,
			durationUntilSpawn = authoring.tentacleSpawn.durationUntilSpawn,
			durationAfterSpawn = authoring.tentacleSpawn.durationAfterSpawn,
			minCooldown = authoring.tentacleSpawn.minCooldown,
			maxCooldown = authoring.tentacleSpawn.maxCooldown
		});
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasBuffer<TeleportLocationsBuffer>();
	}
}

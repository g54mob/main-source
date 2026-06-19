using Pug.Conversion;

public class TeleportStateConverter : SingleAuthoringComponentConverter<TeleportStateAuthoring>
{
	protected override void Convert(TeleportStateAuthoring authoring)
	{
		AddComponentData(new TeleportStateCD
		{
			canOnlyTeleportBackToSpawn = authoring.canOnlyTeleportBackToSpawn,
			canOnlyTeleportToNonBlockedGround = authoring.canOnlyTeleportToNonBlockedGround,
			canTeleportToPitAndWater = authoring.canTeleportToPitAndWater,
			startTeleportDuration = authoring.startTeleportDuration,
			endTeleportDuration = authoring.endTeleportDuration,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			minTeleportDistanceFromPlayer = authoring.minTeleportDistanceFromPlayer,
			maxTeleportDistanceFromPlayer = authoring.maxTeleportDistanceFromPlayer,
			updateTilesAtAreaMinCorner = authoring.updateTilesAtAreaMinCorner,
			updateTilesAtAreaMaxCorner = authoring.updateTilesAtAreaMaxCorner,
			allowedRadiusToMoveFromPosition = authoring.allowedRadiusToMoveFromPosition
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<IsInCombatCD>();
	}
}

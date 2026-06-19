using Pug.Conversion;
using Unity.NetCode;
using UnityEngine;

public class MortarProjectileConverter : SingleAuthoringComponentConverter<MortarProjectileAuthoring>
{
	protected override void Convert(MortarProjectileAuthoring authoring)
	{
		EnsureHasComponent<ProjectileSourceCD>();
		EnsureHasComponent<OwnerReferenceCD>();
		AddComponentData(new MortarProjectileCD
		{
			radius = authoring.radius,
			spawnTilesOnGoingDown = authoring.spawnTilesOnGoingDown,
			tileTypeToSpawnOnGoingDown = authoring.tileTypeToSpawnOnGoingDown,
			tilesetToSpawnOnGoingDown = authoring.tilesetToSpawnOnGoingDown,
			spawnTilesOnGoingDownExtraRadius = authoring.spawnTilesOnGoingDownExtraRadius,
			goUpTime = (authoring.useDefaultTimings ? authoring.goUpTime : 0f),
			airTime = (authoring.useDefaultTimings ? authoring.airTime : 0f),
			goDownTime = (authoring.useDefaultTimings ? authoring.goDownTime : 0f),
			explodeTime = (authoring.useDefaultTimings ? authoring.explodeTime : 0f),
			totalAirTime = (authoring.useDefaultTimings ? (authoring.goUpTime + authoring.airTime + authoring.goDownTime) : 0f),
			canSpawnTilesOnWaterOrPits = authoring.canSpawnTilesOnWaterOrPits,
			randomizeEdgeForTilesToSpawn = authoring.randomizeEdgeForTilesToSpawn
		});
		EnsureHasComponent<MortarProjectileEffectTriggerCD>(componentIsEnabled: false);
		AddComponentData(new MortarProjectileDamageEffectCD
		{
			pushback = authoring.pushback,
			checkVisibility = authoring.checkVisibility,
			bypassMaxDamagePerHit = authoring.bypassMaxDamagePerHit,
			spawnTilesOnLand = authoring.spawnTilesOnLand,
			tileTypeToSpawn = authoring.tileTypeToSpawn,
			tilesetToSpawn = authoring.tilesetToSpawn,
			removeTilesOnLand = authoring.removeTilesOnLand,
			tileTypeToRemove = authoring.tileTypeToRemove,
			tilesetToRemove = authoring.tilesetToRemove,
			isPredicted = authoring.isPredicted,
			hitTiles = authoring.hitTiles,
			skipWallAndRootsLootDropOnDestroy = authoring.skipWallAndRootsLootDropOnDestroy,
			isMagic = authoring.isMagic,
			spawnNapalmObjectID = authoring.spawnNapalmObjectID,
			spawnNapalmVariation = authoring.spawnNapalmVariation
		});
		if (authoring.checkVisibility && TryGetActiveComponent<GhostAuthoringComponent>(authoring, out var component) && component.SupportedGhostModes != GhostModeMask.Predicted)
		{
			Debug.LogError("MortarProjectileAuthoring is set up with checkVisibility, but is not predicted. Currently we only support predicted behaviour as tileLookup has no history on server");
		}
	}
}

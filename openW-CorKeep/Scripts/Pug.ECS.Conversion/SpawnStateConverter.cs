using Pug.Conversion;
using UnityEngine;

public class SpawnStateConverter : SingleAuthoringComponentConverter<SpawnStateAuthoring>
{
	protected override void Convert(SpawnStateAuthoring authoring)
	{
		AddComponentData(new SpawnStateCD
		{
			duration = authoring.duration,
			animId = Animator.StringToHash(authoring.animId),
			facingDirection = authoring.facingDirection,
			removeTilesOnSpawn = authoring.removeTilesOnSpawn,
			radiusSqToRemoveTilesWithin = authoring.radiusToRemoveTilesWithin * authoring.radiusToRemoveTilesWithin,
			removeTilesOnSpawnOffset = authoring.removeTilesOnSpawnOffset
		});
	}
}

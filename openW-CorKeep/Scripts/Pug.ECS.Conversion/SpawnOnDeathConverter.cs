using Pug.Conversion;

public class SpawnOnDeathConverter : SingleAuthoringComponentConverter<SpawnOnDeathAuthoring>
{
	protected override void Convert(SpawnOnDeathAuthoring authoring)
	{
		AddComponentData(new SpawnEntityOnDeathCD
		{
			objectToSpawn = authoring.objectToSpawn,
			objectVariation = authoring.objectVariation,
			spawnChance = authoring.spawnChance,
			offset = authoring.offset,
			amount = authoring.amount,
			maxAmountAllowedWithinRadius = authoring.maxAmountAllowedWithinRadius,
			maxAmountCheckRadius = authoring.maxAmountCheckRadius,
			dontSpawnIfKilledByDestroyTimer = authoring.dontSpawnIfKilledByDestroyTimer
		});
	}
}

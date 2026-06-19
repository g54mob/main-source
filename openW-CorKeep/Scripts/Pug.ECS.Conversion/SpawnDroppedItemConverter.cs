using Pug.Conversion;

public class SpawnDroppedItemConverter : SingleAuthoringComponentConverter<SpawnDroppedItemAuthoring>
{
	protected override void Convert(SpawnDroppedItemAuthoring authoring)
	{
		AddComponentData(new SpawnDroppedItemCD
		{
			objectID = authoring.objectID,
			amount = authoring.amount,
			repeats = authoring.repeats,
			timeBetweenSpawns = authoring.timeBetweenSpawns,
			timer = authoring.timer
		});
	}
}

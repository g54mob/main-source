using Pug.Conversion;

public class DestroyNearbyOnDeathConverter : SingleAuthoringComponentConverter<DestroyNearbyOnDeathAuthoring>
{
	protected override void Convert(DestroyNearbyOnDeathAuthoring authoring)
	{
		AddComponentData(new DestroyNearbyEntitiesOnDeathCD
		{
			radius = authoring.radius,
			killAnyTemporaryEnemy = authoring.killAnyTemporaryEnemy,
			destroyEntitiesWithDontDestroyOnZeroHealthCD = authoring.destroyEntitiesWithDontDestroyOnZeroHealthCD
		});
		EnsureHasBuffer<DestroyNearbyEntitiesOnDeathBuffer>();
		foreach (ObjectID item in authoring.objectsToDestroy)
		{
			AddToBuffer(new DestroyNearbyEntitiesOnDeathBuffer
			{
				objectID = item
			});
		}
	}
}

using Pug.Conversion;
using Unity.Entities;

public class PetWalkStateConverter : SingleAuthoringComponentConverter<PetWalkStateAuthoring>
{
	protected override void Convert(PetWalkStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		MovementSpeedAuthoring component;
		float speed = (authoring.TryGetComponent<MovementSpeedAuthoring>(out component) ? component.speed : 0f);
		float speedMultiplier = PetWalkStateUtility.CalculateSpeedMultiplier(1000f);
		float maximumMovementSpeed = PetWalkStateUtility.CalculateMovementSpeed(speed, speedMultiplier);
		Entity pathFindEntity = PathFindingConversion.CreatePathfindingEntity(this, authoring, authoring.belongsToShape, base.PrimaryEntity, 20f, maximumMovementSpeed);
		AddComponentData(new PetWalkStateCD
		{
			pathFindEntity = pathFindEntity
		});
	}
}

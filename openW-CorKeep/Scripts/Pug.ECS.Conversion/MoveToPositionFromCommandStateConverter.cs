using Pug.Conversion;
using Unity.Entities;

public class MoveToPositionFromCommandStateConverter : SingleAuthoringComponentConverter<MoveToPositionFromCommandStateAuthoring>
{
	protected override void Convert(MoveToPositionFromCommandStateAuthoring stateAuthoring)
	{
		MovementSpeedAuthoring component;
		float speed = (stateAuthoring.TryGetComponent<MovementSpeedAuthoring>(out component) ? component.speed : 0f);
		ChaseStateAuthoring component2;
		float moveSpeedMultiplier = (stateAuthoring.TryGetComponent<ChaseStateAuthoring>(out component2) ? component2.moveSpeedMultiplier : 1f);
		float maximumMovementSpeed = MoveToPositionFromCommandStateUtility.CalculateMovementSpeed(speed, moveSpeedMultiplier);
		MinionAuthoring component3;
		Entity pathFindingEntity = ((!TryGetActiveComponent<MinionAuthoring>(stateAuthoring, out component3) || !component3.hasMiningAttack) ? PathFindingConversion.CreatePathfindingEntity(this, stateAuthoring, stateAuthoring.belongsToShape, base.PrimaryEntity, 20f, maximumMovementSpeed) : PathFindingConversion.CreatePathfindingEntity(this, stateAuthoring, stateAuthoring.belongsToShape, base.PrimaryEntity, 20f, maximumMovementSpeed, PathFindCD.PathFindAlgorithm.AStar, PathFindAStarCD.PolicyType.AllowButAvoidWalls));
		AddComponentData(new MoveToPositionFromCommandStateCD
		{
			pathFindingEntity = pathFindingEntity
		});
	}
}

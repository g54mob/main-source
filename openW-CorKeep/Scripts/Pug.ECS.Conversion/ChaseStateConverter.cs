using Pug.Conversion;
using Unity.Entities;

public class ChaseStateConverter : SingleAuthoringComponentConverter<ChaseStateAuthoring>
{
	protected override void Convert(ChaseStateAuthoring authoring)
	{
		CattleAuthoring component;
		bool isLeashed = TryGetActiveComponent<CattleAuthoring>(authoring, out component);
		MovementSpeedAuthoring component2;
		float maximumMovementSpeed = ChaseStateUtility.CalculateMovementSpeed(authoring.TryGetComponent<MovementSpeedAuthoring>(out component2) ? component2.speed : 0f, authoring.moveSpeedMultiplier, isLeashed);
		Entity pathFindEntity = PathFindingConversion.CreatePathfindingEntity(this, authoring, authoring.belongsToShape, base.PrimaryEntity, authoring.chaseAtDistance, maximumMovementSpeed);
		if (authoring.skipVisibilityCheck)
		{
			SetProperty("Chase/skipVisibilityCheck");
		}
		SetProperty("Chase/moveSpeedMultiplier", authoring.moveSpeedMultiplier);
		if (authoring.ignoreLowColliders)
		{
			SetProperty("Chase/ignoreLowColliders");
		}
		SetProperty("Chase/preChaseDuration", authoring.preChaseDuration);
		SetProperty("Chase/endChaseDuration", authoring.endChaseDuration);
		SetProperty("Chase/distanceToStartSideSteppingSq", authoring.distanceToStartSideStepping * authoring.distanceToStartSideStepping);
		SetProperty("Chase/minDistanceToKeep", authoring.minDistanceToKeep);
		SetProperty("Chase/maxDistanceToKeep", authoring.maxDistanceToKeep);
		SetProperty("Chase/obstacleAvoidDistance", authoring.obstacleAvoidDistance);
		if (authoring.preferPathFind)
		{
			SetProperty("Chase/preferPathFind");
		}
		if (authoring.needPathToChase)
		{
			SetProperty("Chase/needPathToChase");
		}
		SetProperty("Chase/idleDuration", authoring.idleDuration);
		SetProperty("Chase/idleCooldown", authoring.idleCooldown);
		AddComponentData(new ChaseStateCD
		{
			chaseAtDistanceSq = authoring.chaseAtDistance * authoring.chaseAtDistance,
			neverTimeoutChasing = authoring.neverStopChasing,
			pathFindEntity = pathFindEntity,
			isDisabled = authoring.disabled,
			distanceToKeepNoiseDisabled = authoring.distanceToKeepNoiseDisabled
		});
		if (authoring.chaseHeldObjects.Count > 0)
		{
			ObjectID[] array = new ObjectID[authoring.chaseHeldObjects.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = authoring.chaseHeldObjects[i];
			}
			SetPropertyList("Chase/chaseHeldObjects", array);
		}
		EnsureHasComponent<IsInCombatCD>();
	}
}

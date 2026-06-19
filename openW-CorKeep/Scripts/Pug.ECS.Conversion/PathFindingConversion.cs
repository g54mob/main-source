using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using UnityEngine;

public static class PathFindingConversion
{
	public static Entity CreatePathfindingEntity(Converter converter, MonoBehaviour authoring, PhysicsShapeAuthoring belongsToShape, Entity primaryEntity, float searchDistance, float maximumMovementSpeed, PathFindCD.PathFindAlgorithm algorithm = PathFindCD.PathFindAlgorithm.BFS, PathFindAStarCD.PolicyType aStarPolicy = PathFindAStarCD.PolicyType.UniformCost)
	{
		Entity entity = converter.CreateAdditionalEntity();
		int num = (int)math.ceil(searchDistance);
		if (authoring.TryGetComponent<MinionAuthoring>(out var _) || authoring.TryGetComponent<PetAuthoring>(out var _))
		{
			num *= 2;
		}
		converter.AddComponentData(entity, new PathFindCD
		{
			startEntity = primaryEntity,
			searchRadius = num,
			belongsToLayer = ((belongsToShape == null) ? uint.MaxValue : belongsToShape.BelongsTo.Value),
			isFlying = authoring.TryGetComponent<IsFlyingAuthoring>(out var _)
		});
		if (algorithm == PathFindCD.PathFindAlgorithm.AStar)
		{
			converter.AddComponentData(entity, new PathFindAStarCD
			{
				Policy = aStarPolicy
			});
		}
		else
		{
			converter.EnsureHasComponent<PathFindBfsCD>(entity);
		}
		PhysicsBodyAuthoring component4;
		float dampeningFactor = (authoring.TryGetComponent<PhysicsBodyAuthoring>(out component4) ? component4.LinearDamping : 1f);
		int simulationTickRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		int nodesForTargetMovementSettings = PathFindUtility.GetNodesForTargetMovementSettings(maximumMovementSpeed, dampeningFactor, simulationTickRate);
		converter.EnsureHasBuffer<PathFindNodeBuffer>(entity);
		for (int i = 0; i < nodesForTargetMovementSettings; i++)
		{
			converter.AddToBuffer(entity, default(PathFindNodeBuffer));
		}
		return entity;
	}
}

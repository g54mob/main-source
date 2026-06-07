using Unity.Entities;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	public delegate void BeforeMovementDelegate(Entity entity, float dt, ref LocalTransform localTransform, ref AgentCylinderShape shape, ref AgentMovementPlane movementPlane, ref DestinationPoint destination, ref MovementState movementState, ref MovementSettings movementSettings, ref MovementControl movementControl, ref ResolvedMovement resolvedMovement);
}

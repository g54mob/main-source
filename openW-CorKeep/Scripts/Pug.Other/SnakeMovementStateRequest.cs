using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SnakeMovementStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (!c._bossLarvaSpawnGroup.HasComponent(entity))
		{
			return c._snakeMovementGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.SnakeMovement) && c._snakeMovementGroup[entity].IsHead(entity) && !c._snakeMovementGroup[entity].isDisabled)
		{
			stateInfo.EnterState(StateID.SnakeMovement);
		}
	}
}

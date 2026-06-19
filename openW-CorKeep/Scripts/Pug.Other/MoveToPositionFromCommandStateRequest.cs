using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct MoveToPositionFromCommandStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._moveToPositionFromCommandGroup.HasComponent(entity))
		{
			return c._localTransformGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ref MoveToPositionFromCommandStateCD valueRW = ref c._moveToPositionFromCommandGroup.GetRefRW(entity).ValueRW;
		bool pendingMove = valueRW.pendingMove;
		RefRW<PathFindCD> refRWOptional = c._pathFindGroup.GetRefRWOptional(valueRW.pathFindingEntity);
		if (!refRWOptional.IsValid)
		{
			return;
		}
		if (!stateInfo.IsCurrentState(StateID.MoveToPositionFromCommand))
		{
			refRWOptional.ValueRW.targetPosition = int2.zero;
		}
		if (!stateInfo.HasState(StateID.MoveToPositionFromCommand) && pendingMove)
		{
			valueRW.consecutiveDamageAttempts = 0;
			valueRW.damageObjectState = MoveToPositionFromCommandStateCD.InternalState.Init;
			refRWOptional.ValueRW.targetPosition = valueRW.position.RoundToInt2();
			if (c._miningMinionGroup.TryGetComponent(entity, out var componentData) && c._pathFindAStarGroup.TryGetComponent(valueRW.pathFindingEntity, out var componentData2))
			{
				componentData2.MiningDamage = componentData.damage;
				c._pathFindAStarGroup[valueRW.pathFindingEntity] = componentData2;
			}
			stateInfo.EnterState(StateID.MoveToPositionFromCommand);
		}
	}
}

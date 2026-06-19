using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct PetWalkStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._petWalkStateGroup.HasComponent(entity))
		{
			return c._ownerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.PetWalk))
		{
			return;
		}
		Entity owner = c._ownerGroup[entity].owner;
		if (owner == Entity.Null || !c._localTransformGroup.HasComponent(owner))
		{
			return;
		}
		float3 position = c._localTransformGroup[entity].Position;
		float3 position2 = c._localTransformGroup[owner].Position;
		PetWalkStateCD value = c._petWalkStateGroup[entity];
		bool flag = IsFighting(in stateInfo);
		if (c._spawnTickGroup.TryGetComponent(entity, out var componentData))
		{
			bool flag2 = NetworkTimeUtilities.TimeBetweenTicksInSeconds(componentData.Value, d._serverTick, d.tickRate) < 0.1f;
			flag = flag || flag2;
		}
		if (c._moveToPositionFromCommandGroup.TryGetComponent(entity, out var componentData2))
		{
			bool flag3 = componentData2.lastFinishedMoveToPositionTick.IsValid && NetworkTimeUtilities.TimeBetweenTicksInSeconds(componentData2.lastFinishedMoveToPositionTick, d._serverTick, d.tickRate) < 1f;
			flag = flag || flag3;
		}
		float num = GetMaxDistanceSqrToPlayerToGo(isMinionFightingCommandTarget: IsMinionFightingCommandTarget(entity, in stateInfo, c._minionGroup, c._moveToPositionFromCommandGroup, c._chaseStateGroup, c._meleeAttackStateGroup, c._rangeStateGroup, c._jumpAttackStateGroup), entity: entity, minionLookup: c._minionGroup, chaseStateLookup: c._chaseStateGroup, isFighting: flag);
		if (math.distancesq(position, position2) >= num)
		{
			if (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.internalState = 0;
				value.currentSpeedMultiplier = 0.5f;
				stateInfo.EnterState(StateID.PetWalk);
			}
		}
		else if (flag)
		{
			value.cooldownTimer.Start(d._elapsedTime, 0.5f);
		}
		c._petWalkStateGroup[entity] = value;
	}

	public static bool IsFighting(in StateInfoCD stateInfo)
	{
		if (!stateInfo.IsCurrentOrPreviousState(StateID.Chase) && !stateInfo.IsCurrentOrPreviousState(StateID.MeleeAttack) && !stateInfo.IsCurrentOrPreviousState(StateID.RangeAttack) && !stateInfo.IsCurrentOrPreviousState(StateID.JumpAttack))
		{
			return stateInfo.IsCurrentOrPreviousState(StateID.MoveToPositionFromCommand);
		}
		return true;
	}

	public static bool IsMinionFightingCommandTarget(Entity entity, in StateInfoCD stateInfo, ComponentLookup<MinionCD> minionLookup, ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup, ComponentLookup<ChaseStateCD> chaseStateLookup, ComponentLookup<MeleeAttackStateCD> meleeAttackStateLookup, ComponentLookup<RangeAttackStateCD> rangeAttackStateLookup, ComponentLookup<JumpAttackStateCD> jumpAttackStateLookup)
	{
		if (!minionLookup.HasComponent(entity))
		{
			return false;
		}
		moveToPositionFromCommandStateLookup.TryGetComponent(entity, out var componentData);
		Entity target = componentData.target;
		Entity entity2 = Entity.Null;
		if (stateInfo.IsCurrentState(StateID.Chase))
		{
			chaseStateLookup.TryGetComponent(entity, out var componentData2);
			entity2 = componentData2.targetEntity;
		}
		else if (stateInfo.IsCurrentState(StateID.MeleeAttack))
		{
			meleeAttackStateLookup.TryGetComponent(entity, out var componentData3);
			entity2 = componentData3.aimingAtEntity;
		}
		else if (stateInfo.IsCurrentState(StateID.RangeAttack))
		{
			rangeAttackStateLookup.TryGetComponent(entity, out var componentData4);
			entity2 = componentData4.aimingAtEntity;
		}
		else if (stateInfo.IsCurrentState(StateID.JumpAttack))
		{
			jumpAttackStateLookup.TryGetComponent(entity, out var componentData5);
			entity2 = componentData5.target;
		}
		if (target != Entity.Null)
		{
			return target == entity2;
		}
		return false;
	}

	public static float GetMaxDistanceSqrToPlayerToGo(Entity entity, ComponentLookup<MinionCD> minionLookup, ComponentLookup<ChaseStateCD> chaseStateLookup, bool isFighting, bool isMinionFightingCommandTarget)
	{
		float num = (minionLookup.HasComponent(entity) ? 3.5f : 2.5f);
		if (isFighting)
		{
			chaseStateLookup.TryGetComponent(entity, out var componentData);
			float x = (isMinionFightingCommandTarget ? 400f : componentData.chaseAtDistanceSq);
			num += math.sqrt(x);
		}
		return num * num;
	}
}

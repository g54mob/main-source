using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct GiantCicadaSlamArmsStateRequest : IStateRequester
{
	private const float TriggerCloseSq = 30f;

	private const float CenterLaneThreshold = 2.5f;

	private const int MaxDistanceToAttack = 130;

	private const float LeftRightFarVsCloseAttackThreshold = 40f;

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._slamArmsStateGroup.HasComponent(entity) && c._idleInCombatStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.GiantCicadaBossSlamArms) || stateInfo.HasState(StateID.StageTransition) || stateInfo.HasState(StateID.CoreBossSpawnVoid))
		{
			return;
		}
		EnemyStagesStateCD enemyStagesStateCD = c._enemyStagesGroup[entity];
		GiantCicadaSlamArmsStateCD value = c._slamArmsStateGroup[entity];
		if (!c._isInCombatGroup[entity].isInCombat)
		{
			value.stateCooldownTimer.Stop();
		}
		else if (!value.stateCooldownTimer.isRunning)
		{
			float newLifespan = value.minCooldown * enemyStagesStateCD.GetMultiplierDecreasingAsHealthDecreases();
			value.stateCooldownTimer.Start(d._elapsedTime, newLifespan);
		}
		else if (value.stateCooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			value.stateCooldownTimer.Stop();
			value.amountOfValidPlayers = d.playerExtrapolatedEntities.Length;
			if (enemyStagesStateCD.currentStage < 1)
			{
				value.armSlamType = d._rng.NextInt(0, 6) switch
				{
					0 => GiantCicadaMeleeAttacks.ArmSlamLeftFar, 
					1 => GiantCicadaMeleeAttacks.ArmSlamLeft, 
					2 => GiantCicadaMeleeAttacks.ArmSlamMiddleClose, 
					3 => GiantCicadaMeleeAttacks.ArmSlamRight, 
					4 => GiantCicadaMeleeAttacks.ArmSlamRightFar, 
					5 => GiantCicadaMeleeAttacks.ArmSlamMiddleFar, 
					_ => GiantCicadaMeleeAttacks.ArmSlamMiddleClose, 
				};
				value.internalState = ArmSlamInternalState.Start;
				c._slamArmsStateGroup[entity] = value;
				stateInfo.EnterState(StateID.GiantCicadaBossSlamArms);
				return;
			}
			float3 position = c._localTransformGroup[entity].Position;
			float num = position.z - 1f;
			Entity entity2 = Entity.Null;
			if (c._lastAttackerGroup.TryGetComponent(entity, out var componentData))
			{
				entity2 = componentData.Value;
			}
			if (entity2 != Entity.Null && c._localTransformGroup.HasComponent(entity2))
			{
				float3 position2 = c._localTransformGroup[entity2].Position;
				if (position2.z < num && math.distancesq(position, position2) < 130f)
				{
					value.armSlamType = GetSlamType(position, position2);
					value.internalState = ArmSlamInternalState.Start;
					stateInfo.EnterState(StateID.GiantCicadaBossSlamArms);
					c._slamArmsStateGroup[entity] = value;
					return;
				}
			}
			NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
			bool flag = false;
			for (int i = 0; i < d.playerExtrapolatedEntities.Length; i++)
			{
				LocalTransform localTransform = c._localTransformGroup[d.playerExtrapolatedEntities[i]];
				if (math.distancesq(position, localTransform.Position) < 130f)
				{
					if (localTransform.Position.z >= num)
					{
						flag = true;
					}
					else
					{
						nativeList.Add(d.playerExtrapolatedEntities[i]);
					}
				}
			}
			if (flag)
			{
				if (value.internalState != ArmSlamInternalState.PlayersAboveTriggered)
				{
					value.internalState = ArmSlamInternalState.PlayersAbove;
					stateInfo.EnterState(StateID.GiantCicadaBossSlamArms);
				}
			}
			else if (nativeList.Length > 0)
			{
				int index = d._rng.NextInt(0, nativeList.Length);
				value.armSlamType = GetSlamType(position, c._localTransformGroup[nativeList[index]].Position);
				value.internalState = ArmSlamInternalState.Start;
				stateInfo.EnterState(StateID.GiantCicadaBossSlamArms);
			}
			else
			{
				value.internalState = ArmSlamInternalState.PlayersTooFarAway;
				stateInfo.EnterState(StateID.GiantCicadaBossSlamArms);
			}
			nativeList.Dispose();
		}
		c._slamArmsStateGroup[entity] = value;
	}

	private GiantCicadaMeleeAttacks GetSlamType(Vector3 bossPosition, Vector3 positionToAttack)
	{
		float num = math.distancesq(bossPosition, positionToAttack);
		if (positionToAttack.x >= bossPosition.x - 2.5f && positionToAttack.x <= bossPosition.x + 2.5f)
		{
			if (!(num < 30f))
			{
				return GiantCicadaMeleeAttacks.ArmSlamMiddleFar;
			}
			return GiantCicadaMeleeAttacks.ArmSlamMiddleClose;
		}
		if (positionToAttack.x < bossPosition.x - 2.5f)
		{
			if (!(num < 70f))
			{
				return GiantCicadaMeleeAttacks.ArmSlamLeftFar;
			}
			return GiantCicadaMeleeAttacks.ArmSlamLeft;
		}
		if (positionToAttack.x > bossPosition.x + 2.5f)
		{
			if (!(num < 70f))
			{
				return GiantCicadaMeleeAttacks.ArmSlamRightFar;
			}
			return GiantCicadaMeleeAttacks.ArmSlamRight;
		}
		return GiantCicadaMeleeAttacks.ArmSlamMiddleFar;
	}
}

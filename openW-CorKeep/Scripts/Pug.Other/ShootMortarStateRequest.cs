using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ShootMortarStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._mortarStateGroup.HasComponent(entity) && c._mortarShotPositionBufferGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ShootMortarProjectileStateCD shootState = c._mortarStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		_ = c._mortarShotPositionBufferGroup[entity];
		if (!shootState.cooldownTimer.isRunning)
		{
			float newLifespan = d._rng.NextFloat(shootState.minCooldown, shootState.maxCooldown);
			shootState.cooldownTimer.Start(d._elapsedTime, newLifespan);
			c._mortarStateGroup[entity] = shootState;
		}
		else
		{
			if (stateInfo.HasState(StateID.ShootMortarProjectile))
			{
				return;
			}
			if (shootState.projectilesSpawned > 0)
			{
				shootState.projectilesSpawned = 0;
				ShootMortarProjectileStateSystem.SetCooldown(entity, d._elapsedTime, ref shootState, c._enrageStateGroup, ref d._rng);
				c._mortarStateGroup[entity] = shootState;
			}
			else
			{
				if (shootState.isDisabled || stateInfo.IsCurrentState(StateID.SlimeBossJump) || stateInfo.IsCurrentState(StateID.SlimeBossTauntJump) || stateInfo.IsCurrentState(StateID.Charge) || (shootState.dontInterruptOtherAttackStates && (stateInfo.IsCurrentState(StateID.MeleeAttack) || stateInfo.IsCurrentState(StateID.MeleeAttackContinuous) || stateInfo.IsCurrentState(StateID.RangeAttack) || stateInfo.IsCurrentState(StateID.BeamAttack) || stateInfo.IsCurrentState(StateID.JumpAttack) || stateInfo.IsCurrentState(StateID.Charge))) || (shootState.onlyShootWhenInCombat && !isInCombatCD.isInCombat) || (shootState.cooldownTimer.isRunning && !shootState.cooldownTimer.IsTimerElapsed(d._elapsedTime)) || (shootState.maxHealthRatioToShoot < 1f && healthCD.Normalized > shootState.maxHealthRatioToShoot))
				{
					return;
				}
				c._behaviourTagsGroup.TryGetComponent(entity, out var componentData);
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					Entity entity2 = dynamicBuffer[i].entity;
					if ((c._entityDestroyedGroup.HasComponent(entity2) && c._entityDestroyedGroup.IsComponentEnabled(entity2)) || !c._objectDataGroup.HasComponent(entity2) || !c._healthGroup.HasComponent(entity2) || (float)c._healthGroup[entity2].health <= 0f)
					{
						continue;
					}
					FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
					FactionCD targetFaction = (c._factionGroup.HasComponent(entity2) ? c._factionGroup[entity2] : default(FactionCD));
					if (!factionCD.CanAttack(targetFaction, d.worldInfo) || (c._tileGroup.HasComponent(entity2) && c._tileGroup[entity2].tileType.IsWalkableTile()) || c._propertiesGroup[entity2].Has(-440732150) || (c._objectCategoryTagsGroup.HasComponent(entity2) && BehaviourTagsCD.CantAttack(componentData, c._objectCategoryTagsGroup[entity2])) || !c._objectCategoryTagsGroup.HasComponent(entity2) || !BehaviourTagsCD.WantsToAttack(componentData, c._objectCategoryTagsGroup[entity2]))
					{
						continue;
					}
					float3 position = localTransform.Position;
					float3 position2 = c._localTransformGroup[entity2].Position;
					bool flag = true;
					if (!shootState.skipVisibilityCheck)
					{
						int2 int5 = position.RoundToInt2();
						int2 end = position2.RoundToInt2();
						int2 pos = int5;
						do
						{
							if (d.tileLookup.GetTopType(pos).IsWallTile())
							{
								flag = false;
								break;
							}
						}
						while (MathUtilities.NextPosOnLine(int5, end, ref pos));
						if (flag)
						{
							CollisionFilter filter = new CollisionFilter
							{
								BelongsTo = uint.MaxValue,
								CollidesWith = 1u
							};
							RaycastInput input = new RaycastInput
							{
								Start = position + new float3(0f, 0.5f, 0f),
								End = position2 + new float3(0f, 0.5f, 0f),
								Filter = filter
							};
							if (d.collisionWorld.CastRay(input))
							{
								flag = false;
							}
						}
					}
					float num = math.distancesq(position, position2);
					if (num < shootState.minMaxDistanceToTargetToShootSqr.x || num > shootState.minMaxDistanceToTargetToShootSqr.y)
					{
						flag = false;
					}
					if (flag)
					{
						shootState.shootPosition = position2;
						shootState.initialShootPosition = position2;
						shootState.aimingAtEntity = entity2;
						shootState.internalState = 0;
						shootState.projectilesSpawned = 0;
						shootState.waveCount = 0;
						if (c._targetMortarPositionBufferGroup.HasComponent(entity) && c._targetMortarPositionBufferGroup[entity].Length > 0)
						{
							shootState.projectilesToSpawn = c._targetMortarPositionBufferGroup[entity].Length;
						}
						else
						{
							shootState.projectilesToSpawn = d._rng.NextInt(shootState.minAmountOfProjectiles, shootState.maxAmountOfProjectiles + 1);
						}
						shootState.internalTimer.Stop();
						stateInfo.EnterState(StateID.ShootMortarProjectile);
						break;
					}
				}
				c._mortarStateGroup[entity] = shootState;
			}
		}
	}
}

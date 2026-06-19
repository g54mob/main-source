using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RangeAttackStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._rangeStateGroup.HasComponent(entity) && c._attackCooldownGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			return c._behaviourTagsGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		RangeAttackStateCD rangeState = c._rangeStateGroup[entity];
		if (!rangeState.isDisabled && !stateInfo.HasState(StateID.RangeAttack) && !stateInfo.IsCurrentState(StateID.SlimeBossJump) && !stateInfo.IsCurrentState(StateID.SlimeBossTauntJump) && !stateInfo.IsCurrentState(StateID.Sleep))
		{
			rangeState.shotsDone = -1;
			AttackCooldownTimerCD cooldownTimer = c._attackCooldownGroup[entity];
			DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer = c._nearbyEntitiesBufferGroup[entity];
			LocalTransform transform = c._localTransformGroup[entity];
			BehaviourTagsCD attackTags = c._behaviourTagsGroup[entity];
			DoUpdate(entity, ecb, d.tileLookup, d.collisionWorld, ref stateInfo, ref rangeState, ref cooldownTimer, in nearbyEntitiesBuffer, in transform, in attackTags, ref d, ref c);
			c._rangeStateGroup[entity] = rangeState;
			c._attackCooldownGroup[entity] = cooldownTimer;
		}
	}

	private void DoUpdate(Entity entity, EntityCommandBuffer ecb, TileAccessor tileLookup, CollisionWorld collisionWorld, ref StateInfoCD stateInfo, ref RangeAttackStateCD rangeState, ref AttackCooldownTimerCD cooldownTimer, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer, in LocalTransform transform, in BehaviourTagsCD attackTags, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (rangeState.onlyAttackWhenInCombat && c._isInCombatGroup.HasComponent(entity) && !c._isInCombatGroup[entity].isInCombat)
		{
			return;
		}
		if (!cooldownTimer.Value.isRunning)
		{
			float newLifespan = d._rng.NextFloat(rangeState.minCooldown, rangeState.maxCooldown);
			cooldownTimer.Value.Start(d._elapsedTime, newLifespan);
		}
		else
		{
			if (cooldownTimer.Value.isRunning && !cooldownTimer.Value.IsTimerElapsed(d._elapsedTime))
			{
				return;
			}
			Entity entity2 = Entity.Null;
			if (c._lastAttackerGroup.HasComponent(entity))
			{
				entity2 = c._lastAttackerGroup[entity].Value;
			}
			NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
			OwnerReferenceCD componentData;
			bool flag = c._ownerGroup.TryGetComponent(entity, out componentData);
			bool flag2 = c._minionGroup.HasComponent(entity);
			bool flag3 = c._petGroup.HasComponent(entity);
			if (flag2 && flag && c._moveToPositionFromCommandGroup.TryGetComponent(entity, out var componentData2) && componentData2.target != Entity.Null)
			{
				nativeList.Add(in componentData2.target);
				if (c._playerGhostGroup.TryGetComponent(componentData2.target, out var componentData3))
				{
					nativeList.Add(in componentData3.playerGhostExtrapolated);
				}
			}
			int length = nativeList.Length;
			if (flag)
			{
				Entity owner = c._ownerGroup[entity].owner;
				if (c._combatantTrackerBuffer.HasComponent(owner))
				{
					for (int i = 0; i < c._combatantTrackerBuffer[owner].Length; i++)
					{
						CombatantsTrackerBuffer combatantsTrackerBuffer = c._combatantTrackerBuffer[owner][i];
						nativeList.Add(in combatantsTrackerBuffer.Target);
						if (c._playerGhostGroup.HasComponent(c._combatantTrackerBuffer[owner][i].Target))
						{
							PlayerGhost playerGhost = c._playerGhostGroup[c._combatantTrackerBuffer[owner][i].Target];
							nativeList.Add(in playerGhost.playerGhostExtrapolated);
						}
					}
				}
			}
			_ = nativeList.Length;
			if (!flag || flag2)
			{
				for (int j = 0; j < nearbyEntitiesBuffer.Length; j++)
				{
					NearbyEntitiesBufferCD nearbyEntitiesBufferCD = nearbyEntitiesBuffer[j];
					nativeList.Add(in nearbyEntitiesBufferCD.entity);
				}
				if (c._lastAttackerGroup.HasComponent(entity))
				{
					entity2 = c._lastAttackerGroup[entity].Value;
					if (entity2 != Entity.Null)
					{
						nativeList.Add(in entity2);
					}
				}
			}
			for (int k = 0; k < nativeList.Length; k++)
			{
				Entity entity3 = nativeList[k];
				bool flag4 = false;
				if (c._lastAttackerGroup.HasComponent(entity))
				{
					entity2 = c._lastAttackerGroup[entity].Value;
					if (entity2 != Entity.Null)
					{
						flag4 = entity2 == entity3;
					}
				}
				Entity entity4 = entity3;
				if (c._playerGhostExtrapolatedGroup.HasComponent(entity3))
				{
					entity4 = c._playerGhostExtrapolatedGroup[entity3].playerGhost;
				}
				else if (c._entityPartGroup.HasComponent(entity3))
				{
					entity4 = c._entityPartGroup[entity3].mainEntity;
				}
				else if (!flag4 && c._playerGhostGroup.HasComponent(entity3))
				{
					continue;
				}
				bool flag5 = k < length;
				if (((flag3 || flag2) && !flag5 && c._bossGroup.HasComponent(entity4) && c._isInCombatGroup.TryGetComponent(entity4, out var componentData4) && !componentData4.isInCombat && !c._snakeMovementGroup.HasComponent(entity4)) || !c._healthGroup.HasComponent(entity4) || (float)c._healthGroup[entity4].health <= 0f || (c._immuneToDamage.TryGetComponent(entity3, out var componentData5) && componentData5.Value == ImmuneToDamageState.Immune))
				{
					continue;
				}
				FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
				if (!c._objectDataGroup.HasComponent(entity4) || (c._entityDestroyedGroup.HasComponent(entity4) && c._entityDestroyedGroup.IsComponentEnabled(entity4)) || c._physicsExcludeGroup.HasAndIsComponentEnabled(entity3))
				{
					continue;
				}
				FactionCD targetFaction = (c._factionGroup.HasComponent(entity4) ? c._factionGroup[entity4] : default(FactionCD));
				if (!factionCD.CanAttack(targetFaction, d.worldInfo) || (c._tileGroup.HasComponent(entity4) && c._tileGroup[entity4].tileType.IsWalkableTile()) || c._propertiesGroup[entity4].Has(-440732150) || (c._objectCategoryTagsGroup.HasComponent(entity4) && BehaviourTagsCD.CantAttack(attackTags, c._objectCategoryTagsGroup[entity4])) || (c._petGroup.HasComponent(entity) && c._shieldGroup.HasComponent(entity4) && c._shieldGroup[entity4].active) || c._critterGroup.HasComponent(entity4) || !c._objectCategoryTagsGroup.HasComponent(entity4) || (rangeState.onlyAttackTargetsWeWantToAttack && !BehaviourTagsCD.WantsToAttack(attackTags, c._objectCategoryTagsGroup[entity4])))
				{
					continue;
				}
				float3 position = transform.Position;
				float3 position2 = c._localTransformGroup[entity3].Position;
				float3 x = position2 - position;
				float3 aimDirection = math.normalizesafe(x);
				float3 float5 = float3.zero;
				if (c._directionBasedOnVariationGroup.HasComponent(entity))
				{
					int num = 1;
					if (c._electricityGroup.HasComponent(entity))
					{
						num = (c._electricityGroup[entity].hasEnoughElectricityToPowerStuff ? 1 : 0);
					}
					if (num == 1)
					{
						float3 float6 = c._directionBasedOnVariationGroup[entity].direction.ToFloat3();
						float3 x2 = math.normalizesafe(float6);
						float3 float7 = math.normalizesafe(x);
						float x3 = math.acos(math.dot(x2, float7) / (math.length(x2) * math.length(float7)));
						float num2 = 0.008722222f * rangeState.aimDegreesMax;
						if (!(math.abs(x3) < num2))
						{
							continue;
						}
						aimDirection = float6;
						float5 = float6 * 0.51f;
					}
				}
				float num3 = (c._combatRadiusGroup.HasComponent(entity3) ? c._combatRadiusGroup[entity3].radius : 0f);
				float num4 = math.length(x) - num3;
				if (rangeState.minDistanceFromTargetToAllowAttack > num4 || (rangeState.maxDistanceFromTargetToAllowAttack > 0f && rangeState.maxDistanceFromTargetToAllowAttack < num4))
				{
					continue;
				}
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				};
				RaycastInput input = new RaycastInput
				{
					Start = position + new float3(0f, 0.5f, 0f) + float5,
					End = position2 + new float3(0f, 0.5f, 0f),
					Filter = filter
				};
				if (!rangeState.skipVisibilityCheck && collisionWorld.CastRay(input, out var closestHit) && !(closestHit.Entity == entity3))
				{
					continue;
				}
				float3 float8 = math.normalizesafe(position2 - position);
				bool flag6 = false;
				for (int l = 0; (float)l < num4 * 2f; l++)
				{
					int2 worldPosition = (position + float8 * l * 0.5f).RoundToInt2();
					if (tileLookup.GetTopType(worldPosition).IsBlockingTile(includeLowColliders: false))
					{
						flag6 = true;
						break;
					}
				}
				if (!flag6)
				{
					rangeState.aimDirection = aimDirection;
					rangeState.aimingAtEntity = (rangeState.projectileTargetsSelf ? entity : entity3);
					rangeState.internalState = RangeAttackInternalState.Anticipating;
					rangeState.internalTimer.Stop();
					rangeState.shootTimer.Stop();
					rangeState.shotsDone = 0;
					stateInfo.EnterState(StateID.RangeAttack);
					return;
				}
			}
			nativeList.Dispose();
		}
	}
}

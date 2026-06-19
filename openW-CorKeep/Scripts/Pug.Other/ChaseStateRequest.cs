using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ChaseStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._chaseStateGroup.HasComponent(entity) && c._physicsColliderGroup.HasComponent(entity) && c._behaviourTagsGroup.HasComponent(entity))
		{
			return c._objectDataGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ChaseStateCD value = c._chaseStateGroup[entity];
		Entity pathFindEntity = value.pathFindEntity;
		PathFindCD pathFindCD = c._pathFindGroup[pathFindEntity];
		DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer = c._pathFindNodeBufferGroup[pathFindEntity];
		Entity targetEntity = pathFindCD.targetEntity;
		pathFindCD.targetEntity = Entity.Null;
		if (!stateInfo.IsCurrentState(StateID.Chase))
		{
			c._pathFindGroup[pathFindEntity] = pathFindCD;
		}
		if (value.isDisabled || stateInfo.HasState(StateID.Chase) || stateInfo.IsCurrentState(StateID.Sleep))
		{
			return;
		}
		value.shouldEnterStateCheckTimer -= d._deltaTime;
		if (value.shouldEnterStateCheckTimer > 0f)
		{
			c._chaseStateGroup[entity] = value;
			return;
		}
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		BehaviourTagsCD behaviourTagsCD = c._behaviourTagsGroup[entity];
		float3 position = c._localTransformGroup[entity].Position;
		float2 direction;
		bool flag = targetEntity != Entity.Null && PathFindUtility.GetDirection(in pathFindCD, pathFindNodeBuffer, position.ToFloat2(), out direction);
		float3 frompos = position + new float3(0f, 0.5f, 0f);
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		bool flag2 = false;
		NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
		OwnerReferenceCD componentData;
		bool flag3 = c._ownerGroup.TryGetComponent(entity, out componentData);
		bool flag4 = c._minionGroup.HasComponent(entity);
		bool flag5 = c._petGroup.HasComponent(entity);
		if (flag4 && flag3 && c._moveToPositionFromCommandGroup.TryGetComponent(entity, out var componentData2) && componentData2.target != Entity.Null)
		{
			nativeList.Add(in componentData2.target);
			if (c._playerGhostGroup.TryGetComponent(componentData2.target, out var componentData3))
			{
				nativeList.Add(in componentData3.playerGhostExtrapolated);
			}
		}
		int length = nativeList.Length;
		if (flag3)
		{
			Entity owner = c._ownerGroup[entity].owner;
			if (c._combatantTrackerBuffer.HasComponent(owner))
			{
				for (int i = 0; i < c._combatantTrackerBuffer[owner].Length; i++)
				{
					CombatantsTrackerBuffer combatantsTrackerBuffer = c._combatantTrackerBuffer[owner][i];
					nativeList.Add(in combatantsTrackerBuffer.Target);
				}
			}
		}
		int length2 = nativeList.Length;
		int num = -1;
		if (!flag3 || flag4)
		{
			for (int j = 0; j < dynamicBuffer.Length + (flag ? 1 : 0); j++)
			{
				nativeList.Add((j == dynamicBuffer.Length) ? targetEntity : dynamicBuffer[j].entity);
			}
			if (c._lastAttackerGroup.TryGetComponent(entity, out var componentData4) && componentData4.Value != Entity.Null && (!value.lastAttackerCheckCooldownTimer.isRunning || value.lastAttackerCheckCooldownTimer.IsTimerElapsed(d._elapsedTime)))
			{
				num = nativeList.Length;
				nativeList.Add(in componentData4.Value);
			}
			if (c._eatStateGroup.HasComponent(entity) || c._leashedGroup.HasComponent(entity))
			{
				int num2 = 0;
				for (int k = 0; k < nativeList.Length; k++)
				{
					Entity entity2 = nativeList[k];
					if (c._playerGhostGroup.HasComponent(entity2))
					{
						int index = k;
						int index2 = num2;
						Entity entity3 = nativeList[num2];
						Entity entity4 = nativeList[k];
						Entity entity5 = (nativeList[index] = entity3);
						entity5 = (nativeList[index2] = entity4);
						num2++;
					}
				}
			}
		}
		bool flag6 = false;
		if (!value.breedCheckCooldownTimer.isRunning || value.breedCheckCooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			flag6 = c._breedStateGroup.HasComponent(entity) && c._eatStateGroup.HasComponent(entity) && c._mealsEatenGroup.HasComponent(entity) && c._breedStateGroup[entity].HasEatenEnough(c._mealsEatenGroup[entity]) && c._objectDataGroup[entity].amount >= c._eatStateGroup[entity].maxFoodUntilFull;
			if (flag6)
			{
				int num3 = 0;
				for (int l = 0; l < nativeList.Length; l++)
				{
					Entity entity8 = nativeList[l];
					if (c._cattleGroup.HasComponent(entity8))
					{
						num3++;
						if (num3 >= 50)
						{
							flag6 = false;
							break;
						}
					}
				}
			}
			if (!value.restartBreedCheckCooldownTimer.isRunning)
			{
				value.restartBreedCheckCooldownTimer.Start(d._elapsedTime, 1f);
			}
			if (value.restartBreedCheckCooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.breedCheckCooldownTimer.Start(d._elapsedTime, 10f + 20f * d._rng.NextFloat());
				value.restartBreedCheckCooldownTimer.Stop();
			}
		}
		for (int m = 0; m < nativeList.Length; m++)
		{
			Entity entity9 = nativeList[m];
			Entity entity10 = entity9;
			bool flag7 = false;
			if (c._entityPartGroup.TryGetComponent(entity9, out var componentData5))
			{
				entity10 = componentData5.mainEntity;
			}
			bool flag8 = m < length2;
			bool flag9 = m < length;
			bool flag10 = m == num;
			if (((flag5 || flag4) && !flag9 && c._bossGroup.HasComponent(entity10) && c._isInCombatGroup.TryGetComponent(entity10, out var componentData6) && !componentData6.isInCombat && !c._snakeMovementGroup.HasComponent(entity10)) || !c._healthGroup.HasComponent(entity10) || (float)c._healthGroup[entity10].health <= 0f || (c._immuneToDamage.TryGetComponent(entity9, out var componentData7) && componentData7.Value == ImmuneToDamageState.Immune))
			{
				continue;
			}
			bool flag11 = false;
			bool flag12 = false;
			bool flag13 = false;
			bool flag14 = false;
			if ((!c._entityDestroyedGroup.HasComponent(entity10) || !c._entityDestroyedGroup.IsComponentEnabled(entity10)) && !c._physicsExcludeGroup.HasAndIsComponentEnabled(entity9) && c._objectDataGroup.HasComponent(entity10))
			{
				flag14 = c._leashedGroup.HasComponent(entity) && c._leashedGroup[entity].leashedToEntity == entity10;
				if (!flag14 && flag6 && c._objectDataGroup[entity10].objectID == c._objectDataGroup[entity].objectID && c._breedStateGroup.HasComponent(entity10) && c._eatStateGroup.HasComponent(entity10) && c._mealsEatenGroup.HasComponent(entity10))
				{
					bool num4 = c._breedStateGroup[entity10].HasEatenEnough(c._mealsEatenGroup[entity10]);
					bool flag15 = c._objectDataGroup[entity10].amount >= c._eatStateGroup[entity10].maxFoodUntilFull;
					if (num4 && flag15)
					{
						flag11 = true;
					}
				}
				if (!flag14 && !flag11 && c._equippedObjectGroup.TryGetComponent(entity10, out var componentData8))
				{
					ContainedObjectsBuffer containedObject = componentData8.containedObject;
					if (containedObject.objectID != ObjectID.None)
					{
						flag12 = c._objectCategoryTagsGroup.TryGetComponent(componentData8.equipmentPrefab, out var componentData9) && BehaviourTagsCD.Eats(behaviourTagsCD, componentData9);
						if (!flag12 && objectPropertiesCD.TryGetList(158600710, out NativeArray<ObjectID> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							for (int n = 0; n < value2.Length; n++)
							{
								if (value2[n] == containedObject.objectID)
								{
									flag12 = true;
									break;
								}
							}
						}
					}
				}
				if (!flag14 && !flag11 && !flag12 && c._objectDataGroup[entity].amount < ((!c._eatStateGroup.HasComponent(entity)) ? 1 : ((int)math.ceil((double)c._eatStateGroup[entity].maxFoodUntilFull / 2.0))) && c._objectDataGroup[entity10].objectID == ObjectID.CattleFeedTray && c._containedObjectsBufferGroup.HasComponent(entity10))
				{
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = c._containedObjectsBufferGroup[entity10];
					for (int num5 = 0; num5 < dynamicBuffer2.Length; num5++)
					{
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer2[num5].objectID, d.database);
						if (c._objectCategoryTagsGroup.TryGetComponent(primaryPrefabEntity, out var componentData10) && BehaviourTagsCD.Eats(behaviourTagsCD, componentData10))
						{
							flag13 = true;
							break;
						}
					}
				}
				FactionCD targetFaction = (c._factionGroup.HasComponent(entity10) ? c._factionGroup[entity10] : default(FactionCD));
				bool flag16 = !c._petGroup.HasComponent(entity) || !c._shieldGroup.HasComponent(entity10) || !c._shieldGroup[entity10].active;
				flag7 = flag14 || flag11 || flag12 || flag13 || (c._objectCategoryTagsGroup.TryGetComponent(entity10, out var componentData11) && ((BehaviourTagsCD.WantsToAndCanAttack(behaviourTagsCD, componentData11) && factionCD.CanAttack(targetFaction, d.worldInfo) && flag16) || (BehaviourTagsCD.Eats(behaviourTagsCD, componentData11) && c._objectDataGroup[entity].amount < ((!c._eatStateGroup.HasComponent(entity)) ? 1 : c._eatStateGroup[entity].maxFoodUntilFull))));
			}
			flag2 = flag2 || flag7;
			if (!flag7)
			{
				continue;
			}
			float3 position2 = c._localTransformGroup[entity9].Position;
			float num6 = (c._combatRadiusGroup.HasComponent(entity9) ? c._combatRadiusGroup[entity9].radiusSq : 0f);
			float num7 = math.distancesq(position, position2) - num6;
			float num8 = (flag9 ? 400f : value.chaseAtDistanceSq);
			if (flag10)
			{
				num8 = 400f;
			}
			if ((!flag14 && !flag9 && entity9 != targetEntity && num7 > num8) || (!flag14 && value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime) && num7 > num8 * 0.5f))
			{
				continue;
			}
			bool flag17 = false;
			bool flag18 = false;
			bool flag19 = objectPropertiesCD.Has(897405507);
			bool flag20 = objectPropertiesCD.Has(-1004432830);
			bool flag21 = objectPropertiesCD.Has(1667637084);
			float num9 = objectPropertiesCD.Get<float>(743376721);
			float newLifespan = objectPropertiesCD.Get<float>(1953737544);
			if ((!flag8 || !pathFindCD.isFlying) && !flag14 && !flag19 && !flag10 && !flag20 && (targetEntity != entity9 || !flag))
			{
				float3 topos = position2 + new float3(0f, 0.5f, 0f);
				uint layerMaskCollidesWith = (flag21 ? 1u : 131329u);
				RaycastInput raycastInput = PhysicsManager.GetRaycastInput(frompos, topos, uint.MaxValue, layerMaskCollidesWith);
				if (d.collisionWorld.CastRay(raycastInput, out var closestHit) && closestHit.Entity != entity9)
				{
					flag18 = true;
					if (!flag21)
					{
						layerMaskCollidesWith = 1u;
						raycastInput = PhysicsManager.GetRaycastInput(frompos, topos, uint.MaxValue, layerMaskCollidesWith);
						flag17 = d.collisionWorld.CastRay(raycastInput);
					}
					else
					{
						flag17 = true;
					}
				}
				int2 int5 = position.RoundToInt2();
				int2 end = position2.RoundToInt2();
				int2 pos = int5;
				do
				{
					TileCD tile;
					bool flag22 = d.tileLookup.TryGetBlockingTile(pos, out tile, !flag21);
					bool flag23 = tile.tileType.IsLowCollider();
					flag18 = flag18 || (flag22 && (!flag21 || !flag23));
					flag17 = flag17 || (flag22 && !flag23);
				}
				while (!flag17 && MathUtilities.NextPosOnLine(int5, end, ref pos));
			}
			if (!flag17 && pathFindCD.targetEntity == Entity.Null)
			{
				pathFindCD.targetEntity = entity9;
				pathFindCD.blockedByCreatures = flag13;
			}
			if (flag14 || (!flag18 && (!flag19 || !(pathFindCD.pathValidTime < 0f))))
			{
				if (flag10)
				{
					value.lastAttackerCheckCooldownTimer.Start(d._elapsedTime, 5f);
				}
				value.internalState = 0;
				value.targetEntity = entity9;
				value.cooldownTimer.Stop();
				value.phaseChaseTimer.Stop();
				value.chaseTimer.Start(d._elapsedTime, d._rng.NextFloat(7f, 10f));
				value.isChasingByLastAttacker = flag10;
				value.isMinionCommandTarget = flag9;
				if (num9 > 0f)
				{
					value.idleCooldownTimer.Start(d._elapsedTime, newLifespan);
					value.idleTimer.Stop();
				}
				stateInfo.EnterState(StateID.Chase);
				pathFindCD.targetEntity = entity9;
				pathFindCD.blockedByCreatures = flag13;
				if (c._minionGroup.HasComponent(entity) || c._petGroup.HasComponent(entity))
				{
					pathFindCD.searchRadius = (int)math.ceil(math.sqrt(num8) * 2f);
				}
				else
				{
					pathFindCD.searchRadius = (int)math.ceil(math.sqrt(num8));
				}
				break;
			}
		}
		if (!flag2)
		{
			value.shouldEnterStateCheckTimer = d._rng.NextFloat(1f, 2f);
		}
		c._chaseStateGroup[entity] = value;
		c._pathFindGroup[pathFindEntity] = pathFindCD;
		nativeList.Dispose();
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(UpdateHealthSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct UpdateHealthFromBufferSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct UpdateHealthFromBufferJob : IJob
	{
		public uint simulationTickRate;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> damageReductionGroup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBuffer;

		public Entity killedEnemiesBufferEntityLocal;

		public bool isServerLocal;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public TileAccessor tileLookUp;

		public Entity healthChangeBufferEntity;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public bool isCreativeMode;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> playerStateCDLookup;

		[ReadOnly]
		public ComponentLookup<PlayerInvincibilityCD> playerInvincibilityCDLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		[ReadOnly]
		public ComponentLookup<GhostInstance> ghostInstanceLookup;

		public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

		public NetworkTick currentTick;

		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> playerStateLookup;

		public ComponentLookup<MagicBarrierCD> magicBarrierLookup;

		public ComponentLookup<ManaCD> manaLookup;

		public ComponentLookup<DontDropLootCD> dontDropLootLookup;

		public ComponentLookup<DontDropSelfCD> dontDropSelfLookup;

		public uint serverSystemSeed;

		[ReadOnly]
		public ComponentLookup<Simulate> simulationLookup;

		public ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerLookup;

		public ComponentLookup<DamageEffectCD> damageTakenLookup;

		public ComponentLookup<HealthRegenerationCD> healthRegenerationLookup;

		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		public ComponentLookup<MoveToPredictedByEntityDestroyedCD> moveToPredictedByEntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> merchantLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileCD> projectileLookup;

		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> nearbyEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public ComponentLookup<DropsLootWhenDamagedCD> dropsLootWhenDamagedLookup;

		[ReadOnly]
		public ComponentLookup<PutTargetInCombatOnDealingDamageCD> putTargetInCombatOnDealingDamageLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		public ComponentLookup<PlantCD> plantLookup;

		[ReadOnly]
		public ComponentLookup<RootPlantCD> rootPlantLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> growingLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> amountOfTimesTakingDamageCounterLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToSkipLootDropCD> immuneToSkipLootDropLookup;

		public BufferLookup<KilledEnemiesBuffer> killedEnemiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		public ComponentLookup<LastDamageTakenTimeCD> lastDamageTakenTimeLookup;

		[ReadOnly]
		public WorldInfoCD worldInfo;

		public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<ChanceToApplyConditionToSelfWhenDamagedBufferElement> chanceToApplyConditionToSelfWhenDamagedBufferLookup;

		[ReadOnly]
		public ComponentLookup<IgnoreImmuneZoneCD> ignoreImmuneZoneLookup;

		public bool isFirstTimeFullyPredictingTick;

		public EntityCommandBuffer ecb;

		public ConditionsTableCD conditionsTableCD;

		public void Execute()
		{
			DynamicBuffer<HealthChangeBuffer> dynamicBuffer = healthChangeBufferLookup[healthChangeBufferEntity];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				Entity entity = dynamicBuffer[i].healthChange.entity;
				if (!healthLookup.TryGetComponent(entity, out var componentData))
				{
					continue;
				}
				HealthChange healthChange = dynamicBuffer[i].healthChange;
				int num = healthChange.amount;
				if (healthChange.wasKilled && moveToPredictedByEntityDestroyedLookup.HasComponent(entity))
				{
					moveToPredictedByEntityDestroyedLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(currentTick);
				}
				if (componentData.health <= 0)
				{
					continue;
				}
				bool flag = !healthChange.applyToNonPredicted && simulationLookup.HasComponent(entity) && !simulationLookup.IsComponentEnabled(entity);
				if (!flag && playerGhostLookup.HasComponent(entity))
				{
					HealthChangeBuffer healthChangeBuffer = dynamicBuffer[i];
					if (healthChangeBuffer.healthChange.amount > 0)
					{
						PlayerController.HealPlayer(healthChangeBuffer.healthChange.amount, ref healthLookup.GetRefRW(entity).ValueRW, playerStateLookup[entity], summarizedConditionEffectsBufferLookup[entity]);
					}
					else
					{
						PlayerController.DealDamageToPlayer(entity, healthChange.causedByEntity, -healthChangeBuffer.healthChange.amount, DamageEffectType.None, float3.zero, float3.zero, float3.zero, 0f, isExplosiveDamage: false, playerStateCDLookup, lastDamageTakenTimeLookup, playerInvincibilityCDLookup, healthLookup, localTransformLookup, magicBarrierLookup, manaLookup, summarizedConditionsBufferLookup, summarizedConditionEffectsBufferLookup, ghostEffectEventBufferLookup, ghostEffectEventBufferPointerLookup, ghostInstanceLookup, receivedPushbackLookup, factionLookup, ownerLookup, worldInfo, currentTick, simulationTickRate);
					}
					continue;
				}
				int num2 = 0;
				bool flag2 = false;
				bool flag3 = false;
				Entity entity2 = Entity.Null;
				bool shouldPullLootToPlayer = false;
				bool requestTookDamageState = false;
				bool flag4 = false;
				float num3 = 1f;
				objectDataLookup.TryGetComponent(entity, out var componentData2);
				bool flag5 = false;
				DropsLootWhenDamagedCD componentData3;
				bool flag6 = dropsLootWhenDamagedLookup.TryGetComponent(entity, out componentData3);
				float3 x = localTransformLookup[entity].Position + PugDatabase.GetEntityLocalCenter(componentData2.objectID, databaseBankCD.databaseBankBlob);
				if (num < 0 && !enemyLookup.HasComponent(entity) && !playerGhostLookup.HasComponent(entity) && !ignoreImmuneZoneLookup.HasComponent(entity))
				{
					tileLookUp.HasType(x.RoundToInt2(), TileType.immune);
				}
				Entity causedByEntity = healthChange.causedByEntity;
				GhostInstance componentData4;
				Unity.Mathematics.Random rng = ((!ghostInstanceLookup.TryGetComponent(entity, out componentData4)) ? PugRandom.GetRngFromEntity(serverSystemSeed, currentTick, entity) : PugRandom.GetRngFromEntity(serverSystemSeed, currentTick, componentData4));
				if (!flag && flag6 && math.any(healthChange.optionalPositionToDropLootWhenDamaged != float2.zero) && (math.all(componentData3.dropLootPosition == float2.zero) || rng.NextBool()))
				{
					componentData3.dropLootPosition = healthChange.optionalPositionToDropLootWhenDamaged;
					dropsLootWhenDamagedLookup[entity] = componentData3;
				}
				if (!flag4 && num < 0)
				{
					flag4 = dynamicBuffer[i].healthChange.damagedByExplosion;
				}
				if (num < 0)
				{
					if (!healthChange.bypassDamageReduction && damageReductionGroup.HasComponent(entity))
					{
						num = math.min(num + damageReductionGroup[entity].reduction, 0);
					}
					num = (int)math.round((float)num * num3);
				}
				else if (num > 0 && summarizedConditionsEffectsBuffer.HasComponent(entity) && summarizedConditionsEffectsBuffer[entity][12].value > 0)
				{
					num = (int)math.max(math.round((float)num * 0.25f), 1f);
				}
				if (num <= 0 && damageReductionGroup.HasComponent(entity) && damageReductionGroup[entity].minDamagePerHit > 0)
				{
					num = math.min(-damageReductionGroup[entity].minDamagePerHit, num);
				}
				if (num < 0 && !healthChange.bypassMaxDamagePerHit && damageReductionGroup.HasComponent(entity) && damageReductionGroup[entity].maxDamagePerHit > 0)
				{
					num = math.max(num, -damageReductionGroup[entity].maxDamagePerHit);
				}
				if (flag)
				{
					if (componentData.health > -1 * num && num < 0)
					{
						int health = componentData.health;
						componentData.health = math.clamp(componentData.health + num, 0, componentData.maxHealth);
						DoDamageEffects(damageTakenTriggerLookup, entity, requestTookDamageState: false, damageTakenLookup, ghostEffectEventBufferLookup, healthChange.causedByEntity, currentTick, ghostEffectEventBufferPointerLookup, healthChange, health, componentData, magicBarrierLookup, num);
					}
					continue;
				}
				num2 += num;
				Entity entity3 = Entity.Null;
				if (playerGhostLookup.HasComponent(causedByEntity))
				{
					entity3 = causedByEntity;
				}
				if (healthChange.wasKnockedBack || !enemyLookup.HasComponent(entity) || putTargetInCombatOnDealingDamageLookup.HasComponent(causedByEntity) || (ownerLookup.TryGetComponent(causedByEntity, out var componentData5) && putTargetInCombatOnDealingDamageLookup.HasComponent(componentData5.owner)))
				{
					requestTookDamageState = true;
				}
				if (healthChange.wasKilled)
				{
					num2 = -componentData.health;
					flag5 = true;
				}
				if (componentData.health + num2 <= 0)
				{
					TileCD componentData6;
					if (dynamicBuffer[i].healthChange.skipLootDropOnDestroy)
					{
						flag2 = true;
						flag3 = true;
					}
					else if (dynamicBuffer[i].healthChange.skipLootDropIfDestroyPlants && IsNonRootPlantThatHasFinishedGrowing(entity))
					{
						flag2 = true;
					}
					else if (dynamicBuffer[i].healthChange.skipWallAndRootsLootDropOnDestroy && tileLookup.TryGetComponent(entity, out componentData6) && (componentData6.tileType == TileType.wall || componentData6.tileType == TileType.bigRoot))
					{
						flag2 = true;
						flag3 = true;
					}
					Entity entity4 = causedByEntity;
					OwnerReferenceCD componentData7;
					if (entity3 != Entity.Null)
					{
						entity2 = causedByEntity;
						shouldPullLootToPlayer = healthChange.pullLootToPlayer;
					}
					else if (ownerLookup.TryGetComponent(causedByEntity, out componentData7))
					{
						int num4 = 0;
						Entity owner = componentData7.owner;
						entity4 = owner;
						while (owner != Entity.Null && num4 < 10)
						{
							if (playerGhostLookup.HasComponent(owner))
							{
								entity2 = owner;
								break;
							}
							if (ownerLookup.TryGetComponent(owner, out var componentData8))
							{
								owner = componentData8.owner;
							}
							num4++;
						}
					}
					if (flag4 && isExplosiveLookup.HasComponent(entity))
					{
						isExplosiveLookup.GetRefRW(entity).ValueRW.wasKilledByAnotherExplosive = true;
					}
					if (dynamicBuffer[i].healthChange.causedByEntity != Entity.Null && plantLookup.HasComponent(entity) && summarizedConditionsEffectsBuffer.HasComponent(causedByEntity))
					{
						int num5 = PugRandom.GenerateRandomExtraItems((float)summarizedConditionsEffectsBuffer[causedByEntity][23].value / 1000f, ref rng);
						if (num5 > 0)
						{
							PlantCD value = plantLookup[entity];
							value.numberOfPlantsToDrop += num5;
							plantLookup[entity] = value;
						}
					}
					if (enemyLookup.HasComponent(entity) && summarizedConditionsBufferLookup.TryGetBuffer(entity4, out var bufferData))
					{
						if (bufferData[65].value > 0 && simulationLookup.HasAndIsComponentEnabled(entity4))
						{
							EntityUtility.AddOrRefreshCondition(new ConditionData
							{
								conditionID = ConditionID.StackedCritChance,
								duration = 8f,
								value = 3,
								valueMultiplier = 1f
							}, conditionsBufferLookup[entity4], conditionsTableCD, currentTick, simulationTickRate, bufferData);
						}
						int value2 = bufferData[175].value;
						if (value2 > 0 && rng.NextFloat() < (float)value2 / 100f && isFirstTimeFullyPredictingTick)
						{
							float3 position = localTransformLookup[entity].Position;
							if (tileLookUp.GetTopType(position.RoundToInt2()).IsWalkableTile())
							{
								Entity entity5 = EntityUtility.CreateEntity(ecb, position, ObjectID.GhostScholar, 1, databaseBankCD.databaseBankBlob);
								EntityUtility.InheritFaction(ecb, entity4, entity5, factionLookup);
							}
						}
					}
				}
				DynamicBuffer<ConditionsBuffer> bufferData2;
				bool flag7 = conditionsBufferLookup.TryGetBuffer(entity, out bufferData2);
				if (!flag5 && num2 != 0 && num2 < 0 && summarizedConditionsEffectsBuffer.HasComponent(entity))
				{
					int value3 = summarizedConditionsEffectsBuffer[entity][98].value;
					if (value3 > 0)
					{
						int num6 = math.max(value3 + num2, 0);
						num2 = 0;
						if (num6 > 0)
						{
							EntityUtility.AddOrRefreshCondition(new ConditionData
							{
								conditionID = ConditionID.ProtectiveArmor,
								duration = float.PositiveInfinity,
								value = num6,
								valueMultiplier = 1f
							}, bufferData2, conditionsTableCD, currentTick, simulationTickRate, summarizedConditionsBufferLookup[entity]);
						}
						else
						{
							EntityUtility.RemoveCondition(ConditionID.ProtectiveArmor, bufferData2);
						}
					}
					if (chanceToApplyConditionToSelfWhenDamagedBufferLookup.TryGetBuffer(entity, out var bufferData3))
					{
						for (int j = 0; j < bufferData3.Length; j++)
						{
							float time = math.clamp((float)componentData.health / (float)componentData.maxHealth, 0f, 1f);
							float num7 = 100f * math.clamp((float)(-num2) / (float)componentData.maxHealth, 0f, 1f);
							BlobAssetReference<BlobCurve> blob = bufferData3[i].chanceForEachPercentDamageTakenByCurrentHealthPercentage;
							float num8 = blob.Evaluate(in time);
							if (rng.NextFloat() < num7 * num8)
							{
								EntityUtility.AddOrRefreshCondition(bufferData3[i].conditionData, bufferData2, conditionsTableCD, currentTick, simulationTickRate, summarizedConditionsBufferLookup[entity]);
							}
						}
					}
				}
				if (flag5 && flag7)
				{
					EntityUtility.RemoveCondition(ConditionID.ProtectiveArmor, bufferData2);
				}
				if (num2 == 0)
				{
					continue;
				}
				int health2 = componentData.health;
				componentData.health = math.clamp(componentData.health + num2, 0, componentData.maxHealth);
				if (health2 > componentData.health && componentData.health > 0)
				{
					DoDamageEffects(damageTakenTriggerLookup, entity, requestTookDamageState, damageTakenLookup, ghostEffectEventBufferLookup, causedByEntity, currentTick, ghostEffectEventBufferPointerLookup, healthChange, health2, componentData, magicBarrierLookup, num);
				}
				if (componentData.health != 0 && num2 < 0 && amountOfTimesTakingDamageCounterLookup.TryGetComponent(entity, out var componentData9) && isFirstTimeFullyPredictingTick)
				{
					componentData9.count++;
					ecb.SetComponent(entity, componentData9);
				}
				if (health2 >= componentData3.minHealthToDropLoot && flag6 && !flag2 && componentData3.damageToDealToDropLoot > 0)
				{
					int damageToDealToDropLoot = componentData3.damageToDealToDropLoot;
					int num9 = health2 / damageToDealToDropLoot;
					int num10 = math.max(componentData.health, componentData3.minHealthToDropLoot) / damageToDealToDropLoot;
					int num11 = num9 - num10;
					bool flag8 = false;
					if (num11 > 0 && componentData3.maxLimitToDropInNearbyArea > 0 && nearbyEntitiesLookup.HasBuffer(entity))
					{
						int num12 = 0;
						for (int k = 0; k < nearbyEntitiesLookup[entity].Length; k++)
						{
							Entity entity6 = nearbyEntitiesLookup[entity][k].entity;
							if (objectDataLookup.TryGetComponent(entity6, out var componentData10) && componentData3.dropsLoot == componentData10.objectID)
							{
								num12++;
								if (num12 >= componentData3.maxLimitToDropInNearbyArea)
								{
									flag8 = true;
									break;
								}
							}
						}
					}
					if (num11 > 0 && !flag8)
					{
						float2 float5 = componentData3.dropLootPosition;
						if (math.all(float5 == float2.zero))
						{
							float5 = localTransformLookup[entity].Position.ToFloat2() + rng.NextFloat2(componentData3.minSpawnOffset, componentData3.maxSpawnOffset);
						}
						else
						{
							componentData3.dropLootPosition = float2.zero;
							dropsLootWhenDamagedLookup[entity] = componentData3;
						}
						if (isFirstTimeFullyPredictingTick)
						{
							if (componentData3.instantiateEntity)
							{
								EntityUtility.CreateEntity(ecb, float5.ToFloat3(), componentData3.dropsLoot, 1, databaseBankCD.databaseBankBlob);
							}
							else
							{
								EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
								{
									objectData = new ObjectDataCD
									{
										objectID = componentData3.dropsLoot,
										amount = num11
									}
								}, float5.ToFloat3(), databaseBankCD.databaseBankBlob, healthChange.pullLootToPlayer ? entity3 : Entity.Null);
							}
						}
					}
				}
				if (componentData.health == 0)
				{
					if (isCreativeMode || !immuneToSkipLootDropLookup.HasComponent(entity))
					{
						if (flag3 && dontDropSelfLookup.HasComponent(entity))
						{
							dontDropSelfLookup.SetComponentEnabled(entity, value: true);
						}
						if (flag2 && dontDropLootLookup.HasComponent(entity))
						{
							dontDropLootLookup.SetComponentEnabled(entity, value: true);
						}
					}
					if (entity2 != Entity.Null)
					{
						if (killedByPlayerLookup.HasComponent(entity))
						{
							killedByPlayerLookup.GetRefRW(entity).ValueRW = new KilledByPlayerCD
							{
								playerEntity = entity2,
								shouldPullLootToPlayer = shouldPullLootToPlayer,
								killedByPlayerExplosion = flag4
							};
							killedByPlayerLookup.SetComponentEnabled(entity, value: true);
						}
						if (PlayerController.ReceivesVitalityFromKillingEntity(entity, enemyLookup, merchantLookup, playerGhostLookup, projectileLookup))
						{
							int amount = math.min(componentData.maxHealth, 1000);
							PlayerController.AddSkill(entity2, SkillID.Vitality, amount, ecb, isServerLocal);
						}
					}
					if (isServerLocal && (entity2 != Entity.Null || bossLookup.HasComponent(entity)))
					{
						DynamicBuffer<KilledEnemiesBuffer> buffer = killedEnemiesBufferLookup[killedEnemiesBufferEntityLocal];
						bool exists;
						int index = EntityUtility.FindSorted(ref buffer, new KilledEnemiesBuffer
						{
							objectData = componentData2
						}, default(KilledEnemiesBufferComparer), out exists);
						if (exists)
						{
							buffer.ElementAt(index).objectData.amount++;
						}
						else
						{
							buffer.Insert(index, new KilledEnemiesBuffer
							{
								objectData = new ObjectDataCD
								{
									objectID = componentData2.objectID,
									variation = componentData2.variation,
									amount = 1
								}
							});
						}
					}
				}
				healthLookup[entity] = componentData;
			}
			dynamicBuffer.Clear();
		}

		private bool IsNonRootPlantThatHasFinishedGrowing(Entity entity)
		{
			if (plantLookup.HasComponent(entity) && !rootPlantLookup.HasComponent(entity) && growingLookup.TryGetComponent(entity, out var componentData) && objectPropertiesLookup.TryGetComponent(entity, out var componentData2))
			{
				return componentData.HasFinishedGrowing(componentData2);
			}
			return false;
		}
	}

	[BurstCompile]
	[WithNone(new Type[] { typeof(PlayerGhost) })]
	[WithAll(new Type[] { typeof(EntityDestroyedCD) })]
	private struct SetAllDestroyedEntitiesZeroHealthJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
				}

				public void Update(ref SystemState state)
				{
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetAllDestroyedEntitiesZeroHealthJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref HealthCD healthCD)
		{
			healthCD.health = 0;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerInvincibilityCD> __PlayerInvincibilityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentLookup;

		public ComponentLookup<ReceivedPushbackCD> __ReceivedPushbackCD_RW_ComponentLookup;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		public ComponentLookup<MagicBarrierCD> __MagicBarrierCD_RW_ComponentLookup;

		public ComponentLookup<ManaCD> __ManaCD_RW_ComponentLookup;

		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RW_ComponentLookup;

		public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

		public ComponentLookup<DamageTakenTriggerCD> __DamageTakenTriggerCD_RW_ComponentLookup;

		public ComponentLookup<DamageEffectCD> __DamageEffectCD_RW_ComponentLookup;

		public ComponentLookup<HealthRegenerationCD> __HealthRegenerationCD_RW_ComponentLookup;

		public ComponentLookup<KilledByPlayerCD> __KilledByPlayerCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		public ComponentLookup<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> __MerchantCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileCD> __ProjectileCD_RO_ComponentLookup;

		public ComponentLookup<IsExplosiveCD> __IsExplosiveCD_RW_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		public ComponentLookup<DropsLootWhenDamagedCD> __DropsLootWhenDamagedCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PutTargetInCombatOnDealingDamageCD> __PutTargetInCombatOnDealingDamageCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

		public ComponentLookup<PlantCD> __PlantCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RootPlantCD> __RootPlantCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> __GrowingCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> __AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToSkipLootDropCD> __ImmuneToSkipLootDropCD_RO_ComponentLookup;

		public BufferLookup<KilledEnemiesBuffer> __KilledEnemiesBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

		public ComponentLookup<LastDamageTakenTimeCD> __LastDamageTakenTimeCD_RW_ComponentLookup;

		public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<ChanceToApplyConditionToSelfWhenDamagedBufferElement> __ChanceToApplyConditionToSelfWhenDamagedBufferElement_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<IgnoreImmuneZoneCD> __IgnoreImmuneZoneCD_RO_ComponentLookup;

		public SetAllDestroyedEntitiesZeroHealthJob.InternalCompilerQueryAndHandleData __UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__PlayerInvincibilityCD_RO_ComponentLookup = state.GetComponentLookup<PlayerInvincibilityCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			__Unity_NetCode_GhostInstance_RO_ComponentLookup = state.GetComponentLookup<GhostInstance>(isReadOnly: true);
			__ReceivedPushbackCD_RW_ComponentLookup = state.GetComponentLookup<ReceivedPushbackCD>();
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__MagicBarrierCD_RW_ComponentLookup = state.GetComponentLookup<MagicBarrierCD>();
			__ManaCD_RW_ComponentLookup = state.GetComponentLookup<ManaCD>();
			__DontDropLootCD_RW_ComponentLookup = state.GetComponentLookup<DontDropLootCD>();
			__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
			__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			__DamageTakenTriggerCD_RW_ComponentLookup = state.GetComponentLookup<DamageTakenTriggerCD>();
			__DamageEffectCD_RW_ComponentLookup = state.GetComponentLookup<DamageEffectCD>();
			__HealthRegenerationCD_RW_ComponentLookup = state.GetComponentLookup<HealthRegenerationCD>();
			__KilledByPlayerCD_RW_ComponentLookup = state.GetComponentLookup<KilledByPlayerCD>();
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPredictedByEntityDestroyedCD>();
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__MerchantCD_RO_ComponentLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__ProjectileCD_RO_ComponentLookup = state.GetComponentLookup<ProjectileCD>(isReadOnly: true);
			__IsExplosiveCD_RW_ComponentLookup = state.GetComponentLookup<IsExplosiveCD>();
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__DropsLootWhenDamagedCD_RW_ComponentLookup = state.GetComponentLookup<DropsLootWhenDamagedCD>();
			__PutTargetInCombatOnDealingDamageCD_RO_ComponentLookup = state.GetComponentLookup<PutTargetInCombatOnDealingDamageCD>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			__PlantCD_RW_ComponentLookup = state.GetComponentLookup<PlantCD>();
			__RootPlantCD_RO_ComponentLookup = state.GetComponentLookup<RootPlantCD>(isReadOnly: true);
			__GrowingCD_RO_ComponentLookup = state.GetComponentLookup<GrowingCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup = state.GetComponentLookup<AmountOfTimesTakingDamageCounterCD>(isReadOnly: true);
			__ImmuneToSkipLootDropCD_RO_ComponentLookup = state.GetComponentLookup<ImmuneToSkipLootDropCD>(isReadOnly: true);
			__KilledEnemiesBuffer_RW_BufferLookup = state.GetBufferLookup<KilledEnemiesBuffer>();
			__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
			__LastDamageTakenTimeCD_RW_ComponentLookup = state.GetComponentLookup<LastDamageTakenTimeCD>();
			__ConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<ConditionsBuffer>();
			__ChanceToApplyConditionToSelfWhenDamagedBufferElement_RO_BufferLookup = state.GetBufferLookup<ChanceToApplyConditionToSelfWhenDamagedBufferElement>(isReadOnly: true);
			__IgnoreImmuneZoneCD_RO_ComponentLookup = state.GetComponentLookup<IgnoreImmuneZoneCD>(isReadOnly: true);
			__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00004734_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00004734_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00004734_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00004735_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00004735_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00004735_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	private Entity _killedEnemiesBufferEntity;

	private Entity _healthChangeBufferEntity;

	private uint _systemSeed;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_937869303_0;

	private EntityQuery __query_937869303_1;

	private EntityQuery __query_937869303_2;

	private EntityQuery __query_937869303_3;

	private EntityQuery __query_937869303_4;

	private EntityQuery __query_937869303_5;

	private EntityQuery __query_937869303_6;

	private EntityQuery __query_937869303_7;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<ConditionsTableCD>();
		if (state.WorldUnmanaged.IsServer())
		{
			state.RequireForUpdate<KilledEnemiesBuffer>();
		}
		_healthChangeBufferEntity = state.EntityManager.CreateSingletonBuffer<HealthChangeBuffer>();
		_systemSeed = EntityUtility.SeedFromSystem("UpdateHealthFromBufferSystem");
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (state.WorldUnmanaged.IsServer())
		{
			_killedEnemiesBufferEntity = __query_937869303_0.GetSingletonEntity();
		}
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_937869303_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		_tileAccessor.Update(ref state);
		if (!__query_937869303_2.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_937869303_3.TryGetSingleton<NetworkTime>(out var value2);
		WorldInfoCD singleton = __query_937869303_4.GetSingleton<WorldInfoCD>();
		state.Dependency = IJobExtensions.Schedule(new UpdateHealthFromBufferJob
		{
			simulationTickRate = (uint)value.SimulationTickRate,
			damageReductionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state),
			summarizedConditionsEffectsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			killedEnemiesBufferEntityLocal = _killedEnemiesBufferEntity,
			isServerLocal = state.WorldUnmanaged.IsServer(),
			databaseBankCD = __query_937869303_5.GetSingleton<PugDatabase.DatabaseBankCD>(),
			tileLookUp = _tileAccessor,
			healthChangeBufferEntity = _healthChangeBufferEntity,
			healthChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state),
			isCreativeMode = singleton.IsWorldModeEnabled(WorldMode.Creative),
			playerStateCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state),
			playerInvincibilityCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerInvincibilityCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			summarizedConditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
			ghostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
			ghostInstanceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentLookup, ref state),
			receivedPushbackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ReceivedPushbackCD_RW_ComponentLookup, ref state),
			currentTick = value2.ServerTick,
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			playerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state),
			magicBarrierLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MagicBarrierCD_RW_ComponentLookup, ref state),
			manaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManaCD_RW_ComponentLookup, ref state),
			dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref state),
			dontDropSelfLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref state),
			serverSystemSeed = (__query_937869303_6.GetSingleton<ServerSeedCD>().Value ^ _systemSeed),
			simulationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
			damageTakenTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageTakenTriggerCD_RW_ComponentLookup, ref state),
			damageTakenLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageEffectCD_RW_ComponentLookup, ref state),
			healthRegenerationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthRegenerationCD_RW_ComponentLookup, ref state),
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RW_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			moveToPredictedByEntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			merchantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MerchantCD_RO_ComponentLookup, ref state),
			playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
			projectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileCD_RO_ComponentLookup, ref state),
			isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RW_ComponentLookup, ref state),
			nearbyEntitiesLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			dropsLootWhenDamagedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DropsLootWhenDamagedCD_RW_ComponentLookup, ref state),
			putTargetInCombatOnDealingDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PutTargetInCombatOnDealingDamageCD_RO_ComponentLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
			plantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RW_ComponentLookup, ref state),
			rootPlantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RootPlantCD_RO_ComponentLookup, ref state),
			growingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GrowingCD_RO_ComponentLookup, ref state),
			objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
			amountOfTimesTakingDamageCounterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup, ref state),
			immuneToSkipLootDropLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToSkipLootDropCD_RO_ComponentLookup, ref state),
			killedEnemiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__KilledEnemiesBuffer_RW_BufferLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			lastDamageTakenTimeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LastDamageTakenTimeCD_RW_ComponentLookup, ref state),
			worldInfo = __query_937869303_4.GetSingleton<WorldInfoCD>(),
			conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
			chanceToApplyConditionToSelfWhenDamagedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ChanceToApplyConditionToSelfWhenDamagedBufferElement_RO_BufferLookup, ref state),
			ignoreImmuneZoneLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IgnoreImmuneZoneCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			isFirstTimeFullyPredictingTick = value2.IsFirstTimeFullyPredictingTick,
			conditionsTableCD = __query_937869303_7.GetSingleton<ConditionsTableCD>()
		}, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_0(default(SetAllDestroyedEntitiesZeroHealthJob), __TypeHandle.__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	public static void DoDamageEffects(ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerLookup, Entity entity, bool requestTookDamageState, ComponentLookup<DamageEffectCD> damageTakenLookup, BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup, Entity attacker, NetworkTick currentTick, ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup, HealthChange healthChangeCD, int prevHealth, HealthCD healthCD, ComponentLookup<MagicBarrierCD> magicBarrierLookup, int healthChange)
	{
		if (damageTakenTriggerLookup.HasComponent(entity))
		{
			damageTakenTriggerLookup.SetComponentEnabled(entity, value: true);
			damageTakenTriggerLookup.GetRefRW(entity).ValueRW.skipRequestTookDamageState = !requestTookDamageState;
		}
		if (damageTakenLookup.HasComponent(entity))
		{
			Entity entity2 = (ghostEffectEventBufferLookup.HasBuffer(attacker) ? attacker : (ghostEffectEventBufferLookup.HasBuffer(entity) ? entity : Entity.Null));
			if (entity2 != Entity.Null)
			{
				RefRW<GhostEffectEventBufferPointerCD> refRW = ghostEffectEventBufferPointerLookup.GetRefRW(entity2);
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBufferLookup[entity2];
				ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						effectID = EffectID.PlayDamageEffect,
						value1 = (healthChangeCD.wasKnockedBack ? 1 : 0),
						value2 = ((prevHealth == healthCD.maxHealth) ? 1 : 0)
					}
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SetAllDestroyedEntitiesZeroHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UpdateHealthFromBufferSystem_SetAllDestroyedEntitiesZeroHealthJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_937869303_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((UpdateHealthFromBufferSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00004734_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00004735_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((UpdateHealthFromBufferSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateHealthFromBufferSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateHealthFromBufferSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateHealthFromBufferSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}

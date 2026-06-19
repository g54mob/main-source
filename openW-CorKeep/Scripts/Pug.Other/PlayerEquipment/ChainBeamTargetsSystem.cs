using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
using Unity.Physics;
using Unity.Transforms;

namespace PlayerEquipment
{
	[BurstCompile]
	[UpdateBefore(typeof(PlayerAttackSystem))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct ChainBeamTargetsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(Simulate),
			typeof(LocalTransform),
			typeof(AnimationOrientationCD),
			typeof(PlayerStateCD),
			typeof(PhysicsMass),
			typeof(PhysicsVelocity)
		})]
		private struct BeamTargetUpdateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerAimPositionCD> __PlayerAimPositionCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

					public BufferTypeHandle<PlayerChainTargetsBuffer> __PlayerChainTargetsBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerAttackCooldownCD> __PlayerAttackCooldownCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerSleepStateCD> __PlayerState_PlayerSleepStateCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlayerAimPositionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerAimPositionCD>();
						__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
						__PlayerChainTargetsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<PlayerChainTargetsBuffer>();
						__PlayerAttackCooldownCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerAttackCooldownCD>(isReadOnly: true);
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
						__PlayerState_PlayerSleepStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerSleepStateCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlayerAimPositionCD_RW_ComponentTypeHandle.Update(ref state);
						__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerChainTargetsBuffer_RW_BufferTypeHandle.Update(ref state);
						__PlayerAttackCooldownCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerSleepStateCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerAttackCooldownCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerSleepStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsMass>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerAimPositionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerChainTargetsBuffer>();
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
				public void Run(ref BeamTargetUpdateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref BeamTargetUpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref BeamTargetUpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref BeamTargetUpdateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref BeamTargetUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref BeamTargetUpdateJob job, EntityManager entityManager)
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

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public TileAccessor tileAccessor;

			[ReadOnly]
			public ComponentLookup<EnemyCD> enemyLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> playerLookup;

			public AttackSystem.Helper attackHelper;

			public EntityCommandBuffer ecb;

			public Entity effectEventBufferSingleton;

			public NetworkTick currentTick;

			public bool isPartialTick;

			[ReadOnly]
			public ComponentLookup<HasWeaponDamageCD> hasWeaponDamageLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> durabilityLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> levelLookup;

			[ReadOnly]
			public ComponentLookup<WeaponDamageCD> weaponDamageLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> tileLookup;

			[ReadOnly]
			public ComponentLookup<PlayerStateCD> playerStateLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> factionLookup;

			[ReadOnly]
			public WorldInfoCD worldInfo;

			[ReadOnly]
			public ComponentLookup<MinionCD> minionLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> useLagCompensationLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> beamWeaponLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in EquippedObjectCD equippedObjectCD, in ClientInput clientInput, ref PlayerAimPositionCD playerAimPositionCD, in BehaviourTagsCD attackTags, ref DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer, in PlayerAttackCooldownCD playerAttackCooldownCD, in PlayerGhost playerGhost, in EquipmentSlotCD equipmentSlotCD, in PlayerSleepStateCD playerSleepStateCD)
			{
				LocalTransform localTransform = attackHelper.localTransformLookup[entity];
				AnimationOrientationCD animationOrientationCD = attackHelper.animationOrientationLookup[entity];
				PlayerStateCD playerStateCD = attackHelper.playerStateLookup[entity];
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob);
				playerChainTargetsBuffer.Clear();
				if (!IsLightingGunActive(entityObjectInfo.objectID, in equippedObjectCD, in clientInput, in playerStateCD, in worldInfo, in playerGhost, in equipmentSlotCD, in playerSleepStateCD) || !beamWeaponLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var beamWeaponCD))
				{
					return;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob, entityObjectInfo.variation);
				int num = 1;
				if (hasWeaponDamageLookup.HasComponent(primaryPrefabEntity))
				{
					bool isReinforced = false;
					if (durabilityLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
					{
						isReinforced = componentData.IsReinforced(equippedObjectCD.containedObject.amount);
					}
					Entity levelEntity = EntityUtility.GetLevelEntity(primaryPrefabEntity, equippedObjectCD.containedObject.objectData, levelEntitiesBufferLookup, levelLookup);
					if (levelEntity != Entity.Null)
					{
						weaponDamageLookup.TryGetComponent(levelEntity, out var componentData2);
						num = componentData2.GetDamage(isReinforced);
					}
				}
				PhysicsWorld physicsWorld = attackHelper.physicsWorld;
				uint num2 = 0u;
				if (attackHelper.interpolationDelayLookup.TryGetComponent(entity, out var componentData3))
				{
					num2 += componentData3.Delay;
				}
				PhysicsWorld physicsWorld2 = physicsWorld;
				PhysicsWorld physicsWorld3 = physicsWorld;
				attackHelper.physicsWorldHistory.GetCollisionWorldFromTick(currentTick, num2, ref physicsWorld2, out var collWorld);
				attackHelper.physicsWorldHistory.GetCollisionWorldFromTick(currentTick, 0u, ref physicsWorld3, out var collWorld2);
				float3 beamStartPoint = SpecialWeaponHandler.GetBeamStartPoint(in animationOrientationCD, in playerStateCD, in localTransform, isVisual: false, beamWeaponCD.beamVisualFromCenter);
				float3 float5 = math.normalizesafe(clientInput.targetingDirection).ToFloat3();
				float3 toWorldPos = beamStartPoint + float5 * 5f + new float3(0f, 0.25f, 0f);
				float3 float6 = toWorldPos;
				bool isHittingSomething = false;
				NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(Allocator.Temp);
				uint collidesWith = (worldInfo.pvpEnabled ? beamWeaponCD.collideFilterPvPOn : beamWeaponCD.collideFilterPvPOff);
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = collidesWith
				};
				float checkFraction = 1.1f;
				Entity firstHitEntity = Entity.Null;
				if (collWorld.CastRay(new RaycastInput
				{
					Start = beamStartPoint,
					End = toWorldPos,
					Filter = filter
				}, ref allHits))
				{
					GetCollisionFromRay(allHits, ref toWorldPos, ref isHittingSomething, float5, playerLookup, tileLookup, collidesWith, factionLookup, worldInfo, attackHelper.petLookup, minionLookup, entity, ref firstHitEntity, useLagCompensationLookup, useLagCompensation: true, ref checkFraction, in beamWeaponCD);
				}
				allHits.Clear();
				if (collWorld2.CastRay(new RaycastInput
				{
					Start = beamStartPoint,
					End = toWorldPos,
					Filter = filter
				}, ref allHits))
				{
					GetCollisionFromRay(allHits, ref toWorldPos, ref isHittingSomething, float5, playerLookup, tileLookup, collidesWith, factionLookup, worldInfo, attackHelper.petLookup, minionLookup, entity, ref firstHitEntity, useLagCompensationLookup, useLagCompensation: false, ref checkFraction, in beamWeaponCD);
				}
				allHits.Dispose();
				if (!isHittingSomething)
				{
					checkFraction = 1.1f;
					NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
					if (collWorld.SphereCastAll(beamStartPoint, 1f, math.normalizesafe(float6 - beamStartPoint), math.length(float6 - beamStartPoint), ref outHits, filter))
					{
						GetCollisionFromOverlap(outHits, ref toWorldPos, ref isHittingSomething, float5, playerLookup, tileLookup, collidesWith, factionLookup, worldInfo, attackHelper.petLookup, minionLookup, entity, ref checkFraction, localTransform, ref firstHitEntity, useLagCompensationLookup, useLagCompensation: true, in beamWeaponCD);
					}
					outHits.Clear();
					if (collWorld2.SphereCastAll(beamStartPoint, 1f, math.normalizesafe(float6 - beamStartPoint), math.length(float6 - beamStartPoint), ref outHits, filter))
					{
						GetCollisionFromOverlap(outHits, ref toWorldPos, ref isHittingSomething, float5, playerLookup, tileLookup, collidesWith, factionLookup, worldInfo, attackHelper.petLookup, minionLookup, entity, ref checkFraction, localTransform, ref firstHitEntity, useLagCompensationLookup, useLagCompensation: false, in beamWeaponCD);
					}
				}
				float3 x = toWorldPos - beamStartPoint;
				float3 float7 = math.normalizesafe(toWorldPos - beamStartPoint);
				int num3 = (int)(math.length(x) / 0.2f);
				float3 float8 = beamStartPoint;
				for (int i = 0; i < num3; i++)
				{
					float8 += float7 * 0.2f;
					if (tileAccessor.GetTop(float8.RoundToInt2()).tileType.IsWallTile())
					{
						toWorldPos = float8;
						isHittingSomething = true;
						break;
					}
				}
				playerAimPositionCD.position = toWorldPos;
				playerAimPositionCD.isHittingSomething = isHittingSomething;
				bool flag = playerAttackCooldownCD.cooldown.GetElapsedTicks(currentTick) == 1;
				if (!(firstHitEntity != Entity.Null))
				{
					return;
				}
				NativeList<DistanceHit> outHits2 = new NativeList<DistanceHit>(Allocator.Temp);
				NativeList<Entity> alreadyTargetedEntities = new NativeList<Entity>(Allocator.Temp);
				alreadyTargetedEntities.Add(in firstHitEntity);
				float3 float9 = toWorldPos;
				bool hitWall = false;
				playerChainTargetsBuffer.Clear();
				playerChainTargetsBuffer.Add(new PlayerChainTargetsBuffer
				{
					targetPosition = toWorldPos
				});
				float3 position = attackHelper.localTransformLookup.GetRefRO(entity).ValueRO.Position;
				uint collidesWith2 = (worldInfo.pvpEnabled ? beamWeaponCD.collideFilterPvPOn : beamWeaponCD.collideFilterPvPOff);
				for (int j = 0; j < 3; j++)
				{
					outHits2.Clear();
					Entity entityToChainTo = Entity.Null;
					float3 entityPos = float3.zero;
					float closestEntityDistanceSq = float.MaxValue;
					if (collWorld.OverlapSphere(float9, 5f, ref outHits2, new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = collidesWith2
					}))
					{
						GetCollisionFromOverlapChained(outHits2, ref entityToChainTo, ref entityPos, ref hitWall, float9, enemyLookup, playerLookup, entity, ref closestEntityDistanceSq, alreadyTargetedEntities, in attackHelper, factionLookup, worldInfo, in tileAccessor, useLagCompensationLookup, useLagCompensation: true);
					}
					outHits2.Clear();
					if (collWorld2.OverlapSphere(float9, 5f, ref outHits2, new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = collidesWith2
					}))
					{
						GetCollisionFromOverlapChained(outHits2, ref entityToChainTo, ref entityPos, ref hitWall, float9, enemyLookup, playerLookup, entity, ref closestEntityDistanceSq, alreadyTargetedEntities, in attackHelper, factionLookup, worldInfo, in tileAccessor, useLagCompensationLookup, useLagCompensation: false);
					}
					if (entityToChainTo == Entity.Null)
					{
						break;
					}
					float3 float10 = entityPos - position;
					alreadyTargetedEntities.Add(in entityToChainTo);
					playerChainTargetsBuffer.Add(new PlayerChainTargetsBuffer
					{
						targetPosition = entityPos
					});
					if (flag && !isPartialTick)
					{
						AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
						{
							effectEventBufferSingleton = effectEventBufferSingleton,
							attacker = entity,
							attackOffset = float10 + 0.5f * math.up(),
							radius = 0.1f,
							damage = num,
							playerDamage = num,
							skipWallAndRootsLootDropOnDestroy = true,
							behaviourTags = attackTags,
							canOnlyAttackType = CanOnlyAttackType.All,
							isPredicted = true,
							isExecutedBeforePhysics = true
						};
						attackHelper.Attack(ecb, in p);
					}
					float9 = entityPos;
				}
				alreadyTargetedEntities.Clear();
				outHits2.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void GetCollisionFromRay(NativeList<RaycastHit> rayHits, ref float3 toWorldPos, ref bool isHittingSomething, float3 tarDir, ComponentLookup<PlayerGhost> playerLookup, ComponentLookup<TileCD> tileLookup, uint collidesWith, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfo, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup, Entity entity, ref Entity firstHitEntity, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup, bool useLagCompensation, ref float checkFraction, in BeamWeaponCD beamWeaponCD)
			{
				for (int i = 0; i < rayHits.Length; i++)
				{
					RaycastHit raycastHit = rayHits[i];
					if (useLagCompensation != useLagCompensationLookup.HasComponent(raycastHit.Entity) || raycastHit.Entity == entity || (tileLookup.HasComponent(raycastHit.Entity) && tileLookup[raycastHit.Entity].tileType == TileType.ground))
					{
						continue;
					}
					if (collidesWith == beamWeaponCD.collideFilterPvPOn && playerLookup.HasComponent(raycastHit.Entity))
					{
						if (IsValidAttackOtherPlayer(entity, raycastHit.Entity, factionLookup, worldInfo) && raycastHit.Fraction < checkFraction)
						{
							checkFraction = raycastHit.Fraction;
							toWorldPos = raycastHit.Position + tarDir * 0.05f;
							toWorldPos.y = 0f;
							isHittingSomething = true;
							firstHitEntity = raycastHit.Entity;
						}
					}
					else if (IsValidBeamTarget(raycastHit.Entity, petLookup, minionLookup) && raycastHit.Fraction < checkFraction)
					{
						checkFraction = raycastHit.Fraction;
						toWorldPos = raycastHit.Position + tarDir * 0.05f;
						toWorldPos.y = 0f;
						isHittingSomething = true;
						firstHitEntity = raycastHit.Entity;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void GetCollisionFromOverlap(NativeList<ColliderCastHit> sphereHits, ref float3 toWorldPos, ref bool isHittingSomething, float3 tarDir, ComponentLookup<PlayerGhost> playerLookup, ComponentLookup<TileCD> tileLookup, uint collidesWith, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfo, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup, Entity entity, ref float lastFraction, LocalTransform localTransform, ref Entity firstHitEntity, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup, bool useLagCompensation, in BeamWeaponCD beamWeaponCD)
			{
				for (int i = 0; i < sphereHits.Length; i++)
				{
					ColliderCastHit colliderCastHit = sphereHits[i];
					if (useLagCompensation != useLagCompensationLookup.HasComponent(colliderCastHit.Entity) || colliderCastHit.Entity == entity || (tileLookup.HasComponent(colliderCastHit.Entity) && tileLookup[colliderCastHit.Entity].tileType == TileType.ground))
					{
						continue;
					}
					if (collidesWith == beamWeaponCD.collideFilterPvPOn && playerLookup.HasComponent(colliderCastHit.Entity))
					{
						if (IsValidAttackOtherPlayer(entity, colliderCastHit.Entity, factionLookup, worldInfo) && math.dot(colliderCastHit.Position - localTransform.Position, tarDir) > 0f && colliderCastHit.Fraction < lastFraction)
						{
							toWorldPos = colliderCastHit.Position;
							toWorldPos.y = 0f;
							firstHitEntity = colliderCastHit.Entity;
							isHittingSomething = true;
							lastFraction = colliderCastHit.Fraction;
						}
					}
					else if (IsValidBeamTarget(colliderCastHit.Entity, petLookup, minionLookup) && math.dot(colliderCastHit.Position - localTransform.Position, tarDir) > 0f && colliderCastHit.Fraction < lastFraction)
					{
						toWorldPos = colliderCastHit.Position;
						toWorldPos.y = 0f;
						firstHitEntity = colliderCastHit.Entity;
						lastFraction = colliderCastHit.Fraction;
						isHittingSomething = true;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void GetCollisionFromOverlapChained(NativeList<DistanceHit> hits, ref Entity entityToChainTo, ref float3 entityPos, ref bool hitWall, float3 lastPos, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<PlayerGhost> playerLookup, Entity entity, ref float closestEntityDistanceSq, NativeList<Entity> alreadyTargetedEntities, in AttackSystem.Helper attackHelper, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfo, in TileAccessor tileAccessor, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup, bool useLagCompensation)
			{
				for (int i = 0; i < hits.Length; i++)
				{
					if (useLagCompensation != useLagCompensationLookup.HasComponent(hits[i].Entity))
					{
						continue;
					}
					float num = math.distancesq(hits[i].Position, lastPos);
					if (entityToChainTo != Entity.Null && closestEntityDistanceSq < num)
					{
						continue;
					}
					Entity entity2 = hits[i].Entity;
					bool flag = entity2 == entity;
					bool flag2 = enemyLookup.HasComponent(entity2) || (playerLookup.HasComponent(entity2) && IsValidAttackOtherPlayer(entity, entity2, factionLookup, worldInfo));
					HealthCD componentData;
					bool num2 = attackHelper.healthLookup.TryGetComponent(entity2, out componentData);
					LocalTransform componentData2;
					bool flag3 = attackHelper.localTransformLookup.TryGetComponent(entity2, out componentData2);
					if (!num2 || !flag3 || flag || !flag2 || componentData.health <= 0 || (alreadyTargetedEntities.Length > 0 && alreadyTargetedEntities.Contains(entity2)))
					{
						continue;
					}
					float3 float5 = math.normalizesafe(componentData2.Position - lastPos);
					float3 x = lastPos;
					int num3 = (int)(math.length(lastPos - componentData2.Position) / 0.2f);
					for (int j = 0; j < num3; j++)
					{
						x += float5 * 0.2f;
						if (tileAccessor.GetTop(x.RoundToInt2()).tileType.IsWallTile())
						{
							hitWall = true;
						}
					}
					if (!hitWall)
					{
						closestEntityDistanceSq = num;
						entityToChainTo = entity2;
						entityPos = componentData2.Position;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static bool IsLightingGunActive(ObjectID objectID, in EquippedObjectCD equippedObjectCD, in ClientInput clientInput, in PlayerStateCD playerStateCD, in WorldInfoCD worldInfoCD, in PlayerGhost playerGhost, in EquipmentSlotCD equipmentSlotCD, in PlayerSleepStateCD playerSleepStateCD)
			{
				if (objectID == ObjectID.LightningGun && equippedObjectCD.containedObject.amount > 0 && clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown) && !playerStateCD.HasAnyState(PlayerStateEnum.VehicleRiding))
				{
					return PlayerController.CurrentStateAllowInteractions(in worldInfoCD, in playerGhost, in playerStateCD, in equipmentSlotCD, isTryingToUseSecondInteract: false, in clientInput, in playerSleepStateCD);
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static bool IsValidBeamTarget(Entity entity, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup)
			{
				if (!petLookup.HasComponent(entity))
				{
					return !minionLookup.HasComponent(entity);
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static bool IsValidAttackOtherPlayer(Entity playerEntity, Entity otherPlayerEntity, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfoCD)
			{
				if (!factionLookup.TryGetComponent(playerEntity, out var componentData) || !factionLookup.TryGetComponent(otherPlayerEntity, out var componentData2))
				{
					return false;
				}
				return componentData.CanAttack(componentData2, worldInfoCD);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerAimPositionCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
				BufferAccessor<PlayerChainTargetsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PlayerChainTargetsBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerAttackCooldownCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerSleepStateCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref EquippedObjectCD equippedObjectCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, i);
						ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i);
						ref PlayerAimPositionCD playerAimPositionCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr4, i);
						ref BehaviourTagsCD attackTags = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i);
						DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer = bufferAccessor[i];
						Execute(entity, in equippedObjectCD, in clientInput, ref playerAimPositionCD, in attackTags, ref playerChainTargetsBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCooldownCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerSleepStateCD>(nativeArrayPtr9, i));
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
							Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
							ref EquippedObjectCD equippedObjectCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, nextRangeBegin);
							ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin);
							ref PlayerAimPositionCD playerAimPositionCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr4, nextRangeBegin);
							ref BehaviourTagsCD attackTags2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, nextRangeBegin);
							DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(entity2, in equippedObjectCD2, in clientInput2, ref playerAimPositionCD2, in attackTags2, ref playerChainTargetsBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCooldownCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerSleepStateCD>(nativeArrayPtr9, nextRangeBegin));
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
						Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
						ref EquippedObjectCD equippedObjectCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, j);
						ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j);
						ref PlayerAimPositionCD playerAimPositionCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr4, j);
						ref BehaviourTagsCD attackTags3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j);
						DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer3 = bufferAccessor[j];
						Execute(entity3, in equippedObjectCD3, in clientInput3, ref playerAimPositionCD3, in attackTags3, ref playerChainTargetsBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCooldownCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerSleepStateCD>(nativeArrayPtr9, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
						ref EquippedObjectCD equippedObjectCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, k);
						ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k);
						ref PlayerAimPositionCD playerAimPositionCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr4, k);
						ref BehaviourTagsCD attackTags4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k);
						DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer4 = bufferAccessor[k];
						Execute(entity4, in equippedObjectCD4, in clientInput4, ref playerAimPositionCD4, in attackTags4, ref playerChainTargetsBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCooldownCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerSleepStateCD>(nativeArrayPtr9, k));
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
			public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<WeaponDamageCD> __WeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HasWeaponDamageCD> __HasWeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			public ComponentLookup<TileCD> __TileCD_RW_ComponentLookup;

			public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentLookup;

			public ComponentLookup<FactionCD> __FactionCD_RW_ComponentLookup;

			public ComponentLookup<MinionCD> __MinionCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> __UseLagCompensationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> __BeamWeaponCD_RO_ComponentLookup;

			public BeamTargetUpdateJob.InternalCompilerQueryAndHandleData __PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__WeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<WeaponDamageCD>(isReadOnly: true);
				__HasWeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<HasWeaponDamageCD>(isReadOnly: true);
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__TileCD_RW_ComponentLookup = state.GetComponentLookup<TileCD>();
				__PlayerState_PlayerStateCD_RW_ComponentLookup = state.GetComponentLookup<PlayerStateCD>();
				__FactionCD_RW_ComponentLookup = state.GetComponentLookup<FactionCD>();
				__MinionCD_RW_ComponentLookup = state.GetComponentLookup<MinionCD>();
				__UseLagCompensationCD_RO_ComponentLookup = state.GetComponentLookup<UseLagCompensationCD>(isReadOnly: true);
				__BeamWeaponCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
				__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000743E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000743E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000743E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
				__codegen__OnCreate_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000743F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000743F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000743F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private const float BEAM_STEP_SIZE = 0.2f;

		public const float BEAM_HEIGHT_OFFSET = 0.25f;

		private const float BEAM_REACH_DISTANCE = 5f;

		private const float CHAIN_REACH_DISTANCE = 5f;

		private NativeList<int2> _tileHitPositions;

		private TileAccessor _tileAccessor;

		private uint _systemServerSeed;

		private AttackSystem.Helper _attackHelper;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_580595679_0;

		private EntityQuery __query_580595679_1;

		private EntityQuery __query_580595679_2;

		private EntityQuery __query_580595679_3;

		private EntityQuery __query_580595679_4;

		private EntityQuery __query_580595679_5;

		private EntityQuery __query_580595679_6;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<ServerSeedCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<ClientServerTickRate>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<ClientServerTickRate>();
			state.RequireForUpdate<TileDamageBuffer>();
			state.RequireForUpdate<TileUpdateBuffer>();
			state.RequireForUpdate<EffectEventBuffer>();
			state.RequireForUpdate<WorldInfoCD>();
			_tileHitPositions = new NativeList<int2>(16, Allocator.Persistent);
		}

		public void OnDestroy(ref SystemState state)
		{
			_tileHitPositions.Dispose();
		}

		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
			_systemServerSeed = __query_580595679_0.GetSingleton<ServerSeedCD>().Value ^ EntityUtility.SeedFromSystem("ChainBeamTargetsSystem");
			_attackHelper = new AttackSystem.Helper(ref state, __query_580595679_1.GetSingleton<ClientServerTickRate>().SimulationTickRate);
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			_tileAccessor.Update(ref state);
			__query_580595679_2.TryGetSingleton<NetworkTime>(out var value);
			_attackHelper.Update(ref state, value.ServerTick, (uint)__query_580595679_1.GetSingleton<ClientServerTickRate>().SimulationTickRate);
			BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_580595679_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
			BeamTargetUpdateJob job = new BeamTargetUpdateJob
			{
				databaseBankCD = __query_580595679_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
				tileAccessor = _tileAccessor,
				ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
				effectEventBufferSingleton = __query_580595679_5.GetSingletonEntity(),
				enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				playerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				attackHelper = _attackHelper,
				currentTick = value.ServerTick,
				isPartialTick = value.IsPartialTick,
				levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
				weaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WeaponDamageCD_RO_ComponentLookup, ref state),
				hasWeaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasWeaponDamageCD_RO_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
				levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
				tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RW_ComponentLookup, ref state),
				playerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RW_ComponentLookup, ref state),
				worldInfo = __query_580595679_6.GetSingleton<WorldInfoCD>(),
				minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RW_ComponentLookup, ref state),
				useLagCompensationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__UseLagCompensationCD_RO_ComponentLookup, ref state),
				beamWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamWeaponCD_RO_ComponentLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ref BeamTargetUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_ChainBeamTargetsSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_580595679_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			__codegen__OnCreate_0000743E_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000743F_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChainBeamTargetsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

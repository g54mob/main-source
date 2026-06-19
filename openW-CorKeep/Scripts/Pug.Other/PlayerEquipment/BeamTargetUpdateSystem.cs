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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace PlayerEquipment
{
	[BurstCompile]
	[UpdateBefore(typeof(PlayerAttackSystem))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct BeamTargetUpdateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		public struct BeamTargetUpdateJob : IJobEntity, IJobChunk
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

					[ReadOnly]
					public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PhysicsMass> __Unity_Physics_PhysicsMass_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerRoutineCD> __PlayerRoutineCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerAimPositionCD> __PlayerAimPositionCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<BeamWeaponAttackCD> __BeamWeaponAttackCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__AnimationOrientationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>(isReadOnly: true);
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
						__Unity_Physics_PhysicsMass_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsMass>(isReadOnly: true);
						__PlayerRoutineCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerRoutineCD>(isReadOnly: true);
						__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
						__PlayerAimPositionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerAimPositionCD>();
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
						__BeamWeaponAttackCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BeamWeaponAttackCD>();
						__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__AnimationOrientationCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Physics_PhysicsMass_RO_ComponentTypeHandle.Update(ref state);
						__PlayerRoutineCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref state);
						__PlayerAimPositionCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__BeamWeaponAttackCD_RW_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
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
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsMass>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerRoutineCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerAimPositionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamWeaponAttackCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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

			[ReadOnly]
			public PhysicsWorld physicsWorld;

			[ReadOnly]
			public PhysicsWorldHistorySingleton physicsWorldHistory;

			public TileAccessor tileAccessor;

			[ReadOnly]
			public ComponentLookup<PetCD> petLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> tileLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> factionLookup;

			[ReadOnly]
			public WorldInfoCD worldInfo;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> playerLookup;

			[ReadOnly]
			public ComponentLookup<CommandDataInterpolationDelay> interpolationDelayLookup;

			[ReadOnly]
			public ComponentLookup<MinionCD> minionLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> useLagCompensationLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> beamWeaponLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

			[ReadOnly]
			public ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> levelLookup;

			[ReadOnly]
			public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> localTransformLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> objectDataLookup;

			[ReadOnly]
			public ComponentLookup<EnemyCD> enemyLookup;

			public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

			public NativeList<Unity.Physics.RaycastHit> rayHits;

			public NativeList<ColliderCastHit> sphereHits;

			public NetworkTick currentTick;

			public uint tickRate;

			public EntityCommandBuffer ecb;

			public bool isFirstTimeFullyPredictingTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in EquippedObjectCD equippedObjectCD, in ClientInput clientInput, in AnimationOrientationCD animationOrientationCD, in PlayerStateCD playerStateCD, in PhysicsMass physicsMass, in PlayerRoutineCD playerRoutineCD, ref PhysicsVelocity physicsVelocity, ref PlayerAimPositionCD playerAimPositionCD, in PlayerGhost playerGhost, in EquipmentSlotCD equipmentSlotCD, ref BeamWeaponAttackCD beamWeaponAttackCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ref RandomCD randomCD)
			{
				bool interactHeldDown = clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown);
				if (!IsBeamActive(PugDatabase.GetEntityObjectInfo(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob).objectType, in equippedObjectCD, interactHeldDown, in playerStateCD, in worldInfo, in playerGhost, in equipmentSlotCD, in clientInput, in beamWeaponAttackCD, currentTick) || !beamWeaponLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var beamWeaponCD))
				{
					beamWeaponAttackCD.lastContiniousActivateTick = NetworkTick.Invalid;
					return;
				}
				if (!beamWeaponAttackCD.lastContiniousActivateTick.IsValid)
				{
					beamWeaponAttackCD.lastContiniousActivateTick = currentTick;
				}
				ref readonly LocalTransform valueRO = ref localTransformLookup.GetRefRO(entity).ValueRO;
				float3 beamStartPoint = SpecialWeaponHandler.GetBeamStartPoint(in animationOrientationCD, in playerStateCD, in valueRO, isVisual: false, beamWeaponCD.beamVisualFromCenter);
				float3 float5 = math.normalizesafe(clientInput.targetingDirection).ToFloat3();
				float num = beamWeaponCD.attackDistance;
				if (beamWeaponCD.expandWhenHeld)
				{
					float t = math.clamp(NetworkTimeUtilities.TimeBetweenTicksInSeconds(beamWeaponAttackCD.lastContiniousActivateTick, currentTick, tickRate) / beamWeaponCD.expandTimeSeconds, 0f, 1f);
					num = math.lerp(beamWeaponCD.expandMinDistance, beamWeaponCD.attackDistance, t);
				}
				float3 toWorldPos = beamStartPoint + float5 * num + new float3(0f, 0.25f, 0f);
				float3 toWorldPosOriginal = toWorldPos;
				bool pvpEnabled = worldInfo.pvpEnabled;
				uint collidesWith = (pvpEnabled ? beamWeaponCD.collideFilterPvPOn : beamWeaponCD.collideFilterPvPOff);
				CollisionFilter beamFilter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = collidesWith
				};
				bool isHittingSomething = false;
				bool pierceEnemiesAndPlayers = !beamWeaponCD.onlyDamageAtEndOfBeam;
				GetCollisionWorlds(entity, out var collisionWorldInterpolated, out var collisionWorldPredicted);
				CheckCollisionFromRay(entity, beamStartPoint, ref toWorldPos, float5, pvpEnabled, beamFilter, ref isHittingSomething, collisionWorldInterpolated, collisionWorldPredicted, pierceEnemiesAndPlayers);
				if (!isHittingSomething && beamWeaponCD.isStickyBeam)
				{
					CheckCollisionWithStickyBeam(entity, beamStartPoint, ref toWorldPos, toWorldPosOriginal, float5, pvpEnabled, beamFilter, valueRO, ref isHittingSomething, collisionWorldInterpolated, collisionWorldPredicted);
				}
				CheckCollisionWithWalls(beamStartPoint, ref toWorldPos, ref isHittingSomething);
				playerAimPositionCD.position = toWorldPos;
				playerAimPositionCD.isHittingSomething = isHittingSomething;
				float beamStrength = 1f;
				if (objectPropertiesLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData) && componentData.TryGet<ConditionID>(1669350244, out var value))
				{
					int stacks = ConditionExtensions.GetStacks(value, summarizedConditionsBuffer[(int)value].value);
					int maxStacksForWeaponEquipmentConditions = ConditionExtensions.GetMaxStacksForWeaponEquipmentConditions(value);
					if (maxStacksForWeaponEquipmentConditions > 0)
					{
						beamStrength = (float)stacks / (float)maxStacksForWeaponEquipmentConditions;
					}
				}
				playerAimPositionCD.beamStrength = beamStrength;
				if (isHittingSomething)
				{
					NetworkTick networkTick = currentTick;
					networkTick.Decrement();
					PlayerController.Pushback(entity, -float5 * 0.1f, in playerStateCD, receivedPushbackLookup, networkTick, tickRate);
				}
				TrySpawnObject(in beamWeaponCD, ref beamWeaponAttackCD, in equippedObjectCD, summarizedConditionsBuffer, localTransformLookup, objectDataLookup, ref randomCD, toWorldPos);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void GetCollisionWorlds(Entity entity, out CollisionWorld collisionWorldInterpolated, out CollisionWorld collisionWorldPredicted)
			{
				uint num = 0u;
				if (interpolationDelayLookup.TryGetComponent(entity, out var componentData))
				{
					num += componentData.Delay;
				}
				physicsWorldHistory.GetCollisionWorldFromTick(currentTick, num, ref physicsWorld, out collisionWorldInterpolated);
				physicsWorldHistory.GetCollisionWorldFromTick(currentTick, 0u, ref physicsWorld, out collisionWorldPredicted);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void GetCollisionFromRay(NativeList<Unity.Physics.RaycastHit> rayHits, ref float3 toWorldPos, ref bool isHittingSomething, float3 tarDir, ComponentLookup<PlayerGhost> playerLookup, ComponentLookup<TileCD> tileLookup, bool isPvPEnabled, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfo, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup, ComponentLookup<EnemyCD> enemyLookup, Entity entity, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup, bool useLagCompensation, ref float checkFraction, bool pierceEnemiesAndPlayers)
			{
				for (int i = 0; i < rayHits.Length; i++)
				{
					Unity.Physics.RaycastHit raycastHit = rayHits[i];
					if (useLagCompensation != useLagCompensationLookup.HasComponent(raycastHit.Entity) || (tileLookup.HasComponent(raycastHit.Entity) && tileLookup[raycastHit.Entity].tileType == TileType.ground))
					{
						continue;
					}
					if (pierceEnemiesAndPlayers)
					{
						if (!playerLookup.HasComponent(raycastHit.Entity) && !enemyLookup.HasComponent(raycastHit.Entity) && IsValidBeamTarget(raycastHit.Entity, petLookup, minionLookup) && raycastHit.Fraction < checkFraction)
						{
							toWorldPos = raycastHit.Position + tarDir * 0.05f;
							checkFraction = raycastHit.Fraction;
							isHittingSomething = true;
						}
					}
					else if (playerLookup.HasComponent(raycastHit.Entity))
					{
						if (isPvPEnabled && IsValidAttackOtherPlayer(entity, raycastHit.Entity, factionLookup, worldInfo) && raycastHit.Fraction < checkFraction)
						{
							toWorldPos = raycastHit.Position + tarDir * 0.05f;
							checkFraction = raycastHit.Fraction;
							isHittingSomething = true;
						}
					}
					else if (IsValidBeamTarget(raycastHit.Entity, petLookup, minionLookup) && raycastHit.Fraction < checkFraction)
					{
						toWorldPos = raycastHit.Position + tarDir * 0.05f;
						checkFraction = raycastHit.Fraction;
						isHittingSomething = true;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void GetCollisionFromOverlap(NativeList<ColliderCastHit> sphereHits, ref float3 toWorldPos, ref bool isHittingSomething, float3 tarDir, ComponentLookup<PlayerGhost> playerLookup, ComponentLookup<TileCD> tileLookup, bool isPvPEnabled, ComponentLookup<FactionCD> factionLookup, WorldInfoCD worldInfo, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup, Entity entity, ref float lastFraction, LocalTransform localTransform, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup, bool useLagCompensation)
			{
				for (int i = 0; i < sphereHits.Length; i++)
				{
					ColliderCastHit colliderCastHit = sphereHits[i];
					if (useLagCompensation != useLagCompensationLookup.HasComponent(colliderCastHit.Entity) || colliderCastHit.Entity == entity || (tileLookup.HasComponent(colliderCastHit.Entity) && tileLookup[colliderCastHit.Entity].tileType == TileType.ground))
					{
						continue;
					}
					if (playerLookup.HasComponent(colliderCastHit.Entity))
					{
						if (isPvPEnabled && IsValidAttackOtherPlayer(entity, colliderCastHit.Entity, factionLookup, worldInfo) && math.dot(colliderCastHit.Position - localTransform.Position, tarDir) > 0f && colliderCastHit.Fraction < lastFraction)
						{
							toWorldPos = colliderCastHit.Position + tarDir * 0.05f;
							isHittingSomething = true;
							lastFraction = colliderCastHit.Fraction;
						}
					}
					else if (IsValidBeamTarget(colliderCastHit.Entity, petLookup, minionLookup) && math.dot(colliderCastHit.Position - localTransform.Position, tarDir) > 0f && colliderCastHit.Fraction < lastFraction)
					{
						toWorldPos = colliderCastHit.Position;
						lastFraction = colliderCastHit.Fraction;
						isHittingSomething = true;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool IsBeamActive(ObjectType objectType, in EquippedObjectCD equippedObjectCD, bool interactHeldDown, in PlayerStateCD playerStateCD, in WorldInfoCD worldInfoCD, in PlayerGhost playerGhost, in EquipmentSlotCD equipmentSlotCD, in ClientInput clientInput, in BeamWeaponAttackCD beamWeaponAttackCD, NetworkTick currentTick)
			{
				if (objectType == ObjectType.BeamWeapon && interactHeldDown && beamWeaponAttackCD.beamWeaponActiveTimer.isRunning)
				{
					return !beamWeaponAttackCD.beamWeaponActiveTimer.IsTimerElapsed(currentTick);
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

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void CheckCollisionFromRay(Entity entity, float3 beamStartPoint, ref float3 toWorldPos, float3 tarDir, bool isPvPEnabled, CollisionFilter beamFilter, ref bool isHittingSomething, CollisionWorld collisionWorldInterpolated, CollisionWorld collisionWorldPredicted, bool pierceEnemiesAndPlayers)
			{
				rayHits.Clear();
				float checkFraction = 1.1f;
				if (collisionWorldInterpolated.CastRay(new RaycastInput
				{
					Start = beamStartPoint,
					End = toWorldPos,
					Filter = beamFilter
				}, ref rayHits))
				{
					GetCollisionFromRay(rayHits, ref toWorldPos, ref isHittingSomething, tarDir, playerLookup, tileLookup, isPvPEnabled, factionLookup, worldInfo, petLookup, minionLookup, enemyLookup, entity, useLagCompensationLookup, useLagCompensation: true, ref checkFraction, pierceEnemiesAndPlayers);
				}
				rayHits.Clear();
				if (collisionWorldPredicted.CastRay(new RaycastInput
				{
					Start = beamStartPoint,
					End = toWorldPos,
					Filter = beamFilter
				}, ref rayHits))
				{
					GetCollisionFromRay(rayHits, ref toWorldPos, ref isHittingSomething, tarDir, playerLookup, tileLookup, isPvPEnabled, factionLookup, worldInfo, petLookup, minionLookup, enemyLookup, entity, useLagCompensationLookup, useLagCompensation: false, ref checkFraction, pierceEnemiesAndPlayers);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void CheckCollisionWithStickyBeam(Entity entity, float3 beamStartPoint, ref float3 toWorldPos, float3 toWorldPosOriginal, float3 tarDir, bool isPvPEnabled, CollisionFilter beamFilter, LocalTransform localTransform, ref bool isHittingSomething, CollisionWorld collisionWorldInterpolated, CollisionWorld collisionWorldPredicted)
			{
				sphereHits.Clear();
				float lastFraction = 1.1f;
				if (collisionWorldInterpolated.SphereCastAll(beamStartPoint, 1f, math.normalizesafe(toWorldPosOriginal - beamStartPoint), math.length(toWorldPosOriginal - beamStartPoint), ref sphereHits, beamFilter))
				{
					GetCollisionFromOverlap(sphereHits, ref toWorldPos, ref isHittingSomething, tarDir, playerLookup, tileLookup, isPvPEnabled, factionLookup, worldInfo, petLookup, minionLookup, entity, ref lastFraction, localTransform, useLagCompensationLookup, useLagCompensation: true);
				}
				sphereHits.Clear();
				if (collisionWorldPredicted.SphereCastAll(beamStartPoint, 1f, math.normalizesafe(toWorldPosOriginal - beamStartPoint), math.length(toWorldPosOriginal - beamStartPoint), ref sphereHits, beamFilter))
				{
					GetCollisionFromOverlap(sphereHits, ref toWorldPos, ref isHittingSomething, tarDir, playerLookup, tileLookup, isPvPEnabled, factionLookup, worldInfo, petLookup, minionLookup, entity, ref lastFraction, localTransform, useLagCompensationLookup, useLagCompensation: false);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void CheckCollisionWithWalls(float3 beamStartPoint, ref float3 toWorldPos, ref bool isHittingSomething)
			{
				float3 x = toWorldPos - beamStartPoint;
				float3 float5 = math.normalizesafe(toWorldPos - beamStartPoint);
				int num = (int)(math.length(x) / 0.2f);
				float3 float6 = beamStartPoint;
				for (int i = 0; i < num; i++)
				{
					float6 += float5 * 0.2f;
					if (tileAccessor.GetTop(float6.RoundToInt2()).tileType.IsWallTile())
					{
						toWorldPos = float6;
						isHittingSomething = true;
						break;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void TrySpawnObject(in BeamWeaponCD beamWeaponCD, ref BeamWeaponAttackCD beamWeaponAttackCD, in EquippedObjectCD equippedObjectCD, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ComponentLookup<LocalTransform> localTransformLookup, ComponentLookup<ObjectDataCD> objectDataLookup, ref RandomCD randomCD, float3 toWorldPos)
			{
				float num = (float)summarizedConditionsBuffer[352].value / 100f;
				if (num == 0f || (beamWeaponAttackCD.specialAttackCooldown.isRunning && !beamWeaponAttackCD.specialAttackCooldown.IsTimerElapsed(currentTick)) || (!Mathf.Approximately(num, 1f) && !(randomCD.Value.NextFloat() <= num)))
				{
					return;
				}
				beamWeaponAttackCD.specialAttackCooldown.Start(currentTick, 0.5f, tickRate);
				if (!isFirstTimeFullyPredictingTick || math.clamp(NetworkTimeUtilities.TimeBetweenTicksInSeconds(beamWeaponAttackCD.lastContiniousActivateTick, currentTick, tickRate) / beamWeaponCD.expandTimeSeconds, 0f, 1f) < 1f)
				{
					return;
				}
				int2 int5 = toWorldPos.RoundToInt2();
				if (!tileAccessor.GetTop(int5).tileType.IsWalkableTile())
				{
					return;
				}
				ObjectID objectID = ObjectID.OilFireTrap;
				NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(8, Allocator.Temp);
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 687967u
				};
				if (physicsWorld.OverlapSphere(toWorldPos, 0.5f, ref outHits, filter))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						DistanceHit distanceHit = outHits[i];
						if (objectDataLookup.TryGetComponent(distanceHit.Entity, out var componentData) && componentData.objectID == objectID && localTransformLookup.TryGetComponent(distanceHit.Entity, out var componentData2) && math.all(componentData2.Position.RoundToInt2() == int5))
						{
							return;
						}
					}
				}
				float3 position = new float3(int5.x, 0f, int5.y);
				int level;
				if (equippedObjectCD.containedObject.objectData.variation > 0)
				{
					level = equippedObjectCD.containedObject.objectData.variation;
				}
				else
				{
					levelLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData3);
					level = componentData3.level;
				}
				int value = summarizedConditionsBuffer[314].value;
				EntityUtility.SpawnFireTrapOrNapalm(objectID, 0, position, level, value, ecb, objectPropertiesLookup, attackContinuouslyLookup, levelEntitiesBufferLookup, levelLookup, conditionsBufferLookup, databaseBankCD, isFirstTimeFullyPredictingTick);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__AnimationOrientationCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Physics_PhysicsMass_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerRoutineCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerAimPositionCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr12 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BeamWeaponAttackCD_RW_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr13 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsMass>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr7, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr8, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr9, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr10, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr11, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BeamWeaponAttackCD>(nativeArrayPtr12, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr13, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsMass>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr7, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr8, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr9, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr10, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr11, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BeamWeaponAttackCD>(nativeArrayPtr12, nextRangeBegin), bufferAccessor[nextRangeBegin], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr13, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsMass>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr7, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr8, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr9, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr10, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr11, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BeamWeaponAttackCD>(nativeArrayPtr12, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr13, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsMass>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr7, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr8, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAimPositionCD>(nativeArrayPtr9, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr10, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr11, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BeamWeaponAttackCD>(nativeArrayPtr12, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr13, k));
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
			public ComponentLookup<PetCD> __PetCD_RW_ComponentLookup;

			public ComponentLookup<TileCD> __TileCD_RW_ComponentLookup;

			public ComponentLookup<ReceivedPushbackCD> __ReceivedPushbackCD_RW_ComponentLookup;

			public ComponentLookup<FactionCD> __FactionCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CommandDataInterpolationDelay> __Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentLookup;

			public ComponentLookup<MinionCD> __MinionCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> __UseLagCompensationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> __BeamWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<AttackContinuouslyCD> __AttackContinuouslyCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

			public BeamTargetUpdateJob.InternalCompilerQueryAndHandleData __PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PetCD_RW_ComponentLookup = state.GetComponentLookup<PetCD>();
				__TileCD_RW_ComponentLookup = state.GetComponentLookup<TileCD>();
				__ReceivedPushbackCD_RW_ComponentLookup = state.GetComponentLookup<ReceivedPushbackCD>();
				__FactionCD_RW_ComponentLookup = state.GetComponentLookup<FactionCD>();
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentLookup = state.GetComponentLookup<CommandDataInterpolationDelay>(isReadOnly: true);
				__MinionCD_RW_ComponentLookup = state.GetComponentLookup<MinionCD>();
				__UseLagCompensationCD_RO_ComponentLookup = state.GetComponentLookup<UseLagCompensationCD>(isReadOnly: true);
				__BeamWeaponCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__AttackContinuouslyCD_RO_ComponentLookup = state.GetComponentLookup<AttackContinuouslyCD>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__ConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<ConditionsBuffer>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
				__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007401_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007401_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007401_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007402_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007402_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007402_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		public const float BEAM_START_DISTANCE_INFRONT = 0.2f;

		public const float BEAM_SPECIAL_SPAWN_COOLDOWN = 0.5f;

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_215200273_0;

		private EntityQuery __query_215200273_1;

		private EntityQuery __query_215200273_2;

		private EntityQuery __query_215200273_3;

		private EntityQuery __query_215200273_4;

		private EntityQuery __query_215200273_5;

		private EntityQuery __query_215200273_6;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<PhysicsWorldHistorySingleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		}

		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			_tileAccessor.Update(ref state);
			EntityCommandBuffer ecb = __query_215200273_0.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_215200273_1.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new BeamTargetUpdateJob
			{
				databaseBankCD = __query_215200273_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
				physicsWorld = __query_215200273_3.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
				physicsWorldHistory = __query_215200273_4.GetSingleton<PhysicsWorldHistorySingleton>(),
				tileAccessor = _tileAccessor,
				petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RW_ComponentLookup, ref state),
				tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RW_ComponentLookup, ref state),
				receivedPushbackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ReceivedPushbackCD_RW_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RW_ComponentLookup, ref state),
				playerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				interpolationDelayLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentLookup, ref state),
				currentTick = value.ServerTick,
				tickRate = (uint)__query_215200273_5.GetSingleton<ClientServerTickRate>().SimulationTickRate,
				worldInfo = __query_215200273_6.GetSingleton<WorldInfoCD>(),
				minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RW_ComponentLookup, ref state),
				useLagCompensationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__UseLagCompensationCD_RO_ComponentLookup, ref state),
				beamWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamWeaponCD_RO_ComponentLookup, ref state),
				objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
				attackContinuouslyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackContinuouslyCD_RO_ComponentLookup, ref state),
				levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
				levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
				conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RO_BufferLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				rayHits = new NativeList<Unity.Physics.RaycastHit>(16, state.WorldUpdateAllocator),
				sphereHits = new NativeList<ColliderCastHit>(16, state.WorldUpdateAllocator),
				ecb = ecb,
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick
			}, __TypeHandle.__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(BeamTargetUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_BeamTargetUpdateSystem_BeamTargetUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_215200273_6 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00007401_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007402_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((BeamTargetUpdateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((BeamTargetUpdateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((BeamTargetUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((BeamTargetUpdateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((BeamTargetUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

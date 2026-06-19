using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using PlayerCommand;
using PlayerEquipment;
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

[BurstCompile]
[UpdateBefore(typeof(TileDamageSystem))]
[UpdateBefore(typeof(UpdateHealthSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct PlayerAttackSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct ClearDealDamageToEntityOnPartialTick : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<DealDamageToEntityBuffer> __DealDamageToEntityBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__DealDamageToEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DealDamageToEntityBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__DealDamageToEntityBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DealDamageToEntityBuffer>();
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
			public void Run(ref ClearDealDamageToEntityOnPartialTick job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ClearDealDamageToEntityOnPartialTick job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ClearDealDamageToEntityOnPartialTick job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ClearDealDamageToEntityOnPartialTick job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ClearDealDamageToEntityOnPartialTick job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ClearDealDamageToEntityOnPartialTick job, EntityManager entityManager)
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

		private void Execute(ref DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer)
		{
			dealDamageToEntityBuffer.Clear();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<DealDamageToEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__DealDamageToEntityBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer = bufferAccessor[i];
					Execute(ref dealDamageToEntityBuffer);
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
						DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(ref dealDamageToEntityBuffer2);
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
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer3 = bufferAccessor[j];
					Execute(ref dealDamageToEntityBuffer3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer4 = bufferAccessor[k];
					Execute(ref dealDamageToEntityBuffer4);
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

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(DealDamageToEntityBuffer)
	})]
	private struct PlayerDealDamageJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public PlayerAttackAspect.TypeHandle __PlayerAttackAspect_RW_AspectTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DealDamageToCrittersCD> __DealDamageToCrittersCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlacementCD> __PlacementCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__PlayerAttackAspect_RW_AspectTypeHandle = new PlayerAttackAspect.TypeHandle(ref state);
					__DealDamageToCrittersCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DealDamageToCrittersCD>(isReadOnly: true);
					__PlacementCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlacementCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__PlayerAttackAspect_RW_AspectTypeHandle.Update(ref state);
					__DealDamageToCrittersCD_RO_ComponentTypeHandle.Update(ref state);
					__PlacementCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DealDamageToCrittersCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DealDamageToEntityBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAspect<PlayerAttackAspect>();
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
			public void Run(ref PlayerDealDamageJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref PlayerDealDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref PlayerDealDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref PlayerDealDamageJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref PlayerDealDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref PlayerDealDamageJob job, EntityManager entityManager)
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

		public PlayerAttackShared PlayerAttackShared;

		public PlayerAttackLookups PlayerAttackLookups;

		[ReadOnly]
		public TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMap;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(PlayerAttackAspect playerAttackAspect, in DealDamageToCrittersCD dealDamageToCrittersCD, in PlacementCD placementCD)
		{
			if (PlayerAttackLookups.playerStateLookup[playerAttackAspect.entity].HasAnyState(PlayerStateEnum.Death))
			{
				PlayerAttackLookups.dealDamageToEntityBufferLookup[playerAttackAspect.entity].Clear();
				return;
			}
			NativeArray<DealDamageToEntityBuffer> nativeArray = PlayerAttackLookups.dealDamageToEntityBufferLookup[playerAttackAspect.entity].ToNativeArray(Allocator.Temp);
			PlayerAttackLookups.dealDamageToEntityBufferLookup[playerAttackAspect.entity].Clear();
			for (int i = 0; i < nativeArray.Length; i++)
			{
				DealDamageToEntityBuffer damage = nativeArray[i];
				switch (damage.attackType)
				{
				case DealDamageToEntityBuffer.AttackType.RayCast:
					PlayerController.TryRayCastAttack(in playerAttackAspect, in PlayerAttackShared, in PlayerAttackLookups, playerAttackAspect.equippedObjectCD.ValueRO.isBroken, playerAttackAspect.playerAttackCD.ValueRO.meleeDamage);
					break;
				case DealDamageToEntityBuffer.AttackType.Melee:
				{
					ref readonly PlayerAttackCD valueRO = ref playerAttackAspect.playerAttackCD.ValueRO;
					PlayerController.TryMeleeAttack(in playerAttackAspect, in PlayerAttackShared, in PlayerAttackLookups, playerAttackAspect.equippedObjectCD.ValueRO.isBroken, valueRO.meleeDamage, valueRO.isWoundup, valueRO.windupMult);
					break;
				}
				case DealDamageToEntityBuffer.AttackType.CatchCritters:
					TryCatchAnyCritters(in playerAttackAspect, in PlayerAttackShared, in PlayerAttackLookups);
					break;
				case DealDamageToEntityBuffer.AttackType.CritterDamage:
					PlayerController.DealCritterDamage(damage.optionalFromPosition, damage.hitPosition, damage.critterDamageSize, damage.critterDamageCanDamageFlying, damage.critterDamageKillEvenIfSquashBugsIsOff, in dealDamageToCrittersCD, playerAttackAspect, PlayerAttackLookups, PlayerAttackShared);
					break;
				case DealDamageToEntityBuffer.AttackType.Shovel:
					DamageFromShovel(playerAttackAspect, damage.hitPosition, PlayerAttackShared, PlayerAttackLookups, placementCD, in tileWithTilesetToObjectDataMap);
					break;
				case DealDamageToEntityBuffer.AttackType.Vehicle:
					PlayerController.TryGoKartAttack(in playerAttackAspect, in PlayerAttackShared, in PlayerAttackLookups);
					break;
				case DealDamageToEntityBuffer.AttackType.ReverseDirectDamage:
					ReverseDirectDamage(in damage, in playerAttackAspect, in PlayerAttackShared, in PlayerAttackLookups);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			nativeArray.Dispose();
		}

		public static void TryCatchAnyCritters(in PlayerAttackAspect playerAttackAspect, in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups)
		{
			Direction facingDirection = playerAttackLookups.animationOrientationLookup[playerAttackAspect.entity].facingDirection;
			NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			float3 halfExtents = new float3(facingDirection.isH ? 0.75f : 1f, 1f, facingDirection.isH ? 1f : 0.75f);
			float3 position = playerAttackLookups.localTransformLookup[playerAttackAspect.entity].Position;
			float3 center = position + facingDirection.f3 * 0.75f;
			PhysicsWorld physicsWorld = playerAttackShared.physicsWorld;
			playerAttackShared.physicsWorldHistory.GetCollisionWorldFromTick(playerAttackShared.currentTick, playerAttackAspect.interpolationDelay.ValueRO.Delay, ref physicsWorld, out var collWorld);
			if (collWorld.BoxCastAll(center, quaternion.identity, halfExtents, float3.zero, 0f, ref outHits, playerAttackShared.critterFilter))
			{
				foreach (ColliderCastHit item2 in outHits)
				{
					Entity entity = item2.Entity;
					if (playerAttackLookups.critterLookup.HasComponent(entity))
					{
						playerAttackLookups.inventoryChangeBufferLookup[playerAttackShared.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
						{
							playerEntity = playerAttackAspect.entity,
							inventoryChangeData = Create.PickUpObject(entity, playerAttackAspect.entity, 0, position)
						});
						if (playerAttackLookups.objectDataLookup.HasComponent(entity) && playerAttackLookups.ghostEffectEventBufferLookup.TryGetBuffer(playerAttackAspect.entity, out var bufferData))
						{
							ObjectDataCD objectDataCD = playerAttackLookups.objectDataLookup[entity];
							RefRW<GhostEffectEventBufferPointerCD> refRW = playerAttackLookups.ghostEffectEventBufferPointerLookup.GetRefRW(playerAttackAspect.entity);
							DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
							ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
							GhostEffectEventBuffer item = new GhostEffectEventBuffer
							{
								Tick = playerAttackShared.currentTick,
								value = new EffectEventCD
								{
									entity = playerAttackAspect.entity,
									localOnlyEffect = 1,
									effectID = EffectID.CaughtItemChatMessage,
									value1 = (int)objectDataCD.objectID
								}
							};
							buffer.AddToRingBuffer(ref valueRW, in item);
						}
					}
				}
			}
			outHits.Dispose();
		}

		private static void DamageFromShovel(PlayerAttackAspect playerAttackAspect, float3 toPos, PlayerAttackShared playerAttackShared, PlayerAttackLookups playerAttackLookups, PlacementCD placementCD, in TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMap)
		{
			int2 int5 = toPos.RoundToInt2();
			int conditionEffectValue = EntityUtility.GetConditionEffectValue(ConditionEffect.Digging, playerAttackAspect.entity, playerAttackLookups.summarizeConiditionsEffectsLookup);
			NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			PhysicsCollider sphereCollider = PhysicsManager.GetSphereCollider(new float3(0f, -0.5f, 0f), 0.2f, 1u, playerAttackShared.colliderCache);
			PhysicsWorld physicsWorld = playerAttackShared.physicsWorld;
			playerAttackShared.physicsWorldHistory.GetCollisionWorldFromTick(playerAttackShared.currentTick, playerAttackAspect.interpolationDelay.ValueRO.Delay, ref physicsWorld, out var collWorld);
			collWorld.CastCollider(PhysicsManager.GetColliderCastInput(toPos, toPos, sphereCollider), ref allHits);
			Entity entity = Entity.Null;
			float3 position = default(float3);
			TileCD tileCD = default(TileCD);
			foreach (ColliderCastHit item2 in allHits)
			{
				if (playerAttackLookups.tileLookup.TryGetComponent(item2.Entity, out var componentData))
				{
					tileCD = componentData;
					if (tileCD.tileType == TileType.ground)
					{
						entity = item2.Entity;
						position = collWorld.Bodies[item2.RigidBodyIndex].WorldFromBody.pos;
						break;
					}
				}
			}
			allHits.Dispose();
			bool flag = playerAttackLookups.godModeLookup.IsComponentEnabled(playerAttackAspect.entity);
			int damageDoneBeforeReduction2;
			if (entity != Entity.Null)
			{
				PlayerController.GetTileDamageValues(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, entity, int5, default(NativeArray<SummarizedConditionsBuffer>), default(NativeArray<SummarizedConditionEffectsBuffer>), conditionEffectValue, out var normHealth, out var damageDone, out var damageDoneBeforeReduction, isTileDamage: false, isDigging: true);
				ClientSystem.DealDamageToEntity(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, entity, position, shouldShowHitFeedbackOnHitEntityPart: false, Entity.Null, default(NativeArray<SummarizedConditionsBuffer>), default(NativeArray<SummarizedConditionEffectsBuffer>), conditionEffectValue, isRanged: false, isMagic: false, playerAttackAspect.entity, placementCD.bestPositionToPlaceAt, out damageDoneBeforeReduction, out damageDone, out damageDoneBeforeReduction2, out var damageAfterReduction, out var _, out var _, out var _, out var _, out var _, showDamageNumber: true, isExplosive: false, isDigging: true, attackWoundup: false, bypassMaxDamagePerHit: false, flag);
				PlayerController.DoImmediateTileDamageEffects(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, tileCD.tileset, tileCD.tileType, placementCD.bestPositionToPlaceAt, normHealth, damageAfterReduction, entity);
				return;
			}
			TileCD tileCD2;
			ObjectDataCD objectDataCD = (playerAttackShared.tileAccessor.GetType(int5, TileType.ground, out tileCD2) ? PugDatabase.TryGetTileItemInfo(TileType.ground, (Tileset)tileCD2.tileset, in tileWithTilesetToObjectDataMap) : default(ObjectDataCD));
			if (objectDataCD.objectID != ObjectID.None)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, playerAttackShared.databaseBank.databaseBankBlob, objectDataCD.variation);
				PlayerController.GetTileDamageValues(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, primaryPrefabEntity, int5, default(NativeArray<SummarizedConditionsBuffer>), default(NativeArray<SummarizedConditionEffectsBuffer>), conditionEffectValue, out var _, out var damageDone2, out damageDoneBeforeReduction2, isTileDamage: false, isDigging: true);
				if (playerAttackShared.worldInfo.IsWorldModeEnabled(WorldMode.Creative) || damageDone2 != int.MaxValue)
				{
					playerAttackLookups.tileDamageBufferLookup[playerAttackShared.tileDamageBufferSingleton].Add(new TileDamageBuffer
					{
						position = int5,
						damage = damageDone2,
						causedByEntity = playerAttackAspect.entity,
						canHitGround = true,
						canHitLowColliders = true,
						pullAnyLootToPlayer = true,
						damagedByExplosion = false,
						bypassMaxDamagePerHit = flag,
						skipWallAndRootsLootDropOnDestroy = flag,
						dontPlayDamageTileEffect = true
					});
					ref GhostEffectEventBufferPointerCD valueRW = ref playerAttackLookups.ghostEffectEventBufferPointerLookup.GetRefRW(playerAttackAspect.entity).ValueRW;
					DynamicBuffer<GhostEffectEventBuffer> buffer = playerAttackLookups.ghostEffectEventBufferLookup[playerAttackAspect.entity];
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = playerAttackShared.currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.DamageTile,
							position1 = new float3(int5.x, 1f, int5.y),
							value1 = tileCD2.tileset,
							tileInfo = new TileInfo
							{
								tileset = tileCD2.tileset,
								tileType = TileType.ground
							}
						}
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
			}
		}

		private static void ReverseDirectDamage(in DealDamageToEntityBuffer damage, in PlayerAttackAspect attackAspect, in PlayerAttackShared PlayerAttackShared, in PlayerAttackLookups PlayerAttackLookups)
		{
			if (PlayerAttackLookups.localTransformLookup.HasComponent(damage.entity) && PlayerAttackLookups.healthLookup.HasComponent(damage.entity))
			{
				if (PlayerAttackLookups.projectileLookup.HasComponent(damage.entity))
				{
					PlayerAttackLookups.healthChangeBufferLookup[PlayerAttackShared.healthChangeBufferEntity].Add(new HealthChangeBuffer
					{
						healthChange = new HealthChange
						{
							entity = damage.entity,
							amount = -damage.damage,
							wasKilled = true,
							bypassMaxDamagePerHit = true
						}
					});
				}
				else
				{
					Entity entity = attackAspect.entity;
					NativeArray<SummarizedConditionsBuffer> conditionsAtHit = PlayerAttackLookups.summarizeConiditionsLookup[entity].AsNativeArray();
					NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsAtHit = PlayerAttackLookups.summarizeConiditionsEffectsLookup[entity].AsNativeArray();
					ClientSystem.DealDamageToEntity(in attackAspect, in PlayerAttackShared, in PlayerAttackLookups, damage.entity, damage.wasHitWhenAtPosition, damage.shoudShowHitFeedbackOnHitEntityPart, damage.hitEntityPart, conditionsAtHit, conditionEffectsAtHit, damage.damage, damage.isRanged, damage.isMagic, entity, damage.hitPosition, out var _, out var _, out var _, out var _, out var _, out var _, out var _, out var _, out var _, damage.isThorns, isExplosive: false, isDigging: false, attackWoundup: false, bypassMaxDamagePerHit: false, godMode: false, isReverseDamage: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			PlayerAttackAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerAttackAspect_RW_AspectTypeHandle.Resolve(chunk);
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DealDamageToCrittersCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlacementCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					PlayerAttackAspect playerAttackAspect = resolvedChunk[i];
					Execute(playerAttackAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr2, i));
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
						PlayerAttackAspect playerAttackAspect2 = resolvedChunk[nextRangeBegin];
						Execute(playerAttackAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr2, nextRangeBegin));
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
					PlayerAttackAspect playerAttackAspect3 = resolvedChunk[j];
					Execute(playerAttackAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					PlayerAttackAspect playerAttackAspect4 = resolvedChunk[k];
					Execute(playerAttackAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr2, k));
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
		public ClearDealDamageToEntityOnPartialTick.InternalCompilerQueryAndHandleData __PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle;

		public PlayerDealDamageJob.InternalCompilerQueryAndHandleData __PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00002E4D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002E4D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002E4D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00002E4E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00002E4E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00002E4E_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00002E4F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00002E4F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00002E4F_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private PlayerDealDamageJob _playerDealDamageJob;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_376898579_0;

	private EntityQuery __query_376898579_1;

	private EntityQuery __query_376898579_2;

	private EntityQuery __query_376898579_3;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<TileWithTilesetToObjectDataMapCD>();
		state.RequireForUpdate<SubMapRegistry>();
		_playerDealDamageJob = new PlayerDealDamageJob
		{
			PlayerAttackShared = new PlayerAttackShared(ref state),
			PlayerAttackLookups = new PlayerAttackLookups(ref state)
		};
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_playerDealDamageJob.PlayerAttackShared.Init(ref state);
		_playerDealDamageJob.tileWithTilesetToObjectDataMap = __query_376898579_1.GetSingleton<TileWithTilesetToObjectDataMapCD>();
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_376898579_2.TryGetSingleton<NetworkTime>(out var value);
		if (value.IsPartialTick)
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(default(ClearDealDamageToEntityOnPartialTick), __TypeHandle.__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			return;
		}
		_playerDealDamageJob.PlayerAttackLookups.Update(ref state);
		EntityCommandBuffer ecb = __query_376898579_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		JobHandle outJobHandle;
		NativeList<Entity> playerEntities = __query_376898579_0.ToEntityListAsync(state.WorldUpdateAllocator, out outJobHandle);
		_playerDealDamageJob.PlayerAttackShared.Update(ref state, ecb, playerEntities);
		state.Dependency = __ScheduleViaJobChunkExtension_1(ref _playerDealDamageJob, __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, JobHandle.CombineDependencies(state.Dependency, outJobHandle), ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(ref _playerDealDamageJob, __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ClearDealDamageToEntityOnPartialTick job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PlayerAttackSystem_ClearDealDamageToEntityOnPartialTick_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ref PlayerDealDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(ref PlayerDealDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PlayerAttackSystem_PlayerDealDamageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_376898579_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileWithTilesetToObjectDataMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_376898579_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_376898579_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_376898579_3 = entityQueryBuilder2.Build(ref state);
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
		((PlayerAttackSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002E4D_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00002E4E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00002E4F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PlayerAttackSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerAttackSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerAttackSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerAttackSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}

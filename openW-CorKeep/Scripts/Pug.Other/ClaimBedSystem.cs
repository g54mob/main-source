using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
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

[BurstCompile]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct ClaimBedSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(FactionCD)
	})]
	private struct ClaimBedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<PlayerClaimedBed> __PlayerClaimedBed_RW_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerGuidCD> __PlayerGuidCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerState_PlayerStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>();
					__PlayerClaimedBed_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerClaimedBed>();
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__PlayerGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGuidCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RW_ComponentTypeHandle.Update(ref state);
					__PlayerClaimedBed_RW_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__PlayerGuidCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGuidCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerClaimedBed>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
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
			public void Run(ref ClaimBedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ClaimBedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ClaimBedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ClaimBedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ClaimBedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ClaimBedJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> cattleLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public ComponentLookup<ClaimedByPlayerGuidCD> claimedByPlayerGuidLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGuidCD> playerGuidLookup;

		[ReadOnly]
		public ComponentLookup<BedCD> bedLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<OccupiableCD> occupiableLookup;

		[ReadOnly]
		public ComponentLookup<GhostOwnerIsLocal> ghostOwnerIsLocal;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		public ColliderCacheCD colliderCacheCD;

		public bool isFirstTimeFullyPredictingTick;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref PlayerStateCD playerStateCD, ref PlayerClaimedBed playerClaimedBed, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in PlayerGuidCD playerGuidCD)
		{
			if (playerStateCD.HasAnyState(PlayerStateEnum.Death | PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding) | godModeLookup.IsComponentEnabled(entity))
			{
				return;
			}
			FactionCD playerFaction = factionLookup[entity];
			float3 position = localTransformLookup[entity].Position;
			bool flag = HasAnyNearbyEnemy(position, in playerFaction);
			bool flag2 = ghostOwnerIsLocal.IsComponentEnabled(entity);
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1u
			};
			collisionWorld.OverlapSphere(position, 1.5f, ref outHits, filter);
			for (int i = 0; i < outHits.Length; i++)
			{
				DistanceHit distanceHit = outHits[i];
				if (!bedLookup.HasComponent(distanceHit.Entity) || !localTransformLookup.TryGetComponent(distanceHit.Entity, out var componentData))
				{
					continue;
				}
				Sleep.GetOffsetAndFacingDirectionFromOccupiable(out var offset, out var _, distanceHit.Entity, directionLookup, occupiableLookup);
				float3 float5 = componentData.Position + offset;
				float num = math.lengthsq(position - float5);
				if (num < 0.16000001f)
				{
					TryToClaimOrSleepInBed(distanceHit.Entity, entity, flag, ref playerStateCD, ref playerClaimedBed, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, in playerGuidCD, flag2);
				}
				if (flag2)
				{
					if (num < 0.16000001f && isFirstTimeFullyPredictingTick)
					{
						claimedByPlayerGuidLookup.GetRefRW(distanceHit.Entity).ValueRW.lastLocalWithinClaimdistanceTick = currentTick;
					}
					else
					{
						claimedByPlayerGuidLookup.GetRefRW(distanceHit.Entity).ValueRW.lastLocalWithinClaimdistanceTick = default(NetworkTick);
					}
				}
			}
			if (!flag)
			{
				TrySleepInClaimedBed(ref playerClaimedBed, in playerGuidCD, ref playerStateCD, position);
			}
		}

		private bool HasAnyNearbyEnemy(float3 position, in FactionCD playerFaction)
		{
			NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			PhysicsCollider sphereCollider = PhysicsManager.GetSphereCollider(float3.zero, 15f, 24u, colliderCacheCD);
			collisionWorld.CastCollider(PhysicsManager.GetColliderCastInput(position, position, sphereCollider), ref allHits);
			bool result = false;
			foreach (ColliderCastHit item in allHits)
			{
				if (enemyLookup.HasComponent(item.Entity) && !cattleLookup.HasComponent(item.Entity) && (!objectDataLookup.TryGetComponent(item.Entity, out var componentData) || componentData.objectID != ObjectID.SlimeBlob) && componentData.objectID != ObjectID.SlipperySlimeBlob && componentData.objectID != ObjectID.PoisonSlimeBlob && (!factionLookup.TryGetComponent(item.Entity, out var componentData2) || !playerFaction.HasBefriendedFaction(componentData2)))
				{
					result = true;
					break;
				}
			}
			allHits.Dispose();
			return result;
		}

		private void TryToClaimOrSleepInBed(Entity bedEntity, Entity playerEntity, bool anyNearbyEnemy, ref PlayerStateCD playerStateCD, ref PlayerClaimedBed playerClaimedBed, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, in PlayerGuidCD playerGuidCD, bool playerIsLocal)
		{
			ClaimedByPlayerGuidCD claimedByPlayerGuidCD = claimedByPlayerGuidLookup[bedEntity];
			if (anyNearbyEnemy)
			{
				if (isFirstTimeFullyPredictingTick && playerIsLocal && claimedByPlayerGuidCD.ShouldDisplayClaimEmotes(currentTick) && !playerStateCD.HasAnyState(PlayerStateEnum.Sleep))
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							entity = playerEntity,
							localOnlyEffect = 1,
							effectID = EffectID.Emote,
							value1 = 8
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
				return;
			}
			bool flag = false;
			Hash128 value = playerGuidLookup[playerEntity].Value;
			if (claimedByPlayerGuidCD.isClaimed && claimedByPlayerGuidCD.playerGuid == value)
			{
				flag = true;
			}
			if (!flag && !claimedByPlayerGuidCD.isClaimed)
			{
				PlayerClaimBed(playerEntity, bedEntity, ref playerClaimedBed, in playerGuidCD);
				flag = true;
			}
			if (!flag && isFirstTimeFullyPredictingTick && playerIsLocal && claimedByPlayerGuidCD.ShouldDisplayClaimEmotes(currentTick))
			{
				DynamicBuffer<GhostEffectEventBuffer> buffer2 = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = playerEntity,
						localOnlyEffect = 1,
						effectID = EffectID.Emote,
						value1 = 7
					}
				};
				buffer2.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
		}

		private void PlayerClaimBed(Entity claimedByEntity, Entity bedToClaim, ref PlayerClaimedBed playerClaimedBed, in PlayerGuidCD playerGuidCD)
		{
			if (playerGuidLookup.HasComponent(claimedByEntity) && claimedByPlayerGuidLookup.HasComponent(bedToClaim) && localTransformLookup.TryGetComponent(bedToClaim, out var componentData))
			{
				Entity entity = Entity.Null;
				entity = playerClaimedBed.claimedBedEntity;
				if (entity != Entity.Null)
				{
					claimedByPlayerGuidLookup.GetRefRW(entity).ValueRW.playerGuid = default(Hash128);
				}
				Hash128 value = playerGuidCD.Value;
				claimedByPlayerGuidLookup.GetRefRW(bedToClaim).ValueRW.playerGuid = value;
				playerClaimedBed.claimedBedEntity = bedToClaim;
				playerClaimedBed.position = componentData.Position.xz;
			}
		}

		private void TrySleepInClaimedBed(ref PlayerClaimedBed playerClaimedBed, in PlayerGuidCD playerGuidCD, ref PlayerStateCD playerStateCD, float3 playerPosition)
		{
			if (playerClaimedBed.claimedBedEntity == Entity.Null || !claimedByPlayerGuidLookup.TryGetComponent(playerClaimedBed.claimedBedEntity, out var componentData) || !componentData.isClaimed || componentData.playerGuid != playerGuidCD.Value)
			{
				playerClaimedBed.canAttemptSleep = true;
				return;
			}
			Sleep.GetOffsetAndFacingDirectionFromOccupiable(out var offset, out var _, playerClaimedBed.claimedBedEntity, directionLookup, occupiableLookup);
			float3 float5 = localTransformLookup[playerClaimedBed.claimedBedEntity].Position + offset;
			float num = math.lengthsq(playerPosition - float5);
			if (playerClaimedBed.canAttemptSleep)
			{
				if (num < 0.16000001f)
				{
					playerStateCD.PushState(PlayerStateEnum.Sleep);
					playerClaimedBed.canAttemptSleep = false;
				}
			}
			else if (num > 0.16000001f)
			{
				playerClaimedBed.canAttemptSleep = true;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerClaimedBed_RW_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGuidCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, i);
					ref PlayerClaimedBed playerClaimedBed = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerClaimedBed>(nativeArrayPtr3, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor2[i];
					Execute(entity, ref playerStateCD, ref playerClaimedBed, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, ref conditionsBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGuidCD>(nativeArrayPtr5, i));
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
						ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, nextRangeBegin);
						ref PlayerClaimedBed playerClaimedBed2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerClaimedBed>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref playerStateCD2, ref playerClaimedBed2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, ref conditionsBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGuidCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, j);
					ref PlayerClaimedBed playerClaimedBed3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerClaimedBed>(nativeArrayPtr3, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, j);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref playerStateCD3, ref playerClaimedBed3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, ref conditionsBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGuidCD>(nativeArrayPtr5, j));
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
					ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, k);
					ref PlayerClaimedBed playerClaimedBed4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerClaimedBed>(nativeArrayPtr3, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, k);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref playerStateCD4, ref playerClaimedBed4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, ref conditionsBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGuidCD>(nativeArrayPtr5, k));
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
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		public ComponentLookup<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGuidCD> __PlayerGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BedCD> __BedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OccupiableCD> __OccupiableCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GhostOwnerIsLocal> __Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

		public ClaimBedJob.InternalCompilerQueryAndHandleData __ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__ClaimedByPlayerGuidCD_RW_ComponentLookup = state.GetComponentLookup<ClaimedByPlayerGuidCD>();
			__PlayerGuidCD_RO_ComponentLookup = state.GetComponentLookup<PlayerGuidCD>(isReadOnly: true);
			__BedCD_RO_ComponentLookup = state.GetComponentLookup<BedCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__OccupiableCD_RO_ComponentLookup = state.GetComponentLookup<OccupiableCD>(isReadOnly: true);
			__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup = state.GetComponentLookup<GhostOwnerIsLocal>(isReadOnly: true);
			__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
			__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000010C8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000010C8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000010C8_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000010C9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000010C9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000010C9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private const float BED_CHECK_DISTANCE = 1.5f;

	private const float DISTANCE_FROM_ENEMIES_TO_SLEEP = 15f;

	public const float BED_LEAVE_DISTANCE_SQR = 0.16000001f;

	private const float AUTO_CLAIM_BED_DISTANCE_SQR = 0.16000001f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1175686554_0;

	private EntityQuery __query_1175686554_1;

	private EntityQuery __query_1175686554_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ColliderCacheCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1175686554_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 1, 10f))
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new ClaimBedJob
			{
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				claimedByPlayerGuidLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ClaimedByPlayerGuidCD_RW_ComponentLookup, ref state),
				playerGuidLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGuidCD_RO_ComponentLookup, ref state),
				bedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BedCD_RO_ComponentLookup, ref state),
				directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				occupiableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OccupiableCD_RO_ComponentLookup, ref state),
				ghostOwnerIsLocal = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup, ref state),
				collisionWorld = __query_1175686554_1.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				colliderCacheCD = __query_1175686554_2.GetSingleton<ColliderCacheCD>(),
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
				currentTick = value.ServerTick,
				godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state)
			}, __TypeHandle.__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ClaimBedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ClaimBedSystem_ClaimBedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1175686554_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1175686554_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ColliderCacheCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1175686554_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000010C8_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000010C9_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ClaimBedSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ClaimBedSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ClaimBedSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

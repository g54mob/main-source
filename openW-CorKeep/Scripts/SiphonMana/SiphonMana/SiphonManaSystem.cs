using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using SiphonMana.Components;
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

namespace SiphonMana
{
	[BurstCompile]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct SiphonManaSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		private struct EntityWithDistance : IComparable<EntityWithDistance>
		{
			public Entity Entity;

			public float DistanceSq;

			public int CompareTo(EntityWithDistance other)
			{
				return DistanceSq.CompareTo(other.DistanceSq);
			}
		}

		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(Simulate),
			typeof(LocalTransform)
		})]
		[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
		[WithPresent(new Type[] { typeof(SiphonManaActiveTag) })]
		private struct SiphonManaStateTargetConnectJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<SiphonManaCD> __SiphonMana_Components_SiphonManaCD_RO_ComponentTypeHandle;

					public BufferTypeHandle<SiphonManaTargetBufferElement> __SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__SiphonMana_Components_SiphonManaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SiphonManaCD>(isReadOnly: true);
						__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<SiphonManaTargetBufferElement>();
						__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
						__OwnerReferenceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__SiphonMana_Components_SiphonManaCD_RO_ComponentTypeHandle.Update(ref state);
						__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle.Update(ref state);
						__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
						__OwnerReferenceCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithPresent<SiphonManaActiveTag>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SiphonManaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<NearbyEntitiesBufferCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<OwnerReferenceCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SiphonManaTargetBufferElement>();
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
				public void Run(ref SiphonManaStateTargetConnectJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SiphonManaStateTargetConnectJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SiphonManaStateTargetConnectJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SiphonManaStateTargetConnectJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SiphonManaStateTargetConnectJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SiphonManaStateTargetConnectJob job, EntityManager entityManager)
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
			public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

			[ReadOnly]
			public ComponentLookup<EntityPartCD> entityPartLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

			[ReadOnly]
			public ComponentLookup<EnemyCD> enemyLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> playerGhostLookup;

			public ComponentLookup<LocalTransform> localTransformLookup;

			public ComponentLookup<SiphonManaActiveTag> siphonManaStateActiveTagLookup;

			public ComponentLookup<FactionCD> factionLookup;

			public NativeList<EntityWithDistance> entityWithDistanceCachedList;

			public NativeList<RaycastHit> rayHitsCachedList;

			public TileAccessor tileAccessor;

			public CollisionWorld collisionWorld;

			public WorldInfoCD worldInfoCD;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in SiphonManaCD siphonManaCD, ref DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer, in OwnerReferenceCD ownerReferenceCD)
			{
				EnabledRefRW<SiphonManaActiveTag> enabledRefRW = siphonManaStateActiveTagLookup.GetEnabledRefRW<SiphonManaActiveTag>(entity);
				float3 position = localTransformLookup[entity].Position;
				if (!IsOwnerInRangeAndSight(in siphonManaCD, position, in ownerReferenceCD))
				{
					EmptyTargetsInBuffer(siphonManaTargetBuffer);
					enabledRefRW.ValueRW = false;
					return;
				}
				entityWithDistanceCachedList.Clear();
				factionLookup.TryGetComponent(entity, out var componentData);
				for (int i = 0; i < nearbyEntitiesBuffer.Length; i++)
				{
					Entity entity2 = nearbyEntitiesBuffer[i].entity;
					EntityPartCD componentData3;
					if (playerGhostExtrapolatedLookup.TryGetComponent(entity2, out var componentData2))
					{
						entity2 = componentData2.playerGhost;
					}
					else if (entityPartLookup.TryGetComponent(entity2, out componentData3))
					{
						entity2 = componentData3.mainEntity;
					}
					if ((!enemyLookup.HasComponent(entity2) && !playerGhostLookup.HasComponent(entity2)) || entityDestroyedLookup.HasAndIsComponentEnabled(entity2) || !localTransformLookup.TryGetComponent(entity2, out var componentData4))
					{
						continue;
					}
					factionLookup.TryGetComponent(entity2, out var componentData5);
					if (componentData.CanAttack(componentData5, worldInfoCD))
					{
						float3 position2 = componentData4.Position;
						float num = math.lengthsq(position2 - position);
						if (!(num >= siphonManaCD.siphonRadiusSq) && CanSeePosition(position, position2))
						{
							ref NativeList<EntityWithDistance> reference = ref entityWithDistanceCachedList;
							EntityWithDistance value = new EntityWithDistance
							{
								Entity = entity2,
								DistanceSq = num
							};
							reference.Add(in value);
						}
					}
				}
				if (entityWithDistanceCachedList.Length == 0)
				{
					EmptyTargetsInBuffer(siphonManaTargetBuffer);
					enabledRefRW.ValueRW = false;
					return;
				}
				enabledRefRW.ValueRW = true;
				entityWithDistanceCachedList.Sort();
				int num2 = math.min(entityWithDistanceCachedList.Length, 1);
				int num3 = 0;
				for (int j = 0; j < siphonManaTargetBuffer.Length; j++)
				{
					if (siphonManaTargetBuffer[j].siphonManaTarget != Entity.Null)
					{
						num3++;
					}
				}
				bool flag = num2 == num3;
				if (flag)
				{
					for (int k = 0; k < num2; k++)
					{
						Entity entity3 = entityWithDistanceCachedList[k].Entity;
						bool flag2 = false;
						for (int l = 0; l < siphonManaTargetBuffer.Length; l++)
						{
							flag2 |= entity3 == siphonManaTargetBuffer[l].siphonManaTarget;
						}
						if (!flag2)
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					EmptyTargetsInBuffer(siphonManaTargetBuffer);
					for (int m = 0; m < num2; m++)
					{
						siphonManaTargetBuffer[m] = new SiphonManaTargetBufferElement
						{
							siphonManaTarget = entityWithDistanceCachedList[m].Entity
						};
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void EmptyTargetsInBuffer(DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer)
			{
				for (int i = 0; i < siphonManaTargetBuffer.Length; i++)
				{
					siphonManaTargetBuffer[i] = default(SiphonManaTargetBufferElement);
				}
			}

			private bool IsOwnerInRangeAndSight(in SiphonManaCD siphonManaCD, float3 ourPosition, in OwnerReferenceCD ownerReferenceCD)
			{
				float3 position = localTransformLookup[ownerReferenceCD.owner].Position;
				if (math.lengthsq(ourPosition - position) <= siphonManaCD.maxTransferDistanceSq)
				{
					return CanSeePosition(ourPosition, position);
				}
				return false;
			}

			private bool CanSeePosition(float3 fromPos, float3 toPos)
			{
				RaycastInput input = new RaycastInput
				{
					Start = fromPos + new float3(0f, 0.5f, 0f),
					End = toPos + new float3(0f, 0.5f, 0f),
					Filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 1u
					}
				};
				rayHitsCachedList.Clear();
				collisionWorld.CastRay(input, ref rayHitsCachedList);
				for (int i = 0; i < rayHitsCachedList.Length; i++)
				{
					Entity entity = rayHitsCachedList[i].Entity;
					EntityPartCD componentData2;
					if (playerGhostExtrapolatedLookup.TryGetComponent(entity, out var componentData))
					{
						entity = componentData.playerGhost;
					}
					else if (entityPartLookup.TryGetComponent(entity, out componentData2))
					{
						entity = componentData2.mainEntity;
					}
					if (!enemyLookup.HasComponent(entity) && !playerGhostLookup.HasComponent(entity))
					{
						return false;
					}
				}
				int2 int5 = fromPos.RoundToInt2();
				int2 end = toPos.RoundToInt2();
				int2 pos = int5;
				do
				{
					if (tileAccessor.GetTopType(pos).IsWallTile())
					{
						return false;
					}
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
				return true;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SiphonMana_Components_SiphonManaCD_RO_ComponentTypeHandle);
				BufferAccessor<SiphonManaTargetBufferElement> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle);
				BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__OwnerReferenceCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref SiphonManaCD siphonManaCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr2, i);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer = bufferAccessor[i];
						Execute(entity, in siphonManaCD, ref siphonManaTargetBuffer, bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, i));
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
							ref SiphonManaCD siphonManaCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr2, nextRangeBegin);
							DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(entity2, in siphonManaCD2, ref siphonManaTargetBuffer2, bufferAccessor2[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, nextRangeBegin));
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
						ref SiphonManaCD siphonManaCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr2, j);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer3 = bufferAccessor[j];
						Execute(entity3, in siphonManaCD3, ref siphonManaTargetBuffer3, bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, j));
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
						ref SiphonManaCD siphonManaCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr2, k);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer4 = bufferAccessor[k];
						Execute(entity4, in siphonManaCD4, ref siphonManaTargetBuffer4, bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, k));
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
			typeof(SiphonManaActiveTag),
			typeof(Simulate)
		})]
		[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
		private struct SiphonManaJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<SiphonManaCD> __SiphonMana_Components_SiphonManaCD_RW_ComponentTypeHandle;

					public BufferTypeHandle<SiphonManaTargetBufferElement> __SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__SiphonMana_Components_SiphonManaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SiphonManaCD>();
						__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<SiphonManaTargetBufferElement>();
						__OwnerReferenceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__SiphonMana_Components_SiphonManaCD_RW_ComponentTypeHandle.Update(ref state);
						__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle.Update(ref state);
						__OwnerReferenceCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<OwnerReferenceCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SiphonManaActiveTag>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SiphonManaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SiphonManaTargetBufferElement>();
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
				public void Run(ref SiphonManaJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SiphonManaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SiphonManaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SiphonManaJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SiphonManaJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SiphonManaJob job, EntityManager entityManager)
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
			public ComponentLookup<Simulate> simulateLookup;

			public ComponentLookup<ManaCD> manaLookup;

			public NetworkTick currentTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(ref SiphonManaCD siphonManaCD, ref DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer, in OwnerReferenceCD ownerReferenceCD)
			{
				if (siphonManaCD.siphonCooldownTimer.isRunning && !siphonManaCD.siphonCooldownTimer.IsTimerElapsed(currentTick))
				{
					return;
				}
				siphonManaCD.siphonCooldownTimer.Start(currentTick);
				if (!simulateLookup.HasAndIsComponentEnabled(ownerReferenceCD.owner) || !manaLookup.TryGetComponent(ownerReferenceCD.owner, out var componentData))
				{
					return;
				}
				int num = (int)math.round(siphonManaCD.maxManaPerSiphonPercentage * (float)componentData.maxMana);
				int num2 = 0;
				for (int i = 0; i < siphonManaTargetBuffer.Length; i++)
				{
					Entity siphonManaTarget = siphonManaTargetBuffer[i].siphonManaTarget;
					if (siphonManaTarget != Entity.Null)
					{
						num2++;
					}
					if (simulateLookup.HasAndIsComponentEnabled(siphonManaTarget) && manaLookup.TryGetComponent(siphonManaTarget, out var componentData2))
					{
						componentData2.mana = math.max(componentData2.mana - num, 0);
						manaLookup[siphonManaTarget] = componentData2;
					}
				}
				componentData.mana = math.min(componentData.mana + num * num2, componentData.maxMana);
				manaLookup[ownerReferenceCD.owner] = componentData;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SiphonMana_Components_SiphonManaCD_RW_ComponentTypeHandle);
				BufferAccessor<SiphonManaTargetBufferElement> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SiphonMana_Components_SiphonManaTargetBufferElement_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__OwnerReferenceCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ref SiphonManaCD siphonManaCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr, i);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer = bufferAccessor[i];
						Execute(ref siphonManaCD, ref siphonManaTargetBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, i));
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
							ref SiphonManaCD siphonManaCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr, nextRangeBegin);
							DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(ref siphonManaCD2, ref siphonManaTargetBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, nextRangeBegin));
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
						ref SiphonManaCD siphonManaCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr, j);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer3 = bufferAccessor[j];
						Execute(ref siphonManaCD3, ref siphonManaTargetBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ref SiphonManaCD siphonManaCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SiphonManaCD>(nativeArrayPtr, k);
						DynamicBuffer<SiphonManaTargetBufferElement> siphonManaTargetBuffer4 = bufferAccessor[k];
						Execute(ref siphonManaCD4, ref siphonManaTargetBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, k));
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
			public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			public ComponentLookup<SiphonManaActiveTag> __SiphonMana_Components_SiphonManaActiveTag_RW_ComponentLookup;

			public ComponentLookup<FactionCD> __FactionCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			public SiphonManaStateTargetConnectJob.InternalCompilerQueryAndHandleData __SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			public ComponentLookup<ManaCD> __ManaCD_RW_ComponentLookup;

			public SiphonManaJob.InternalCompilerQueryAndHandleData __SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
				__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__SiphonMana_Components_SiphonManaActiveTag_RW_ComponentLookup = state.GetComponentLookup<SiphonManaActiveTag>();
				__FactionCD_RW_ComponentLookup = state.GetComponentLookup<FactionCD>();
				__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__ManaCD_RW_ComponentLookup = state.GetComponentLookup<ManaCD>();
				__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000000C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000000C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000000C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1377861710_0;

		private EntityQuery __query_1377861710_1;

		private EntityQuery __query_1377861710_2;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
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
			state.Dependency = __ScheduleViaJobChunkExtension_0(new SiphonManaStateTargetConnectJob
			{
				playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
				entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
				entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
				siphonManaStateActiveTagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SiphonMana_Components_SiphonManaActiveTag_RW_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RW_ComponentLookup, ref state),
				enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				entityWithDistanceCachedList = new NativeList<EntityWithDistance>(8, state.WorldUpdateAllocator),
				rayHitsCachedList = new NativeList<RaycastHit>(8, state.WorldUpdateAllocator),
				tileAccessor = _tileAccessor,
				collisionWorld = __query_1377861710_0.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				worldInfoCD = __query_1377861710_1.GetSingleton<WorldInfoCD>()
			}, __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			__query_1377861710_2.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new SiphonManaJob
			{
				simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
				manaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManaCD_RW_ComponentLookup, ref state),
				currentTick = value.ServerTick
			}, __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(SiphonManaStateTargetConnectJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaStateTargetConnectJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(SiphonManaJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__SiphonMana_SiphonManaSystem_SiphonManaJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1377861710_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1377861710_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1377861710_2 = entityQueryBuilder2.Build(ref state);
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
			((SiphonManaSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000000C_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((SiphonManaSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((SiphonManaSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SiphonManaSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SiphonManaSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using Unity.Profiling;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateBefore(typeof(UpdateHealthSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
public struct TileDamageSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct MergeJob : IJob
	{
		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public Entity tileDamageBufferEntity;

		public void Execute()
		{
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				ref TileDamageBuffer reference = ref dynamicBuffer.ElementAt(i);
				for (int num = dynamicBuffer.Length - 1; num > i; num--)
				{
					if (math.all(dynamicBuffer[num].position == reference.position))
					{
						reference.damage += dynamicBuffer[num].damage;
						dynamicBuffer.RemoveAtSwapBack(num);
					}
				}
			}
		}
	}

	[BurstCompile]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	[WithAll(new Type[]
	{
		typeof(TileDamageTagCD),
		typeof(EntityDestroyedCD)
	})]
	private struct RemoveDamagesFromDeadTilesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileDamageTagCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
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
			public void Run(ref RemoveDamagesFromDeadTilesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RemoveDamagesFromDeadTilesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RemoveDamagesFromDeadTilesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RemoveDamagesFromDeadTilesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RemoveDamagesFromDeadTilesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RemoveDamagesFromDeadTilesJob job, EntityManager entityManager)
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

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public ComponentLookup<TileDamageTagCD> tileDamageTagLookup;

		public Entity tileDamageBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform)
		{
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			int2 int5 = (int2)math.round(new float2(transform.Position.x, transform.Position.z));
			for (int num = dynamicBuffer.Length - 1; num >= 0; num--)
			{
				if (math.all(dynamicBuffer.ElementAt(num).position == int5))
				{
					dynamicBuffer.RemoveAtSwapBack(num);
				}
			}
			tileDamageTagLookup.SetComponentEnabled(entity, value: false);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k));
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
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	[WithAll(new Type[]
	{
		typeof(TileDamageTagCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct ApplyDamageToExistingDamageEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<TileCD> __TileCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__TileCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TileCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__TileCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileDamageTagCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
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
			public void Run(ref ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ApplyDamageToExistingDamageEntitiesJob job, EntityManager entityManager)
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

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public Entity tileDamageBufferEntity;

		[ReadOnly]
		public TileAccessor tileLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> damageReductionLookup;

		[ReadOnly]
		public ComponentLookup<InitialHealthChange> initalHealthChangeLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public Entity healthChangeBufferEntity;

		public bool isServer;

		public bool isFirstTimeFullyPredictingTick;

		public NetworkTick tick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in HealthCD health, in TileCD tileCD)
		{
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			int2 int5 = (int2)math.round(new float2(transform.Position.x, transform.Position.z));
			TileCD topDamageableTile = tileLookup.GetTopDamageableTile(int5);
			bool flag = isExplosiveLookup.HasComponent(entity);
			bool flag2 = false;
			for (int num = dynamicBuffer.Length - 1; num >= 0; num--)
			{
				if (math.all(dynamicBuffer.ElementAt(num).position == int5) && topDamageableTile.Equals(tileCD))
				{
					TileDamageBuffer tileDamage = dynamicBuffer[num];
					if (!tileDamage.dontHitWalkableTiles || !tileCD.tileType.IsWalkableTile())
					{
						HealthChange healthChange = new HealthChange
						{
							entity = entity,
							amount = -tileDamage.damage,
							skipWallAndRootsLootDropOnDestroy = tileDamage.skipWallAndRootsLootDropOnDestroy,
							causedByEntity = tileDamage.causedByEntity,
							bypassDamageReduction = tileDamage.bypassDamageReduction,
							bypassMaxDamagePerHit = tileDamage.bypassMaxDamagePerHit,
							pullLootToPlayer = tileDamage.pullAnyLootToPlayer,
							damagedByExplosion = tileDamage.damagedByExplosion,
							skipLootDropOnDestroy = (tileDamage.damagedByExplosion && flag)
						};
						healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
						{
							healthChange = healthChange
						});
						if (isFirstTimeFullyPredictingTick && !tileDamage.dontPlayDamageTileEffect && (!tileDamage.dontHitGroundSlime || topDamageableTile.tileType != TileType.groundSlime))
						{
							damageReductionLookup.TryGetComponent(entity, out var componentData);
							PlayDamageTileEffect(tick, in tileDamage, tileCD, ecb, effectEventBufferSingleton, componentData, health, in tileLookup, ref ghostEffectEventBufferPointerLookup, ref ghostEffectEventBufferLookup);
						}
						dynamicBuffer.RemoveAtSwapBack(num);
						flag2 = true;
					}
				}
			}
			bool flag3 = initalHealthChangeLookup.IsComponentEnabled(entity);
			if (!flag2 && isServer && health.health >= health.maxHealth && !flag3)
			{
				ecb.DestroyEntity(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__TileCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr4, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr4, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr4, k));
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
	private struct CreateNewTileDamageEntitiesJob : IJob
	{
		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public Entity tileDamageBufferEntity;

		[ReadOnly]
		public TileAccessor tileLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> damageReductionLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public Entity effectEventBufferSingleton;

		public bool creativeMode;

		public bool isFirstTimeFullyPredictingTick;

		public bool isClient;

		public Unity.Mathematics.Random backupRandom;

		public NetworkTick tick;

		public void Execute()
		{
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			NativeArray<TileDamageBuffer> array = dynamicBuffer.AsNativeArray();
			array.Sort(default(TileDamageBufferComparer));
			for (int i = 0; i < array.Length; i++)
			{
				TileDamageBuffer tileDamage = array[i];
				TileCD tile = tileLookup.GetTopDamageableTile(tileDamage.position);
				if ((tileDamage.dontHitBridges && tile.tileType == TileType.bridge) || (tileDamage.dontHitGroundSlime && tile.tileType == TileType.groundSlime) || (!tileDamage.canHitLowColliders && tile.tileType.IsLowCollider()) || (tileDamage.dontHitWalkableTiles && tile.tileType.IsWalkableTile()))
				{
					continue;
				}
				if (tileDamage.canHitGround && tile.tileType == TileType.none && tileLookup.GetType(tileDamage.position, TileType.ground, out var tileCD))
				{
					tile = tileCD;
				}
				ObjectDataCD objectData = PugDatabase.GetObjectData(tile.tileset, tile.tileType, databaseBankCD.databaseBankBlob);
				if (objectData.objectID == ObjectID.None)
				{
					continue;
				}
				if (creativeMode || objectData.objectID == ObjectID.KinematicDynamo || (!tileLookup.HasType(tileDamage.position, TileType.immune) && tile.tileType != TileType.greatWall && ((tile.tileset != 2 && tile.tileset != 72) || (tile.tileType != TileType.wall && tile.tileType != TileType.ground))))
				{
					if (isFirstTimeFullyPredictingTick)
					{
						Entity prefabEntity;
						Entity entity = EntityUtility.CreateEntity(position: new float3(tileDamage.position.x, 0f, tileDamage.position.y), ecb: ecb, objectID: objectData.objectID, _amount: 1, entityInfoBank: databaseBankCD.databaseBankBlob, prefabEntity: out prefabEntity, variation: objectData.variation);
						ecb.AddComponent<DontSerializeCD>(entity);
						ecb.SetComponentEnabled<TileDamageTagCD>(entity, value: true);
						ecb.SetComponent(entity, new InitialHealthChange
						{
							healthChange = new HealthChange
							{
								entity = entity,
								amount = -tileDamage.damage,
								skipWallAndRootsLootDropOnDestroy = tileDamage.skipWallAndRootsLootDropOnDestroy,
								causedByEntity = tileDamage.causedByEntity,
								bypassDamageReduction = tileDamage.bypassDamageReduction,
								bypassMaxDamagePerHit = tileDamage.bypassMaxDamagePerHit,
								pullLootToPlayer = tileDamage.pullAnyLootToPlayer,
								damagedByExplosion = tileDamage.damagedByExplosion,
								skipLootDropOnDestroy = (tileDamage.damagedByExplosion && isExplosiveLookup.HasComponent(prefabEntity))
							}
						});
						ecb.SetComponentEnabled<InitialHealthChange>(entity, value: true);
						MoveToPredictedByCombatOrInventoryInteractionCD component = default(MoveToPredictedByCombatOrInventoryInteractionCD);
						component.SetLastInteractionTick(tick);
						ecb.SetComponent(entity, component);
						if (randomLookup.TryGetComponent(tileDamage.causedByEntity, out var componentData))
						{
							Unity.Mathematics.Random value = PugRandom.InheritRngFromEntity(ref componentData.Value);
							ecb.SetComponent(entity, new RandomCD
							{
								Value = value
							});
							randomLookup[tileDamage.causedByEntity] = componentData;
						}
						else if (isClient)
						{
							ecb.SetComponent(entity, new RandomCD
							{
								Value = new Unity.Mathematics.Random(backupRandom.NextUInt())
							});
						}
						if (!tileDamage.dontPlayDamageTileEffect)
						{
							damageReductionLookup.TryGetComponent(prefabEntity, out var componentData2);
							HealthCD healthCD = healthLookup[prefabEntity];
							PlayDamageTileEffect(tick, in tileDamage, tile, ecb, effectEventBufferSingleton, componentData2, healthCD, in tileLookup, ref ghostEffectEventBufferPointerLookup, ref ghostEffectEventBufferLookup);
						}
					}
				}
				else if (!tileDamage.dontPlayDamageTileEffect && isFirstTimeFullyPredictingTick)
				{
					PlayDamageTileFailEffect(tick, tileDamage, tile, ecb, effectEventBufferSingleton, ref ghostEffectEventBufferPointerLookup, ref ghostEffectEventBufferLookup);
				}
			}
			dynamicBuffer.Clear();
		}
	}

	private struct TypeHandle
	{
		public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

		public ComponentLookup<TileDamageTagCD> __TileDamageTagCD_RW_ComponentLookup;

		public RemoveDamagesFromDeadTilesJob.InternalCompilerQueryAndHandleData __TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> __IsExplosiveCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<InitialHealthChange> __InitialHealthChange_RO_ComponentLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		public ApplyDamageToExistingDamageEntitiesJob.InternalCompilerQueryAndHandleData __TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
			__TileDamageTagCD_RW_ComponentLookup = state.GetComponentLookup<TileDamageTagCD>();
			__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__IsExplosiveCD_RO_ComponentLookup = state.GetComponentLookup<IsExplosiveCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__InitialHealthChange_RO_ComponentLookup = state.GetComponentLookup<InitialHealthChange>(isReadOnly: true);
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00004370_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00004370_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00004370_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00004371_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00004371_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00004371_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private EntityQuery _pickedUpTilesQ;

	private TileAccessor _tileAccessor;

	private static readonly ProfilerMarker marker_1 = new ProfilerMarker("Marker_1");

	private static readonly ProfilerMarker marker_2 = new ProfilerMarker("Marker_2");

	private static readonly ProfilerMarker marker_3 = new ProfilerMarker("Marker_3");

	private static readonly ProfilerMarker marker_4 = new ProfilerMarker("Marker_4");

	private static readonly ProfilerMarker marker_5 = new ProfilerMarker("Marker_5");

	private TypeHandle __TypeHandle;

	private EntityQuery __query_972544419_0;

	private EntityQuery __query_972544419_1;

	private EntityQuery __query_972544419_2;

	private EntityQuery __query_972544419_3;

	private EntityQuery __query_972544419_4;

	private EntityQuery __query_972544419_5;

	private EntityQuery __query_972544419_6;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		Entity entity = state.EntityManager.CreateEntity();
		state.EntityManager.AddBuffer<TileDamageBuffer>(entity);
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
	}

	[BurstCompile]
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
		using (new ProfilerMarker("Full").Auto())
		{
			new ProfilerMarker("Tile accessor");
			_tileAccessor.Update(ref state);
			new ProfilerMarker("Start fetches");
			EntityCommandBuffer ecb = __query_972544419_0.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			Entity singletonEntity = __query_972544419_1.GetSingletonEntity();
			Entity singletonEntity2 = __query_972544419_2.GetSingletonEntity();
			bool creativeMode = __query_972544419_3.GetSingleton<WorldInfoCD>().IsWorldModeEnabled(WorldMode.Creative);
			bool flag = state.WorldUnmanaged.IsServer();
			new ProfilerMarker("First job");
			BufferLookup<TileDamageBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref state);
			state.Dependency = IJobExtensions.Schedule(new MergeJob
			{
				tileDamageBufferEntity = singletonEntity2,
				tileDamageBufferLookup = bufferLookup
			}, state.Dependency);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RemoveDamagesFromDeadTilesJob
			{
				tileDamageBufferEntity = singletonEntity2,
				tileDamageBufferLookup = bufferLookup,
				tileDamageTagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileDamageTagCD_RW_ComponentLookup, ref state)
			}, __TypeHandle.__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			__query_972544419_4.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new ApplyDamageToExistingDamageEntitiesJob
			{
				tileDamageBufferEntity = singletonEntity2,
				tileDamageBufferLookup = bufferLookup,
				ecb = ecb,
				effectEventBufferSingleton = singletonEntity,
				tileLookup = _tileAccessor,
				isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RO_ComponentLookup, ref state),
				damageReductionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state),
				initalHealthChangeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InitialHealthChange_RO_ComponentLookup, ref state),
				ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
				ghostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
				isServer = flag,
				healthChangeBufferEntity = __query_972544419_5.GetSingletonEntity(),
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
				healthChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state),
				tick = value.ServerTick
			}, __TypeHandle.__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = IJobExtensions.Schedule(new CreateNewTileDamageEntitiesJob
			{
				tileDamageBufferEntity = singletonEntity2,
				tileDamageBufferLookup = bufferLookup,
				ecb = ecb,
				effectEventBufferSingleton = singletonEntity,
				tileLookup = _tileAccessor,
				isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RO_ComponentLookup, ref state),
				damageReductionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state),
				healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
				randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
				ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
				ghostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
				databaseBankCD = __query_972544419_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
				creativeMode = creativeMode,
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
				isClient = !flag,
				backupRandom = PugRandom.GetRng(),
				tick = value.ServerTick
			}, state.Dependency);
		}
	}

	public static int CalculateTileDamageAfterReduction(int tileDamage, DamageReductionCD tileDamageReduction)
	{
		int num = math.max(0, tileDamage - tileDamageReduction.reduction);
		num = ((tileDamageReduction.minDamagePerHit > 0) ? math.max(num, tileDamageReduction.minDamagePerHit) : num);
		return (tileDamageReduction.maxDamagePerHit > 0) ? math.min(num, tileDamageReduction.maxDamagePerHit) : num;
	}

	private static void PlayDamageTileEffect(NetworkTick tick, in TileDamageBuffer tileDamage, TileCD tile, EntityCommandBuffer ecb, Entity effectEventBufferSingleton, DamageReductionCD damageReduction, HealthCD healthCD, in TileAccessor tileLookUp, ref ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup, ref BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup)
	{
		int num = CalculateTileDamageAfterReduction(tileDamage.damage, damageReduction);
		TileCD tileCD = default(TileCD);
		if (tile.tileType.IsContainedResource())
		{
			tileLookUp.GetType(tileDamage.position, TileType.wall, out tileCD);
		}
		EffectEventCD effectEventCD = ((num <= 0) ? new EffectEventCD
		{
			effectID = EffectID.FailedHitWithSparks,
			position1 = new float3(tileDamage.position.x, 1f, tileDamage.position.y)
		} : ((healthCD.health <= num) ? new EffectEventCD
		{
			effectID = EffectID.DestroyTile,
			position1 = new float3(tileDamage.position.x, 0.5f, tileDamage.position.y),
			value1 = tileCD.tileset,
			tileInfo = new TileInfo
			{
				tileset = tile.tileset,
				tileType = tile.tileType
			}
		} : new EffectEventCD
		{
			effectID = EffectID.DamageTile,
			position1 = new float3(tileDamage.position.x, 1f, tileDamage.position.y),
			value1 = tileCD.tileset,
			tileInfo = new TileInfo
			{
				tileset = tile.tileset,
				tileType = tile.tileType
			}
		}));
		if (ghostEffectEventBufferLookup.TryGetBuffer(tileDamage.causedByEntity, out var bufferData))
		{
			DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
			ref GhostEffectEventBufferPointerCD valueRW = ref ghostEffectEventBufferPointerLookup.GetRefRW(tileDamage.causedByEntity).ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = tick,
				value = effectEventCD
			};
			buffer.AddToRingBuffer(ref valueRW, in item);
		}
		else
		{
			EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, effectEventCD);
		}
	}

	private static void PlayDamageTileFailEffect(NetworkTick tick, TileDamageBuffer tileDamage, TileCD tile, EntityCommandBuffer ecb, Entity effectEventBufferSingleton, ref ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup, ref BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup)
	{
		EffectEventCD effectEventCD = new EffectEventCD
		{
			effectID = EffectID.FailedHitWithSparks,
			position1 = new float3(tileDamage.position.x, 1f, tileDamage.position.y),
			value1 = (int)tile.tileType,
			value2 = tile.tileset
		};
		if (ghostEffectEventBufferLookup.TryGetBuffer(tileDamage.causedByEntity, out var bufferData))
		{
			DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
			ref GhostEffectEventBufferPointerCD valueRW = ref ghostEffectEventBufferPointerLookup.GetRefRW(tileDamage.causedByEntity).ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = tick,
				value = effectEventCD
			};
			buffer.AddToRingBuffer(ref valueRW, in item);
		}
		else
		{
			EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, effectEventCD);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(RemoveDamagesFromDeadTilesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__TileDamageSystem_RemoveDamagesFromDeadTilesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ApplyDamageToExistingDamageEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__TileDamageSystem_ApplyDamageToExistingDamageEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_972544419_6 = entityQueryBuilder2.Build(ref state);
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
		((TileDamageSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00004370_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00004371_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((TileDamageSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((TileDamageSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TileDamageSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TileDamageSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}

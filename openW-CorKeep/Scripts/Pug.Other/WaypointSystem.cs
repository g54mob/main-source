using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PugEntitiesUtil;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct WaypointSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(PortalCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct CheckForActivePortalsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PortalCD>();
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
			public void Run(ref CheckForActivePortalsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CheckForActivePortalsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CheckForActivePortalsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CheckForActivePortalsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CheckForActivePortalsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CheckForActivePortalsJob job, EntityManager entityManager)
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

		public NativeReference<bool> AnyPortalActive;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in ObjectDataCD objectData)
		{
			if (objectData.amount >= 600)
			{
				AnyPortalActive.Value = true;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, i));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, nextRangeBegin));
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
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, k));
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
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct ActivateWaypointJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<PortalCD> __PortalCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<CompanionInstantiatedEntityBuffer> __PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<WayPointCD> __WayPointCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
					__PortalCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PortalCD>();
					__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CompanionInstantiatedEntityBuffer>(isReadOnly: true);
					__WayPointCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WayPointCD>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ObjectDataCD_RW_ComponentTypeHandle.Update(ref state);
					__PortalCD_RW_ComponentTypeHandle.Update(ref state);
					__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle.Update(ref state);
					__WayPointCD_RO_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CompanionInstantiatedEntityBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WayPointCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PortalCD>();
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
			public void Run(ref ActivateWaypointJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ActivateWaypointJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ActivateWaypointJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ActivateWaypointJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ActivateWaypointJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ActivateWaypointJob job, EntityManager entityManager)
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

		public ComponentLookup<MapMarkerActivatedCD> MapMarkerActivatedLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> GhostEffectEventBufferPointerLookup;

		public BufferLookup<GhostEffectEventBuffer> GhostEffectEventBufferLookup;

		public float DeltaTime;

		public NetworkTick CurrentTick;

		[ReadOnly]
		public NativeReference<bool> AnyPortalActive;

		public bool ActivateAll;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(ref ObjectDataCD objectData, ref PortalCD portalCD, in DynamicBuffer<CompanionInstantiatedEntityBuffer> companionBuffer, in WayPointCD waypoint, in DistanceToPlayerCD distanceToPlayer)
		{
			bool flag = objectData.amount >= 600;
			for (int i = 0; i < companionBuffer.Length; i++)
			{
				Entity value = companionBuffer[i].Value;
				if (MapMarkerActivatedLookup.TryGetComponent(value, out var componentData) && (componentData.Hidden != !flag || componentData.Value != flag))
				{
					MapMarkerActivatedLookup[value] = new MapMarkerActivatedCD
					{
						Value = flag,
						Hidden = !flag
					};
				}
			}
			if (flag)
			{
				return;
			}
			if (waypoint.isCoreWaypoint)
			{
				if (AnyPortalActive.Value)
				{
					objectData.amount = 600;
				}
				return;
			}
			if (ActivateAll)
			{
				objectData.amount = 600;
			}
			int num = 598;
			portalCD.accumulationTimer += DeltaTime;
			if (portalCD.accumulationTimer > 1f && objectData.amount < num)
			{
				objectData.amount++;
				portalCD.accumulationTimer -= 1f;
			}
			if (distanceToPlayer.minDistanceSq > 0f && distanceToPlayer.minDistanceSq < waypoint.distanceToActivateSQ && objectData.amount >= num)
			{
				objectData.amount = 600;
				Entity closestPlayer = distanceToPlayer.closestPlayer;
				if (closestPlayer != Entity.Null && GhostEffectEventBufferLookup.HasBuffer(closestPlayer) && GhostEffectEventBufferPointerLookup.HasComponent(closestPlayer))
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = GhostEffectEventBufferLookup[closestPlayer];
					ref GhostEffectEventBufferPointerCD valueRW = ref GhostEffectEventBufferPointerLookup.GetRefRW(closestPlayer).ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = CurrentTick,
						value = new EffectEventCD
						{
							entity = closestPlayer,
							localOnlyEffect = 1,
							effectID = EffectID.Emote,
							value1 = 34
						}
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PortalCD_RW_ComponentTypeHandle);
			BufferAccessor<CompanionInstantiatedEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WayPointCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PortalCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WayPointCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PortalCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WayPointCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PortalCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WayPointCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PortalCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WayPointCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, k));
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
		public CheckForActivePortalsJob.InternalCompilerQueryAndHandleData __WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<MapMarkerActivatedCD> __MapMarkerActivatedCD_RW_ComponentLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ActivateWaypointJob.InternalCompilerQueryAndHandleData __WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__MapMarkerActivatedCD_RW_ComponentLookup = state.GetComponentLookup<MapMarkerActivatedCD>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000047F6_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000047F6_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000047F6_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnDestroy_000047F8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000047F8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000047F8_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private static bool _activateAllPortals;

	private NativeReference<bool> _anyPortalActive;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_360119563_0;

	private EntityQuery __query_360119563_1;

	public static void ActivateAllPortals()
	{
		_activateAllPortals = true;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_anyPortalActive = new NativeReference<bool>(value: false, Allocator.Persistent);
		state.RequireForUpdate(__query_360119563_0);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_anyPortalActive.Dispose();
	}

	public void OnUpdate(ref SystemState state)
	{
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		__query_360119563_1.TryGetSingleton<NetworkTime>(out var value);
		_anyPortalActive.Value = false;
		CheckForActivePortalsJob job = new CheckForActivePortalsJob
		{
			AnyPortalActive = _anyPortalActive
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		ActivateWaypointJob job2 = new ActivateWaypointJob
		{
			MapMarkerActivatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MapMarkerActivatedCD_RW_ComponentLookup, ref state),
			GhostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
			GhostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
			DeltaTime = deltaTime,
			CurrentTick = value.ServerTick,
			AnyPortalActive = _anyPortalActive,
			ActivateAll = _activateAllPortals
		};
		state.Dependency = __ScheduleViaJobChunkExtension_1(job2, __TypeHandle.__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(CheckForActivePortalsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WaypointSystem_CheckForActivePortalsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ActivateWaypointJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WaypointSystem_ActivateWaypointJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PortalCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_360119563_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_360119563_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000047F6_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((WaypointSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000047F8_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((WaypointSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WaypointSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WaypointSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}

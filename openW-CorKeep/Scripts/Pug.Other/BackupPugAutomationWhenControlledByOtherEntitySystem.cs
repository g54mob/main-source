using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Automation;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct BackupPugAutomationWhenControlledByOtherEntitySystem : ISystem, ISystemCompilerGenerated
{
	public struct PugAutomationCopyCD : IComponentData, IQueryTypeParameter
	{
		public PugAutomationCD Value;
	}

	[BurstCompile]
	[WithNone(new Type[] { typeof(PugAutomationCopyCD) })]
	[WithAll(new Type[] { typeof(ControlledByOtherEntityCD) })]
	private struct BackupPugAutomationJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugAutomationCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PugAutomationCopyCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugAutomationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ControlledByOtherEntityCD>();
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
			public void Run(ref BackupPugAutomationJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BackupPugAutomationJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BackupPugAutomationJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BackupPugAutomationJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BackupPugAutomationJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BackupPugAutomationJob job, EntityManager entityManager)
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

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in PugAutomationCD pugAutomationCD)
		{
			ecb.SetComponent(entity, new PugAutomationCopyCD
			{
				Value = pugAutomationCD
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr2, k));
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
	[WithAny(new Type[]
	{
		typeof(PugAutomationCD),
		typeof(PugAutomationCopyCD)
	})]
	private struct UpdatePugAutomationPresenceJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
					__ControlledByOtherEntityCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ControlledByOtherEntityCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref state);
					__ControlledByOtherEntityCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<PugAutomationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAny<PugAutomationCopyCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ControlledByOtherEntityCD>();
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
			public void Run(ref UpdatePugAutomationPresenceJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdatePugAutomationPresenceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdatePugAutomationPresenceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdatePugAutomationPresenceJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdatePugAutomationPresenceJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdatePugAutomationPresenceJob job, EntityManager entityManager)
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

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> disabledLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationCD> pugAutomationLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationCopyCD> pugAutomationCopyLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref AnimationOrientationCD orientation, ref ControlledByOtherEntityCD controlledByCD)
		{
			PugAutomationCopyCD componentData;
			if (UpdateControllableSystem.IsValidControllingEntity(in controlledByCD, localTransformLookup, entityDestroyedLookup, disabledLookup))
			{
				if (pugAutomationLookup.HasComponent(entity))
				{
					ecb.RemoveComponent<PugAutomationCD>(entity);
				}
			}
			else if (!pugAutomationLookup.HasComponent(entity) && pugAutomationCopyLookup.TryGetComponent(entity, out componentData))
			{
				ecb.AddComponent(entity, componentData.Value);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ControlledByOtherEntityCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr3, k));
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
		public BackupPugAutomationJob.InternalCompilerQueryAndHandleData __BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationCopyCD> __BackupPugAutomationWhenControlledByOtherEntitySystem_PugAutomationCopyCD_RO_ComponentLookup;

		public UpdatePugAutomationPresenceJob.InternalCompilerQueryAndHandleData __BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__Pug_Automation_PugAutomationCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCD>(isReadOnly: true);
			__BackupPugAutomationWhenControlledByOtherEntitySystem_PugAutomationCopyCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCopyCD>(isReadOnly: true);
			__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000003EF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000003EF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000003EF_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000003F0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000003F0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000003F0_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1621289374_0;

	private EntityQuery __query_1621289374_1;

	private EntityQuery __query_1621289374_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ControlledByOtherEntityCD>();
		NativeArray<EntityQuery> queries = new NativeArray<EntityQuery>(2, Allocator.Temp);
		queries[0] = __query_1621289374_0;
		queries[1] = __query_1621289374_1;
		state.RequireAnyForUpdate(queries);
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
		EntityQuery _query_1621289374_ = __query_1621289374_2;
		ecb.AddComponent<PugAutomationCopyCD>(_query_1621289374_, EntityQueryCaptureMode.AtPlayback);
		__ScheduleViaJobChunkExtension_0(new BackupPugAutomationJob
		{
			ecb = ecb
		}, _query_1621289374_, state.Dependency, ref state, hasUserDefinedQuery: true);
		__ScheduleViaJobChunkExtension_1(new UpdatePugAutomationPresenceJob
		{
			ecb = ecb,
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			disabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup, ref state),
			pugAutomationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentLookup, ref state),
			pugAutomationCopyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_PugAutomationCopyCD_RO_ComponentLookup, ref state)
		}, __TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		ecb.Playback(state.EntityManager);
		ecb.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(BackupPugAutomationJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_BackupPugAutomationJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_1(UpdatePugAutomationPresenceJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__BackupPugAutomationWhenControlledByOtherEntitySystem_UpdatePugAutomationPresenceJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugAutomationCD>();
		__query_1621289374_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugAutomationCopyCD>();
		__query_1621289374_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ControlledByOtherEntityCD, PugAutomationCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PugAutomationCopyCD>();
		__query_1621289374_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000003EF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000003F0_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((BackupPugAutomationWhenControlledByOtherEntitySystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BackupPugAutomationWhenControlledByOtherEntitySystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BackupPugAutomationWhenControlledByOtherEntitySystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;

namespace Interaction
{
	[BurstCompile]
	[UpdateInGroup(typeof(PerformInteractionSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct TriggerUseControllableSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAny(new Type[]
		{
			typeof(SittableCD),
			typeof(MinecartCD),
			typeof(BoatCD),
			typeof(VehicleCD)
		})]
		[WithChangeFilter(new Type[] { typeof(TriggerUseInteractionBuffer) })]
		private struct TriggerUseControllableJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public BufferTypeHandle<TriggerUseInteractionBuffer> __Interaction_TriggerUseInteractionBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Interaction_TriggerUseInteractionBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<TriggerUseInteractionBuffer>();
						__ControlledByOtherEntityCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ControlledByOtherEntityCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Interaction_TriggerUseInteractionBuffer_RW_BufferTypeHandle.Update(ref state);
						__ControlledByOtherEntityCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<SittableCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAny<MinecartCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAny<BoatCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAny<VehicleCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TriggerUseInteractionBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ControlledByOtherEntityCD>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(TriggerUseInteractionBuffer))
					});
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
				public void Run(ref TriggerUseControllableJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref TriggerUseControllableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref TriggerUseControllableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref TriggerUseControllableJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref TriggerUseControllableJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref TriggerUseControllableJob job, EntityManager entityManager)
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

			public ComponentLookup<PlayerStateCD> playerStateLookup;

			public ComponentLookup<ControllingOtherEntityCD> controllingOtherEntityLookup;

			[ReadOnly]
			public ComponentLookup<MinecartCD> minecartLookup;

			[ReadOnly]
			public ComponentLookup<BoatCD> boatLookup;

			[ReadOnly]
			public ComponentLookup<VehicleCD> vehicleLookup;

			[ReadOnly]
			public ComponentLookup<SittableCD> sittableLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, ref DynamicBuffer<TriggerUseInteractionBuffer> triggerUseInteractionBuffer, ref ControlledByOtherEntityCD controlledByOtherEntityCD)
			{
				if (controlledByOtherEntityCD.controlledByEntity != Entity.Null)
				{
					triggerUseInteractionBuffer.Clear();
					return;
				}
				int num = 0;
				if (num < triggerUseInteractionBuffer.Length)
				{
					if (sittableLookup.HasComponent(entity))
					{
						playerStateLookup.GetRefRW(triggerUseInteractionBuffer[num].interactorEntity).ValueRW.SetNextState(PlayerStateEnum.Sitting);
					}
					else if (minecartLookup.HasComponent(entity))
					{
						playerStateLookup.GetRefRW(triggerUseInteractionBuffer[num].interactorEntity).ValueRW.SetNextState(PlayerStateEnum.MinecartRiding);
					}
					else if (boatLookup.HasComponent(entity))
					{
						playerStateLookup.GetRefRW(triggerUseInteractionBuffer[num].interactorEntity).ValueRW.SetNextState(PlayerStateEnum.BoatRiding);
					}
					else if (vehicleLookup.HasComponent(entity))
					{
						playerStateLookup.GetRefRW(triggerUseInteractionBuffer[num].interactorEntity).ValueRW.SetNextState(PlayerStateEnum.VehicleRiding);
					}
					controllingOtherEntityLookup.GetRefRW(triggerUseInteractionBuffer[num].interactorEntity).ValueRW.requestToBeControlledEntity = entity;
				}
				triggerUseInteractionBuffer.Clear();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				BufferAccessor<TriggerUseInteractionBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Interaction_TriggerUseInteractionBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ControlledByOtherEntityCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						DynamicBuffer<TriggerUseInteractionBuffer> triggerUseInteractionBuffer = bufferAccessor[i];
						Execute(entity, ref triggerUseInteractionBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr2, i));
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
							DynamicBuffer<TriggerUseInteractionBuffer> triggerUseInteractionBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(entity2, ref triggerUseInteractionBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr2, nextRangeBegin));
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
						DynamicBuffer<TriggerUseInteractionBuffer> triggerUseInteractionBuffer3 = bufferAccessor[j];
						Execute(entity3, ref triggerUseInteractionBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr2, j));
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
						DynamicBuffer<TriggerUseInteractionBuffer> triggerUseInteractionBuffer4 = bufferAccessor[k];
						Execute(entity4, ref triggerUseInteractionBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControlledByOtherEntityCD>(nativeArrayPtr2, k));
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
			public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentLookup;

			public ComponentLookup<ControllingOtherEntityCD> __ControllingOtherEntityCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SittableCD> __SittableCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MinecartCD> __MinecartCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BoatCD> __BoatCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<VehicleCD> __VehicleCD_RO_ComponentLookup;

			public TriggerUseControllableJob.InternalCompilerQueryAndHandleData __Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PlayerState_PlayerStateCD_RW_ComponentLookup = state.GetComponentLookup<PlayerStateCD>();
				__ControllingOtherEntityCD_RW_ComponentLookup = state.GetComponentLookup<ControllingOtherEntityCD>();
				__SittableCD_RO_ComponentLookup = state.GetComponentLookup<SittableCD>(isReadOnly: true);
				__MinecartCD_RO_ComponentLookup = state.GetComponentLookup<MinecartCD>(isReadOnly: true);
				__BoatCD_RO_ComponentLookup = state.GetComponentLookup<BoatCD>(isReadOnly: true);
				__VehicleCD_RO_ComponentLookup = state.GetComponentLookup<VehicleCD>(isReadOnly: true);
				__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_000000E1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000000E1_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000000E1_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new TriggerUseControllableJob
			{
				playerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentLookup, ref state),
				controllingOtherEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ControllingOtherEntityCD_RW_ComponentLookup, ref state),
				sittableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SittableCD_RO_ComponentLookup, ref state),
				minecartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinecartCD_RO_ComponentLookup, ref state),
				boatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BoatCD_RO_ComponentLookup, ref state),
				vehicleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VehicleCD_RO_ComponentLookup, ref state)
			}, __TypeHandle.__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(TriggerUseControllableJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Interaction_TriggerUseControllableSystem_TriggerUseControllableJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000000E1_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((TriggerUseControllableSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((TriggerUseControllableSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

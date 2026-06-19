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
using Unity.NetCode;

namespace PlayerEquipment
{
	[BurstCompile]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct PlayerShieldingRoutineSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct ShieldJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<PlayerRoutineCD> __PlayerRoutineCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<UseOffHandStateCD> __PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentCD> __EquipmentCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PlayerRoutineCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerRoutineCD>();
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>();
						__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<UseOffHandStateCD>();
						__EquipmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PlayerRoutineCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle.Update(ref state);
						__EquipmentCD_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EquipmentCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerRoutineCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<UseOffHandStateCD>();
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
				public void Run(ref ShieldJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ShieldJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ShieldJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ShieldJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ShieldJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ShieldJob job, EntityManager entityManager)
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

			public NetworkTick currentTick;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			[ReadOnly]
			public ComponentLookup<OffHandCD> offHandLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> durabilityLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(ref PlayerRoutineCD playerRoutineCD, ref PlayerStateCD playerStateCD, ref UseOffHandStateCD useOffHandStateCD, in EquipmentCD equipmentCD, in EquippedObjectCD equippedObjectCD, in ClientInput clientInput, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer)
			{
				if (playerRoutineCD.activeRoutine == PlayerRoutines.Shielding)
				{
					ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[equipmentCD.offHandIndex];
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer2.objectID, databaseBankCD.databaseBankBlob, containedObjectsBuffer2.variation);
					if ((useOffHandStateCD.minShieldTimer.IsTimerElapsed(currentTick) && !clientInput.IsButtonStateSet(CommandInputButtonStateNames.UseOffHand_HeldDown)) || !offHandLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || componentData.mechanic != OffHandMechanic.Shield || PlayerController.ItemIsBroken(containedObjectsBuffer2.objectData, databaseBankCD.databaseBankBlob, durabilityLookup) || SpecialWeaponHandler.IsTryingToUseBeamOrDrillTool(in clientInput, in equippedObjectCD, databaseBankCD))
					{
						playerRoutineCD.activeRoutine = PlayerRoutines.Inactive;
						playerStateCD.SetNextState(PlayerStateEnum.Walk);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerRoutineCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquipmentCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, i), bufferAccessor[i]);
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, j), bufferAccessor[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, k), bufferAccessor[k]);
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
			public ComponentLookup<OffHandCD> __OffHandCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			public ShieldJob.InternalCompilerQueryAndHandleData __PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__OffHandCD_RO_ComponentLookup = state.GetComponentLookup<OffHandCD>(isReadOnly: true);
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007680_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007680_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007680_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007681_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007681_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007681_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1176430029_0;

		private EntityQuery __query_1176430029_1;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1176430029_0.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new ShieldJob
			{
				currentTick = value.ServerTick,
				databaseBankCD = __query_1176430029_1.GetSingleton<PugDatabase.DatabaseBankCD>(),
				offHandLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OffHandCD_RO_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state)
			}, __TypeHandle.__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ShieldJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_PlayerShieldingRoutineSystem_ShieldJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1176430029_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1176430029_1 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00007680_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007681_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PlayerShieldingRoutineSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerShieldingRoutineSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerShieldingRoutineSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

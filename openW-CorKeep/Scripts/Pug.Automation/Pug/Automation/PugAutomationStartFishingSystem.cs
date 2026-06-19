using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

namespace Pug.Automation
{
	[BurstCompile]
	[UpdateInGroup(typeof(PugAutomationStartCraftSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct PugAutomationStartFishingSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(FisherCD) })]
		[WithChangeFilter(new Type[] { typeof(BigEntityCraftingDataChangedTriggerCD) })]
		private struct UpdateFishingTimerJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<CrafterForSlotCD> __Pug_Automation_CrafterForSlotCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PugTimerRefCD> __PugTimerRefCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
						__Pug_Automation_CrafterForSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CrafterForSlotCD>(isReadOnly: true);
						__PugTimerRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugTimerRefCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_CrafterForSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__PugTimerRefCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BigEntityRefCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<CrafterForSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugTimerRefCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<FisherCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BigEntityCraftingDataChangedTriggerCD>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(BigEntityCraftingDataChangedTriggerCD))
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
				public void Run(ref UpdateFishingTimerJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateFishingTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateFishingTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateFishingTimerJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateFishingTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateFishingTimerJob job, EntityManager entityManager)
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
			public ComponentLookup<PugAutomationCD> pugAutomationLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

			public ComponentLookup<FishingCD> fishingLookup;

			public ComponentLookup<RandomCD> randomLookup;

			public BufferLookup<CraftingTimerSlotBuffer> craftingTimerSlotBufferLookup;

			public BufferLookup<CraftingByConsumedObjectSlotBuffer> craftingByConsumedObjectSlotBufferLookup;

			public PugTimerSystem.Timer pugTimer;

			public int simulationTickRate;

			public bool instantCraftingLocal;

			public EntityCommandBuffer ecb;

			[ReadOnly]
			public PugDatabase.DatabaseBankCD databaseBankCD;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in BigEntityRefCD bigEntityRefCD, in CrafterForSlotCD crafterForSlotCD, in PugTimerRefCD pugTimerRef)
			{
				Entity value = bigEntityRefCD.Value;
				RefRW<FishingCD> refRWOptional = fishingLookup.GetRefRWOptional(value);
				if (!refRWOptional.IsValid)
				{
					return;
				}
				ref FishingCD valueRW = ref refRWOptional.ValueRW;
				int slotIndex = crafterForSlotCD.slotIndex;
				if (!containedObjectsBufferLookup.TryGetBuffer(value, out var bufferData) || slotIndex >= bufferData.Length)
				{
					return;
				}
				bool flag = InventoryUtility.CanFish(value, slotIndex, containedObjectsBufferLookup, objectCategoryTagsLookup, databaseBankCD);
				if (!craftingTimerSlotBufferLookup.TryGetBuffer(value, out var bufferData2) || !craftingByConsumedObjectSlotBufferLookup.TryGetBuffer(value, out var bufferData3) || slotIndex >= bufferData2.Length)
				{
					return;
				}
				ref CraftingTimerSlotBuffer reference = ref bufferData2.ElementAt(slotIndex);
				ref CraftingByConsumedObjectSlotBuffer reference2 = ref bufferData3.ElementAt(slotIndex);
				ContainedObjectsBuffer containedObjectsBuffer = bufferData[slotIndex];
				bool flag2 = !reference2.previousConsumedItem.EqualsExact(containedObjectsBuffer);
				if (!flag)
				{
					reference.timeLeftToCraft = 0f;
					reference2.previousConsumedItem = default(ContainedObjectsBuffer);
				}
				else if (flag2)
				{
					float num = 0f;
					RefRW<RandomCD> refRWOptional2 = randomLookup.GetRefRWOptional(value);
					if (refRWOptional2.IsValid)
					{
						num = refRWOptional2.ValueRW.Value.NextFloat(valueRW.minMaxRandomDefaultCraftingTime.x, valueRW.minMaxRandomDefaultCraftingTime.y);
					}
					reference.timeLeftToCraft = (instantCraftingLocal ? 0f : num);
					reference2.previousConsumedItem = containedObjectsBuffer;
				}
				if (flag && pugTimerRef.entity == Entity.Null && pugAutomationLookup.TryGetComponent(value, out var componentData) && componentData.isActive)
				{
					reference2.previousConsumedItem = containedObjectsBuffer;
					pugTimer.StartTimer(ecb, entity, math.min(1f, reference.timeLeftToCraft), simulationTickRate);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_CrafterForSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugTimerRefCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CrafterForSlotCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr4, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CrafterForSlotCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr4, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CrafterForSlotCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr4, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CrafterForSlotCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr4, k));
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
			public ComponentLookup<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

			public ComponentLookup<FishingCD> __FishingCD_RW_ComponentLookup;

			public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

			public BufferLookup<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RW_BufferLookup;

			public BufferLookup<CraftingByConsumedObjectSlotBuffer> __CraftingByConsumedObjectSlotBuffer_RW_BufferLookup;

			public UpdateFishingTimerJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_PugAutomationCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCD>(isReadOnly: true);
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
				__FishingCD_RW_ComponentLookup = state.GetComponentLookup<FishingCD>();
				__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
				__CraftingTimerSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingTimerSlotBuffer>();
				__CraftingByConsumedObjectSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingByConsumedObjectSlotBuffer>();
				__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000215_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000215_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000215_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00000216_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000216_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000216_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private PugTimerSystem.Timer _pugTimer;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2125565635_0;

		private EntityQuery __query_2125565635_1;

		private EntityQuery __query_2125565635_2;

		private EntityQuery __query_2125565635_3;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<InventoryAuxDataSystemDataCD>();
			state.RequireForUpdate<UpgradeCostsTableCD>();
			state.RequireForUpdate<SkillTalentsTableCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			_pugTimer = PugTimerSystem.Timer.Create(ref state);
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_2125565635_0.TryGetSingleton<ClientServerTickRate>(out var value);
			value.ResolveDefaults();
			int simulationTickRate = value.SimulationTickRate;
			EntityCommandBuffer ecb = __query_2125565635_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_2125565635_2.TryGetSingleton<NetworkTime>(out var _);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateFishingTimerJob
			{
				pugAutomationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentLookup, ref state),
				containedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				objectCategoryTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
				fishingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FishingCD_RW_ComponentLookup, ref state),
				randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
				craftingTimerSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingTimerSlotBuffer_RW_BufferLookup, ref state),
				craftingByConsumedObjectSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingByConsumedObjectSlotBuffer_RW_BufferLookup, ref state),
				pugTimer = _pugTimer,
				instantCraftingLocal = PugAutomationCraftingSystem.InstantCrafting.Data,
				simulationTickRate = simulationTickRate,
				ecb = ecb,
				databaseBankCD = __query_2125565635_3.GetSingleton<PugDatabase.DatabaseBankCD>()
			}, __TypeHandle.__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(UpdateFishingTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationStartFishingSystem_UpdateFishingTimerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2125565635_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2125565635_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2125565635_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2125565635_3 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00000215_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000216_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugAutomationStartFishingSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationStartFishingSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationStartFishingSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

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
	[UpdateInGroup(typeof(PugAutomationFinishCraftingSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct PugAutomationIncinerateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(IsIncineratorTimerTriggerCD) })]
		private struct IncinerateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<PugTimerRefCD> __PugTimerRefCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PugTimerRefCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PugTimerRefCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PugTimerRefCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<IsIncineratorTimerTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PugTimerRefCD>();
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
				public void Run(ref IncinerateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref IncinerateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref IncinerateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref IncinerateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref IncinerateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref IncinerateJob job, EntityManager entityManager)
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
			public ComponentLookup<BigEntityRefCD> bigEntityRefLookup;

			[ReadOnly]
			public ComponentLookup<CrafterForSlotCD> crafterForSlotLookup;

			[ReadOnly]
			public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeIncineratedLookup;

			public InventoryHandlerShared inventoryHandlerShared;

			public ComponentLookup<IncineratorCD> incineratorLookup;

			public BufferLookup<CraftingTimerSlotBuffer> craftingTimerSlotBufferLookup;

			public BufferLookup<CraftingByConsumedObjectSlotBuffer> craftingByConsumedObjectSlotBufferLookup;

			public EntityCommandBuffer ecb;

			public PugTimerSystem.Timer pugTimer;

			public int simulationTickRate;

			public bool instantCraftingLocal;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref PugTimerRefCD pugTimerRef)
			{
				ecb.DestroyEntity(entity);
				Entity entity2 = pugTimerRef.entity;
				if (!bigEntityRefLookup.TryGetComponent(entity2, out var componentData))
				{
					return;
				}
				Entity value = componentData.Value;
				if (pugAutomationLookup.TryGetComponent(value, out var componentData2) && !componentData2.isActive)
				{
					return;
				}
				RefRO<CrafterForSlotCD> refROOptional = crafterForSlotLookup.GetRefROOptional(entity2);
				if (!refROOptional.IsValid)
				{
					return;
				}
				int slotIndex = refROOptional.ValueRO.slotIndex;
				if (!craftingTimerSlotBufferLookup.TryGetBuffer(value, out var bufferData) || slotIndex >= bufferData.Length)
				{
					return;
				}
				ref CraftingTimerSlotBuffer reference = ref bufferData.ElementAt(slotIndex);
				RefRW<IncineratorCD> refRWOptional = incineratorLookup.GetRefRWOptional(value);
				if (!refRWOptional.IsValid)
				{
					return;
				}
				ref IncineratorCD valueRW = ref refRWOptional.ValueRW;
				reference.timeLeftToCraft -= 1f;
				DynamicBuffer<ContainedObjectsBuffer> bufferData2;
				if (reference.timeLeftToCraft > 0f)
				{
					pugTimer.StartTimer(ecb, entity2, 1f, simulationTickRate);
				}
				else if (inventoryHandlerShared.containedObjectsBufferLookup.TryGetBuffer(value, out bufferData2) && bufferData2[slotIndex].objectID != ObjectID.None && InventoryUtility.CanIncinerate(inventoryHandlerShared.containedObjectsBufferLookup, value, slotIndex, incineratorLookup, overrideAlwaysAllowToBeIncineratedLookup, inventoryHandlerShared.databaseBankCD))
				{
					InventoryUtility.DestroyInventoryObject(in inventoryHandlerShared, value, slotIndex);
					if (InventoryUtility.CanIncinerate(inventoryHandlerShared.containedObjectsBufferLookup, value, slotIndex, incineratorLookup, overrideAlwaysAllowToBeIncineratedLookup, inventoryHandlerShared.databaseBankCD))
					{
						reference.timeLeftToCraft = (instantCraftingLocal ? 0f : valueRW.defaultIncinerationTime);
						pugTimer.StartTimer(ecb, entity2, math.min(1f, reference.timeLeftToCraft), simulationTickRate);
					}
					else
					{
						reference.timeLeftToCraft = 0f;
					}
					if (craftingByConsumedObjectSlotBufferLookup.TryGetBuffer(value, out var bufferData3))
					{
						bufferData3.ElementAt(slotIndex).previousConsumedItem = bufferData2[slotIndex];
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PugTimerRefCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr2, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr2, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugTimerRefCD>(nativeArrayPtr2, k));
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
			public ComponentLookup<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CrafterForSlotCD> __Pug_Automation_CrafterForSlotCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> __OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup;

			public ComponentLookup<IncineratorCD> __IncineratorCD_RW_ComponentLookup;

			public BufferLookup<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RW_BufferLookup;

			public BufferLookup<CraftingByConsumedObjectSlotBuffer> __CraftingByConsumedObjectSlotBuffer_RW_BufferLookup;

			public IncinerateJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_PugAutomationCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCD>(isReadOnly: true);
				__Pug_Automation_BigEntityRefCD_RO_ComponentLookup = state.GetComponentLookup<BigEntityRefCD>(isReadOnly: true);
				__Pug_Automation_CrafterForSlotCD_RO_ComponentLookup = state.GetComponentLookup<CrafterForSlotCD>(isReadOnly: true);
				__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup = state.GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
				__IncineratorCD_RW_ComponentLookup = state.GetComponentLookup<IncineratorCD>();
				__CraftingTimerSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingTimerSlotBuffer>();
				__CraftingByConsumedObjectSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingByConsumedObjectSlotBuffer>();
				__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000109_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000109_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000109_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000010A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000010A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000010A_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_0000010B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_0000010B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000010B_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private InventoryHandlerShared _inventoryHandlerShared;

		private PugTimerSystem.Timer _pugTimer;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_439729985_0;

		private EntityQuery __query_439729985_1;

		private EntityQuery __query_439729985_2;

		private EntityQuery __query_439729985_3;

		private EntityQuery __query_439729985_4;

		private EntityQuery __query_439729985_5;

		private EntityQuery __query_439729985_6;

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
		public void OnStartRunning(ref SystemState state)
		{
			_inventoryHandlerShared = new InventoryHandlerShared(ref state, __query_439729985_0.GetSingleton<PugDatabase.DatabaseBankCD>(), __query_439729985_1.GetSingleton<SkillTalentsTableCD>(), __query_439729985_2.GetSingleton<UpgradeCostsTableCD>(), __query_439729985_3.GetSingleton<InventoryAuxDataSystemDataCD>());
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_439729985_4.TryGetSingleton<ClientServerTickRate>(out var value);
			value.ResolveDefaults();
			int simulationTickRate = value.SimulationTickRate;
			EntityCommandBuffer ecb = __query_439729985_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			EntityCommandBuffer ecb2 = __query_439729985_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_439729985_6.TryGetSingleton<NetworkTime>(out var value2);
			_inventoryHandlerShared.Update(ref state, ecb, value2);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new IncinerateJob
			{
				inventoryHandlerShared = _inventoryHandlerShared,
				pugAutomationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentLookup, ref state),
				bigEntityRefLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentLookup, ref state),
				crafterForSlotLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_CrafterForSlotCD_RO_ComponentLookup, ref state),
				overrideAlwaysAllowToBeIncineratedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup, ref state),
				incineratorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IncineratorCD_RW_ComponentLookup, ref state),
				craftingTimerSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingTimerSlotBuffer_RW_BufferLookup, ref state),
				craftingByConsumedObjectSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingByConsumedObjectSlotBuffer_RW_BufferLookup, ref state),
				ecb = ecb2,
				pugTimer = _pugTimer,
				instantCraftingLocal = PugAutomationCraftingSystem.InstantCrafting.Data,
				simulationTickRate = simulationTickRate
			}, __TypeHandle.__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(IncinerateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationIncinerateSystem_IncinerateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SkillTalentsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<UpgradeCostsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_439729985_6 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00000109_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000010A_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_0000010B_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((PugAutomationIncinerateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugAutomationIncinerateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationIncinerateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationIncinerateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationIncinerateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

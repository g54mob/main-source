using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace Pug.Automation
{
	[BurstCompile]
	[UpdateInGroup(typeof(PugAutomationFinishCraftingSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct PugAutomationCraftingSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(CraftingTimerTriggerCD) })]
		private struct PugAutomationCraftJob : IJobEntity, IJobChunk
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
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CraftingTimerTriggerCD>();
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
				public void Run(ref PugAutomationCraftJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref PugAutomationCraftJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref PugAutomationCraftJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref PugAutomationCraftJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref PugAutomationCraftJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref PugAutomationCraftJob job, EntityManager entityManager)
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
			public BufferLookup<CanCraftObjectsBuffer> canCraftBufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> objectDataLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> localTransformLookup;

			public BufferLookup<CraftingByRecipeSlotBuffer> craftingWithRecipeSlotBufferLookup;

			public BufferLookup<CraftingTimerSlotBuffer> craftingTimerSlotBufferLookup;

			public InventoryHandlerShared inventoryHandlerShared;

			public EntityCommandBuffer ecb;

			public PugDatabase.DatabaseBankCD databaseBankCD;

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
				if (!craftingTimerSlotBufferLookup.TryGetBuffer(value, out var bufferData) || !craftingWithRecipeSlotBufferLookup.TryGetBuffer(value, out var bufferData2) || slotIndex >= bufferData.Length)
				{
					return;
				}
				ref CraftingTimerSlotBuffer reference = ref bufferData.ElementAt(slotIndex);
				ref CraftingByRecipeSlotBuffer reference2 = ref bufferData2.ElementAt(slotIndex);
				if (!inventoryHandlerShared.craftingLookup.TryGetComponent(value, out var _))
				{
					return;
				}
				reference.timeLeftToCraft -= 1f;
				if (reference.timeLeftToCraft > 0f)
				{
					pugTimer.StartTimer(ecb, entity2, 1f, simulationTickRate);
					return;
				}
				DynamicBuffer<CanCraftObjectsBuffer> dynamicBuffer = canCraftBufferLookup[value];
				if (reference2.currentlyCraftingIndex < 0 || reference2.currentlyCraftingIndex >= dynamicBuffer.Length)
				{
					return;
				}
				CanCraftObjectsBuffer objectToCraft = dynamicBuffer[reference2.currentlyCraftingIndex];
				ObjectDataCD mainEntityObjectData = objectDataLookup[value];
				using NativeList<Entity> inventoryEntities = new NativeList<Entity>(Allocator.Temp);
				inventoryEntities.Add(in value);
				localTransformLookup.TryGetComponent(value, out var componentData4);
				InventoryUtility.Craft(in inventoryHandlerShared, value, mainEntityObjectData, inventoryEntities, objectToCraft, 0, componentData4.Position, useCraftingCostMultiplier: false);
				if (InventoryUtility.CanCraft(in inventoryHandlerShared, value, mainEntityObjectData, inventoryEntities, objectToCraft))
				{
					reference.timeLeftToCraft = (instantCraftingLocal ? 0f : PugDatabase.GetEntityObjectInfo(objectToCraft.objectID, databaseBankCD.databaseBankBlob).craftingTime);
					if (objectToCraft.craftingTimeOverride > 0f)
					{
						reference.timeLeftToCraft = objectToCraft.craftingTimeOverride;
					}
					pugTimer.StartTimer(ecb, entity2, math.min(1f, reference.timeLeftToCraft), simulationTickRate);
				}
				else
				{
					reference.timeLeftToCraft = 0f;
					reference2.currentlyCraftingIndex = -1;
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

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct InstantCraftingKey
		{
		}

		[CommandPrefix("crafting.")]
		private static class Crafting
		{
			[Preserve]
			[Conditional("UNITY_EDITOR")]
			[Conditional("FORCE_DEBUG_MODE")]
			[Conditional("PUG_MARKETING_BUILD")]
			[Conditional("PUG_USE_STEAM")]
			[Conditional("UNITY_MICROSOFT_PC")]
			[Conditional("UNITY_EPIC")]
			[Command("toggleInstantCrafting", "Toggles instant crafting.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
			public static void ToggleInstantCrafting()
			{
				InstantCrafting.Data = !InstantCrafting.Data;
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
			public BufferLookup<CanCraftObjectsBuffer> __CanCraftObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			public BufferLookup<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RW_BufferLookup;

			public BufferLookup<CraftingByRecipeSlotBuffer> __CraftingByRecipeSlotBuffer_RW_BufferLookup;

			public PugAutomationCraftJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_PugAutomationCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCD>(isReadOnly: true);
				__Pug_Automation_BigEntityRefCD_RO_ComponentLookup = state.GetComponentLookup<BigEntityRefCD>(isReadOnly: true);
				__Pug_Automation_CrafterForSlotCD_RO_ComponentLookup = state.GetComponentLookup<CrafterForSlotCD>(isReadOnly: true);
				__CanCraftObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<CanCraftObjectsBuffer>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__CraftingTimerSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingTimerSlotBuffer>();
				__CraftingByRecipeSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingByRecipeSlotBuffer>();
				__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000003A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000003A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000003A_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000003B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000003B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000003B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_0000003C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_0000003C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000003C_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		public static readonly SharedStatic<bool> InstantCrafting = SharedStatic<bool>.GetOrCreateUnsafe(0u, -8387164020008362270L, 0L);

		private InventoryHandlerShared _inventoryHandlerShared;

		private PugTimerSystem.Timer _pugTimer;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1888205699_0;

		private EntityQuery __query_1888205699_1;

		private EntityQuery __query_1888205699_2;

		private EntityQuery __query_1888205699_3;

		private EntityQuery __query_1888205699_4;

		private EntityQuery __query_1888205699_5;

		private EntityQuery __query_1888205699_6;

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
			_inventoryHandlerShared = new InventoryHandlerShared(ref state, __query_1888205699_0.GetSingleton<PugDatabase.DatabaseBankCD>(), __query_1888205699_1.GetSingleton<SkillTalentsTableCD>(), __query_1888205699_2.GetSingleton<UpgradeCostsTableCD>(), __query_1888205699_3.GetSingleton<InventoryAuxDataSystemDataCD>());
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1888205699_4.TryGetSingleton<ClientServerTickRate>(out var value);
			value.ResolveDefaults();
			int simulationTickRate = value.SimulationTickRate;
			EntityCommandBuffer ecb = __query_1888205699_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			EntityCommandBuffer ecb2 = __query_1888205699_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_1888205699_6.TryGetSingleton<NetworkTime>(out var value2);
			_inventoryHandlerShared.Update(ref state, ecb, value2);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new PugAutomationCraftJob
			{
				pugAutomationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentLookup, ref state),
				bigEntityRefLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentLookup, ref state),
				crafterForSlotLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_CrafterForSlotCD_RO_ComponentLookup, ref state),
				canCraftBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CanCraftObjectsBuffer_RO_BufferLookup, ref state),
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				craftingTimerSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingTimerSlotBuffer_RW_BufferLookup, ref state),
				craftingWithRecipeSlotBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingByRecipeSlotBuffer_RW_BufferLookup, ref state),
				inventoryHandlerShared = _inventoryHandlerShared,
				ecb = ecb2,
				databaseBankCD = __query_1888205699_0.GetSingleton<PugDatabase.DatabaseBankCD>(),
				pugTimer = _pugTimer,
				instantCraftingLocal = InstantCrafting.Data,
				simulationTickRate = simulationTickRate
			}, __TypeHandle.__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(PugAutomationCraftJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationCraftingSystem_PugAutomationCraftJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SkillTalentsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<UpgradeCostsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1888205699_6 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000003A_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000003B_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_0000003C_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((PugAutomationCraftingSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugAutomationCraftingSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationCraftingSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationCraftingSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationCraftingSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

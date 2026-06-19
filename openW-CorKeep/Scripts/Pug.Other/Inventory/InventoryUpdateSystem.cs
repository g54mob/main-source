using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using UnityEngine;

namespace Inventory
{
	[BurstCompile]
	[UpdateInGroup(typeof(InventorySystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct InventoryUpdateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InventoryInitialized : IComponentData, IQueryTypeParameter
		{
		}

		[BurstCompile]
		private struct ClearInventoryChangesOnPartialTickJob : IJob
		{
			public Entity inventoryChangeBufferEntity;

			public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

			public void Execute()
			{
				inventoryChangeBufferLookup[inventoryChangeBufferEntity].Clear();
			}
		}

		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(InventoryBuffer),
			typeof(ContainedObjectsBuffer)
		})]
		[WithNone(new Type[] { typeof(InventoryInitialized) })]
		private struct InitializeInventoryJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InventoryInitialized>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<InventoryBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
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
				public void Run(ref InitializeInventoryJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref InitializeInventoryJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref InitializeInventoryJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref InitializeInventoryJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref InitializeInventoryJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref InitializeInventoryJob job, EntityManager entityManager)
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

			public InventoryHandlerShared inventoryHandlerShared;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity)
			{
				inventoryHandlerShared.ecb.AddComponent<InventoryInitialized>(entity);
				UpdateInventorySpace(in inventoryHandlerShared, entity, force: true);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity);
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
							Execute(entity2);
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
						Execute(entity3);
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
						Execute(entity4);
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
		private struct ProcessInventoryChangesJob : IJob
		{
			public Entity inventoryChangeBufferEntity;

			public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

			public BufferLookup<InventoryChangeResultBuffer> inventoryChangeResultBufferLookup;

			[ReadOnly]
			public ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup;

			public bool worldIsReadOnly;

			public bool isCreativeMode;

			public NativeParallelHashSet<Entity> pickedUpObjects;

			public InventoryHandlerShared inventoryHandlerShared;

			[ReadOnly]
			public CollisionWorld collisionWorld;

			public void Execute()
			{
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = inventoryChangeBufferLookup[inventoryChangeBufferEntity];
				DynamicBuffer<InventoryChangeResultBuffer> dynamicBuffer2 = inventoryChangeResultBufferLookup[inventoryChangeBufferEntity];
				dynamicBuffer2.Resize(dynamicBuffer.Length, NativeArrayOptions.ClearMemory);
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					InventoryChangeBuffer inventoryChange = dynamicBuffer[i];
					if (!worldIsReadOnly || !inventoryHandlerShared.playerGhostLookup.TryGetComponent(inventoryChange.playerEntity, out var componentData) || componentData.adminPrivileges > 0 || inventoryChange.inventoryChangeData.inventoryAction == InventoryAction.MoveOrDropItemIgnoreGuestMode)
					{
						bool inventoryChangeSuccessful = ProcessInventoryChange(inventoryChange.inventoryChangeData, in inventoryHandlerShared, isCreativeMode, pickedUpObjects, in collisionWorld, inventoryAutoTransferEnabledLookup);
						dynamicBuffer2[i] = new InventoryChangeResultBuffer
						{
							inventoryChangeSuccessful = inventoryChangeSuccessful
						};
						if (!inventoryHandlerShared.isServer)
						{
							MarkInventoriesInteracted(inventoryChange, inventoryHandlerShared.currentTick, inventoryHandlerShared.moveToPredictedByCombatInteractionLookup);
						}
					}
				}
				dynamicBuffer.Clear();
			}
		}

		[BurstCompile]
		private struct ProcessCraftingJob : IJob
		{
			public Entity craftBufferEntity;

			public BufferLookup<CraftBuffer> craftBufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> objectDataLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> localTransformLookup;

			[ReadOnly]
			public ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup;

			[ReadOnly]
			public CollisionWorld collisionWorld;

			public bool worldIsReadOnly;

			public InventoryHandlerShared inventoryHandlerShared;

			public void Execute()
			{
				DynamicBuffer<CraftBuffer> dynamicBuffer = craftBufferLookup[craftBufferEntity];
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					CraftBuffer craftActionData = dynamicBuffer[i];
					if (worldIsReadOnly && inventoryHandlerShared.playerGhostLookup.TryGetComponent(craftActionData.playerEntity, out var componentData) && componentData.adminPrivileges <= 0)
					{
						continue;
					}
					CraftActionData craftActionData2 = craftActionData.craftActionData;
					objectDataLookup.TryGetComponent(craftActionData2.mainInventoryEntity, out var componentData2);
					localTransformLookup.TryGetComponent(craftActionData2.mainInventoryEntity, out var componentData3);
					float3 position = componentData3.Position;
					NativeList<Entity> inventories = new NativeList<Entity>(Allocator.Temp);
					if (craftActionData2.mainInventoryEntity != Entity.Null)
					{
						inventories.Add(in craftActionData2.mainInventoryEntity);
					}
					if (localTransformLookup.TryGetComponent(craftActionData2.craftingEntity, out var componentData4))
					{
						InventoryUtility.GetNearbyChestsForCraftingByDistance(in componentData4.Position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories);
					}
					if (inventories.Length == 0 || inventories[0] == Entity.Null)
					{
						UnityEngine.Debug.LogError("Craft got null inventory, are you sure it has a GhostComponent?");
						continue;
					}
					switch (craftActionData2.craftAction)
					{
					case CraftAction.Craft:
						InventoryUtility.Craft(in inventoryHandlerShared, inventories[0], componentData2, inventories, new CanCraftObjectsBuffer
						{
							objectID = craftActionData2.objectId,
							amount = craftActionData2.amount
						}, craftActionData2.additionalFreeAmount, position, useCraftingCostMultiplier: true, craftActionData2.playerEntity, craftActionData2.craftingEntity);
						break;
					case CraftAction.CraftParchmentRecipe:
						InventoryUtility.CraftParchmentRecipe(in inventoryHandlerShared, inventories[0], craftActionData2.objectId, craftActionData2.int0, craftActionData2.int1);
						break;
					case CraftAction.Upgrade:
						InventoryUtility.Upgrade(in inventoryHandlerShared, craftActionData2.targetInventoryEntity, craftActionData2.int0, craftActionData2.objectId, inventories, craftActionData2.int1, craftActionData2.bool0);
						break;
					case CraftAction.RepairOrReinforce:
					{
						Entity playerEntity = craftActionData2.playerEntity;
						Entity targetInventoryEntity = craftActionData2.targetInventoryEntity;
						InventoryUtility.RepairOrReinforce(in inventoryHandlerShared, targetInventoryEntity, craftActionData2.int0, craftActionData2.objectId, inventories, craftActionData2.int1, craftActionData2.craftingEntity, playerEntity, craftActionData2.bool0, craftActionData2.bool1);
						break;
					}
					case CraftAction.SetupCookBookRecipe:
						InventoryUtility.SetupCookBookRecipe(in inventoryHandlerShared, craftActionData2.craftingEntity, craftActionData2.playerEntity, craftActionData2.targetInventoryEntity, craftActionData2.bool0, inventories, craftActionData2.objectId, craftActionData2.int0);
						break;
					case CraftAction.ActivateRecipeSlot:
						InventoryUtility.ActivateRecipeSlot(in inventoryHandlerShared, craftActionData2.craftingEntity, craftActionData2.playerEntity, inventories, craftActionData2.int0, craftActionData2.bool0, craftActionData2.int1);
						break;
					case CraftAction.RepairOrReinforceAllItems:
						InventoryUtility.RepairAllItems(in inventoryHandlerShared, craftActionData2.targetInventoryEntity, inventories, craftActionData2.craftingEntity, craftActionData2.playerEntity, craftActionData2.bool0);
						break;
					default:
						UnityEngine.Debug.LogError($"Action not implemented: {craftActionData2.craftAction}");
						break;
					}
					if (!inventoryHandlerShared.isServer)
					{
						MarkInventoriesInteracted(craftActionData, inventories, inventoryHandlerShared.currentTick, inventoryHandlerShared.moveToPredictedByCombatInteractionLookup);
					}
				}
				dynamicBuffer.Clear();
			}
		}

		private struct TypeHandle
		{
			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public InitializeInventoryJob.InternalCompilerQueryAndHandleData __Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle;

			public BufferLookup<InventoryChangeResultBuffer> __Inventory_InventoryChangeResultBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<InventoryAutoTransferEnabledCD> __InventoryAutoTransferEnabledCD_RO_ComponentLookup;

			public BufferLookup<CraftBuffer> __Inventory_CraftBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Inventory_InventoryChangeResultBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeResultBuffer>();
				__InventoryAutoTransferEnabledCD_RO_ComponentLookup = state.GetComponentLookup<InventoryAutoTransferEnabledCD>(isReadOnly: true);
				__Inventory_CraftBuffer_RW_BufferLookup = state.GetBufferLookup<CraftBuffer>();
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_000072EE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000072EE_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000072EE_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_000072EF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_000072EF_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000072EF_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnStopRunning_000072F0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_000072F0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000072F0_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
				__codegen__OnStopRunning_0024BurstManaged(self, state);
			}
		}

		private InventoryHandlerShared _inventoryHandlerShared;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1799965905_0;

		private EntityQuery __query_1799965905_1;

		private EntityQuery __query_1799965905_2;

		private EntityQuery __query_1799965905_3;

		private EntityQuery __query_1799965905_4;

		private EntityQuery __query_1799965905_5;

		private EntityQuery __query_1799965905_6;

		private EntityQuery __query_1799965905_7;

		private EntityQuery __query_1799965905_8;

		private EntityQuery __query_1799965905_9;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<CraftBuffer>();
			state.RequireForUpdate<InventoryChangeBuffer>();
			state.RequireForUpdate<InventoryAuxDataSystemDataCD>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			Entity entity = state.EntityManager.CreateEntity();
			state.EntityManager.AddBuffer<InventoryChangeBuffer>(entity);
			state.EntityManager.AddBuffer<CraftBuffer>(entity);
			state.EntityManager.AddBuffer<InventoryChangeResultBuffer>(entity);
			state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			_inventoryHandlerShared = new InventoryHandlerShared(ref state, __query_1799965905_0.GetSingleton<PugDatabase.DatabaseBankCD>(), __query_1799965905_1.GetSingleton<SkillTalentsTableCD>(), __query_1799965905_2.GetSingleton<UpgradeCostsTableCD>(), __query_1799965905_3.GetSingleton<InventoryAuxDataSystemDataCD>());
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1799965905_4.TryGetSingleton<NetworkTime>(out var value);
			if (value.IsPartialTick)
			{
				state.Dependency = IJobExtensions.Schedule(new ClearInventoryChangesOnPartialTickJob
				{
					inventoryChangeBufferEntity = __query_1799965905_5.GetSingletonEntity(),
					inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state)
				}, state.Dependency);
				return;
			}
			EntityCommandBuffer ecb = __query_1799965905_6.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			NativeParallelHashSet<Entity> pickedUpObjects = new NativeParallelHashSet<Entity>(4, state.WorldUpdateAllocator);
			_inventoryHandlerShared.Update(ref state, ecb, value);
			InventoryHandlerShared inventoryHandlerShared = _inventoryHandlerShared;
			state.Dependency = __ScheduleViaJobChunkExtension_0(new InitializeInventoryJob
			{
				inventoryHandlerShared = inventoryHandlerShared
			}, __TypeHandle.__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = IJobExtensions.Schedule(new ProcessInventoryChangesJob
			{
				inventoryChangeBufferEntity = __query_1799965905_5.GetSingletonEntity(),
				inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				inventoryChangeResultBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeResultBuffer_RW_BufferLookup, ref state),
				inventoryAutoTransferEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InventoryAutoTransferEnabledCD_RO_ComponentLookup, ref state),
				worldIsReadOnly = __query_1799965905_7.GetSingleton<WorldInfoCD>().guestMode,
				isCreativeMode = __query_1799965905_7.GetSingleton<WorldInfoCD>().IsWorldModeEnabled(WorldMode.Creative),
				pickedUpObjects = pickedUpObjects,
				inventoryHandlerShared = inventoryHandlerShared,
				collisionWorld = __query_1799965905_8.GetSingleton<PhysicsWorldSingleton>().CollisionWorld
			}, state.Dependency);
			state.Dependency = IJobExtensions.Schedule(new ProcessCraftingJob
			{
				craftBufferEntity = __query_1799965905_9.GetSingletonEntity(),
				craftBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_CraftBuffer_RW_BufferLookup, ref state),
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				inventoryAutoTransferEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InventoryAutoTransferEnabledCD_RO_ComponentLookup, ref state),
				collisionWorld = __query_1799965905_8.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				worldIsReadOnly = __query_1799965905_7.GetSingleton<WorldInfoCD>().guestMode,
				inventoryHandlerShared = inventoryHandlerShared
			}, state.Dependency);
		}

		private static ExtraInventoryCD GetExtraInventorySpace(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, InventoryBuffer inventory)
		{
			int extraInventorySizeSlot = inventory.extraInventorySizeSlot;
			if (extraInventorySizeSlot < 0)
			{
				return default(ExtraInventoryCD);
			}
			ObjectDataCD objectData = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity][extraInventorySizeSlot].objectData;
			if (objectData.objectID == ObjectID.None)
			{
				return default(ExtraInventoryCD);
			}
			Entity levelEntity = EntityUtility.GetLevelEntity(PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, objectData.variation), objectData, inventoryHandlerShared.levelEntitiesBufferLookup, inventoryHandlerShared.levelLookup);
			if (!inventoryHandlerShared.extraInventorySizeLookup.TryGetComponent(levelEntity, out var componentData))
			{
				return default(ExtraInventoryCD);
			}
			return componentData;
		}

		private static void UpdateInventorySpace(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, bool force = false)
		{
			if (!inventoryHandlerShared.inventoryLookup.TryGetBuffer(inventoryEntity, out var bufferData))
			{
				return;
			}
			for (int i = 0; i < bufferData.Length; i++)
			{
				InventoryBuffer inventory = bufferData[i];
				ExtraInventoryCD extraInventorySpace = GetExtraInventorySpace(in inventoryHandlerShared, inventoryEntity, inventory);
				bool flag = inventory.extraInventoryCategoryTagsMask != extraInventorySpace.categoryTagsMask;
				if (force || inventory.extraSize != extraInventorySpace.size || flag)
				{
					float3 position = inventoryHandlerShared.localTransformLookup[inventoryEntity].Position;
					InventoryUtility.UpdateInventoryRequirements(in inventoryHandlerShared, inventoryEntity, extraInventorySpace, i);
					bufferData[i] = InventoryUtility.UpdateInventorySize(in inventoryHandlerShared, inventoryEntity, extraInventorySpace, position, bufferData[i], i, flag);
				}
			}
		}

		private static bool ProcessInventoryChange(InventoryChangeData rpc, in InventoryHandlerShared inventoryHandlerShared, bool isCreativeMode, NativeParallelHashSet<Entity> pickedUpObjects, in CollisionWorld collisionWorld, ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup)
		{
			if (rpc.inventory1 == Entity.Null)
			{
				UnityEngine.Debug.LogError("Got null inventory, are you sure it has a GhostComponent?");
				return false;
			}
			if (!inventoryHandlerShared.vendingMachineLookup.HasComponent(rpc.inventory1) && (!inventoryHandlerShared.inventoryLookup.HasComponent(rpc.inventory1) || !inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(rpc.inventory1)))
			{
				return false;
			}
			switch (rpc.inventoryAction)
			{
			case InventoryAction.MoveAmount:
			case InventoryAction.MoveOrDropItem:
			case InventoryAction.MoveOrDropAllItems:
			case InventoryAction.MoveOrDropAmount:
			case InventoryAction.Swap:
			case InventoryAction.QuickStack:
			case InventoryAction.MoveInventory:
			case InventoryAction.MoveOrDropItemIgnoreGuestMode:
				if (!inventoryHandlerShared.inventoryLookup.HasComponent(rpc.entityOrInventory2) || !inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(rpc.entityOrInventory2))
				{
					return false;
				}
				break;
			}
			if (rpc.inventoryAction == InventoryAction.MoveAllOrDropThenTryMove && (!inventoryHandlerShared.inventoryLookup.HasComponent(rpc.entityOrInventory3) || !inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(rpc.entityOrInventory3)))
			{
				return false;
			}
			bool result = true;
			switch (rpc.inventoryAction)
			{
			case InventoryAction.ConsumeObjectType:
				InventoryUtility.ConsumeObject(in inventoryHandlerShared, rpc.inventory1, (ObjectID)rpc.index1, rpc.amount);
				break;
			case InventoryAction.ConsumeEntityAt:
				if (rpc.bool2)
				{
					if (!rpc.bool1)
					{
						InventoryUtility.CreateEntityWithoutConsume(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.amount, rpc.position1, rpc.index2, rpc.position2, (ObjectID)rpc.index3);
					}
				}
				else
				{
					result = InventoryUtility.ConsumeEntityAt(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.amount, rpc.bool1, rpc.position1, rpc.index2, rpc.position2, (ObjectID)rpc.index3);
				}
				break;
			case InventoryAction.CreateObject:
				InventoryUtility.CreateObject(in inventoryHandlerShared, rpc.inventory1, rpc.index1, (ObjectID)rpc.index2, rpc.amount, rpc.position1, rpc.variation);
				break;
			case InventoryAction.AddAmount:
				InventoryUtility.AddAmount(in inventoryHandlerShared, rpc.inventory1, rpc.index1, (ObjectID)rpc.index2, rpc.amount);
				break;
			case InventoryAction.SetAmount:
				InventoryUtility.SetAmount(in inventoryHandlerShared, rpc.inventory1, rpc.index1, (ObjectID)rpc.index2, rpc.amount);
				break;
			case InventoryAction.SetVariation:
				InventoryUtility.SetVariation(in inventoryHandlerShared, rpc.inventory1, rpc.index1, (ObjectID)rpc.index2, rpc.variation);
				break;
			case InventoryAction.Swap:
				InventoryUtility.Swap(in inventoryHandlerShared, rpc.inventory1, rpc.entityOrInventory2, rpc.index1, rpc.index2);
				break;
			case InventoryAction.DropItem:
				InventoryUtility.DropItem(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.amount, rpc.position1, rpc.entityOrInventory2);
				break;
			case InventoryAction.MoveAmount:
				InventoryUtility.MoveAmount(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3, rpc.amount, rpc.bool1);
				break;
			case InventoryAction.MoveOrDropAmount:
				InventoryUtility.MoveOrDrop(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3, rpc.amount, rpc.position1);
				break;
			case InventoryAction.DropAllItemsAt:
				InventoryUtility.DropItem(in inventoryHandlerShared, rpc.inventory1, rpc.index1, int.MaxValue, rpc.position1, rpc.entityOrInventory2);
				break;
			case InventoryAction.MoveOrDropAllItems:
				InventoryUtility.MoveOrDropAllItems(in inventoryHandlerShared, rpc.inventory1, rpc.entityOrInventory2, rpc.index2, rpc.index3, rpc.position1);
				break;
			case InventoryAction.MoveOrDropItem:
			case InventoryAction.MoveOrDropItemIgnoreGuestMode:
				InventoryUtility.MoveOrDrop(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3, int.MaxValue, rpc.position1);
				break;
			case InventoryAction.MoveOrDropItems:
				InventoryUtility.MoveOrDropItems(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.index2, rpc.entityOrInventory2, rpc.index3, rpc.index4, rpc.position1);
				break;
			case InventoryAction.MoveAllOrDropThenTryMove:
				InventoryUtility.MoveOrDrop(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3, int.MaxValue, rpc.position1);
				InventoryUtility.MoveAmount(in inventoryHandlerShared, rpc.entityOrInventory3, rpc.index4, rpc.inventory1, rpc.index1, -1, rpc.amount);
				break;
			case InventoryAction.DropAllItems:
				InventoryUtility.DropAllItems(in inventoryHandlerShared, rpc.inventory1, rpc.position1, rpc.entityOrInventory2, rpc.bool1);
				break;
			case InventoryAction.Destroy:
				InventoryUtility.DestroyInventoryObject(in inventoryHandlerShared, rpc.inventory1, (ObjectID)rpc.index2, rpc.index1);
				break;
			case InventoryAction.DestroyItems:
			{
				for (int i = rpc.index1; i <= rpc.index2; i++)
				{
					InventoryUtility.DestroyInventoryObject(in inventoryHandlerShared, rpc.inventory1, i);
				}
				break;
			}
			case InventoryAction.Sell:
				InventoryUtility.SellObject(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3, rpc.objectID, rpc.amount, rpc.variation, rpc.position1);
				break;
			case InventoryAction.QuickStack:
				InventoryUtility.QuickStack(in inventoryHandlerShared, rpc.inventory1, rpc.entityOrInventory2);
				break;
			case InventoryAction.Sort:
				InventoryUtility.Sort(in inventoryHandlerShared, rpc.inventory1, rpc.bool1);
				break;
			case InventoryAction.MoveInventory:
				InventoryUtility.MoveInventory(in inventoryHandlerShared, rpc.inventory1, rpc.entityOrInventory2, rpc.index1, rpc.index2, rpc.index3);
				break;
			case InventoryAction.PickUpObject:
				InventoryUtility.PickUpObject(in inventoryHandlerShared, rpc.entityOrInventory2, rpc.index1, rpc.inventory1, rpc.position1, pickedUpObjects);
				break;
			case InventoryAction.SetName:
			{
				NameCD data2 = new NameCD
				{
					Value = rpc.string1
				};
				int auxDataIndex2 = InventoryUtility.GetAuxDataIndex(inventoryHandlerShared.containedObjectsBufferLookup, rpc.inventory1, rpc.index1, rpc.objectID);
				if (auxDataIndex2 == 0)
				{
					UnityEngine.Debug.LogWarning("recreating corrupt auxiliary data for inventory object (no name)");
					Entity e = inventoryHandlerShared.ecb.CreateEntity();
					inventoryHandlerShared.ecb.AddComponent(e, new PetInitializeAuxDataCD
					{
						EntityContainingPet = rpc.inventory1
					});
					inventoryHandlerShared.ecb.AddComponent<BlockSaveCD>(e);
				}
				else
				{
					inventoryHandlerShared.inventoryAuxDataSystemDataCD.GetAccessor().SetComponentData(auxDataIndex2, inventoryHandlerShared.ecb, data2);
					InventoryUtility.SetAuxDataIndex(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.objectID, auxDataIndex2);
				}
				break;
			}
			case InventoryAction.SetPetSkin:
			{
				PetSkinCD data = new PetSkinCD
				{
					skinIndex = rpc.index2
				};
				int auxDataIndex = InventoryUtility.GetAuxDataIndex(inventoryHandlerShared.containedObjectsBufferLookup, rpc.inventory1, rpc.index1, rpc.objectID);
				inventoryHandlerShared.inventoryAuxDataSystemDataCD.GetAccessor().SetComponentData(auxDataIndex, inventoryHandlerShared.ecb, data);
				InventoryUtility.SetAuxDataIndex(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.objectID, auxDataIndex);
				break;
			}
			case InventoryAction.SetPetTalentPoints:
				InventoryUtility.SetPetTalentPoints(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.objectID, rpc.index2, rpc.amount);
				break;
			case InventoryAction.ResetPetTalentTree:
				InventoryUtility.ResetPetTalentTree(in inventoryHandlerShared, rpc.inventory1, rpc.bool1);
				break;
			case InventoryAction.Buy:
				InventoryUtility.Buy(in inventoryHandlerShared, rpc.inventory1, rpc.index1, rpc.entityOrInventory2, rpc.index2, rpc.index3);
				break;
			case InventoryAction.ResetSkillTalentTree:
				InventoryUtility.ResetSkillTalentTree(in inventoryHandlerShared, rpc.inventory1, (SkillID)rpc.index1, rpc.bool1);
				break;
			case InventoryAction.SalvageAll:
				InventoryUtility.SalvageAll(in inventoryHandlerShared, rpc.inventory1, rpc.entityOrInventory2, rpc.position1, rpc.index1, rpc.index2);
				break;
			case InventoryAction.SellAll:
				InventoryUtility.SellAll(in inventoryHandlerShared, rpc.index1, rpc.index2, rpc.position1, rpc.inventory1);
				break;
			case InventoryAction.TryReplaceBrokenObject:
				InventoryUtility.TryReplaceBrokenObject(in inventoryHandlerShared, rpc.inventory1, rpc.index1);
				break;
			case InventoryAction.ToggleLock:
				InventoryUtility.ToggleLock(in inventoryHandlerShared, rpc.inventory1, rpc.index1);
				break;
			case InventoryAction.QuickStackToNearbyChests:
			{
				if (!inventoryHandlerShared.localTransformLookup.TryGetComponent(rpc.inventory1, out var componentData))
				{
					return false;
				}
				NativeList<Entity> nearbyChestsForAutoStackingByDistance = InventoryUtility.GetNearbyChestsForAutoStackingByDistance(componentData.Position, collisionWorld, inventoryAutoTransferEnabledLookup, inventoryHandlerShared.localTransformLookup, Allocator.Temp);
				if (nearbyChestsForAutoStackingByDistance.Length == 0)
				{
					nearbyChestsForAutoStackingByDistance.Dispose();
					return false;
				}
				InventoryUtility.QuickStackToNearbyChests(in inventoryHandlerShared, rpc.inventory1, nearbyChestsForAutoStackingByDistance);
				nearbyChestsForAutoStackingByDistance.Dispose();
				break;
			}
			case InventoryAction.AddFilter:
				InventoryUtility.AddFilter(in inventoryHandlerShared, rpc.inventory1, rpc.objectID, rpc.variation);
				break;
			case InventoryAction.SetAllItemsInInventoryToLevel:
				InventoryUtility.UpgradeAllItemsInInventory(in inventoryHandlerShared, rpc.inventory1, rpc.index1);
				break;
			default:
				UnityEngine.Debug.LogError($"command not implemented: {rpc.inventoryAction}");
				break;
			case InventoryAction.ClaimInventory:
				break;
			}
			UpdateInventorySpace(in inventoryHandlerShared, rpc.inventory1);
			switch (rpc.inventoryAction)
			{
			case InventoryAction.MoveAmount:
			case InventoryAction.MoveOrDropItem:
			case InventoryAction.MoveOrDropAllItems:
			case InventoryAction.MoveOrDropAmount:
			case InventoryAction.Swap:
			case InventoryAction.QuickStack:
			case InventoryAction.MoveInventory:
			case InventoryAction.MoveOrDropItemIgnoreGuestMode:
				UpdateInventorySpace(in inventoryHandlerShared, rpc.entityOrInventory2);
				break;
			}
			if (rpc.inventoryAction == InventoryAction.MoveAllOrDropThenTryMove)
			{
				UpdateInventorySpace(in inventoryHandlerShared, rpc.entityOrInventory3);
			}
			return result;
		}

		private static void MarkInventoriesInteracted(InventoryChangeBuffer inventoryChange, NetworkTick currentTick, ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup)
		{
			TryMarkInventoryInteracted(inventoryChange.inventoryChangeData.inventory1, currentTick, moveToPredictedByCombatInteractionLookup);
			TryMarkInventoryInteracted(inventoryChange.inventoryChangeData.entityOrInventory2, currentTick, moveToPredictedByCombatInteractionLookup);
			TryMarkInventoryInteracted(inventoryChange.inventoryChangeData.entityOrInventory3, currentTick, moveToPredictedByCombatInteractionLookup);
		}

		private static void MarkInventoriesInteracted(CraftBuffer craftActionData, NativeList<Entity> inventories, NetworkTick currentTick, ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup)
		{
			TryMarkInventoryInteracted(craftActionData.craftActionData.targetInventoryEntity, currentTick, moveToPredictedByCombatInteractionLookup);
			TryMarkInventoryInteracted(craftActionData.craftActionData.craftingEntity, currentTick, moveToPredictedByCombatInteractionLookup);
			for (int i = 0; i < inventories.Length; i++)
			{
				TryMarkInventoryInteracted(inventories[i], currentTick, moveToPredictedByCombatInteractionLookup);
			}
		}

		private static void TryMarkInventoryInteracted(Entity inventory, NetworkTick currentTick, ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup)
		{
			if (moveToPredictedByCombatInteractionLookup.HasComponent(inventory))
			{
				moveToPredictedByCombatInteractionLookup.GetRefRW(inventory).ValueRW.SetLastInteractionTick(currentTick);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(InitializeInventoryJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Inventory_InventoryUpdateSystem_InitializeInventoryJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SkillTalentsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<UpgradeCostsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CraftBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799965905_9 = entityQueryBuilder2.Build(ref state);
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
			((InventoryUpdateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000072EE_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_000072EF_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_000072F0_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((InventoryUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((InventoryUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((InventoryUpdateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((InventoryUpdateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

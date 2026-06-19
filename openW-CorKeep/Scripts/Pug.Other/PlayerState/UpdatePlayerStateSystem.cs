using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using Pug.Properties;
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

namespace PlayerState
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(PlayerStateSystemGroup))]
	public struct UpdatePlayerStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct UpdateStateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public StateUpdateAspect.TypeHandle __PlayerState_StateUpdateAspect_RW_AspectTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PlayerState_StateUpdateAspect_RW_AspectTypeHandle = new StateUpdateAspect.TypeHandle(ref state);
					}

					public void Update(ref SystemState state)
					{
						__PlayerState_StateUpdateAspect_RW_AspectTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAspect<StateUpdateAspect>();
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
				public void Run(ref UpdateStateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateStateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateStateJob job, EntityManager entityManager)
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

			public LookupStateUpdateData lookupStateUpdateData;

			public SharedStateUpdateData sharedStateUpdateData;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(StateUpdateAspect stateUpdateAspect)
			{
				PlayerStateCD valueRO = stateUpdateAspect.playerStateCD.ValueRO;
				UpdateState(valueRO.level1State, ref stateUpdateAspect, ref sharedStateUpdateData, ref lookupStateUpdateData);
				if (valueRO.level2State != PlayerStateEnum.Null)
				{
					UpdateState(valueRO.level2State, ref stateUpdateAspect, ref sharedStateUpdateData, ref lookupStateUpdateData);
				}
				if (valueRO.level3State != PlayerStateEnum.Null)
				{
					UpdateState(valueRO.level3State, ref stateUpdateAspect, ref sharedStateUpdateData, ref lookupStateUpdateData);
				}
			}

			private static void UpdateState(PlayerStateEnum currentState, ref StateUpdateAspect stateUpdateAspect, ref SharedStateUpdateData sharedStateUpdateData, ref LookupStateUpdateData lookupStateUpdateData)
			{
				switch (currentState)
				{
				case PlayerStateEnum.SpawningFromCore:
					SpawningFromCore.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Walk:
					Walk.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Release:
					Release.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Anticipation:
					Anticipation.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.NoClip:
					NoClip.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Death:
					Death.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.PlaceObject:
					PlaceObject.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Dig:
					Dig.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Flatten:
					Flatten.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.RefillWater:
					RefillWater.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.PlaceWater:
					PlaceWater.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Sleep:
					Sleep.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Casting:
					Casting.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.MinecartRiding:
					MinecartRiding.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Fishing:
					Fishing.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.BoatRiding:
					BoatRiding.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.VehicleRiding:
					VehicleRiding.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Teleporting:
					Teleporting.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.Sitting:
					Sitting.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.PlayingInstrument:
					PlayingInstrument.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				case PlayerStateEnum.UseOffHand:
					UseOffHand.UpdateState(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					break;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				StateUpdateAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerState_StateUpdateAspect_RW_AspectTypeHandle.Resolve(chunk);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						StateUpdateAspect stateUpdateAspect = resolvedChunk[i];
						Execute(stateUpdateAspect);
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
							StateUpdateAspect stateUpdateAspect2 = resolvedChunk[nextRangeBegin];
							Execute(stateUpdateAspect2);
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
						StateUpdateAspect stateUpdateAspect3 = resolvedChunk[j];
						Execute(stateUpdateAspect3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						StateUpdateAspect stateUpdateAspect4 = resolvedChunk[k];
						Execute(stateUpdateAspect4);
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
			public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EnemyActAsDestructibleCD> __EnemyActAsDestructibleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoveFreelyWeaponCD> __MoveFreelyWeaponCD_RO_ComponentLookup;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ParchmentRecipeCD> __ParchmentRecipeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ScannerCD> __ScannerCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SpawnsItemsOnUseCD> __SpawnsItemsOnUseCD_RO_ComponentLookup;

			public ComponentLookup<LeashedCD> __LeashedCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OccupiableCD> __OccupiableCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OffHandCD> __OffHandCD_RO_ComponentLookup;

			public ComponentLookup<OctopusBossCD> __OctopusBossCD_RW_ComponentLookup;

			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SittableCD> __SittableCD_RO_ComponentLookup;

			public ComponentLookup<MinecartCD> __MinecartCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<VehicleCD> __VehicleCD_RO_ComponentLookup;

			public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public BufferLookup<CraftBuffer> __Inventory_CraftBuffer_RW_BufferLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public BufferLookup<InventoryBuffer> __InventoryBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<AnvilCD> __AnvilCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BreedToggleCD> __BreedToggleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<NameCD> __NameCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MealsEatenCD> __MealsEatenCD_RO_ComponentLookup;

			public ComponentLookup<WaitingForCastingOpenItemResultCD> __WaitingForCastingOpenItemResultCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			public ComponentLookup<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			public ComponentLookup<WaitingForConsumedBaitResultCD> __WaitingForConsumedBaitResultCD_RW_ComponentLookup;

			public ComponentLookup<DelayedFishLootCD> __DelayedFishLootCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BoatCD> __BoatCD_RO_ComponentLookup;

			public UpdateStateJob.InternalCompilerQueryAndHandleData __PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
				__EnemyActAsDestructibleCD_RO_ComponentLookup = state.GetComponentLookup<EnemyActAsDestructibleCD>(isReadOnly: true);
				__MoveFreelyWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MoveFreelyWeaponCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
				__ParchmentRecipeCD_RO_ComponentLookup = state.GetComponentLookup<ParchmentRecipeCD>(isReadOnly: true);
				__ScannerCD_RO_ComponentLookup = state.GetComponentLookup<ScannerCD>(isReadOnly: true);
				__SpawnsItemsOnUseCD_RO_ComponentLookup = state.GetComponentLookup<SpawnsItemsOnUseCD>(isReadOnly: true);
				__LeashedCD_RW_ComponentLookup = state.GetComponentLookup<LeashedCD>();
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__OccupiableCD_RO_ComponentLookup = state.GetComponentLookup<OccupiableCD>(isReadOnly: true);
				__OffHandCD_RO_ComponentLookup = state.GetComponentLookup<OffHandCD>(isReadOnly: true);
				__OctopusBossCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossCD>();
				__ObjectDataCD_RW_ComponentLookup = state.GetComponentLookup<ObjectDataCD>();
				__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
				__SittableCD_RO_ComponentLookup = state.GetComponentLookup<SittableCD>(isReadOnly: true);
				__MinecartCD_RW_ComponentLookup = state.GetComponentLookup<MinecartCD>();
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__VehicleCD_RO_ComponentLookup = state.GetComponentLookup<VehicleCD>(isReadOnly: true);
				__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__Inventory_CraftBuffer_RW_BufferLookup = state.GetBufferLookup<CraftBuffer>();
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__InventoryBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
				__AnvilCD_RO_ComponentLookup = state.GetComponentLookup<AnvilCD>(isReadOnly: true);
				__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
				__BreedToggleCD_RO_ComponentLookup = state.GetComponentLookup<BreedToggleCD>(isReadOnly: true);
				__NameCD_RO_ComponentLookup = state.GetComponentLookup<NameCD>(isReadOnly: true);
				__MealsEatenCD_RO_ComponentLookup = state.GetComponentLookup<MealsEatenCD>(isReadOnly: true);
				__WaitingForCastingOpenItemResultCD_RW_ComponentLookup = state.GetComponentLookup<WaitingForCastingOpenItemResultCD>();
				__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__ControlledByOtherEntityCD_RW_ComponentLookup = state.GetComponentLookup<ControlledByOtherEntityCD>();
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__WaitingForConsumedBaitResultCD_RW_ComponentLookup = state.GetComponentLookup<WaitingForConsumedBaitResultCD>();
				__DelayedFishLootCD_RW_ComponentLookup = state.GetComponentLookup<DelayedFishLootCD>();
				__BoatCD_RO_ComponentLookup = state.GetComponentLookup<BoatCD>(isReadOnly: true);
				__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_000071C9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_000071C9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000071C9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_000071CA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000071CA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000071CA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_000071CB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_000071CB_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000071CB_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private float3 _playerSpawnPosition;

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_725416147_0;

		private EntityQuery __query_725416147_1;

		private EntityQuery __query_725416147_2;

		private EntityQuery __query_725416147_3;

		private EntityQuery __query_725416147_4;

		private EntityQuery __query_725416147_5;

		private EntityQuery __query_725416147_6;

		private EntityQuery __query_725416147_7;

		private EntityQuery __query_725416147_8;

		private EntityQuery __query_725416147_9;

		private EntityQuery __query_725416147_10;

		private EntityQuery __query_725416147_11;

		private EntityQuery __query_725416147_12;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PhysicsWorldHistorySingleton>();
			state.RequireForUpdate<LootTableBankCD>();
			state.RequireForUpdate<FishingTableCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<ConditionsTableCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			_playerSpawnPosition = PlayerControllerBurstableStatics.PLAYER_SPAWN_POSITION;
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
			_tileAccessor.Update(ref state);
			EntityCommandBuffer ecb = __query_725416147_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			if (!__query_725416147_2.TryGetSingleton<ClientServerTickRate>(out var value))
			{
				value.ResolveDefaults();
			}
			JobHandle outJobHandle;
			NativeList<Entity> octopusBosses = __query_725416147_0.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
			state.Dependency = JobHandle.CombineDependencies(state.Dependency, outJobHandle);
			__query_725416147_3.TryGetSingleton<NetworkTime>(out var value2);
			UpdateStateJob job = new UpdateStateJob
			{
				lookupStateUpdateData = new LookupStateUpdateData
				{
					enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
					enemyActAsDestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyActAsDestructibleCD_RO_ComponentLookup, ref state),
					moveFreelyWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveFreelyWeaponCD_RO_ComponentLookup, ref state),
					localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
					disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
					parchmentRecipeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ParchmentRecipeCD_RO_ComponentLookup, ref state),
					scannerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScannerCD_RO_ComponentLookup, ref state),
					spawnsItemsOnUseLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnsItemsOnUseCD_RO_ComponentLookup, ref state),
					leashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LeashedCD_RW_ComponentLookup, ref state),
					summarizedConditionsLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
					directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
					occupiableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OccupiableCD_RO_ComponentLookup, ref state),
					offHandLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OffHandCD_RO_ComponentLookup, ref state),
					octopusBossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossCD_RW_ComponentLookup, ref state),
					objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RW_ComponentLookup, ref state),
					summarizedConditionEffectsLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
					entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
					sittableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SittableCD_RO_ComponentLookup, ref state),
					minecartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinecartCD_RW_ComponentLookup, ref state),
					simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
					vehicleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VehicleCD_RO_ComponentLookup, ref state),
					randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
					inventoryChangeBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
					craftBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_CraftBuffer_RW_BufferLookup, ref state),
					containedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
					inventoryBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
					anvilLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnvilCD_RO_ComponentLookup, ref state),
					cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
					breedToggleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BreedToggleCD_RO_ComponentLookup, ref state),
					nameLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__NameCD_RO_ComponentLookup, ref state),
					mealsEatenLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MealsEatenCD_RO_ComponentLookup, ref state),
					waitingForCastingOpenItemResultLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaitingForCastingOpenItemResultCD_RW_ComponentLookup, ref state),
					godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
					objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
					controlledByOtherEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ControlledByOtherEntityCD_RW_ComponentLookup, ref state),
					levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
					waitingForConsumedBaitResultLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaitingForConsumedBaitResultCD_RW_ComponentLookup, ref state),
					delayedFishingLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DelayedFishLootCD_RW_ComponentLookup, ref state),
					boatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BoatCD_RO_ComponentLookup, ref state)
				},
				sharedStateUpdateData = new SharedStateUpdateData
				{
					physicsWorld = __query_725416147_4.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
					physicsWorldHistory = __query_725416147_5.GetSingleton<PhysicsWorldHistorySingleton>(),
					currentTick = value2.ServerTick,
					pugDatabaseBank = __query_725416147_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
					ecb = ecb,
					conditionsTableCD = __query_725416147_7.GetSingleton<ConditionsTableCD>(),
					playerSpawnPosition = _playerSpawnPosition,
					deltaTime = state.WorldUnmanaged.Time.DeltaTime,
					tickRate = (uint)value.SimulationTickRate,
					isServer = state.WorldUnmanaged.IsServer(),
					tileAccessor = _tileAccessor,
					octopusBosses = octopusBosses,
					fishingTableCD = __query_725416147_8.GetSingleton<FishingTableCD>(),
					lootTableBank = __query_725416147_9.GetSingleton<LootTableBankCD>(),
					isFirstTimeFullyPredictingTick = value2.IsFirstTimeFullyPredictingTick,
					inventoryChangeBufferEntity = __query_725416147_10.GetSingletonEntity(),
					craftBufferEntity = __query_725416147_11.GetSingletonEntity(),
					InventoryAuxDataSystemData = __query_725416147_12.GetSingleton<InventoryAuxDataSystemDataCD>(),
					isFinalFullPredictionTick = value2.IsFinalFullPredictionTick,
					isPartialTick = value2.IsPartialTick
				}
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ref UpdateStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerState_UpdatePlayerStateSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<OctopusBossCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
			__query_725416147_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<FishingTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<LootTableBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_9 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_10 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CraftBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_11 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_725416147_12 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_000071C9_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000071CA_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_000071CB_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

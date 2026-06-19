using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommandMinion;
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

namespace PlayerEquipment
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(EquipmentAfterUpdateSystemGroup))]
	public struct AttackWithEquipmentSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(AttackWithEquipmentTag),
			typeof(Simulate)
		})]
		private struct AttackJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public AttackWithEquipmentAspect.TypeHandle __PlayerEquipment_AttackWithEquipmentAspect_RW_AspectTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerRoutineCD> __PlayerRoutineCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PlayerEquipment_AttackWithEquipmentAspect_RW_AspectTypeHandle = new AttackWithEquipmentAspect.TypeHandle(ref state);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlayerRoutineCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerRoutineCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PlayerEquipment_AttackWithEquipmentAspect_RW_AspectTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlayerRoutineCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerRoutineCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AttackWithEquipmentTag>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAspect<AttackWithEquipmentAspect>();
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
				public void Run(ref AttackJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref AttackJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref AttackJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref AttackJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref AttackJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref AttackJob job, EntityManager entityManager)
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

			public AttackWithEquipmentShared attackWithEquipmentShared;

			public AttackWithEquipmentLookup attackWithEquipmentLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(AttackWithEquipmentAspect attackWithEquipmentAspect, in ClientInput clientInput, in PlayerRoutineCD playerRoutineCD)
			{
				attackWithEquipmentLookup.attackWithEquipmentLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: false);
				if (playerRoutineCD.activeRoutine != PlayerRoutines.Inactive && playerRoutineCD.activeRoutine != PlayerRoutines.Shielding)
				{
					return;
				}
				Entity equipmentPrefab = attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab;
				ref EquipmentSlotCD valueRW = ref attackWithEquipmentAspect.equipmentSlotCD.ValueRW;
				if (valueRW.currentWindup > 0f && attackWithEquipmentLookup.secondaryUseLookup.TryGetComponent(equipmentPrefab, out var componentData) && valueRW.currentWindupTier < componentData.cancelAttackIfNotAtWindupTier)
				{
					valueRW.windupCanceled = true;
					return;
				}
				valueRW.windupCanceled = false;
				bool flag = valueRW.slotType == EquipmentSlotType.MeleeWeaponSlot;
				bool flag2 = valueRW.slotType == EquipmentSlotType.RangeWeaponSlot;
				bool flag3 = valueRW.slotType == EquipmentSlotType.BeamWeaponSlot;
				bool flag4 = valueRW.slotType == EquipmentSlotType.SummoningWeaponSlot;
				if ((!flag && !flag2 && !flag3 && !flag4) || attackWithEquipmentAspect.equippedObjectCD.ValueRO.isBroken)
				{
					EquipmentSlot.AttackWithItem(in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
				}
				else if (flag)
				{
					MeleeWeaponSlot.AttackWithItem(in clientInput, in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
				}
				else if (flag2)
				{
					RangeWeaponSlot.AttackWithItem(in clientInput, in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
				}
				else if (flag3)
				{
					BeamWeaponSlot.AttackWithItem(in clientInput, in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
				}
				else if (flag4)
				{
					SummoningWeaponSlot.AttackWithItem(in clientInput, in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				AttackWithEquipmentAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerEquipment_AttackWithEquipmentAspect_RW_AspectTypeHandle.Resolve(chunk);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerRoutineCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						AttackWithEquipmentAspect attackWithEquipmentAspect = resolvedChunk[i];
						Execute(attackWithEquipmentAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, i));
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
							AttackWithEquipmentAspect attackWithEquipmentAspect2 = resolvedChunk[nextRangeBegin];
							Execute(attackWithEquipmentAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, nextRangeBegin));
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
						AttackWithEquipmentAspect attackWithEquipmentAspect3 = resolvedChunk[j];
						Execute(attackWithEquipmentAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						AttackWithEquipmentAspect attackWithEquipmentAspect4 = resolvedChunk[k];
						Execute(attackWithEquipmentAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, k));
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
			public ComponentLookup<CooldownCD> __CooldownCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WarmupCD> __WarmupCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MeleeWeaponCD> __MeleeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HasWeaponDamageCD> __HasWeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<RangeWeaponCD> __RangeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SecondaryUseCD> __SecondaryUseCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ConsumesManaCD> __ConsumesManaCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CommandMinionWeaponCD> __CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> __PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup;

			public ComponentLookup<QueueHitTriggerCD> __QueueHitTriggerCD_RW_ComponentLookup;

			public ComponentLookup<AttackWithEquipmentTag> __PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

			public ComponentLookup<RangedWeaponSpawnProjectileTriggerTag> __PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentLookup;

			public ComponentLookup<BeamWeaponSpawnProjectileTriggerTag> __PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentLookup;

			public AttackJob.InternalCompilerQueryAndHandleData __PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__CooldownCD_RO_ComponentLookup = state.GetComponentLookup<CooldownCD>(isReadOnly: true);
				__WarmupCD_RO_ComponentLookup = state.GetComponentLookup<WarmupCD>(isReadOnly: true);
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__MeleeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MeleeWeaponCD>(isReadOnly: true);
				__HasWeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<HasWeaponDamageCD>(isReadOnly: true);
				__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__RangeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<RangeWeaponCD>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__SecondaryUseCD_RO_ComponentLookup = state.GetComponentLookup<SecondaryUseCD>(isReadOnly: true);
				__ConsumesManaCD_RO_ComponentLookup = state.GetComponentLookup<ConsumesManaCD>(isReadOnly: true);
				__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
				__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
				__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup = state.GetComponentLookup<CommandMinionWeaponCD>(isReadOnly: true);
				__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
				__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup = state.GetComponentLookup<AffectObjectWhenMelodyPlayedCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup = state.GetComponentLookup<ReduceDurabilityOfEquippedTriggerCD>();
				__QueueHitTriggerCD_RW_ComponentLookup = state.GetComponentLookup<QueueHitTriggerCD>();
				__PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup = state.GetComponentLookup<AttackWithEquipmentTag>();
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
				__PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentLookup = state.GetComponentLookup<RangedWeaponSpawnProjectileTriggerTag>();
				__PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentLookup = state.GetComponentLookup<BeamWeaponSpawnProjectileTriggerTag>();
				__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_000073CF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000073CF_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000073CF_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_000073D0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_000073D0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000073D0_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnStartRunning_000073D1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_000073D1_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000073D1_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private uint _tickRate;

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1510366475_0;

		private EntityQuery __query_1510366475_1;

		private EntityQuery __query_1510366475_2;

		private EntityQuery __query_1510366475_3;

		private EntityQuery __query_1510366475_4;

		private EntityQuery __query_1510366475_5;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
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
			EntityCommandBuffer ecb = __query_1510366475_0.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_1510366475_1.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new AttackJob
			{
				attackWithEquipmentShared = new AttackWithEquipmentShared
				{
					currentTick = value.ServerTick,
					tickRate = _tickRate,
					databaseBank = __query_1510366475_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
					ecb = ecb,
					isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
					conditionsTableCD = __query_1510366475_3.GetSingleton<ConditionsTableCD>(),
					inventoryChangeBufferEntity = __query_1510366475_4.GetSingletonEntity(),
					collisionWorld = __query_1510366475_5.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
					tileAccessor = _tileAccessor
				},
				attackWithEquipmentLookup = new AttackWithEquipmentLookup
				{
					cooldownLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CooldownCD_RO_ComponentLookup, ref state),
					warmupLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WarmupCD_RO_ComponentLookup, ref state),
					durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
					meleeWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeWeaponCD_RO_ComponentLookup, ref state),
					hasWeaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasWeaponDamageCD_RO_ComponentLookup, ref state),
					summarizedConditionEffectBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
					summarizedConditionsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
					rangedWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeWeaponCD_RO_ComponentLookup, ref state),
					levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
					levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
					secondaryUseLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SecondaryUseCD_RO_ComponentLookup, ref state),
					consumesManaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConsumesManaCD_RO_ComponentLookup, ref state),
					healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
					godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
					commandMinionWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup, ref state),
					doorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
					affectObjectWhenMelodyPlayedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup, ref state),
					objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
					reduceDurabilityOfEquippedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup, ref state),
					queueHitLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__QueueHitTriggerCD_RW_ComponentLookup, ref state),
					attackWithEquipmentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup, ref state),
					inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
					randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
					rangedWeaponSpawnProjectileTriggerTagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentLookup, ref state),
					beamWeaponSpawnProjectileTriggerTagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentLookup, ref state)
				}
			}, __TypeHandle.__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(AttackJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_AttackWithEquipmentSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1510366475_5 = entityQueryBuilder2.Build(ref state);
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
			((AttackWithEquipmentSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000073CF_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_000073D0_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_000073D1_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((AttackWithEquipmentSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((AttackWithEquipmentSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((AttackWithEquipmentSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((AttackWithEquipmentSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((AttackWithEquipmentSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

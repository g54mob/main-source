using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlacementIndicator;
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

namespace PlayerEquipment
{
	[BurstCompile]
	[UpdateBefore(typeof(EquipmentLateUpdateSystem))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct RangeWeaponSpawnProjectileSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(Simulate) })]
		[WithChangeFilter(new Type[] { typeof(RangedWeaponSpawnProjectileTriggerTag) })]
		private struct RangedWeaponSpawnProjectileJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<GhostOwner> __Unity_NetCode_GhostOwner_RO_ComponentTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlacementIndicatorCD> __PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<RangedWeaponSpawnProjectileTriggerTag> __PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostOwner>(isReadOnly: true);
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlacementIndicatorCD>(isReadOnly: true);
						__PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangedWeaponSpawnProjectileTriggerTag>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostOwner>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicatorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangedWeaponSpawnProjectileTriggerTag>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(RangedWeaponSpawnProjectileTriggerTag))
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
				public void Run(ref RangedWeaponSpawnProjectileJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RangedWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RangedWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RangedWeaponSpawnProjectileJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RangedWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RangedWeaponSpawnProjectileJob job, EntityManager entityManager)
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

			public SpawnProjectilesHelpData attackWithEquipmentHelpData;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in ClientInput clientInput, in EquipmentSlotCD equipmentSlotCD, in EquippedObjectCD equippedObjectCD, in LocalTransform localTransform, in GhostOwner ghostOwner, ref RandomCD randomCD, in PlacementIndicatorCD placementIndicatorCD, EnabledRefRW<RangedWeaponSpawnProjectileTriggerTag> rangedWeaponSpawnProjectileTriggerTagEnabled)
			{
				rangedWeaponSpawnProjectileTriggerTagEnabled.ValueRW = false;
				Entity equipmentPrefab = equippedObjectCD.equipmentPrefab;
				if (!attackWithEquipmentHelpData.rangedWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData))
				{
					return;
				}
				int num = 10;
				if (attackWithEquipmentHelpData.hasWeaponDamageLookup.HasComponent(equipmentPrefab))
				{
					bool isReinforced = false;
					if (attackWithEquipmentHelpData.durabilityLookup.TryGetComponent(equipmentPrefab, out var componentData2))
					{
						isReinforced = componentData2.IsReinforced(equippedObjectCD.containedObject.objectData.amount);
					}
					Entity levelEntity = EntityUtility.GetLevelEntity(equipmentPrefab, equippedObjectCD.containedObject.objectData, attackWithEquipmentHelpData.levelEntitiesBufferLookup, attackWithEquipmentHelpData.levelLookup);
					if (levelEntity != Entity.Null)
					{
						attackWithEquipmentHelpData.weaponDamageLookup.TryGetComponent(levelEntity, out var componentData3);
						num = componentData3.GetDamage(isReinforced);
					}
				}
				int num2 = ((!equipmentSlotCD.secondaryUse.hasSecondaryUse) ? componentData.extraProjectiles : ((componentData.extraProjectiles > 0) ? ((int)math.floor(equipmentSlotCD.currentWindup * (float)componentData.extraProjectiles)) : 0));
				int totalShots = 1 + num2;
				if (componentData.extraProjectiles == 0)
				{
					float end = equipmentSlotCD.secondaryUse.windupTime * equipmentSlotCD.secondaryUse.extraDamageMultiplier;
					num = (int)math.round((float)num * math.lerp(1f, end, equipmentSlotCD.currentWindup));
				}
				ObjectDataCD objectData = equippedObjectCD.containedObject.objectData;
				RangeWeaponSlot.SpawnProjectiles(entity, in attackWithEquipmentHelpData, totalShots, in componentData, in clientInput, equipmentPrefab, in objectData, num, in equipmentSlotCD, ref randomCD, in localTransform, in ghostOwner, in placementIndicatorCD);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle);
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__PlayerEquipment_RangedWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, i), enabledMask.GetEnabledRefRW<RangedWeaponSpawnProjectileTriggerTag>(i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, nextRangeBegin), enabledMask.GetEnabledRefRW<RangedWeaponSpawnProjectileTriggerTag>(nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, j), enabledMask.GetEnabledRefRW<RangedWeaponSpawnProjectileTriggerTag>(j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, k), enabledMask.GetEnabledRefRW<RangedWeaponSpawnProjectileTriggerTag>(k));
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

		[WithAll(new Type[] { typeof(Simulate) })]
		[WithChangeFilter(new Type[] { typeof(BeamWeaponSpawnProjectileTriggerTag) })]
		private struct BeamWeaponSpawnProjectileJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<GhostOwner> __Unity_NetCode_GhostOwner_RO_ComponentTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlacementIndicatorCD> __PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<BeamWeaponSpawnProjectileTriggerTag> __PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostOwner>(isReadOnly: true);
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlacementIndicatorCD>(isReadOnly: true);
						__PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BeamWeaponSpawnProjectileTriggerTag>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostOwner>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicatorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamWeaponSpawnProjectileTriggerTag>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(BeamWeaponSpawnProjectileTriggerTag))
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
				public void Run(ref BeamWeaponSpawnProjectileJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref BeamWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref BeamWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref BeamWeaponSpawnProjectileJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref BeamWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref BeamWeaponSpawnProjectileJob job, EntityManager entityManager)
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

			public SpawnProjectilesHelpData attackWithEquipmentHelpData;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in ClientInput clientInput, in EquipmentSlotCD equipmentSlotCD, in EquippedObjectCD equippedObjectCD, in LocalTransform localTransform, in GhostOwner ghostOwner, ref RandomCD randomCD, in PlacementIndicatorCD placementIndicatorCD, EnabledRefRW<BeamWeaponSpawnProjectileTriggerTag> beamWeaponSpawnProjectileTriggerTagEnabled)
			{
				beamWeaponSpawnProjectileTriggerTagEnabled.ValueRW = false;
				Entity equipmentPrefab = equippedObjectCD.equipmentPrefab;
				if (!attackWithEquipmentHelpData.beamWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData))
				{
					return;
				}
				int num = 10;
				if (attackWithEquipmentHelpData.hasWeaponDamageLookup.HasComponent(equipmentPrefab))
				{
					bool isReinforced = false;
					if (attackWithEquipmentHelpData.durabilityLookup.TryGetComponent(equipmentPrefab, out var componentData2))
					{
						isReinforced = componentData2.IsReinforced(equippedObjectCD.containedObject.objectData.amount);
					}
					Entity levelEntity = EntityUtility.GetLevelEntity(equipmentPrefab, equippedObjectCD.containedObject.objectData, attackWithEquipmentHelpData.levelEntitiesBufferLookup, attackWithEquipmentHelpData.levelLookup);
					if (levelEntity != Entity.Null)
					{
						attackWithEquipmentHelpData.weaponDamageLookup.TryGetComponent(levelEntity, out var componentData3);
						num = componentData3.GetDamage(isReinforced);
					}
				}
				int num2 = ((!equipmentSlotCD.secondaryUse.hasSecondaryUse) ? componentData.extraProjectiles : ((componentData.extraProjectiles > 0) ? ((int)math.floor(equipmentSlotCD.currentWindup * (float)componentData.extraProjectiles)) : 0));
				int totalShots = 1 + num2;
				if (componentData.extraProjectiles == 0)
				{
					float end = equipmentSlotCD.secondaryUse.windupTime * equipmentSlotCD.secondaryUse.extraDamageMultiplier;
					num = (int)math.round((float)num * math.lerp(1f, end, equipmentSlotCD.currentWindup));
				}
				ObjectDataCD objectData = equippedObjectCD.containedObject.objectData;
				BeamWeaponSlot.SpawnProjectiles(entity, in attackWithEquipmentHelpData, totalShots, in componentData, in clientInput, equipmentPrefab, in objectData, num, in equipmentSlotCD, ref randomCD, in localTransform, in ghostOwner);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostOwner_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle);
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__PlayerEquipment_BeamWeaponSpawnProjectileTriggerTag_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, i), enabledMask.GetEnabledRefRW<BeamWeaponSpawnProjectileTriggerTag>(i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, nextRangeBegin), enabledMask.GetEnabledRefRW<BeamWeaponSpawnProjectileTriggerTag>(nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, j), enabledMask.GetEnabledRefRW<BeamWeaponSpawnProjectileTriggerTag>(j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostOwner>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr8, k), enabledMask.GetEnabledRefRW<BeamWeaponSpawnProjectileTriggerTag>(k));
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
			public ComponentLookup<RangeWeaponCD> __RangeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> __BeamWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HasWeaponDamageCD> __HasWeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<WeaponDamageCD> __WeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MortarProjectileDamageEffectCD> __MortarProjectileDamageEffectCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<IsExplosiveCD> __IsExplosiveCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PiercingProjectileCD> __PiercingProjectileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BouncingProjectileCD> __BouncingProjectileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RW_BufferLookup;

			public RangedWeaponSpawnProjectileJob.InternalCompilerQueryAndHandleData __PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle;

			public BeamWeaponSpawnProjectileJob.InternalCompilerQueryAndHandleData __PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__RangeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<RangeWeaponCD>(isReadOnly: true);
				__BeamWeaponCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
				__HasWeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<HasWeaponDamageCD>(isReadOnly: true);
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__WeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<WeaponDamageCD>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__MortarProjectileCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
				__MortarProjectileDamageEffectCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(isReadOnly: true);
				__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
				__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
				__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__IsExplosiveCD_RO_ComponentLookup = state.GetComponentLookup<IsExplosiveCD>(isReadOnly: true);
				__PiercingProjectileCD_RO_ComponentLookup = state.GetComponentLookup<PiercingProjectileCD>(isReadOnly: true);
				__BouncingProjectileCD_RO_ComponentLookup = state.GetComponentLookup<BouncingProjectileCD>(isReadOnly: true);
				__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
				__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup = state.GetComponentLookup<AffectObjectWhenMelodyPlayedCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__ConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<ConditionsBuffer>();
				__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_000076F9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_000076F9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000076F9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_000076FA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000076FA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000076FA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_000076FB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_000076FB_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000076FB_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
		internal delegate void __codegen__OnStopRunning_000076FC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_000076FC_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000076FC_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_954459550_0;

		private EntityQuery __query_954459550_1;

		private EntityQuery __query_954459550_2;

		private EntityQuery __query_954459550_3;

		private EntityQuery __query_954459550_4;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<ConditionsTableCD>();
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_954459550_0.TryGetSingleton<NetworkTime>(out var value);
			_tileAccessor.Update(ref state);
			SpawnProjectilesHelpData attackWithEquipmentHelpData = new SpawnProjectilesHelpData
			{
				rangedWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeWeaponCD_RO_ComponentLookup, ref state),
				beamWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamWeaponCD_RO_ComponentLookup, ref state),
				hasWeaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasWeaponDamageCD_RO_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
				levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
				weaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WeaponDamageCD_RO_ComponentLookup, ref state),
				levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
				mortarProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileCD_RO_ComponentLookup, ref state),
				mortarProjectileDamageEffectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileDamageEffectCD_RO_ComponentLookup, ref state),
				behaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				movementSpeedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
				summarizedConditionsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
				isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RO_ComponentLookup, ref state),
				piercingProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PiercingProjectileCD_RO_ComponentLookup, ref state),
				bouncingProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BouncingProjectileCD_RO_ComponentLookup, ref state),
				doorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
				affectObjectWhenMelodyPlayedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup, ref state),
				objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
				conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
				conditionsTableCD = __query_954459550_1.GetSingleton<ConditionsTableCD>(),
				databaseBankCD = __query_954459550_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
				collisionWorld = __query_954459550_3.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				ecb = __query_954459550_4.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged),
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
				tileAccessor = _tileAccessor
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RangedWeaponSpawnProjectileJob
			{
				attackWithEquipmentHelpData = attackWithEquipmentHelpData
			}, __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new BeamWeaponSpawnProjectileJob
			{
				attackWithEquipmentHelpData = attackWithEquipmentHelpData
			}, __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(RangedWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_RangedWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(BeamWeaponSpawnProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_RangeWeaponSpawnProjectileSystem_BeamWeaponSpawnProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_954459550_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_954459550_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_954459550_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_954459550_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_954459550_4 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_000076F9_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000076FA_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_000076FB_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_000076FC_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((RangeWeaponSpawnProjectileSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RangeWeaponSpawnProjectileSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RangeWeaponSpawnProjectileSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RangeWeaponSpawnProjectileSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RangeWeaponSpawnProjectileSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

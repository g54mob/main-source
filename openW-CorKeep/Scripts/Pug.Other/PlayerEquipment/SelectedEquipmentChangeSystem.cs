using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommandMinion;
using PlayerState;
using Pug.Properties;
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
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(EquipmentBeforeUpdateSystemGroup))]
	public struct SelectedEquipmentChangeSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct EquippedSlotChangeJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlacementCD> __PlacementCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					public ComponentTypeHandle<AimIndicatorCachedStatesCD> __AimIndicatorCachedStatesCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__EquippedObjectCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>();
						__PlayerEquipment_EquipmentSlotCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>();
						__PlacementCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlacementCD>();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
						__AimIndicatorCachedStatesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AimIndicatorCachedStatesCD>();
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__EquippedObjectCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RW_ComponentTypeHandle.Update(ref state);
						__PlacementCD_RW_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__AimIndicatorCachedStatesCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlacementCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AimIndicatorCachedStatesCD>();
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
				public void Run(ref EquippedSlotChangeJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref EquippedSlotChangeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref EquippedSlotChangeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref EquippedSlotChangeJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref EquippedSlotChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref EquippedSlotChangeJob job, EntityManager entityManager)
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
			public ComponentLookup<CattleCD> cattleLookup;

			public WorldInfoCD worldInfo;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> tileLookup;

			[ReadOnly]
			public ComponentLookup<PseudoTileCD> pseudoTileLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> durabilityLookup;

			[ReadOnly]
			public ComponentLookup<RangeWeaponCD> rangeWeaponLookup;

			[ReadOnly]
			public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

			[ReadOnly]
			public ComponentLookup<CommandMinionWeaponCD> commandMinionLookup;

			[ReadOnly]
			public ComponentLookup<CastItemCD> castItemLookup;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> directionLookup;

			public PugDatabase.DatabaseBankCD databaseBank;

			public uint tickRate;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(ref EquippedObjectCD equippedObjectCD, ref EquipmentSlotCD equipmentSlotCD, ref PlacementCD placementCD, in ClientInput clientInput, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ref AimIndicatorCachedStatesCD aimIndicatorCachedStatesCD, in PlayerStateCD playerStateCD)
			{
				int equippedSlotIndex = equippedObjectCD.equippedSlotIndex;
				ContainedObjectsBuffer containedObject = equippedObjectCD.containedObject;
				equippedObjectCD.equippedSlotIndex = clientInput.equippedSlotIndex;
				equippedObjectCD.containedObject = containedObjectsBuffer[equippedObjectCD.equippedSlotIndex];
				equippedObjectCD.equipmentPrefab = PugDatabase.GetPrimaryPrefabEntity(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob, equippedObjectCD.containedObject.variation);
				equippedObjectCD.isBroken = PlayerController.ItemIsBroken(equippedObjectCD.equipmentPrefab, equippedObjectCD.containedObject.objectData, databaseBankCD.databaseBankBlob, durabilityLookup);
				aimIndicatorCachedStatesCD.hasAimValidStateAndIntactWeapon = PlayerController.StateAllowsAimUI(in playerStateCD) && !equippedObjectCD.isBroken;
				rangeWeaponLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(componentData.projectileID, databaseBankCD.databaseBankBlob);
				aimIndicatorCachedStatesCD.isMortar = mortarProjectileLookup.HasComponent(primaryPrefabEntity);
				aimIndicatorCachedStatesCD.isRanged = equipmentSlotCD.slotType == EquipmentSlotType.RangeWeaponSlot && !aimIndicatorCachedStatesCD.isMortar;
				aimIndicatorCachedStatesCD.isBeamWeapon = equipmentSlotCD.slotType == EquipmentSlotType.BeamWeaponSlot;
				aimIndicatorCachedStatesCD.isCommandMinion = commandMinionLookup.HasComponent(equippedObjectCD.equipmentPrefab);
				if (equippedObjectCD.equippedSlotIndex != equippedSlotIndex || !equippedObjectCD.containedObject.Equals(containedObject))
				{
					if (PlacementHandler.ObjectCanBeRotated(equippedObjectCD.equipmentPrefab, directionBasedOnVariationLookup, objectPropertiesLookup, directionLookup))
					{
						if (placementCD.rotationVariationToPlace >= 4)
						{
							placementCD.rotationVariationToPlace = 2;
						}
					}
					else if (PlacementHandler.ObjectCanBeToggledToNewNonRotationOption(equippedObjectCD.equipmentPrefab, objectPropertiesLookup))
					{
						int value = 0;
						if (objectPropertiesLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData2))
						{
							componentData2.TryGet<int>(-1876849774, out value);
						}
						if (placementCD.nonRotationVariationToPlace >= value)
						{
							placementCD.nonRotationVariationToPlace = 0;
						}
					}
					placementCD.currentPrefabVariation = 0;
					equipmentSlotCD = EquipmentSlotCD.GetDefaultValues(equipmentSlotCD.secondInteractBlockedUntilRelease);
				}
				equipmentSlotCD.slotType = PlayerController.GetEquippedSlotTypeForObjectType(PugDatabase.GetEntityObjectInfo(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob, equippedObjectCD.containedObject.variation).objectType, equippedObjectCD.equipmentPrefab, cattleLookup, castItemLookup, worldInfo);
				EquipmentSlotType slotType = equipmentSlotCD.slotType;
				if (slotType == EquipmentSlotType.PlaceObjectSlot || slotType == EquipmentSlotType.BucketSlot || slotType == EquipmentSlotType.WaterCanSlot || slotType == EquipmentSlotType.PaintToolSlot || slotType == EquipmentSlotType.HoeSlot || slotType == EquipmentSlotType.RoofingToolSlot || slotType == EquipmentSlotType.ShovelSlot)
				{
					PlacementHandler.Activate(ref placementCD, equippedObjectCD.equipmentPrefab, objectPropertiesLookup, tileLookup, pseudoTileLookup);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlacementCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AimIndicatorCachedStatesCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AimIndicatorCachedStatesCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, i));
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, nextRangeBegin), bufferAccessor[nextRangeBegin], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AimIndicatorCachedStatesCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, nextRangeBegin));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AimIndicatorCachedStatesCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AimIndicatorCachedStatesCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, k));
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
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct EquipmentPresetChangeJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ActiveEquipmentPresetCD> __ActiveEquipmentPresetCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<EquipmentPresetsBuffer> __EquipmentPresetsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__ActiveEquipmentPresetCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ActiveEquipmentPresetCD>();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__EquipmentPresetsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<EquipmentPresetsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__ActiveEquipmentPresetCD_RW_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__EquipmentPresetsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentPresetsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ActiveEquipmentPresetCD>();
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
				public void Run(ref EquipmentPresetChangeJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref EquipmentPresetChangeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref EquipmentPresetChangeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref EquipmentPresetChangeJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref EquipmentPresetChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref EquipmentPresetChangeJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(ref ActiveEquipmentPresetCD activeEquipmentPresetCD, in ClientInput clientInput, in DynamicBuffer<EquipmentPresetsBuffer> equipmentPresetsBuffer)
			{
				if (clientInput.WasInputCreated())
				{
					int value = math.clamp(clientInput.equipmentPresetIndex, 0, equipmentPresetsBuffer.Length);
					activeEquipmentPresetCD.Value = value;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ActiveEquipmentPresetCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				BufferAccessor<EquipmentPresetsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__EquipmentPresetsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, i), bufferAccessor[i]);
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, j), bufferAccessor[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr2, k), bufferAccessor[k]);
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
		private struct SetEquipmentPresetJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<ActiveEquipmentPresetCD> __ActiveEquipmentPresetCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<EquipmentCD> __EquipmentCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<EquipmentPresetsBuffer> __EquipmentPresetsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__ActiveEquipmentPresetCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ActiveEquipmentPresetCD>(isReadOnly: true);
						__EquipmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentCD>();
						__EquipmentPresetsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<EquipmentPresetsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__ActiveEquipmentPresetCD_RO_ComponentTypeHandle.Update(ref state);
						__EquipmentCD_RW_ComponentTypeHandle.Update(ref state);
						__EquipmentPresetsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ActiveEquipmentPresetCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentPresetsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EquipmentCD>();
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
				public void Run(ref SetEquipmentPresetJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SetEquipmentPresetJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SetEquipmentPresetJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SetEquipmentPresetJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SetEquipmentPresetJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SetEquipmentPresetJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(in ActiveEquipmentPresetCD activeEquipmentPresetCD, ref EquipmentCD equipmentCD, in DynamicBuffer<EquipmentPresetsBuffer> equipmentPresetsBuffer)
			{
				equipmentCD = equipmentPresetsBuffer[activeEquipmentPresetCD.Value].equipment;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ActiveEquipmentPresetCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__EquipmentCD_RW_ComponentTypeHandle);
				BufferAccessor<EquipmentPresetsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__EquipmentPresetsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, i), bufferAccessor[i]);
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, j), bufferAccessor[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ActiveEquipmentPresetCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, k), bufferAccessor[k]);
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
			public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PseudoTileCD> __PseudoTileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<RangeWeaponCD> __RangeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CommandMinionWeaponCD> __CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CastItemCD> __CastItemCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

			public EquippedSlotChangeJob.InternalCompilerQueryAndHandleData __PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle;

			public EquipmentPresetChangeJob.InternalCompilerQueryAndHandleData __PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle;

			public SetEquipmentPresetJob.InternalCompilerQueryAndHandleData __PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
				__PseudoTileCD_RO_ComponentLookup = state.GetComponentLookup<PseudoTileCD>(isReadOnly: true);
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__RangeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<RangeWeaponCD>(isReadOnly: true);
				__MortarProjectileCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
				__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup = state.GetComponentLookup<CommandMinionWeaponCD>(isReadOnly: true);
				__CastItemCD_RO_ComponentLookup = state.GetComponentLookup<CastItemCD>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
				__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007750_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007750_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007750_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007751_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007751_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007751_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1237120696_0;

		private EntityQuery __query_1237120696_1;

		private EntityQuery __query_1237120696_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<WorldInfoCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			JobHandle job = __ScheduleViaJobChunkExtension_0(new EquippedSlotChangeJob
			{
				databaseBankCD = __query_1237120696_0.GetSingleton<PugDatabase.DatabaseBankCD>(),
				cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
				objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
				tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
				pseudoTileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PseudoTileCD_RO_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
				rangeWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeWeaponCD_RO_ComponentLookup, ref state),
				mortarProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileCD_RO_ComponentLookup, ref state),
				commandMinionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup, ref state),
				castItemLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CastItemCD_RO_ComponentLookup, ref state),
				directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				directionBasedOnVariationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state),
				databaseBank = __query_1237120696_0.GetSingleton<PugDatabase.DatabaseBankCD>(),
				worldInfo = __query_1237120696_1.GetSingleton<WorldInfoCD>(),
				tickRate = (uint)__query_1237120696_2.GetSingleton<ClientServerTickRate>().SimulationTickRate
			}, __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			JobHandle dependency = __ScheduleViaJobChunkExtension_1(default(EquipmentPresetChangeJob), __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			JobHandle job2 = __ScheduleViaJobChunkExtension_2(default(SetEquipmentPresetJob), __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = JobHandle.CombineDependencies(job, job2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(EquippedSlotChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquippedSlotChangeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(EquipmentPresetChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_EquipmentPresetChangeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(SetEquipmentPresetJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_SelectedEquipmentChangeSystem_SetEquipmentPresetJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1237120696_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1237120696_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1237120696_2 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00007750_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007751_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SelectedEquipmentChangeSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SelectedEquipmentChangeSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SelectedEquipmentChangeSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

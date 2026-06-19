using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommandMinion;
using Inventory;
using Pug.Automation;
using Pug.Properties;
using PugTilemap;
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
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(EquipmentUpdateSystemGroup))]
	public struct EquipmentUpdateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct UpdateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public EquipmentUpdateAspect.TypeHandle __PlayerEquipment_EquipmentUpdateAspect_RW_AspectTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PlayerEquipment_EquipmentUpdateAspect_RW_AspectTypeHandle = new EquipmentUpdateAspect.TypeHandle(ref state);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PlayerEquipment_EquipmentUpdateAspect_RW_AspectTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAspect<EquipmentUpdateAspect>();
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
				public void Run(ref UpdateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateJob job, EntityManager entityManager)
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

			public EquipmentUpdateSharedData equipmentUpdateSharedData;

			public LookupEquipmentUpdateData lookupEquipmentUpdateData;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(EquipmentUpdateAspect equipmentUpdateAspect, in ClientInput clientInput)
			{
				bool flag = clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown);
				bool flag2 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown);
				flag2 &= !equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractBlockedUntilRelease;
				equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractBlockedUntilRelease &= !clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_Released);
				if (!PlayerController.CurrentStateAllowInteractions(in equipmentUpdateSharedData.worldInfoCD, in equipmentUpdateAspect.playerGhost.ValueRO, in equipmentUpdateAspect.playerStateCD.ValueRO, in equipmentUpdateAspect.equipmentSlotCD.ValueRO, flag2 && !flag, in clientInput, in equipmentUpdateAspect.playerSleepStateCD.ValueRO))
				{
					return;
				}
				DynamicBuffer<ContainedObjectsBuffer> bufferData;
				CraftingCD componentData;
				bool flag3 = lookupEquipmentUpdateData.containedObjectsBufferLookup.TryGetBuffer(equipmentUpdateAspect.entity, out bufferData) && lookupEquipmentUpdateData.craftingLookup.TryGetComponent(equipmentUpdateAspect.entity, out componentData) && bufferData.Length > componentData.outputSlotIndex && bufferData[componentData.outputSlotIndex].objectID != ObjectID.None;
				bool flag4 = flag | equipmentUpdateAspect.equipmentSlotCD.ValueRW.interactIsPendingToBeUsed;
				bool flag5 = flag2 | equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractIsPendingToBeUsed;
				bool flag6 = false;
				bool flag7 = EquipmentSlot.IsItemOnCooldown(in equipmentUpdateAspect.equippedObjectCD.ValueRO, in equipmentUpdateSharedData.databaseBank, in lookupEquipmentUpdateData.cooldownLookup, equipmentUpdateAspect.syncedSharedCooldownTimers, in equipmentUpdateSharedData.currentTick);
				if (!flag7)
				{
					switch (equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType)
					{
					case EquipmentSlotType.ShovelSlot:
						flag6 = ShovelSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.PlaceObjectSlot:
						flag6 = PlaceObjectSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.EatableSlot:
						flag6 = EatableSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.WaterCanSlot:
						flag6 = WaterCanSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.SeederSlot:
						flag6 = SeederSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.HoeSlot:
						flag6 = HoeSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.CastingSlot:
						flag6 = CastingItemSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.PaintToolSlot:
						flag6 = PaintToolSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.FishingRodSlot:
						flag6 = FishingRodSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.InstrumentSlot:
						flag6 = InstrumentSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.BucketSlot:
						flag6 = BucketSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.RoofingToolSlot:
						flag6 = RoofingToolSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.SummoningWeaponSlot:
						flag6 = SummoningWeaponSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					case EquipmentSlotType.EquipGearSlot:
						flag6 = EquipGearSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
						break;
					}
				}
				if (!flag3 && lookupEquipmentUpdateData.commandMinionLookup.HasComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab))
				{
					flag6 = SummoningWeaponSlot.UpdateEquipmentCommandMinion(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData, flag3);
				}
				bool flag8 = flag6;
				bool flag9 = EquipmentSlotUtility.IsWeaponSlot(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType);
				if (!flag3 && !flag6 && !EquipmentSlot.IsAttackOnCooldown(ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, in equipmentUpdateSharedData.currentTick) && (!flag7 || !flag9))
				{
					flag6 = EquipmentSlot.UpdateEquipment(flag4, flag5, in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in lookupEquipmentUpdateData);
					flag8 = true;
				}
				bool flag10 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_Pressed);
				bool flag11 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_Pressed);
				if (flag4)
				{
					if (flag8)
					{
						equipmentUpdateAspect.equipmentSlotCD.ValueRW.interactIsPendingToBeUsed = false;
					}
					else if (flag10 && EquipmentSlot.GetHitCooldownRemaining(equipmentUpdateAspect, equipmentUpdateSharedData, lookupEquipmentUpdateData) < 0.2f)
					{
						equipmentUpdateAspect.equipmentSlotCD.ValueRW.interactIsPendingToBeUsed = true;
					}
				}
				if (flag5)
				{
					if (flag8)
					{
						equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractIsPendingToBeUsed = false;
					}
					else if (flag11 && EquipmentSlot.GetCooldownRemainingForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, lookupEquipmentUpdateData) < 0.1f)
					{
						equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractIsPendingToBeUsed = true;
					}
				}
				if (!flag3 && flag7 && !flag6 && !flag9 && (flag10 || flag11))
				{
					Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
					if (!lookupEquipmentUpdateData.tileLookup.TryGetComponent(equipmentPrefab, out var componentData2) || !componentData2.tileType.IsWallTile())
					{
						equipmentUpdateAspect.equipmentSlotCD.ValueRW.lastInteractPressedOnCooldownTick = equipmentUpdateSharedData.currentTick;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				EquipmentUpdateAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerEquipment_EquipmentUpdateAspect_RW_AspectTypeHandle.Resolve(chunk);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						EquipmentUpdateAspect equipmentUpdateAspect = resolvedChunk[i];
						Execute(equipmentUpdateAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, i));
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
							EquipmentUpdateAspect equipmentUpdateAspect2 = resolvedChunk[nextRangeBegin];
							Execute(equipmentUpdateAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, nextRangeBegin));
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
						EquipmentUpdateAspect equipmentUpdateAspect3 = resolvedChunk[j];
						Execute(equipmentUpdateAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						EquipmentUpdateAspect equipmentUpdateAspect4 = resolvedChunk[k];
						Execute(equipmentUpdateAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr, k));
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
			public ComponentLookup<SecondaryUseCD> __SecondaryUseCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CooldownCD> __CooldownCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WarmupCD> __WarmupCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ConsumesManaCD> __ConsumesManaCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ParchmentRecipeCD> __ParchmentRecipeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

			public ComponentLookup<AttackWithEquipmentTag> __PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PetCandyCD> __PetCandyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PotionCD> __PotionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

			public ComponentLookup<PlayAnimationStateCD> __PlayAnimationStateCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			public ComponentLookup<WaitingForEatableSlotConsumeResultCD> __WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup;

			public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<AdaptiveEntityBuffer> __AdaptiveEntityBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ResizableTileSizeCD> __ResizableTileSizeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

			public ComponentLookup<PlantCD> __PlantCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CritterCD> __CritterCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FireflyCD> __FireflyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<RequiresDrillCD> __RequiresDrillCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EventTerminalCD> __EventTerminalCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WaterSourceCD> __WaterSourceCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PaintToolCD> __PaintToolCD_RO_ComponentLookup;

			public ComponentLookup<PaintableObjectCD> __PaintableObjectCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GrowingCD> __GrowingCD_RO_ComponentLookup;

			public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> __PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

			public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

			public ComponentLookup<DontDropLootCD> __DontDropLootCD_RW_ComponentLookup;

			public ComponentLookup<KilledByPlayerCD> __KilledByPlayerCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DestructibleObjectCD> __DestructibleObjectCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CanBeRemovedByWaterCD> __CanBeRemovedByWaterCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GroundDecorationCD> __GroundDecorationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DiggableCD> __DiggableCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PseudoTileCD> __PseudoTileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DontBlockDiggingCD> __DontBlockDiggingCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FullnessCD> __FullnessCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public BufferLookup<InventoryBuffer> __InventoryBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<AnvilCD> __AnvilCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WayPointCD> __WayPointCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CraftingCD> __CraftingCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ProximityTriggerCD> __ProximityTriggerCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CommandMinionWeaponCD> __CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<RootPlantCD> __RootPlantCD_RO_ComponentLookup;

			public ComponentLookup<TriggerSelectEnemyToAttackForMinionCommandCD> __TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentLookup;

			public ComponentLookup<TriggerAnimationOnDeathCD> __TriggerAnimationOnDeathCD_RW_ComponentLookup;

			public ComponentLookup<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup;

			public ComponentLookup<HasExplodedCD> __HasExplodedCD_RW_ComponentLookup;

			public UpdateJob.InternalCompilerQueryAndHandleData __PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__SecondaryUseCD_RO_ComponentLookup = state.GetComponentLookup<SecondaryUseCD>(isReadOnly: true);
				__CooldownCD_RO_ComponentLookup = state.GetComponentLookup<CooldownCD>(isReadOnly: true);
				__WarmupCD_RO_ComponentLookup = state.GetComponentLookup<WarmupCD>(isReadOnly: true);
				__ConsumesManaCD_RO_ComponentLookup = state.GetComponentLookup<ConsumesManaCD>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__ParchmentRecipeCD_RO_ComponentLookup = state.GetComponentLookup<ParchmentRecipeCD>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup = state.GetComponentLookup<AttackWithEquipmentTag>();
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
				__PetCandyCD_RO_ComponentLookup = state.GetComponentLookup<PetCandyCD>(isReadOnly: true);
				__PotionCD_RO_ComponentLookup = state.GetComponentLookup<PotionCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
				__PlayAnimationStateCD_RW_ComponentLookup = state.GetComponentLookup<PlayAnimationStateCD>();
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup = state.GetComponentLookup<WaitingForEatableSlotConsumeResultCD>();
				__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
				__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__AdaptiveEntityBuffer_RO_BufferLookup = state.GetBufferLookup<AdaptiveEntityBuffer>(isReadOnly: true);
				__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__ResizableTileSizeCD_RO_ComponentLookup = state.GetComponentLookup<ResizableTileSizeCD>(isReadOnly: true);
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
				__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
				__PlantCD_RW_ComponentLookup = state.GetComponentLookup<PlantCD>();
				__CritterCD_RO_ComponentLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
				__FireflyCD_RO_ComponentLookup = state.GetComponentLookup<FireflyCD>(isReadOnly: true);
				__RequiresDrillCD_RO_ComponentLookup = state.GetComponentLookup<RequiresDrillCD>(isReadOnly: true);
				__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
				__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
				__EventTerminalCD_RO_ComponentLookup = state.GetComponentLookup<EventTerminalCD>(isReadOnly: true);
				__WaterSourceCD_RO_ComponentLookup = state.GetComponentLookup<WaterSourceCD>(isReadOnly: true);
				__PaintToolCD_RO_ComponentLookup = state.GetComponentLookup<PaintToolCD>(isReadOnly: true);
				__PaintableObjectCD_RW_ComponentLookup = state.GetComponentLookup<PaintableObjectCD>();
				__GrowingCD_RO_ComponentLookup = state.GetComponentLookup<GrowingCD>(isReadOnly: true);
				__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup = state.GetComponentLookup<ReduceDurabilityOfEquippedTriggerCD>();
				__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
				__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
				__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
				__DontDropLootCD_RW_ComponentLookup = state.GetComponentLookup<DontDropLootCD>();
				__KilledByPlayerCD_RW_ComponentLookup = state.GetComponentLookup<KilledByPlayerCD>();
				__DestructibleObjectCD_RO_ComponentLookup = state.GetComponentLookup<DestructibleObjectCD>(isReadOnly: true);
				__CanBeRemovedByWaterCD_RO_ComponentLookup = state.GetComponentLookup<CanBeRemovedByWaterCD>(isReadOnly: true);
				__GroundDecorationCD_RO_ComponentLookup = state.GetComponentLookup<GroundDecorationCD>(isReadOnly: true);
				__DiggableCD_RO_ComponentLookup = state.GetComponentLookup<DiggableCD>(isReadOnly: true);
				__PseudoTileCD_RO_ComponentLookup = state.GetComponentLookup<PseudoTileCD>(isReadOnly: true);
				__DontBlockDiggingCD_RO_ComponentLookup = state.GetComponentLookup<DontBlockDiggingCD>(isReadOnly: true);
				__FullnessCD_RO_ComponentLookup = state.GetComponentLookup<FullnessCD>(isReadOnly: true);
				__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__InventoryBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
				__AnvilCD_RO_ComponentLookup = state.GetComponentLookup<AnvilCD>(isReadOnly: true);
				__WayPointCD_RO_ComponentLookup = state.GetComponentLookup<WayPointCD>(isReadOnly: true);
				__CraftingCD_RO_ComponentLookup = state.GetComponentLookup<CraftingCD>(isReadOnly: true);
				__ProximityTriggerCD_RO_ComponentLookup = state.GetComponentLookup<ProximityTriggerCD>(isReadOnly: true);
				__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup = state.GetComponentLookup<CommandMinionWeaponCD>(isReadOnly: true);
				__RootPlantCD_RO_ComponentLookup = state.GetComponentLookup<RootPlantCD>(isReadOnly: true);
				__TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentLookup = state.GetComponentLookup<TriggerSelectEnemyToAttackForMinionCommandCD>();
				__TriggerAnimationOnDeathCD_RW_ComponentLookup = state.GetComponentLookup<TriggerAnimationOnDeathCD>();
				__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPredictedByEntityDestroyedCD>();
				__HasExplodedCD_RW_ComponentLookup = state.GetComponentLookup<HasExplodedCD>();
				__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000753A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000753A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000753A_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_0000753B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_0000753B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000753B_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

		private uint _tickRate;

		private TileAccessor _tileAccessor;

		private EntityArchetype _achievementArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1238627873_0;

		private EntityQuery __query_1238627873_1;

		private EntityQuery __query_1238627873_2;

		private EntityQuery __query_1238627873_3;

		private EntityQuery __query_1238627873_4;

		private EntityQuery __query_1238627873_5;

		private EntityQuery __query_1238627873_6;

		private EntityQuery __query_1238627873_7;

		private EntityQuery __query_1238627873_8;

		private EntityQuery __query_1238627873_9;

		public void OnCreate(ref SystemState state)
		{
			_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<TileWithTilesetToObjectDataMapCD>();
			_achievementArchetype = AchievementSystem.GetRpcArchetype(state.EntityManager);
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
		}

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
			__query_1238627873_0.TryGetSingleton<NetworkTime>(out var value);
			BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_1238627873_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateJob
			{
				equipmentUpdateSharedData = new EquipmentUpdateSharedData
				{
					currentTick = value.ServerTick,
					databaseBank = __query_1238627873_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
					worldInfoCD = __query_1238627873_3.GetSingleton<WorldInfoCD>(),
					tickRate = _tickRate,
					physicsWorld = __query_1238627873_4.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
					physicsWorldHistory = __query_1238627873_5.GetSingleton<PhysicsWorldHistorySingleton>(),
					inventoryUpdateBufferEntity = __query_1238627873_6.GetSingletonEntity(),
					tileUpdateBufferEntity = __query_1238627873_7.GetSingletonEntity(),
					tileAccessor = _tileAccessor,
					tileWithTilesetToObjectDataMapCD = __query_1238627873_8.GetSingleton<TileWithTilesetToObjectDataMapCD>(),
					colliderCacheCD = __query_1238627873_9.GetSingleton<ColliderCacheCD>(),
					isServer = state.WorldUnmanaged.IsServer(),
					ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
					isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
					achievementArchetype = _achievementArchetype
				},
				lookupEquipmentUpdateData = new LookupEquipmentUpdateData
				{
					secondaryUseLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SecondaryUseCD_RO_ComponentLookup, ref state),
					cooldownLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CooldownCD_RO_ComponentLookup, ref state),
					warmupLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WarmupCD_RO_ComponentLookup, ref state),
					consumeManaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConsumesManaCD_RO_ComponentLookup, ref state),
					levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
					levelEntitiesLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
					parchementRecipeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ParchmentRecipeCD_RO_ComponentLookup, ref state),
					objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
					attackWithEquipmentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_AttackWithEquipmentTag_RW_ComponentLookup, ref state),
					inventoryUpdateBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
					cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
					petCandyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCandyCD_RO_ComponentLookup, ref state),
					potionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PotionCD_RO_ComponentLookup, ref state),
					localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
					petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
					playAnimationStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayAnimationStateCD_RW_ComponentLookup, ref state),
					simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
					waitingForEatableSlotConsumeResultLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup, ref state),
					tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
					tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
					objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
					adaptiveEntityBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AdaptiveEntityBuffer_RO_BufferLookup, ref state),
					directionBasedOnVariationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state),
					directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
					sizeVariationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ResizableTileSizeCD_RO_ComponentLookup, ref state),
					playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
					minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref state),
					indestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
					plantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RW_ComponentLookup, ref state),
					critterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state),
					fireflyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FireflyCD_RO_ComponentLookup, ref state),
					requiresDrillLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RequiresDrillCD_RO_ComponentLookup, ref state),
					surfacePriorityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref state),
					electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state),
					eventTerminalLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EventTerminalCD_RO_ComponentLookup, ref state),
					waterSourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaterSourceCD_RO_ComponentLookup, ref state),
					paintToolLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PaintToolCD_RO_ComponentLookup, ref state),
					paintableObjectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PaintableObjectCD_RW_ComponentLookup, ref state),
					growingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GrowingCD_RO_ComponentLookup, ref state),
					healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
					summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
					reduceDurabilityOfEquippedTagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup, ref state),
					summarizedConditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
					entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
					dontDropSelfLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref state),
					dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref state),
					killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RW_ComponentLookup, ref state),
					destructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestructibleObjectCD_RO_ComponentLookup, ref state),
					canBeRemovedByWaterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CanBeRemovedByWaterCD_RO_ComponentLookup, ref state),
					groundDecorationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GroundDecorationCD_RO_ComponentLookup, ref state),
					diggableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DiggableCD_RO_ComponentLookup, ref state),
					pseudoTileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PseudoTileCD_RO_ComponentLookup, ref state),
					dontBlockDiggingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontBlockDiggingCD_RO_ComponentLookup, ref state),
					fullnessLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FullnessCD_RO_ComponentLookup, ref state),
					godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
					containedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
					inventoryBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
					anvilLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnvilCD_RO_ComponentLookup, ref state),
					waypointLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WayPointCD_RO_ComponentLookup, ref state),
					craftingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CraftingCD_RO_ComponentLookup, ref state),
					proximityTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProximityTriggerCD_RO_ComponentLookup, ref state),
					commandMinionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CommandMinion_CommandMinionWeaponCD_RO_ComponentLookup, ref state),
					rootPlantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RootPlantCD_RO_ComponentLookup, ref state),
					triggerSelectNewEnemyToAttackCommandLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentLookup, ref state),
					triggerAnimationOnDeathLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TriggerAnimationOnDeathCD_RW_ComponentLookup, ref state),
					moveToPredictedByEntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup, ref state),
					hasExplodedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasExplodedCD_RW_ComponentLookup, ref state)
				}
			}, __TypeHandle.__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(UpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_EquipmentUpdateSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TileWithTilesetToObjectDataMapCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ColliderCacheCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1238627873_9 = entityQueryBuilder2.Build(ref state);
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
			((EquipmentUpdateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000753A_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_0000753B_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((EquipmentUpdateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((EquipmentUpdateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((EquipmentUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((EquipmentUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((EquipmentUpdateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}
	}
}

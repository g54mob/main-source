using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	[UpdateAfter(typeof(AttackWithEquipmentSystem))]
	[UpdateInGroup(typeof(EquipmentAfterUpdateSystemGroup))]
	public struct QueueHitSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(QueueHitTriggerCD),
			typeof(Simulate)
		})]
		private struct QueueHitJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public QueueHitAspect.TypeHandle __PlayerEquipment_QueueHitAspect_RW_AspectTypeHandle;

					public ComponentTypeHandle<ReleaseStateCD> __PlayerState_ReleaseStateCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PlayerEquipment_QueueHitAspect_RW_AspectTypeHandle = new QueueHitAspect.TypeHandle(ref state);
						__PlayerState_ReleaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ReleaseStateCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PlayerEquipment_QueueHitAspect_RW_AspectTypeHandle.Update(ref state);
						__PlayerState_ReleaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<QueueHitTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ReleaseStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAspect<QueueHitAspect>();
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
				public void Run(ref QueueHitJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref QueueHitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref QueueHitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref QueueHitJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref QueueHitJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref QueueHitJob job, EntityManager entityManager)
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

			public QueueHitShared queueHitShared;

			public QueueHitLookups queueHitLookups;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, QueueHitAspect queueHitAspect, ref ReleaseStateCD releaseStateCD)
			{
				ref PlayerStateCD valueRW = ref queueHitAspect.playerStateCD.ValueRW;
				bool num = valueRW.HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding);
				int animationToPlayAfterAttack = (num ? queueHitShared.ridingAnimID : (-1));
				ref readonly EquippedObjectCD valueRO = ref queueHitAspect.equippedObjectCD.ValueRO;
				bool flag = valueRO.containedObject.objectID != ObjectID.None && valueRO.isBroken;
				bool flag2 = !num && (!queueHitLookups.moveFreelyWeaponLookup.HasComponent(valueRO.equipmentPrefab) || flag);
				Attack(entity, in queueHitAspect, in queueHitShared, in queueHitLookups, flag2, animationToPlayAfterAttack);
				if (flag2)
				{
					valueRW.SetNextState(PlayerStateEnum.Release);
				}
				queueHitLookups.queueHitTriggerLookup.SetComponentEnabled(entity, value: false);
			}

			private static void Attack(Entity entity, in QueueHitAspect queueHitAspect, in QueueHitShared queueHitShared, in QueueHitLookups queueHitLookups, bool isUsingReleaseState, int _animationToPlayAfterAttack = -1)
			{
				ref PlayerAttackCD valueRW = ref queueHitAspect.playerAttackCD.ValueRW;
				ref readonly EquipmentSlotCD valueRO = ref queueHitAspect.equipmentSlotCD.ValueRO;
				ref readonly EquippedObjectCD valueRO2 = ref queueHitAspect.equippedObjectCD.ValueRO;
				queueHitAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Inactive;
				valueRW.animationToPlayAfterAttack = _animationToPlayAfterAttack;
				valueRW.windupMult = 0f;
				valueRW.isWoundup = false;
				valueRW.slotType = valueRO.slotType;
				valueRW.didSpawnTrail = false;
				if (valueRO2.containedObject.objectID != ObjectID.None)
				{
					valueRW.objectType = PugDatabase.GetEntityObjectInfo(valueRO2.containedObject.objectID, queueHitShared.databaseBankCD.databaseBankBlob, valueRO2.containedObject.variation).objectType;
				}
				else
				{
					valueRW.objectType = ObjectType.NonUsable;
				}
				valueRW.windupForce = (valueRO.secondaryUse.hasSecondaryUse ? valueRO.currentWindup : 1f);
				valueRW.heldItemIsBroken = valueRO2.containedObject.objectID != ObjectID.None && valueRO2.isBroken;
				bool flag = valueRW.slotType == EquipmentSlotType.RangeWeaponSlot && !valueRW.heldItemIsBroken;
				bool summonMinion = queueHitAspect.equipmentSlotCD.ValueRO.summonMinion;
				bool flag2 = valueRW.slotType == EquipmentSlotType.BeamWeaponSlot && !valueRW.heldItemIsBroken && valueRO.currentWindup > 0f;
				Entity equipmentPrefab = valueRO2.equipmentPrefab;
				MeleeWeaponCD componentData;
				bool flag3 = queueHitLookups.meleeWeaponLookup.TryGetComponent(equipmentPrefab, out componentData);
				RangeWeaponCD componentData2;
				bool flag4 = queueHitLookups.rangeWeaponLookup.TryGetComponent(equipmentPrefab, out componentData2);
				BeamWeaponCD componentData3;
				bool flag5 = queueHitLookups.beamWeaponLookup.TryGetComponent(equipmentPrefab, out componentData3);
				float num = ((!isUsingReleaseState) ? 0f : (1f / (float)queueHitShared.tickRate));
				bool quickHit = componentData.quickHit;
				float remainingSeconds = queueHitAspect.playerAttackCooldownCD.ValueRO.cooldown.GetRemainingSeconds(in queueHitShared.currentTick, queueHitShared.tickRate);
				float num2 = math.min(remainingSeconds, 0.15f);
				float num3 = math.clamp((quickHit ? (num2 / 2f) : num2) - num, 0f, float.MaxValue);
				valueRW.hitDuration.SetTargetTicks(num3, queueHitShared.tickRate);
				float num4 = math.min(remainingSeconds, 1f / 15f);
				float seconds = math.min(quickHit ? (num4 / 2f) : num4, num3);
				valueRW.hitDelay.SetTargetTicks(seconds, queueHitShared.tickRate);
				if (!flag && !summonMinion && !flag2)
				{
					valueRW.hitDelay.Start(queueHitShared.currentTick);
					valueRW.meleeDamage = 10;
					if (queueHitLookups.hasWeaponDamageLookup.HasComponent(equipmentPrefab) && !queueHitLookups.controlledByOTherEntityLookup.HasComponent(equipmentPrefab) && !valueRW.heldItemIsBroken)
					{
						bool isReinforced = false;
						if (queueHitLookups.durabilityLookup.TryGetComponent(equipmentPrefab, out var componentData4))
						{
							isReinforced = componentData4.IsReinforced(valueRO2.containedObject.amount);
						}
						float num5 = 0f;
						if (queueHitLookups.objectPropertiesLookup.TryGetComponent(equipmentPrefab, out var componentData5) && componentData5.TryGet<ConditionID>(1669350244, out var value))
						{
							num5 = (float)EntityUtility.GetConditionValue(value, entity, queueHitLookups.summarizedConditionsBufferLookup) / 100f;
						}
						valueRW.isWoundup = valueRO.atMaxWindup;
						valueRW.windupMult = valueRO.currentWindupMultiplier;
						float num6 = valueRO.secondaryUse.windupTime * valueRO.secondaryUse.extraDamageMultiplier;
						float num7 = math.lerp(1f, valueRW.windupMult * num6, valueRO.currentWindup);
						Entity levelEntity = EntityUtility.GetLevelEntity(equipmentPrefab, valueRO2.containedObject.objectData, queueHitLookups.levelEntitiesBufferLookup, queueHitLookups.levelLookup);
						if (levelEntity != Entity.Null)
						{
							valueRW.meleeDamage = (int)math.round((1f + num5) * num7 * (float)queueHitLookups.weaponDamageLookup[levelEntity].GetDamage(isReinforced));
						}
					}
				}
				else
				{
					valueRW.meleeDamage = 0;
					valueRW.hitDelay.Stop(queueHitShared.currentTick);
				}
				bool reorientationBlocked = true;
				if (flag3 || flag5)
				{
					reorientationBlocked = !queueHitLookups.moveFreelyWeaponLookup.HasComponent(equipmentPrefab);
				}
				else if (flag4)
				{
					reorientationBlocked = !componentData2.rotateFreely;
				}
				queueHitAspect.playerOrientationCD.ValueRW.reorientationBlocked = reorientationBlocked;
				valueRW.lungeForce = (valueRW.heldItemIsBroken ? 0f : componentData.lungeForce);
				queueHitLookups.leaveTrailLookup.TryGetComponent(equipmentPrefab, out var componentData6);
				valueRW.leaveTrail = !valueRW.heldItemIsBroken && componentData6.leaveTrail;
				valueRW.trails = ((!valueRW.heldItemIsBroken) ? componentData6.trails : 0);
				valueRW.recoilForce = (valueRW.heldItemIsBroken ? 0f : componentData2.recoilForce);
				valueRW.currentWindupTier = valueRO.currentWindupTier;
				if (!valueRW.heldItemIsBroken && valueRO.secondaryUse.hasSecondaryUse)
				{
					float num8 = (float)valueRO.currentWindupTier / (float)valueRO.secondaryUse.windupTiers;
					valueRW.trails = (int)((float)valueRW.trails * num8 / 2f) * 2;
				}
				valueRW.hitDuration.Start(queueHitShared.currentTick);
				if (valueRW.heldItemIsBroken)
				{
					PlayerController.PlayAnimationTrigger(-34540245, queueHitShared.currentTick, queueHitAspect.animationBuffer, ref queueHitAspect.animationBufferPointer.ValueRW);
				}
				else
				{
					int num9 = 0;
					if (flag3)
					{
						num9 = componentData.overrideAnimation;
					}
					else if (flag5)
					{
						num9 = ((!flag2) ? componentData3.overrideAnimation : componentData3.secondaryOverrideAnimation);
					}
					else if (flag4)
					{
						num9 = componentData2.overrideAnimation;
					}
					if (num9 != 0)
					{
						PlayerController.PlayAnimationTrigger(num9, queueHitShared.currentTick, queueHitAspect.animationBuffer, ref queueHitAspect.animationBufferPointer.ValueRW);
					}
					else
					{
						EquipmentSlotType slotType = valueRW.slotType;
						if (slotType == EquipmentSlotType.MeleeWeaponSlot || slotType == EquipmentSlotType.ShovelSlot || slotType == EquipmentSlotType.HoeSlot || slotType == EquipmentSlotType.PaintToolSlot || slotType == EquipmentSlotType.FishingRodSlot || slotType == EquipmentSlotType.InstrumentSlot || slotType == EquipmentSlotType.BugNet || slotType == EquipmentSlotType.RoofingToolSlot || slotType == EquipmentSlotType.EquipGearSlot || slotType == EquipmentSlotType.SeederSlot || slotType == EquipmentSlotType.BeamWeaponSlot)
						{
							PlayerController.PlayAnimationTrigger(1203776827, queueHitShared.currentTick, queueHitAspect.animationBuffer, ref queueHitAspect.animationBufferPointer.ValueRW);
						}
						else if (flag || summonMinion)
						{
							PlayerController.PlayAnimationTrigger(-1014102059, queueHitShared.currentTick, queueHitAspect.animationBuffer, ref queueHitAspect.animationBufferPointer.ValueRW);
						}
						else
						{
							PlayerController.PlayAnimationTrigger(-34540245, queueHitShared.currentTick, queueHitAspect.animationBuffer, ref queueHitAspect.animationBufferPointer.ValueRW);
						}
					}
				}
				queueHitAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Attacking;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				QueueHitAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerEquipment_QueueHitAspect_RW_AspectTypeHandle.Resolve(chunk);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_ReleaseStateCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						QueueHitAspect queueHitAspect = resolvedChunk[i];
						Execute(entity, queueHitAspect, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReleaseStateCD>(nativeArrayPtr2, i));
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
							QueueHitAspect queueHitAspect2 = resolvedChunk[nextRangeBegin];
							Execute(entity2, queueHitAspect2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReleaseStateCD>(nativeArrayPtr2, nextRangeBegin));
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
						QueueHitAspect queueHitAspect3 = resolvedChunk[j];
						Execute(entity3, queueHitAspect3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReleaseStateCD>(nativeArrayPtr2, j));
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
						QueueHitAspect queueHitAspect4 = resolvedChunk[k];
						Execute(entity4, queueHitAspect4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReleaseStateCD>(nativeArrayPtr2, k));
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
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MeleeWeaponCD> __MeleeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<RangeWeaponCD> __RangeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BeamWeaponCD> __BeamWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoveFreelyWeaponCD> __MoveFreelyWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HasWeaponDamageCD> __HasWeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WeaponDamageCD> __WeaponDamageCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LeaveTrailCD> __LeaveTrailCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			public ComponentLookup<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RW_ComponentLookup;

			public ComponentLookup<QueueHitTriggerCD> __QueueHitTriggerCD_RW_ComponentLookup;

			public QueueHitJob.InternalCompilerQueryAndHandleData __PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__MeleeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MeleeWeaponCD>(isReadOnly: true);
				__RangeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<RangeWeaponCD>(isReadOnly: true);
				__BeamWeaponCD_RO_ComponentLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
				__MoveFreelyWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MoveFreelyWeaponCD>(isReadOnly: true);
				__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
				__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
				__HasWeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<HasWeaponDamageCD>(isReadOnly: true);
				__WeaponDamageCD_RO_ComponentLookup = state.GetComponentLookup<WeaponDamageCD>(isReadOnly: true);
				__LeaveTrailCD_RO_ComponentLookup = state.GetComponentLookup<LeaveTrailCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__ControlledByOtherEntityCD_RW_ComponentLookup = state.GetComponentLookup<ControlledByOtherEntityCD>();
				__QueueHitTriggerCD_RW_ComponentLookup = state.GetComponentLookup<QueueHitTriggerCD>();
				__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_000076C8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000076C8_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000076C8_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private int _ridingAnimID;

		private uint _tickRate;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1011840603_0;

		private EntityQuery __query_1011840603_1;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			_ridingAnimID = -1193264516;
			_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1011840603_0.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new QueueHitJob
			{
				queueHitShared = new QueueHitShared
				{
					currentTick = value.ServerTick,
					ridingAnimID = _ridingAnimID,
					databaseBankCD = __query_1011840603_1.GetSingleton<PugDatabase.DatabaseBankCD>(),
					tickRate = _tickRate
				},
				queueHitLookups = new QueueHitLookups
				{
					durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
					meleeWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeWeaponCD_RO_ComponentLookup, ref state),
					rangeWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeWeaponCD_RO_ComponentLookup, ref state),
					beamWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamWeaponCD_RO_ComponentLookup, ref state),
					moveFreelyWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveFreelyWeaponCD_RO_ComponentLookup, ref state),
					levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
					levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
					hasWeaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasWeaponDamageCD_RO_ComponentLookup, ref state),
					weaponDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WeaponDamageCD_RO_ComponentLookup, ref state),
					leaveTrailLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LeaveTrailCD_RO_ComponentLookup, ref state),
					objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
					summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
					controlledByOTherEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ControlledByOtherEntityCD_RW_ComponentLookup, ref state),
					queueHitTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__QueueHitTriggerCD_RW_ComponentLookup, ref state)
				}
			}, __TypeHandle.__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(QueueHitJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_QueueHitSystem_QueueHitJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1011840603_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1011840603_1 = entityQueryBuilder2.Build(ref state);
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
			((QueueHitSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000076C8_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((QueueHitSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((QueueHitSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

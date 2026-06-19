using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

namespace PlayerEquipment
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateBefore(typeof(PlayerAttackSystem))]
	[UpdateBefore(typeof(TileDamageSystem))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	public struct PlayerAttackRoutineSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct AttackJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<PlayerRoutineCD> __PlayerRoutineCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerAttackCD> __PlayerEquipment_PlayerAttackCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerOrientationCD> __PlayerOrientationCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					public BufferTypeHandle<DealDamageToEntityBuffer> __DealDamageToEntityBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

					public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PlayerRoutineCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerRoutineCD>();
						__PlayerEquipment_PlayerAttackCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerAttackCD>();
						__PlayerOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerOrientationCD>();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__DealDamageToEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DealDamageToEntityBuffer>();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
						__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PlayerRoutineCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_PlayerAttackCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerOrientationCD_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__DealDamageToEntityBuffer_RW_BufferTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
						__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
						__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
						__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerRoutineCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerAttackCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerOrientationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DealDamageToEntityBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
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

			[ReadOnly]
			public ComponentLookup<GhostOwner> ghostOwnerLookup;

			[ReadOnly]
			public ComponentLookup<LeaveTrailCD> leaveTrailLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> factionLookup;

			[ReadOnly]
			public ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup;

			[ReadOnly]
			public ComponentLookup<BehaviourTagsCD> behaviorlookup;

			public ConditionsTableCD conditionsTableCD;

			public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public NetworkTick currentTick;

			public uint tickRate;

			public bool isFirstTimeFullyPredictingTick;

			public float deltaTime;

			public EntityCommandBuffer ecb;

			public bool isPartialTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref PlayerRoutineCD playerRoutineCD, ref PlayerAttackCD playerAttackCD, ref PlayerOrientationCD playerOrientationCD, in LocalTransform localTransform, ref DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer, in ClientInput clientInput, in PlayerStateCD playerStateCD, in EquipmentSlotCD equipmentSlotCD, in EquippedObjectCD equippedObjectCD, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref AnimationBufferPointer animationBufferPointer, ref DynamicBuffer<AnimationBuffer> animationBuffer)
			{
				if (playerRoutineCD.activeRoutine != PlayerRoutines.Attacking)
				{
					return;
				}
				if (playerAttackCD.hitDelay.isRunning && playerAttackCD.hitDelay.IsTimerElapsed(currentTick))
				{
					if (playerAttackCD.slotType == EquipmentSlotType.BugNet && !playerAttackCD.heldItemIsBroken)
					{
						dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
						{
							attackType = DealDamageToEntityBuffer.AttackType.CatchCritters
						});
					}
					else if (playerAttackCD.objectType == ObjectType.BeamWeapon && !playerAttackCD.heldItemIsBroken)
					{
						dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
						{
							attackType = DealDamageToEntityBuffer.AttackType.RayCast
						});
					}
					else
					{
						dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
						{
							attackType = DealDamageToEntityBuffer.AttackType.Melee
						});
					}
					playerAttackCD.hitDelay.Stop(currentTick);
				}
				if (math.abs(playerAttackCD.lungeForce) > 0f || math.abs(playerAttackCD.recoilForce) > 0f)
				{
					float num = 1f;
					float3 float5 = clientInput.targetingDirection.ToFloat3() * playerAttackCD.windupForce * num;
					PlayerController.Pushback(entity, float5 * (playerAttackCD.lungeForce - playerAttackCD.recoilForce), in playerStateCD, receivedPushbackLookup, currentTick, tickRate);
					playerAttackCD.lungeForce = 0f;
					playerAttackCD.recoilForce = 0f;
				}
				if (playerAttackCD.hitDuration.isRunning && !playerAttackCD.hitDuration.IsTimerElapsed(currentTick))
				{
					if (!playerAttackCD.leaveTrail || playerAttackCD.didSpawnTrail || !equipmentSlotCD.secondaryUse.hasSecondaryUse || playerAttackCD.currentWindupTier <= 0)
					{
						return;
					}
					playerAttackCD.didSpawnTrail = true;
					ObjectID trailObjectID = leaveTrailLookup[equippedObjectCD.equipmentPrefab].trailObjectID;
					SfxID sfxID = SfxID.swordImpact;
					switch (trailObjectID)
					{
					case ObjectID.CrystalSpikeTrail:
						sfxID = SfxID.crystalDestroy2;
						break;
					case ObjectID.RuneSongTrail:
						sfxID = SfxID.zealotBladeWhoosh;
						break;
					case ObjectID.VoidClubTrail:
						sfxID = SfxID.hydraShockwaveAnticipate;
						break;
					}
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, sfxID, entity)
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
					if (isFirstTimeFullyPredictingTick)
					{
						float3 float6 = clientInput.targetingDirection.ToFloat3();
						for (int i = 0; i < playerAttackCD.trails; i++)
						{
							float3 position = localTransform.Position + float6 * (1f + (float)i);
							EntityUtility.SpawnTrail(ghostOwnerLookup, attackContinuouslyLookup, factionLookup, summarizedConditionBufferLookup, behaviorlookup, conditionsTableCD, ecb, position, databaseBankCD.databaseBankBlob, entity, playerAttackCD.meleeDamage, trailObjectID);
						}
					}
				}
				else
				{
					if (playerAttackCD.animationToPlayAfterAttack != -1 && !isPartialTick)
					{
						PlayerController.PlayAnimationTrigger(playerAttackCD.animationToPlayAfterAttack, currentTick, animationBuffer, ref animationBufferPointer);
					}
					playerOrientationCD.reorientationBlocked = false;
					playerRoutineCD.activeRoutine = PlayerRoutines.Inactive;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerRoutineCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_PlayerAttackCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerOrientationCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				BufferAccessor<DealDamageToEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__DealDamageToEntityBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
				BufferAccessor<AnimationBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref PlayerRoutineCD playerRoutineCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, i);
						ref PlayerAttackCD playerAttackCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCD>(nativeArrayPtr3, i);
						ref PlayerOrientationCD playerOrientationCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerOrientationCD>(nativeArrayPtr4, i);
						ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i);
						DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer = bufferAccessor[i];
						ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, i);
						ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr7, i);
						ref EquipmentSlotCD equipmentSlotCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, i);
						ref EquippedObjectCD equippedObjectCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr9, i);
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr10, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor2[i];
						ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr11, i);
						DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor3[i];
						Execute(entity, ref playerRoutineCD, ref playerAttackCD, ref playerOrientationCD, in localTransform, ref dealDamageToEntityBuffer, in clientInput, in playerStateCD, in equipmentSlotCD, in equippedObjectCD, ref ghostEffectEventBufferPointerCD, ref ghostEffectEventBuffer, ref animationBufferPointer, ref animationBuffer);
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
							ref PlayerRoutineCD playerRoutineCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, nextRangeBegin);
							ref PlayerAttackCD playerAttackCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCD>(nativeArrayPtr3, nextRangeBegin);
							ref PlayerOrientationCD playerOrientationCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerOrientationCD>(nativeArrayPtr4, nextRangeBegin);
							ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin);
							DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer2 = bufferAccessor[nextRangeBegin];
							ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, nextRangeBegin);
							ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr7, nextRangeBegin);
							ref EquipmentSlotCD equipmentSlotCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, nextRangeBegin);
							ref EquippedObjectCD equippedObjectCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr9, nextRangeBegin);
							ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr10, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor2[nextRangeBegin];
							ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr11, nextRangeBegin);
							DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor3[nextRangeBegin];
							Execute(entity2, ref playerRoutineCD2, ref playerAttackCD2, ref playerOrientationCD2, in localTransform2, ref dealDamageToEntityBuffer2, in clientInput2, in playerStateCD2, in equipmentSlotCD2, in equippedObjectCD2, ref ghostEffectEventBufferPointerCD2, ref ghostEffectEventBuffer2, ref animationBufferPointer2, ref animationBuffer2);
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
						ref PlayerRoutineCD playerRoutineCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, j);
						ref PlayerAttackCD playerAttackCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCD>(nativeArrayPtr3, j);
						ref PlayerOrientationCD playerOrientationCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerOrientationCD>(nativeArrayPtr4, j);
						ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j);
						DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer3 = bufferAccessor[j];
						ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, j);
						ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr7, j);
						ref EquipmentSlotCD equipmentSlotCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, j);
						ref EquippedObjectCD equippedObjectCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr9, j);
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr10, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor2[j];
						ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr11, j);
						DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor3[j];
						Execute(entity3, ref playerRoutineCD3, ref playerAttackCD3, ref playerOrientationCD3, in localTransform3, ref dealDamageToEntityBuffer3, in clientInput3, in playerStateCD3, in equipmentSlotCD3, in equippedObjectCD3, ref ghostEffectEventBufferPointerCD3, ref ghostEffectEventBuffer3, ref animationBufferPointer3, ref animationBuffer3);
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
						ref PlayerRoutineCD playerRoutineCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, k);
						ref PlayerAttackCD playerAttackCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerAttackCD>(nativeArrayPtr3, k);
						ref PlayerOrientationCD playerOrientationCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerOrientationCD>(nativeArrayPtr4, k);
						ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k);
						DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer4 = bufferAccessor[k];
						ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr6, k);
						ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr7, k);
						ref EquipmentSlotCD equipmentSlotCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, k);
						ref EquippedObjectCD equippedObjectCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr9, k);
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr10, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor2[k];
						ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr11, k);
						DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor3[k];
						Execute(entity4, ref playerRoutineCD4, ref playerAttackCD4, ref playerOrientationCD4, in localTransform4, ref dealDamageToEntityBuffer4, in clientInput4, in playerStateCD4, in equipmentSlotCD4, in equippedObjectCD4, ref ghostEffectEventBufferPointerCD4, ref ghostEffectEventBuffer4, ref animationBufferPointer4, ref animationBuffer4);
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
			public ComponentLookup<GhostOwner> __Unity_NetCode_GhostOwner_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LeaveTrailCD> __LeaveTrailCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<AttackContinuouslyCD> __AttackContinuouslyCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

			public ComponentLookup<ReceivedPushbackCD> __ReceivedPushbackCD_RW_ComponentLookup;

			public AttackJob.InternalCompilerQueryAndHandleData __PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_NetCode_GhostOwner_RO_ComponentLookup = state.GetComponentLookup<GhostOwner>(isReadOnly: true);
				__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
				__LeaveTrailCD_RO_ComponentLookup = state.GetComponentLookup<LeaveTrailCD>(isReadOnly: true);
				__AttackContinuouslyCD_RO_ComponentLookup = state.GetComponentLookup<AttackContinuouslyCD>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
				__ReceivedPushbackCD_RW_ComponentLookup = state.GetComponentLookup<ReceivedPushbackCD>();
				__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_000075C8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_000075C8_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000075C8_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_000075C9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000075C9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000075C9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		public PugDatabase.DatabaseBankCD _databaseBankCD;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1147732400_0;

		private EntityQuery __query_1147732400_1;

		private EntityQuery __query_1147732400_2;

		private EntityQuery __query_1147732400_3;

		private EntityQuery __query_1147732400_4;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<ConditionsTableCD>();
		}

		public void OnStartRunning(ref SystemState state)
		{
			_databaseBankCD = __query_1147732400_0.GetSingleton<PugDatabase.DatabaseBankCD>();
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			EntityCommandBuffer ecb = __query_1147732400_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_1147732400_2.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new AttackJob
			{
				ghostOwnerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostOwner_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				leaveTrailLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LeaveTrailCD_RO_ComponentLookup, ref state),
				attackContinuouslyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackContinuouslyCD_RO_ComponentLookup, ref state),
				summarizedConditionBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
				behaviorlookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
				receivedPushbackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ReceivedPushbackCD_RW_ComponentLookup, ref state),
				conditionsTableCD = __query_1147732400_3.GetSingleton<ConditionsTableCD>(),
				databaseBankCD = _databaseBankCD,
				currentTick = value.ServerTick,
				tickRate = (uint)__query_1147732400_4.GetSingleton<ClientServerTickRate>().SimulationTickRate,
				isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
				deltaTime = state.WorldUnmanaged.Time.DeltaTime,
				ecb = ecb,
				isPartialTick = value.IsPartialTick
			}, __TypeHandle.__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(AttackJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_PlayerAttackRoutineSystem_AttackJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1147732400_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1147732400_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1147732400_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1147732400_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1147732400_4 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_000075C8_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000075C9_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((PlayerAttackRoutineSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((PlayerAttackRoutineSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PlayerAttackRoutineSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerAttackRoutineSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerAttackRoutineSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

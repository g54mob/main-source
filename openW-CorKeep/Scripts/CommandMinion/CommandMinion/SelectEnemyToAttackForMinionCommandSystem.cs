using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlacementIndicator;
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

namespace CommandMinion
{
	[BurstCompile]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct SelectEnemyToAttackForMinionCommandSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(MinionCD) })]
		private struct RecordMinionJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__OwnerReferenceCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__OwnerReferenceCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MinionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OwnerReferenceCD>();
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
				public void Run(ref RecordMinionJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RecordMinionJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RecordMinionJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RecordMinionJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RecordMinionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RecordMinionJob job, EntityManager entityManager)
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

			public NativeParallelMultiHashMap<Entity, Entity> ownerToMinionMap;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, OwnerReferenceCD ownerReferenceCD)
			{
				if (ownerReferenceCD.owner != Entity.Null)
				{
					ownerToMinionMap.Add(ownerReferenceCD.owner, entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__OwnerReferenceCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, i));
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
							Execute(entity2, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, j));
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
						Execute(entity4, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, k));
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
		[WithAll(new Type[]
		{
			typeof(Simulate),
			typeof(TriggerSelectEnemyToAttackForMinionCommandCD),
			typeof(FactionCD)
		})]
		private struct SelectEnemyToAttackForMinionCommandJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<TriggerSelectEnemyToAttackForMinionCommandCD> __TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlacementIndicatorCD> __PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<CommandDataInterpolationDelay> __Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentTypeHandle;

					public ComponentTypeHandle<MinionCommandAttackTargetCD> __CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<TriggerSelectEnemyToAttackForMinionCommandCD>();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlacementIndicatorCD>(isReadOnly: true);
						__Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CommandDataInterpolationDelay>(isReadOnly: true);
						__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MinionCommandAttackTargetCD>();
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentTypeHandle.Update(ref state);
						__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle.Update(ref state);
						__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
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
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicatorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<CommandDataInterpolationDelay>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TriggerSelectEnemyToAttackForMinionCommandCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MinionCommandAttackTargetCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
				public void Run(ref SelectEnemyToAttackForMinionCommandJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SelectEnemyToAttackForMinionCommandJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SelectEnemyToAttackForMinionCommandJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SelectEnemyToAttackForMinionCommandJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SelectEnemyToAttackForMinionCommandJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SelectEnemyToAttackForMinionCommandJob job, EntityManager entityManager)
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

			public ComponentLookup<StateInfoCD> stateInfoLookup;

			public ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup;

			[ReadOnly]
			public ComponentLookup<DoorCD> doorLookup;

			[ReadOnly]
			public ComponentLookup<AffectObjectWhenMelodyPlayedCD> affectObjectWhenMelodyPlayedLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> factionLookup;

			[ReadOnly]
			public ComponentLookup<CattleCD> cattleLookup;

			[ReadOnly]
			public ComponentLookup<CritterCD> critterLookup;

			[ReadOnly]
			public ComponentLookup<MerchantCD> merchantLookup;

			[ReadOnly]
			public ComponentLookup<HealthCD> healthLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> useLagCompensationLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> simulateLookup;

			[ReadOnly]
			public ComponentLookup<EntityPartCD> entityPartLookup;

			[ReadOnly]
			public NativeParallelMultiHashMap<Entity, Entity>.ReadOnly ownerToMinionMap;

			[ReadOnly]
			public PhysicsWorldHistorySingleton physicsWorldHistorySingleton;

			[ReadOnly]
			public PhysicsWorld physicsWorld;

			[ReadOnly]
			public TileAccessor tileAccessor;

			[ReadOnly]
			public WorldInfoCD worldInfoCD;

			public NetworkTick currentTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, EnabledRefRW<TriggerSelectEnemyToAttackForMinionCommandCD> triggerSelectEnemyToAttackForMinionCD, in LocalTransform localTransform, in ClientInput clientInput, in PlacementIndicatorCD placementIndicatorCD, in CommandDataInterpolationDelay interpolationDelay, ref MinionCommandAttackTargetCD minionCommandAttackTargetCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				triggerSelectEnemyToAttackForMinionCD.ValueRW = false;
				float3 float5 = RangeWeaponSlot.CalculateAimMarkerTargetPosition(in localTransform.Position, in clientInput, 12f, in physicsWorld.CollisionWorld, placementIndicatorCD.relativePlayerPosition, in tileAccessor, raycastToTarget: false, doorLookup, affectObjectWhenMelodyPlayedLookup, mouseConfined: false);
				FactionCD factionCD = factionLookup[entity];
				Entity entity2 = CommandMinionUtility.GetClosestAttackTargetInArea(float5, in physicsWorldHistorySingleton, ref physicsWorld, currentTick, interpolationDelay, useLagCompensationLookup);
				if (entityPartLookup.TryGetComponent(entity2, out var componentData))
				{
					Entity mainEntity = componentData.mainEntity;
					if (mainEntity != Entity.Null)
					{
						entity2 = mainEntity;
					}
				}
				FactionCD componentData2;
				bool flag = factionLookup.TryGetComponent(entity2, out componentData2) && factionCD.CanAttack(componentData2, worldInfoCD) && healthLookup.HasComponent(entity2) && !cattleLookup.HasComponent(entity2) && !critterLookup.HasComponent(entity2) && !merchantLookup.HasComponent(entity2);
				if (entity2 == entity || !flag)
				{
					entity2 = Entity.Null;
				}
				minionCommandAttackTargetCD.target = entity2;
				minionCommandAttackTargetCD.position = float5.xz;
				minionCommandAttackTargetCD.isValidTarget = true;
				GhostEffectEventBuffer item;
				if (entity2 != Entity.Null)
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.MinionTargetFlash,
							localOnlyEffect = 1,
							entity = entity2
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
					DynamicBuffer<GhostEffectEventBuffer> buffer2 = ghostEffectEventBuffer;
					item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.CommandMinionAttackSound,
							localOnlyEffect = 1,
							position1 = float5
						}
					};
					buffer2.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
				else
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer3 = ghostEffectEventBuffer;
					item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.CommandMinionMoveArrow,
							localOnlyEffect = 1,
							position1 = float5
						}
					};
					buffer3.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
				if (ownerToMinionMap.TryGetFirstValue(entity, out var item2, out var it))
				{
					do
					{
						SetTargetForMinion(item2, entity2, float5.xz);
					}
					while (ownerToMinionMap.TryGetNextValue(out item2, ref it));
					return;
				}
				DynamicBuffer<GhostEffectEventBuffer> buffer4 = ghostEffectEventBuffer;
				item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						effectID = EffectID.Emote,
						entity = entity,
						localOnlyEffect = 1,
						value1 = 43
					}
				};
				buffer4.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}

			private void SetTargetForMinion(Entity minionEntity, Entity target, float2 position)
			{
				if (!simulateLookup.HasAndIsComponentEnabled(minionEntity))
				{
					return;
				}
				RefRW<StateInfoCD> refRWOptional = stateInfoLookup.GetRefRWOptional(minionEntity);
				RefRW<MoveToPositionFromCommandStateCD> refRWOptional2 = moveToPositionFromCommandStateLookup.GetRefRWOptional(minionEntity);
				if (refRWOptional.IsValid && refRWOptional2.IsValid)
				{
					ref StateInfoCD valueRW = ref refRWOptional.ValueRW;
					ref MoveToPositionFromCommandStateCD valueRW2 = ref refRWOptional2.ValueRW;
					if (valueRW.IsCurrentState(StateID.Chase) || valueRW.IsCurrentState(StateID.MoveToPositionFromCommand) || valueRW.IsCurrentState(StateID.PetWalk))
					{
						valueRW.LeaveState();
						valueRW.EnterState(StateID.Idle);
					}
					valueRW2.position = position;
					valueRW2.target = target;
					valueRW2.pendingMove = target == Entity.Null;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__TriggerSelectEnemyToAttackForMinionCommandCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlacementIndicator_PlacementIndicatorCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_CommandDataInterpolationDelay_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
						ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i);
						ref PlacementIndicatorCD placementIndicatorCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr4, i);
						ref CommandDataInterpolationDelay interpolationDelay = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CommandDataInterpolationDelay>(nativeArrayPtr5, i);
						ref MinionCommandAttackTargetCD minionCommandAttackTargetCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr6, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, i);
						Execute(entity, enabledMask.GetEnabledRefRW<TriggerSelectEnemyToAttackForMinionCommandCD>(i), in localTransform, in clientInput, in placementIndicatorCD, in interpolationDelay, ref minionCommandAttackTargetCD, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD);
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
							ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
							ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin);
							ref PlacementIndicatorCD placementIndicatorCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr4, nextRangeBegin);
							ref CommandDataInterpolationDelay interpolationDelay2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CommandDataInterpolationDelay>(nativeArrayPtr5, nextRangeBegin);
							ref MinionCommandAttackTargetCD minionCommandAttackTargetCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr6, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
							ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, nextRangeBegin);
							Execute(entity2, enabledMask.GetEnabledRefRW<TriggerSelectEnemyToAttackForMinionCommandCD>(nextRangeBegin), in localTransform2, in clientInput2, in placementIndicatorCD2, in interpolationDelay2, ref minionCommandAttackTargetCD2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2);
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
						ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
						ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j);
						ref PlacementIndicatorCD placementIndicatorCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr4, j);
						ref CommandDataInterpolationDelay interpolationDelay3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CommandDataInterpolationDelay>(nativeArrayPtr5, j);
						ref MinionCommandAttackTargetCD minionCommandAttackTargetCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr6, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, j);
						Execute(entity3, enabledMask.GetEnabledRefRW<TriggerSelectEnemyToAttackForMinionCommandCD>(j), in localTransform3, in clientInput3, in placementIndicatorCD3, in interpolationDelay3, ref minionCommandAttackTargetCD3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3);
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
						ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
						ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k);
						ref PlacementIndicatorCD placementIndicatorCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlacementIndicatorCD>(nativeArrayPtr4, k);
						ref CommandDataInterpolationDelay interpolationDelay4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CommandDataInterpolationDelay>(nativeArrayPtr5, k);
						ref MinionCommandAttackTargetCD minionCommandAttackTargetCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr6, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, k);
						Execute(entity4, enabledMask.GetEnabledRefRW<TriggerSelectEnemyToAttackForMinionCommandCD>(k), in localTransform4, in clientInput4, in placementIndicatorCD4, in interpolationDelay4, ref minionCommandAttackTargetCD4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4);
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
		[WithAll(new Type[]
		{
			typeof(Simulate),
			typeof(LocalTransform)
		})]
		private struct ClearTooFarAwayCommandMinionTargetJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<MinionCommandAttackTargetCD> __CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MinionCommandAttackTargetCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MinionCommandAttackTargetCD>();
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
				public void Run(ref ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ClearTooFarAwayCommandMinionTargetJob job, EntityManager entityManager)
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

			public ComponentLookup<LocalTransform> localTransformLookup;

			public ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup;

			[ReadOnly]
			public NativeParallelMultiHashMap<Entity, Entity>.ReadOnly ownerToMinionMap;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref MinionCommandAttackTargetCD minionCommandAttackTargetCD)
			{
				if (!minionCommandAttackTargetCD.isValidTarget)
				{
					return;
				}
				LocalTransform localTransform = localTransformLookup[entity];
				bool flag = false;
				if (minionCommandAttackTargetCD.target != Entity.Null)
				{
					if (!localTransformLookup.TryGetComponent(minionCommandAttackTargetCD.target, out var componentData) || math.length(localTransform.Position - componentData.Position) > 20f)
					{
						flag = true;
					}
				}
				else if (math.length(localTransform.Position.xz - minionCommandAttackTargetCD.position) > 20f)
				{
					flag = true;
				}
				if (!flag)
				{
					return;
				}
				minionCommandAttackTargetCD.isValidTarget = false;
				if (!ownerToMinionMap.TryGetFirstValue(entity, out var item, out var it))
				{
					return;
				}
				do
				{
					RefRW<MoveToPositionFromCommandStateCD> refRWOptional = moveToPositionFromCommandStateLookup.GetRefRWOptional(item);
					if (refRWOptional.IsValid)
					{
						ref MoveToPositionFromCommandStateCD valueRW = ref refRWOptional.ValueRW;
						valueRW.pendingMove = false;
						valueRW.target = Entity.Null;
					}
				}
				while (ownerToMinionMap.TryGetNextValue(out item, ref it));
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CommandMinion_MinionCommandAttackTargetCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr2, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr2, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCommandAttackTargetCD>(nativeArrayPtr2, k));
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
			public RecordMinionJob.InternalCompilerQueryAndHandleData __CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<StateInfoCD> __StateInfoCD_RW_ComponentLookup;

			public ComponentLookup<MoveToPositionFromCommandStateCD> __MoveToPositionFromCommandStateCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CritterCD> __CritterCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MerchantCD> __MerchantCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<UseLagCompensationCD> __UseLagCompensationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

			public SelectEnemyToAttackForMinionCommandJob.InternalCompilerQueryAndHandleData __CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			public ClearTooFarAwayCommandMinionTargetJob.InternalCompilerQueryAndHandleData __CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__StateInfoCD_RW_ComponentLookup = state.GetComponentLookup<StateInfoCD>();
				__MoveToPositionFromCommandStateCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPositionFromCommandStateCD>();
				__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
				__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup = state.GetComponentLookup<AffectObjectWhenMelodyPlayedCD>(isReadOnly: true);
				__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
				__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
				__CritterCD_RO_ComponentLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
				__MerchantCD_RO_ComponentLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
				__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
				__UseLagCompensationCD_RO_ComponentLookup = state.GetComponentLookup<UseLagCompensationCD>(isReadOnly: true);
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
				__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000000C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000000C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000000C_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000000D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000000D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000000D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_0000000E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_0000000E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000000E_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_743614882_0;

		private EntityQuery __query_743614882_1;

		private EntityQuery __query_743614882_2;

		private EntityQuery __query_743614882_3;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<PhysicsWorldHistorySingleton>();
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
			__query_743614882_0.TryGetSingleton<NetworkTime>(out var value);
			NativeParallelMultiHashMap<Entity, Entity> ownerToMinionMap = new NativeParallelMultiHashMap<Entity, Entity>(32, state.WorldUpdateAllocator);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RecordMinionJob
			{
				ownerToMinionMap = ownerToMinionMap
			}, __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new SelectEnemyToAttackForMinionCommandJob
			{
				stateInfoLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__StateInfoCD_RW_ComponentLookup, ref state),
				moveToPositionFromCommandStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPositionFromCommandStateCD_RW_ComponentLookup, ref state),
				doorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
				affectObjectWhenMelodyPlayedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
				critterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state),
				merchantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MerchantCD_RO_ComponentLookup, ref state),
				healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
				useLagCompensationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__UseLagCompensationCD_RO_ComponentLookup, ref state),
				simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
				entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
				ownerToMinionMap = ownerToMinionMap.AsReadOnly(),
				physicsWorldHistorySingleton = __query_743614882_1.GetSingleton<PhysicsWorldHistorySingleton>(),
				physicsWorld = __query_743614882_2.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
				tileAccessor = _tileAccessor,
				worldInfoCD = __query_743614882_3.GetSingleton<WorldInfoCD>(),
				currentTick = value.ServerTick
			}, __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			if (state.WorldUnmanaged.IsServer())
			{
				state.Dependency = __ScheduleViaJobChunkExtension_2(new ClearTooFarAwayCommandMinionTargetJob
				{
					localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
					moveToPositionFromCommandStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPositionFromCommandStateCD_RW_ComponentLookup, ref state),
					ownerToMinionMap = ownerToMinionMap.AsReadOnly()
				}, __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(RecordMinionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_RecordMinionJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(SelectEnemyToAttackForMinionCommandJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_SelectEnemyToAttackForMinionCommandJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(ClearTooFarAwayCommandMinionTargetJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__CommandMinion_SelectEnemyToAttackForMinionCommandSystem_ClearTooFarAwayCommandMinionTargetJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_743614882_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_743614882_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_743614882_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_743614882_3 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000000C_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000000D_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_0000000E_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((SelectEnemyToAttackForMinionCommandSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SelectEnemyToAttackForMinionCommandSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SelectEnemyToAttackForMinionCommandSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SelectEnemyToAttackForMinionCommandSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SelectEnemyToAttackForMinionCommandSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

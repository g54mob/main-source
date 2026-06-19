using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
using Pug.Automation;
using Pug.UnityExtensions;
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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforeUpdateStateSystemGroup))]
public struct PlayerVelocityCalculationSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct SetTargetMovementVelocityJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<PlayerMovementCD> __PlayerMovementCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<FishingStateCD> __PlayerState_FishingStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
					__PlayerMovementCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerMovementCD>();
					__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__PlayerState_FishingStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<FishingStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerMovementCD_RW_ComponentTypeHandle.Update(ref state);
					__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerState_FishingStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<FishingStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerMovementCD>();
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
			public void Run(ref SetTargetMovementVelocityJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetTargetMovementVelocityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetTargetMovementVelocityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetTargetMovementVelocityJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetTargetMovementVelocityJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetTargetMovementVelocityJob job, EntityManager entityManager)
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

		public NetworkTick currentTick;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in PlayerStateCD playerStateCD, ref PlayerMovementCD playerMovementCD, in ClientInput clientInput, in HealthCD healthCD, in FishingStateCD fishingStateCD)
		{
			float2 float5 = clientInput.movementDirection;
			if (math.length(float5) > 1f)
			{
				float5 = math.normalize(float5);
			}
			bool flag = (playerStateCD.HasAnyState(PlayerStateEnum.Fishing) && fishingStateCD.IsCasting(currentTick)) || playerStateCD.HasAnyState(PlayerStateEnum.SpawningFromCore | PlayerStateEnum.PlayingInstrument | PlayerStateEnum.IgnoreAllInput);
			bool flag2 = godModeLookup.IsComponentEnabled(entity);
			flag |= !flag2 && playerStateCD.HasAnyState(PlayerStateEnum.PlaceObject);
			bool num = healthCD.health <= 0;
			bool flag3 = playerStateCD.HasAnyState(PlayerStateEnum.Sleep) && EntityUtility.GetConditionValue(ConditionID.Sleeping, entity, summarizedConditionsLookup) != 0;
			if (!num && !flag3 && !flag)
			{
				playerMovementCD.targetMovementVelocity = float5;
			}
			else
			{
				playerMovementCD.targetMovementVelocity = float2.zero;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerMovementCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_FishingStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingStateCD>(nativeArrayPtr6, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingStateCD>(nativeArrayPtr6, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingStateCD>(nativeArrayPtr6, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingStateCD>(nativeArrayPtr6, k));
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
	private struct CalculateAdjustedMovementVelocityJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<PlayerMovementCD> __PlayerMovementCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<VelocityAffectedCD> __VelocityAffectedCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<CornerSmoothingCD> __CornerSmoothingCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EquipmentSlotConstantCD> __PlayerEquipment_EquipmentSlotConstantCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EquipmentSlotCD> __PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ControllingOtherEntityCD> __ControllingOtherEntityCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
					__PlayerMovementCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerMovementCD>();
					__VelocityAffectedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<VelocityAffectedCD>();
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					__CornerSmoothingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CornerSmoothingCD>(isReadOnly: true);
					__PlayerEquipment_EquipmentSlotConstantCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotConstantCD>(isReadOnly: true);
					__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
					__ControllingOtherEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ControllingOtherEntityCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerMovementCD_RW_ComponentTypeHandle.Update(ref state);
					__VelocityAffectedCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					__CornerSmoothingCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerEquipment_EquipmentSlotConstantCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle.Update(ref state);
					__ControllingOtherEntityCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CornerSmoothingCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotConstantCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentSlotCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ControllingOtherEntityCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerMovementCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<VelocityAffectedCD>();
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
			public void Run(ref CalculateAdjustedMovementVelocityJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CalculateAdjustedMovementVelocityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CalculateAdjustedMovementVelocityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CalculateAdjustedMovementVelocityJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CalculateAdjustedMovementVelocityJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CalculateAdjustedMovementVelocityJob job, EntityManager entityManager)
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
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		public bool simulationDisabled;

		public CollisionFilter velocityAffectorFilter;

		public CollisionFilter forceFromNearbyFilter;

		[ReadOnly]
		public TileAccessor tileAccessor;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup;

		public ComponentLookup<VelocityAffectorCD> velocityAffectorLookup;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> electricityLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectLookup;

		[ReadOnly]
		public ComponentLookup<AddForceToNearbyEntitiesCD> addForceToNearbyEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<BoatCD> boatLookup;

		[ReadOnly]
		public ComponentLookup<VehicleCD> vehicleLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		public ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public WorldInfoCD worldInfo;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in PlayerStateCD playerStateCD, ref PlayerMovementCD playerMovementCD, ref VelocityAffectedCD velocityAffectedCD, in DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffectsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> conditionsBuffer, in ClientInput clientInput, in CornerSmoothingCD cornerSmoothingCD, in EquipmentSlotConstantCD equipmentSlotConstantCD, in EquipmentSlotCD equipmentSlotCD, in ControllingOtherEntityCD controllingOtherEntityCD)
		{
			LocalTransform localTransform = localTransformLookup[entity];
			float2 targetMovementVelocity = playerMovementCD.targetMovementVelocity;
			float3 result = float3.zero;
			playerMovementCD.anyVelocityAffectorForce = float2.zero;
			bool flag = godModeLookup.IsComponentEnabled(entity);
			physicsWorldHistory.GetCollisionWorldFromTick(currentTick, 1u, ref physicsWorld, out var collWorld);
			bool flag2 = ShouldIncludeMovementSpeedAffections(in playerStateCD, flag);
			if (flag2)
			{
				PlayerControllerBurstedUtility.GetAnyVelocityAffectorForce(in localTransform.Position, ref velocityAffectedCD, in velocityAffectorFilter, in directionBasedOnVariationLookup, velocityAffectorLookup, in electricityLookup, in localTransformLookup, in objectLookup, moveToPredictedByCombatInteractionLookup, in simulateLookup, in collWorld, currentTick, out playerMovementCD.anyVelocityAffectorForce);
			}
			if (!playerStateCD.HasAnyState(PlayerStateEnum.MinecartRiding))
			{
				FactionCD factionCD = factionLookup[entity];
				PlayerControllerBurstedUtility.GetAnyForceFromNearbyEntity(in localTransform.Position, in forceFromNearbyFilter, in factionCD, in addForceToNearbyEntitiesLookup, in localTransformLookup, in factionLookup, in collWorld, in ownerLookup, in worldInfo, ref tileAccessor, currentTick, out result);
			}
			if (!(math.length(targetMovementVelocity) > 0.1f))
			{
				if (simulationDisabled || flag)
				{
					playerMovementCD.anyVelocityAffectorForce = float2.zero;
				}
				playerMovementCD.adjustedMovementVelocity = targetMovementVelocity + playerMovementCD.anyVelocityAffectorForce + result.ToFloat2();
				return;
			}
			if (flag2)
			{
				if (conditionEffectsBuffer[26].value > 0 || conditionEffectsBuffer[58].value > 0)
				{
					playerMovementCD.adjustedMovementVelocity = float2.zero;
					return;
				}
				float conditionsMovementSpeedMultiplier = PlayerController.GetConditionsMovementSpeedMultiplier(in conditionEffectsBuffer);
				targetMovementVelocity *= conditionsMovementSpeedMultiplier;
			}
			if (playerStateCD.HasAnyState(PlayerStateEnum.BoatRiding))
			{
				if (boatLookup.TryGetComponent(controllingOtherEntityCD.controlledEntity, out var componentData))
				{
					targetMovementVelocity *= componentData.speedMultiplier;
				}
				float num = 1f + (float)conditionsBuffer[182].value / 100f;
				targetMovementVelocity *= num;
			}
			if (playerStateCD.HasAnyState(PlayerStateEnum.VehicleRiding) && vehicleLookup.TryGetComponent(controllingOtherEntityCD.controlledEntity, out var componentData2))
			{
				targetMovementVelocity *= componentData2.speedMultiplier;
			}
			if (playerStateCD.HasNoneState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.VehicleRiding) && ((equipmentSlotCD.secondaryUse.hasSecondaryUse && equipmentSlotCD.windupTimer.isRunning) || equipmentSlotCD.warmupTimer.isRunning))
			{
				targetMovementVelocity *= equipmentSlotConstantCD.equipmentData.Value.GetEquipmentInfo(equipmentSlotCD.slotType).windupMoveSpeedMultiplier;
			}
			if (flag)
			{
				float num2 = (clientInput.IsButtonStateSet(CommandInputButtonStateNames.MoveFaster_HeldDown) ? 3f : 1f);
				playerMovementCD.adjustedMovementVelocity = targetMovementVelocity * num2;
			}
			else
			{
				playerMovementCD.adjustedMovementVelocity = PlayerController.GetCornerSmoothingFromVectorInternal(localTransform.Position, targetMovementVelocity.ToFloat3(), in collWorld, in cornerSmoothingCD, in playerStateCD).ToFloat2() + playerMovementCD.anyVelocityAffectorForce + result.ToFloat2();
			}
		}

		private bool ShouldIncludeMovementSpeedAffections(in PlayerStateCD playerStateCD, bool isGodMode)
		{
			if (playerStateCD.HasNoneState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding))
			{
				if (playerStateCD.HasAnyState(PlayerStateEnum.Walk))
				{
					if (!simulationDisabled)
					{
						return !isGodMode;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerMovementCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__VelocityAffectedCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CornerSmoothingCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotConstantCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerEquipment_EquipmentSlotCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ControllingOtherEntityCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VelocityAffectedCD>(nativeArrayPtr4, i), bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CornerSmoothingCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotConstantCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControllingOtherEntityCD>(nativeArrayPtr9, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VelocityAffectedCD>(nativeArrayPtr4, nextRangeBegin), bufferAccessor[nextRangeBegin], bufferAccessor2[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CornerSmoothingCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotConstantCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControllingOtherEntityCD>(nativeArrayPtr9, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VelocityAffectedCD>(nativeArrayPtr4, j), bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CornerSmoothingCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotConstantCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControllingOtherEntityCD>(nativeArrayPtr9, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VelocityAffectedCD>(nativeArrayPtr4, k), bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CornerSmoothingCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotConstantCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentSlotCD>(nativeArrayPtr8, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ControllingOtherEntityCD>(nativeArrayPtr9, k));
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
		public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		public SetTargetMovementVelocityJob.InternalCompilerQueryAndHandleData __PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

		public ComponentLookup<VelocityAffectorCD> __VelocityAffectorCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AddForceToNearbyEntitiesCD> __AddForceToNearbyEntitiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BoatCD> __BoatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<VehicleCD> __VehicleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		public ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> __MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

		public CalculateAdjustedMovementVelocityJob.InternalCompilerQueryAndHandleData __PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			__VelocityAffectorCD_RW_ComponentLookup = state.GetComponentLookup<VelocityAffectorCD>();
			__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__AddForceToNearbyEntitiesCD_RO_ComponentLookup = state.GetComponentLookup<AddForceToNearbyEntitiesCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__BoatCD_RO_ComponentLookup = state.GetComponentLookup<BoatCD>(isReadOnly: true);
			__VehicleCD_RO_ComponentLookup = state.GetComponentLookup<VehicleCD>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD>();
			__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00002D6E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00002D6E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00002D6E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00002D6F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002D6F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002D6F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStopRunning_00002D71_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00002D71_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00002D71_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private EntityQuery __query_506620920_0;

	private EntityQuery __query_506620920_1;

	private EntityQuery __query_506620920_2;

	private EntityQuery __query_506620920_3;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<PhysicsWorldHistorySingleton>();
		state.RequireForUpdate<WorldInfoCD>();
	}

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
		_tileAccessor.Update(ref state);
		__query_506620920_0.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		state.Dependency = __ScheduleViaJobChunkExtension_0(new SetTargetMovementVelocityJob
		{
			currentTick = serverTick,
			godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
			summarizedConditionsLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state)
		}, __TypeHandle.__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		WorldInfoCD singleton = __query_506620920_1.GetSingleton<WorldInfoCD>();
		state.Dependency = __ScheduleViaJobChunkExtension_1(new CalculateAdjustedMovementVelocityJob
		{
			physicsWorld = __query_506620920_2.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
			physicsWorldHistory = __query_506620920_3.GetSingleton<PhysicsWorldHistorySingleton>(),
			simulationDisabled = singleton.simulationDisabled,
			velocityAffectorFilter = PlayerControllerBurstableStatics.velocityAffectorFilter,
			forceFromNearbyFilter = PlayerControllerBurstableStatics.forceFromNearbyFilter,
			tileAccessor = _tileAccessor,
			directionBasedOnVariationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state),
			velocityAffectorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VelocityAffectorCD_RW_ComponentLookup, ref state),
			electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			objectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			addForceToNearbyEntitiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AddForceToNearbyEntitiesCD_RO_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			boatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BoatCD_RO_ComponentLookup, ref state),
			vehicleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VehicleCD_RO_ComponentLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
			moveToPredictedByCombatInteractionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentLookup, ref state),
			simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
			worldInfo = __query_506620920_1.GetSingleton<WorldInfoCD>(),
			currentTick = value.ServerTick
		}, __TypeHandle.__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SetTargetMovementVelocityJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PlayerVelocityCalculationSystem_SetTargetMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(CalculateAdjustedMovementVelocityJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PlayerVelocityCalculationSystem_CalculateAdjustedMovementVelocityJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_506620920_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_506620920_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_506620920_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_506620920_3 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00002D6E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002D6F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((PlayerVelocityCalculationSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00002D71_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PlayerVelocityCalculationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerVelocityCalculationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerVelocityCalculationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerVelocityCalculationSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}

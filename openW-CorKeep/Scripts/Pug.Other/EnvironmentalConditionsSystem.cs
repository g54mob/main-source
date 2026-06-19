using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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

[BurstCompile]
[UpdateInGroup(typeof(ConditionEffectsUpdateSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct EnvironmentalConditionsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(ConditionsBuffer)
	})]
	[WithNone(new Type[]
	{
		typeof(ProjectileCD),
		typeof(DestructibleObjectCD)
	})]
	private struct EnvironmentalConditionUpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectTypeCD> __ObjectTypeCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ObjectTypeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectTypeCD>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ObjectTypeCD_RO_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<ProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DestructibleObjectCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectTypeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionTickTimerBuffer>();
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
			public void Run(ref EnvironmentalConditionUpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref EnvironmentalConditionUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref EnvironmentalConditionUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref EnvironmentalConditionUpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref EnvironmentalConditionUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref EnvironmentalConditionUpdateJob job, EntityManager entityManager)
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

		public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<CantBeAttackedCD> cantBeAttackedLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> physicsColliderLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileCD> projectileLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

		[NativeDisableParallelForRestriction]
		public ComponentLookup<AffectedByAcidConditionCD> affectedByAcidConditionLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> surfacePriorityLookup;

		[NativeDisableParallelForRestriction]
		public ComponentLookup<AffectedBySlipperyMovementConditionCD> affectedBySlipperyMovementConditionLookup;

		[NativeDisableParallelForRestriction]
		public ComponentLookup<InfectedWithMoldConditionCD> infectedWithMoldConditionLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> playerStateLookup;

		[ReadOnly]
		public TileAccessor tileAccessor;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public ConditionsTableCD conditionsTableCD;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in ObjectTypeCD objectType, in DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer, in DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer)
		{
			PlayerStateCD componentData;
			bool flag = playerStateLookup.TryGetComponent(entity, out componentData);
			bool flag2 = entityDestroyedLookup.IsComponentEnabled(entity) || cantBeAttackedLookup.HasComponent(entity) || !physicsColliderLookup.HasComponent(entity) || disablePhysicsLookup.HasAndIsComponentEnabled(entity) || (flag && componentData.HasAnyState(PlayerStateEnum.Death)) || (flag && godModeLookup.HasAndIsComponentEnabled(entity));
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			bool flag10 = petLookup.HasComponent(entity) || minionLookup.HasComponent(entity);
			if (objectType.Value == ObjectType.PlaceablePrefab)
			{
				return;
			}
			if (!flag2)
			{
				int2 worldPosition = new int2((int)math.round(transform.Position.x), (int)math.round(transform.Position.z));
				TileCD top = tileAccessor.GetTop(worldPosition);
				if (top.tileType == TileType.groundSlime && !projectileLookup.HasComponent(entity) && !mortarProjectileLookup.HasComponent(entity))
				{
					flag3 = sumConditionsBuffer[20].value <= 0 && top.tileset != 10;
					if (!flag10 && top.tileset == 6 && sumConditionsBuffer[37].value <= 0)
					{
						flag4 = true;
					}
					else if (!flag10 && top.tileset == 8 && sumConditionEffectsBuffer[30].value == 0)
					{
						flag5 = true;
					}
					else if (top.tileset == 10 && sumConditionsBuffer[62].value == 0)
					{
						flag6 = true;
					}
					else if (!flag10 && top.tileset == 3 && sumConditionsBuffer[159].value == 0)
					{
						flag8 = true;
					}
					else if (!flag10 && top.tileset == 69 && sumConditionsBuffer[337].value == 0)
					{
						flag9 = true;
					}
				}
				if (sumConditionsBuffer[36].value <= 0 && tileAccessor.HasTypeAndTileset(worldPosition, TileType.ground, 9))
				{
					flag7 = true;
				}
			}
			if (flag3 || flag4 || flag5 || flag6 || flag8 || flag9)
			{
				int surfacePriorityFromJob = TileType.groundSlime.GetSurfacePriorityFromJob();
				NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(1, Allocator.Temp);
				RaycastInput input = new RaycastInput
				{
					Start = transform.Position,
					End = transform.Position,
					Filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 16384u
					}
				};
				if (collisionWorld.CastRay(input, ref allHits))
				{
					for (int i = 0; i < allHits.Length; i++)
					{
						if (surfacePriorityLookup.TryGetComponent(allHits[i].Entity, out var componentData2) && componentData2.Value > surfacePriorityFromJob)
						{
							flag3 = false;
							flag4 = false;
							flag5 = false;
							flag6 = false;
							flag8 = false;
							flag9 = false;
							break;
						}
					}
				}
				allHits.Dispose();
			}
			int value = sumConditionsBuffer[302].value;
			float num = 1f - (float)sumConditionsBuffer[227].value / 100f;
			int num2 = (int)math.round((float)(-(flag9 ? 300 : 500)) * num);
			if (flag3 && value != num2)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.SlowedByGroundSlime,
					value = num2
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
			}
			else if (!flag3 && sumConditionsBuffer[302].value != 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = conditionsBufferLookup[entity];
				EntityUtility.RemoveCondition(ConditionID.SlowedByGroundSlime, conditionsBuffer2);
			}
			if (flag4 && sumConditionsBuffer[17].value <= 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AcidDamage,
					value = 12
				}, conditionsBuffer3, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
				if (!affectedByAcidConditionLookup.IsComponentEnabled(entity))
				{
					affectedByAcidConditionLookup.SetComponentEnabled(entity, value: true);
					ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AcidDamage);
				}
			}
			else if (!flag4 && sumConditionsBuffer[17].value > 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = conditionsBufferLookup[entity];
				EntityUtility.RemoveCondition(ConditionID.AcidDamage, conditionsBuffer4);
				if (affectedByAcidConditionLookup.IsComponentEnabled(entity))
				{
					affectedByAcidConditionLookup.SetComponentEnabled(entity, value: false);
					ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.AcidDamage);
				}
			}
			if (flag5)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer5 = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.Poisoned,
					value = 1,
					duration = 15f
				}, conditionsBuffer5, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
			}
			else if (sumConditionEffectsBuffer[30].value > 0 && sumConditionsBuffer[14].value > 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer6 = conditionsBufferLookup[entity];
				EntityUtility.RemoveCondition(ConditionID.Poisoned, conditionsBuffer6);
			}
			if (flag6 && sumConditionsBuffer[64].value <= 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer7 = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.SlipperyMovementFromGround,
					value = 1
				}, conditionsBuffer7, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
				if (!affectedBySlipperyMovementConditionLookup.IsComponentEnabled(entity))
				{
					affectedBySlipperyMovementConditionLookup.SetComponentEnabled(entity, value: true);
				}
			}
			else if (!flag6 && sumConditionsBuffer[64].value > 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer8 = conditionsBufferLookup[entity];
				EntityUtility.RemoveCondition(ConditionID.SlipperyMovementFromGround, conditionsBuffer8);
			}
			if (flag8 && sumConditionsBuffer[29].value < 40)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer9 = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.Burning,
					value = 40,
					duration = 8.4f
				}, conditionsBuffer9, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
			}
			if (flag9)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer10 = conditionsBufferLookup[entity];
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.DrenchedInOil,
					value = 100,
					duration = 10f
				}, conditionsBuffer10, conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
			}
			if (flag7)
			{
				if (sumConditionsBuffer[35].value >= 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer11 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
					{
						conditionID = ConditionID.InfectedWithMold,
						value = -70,
						duration = 0f
					}, conditionsBuffer11, conditionsTableCD, currentTick, tickRate);
				}
				if (!infectedWithMoldConditionLookup.IsComponentEnabled(entity))
				{
					infectedWithMoldConditionLookup.SetComponentEnabled(entity, value: true);
					ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.InfectedWithMold);
				}
			}
			else if (sumConditionsBuffer[36].value > 0 && sumConditionsBuffer[35].value < 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer12 = conditionsBufferLookup[entity];
				EntityUtility.RemoveCondition(ConditionID.InfectedWithMold, conditionsBuffer12);
				if (infectedWithMoldConditionLookup.IsComponentEnabled(entity))
				{
					infectedWithMoldConditionLookup.SetComponentEnabled(entity, value: false);
					ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.InfectedWithMold);
				}
			}
			else if (sumConditionsBuffer[35].value < 0 && !infectedWithMoldConditionLookup.IsComponentEnabled(entity))
			{
				infectedWithMoldConditionLookup.SetComponentEnabled(entity, value: true);
				ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.InfectedWithMold);
			}
			bool flag11 = false;
			int value2 = sumConditionsBuffer[185].value;
			int value3 = sumConditionsBuffer[315].value;
			if (value2 > 0 || value3 > 0)
			{
				int2 int5 = new int2((int)math.round(transform.Position.x), (int)math.round(transform.Position.z));
				int num3 = 2;
				for (int j = -num3; j <= num3; j++)
				{
					for (int k = -num3; k <= num3; k++)
					{
						int2 worldPosition2 = int5 + new int2(j, k);
						if (tileAccessor.GetTop(worldPosition2).tileType == TileType.water)
						{
							flag11 = true;
							break;
						}
					}
					if (flag11)
					{
						break;
					}
				}
			}
			if (flag11)
			{
				if (value2 > 0 && sumConditionsBuffer[186].value <= 0)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.IncreasedArmorPercentageFromAdjacentWater,
						value = value2
					}, conditionsBufferLookup[entity], conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
				}
				if (value3 > 0 && sumConditionsBuffer[316].value <= 0)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.IncreasedMagicDamagePercentageFromAdjacentWater,
						value = value3
					}, conditionsBufferLookup[entity], conditionsTableCD, currentTick, tickRate, sumConditionsBuffer);
				}
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.IncreasedArmorPercentageFromAdjacentWater, conditionsBufferLookup[entity]);
				EntityUtility.RemoveCondition(ConditionID.IncreasedMagicDamagePercentageFromAdjacentWater, conditionsBufferLookup[entity]);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectTypeCD_RO_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					ref ObjectTypeCD objectType = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectTypeCD>(nativeArrayPtr3, i);
					DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer = bufferAccessor2[i];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor3[i];
					Execute(entity, in transform, in objectType, in sumConditionsBuffer, in sumConditionEffectsBuffer, ref conditionTickTimerBuffer);
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
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						ref ObjectTypeCD objectType2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectTypeCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer2 = bufferAccessor2[nextRangeBegin];
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor3[nextRangeBegin];
						Execute(entity2, in transform2, in objectType2, in sumConditionsBuffer2, in sumConditionEffectsBuffer2, ref conditionTickTimerBuffer2);
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
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					ref ObjectTypeCD objectType3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectTypeCD>(nativeArrayPtr3, j);
					DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer3 = bufferAccessor2[j];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor3[j];
					Execute(entity3, in transform3, in objectType3, in sumConditionsBuffer3, in sumConditionEffectsBuffer3, ref conditionTickTimerBuffer3);
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
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					ref ObjectTypeCD objectType4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectTypeCD>(nativeArrayPtr3, k);
					DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer4 = bufferAccessor2[k];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor3[k];
					Execute(entity4, in transform4, in objectType4, in sumConditionsBuffer4, in sumConditionEffectsBuffer4, ref conditionTickTimerBuffer4);
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
		public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CantBeAttackedCD> __CantBeAttackedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileCD> __ProjectileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RO_ComponentLookup;

		public ComponentLookup<AffectedByAcidConditionCD> __AffectedByAcidConditionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

		public ComponentLookup<AffectedBySlipperyMovementConditionCD> __AffectedBySlipperyMovementConditionCD_RW_ComponentLookup;

		public ComponentLookup<InfectedWithMoldConditionCD> __InfectedWithMoldConditionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

		public EnvironmentalConditionUpdateJob.InternalCompilerQueryAndHandleData __EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<ConditionsBuffer>();
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__CantBeAttackedCD_RO_ComponentLookup = state.GetComponentLookup<CantBeAttackedCD>(isReadOnly: true);
			__Unity_Physics_PhysicsCollider_RO_ComponentLookup = state.GetComponentLookup<PhysicsCollider>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
			__ProjectileCD_RO_ComponentLookup = state.GetComponentLookup<ProjectileCD>(isReadOnly: true);
			__MortarProjectileCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
			__AffectedByAcidConditionCD_RW_ComponentLookup = state.GetComponentLookup<AffectedByAcidConditionCD>();
			__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
			__AffectedBySlipperyMovementConditionCD_RW_ComponentLookup = state.GetComponentLookup<AffectedBySlipperyMovementConditionCD>();
			__InfectedWithMoldConditionCD_RW_ComponentLookup = state.GetComponentLookup<InfectedWithMoldConditionCD>();
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
			__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001421_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001421_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001421_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001422_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001422_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001422_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private ConditionsTableCD _conditionsTable;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_775809159_0;

	private EntityQuery __query_775809159_1;

	private EntityQuery __query_775809159_2;

	private EntityQuery __query_775809159_3;

	public void removeEnvironentalConditions(ref SystemState state)
	{
		_conditionsTable = __query_775809159_0.GetSingleton<ConditionsTableCD>();
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<WorldInfoCD>();
	}

	public void OnStartRunning(ref SystemState state)
	{
		_conditionsTable = __query_775809159_0.GetSingleton<ConditionsTableCD>();
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_775809159_1.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 5, 10f))
		{
			_tileAccessor.Update(ref state);
			if (!__query_775809159_2.TryGetSingleton<ClientServerTickRate>(out var value2))
			{
				value2.ResolveDefaults();
			}
			uint simulationTickRate = (uint)value2.SimulationTickRate;
			state.Dependency = __ScheduleViaJobChunkExtension_0(new EnvironmentalConditionUpdateJob
			{
				conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
				entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				cantBeAttackedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CantBeAttackedCD_RO_ComponentLookup, ref state),
				physicsColliderLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RO_ComponentLookup, ref state),
				disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state),
				petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
				minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref state),
				projectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileCD_RO_ComponentLookup, ref state),
				mortarProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileCD_RO_ComponentLookup, ref state),
				affectedByAcidConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectedByAcidConditionCD_RW_ComponentLookup, ref state),
				surfacePriorityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref state),
				affectedBySlipperyMovementConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectedBySlipperyMovementConditionCD_RW_ComponentLookup, ref state),
				infectedWithMoldConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InfectedWithMoldConditionCD_RW_ComponentLookup, ref state),
				playerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state),
				godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
				tileAccessor = _tileAccessor,
				collisionWorld = __query_775809159_3.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				conditionsTableCD = _conditionsTable,
				currentTick = value.ServerTick,
				tickRate = simulationTickRate
			}, __TypeHandle.__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(EnvironmentalConditionUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__EnvironmentalConditionsSystem_EnvironmentalConditionUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775809159_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775809159_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775809159_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775809159_3 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001421_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001422_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((EnvironmentalConditionsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((EnvironmentalConditionsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EnvironmentalConditionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentalConditionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentalConditionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

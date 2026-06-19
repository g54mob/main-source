using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

namespace ECS.Systems.Conditions
{
	[BurstCompile]
	[UpdateInGroup(typeof(ConditionEffectsUpdateSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct ModifyMaxHealthConditionsSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(Simulate),
			typeof(ConditionsBuffer)
		})]
		private struct ModifyHealthJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentCD> __EquipmentCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SkillBuffer> __SkillBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__EquipmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
						__PetOwnerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>();
						__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
						__SkillBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SkillBuffer>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__EquipmentCD_RO_ComponentTypeHandle.Update(ref state);
						__PetOwnerCD_RW_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
						__SkillBuffer_RO_BufferTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EquipmentCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SkillBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PetOwnerCD>();
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
				public void Run(ref ModifyHealthJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ModifyHealthJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ModifyHealthJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ModifyHealthJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ModifyHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ModifyHealthJob job, EntityManager entityManager)
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
			public ConditionsTableCD conditionsTableCD;

			public NetworkTick currentTick;

			public uint tickRate;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in EquipmentCD equipmentCD, PetOwnerCD petOwnerCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in DynamicBuffer<SkillBuffer> skillBuffer, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer)
			{
				int value = summarizedConditionsBuffer[115].value;
				int value2 = summarizedConditionsBuffer[116].value;
				if (value > 0)
				{
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < skillBuffer.Length; i++)
					{
						int value3 = skillBuffer[i].Value;
						num2 += SkillExtensions.GetLevelFromSkill((SkillID)i, value3);
					}
					num = (int)math.round((float)(num2 * value) / 100f);
					if (num != value2)
					{
						DynamicBuffer<ConditionsBuffer> conditionsBuffer = conditionsBufferLookup[entity];
						EntityUtility.AddOrRefreshCondition(new ConditionData
						{
							conditionID = ConditionID.IncreasedMaxHealthFromAllSkillPoints,
							value = num
						}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
					}
				}
				else if (value2 != 0 && value == 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.IncreasedMaxHealthFromAllSkillPoints, conditionsBuffer2);
				}
				int value4 = summarizedConditionsBuffer[240].value;
				int value5 = summarizedConditionsBuffer[241].value;
				ObjectID objectID = containedObjectsBuffer[petOwnerCD.SlotIndex].objectData.objectID;
				if (value4 > 0 && value5 != value4 && objectID != ObjectID.None)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.IncreasedMaxHealthFromPet,
						value = value4,
						duration = float.PositiveInfinity
					}, conditionsBuffer3, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value5 > 0 && (value4 <= 0 || objectID == ObjectID.None))
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.IncreasedMaxHealthFromPet, conditionsBuffer4);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquipmentCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PetOwnerCD_RW_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
				BufferAccessor<SkillBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SkillBuffer_RO_BufferTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref EquipmentCD equipmentCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, i);
						ref PetOwnerCD reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, i);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor[i];
						DynamicBuffer<SkillBuffer> skillBuffer = bufferAccessor2[i];
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = bufferAccessor3[i];
						Execute(entity, in equipmentCD, reference, in summarizedConditionsBuffer, in skillBuffer, in containedObjectsBuffer);
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
							ref EquipmentCD equipmentCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, nextRangeBegin);
							ref PetOwnerCD reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, nextRangeBegin);
							DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<SkillBuffer> skillBuffer2 = bufferAccessor2[nextRangeBegin];
							DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer2 = bufferAccessor3[nextRangeBegin];
							Execute(entity2, in equipmentCD2, reference2, in summarizedConditionsBuffer2, in skillBuffer2, in containedObjectsBuffer2);
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
						ref EquipmentCD equipmentCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, j);
						ref PetOwnerCD reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, j);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor[j];
						DynamicBuffer<SkillBuffer> skillBuffer3 = bufferAccessor2[j];
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer3 = bufferAccessor3[j];
						Execute(entity3, in equipmentCD3, reference3, in summarizedConditionsBuffer3, in skillBuffer3, in containedObjectsBuffer3);
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
						ref EquipmentCD equipmentCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr2, k);
						ref PetOwnerCD reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, k);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor[k];
						DynamicBuffer<SkillBuffer> skillBuffer4 = bufferAccessor2[k];
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer4 = bufferAccessor3[k];
						Execute(entity4, in equipmentCD4, reference4, in summarizedConditionsBuffer4, in skillBuffer4, in containedObjectsBuffer4);
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
			typeof(ConditionsBuffer)
		})]
		private struct GiveConditionsByHealthJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
						__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__HealthCD_RO_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ConditionsBuffer>();
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
				public void Run(ref GiveConditionsByHealthJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GiveConditionsByHealthJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GiveConditionsByHealthJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GiveConditionsByHealthJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GiveConditionsByHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GiveConditionsByHealthJob job, EntityManager entityManager)
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
			public ConditionsTableCD conditionsTableCD;

			public NetworkTick currentTick;

			public uint tickRate;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in HealthCD healthCD, in DynamicBuffer<SummarizedConditionEffectsBuffer> sumarizedConditionEffectsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
			{
				float num = (float)healthCD.health / (float)healthCD.GetMaxHealthWithConditions(sumarizedConditionEffectsBuffer);
				bool flag = num < 0.3f;
				bool flag2 = num >= 1f;
				int value = summarizedConditionsBuffer[109].value;
				int value2 = summarizedConditionsBuffer[110].value;
				if (flag2 && value != value2 && value > 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.DamageIncreaseAtMaxHealth,
						value = value,
						duration = 0f
					}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value2 != 0 && (!flag2 || value == 0))
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.DamageIncreaseAtMaxHealth, conditionsBuffer2);
				}
				int value3 = summarizedConditionsBuffer[111].value;
				int value4 = summarizedConditionsBuffer[112].value;
				if (flag && value3 != value4 && value3 > 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.DamageIncreaseAtLowHealth,
						value = value3,
						duration = 0f
					}, conditionsBuffer3, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value4 != 0 && (!flag || value3 == 0))
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.DamageIncreaseAtLowHealth, conditionsBuffer4);
				}
				int value5 = summarizedConditionsBuffer[124].value;
				int value6 = summarizedConditionsBuffer[125].value;
				if (flag && value5 != value6 && value5 > 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer5 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.IncreasedArmorFromLowHealth,
						value = value5,
						duration = 0f
					}, conditionsBuffer5, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value6 != 0 && (!flag || value5 == 0))
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer6 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.IncreasedArmorFromLowHealth, conditionsBuffer6);
				}
				int value7 = summarizedConditionsBuffer[106].value;
				int value8 = summarizedConditionsBuffer[107].value;
				bool flag3 = num < 0.5f;
				if (flag3 && value7 != value8 && value7 > 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer7 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.HealthRegenFromBeingBelowHalfHealth,
						value = value7,
						duration = 0f
					}, conditionsBuffer7, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value8 != 0 && (value7 == 0 || !flag3))
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer8 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.HealthRegenFromBeingBelowHalfHealth, conditionsBuffer8);
				}
				int num2 = (int)math.round((float)summarizedConditionsBuffer[171].value * (1f - num) * 1000f * 0.2f);
				int value9 = summarizedConditionsBuffer[172].value;
				if (num2 != value9 && num2 > 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer9 = conditionsBufferLookup[entity];
					EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
					{
						conditionID = ConditionID.AttackSpeedFromMissingHealth,
						value = num2,
						duration = 0f
					}, conditionsBuffer9, conditionsTableCD, currentTick, tickRate);
				}
				else if (value9 != 0 && num2 == 0)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer10 = conditionsBufferLookup[entity];
					EntityUtility.RemoveCondition(ConditionID.AttackSpeedFromMissingHealth, conditionsBuffer10);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i), bufferAccessor[i], bufferAccessor2[i]);
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin], bufferAccessor2[nextRangeBegin]);
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j), bufferAccessor[j], bufferAccessor2[j]);
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k), bufferAccessor[k], bufferAccessor2[k]);
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

			public ModifyHealthJob.InternalCompilerQueryAndHandleData __ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle;

			public GiveConditionsByHealthJob.InternalCompilerQueryAndHandleData __ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__ConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<ConditionsBuffer>();
				__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_000077F8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_000077F8_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000077F8_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_000077F9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000077F9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000077F9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1704626328_0;

		private EntityQuery __query_1704626328_1;

		private EntityQuery __query_1704626328_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<ConditionsTableCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1704626328_0.TryGetSingleton<NetworkTime>(out var value);
			if (VariableSystemUpdate.ShouldUpdate(ref state, value, 3, 3f))
			{
				if (!__query_1704626328_1.TryGetSingleton<ClientServerTickRate>(out var value2))
				{
					value2.ResolveDefaults();
				}
				uint simulationTickRate = (uint)value2.SimulationTickRate;
				state.Dependency = __ScheduleViaJobChunkExtension_0(new ModifyHealthJob
				{
					conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
					conditionsTableCD = __query_1704626328_2.GetSingleton<ConditionsTableCD>(),
					currentTick = value.ServerTick,
					tickRate = simulationTickRate
				}, __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				state.Dependency = __ScheduleViaJobChunkExtension_1(new GiveConditionsByHealthJob
				{
					conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
					conditionsTableCD = __query_1704626328_2.GetSingleton<ConditionsTableCD>(),
					currentTick = value.ServerTick,
					tickRate = simulationTickRate
				}, __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ModifyHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_ModifyHealthJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(GiveConditionsByHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__ECS_Systems_Conditions_ModifyMaxHealthConditionsSystem_GiveConditionsByHealthJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1704626328_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1704626328_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1704626328_2 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_000077F8_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000077F9_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ModifyMaxHealthConditionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ModifyMaxHealthConditionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ModifyMaxHealthConditionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

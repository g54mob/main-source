using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Affixes.Components;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

namespace Affixes.Systems
{
	[BurstCompile]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct AffixSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct InitializeAffixesJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<InitializedAffixesCD> __InitializedAffixesCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<DefaultSupportedAffixesBuffer> __Affixes_Components_DefaultSupportedAffixesBuffer_RO_BufferTypeHandle;

					public BufferTypeHandle<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__InitializedAffixesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InitializedAffixesCD>();
						__Affixes_Components_DefaultSupportedAffixesBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DefaultSupportedAffixesBuffer>(isReadOnly: true);
						__ActiveAffixConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixConditionsBuffer>();
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					}

					public void Update(ref SystemState state)
					{
						__InitializedAffixesCD_RW_ComponentTypeHandle.Update(ref state);
						__Affixes_Components_DefaultSupportedAffixesBuffer_RO_BufferTypeHandle.Update(ref state);
						__ActiveAffixConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DefaultSupportedAffixesBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<InitializedAffixesCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ActiveAffixConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
				public void Run(ref InitializeAffixesJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref InitializeAffixesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref InitializeAffixesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref InitializeAffixesJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref InitializeAffixesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref InitializeAffixesJob job, EntityManager entityManager)
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

			private void Execute(EnabledRefRW<InitializedAffixesCD> initializeAffixesEnabledRefRW, in DynamicBuffer<DefaultSupportedAffixesBuffer> defaultSupportedAffixesBuffer, ref DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer, ref RandomCD randomCD)
			{
				initializeAffixesEnabledRefRW.ValueRW = false;
				if (defaultSupportedAffixesBuffer.Length != 0 && activeAffixConditionsBuffer.Length <= 0)
				{
					DefaultSupportedAffixesBuffer defaultSupportedAffixesBuffer2 = defaultSupportedAffixesBuffer[randomCD.Value.NextInt(0, defaultSupportedAffixesBuffer.Length)];
					activeAffixConditionsBuffer.Add(new ActiveAffixConditionsBuffer
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)defaultSupportedAffixesBuffer2.affixID,
							value = 1,
							duration = -1f
						}
					});
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__InitializedAffixesCD_RW_ComponentTypeHandle);
				BufferAccessor<DefaultSupportedAffixesBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Affixes_Components_DefaultSupportedAffixesBuffer_RO_BufferTypeHandle);
				BufferAccessor<ActiveAffixConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ActiveAffixConditionsBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						DynamicBuffer<DefaultSupportedAffixesBuffer> defaultSupportedAffixesBuffer = bufferAccessor[i];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer = bufferAccessor2[i];
						ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr, i);
						Execute(enabledMask.GetEnabledRefRW<InitializedAffixesCD>(i), in defaultSupportedAffixesBuffer, ref activeAffixConditionsBuffer, ref randomCD);
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
							DynamicBuffer<DefaultSupportedAffixesBuffer> defaultSupportedAffixesBuffer2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer2 = bufferAccessor2[nextRangeBegin];
							ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr, nextRangeBegin);
							Execute(enabledMask.GetEnabledRefRW<InitializedAffixesCD>(nextRangeBegin), in defaultSupportedAffixesBuffer2, ref activeAffixConditionsBuffer2, ref randomCD2);
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
						DynamicBuffer<DefaultSupportedAffixesBuffer> defaultSupportedAffixesBuffer3 = bufferAccessor[j];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer3 = bufferAccessor2[j];
						ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr, j);
						Execute(enabledMask.GetEnabledRefRW<InitializedAffixesCD>(j), in defaultSupportedAffixesBuffer3, ref activeAffixConditionsBuffer3, ref randomCD3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						DynamicBuffer<DefaultSupportedAffixesBuffer> defaultSupportedAffixesBuffer4 = bufferAccessor[k];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer4 = bufferAccessor2[k];
						ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr, k);
						Execute(enabledMask.GetEnabledRefRW<InitializedAffixesCD>(k), in defaultSupportedAffixesBuffer4, ref activeAffixConditionsBuffer4, ref randomCD4);
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
		[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
		private struct AffixJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					public BufferTypeHandle<ActiveAffixStateBuffer> __Affixes_Components_ActiveAffixStateBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RO_BufferTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<FactionCD> __FactionCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<IsInCombatCD> __IsInCombatCD_RO_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Affixes_Components_ActiveAffixStateBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixStateBuffer>();
						__ActiveAffixConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixConditionsBuffer>(isReadOnly: true);
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
						__FactionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<FactionCD>(isReadOnly: true);
						__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
						__IsInCombatCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsInCombatCD>(isReadOnly: true);
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Affixes_Components_ActiveAffixStateBuffer_RW_BufferTypeHandle.Update(ref state);
						__ActiveAffixConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
						__FactionCD_RO_ComponentTypeHandle.Update(ref state);
						__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
						__IsInCombatCD_RO_ComponentTypeHandle.Update(ref state);
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
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ActiveAffixConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ActiveAffixStateBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
				public void Run(ref AffixJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref AffixJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref AffixJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref AffixJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref AffixJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref AffixJob job, EntityManager entityManager)
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

			public TileAccessor tileAccessor;

			[ReadOnly]
			public ComponentLookup<ElectricOrbCD> electricOrbLookup;

			[ReadOnly]
			public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

			[ReadOnly]
			public NativeList<LocalTransform> playerPositions;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public EntityCommandBuffer ecb;

			public NetworkTick currentTick;

			public uint tickRate;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in LocalTransform localTransform, ref DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer, in DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer, ref RandomCD randomCD, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, in IsInCombatCD isInCombatCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				EnsureStateBufferSize(ref activeAffixStateBuffer, in activeAffixConditionsBuffer);
				float3 enemyPosition = localTransform.Position;
				for (int i = 0; i < activeAffixConditionsBuffer.Length; i++)
				{
					ActiveAffixConditionsBuffer activeAffixConditionsBuffer2 = activeAffixConditionsBuffer[i];
					ref ActiveAffixStateBuffer affixState = ref activeAffixStateBuffer.ElementAt(i);
					UpdateAffixState(entity, (AffixID)activeAffixConditionsBuffer2.conditionData.conditionID, ref affixState, in enemyPosition, in factionCD, in behaviourTagsCD, ref randomCD, in isInCombatCD, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD);
				}
			}

			private void EnsureStateBufferSize(ref DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer, in DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer)
			{
				if (activeAffixStateBuffer.Length < activeAffixConditionsBuffer.Length)
				{
					for (int i = activeAffixStateBuffer.Length; i < activeAffixConditionsBuffer.Length; i++)
					{
						activeAffixStateBuffer.Add(default(ActiveAffixStateBuffer));
					}
				}
			}

			private void UpdateAffixState(Entity entity, AffixID affixConditionID, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, ref RandomCD randomCD, in IsInCombatCD isInCombatCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				switch (affixState.state)
				{
				case AffixState.Inactive:
					Initialize(affixConditionID, ref affixState, in enemyPosition, ref randomCD);
					break;
				case AffixState.Active:
					UpdateActive(entity, affixConditionID, ref affixState, in enemyPosition, in factionCD, in behaviourTagsCD, ref randomCD, in isInCombatCD, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD);
					break;
				case AffixState.Cooldown:
					UpdateCooldown(affixConditionID, ref affixState, in enemyPosition);
					break;
				}
			}

			private void Initialize(AffixID affixConditionID, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, ref RandomCD randomCD)
			{
				affixState.state = AffixState.Cooldown;
				float seconds = randomCD.Value.NextFloat(2f, 4f);
				affixState.cooldownTimer.Start(currentTick, seconds, tickRate);
			}

			private void UpdateActive(Entity entity, AffixID affixConditionID, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, ref RandomCD randomCD, in IsInCombatCD isInCombatCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				if (!isInCombatCD.isInCombat)
				{
					float seconds = randomCD.Value.NextFloat(2f, 4f);
					affixState.cooldownTimer.Start(currentTick, seconds, tickRate);
					return;
				}
				bool spawnedEffect = false;
				switch (affixConditionID)
				{
				case AffixID.AffixElectricOrb:
					UpdateElectricOrb(entity, ref affixState, in enemyPosition, in factionCD, in behaviourTagsCD, ref randomCD, ref spawnedEffect);
					break;
				case AffixID.AffixArcaneBeam:
					UpdateArcaneBeam(entity, ref affixState, in enemyPosition, in factionCD, in behaviourTagsCD, ref randomCD, ref spawnedEffect);
					break;
				case AffixID.AffixFireBomb:
					UpdateFireBomb(entity, ref affixState, in enemyPosition, in factionCD, in behaviourTagsCD, ref randomCD, ref spawnedEffect);
					break;
				}
				if (spawnedEffect)
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						value = new EffectEventCD
						{
							effectID = EffectID.AffixActivated,
							value1 = (int)affixConditionID
						},
						Tick = currentTick
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
			}

			private void UpdateElectricOrb(Entity entity, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, ref RandomCD randomCD, ref bool spawnedEffect)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.AffixElectricOrb, databaseBankCD.databaseBankBlob);
				electricOrbLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
				if (!TryGetSpawnPositionNearbyPlayer(out var spawnPos, in enemyPosition, ref randomCD, new float2(0.5f, 1f)))
				{
					float seconds = randomCD.Value.NextFloat(2f, 4f);
					affixState.cooldownTimer.Start(currentTick, seconds, tickRate);
					return;
				}
				affixState.state = AffixState.Cooldown;
				float seconds2 = componentData.VisibleFullDuration * 0.5f + randomCD.Value.NextFloat(2f, 4f);
				affixState.cooldownTimer.Start(currentTick, seconds2, tickRate);
				float3 v257 = randomCD.Value.NextFloat2Direction().ToFloat3();
				int num = 3;
				float num2 = 0.25f;
				float num3 = MathF.PI * 2f / (float)num;
				for (int i = 0; i < num; i++)
				{
					float3 float5 = math.normalizesafe(math.mul(quaternion.RotateY((float)i * num3), v257).ToFloat2()).ToFloat3();
					float3 float6 = spawnPos + float5 * num2;
					if (!tileAccessor.GetTop(float6.RoundToInt2()).tileType.IsBlockingTile(includeLowColliders: false))
					{
						Entity entity2 = EntityUtility.CreateEntity(ecb, float6, ObjectID.AffixElectricOrb, 1, databaseBankCD.databaseBankBlob);
						ecb.SetComponent(entity2, new DirectionCD
						{
							direction = float5
						});
						EntityUtility.InheritFaction(ecb, entity, entity2, in factionCD);
						ecb.SetComponent(entity2, behaviourTagsCD);
						ecb.SetComponent(entity2, new OwnerReferenceCD
						{
							owner = entity
						});
						if (spawnedEffect)
						{
							ecb.SetComponent(entity2, new AffixCD
							{
								dispalyConnectionToOwner = false
							});
						}
						spawnedEffect = true;
					}
				}
			}

			private void UpdateArcaneBeam(Entity entity, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, ref RandomCD randomCD, ref bool spawnedEffect)
			{
				affixState.state = AffixState.Cooldown;
				if (!TryGetSpawnPositionNearbyPlayer(out var spawnPos, in enemyPosition, ref randomCD, new float2(0.5f, 1f)))
				{
					float seconds = randomCD.Value.NextFloat(2f, 4f);
					affixState.cooldownTimer.Start(currentTick, seconds, tickRate);
					return;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.AffixArcaneBeam, databaseBankCD.databaseBankBlob);
				destroyTimerLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
				float seconds2 = NetworkTimeUtilities.TicksToSeconds(componentData.timer.targetTicks, tickRate) * 0.5f + randomCD.Value.NextFloat(2f, 4f);
				affixState.cooldownTimer.Start(currentTick, seconds2, tickRate);
				Entity entity2 = EntityUtility.CreateEntity(ecb, spawnPos, ObjectID.AffixArcaneBeam, 1, databaseBankCD.databaseBankBlob);
				EntityUtility.InheritFaction(ecb, entity, entity2, in factionCD);
				ecb.SetComponent(entity2, behaviourTagsCD);
				ecb.SetComponent(entity2, new OwnerReferenceCD
				{
					owner = entity
				});
				spawnedEffect = true;
			}

			private bool TryGetSpawnPositionNearbyPlayer(out float3 spawnPos, in float3 enemyPosition, ref RandomCD randomCD, float2 minMaxAlphaForDistanceToPlayer)
			{
				float3 float5 = float3.zero;
				float num = 15f;
				foreach (LocalTransform playerPosition in playerPositions)
				{
					float num2 = math.distance(enemyPosition, playerPosition.Position);
					if (num2 < num)
					{
						num = num2;
						float5 = playerPosition.Position;
					}
				}
				if (math.abs(num - 15f) < 1.1920929E-07f)
				{
					float3 float6 = randomCD.Value.NextFloat2Direction().ToFloat3();
					float5 = enemyPosition + float6 * randomCD.Value.NextFloat(1f, 5f);
				}
				float3 float7 = float5 - enemyPosition;
				int num3 = 10;
				while (num3 > 0)
				{
					num3--;
					float num4 = 1f - randomCD.Value.NextFloat(minMaxAlphaForDistanceToPlayer.x, minMaxAlphaForDistanceToPlayer.y);
					num4 *= num4;
					num4 = math.clamp(1f - num4, 0f, 1f);
					float3 float8 = enemyPosition + float7 * num4;
					if (!tileAccessor.GetTop(float8.RoundToInt2()).tileType.IsBlockingTile(includeLowColliders: false))
					{
						spawnPos = float8;
						return true;
					}
				}
				spawnPos = default(float3);
				return false;
			}

			private void UpdateFireBomb(Entity entity, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition, in FactionCD factionCD, in BehaviourTagsCD behaviourTagsCD, ref RandomCD randomCD, ref bool spawnedEffect)
			{
				affixState.state = AffixState.Cooldown;
				if (!TryGetSpawnPositionNearbyPlayer(out var spawnPos, in enemyPosition, ref randomCD, new float2(0.7f, 1f)))
				{
					float seconds = randomCD.Value.NextFloat(2f, 4f);
					affixState.cooldownTimer.Start(currentTick, seconds, tickRate);
					return;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.AffixFireBomb, databaseBankCD.databaseBankBlob);
				destroyTimerLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
				float seconds2 = NetworkTimeUtilities.TicksToSeconds(componentData.timer.targetTicks, tickRate) * 0.5f + randomCD.Value.NextFloat(2f, 4f);
				affixState.cooldownTimer.Start(currentTick, seconds2, tickRate);
				Entity entity2 = EntityUtility.CreateEntity(ecb, spawnPos, ObjectID.AffixFireBomb, 1, databaseBankCD.databaseBankBlob);
				EntityUtility.InheritFaction(ecb, entity, entity2, in factionCD);
				ecb.SetComponent(entity2, behaviourTagsCD);
				ecb.SetComponent(entity2, new OwnerReferenceCD
				{
					owner = entity
				});
				spawnedEffect = true;
			}

			private void UpdateCooldown(AffixID affixConditionID, ref ActiveAffixStateBuffer affixState, in float3 enemyPosition)
			{
				if (!affixState.cooldownTimer.isRunning || affixState.cooldownTimer.IsTimerElapsed(currentTick))
				{
					affixState.state = AffixState.Active;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				BufferAccessor<ActiveAffixStateBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Affixes_Components_ActiveAffixStateBuffer_RW_BufferTypeHandle);
				BufferAccessor<ActiveAffixConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ActiveAffixConditionsBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__FactionCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__IsInCombatCD_RO_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
						DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer = bufferAccessor[i];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer = bufferAccessor2[i];
						ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, i);
						ref FactionCD factionCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr4, i);
						ref BehaviourTagsCD behaviourTagsCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i);
						ref IsInCombatCD isInCombatCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr6, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor3[i];
						Execute(entity, in localTransform, ref activeAffixStateBuffer, in activeAffixConditionsBuffer, ref randomCD, in factionCD, in behaviourTagsCD, in isInCombatCD, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, i));
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
							DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer2 = bufferAccessor2[nextRangeBegin];
							ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, nextRangeBegin);
							ref FactionCD factionCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr4, nextRangeBegin);
							ref BehaviourTagsCD behaviourTagsCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, nextRangeBegin);
							ref IsInCombatCD isInCombatCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr6, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor3[nextRangeBegin];
							Execute(entity2, in localTransform2, ref activeAffixStateBuffer2, in activeAffixConditionsBuffer2, ref randomCD2, in factionCD2, in behaviourTagsCD2, in isInCombatCD2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, nextRangeBegin));
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
						DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer3 = bufferAccessor[j];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer3 = bufferAccessor2[j];
						ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, j);
						ref FactionCD factionCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr4, j);
						ref BehaviourTagsCD behaviourTagsCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j);
						ref IsInCombatCD isInCombatCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr6, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor3[j];
						Execute(entity3, in localTransform3, ref activeAffixStateBuffer3, in activeAffixConditionsBuffer3, ref randomCD3, in factionCD3, in behaviourTagsCD3, in isInCombatCD3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, j));
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
						DynamicBuffer<ActiveAffixStateBuffer> activeAffixStateBuffer4 = bufferAccessor[k];
						DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixConditionsBuffer4 = bufferAccessor2[k];
						ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, k);
						ref FactionCD factionCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr4, k);
						ref BehaviourTagsCD behaviourTagsCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k);
						ref IsInCombatCD isInCombatCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr6, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor3[k];
						Execute(entity4, in localTransform4, ref activeAffixStateBuffer4, in activeAffixConditionsBuffer4, ref randomCD4, in factionCD4, in behaviourTagsCD4, in isInCombatCD4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr7, k));
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
			public InitializeAffixesJob.InternalCompilerQueryAndHandleData __Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricOrbCD> __ElectricOrbCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

			public AffixJob.InternalCompilerQueryAndHandleData __Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__ElectricOrbCD_RO_ComponentLookup = state.GetComponentLookup<ElectricOrbCD>(isReadOnly: true);
				__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
				__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000000B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000000B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000000B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000000C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000000C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000000C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private const float INITIAL_SPAWN_DELAY_MIN = 2f;

		private const float INITIAL_SPAWN_DELAY_MAX = 4f;

		private const float COOLDOWN_SINCE_PREVIOUS_MIN = 2f;

		private const float COOLDOWN_SINCE_PREVIOUS_MAX = 4f;

		private const float COOLDOWN_PREVIOUS_USAGE_PERCENTAGE = 0.5f;

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1751997442_0;

		private EntityQuery __query_1751997442_1;

		private EntityQuery __query_1751997442_2;

		private EntityQuery __query_1751997442_3;

		private EntityQuery __query_1751997442_4;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<ClientServerTickRate>();
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
			BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_1751997442_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
			__query_1751997442_2.TryGetSingleton<NetworkTime>(out var value);
			JobHandle job = __ScheduleViaJobChunkExtension_0(default(InitializeAffixesJob), __TypeHandle.__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			EntityQuery _query_1751997442_ = __query_1751997442_0;
			JobHandle outJobHandle;
			NativeList<LocalTransform> playerPositions = _query_1751997442_.ToComponentDataListAsync<LocalTransform>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
			JobHandle dependency = JobHandle.CombineDependencies(job, outJobHandle);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new AffixJob
			{
				tileAccessor = _tileAccessor,
				electricOrbLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ElectricOrbCD_RO_ComponentLookup, ref state),
				destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
				playerPositions = playerPositions,
				databaseBankCD = __query_1751997442_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
				ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
				currentTick = value.ServerTick,
				tickRate = (uint)__query_1751997442_4.GetSingleton<ClientServerTickRate>().SimulationTickRate
			}, __TypeHandle.__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(InitializeAffixesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Affixes_Systems_AffixSystem_InitializeAffixesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(AffixJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Affixes_Systems_AffixSystem_AffixJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost, LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<DisablePhysicsCD>();
			__query_1751997442_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1751997442_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1751997442_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1751997442_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1751997442_4 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000000B_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000000C_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((AffixSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((AffixSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((AffixSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((AffixSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((AffixSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
[UpdateBefore(typeof(TileDamageSystem))]
[UpdateBefore(typeof(ConditionEffectsUpdateSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct MortarProjectileSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(LocalTransform)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct MortarStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<MortarProjectileCD> __MortarProjectileCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MortarProjectileCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MortarProjectileCD>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MortarProjectileCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MortarProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
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
			public void Run(ref MortarStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MortarStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MortarStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MortarStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MortarStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MortarStateJob job, EntityManager entityManager)
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
		public ComponentLookup<FactionCD> factionLookup;

		public ComponentLookup<MortarProjectileEffectTriggerCD> mortarProjectileEffectTriggerLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public Entity tileUpdateBufferSingleton;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public WorldInfoCD worldInfoCD;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref MortarProjectileCD mortarProjectileCD, ref HealthCD healthCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref LocalTransform localTransform)
		{
			if (mortarProjectileEffectTriggerLookup.IsComponentEnabled(entity))
			{
				mortarProjectileEffectTriggerLookup.SetComponentEnabled(entity, value: false);
			}
			if (healthCD.health > 0)
			{
				factionLookup.TryGetComponent(entity, out var componentData);
				if (!worldInfoCD.IsWorldModeEnabled(WorldMode.Creative) && componentData.originalFaction != FactionID.Player && math.lengthsq(localTransform.Position) < 9f)
				{
					healthCD.health = 0;
				}
				else if (mortarProjectileCD.internalState == MortarProjectileState.Initialize)
				{
					Initialize(ref mortarProjectileCD, animationBuffer, ref animationBufferPointer);
				}
				else if (mortarProjectileCD.internalState == MortarProjectileState.GoUp)
				{
					GoUpUpdate(ref mortarProjectileCD, ref localTransform, animationBuffer, ref animationBufferPointer);
				}
				else if (mortarProjectileCD.internalState == MortarProjectileState.Airborne)
				{
					AirborneUpdate(ref mortarProjectileCD, in localTransform, animationBuffer, ref animationBufferPointer);
				}
				else if (mortarProjectileCD.internalState == MortarProjectileState.GoDown)
				{
					GoDownUpdate(entity, ref mortarProjectileCD, in localTransform, animationBuffer, ref animationBufferPointer);
				}
				else if (mortarProjectileCD.internalState == MortarProjectileState.Explode)
				{
					ExplodeUpdate(ref mortarProjectileCD, ref healthCD);
				}
			}
		}

		private void Initialize(ref MortarProjectileCD mortarProjectileCD, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			mortarProjectileCD.timer.Start(currentTick, mortarProjectileCD.goUpTime, tickRate);
			mortarProjectileCD.internalState = MortarProjectileState.GoUp;
			AnimationUtilities.TriggerAnimation(1408713878, currentTick, animationBuffer, ref animationBufferPointer);
		}

		private void GoUpUpdate(ref MortarProjectileCD mortarProjectileCD, ref LocalTransform localTransform, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (mortarProjectileCD.timer.IsTimerElapsed(currentTick))
			{
				localTransform = LocalTransform.FromPosition(mortarProjectileCD.targetPosition);
				mortarProjectileCD.timer.Start(currentTick, mortarProjectileCD.airTime, tickRate);
				mortarProjectileCD.internalState = MortarProjectileState.Airborne;
				AnimationUtilities.TriggerAnimation(-225098472, currentTick, animationBuffer, ref animationBufferPointer);
			}
		}

		private void AirborneUpdate(ref MortarProjectileCD mortarProjectileCD, in LocalTransform localTransform, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (!mortarProjectileCD.timer.IsTimerElapsed(currentTick))
			{
				return;
			}
			mortarProjectileCD.timer.Start(currentTick, mortarProjectileCD.goDownTime, tickRate);
			mortarProjectileCD.internalState = MortarProjectileState.GoDown;
			AnimationUtilities.TriggerAnimation(584621764, currentTick, animationBuffer, ref animationBufferPointer);
			if (!mortarProjectileCD.spawnTilesOnGoingDown)
			{
				return;
			}
			DynamicBuffer<TileUpdateBuffer> dynamicBuffer = tileUpdateBufferLookup[tileUpdateBufferSingleton];
			float2 y = new float2(localTransform.Position.x, localTransform.Position.z);
			int2 int5 = localTransform.Position.RoundToInt2();
			int num = (int)math.ceil(mortarProjectileCD.radius + mortarProjectileCD.spawnTilesOnGoingDownExtraRadius);
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					int2 int6 = int5 + new int2(i, j);
					if (math.length(int6) > 1.5f && math.distance(int6, y) <= mortarProjectileCD.radius + mortarProjectileCD.spawnTilesOnGoingDownExtraRadius && (tileAccessor.HasType(int6, TileType.ground) || (mortarProjectileCD.canSpawnTilesOnWaterOrPits && (tileAccessor.GetTopType(int6) == TileType.water || tileAccessor.GetTopType(int6) == TileType.pit))) && !PositionIsBlocked(collisionWorld, new float3(int6.x, 0f, int6.y), 0.49f, mortarProjectileCD.canSpawnTilesOnWaterOrPits))
					{
						dynamicBuffer.Add(new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Add,
							position = int6,
							tile = new TileCD
							{
								tileset = (int)mortarProjectileCD.tilesetToSpawnOnGoingDown,
								tileType = mortarProjectileCD.tileTypeToSpawnOnGoingDown
							}
						});
					}
				}
			}
		}

		private void GoDownUpdate(Entity entity, ref MortarProjectileCD mortarProjectileCD, in LocalTransform localTransform, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (mortarProjectileCD.timer.IsTimerElapsed(currentTick))
			{
				mortarProjectileCD.timer.Start(currentTick, mortarProjectileCD.explodeTime, tickRate);
				mortarProjectileCD.internalState = MortarProjectileState.Explode;
				AnimationUtilities.TriggerAnimation(1416834189, currentTick, animationBuffer, ref animationBufferPointer);
				mortarProjectileEffectTriggerLookup.SetComponentEnabled(entity, value: true);
			}
		}

		private void ExplodeUpdate(ref MortarProjectileCD mortarProjectileCD, ref HealthCD healthCD)
		{
			if (mortarProjectileCD.timer.IsTimerElapsed(currentTick))
			{
				healthCD.health = 0;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MortarProjectileCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref MortarProjectileCD mortarProjectileCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr2, i);
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref mortarProjectileCD, ref healthCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i));
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
						ref MortarProjectileCD mortarProjectileCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr2, nextRangeBegin);
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref mortarProjectileCD2, ref healthCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin));
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
					ref MortarProjectileCD mortarProjectileCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr2, j);
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref mortarProjectileCD3, ref healthCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j));
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
					ref MortarProjectileCD mortarProjectileCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr2, k);
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref mortarProjectileCD4, ref healthCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k));
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
	[WithChangeFilter(new Type[] { typeof(MortarProjectileEffectTriggerCD) })]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(MortarProjectileEffectTriggerCD),
		typeof(RandomCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct MortarDamageTriggerJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MortarProjectileDamageEffectCD> __MortarProjectileDamageEffectCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MortarProjectileCD> __MortarProjectileCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ProjectileSourceCD> __ProjectileSourceCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MortarProjectileDamageEffectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MortarProjectileDamageEffectCD>(isReadOnly: true);
					__MortarProjectileCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MortarProjectileCD>(isReadOnly: true);
					__ProjectileSourceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProjectileSourceCD>(isReadOnly: true);
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MortarProjectileDamageEffectCD_RO_ComponentTypeHandle.Update(ref state);
					__MortarProjectileCD_RO_ComponentTypeHandle.Update(ref state);
					__ProjectileSourceCD_RO_ComponentTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MortarProjectileDamageEffectCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MortarProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProjectileSourceCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MortarProjectileEffectTriggerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RandomCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(MortarProjectileEffectTriggerCD))
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
			public void Run(ref MortarDamageTriggerJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MortarDamageTriggerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MortarDamageTriggerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MortarDamageTriggerJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MortarDamageTriggerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MortarDamageTriggerJob job, EntityManager entityManager)
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

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookUp;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public Entity tileUpdateBufferSingleton;

		public Entity effectEventBufferSingleton;

		public Entity tileDamageBufferEntity;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		public bool isServer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in MortarProjectileDamageEffectCD mortarProjectileDamageEffectCD, in MortarProjectileCD mortarProjectileCD, in ProjectileSourceCD projectileSourceCD, in BehaviourTagsCD attackTags)
		{
			Entity entity2 = Entity.Null;
			bool flag = false;
			if (ownerLookup.TryGetComponent(entity, out var componentData))
			{
				entity2 = componentData.owner;
				flag = attackHelper.playerGhostLookup.HasComponent(componentData.owner);
			}
			if (!isServer && !flag)
			{
				return;
			}
			Entity entity3 = ((entity2 != Entity.Null && mortarProjectileCD.goDownTime == 0f && mortarProjectileCD.airTime == 0f && mortarProjectileCD.goUpTime == 0f) ? entity2 : entity);
			float3 attackOffset = float3.zero;
			ref LocalTransform valueRW = ref attackHelper.localTransformLookup.GetRefRW(entity).ValueRW;
			if (attackHelper.localTransformLookup.TryGetComponent(entity3, out var componentData2))
			{
				attackOffset = valueRW.Position - componentData2.Position;
			}
			AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
			{
				effectEventBufferSingleton = effectEventBufferSingleton,
				attacker = entity3,
				isRanged = true,
				attackOffset = attackOffset,
				radius = mortarProjectileCD.radius,
				damage = mortarProjectileDamageEffectCD.damage,
				playerDamage = mortarProjectileDamageEffectCD.damage,
				pushback = mortarProjectileDamageEffectCD.pushback,
				behaviourTags = attackTags,
				checkVisibility = mortarProjectileDamageEffectCD.checkVisibility,
				bypassMaxDamagePerHit = mortarProjectileDamageEffectCD.bypassMaxDamagePerHit,
				isPredicted = (flag || mortarProjectileDamageEffectCD.checkVisibility),
				isMagic = mortarProjectileDamageEffectCD.isMagic
			};
			attackHelper.Attack(ecb, in p);
			if (mortarProjectileDamageEffectCD.hitTiles)
			{
				DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
				float num = mortarProjectileCD.radius * mortarProjectileCD.radius;
				int num2 = (int)math.round(mortarProjectileCD.radius);
				int2 int5 = valueRW.Position.RoundToInt2();
				float3 float5 = valueRW.Position + new float3(0f, 0.25f, 0f);
				for (int i = -num2; i <= num2; i++)
				{
					for (int j = -num2; j <= num2; j++)
					{
						if (math.lengthsq(new float2(i, j)) <= num)
						{
							int2 int6 = int5 + new int2(i, j);
							if (!mortarProjectileDamageEffectCD.checkVisibility || !TileRayCastIsBlocked(float5, int6.ToFloat3() + new float3(0f, 0.25f, 0f), entity2, collisionWorld, tileAccessor, entityPartLookUp))
							{
								dynamicBuffer.Add(new TileDamageBuffer
								{
									damage = mortarProjectileDamageEffectCD.tileDamage,
									position = int6,
									skipWallAndRootsLootDropOnDestroy = mortarProjectileDamageEffectCD.skipWallAndRootsLootDropOnDestroy,
									canHitGround = false,
									causedByEntity = entity,
									dontHitBridges = true,
									canHitLowColliders = true,
									bypassMaxDamagePerHit = mortarProjectileDamageEffectCD.bypassMaxDamagePerHit,
									dontHitWalkableTiles = true
								});
							}
						}
					}
				}
			}
			ref RandomCD valueRW2 = ref attackHelper.randomLookup.GetRefRW(entity).ValueRW;
			if (mortarProjectileDamageEffectCD.removeTilesOnLand)
			{
				DynamicBuffer<TileUpdateBuffer> dynamicBuffer2 = tileUpdateBufferLookup[tileUpdateBufferSingleton];
				float2 y = new float2(valueRW.Position.x, valueRW.Position.z);
				int2 int7 = valueRW.Position.RoundToInt2();
				int num3 = (int)math.ceil(mortarProjectileCD.radius);
				for (int k = -num3; k <= num3; k++)
				{
					for (int l = -num3; l <= num3; l++)
					{
						int2 int8 = int7 + new int2(k, l);
						if (math.length(int8) > 1.5f && math.distance(int8, y) <= mortarProjectileCD.radius && (tileAccessor.HasType(int8, TileType.ground) || (tileAccessor.HasType(int8, TileType.roofHole) && !PositionIsBlocked(collisionWorld, new float3(int8.x, 0f, int8.y), 0.49f))))
						{
							dynamicBuffer2.Add(new TileUpdateBuffer
							{
								command = TileUpdateBuffer.Command.Remove,
								position = int8,
								tile = new TileCD
								{
									tileset = (int)mortarProjectileDamageEffectCD.tilesetToRemove,
									tileType = mortarProjectileDamageEffectCD.tileTypeToRemove
								}
							});
						}
					}
				}
			}
			if (mortarProjectileDamageEffectCD.spawnTilesOnLand)
			{
				DynamicBuffer<TileUpdateBuffer> dynamicBuffer3 = tileUpdateBufferLookup[tileUpdateBufferSingleton];
				float2 y2 = new float2(valueRW.Position.x, valueRW.Position.z);
				int2 int9 = valueRW.Position.RoundToInt2();
				int num4 = (int)math.ceil(mortarProjectileCD.radius);
				for (int m = -num4; m <= num4; m++)
				{
					for (int n = -num4; n <= num4; n++)
					{
						int2 int10 = int9 + new int2(m, n);
						if (!(math.length(int10) <= 1.5f) && !(math.distance(int10, y2) > mortarProjectileCD.radius))
						{
							float num5 = math.distance(int10, y2);
							float num6 = mortarProjectileCD.radius - num5;
							if ((!mortarProjectileCD.randomizeEdgeForTilesToSpawn || !(valueRW2.Value.NextFloat() > num6)) && tileAccessor.HasType(int10, TileType.ground) && !PositionIsBlocked(collisionWorld, new float3(int10.x, 0f, int10.y), 0.49f))
							{
								dynamicBuffer3.Add(new TileUpdateBuffer
								{
									command = TileUpdateBuffer.Command.Add,
									position = int10,
									tile = new TileCD
									{
										tileset = (int)mortarProjectileDamageEffectCD.tilesetToSpawn,
										tileType = mortarProjectileDamageEffectCD.tileTypeToSpawn
									}
								});
							}
						}
					}
				}
			}
			if (mortarProjectileDamageEffectCD.spawnNapalmObjectID != ObjectID.None)
			{
				EntityUtility.SpawnFireTrapOrNapalm(mortarProjectileDamageEffectCD.spawnNapalmObjectID, mortarProjectileDamageEffectCD.spawnNapalmVariation, valueRW.Position, projectileSourceCD.weaponLevel, 0, ecb, attackHelper.propertiesLookup, attackHelper.attackContinuouslyLookup, levelEntitiesBufferLookup, levelLookup, attackHelper.conditionsBufferLookup, attackHelper.databaseBank, attackHelper.isFirstTimeFullyPredictingTick);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool TileRayCastIsBlocked(float3 from, float3 to, Entity ownerEntity, CollisionWorld collisionWorld, TileAccessor tileAccessor, ComponentLookup<EntityPartCD> entityPartLookUp)
		{
			int2 int5 = to.RoundToInt2();
			float3 x = to - from;
			float3 float5 = math.normalizesafe(x, new float3(0f, 0f, 1f));
			float num = math.length(x);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1u
			};
			RaycastInput input = new RaycastInput
			{
				Start = from,
				End = to,
				Filter = filter
			};
			NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(Allocator.Temp);
			if (collisionWorld.CastRay(input, ref allHits))
			{
				for (int i = 0; i < allHits.Length; i++)
				{
					RaycastHit raycastHit = allHits[i];
					int2 obj = (raycastHit.Position + float5 * 0.1f).RoundToInt2();
					Entity entity = (entityPartLookUp.HasComponent(raycastHit.Entity) ? entityPartLookUp[raycastHit.Entity].mainEntity : Entity.Null);
					if (math.any(obj != int5) && ownerEntity != raycastHit.Entity && entity != ownerEntity)
					{
						allHits.Dispose();
						return true;
					}
				}
			}
			allHits.Dispose();
			num = math.max(0.1f, num - 0.8f);
			if (SinglePugMap.RaycastWalls(from.ToFloat2(), float5.ToFloat2(), num, out var _, tileAccessor))
			{
				return true;
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MortarProjectileDamageEffectCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MortarProjectileCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ProjectileSourceCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileDamageEffectCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProjectileSourceCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileDamageEffectCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProjectileSourceCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileDamageEffectCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProjectileSourceCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileDamageEffectCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MortarProjectileCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProjectileSourceCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k));
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
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public ComponentLookup<MortarProjectileEffectTriggerCD> __MortarProjectileEffectTriggerCD_RW_ComponentLookup;

		public MortarStateJob.InternalCompilerQueryAndHandleData __MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

		public MortarDamageTriggerJob.InternalCompilerQueryAndHandleData __MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__MortarProjectileEffectTriggerCD_RW_ComponentLookup = state.GetComponentLookup<MortarProjectileEffectTriggerCD>();
			__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
			__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
			__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000250B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000250B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000250B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000250C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000250C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000250C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_0000250D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_0000250D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000250D_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_0000250E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_0000250E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000250E_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_0000250F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000250F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000250F_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private AttackSystem.Helper _attackHelper;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_175951654_0;

	private EntityQuery __query_175951654_1;

	private EntityQuery __query_175951654_2;

	private EntityQuery __query_175951654_3;

	private EntityQuery __query_175951654_4;

	private EntityQuery __query_175951654_5;

	private EntityQuery __query_175951654_6;

	private EntityQuery __query_175951654_7;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool PositionIsBlocked(CollisionWorld collisionWorld, float3 position, float radius, bool canSpawnOnWaterOrPit = true)
	{
		return collisionWorld.SphereCast(position, radius, float3.zero, 0f, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = (canSpawnOnWaterOrPit ? 1u : 131329u)
		});
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<MortarProjectileCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_175951654_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		if (!__query_175951654_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_tileAccessor.Update(ref state);
		__query_175951654_1.TryGetSingleton<NetworkTime>(out var value2);
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new MortarStateJob
		{
			tileAccessor = _tileAccessor,
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			tileUpdateBufferSingleton = __query_175951654_2.GetSingletonEntity(),
			mortarProjectileEffectTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileEffectTriggerCD_RW_ComponentLookup, ref state),
			collisionWorld = __query_175951654_3.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld,
			worldInfoCD = __query_175951654_4.GetSingleton<WorldInfoCD>(),
			currentTick = value2.ServerTick,
			tickRate = (uint)value.SimulationTickRate
		}, __TypeHandle.__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new MortarDamageTriggerJob
		{
			tileAccessor = _tileAccessor,
			attackHelper = _attackHelper,
			entityPartLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			tileDamageBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref state),
			effectEventBufferSingleton = __query_175951654_5.GetSingletonEntity(),
			tileUpdateBufferSingleton = __query_175951654_2.GetSingletonEntity(),
			collisionWorld = __query_175951654_3.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld,
			tileDamageBufferEntity = __query_175951654_6.GetSingletonEntity(),
			ecb = __query_175951654_7.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged),
			levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
			levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
			isServer = state.WorldUnmanaged.IsServer()
		}, __TypeHandle.__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(MortarStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__MortarProjectileSystem_MortarStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(MortarDamageTriggerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__MortarProjectileSystem_MortarDamageTriggerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_175951654_7 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000250B_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000250C_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_0000250D_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_0000250E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000250F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MortarProjectileSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}

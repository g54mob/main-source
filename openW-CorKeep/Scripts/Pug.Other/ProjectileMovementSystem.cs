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
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
public struct ProjectileMovementSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct CheckForInvalidGroundBounceJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<GroundBouncableProjectileCD> __GroundBouncableProjectileCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DestroyTimerCD> __DestroyTimerCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__GroundBouncableProjectileCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GroundBouncableProjectileCD>();
					__DestroyTimerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DestroyTimerCD>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__GroundBouncableProjectileCD_RW_ComponentTypeHandle.Update(ref state);
					__DestroyTimerCD_RO_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DestroyTimerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GroundBouncableProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
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
			public void Run(ref CheckForInvalidGroundBounceJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CheckForInvalidGroundBounceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CheckForInvalidGroundBounceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CheckForInvalidGroundBounceJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CheckForInvalidGroundBounceJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CheckForInvalidGroundBounceJob job, EntityManager entityManager)
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

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in LocalTransform localTransform, ref GroundBouncableProjectileCD groundBouncableProjectileCD, in DestroyTimerCD destroyTimerCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref HealthCD healthCD)
		{
			if (groundBouncableProjectileCD.startFallTick.IsValid)
			{
				return;
			}
			NetworkTick networkTick = currentTick;
			networkTick.Decrement();
			NetworkTick networkTick2 = currentTick;
			networkTick2.Increment();
			float time = destroyTimerCD.timer.GetPercentageFinished(networkTick);
			float time2 = destroyTimerCD.timer.GetPercentageFinished(currentTick);
			float time3 = destroyTimerCD.timer.GetPercentageFinished(networkTick2);
			if (time3 == 0f)
			{
				return;
			}
			float num = groundBouncableProjectileCD.verticalCurve.Value.Evaluate(in time);
			float num2 = groundBouncableProjectileCD.verticalCurve.Value.Evaluate(in time2);
			float num3 = groundBouncableProjectileCD.verticalCurve.Value.Evaluate(in time3);
			float num4 = num2 - num;
			float num5 = num3 - num2;
			bool num6 = num4 < 0f && num5 > 0f;
			bool flag = num4 == 0f && num5 == 0f;
			if (!num6 && !flag)
			{
				return;
			}
			TileCD top = tileAccessor.GetTop(localTransform.Position.RoundToInt2());
			TileType tileType = top.tileType;
			if (tileType != TileType.pit && tileType != TileType.water)
			{
				return;
			}
			if (top.tileset == 3)
			{
				healthCD.health = 0;
				return;
			}
			groundBouncableProjectileCD.startFallTick = currentTick;
			groundBouncableProjectileCD.fallingInWater = top.tileType == TileType.water;
			if (groundBouncableProjectileCD.fallingInWater)
			{
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						effectID = EffectID.SmallWaterSplash,
						position1 = localTransform.Position
					}
				};
				buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GroundBouncableProjectileCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DestroyTimerCD_RO_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i);
					ref GroundBouncableProjectileCD groundBouncableProjectileCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GroundBouncableProjectileCD>(nativeArrayPtr2, i);
					ref DestroyTimerCD destroyTimerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyTimerCD>(nativeArrayPtr3, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
					Execute(in localTransform, ref groundBouncableProjectileCD, in destroyTimerCD, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, i));
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
						ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin);
						ref GroundBouncableProjectileCD groundBouncableProjectileCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GroundBouncableProjectileCD>(nativeArrayPtr2, nextRangeBegin);
						ref DestroyTimerCD destroyTimerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyTimerCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(in localTransform2, ref groundBouncableProjectileCD2, in destroyTimerCD2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j);
					ref GroundBouncableProjectileCD groundBouncableProjectileCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GroundBouncableProjectileCD>(nativeArrayPtr2, j);
					ref DestroyTimerCD destroyTimerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyTimerCD>(nativeArrayPtr3, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
					Execute(in localTransform3, ref groundBouncableProjectileCD3, in destroyTimerCD3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k);
					ref GroundBouncableProjectileCD groundBouncableProjectileCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GroundBouncableProjectileCD>(nativeArrayPtr2, k);
					ref DestroyTimerCD destroyTimerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyTimerCD>(nativeArrayPtr3, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
					Execute(in localTransform4, ref groundBouncableProjectileCD4, in destroyTimerCD4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, k));
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
		typeof(LocalTransform),
		typeof(Simulate),
		typeof(ProjectileCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct ProjectileMovementJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ProjectileAspect.TypeHandle __ProjectileAspect_RW_AspectTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ProjectileAspect_RW_AspectTypeHandle = new ProjectileAspect.TypeHandle(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ProjectileAspect_RW_AspectTypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAspect<ProjectileAspect>();
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
			public void Run(ref ProjectileMovementJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ProjectileMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ProjectileMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ProjectileMovementJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ProjectileMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ProjectileMovementJob job, EntityManager entityManager)
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

		public ComponentLookup<LocalTransform> localTranslationLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		public ComponentLookup<ProjectileCD> projectileLookup;

		public NetworkTick currentTick;

		public float deltaTime;

		public uint tickRate;

		public bool isServer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ProjectileAspect projectileAspect, in GhostInstance ghostInstance)
		{
			if (NetworkTimeUtilities.IsSpawnTickForBeginECBCreatedGhost(in ghostInstance, currentTick, isServer))
			{
				return;
			}
			ref ProjectileCD valueRW = ref projectileLookup.GetRefRW(entity).ValueRW;
			if (float.IsNaN(valueRW.directionRadians))
			{
				valueRW.directionRadians = projectileAspect.projectileSetup.ValueRO.directionRadians;
			}
			if (healthLookup[entity].health <= 0)
			{
				return;
			}
			LocalTransform value = localTranslationLookup[entity];
			if (valueRW.prevPos.Equals(float2.zero))
			{
				valueRW.prevPos = value.Position.xz;
			}
			valueRW.prevPrevPos = valueRW.prevPos;
			valueRW.prevPos = value.Position.xz;
			if (projectileAspect.groundBouncableProjectileCD.IsValid && projectileAspect.groundBouncableProjectileCD.ValueRO.startFallTick.IsValid)
			{
				float num = NetworkTimeUtilities.TimeBetweenTicksInSeconds(projectileAspect.groundBouncableProjectileCD.ValueRO.startFallTick, currentTick, tickRate);
				float num2 = math.lerp(projectileAspect.GetSpeed(projectileAspect.groundBouncableProjectileCD.ValueRO.startFallTick, tickRate), 0f, math.clamp(num * 2f, 0f, 1f));
				value.Position += valueRW.GetDirection3() * num2 * deltaTime;
				localTranslationLookup[entity] = value;
				return;
			}
			if (projectileAspect.homing.IsValid)
			{
				HomingProjectileCD valueRO = projectileAspect.homing.ValueRO;
				PlayerGhostExtrapolated componentData;
				Entity entity2 = ((!playerGhostExtrapolatedLookup.TryGetComponent(valueRO.followingEntity, out componentData)) ? valueRO.followingEntity : componentData.playerGhost);
				if (localTranslationLookup.TryGetComponent(valueRO.followingEntity, out var componentData2) && (!healthLookup.TryGetComponent(entity2, out var componentData3) || componentData3.health > 0))
				{
					float3 direction = math.normalizesafe(componentData2.Position - value.Position);
					valueRW.SetDirection(direction);
				}
			}
			float speed = projectileAspect.GetSpeed(currentTick, tickRate);
			NetworkTick networkTick = currentTick;
			networkTick.Decrement();
			float speed2 = projectileAspect.GetSpeed(networkTick, tickRate);
			if (math.sign(speed) != math.sign(speed2))
			{
				valueRW.lastHitEnemy = Entity.Null;
			}
			value.Position += valueRW.GetDirection3() * speed * deltaTime;
			localTranslationLookup[entity] = value;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			ProjectileAspect.ResolvedChunk resolvedChunk = __TypeHandle.__ProjectileAspect_RW_AspectTypeHandle.Resolve(chunk);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ProjectileAspect projectileAspect = resolvedChunk[i];
					Execute(entity, projectileAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i));
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
						ProjectileAspect projectileAspect2 = resolvedChunk[nextRangeBegin];
						Execute(entity2, projectileAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin));
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
					ProjectileAspect projectileAspect3 = resolvedChunk[j];
					Execute(entity3, projectileAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j));
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
					ProjectileAspect projectileAspect4 = resolvedChunk[k];
					Execute(entity4, projectileAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k));
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
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateBefore(typeof(ProjectileMovementJob))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WithAll(new Type[]
	{
		typeof(LocalTransform),
		typeof(Simulate),
		typeof(ProjectileCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct DelayTargetJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ProjectileAspect.TypeHandle __ProjectileAspect_RW_AspectTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DirectionCD> __DirectionCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<IndirectProjectileCD> __IndirectProjectileCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ProjectileAspect_RW_AspectTypeHandle = new ProjectileAspect.TypeHandle(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__DirectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>(isReadOnly: true);
					__IndirectProjectileCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<IndirectProjectileCD>();
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ProjectileAspect_RW_AspectTypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__DirectionCD_RO_ComponentTypeHandle.Update(ref state);
					__IndirectProjectileCD_RW_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DirectionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<NearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<IndirectProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAspect<ProjectileAspect>();
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
			public void Run(ref DelayTargetJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DelayTargetJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DelayTargetJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DelayTargetJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DelayTargetJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DelayTargetJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		public ComponentLookup<ProjectileCD> projectileLookup;

		public NetworkTick currentTick;

		public double time;

		public bool isServer;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ProjectileAspect projectileAspect, in GhostInstance ghostInstance, in DirectionCD directionCD, ref IndirectProjectileCD indirectProjectileCD, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (NetworkTimeUtilities.IsSpawnTickForBeginECBCreatedGhost(in ghostInstance, currentTick, isServer) || healthLookup[entity].health <= 0)
			{
				return;
			}
			if (!indirectProjectileCD.internalTimer.isRunning && indirectProjectileCD.delayTime != 0f)
			{
				indirectProjectileCD.internalTimer.Start(time, indirectProjectileCD.delayTime);
			}
			else
			{
				if (indirectProjectileCD.delayTime != 0f && !indirectProjectileCD.internalTimer.IsTimerElapsed(time))
				{
					return;
				}
				ref ProjectileCD valueRW = ref projectileLookup.GetRefRW(entity).ValueRW;
				if (valueRW.directionRadians == 0f)
				{
					valueRW.SetDirection(directionCD.direction);
				}
				projectileAspect.speed.ValueRW.originalSpeed = indirectProjectileCD.speed;
				ecb.SetComponent(entity, new ProjectileSetupCD
				{
					damage = 1,
					directionRadians = math.atan2(directionCD.direction.z, directionCD.direction.x)
				});
				ecb.SetComponent(entity, new ProjectileSourceCD
				{
					shotFromReinforcedWeapon = false
				});
				if (indirectProjectileCD.seeking)
				{
					Entity entity2 = default(Entity);
					float num = float.PositiveInfinity;
					for (int i = 0; i < nearbyEntities.Length; i++)
					{
						Entity entity3 = nearbyEntities[i].entity;
						if (enemyLookup.HasComponent(entity3) && localTransformLookup.HasComponent(entity3))
						{
							float num2 = math.lengthsq(localTransformLookup[entity].Position - localTransformLookup[entity3].Position);
							if (num2 < num)
							{
								num = num2;
								entity2 = entity3;
							}
						}
					}
					if (entity2 != default(Entity))
					{
						ecb.AddComponent(entity, new HomingProjectileCD
						{
							followingEntity = entity2
						});
					}
				}
				ecb.RemoveComponent<IndirectProjectileCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			ProjectileAspect.ResolvedChunk resolvedChunk = __TypeHandle.__ProjectileAspect_RW_AspectTypeHandle.Resolve(chunk);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DirectionCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__IndirectProjectileCD_RW_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ProjectileAspect projectileAspect = resolvedChunk[i];
					Execute(entity, projectileAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IndirectProjectileCD>(nativeArrayPtr4, i), bufferAccessor[i]);
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
						ProjectileAspect projectileAspect2 = resolvedChunk[nextRangeBegin];
						Execute(entity2, projectileAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IndirectProjectileCD>(nativeArrayPtr4, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					ProjectileAspect projectileAspect3 = resolvedChunk[j];
					Execute(entity3, projectileAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IndirectProjectileCD>(nativeArrayPtr4, j), bufferAccessor[j]);
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
					ProjectileAspect projectileAspect4 = resolvedChunk[k];
					Execute(entity4, projectileAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IndirectProjectileCD>(nativeArrayPtr4, k), bufferAccessor[k]);
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
		public CheckForInvalidGroundBounceJob.InternalCompilerQueryAndHandleData __ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		public ComponentLookup<ProjectileCD> __ProjectileCD_RW_ComponentLookup;

		public ProjectileMovementJob.InternalCompilerQueryAndHandleData __ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		public DelayTargetJob.InternalCompilerQueryAndHandleData __ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__ProjectileCD_RW_ComponentLookup = state.GetComponentLookup<ProjectileCD>();
			__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003048_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003048_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003048_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStopRunning_0000304A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000304A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000304A_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private uint _tickRate;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1963201159_0;

	private EntityQuery __query_1963201159_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		state.RequireForUpdate<ProjectileCD>();
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
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
		__query_1963201159_0.TryGetSingleton<NetworkTime>(out var value);
		EntityCommandBuffer ecb = __query_1963201159_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new CheckForInvalidGroundBounceJob
		{
			tileAccessor = _tileAccessor,
			currentTick = value.ServerTick
		}, __TypeHandle.__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new ProjectileMovementJob
		{
			localTranslationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			projectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileCD_RW_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			tickRate = _tickRate,
			isServer = state.WorldUnmanaged.IsServer()
		}, __TypeHandle.__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new DelayTargetJob
		{
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			projectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileCD_RW_ComponentLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			isServer = state.WorldUnmanaged.IsServer(),
			ecb = ecb
		}, __TypeHandle.__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(CheckForInvalidGroundBounceJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ProjectileMovementSystem_CheckForInvalidGroundBounceJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ProjectileMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ProjectileMovementSystem_ProjectileMovementJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(DelayTargetJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ProjectileMovementSystem_DelayTargetJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963201159_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963201159_1 = entityQueryBuilder2.Build(ref state);
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
		((ProjectileMovementSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003048_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((ProjectileMovementSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000304A_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ProjectileMovementSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ProjectileMovementSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ProjectileMovementSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}

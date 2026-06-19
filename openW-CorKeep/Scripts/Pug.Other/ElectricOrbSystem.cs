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
[UpdateBefore(typeof(TileDamageSystem))]
[UpdateAfter(typeof(ProjectileMovementSystem))]
[UpdateBefore(typeof(ConditionEffectsUpdateSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct ElectricOrbSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ElectricOrbJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<ElectricOrbCD> __ElectricOrbCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<DirectionCD> __DirectionCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ElectricOrbCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricOrbCD>();
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__DirectionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__ElectricOrbCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__DirectionCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ElectricOrbCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DirectionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref ElectricOrbJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ElectricOrbJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ElectricOrbJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ElectricOrbJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ElectricOrbJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ElectricOrbJob job, EntityManager entityManager)
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
		public TileAccessor tileAccessor;

		[ReadOnly]
		public NativeArray<float2> normals;

		public NetworkTick currentTick;

		public double time;

		public float deltaTime;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(ref ElectricOrbCD electricOrbCD, ref LocalTransform localTransform, ref DirectionCD directionCD, ref HealthCD healthCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref RandomCD randomCD)
		{
			CheckChangeState(ref electricOrbCD, ref healthCD, ref animationBuffer, ref animationBufferPointer);
			if (electricOrbCD.state == ElectricOrbCD.State.Active)
			{
				UpdateMovementPattern(ref electricOrbCD, ref randomCD);
				UpdateMovement(ref electricOrbCD, ref localTransform, ref directionCD);
			}
		}

		private void CheckChangeState(ref ElectricOrbCD electricOrbCD, ref HealthCD healthCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (electricOrbCD.state == ElectricOrbCD.State.Uninitialized)
			{
				AnimationUtilities.TriggerAnimation(-1619438193, currentTick, animationBuffer, ref animationBufferPointer);
				electricOrbCD.state = ElectricOrbCD.State.Starting;
				electricOrbCD.stateTimer.Start(currentTick, electricOrbCD.startDuration, tickRate);
			}
			else if (electricOrbCD.state == ElectricOrbCD.State.Starting && electricOrbCD.stateTimer.IsTimerElapsed(currentTick))
			{
				AnimationUtilities.TriggerAnimation(-1587601938, currentTick, animationBuffer, ref animationBufferPointer);
				electricOrbCD.movementPatternIndex = -1;
				electricOrbCD.state = ElectricOrbCD.State.Active;
				electricOrbCD.stateTimer.Start(currentTick, electricOrbCD.loopDuration, tickRate);
			}
			else if (electricOrbCD.state == ElectricOrbCD.State.Active && electricOrbCD.stateTimer.IsTimerElapsed(currentTick))
			{
				AnimationUtilities.TriggerAnimation(16528305, currentTick, animationBuffer, ref animationBufferPointer);
				electricOrbCD.state = ElectricOrbCD.State.Ending;
				electricOrbCD.stateTimer.Start(currentTick, electricOrbCD.endDuration, tickRate);
			}
			else if (electricOrbCD.state == ElectricOrbCD.State.Ending && electricOrbCD.stateTimer.IsTimerElapsed(currentTick))
			{
				AnimationUtilities.TriggerAnimation(-2007111235, currentTick, animationBuffer, ref animationBufferPointer);
				electricOrbCD.state = ElectricOrbCD.State.Ended;
				electricOrbCD.stateTimer.Start(currentTick, electricOrbCD.hiddenEndDuration, tickRate);
				healthCD.health = 0;
			}
		}

		private void UpdateMovementPattern(ref ElectricOrbCD electricOrbCD, ref RandomCD randomCD)
		{
			if (electricOrbCD.movementPatternIndex != -1 && !electricOrbCD.movementPatternTimer.IsTimerElapsed(currentTick))
			{
				return;
			}
			ref BlobArray<ElectricOrbMovementPatternBlob> value = ref electricOrbCD.movementPatterns.Value;
			if (value.Length != 0)
			{
				electricOrbCD.movementPatternIndex++;
				if (electricOrbCD.movementPatternIndex >= value.Length)
				{
					electricOrbCD.movementPatternIndex = 0;
				}
				ref ElectricOrbMovementPatternBlob reference = ref value[electricOrbCD.movementPatternIndex];
				float num = randomCD.Value.NextFloat(reference.minMaxDurationSeconds.x, reference.minMaxDurationSeconds.y);
				if (num <= 0f)
				{
					num = 100000f;
				}
				electricOrbCD.movementPatternTimer.Start(currentTick, num, tickRate);
				electricOrbCD.patternSign = ((!randomCD.Value.NextBool()) ? 1 : (-1));
				electricOrbCD.speed = randomCD.Value.NextFloat(reference.minMaxSpeed.x, reference.minMaxSpeed.y);
			}
		}

		private void UpdateMovement(ref ElectricOrbCD electricOrbCD, ref LocalTransform localTransform, ref DirectionCD directionCD)
		{
			if (electricOrbCD.movementPatternIndex != -1)
			{
				ref ElectricOrbMovementPatternBlob reference = ref electricOrbCD.movementPatterns.Value[electricOrbCD.movementPatternIndex];
				float2 prevPos = localTransform.Position.ToFloat2();
				float2 float5 = math.normalizesafe(math.mul(quaternion.RotateY((float)electricOrbCD.patternSign * GetSinusoidalTurnAngle(maxTurnAngle: reference.sinusoidalMaxTurnAngleRadians, repeatTimeSeconds: reference.sinusoidalRepeatTimeSeconds, walkTime: electricOrbCD.stateTimer.GetElapsedSeconds(currentTick, tickRate))), directionCD.direction).ToFloat2()) * electricOrbCD.speed * deltaTime;
				float2 newPosition = prevPos + float5;
				float2 x = newPosition - prevPos;
				float distance = math.length(x);
				x = math.normalizesafe(x);
				localTransform = LocalTransform.FromPosition(newPosition.ToFloat3());
				if (electricOrbCD.bounceOnWalls)
				{
					EvaluateBounceOnWalls(in prevPos, in newPosition, in x, in distance, ref directionCD, ref localTransform);
				}
			}
		}

		private void EvaluateBounceOnWalls(in float2 prevPos, in float2 newPosition, in float2 moveDir, in float distance, ref DirectionCD directionCD, ref LocalTransform localTransform)
		{
			NativeList<TileHitInfo> tilesToCheck = new NativeList<TileHitInfo>(2, Allocator.Temp);
			EntityUtility.DoRayCast(EntityUtility.TileRayCastType.Walls, prevPos, moveDir, distance, tileAccessor, tilesToCheck);
			if (tilesToCheck.Length == 0)
			{
				return;
			}
			int2 zero = int2.zero;
			float2 normal = float2.zero;
			float closestTileDistance = float.MaxValue;
			TileHitInfo tileCollidedWith = default(TileHitInfo);
			float num = 0.5f;
			float2 rayOrigin = prevPos - directionCD.direction.ToFloat2() * num * 0.1f;
			EntityUtility.CheckIfIntersectedTile(tilesToCheck, normals, in prevPos, in rayOrigin, in moveDir, ref closestTileDistance, ref normal, ref tileCollidedWith, hasBouncing: true, zero);
			if (!normal.Equals(float2.zero))
			{
				float2 float5 = math.normalizesafe(math.reflect(moveDir, normal));
				directionCD.direction = float5.ToFloat3();
				float2 point = tileCollidedWith.point;
				float num2 = math.length(prevPos - point);
				float num3 = math.length(newPosition - prevPos);
				float num4 = num2 / num3;
				float2 float6 = point + normal * 0.01f;
				float2 float7 = point + float5 * num3 * (1f - num4);
				float2 x = float7 - float6;
				float distance2 = math.length(x);
				x = math.normalizesafe(x);
				tilesToCheck.Clear();
				EntityUtility.DoRayCast(EntityUtility.TileRayCastType.Walls, float6, x, distance2, tileAccessor, tilesToCheck);
				if (tilesToCheck.Length > 0)
				{
					localTransform.Position = float6.X0Y();
				}
				else
				{
					localTransform.Position = float7.X0Y();
				}
			}
		}

		private float GetSinusoidalTurnAngle(float walkTime, float maxTurnAngle, float repeatTimeSeconds)
		{
			return maxTurnAngle * math.sin(repeatTimeSeconds * walkTime * (MathF.PI * 2f) + MathF.PI / 2f);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ElectricOrbCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__DirectionCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref ElectricOrbCD electricOrbCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricOrbCD>(nativeArrayPtr, i);
					ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					ref DirectionCD directionCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, i);
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(ref electricOrbCD, ref localTransform, ref directionCD, ref healthCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr6, i));
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
						ref ElectricOrbCD electricOrbCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricOrbCD>(nativeArrayPtr, nextRangeBegin);
						ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						ref DirectionCD directionCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, nextRangeBegin);
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(ref electricOrbCD2, ref localTransform2, ref directionCD2, ref healthCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref ElectricOrbCD electricOrbCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricOrbCD>(nativeArrayPtr, j);
					ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					ref DirectionCD directionCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, j);
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(ref electricOrbCD3, ref localTransform3, ref directionCD3, ref healthCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr6, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref ElectricOrbCD electricOrbCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricOrbCD>(nativeArrayPtr, k);
					ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					ref DirectionCD directionCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DirectionCD>(nativeArrayPtr3, k);
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(ref electricOrbCD4, ref localTransform4, ref directionCD4, ref healthCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr6, k));
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
		public ElectricOrbJob.InternalCompilerQueryAndHandleData __ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00001CBE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001CBE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001CBE_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TileAccessor _tileAccessor;

	private NativeArray<float2> _normals;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1594576852_0;

	private EntityQuery __query_1594576852_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
		_normals = new NativeArray<float2>(4, Allocator.Persistent);
		_normals[0] = new float2(-1f, 0f);
		_normals[1] = new float2(1f, 0f);
		_normals[2] = new float2(0f, 1f);
		_normals[3] = new float2(0f, -1f);
	}

	public void OnDestroy(ref SystemState state)
	{
		if (_normals.IsCreated)
		{
			_normals.Dispose();
		}
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
		__query_1594576852_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new ElectricOrbJob
		{
			tileAccessor = _tileAccessor,
			normals = _normals,
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			tickRate = (uint)__query_1594576852_1.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ElectricOrbJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ElectricOrbSystem_ElectricOrbJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1594576852_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1594576852_1 = entityQueryBuilder2.Build(ref state);
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
		((ElectricOrbSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001CBE_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		((ElectricOrbSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((ElectricOrbSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((ElectricOrbSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ElectricOrbSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ElectricOrbSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

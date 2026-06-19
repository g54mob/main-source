using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
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
[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct BushStateSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct BushStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BushStateCD> __BushStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__BushStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BushStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__BushStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BushStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref BushStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BushStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BushStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BushStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BushStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BushStateJob job, EntityManager entityManager)
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
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		[ReadOnly]
		public ComponentLookup<LastAttackerCD> LastAttackerLookup;

		[ReadOnly]
		public CollisionWorld CollisionWorld;

		public double Time;

		public NetworkTick CurrentTick;

		public Unity.Mathematics.Random Rng;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref StateInfoCD stateInfo, ref BushStateCD bushStateCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities, in LocalTransform transform, in ObjectPropertiesCD properties)
		{
			if (!stateInfo.IsCurrentState(StateID.Bush))
			{
				return;
			}
			if (bushStateCD.nextInternalStateOnTimerElapse == BushStateCD.InternalState.EnterState)
			{
				AnimationUtilities.TriggerAnimation(1792219624, CurrentTick, animationBuffer, ref animationBufferPointer);
				bushStateCD.nextInternalStateOnTimerElapse = BushStateCD.InternalState.InBush;
				bushStateCD.timer.Start(Time, properties.Get<float>(-1386347428));
				float min = properties.Get<float>(955565602);
				float max = properties.Get<float>(-184959699);
				float newLifespan = Rng.NextFloat(min, max);
				bushStateCD.randomlyLeaveStatetimer.Start(Time, newLifespan);
				return;
			}
			bool flag = bushStateCD.timer.isRunning && bushStateCD.timer.IsTimerElapsed(Time);
			if (bushStateCD.nextInternalStateOnTimerElapse == BushStateCD.InternalState.InBush && flag)
			{
				AnimationUtilities.TriggerAnimation(-1523938960, CurrentTick, animationBuffer, ref animationBufferPointer);
				bushStateCD.nextInternalStateOnTimerElapse = BushStateCD.InternalState.Peek;
				bushStateCD.timer.Start(Time, Rng.NextFloat(4f, 6f));
			}
			else if (bushStateCD.nextInternalStateOnTimerElapse == BushStateCD.InternalState.Peek && flag)
			{
				AnimationUtilities.TriggerAnimation(-1562274691, CurrentTick, animationBuffer, ref animationBufferPointer);
				bushStateCD.nextInternalStateOnTimerElapse = BushStateCD.InternalState.InBush;
				bushStateCD.timer.Start(Time, properties.Get<float>(-98368079));
			}
			else if (bushStateCD.nextInternalStateOnTimerElapse == BushStateCD.InternalState.LeaveBush)
			{
				AnimationUtilities.TriggerAnimation(1096900643, CurrentTick, animationBuffer, ref animationBufferPointer);
				bushStateCD.nextInternalStateOnTimerElapse = BushStateCD.InternalState.ExitState;
				bushStateCD.timer.Start(Time, properties.Get<float>(-1282128049));
			}
			else if (bushStateCD.nextInternalStateOnTimerElapse == BushStateCD.InternalState.ExitState && flag)
			{
				stateInfo.LeaveState();
				bushStateCD.cooldownTimer.Start(Time, Rng.NextFloat(3f, 4f));
			}
			if (ShouldLeaveState(entity, bushStateCD, transform.Position, nearbyEntities))
			{
				bushStateCD.randomlyLeaveStatetimer.Stop();
				bushStateCD.nextInternalStateOnTimerElapse = BushStateCD.InternalState.LeaveBush;
			}
		}

		private bool ShouldLeaveState(Entity entity, BushStateCD bushState, float3 position, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (bushState.nextInternalStateOnTimerElapse != BushStateCD.InternalState.Peek)
			{
				return false;
			}
			if (bushState.randomlyLeaveStatetimer.IsTimerElapsed(Time))
			{
				return true;
			}
			if (LastAttackerLookup.TryGetComponent(entity, out var componentData) && componentData.Value != Entity.Null)
			{
				return true;
			}
			float3 frompos = position + new float3(0f, 0.5f, 0f);
			uint layerMaskCollidesWith = 131329u;
			for (int i = 0; i < nearbyEntities.Length; i++)
			{
				if (!ObjectDataLookup.TryGetComponent(nearbyEntities[i].entity, out var componentData2) || componentData2.objectID != ObjectID.Player || (EntityDestroyedLookup.HasComponent(nearbyEntities[i].entity) && EntityDestroyedLookup.IsComponentEnabled(nearbyEntities[i].entity)) || !LocalTransformLookup.TryGetComponent(nearbyEntities[i].entity, out var componentData3))
				{
					continue;
				}
				float3 position2 = componentData3.Position;
				if (bushState.distanceToTargetToLeaveStateSq == 0f || math.distancesq(position, position2) < bushState.distanceToTargetToLeaveStateSq)
				{
					float3 topos = position2 + new float3(0f, 0.5f, 0f);
					RaycastInput raycastInput = PhysicsManager.GetRaycastInput(frompos, topos, uint.MaxValue, layerMaskCollidesWith);
					if (!CollisionWorld.CastRay(raycastInput))
					{
						return true;
					}
				}
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BushStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfo = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref BushStateCD bushStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BushStateCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref stateInfo, ref bushStateCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, i));
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
						ref StateInfoCD stateInfo2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref BushStateCD bushStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BushStateCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref stateInfo2, ref bushStateCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), bufferAccessor2[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref StateInfoCD stateInfo3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref BushStateCD bushStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BushStateCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref stateInfo3, ref bushStateCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, j));
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
					ref StateInfoCD stateInfo4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref BushStateCD bushStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BushStateCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref stateInfo4, ref bushStateCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, k));
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
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LastAttackerCD> __LastAttackerCD_RO_ComponentLookup;

		public BushStateJob.InternalCompilerQueryAndHandleData __BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__LastAttackerCD_RO_ComponentLookup = state.GetComponentLookup<LastAttackerCD>(isReadOnly: true);
			__BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000391A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000391A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000391A_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000391B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000391B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000391B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private const float MIN_COOLDOWN = 3f;

	private const float MAX_COOLDOWN = 4f;

	private const float MIN_PEEK_INTERVAL = 4f;

	private const float MAX_PEEK_INTERVAL = 6f;

	private EntityQuery _query;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1239634890_0;

	private EntityQuery __query_1239634890_1;

	private EntityQuery __query_1239634890_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_query = __query_1239634890_0;
		state.RequireForUpdate(_query);
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1239634890_1.TryGetSingleton<NetworkTime>(out var value);
		BushStateJob job = new BushStateJob
		{
			ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			LastAttackerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LastAttackerCD_RO_ComponentLookup, ref state),
			CollisionWorld = __query_1239634890_2.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld,
			Time = state.WorldUnmanaged.Time.ElapsedTime,
			CurrentTick = value.ServerTick,
			Rng = PugRandom.GetRng()
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, _query, state.Dependency, ref state, hasUserDefinedQuery: true);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(BushStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BushStateSystem_BushStateJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NearbyEntitiesBufferCD, LocalTransform, ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD, BushStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer, AnimationBufferPointer>();
		__query_1239634890_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1239634890_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1239634890_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000391A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000391B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((BushStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BushStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BushStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

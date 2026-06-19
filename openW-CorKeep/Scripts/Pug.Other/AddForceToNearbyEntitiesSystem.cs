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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct AddForceToNearbyEntitiesSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	public struct AddForceJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<AddForceToNearbyEntitiesCD> __AddForceToNearbyEntitiesCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__AddForceToNearbyEntitiesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AddForceToNearbyEntitiesCD>();
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__AddForceToNearbyEntitiesCD_RW_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AddForceToNearbyEntitiesCD>();
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
			public void Run(ref AddForceJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AddForceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AddForceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AddForceJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AddForceJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AddForceJob job, EntityManager entityManager)
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
		public ComponentLookup<EnemyCD> EnemyLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> FactionLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToPushBackCD> ImmuneToPushBackLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> TranslationLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> PhysicsVelocityLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> OwnerLookup;

		[ReadOnly]
		public TileAccessor TileAccessor;

		[ReadOnly]
		public CollisionWorld CollisionWorld;

		[ReadOnly]
		public WorldInfoCD worldInfo;

		public NetworkTick CurrentTick;

		public uint TickRate;

		public float DeltaTime;

		public EntityCommandBuffer Ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(Entity entity, ref AddForceToNearbyEntitiesCD addForceToNearbyEntities, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (addForceToNearbyEntities.state == AddForceToNearbyEntitiesCD.State.Initialize)
			{
				Initialize(ref addForceToNearbyEntities);
			}
			if (addForceToNearbyEntities.state == AddForceToNearbyEntitiesCD.State.Inactive)
			{
				Inactive(ref addForceToNearbyEntities);
			}
			if (addForceToNearbyEntities.state == AddForceToNearbyEntitiesCD.State.Active)
			{
				Active(ref addForceToNearbyEntities, in nearbyEntities);
			}
			ApplyForce(entity, ref addForceToNearbyEntities, in nearbyEntities);
		}

		private void Initialize(ref AddForceToNearbyEntitiesCD addForceToNearbyEntities)
		{
			if (addForceToNearbyEntities.activationDelay > 0f)
			{
				addForceToNearbyEntities.stateTimer.Start(CurrentTick, addForceToNearbyEntities.activationDelay, TickRate);
				addForceToNearbyEntities.state = AddForceToNearbyEntitiesCD.State.Inactive;
			}
			else
			{
				addForceToNearbyEntities.stateTimer.Start(CurrentTick, addForceToNearbyEntities.activeDuration, TickRate);
				addForceToNearbyEntities.state = AddForceToNearbyEntitiesCD.State.Active;
			}
		}

		private void Inactive(ref AddForceToNearbyEntitiesCD addForceToNearbyEntities)
		{
			if (!addForceToNearbyEntities.stateTimer.isRunning || addForceToNearbyEntities.stateTimer.IsTimerElapsed(CurrentTick))
			{
				addForceToNearbyEntities.state = AddForceToNearbyEntitiesCD.State.Active;
				addForceToNearbyEntities.stateTimer.Start(CurrentTick, addForceToNearbyEntities.activeDuration, TickRate);
			}
		}

		private void Active(ref AddForceToNearbyEntitiesCD addForceToNearbyEntities, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (!(addForceToNearbyEntities.inactiveDuration <= 0f) && (!addForceToNearbyEntities.stateTimer.isRunning || addForceToNearbyEntities.stateTimer.IsTimerElapsed(CurrentTick)))
			{
				addForceToNearbyEntities.stateTimer.Start(CurrentTick, addForceToNearbyEntities.inactiveDuration, TickRate);
				addForceToNearbyEntities.state = AddForceToNearbyEntitiesCD.State.Inactive;
			}
		}

		private void ApplyForce(Entity entity, ref AddForceToNearbyEntitiesCD addForceToNearbyEntities, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (nearbyEntities.IsEmpty)
			{
				return;
			}
			float num = addForceToNearbyEntities.force;
			if (addForceToNearbyEntities.state == AddForceToNearbyEntitiesCD.State.Active)
			{
				float num2 = 1f;
				if (addForceToNearbyEntities.stateTimer.isRunning && addForceToNearbyEntities.stateTimer.targetTicks != 0)
				{
					num2 = addForceToNearbyEntities.activeForceMultiplierCurve.Evaluate(addForceToNearbyEntities.stateTimer.GetElapsedRatio(CurrentTick));
				}
				num += addForceToNearbyEntities.forceDuringActivation * num2;
			}
			if (num == 0f)
			{
				return;
			}
			LocalTransform localTransform = TranslationLookup[entity];
			FactionLookup.TryGetComponent(entity, out var componentData);
			for (int i = 0; i < nearbyEntities.Length; i++)
			{
				Entity entity2 = nearbyEntities[i].entity;
				FactionLookup.TryGetComponent(entity2, out var componentData2);
				if (componentData.CanAttack(componentData2, worldInfo) && PhysicsVelocityLookup.TryGetComponent(entity2, out var componentData3) && TranslationLookup.TryGetComponent(entity2, out var componentData4) && EnemyLookup.HasComponent(entity2) && !ImmuneToPushBackLookup.HasComponent(entity2) && (!EntityDestroyedLookup.HasComponent(entity2) || !EntityDestroyedLookup.IsComponentEnabled(entity2)) && !(math.distancesq(localTransform.Position, componentData4.Position) > addForceToNearbyEntities.radiusSq) && (!addForceToNearbyEntities.checkLineOfSight || !RayCastIsBlocked(localTransform.Position, componentData4.Position, OwnerLookup.HasComponent(entity) ? OwnerLookup[entity].owner : Entity.Null, CollisionWorld, TileAccessor)))
				{
					float3 float5 = math.normalizesafe(componentData4.Position - localTransform.Position);
					componentData3.AddLinear2D(num * float5 * DeltaTime);
					Ecb.SetComponent(entity2, componentData3);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AddForceToNearbyEntitiesCD_RW_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AddForceToNearbyEntitiesCD>(nativeArrayPtr2, i), bufferAccessor[i]);
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AddForceToNearbyEntitiesCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AddForceToNearbyEntitiesCD>(nativeArrayPtr2, j), bufferAccessor[j]);
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AddForceToNearbyEntitiesCD>(nativeArrayPtr2, k), bufferAccessor[k]);
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
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToPushBackCD> __ImmuneToPushBackCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		public AddForceJob.InternalCompilerQueryAndHandleData __AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__ImmuneToPushBackCD_RO_ComponentLookup = state.GetComponentLookup<ImmuneToPushBackCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__Unity_Physics_PhysicsVelocity_RO_ComponentLookup = state.GetComponentLookup<PhysicsVelocity>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000001F5_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000001F5_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000001F5_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000001F6_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000001F6_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000001F6_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_000001F7_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000001F7_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000001F7_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_000001F8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000001F8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000001F8_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private EntityQuery _addForceQuery;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1654656867_0;

	private EntityQuery __query_1654656867_1;

	private EntityQuery __query_1654656867_2;

	private EntityQuery __query_1654656867_3;

	private EntityQuery __query_1654656867_4;

	private EntityQuery __query_1654656867_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		_addForceQuery = __query_1654656867_0;
		state.RequireForUpdate(_addForceQuery);
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<ClientServerTickRate>();
	}

	[BurstCompile]
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
		EntityCommandBuffer ecb = __query_1654656867_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		CollisionWorld collisionWorld = __query_1654656867_2.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld;
		WorldInfoCD singleton = __query_1654656867_3.GetSingleton<WorldInfoCD>();
		__query_1654656867_4.TryGetSingleton<NetworkTime>(out var value);
		_tileAccessor.Update(ref state);
		AddForceJob job = new AddForceJob
		{
			EnemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			FactionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			ImmuneToPushBackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToPushBackCD_RO_ComponentLookup, ref state),
			TranslationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			PhysicsVelocityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RO_ComponentLookup, ref state),
			OwnerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			CollisionWorld = collisionWorld,
			TileAccessor = _tileAccessor,
			DeltaTime = deltaTime,
			Ecb = ecb,
			worldInfo = singleton,
			CurrentTick = value.ServerTick,
			TickRate = (uint)__query_1654656867_5.GetSingleton<ClientServerTickRate>().SimulationTickRate
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, _addForceQuery, state.Dependency, ref state, hasUserDefinedQuery: true);
	}

	private static bool RayCastIsBlocked(float3 from, float3 to, Entity ownerEntity, CollisionWorld collisionWorld, TileAccessor tileAccessor)
	{
		int2 int5 = to.RoundToInt2();
		float3 x = to - from;
		float3 float5 = math.normalizesafe(x, new float3(0f, 0f, 1f));
		float y = math.length(x);
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
				if (math.any((raycastHit.Position + float5 * 0.1f).RoundToInt2() != int5) && ownerEntity != raycastHit.Entity)
				{
					allHits.Dispose();
					return true;
				}
			}
		}
		allHits.Dispose();
		y = math.max(0.1f, y);
		if (SinglePugMap.RaycastWalls(from.ToFloat2(), float5.ToFloat2(), y, out var _, tileAccessor))
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(AddForceJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__AddForceToNearbyEntitiesSystem_AddForceJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform, AddForceToNearbyEntitiesCD, NearbyEntitiesBufferCD>();
		__query_1654656867_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1654656867_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1654656867_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1654656867_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1654656867_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1654656867_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000001F5_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000001F6_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000001F7_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000001F8_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((AddForceToNearbyEntitiesSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AddForceToNearbyEntitiesSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AddForceToNearbyEntitiesSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AddForceToNearbyEntitiesSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AddForceToNearbyEntitiesSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.Automation;
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

namespace PlayerEquipment
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(AfterUpdateStateSystemGroup))]
	public struct PlayerRemoteDetonatorRoutineSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct RemoteDetonatorJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<PlayerRoutineCD> __PlayerRoutineCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<UseOffHandStateCD> __PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PlayerRoutineCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerRoutineCD>();
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>();
						__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<UseOffHandStateCD>();
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PlayerRoutineCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
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
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerRoutineCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<UseOffHandStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
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
				public void Run(ref RemoteDetonatorJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RemoteDetonatorJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RemoteDetonatorJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RemoteDetonatorJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RemoteDetonatorJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RemoteDetonatorJob job, EntityManager entityManager)
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
			public CollisionWorld collisionWorld;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> objectDataLookup;

			public ComponentLookup<ElectricityCD> electricityLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref PlayerRoutineCD playerRoutineCD, ref PlayerStateCD playerStateCD, ref UseOffHandStateCD useOffHandStateCD, LocalTransform transform, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				if (playerRoutineCD.activeRoutine != PlayerRoutines.RemoteDetonation)
				{
					return;
				}
				if (useOffHandStateCD.remoteDetonatorTimer.IsTimerElapsed(currentTick))
				{
					playerRoutineCD.activeRoutine = PlayerRoutines.Inactive;
					playerStateCD.SetNextState(PlayerStateEnum.Walk);
				}
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				bool flag = false;
				if (collisionWorld.SphereCastAll(transform.Position, 8f, float3.zero, 0f, ref outHits, new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				}))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						Entity entity2 = outHits[i].Entity;
						if (objectDataLookup.TryGetComponent(entity2, out var componentData) && componentData.objectID == ObjectID.RemoteExplosive && electricityLookup.HasComponent(entity2))
						{
							electricityLookup.GetRefRW(entity2).ValueRW.electricityAmountLeft = 25;
							flag = true;
						}
					}
				}
				outHits.Dispose();
				if (!useOffHandStateCD.remoteDetonatorHadAnyTriggered && flag)
				{
					useOffHandStateCD.remoteDetonatorHadAnyTriggered = true;
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.RemoteDetonatorExplosionSfx,
							position1 = transform.Position,
							localOnlyEffect = 1
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerRoutineCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_UseOffHandStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref PlayerRoutineCD playerRoutineCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, i);
						ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr3, i);
						ref UseOffHandStateCD useOffHandStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr4, i);
						ref LocalTransform reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, i);
						Execute(entity, ref playerRoutineCD, ref playerStateCD, ref useOffHandStateCD, reference, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD);
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
							ref PlayerRoutineCD playerRoutineCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, nextRangeBegin);
							ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr3, nextRangeBegin);
							ref UseOffHandStateCD useOffHandStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr4, nextRangeBegin);
							ref LocalTransform reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
							ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, nextRangeBegin);
							Execute(entity2, ref playerRoutineCD2, ref playerStateCD2, ref useOffHandStateCD2, reference2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2);
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
						ref PlayerRoutineCD playerRoutineCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, j);
						ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr3, j);
						ref UseOffHandStateCD useOffHandStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr4, j);
						ref LocalTransform reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, j);
						Execute(entity3, ref playerRoutineCD3, ref playerStateCD3, ref useOffHandStateCD3, reference3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3);
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
						ref PlayerRoutineCD playerRoutineCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerRoutineCD>(nativeArrayPtr2, k);
						ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr3, k);
						ref UseOffHandStateCD useOffHandStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UseOffHandStateCD>(nativeArrayPtr4, k);
						ref LocalTransform reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, k);
						Execute(entity4, ref playerRoutineCD4, ref playerStateCD4, ref useOffHandStateCD4, reference4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4);
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

			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RW_ComponentLookup;

			public RemoteDetonatorJob.InternalCompilerQueryAndHandleData __PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__Pug_Automation_ElectricityCD_RW_ComponentLookup = state.GetComponentLookup<ElectricityCD>();
				__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007652_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007652_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007652_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007653_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007653_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007653_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1332044416_0;

		private EntityQuery __query_1332044416_1;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PhysicsWorldSingleton>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1332044416_0.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RemoteDetonatorJob
			{
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				collisionWorld = __query_1332044416_1.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RW_ComponentLookup, ref state),
				currentTick = value.ServerTick
			}, __TypeHandle.__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(RemoteDetonatorJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_PlayerRemoteDetonatorRoutineSystem_RemoteDetonatorJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1332044416_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1332044416_1 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00007652_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007653_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PlayerRemoteDetonatorRoutineSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerRemoteDetonatorRoutineSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PlayerRemoteDetonatorRoutineSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}

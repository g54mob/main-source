using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interaction;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;

namespace PlayerState
{
	[BurstCompile]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct UpdatePlayerStateAfterPhysicsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct UpdateNoClipJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerMovementCD> __PlayerMovementCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PhysicsGraphicalSmoothing> __Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RW_ComponentTypeHandle;

					public ComponentTypeHandle<WalkStateCD> __PlayerState_WalkStateCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<SimulationTickStartPositionCD> __SimulationTickStartPositionCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<InteractorCD> __Interaction_InteractorCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EffectiveVelocityCD> __EffectiveVelocityCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerColliderCD> __PlayerColliderCD_RO_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
						__PlayerMovementCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerMovementCD>(isReadOnly: true);
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsGraphicalSmoothing>();
						__PlayerState_WalkStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WalkStateCD>();
						__SimulationTickStartPositionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SimulationTickStartPositionCD>(isReadOnly: true);
						__Interaction_InteractorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InteractorCD>();
						__EffectiveVelocityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EffectiveVelocityCD>(isReadOnly: true);
						__PlayerColliderCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerColliderCD>(isReadOnly: true);
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PlayerState_PlayerStateCD_RW_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
						__PlayerMovementCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RW_ComponentTypeHandle.Update(ref state);
						__PlayerState_WalkStateCD_RW_ComponentTypeHandle.Update(ref state);
						__SimulationTickStartPositionCD_RO_ComponentTypeHandle.Update(ref state);
						__Interaction_InteractorCD_RW_ComponentTypeHandle.Update(ref state);
						__EffectiveVelocityCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerColliderCD_RO_ComponentTypeHandle.Update(ref state);
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
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerMovementCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SimulationTickStartPositionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EffectiveVelocityCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerColliderCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsGraphicalSmoothing>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WalkStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<InteractorCD>();
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
				public void Run(ref UpdateNoClipJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateNoClipJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateNoClipJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateNoClipJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateNoClipJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateNoClipJob job, EntityManager entityManager)
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

			public PhysicsWorld physicsWorld;

			public TileAccessor tileAccessor;

			public float deltaTime;

			public EntityCommandBuffer ecb;

			public bool isServer;

			public NetworkTick currentTick;

			public bool isFinalPredictionTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref PlayerStateCD playerStateCD, in ClientInput clientInput, ref LocalTransform localTransform, in PlayerMovementCD playerMovementCD, ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing, ref WalkStateCD walkStateCD, in SimulationTickStartPositionCD simulationTickStartPositionCD, ref InteractorCD interactorCD, in EffectiveVelocityCD effectiveVelocityCD, in PlayerColliderCD playerColliderCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
			{
				switch (playerStateCD.level1State)
				{
				case PlayerStateEnum.Walk:
					Walk.UpdateStateAfterPhysics(entity, ref walkStateCD, in playerMovementCD, in simulationTickStartPositionCD, in localTransform, ecb, isServer);
					break;
				case PlayerStateEnum.NoClip:
					NoClip.UpdateStateAfterPhysics(in clientInput, ref localTransform, in playerMovementCD, ref physicsGraphicalSmoothing, deltaTime, isFinalPredictionTick);
					break;
				case PlayerStateEnum.BoatRiding:
					BoatRiding.UpdateStateAfterPhysics(entity, ref interactorCD, ref playerStateCD, in effectiveVelocityCD, in localTransform, in playerColliderCD, ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, currentTick, in tileAccessor, ref physicsWorld);
					break;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerMovementCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_WalkStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SimulationTickStartPositionCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Interaction_InteractorCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EffectiveVelocityCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerColliderCD_RO_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr12 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, i);
						ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i);
						ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i);
						ref PlayerMovementCD playerMovementCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr5, i);
						ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr6, i);
						ref WalkStateCD walkStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WalkStateCD>(nativeArrayPtr7, i);
						ref SimulationTickStartPositionCD simulationTickStartPositionCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SimulationTickStartPositionCD>(nativeArrayPtr8, i);
						ref InteractorCD interactorCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr9, i);
						ref EffectiveVelocityCD effectiveVelocityCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr10, i);
						ref PlayerColliderCD playerColliderCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerColliderCD>(nativeArrayPtr11, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
						Execute(entity, ref playerStateCD, in clientInput, ref localTransform, in playerMovementCD, ref physicsGraphicalSmoothing, ref walkStateCD, in simulationTickStartPositionCD, ref interactorCD, in effectiveVelocityCD, in playerColliderCD, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr12, i));
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
							ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, nextRangeBegin);
							ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin);
							ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin);
							ref PlayerMovementCD playerMovementCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr5, nextRangeBegin);
							ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr6, nextRangeBegin);
							ref WalkStateCD walkStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WalkStateCD>(nativeArrayPtr7, nextRangeBegin);
							ref SimulationTickStartPositionCD simulationTickStartPositionCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SimulationTickStartPositionCD>(nativeArrayPtr8, nextRangeBegin);
							ref InteractorCD interactorCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr9, nextRangeBegin);
							ref EffectiveVelocityCD effectiveVelocityCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr10, nextRangeBegin);
							ref PlayerColliderCD playerColliderCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerColliderCD>(nativeArrayPtr11, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(entity2, ref playerStateCD2, in clientInput2, ref localTransform2, in playerMovementCD2, ref physicsGraphicalSmoothing2, ref walkStateCD2, in simulationTickStartPositionCD2, ref interactorCD2, in effectiveVelocityCD2, in playerColliderCD2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr12, nextRangeBegin));
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
						ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, j);
						ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j);
						ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j);
						ref PlayerMovementCD playerMovementCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr5, j);
						ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr6, j);
						ref WalkStateCD walkStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WalkStateCD>(nativeArrayPtr7, j);
						ref SimulationTickStartPositionCD simulationTickStartPositionCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SimulationTickStartPositionCD>(nativeArrayPtr8, j);
						ref InteractorCD interactorCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr9, j);
						ref EffectiveVelocityCD effectiveVelocityCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr10, j);
						ref PlayerColliderCD playerColliderCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerColliderCD>(nativeArrayPtr11, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
						Execute(entity3, ref playerStateCD3, in clientInput3, ref localTransform3, in playerMovementCD3, ref physicsGraphicalSmoothing3, ref walkStateCD3, in simulationTickStartPositionCD3, ref interactorCD3, in effectiveVelocityCD3, in playerColliderCD3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr12, j));
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
						ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr2, k);
						ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k);
						ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k);
						ref PlayerMovementCD playerMovementCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr5, k);
						ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr6, k);
						ref WalkStateCD walkStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WalkStateCD>(nativeArrayPtr7, k);
						ref SimulationTickStartPositionCD simulationTickStartPositionCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SimulationTickStartPositionCD>(nativeArrayPtr8, k);
						ref InteractorCD interactorCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr9, k);
						ref EffectiveVelocityCD effectiveVelocityCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr10, k);
						ref PlayerColliderCD playerColliderCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerColliderCD>(nativeArrayPtr11, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
						Execute(entity4, ref playerStateCD4, in clientInput4, ref localTransform4, in playerMovementCD4, ref physicsGraphicalSmoothing4, ref walkStateCD4, in simulationTickStartPositionCD4, ref interactorCD4, in effectiveVelocityCD4, in playerColliderCD4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr12, k));
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
			public UpdateNoClipJob.InternalCompilerQueryAndHandleData __PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000714F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000714F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000714F_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007150_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007150_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007150_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_00007151_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_00007151_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00007151_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_675716879_0;

		private EntityQuery __query_675716879_1;

		private EntityQuery __query_675716879_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
		}

		[BurstCompile]
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
			__query_675716879_0.TryGetSingleton<NetworkTime>(out var value);
			BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_675716879_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateNoClipJob
			{
				physicsWorld = __query_675716879_2.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
				tileAccessor = _tileAccessor,
				deltaTime = state.WorldUnmanaged.Time.DeltaTime,
				ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
				isServer = state.WorldUnmanaged.IsServer(),
				currentTick = value.ServerTick,
				isFinalPredictionTick = value.IsFinalPredictionTick
			}, __TypeHandle.__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(UpdateNoClipJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerState_UpdatePlayerStateAfterPhysicsSystem_UpdateNoClipJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_675716879_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_675716879_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_675716879_2 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000714F_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007150_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_00007151_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateAfterPhysicsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateAfterPhysicsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateAfterPhysicsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateAfterPhysicsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStateAfterPhysicsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}

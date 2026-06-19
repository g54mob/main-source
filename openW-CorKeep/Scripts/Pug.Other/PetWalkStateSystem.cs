using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class PetWalkStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct PetWalkStateSystem_46160861_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003C9C_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003C9C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003C9C_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public double time;

		public float deltaTime;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public BufferLookup<CombatantsTrackerBuffer> combatantBuffer;

		public Entity effectEventBufferSingleton;

		public ComponentLookup<MinionCD> minionLookup;

		public ComponentLookup<ChaseStateCD> chaseStateLookup;

		public ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup;

		public ComponentLookup<MeleeAttackStateCD> meleeAttackStateLookup;

		public ComponentLookup<RangeAttackStateCD> rangeAttackStateLookup;

		public ComponentLookup<JumpAttackStateCD> jumpAttackStateLookup;

		public NetworkTick currentTick;

		public int moveAnimID;

		public int idleAnimID;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __physVelocityTypeHandle;

		public ComponentTypeHandle<PetWalkStateCD> __petWalkStateTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __orientationTypeHandle;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		public ComponentLookup<PathFindCD> __PathFindCD_ComponentLookup;

		public BufferLookup<PathFindNodeBuffer> __PathFindNodeBuffer_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EffectiveVelocityCD> __EffectiveVelocityCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref PhysicsVelocity physVelocity, [NoAlias] ref PetWalkStateCD petWalkState, [NoAlias] ref StateInfoCD stateInfo, DynamicBuffer<AnimationBuffer> anim, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref AnimationOrientationCD orientation)
		{
			if (!stateInfo.IsCurrentState(StateID.PetWalk) || !__OwnerReferenceCD_ComponentLookup.HasComponent(entity))
			{
				return;
			}
			OwnerReferenceCD ownerReferenceCD = __OwnerReferenceCD_ComponentLookup[entity];
			if (!__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(ownerReferenceCD.owner) || !__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(entity))
			{
				return;
			}
			PathFindCD pathFindCD = __PathFindCD_ComponentLookup[petWalkState.pathFindEntity];
			DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer = __PathFindNodeBuffer_BufferLookup[petWalkState.pathFindEntity];
			if (pathFindCD.targetEntity != ownerReferenceCD.owner)
			{
				pathFindCD.targetEntity = ownerReferenceCD.owner;
				__PathFindCD_ComponentLookup[petWalkState.pathFindEntity] = pathFindCD;
				return;
			}
			if (petWalkState.internalState == 0)
			{
				petWalkState.pathFindTimer.Stop();
				petWalkState.internalState = 1;
			}
			float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position;
			float3 position2 = __Unity_Transforms_LocalTransform_ComponentLookup[ownerReferenceCD.owner].Position;
			float3 float5 = float3.zero;
			float3 x = position2 - position;
			float num = math.length(x);
			bool isFighting = PetWalkStateRequest.IsFighting(in stateInfo);
			bool isMinionFightingCommandTarget = PetWalkStateRequest.IsMinionFightingCommandTarget(entity, in stateInfo, minionLookup, moveToPositionFromCommandStateLookup, chaseStateLookup, meleeAttackStateLookup, rangeAttackStateLookup, jumpAttackStateLookup);
			float maxDistanceSqrToPlayerToGo = PetWalkStateRequest.GetMaxDistanceSqrToPlayerToGo(entity, minionLookup, chaseStateLookup, isFighting, isMinionFightingCommandTarget);
			maxDistanceSqrToPlayerToGo *= 0.9f;
			if ((!petWalkState.attemptToAttackCooldownTimer.isRunning || petWalkState.attemptToAttackCooldownTimer.IsTimerElapsed(time)) && math.distancesq(position, position2) < maxDistanceSqrToPlayerToGo && combatantBuffer.HasBuffer(ownerReferenceCD.owner) && chaseStateLookup.TryGetComponent(entity, out var componentData))
			{
				for (int i = 0; i < combatantBuffer[ownerReferenceCD.owner].Length; i++)
				{
					if (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(combatantBuffer[ownerReferenceCD.owner][i].Target))
					{
						float3 position3 = __Unity_Transforms_LocalTransform_ComponentLookup[combatantBuffer[ownerReferenceCD.owner][i].Target].Position;
						if (math.distancesq(position, position3) < componentData.chaseAtDistanceSq * 0.9f)
						{
							petWalkState.cooldownTimer.Start(time, 0.5f);
							petWalkState.attemptToAttackCooldownTimer.Start(time, 3f);
							stateInfo.LeaveState();
							return;
						}
					}
				}
			}
			if (num > 20f)
			{
				float3 float6 = position2 + new float3(0.2f, 0f, -0.2f);
				ecb.SetComponent(entity, LocalTransform.FromPosition(float6));
				petWalkState.pathFindTimer.Stop();
				EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
				{
					effectID = EffectID.PetTeleport,
					position1 = float6
				});
				return;
			}
			float2 float7 = (__EffectiveVelocityCD_ComponentLookup.HasComponent(ownerReferenceCD.owner) ? __EffectiveVelocityCD_ComponentLookup[ownerReferenceCD.owner].Value : float2.zero);
			bool num2 = num > ((math.length(float7) > 0.1f) ? 0f : 2f);
			if (PathFindUtility.GetDirection(in pathFindCD, pathFindNodeBuffer, position.ToFloat2(), out var direction))
			{
				float5 = direction.ToFloat3();
				petWalkState.pathFindTimer.Stop();
			}
			else
			{
				if (!petWalkState.pathFindTimer.isRunning)
				{
					petWalkState.pathFindTimer.Start(time, 1f);
					petWalkState.lastDistanceToOwner = num;
				}
				else if (num < petWalkState.lastDistanceToOwner - 0.1f)
				{
					petWalkState.pathFindTimer.Start(time, 1f);
					petWalkState.lastDistanceToOwner = num;
				}
				else if (petWalkState.pathFindTimer.IsTimerElapsed(time))
				{
					float3 float8 = position2 + new float3(0.2f, 0f, -0.2f);
					ecb.SetComponent(entity, LocalTransform.FromPosition(float8));
					petWalkState.pathFindTimer.Stop();
					EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
					{
						effectID = EffectID.PetTeleport,
						position1 = float8
					});
				}
				else if (petWalkState.pathFindTimer.GetElapsedTime(time) > 0.5f && anim.GetLastAddedElement(in animationBufferPointer).animID != idleAnimID)
				{
					AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, anim, ref animationBufferPointer);
				}
				if (petWalkState.pathFindTimer.isRunning && petWalkState.pathFindTimer.GetElapsedTime(time) <= 0.5f)
				{
					float5 = math.normalizesafe(x);
				}
			}
			if (math.any(float5 != float3.zero))
			{
				if (anim.GetLastAddedElement(in animationBufferPointer).animID != moveAnimID)
				{
					AnimationUtilities.TriggerAnimation(moveAnimID, currentTick, anim, ref animationBufferPointer);
				}
				orientation.SetFacingDirectionFromVector(float5);
			}
			if (num2)
			{
				float num3 = 0f;
				if (float.IsNormal(float7.x) && float.IsNormal(float7.y))
				{
					num3 = math.length(math.min(1000, float7)) * 10f;
				}
				if (num3 < 1f && __MovementSpeedCD_ComponentLookup.HasComponent(entity))
				{
					num3 = __MovementSpeedCD_ComponentLookup[entity].speed;
				}
				float end = PetWalkStateUtility.CalculateSpeedMultiplier(num);
				petWalkState.currentSpeedMultiplier = math.lerp(petWalkState.currentSpeedMultiplier, end, 0.1f);
				float num4 = PetWalkStateUtility.CalculateMovementSpeed(num3, petWalkState.currentSpeedMultiplier);
				physVelocity.AddLinear2D(float5 * num4 * deltaTime);
			}
			else
			{
				if (anim.GetLastAddedElement(in animationBufferPointer).animID != idleAnimID)
				{
					AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, anim, ref animationBufferPointer);
				}
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __physVelocityTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __petWalkStateTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __orientationTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetWalkStateCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetWalkStateCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetWalkStateCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetWalkStateCD>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, l));
				}
				num2 >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003C9C_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003C9C_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PetWalkStateSystem_46160861_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

		public ComponentTypeHandle<PetWalkStateCD> __PetWalkStateCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public ComponentLookup<PathFindCD> __PathFindCD_RW_ComponentLookup;

		public BufferLookup<PathFindNodeBuffer> __PathFindNodeBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EffectiveVelocityCD> __EffectiveVelocityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<CombatantsTrackerBuffer> __CombatantsTrackerBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ChaseStateCD> __ChaseStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MoveToPositionFromCommandStateCD> __MoveToPositionFromCommandStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MeleeAttackStateCD> __MeleeAttackStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RangeAttackStateCD> __RangeAttackStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<JumpAttackStateCD> __JumpAttackStateCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
			__PetWalkStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PetWalkStateCD>();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__PathFindCD_RW_ComponentLookup = state.GetComponentLookup<PathFindCD>();
			__PathFindNodeBuffer_RW_BufferLookup = state.GetBufferLookup<PathFindNodeBuffer>();
			__EffectiveVelocityCD_RO_ComponentLookup = state.GetComponentLookup<EffectiveVelocityCD>(isReadOnly: true);
			__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
			__CombatantsTrackerBuffer_RO_BufferLookup = state.GetBufferLookup<CombatantsTrackerBuffer>(isReadOnly: true);
			__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
			__ChaseStateCD_RO_ComponentLookup = state.GetComponentLookup<ChaseStateCD>(isReadOnly: true);
			__MoveToPositionFromCommandStateCD_RO_ComponentLookup = state.GetComponentLookup<MoveToPositionFromCommandStateCD>(isReadOnly: true);
			__MeleeAttackStateCD_RO_ComponentLookup = state.GetComponentLookup<MeleeAttackStateCD>(isReadOnly: true);
			__RangeAttackStateCD_RO_ComponentLookup = state.GetComponentLookup<RangeAttackStateCD>(isReadOnly: true);
			__JumpAttackStateCD_RO_ComponentLookup = state.GetComponentLookup<JumpAttackStateCD>(isReadOnly: true);
		}
	}

	private const float DISTANCESQ_TO_PLAYER_TO_PRIO_FOLLOW_OVER_ATTACKING = 64f;

	private const float DISTANCESQ_TO_ENEMY_TO_PRIO_ATTACKING_OVER_FOLLOWING = 64f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_620361162_0;

	private EntityQuery __query_620361162_1;

	private EntityQuery __query_620361162_2;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		RequireForUpdate<EffectEventBuffer>();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BufferLookup<CombatantsTrackerBuffer> combatantBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CombatantsTrackerBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		Entity effectEventBufferSingleton = __query_620361162_1.GetSingletonEntity();
		ComponentLookup<MinionCD> minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<ChaseStateCD> chaseStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChaseStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPositionFromCommandStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MeleeAttackStateCD> meleeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeAttackStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<RangeAttackStateCD> rangeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeAttackStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<JumpAttackStateCD> jumpAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__JumpAttackStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		__query_620361162_2.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		int moveAnimID = -281135240;
		int idleAnimID = -601574123;
		PetWalkStateSystem_46160861_LambdaJob_0_Execute(ref time, ref deltaTime, ref ecb, ref combatantBuffer, ref effectEventBufferSingleton, ref minionLookup, ref chaseStateLookup, ref moveToPositionFromCommandStateLookup, ref meleeAttackStateLookup, ref rangeAttackStateLookup, ref jumpAttackStateLookup, ref currentTick, ref moveAnimID, ref idleAnimID);
		base.OnUpdate();
	}

	private void PetWalkStateSystem_46160861_LambdaJob_0_Execute(ref double time, ref float deltaTime, ref EntityCommandBuffer ecb, ref BufferLookup<CombatantsTrackerBuffer> combatantBuffer, ref Entity effectEventBufferSingleton, ref ComponentLookup<MinionCD> minionLookup, ref ComponentLookup<ChaseStateCD> chaseStateLookup, ref ComponentLookup<MoveToPositionFromCommandStateCD> moveToPositionFromCommandStateLookup, ref ComponentLookup<MeleeAttackStateCD> meleeAttackStateLookup, ref ComponentLookup<RangeAttackStateCD> rangeAttackStateLookup, ref ComponentLookup<JumpAttackStateCD> jumpAttackStateLookup, ref NetworkTick currentTick, ref int moveAnimID, ref int idleAnimID)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PetWalkStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__OwnerReferenceCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PathFindCD_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PathFindNodeBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__EffectiveVelocityCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		PetWalkStateSystem_46160861_LambdaJob_0_Job value = new PetWalkStateSystem_46160861_LambdaJob_0_Job
		{
			time = time,
			deltaTime = deltaTime,
			ecb = ecb,
			combatantBuffer = combatantBuffer,
			effectEventBufferSingleton = effectEventBufferSingleton,
			minionLookup = minionLookup,
			chaseStateLookup = chaseStateLookup,
			moveToPositionFromCommandStateLookup = moveToPositionFromCommandStateLookup,
			meleeAttackStateLookup = meleeAttackStateLookup,
			rangeAttackStateLookup = rangeAttackStateLookup,
			jumpAttackStateLookup = jumpAttackStateLookup,
			currentTick = currentTick,
			moveAnimID = moveAnimID,
			idleAnimID = idleAnimID,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__physVelocityTypeHandle = __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle,
			__petWalkStateTypeHandle = __TypeHandle.__PetWalkStateCD_RW_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__animTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__orientationTypeHandle = __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle,
			__OwnerReferenceCD_ComponentLookup = __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__PathFindCD_ComponentLookup = __TypeHandle.__PathFindCD_RW_ComponentLookup,
			__PathFindNodeBuffer_BufferLookup = __TypeHandle.__PathFindNodeBuffer_RW_BufferLookup,
			__EffectiveVelocityCD_ComponentLookup = __TypeHandle.__EffectiveVelocityCD_RO_ComponentLookup,
			__MovementSpeedCD_ComponentLookup = __TypeHandle.__MovementSpeedCD_RO_ComponentLookup
		};
		value.__ChunkBaseEntityIndices = __query_620361162_0.CalculateBaseEntityIndexArray(base.CheckedStateRef.WorldUpdateAllocator);
		if (!__query_620361162_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			PetWalkStateSystem_46160861_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_620361162_0, jobPtr);
		}
		time = value.time;
		deltaTime = value.deltaTime;
		ecb = value.ecb;
		combatantBuffer = value.combatantBuffer;
		effectEventBufferSingleton = value.effectEventBufferSingleton;
		minionLookup = value.minionLookup;
		chaseStateLookup = value.chaseStateLookup;
		moveToPositionFromCommandStateLookup = value.moveToPositionFromCommandStateLookup;
		meleeAttackStateLookup = value.meleeAttackStateLookup;
		rangeAttackStateLookup = value.rangeAttackStateLookup;
		jumpAttackStateLookup = value.jumpAttackStateLookup;
		currentTick = value.currentTick;
		moveAnimID = value.moveAnimID;
		idleAnimID = value.idleAnimID;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PhysicsVelocity>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PetWalkStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		__query_620361162_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_620361162_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_620361162_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public PetWalkStateSystem()
	{
	}
}

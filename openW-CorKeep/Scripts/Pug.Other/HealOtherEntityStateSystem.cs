using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugTilemap;
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
public class HealOtherEntityStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct HealOtherEntityStateSystem_747702BA_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003A8B_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003A8B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003A8B_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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
		public CollisionWorld collisionWorld;

		public TileAccessor tileLookup;

		public double time;

		public BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> healedByOtherEntitiesBufferLookUp;

		[ReadOnly]
		public BufferLookup<HydrasBuffer> moleBufferLookUp;

		public int startChannelingAnimID;

		public int channelingAnimID;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerCDLookup;

		public NetworkTick currentTick;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<HealOtherEntityStateCD> __healStateTypeHandle;

		public BufferTypeHandle<EntitiesHealedBuffer> __entitiesHealedTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __orientationCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __attackTagsTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> __AmountOfTimesTakingDamageCounterCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MainHydraRefCD> __MainHydraRefCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref HealOtherEntityStateCD healState, DynamicBuffer<EntitiesHealedBuffer> entitiesHealed, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref AnimationOrientationCD orientationCD, [NoAlias] in BehaviourTagsCD attackTags)
		{
			if (!stateInfo.IsCurrentState(StateID.HealOtherEntity))
			{
				entitiesHealed.Clear();
				return;
			}
			bool flag = healState.targetEntity != Entity.Null && (!entityDestroyedLookup.HasComponent(healState.targetEntity) || !entityDestroyedLookup.IsComponentEnabled(healState.targetEntity)) && __Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(healState.targetEntity);
			if (flag)
			{
				if (healState.keepHealingUntilTakingDamageXTimes > 0 && __AmountOfTimesTakingDamageCounterCD_ComponentLookup.HasComponent(entity))
				{
					if ((healState.internalState == 1 || healState.internalState == 2) && healState.internalTimer.isRunning && healState.damageTakenCountOnStartingToShoot + healState.keepHealingUntilTakingDamageXTimes <= __AmountOfTimesTakingDamageCounterCD_ComponentLookup[entity].count)
					{
						flag = false;
					}
				}
				else
				{
					flag = !damageTakenTriggerCDLookup.HasComponent(entity) || !damageTakenTriggerCDLookup.IsComponentEnabled(entity);
				}
			}
			if (flag)
			{
				float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position;
				float3 position2 = __Unity_Transforms_LocalTransform_ComponentLookup[healState.targetEntity].Position;
				if (math.length(position2 - position) < healState.maxReachDistance && !healState.skipVisibilityCheck)
				{
					CollisionFilter filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 1u
					};
					RaycastInput input = new RaycastInput
					{
						Start = position + new float3(0f, 0.5f, 0f),
						End = position2 + new float3(0f, 0.5f, 0f),
						Filter = filter
					};
					if (collisionWorld.CastRay(input))
					{
						flag = false;
					}
					if (flag)
					{
						int2 int5 = position.RoundToInt2();
						int2 end = position2.RoundToInt2();
						int2 pos = int5;
						do
						{
							if (tileLookup.GetTopType(pos).IsWallTile())
							{
								flag = false;
								break;
							}
						}
						while (MathUtilities.NextPosOnLine(int5, end, ref pos));
					}
				}
			}
			if (!flag)
			{
				healState.targetEntity = Entity.Null;
				float newLifespan = Unity.Mathematics.Random.CreateFromIndex((uint)((double)entity.Index + time + 1.0)).NextFloat(healState.minCooldown, healState.maxCooldown);
				healState.cooldownTimer.Start(time, newLifespan);
				stateInfo.LeaveState();
				return;
			}
			if (healState.targetEntity != Entity.Null && __Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(healState.targetEntity))
			{
				float3 position3 = __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position;
				float3 x = __Unity_Transforms_LocalTransform_ComponentLookup[healState.targetEntity].Position - position3;
				x = math.normalizesafe(x);
				orientationCD.SetFacingDirectionFromVector(x);
			}
			if (healState.internalState == 0 && !healState.internalTimer.isRunning)
			{
				AnimationUtilities.TriggerAnimation(startChannelingAnimID, currentTick, animationBuffer, ref animationBufferPointer);
				healState.internalTimer.Start(time, healState.anticipationDuration);
				healState.internalState = 1;
				if (healState.keepHealingUntilTakingDamageXTimes > 0 && __AmountOfTimesTakingDamageCounterCD_ComponentLookup.HasComponent(entity))
				{
					healState.damageTakenCountOnStartingToShoot = __AmountOfTimesTakingDamageCounterCD_ComponentLookup[entity].count;
				}
			}
			else if (healState.internalState == 1 && healState.internalTimer.isRunning && healState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(channelingAnimID, currentTick, animationBuffer, ref animationBufferPointer);
				healState.internalTimer.Start(time, healState.healDuration);
				healState.internalState = 2;
			}
			else if (healState.internalState == 2 && healState.internalTimer.isRunning && !healState.internalTimer.IsTimerElapsed(time))
			{
				if (!healedByOtherEntitiesBufferLookUp.HasComponent(healState.targetEntity))
				{
					return;
				}
				DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> dynamicBuffer = healedByOtherEntitiesBufferLookUp[healState.targetEntity];
				bool flag2 = false;
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					if (dynamicBuffer[i].entityHealing == entity)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					return;
				}
				entitiesHealed.Clear();
				if (__MainHydraRefCD_ComponentLookup.HasComponent(healState.targetEntity))
				{
					Entity mainHydra = __MainHydraRefCD_ComponentLookup[healState.targetEntity].mainHydra;
					if (moleBufferLookUp.HasComponent(mainHydra))
					{
						DynamicBuffer<HydrasBuffer> dynamicBuffer2 = moleBufferLookUp[mainHydra];
						for (int j = 0; j < dynamicBuffer2.Length; j++)
						{
							entitiesHealed.Add(new EntitiesHealedBuffer
							{
								entity = dynamicBuffer2[j].hydra
							});
						}
					}
				}
				else
				{
					entitiesHealed.Add(new EntitiesHealedBuffer
					{
						entity = healState.targetEntity
					});
				}
				for (int k = 0; k < entitiesHealed.Length; k++)
				{
					Entity entity2 = entitiesHealed[k].entity;
					if (__HealthCD_ComponentLookup.HasComponent(entity2) && healedByOtherEntitiesBufferLookUp.TryGetBuffer(entity2, out var bufferData))
					{
						bufferData.Add(new IsBeingBeHealedByOtherEntitiesBuffer
						{
							entityHealing = entity,
							amountPerSecond = ((healState.healPercentageOfHp && __HealthCD_ComponentLookup.HasComponent(entity2)) ? ((int)math.round((float)(__HealthCD_ComponentLookup[entity2].maxHealth * healState.healPerSecond) / 100f)) : healState.healPerSecond)
						});
					}
				}
			}
			else if (healState.internalState == 2 && healState.internalTimer.isRunning && healState.internalTimer.IsTimerElapsed(time))
			{
				entitiesHealed.Clear();
				healState.targetEntity = Entity.Null;
				float newLifespan2 = Unity.Mathematics.Random.CreateFromIndex((uint)((double)entity.Index + time + 1.0)).NextFloat(healState.minCooldown, healState.maxCooldown);
				healState.cooldownTimer.Start(time, newLifespan2);
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __healStateTypeHandle);
			BufferAccessor<EntitiesHealedBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __entitiesHealedTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __orientationCDTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __attackTagsTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealOtherEntityStateCD>(nativeArrayPtr3, i), bufferAccessor[i], bufferAccessor2[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealOtherEntityStateCD>(nativeArrayPtr3, j), bufferAccessor[j], bufferAccessor2[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealOtherEntityStateCD>(nativeArrayPtr3, k), bufferAccessor[k], bufferAccessor2[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealOtherEntityStateCD>(nativeArrayPtr3, l), bufferAccessor[l], bufferAccessor2[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003A8B_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003A8B_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<HealOtherEntityStateSystem_747702BA_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HealOtherEntityStateCD> __HealOtherEntityStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<EntitiesHealedBuffer> __EntitiesHealedBuffer_RW_BufferTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> __AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MainHydraRefCD> __MainHydraRefCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> __IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<HydrasBuffer> __HydrasBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__HealOtherEntityStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealOtherEntityStateCD>();
			__EntitiesHealedBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<EntitiesHealedBuffer>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
			__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup = state.GetComponentLookup<AmountOfTimesTakingDamageCounterCD>(isReadOnly: true);
			__MainHydraRefCD_RO_ComponentLookup = state.GetComponentLookup<MainHydraRefCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup = state.GetBufferLookup<IsBeingBeHealedByOtherEntitiesBuffer>();
			__HydrasBuffer_RO_BufferLookup = state.GetBufferLookup<HydrasBuffer>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_921692486_0;

	private EntityQuery __query_921692486_1;

	[Preserve]
	protected override void OnUpdate()
	{
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		TileAccessor tileLookup = CreateTileAccessor();
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> healedByOtherEntitiesBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<HydrasBuffer> moleBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HydrasBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		int startChannelingAnimID = 1314006782;
		int channelingAnimID = -2074345483;
		ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerCDLookup = GetComponentLookup<DamageTakenTriggerCD>(isReadOnly: true);
		__query_921692486_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		HealOtherEntityStateSystem_747702BA_LambdaJob_0_Execute(ref collisionWorld, ref tileLookup, ref time, ref healedByOtherEntitiesBufferLookUp, ref moleBufferLookUp, ref startChannelingAnimID, ref channelingAnimID, ref entityDestroyedLookup, ref damageTakenTriggerCDLookup, ref currentTick);
		base.OnUpdate();
	}

	private void HealOtherEntityStateSystem_747702BA_LambdaJob_0_Execute(ref CollisionWorld collisionWorld, ref TileAccessor tileLookup, ref double time, ref BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> healedByOtherEntitiesBufferLookUp, ref BufferLookup<HydrasBuffer> moleBufferLookUp, ref int startChannelingAnimID, ref int channelingAnimID, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ref ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerCDLookup, ref NetworkTick currentTick)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealOtherEntityStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EntitiesHealedBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MainHydraRefCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		HealOtherEntityStateSystem_747702BA_LambdaJob_0_Job value = new HealOtherEntityStateSystem_747702BA_LambdaJob_0_Job
		{
			collisionWorld = collisionWorld,
			tileLookup = tileLookup,
			time = time,
			healedByOtherEntitiesBufferLookUp = healedByOtherEntitiesBufferLookUp,
			moleBufferLookUp = moleBufferLookUp,
			startChannelingAnimID = startChannelingAnimID,
			channelingAnimID = channelingAnimID,
			entityDestroyedLookup = entityDestroyedLookup,
			damageTakenTriggerCDLookup = damageTakenTriggerCDLookup,
			currentTick = currentTick,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__healStateTypeHandle = __TypeHandle.__HealOtherEntityStateCD_RW_ComponentTypeHandle,
			__entitiesHealedTypeHandle = __TypeHandle.__EntitiesHealedBuffer_RW_BufferTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__orientationCDTypeHandle = __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle,
			__attackTagsTypeHandle = __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__AmountOfTimesTakingDamageCounterCD_ComponentLookup = __TypeHandle.__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup,
			__MainHydraRefCD_ComponentLookup = __TypeHandle.__MainHydraRefCD_RO_ComponentLookup,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup
		};
		if (!__query_921692486_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			HealOtherEntityStateSystem_747702BA_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_921692486_0, jobPtr);
		}
		collisionWorld = value.collisionWorld;
		tileLookup = value.tileLookup;
		time = value.time;
		healedByOtherEntitiesBufferLookUp = value.healedByOtherEntitiesBufferLookUp;
		moleBufferLookUp = value.moleBufferLookUp;
		startChannelingAnimID = value.startChannelingAnimID;
		channelingAnimID = value.channelingAnimID;
		entityDestroyedLookup = value.entityDestroyedLookup;
		damageTakenTriggerCDLookup = value.damageTakenTriggerCDLookup;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealOtherEntityStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EntitiesHealedBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		_queryRequiredForUpdate = (__query_921692486_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_921692486_1 = entityQueryBuilder2.Build(ref state);
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
	public HealOtherEntityStateSystem()
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class ExplodeStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct ExplodeStateSystem_704F5CB8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003A6C_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003A6C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003A6C_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public double time;

		public EntityCommandBuffer ecb;

		public uint tickRate;

		public NetworkTick currentTick;

		public ComponentLookup<HasExplodedCD> hasExplodedLookup;

		public int startExplodeAnimID;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public Entity healthChangeBufferEntity;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<ExplodeStateCD> __explodeStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __healthTypeHandle;

		[ReadOnly]
		public ComponentLookup<ExplosionCD> __ExplosionCD_ComponentLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref ExplodeStateCD explodeState, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] in LocalTransform transform, [NoAlias] in HealthCD health)
		{
			if (!stateInfo.IsCurrentState(StateID.Explode))
			{
				return;
			}
			if (explodeState.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(startExplodeAnimID, currentTick, animationBuffer, ref animationBufferPointer);
				explodeState.internalTimer.Start(time, explodeState.anticipationDuration);
				explodeState.internalState = 1;
			}
			else if (explodeState.internalState == 1 && explodeState.internalTimer.isRunning && explodeState.internalTimer.IsTimerElapsed(time))
			{
				Entity prefabEntity;
				Entity entity2 = EntityUtility.CreateEntity(ecb, transform.Position, explodeState.explosionID, 1, databaseLocal, out prefabEntity, explodeState.explosionVariation);
				if (__ExplosionCD_ComponentLookup.HasComponent(prefabEntity))
				{
					int damage = explodeState.damage;
					int tileDamage = explodeState.tileDamage;
					ExplosionCD component = __ExplosionCD_ComponentLookup[prefabEntity];
					component.damage = damage;
					component.tileDamage = tileDamage;
					component.delayTimer.Start(currentTick, 0.2f, tickRate);
					ecb.SetComponent(entity2, component);
					ecb.SetComponent(entity2, new OwnerReferenceCD
					{
						owner = entity
					});
				}
				__HealthChangeBuffer_BufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = -health.health * 20,
						skipLootDropOnDestroy = !explodeState.dropLootOnDestroy,
						bypassMaxDamagePerHit = true,
						bypassDamageReduction = true
					}
				});
				explodeState.internalState = 2;
				ExplodeStateCD component2 = explodeState;
				component2.explosionEntity = entity2;
				ecb.SetComponent(entity, component2);
				if (hasExplodedLookup.HasComponent(entity))
				{
					hasExplodedLookup.SetComponentEnabled(entity, value: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __explodeStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __healthTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeStateCD>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeStateCD>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeStateCD>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeStateCD>(nativeArrayPtr3, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003A6C_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003A6C_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ExplodeStateSystem_704F5CB8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ExplodeStateCD> __ExplodeStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<ExplosionCD> __ExplosionCD_RO_ComponentLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		public ComponentLookup<HasExplodedCD> __HasExplodedCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__ExplodeStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ExplodeStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
			__ExplosionCD_RO_ComponentLookup = state.GetComponentLookup<ExplosionCD>(isReadOnly: true);
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__HasExplodedCD_RW_ComponentLookup = state.GetComponentLookup<HasExplodedCD>();
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1055310828_0;

	private EntityQuery __query_1055310828_1;

	private EntityQuery __query_1055310828_2;

	private EntityQuery __query_1055310828_3;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		uint tickRate = (uint)__query_1055310828_1.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		__query_1055310828_2.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		ComponentLookup<HasExplodedCD> hasExplodedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasExplodedCD_RW_ComponentLookup, ref base.CheckedStateRef);
		int startExplodeAnimID = -1473092350;
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		Entity healthChangeBufferEntity = __query_1055310828_3.GetSingletonEntity();
		ExplodeStateSystem_704F5CB8_LambdaJob_0_Execute(ref time, ref ecb, ref tickRate, ref currentTick, ref hasExplodedLookup, ref startExplodeAnimID, ref databaseLocal, ref healthChangeBufferEntity);
		base.OnUpdate();
	}

	private void ExplodeStateSystem_704F5CB8_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb, ref uint tickRate, ref NetworkTick currentTick, ref ComponentLookup<HasExplodedCD> hasExplodedLookup, ref int startExplodeAnimID, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref Entity healthChangeBufferEntity)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ExplodeStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ExplosionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthChangeBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
		ExplodeStateSystem_704F5CB8_LambdaJob_0_Job value = new ExplodeStateSystem_704F5CB8_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			tickRate = tickRate,
			currentTick = currentTick,
			hasExplodedLookup = hasExplodedLookup,
			startExplodeAnimID = startExplodeAnimID,
			databaseLocal = databaseLocal,
			healthChangeBufferEntity = healthChangeBufferEntity,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__explodeStateTypeHandle = __TypeHandle.__ExplodeStateCD_RW_ComponentTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__healthTypeHandle = __TypeHandle.__HealthCD_RO_ComponentTypeHandle,
			__ExplosionCD_ComponentLookup = __TypeHandle.__ExplosionCD_RO_ComponentLookup,
			__HealthChangeBuffer_BufferLookup = __TypeHandle.__HealthChangeBuffer_RW_BufferLookup
		};
		if (!__query_1055310828_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ExplodeStateSystem_704F5CB8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1055310828_0, jobPtr);
		}
		time = value.time;
		ecb = value.ecb;
		tickRate = value.tickRate;
		currentTick = value.currentTick;
		hasExplodedLookup = value.hasExplodedLookup;
		startExplodeAnimID = value.startExplodeAnimID;
		databaseLocal = value.databaseLocal;
		healthChangeBufferEntity = value.healthChangeBufferEntity;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ExplodeStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		__query_1055310828_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1055310828_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1055310828_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1055310828_3 = entityQueryBuilder2.Build(ref state);
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
	public ExplodeStateSystem()
	{
	}
}

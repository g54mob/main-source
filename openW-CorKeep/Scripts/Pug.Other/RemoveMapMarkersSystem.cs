using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct RemoveMapMarkersSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct RemoveMapMarkersJob : IJob
	{
		public Entity removeMapMarkerEntity;

		public BufferLookup<RemoveMapMarkerBuffer> removeMapMarkerBufferLookup;

		public ComponentLookup<RemoveAllMapMarkerTriggerCD> removeAllMapMarkerTriggerLookup;

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public NativeList<Entity> mapMarkerEntities;

		[ReadOnly]
		public NativeList<MapMarkerCD> mapMarkerData;

		[ReadOnly]
		public NativeList<LocalTransform> mapMarkerTransforms;

		public ComponentLookup<MoveToPredictedByEntityDestroyedCD> moveToPredictedByEntityDestroyedLookup;

		public NetworkTick currentTick;

		public void Execute()
		{
			DynamicBuffer<RemoveMapMarkerBuffer> dynamicBuffer = removeMapMarkerBufferLookup[removeMapMarkerEntity];
			if (removeAllMapMarkerTriggerLookup.IsComponentEnabled(removeMapMarkerEntity))
			{
				for (int i = 0; i < mapMarkerEntities.Length; i++)
				{
					if (mapMarkerData[i].mapMarkerType == MapMarkerType.UserPlacedMarker)
					{
						if (entityDestroyedLookup.HasComponent(mapMarkerEntities[i]))
						{
							entityDestroyedLookup.SetComponentEnabled(mapMarkerEntities[i], value: true);
						}
						if (moveToPredictedByEntityDestroyedLookup.HasComponent(mapMarkerEntities[i]))
						{
							moveToPredictedByEntityDestroyedLookup.GetRefRW(mapMarkerEntities[i]).ValueRW.SetLastInteractionTick(currentTick);
						}
					}
				}
				removeAllMapMarkerTriggerLookup.SetComponentEnabled(removeMapMarkerEntity, value: false);
				dynamicBuffer.Clear();
				return;
			}
			for (int j = 0; j < dynamicBuffer.Length; j++)
			{
				Entity entity = dynamicBuffer[j].entity;
				if (!entityDestroyedLookup.HasComponent(entity))
				{
					entity = Entity.Null;
					for (int k = 0; k < mapMarkerTransforms.Length; k++)
					{
						if (math.abs(mapMarkerTransforms[k].Position.x - dynamicBuffer[j].position.x) < 0.001f && math.abs(mapMarkerTransforms[k].Position.z - dynamicBuffer[j].position.y) < 0.001f && mapMarkerData[k].mapMarkerType == MapMarkerType.UserPlacedMarker)
						{
							entity = mapMarkerEntities[k];
							break;
						}
					}
				}
				if (entity != Entity.Null)
				{
					entityDestroyedLookup.SetComponentEnabled(entity, value: true);
					if (moveToPredictedByEntityDestroyedLookup.HasComponent(entity))
					{
						moveToPredictedByEntityDestroyedLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(currentTick);
					}
				}
			}
			dynamicBuffer.Clear();
		}
	}

	private struct TypeHandle
	{
		public BufferLookup<RemoveMapMarkerBuffer> __RemoveMapMarkerBuffer_RW_BufferLookup;

		public ComponentLookup<RemoveAllMapMarkerTriggerCD> __RemoveAllMapMarkerTriggerCD_RW_ComponentLookup;

		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

		public ComponentLookup<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__RemoveMapMarkerBuffer_RW_BufferLookup = state.GetBufferLookup<RemoveMapMarkerBuffer>();
			__RemoveAllMapMarkerTriggerCD_RW_ComponentLookup = state.GetComponentLookup<RemoveAllMapMarkerTriggerCD>();
			__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
			__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPredictedByEntityDestroyedCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000031F2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000031F2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000031F2_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_579375114_0;

	private EntityQuery __query_579375114_1;

	private EntityQuery __query_579375114_2;

	public void OnCreate(ref SystemState state)
	{
		EntityArchetype archetype = state.EntityManager.CreateArchetype(typeof(RemoveMapMarkerBuffer), typeof(RemoveAllMapMarkerTriggerCD));
		Entity entity = state.EntityManager.CreateEntity(archetype);
		state.EntityManager.SetComponentEnabled<RemoveAllMapMarkerTriggerCD>(entity, value: false);
		state.RequireForUpdate<RemoveMapMarkerBuffer>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NetworkTime singleton = __query_579375114_1.GetSingleton<NetworkTime>();
		EntityQuery _query_579375114_ = __query_579375114_0;
		JobHandle outJobHandle;
		NativeList<Entity> mapMarkerEntities = _query_579375114_.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		JobHandle outJobHandle2;
		NativeList<MapMarkerCD> mapMarkerData = _query_579375114_.ToComponentDataListAsync<MapMarkerCD>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle2);
		JobHandle outJobHandle3;
		NativeList<LocalTransform> mapMarkerTransforms = _query_579375114_.ToComponentDataListAsync<LocalTransform>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle3);
		JobHandle dependsOn = JobHandle.CombineDependencies(outJobHandle, outJobHandle2, outJobHandle3);
		state.Dependency = IJobExtensions.Schedule(new RemoveMapMarkersJob
		{
			removeMapMarkerEntity = __query_579375114_2.GetSingletonEntity(),
			removeMapMarkerBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__RemoveMapMarkerBuffer_RW_BufferLookup, ref state),
			removeAllMapMarkerTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RemoveAllMapMarkerTriggerCD_RW_ComponentLookup, ref state),
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
			mapMarkerEntities = mapMarkerEntities,
			mapMarkerData = mapMarkerData,
			mapMarkerTransforms = mapMarkerTransforms,
			moveToPredictedByEntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup, ref state),
			currentTick = singleton.ServerTick
		}, dependsOn);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MapMarkerCD, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
		__query_579375114_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_579375114_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<RemoveMapMarkerBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_579375114_2 = entityQueryBuilder2.Build(ref state);
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
		((RemoveMapMarkersSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000031F2_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RemoveMapMarkersSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RemoveMapMarkersSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}

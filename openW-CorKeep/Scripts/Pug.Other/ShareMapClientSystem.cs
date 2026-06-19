using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class ShareMapClientSystem : PugSimulationSystemBase
{
	private struct ShareMapClientSystem_43E097DA_LambdaJob_0_Job : IJobChunk
	{
		public ShareMapClientSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		private void OriginalLambdaBody(Entity entity, in ListMapRequest _)
		{
			ecb.DestroyEntity(entity);
			__this.SendMapList(ref ecb);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), default(ListMapRequest));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), default(ListMapRequest));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), default(ListMapRequest));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), default(ListMapRequest));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapClientSystem_43E097DA_LambdaJob_0_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct ShareMapClientSystem_43E097DA_LambdaJob_1_Job : IJobChunk
	{
		public ShareMapClientSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ListMapResponse> __incomingMapResponseTypeHandle;

		private void OriginalLambdaBody(Entity entity, in ListMapResponse incomingMapResponse)
		{
			ecb.DestroyEntity(entity);
			if (!Manager.ui.mapUI.MapParts.TryGetValue(incomingMapResponse.MapPosition.ToVec2Int(), out var value) || !(value.TimestampHash == incomingMapResponse.TimestampHash))
			{
				ecb.SetComponent(ecb.CreateEntity(__this._updateMapRequestArchetype), new UpdateMapRequest
				{
					MapPosition = incomingMapResponse.MapPosition
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __incomingMapResponseTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapClientSystem_43E097DA_LambdaJob_1_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct ShareMapClientSystem_43E097DA_LambdaJob_2_Job : IJobChunk
	{
		public ShareMapClientSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<UpdateMapRequest> __incomingUpdateRequestTypeHandle;

		private void OriginalLambdaBody(Entity entity, in UpdateMapRequest incomingUpdateRequest)
		{
			ecb.DestroyEntity(entity);
			Dictionary<Vector2Int, MapPartSerialized> mapParts = Manager.ui.mapUI.MapParts;
			int2 mapPosition = incomingUpdateRequest.MapPosition;
			if (!mapParts.TryGetValue(mapPosition.ToVec2Int(), out var value))
			{
				Debug.LogWarning($"Ignoring request for map part {mapPosition} not present on client");
				return;
			}
			byte[] data = MapPackingHelper.PackIntoBuffer(mapPosition, value);
			Manager.networking.SendSideChannel(__this._connectionEntity, __this.World, NetworkingManager.SideChannel.MapData, isServer: false, data);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __incomingUpdateRequestTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapClientSystem_43E097DA_LambdaJob_2_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ListMapResponse> __ListMapResponse_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<UpdateMapRequest> __UpdateMapRequest_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ListMapResponse_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ListMapResponse>(isReadOnly: true);
			__UpdateMapRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<UpdateMapRequest>(isReadOnly: true);
		}
	}

	private const NetworkingManager.SideChannel SIDE_CHANNEL = NetworkingManager.SideChannel.MapData;

	private Entity _connectionEntity;

	private EntityArchetype _listMapRequestArchetype;

	private EntityArchetype _listMapResponseArchetype;

	private EntityArchetype _updateMapRequestArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1599554168_0;

	private EntityQuery __query_1599554168_1;

	private EntityQuery __query_1599554168_2;

	private EntityQuery __query_1599554168_3;

	private EntityQuery __query_1599554168_4;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<NetworkStreamConnection>();
		Manager.networking.AddSideChannelHandler(NetworkingManager.SideChannel.MapData, isServer: false, ReceiveMapData);
		_listMapRequestArchetype = base.EntityManager.CreateArchetype(typeof(ListMapRequest), typeof(SendRpcCommandRequest));
		_listMapResponseArchetype = base.EntityManager.CreateArchetype(typeof(ListMapResponse), typeof(SendRpcCommandRequest));
		_updateMapRequestArchetype = base.EntityManager.CreateArchetype(typeof(UpdateMapRequest), typeof(SendRpcCommandRequest));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		Manager.networking.RemoveSideChannelHandler(NetworkingManager.SideChannel.MapData, isServer: false);
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		_connectionEntity = __query_1599554168_3.GetSingletonEntity();
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NetworkTime singleton = __query_1599554168_4.GetSingleton<NetworkTime>();
		if (!VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 10, 1f))
		{
			base.OnUpdate();
			return;
		}
		EntityCommandBuffer ecb = CreateCommandBuffer();
		ShareMapClientSystem_43E097DA_LambdaJob_0_Execute(ref ecb);
		ShareMapClientSystem_43E097DA_LambdaJob_1_Execute(ref ecb);
		ShareMapClientSystem_43E097DA_LambdaJob_2_Execute(ref ecb);
	}

	public void TriggerExchangeWithServer()
	{
		base.EntityManager.CreateEntity(_listMapRequestArchetype);
	}

	private void SendMapList(ref EntityCommandBuffer ecb)
	{
		Dictionary<Vector2Int, MapPartSerialized> mapParts = Manager.ui.mapUI.MapParts;
		foreach (Vector2Int key in mapParts.Keys)
		{
			ecb.SetComponent(ecb.CreateEntity(_listMapResponseArchetype), new ListMapResponse(key.ToInt2(), mapParts[key].TimestampHash));
		}
	}

	private void ReceiveMapData(byte[] mapPartData)
	{
		MapPackingHelper.UnpackFromBuffer(mapPartData, out var mapPosition, out var mapPart);
		Manager.ui.mapUI.UpdateMapPart(mapPosition, mapPart);
	}

	private void ShareMapClientSystem_43E097DA_LambdaJob_0_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		ShareMapClientSystem_43E097DA_LambdaJob_0_Job value = new ShareMapClientSystem_43E097DA_LambdaJob_0_Job
		{
			__this = this,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_1599554168_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapClientSystem_43E097DA_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1599554168_0, jobPtr);
		}
		ecb = value.ecb;
	}

	private void ShareMapClientSystem_43E097DA_LambdaJob_1_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ListMapResponse_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ShareMapClientSystem_43E097DA_LambdaJob_1_Job value = new ShareMapClientSystem_43E097DA_LambdaJob_1_Job
		{
			__this = this,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__incomingMapResponseTypeHandle = __TypeHandle.__ListMapResponse_RO_ComponentTypeHandle
		};
		if (!__query_1599554168_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapClientSystem_43E097DA_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_1599554168_1, jobPtr);
		}
		ecb = value.ecb;
	}

	private void ShareMapClientSystem_43E097DA_LambdaJob_2_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__UpdateMapRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ShareMapClientSystem_43E097DA_LambdaJob_2_Job value = new ShareMapClientSystem_43E097DA_LambdaJob_2_Job
		{
			__this = this,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__incomingUpdateRequestTypeHandle = __TypeHandle.__UpdateMapRequest_RO_ComponentTypeHandle
		};
		if (!__query_1599554168_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapClientSystem_43E097DA_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_1599554168_2, jobPtr);
		}
		ecb = value.ecb;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ListMapRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554168_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ListMapResponse>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554168_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<UpdateMapRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554168_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1599554168_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1599554168_4 = entityQueryBuilder2.Build(ref state);
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
	public ShareMapClientSystem()
	{
	}
}

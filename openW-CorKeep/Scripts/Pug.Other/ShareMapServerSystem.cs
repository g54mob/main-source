using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.Platform;
using Pug.UnityExtensions;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class ShareMapServerSystem : PugSimulationSystemBase
{
	private struct ShareMapServerSystem_12B634E6_LambdaJob_0_Job : IJobChunk
	{
		public ShareMapServerSystem __this;

		public EntityCommandBuffer ecb;

		public bool worldIsReadOnly;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcRequestTypeHandle;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_ComponentLookup;

		private void OriginalLambdaBody(Entity entity, in ListMapRequest _, in ReceiveRpcCommandRequest rpcRequest)
		{
			ecb.DestroyEntity(entity);
			Entity sourceConnection = rpcRequest.SourceConnection;
			if (worldIsReadOnly && __ConnectionAdminLevelCD_ComponentLookup[sourceConnection].adminPrivileges <= 0)
			{
				return;
			}
			ecb.SetComponent(ecb.CreateEntity(__this._listMapRequestArchetype), new SendRpcCommandRequest
			{
				TargetConnection = sourceConnection
			});
			SerializableDictionary<Vector2Int, MapPartSerialized> mapParts = __this._mapFile.mapParts;
			foreach (Vector2Int key in mapParts.Keys)
			{
				Entity e = ecb.CreateEntity(__this._listMapResponseArchetype);
				ecb.SetComponent(e, new ListMapResponse(key.ToInt2(), mapParts[key].TimestampHash));
				ecb.SetComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = sourceConnection
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcRequestTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), default(ListMapRequest), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), default(ListMapRequest), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), default(ListMapRequest), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), default(ListMapRequest), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapServerSystem_12B634E6_LambdaJob_0_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct ShareMapServerSystem_12B634E6_LambdaJob_1_Job : IJobChunk
	{
		public ShareMapServerSystem __this;

		public EntityCommandBuffer ecb;

		public bool worldIsReadOnly;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ListMapResponse> __incomingListResponseTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcRequestTypeHandle;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_ComponentLookup;

		private void OriginalLambdaBody(Entity entity, in ListMapResponse incomingListResponse, in ReceiveRpcCommandRequest rpcRequest)
		{
			ecb.DestroyEntity(entity);
			Entity sourceConnection = rpcRequest.SourceConnection;
			if ((!worldIsReadOnly || __ConnectionAdminLevelCD_ComponentLookup[sourceConnection].adminPrivileges > 0) && (!__this._mapFile.mapParts.TryGetValue(incomingListResponse.MapPosition.ToVec2Int(), out var value) || !(incomingListResponse.TimestampHash == value.TimestampHash)))
			{
				Entity e = ecb.CreateEntity(__this._updateMapRequestArchetype);
				ecb.SetComponent(e, new UpdateMapRequest
				{
					MapPosition = incomingListResponse.MapPosition
				});
				ecb.SetComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = sourceConnection
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __incomingListResponseTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcRequestTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ListMapResponse>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapServerSystem_12B634E6_LambdaJob_1_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct ShareMapServerSystem_12B634E6_LambdaJob_2_Job : IJobChunk
	{
		public ShareMapServerSystem __this;

		public EntityCommandBuffer ecb;

		public bool worldIsReadOnly;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<UpdateMapRequest> __incomingMapRequestTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcRequestTypeHandle;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_ComponentLookup;

		private void OriginalLambdaBody(Entity entity, in UpdateMapRequest incomingMapRequest, in ReceiveRpcCommandRequest rpcRequest)
		{
			ecb.DestroyEntity(entity);
			Entity sourceConnection = rpcRequest.SourceConnection;
			if (!worldIsReadOnly || __ConnectionAdminLevelCD_ComponentLookup[sourceConnection].adminPrivileges > 0)
			{
				int2 mapPosition = incomingMapRequest.MapPosition;
				if (!__this._mapFile.mapParts.TryGetValue(mapPosition.ToVec2Int(), out var value))
				{
					Debug.LogWarning($"Ignoring request for map part {mapPosition} not present on server");
					return;
				}
				byte[] data = MapPackingHelper.PackIntoBuffer(mapPosition, value);
				Manager.networking.SendSideChannel(sourceConnection, __this.World, NetworkingManager.SideChannel.MapData, isServer: true, data);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __incomingMapRequestTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcRequestTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdateMapRequest>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShareMapServerSystem_12B634E6_LambdaJob_2_Job>(jobPtr), ref query);
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
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<ListMapResponse> __ListMapResponse_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<UpdateMapRequest> __UpdateMapRequest_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			__ConnectionAdminLevelCD_RO_ComponentLookup = state.GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
			__ListMapResponse_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ListMapResponse>(isReadOnly: true);
			__UpdateMapRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<UpdateMapRequest>(isReadOnly: true);
		}
	}

	private const NetworkingManager.SideChannel SIDE_CHANNEL = NetworkingManager.SideChannel.MapData;

	private MapFile _mapFile = new MapFile
	{
		mapParts = new SerializableDictionary<Vector2Int, MapPartSerialized>()
	};

	private FilesystemManager.File _mapFileHandle;

	private Texture2D _newMapTexture;

	private Texture2D _newTimestampTexture;

	private Texture2D _currentMapTexture;

	private Texture2D _currentTimestampTexture;

	private bool _initialized;

	private const double SAVE_DELAY_SECONDS = 0.5;

	private double _lastMapChangeTime;

	private EntityArchetype _listMapRequestArchetype;

	private EntityArchetype _listMapResponseArchetype;

	private EntityArchetype _updateMapRequestArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1599554271_0;

	private EntityQuery __query_1599554271_1;

	private EntityQuery __query_1599554271_2;

	private EntityQuery __query_1599554271_3;

	private EntityQuery __query_1599554271_4;

	[Preserve]
	protected override void OnCreate()
	{
		_newMapTexture = new Texture2D(2, 2, TextureFormat.ARGB32, mipChain: false, linear: false);
		_newTimestampTexture = new Texture2D(2, 2, TextureFormat.ARGB32, mipChain: false, linear: true);
		_currentMapTexture = new Texture2D(2, 2, TextureFormat.ARGB32, mipChain: false, linear: false);
		_currentTimestampTexture = new Texture2D(2, 2, TextureFormat.ARGB32, mipChain: false, linear: true);
		RequireForUpdate<ServerSaveIdCD>();
		_listMapRequestArchetype = base.EntityManager.CreateArchetype(typeof(ListMapRequest), typeof(SendRpcCommandRequest));
		_listMapResponseArchetype = base.EntityManager.CreateArchetype(typeof(ListMapResponse), typeof(SendRpcCommandRequest));
		_updateMapRequestArchetype = base.EntityManager.CreateArchetype(typeof(UpdateMapRequest), typeof(SendRpcCommandRequest));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (_initialized)
		{
			return;
		}
		_mapFileHandle = Manager.filesystemManager.GetFile(FilesystemManager.FileID.ServerMapParts, __query_1599554271_3.GetSingleton<ServerSaveIdCD>().Value);
		if (_mapFileHandle.Exists())
		{
			try
			{
				FilesystemManager.LoadBinaryFile(_mapFileHandle, ref _mapFile);
				List<Vector2Int> list = new List<Vector2Int>(_mapFile.mapParts.Count);
				foreach (KeyValuePair<Vector2Int, MapPartSerialized> mapPart in _mapFile.mapParts)
				{
					_currentMapTexture.LoadImage(mapPart.Value.png);
					_currentTimestampTexture.LoadImage(mapPart.Value.timestampPng);
					if (_currentMapTexture.width != 256 || _currentMapTexture.height != 256 || _currentTimestampTexture.width != 256 || _currentTimestampTexture.height != 256)
					{
						Debug.LogError($"Invalid map part dimensions for {mapPart.Key} on server, removing from map");
						list.Add(mapPart.Key);
					}
				}
				foreach (Vector2Int item in list)
				{
					_mapFile.mapParts.Remove(item);
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Failed to read server-side cartography table map file, replace with empty map");
				Debug.LogException(exception);
				_mapFile = new MapFile
				{
					mapParts = new SerializableDictionary<Vector2Int, MapPartSerialized>()
				};
			}
		}
		Debug.Log($"Read cartography table map with {_mapFile.mapParts.Count} parts");
		Manager.networking.AddSideChannelHandler(NetworkingManager.SideChannel.MapData, isServer: true, ReceiveMapData);
		_lastMapChangeTime = -1.0;
		_initialized = true;
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		if (_initialized)
		{
			Manager.networking.RemoveSideChannelHandler(NetworkingManager.SideChannel.MapData, isServer: true);
			if (_lastMapChangeTime >= 0.0)
			{
				_mapFileHandle.Write(FilesystemManager.SerializeToBinary(_mapFile));
				_lastMapChangeTime = -1.0;
			}
		}
		UnityEngine.Object.Destroy(_newMapTexture);
		UnityEngine.Object.Destroy(_newTimestampTexture);
		UnityEngine.Object.Destroy(_currentMapTexture);
		UnityEngine.Object.Destroy(_currentTimestampTexture);
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NetworkTime singleton = __query_1599554271_4.GetSingleton<NetworkTime>();
		if (!VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 10, 1f))
		{
			base.OnUpdate();
			return;
		}
		EntityCommandBuffer ecb = CreateCommandBuffer();
		if (_lastMapChangeTime >= 0.0 && _lastMapChangeTime + 0.5 <= base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime)
		{
			_mapFileHandle.Write(FilesystemManager.SerializeToBinary(_mapFile));
			_lastMapChangeTime = -1.0;
		}
		bool worldIsReadOnly = base.WorldInfo.guestMode;
		ShareMapServerSystem_12B634E6_LambdaJob_0_Execute(ref ecb, ref worldIsReadOnly);
		ShareMapServerSystem_12B634E6_LambdaJob_1_Execute(ref ecb, ref worldIsReadOnly);
		ShareMapServerSystem_12B634E6_LambdaJob_2_Execute(ref ecb, ref worldIsReadOnly);
	}

	private void ReceiveMapData(byte[] mapPartData)
	{
		MapPackingHelper.UnpackFromBuffer(mapPartData, out var mapPosition, out var mapPart);
		Vector2Int key = mapPosition.ToVec2Int();
		if (_mapFile.mapParts.TryAdd(key, mapPart))
		{
			_lastMapChangeTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
			return;
		}
		bool flag = false;
		MapPartSerialized mapPartSerialized = _mapFile.mapParts[key];
		_currentTimestampTexture.LoadImage(mapPartSerialized.timestampPng);
		NativeArray<PugColorARGB32> pixelData = _currentTimestampTexture.GetPixelData<PugColorARGB32>(0);
		_newTimestampTexture.LoadImage(mapPart.timestampPng);
		NativeArray<PugColorARGB32> pixelData2 = _newTimestampTexture.GetPixelData<PugColorARGB32>(0);
		NativeArray<PugColorARGB32> nativeArray = default(NativeArray<PugColorARGB32>);
		NativeArray<PugColorARGB32> nativeArray2 = default(NativeArray<PugColorARGB32>);
		for (int i = 0; i < 256; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				int index = i * 256 + j;
				if (MapUI.TimestampIsNewer(pixelData2[index], pixelData[index]))
				{
					if (!flag)
					{
						_currentMapTexture.LoadImage(mapPartSerialized.png);
						_newMapTexture.LoadImage(mapPart.png);
						nativeArray = _currentMapTexture.GetPixelData<PugColorARGB32>(0);
						nativeArray2 = _newMapTexture.GetPixelData<PugColorARGB32>(0);
						flag = true;
					}
					nativeArray[index] = nativeArray2[index];
					pixelData[index] = pixelData2[index];
				}
			}
		}
		if (flag)
		{
			_currentMapTexture.Apply();
			_currentTimestampTexture.Apply();
			MapPartSerialized value = new MapPartSerialized
			{
				png = _currentMapTexture.EncodeToPNG(),
				timestampPng = _currentTimestampTexture.EncodeToPNG()
			};
			value.RecomputeTimestampHash();
			_mapFile.mapParts[key] = value;
			_lastMapChangeTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		}
	}

	public void Clear()
	{
		_mapFile = new MapFile
		{
			mapParts = new SerializableDictionary<Vector2Int, MapPartSerialized>()
		};
		_mapFileHandle.Write(FilesystemManager.SerializeToBinary(_mapFile));
	}

	private void ShareMapServerSystem_12B634E6_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref bool worldIsReadOnly)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShareMapServerSystem_12B634E6_LambdaJob_0_Job value = new ShareMapServerSystem_12B634E6_LambdaJob_0_Job
		{
			__this = this,
			ecb = ecb,
			worldIsReadOnly = worldIsReadOnly,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__rpcRequestTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__ConnectionAdminLevelCD_ComponentLookup = __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup
		};
		if (!__query_1599554271_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapServerSystem_12B634E6_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1599554271_0, jobPtr);
		}
		ecb = value.ecb;
		worldIsReadOnly = value.worldIsReadOnly;
	}

	private void ShareMapServerSystem_12B634E6_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref bool worldIsReadOnly)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ListMapResponse_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShareMapServerSystem_12B634E6_LambdaJob_1_Job value = new ShareMapServerSystem_12B634E6_LambdaJob_1_Job
		{
			__this = this,
			ecb = ecb,
			worldIsReadOnly = worldIsReadOnly,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__incomingListResponseTypeHandle = __TypeHandle.__ListMapResponse_RO_ComponentTypeHandle,
			__rpcRequestTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__ConnectionAdminLevelCD_ComponentLookup = __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup
		};
		if (!__query_1599554271_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapServerSystem_12B634E6_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_1599554271_1, jobPtr);
		}
		ecb = value.ecb;
		worldIsReadOnly = value.worldIsReadOnly;
	}

	private void ShareMapServerSystem_12B634E6_LambdaJob_2_Execute(ref EntityCommandBuffer ecb, ref bool worldIsReadOnly)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__UpdateMapRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShareMapServerSystem_12B634E6_LambdaJob_2_Job value = new ShareMapServerSystem_12B634E6_LambdaJob_2_Job
		{
			__this = this,
			ecb = ecb,
			worldIsReadOnly = worldIsReadOnly,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__incomingMapRequestTypeHandle = __TypeHandle.__UpdateMapRequest_RO_ComponentTypeHandle,
			__rpcRequestTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__ConnectionAdminLevelCD_ComponentLookup = __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup
		};
		if (!__query_1599554271_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShareMapServerSystem_12B634E6_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_1599554271_2, jobPtr);
		}
		ecb = value.ecb;
		worldIsReadOnly = value.worldIsReadOnly;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ListMapRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554271_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ListMapResponse>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554271_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<UpdateMapRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1599554271_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSaveIdCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1599554271_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1599554271_4 = entityQueryBuilder2.Build(ref state);
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
	public ShareMapServerSystem()
	{
	}
}

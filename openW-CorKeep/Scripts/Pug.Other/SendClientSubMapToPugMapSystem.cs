using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.NetCode.LowLevel;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class SendClientSubMapToPugMapSystem : PugSimulationSystemBase
{
	public struct TileUpdate
	{
		public bool add;

		public bool triggerLightUpdate;

		public int2 pos;

		public int tileset;

		public TileType tileType;
	}

	public struct PositionAndTile : IEquatable<PositionAndTile>
	{
		public int2 pos;

		public TileCD tile;

		public bool Equals(PositionAndTile other)
		{
			if (pos.Equals(other.pos))
			{
				return tile.Equals(other.tile);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is PositionAndTile other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (pos.GetHashCode() * 397) ^ tile.GetHashCode();
		}
	}

	public struct TileOverride
	{
		public bool add;

		public PositionAndTile posAndTile;

		public float timer;
	}

	public struct LayerData
	{
		public TileCD layer;

		public ClientSubMapLayer data;

		public ClientSubMapLayer dataCopy;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TileUpdateComparer : IComparer<TileUpdate>
	{
		public int Compare(TileUpdate x, TileUpdate y)
		{
			int num = x.tileset.CompareTo(y.tileset);
			if (num != 0)
			{
				return num;
			}
			num = UnsafeUtility.EnumToInt(x.tileType).CompareTo(UnsafeUtility.EnumToInt(y.tileType));
			if (num != 0)
			{
				return num;
			}
			return x.add.CompareTo(y.add);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct SetLayerData_Job : IJobChunk
	{
		public NativeList<LayerData> layerDataListLocal;

		public SnapshotDataLookupHelper snapshotDataLookupLocal;

		public NativeHashMap<int2, NetworkTick> predictedPositions;

		public NetworkTime networkTime;

		public float2 cameraPos;

		public int2 subMapSize;

		public ComponentTypeHandle<ClientSubMapLayerCD> __clientSubMapLayerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> __ghostInstanceTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> __snapshotDataTypeHandle;

		public BufferTypeHandle<SnapshotDataBuffer> __snapshotDataBufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref ClientSubMapLayerCD clientSubMapLayer, [NoAlias] in GhostInstance ghostInstance, [NoAlias] in SnapshotData snapshotData, DynamicBuffer<SnapshotDataBuffer> snapshotDataBuffer)
		{
			if (math.distancesq(clientSubMapLayer.data.viewPoint, cameraPos) > 4096f)
			{
				return;
			}
			if (!snapshotDataLookupLocal.CreateSnapshotBufferLookup().TryGetComponentDataFromSnapshotHistory<ClientSubMapLayerCD>(ghostInstance.ghostType, snapshotData, in snapshotDataBuffer, out var componentData, networkTime.InterpolationTick, networkTime.InterpolationTickFraction))
			{
				componentData = clientSubMapLayer;
			}
			int2 int5 = clientSubMapLayer.data.viewPoint - subMapSize / 2;
			int2 int6 = int5 + subMapSize;
			int2 int7 = componentData.data.viewPoint - subMapSize / 2;
			int2 int8 = int7 + subMapSize;
			foreach (KVPair<int2, NetworkTick> predictedPosition in predictedPositions)
			{
				if (!math.any((predictedPosition.Key < int5) | (predictedPosition.Key >= int6)) && !math.any((predictedPosition.Key < int7) | (predictedPosition.Key >= int8)))
				{
					int2 pos = predictedPosition.Key - int5;
					int2 pos2 = predictedPosition.Key - int7;
					if (clientSubMapLayer.data.GetByRef(pos))
					{
						componentData.data.Set(pos2);
					}
					else
					{
						componentData.data.Unset(pos2);
					}
				}
			}
			int i;
			for (i = 0; i < layerDataListLocal.Length; i++)
			{
				ref LayerData reference = ref layerDataListLocal.ElementAt(i);
				if (reference.layer.Equals(componentData.layer))
				{
					reference.layer = componentData.layer;
					reference.data = componentData.data;
					break;
				}
			}
			if (i == layerDataListLocal.Length)
			{
				ref NativeList<LayerData> reference2 = ref layerDataListLocal;
				LayerData value = new LayerData
				{
					layer = componentData.layer,
					data = componentData.data
				};
				reference2.Add(in value);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __clientSubMapLayerTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __ghostInstanceTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __snapshotDataTypeHandle);
			BufferAccessor<SnapshotDataBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __snapshotDataBufferTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnapshotData>(nativeArrayPtr3, i), bufferAccessor[i]);
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnapshotData>(nativeArrayPtr3, j), bufferAccessor[j]);
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnapshotData>(nativeArrayPtr3, k), bufferAccessor[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientSubMapLayerCD>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnapshotData>(nativeArrayPtr3, l), bufferAccessor[l]);
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct SendClientSubMapToPugMapSystem_4EEC37E0_LambdaJob_1_Job : IJob
	{
		public NativeHashMap<int2, NetworkTick> predictedPositions;

		public NetworkTime networkTime;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			if (!networkTime.InterpolationTick.IsValid)
			{
				return;
			}
			NativeList<int2> nativeList = new NativeList<int2>(Allocator.Temp);
			foreach (KVPair<int2, NetworkTick> predictedPosition in predictedPositions)
			{
				if (networkTime.InterpolationTick.IsNewerThan(predictedPosition.Value))
				{
					nativeList.Add(predictedPosition.Key);
				}
			}
			foreach (int2 item in nativeList)
			{
				predictedPositions.Remove(item);
			}
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct GatherTileUpdates_Job : IJob
	{
		public NativeList<LayerData> layerDataListLocal;

		public NativeList<TileUpdate> tileUpdatesLocal;

		public float2 cameraPos;

		public int2 subMapSize;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			ComputeShouldBeViewedMemo(cameraPos, out var memo, out var basePos, out var maxViewRect);
			for (int i = 0; i < layerDataListLocal.Length; i++)
			{
				ref LayerData reference = ref layerDataListLocal.ElementAt(i);
				ref ClientSubMapLayer dataCopy = ref reference.dataCopy;
				int2 valueToClamp = reference.data.viewPoint - reference.dataCopy.viewPoint;
				valueToClamp = math.clamp(valueToClamp, -subMapSize, subMapSize);
				reference.dataCopy.viewPoint = reference.data.viewPoint;
				if (valueToClamp.y > 0)
				{
					for (int j = 0; j < subMapSize.y - valueToClamp.y; j++)
					{
						ulong num = dataCopy.Row(j + valueToClamp.y);
						num = ((valueToClamp.x <= 0) ? (num << -valueToClamp.x) : (num >> valueToClamp.x));
						dataCopy.Row(j) = num;
					}
					for (int num2 = subMapSize.y - 1; num2 >= subMapSize.y - valueToClamp.y; num2--)
					{
						dataCopy.Row(num2) = 0uL;
					}
				}
				else
				{
					for (int num3 = subMapSize.y - 1; num3 >= -valueToClamp.y; num3--)
					{
						ulong num4 = dataCopy.Row(num3 + valueToClamp.y);
						num4 = ((valueToClamp.x <= 0) ? (num4 << -valueToClamp.x) : (num4 >> valueToClamp.x));
						dataCopy.Row(num3) = num4;
					}
					for (int k = 0; k < -valueToClamp.y; k++)
					{
						dataCopy.Row(k) = 0uL;
					}
				}
			}
			for (int l = 0; l < layerDataListLocal.Length; l++)
			{
				ref LayerData reference2 = ref layerDataListLocal.ElementAt(l);
				ref ClientSubMapLayer data = ref reference2.data;
				ref ClientSubMapLayer dataCopy2 = ref reference2.dataCopy;
				int2 int5 = reference2.data.viewPoint - subMapSize / 2;
				for (int m = 0; m < subMapSize.y; m++)
				{
					ulong num5 = data.Row(m);
					ulong num6 = dataCopy2.Row(m);
					for (int n = 0; n < subMapSize.x; n++)
					{
						int2 int6 = new int2(n, m) + int5;
						if (ShouldBeViewedCache(int6, basePos, maxViewRect, ref memo))
						{
							if ((num5 & 1) != (num6 & 1))
							{
								bool flag = (num5 & 1) != 0;
								ref NativeList<TileUpdate> reference3 = ref tileUpdatesLocal;
								TileUpdate value = new TileUpdate
								{
									add = flag,
									triggerLightUpdate = true,
									pos = int6,
									tileset = reference2.layer.tileset,
									tileType = reference2.layer.tileType
								};
								reference3.Add(in value);
								if (flag)
								{
									dataCopy2.Set(new int2(n, m));
								}
								else
								{
									dataCopy2.Unset(new int2(n, m));
								}
							}
						}
						else if ((num6 & 1) != 0L)
						{
							ref NativeList<TileUpdate> reference4 = ref tileUpdatesLocal;
							TileUpdate value = new TileUpdate
							{
								add = false,
								triggerLightUpdate = false,
								pos = int6,
								tileset = reference2.layer.tileset,
								tileType = reference2.layer.tileType
							};
							reference4.Add(in value);
							dataCopy2.Unset(new int2(n, m));
						}
						num5 >>= 1;
						num6 >>= 1;
					}
				}
			}
			memo.Dispose();
			for (int num7 = 0; num7 < layerDataListLocal.Length; num7++)
			{
				layerDataListLocal.ElementAt(num7).data.Clear();
			}
			tileUpdatesLocal.Sort(default(TileUpdateComparer));
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<ClientSubMapLayerCD> __ClientSubMapLayerCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> __Unity_NetCode_SnapshotData_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDataBuffer> __Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ClientSubMapLayerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ClientSubMapLayerCD>();
			__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
			__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnapshotData>(isReadOnly: true);
			__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnapshotDataBuffer>(isReadOnly: true);
		}
	}

	private SnapshotDataLookupHelper spawnBufferHelper;

	private NativeList<LayerData> layerDataList;

	public NativeList<TileUpdate> tileUpdates;

	public JobHandle tileUpdatesWriterDependency;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_526967604_0;

	private EntityQuery __query_526967604_1;

	private EntityQuery __query_526967604_2;

	private EntityQuery __query_526967604_3;

	private EntityQuery __query_526967604_4;

	public void Apply(SinglePugMap pugMap)
	{
		base.Dependency.Complete();
		if (tileUpdates.Length != 0)
		{
			pugMap.ApplySortedTileUpdates(tileUpdates);
			tileUpdates.Clear();
		}
	}

	[Preserve]
	protected override void OnCreate()
	{
		layerDataList = new NativeList<LayerData>(64, Allocator.Persistent);
		tileUpdates = new NativeList<TileUpdate>(Allocator.Persistent);
		RequireForUpdate<GhostCollection>();
		RequireForUpdate<SpawnedGhostEntityMap>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		layerDataList.Dispose();
		tileUpdates.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		spawnBufferHelper = new SnapshotDataLookupHelper(ref base.CheckedStateRef, __query_526967604_1.GetSingletonEntity(), __query_526967604_2.GetSingletonEntity());
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		_ = ref base.CheckedStateRef.WorldUnmanaged.Time;
		base.Dependency = JobHandle.CombineDependencies(base.Dependency, tileUpdatesWriterDependency);
		tileUpdatesWriterDependency = default(JobHandle);
		NativeList<LayerData> layerDataListLocal = layerDataList;
		NativeList<TileUpdate> tileUpdatesLocal = tileUpdates;
		SnapshotDataLookupHelper snapshotDataLookupLocal = spawnBufferHelper;
		NativeHashMap<int2, NetworkTick> predictedPositions = __query_526967604_3.GetSingleton<PredictedTilePositions>().predictedPositions;
		NetworkTime singleton = __query_526967604_4.GetSingleton<NetworkTime>();
		float2 cameraPos = Manager.camera.GetCameraCurrentPosition().ToFloat2();
		int2 subMapSize = new int2(64, 48);
		snapshotDataLookupLocal.Update(ref base.CheckedStateRef);
		SendClientSubMapToPugMapSystem_4EEC37E0_LambdaJob_1_Execute(predictedPositions, singleton);
		SetLayerData_Execute(layerDataListLocal, snapshotDataLookupLocal, predictedPositions, singleton, cameraPos, subMapSize);
		GatherTileUpdates_Execute(layerDataListLocal, tileUpdatesLocal, cameraPos, subMapSize);
		base.OnUpdate();
	}

	private static void ComputeShouldBeViewedMemo(float2 cameraPos, out NativeArray<bool> memo, out int2 basePos, out int2 maxViewRect)
	{
		int2 int5 = new int2(20, 16);
		int2 int6 = new int2(4, 4);
		int2 obj = int5 * 2;
		maxViewRect = (int5 + int6) * 2;
		basePos = (int2)math.round(cameraPos) - maxViewRect / 2;
		cameraPos.y -= 2f;
		cameraPos += (float2)int6;
		int2 int7 = (int2)math.ceil((float2)obj / (float2)int6);
		float2 float5 = new float2((float)int7.y / (float)int6.x, (float)int7.x / (float)int6.y);
		int2 int8 = (int2)math.floor(math.fmod(math.fmod(cameraPos, int6) + int6, int6) * float5) * int6;
		cameraPos = (int2)math.floor(cameraPos / int6) * int6;
		memo = new NativeArray<bool>(maxViewRect.x * maxViewRect.y, Allocator.Temp);
		for (int i = 0; i < maxViewRect.y; i++)
		{
			for (int j = 0; j < maxViewRect.x; j++)
			{
				int2 int9 = new int2(j, i);
				int2 int10 = basePos + int9;
				float2 float6 = int10 - (cameraPos - int5);
				int10 += (int2)(float6 >= int8) * int6;
				memo[int9.x + int9.y * maxViewRect.x] = math.all(math.abs(int10 - cameraPos) <= int5);
			}
		}
	}

	private static bool ShouldBeViewedCache(int2 worldPosition, int2 basePosition, int2 viewRect, ref NativeArray<bool> memo)
	{
		int2 int5 = worldPosition - basePosition;
		if (math.any(int5 < 0) || math.any(int5 >= viewRect))
		{
			return false;
		}
		return memo[int5.x + int5.y * viewRect.x];
	}

	private void SetLayerData_Execute(NativeList<LayerData> layerDataListLocal, SnapshotDataLookupHelper snapshotDataLookupLocal, NativeHashMap<int2, NetworkTick> predictedPositions, NetworkTime networkTime, float2 cameraPos, int2 subMapSize)
	{
		__TypeHandle.__ClientSubMapLayerCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		SetLayerData_Job jobData = new SetLayerData_Job
		{
			layerDataListLocal = layerDataListLocal,
			snapshotDataLookupLocal = snapshotDataLookupLocal,
			predictedPositions = predictedPositions,
			networkTime = networkTime,
			cameraPos = cameraPos,
			subMapSize = subMapSize,
			__clientSubMapLayerTypeHandle = __TypeHandle.__ClientSubMapLayerCD_RW_ComponentTypeHandle,
			__ghostInstanceTypeHandle = __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle,
			__snapshotDataTypeHandle = __TypeHandle.__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle,
			__snapshotDataBufferTypeHandle = __TypeHandle.__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967604_0, base.CheckedStateRef.Dependency);
	}

	private void SendClientSubMapToPugMapSystem_4EEC37E0_LambdaJob_1_Execute(NativeHashMap<int2, NetworkTick> predictedPositions, NetworkTime networkTime)
	{
		SendClientSubMapToPugMapSystem_4EEC37E0_LambdaJob_1_Job jobData = new SendClientSubMapToPugMapSystem_4EEC37E0_LambdaJob_1_Job
		{
			predictedPositions = predictedPositions,
			networkTime = networkTime
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	private void GatherTileUpdates_Execute(NativeList<LayerData> layerDataListLocal, NativeList<TileUpdate> tileUpdatesLocal, float2 cameraPos, int2 subMapSize)
	{
		GatherTileUpdates_Job jobData = new GatherTileUpdates_Job
		{
			layerDataListLocal = layerDataListLocal,
			tileUpdatesLocal = tileUpdatesLocal,
			cameraPos = cameraPos,
			subMapSize = subMapSize
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnapshotData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnapshotDataBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClientSubMapLayerCD>();
		__query_526967604_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostCollection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967604_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnedGhostEntityMap>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967604_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PredictedTilePositions>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967604_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967604_4 = entityQueryBuilder2.Build(ref state);
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
	public SendClientSubMapToPugMapSystem()
	{
	}
}

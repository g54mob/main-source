using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class WaterSpreadingInitSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RunWaterSpreadingInitCD : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct WaterSpreadingInitSystem_543A9C94_LambdaJob_0_Job : IJobChunk
	{
		public NativeList<int2> waterSpreadingPositionsLocal;

		[ReadOnly]
		public ComponentTypeHandle<SubMapCD> __submapTypeHandle;

		public BufferTypeHandle<SubMapLayerBuffer> __submapLayersTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in SubMapCD submap, DynamicBuffer<SubMapLayerBuffer> submapLayers)
		{
			DynamicBuffer<SubMapLayer> layers = submapLayers.Reinterpret<SubMapLayer>();
			SubMapLayer subMapLayer = FindAllWaterTiles(in layers);
			BitwiseComplementInPlace(ref subMapLayer.bitfield);
			for (int i = 0; i < layers.Length; i++)
			{
				if ((layers[i].layer.tileType != TileType.water && layers[i].layer.tileType != TileType.pit) || (layers[i].layer.tileType == TileType.water && layers[i].layer.tileset == 10))
				{
					continue;
				}
				SubMapLayer sl = subMapLayer;
				if (layers[i].layer.tileType == TileType.water)
				{
					BitwiseOrInPlace(ref sl.bitfield, layers[i].bitfield);
				}
				for (int j = 0; j < submap.height(); j++)
				{
					if (layers[i].GetRow(j) == 0L)
					{
						continue;
					}
					for (int k = 0; k < submap.width(); k++)
					{
						int2 int5 = new int2(k, j);
						if (!layers[i].Get(int5))
						{
							continue;
						}
						if (k != 0 && k != submap.width() - 1 && j != 0 && j != submap.height())
						{
							int2 pos = new int2(k - 1, j);
							int2 pos2 = new int2(k + 1, j);
							int2 pos3 = new int2(k, j - 1);
							int2 pos4 = new int2(k, j + 1);
							if (sl.Get(pos) && sl.Get(pos2) && sl.Get(pos3) && sl.Get(pos4))
							{
								continue;
							}
						}
						waterSpreadingPositionsLocal.Add(submap.position() + int5);
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __submapTypeHandle);
			BufferAccessor<SubMapLayerBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __submapLayersTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, i), bufferAccessor[i]);
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, j), bufferAccessor[j]);
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, k), bufferAccessor[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, l), bufferAccessor[l]);
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<SubMapCD> __SubMapCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SubMapLayerBuffer> __SubMapLayerBuffer_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SubMapCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
			__SubMapLayerBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SubMapLayerBuffer>(isReadOnly: true);
		}
	}

	private Entity runSingleton;

	private EntityArchetype archetype;

	private NativeList<int2> waterSpreadingPositions;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2111791439_0;

	[Preserve]
	protected override void OnCreate()
	{
		archetype = base.EntityManager.CreateArchetype(typeof(WaterSpreaderCD));
		RequireForUpdate<RunWaterSpreadingInitCD>();
		RequireForUpdate<WorldHasBeenDeserializedCD>();
		runSingleton = base.EntityManager.CreateEntity(typeof(RunWaterSpreadingInitCD), typeof(InitialLoadingCD));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		waterSpreadingPositions = new NativeList<int2>(16384, base.World.UpdateAllocator.ToAllocator);
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		base.Dependency.Complete();
		using NativeArray<Entity> nativeArray = base.EntityManager.CreateEntity(archetype, waterSpreadingPositions.Length, Allocator.Temp);
		ThreadSafeTimerSimple timer = default(ThreadSafeTimerSimple);
		timer.Start(base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime, 0f);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			base.EntityManager.SetComponentData(nativeArray[i], new WaterSpreaderCD
			{
				position = waterSpreadingPositions[i],
				timer = timer
			});
		}
		waterSpreadingPositions.Dispose();
		base.OnStopRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NativeList<int2> waterSpreadingPositionsLocal = waterSpreadingPositions;
		base.EntityManager.DestroyEntity(runSingleton);
		WaterSpreadingInitSystem_543A9C94_LambdaJob_0_Execute(waterSpreadingPositionsLocal);
	}

	private static SubMapLayer FindAllWaterTiles(in DynamicBuffer<SubMapLayer> layers)
	{
		SubMapLayer result = default(SubMapLayer);
		for (int i = 0; i < layers.Length; i++)
		{
			if (layers[i].layer.tileType == TileType.water)
			{
				BitwiseOrInPlace(ref result.bitfield, layers[i].bitfield);
			}
		}
		return result;
	}

	private unsafe static void BitwiseOrInPlace(ref FixedArray512 bitmask1, FixedArray512 bitmask2)
	{
		for (int i = 0; i < 512; i++)
		{
			byte* num = bitmask1.GetUnsafePtr() + i;
			*num |= bitmask2.GetUnsafePtr()[i];
		}
	}

	private unsafe static void BitwiseComplementInPlace(ref FixedArray512 bitmask1)
	{
		for (int i = 0; i < 512; i++)
		{
			bitmask1.GetUnsafePtr()[i] = (byte)(~bitmask1.GetUnsafePtr()[i]);
		}
	}

	private void WaterSpreadingInitSystem_543A9C94_LambdaJob_0_Execute(NativeList<int2> waterSpreadingPositionsLocal)
	{
		__TypeHandle.__SubMapCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SubMapLayerBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		WaterSpreadingInitSystem_543A9C94_LambdaJob_0_Job jobData = new WaterSpreadingInitSystem_543A9C94_LambdaJob_0_Job
		{
			waterSpreadingPositionsLocal = waterSpreadingPositionsLocal,
			__submapTypeHandle = __TypeHandle.__SubMapCD_RO_ComponentTypeHandle,
			__submapLayersTypeHandle = __TypeHandle.__SubMapLayerBuffer_RO_BufferTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_2111791439_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SubMapLayerBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_2111791439_0 = entityQueryBuilder2.Build(ref state);
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
	public WaterSpreadingInitSystem()
	{
	}
}

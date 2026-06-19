using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
public class MapDebugExtractSubmapSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Job : IJob
	{
		public NativeArray<TileCD> tilesLocal;

		public Entity entityLocal;

		public BufferLookup<SubMapLayerBuffer> submapLayerLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			DynamicBuffer<SubMapLayer> dynamicBuffer = submapLayerLookup[entityLocal].Reinterpret<SubMapLayer>();
			NativeArray<int> array = new NativeArray<int>(dynamicBuffer.Length, Allocator.Temp);
			NativeArray<int> externalValues = new NativeArray<int>(dynamicBuffer.Length, Allocator.Temp);
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				array[i] = i;
				TileType tileType = dynamicBuffer[i].layer.tileType;
				externalValues[i] = -tileType.GetSurfacePriority();
			}
			array.Sort(new CompareByExternalValue
			{
				ExternalValues = externalValues
			});
			for (int j = 0; j < 64; j++)
			{
				for (int k = 0; k < 64; k++)
				{
					int index = j * 64 + k;
					tilesLocal[index] = default(TileCD);
					foreach (int item in array)
					{
						if (dynamicBuffer[item].Get(k, j))
						{
							tilesLocal[index] = dynamicBuffer[item].layer;
							break;
						}
					}
				}
			}
			array.Dispose();
			externalValues.Dispose();
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public BufferLookup<SubMapLayerBuffer> __SubMapLayerBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SubMapLayerBuffer_RO_BufferLookup = state.GetBufferLookup<SubMapLayerBuffer>(isReadOnly: true);
		}
	}

	public NativeReference<Entity> SubmapEntity;

	public NativeArray<TileCD> MapTiles;

	private TypeHandle __TypeHandle;

	[Preserve]
	protected override void OnCreate()
	{
		SubmapEntity = new NativeReference<Entity>(Allocator.Persistent);
		MapTiles = new NativeArray<TileCD>(4096, Allocator.Persistent);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		SubmapEntity.Dispose();
		MapTiles.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (!(SubmapEntity.Value == Entity.Null))
		{
			NativeArray<TileCD> mapTiles = MapTiles;
			Entity value = SubmapEntity.Value;
			BufferLookup<SubMapLayerBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Execute(mapTiles, value, bufferLookup);
			base.OnUpdate();
		}
	}

	private void MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Execute(NativeArray<TileCD> tilesLocal, Entity entityLocal, BufferLookup<SubMapLayerBuffer> submapLayerLookup)
	{
		MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Job jobData = new MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Job
		{
			tilesLocal = tilesLocal,
			entityLocal = entityLocal,
			submapLayerLookup = submapLayerLookup
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		new EntityQueryBuilder(Allocator.Temp).Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public MapDebugExtractSubmapSystem()
	{
	}
}

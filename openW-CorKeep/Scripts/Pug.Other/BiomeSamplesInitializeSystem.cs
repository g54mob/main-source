using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugWorldGen.CoreKeeper;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class BiomeSamplesInitializeSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct InitializeTrigger : IComponentData, IQueryTypeParameter
	{
	}

	[BurstCompile]
	private struct ParseShaderDataJob : IJob
	{
		[ReadOnly]
		public NativeArray<Color32> Data;

		public NativeArray<byte> Samples;

		public void Execute()
		{
			for (int i = 0; i < Data.Length; i++)
			{
				PugWorldGen.CoreKeeper.Biome biome = CoreKeeperWorld.GetBiome(Data[i].g);
				Samples[i] = (byte)(biome switch
				{
					PugWorldGen.CoreKeeper.Biome.Dirt => 1u, 
					PugWorldGen.CoreKeeper.Biome.Clay => 2u, 
					PugWorldGen.CoreKeeper.Biome.Stone => 3u, 
					PugWorldGen.CoreKeeper.Biome.Forest => 5u, 
					PugWorldGen.CoreKeeper.Biome.Sea => 7u, 
					PugWorldGen.CoreKeeper.Biome.Desert => 8u, 
					PugWorldGen.CoreKeeper.Biome.Crystal => 9u, 
					PugWorldGen.CoreKeeper.Biome.Passage => 10u, 
					PugWorldGen.CoreKeeper.Biome.Excavation => 11u, 
					_ => 0u, 
				});
			}
		}
	}

	[BurstCompile]
	private struct VerifySamplesCoverEntireWorldJob : IJob
	{
		[ReadOnly]
		public NativeArray<byte> Samples;

		public int2 SampleBasePosition;

		public int SamplesPerDimension;

		public void Execute()
		{
			if (TryGetBiomeAtEdge(out var sample))
			{
				int2 int5 = SampleToWorldPosition(sample);
				Debug.LogError($"BiomeSamplesInitializeSystem: Biome samples do not cover entire world! Found biome {(Biome)Samples[sample]} ({Samples[sample]}) at edge position {int5.x}, {int5.y} (sample index {sample}). This may result in scenes placed outside world bounds and other issues.");
			}
		}

		private bool TryGetBiomeAtEdge(out int sample)
		{
			for (int i = 0; i < SamplesPerDimension; i++)
			{
				if (Samples[i] != 0)
				{
					sample = i;
					return true;
				}
				if (Samples[(SamplesPerDimension - 1) * SamplesPerDimension + i] != 0)
				{
					sample = (SamplesPerDimension - 1) * SamplesPerDimension + i;
					return true;
				}
			}
			for (int j = 1; j < SamplesPerDimension - 1; j++)
			{
				if (Samples[j * SamplesPerDimension] != 0)
				{
					sample = j * SamplesPerDimension;
					return true;
				}
				if (Samples[j * SamplesPerDimension + SamplesPerDimension - 1] != 0)
				{
					sample = j * SamplesPerDimension + SamplesPerDimension - 1;
					return true;
				}
			}
			sample = 0;
			return false;
		}

		private int2 SampleToWorldPosition(int sample)
		{
			int x = sample % SamplesPerDimension;
			int y = sample / SamplesPerDimension;
			return SampleBasePosition + new int2(x, y) * 16;
		}
	}

	[BurstCompile]
	private struct ComputeBiomeCentroidsJob : IJob
	{
		private const int MAX_SAMPLES_PER_DIMENSION = 128;

		[ReadOnly]
		public NativeArray<byte> Samples;

		public NativeArray<int2> Centroids;

		public int2 SampleBasePosition;

		public int SamplesPerDimension;

		public void Execute()
		{
			for (int i = 0; i < Centroids.Length; i++)
			{
				int2 int5 = ComputeCentroidSampleCoordinates(i, SamplesPerDimension / 2, 2);
				Centroids[i] = SampleBasePosition + int5 * 16;
			}
		}

		private int2 ComputeCentroidSampleCoordinates(int biome, int initialSampleRadius, int finalSampleRadius)
		{
			bool flag = false;
			int2 int5 = new int2(SamplesPerDimension, SamplesPerDimension) / 2;
			for (int num = initialSampleRadius; num >= finalSampleRadius; num /= 2)
			{
				int num2 = 1;
				while (2 * num / num2 > 128)
				{
					num2 *= 2;
				}
				float2 zero = float2.zero;
				int num3 = 0;
				int2 int6 = math.max(int2.zero, int5 - num + num2 / 2);
				int2 int7 = math.min(new int2(SamplesPerDimension - 1), int5 + num);
				for (int i = int6.y; i <= int7.y; i += num2)
				{
					for (int j = int6.x; j <= int7.x; j += num2)
					{
						if (Samples[i * SamplesPerDimension + j] == biome)
						{
							zero += new float2(j, i) + 0.5f;
							num3++;
						}
					}
				}
				if (num3 == 0)
				{
					break;
				}
				flag = true;
				int5 = (zero / num3).RoundToInt2();
			}
			if (!flag)
			{
				return int2.zero;
			}
			return int5;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private int _worldRadius;

	private int _resolution1D;

	private EntityArchetype _singletonArchetype;

	private WorldGenManager.ProceduralDataRequester _proceduralDataRequester;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1648067452_0;

	private EntityQuery __query_1648067452_1;

	private EntityQuery __query_1648067452_2;

	private EntityQuery __query_1648067452_3;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<InitializeTrigger>();
		_singletonArchetype = base.EntityManager.CreateArchetype(typeof(BiomeSamplesCD), typeof(BiomeCentroidsCD));
	}

	[Preserve]
	protected override void OnDestroy()
	{
		if (__query_1648067452_1.TryGetSingleton<BiomeSamplesCD>(out var value))
		{
			value.BasePosition.Dispose();
			value.Samples.Dispose();
		}
		if (__query_1648067452_2.TryGetSingleton<BiomeCentroidsCD>(out var value2))
		{
			value2.Centroids.Dispose();
		}
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		_worldRadius = Manager.worldGen.GetScaledWorldRadiusBound();
		_worldRadius = (int)math.ceil((float)_worldRadius / 16f) * 16;
		_resolution1D = (int)math.ceil((float)(2 * _worldRadius) / 16f);
		_proceduralDataRequester = Manager.worldGen.CreateProceduralDataRequester(_resolution1D * _resolution1D);
		int2 x = new int2(-_worldRadius);
		int2 x2 = new int2(_worldRadius * 2);
		_proceduralDataRequester.RequestArea(x.ToFloat2(), x2.ToFloat2(), 16);
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		_proceduralDataRequester.Dispose();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = __query_1648067452_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(base.CheckedStateRef.WorldUnmanaged);
		if (_proceduralDataRequester.TryGetAreaRequestResult(out var result))
		{
			NativeArray<byte> samples = new NativeArray<byte>(_resolution1D * _resolution1D, Allocator.Persistent);
			NativeArray<int2> centroids = new NativeArray<int2>(12, Allocator.Persistent);
			Entity e = entityCommandBuffer.CreateEntity(_singletonArchetype);
			entityCommandBuffer.SetComponent(e, new BiomeSamplesCD
			{
				BasePosition = new NativeReference<int2>(new int2(-_worldRadius, -_worldRadius), Allocator.Persistent),
				SamplesPerDimension = _resolution1D,
				Samples = samples
			});
			entityCommandBuffer.SetComponent(e, new BiomeCentroidsCD
			{
				Centroids = centroids
			});
			ParseShaderDataJob jobData = new ParseShaderDataJob
			{
				Data = result.Data,
				Samples = samples
			};
			base.Dependency = IJobExtensions.Schedule(jobData, base.Dependency);
			ComputeBiomeCentroidsJob jobData2 = new ComputeBiomeCentroidsJob
			{
				Centroids = centroids,
				Samples = samples,
				SampleBasePosition = new int2(-_worldRadius, -_worldRadius),
				SamplesPerDimension = _resolution1D
			};
			base.Dependency = IJobExtensions.Schedule(jobData2, base.Dependency);
			entityCommandBuffer.DestroyEntity(__query_1648067452_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<InitializeTrigger>();
		__query_1648067452_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067452_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeCentroidsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067452_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067452_3 = entityQueryBuilder2.Build(ref state);
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
	public BiomeSamplesInitializeSystem()
	{
	}
}

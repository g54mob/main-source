using System.Collections.Generic;
using System.Threading;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers.Profiling;
using Unity.Mathematics;

namespace ModApi.Planet
{
	public class TerrainGeneratorCacheData
	{
		private static readonly object _Lock = new object();

		private static Stack<TerrainGeneratorCacheData> _pool = new Stack<TerrainGeneratorCacheData>();

		public int BiomeCount { get; private set; }

		public double[] BiomeTempData { get; private set; }

		public PlanetBiomeVertexData BiomeVertexData { get; private set; }

		public PlanetBiomeVertexData[] BiomeVertexDataResults { get; private set; }

		public int CustomVertexPlanetDataVersion { get; }

		public float[][] MapSampleArray { get; private set; }

		public PlanetMapSet.MapSampleResult MapSampleResult { get; private set; }

		public PlanetModifierProfiler ModifierProfiler { get; set; }

		public PlanetModifierProfilerThread ModifierProfilerThread { get; private set; }

		public float4[] TempVertexFloat4x4Array { get; private set; }

		public int TerrainQuadVertexCount { get; private set; }

		public int ThreadId { get; private set; }

		public PlanetVertexDataInput VertexDataInput { get; private set; }

		public PlanetVertexDataInput[] VertexDataInputs { get; private set; }

		public PlanetVertexData[] VertexDataResults { get; private set; }

		public TerrainGeneratorCacheData(int biomeCount, int terrainQuadVertexCount)
		{
			BiomeCount = biomeCount;
			TerrainQuadVertexCount = terrainQuadVertexCount;
			CustomVertexPlanetDataVersion = CustomPlanetVertexData.Version;
			ThreadId = Thread.CurrentThread.ManagedThreadId;
			VertexDataInput = new PlanetVertexDataInput();
			VertexDataInputs = new PlanetVertexDataInput[terrainQuadVertexCount];
			VertexDataResults = new PlanetVertexData[terrainQuadVertexCount];
			BiomeVertexDataResults = new PlanetBiomeVertexData[terrainQuadVertexCount];
			BiomeVertexData = new PlanetBiomeVertexData();
			BiomeTempData = new double[biomeCount];
			MapSampleResult = new PlanetMapSet.MapSampleResult(biomeCount);
			MapSampleArray = new float[5][]
			{
				new float[4],
				new float[4],
				new float[4],
				new float[4],
				new float[4]
			};
			ModifierProfilerThread = new PlanetModifierProfilerThread();
			for (int i = 0; i < VertexDataInputs.Length; i++)
			{
				VertexDataInputs[i] = new PlanetVertexDataInput();
				VertexDataResults[i] = new PlanetVertexData(this);
				BiomeVertexDataResults[i] = new PlanetBiomeVertexData
				{
					CommonData = VertexDataResults[i],
					Data = new double[10]
				};
			}
			TempVertexFloat4x4Array = new float4[terrainQuadVertexCount * 4];
		}

		public static void CleanupOnSceneTransition()
		{
		}

		public static TerrainGeneratorCacheData GetCacheData(int biomeCount, int terrainQuadVertexCount)
		{
			TerrainGeneratorCacheData terrainGeneratorCacheData = null;
			lock (_Lock)
			{
				terrainGeneratorCacheData = ((_pool.Count == 0) ? new TerrainGeneratorCacheData(biomeCount, terrainQuadVertexCount) : _pool.Pop());
				while (terrainGeneratorCacheData.BiomeCount != biomeCount || terrainGeneratorCacheData.TerrainQuadVertexCount != terrainQuadVertexCount || terrainGeneratorCacheData.CustomVertexPlanetDataVersion != CustomPlanetVertexData.Version)
				{
					terrainGeneratorCacheData = ((_pool.Count == 0) ? new TerrainGeneratorCacheData(biomeCount, terrainQuadVertexCount) : _pool.Pop());
				}
			}
			terrainGeneratorCacheData.ThreadId = Thread.CurrentThread.ManagedThreadId;
			return terrainGeneratorCacheData;
		}

		public void ReturnToPool()
		{
			lock (_Lock)
			{
				_pool.Push(this);
			}
		}
	}
}

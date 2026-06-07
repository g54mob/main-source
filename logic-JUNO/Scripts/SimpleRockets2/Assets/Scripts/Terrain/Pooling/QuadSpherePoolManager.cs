using System;
using System.Collections;
using System.Collections.Generic;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Terrain.Pooling
{
	public class QuadSpherePoolManager : MonoBehaviour
	{
		private static bool _destroyed;

		private static QuadSpherePoolManager _instance;

		private static AnimationCurve _physicsQuadCountEstimates;

		private static AnimationCurve _terrainQuadCountEstimates;

		private List<IQuadSpherePool> _asyncFillPools;

		private Coroutine _asyncPoolFillCoroutine;

		private bool _initialized;

		private Dictionary<int, int[]> _quadTriangleCache = new Dictionary<int, int[]>();

		public static QuadSpherePoolManager Instance
		{
			get
			{
				if (_instance == null && !_destroyed)
				{
					_instance = new GameObject("QuadSpherePoolManager").AddComponent<QuadSpherePoolManager>();
					UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}

		public QuadMeshPool PhysicsMeshPool { get; private set; }

		public PhysicsQuadPool PhysicsQuadPool { get; private set; }

		public QuadScriptPool QuadScriptPool { get; private set; }

		public MeshDataTerrainPool TerrainMeshDataPool { get; private set; }

		public QuadMeshPool TerrainMeshPool { get; private set; }

		public MeshDataWaterPool WaterMeshDataPool { get; private set; }

		public QuadMeshPool WaterMeshPool { get; private set; }

		public int[] GetQuadMeshTriangles(int vertexCount, bool skipEdgeVertices = false)
		{
			int num = vertexCount;
			if (skipEdgeVertices)
			{
				num = -num;
			}
			if (!_quadTriangleCache.TryGetValue(num, out var value))
			{
				value = GenerateQuadTriangles((int)Mathf.Sqrt(vertexCount), skipEdgeVertices);
				_quadTriangleCache.Add(num, value);
			}
			return value;
		}

		public void Initialize(QuadSphereScript quadSphere, bool soiTransition)
		{
			int numVerticesInPaddedQuad = quadSphere.NumVerticesInPaddedQuad;
			int numVerticesInWaterQuad = quadSphere.NumVerticesInWaterQuad;
			bool flag = !CurrentDevice.Flags.HasFlag(DeviceFlags.LowRam);
			QuadMeshDataFlags quadMeshDataFlags = quadSphere.RequiredQuadMeshDataTerrain;
			QuadMeshDataFlags quadMeshDataFlags2 = quadSphere.RequiredQuadMeshDataWater;
			if (flag)
			{
				TerrainQualitySettings terrain = Game.Instance.QualitySettings.Terrain;
				_ = Game.Instance.QualitySettings.VisualEffects;
				quadMeshDataFlags |= QuadMeshDataFlags.Color | QuadMeshDataFlags.UV4;
				if (terrain.Textures.Value != TerrainQualitySettings.TextureQuality.Off)
				{
					quadMeshDataFlags |= QuadMeshDataFlags.UV | QuadMeshDataFlags.UV2 | QuadMeshDataFlags.UV3;
				}
				quadMeshDataFlags2 |= QuadMeshDataFlags.Color | QuadMeshDataFlags.UV | QuadMeshDataFlags.UV2 | QuadMeshDataFlags.UV3;
			}
			NumericSetting<float> lodDistance = Game.Instance.QualitySettings.Terrain.LodDistance;
			(int, int) estimatedQuadCount = GetEstimatedQuadCount(lodDistance);
			int quadSplitJobPoolSize = quadSphere.AsyncJobProcessor.QuadSplitJobPoolSize;
			if (!_initialized)
			{
				int initialSize = estimatedQuadCount.Item1 + 24 * Mathf.CeilToInt(lodDistance);
				int initialSize2 = estimatedQuadCount.Item2 + 4 * Mathf.CeilToInt(lodDistance);
				QuadScriptPool = new QuadScriptPool(initialSize);
				TerrainMeshPool = new QuadMeshPool(QuadMeshPoolType.Terrain, numVerticesInPaddedQuad, quadMeshDataFlags, initialSize);
				PhysicsMeshPool = new QuadMeshPool(QuadMeshPoolType.Physics, numVerticesInPaddedQuad, QuadMeshDataFlags.None, initialSize2);
				WaterMeshPool = new QuadMeshPool(QuadMeshPoolType.Water, numVerticesInWaterQuad, quadMeshDataFlags2, initialSize);
				TerrainMeshDataPool = new MeshDataTerrainPool(numVerticesInPaddedQuad, quadMeshDataFlags, quadSplitJobPoolSize * 4);
				WaterMeshDataPool = new MeshDataWaterPool(numVerticesInWaterQuad, quadMeshDataFlags2, quadSplitJobPoolSize * 4);
				PhysicsQuadPool = new PhysicsQuadPool(initialSize2);
				_asyncFillPools = new List<IQuadSpherePool>(5);
				_initialized = true;
			}
			_asyncFillPools.Clear();
			if (_asyncPoolFillCoroutine != null)
			{
				StopCoroutine(_asyncPoolFillCoroutine);
				_asyncPoolFillCoroutine = null;
			}
			TerrainMeshPool.Initialize(numVerticesInPaddedQuad, quadMeshDataFlags);
			PhysicsMeshPool.Initialize(numVerticesInPaddedQuad, QuadMeshDataFlags.None);
			WaterMeshPool.Initialize(numVerticesInWaterQuad, quadMeshDataFlags2);
			TerrainMeshDataPool.Initialize(numVerticesInPaddedQuad, quadMeshDataFlags);
			WaterMeshDataPool.Initialize(numVerticesInWaterQuad, quadMeshDataFlags2);
			GC.Collect();
			int i = 1;
			int num = 6;
			int num2 = 0;
			for (; i <= quadSphere.MinSubdivisionLevel; i++)
			{
				num2 = num;
				num += (int)Math.Pow(4.0, i) * 6;
			}
			int item = estimatedQuadCount.Item1;
			int item2 = estimatedQuadCount.Item2;
			int targetSize = item - num2;
			int num3 = num - num2;
			QuadScriptPool.Resize(item, soiTransition ? num : item);
			TerrainMeshPool.Resize(targetSize, soiTransition ? num3 : item);
			PhysicsMeshPool.Resize(item2, (!soiTransition) ? item2 : 0);
			PhysicsQuadPool.Resize(item2, (!soiTransition) ? item2 : 0);
			if (quadSphere.PlanetData.HasWater || flag)
			{
				WaterMeshPool.Resize(targetSize, soiTransition ? num3 : item);
			}
			if (_asyncPoolFillCoroutine != null)
			{
				StopCoroutine(_asyncPoolFillCoroutine);
				_asyncPoolFillCoroutine = null;
			}
			_asyncPoolFillCoroutine = StartCoroutine(FillPoolsAsynchronously());
		}

		protected virtual void OnDestroy()
		{
			_destroyed = true;
		}

		private static int[] GenerateQuadTriangles(int vertsOnEdge, bool skipEdgeVertices)
		{
			int[] array = null;
			int num = 0;
			int num2 = 0;
			if (skipEdgeVertices)
			{
				array = new int[(vertsOnEdge - 3) * (vertsOnEdge - 3) * 2 * 3];
				for (int i = 0; i < vertsOnEdge - 1; i++)
				{
					for (int j = 0; j < vertsOnEdge - 1; j++)
					{
						if (i > 0 && j > 0 && i < vertsOnEdge - 2 && j < vertsOnEdge - 2)
						{
							array[num++] = num2;
							array[num++] = num2 + 1;
							array[num++] = num2 + vertsOnEdge;
							array[num++] = num2 + 1;
							array[num++] = num2 + vertsOnEdge + 1;
							array[num++] = num2 + vertsOnEdge;
						}
						num2++;
					}
					num2++;
				}
			}
			else
			{
				array = new int[(vertsOnEdge - 1) * (vertsOnEdge - 1) * 2 * 3];
				for (int k = 0; k < vertsOnEdge - 1; k++)
				{
					for (int l = 0; l < vertsOnEdge - 1; l++)
					{
						array[num++] = num2;
						array[num++] = num2 + 1;
						array[num++] = num2 + vertsOnEdge;
						array[num++] = num2 + 1;
						array[num++] = num2 + vertsOnEdge + 1;
						array[num++] = num2 + vertsOnEdge;
						num2++;
					}
					num2++;
				}
			}
			return array;
		}

		private static (int TerrainQuads, int PhysicsQuads) GetEstimatedQuadCount(float lodLevel)
		{
			if (_terrainQuadCountEstimates == null || _physicsQuadCountEstimates == null)
			{
				_terrainQuadCountEstimates = new AnimationCurve(new Keyframe(2f, 684f), new Keyframe(3f, 754f), new Keyframe(4f, 902f), new Keyframe(5f, 1154f), new Keyframe(6f, 1330f), new Keyframe(7f, 1656f), new Keyframe(8f, 1984f), new Keyframe(9f, 2374f), new Keyframe(10f, 2844f));
				_physicsQuadCountEstimates = new AnimationCurve(new Keyframe(2f, 24f), new Keyframe(3f, 48f), new Keyframe(4f, 64f), new Keyframe(5f, 64f), new Keyframe(6f, 64f), new Keyframe(7f, 64f), new Keyframe(8f, 64f), new Keyframe(9f, 80f), new Keyframe(10f, 80f));
			}
			return (TerrainQuads: Mathf.CeilToInt(_terrainQuadCountEstimates.Evaluate(lodLevel)), PhysicsQuads: Mathf.CeilToInt(_physicsQuadCountEstimates.Evaluate(lodLevel)));
		}

		private IEnumerator FillPoolsAsynchronously()
		{
			_asyncFillPools.Clear();
			_asyncFillPools.Add(QuadScriptPool);
			_asyncFillPools.Add(TerrainMeshPool);
			_asyncFillPools.Add(PhysicsMeshPool);
			_asyncFillPools.Add(WaterMeshPool);
			_asyncFillPools.Add(PhysicsQuadPool);
			yield return null;
			while (true)
			{
				for (int i = _asyncFillPools.Count - 1; i >= 0; i--)
				{
					IQuadSpherePool quadSpherePool = _asyncFillPools[i];
					if (quadSpherePool.Size < quadSpherePool.TargetSize)
					{
						quadSpherePool.Grow(1);
						yield return null;
					}
				}
				yield return null;
			}
		}
	}
}

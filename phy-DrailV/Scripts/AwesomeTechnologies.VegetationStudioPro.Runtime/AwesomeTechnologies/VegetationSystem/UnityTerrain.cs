using System;
using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem.Biomes;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace AwesomeTechnologies.VegetationSystem
{
	[AwesomeTechnologiesScriptOrder(-100)]
	[ExecuteInEditMode]
	public class UnityTerrain : MonoBehaviour, IVegetationStudioTerrain
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct GenerateDefaultBiomeBlendMaskJob : IJobParallelFor
		{
			public NativeArray<float> BlendMask;

			public void Execute(int index)
			{
				BlendMask[index] = 1f;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct GenerateBlendMaskJob : IJobParallelFor
		{
			public NativeArray<float> BlendMask;

			[ReadOnly]
			public NativeArray<Vector2> PolygonArray;

			[ReadOnly]
			public NativeArray<LineSegment2D> SegmentArray;

			[ReadOnly]
			public NativeArray<float> CurveArray;

			public int Width;

			public int Height;

			public Vector3 TerrainSize;

			public Vector4 TerrainPosition;

			public Rect PolygonRect;

			public bool UseNoise;

			public float NoiseScale;

			public float BlendDistance;

			public bool Include;

			public void Execute(int index)
			{
				float num = BlendMask[index];
				float x = num;
				int num2 = Mathf.FloorToInt((float)index / (float)Width);
				int num3 = index - num2 * Width;
				float x2 = TerrainPosition.x + TerrainSize.x / (float)Width * (float)num3;
				float y = TerrainPosition.z + TerrainSize.z / (float)Height * (float)num2;
				float num4 = TerrainPosition.x + TerrainSize.x / (float)Width * (float)num2;
				float num5 = TerrainPosition.z - TerrainSize.z / (float)Height * (float)(-num3);
				Vector2 vector = new Vector2(x2, y);
				if (PolygonRect.Contains(vector) && IsInPolygon(vector))
				{
					num = math.max(num, 1f);
					float num6 = DistanceToEdge(vector);
					if (num6 < BlendDistance)
					{
						float falseValue = math.select(1f, Mathf.PerlinNoise(num4 / NoiseScale, num5 / NoiseScale), UseNoise);
						falseValue = math.select(falseValue, 0f, !Include && !UseNoise);
						num = math.select(math.max((1f - SampleCurveArray(num6 / BlendDistance)) * (1f - falseValue), num), math.min(SampleCurveArray(num6 / BlendDistance) * falseValue, num), Include);
						num = math.max(x, num);
					}
					BlendMask[index] = num;
				}
			}

			private float SampleCurveArray(float value)
			{
				if (CurveArray.Length == 0)
				{
					return 0f;
				}
				int value2 = Mathf.RoundToInt(value * (float)CurveArray.Length);
				value2 = Mathf.Clamp(value2, 0, CurveArray.Length - 1);
				if (value2 == CurveArray.Length - 1)
				{
					return CurveArray[value2];
				}
				float x = math.clamp(value, 0f, 1f) * (float)(CurveArray.Length - 1);
				float start = CurveArray[value2];
				float end = CurveArray[value2 + 1];
				return math.lerp(start, end, math.frac(x));
			}

			private float DistanceToEdge(Vector2 point)
			{
				float num = float.MaxValue;
				for (int i = 0; i < SegmentArray.Length; i++)
				{
					if (SegmentArray[i].DisableEdge == 0)
					{
						num = math.min(num, SegmentArray[i].DistanceToPoint(point));
					}
				}
				return num;
			}

			private bool IsInPolygon(Vector2 p)
			{
				bool flag = false;
				if (PolygonArray.Length < 3)
				{
					return false;
				}
				Vector2 vector = new Vector2(PolygonArray[PolygonArray.Length - 1].x, PolygonArray[PolygonArray.Length - 1].y);
				for (int i = 0; i < PolygonArray.Length; i++)
				{
					Vector2 vector2 = new Vector2(PolygonArray[i].x, PolygonArray[i].y);
					Vector2 vector3;
					Vector2 vector4;
					if (vector2.x > vector.x)
					{
						vector3 = vector;
						vector4 = vector2;
					}
					else
					{
						vector3 = vector2;
						vector4 = vector;
					}
					if (vector2.x < p.x == p.x <= vector.x && (p.y - (float)(long)vector3.y) * (vector4.x - vector3.x) < (vector4.y - (float)(long)vector3.y) * (p.x - vector3.x))
					{
						flag = !flag;
					}
					vector = vector2;
				}
				return flag;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct CopyLockedDataJob : IJobParallelFor
		{
			public NativeArray<float> SplatMapArray;

			[ReadOnly]
			public NativeArray<float> CurrentSplatMapArray;

			public int Width;

			public int Height;

			public int Layers;

			public int TextureIndex;

			public void Execute(int index)
			{
				Math.DivRem(index, Layers, out var result);
				if (result == TextureIndex)
				{
					SplatMapArray[index] = CurrentSplatMapArray[index];
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct ProcessSplatMapJob : IJobParallelFor
		{
			public NativeArray<float> SplatMapArray;

			[ReadOnly]
			public NativeArray<float> BlendMask;

			[ReadOnly]
			public NativeArray<HeightMapSample> HeightMap;

			[ReadOnly]
			public NativeArray<float> Heights;

			[ReadOnly]
			public NativeArray<float> HeightCurve;

			[ReadOnly]
			public NativeArray<float> SteepnessCurve;

			public int Width;

			public int Height;

			public int Layers;

			public int TextureIndex;

			public bool TextureUseNoise;

			public float TextureNoiseScale;

			public float TextureWeight;

			public Vector2 TextureNoiseOffset;

			public float NoiceCellResolutionFactor;

			public bool InverseTextureNoise;

			public float TerrainHeight;

			public float TerrainYPosition;

			public float WorldspaceSeaLevel;

			public int HeightmapWidth;

			public int HeightmapHeight;

			public Vector3 HeightMapScale;

			public bool ConcaveEnable;

			public bool ConvexEnable;

			public bool ConcaveAverage;

			public float ConcaveMinHeightDifference;

			public float ConcaveDistance;

			public int ConcaveMode;

			public Vector3 TerrainSize;

			public Vector4 TerrainPosition;

			public void Execute(int index)
			{
				int result;
				int result2;
				int num = Math.DivRem(Math.DivRem(index, Layers, out result), Height, out result2) % Width;
				float num2 = TerrainPosition.x + TerrainSize.x / (float)Width * (float)result2;
				float num3 = TerrainPosition.z - TerrainSize.z / (float)Height * (float)(-num);
				float num4 = HeightMap[result2 + num * Width].Height + TerrainYPosition;
				num4 -= WorldspaceSeaLevel;
				float steepness = HeightMap[result2 + num * Width].Steepness;
				if (result != TextureIndex)
				{
					return;
				}
				float num5 = math.select(1f, Mathf.PerlinNoise((num2 + TextureNoiseOffset.x) / TextureNoiseScale, (num3 + TextureNoiseOffset.y) / TextureNoiseScale), TextureUseNoise);
				num5 = math.select(num5, 1f - num5, InverseTextureNoise && TextureUseNoise);
				float num6 = SampleCurveArray(SteepnessCurve, steepness / 90f) * SampleCurveArray(HeightCurve, num4 / TerrainHeight) * num5 * TextureWeight;
				if (ConcaveEnable || ConvexEnable)
				{
					float num7 = (float)Width / (float)HeightmapWidth;
					float2 heightmapPosition = new float2((float)result2 / num7, (float)num / num7);
					float num8 = SampleConcaveFactor(heightmapPosition);
					if (ConcaveMode == 0)
					{
						num8 = num8 * num5 * TextureWeight;
						SplatMapArray[index] = math.max(num8, num6);
					}
					else
					{
						SplatMapArray[index] = num8 * num6;
					}
				}
				else
				{
					SplatMapArray[index] = num6;
				}
			}

			private float SampleCurveArray(NativeArray<float> curve, float value)
			{
				if (curve.Length == 0)
				{
					return 0f;
				}
				int value2 = Mathf.RoundToInt(value * (float)curve.Length);
				value2 = Mathf.Clamp(value2, 0, curve.Length - 1);
				if (value2 == curve.Length - 1)
				{
					return curve[value2];
				}
				float x = math.clamp(value, 0f, 1f) * (float)(curve.Length - 1);
				float start = curve[value2];
				float end = curve[value2 + 1];
				return math.lerp(start, end, math.frac(x));
			}

			private float SampleConcaveFactor(float2 heightmapPosition)
			{
				int num = Mathf.RoundToInt(heightmapPosition.x);
				int num2 = Mathf.RoundToInt(heightmapPosition.y);
				int num3 = Mathf.RoundToInt(ConcaveDistance / HeightMapScale.x);
				float height = GetHeight(num, num2);
				float height2 = GetHeight(num - num3, num2 - num3);
				float height3 = GetHeight(num, num2 - num3);
				float height4 = GetHeight(num + num3, num2 - num3);
				float height5 = GetHeight(num - num3, num2);
				float height6 = GetHeight(num + num3, num2);
				float height7 = GetHeight(num - num3, num2 + num3);
				float height8 = GetHeight(num, num2 + num3);
				float height9 = GetHeight(num + num3, num2 + num3);
				float num4 = ((!ConcaveAverage) ? GetMinimumHeight(height2, height3, height4, height5, height6, height7, height8, height9) : ((height2 + height3 + height4 + height5 + height6 + height7 + height8 + height9) / 8f));
				float num5 = math.clamp((height - num4) / ConcaveMinHeightDifference, 0f, 1f);
				float num6 = math.clamp((num4 - height) / ConcaveMinHeightDifference, 0f, 1f);
				if (ConvexEnable && ConcaveEnable)
				{
					return math.max(num5, num6);
				}
				if (ConcaveEnable)
				{
					return num6;
				}
				return num5;
			}

			private float GetMinimumHeight(float height1, float height2, float height3, float height4, float height5, float height6, float height7, float height8)
			{
				return math.min(math.min(math.min(math.min(math.min(math.min(math.min(height1, height2), height3), height4), height5), height6), height7), height8);
			}

			private float GetHeight(int x, int y)
			{
				x = math.clamp(x, 0, HeightmapWidth - 1);
				y = math.clamp(y, 0, HeightmapHeight - 1);
				return Heights[y * HeightmapWidth + x] * HeightMapScale.y;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct BlendSplatMapJob : IJobParallelFor
		{
			public NativeArray<float> CurrentSplatMapArray;

			[ReadOnly]
			public NativeArray<float> SplatMapArray;

			[ReadOnly]
			public NativeArray<float> BlendMask;

			public int Width;

			public int Height;

			public int Layers;

			public void Execute(int index)
			{
				int result;
				int result2;
				int num = Math.DivRem(Math.DivRem(index, Layers, out result), Height, out result2) % Width;
				float num2 = BlendMask[result2 + num * Width];
				CurrentSplatMapArray[index] = CurrentSplatMapArray[index] * (1f - num2) + SplatMapArray[index] * num2;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct NormalizeSplatMapJob : IJobParallelForBatch
		{
			public NativeArray<float> SplatMapArray;

			public int FirstEnabledIndex;

			public void Execute(int startIndex, int count)
			{
				float num = 0f;
				for (int i = 0; i <= count - 1; i++)
				{
					num += SplatMapArray[startIndex + i];
				}
				if (Math.Abs(num) > 0.0001f)
				{
					for (int j = 0; j <= count - 1; j++)
					{
						SplatMapArray[startIndex + j] /= num;
					}
					return;
				}
				for (int k = 0; k <= count - 1; k++)
				{
					SplatMapArray[startIndex + k] = 0f;
				}
				SplatMapArray[startIndex + FirstEnabledIndex] = 1f;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct NormalizeSplatMapKeepLockedDataJob : IJobParallelForBatch
		{
			public NativeArray<float> SplatMapArray;

			public int FirstEnabledIndex;

			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<int> AutomaticGenerationArray;

			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<int> LockedTextureArray;

			public void Execute(int startIndex, int count)
			{
				float num = 0f;
				for (int i = 0; i <= count - 1; i++)
				{
					if (LockedTextureArray[i] == 1)
					{
						num += SplatMapArray[startIndex + i];
					}
				}
				float num2 = 0f;
				for (int j = 0; j <= count - 1; j++)
				{
					if (AutomaticGenerationArray[j] == 1)
					{
						num2 += SplatMapArray[startIndex + j];
					}
				}
				num2 /= 1f - num;
				if (Math.Abs(num2 + num) > float.Epsilon)
				{
					for (int k = 0; k <= count - 1; k++)
					{
						if (AutomaticGenerationArray[k] == 1)
						{
							SplatMapArray[startIndex + k] /= num2;
						}
					}
				}
				else
				{
					for (int l = 0; l <= count - 1; l++)
					{
						SplatMapArray[startIndex + l] = 0f;
					}
					SplatMapArray[startIndex + FirstEnabledIndex] = 1f;
				}
			}
		}

		public NativeArray<float> Heights;

		[FormerlySerializedAs("_terrain")]
		public Terrain Terrain;

		private int _heightmapHeight;

		private int _heightmapWidth;

		private Vector3 _size;

		private Vector3 _scale;

		private Vector3 _heightmapScale;

		private Rect _terrainRect;

		private readonly List<NativeArray<ARGBBytes>> _splatMapArrayList = new List<NativeArray<ARGBBytes>>();

		private readonly List<int> _splatMapFormatList = new List<int>();

		private Material _originalTerrainMaterial;

		private float _originalTerrainheightmapPixelError;

		public bool TerrainMaterialOverridden;

		private bool _originalTerrainInstanced;

		private float _originalBasemapDistance;

		[NonSerialized]
		public Material TerrainHeatmapMaterial;

		public bool DisableTerrainTreesAndDetails = true;

		public bool AutoAddToVegegetationSystem;

		private bool _initDone;

		public TerrainSourceID TerrainSourceID;

		public Vector3 TerrainPosition = Vector3.zero;

		private JobHandle _splatMapHandle;

		private NativeArray<HeightMapSample> _heightMapSamples;

		private NativeArray<float> _currentSplatmapArray;

		private readonly List<NativeArray<float>> _nativeArrayFloatList = new List<NativeArray<float>>();

		public string TerrainType => "Unity terrain";

		public Bounds TerrainBounds
		{
			get
			{
				if ((bool)Terrain)
				{
					TerrainData terrainData = Terrain.terrainData;
					return new Bounds(terrainData.bounds.center + TerrainPosition, terrainData.bounds.size);
				}
				return new Bounds(Vector3.zero, Vector3.zero);
			}
		}

		private void Reset()
		{
			FindTerrain();
			TerrainPosition = base.transform.position;
		}

		private void FindTerrain()
		{
			if (!Terrain)
			{
				Terrain = base.gameObject.GetComponent<Terrain>();
			}
		}

		private void Awake()
		{
			FindTerrain();
		}

		private void Start()
		{
			if ((bool)Terrain && DisableTerrainTreesAndDetails)
			{
				Terrain.drawTreesAndFoliage = false;
			}
		}

		private void LoadHeightData()
		{
			TerrainData terrainData = Terrain.terrainData;
			_heightmapScale = terrainData.heightmapScale;
			_heightmapHeight = terrainData.heightmapResolution;
			_heightmapWidth = terrainData.heightmapResolution;
			_size = terrainData.size;
			_scale.x = _size.x / (float)(_heightmapWidth - 1);
			_scale.y = _size.y;
			_scale.z = _size.z / (float)(_heightmapHeight - 1);
			Vector2 position = new Vector2(TerrainPosition.x, TerrainPosition.z);
			Vector2 size = new Vector2(_size.x, _size.z);
			_terrainRect = new Rect(position, size);
			float[,] heights = Terrain.terrainData.GetHeights(0, 0, _heightmapWidth, _heightmapHeight);
			if (Heights.IsCreated)
			{
				Heights.Dispose();
			}
			Heights = new NativeArray<float>(_heightmapWidth * _heightmapHeight, Allocator.Persistent);
			Heights.CopyFromFast(heights);
		}

		public JobHandle SampleTerrain(NativeList<VegetationSpawnLocationInstance> spawnLocationList, VegetationInstanceData instanceData, int sampleCount, Rect spawnRect, JobHandle dependsOn)
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			if (spawnRect.Overlaps(_terrainRect))
			{
				return new UnityTerrainSampleJob
				{
					InputHeights = Heights,
					SpawnLocationList = spawnLocationList.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					Rotation = instanceData.Rotation.AsDeferredJobArray(),
					Scales = instanceData.Scale.AsDeferredJobArray(),
					TerrainNormal = instanceData.TerrainNormal.AsDeferredJobArray(),
					BiomeDistance = instanceData.BiomeDistance.AsDeferredJobArray(),
					TerrainTextureData = instanceData.TerrainTextureData.AsDeferredJobArray(),
					RandomNumberIndex = instanceData.RandomNumberIndex.AsDeferredJobArray(),
					DistanceFalloff = instanceData.DistanceFalloff.AsDeferredJobArray(),
					VegetationMaskDensity = instanceData.VegetationMaskDensity.AsDeferredJobArray(),
					VegetationMaskScale = instanceData.VegetationMaskScale.AsDeferredJobArray(),
					TerrainSourceIDs = instanceData.TerrainSourceID.AsDeferredJobArray(),
					TextureMaskData = instanceData.TextureMaskData.AsDeferredJobArray(),
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					HeightmapSampled = instanceData.HeightmapSampled.AsDeferredJobArray(),
					HeightMapScale = _heightmapScale,
					HeightmapHeight = _heightmapHeight,
					HeightmapWidth = _heightmapWidth,
					TerrainPosition = TerrainPosition,
					Scale = _scale,
					Size = _size,
					TerrainSourceID = (byte)TerrainSourceID
				}.Schedule(sampleCount, 64, dependsOn);
			}
			return dependsOn;
		}

		public void RefreshTerrainData()
		{
			LoadHeightData();
		}

		public void RefreshTerrainData(Bounds bounds)
		{
			Rect other = RectExtension.CreateRectFromBounds(TerrainBounds);
			if (!RectExtension.CreateRectFromBounds(bounds).Overlaps(other))
			{
				LoadHeightData();
			}
		}

		public JobHandle SampleCellHeight(NativeArray<Bounds> vegetationCellBoundsList, float worldspaceHeightCutoff, Rect cellBoundsRect, JobHandle dependsOn = default(JobHandle))
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			if (!Heights.IsCreated)
			{
				LoadHeightData();
			}
			if (cellBoundsRect.Overlaps(_terrainRect))
			{
				return new UnityTerranCellSampleJob
				{
					InputHeights = Heights,
					VegetationCellBoundsList = vegetationCellBoundsList,
					HeightMapScale = _heightmapScale,
					HeightmapHeight = _heightmapHeight,
					HeightmapWidth = _heightmapWidth,
					TerrainPosition = TerrainPosition,
					WorldspaceHeightCutoff = worldspaceHeightCutoff,
					TerrainRect = RectExtension.CreateRectFromBounds(TerrainBounds)
				}.Schedule(vegetationCellBoundsList.Length, 32, dependsOn);
			}
			return dependsOn;
		}

		public JobHandle SampleConcaveLocation(VegetationInstanceData instanceData, float minHeightDifference, float distance, bool inverse, bool average, Rect spawnRect, JobHandle dependsOn)
		{
			if (!_initDone)
			{
				return dependsOn;
			}
			if (spawnRect.Overlaps(_terrainRect))
			{
				return new UnityTerrainSampleConcaveJob
				{
					InputHeights = Heights,
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					HeightMapScale = _heightmapScale,
					HeightmapHeight = _heightmapHeight,
					HeightmapWidth = _heightmapWidth,
					TerrainPosition = TerrainPosition,
					Size = _size,
					Distance = distance,
					MinHeightDifference = minHeightDifference,
					Inverse = inverse,
					Average = average
				}.Schedule(instanceData.Excluded, 64, dependsOn);
			}
			return dependsOn;
		}

		public void Init()
		{
			if (!Heights.IsCreated)
			{
				LoadHeightData();
			}
		}

		public void DisposeTemporaryMemory()
		{
		}

		public bool HasTerrainTextures()
		{
			return true;
		}

		public Texture2D GetTerrainTexture(int index)
		{
			if (!Terrain)
			{
				return null;
			}
			if (!Terrain.terrainData)
			{
				return null;
			}
			if (Terrain.terrainData.terrainLayers.Length > index)
			{
				if ((bool)Terrain.terrainData.terrainLayers[index])
				{
					return Terrain.terrainData.terrainLayers[index].diffuseTexture;
				}
				return null;
			}
			return null;
		}

		public TerrainLayer[] GetTerrainLayers()
		{
			if (!Terrain)
			{
				return new TerrainLayer[0];
			}
			return Terrain.terrainData.terrainLayers;
		}

		public void SetTerrainLayers(TerrainLayer[] terrainLayers)
		{
			if ((bool)Terrain)
			{
				Terrain.terrainData.terrainLayers = terrainLayers;
			}
		}

		private void OnEnable()
		{
			RefreshSplatMaps();
			_initDone = true;
			if (AutoAddToVegegetationSystem && Application.isPlaying)
			{
				AddTerrainToVegetationSystem();
			}
			else
			{
				VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
			}
		}

		public void AddTerrainToVegetationSystem()
		{
			VegetationStudioManager.AddTerrain(base.gameObject, forceAdd: false);
		}

		private void OnDisable()
		{
			_initDone = false;
			if (AutoAddToVegegetationSystem && Application.isPlaying)
			{
				VegetationStudioManager.RemoveTerrain(base.gameObject);
			}
			else
			{
				VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
			}
			Dispose();
		}

		public void RefreshTerrainArea()
		{
			VegetationStudioManager.RefreshTerrainArea(TerrainBounds);
		}

		public void Dispose()
		{
			if (Heights.IsCreated)
			{
				Heights.Dispose();
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(TerrainBounds.center, TerrainBounds.size);
		}

		private void Update()
		{
			if (!Application.isPlaying)
			{
				TerrainPosition = base.transform.position;
			}
		}

		public bool NeedsSplatMapUpdate(Bounds updateBounds)
		{
			return updateBounds.Intersects(TerrainBounds);
		}

		public void PrepareSplatmapGeneration(bool clearLockedTextures)
		{
			LoadHeightData();
			int alphamapWidth = Terrain.terrainData.alphamapWidth;
			int alphamapHeight = Terrain.terrainData.alphamapHeight;
			int alphamapLayers = Terrain.terrainData.alphamapLayers;
			int num = alphamapWidth * alphamapHeight;
			if (_heightMapSamples.IsCreated)
			{
				_heightMapSamples.Dispose();
			}
			_heightMapSamples = new NativeArray<HeightMapSample>(num, Allocator.TempJob);
			SampleHeightMapJob jobData = new SampleHeightMapJob
			{
				HeightMapSamples = _heightMapSamples,
				InputHeights = Heights,
				HeightMapScale = _heightmapScale,
				HeightmapHeight = _heightmapHeight,
				HeightmapWidth = _heightmapWidth,
				Scale = _scale,
				Size = _size,
				Width = alphamapWidth,
				Height = alphamapHeight
			};
			_splatMapHandle = jobData.Schedule(num, 32);
			if (_currentSplatmapArray.IsCreated)
			{
				_currentSplatmapArray.Dispose();
			}
			_currentSplatmapArray = new NativeArray<float>(alphamapWidth * alphamapHeight * alphamapLayers, Allocator.TempJob);
			if (!clearLockedTextures)
			{
				float[,,] alphamaps = Terrain.terrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
				_currentSplatmapArray.CopyFromFast(alphamaps);
			}
		}

		public void GenerateSplatMapBiome(Bounds updateBounds, BiomeType biomeType, List<PolygonBiomeMask> polygonBiomeMaskList, List<TerrainTextureSettings> terrainTextureSettingsList, float heightCurveSampleHeight, float worldSpaceSeaLevel, bool clearLockedTextures)
		{
			int alphamapWidth = Terrain.terrainData.alphamapWidth;
			int alphamapHeight = Terrain.terrainData.alphamapHeight;
			int alphamapLayers = Terrain.terrainData.alphamapLayers;
			int num = alphamapWidth * alphamapHeight;
			NativeArray<float> nativeArray = new NativeArray<float>(num, Allocator.TempJob);
			NativeArray<float> nativeArray2 = new NativeArray<float>(alphamapWidth * alphamapHeight * alphamapLayers, Allocator.TempJob);
			if (biomeType == BiomeType.Default)
			{
				GenerateDefaultBiomeBlendMaskJob jobData = new GenerateDefaultBiomeBlendMaskJob
				{
					BlendMask = nativeArray
				};
				_splatMapHandle = jobData.Schedule(num, 32, _splatMapHandle);
			}
			else
			{
				for (int i = 0; i <= polygonBiomeMaskList.Count - 1; i++)
				{
					GenerateBlendMaskJob jobData2 = new GenerateBlendMaskJob
					{
						Width = alphamapWidth,
						Height = alphamapHeight,
						TerrainSize = _size,
						TerrainPosition = TerrainPosition,
						BlendMask = nativeArray,
						PolygonArray = polygonBiomeMaskList[i].PolygonArray,
						SegmentArray = polygonBiomeMaskList[i].SegmentArray,
						CurveArray = polygonBiomeMaskList[i].TextureCurveArray,
						UseNoise = polygonBiomeMaskList[i].UseNoise,
						NoiseScale = polygonBiomeMaskList[i].NoiseScale,
						BlendDistance = polygonBiomeMaskList[i].BlendDistance,
						PolygonRect = RectExtension.CreateRectFromBounds(polygonBiomeMaskList[i].MaskBounds),
						Include = true
					};
					_splatMapHandle = jobData2.Schedule(num, 32, _splatMapHandle);
				}
			}
			for (int j = 0; j <= terrainTextureSettingsList.Count - 1; j++)
			{
				if (j < alphamapLayers)
				{
					if (terrainTextureSettingsList[j].Enabled)
					{
						ProcessSplatMapJob jobData3 = new ProcessSplatMapJob
						{
							Height = alphamapHeight,
							Width = alphamapWidth,
							Layers = alphamapLayers,
							SplatMapArray = nativeArray2,
							BlendMask = nativeArray,
							HeightMap = _heightMapSamples,
							Heights = Heights,
							TextureIndex = j,
							TextureUseNoise = terrainTextureSettingsList[j].UseNoise,
							TextureNoiseScale = terrainTextureSettingsList[j].NoiseScale,
							TextureWeight = terrainTextureSettingsList[j].TextureWeight,
							TextureNoiseOffset = terrainTextureSettingsList[j].NoiseOffset,
							InverseTextureNoise = terrainTextureSettingsList[j].InverseNoise,
							HeightCurve = terrainTextureSettingsList[j].HeightCurveArray,
							SteepnessCurve = terrainTextureSettingsList[j].SteepnessCurveArray,
							TerrainHeight = heightCurveSampleHeight,
							TerrainYPosition = TerrainPosition.y,
							WorldspaceSeaLevel = worldSpaceSeaLevel,
							HeightMapScale = _heightmapScale,
							HeightmapHeight = _heightmapHeight,
							HeightmapWidth = _heightmapWidth,
							ConcaveEnable = terrainTextureSettingsList[j].ConcaveEnable,
							ConvexEnable = terrainTextureSettingsList[j].ConvexEnable,
							ConcaveAverage = terrainTextureSettingsList[j].ConcaveAverage,
							ConcaveMinHeightDifference = terrainTextureSettingsList[j].ConcaveMinHeightDifference,
							ConcaveDistance = terrainTextureSettingsList[j].ConcaveDistance,
							ConcaveMode = (int)terrainTextureSettingsList[j].ConcaveMode,
							TerrainSize = _size,
							TerrainPosition = TerrainPosition
						};
						_splatMapHandle = jobData3.Schedule(alphamapWidth * alphamapHeight * alphamapLayers, 32, _splatMapHandle);
					}
					else if (!clearLockedTextures && terrainTextureSettingsList[j].LockTexture)
					{
						CopyLockedDataJob jobData4 = new CopyLockedDataJob
						{
							Height = alphamapHeight,
							Width = alphamapWidth,
							Layers = alphamapLayers,
							SplatMapArray = nativeArray2,
							CurrentSplatMapArray = _currentSplatmapArray,
							TextureIndex = j
						};
						_splatMapHandle = jobData4.Schedule(alphamapWidth * alphamapHeight * alphamapLayers, 32, _splatMapHandle);
					}
				}
			}
			int firstEnabledIndex = 0;
			for (int k = 0; k <= terrainTextureSettingsList.Count - 1; k++)
			{
				if (terrainTextureSettingsList[k].Enabled)
				{
					firstEnabledIndex = k;
					break;
				}
			}
			if (!clearLockedTextures)
			{
				NativeArray<int> lockedTextureArray = new NativeArray<int>(terrainTextureSettingsList.Count, Allocator.TempJob);
				NativeArray<int> automaticGenerationArray = new NativeArray<int>(terrainTextureSettingsList.Count, Allocator.TempJob);
				for (int l = 0; l <= terrainTextureSettingsList.Count - 1; l++)
				{
					if (terrainTextureSettingsList[l].Enabled)
					{
						automaticGenerationArray[l] = 1;
					}
					else if (terrainTextureSettingsList[l].LockTexture)
					{
						lockedTextureArray[l] = 1;
					}
				}
				NormalizeSplatMapKeepLockedDataJob jobData5 = new NormalizeSplatMapKeepLockedDataJob
				{
					SplatMapArray = nativeArray2,
					FirstEnabledIndex = firstEnabledIndex,
					AutomaticGenerationArray = automaticGenerationArray,
					LockedTextureArray = lockedTextureArray
				};
				_splatMapHandle = jobData5.ScheduleBatch(alphamapWidth * alphamapHeight * alphamapLayers, alphamapLayers, _splatMapHandle);
			}
			else
			{
				NormalizeSplatMapJob jobData6 = new NormalizeSplatMapJob
				{
					SplatMapArray = nativeArray2,
					FirstEnabledIndex = firstEnabledIndex
				};
				_splatMapHandle = jobData6.ScheduleBatch(alphamapWidth * alphamapHeight * alphamapLayers, alphamapLayers, _splatMapHandle);
			}
			BlendSplatMapJob jobData7 = new BlendSplatMapJob
			{
				CurrentSplatMapArray = _currentSplatmapArray,
				SplatMapArray = nativeArray2,
				BlendMask = nativeArray,
				Height = alphamapHeight,
				Width = alphamapWidth,
				Layers = alphamapLayers
			};
			_splatMapHandle = jobData7.Schedule(alphamapWidth * alphamapHeight * alphamapLayers, 32, _splatMapHandle);
			_nativeArrayFloatList.Add(nativeArray2);
			_nativeArrayFloatList.Add(nativeArray);
		}

		public void CompleteSplatmapGeneration()
		{
			_splatMapHandle.Complete();
			int alphamapWidth = Terrain.terrainData.alphamapWidth;
			int alphamapHeight = Terrain.terrainData.alphamapHeight;
			int alphamapLayers = Terrain.terrainData.alphamapLayers;
			float[,,] array = new float[alphamapWidth, alphamapHeight, alphamapLayers];
			_currentSplatmapArray.CopyToFast(array);
			Terrain.terrainData.SetAlphamaps(0, 0, array);
			if (_heightMapSamples.IsCreated)
			{
				_heightMapSamples.Dispose();
			}
			if (_currentSplatmapArray.IsCreated)
			{
				_currentSplatmapArray.Dispose();
			}
			for (int i = 0; i <= _nativeArrayFloatList.Count - 1; i++)
			{
				if (_nativeArrayFloatList[i].IsCreated)
				{
					_nativeArrayFloatList[i].Dispose();
				}
			}
			_nativeArrayFloatList.Clear();
		}

		private void SetupHeatmapMaterial()
		{
			TerrainHeatmapMaterial = UnityEngine.Object.Instantiate(Resources.Load<Material>("TerrainHeatmap"));
			TerrainHeatmapMaterial.shader = Shader.Find("AwesomeTechnologies/Release/Terrain/BetterShaders_TerrainHeatmap");
		}

		public void OverrideTerrainMaterial()
		{
			if ((bool)Terrain)
			{
				if (TerrainHeatmapMaterial == null)
				{
					SetupHeatmapMaterial();
				}
				if (!TerrainMaterialOverridden)
				{
					_originalTerrainMaterial = Terrain.materialTemplate;
					_originalTerrainheightmapPixelError = Terrain.heightmapPixelError;
					_originalBasemapDistance = Terrain.basemapDistance;
					_originalTerrainInstanced = Terrain.drawInstanced;
					Terrain.drawInstanced = false;
					TerrainMaterialOverridden = true;
				}
				Terrain.materialTemplate = TerrainHeatmapMaterial;
				Terrain.basemapDistance = 0f;
				Terrain.heightmapPixelError = 1f;
			}
		}

		public void RestoreTerrainMaterial()
		{
			if ((bool)Terrain && TerrainMaterialOverridden)
			{
				Terrain.materialTemplate = _originalTerrainMaterial;
				Terrain.heightmapPixelError = _originalTerrainheightmapPixelError;
				Terrain.basemapDistance = _originalBasemapDistance;
				Terrain.drawInstanced = _originalTerrainInstanced;
				TerrainMaterialOverridden = false;
			}
		}

		public void UpdateTerrainMaterial(float worldspaceSeaLevel, float worldspaceMaxTerrainHeight, TerrainTextureSettings terrainTextureSettings)
		{
			if ((bool)TerrainHeatmapMaterial)
			{
				TerrainHeatmapMaterial.SetFloat("_TerrainMinHeight", worldspaceSeaLevel);
				TerrainHeatmapMaterial.SetFloat("_TerrainMaxHeight", worldspaceMaxTerrainHeight);
				TerrainHeatmapMaterial.SetFloat("_MinHeight", 0f);
				TerrainHeatmapMaterial.SetFloat("_MaxHeight", 0f);
				TerrainHeatmapMaterial.SetFloat("_MinSteepness", 0f);
				TerrainHeatmapMaterial.SetFloat("_MaxSteepness", 90f);
				TerrainHeatmapMaterial.SetTexture("_CurveTexture", new Texture2D(1, 1));
				TerrainHeatmapMaterial.SetFloatArray("_HeightCurve", terrainTextureSettings.TextureHeightCurve.GenerateCurveArray(256));
				TerrainHeatmapMaterial.SetFloatArray("_SteepnessCurve", terrainTextureSettings.TextureSteepnessCurve.GenerateCurveArray(256));
				TerrainHeatmapMaterial.SetFloat("_UseNoise", terrainTextureSettings.UseNoise ? 1 : 0);
				TerrainHeatmapMaterial.SetFloat("_InverseNoise", terrainTextureSettings.InverseNoise ? 1 : 0);
				TerrainHeatmapMaterial.SetFloat("_NoiseScale", terrainTextureSettings.NoiseScale);
				TerrainHeatmapMaterial.SetVector("_NoiseOffset", new Vector4(terrainTextureSettings.NoiseOffset.x, 0f, terrainTextureSettings.NoiseOffset.y, 0f));
			}
		}

		public Texture2D GetTerrainPreviewTexture(int textureIndex)
		{
			return null;
		}

		public void RefreshSplatMaps()
		{
			if (!Terrain || !Terrain.terrainData)
			{
				return;
			}
			_splatMapArrayList.Clear();
			_splatMapFormatList.Clear();
			for (int i = 0; i <= Terrain.terrainData.alphamapTextures.Length - 1; i++)
			{
				NativeArray<ARGBBytes> rawTextureData = Terrain.terrainData.alphamapTextures[i].GetRawTextureData<ARGBBytes>();
				_splatMapArrayList.Add(rawTextureData);
				if (Terrain.terrainData.alphamapTextures[i].format == TextureFormat.RGBA32)
				{
					_splatMapFormatList.Add(1);
				}
				else
				{
					_splatMapFormatList.Add(0);
				}
			}
		}

		private bool IsSplatmapArraysValid()
		{
			for (int i = 0; i <= _splatMapArrayList.Count - 1; i++)
			{
				if (!_splatMapArrayList[i].IsCreated)
				{
					return false;
				}
			}
			return true;
		}

		public void VerifySplatmapAccess()
		{
			RefreshSplatMaps();
		}

		public JobHandle ProcessSplatmapRules(List<TerrainTextureRule> terrainTextureRuleList, VegetationInstanceData instanceData, bool include, Rect cellRect, JobHandle dependsOn)
		{
			if (cellRect.Overlaps(_terrainRect))
			{
				if (!IsSplatmapArraysValid())
				{
					return dependsOn;
				}
				int alphamapWidth = Terrain.terrainData.alphamapWidth;
				int alphamapHeight = Terrain.terrainData.alphamapHeight;
				Vector2 vector = new Vector2(Terrain.terrainData.size.x / (float)(alphamapWidth - 1), Terrain.terrainData.size.z / (float)(alphamapHeight - 1));
				for (int i = 0; i <= terrainTextureRuleList.Count - 1; i++)
				{
					int num = terrainTextureRuleList[i].TextureIndex / 4;
					int num2 = terrainTextureRuleList[i].TextureIndex - 4 * num;
					if (num >= _splatMapArrayList.Count)
					{
						continue;
					}
					if (_splatMapFormatList[num] == 1)
					{
						num2--;
						if (num2 == -1)
						{
							num2 = 3;
						}
					}
					dependsOn = new SplatMapRuleJob
					{
						Excluded = instanceData.Excluded.AsDeferredJobArray(),
						TerrainTextureData = instanceData.TerrainTextureData.AsDeferredJobArray(),
						Position = instanceData.Position.AsDeferredJobArray(),
						SplatMapArray = _splatMapArrayList[num],
						MinValue = terrainTextureRuleList[i].MinimumValue,
						MaxValue = terrainTextureRuleList[i].MaximumValue,
						SplatmapIndex = num2,
						Width = alphamapWidth,
						Height = alphamapHeight,
						TerrainPosition = TerrainPosition,
						SplatCellSize = vector,
						Include = include
					}.Schedule(instanceData.Excluded, 32, dependsOn);
				}
				return new SplatMapRuleCompleteJob
				{
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					TerrainTextureData = instanceData.TerrainTextureData.AsDeferredJobArray(),
					Include = include
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}
	}
}

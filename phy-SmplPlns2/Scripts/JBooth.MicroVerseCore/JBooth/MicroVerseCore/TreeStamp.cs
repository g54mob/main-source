using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class TreeStamp : Stamp, ITreeModifier, ISpawner, IModifier, ITextureModifier
	{
		[Serializable]
		public struct Randomization
		{
			public float weight;

			public Vector2 scaleHeightRange;

			public Vector2 scaleWidthRange;

			public float sink;

			public float scaleMultiplierAtBoundaries;

			public Vector2 weightRange;

			public int flags;

			public bool lockScaleWidthHeight
			{
				get
				{
					return (flags & 2) != 0;
				}
				set
				{
					if (value)
					{
						flags |= 2;
					}
					else
					{
						flags &= -3;
					}
				}
			}

			public bool randomRotation
			{
				get
				{
					return (flags & 4) == 0;
				}
				set
				{
					if (!value)
					{
						flags |= 4;
					}
					else
					{
						flags &= -5;
					}
				}
			}

			public bool densityByWeight
			{
				get
				{
					return (flags & 8) == 0;
				}
				set
				{
					if (!value)
					{
						flags |= 8;
					}
					else
					{
						flags &= -9;
					}
				}
			}

			public bool disabled
			{
				get
				{
					return (flags & 0x10) == 0;
				}
				set
				{
					if (!value)
					{
						flags |= 16;
					}
					else
					{
						flags &= -17;
					}
				}
			}

			public bool mapHeightFilterToScale
			{
				get
				{
					return (flags & 0x20) != 0;
				}
				set
				{
					if (value)
					{
						flags |= 32;
					}
					else
					{
						flags &= -33;
					}
				}
			}

			public bool mapWeightToScale
			{
				get
				{
					return (flags & 0x40) != 0;
				}
				set
				{
					if (value)
					{
						flags |= 64;
					}
					else
					{
						flags &= -65;
					}
				}
			}

			public bool randomScale
			{
				get
				{
					return (flags & 0x80) == 0;
				}
				set
				{
					if (!value)
					{
						flags |= 128;
					}
					else
					{
						flags &= -129;
					}
				}
			}
		}

		public int version;

		private static Texture2D randomTexture;

		public List<TreePrototypeSerializable> prototypes = new List<TreePrototypeSerializable>();

		public List<Randomization> randomizations = new List<Randomization>();

		public uint seed;

		public Texture2D poissonDisk;

		[Range(0f, 2f)]
		public float poissonDiskStrength = 1f;

		[Range(0.1f, 20f)]
		public float density = 1f;

		[Tooltip("Write into occlusion system so other things won't spawn on top of us")]
		public bool occludeOthers = true;

		[Tooltip("Read occlusion system so we won't spawn where we're not supposed to")]
		public bool occludedByOthers = true;

		public float minDistanceFromTree;

		public float maxDistanceFromTree;

		public float minDistanceFromObject;

		public float maxDistanceFromObject;

		public float minDistanceFromParent;

		public float maxDistanceFromParent;

		public bool sdfClamp;

		[Tooltip("Minimum height to place tree - this lets you spawn objects on water, for instance")]
		public float minHeight = -99999f;

		[Tooltip("Allows to to raise or lower the terrain around tree objects")]
		[Range(-3f, 3f)]
		public float heightModAmount;

		[Tooltip("Controls the width of the height adjustment")]
		[Range(0.1f, 20f)]
		public float heightModWidth = 5f;

		[Tooltip("Texture to apply")]
		public TerrainLayer layer;

		[Tooltip("Weight of texture to apply")]
		[Range(0f, 1f)]
		public float layerWeight;

		[Tooltip("Controls the width of the texturing")]
		[Range(0.1f, 20f)]
		public float layerWidth = 5f;

		[Tooltip("Applies the slope filter from the stamp to the height/texture mods, so they don't go out over cliffs")]
		public bool applyFilteringToTextureMod;

		public FilterSet filterSet = new FilterSet();

		private Vector4[] textureLayerWeights;

		private Material material;

		private RenderBuffer[] _mrt;

		private Dictionary<Terrain, RenderTexture> sdfs = new Dictionary<Terrain, RenderTexture>();

		private ComputeBuffer randomizationBuffer;

		private static Shader treeStampShader = null;

		private int[] prototypeIndexes;

		private Dictionary<Terrain, RenderTexture> posWeightRTs = new Dictionary<Terrain, RenderTexture>();

		private Dictionary<Terrain, RenderTexture> randomsRTs = new Dictionary<Terrain, RenderTexture>();

		private static int _RandomTex = Shader.PropertyToID("_RandomTex");

		private static int _Disc = Shader.PropertyToID("_Disc");

		private static int _DiscStrength = Shader.PropertyToID("_DiscStrength");

		private static int _Density = Shader.PropertyToID("_Density");

		private static int _InstanceCount = Shader.PropertyToID("_InstanceCount");

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Normalmap = Shader.PropertyToID("_Normalmap");

		private static int _Curvemap = Shader.PropertyToID("_Curvemap");

		private static int _Flowmap = Shader.PropertyToID("_Flowmap");

		private static int _ClearLayer = Shader.PropertyToID("_ClearLayer");

		private static int _ClearMask = Shader.PropertyToID("_ClearMask");

		private static int _MinHeight = Shader.PropertyToID("_MinHeight");

		private static int _NumTreeIndexes = Shader.PropertyToID("_NumTreeIndexes");

		private static int _TotalWeights = Shader.PropertyToID("_TotalWeights");

		private static int _HeightOffset = Shader.PropertyToID("_HeightOffset");

		private static int _PlacementMask = Shader.PropertyToID("_PlacementMask");

		private static int _TerrainPixelCount = Shader.PropertyToID("_TerrainPixelCount");

		private static int _ModWidth = Shader.PropertyToID("_ModWidth");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		private static int _Seed = Shader.PropertyToID("_Seed");

		private static int _TextureLayerWeights = Shader.PropertyToID("_TextureLayerWeights");

		private static int _Randomizations = Shader.PropertyToID("_Randomizations");

		private static int _YCount = Shader.PropertyToID("_YCount");

		private Dictionary<Terrain, int[]> prototypeMappings = new Dictionary<Terrain, int[]>();

		private static int _RealHeight = Shader.PropertyToID("_RealHeight");

		private static int _TreeSDF = Shader.PropertyToID("_TreeSDF");

		private static int _Amount = Shader.PropertyToID("_Amount");

		private static int _Width = Shader.PropertyToID("_Width");

		private static int _Index = Shader.PropertyToID("_Index");

		private Material heightModMat;

		private Material splatModMat;

		public override FilterSet GetFilterSet()
		{
			return filterSet;
		}

		public override void OnEnable()
		{
			base.OnEnable();
			Revision();
		}

		private void Revision()
		{
			if (version == 0)
			{
				version = 1;
				for (int i = 0; i < randomizations.Count; i++)
				{
					Randomization value = randomizations[i];
					value.disabled = false;
					randomizations[i] = value;
				}
			}
		}

		public bool NeedCurvatureMap()
		{
			return filterSet.NeedCurvatureMap();
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
		}

		public override Bounds GetBounds()
		{
			FalloffOverride componentInParent = GetComponentInParent<FalloffOverride>();
			FalloffFilter.FilterType filterType = filterSet.falloffFilter.filterType;
			FalloffFilter falloffFilter = filterSet.falloffFilter;
			if (componentInParent != null && componentInParent.enabled)
			{
				filterType = componentInParent.filter.filterType;
				falloffFilter = componentInParent.filter;
			}
			if (filterType == FalloffFilter.FilterType.SplineArea && falloffFilter.splineArea != null)
			{
				return falloffFilter.splineArea.GetBounds();
			}
			if (filterType == FalloffFilter.FilterType.Global && falloffFilter.paintArea != null && falloffFilter.paintArea.clampOutsideOfBounds)
			{
				return falloffFilter.paintArea.GetBounds();
			}
			if (filterType == FalloffFilter.FilterType.Global)
			{
				return new Bounds(Vector3.zero, new Vector3(99999f, 999999f, 99999f));
			}
			return TerrainUtil.GetBounds(base.transform);
		}

		public bool OccludesOthers()
		{
			return occludeOthers;
		}

		public bool UsesOtherTreeSDF()
		{
			if (!(minDistanceFromTree > 0f))
			{
				return maxDistanceFromTree > 0f;
			}
			return true;
		}

		public bool UsesOtherObjectSDF()
		{
			if (!(minDistanceFromObject > 0f))
			{
				return maxDistanceFromObject > 0f;
			}
			return true;
		}

		public bool NeedSDF()
		{
			if (!(heightModAmount > 0f))
			{
				if (layer != null)
				{
					return layerWeight > 0f;
				}
				return false;
			}
			return true;
		}

		public bool NeedParentSDF()
		{
			if (!(minDistanceFromParent > 0f))
			{
				return maxDistanceFromParent > 0f;
			}
			return true;
		}

		public bool NeedToGenerateSDFForChilden()
		{
			ISpawner component = GetComponent<ISpawner>();
			ISpawner[] componentsInChildren = GetComponentsInChildren<ISpawner>(includeInactive: false);
			foreach (ISpawner spawner in componentsInChildren)
			{
				if (spawner != component && spawner.NeedParentSDF())
				{
					return true;
				}
			}
			return false;
		}

		public void SetSDF(Terrain t, RenderTexture rt)
		{
			if (sdfs.ContainsKey(t))
			{
				Debug.LogError("Stamp " + base.name + " already generated sdf for " + t.name);
			}
			sdfs[t] = rt;
		}

		public RenderTexture GetSDF(Terrain t)
		{
			if (sdfs.ContainsKey(t))
			{
				return sdfs[t];
			}
			return null;
		}

		public void Initialize()
		{
			if (treeStampShader == null)
			{
				treeStampShader = Shader.Find("Hidden/MicroVerse/VegetationFilter");
			}
			prototypeMappings.Clear();
			if (material == null)
			{
				material = new Material(treeStampShader);
			}
			if (_mrt == null)
			{
				_mrt = new RenderBuffer[2];
			}
			if (randomTexture == null)
			{
				randomTexture = new Texture2D(64, 64, TextureFormat.RGBAHalf, mipChain: false, linear: true);
				randomTexture.filterMode = FilterMode.Point;
				NativeArray<half4> rawTextureData = randomTexture.GetRawTextureData<half4>();
				Unity.Mathematics.Random random = new Unity.Mathematics.Random(31u);
				random.InitState(31u);
				for (int i = 0; i < rawTextureData.Length; i++)
				{
					rawTextureData[i] = (half4)random.NextFloat4(0, 1);
				}
				randomTexture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
			NativeArray<Randomization> data = new NativeArray<Randomization>(randomizations.Count, Allocator.Temp);
			data.CopyFrom(randomizations.ToArray());
			randomizationBuffer = new ComputeBuffer(randomizations.Count, UnsafeUtility.SizeOf<Randomization>());
			randomizationBuffer.SetData(data);
			data.Dispose();
			material.SetTexture(_RandomTex, randomTexture);
			material.SetTexture(_Disc, poissonDisk);
			material.SetFloat(_DiscStrength, poissonDiskStrength);
			material.SetFloat(_MinHeight, minHeight);
			material.SetFloat(_NumTreeIndexes, prototypes.Count);
			material.SetFloat(_HeightOffset, heightModAmount);
			material.SetFloat(_ModWidth, Mathf.Max(layerWeight, heightModWidth));
			material.SetFloat(_Seed, seed);
			material.SetBuffer(_Randomizations, randomizationBuffer);
			if (poissonDisk != null)
			{
				poissonDisk.wrapMode = TextureWrapMode.Repeat;
				poissonDisk.filterMode = FilterMode.Point;
			}
			if (prototypes != null && prototypes.Count != 0 && (prototypeIndexes == null || prototypeIndexes.Length != prototypes.Count))
			{
				prototypeIndexes = new int[prototypes.Count];
			}
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
		}

		public void InqTreePrototypes(List<TreePrototypeSerializable> trees)
		{
			trees.AddRange(prototypes);
		}

		public bool NeedTreeClear()
		{
			return false;
		}

		public void ApplyTreeClear(TreeData td)
		{
		}

		public bool NeedDetailClear()
		{
			return false;
		}

		public void ApplyDetailClear(DetailData td)
		{
		}

		public void ApplyTreeStamp(TreeData td, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
			if (!(poissonDisk == null) && prototypes.Count != 0)
			{
				textureLayerWeights = filterSet.GetTextureWeights(od.terrain.terrainData.terrainLayers);
				float num = 0f;
				for (int i = 0; i < prototypes.Count; i++)
				{
					prototypeIndexes[i] = VegetationUtilities.FindTreeIndex(od.terrain, prototypes[i]);
					num += randomizations[i].weight + 1f;
				}
				prototypeMappings.Add(od.terrain, prototypeIndexes);
				keywordBuilder.Clear();
				material.SetFloat(_ClearLayer, td.layerIndex);
				material.SetTexture(_ClearMask, td.treeClearMap);
				material.SetTexture(_Heightmap, td.heightMap);
				material.SetTexture(_Normalmap, td.normalMap);
				material.SetTexture(_Curvemap, td.curveMap);
				material.SetTexture(_Flowmap, td.flowMap);
				material.SetVectorArray(_TextureLayerWeights, textureLayerWeights);
				material.SetFloat(_TotalWeights, num);
				if (occludedByOthers)
				{
					material.SetTexture(_PlacementMask, od.terrainMask);
				}
				else
				{
					material.SetTexture(_PlacementMask, null);
				}
				float ratio = (float)td.heightMap.width / td.terrain.terrainData.size.x;
				FilterSet.PrepareSDFFilter(keywordBuilder, material, base.transform, od, ratio, sdfClamp, minDistanceFromTree, maxDistanceFromTree, minDistanceFromObject, maxDistanceFromObject, minDistanceFromParent, maxDistanceFromParent);
				material.SetInt(_TerrainPixelCount, td.heightMap.width);
				material.SetTexture(_IndexMap, td.dataCache.indexMaps[td.terrain]);
				material.SetTexture(_WeightMap, td.dataCache.weightMaps[td.terrain]);
				keywordBuilder.Add("_RECONSTRUCTNORMAL");
				float terrainScalingFactor = GetTerrainScalingFactor(td.terrain);
				filterSet.PrepareTransform(base.transform, td.terrain, material, keywordBuilder.keywords, terrainScalingFactor);
				keywordBuilder.Assign(material);
				int num2 = Mathf.RoundToInt(512f * density * density * terrainScalingFactor * terrainScalingFactor);
				material.SetFloat(_InstanceCount, num2);
				float num3 = (float)num2 / 512f;
				int num4 = Mathf.FloorToInt(num2 / 512);
				if (num3 != (float)Mathf.FloorToInt(num3))
				{
					num4++;
				}
				material.SetFloat(_YCount, num4);
				RenderTexture renderTexture = new RenderTexture(512, num4, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				renderTexture.name = "TreeStamp::PositonWeightRT";
				RenderTexture renderTexture2 = new RenderTexture(512, num4, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				posWeightRTs[td.terrain] = renderTexture;
				randomsRTs[td.terrain] = renderTexture2;
				_mrt[0] = renderTexture.colorBuffer;
				_mrt[1] = renderTexture2.colorBuffer;
				Graphics.SetRenderTarget(_mrt, renderTexture.depthBuffer);
				Graphics.Blit(poissonDisk, material, 0);
				TreeUtil.ApplyOcclusion(renderTexture, od, occludeOthers, heightModAmount > 0f || (layer != null && layerWeight > 0f));
			}
		}

		public void ProcessTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
			if (poissonDisk == null || prototypes.Count == 0)
			{
				return;
			}
			RenderTexture filteredInstances = posWeightRTs[vd.terrain];
			RenderTexture randomResults = randomsRTs[vd.terrain];
			if (heightModAmount != 0f)
			{
				if (heightModMat == null)
				{
					heightModMat = new Material(Shader.Find("Hidden/MicroVerse/TreeHeightMod"));
				}
				RenderTexture temporary = RenderTexture.GetTemporary(vd.heightMap.descriptor);
				heightModMat.SetFloat(_RealHeight, od.RealHeight);
				heightModMat.SetTexture(_TreeSDF, od.currentTreeSDF);
				heightModMat.SetFloat(_Amount, heightModAmount);
				heightModMat.SetTexture(_PlacementMask, od.terrainMask);
				float num = (float)vd.heightMap.width / vd.terrain.terrainData.size.x;
				heightModMat.SetFloat(_Width, heightModWidth * num);
				Graphics.Blit(vd.heightMap, temporary, heightModMat);
				Graphics.Blit(temporary, vd.heightMap);
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(temporary);
			}
			if (layer != null && layerWeight > 0f)
			{
				if (splatModMat == null)
				{
					splatModMat = new Material(Shader.Find("Hidden/MicroVerse/TreeSplatMod"));
				}
				if (applyFilteringToTextureMod)
				{
					KeywordBuilder keywordBuilder = new KeywordBuilder();
					keywordBuilder.Add("_RECONSTRUCTNORMAL");
					keywordBuilder.Add("_APPLYFILTER");
					filterSet.PrepareTransform(base.transform, od.terrain, splatModMat, keywordBuilder.keywords);
					filterSet.PrepareMaterial(base.transform, splatModMat, keywordBuilder.initialKeywords);
					splatModMat.SetTexture(_Heightmap, vd.heightMap);
					splatModMat.SetTexture(_Normalmap, vd.normalMap);
					splatModMat.SetTexture(_Curvemap, vd.curveMap);
					splatModMat.SetTexture(_Flowmap, vd.flowMap);
					splatModMat.SetVectorArray(_TextureLayerWeights, textureLayerWeights);
					keywordBuilder.Assign(splatModMat);
				}
				RenderTexture renderTexture = vd.dataCache.indexMaps[vd.terrain];
				RenderTexture renderTexture2 = vd.dataCache.weightMaps[vd.terrain];
				RenderTexture temporary2 = RenderTexture.GetTemporary(renderTexture.descriptor);
				RenderTexture temporary3 = RenderTexture.GetTemporary(renderTexture2.descriptor);
				splatModMat.SetTexture(_TreeSDF, od.currentTreeSDF);
				splatModMat.SetTexture(_IndexMap, renderTexture);
				splatModMat.SetTexture(_WeightMap, renderTexture2);
				splatModMat.SetTexture(_PlacementMask, od.terrainMask);
				splatModMat.SetFloat(_Amount, layerWeight);
				float num2 = (float)renderTexture.width / vd.terrain.terrainData.size.x;
				splatModMat.SetFloat(_Width, layerWidth * num2);
				int num3 = TerrainUtil.FindTextureChannelIndex(vd.terrain, layer);
				splatModMat.SetFloat(_Index, num3);
				Graphics.SetRenderTarget(new RenderBuffer[2] { temporary2.colorBuffer, temporary3.colorBuffer }, temporary2.depthBuffer);
				Graphics.Blit(null, splatModMat);
				Graphics.Blit(temporary2, renderTexture);
				Graphics.Blit(temporary3, renderTexture2);
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(temporary2);
				RenderTexture.ReleaseTemporary(temporary3);
			}
			TreeJobHolder treeJobHolder = new TreeJobHolder();
			NativeArray<int> treeIndexes = new NativeArray<int>(prototypeMappings[od.terrain].Length, Allocator.Persistent);
			treeIndexes.CopyFrom(prototypeMappings[od.terrain]);
			treeJobHolder.AddJob(filteredInstances, randomResults, treeIndexes);
			if (jobs.ContainsKey(vd.terrain))
			{
				jobs[vd.terrain].Add(treeJobHolder);
				return;
			}
			jobs.Add(vd.terrain, new List<TreeJobHolder> { treeJobHolder });
		}

		protected override void OnDestroy()
		{
			if (material != null)
			{
				UnityEngine.Object.DestroyImmediate(material);
			}
			if (heightModMat != null)
			{
				UnityEngine.Object.DestroyImmediate(heightModMat);
			}
			if (splatModMat != null)
			{
				UnityEngine.Object.DestroyImmediate(splatModMat);
			}
			base.OnDestroy();
		}

		public void Dispose()
		{
			RenderTexture.active = null;
			foreach (RenderTexture value in sdfs.Values)
			{
				if (value != null)
				{
					RenderTexture.ReleaseTemporary(value);
				}
			}
			randomizationBuffer.Dispose();
			sdfs.Clear();
		}

		private void OnDrawGizmosSelected()
		{
			if (filterSet.falloffFilter.filterType != FalloffFilter.FilterType.Global && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.SplineArea && MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.treeStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}

		public bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od)
		{
			return false;
		}

		public void InqTerrainLayers(Terrain terrain, List<TerrainLayer> prototypes)
		{
			if (layer != null)
			{
				prototypes.Add(layer);
			}
		}
	}
}

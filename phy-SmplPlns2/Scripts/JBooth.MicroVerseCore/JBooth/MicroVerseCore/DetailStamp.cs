using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class DetailStamp : Stamp, IDetailModifier, ISpawner, IModifier
	{
		public DetailPrototypeSerializable prototype = new DetailPrototypeSerializable();

		public DetailPrototypeSettings settings;

		public FilterSet filterSet = new FilterSet();

		private Material material;

		public bool occludedByOthers = true;

		public float minDistanceFromTree;

		public float maxDistanceFromTree;

		public float minDistanceFromObject;

		public float maxDistanceFromObject;

		public float minDistanceFromParent;

		public float maxDistanceFromParent;

		public bool sdfClamp;

		[Tooltip("Weight Range in which details will spawn")]
		public Vector2 weightRange = new Vector2(0f, 999999f);

		private static Shader detailShader = null;

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Normalmap = Shader.PropertyToID("_Normalmap");

		private static int _Curvemap = Shader.PropertyToID("_Curvemap");

		private static int _Flowmap = Shader.PropertyToID("_Flowmap");

		private static int _WeightRange = Shader.PropertyToID("_WeightRange");

		private static int _Density = Shader.PropertyToID("_Density");

		private static int _PlacementMask = Shader.PropertyToID("_PlacementMask");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		private static int _TextureLayerWeights = Shader.PropertyToID("_TextureLayerWeights");

		private static int _ClearLayer = Shader.PropertyToID("_ClearLayer");

		private static int _ClearMask = Shader.PropertyToID("_ClearMask");

		private static int _DensityNoise = Shader.PropertyToID("_DensityNoise");

		public override FilterSet GetFilterSet()
		{
			return filterSet;
		}

		public bool NeedCurvatureMap()
		{
			return filterSet.NeedCurvatureMap();
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
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
			return false;
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
			return false;
		}

		public void SetSDF(Terrain t, RenderTexture rt)
		{
		}

		public RenderTexture GetSDF(Terrain t)
		{
			return null;
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

		public void Initialize()
		{
			if (detailShader == null)
			{
				detailShader = Shader.Find("Hidden/MicroVerse/DetailFilter");
			}
			material = new Material(detailShader);
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
		}

		public void ApplyDetailStamp(DetailData dd, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers, OcclusionData od)
		{
			DetailPrototypeSerializable detailPrototypeSerializable = prototype;
			if (settings != null && settings.prototype != null)
			{
				detailPrototypeSerializable = settings.prototype;
			}
			if (detailPrototypeSerializable.IsValid())
			{
				int key = VegetationUtilities.FindDetailIndex(od.terrain, detailPrototypeSerializable);
				Vector4[] textureWeights = filterSet.GetTextureWeights(od.terrain.terrainData.terrainLayers);
				keywordBuilder.Clear();
				keywordBuilder.Add("_RECONSTRUCTNORMAL");
				material.SetTexture(_ClearMask, dd.clearMap);
				material.SetFloat(_ClearLayer, dd.layerIndex);
				material.SetTexture(_Heightmap, dd.heightMap);
				material.SetTexture(_Normalmap, dd.normalMap);
				material.SetTexture(_Curvemap, dd.curveMap);
				material.SetTexture(_Flowmap, dd.flowMap);
				material.SetVector(_WeightRange, weightRange);
				if (od.terrain.terrainData.detailScatterMode == DetailScatterMode.CoverageMode)
				{
					material.SetVector(_DensityNoise, Vector2.zero);
					material.SetFloat(_Density, 1f);
				}
				else if (detailPrototypeSerializable.density < 1f)
				{
					material.SetFloat(_Density, 1f / 128f);
					material.SetVector(_DensityNoise, new Vector2(1f - Mathf.Pow(detailPrototypeSerializable.density, 4f), 0.25f));
				}
				else
				{
					material.SetFloat(_Density, detailPrototypeSerializable.density / 128f);
					material.SetVector(_DensityNoise, Vector2.zero);
				}
				if (material.GetFloat(_Density) < 1f)
				{
					keywordBuilder.Add("_DENSITYNOISENEEDED");
				}
				if (occludedByOthers)
				{
					material.SetTexture(_PlacementMask, od.terrainMask);
				}
				else
				{
					material.SetTexture(_PlacementMask, null);
				}
				float ratio = (float)dd.heightMap.width / dd.terrain.terrainData.size.x;
				FilterSet.PrepareSDFFilter(keywordBuilder, material, base.transform, od, ratio, sdfClamp, minDistanceFromTree, maxDistanceFromTree, minDistanceFromObject, maxDistanceFromObject, minDistanceFromParent, maxDistanceFromParent);
				material.SetTexture(_IndexMap, dd.dataCache.indexMaps[dd.terrain]);
				material.SetTexture(_WeightMap, dd.dataCache.weightMaps[dd.terrain]);
				material.SetVectorArray(_TextureLayerWeights, textureWeights);
				filterSet.PrepareTransform(base.transform, dd.terrain, material, keywordBuilder.keywords, GetTerrainScalingFactor(dd.terrain));
				keywordBuilder.Assign(material);
				RenderTexture temporary = RenderTexture.GetTemporary(dd.terrain.terrainData.detailWidth, dd.terrain.terrainData.detailHeight, 0, GraphicsFormat.R8_UNorm);
				temporary.name = "DetailStamp::rt";
				Graphics.Blit(null, temporary, material);
				if (!resultBuffers.ContainsKey(dd.terrain))
				{
					resultBuffers.Add(dd.terrain, new Dictionary<int, List<RenderTexture>>());
				}
				Dictionary<int, List<RenderTexture>> dictionary = resultBuffers[dd.terrain];
				if (dictionary.ContainsKey(key))
				{
					dictionary[key].Add(temporary);
					return;
				}
				dictionary.Add(key, new List<RenderTexture>(1) { temporary });
			}
		}

		protected override void OnDestroy()
		{
			if (material != null)
			{
				Object.DestroyImmediate(material);
			}
			base.OnDestroy();
		}

		public void Dispose()
		{
		}

		private void OnDrawGizmosSelected()
		{
			if (filterSet.falloffFilter.filterType != FalloffFilter.FilterType.Global && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.SplineArea && MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.detailStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}

		public void InqDetailPrototypes(List<DetailPrototypeSerializable> prototypes)
		{
			if (settings != null && settings.prototype != null)
			{
				prototypes.Add(settings.prototype);
			}
			else
			{
				prototypes.Add(prototype);
			}
		}

		public bool NeedDetailClear()
		{
			return false;
		}

		public void ApplyDetailClear(DetailData td)
		{
		}
	}
}

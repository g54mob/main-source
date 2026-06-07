using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteInEditMode]
	public class OcclusionStamp : Stamp, IHeightModifier, IModifier, ITextureModifier, ITreeModifier, ISpawner, IDetailModifier
	{
		[Tooltip("How much to prevent future height stamps in the hierarchy from affecting this area")]
		[Range(0f, 1f)]
		public float occludeHeightWeight;

		[Tooltip("How much to prevent future texture stamps in the hierarchy from affecting this area")]
		[Range(0f, 1f)]
		public float occludeTextureWeight;

		[Tooltip("How much to prevent future tree stamps in the hierarchy from affecting this area")]
		[Range(0f, 1f)]
		public float occludeTreeWeight;

		[Tooltip("How much to prevent future detail stamps in the hierarchy from affecting this area")]
		[Range(0f, 1f)]
		public float occludeDetailWeight;

		[Tooltip("How much to prevent future objects from affecting this area")]
		[Range(0f, 1f)]
		public float occludeObjectWeight;

		public FilterSet filterSet = new FilterSet();

		private Material material;

		private static Shader occlusionShader = null;

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Normalmap = Shader.PropertyToID("_Normalmap");

		private static int _Curvemap = Shader.PropertyToID("_Curvemap");

		private static int _Flowmap = Shader.PropertyToID("_Flowmap");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		public void Initialize()
		{
			if (occlusionShader == null)
			{
				occlusionShader = Shader.Find("Hidden/MicroVerse/OccludeLayer");
			}
			if (material == null)
			{
				material = new Material(occlusionShader);
			}
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
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

		public bool UsesOtherTreeSDF()
		{
			return false;
		}

		public bool UsesOtherObjectSDF()
		{
			return false;
		}

		public override FilterSet GetFilterSet()
		{
			return filterSet;
		}

		private void PrepareMaterial(Material material, OcclusionData od, List<string> keywords)
		{
			material.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(od.terrain, base.transform));
			material.SetVector("_RealSize", TerrainUtil.ComputeTerrainSize(od.terrain));
			keywordBuilder.Add("_RECONSTRUCTNORMAL");
			filterSet.PrepareTransform(base.transform, od.terrain, material, keywords, GetTerrainScalingFactor(od.terrain));
		}

		private void Render(OcclusionData od)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(od.terrainMask.descriptor);
			temporary.name = "Occlusion::Render::Temp";
			material.SetTexture("_MainTex", od.terrainMask);
			Graphics.Blit(od.terrainMask, temporary, material);
			RenderTexture.ReleaseTemporary(od.terrainMask);
			od.terrainMask = temporary;
		}

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			if (occludeHeightWeight <= 0f)
			{
				return false;
			}
			keywordBuilder.Clear();
			PrepareMaterial(material, od, keywordBuilder.keywords);
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.keywords);
			keywordBuilder.Assign(material);
			material.SetVector("_Mask", new Vector4(occludeHeightWeight, 0f, 0f, 0f));
			Render(od);
			return false;
		}

		public bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od)
		{
			if (occludeTextureWeight <= 0f)
			{
				return false;
			}
			keywordBuilder.Clear();
			keywordBuilder.Add("_ISSPLAT");
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.keywords);
			PrepareMaterial(material, od, keywordBuilder.keywords);
			keywordBuilder.Assign(material);
			material.SetVector("_Mask", new Vector4(0f, occludeTextureWeight, 0f, 0f));
			material.SetTexture("_MainTex", weightSrc);
			Graphics.Blit(weightSrc, weightDest, material);
			Graphics.Blit(indexSrc, indexDest);
			return true;
		}

		public bool OccludesOthers()
		{
			return true;
		}

		public bool NeedSDF()
		{
			return false;
		}

		public void ApplyTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
			if (!(occludeTreeWeight <= 0f))
			{
				keywordBuilder.Clear();
				PrepareMaterial(material, od, keywordBuilder.keywords);
				filterSet.PrepareMaterial(base.transform, material, keywordBuilder.keywords);
				Vector4[] textureWeights = filterSet.GetTextureWeights(vd.terrain.terrainData.terrainLayers);
				material.SetVectorArray("_TextureLayerWeights", textureWeights);
				material.SetTexture(_Heightmap, vd.heightMap);
				material.SetTexture(_Normalmap, vd.normalMap);
				material.SetTexture(_Curvemap, vd.curveMap);
				material.SetTexture(_Flowmap, vd.flowMap);
				material.SetTexture(_IndexMap, vd.dataCache.indexMaps[vd.terrain]);
				material.SetTexture(_WeightMap, vd.dataCache.weightMaps[vd.terrain]);
				keywordBuilder.Assign(material);
				keywordBuilder.Assign(material);
				material.SetVector("_Mask", new Vector4(0f, 0f, occludeTreeWeight, 0f));
				Render(od);
			}
		}

		public void ProcessTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
		}

		public bool NeedParentSDF()
		{
			return false;
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

		public void ApplyDetailStamp(DetailData dd, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers, OcclusionData od)
		{
			if (!(occludeDetailWeight <= 0f))
			{
				keywordBuilder.Clear();
				PrepareMaterial(material, od, keywordBuilder.keywords);
				filterSet.PrepareMaterial(base.transform, material, keywordBuilder.keywords);
				keywordBuilder.Assign(material);
				Vector4[] textureWeights = filterSet.GetTextureWeights(dd.terrain.terrainData.terrainLayers);
				material.SetVectorArray("_TextureLayerWeights", textureWeights);
				material.SetTexture(_Heightmap, dd.heightMap);
				material.SetTexture(_Normalmap, dd.normalMap);
				material.SetTexture(_Curvemap, dd.curveMap);
				material.SetTexture(_Flowmap, dd.flowMap);
				material.SetTexture(_IndexMap, dd.dataCache.indexMaps[dd.terrain]);
				material.SetTexture(_WeightMap, dd.dataCache.weightMaps[dd.terrain]);
				material.SetVector("_Mask", new Vector4(0f, 0f, 0f, occludeDetailWeight));
				Render(od);
			}
		}

		public void InqTreePrototypes(List<TreePrototypeSerializable> prototypes)
		{
		}

		public void InqDetailPrototypes(List<DetailPrototypeSerializable> prototypes)
		{
		}

		public void InqTerrainLayers(Terrain terrain, List<TerrainLayer> prototypes)
		{
		}

		public bool NeedCurvatureMap()
		{
			return filterSet.NeedCurvatureMap();
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
		}

		public void Dispose()
		{
		}

		protected override void OnDestroy()
		{
			if (material != null)
			{
				Object.DestroyImmediate(material);
			}
			base.OnDestroy();
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

		private void OnDrawGizmosSelected()
		{
			if (MicroVerse.instance != null && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.Global && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.SplineArea)
			{
				Gizmos.color = MicroVerse.instance.options.colors.occluderStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}
	}
}

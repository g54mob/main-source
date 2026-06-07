using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class ClearStamp : Stamp, ITreeModifier, ISpawner, IModifier, IDetailModifier
	{
		public bool clearTrees = true;

		public bool clearDetails = true;

		public FilterSet filterSet = new FilterSet();

		private Material material;

		private static Shader clearShader = null;

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Normalmap = Shader.PropertyToID("_Normalmap");

		private static int _Curvemap = Shader.PropertyToID("_Curvemap");

		private static int _Flowmap = Shader.PropertyToID("_Flowmap");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		public bool NeedCurvatureMap()
		{
			return filterSet.NeedCurvatureMap();
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
		}

		public bool NeedTreeClear()
		{
			return clearTrees;
		}

		public bool NeedDetailClear()
		{
			return clearDetails;
		}

		public override FilterSet GetFilterSet()
		{
			return filterSet;
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
			if (filterType == FalloffFilter.FilterType.SplineArea && filterSet.falloffFilter.splineArea != null)
			{
				return filterSet.falloffFilter.splineArea.GetBounds();
			}
			if (filterType == FalloffFilter.FilterType.Global && falloffFilter != null && falloffFilter.paintArea != null && falloffFilter.paintArea.clampOutsideOfBounds)
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
			return false;
		}

		public bool NeedSDF()
		{
			return false;
		}

		public bool UsesOtherTreeSDF()
		{
			return false;
		}

		public bool UsesOtherObjectSDF()
		{
			return false;
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

		public void Initialize()
		{
			if (clearShader == null)
			{
				clearShader = Shader.Find("Hidden/MicroVerse/ClearFilter");
			}
			if (material == null)
			{
				material = new Material(clearShader);
			}
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
		}

		public void InqTreePrototypes(List<TreePrototypeSerializable> trees)
		{
		}

		public void ApplyTreeClear(TreeData td)
		{
			if (clearTrees)
			{
				keywordBuilder.Clear();
				keywordBuilder.Add("_RECONSTRUCTNORMAL");
				Vector4[] textureWeights = filterSet.GetTextureWeights(td.terrain.terrainData.terrainLayers);
				material.SetVectorArray("_TextureLayerWeights", textureWeights);
				material.SetTexture(_Heightmap, td.heightMap);
				material.SetTexture(_Normalmap, td.normalMap);
				material.SetTexture(_Curvemap, td.curveMap);
				material.SetTexture(_Flowmap, td.flowMap);
				filterSet.PrepareTransform(base.transform, td.terrain, material, keywordBuilder.keywords, GetTerrainScalingFactor(td.terrain));
				keywordBuilder.Assign(material);
				RenderTexture temporary = RenderTexture.GetTemporary(td.treeClearMap.descriptor);
				material.SetFloat("_LayerIndex", td.layerIndex);
				material.SetTexture(_IndexMap, td.dataCache.indexMaps[td.terrain]);
				material.SetTexture(_WeightMap, td.dataCache.weightMaps[td.terrain]);
				temporary.name = "TreeClear";
				Graphics.Blit(td.treeClearMap, temporary, material);
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(td.treeClearMap);
				td.treeClearMap = temporary;
				td.layerIndex++;
			}
		}

		public void ApplyDetailClear(DetailData dd)
		{
			if (clearDetails)
			{
				keywordBuilder.Clear();
				keywordBuilder.Add("_RECONSTRUCTNORMAL");
				Vector4[] textureWeights = filterSet.GetTextureWeights(dd.terrain.terrainData.terrainLayers);
				material.SetVectorArray("_TextureLayerWeights", textureWeights);
				material.SetTexture(_Heightmap, dd.heightMap);
				material.SetTexture(_Normalmap, dd.normalMap);
				material.SetTexture(_Curvemap, dd.curveMap);
				material.SetTexture(_Flowmap, dd.flowMap);
				filterSet.PrepareTransform(base.transform, dd.terrain, material, keywordBuilder.keywords, GetTerrainScalingFactor(dd.terrain));
				keywordBuilder.Assign(material);
				RenderTexture temporary = RenderTexture.GetTemporary(dd.clearMap.descriptor);
				material.SetFloat("_LayerIndex", dd.layerIndex);
				material.SetTexture(_IndexMap, dd.dataCache.indexMaps[dd.terrain]);
				material.SetTexture(_WeightMap, dd.dataCache.weightMaps[dd.terrain]);
				temporary.name = "DetailClear";
				Graphics.Blit(dd.clearMap, temporary, material);
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(dd.clearMap);
				dd.clearMap = temporary;
				dd.layerIndex++;
			}
		}

		public void ApplyTreeStamp(TreeData td, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
			if (clearTrees)
			{
				td.layerIndex++;
			}
		}

		public void ProcessTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
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

		private void OnDrawGizmosSelected()
		{
			if (filterSet.falloffFilter.filterType != FalloffFilter.FilterType.Global && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.SplineArea && MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.treeStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}

		public void ApplyDetailStamp(DetailData dd, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers, OcclusionData od)
		{
			if (clearDetails)
			{
				dd.layerIndex++;
			}
		}

		public void InqDetailPrototypes(List<DetailPrototypeSerializable> prototypes)
		{
		}
	}
}

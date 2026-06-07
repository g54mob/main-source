using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class HoleStamp : Stamp, IHoleModifier, IModifier
	{
		public FilterSet filterSet = new FilterSet();

		private static Shader holeShader;

		private Material material;

		public override FilterSet GetFilterSet()
		{
			return filterSet;
		}

		public void Initialize()
		{
			if (holeShader == null)
			{
				holeShader = Shader.Find("Hidden/MicroVerse/HoleStamp");
			}
			if (material == null)
			{
				material = new Material(holeShader);
			}
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
		}

		public bool IsValidHoleStamp()
		{
			return true;
		}

		public void ApplyHoleStamp(RenderTexture src, RenderTexture dest, HoleData md, OcclusionData od)
		{
			Vector4[] textureWeights = filterSet.GetTextureWeights(md.terrain.terrainData.terrainLayers);
			keywordBuilder.Clear();
			keywordBuilder.Add("_RECONSTRUCTNORMAL");
			material.SetTexture("_Heightmap", md.heightMap);
			material.SetTexture("_Normalmap", md.normalMap);
			material.SetTexture("_Curvemap", md.curveMap);
			material.SetTexture("_Flowmap", md.flowMap);
			material.SetTexture("_IndexMap", md.indexMap);
			material.SetTexture("_WeightMap", md.weightMap);
			material.SetVectorArray("_TextureLayerWeights", textureWeights);
			filterSet.PrepareTransform(base.transform, md.terrain, material, keywordBuilder.keywords, GetTerrainScalingFactor(md.terrain));
			keywordBuilder.Assign(material);
			Graphics.Blit(src, dest, material);
		}

		public void Dispose()
		{
			Object.DestroyImmediate(material);
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
			if (filterType == FalloffFilter.FilterType.Global)
			{
				return new Bounds(Vector3.zero, new Vector3(99999f, 999999f, 99999f));
			}
			return TerrainUtil.GetBounds(base.transform);
		}

		private void OnDrawGizmosSelected()
		{
			if (MicroVerse.instance != null)
			{
				Gizmos.color = Color.grey;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}

		public bool NeedCurvatureMap()
		{
			return filterSet.curvatureFilter.enabled;
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
		}
	}
}

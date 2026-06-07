using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class TextureStamp : Stamp, ITextureModifier, IModifier
	{
		public TerrainLayer layer;

		public FilterSet filterSet = new FilterSet();

		[Tooltip("When true, we ignore occlusion stamps")]
		public bool ignoreOcclusion;

		private Material material;

		private RenderBuffer[] _mrt;

		private static Shader splatFilterShader = null;

		private int channelIndex = -1;

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Normalmap = Shader.PropertyToID("_Normalmap");

		private static int _Curvemap = Shader.PropertyToID("_Curvemap");

		private static int _Flowmap = Shader.PropertyToID("_Flowmap");

		private static int _PlacementMask = Shader.PropertyToID("_PlacementMask");

		private static int _Channel = Shader.PropertyToID("_Channel");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		public override FilterSet GetFilterSet()
		{
			return filterSet;
		}

		public void Initialize()
		{
			if (splatFilterShader == null)
			{
				splatFilterShader = Shader.Find("Hidden/MicroVerse/SplatFilter");
			}
			if (material == null)
			{
				material = new Material(splatFilterShader);
			}
			_mrt = new RenderBuffer[2];
			keywordBuilder.ClearInitial();
			filterSet.PrepareMaterial(base.transform, material, keywordBuilder.initialKeywords);
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

		public void Dispose()
		{
			_mrt = null;
		}

		protected override void OnDestroy()
		{
			Object.DestroyImmediate(material);
		}

		public bool NeedCurvatureMap()
		{
			return filterSet.NeedCurvatureMap();
		}

		public bool NeedFlowMap()
		{
			return filterSet.NeedFlowMap();
		}

		public bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od)
		{
			if (layer == null)
			{
				return false;
			}
			channelIndex = TerrainUtil.FindTextureChannelIndex(od.terrain, layer);
			if (channelIndex == -1)
			{
				return false;
			}
			keywordBuilder.Clear();
			material.SetTexture(_Heightmap, splatmapData.heightMap);
			material.SetTexture(_Normalmap, splatmapData.normalMap);
			material.SetTexture(_Curvemap, splatmapData.curveMap);
			material.SetTexture(_Flowmap, splatmapData.flowMap);
			if (!ignoreOcclusion)
			{
				material.SetTexture(_PlacementMask, od.terrainMask);
			}
			else
			{
				material.SetTexture(_PlacementMask, null);
			}
			material.SetVector("_AlphaMapSize", new Vector2(indexSrc.width, indexSrc.width));
			filterSet.PrepareTransform(base.transform, splatmapData.terrain, material, keywordBuilder.keywords);
			material.SetFloat(_Channel, channelIndex);
			material.SetTexture(_WeightMap, weightSrc);
			material.SetTexture(_IndexMap, indexSrc);
			keywordBuilder.Assign(material);
			_mrt[0] = indexDest.colorBuffer;
			_mrt[1] = weightDest.colorBuffer;
			Graphics.SetRenderTarget(_mrt, indexDest.depthBuffer);
			Graphics.Blit(null, material, 0);
			return true;
		}

		private void OnDrawGizmosSelected()
		{
			if (filterSet.falloffFilter.filterType != FalloffFilter.FilterType.Global && filterSet.falloffFilter.filterType != FalloffFilter.FilterType.SplineArea && MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.textureStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}

		void ITextureModifier.InqTerrainLayers(Terrain terrain, List<TerrainLayer> layers)
		{
			layers.Add(layer);
		}
	}
}

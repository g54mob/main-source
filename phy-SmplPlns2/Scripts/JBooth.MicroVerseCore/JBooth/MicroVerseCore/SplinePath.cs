using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace JBooth.MicroVerseCore
{
	public class SplinePath : Stamp, IHeightModifier, IModifier, ITextureModifier
	{
		public enum CombineMode
		{
			Override = 0,
			Max = 1,
			Min = 2,
			Blend = 9
		}

		public enum SDFRes
		{
			k256 = 0x100,
			k512 = 0x200,
			k1024 = 0x400,
			k2048 = 0x800
		}

		public enum SearchQuality
		{
			VeryLow = 0x40,
			Low = 0x80,
			Medium = 0x100,
			High = 0x200,
			VeryHigh = 0x400,
			ExtremelyHigh = 0x800
		}

		[Serializable]
		public class SplineWidthData
		{
			public SplineData<float> widthData = new SplineData<float>();
		}

		public CombineMode heightBlendMode;

		[HideInInspector]
		public SplineRenderer.RenderDesc[] multiSpline;

		public SplineContainer spline;

		[Tooltip("When true, a closed spline is treated as an area for the effect instead of following the path")]
		public Noise positionNoise = new Noise();

		public Noise widthNoise = new Noise();

		[Tooltip("Blend between existing height map and new one")]
		[Range(0f, 1f)]
		public float blend = 1f;

		public bool treatAsSplineArea;

		[Tooltip("Resolution of the internal SDF used for the spline. Higher makes edits take longer")]
		public SDFRes sdfRes = SDFRes.k512;

		[Tooltip("Higher values will spend more time finding the closest point on the spline, improving quality but increasing update times")]
		public SearchQuality searchQuality = SearchQuality.Medium;

		[Tooltip("Should the heightmap be adjusted to match the spline")]
		public bool modifyHeightMap = true;

		[Tooltip("Width of the area")]
		public float width = 1f;

		[Tooltip("How many units should it be before the effect is gone")]
		public float smoothness = 2f;

		[Tooltip("Positive values push the terrain down, negative up")]
		public float trench;

		public AnimationCurve trenchCurve = AnimationCurve.Constant(0f, 1f, 0f);

		public bool useTrenchCurve;

		public Noise heightNoise = new Noise();

		public Easing embankmentEasing = new Easing();

		public Noise embankmentNoise = new Noise();

		public bool useTextureCurve;

		public bool useDetailCurve;

		public bool useTreeCurve;

		public AnimationCurve textureCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		public AnimationCurve treeCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		public AnimationCurve detailCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		[Tooltip("Allows you to texture the area of the spline with a terrain layer")]
		public bool modifySplatMap = true;

		public TerrainLayer layer;

		[Tooltip("Width of texturing effect")]
		[Range(0f, 1f)]
		public float splatWeight = 1f;

		public float splatWidth = 1f;

		[Tooltip("How many units should it be before the effect is gone")]
		public float splatSmoothness = 2f;

		public Noise splatNoise = new Noise();

		[Tooltip("Texture the area of the spline's falloff with a separate texture")]
		public TerrainLayer embankmentLayer;

		[Tooltip("When true, tree's will not appear on the path")]
		public bool clearTrees = true;

		[Tooltip("Width of tree clearing effect")]
		public float treeWidth = 1f;

		[Tooltip("Falloff of tree clearing effect")]
		public float treeSmoothness = 3f;

		[Tooltip("When true, detail objects will not appear on the path")]
		public bool clearDetails = true;

		[Tooltip("Width of detail clearing effect")]
		public float detailWidth = 1f;

		[Tooltip("falloff of detail clearing effect")]
		public float detailSmoothness = 3f;

		[Tooltip("When true, objects will not appear on the path")]
		public bool clearObjects;

		[Tooltip("Width of detail clearing effect")]
		public float objectWidth = 1f;

		[Tooltip("falloff of detail clearing effect")]
		public float objectSmoothness = 3f;

		[Tooltip("Will prevent future things from modifying heights")]
		public bool occludeHeightMod;

		[Tooltip("Width of detail clearing effect")]
		public float occludeHeightWidth = 1f;

		[Tooltip("falloff of detail clearing effect")]
		public float occludeHeightSmoothness = 3f;

		[Tooltip("Will prevent future things from modifying splats")]
		public bool occludeTextureMod;

		[Tooltip("Width of detail clearing effect")]
		public float occludeTextureWidth = 1f;

		[Tooltip("falloff of detail clearing effect")]
		public float occludeTextureSmoothness = 3f;

		[Tooltip("Curve to use when interpolating the width of the spline")]
		public Easing splineWidthEasing = new Easing();

		private static Material heightMat;

		private static Material splatMat;

		public List<SplineWidthData> splineWidths = new List<SplineWidthData>();

		private RenderBuffer[] multipleRenderBuffers;

		private Dictionary<Terrain, SplineRenderer> splineRenderers = new Dictionary<Terrain, SplineRenderer>();

		private int mainChannelIndex = -1;

		private int embankmentChannelIndex;

		private static int _SplineSDF = Shader.PropertyToID("_SplineSDF");

		private static int _TerrainHeight = Shader.PropertyToID("_TerrainHeight");

		private static int _TreeWidth = Shader.PropertyToID("_TreeWidth");

		private static int _Channel = Shader.PropertyToID("_Channel");

		private static int _TreeSmoothness = Shader.PropertyToID("_TreeSmoothness");

		private static int _DetailWidth = Shader.PropertyToID("_DetailWidth");

		private static int _DetailSmoothness = Shader.PropertyToID("_DetailSmoothness");

		private static int _SplatWidth = Shader.PropertyToID("_SplatWidth");

		private static int _SplatSmoothness = Shader.PropertyToID("_SplatSmoothness");

		private static int _WeightMap = Shader.PropertyToID("_WeightMap");

		private static int _IndexMap = Shader.PropertyToID("_IndexMap");

		private static int _AlphaMapSize = Shader.PropertyToID("_AlphaMapSize");

		private static int _SplatWeight = Shader.PropertyToID("_SplatWeight");

		private static int _HeightMapSize = Shader.PropertyToID("_HeightMapSize");

		private static int _Blend = Shader.PropertyToID("_Blend");

		private static Shader sdfToMaskShader = null;

		private static Material sdfToMaskMat = null;

		private Texture2D cachedSplineTextureWeight;

		private Texture2D cachedSplineTreeWeight;

		private Texture2D cachedSplineDetailWeight;

		private Texture2D cachedSplineTrenchWeight;

		private static int _NoiseUV = Shader.PropertyToID("_NoiseUV");

		private static int _Width = Shader.PropertyToID("_Width");

		private static int _Smoothness = Shader.PropertyToID("_Smoothness");

		private static int _RealHeight = Shader.PropertyToID("_RealHeight");

		private static int _Trench = Shader.PropertyToID("_Trench");

		private static int _TrenchCurve = Shader.PropertyToID("_TrenchCurve");

		private static int _CombineMode = Shader.PropertyToID("_CombineMode");

		private static int _CombineBlend = Shader.PropertyToID("_CombineBlend");

		private static int _EmbankmentChannel = Shader.PropertyToID("_EmbankmentChannel");

		private static int _HeightWidth = Shader.PropertyToID("_HeightWidth");

		private static int _HeightSmoothness = Shader.PropertyToID("_HeightSmoothness");

		private static int _NoiseParams = Shader.PropertyToID("_NoiseParams");

		private static int _NoiseParams2 = Shader.PropertyToID("_NoiseParams2");

		private static int _SplatNoiseChannel = Shader.PropertyToID("_SplatNoiseChannel");

		private static int _SplatNoiseTexture = Shader.PropertyToID("_SplatNoiseTexture");

		private Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

		private float ComputeMaxSDF()
		{
			float num = 0f;
			if (modifyHeightMap)
			{
				num = width + smoothness;
			}
			if (modifySplatMap)
			{
				num = Mathf.Max(num, splatWidth + splatSmoothness);
			}
			if (clearTrees)
			{
				num = Mathf.Max(num, treeWidth + treeSmoothness);
			}
			if (clearDetails)
			{
				num = Mathf.Max(num, detailWidth + detailSmoothness);
			}
			if (occludeHeightMod)
			{
				num = Mathf.Max(num, occludeHeightSmoothness + occludeHeightWidth);
			}
			if (occludeTextureMod)
			{
				num = Mathf.Max(num, occludeTextureWidth + occludeTextureSmoothness);
			}
			if (splineWidths != null)
			{
				float num2 = 0f;
				foreach (SplineWidthData splineWidth in splineWidths)
				{
					foreach (DataPoint<float> widthDatum in splineWidth.widthData)
					{
						if (widthDatum.Value > num2)
						{
							num2 = widthDatum.Value;
						}
					}
				}
				num += num2;
			}
			return num + 3f;
		}

		public bool NeedCurvatureMap()
		{
			return false;
		}

		public bool NeedFlowMap()
		{
			return false;
		}

		public override void OnEnable()
		{
			if (spline == null)
			{
				spline = GetComponent<SplineContainer>();
			}
			base.OnEnable();
		}

		public void ClearSplineRenders(Bounds? bounds = null)
		{
			if (!bounds.HasValue)
			{
				foreach (SplineRenderer value2 in splineRenderers.Values)
				{
					value2.Dispose();
				}
				splineRenderers.Clear();
			}
			else
			{
				Bounds value = bounds.Value;
				value.max = new Vector3(value.max.x, 100000f, value.max.z);
				value.min = new Vector3(value.min.x, -100000f, value.min.z);
				value.Expand(ComputeMaxSDF());
				List<Terrain> list = new List<Terrain>();
				foreach (Terrain key in splineRenderers.Keys)
				{
					if (TerrainUtil.ComputeTerrainBounds(key).Intersects(value))
					{
						list.Add(key);
					}
				}
				foreach (Terrain item in list)
				{
					splineRenderers[item].Dispose();
					splineRenderers.Remove(item);
				}
			}
			ClearCachedBounds();
		}

		private SplineRenderer GetSplineRenderer(Terrain terrain)
		{
			if (splineRenderers.ContainsKey(terrain))
			{
				SplineRenderer splineRenderer = splineRenderers[terrain];
				float num = ComputeMaxSDF();
				if (splineRenderer.lastMaxSDF < num)
				{
					if (multiSpline != null)
					{
						splineRenderer.Render(multiSpline, terrain, (int)sdfRes, num, (int)searchQuality);
					}
					else if (spline != null)
					{
						splineRenderer.Render(spline, terrain, positionNoise, widthNoise, splineWidths, splineWidthEasing, (int)sdfRes, num, (int)searchQuality);
					}
				}
				return splineRenderer;
			}
			if (TerrainUtil.ComputeTerrainBounds(terrain).Intersects(GetBounds()))
			{
				SplineRenderer splineRenderer2 = new SplineRenderer();
				bounds = new Bounds(Vector3.zero, Vector3.zero);
				if (multiSpline != null)
				{
					splineRenderer2.Render(multiSpline, terrain, (int)sdfRes, ComputeMaxSDF(), (int)searchQuality);
				}
				else if (spline != null)
				{
					splineRenderer2.Render(spline, terrain, positionNoise, widthNoise, splineWidths, splineWidthEasing, (int)sdfRes, ComputeMaxSDF(), (int)searchQuality);
				}
				splineRenderers.Add(terrain, splineRenderer2);
				return splineRenderer2;
			}
			return null;
		}

		public void UpdateSplineSDFs()
		{
			ClearSplineRenders();
			if (!(MicroVerse.instance == null))
			{
				MicroVerse.instance.SyncTerrainList();
				Terrain[] terrains = MicroVerse.instance.terrains;
				foreach (Terrain terrain in terrains)
				{
					GetSplineRenderer(terrain);
				}
			}
		}

		public void Initialize()
		{
			if (heightMat == null)
			{
				heightMat = new Material(Shader.Find("Hidden/MicroVerse/SplinePathHeight"));
			}
			if (splatMat == null)
			{
				splatMat = new Material(Shader.Find("Hidden/MicroVerse/SplinePathTexture"));
			}
			if (multipleRenderBuffers == null)
			{
				multipleRenderBuffers = new RenderBuffer[2];
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ClearSplineRenders();
		}

		protected override void OnDestroy()
		{
			if (heightMat != null)
			{
				UnityEngine.Object.DestroyImmediate(heightMat);
			}
			if (splatMat != null)
			{
				UnityEngine.Object.DestroyImmediate(splatMat);
			}
			if (sdfToMaskMat != null)
			{
				UnityEngine.Object.DestroyImmediate(sdfToMaskMat);
			}
			ClearSplineRenders();
			base.OnDestroy();
		}

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			bool result = false;
			keywordBuilder.Clear();
			SplineRenderer splineRenderer = GetSplineRenderer(od.terrain);
			if (splineRenderer != null)
			{
				if (modifyHeightMap)
				{
					PrepareMaterial(heightMat, heightmapData, keywordBuilder.keywords);
					heightMat.SetTexture(_SplineSDF, splineRenderer.splineSDF);
					heightMat.SetFloat(_TerrainHeight, od.terrain.transform.position.y);
					heightMat.SetFloat(_HeightMapSize, source.width);
					keywordBuilder.Assign(heightMat);
					Graphics.Blit(source, dest, heightMat);
					heightMat.SetFloat(_Blend, blend);
					result = true;
				}
				if (clearTrees || clearDetails || occludeHeightMod || occludeTextureMod)
				{
					if (sdfToMaskShader == null)
					{
						sdfToMaskShader = Shader.Find("Hidden/MicroVerse/SDFToMask");
					}
					if (sdfToMaskMat == null)
					{
						sdfToMaskMat = new Material(sdfToMaskShader);
					}
					sdfToMaskMat.DisableKeyword("_TREATASAREA");
					if (treatAsSplineArea)
					{
						sdfToMaskMat.EnableKeyword("_TREATASAREA");
					}
					sdfToMaskMat.SetFloat(_HeightWidth, occludeHeightMod ? occludeHeightWidth : (-1f));
					sdfToMaskMat.SetFloat(_HeightSmoothness, occludeHeightSmoothness);
					sdfToMaskMat.SetFloat(_SplatWidth, occludeTextureMod ? occludeTextureWidth : (-1f));
					sdfToMaskMat.SetFloat(_SplatSmoothness, occludeTextureSmoothness);
					sdfToMaskMat.SetFloat(_TreeWidth, clearTrees ? treeWidth : (-1f));
					sdfToMaskMat.SetFloat(_TreeSmoothness, treeSmoothness);
					sdfToMaskMat.SetFloat(_DetailWidth, clearDetails ? detailWidth : (-1f));
					sdfToMaskMat.SetFloat(_DetailSmoothness, detailSmoothness);
					sdfToMaskMat.SetTexture(_SplineSDF, splineRenderer.splineSDF);
					sdfToMaskMat.DisableKeyword("_SPLINECURVETREEWEIGHT");
					sdfToMaskMat.DisableKeyword("_SPLINECURVEDETAILWEIGHT");
					if (useTreeCurve)
					{
						sdfToMaskMat.EnableKeyword("_SPLINECURVETREEWEIGHT");
						UpdateCachedTreeWeight();
						sdfToMaskMat.SetTexture("_SplineTreeWeight", cachedSplineTreeWeight);
					}
					if (useDetailCurve)
					{
						sdfToMaskMat.EnableKeyword("_SPLINECURVEDETAILWEIGHT");
						UpdateCachedDetailWeight();
						sdfToMaskMat.SetTexture("_SplineDetailWeight", cachedSplineDetailWeight);
					}
					RenderTexture temporary = RenderTexture.GetTemporary(od.terrainMask.descriptor);
					temporary.name = "SplinePath::OcclusionRender";
					temporary.wrapMode = TextureWrapMode.Clamp;
					Graphics.Blit(od.terrainMask, temporary, sdfToMaskMat);
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(od.terrainMask);
					od.terrainMask = temporary;
					RenderTexture.active = dest;
				}
				if (clearObjects)
				{
					if (sdfToMaskShader == null)
					{
						sdfToMaskShader = Shader.Find("Hidden/MicroVerse/SDFToMask");
					}
					if (sdfToMaskMat == null)
					{
						sdfToMaskMat = new Material(sdfToMaskShader);
					}
					sdfToMaskMat.DisableKeyword("_TREATASAREA");
					sdfToMaskMat.SetFloat(_HeightWidth, objectWidth);
					sdfToMaskMat.SetFloat(_HeightSmoothness, objectSmoothness);
					sdfToMaskMat.SetTexture(_SplineSDF, splineRenderer.splineSDF);
					RenderTexture temporary2 = RenderTexture.GetTemporary(od.objectMask.descriptor);
					temporary2.name = "SplinePath::OcclusionRender";
					temporary2.wrapMode = TextureWrapMode.Clamp;
					Graphics.Blit(od.objectMask, temporary2, sdfToMaskMat);
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(od.objectMask);
					od.objectMask = temporary2;
					RenderTexture.active = dest;
				}
			}
			return result;
		}

		public void ClearCachedSplineTextureCurve()
		{
			if (cachedSplineTextureWeight != null)
			{
				UnityEngine.Object.DestroyImmediate(cachedSplineTextureWeight);
			}
		}

		public void ClearCachedSplineTreeCurve()
		{
			if (cachedSplineTreeWeight != null)
			{
				UnityEngine.Object.DestroyImmediate(cachedSplineTreeWeight);
			}
		}

		public void ClearCachedSplineDetailCurve()
		{
			if (cachedSplineDetailWeight != null)
			{
				UnityEngine.Object.DestroyImmediate(cachedSplineDetailWeight);
			}
		}

		public void ClearCachedSplineTrenchCurve()
		{
			if (cachedSplineTrenchWeight != null)
			{
				UnityEngine.Object.DestroyImmediate(cachedSplineTrenchWeight);
			}
		}

		public void UpdateCachedTextureWeight()
		{
			if (cachedSplineTextureWeight == null)
			{
				cachedSplineTextureWeight = new Texture2D(128, 1, TextureFormat.R8, mipChain: false);
				cachedSplineTextureWeight.filterMode = FilterMode.Bilinear;
				cachedSplineTextureWeight.wrapMode = TextureWrapMode.Clamp;
				cachedSplineTextureWeight.hideFlags = HideFlags.HideAndDontSave;
				for (int i = 0; i < 128; i++)
				{
					cachedSplineTextureWeight.SetPixel(i, 0, new Color(textureCurve.Evaluate((float)i / 128f), 0f, 0f, 1f));
				}
				cachedSplineTextureWeight.Apply();
			}
		}

		public void UpdateCachedTreeWeight()
		{
			if (cachedSplineTreeWeight == null)
			{
				cachedSplineTreeWeight = new Texture2D(128, 1, TextureFormat.R8, mipChain: false);
				cachedSplineTreeWeight.filterMode = FilterMode.Bilinear;
				cachedSplineTreeWeight.wrapMode = TextureWrapMode.Clamp;
				cachedSplineTreeWeight.hideFlags = HideFlags.HideAndDontSave;
				for (int i = 0; i < 128; i++)
				{
					cachedSplineTreeWeight.SetPixel(i, 0, new Color(treeCurve.Evaluate((float)i / 128f), 0f, 0f, 1f));
				}
				cachedSplineTreeWeight.Apply();
			}
		}

		public void UpdateCachedTrenchCurve()
		{
			if (cachedSplineTrenchWeight == null)
			{
				cachedSplineTrenchWeight = new Texture2D(128, 1, TextureFormat.RFloat, mipChain: false);
				cachedSplineTrenchWeight.filterMode = FilterMode.Bilinear;
				cachedSplineTrenchWeight.wrapMode = TextureWrapMode.Clamp;
				cachedSplineTrenchWeight.hideFlags = HideFlags.HideAndDontSave;
				for (int i = 0; i < 128; i++)
				{
					cachedSplineTrenchWeight.SetPixel(i, 0, new Color(trenchCurve.Evaluate((float)i / 128f), 0f, 0f, 1f));
				}
				cachedSplineTrenchWeight.Apply();
			}
		}

		public void UpdateCachedDetailWeight()
		{
			if (cachedSplineDetailWeight == null)
			{
				cachedSplineDetailWeight = new Texture2D(128, 1, TextureFormat.R8, mipChain: false);
				cachedSplineDetailWeight.filterMode = FilterMode.Bilinear;
				cachedSplineDetailWeight.wrapMode = TextureWrapMode.Clamp;
				cachedSplineDetailWeight.hideFlags = HideFlags.HideAndDontSave;
				for (int i = 0; i < 128; i++)
				{
					cachedSplineDetailWeight.SetPixel(i, 0, new Color(detailCurve.Evaluate((float)i / 128f), 0f, 0f, 1f));
				}
				cachedSplineDetailWeight.Apply();
			}
		}

		public bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od)
		{
			if (layer == null)
			{
				return false;
			}
			if (!modifySplatMap)
			{
				return false;
			}
			SplineRenderer splineRenderer = GetSplineRenderer(od.terrain);
			if (splineRenderer != null)
			{
				mainChannelIndex = TerrainUtil.FindTextureChannelIndex(od.terrain, layer);
				embankmentChannelIndex = TerrainUtil.FindTextureChannelIndex(od.terrain, embankmentLayer);
				if (mainChannelIndex == -1)
				{
					return false;
				}
				keywordBuilder.Clear();
				PrepareMaterial(splatMat, splatmapData, keywordBuilder.keywords);
				splatMat.SetTexture(_SplineSDF, splineRenderer.splineSDF);
				splatMat.SetFloat(_Channel, mainChannelIndex);
				splatMat.SetTexture(_WeightMap, weightSrc);
				splatMat.SetTexture(_IndexMap, indexSrc);
				splatMat.SetFloat(_AlphaMapSize, indexSrc.width);
				splatMat.SetFloat(_SplatWeight, splatWeight);
				if (useTextureCurve)
				{
					keywordBuilder.Add("_SPLINECURVETEXTUREWEIGHT");
					UpdateCachedTextureWeight();
					splatMat.SetTexture("_SplineTextureWeight", cachedSplineTextureWeight);
				}
				keywordBuilder.Assign(splatMat);
				multipleRenderBuffers[0] = indexDest.colorBuffer;
				multipleRenderBuffers[1] = weightDest.colorBuffer;
				Graphics.SetRenderTarget(multipleRenderBuffers, indexDest.depthBuffer);
				Graphics.Blit(null, splatMat, 0);
				return true;
			}
			return false;
		}

		public void Dispose()
		{
		}

		private void PrepareMaterial(Material material, HeightmapData heightmapData, List<string> keywords)
		{
			if (treatAsSplineArea)
			{
				keywordBuilder.Add("_TREATASAREA");
			}
			Vector3 position = heightmapData.terrain.transform.position;
			position.x /= heightmapData.terrain.terrainData.size.x;
			position.z /= heightmapData.terrain.terrainData.size.z;
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(heightmapData.terrain)));
			material.SetFloat(_Width, width);
			material.SetFloat(_Smoothness, smoothness);
			material.SetFloat(_Trench, trench);
			if (useTrenchCurve)
			{
				keywords.Add("_SPLINECURVETRENCHWEIGHT");
				UpdateCachedTrenchCurve();
				material.SetTexture(_TrenchCurve, cachedSplineTrenchWeight);
			}
			heightNoise.PrepareMaterial(material, "_HEIGHT", "_Height", keywords);
			material.SetFloat(_RealHeight, heightmapData.RealHeight);
			material.SetFloat(_Blend, blend);
			material.SetFloat(_CombineBlend, blend);
			embankmentEasing.PrepareMaterial(material, "_FALLOFF", keywords);
			embankmentNoise.PrepareMaterial(material, "_FALLOFF", "_Falloff", keywords);
			material.SetInt(_CombineMode, (int)heightBlendMode);
		}

		private void PrepareMaterial(Material material, TextureData splatmapData, List<string> keywords)
		{
			if (treatAsSplineArea)
			{
				keywordBuilder.Add("_TREATASAREA");
			}
			material.SetFloat(_Width, splatWidth);
			material.SetFloat(_Smoothness, splatSmoothness);
			material.SetFloat(_EmbankmentChannel, embankmentChannelIndex);
			material.SetFloat(_HeightWidth, width);
			material.SetFloat(_HeightSmoothness, smoothness);
			material.SetVector(_NoiseParams, splatNoise.GetParamVector());
			material.SetVector(_NoiseParams2, splatNoise.GetParam2Vector());
			material.SetFloat(_SplatNoiseChannel, (float)splatNoise.channel);
			material.SetTexture(_SplatNoiseTexture, splatNoise.texture);
			material.SetTextureScale(_SplatNoiseTexture, splatNoise.GetTextureScale());
			material.SetTextureOffset(_SplatNoiseTexture, splatNoise.GetTextureOffset());
			material.SetFloat(_CombineBlend, blend);
			Vector3 position = splatmapData.terrain.transform.position;
			position.x /= splatmapData.terrain.terrainData.size.x;
			position.z /= splatmapData.terrain.terrainData.size.z;
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(splatmapData.terrain)));
			splatNoise.EnableKeyword(material, "_SPLAT", keywords);
			if (embankmentChannelIndex != -1)
			{
				keywordBuilder.Add("_EMBANKMENT");
			}
		}

		public static Bounds ComputeBounds(SplineContainer spline, float expand)
		{
			if (spline == null || spline.Spline == null)
			{
				return new Bounds(new Vector3(-999999f, -999999f, -99999f), Vector3.one);
			}
			Bounds result = spline.Spline.GetBounds(spline.transform.localToWorldMatrix);
			result.Expand(expand);
			result.max = new Vector3(result.max.x, 100000f, result.max.z);
			result.min = new Vector3(result.min.x, -100000f, result.min.z);
			for (int i = 1; i < spline.Splines.Count; i++)
			{
				Bounds bounds = spline.Splines[i].GetBounds(spline.transform.localToWorldMatrix);
				bounds.center = spline.transform.localToWorldMatrix.MultiplyPoint(bounds.center);
				bounds.size = spline.transform.localToWorldMatrix.MultiplyPoint(bounds.size);
				bounds.Expand(expand);
				bounds.max = new Vector3(bounds.max.x, 100000f, bounds.max.z);
				bounds.min = new Vector3(bounds.min.x, -100000f, bounds.min.z);
				result.Encapsulate(bounds);
			}
			return result;
		}

		public override Bounds GetBounds()
		{
			if (bounds.size == Vector3.zero)
			{
				float a = Mathf.Max(width, splatWidth);
				a = Mathf.Max(a, smoothness);
				a = Mathf.Max(a, splatSmoothness);
				if (multiSpline != null)
				{
					int num = 0;
					SplineRenderer.RenderDesc[] array = multiSpline;
					for (int i = 0; i < array.Length; i++)
					{
						SplineRenderer.RenderDesc renderDesc = array[i];
						if (renderDesc.splineContainer != null)
						{
							if (num == 0)
							{
								bounds = ComputeBounds(renderDesc.splineContainer, a + renderDesc.widthBoost + positionNoise.amplitude * 0.5f);
							}
							else
							{
								bounds.Encapsulate(ComputeBounds(renderDesc.splineContainer, a + renderDesc.widthBoost + positionNoise.amplitude * 0.5f));
							}
							num++;
						}
					}
				}
				else if (spline != null)
				{
					bounds = ComputeBounds(spline, a);
				}
				else
				{
					bounds = new Bounds(Vector3.zero, Vector3.zero);
				}
			}
			return bounds;
		}

		public void InqTerrainLayers(Terrain terrain, List<TerrainLayer> layers)
		{
			if (layer != null)
			{
				layers.Add(layer);
			}
			if (embankmentLayer != null)
			{
				layers.Add(embankmentLayer);
			}
		}
	}
}

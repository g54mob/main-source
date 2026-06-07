using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class FilterSet : ISerializationCallbackReceiver
	{
		public enum NoiseOp
		{
			Add = 0,
			Subtract = 1,
			Multiply = 2,
			Overlay = 3,
			Min = 4,
			Max = 5
		}

		[Serializable]
		public class Filter
		{
			public enum FilterType
			{
				Simple = 0,
				Curve = 1
			}

			public bool enabled;

			public FilterType filterType;

			[Range(0f, 1f)]
			public float weight = 1f;

			public Vector2 range = new Vector2(0f, 1f);

			public Vector2 smoothness = new Vector2(1f, 1f);

			public Noise noise = new Noise();

			public float mipBias;

			public AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.25f, 1f), new Keyframe(0.75f, 1f), new Keyframe(1f, 0f));

			public Texture2D _curveTexture;

			public Texture2D curveTexture
			{
				get
				{
					if (_curveTexture == null)
					{
						_curveTexture = new Texture2D(128, 1, TextureFormat.R8, mipChain: false, linear: true);
						_curveTexture.hideFlags = HideFlags.HideAndDontSave;
						for (int i = 0; i < 128; i++)
						{
							float num = curve.Evaluate((float)i / 128f);
							_curveTexture.SetPixel(i, 0, new Color(num, num, num, num));
						}
						_curveTexture.Apply();
					}
					return _curveTexture;
				}
			}

			public Filter(Vector2 range, Vector2 smoothness)
			{
				this.range = range;
				this.smoothness = smoothness;
			}
		}

		[Serializable]
		public class TextureFilter
		{
			public TerrainLayer layer;

			[Range(-1f, 1f)]
			public float weight;

			[Range(0f, 10f)]
			public float amplitude = 1f;

			[Range(-1f, 1f)]
			public float balance;
		}

		public FalloffFilter falloffFilter = new FalloffFilter();

		[Range(0f, 1f)]
		public float weight = 1f;

		public Noise weightNoise = new Noise();

		public Noise weight2Noise = new Noise();

		public Noise weight3Noise = new Noise();

		public NoiseOp weight2NoiseOp;

		public NoiseOp weight3NoiseOp;

		public int version;

		public Filter heightFilter = new Filter(new Vector2(0f, 500f), new Vector2(20f, 20f));

		public Filter slopeFilter = new Filter(new Vector2(0f, 18f), new Vector2(4f, 4f));

		public Filter angleFilter = new Filter(new Vector2(0f, 90f), new Vector2(12f, 12f));

		public Filter curvatureFilter = new Filter(new Vector2(0.6f, 1f), new Vector2(0.1f, 0.1f));

		public Filter flowFilter = new Filter(new Vector2(0.6f, 1f), new Vector2(0.1f, 0.1f));

		public bool textureFilterEnabled;

		[Range(0f, 1f)]
		public float otherTextureWeight = 1f;

		public List<TextureFilter> textureFilters = new List<TextureFilter>();

		private static Vector4[] terrainLayerWeights = new Vector4[32];

		private static int _Transform = Shader.PropertyToID("_Transform");

		private static int _RealSize = Shader.PropertyToID("_RealSize");

		private static int _Weight = Shader.PropertyToID("_Weight");

		private static int _NoiseUV = Shader.PropertyToID("_NoiseUV");

		private static int _WeightNoise = Shader.PropertyToID("_WeightNoise");

		private static int _WeightNoise2 = Shader.PropertyToID("_WeightNoise2");

		private static int _WeightNoiseChannel = Shader.PropertyToID("_WeightNoiseChannel");

		private static int _WeightNoiseTexture = Shader.PropertyToID("_WeightNoiseTexture");

		private static int _Weight2Noise = Shader.PropertyToID("_Weight2Noise");

		private static int _Weight2Noise2 = Shader.PropertyToID("_Weight2Noise2");

		private static int _Weight2NoiseTexture = Shader.PropertyToID("_Weight2NoiseTexture");

		private static int _Weight2NoiseChannel = Shader.PropertyToID("_Weight2NoiseChannel");

		private static int _Weight3Noise = Shader.PropertyToID("_Weight3Noise");

		private static int _Weight3Noise2 = Shader.PropertyToID("_Weight3Noise2");

		private static int _Weight3NoiseTexture = Shader.PropertyToID("_Weight3NoiseTexture");

		private static int _Weight3NoiseChannel = Shader.PropertyToID("_Weight3NoiseChannel");

		private static int _Weight2NoiseOp = Shader.PropertyToID("_Weight2NoiseOp");

		private static int _Weight3NoiseOp = Shader.PropertyToID("_Weight3NoiseOp");

		private static int _HeightWeight = Shader.PropertyToID("_HeightWeight");

		private static int _HeightRange = Shader.PropertyToID("_HeightRange");

		private static int _HeightSmoothness = Shader.PropertyToID("_HeightSmoothness");

		private static int _HeightNoise1 = Shader.PropertyToID("_HeightNoise1");

		private static int _HeightNoise2 = Shader.PropertyToID("_HeightNoise");

		private static int _HeightNoiseTexture = Shader.PropertyToID("_HeightNoiseTexture");

		private static int _HeightNoiseChannel = Shader.PropertyToID("_HeightNoiseChannel");

		private static int _SlopeWeight = Shader.PropertyToID("_SlopeWeight");

		private static int _SlopeRange = Shader.PropertyToID("_SlopeRange");

		private static int _SlopeSmoothness = Shader.PropertyToID("_SlopeSmoothness");

		private static int _SlopeNoise = Shader.PropertyToID("_SlopeNoise");

		private static int _SlopeNoise2 = Shader.PropertyToID("_SlopeNoise2");

		private static int _SlopeNoiseTexture = Shader.PropertyToID("_SlopeNoiseTexture");

		private static int _SlopeNoiseChannel = Shader.PropertyToID("_SlopeNoiseChannel");

		private static int _AngleWeight = Shader.PropertyToID("_AngleWeight");

		private static int _AngleRange = Shader.PropertyToID("_AngleRange");

		private static int _AngleSmoothness = Shader.PropertyToID("_AngleSmoothness");

		private static int _AngleNoise = Shader.PropertyToID("_AngleNoise");

		private static int _AngleNoise2 = Shader.PropertyToID("_AngleNoise2");

		private static int _AngleNoiseTexture = Shader.PropertyToID("_AngleNoiseTexture");

		private static int _AngleNoiseChannel = Shader.PropertyToID("_AngleNoiseChannel");

		private static int _CurvatureWeight = Shader.PropertyToID("_CurvatureWeight");

		private static int _CurvatureRange = Shader.PropertyToID("_CurvatureRange");

		private static int _CurvatureSmoothness = Shader.PropertyToID("_CurvatureSmoothness");

		private static int _CurvatureNoise = Shader.PropertyToID("_CurvatureNoise");

		private static int _CurvatureNoise2 = Shader.PropertyToID("_CurvatureNoise2");

		private static int _CurvatureNoiseTexture = Shader.PropertyToID("_CurvatureNoiseTexture");

		private static int _CurvatureNoiseChannel = Shader.PropertyToID("_CurvatureNoiseChannel");

		private static int _CurvatureMipBias = Shader.PropertyToID("_CurvatureMipBias");

		private static int _FlowWeight = Shader.PropertyToID("_FlowWeight");

		private static int _FlowRange = Shader.PropertyToID("_FlowRange");

		private static int _FlowSmoothness = Shader.PropertyToID("_FlowSmoothness");

		private static int _FlowNoise = Shader.PropertyToID("_FlowNoise");

		private static int _FlowNoise2 = Shader.PropertyToID("_FlowNoise2");

		private static int _FlowNoiseTexture = Shader.PropertyToID("_FlowNoiseTexture");

		private static int _FlowNoiseChannel = Shader.PropertyToID("_FlowNoiseChannel");

		private static int _HeightCurve = Shader.PropertyToID("_HeightCurve");

		private static int _SlopeCurve = Shader.PropertyToID("_SlopeCurve");

		private static int _AngleCurve = Shader.PropertyToID("_AngleCurve");

		private static int _CurvatureCurve = Shader.PropertyToID("_CurvatureCurve");

		private static int _FlowCurve = Shader.PropertyToID("_FlowCurve");

		private static int _GlobalOriginMTX = Shader.PropertyToID("_GlobalOriginMTX");

		private static int _TerrainSize = Shader.PropertyToID("_TerrainSize");

		private static int _PlacementSDF = Shader.PropertyToID("_PlacementSDF");

		private static int _PlacementSDF2 = Shader.PropertyToID("_PlacementSDF2");

		private static int _PlacementSDF3 = Shader.PropertyToID("_PlacementSDF3");

		private static int _DistancesFromTrees = Shader.PropertyToID("_DistancesFromTrees");

		private static int _DistancesFromObject = Shader.PropertyToID("_DistancesFromObject");

		private static int _DistancesFromParent = Shader.PropertyToID("_DistancesFromParent");

		private static int _SDFClamp = Shader.PropertyToID("_SDFClamp");

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if (version == 0)
			{
				slopeFilter.range *= 1.5789474f;
				slopeFilter.smoothness *= 1.5789474f;
			}
			if (version == 1)
			{
				slopeFilter.range *= 1.5789474f;
				slopeFilter.smoothness *= 1.5789474f;
				slopeFilter.range.x = Mathf.Clamp(slopeFilter.range.x, 0f, 90f);
				slopeFilter.range.y = Mathf.Clamp(slopeFilter.range.y, 0f, 90f);
				slopeFilter.smoothness.x = Mathf.Clamp(slopeFilter.smoothness.x, 0f, 90f);
				slopeFilter.smoothness.y = Mathf.Clamp(slopeFilter.smoothness.y, 0f, 90f);
			}
			version = 2;
		}

		public void ScaleAllNoises(float factor)
		{
			weightNoise.frequency *= factor;
			weight2Noise.frequency *= factor;
			weight3Noise.frequency *= factor;
			angleFilter.noise.frequency *= factor;
			slopeFilter.noise.frequency *= factor;
			curvatureFilter.noise.frequency *= factor;
			flowFilter.noise.frequency *= factor;
			heightFilter.noise.frequency *= factor;
			falloffFilter.noise.frequency *= factor;
		}

		public bool NeedCurvatureMap()
		{
			return curvatureFilter.enabled;
		}

		public bool NeedFlowMap()
		{
			return flowFilter.enabled;
		}

		public Vector4[] GetTextureWeights(TerrainLayer[] layers)
		{
			terrainLayerWeights = new Vector4[32];
			for (int i = 0; i < 32; i++)
			{
				terrainLayerWeights[i] = new Vector4(1f - otherTextureWeight, 1f, 0f, 0f);
			}
			for (int j = 0; j < layers.Length; j++)
			{
				foreach (TextureFilter textureFilter in textureFilters)
				{
					if ((object)textureFilter.layer == layers[j])
					{
						terrainLayerWeights[j] = new Vector4(1f - textureFilter.weight, textureFilter.amplitude, textureFilter.balance, 0f);
					}
				}
			}
			return terrainLayerWeights;
		}

		public void PrepareTransform(Transform transform, Terrain terrain, Material material, List<string> keywords, float densityScale = 1f)
		{
			float num = terrain.terrainData.heightmapScale.y * 2f;
			material.SetMatrix(_Transform, TerrainUtil.ComputeStampMatrix(terrain, transform));
			material.SetVector(_RealSize, TerrainUtil.ComputeTerrainSize(terrain));
			Vector3 position = terrain.transform.position;
			Vector3 position2 = Shader.GetGlobalMatrix("_GlobalOriginMTX").GetPosition();
			position += position2;
			position.x /= terrain.terrainData.size.x;
			position.z /= terrain.terrainData.size.z;
			material.SetVector(_TerrainSize, terrain.terrainData.size);
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, densityScale));
			if (heightFilter.enabled)
			{
				material.SetVector(_HeightRange, heightFilter.range / num);
				material.SetVector(_HeightSmoothness, heightFilter.smoothness / num);
			}
			falloffFilter.PrepareTerrain(material, terrain, transform, keywords);
		}

		public void PrepareMaterial(Transform transform, Material material, List<string> keywords)
		{
			falloffFilter.PrepareMaterial(material, transform, keywords);
			material.SetFloat(_Weight, weight);
			if (weightNoise.noiseType != Noise.NoiseType.None)
			{
				material.SetVector(_WeightNoise, weightNoise.GetParamVector());
				material.SetVector(_WeightNoise2, weightNoise.GetParam2Vector());
				material.SetTexture(_WeightNoiseTexture, weightNoise.texture);
				material.SetTextureScale(_WeightNoiseTexture, weightNoise.GetTextureScale());
				material.SetTextureOffset(_WeightNoiseTexture, weightNoise.GetTextureOffset());
				material.SetFloat(_WeightNoiseChannel, (float)weightNoise.channel);
			}
			if (weight2Noise.noiseType != Noise.NoiseType.None)
			{
				material.SetVector(_Weight2Noise, weight2Noise.GetParamVector());
				material.SetVector(_Weight2Noise2, weight2Noise.GetParam2Vector());
				material.SetTexture(_Weight2NoiseTexture, weight2Noise.texture);
				material.SetTextureScale(_Weight2NoiseTexture, weight2Noise.GetTextureScale());
				material.SetTextureOffset(_Weight2NoiseTexture, weight2Noise.GetTextureOffset());
				material.SetFloat(_Weight2NoiseChannel, (float)weight2Noise.channel);
				material.SetFloat(_Weight2NoiseOp, (float)weight2NoiseOp);
			}
			if (weight3Noise.noiseType != Noise.NoiseType.None)
			{
				material.SetVector(_Weight3Noise, weight3Noise.GetParamVector());
				material.SetVector(_Weight3Noise2, weight3Noise.GetParam2Vector());
				material.SetTexture(_Weight3NoiseTexture, weight3Noise.texture);
				material.SetTextureScale(_Weight3NoiseTexture, weight3Noise.GetTextureScale());
				material.SetTextureOffset(_Weight3NoiseTexture, weight3Noise.GetTextureOffset());
				material.SetFloat(_Weight3NoiseChannel, (float)weight3Noise.channel);
				material.SetFloat(_Weight3NoiseOp, (float)weight3NoiseOp);
			}
			if (heightFilter.enabled)
			{
				material.SetFloat(_HeightWeight, heightFilter.weight);
				material.SetVector(_HeightNoise1, heightFilter.noise.GetParamVector());
				material.SetVector(_HeightNoise2, heightFilter.noise.GetParam2Vector());
				material.SetTexture(_HeightNoiseTexture, heightFilter.noise.texture);
				material.SetTextureScale(_HeightNoiseTexture, heightFilter.noise.GetTextureScale());
				material.SetTextureOffset(_HeightNoiseTexture, heightFilter.noise.GetTextureOffset());
				material.SetFloat(_HeightNoiseChannel, (float)heightFilter.noise.channel);
			}
			if (slopeFilter.enabled)
			{
				material.SetFloat(_SlopeWeight, slopeFilter.weight);
				material.SetVector(_SlopeRange, slopeFilter.range * (MathF.PI / 180f));
				material.SetVector(_SlopeSmoothness, slopeFilter.smoothness * (MathF.PI / 180f));
				material.SetVector(_SlopeNoise, slopeFilter.noise.GetParamVector());
				material.SetVector(_SlopeNoise2, slopeFilter.noise.GetParam2Vector());
				material.SetTexture(_SlopeNoiseTexture, slopeFilter.noise.texture);
				material.SetTextureScale(_SlopeNoiseTexture, slopeFilter.noise.GetTextureScale());
				material.SetTextureOffset(_SlopeNoiseTexture, slopeFilter.noise.GetTextureOffset());
				material.SetFloat(_SlopeNoiseChannel, (float)slopeFilter.noise.channel);
			}
			if (angleFilter.enabled)
			{
				material.SetFloat(_AngleWeight, angleFilter.weight);
				material.SetVector(_AngleRange, angleFilter.range * (MathF.PI / 180f));
				material.SetVector(_AngleSmoothness, angleFilter.smoothness * (MathF.PI / 180f));
				material.SetVector(_AngleNoise, angleFilter.noise.GetParamVector());
				material.SetVector(_AngleNoise2, angleFilter.noise.GetParam2Vector());
				material.SetTexture(_AngleNoiseTexture, angleFilter.noise.texture);
				material.SetTextureScale(_AngleNoiseTexture, angleFilter.noise.GetTextureScale());
				material.SetTextureOffset(_AngleNoiseTexture, angleFilter.noise.GetTextureOffset());
				material.SetFloat(_AngleNoiseChannel, (float)angleFilter.noise.channel);
			}
			if (curvatureFilter.enabled)
			{
				material.SetFloat(_CurvatureWeight, curvatureFilter.weight);
				material.SetVector(_CurvatureRange, curvatureFilter.range);
				material.SetVector(_CurvatureSmoothness, curvatureFilter.smoothness);
				material.SetVector(_CurvatureNoise, curvatureFilter.noise.GetParamVector());
				material.SetVector(_CurvatureNoise2, curvatureFilter.noise.GetParam2Vector());
				material.SetTexture(_CurvatureNoiseTexture, curvatureFilter.noise.texture);
				material.SetTextureScale(_CurvatureNoiseTexture, curvatureFilter.noise.GetTextureScale());
				material.SetTextureOffset(_CurvatureNoiseTexture, curvatureFilter.noise.GetTextureOffset());
				material.SetFloat(_CurvatureNoiseChannel, (float)curvatureFilter.noise.channel);
				material.SetFloat(_CurvatureMipBias, curvatureFilter.mipBias);
			}
			if (flowFilter.enabled)
			{
				material.SetFloat(_FlowWeight, flowFilter.weight);
				material.SetVector(_FlowRange, flowFilter.range);
				material.SetVector(_FlowSmoothness, flowFilter.smoothness);
				material.SetVector(_FlowNoise, flowFilter.noise.GetParamVector());
				material.SetVector(_FlowNoise2, flowFilter.noise.GetParam2Vector());
				material.SetTexture(_FlowNoiseTexture, flowFilter.noise.texture);
				material.SetTextureScale(_FlowNoiseTexture, flowFilter.noise.GetTextureScale());
				material.SetTextureOffset(_FlowNoiseTexture, flowFilter.noise.GetTextureOffset());
				material.SetFloat(_FlowNoiseChannel, (float)flowFilter.noise.channel);
			}
			if (heightFilter.enabled)
			{
				keywords.Add("_HEIGHTFILTER");
				if (heightFilter.filterType == Filter.FilterType.Curve)
				{
					keywords.Add("_HEIGHTCURVE");
					material.SetTexture(_HeightCurve, heightFilter.curveTexture);
				}
				heightFilter.noise.EnableKeyword(material, "_HEIGHT", keywords);
			}
			if (slopeFilter.enabled)
			{
				keywords.Add("_SLOPEFILTER");
				if (slopeFilter.filterType == Filter.FilterType.Curve)
				{
					keywords.Add("_SLOPECURVE");
					material.SetTexture(_SlopeCurve, slopeFilter.curveTexture);
				}
				slopeFilter.noise.EnableKeyword(material, "_SLOPE", keywords);
			}
			if (angleFilter.enabled)
			{
				keywords.Add("_ANGLEFILTER");
				if (angleFilter.filterType == Filter.FilterType.Curve)
				{
					keywords.Add("_ANGLECURVE");
					material.SetTexture(_AngleCurve, angleFilter.curveTexture);
				}
				angleFilter.noise.EnableKeyword(material, "_ANGLE", keywords);
			}
			if (curvatureFilter.enabled)
			{
				keywords.Add("_CURVATUREFILTER");
				if (curvatureFilter.filterType == Filter.FilterType.Curve)
				{
					keywords.Add("_CURVATURECURVE");
					material.SetTexture(_CurvatureCurve, curvatureFilter.curveTexture);
				}
				curvatureFilter.noise.EnableKeyword(material, "_CURVATURE", keywords);
			}
			if (flowFilter.enabled)
			{
				keywords.Add("_FLOWFILTER");
				if (flowFilter.filterType == Filter.FilterType.Curve)
				{
					keywords.Add("_FLOWCURVE");
					material.SetTexture(_FlowCurve, curvatureFilter.curveTexture);
				}
				flowFilter.noise.EnableKeyword(material, "_FLOW", keywords);
			}
			if (textureFilterEnabled)
			{
				keywords.Add("_TEXTUREFILTER");
			}
			weightNoise.EnableKeyword(material, "_WEIGHT", keywords);
			weight2Noise.EnableKeyword(material, "_WEIGHT2", keywords);
			weight3Noise.EnableKeyword(material, "_WEIGHT3", keywords);
		}

		public static void PrepareSDFFilter(Stamp.KeywordBuilder keywords, Material material, Transform transform, OcclusionData od, float ratio, bool sdfClamp, float minTree, float maxTree, float minObj, float maxObj, float minParent, float maxParent)
		{
			if (maxTree >= 255f)
			{
				maxTree = minTree;
			}
			if (maxObj >= 255f)
			{
				maxObj = minObj;
			}
			if (maxParent >= 255f)
			{
				maxParent = minParent;
			}
			if (minObj + minTree + maxObj + maxTree <= 0f && ((!(minParent > 0f) && !(maxParent > 0f)) || !(transform.parent != null)))
			{
				return;
			}
			keywords.Add("_SDFFILTERING");
			if (minTree > 0f || maxTree > 0f)
			{
				material.SetVector(_DistancesFromTrees, new Vector2(minTree * ratio, maxTree * ratio));
				material.SetTexture(_PlacementSDF, od.treeSDF);
			}
			if (minObj > 0f || maxObj > 0f)
			{
				material.SetVector(_DistancesFromObject, new Vector2(minObj * ratio, maxObj * ratio));
				material.SetTexture(_PlacementSDF2, od.objectSDF);
			}
			if ((minParent > 0f || maxParent > 0f) && transform.parent != null)
			{
				ISpawner componentInParent = transform.parent.GetComponentInParent<ISpawner>(includeInactive: false);
				if (componentInParent != null)
				{
					RenderTexture sDF = componentInParent.GetSDF(od.terrain);
					if (sDF != null)
					{
						material.SetVector(_DistancesFromParent, new Vector2(minParent * ratio, maxParent * ratio));
						material.SetTexture(_PlacementSDF3, sDF);
					}
				}
			}
			material.SetFloat(_SDFClamp, sdfClamp ? 1f : 0f);
		}
	}
}

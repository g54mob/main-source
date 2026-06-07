using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class HeightStamp : Stamp, IHeightModifier, IModifier
	{
		public enum CombineMode
		{
			Override = 0,
			Max = 1,
			Min = 2,
			Add = 3,
			Subtract = 4,
			Multiply = 5,
			Average = 6,
			Difference = 7,
			SqrtMultiply = 8,
			Blend = 9
		}

		public Texture2D stamp;

		public CombineMode mode = CombineMode.Max;

		public FalloffFilter falloff = new FalloffFilter();

		[Tooltip("Twists the stamp around the Y axis")]
		[Range(-90f, 90f)]
		public float twist;

		[Tooltip("Erodes the slopes of the terrain")]
		[Range(0f, 600f)]
		public float erosion;

		[Tooltip("Controls the scale of the erosion effect")]
		[Range(1f, 90f)]
		public float erosionSize = 4f;

		[Tooltip("Bends the heights towards the top or bottom")]
		[Range(0.1f, 8f)]
		public float power = 1f;

		[Tooltip("Invert the height map")]
		public bool invert;

		public bool useHeightRemap;

		public AnimationCurve remapCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private Texture2D remapCurveTex;

		[Tooltip("Blend between existing height map and new one")]
		[Range(0f, 1f)]
		public float blend = 1f;

		public Vector2 remapRange = new Vector2(0f, 1f);

		public Vector4 scaleOffset = new Vector4(1f, 1f, 0f, 0f);

		[Range(-1f, 1f)]
		public float tiltX;

		[Range(-1f, 1f)]
		public float tiltZ;

		public bool tiltScaleX;

		public bool tiltScaleZ;

		[Range(0f, 6f)]
		public float mipBias;

		private Material material;

		[SerializeField]
		private int version;

		private static Shader heightmapShader = null;

		private static int _AlphaMapSize = Shader.PropertyToID("_AlphaMapSize");

		private static int _PlacementMask = Shader.PropertyToID("_PlacementMask");

		private static int _NoiseUV = Shader.PropertyToID("_NoiseUV");

		private static int _Invert = Shader.PropertyToID("_Invert");

		private static int _Blend = Shader.PropertyToID("_Blend");

		private static int _Power = Shader.PropertyToID("_Power");

		private static int _Tilt = Shader.PropertyToID("_Tilt");

		private static int _TiltScale = Shader.PropertyToID("_TiltScale");

		private static int _Transform = Shader.PropertyToID("_Transform");

		private static int _RealSize = Shader.PropertyToID("_RealSize");

		private static int _StampTex = Shader.PropertyToID("_StampTex");

		private static int _MipBias = Shader.PropertyToID("_MipBias");

		private static int _RemapRange = Shader.PropertyToID("_RemapRange");

		private static int _ScaleOffset = Shader.PropertyToID("_ScaleOffset");

		private static int _HeightRemap = Shader.PropertyToID("_HeightRemap");

		private static int _CombineMode = Shader.PropertyToID("_CombineMode");

		private static int _Twist = Shader.PropertyToID("_Twist");

		private static int _Erosion = Shader.PropertyToID("_Erosion");

		private static int _ErosionSize = Shader.PropertyToID("_ErosionSize");

		private static int _HeightRemapCurve = Shader.PropertyToID("_HeightRemapCurve");

		private static int _CombineBlend = Shader.PropertyToID("_CombineBlend");

		public void ClearRemapCurve()
		{
			if (remapCurveTex != null)
			{
				Object.DestroyImmediate(remapCurveTex);
			}
		}

		public void Dispose()
		{
		}

		protected override void OnDestroy()
		{
			Object.DestroyImmediate(material);
			base.OnDestroy();
		}

		public override void OnEnable()
		{
			if (version == 0 && mode == CombineMode.Max)
			{
				Vector3 position = base.transform.position;
				position.y = 0f;
				base.transform.position = position;
			}
			else if (version == 1 && mode != CombineMode.Override && mode != CombineMode.Max)
			{
				Vector3 position2 = base.transform.position;
				position2.y = 0f;
				base.transform.position = position2;
			}
			base.OnEnable();
			version = 2;
		}

		public void Initialize()
		{
			if (stamp != null)
			{
				stamp.wrapMode = TextureWrapMode.Clamp;
			}
			if (heightmapShader == null)
			{
				heightmapShader = Shader.Find("Hidden/MicroVerse/HeightmapStamp");
			}
			if (material == null)
			{
				material = new Material(heightmapShader);
			}
			if (useHeightRemap && remapCurveTex == null)
			{
				remapCurveTex = new Texture2D(256, 1, TextureFormat.R16, mipChain: false);
				remapCurveTex.wrapMode = TextureWrapMode.Clamp;
				remapCurveTex.filterMode = FilterMode.Bilinear;
				remapCurveTex.hideFlags = HideFlags.HideAndDontSave;
				for (int i = 0; i < 256; i++)
				{
					remapCurveTex.SetPixel(i, 0, new Color(remapCurve.Evaluate((float)i / 256f), 0f, 0f, 1f));
				}
				remapCurveTex.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
		}

		public override Bounds GetBounds()
		{
			FalloffOverride componentInParent = GetComponentInParent<FalloffOverride>();
			FalloffFilter.FilterType filterType = falloff.filterType;
			FalloffFilter filter = falloff;
			if (componentInParent != null && componentInParent.enabled)
			{
				filterType = componentInParent.filter.filterType;
				filter = componentInParent.filter;
			}
			if (filterType == FalloffFilter.FilterType.SplineArea && filter.splineArea != null)
			{
				return filter.splineArea.GetBounds();
			}
			if (filterType == FalloffFilter.FilterType.Global && filter.paintArea != null && filter.paintArea.clampOutsideOfBounds)
			{
				return filter.paintArea.GetBounds();
			}
			return TerrainUtil.GetBounds(base.transform);
		}

		public bool ApplyHeightStampAbsolute(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od, Vector2 heightRenorm)
		{
			material.SetVector("_HeightRenorm", heightRenorm);
			keywordBuilder.Clear();
			keywordBuilder.Add("_PASTESTAMP");
			keywordBuilder.Add("_ABSOLUTEHEIGHT");
			PrepareMaterial(material, heightmapData, keywordBuilder.keywords);
			material.SetFloat(_AlphaMapSize, source.width);
			material.SetTexture(_PlacementMask, od.terrainMask);
			Vector3 position = heightmapData.terrain.transform.position;
			position.x /= heightmapData.terrain.terrainData.size.x;
			position.z /= heightmapData.terrain.terrainData.size.z;
			material.SetFloat(_Power, 1f);
			material.SetFloat(_Blend, 1f);
			material.SetFloat(_Invert, 0f);
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(heightmapData.terrain)));
			keywordBuilder.Assign(material);
			material.SetMatrix(_Transform, TerrainUtil.ComputeStampMatrix(heightmapData.terrain, base.transform));
			Graphics.Blit(source, dest, material);
			return true;
		}

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			keywordBuilder.Clear();
			PrepareMaterial(material, heightmapData, keywordBuilder.keywords);
			material.SetFloat(_AlphaMapSize, source.width);
			material.SetTexture(_PlacementMask, od.terrainMask);
			Vector3 position = heightmapData.terrain.transform.position;
			position.x /= heightmapData.terrain.terrainData.size.x;
			position.z /= heightmapData.terrain.terrainData.size.z;
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(heightmapData.terrain)));
			material.SetFloat(_Power, power);
			material.SetFloat(_Blend, blend);
			material.SetFloat(_Invert, invert ? 1f : 0f);
			material.SetVector(_TiltScale, new Vector2(tiltScaleX ? 1 : 0, tiltScaleZ ? 1 : 0));
			material.SetVector(_Tilt, new Vector3(tiltX, 0f, tiltZ));
			if (power != 1f || tiltX != 0f || tiltZ != 0f)
			{
				keywordBuilder.Add("_USEPOWORTILT");
			}
			keywordBuilder.Assign(material);
			Graphics.Blit(source, dest, material);
			return true;
		}

		private void PrepareMaterial(Material material, HeightmapData heightmapData, List<string> keywords)
		{
			Vector3 vector = heightmapData.WorldToTerrainMatrix.MultiplyPoint3x4(base.transform.position);
			Vector3 lossyScale = base.transform.lossyScale;
			material.SetMatrix(_Transform, TerrainUtil.ComputeStampMatrix(heightmapData.terrain, base.transform, heightStamp: true));
			material.SetVector(_RealSize, TerrainUtil.ComputeTerrainSize(heightmapData.terrain));
			if (stamp != null)
			{
				stamp.wrapMode = ((scaleOffset == new Vector4(1f, 1f, 0f, 0f)) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
			}
			material.SetTexture(_StampTex, stamp);
			material.SetFloat(_MipBias, mipBias);
			material.SetVector(_RemapRange, remapRange);
			material.SetVector(_ScaleOffset, scaleOffset);
			material.SetFloat(_CombineBlend, blend);
			falloff.PrepareTerrain(material, heightmapData.terrain, base.transform, keywords);
			falloff.PrepareMaterial(material, base.transform, keywords);
			float y = vector.y;
			material.SetVector(_HeightRemap, new Vector2(y, y + lossyScale.y) / heightmapData.RealHeight);
			material.SetInt(_CombineMode, (int)mode);
			if (twist != 0f)
			{
				keywords.Add("_TWIST");
				material.SetFloat(_Twist, twist);
			}
			if (erosion != 0f)
			{
				keywords.Add("_EROSION");
				material.SetFloat(_Erosion, erosion);
				material.SetFloat(_ErosionSize, erosionSize);
			}
			if (useHeightRemap)
			{
				keywords.Add("_USEHEIGHTREMAPCUVE");
				material.SetTexture(_HeightRemapCurve, remapCurveTex);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (MicroVerse.instance != null)
			{
				Gizmos.color = MicroVerse.instance.options.colors.heightStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}
	}
}

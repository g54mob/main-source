using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class HeightAreaEffectStamp : Stamp, IHeightModifier, IModifier
	{
		public enum EffectType
		{
			Terrace = 0,
			Beach = 1,
			RemapCurve = 2,
			Noise = 3
		}

		[Tooltip("Effect to apply")]
		public EffectType effectType;

		public FalloffFilter falloff = new FalloffFilter();

		public Noise noise = new Noise();

		[Tooltip("How the noise should be combined with the existing height data")]
		public HeightStamp.CombineMode combineMode = HeightStamp.CombineMode.Add;

		[Range(0f, 1f)]
		public float combineBlend;

		[Tooltip("How high each terrace should be")]
		[Range(0.05f, 20f)]
		public float terraceSize = 1f;

		[Tooltip("How sharp the terrace should be")]
		[Range(0f, 1f)]
		public float terraceStrength = 1f;

		[Tooltip("The effect will only be present around the stamps world Y value by this many meters")]
		[Range(0.05f, 100f)]
		public float beachDistance = 5f;

		[Tooltip("Allows you to control the curve of adjustment")]
		[Range(0.25f, 4f)]
		public float beachPower = 1f;

		public AnimationCurve remapCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private Material material;

		public Texture2D remapCurveTex;

		private static Shader heightmapShader = null;

		private static int _Transform = Shader.PropertyToID("_Transform");

		private static int _RealSize = Shader.PropertyToID("_RealSize");

		private static int _NoiseUV = Shader.PropertyToID("_NoiseUV");

		private static int _TerraceSize = Shader.PropertyToID("_TerraceSize");

		private static int _BeachDistance = Shader.PropertyToID("_BeachDistance");

		private static int _WorldPosY = Shader.PropertyToID("_WorldPosY");

		private static int _BeachPower = Shader.PropertyToID("_BeachPower");

		private static int _RemapCurve = Shader.PropertyToID("_RemapCurve");

		private static int _CombineMode = Shader.PropertyToID("_CombineMode");

		private static int _CombineBlend = Shader.PropertyToID("_CombineBlend");

		private static int _TerraceStrength = Shader.PropertyToID("_TerraceStrength");

		public void Dispose()
		{
		}

		protected override void OnDestroy()
		{
			Object.DestroyImmediate(material);
			base.OnDestroy();
		}

		public void Initialize()
		{
			if (heightmapShader == null)
			{
				heightmapShader = Shader.Find("Hidden/MicroVerse/HeightAreaEffectStamp");
			}
			if (material == null)
			{
				material = new Material(heightmapShader);
			}
			if (effectType == EffectType.RemapCurve && remapCurveTex == null)
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

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			keywordBuilder.Clear();
			falloff.PrepareMaterial(material, base.transform, keywordBuilder.keywords);
			falloff.PrepareTerrain(material, heightmapData.terrain, base.transform, keywordBuilder.keywords);
			switch (effectType)
			{
			case EffectType.Terrace:
				keywordBuilder.Add("_TERRACE");
				material.SetFloat(_TerraceSize, terraceSize);
				material.SetFloat(_TerraceStrength, terraceStrength);
				break;
			case EffectType.Beach:
				keywordBuilder.Add("_BEACH");
				material.SetFloat(_BeachDistance, beachDistance);
				material.SetFloat(_BeachPower, beachPower);
				break;
			case EffectType.RemapCurve:
				keywordBuilder.Add("_REMAP");
				material.SetTexture(_RemapCurve, remapCurveTex);
				break;
			case EffectType.Noise:
				noise.PrepareMaterial(material, "_NOISE", "_Noise", keywordBuilder.keywords);
				material.SetFloat(_CombineMode, (float)combineMode);
				material.SetFloat(_CombineBlend, combineBlend);
				break;
			}
			material.SetFloat(_WorldPosY, base.transform.position.y);
			material.SetMatrix(_Transform, TerrainUtil.ComputeStampMatrix(heightmapData.terrain, base.transform, heightStamp: true));
			material.SetVector(_RealSize, TerrainUtil.ComputeTerrainSize(heightmapData.terrain));
			Vector3 position = heightmapData.terrain.transform.position;
			position.x /= heightmapData.terrain.terrainData.size.x;
			position.z /= heightmapData.terrain.terrainData.size.z;
			material.SetVector(_NoiseUV, new Vector3(position.x, position.z, GetTerrainScalingFactor(heightmapData.terrain)));
			keywordBuilder.Assign(material);
			Graphics.Blit(source, dest, material);
			return true;
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

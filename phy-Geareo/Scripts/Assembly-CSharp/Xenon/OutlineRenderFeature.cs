using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Xenon
{
	public class OutlineRenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class Settings
		{
			public RenderPassEvent RenderPassEvent;

			public LayerMask LayerMask;

			public RenderingLayerMask RenderingLayerMask;

			public Material OverrideMaterial;

			public Material BlitMaterial;

			public bool ClearDepth;
		}

		[Serializable]
		public class OutlineSettings
		{
			public float OutlineScale;

			public float RobertsCrossMultiplier;

			public float DepthThreshold;

			public float NormalThreshold;

			public float SteepAngleThreshold;

			public float SteepAngleMultiplier;

			public Color OutlineColor;
		}

		public class OutlineData : ContextItem
		{
			public TextureHandle FilterTextureHandle;

			public override void Reset()
			{
			}
		}

		public Settings FeatureSettings;

		public OutlineSettings MaterialSettings;

		private OutlinePassFilter _outlinePassFilter;

		private OutlinePassFinal _outlinePassFinal;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	[DisallowMultipleRendererFeature("Stylized Water 2")]
	public class StylizedWaterRenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class ScreenSpaceReflectionSettings
		{
			public bool enable;
		}

		public ScreenSpaceReflectionSettings screenSpaceReflectionSettings;

		[Tooltip("Project caustics from the main directional light.")]
		public bool directionalCaustics;

		public DisplacementPrePass.Settings displacementPrePassSettings;

		private SetupConstants constantsSetup;

		private DisplacementPrePass displacementPass;

		public static StylizedWaterRenderFeature GetDefault()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		private void OnDestroy()
		{
		}
	}
}

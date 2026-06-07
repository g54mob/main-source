using System;
using Rendering.RenderFeatures.OrderedDither;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Rendering.RenderFeatures
{
	public class CustomPostProcessRenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class FeatureSettings
		{
			public Material blurMaterial;

			public Material vignetteMaterial;

			[Range(0f, 1f)]
			public float tintBlend;

			public Texture2D tintTexture;

			public Texture2D paperTexture;

			[Tooltip("Vignette color.")]
			public Color color;

			[Tooltip("Sets the vignette center point (screen center is [0.5, 0.5]).")]
			public Vector2 center;

			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			[Tooltip("Lower values will make a square-ish vignette.")]
			[Range(0f, 1f)]
			public float roundness;

			[Tooltip("Set to true to mark the vignette to be perfectly round. False will make its shape dependent on the current aspect ratio.")]
			public bool rounded;
		}

		public FeatureSettings settings = new FeatureSettings();

		private CustomBlurPass _customBlurPass;

		private CustomVignettePass _customVignettePass;

		public override void Create()
		{
			_customBlurPass = new CustomBlurPass(settings.blurMaterial);
			_customVignettePass = new CustomVignettePass(settings);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderingData.cameraData.camera.TryGetComponent<AuxiliaryGameCamera>(out var component);
			if (component == null || !component.ShouldBlur)
			{
				return;
			}
			GameCamera mainGameCamera = component.mainGameCamera;
			renderingData.cameraData.camera.TryGetComponent<GameCamera>(out var _);
			if (mainGameCamera.PostProcessingEnabled)
			{
				CustomBlurData customBlur = mainGameCamera.customBlur;
				if ((double)customBlur.Strength > 0.0)
				{
					_customBlurPass.Setup(customBlur.Strength, customBlur.LevelsRange, customBlur.LevelsOffset);
					renderer.EnqueuePass(_customBlurPass);
				}
				renderer.EnqueuePass(_customVignettePass);
			}
		}
	}
}

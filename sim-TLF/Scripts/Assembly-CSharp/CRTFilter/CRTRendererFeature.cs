using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CRTFilter
{
	public class CRTRendererFeature : ScriptableRendererFeature
	{
		public enum Presets
		{
			none = 0,
			subtle = 1,
			retro = 2,
			strong = 3,
			oldCrt = 4,
			arcade = 5,
			custom = 6
		}

		private class CRTRenderPass : ScriptableRenderPass
		{
			private const string TEXNAME = "CRTFilterTexture";

			private const string PASSNAME = "CRTFilterPass";

			private Material shaderMaterial;

			private RTHandle crtTexture;

			public CRTRenderPass(Material material)
			{
				shaderMaterial = material;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				RenderTextureDescriptor descriptor = cameraTextureDescriptor;
				descriptor.msaaSamples = 1;
				descriptor.depthBufferBits = 0;
				RenderingUtils.ReAllocateHandleIfNeeded(ref crtTexture, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "CRTFilterTexture");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (!renderingData.cameraData.isPreviewCamera && !(shaderMaterial == null) && crtTexture != null)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("CRTFilterPass");
					shaderMaterial.SetFloat("p_time", Time.time);
					commandBuffer.Blit(renderingData.cameraData.renderer.cameraColorTargetHandle, crtTexture, shaderMaterial, 0);
					commandBuffer.Blit(crtTexture, renderingData.cameraData.renderer.cameraColorTargetHandle);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					CommandBufferPool.Release(commandBuffer);
				}
			}

			public void Dispose()
			{
				RTHandles.Release(crtTexture);
				crtTexture = null;
			}
		}

		public Shader shader;

		public Shader shaderLite;

		public bool useShaderLite;

		public bool useVolumeComponent;

		public RenderPassEvent injectionPoint = RenderPassEvent.BeforeRenderingPostProcessing;

		public Presets preset;

		[Range(0f, 640f)]
		public float pixelResolutionX = 320f;

		[Range(0f, 640f)]
		public float pixelResolutionY = 200f;

		[Header("Screen geometry")]
		[Range(0f, 11f)]
		public float screenBend = 4f;

		[Range(0f, 30f)]
		public float screenOverscan = 1f;

		[Range(0f, 20f)]
		public float vignetteSize = 5.7f;

		[Range(0f, 10f)]
		public float vignetteSmooth = 2f;

		[Range(0f, 100f)]
		public float vignetteRound = 25f;

		[Header("Blur effects")]
		[Range(0f, 10f)]
		public float blur;

		[Range(0f, 25f)]
		public float bleed = 1f;

		[Range(0f, 25f)]
		public float smidge;

		[Header("Scanlines and noise")]
		[Range(0f, 25f)]
		public float scanlinesStrength = 6f;

		[Range(0f, 10f)]
		public float apertureStrength = 0.5f;

		[Range(-50f, 50f)]
		public float shadowlines = 6f;

		[Range(-50f, 50f)]
		public float shadowlinesSpeed = 2f;

		[Range(0f, 1f)]
		public float shadowlinesAlpha = 0.1f;

		[Range(0f, 50f)]
		public float noiseSize = 50f;

		[Range(0f, 10f)]
		public float noiseSpeed = 2f;

		[Range(0f, 1f)]
		public float noiseAlpha = 0.1f;

		[Header("Image adjustments")]
		[Range(0f, 2f)]
		public float brightness = 1f;

		[Range(-1f, 3f)]
		public float contrast = 1f;

		[Range(0f, 2f)]
		public float gamma = 1f;

		[Range(0f, 2f)]
		public float red = 1f;

		[Range(0f, 2f)]
		public float green = 1f;

		[Range(0f, 2f)]
		public float blue = 1f;

		[Range(-10f, 10f)]
		public float chromaticAberration = 1f;

		public Vector2 redOffset = new Vector2(0.1f, -0.1f);

		public Vector2 blueOffset = new Vector2(0f, 0.1f);

		public Vector2 greenOffset = new Vector2(-0.1f, 0f);

		private CRTRenderPass crtRenderPass;

		private Material shaderMaterial;

		public void OnValidate()
		{
			if (useVolumeComponent)
			{
				preset = Presets.none;
			}
			switch (preset)
			{
			case Presets.none:
				screenBend = 0f;
				screenOverscan = 0f;
				blur = 0f;
				bleed = 0f;
				smidge = 0f;
				scanlinesStrength = 0f;
				apertureStrength = 0f;
				shadowlines = 0f;
				shadowlinesSpeed = 0f;
				shadowlinesAlpha = 0f;
				vignetteSize = 0f;
				vignetteSmooth = 0f;
				vignetteRound = 0f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				brightness = 1f;
				contrast = 1f;
				gamma = 1f;
				red = 1f;
				green = 1f;
				blue = 1f;
				chromaticAberration = 0f;
				redOffset = Vector2.zero;
				blueOffset = Vector2.zero;
				greenOffset = Vector2.zero;
				break;
			case Presets.subtle:
				screenBend = 0.51f;
				screenOverscan = 0f;
				blur = 0.5f;
				bleed = 0f;
				smidge = 0f;
				scanlinesStrength = 1f;
				apertureStrength = 0.1f;
				shadowlines = 0f;
				shadowlinesSpeed = 0f;
				shadowlinesAlpha = 0f;
				vignetteSize = 5.7f;
				vignetteSmooth = 2f;
				vignetteRound = 63f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 0f;
				break;
			case Presets.retro:
				screenBend = 0.05f;
				screenOverscan = 0f;
				blur = 0.5f;
				bleed = 1.1f;
				smidge = 14f;
				scanlinesStrength = 6.6f;
				apertureStrength = 0.7f;
				shadowlines = 0f;
				shadowlinesSpeed = 0f;
				shadowlinesAlpha = 0f;
				vignetteSize = 5.7f;
				vignetteSmooth = 3.6f;
				vignetteRound = 33.3f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 0f;
				break;
			case Presets.strong:
				screenBend = 6.5f;
				screenOverscan = 0.5f;
				blur = 0.8f;
				bleed = 0f;
				smidge = 0f;
				scanlinesStrength = 2.8f;
				apertureStrength = 1f;
				shadowlines = 3.5f;
				shadowlinesSpeed = 0.5f;
				shadowlinesAlpha = 0.1f;
				vignetteSize = 5.7f;
				vignetteSmooth = 2.8f;
				vignetteRound = 70f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 0.5f;
				break;
			case Presets.oldCrt:
				screenBend = 8.3f;
				screenOverscan = 1.5f;
				blur = 1f;
				bleed = 0.1f;
				smidge = 0f;
				scanlinesStrength = 9f;
				apertureStrength = 4f;
				shadowlines = 3.5f;
				shadowlinesSpeed = 1.5f;
				shadowlinesAlpha = 0.2f;
				vignetteSize = 5.7f;
				vignetteSmooth = 2f;
				vignetteRound = 87f;
				noiseSize = 26f;
				noiseAlpha = 0.25f;
				noiseSpeed = 7.2f;
				chromaticAberration = 1.5f;
				break;
			case Presets.arcade:
				screenBend = 7.2f;
				screenOverscan = 0.5f;
				blur = 0f;
				bleed = 3f;
				smidge = 15f;
				scanlinesStrength = 9f;
				apertureStrength = 4f;
				shadowlines = 0f;
				shadowlinesSpeed = 0f;
				shadowlinesAlpha = 0f;
				vignetteSize = 5.7f;
				vignetteSmooth = 1f;
				vignetteRound = 85f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 1f;
				break;
			}
			if (useShaderLite)
			{
				blur = 0f;
				smidge = 0f;
				apertureStrength = 0f;
				brightness = 1f;
				contrast = 1f;
				gamma = 1f;
				red = 1f;
				green = 1f;
				blue = 1f;
				chromaticAberration = 0f;
				redOffset = Vector2.zero;
				blueOffset = Vector2.zero;
				greenOffset = Vector2.zero;
			}
			if (chromaticAberration != 0f)
			{
				redOffset = new Vector2(chromaticAberration / 10f, chromaticAberration / 10f);
				blueOffset = new Vector2(0f, (0f - chromaticAberration / 10f) * 1.4f);
				greenOffset = new Vector2((0f - chromaticAberration) / 10f, chromaticAberration / 10f);
			}
		}

		public override void Create()
		{
			if (shaderMaterial == null)
			{
				shaderMaterial = CoreUtils.CreateEngineMaterial(useShaderLite ? shaderLite : shader);
			}
			if (crtRenderPass == null)
			{
				crtRenderPass = new CRTRenderPass(shaderMaterial);
				crtRenderPass.renderPassEvent = injectionPoint;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (shaderMaterial != null)
			{
				CoreUtils.Destroy(shaderMaterial);
				shaderMaterial = null;
			}
			if (crtRenderPass != null)
			{
				crtRenderPass.Dispose();
				crtRenderPass = null;
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (shaderMaterial == null || crtRenderPass == null)
			{
				return;
			}
			CRTVolumeComponent cRTVolumeComponent = null;
			if (useVolumeComponent)
			{
				try
				{
					cRTVolumeComponent = VolumeManager.instance.stack.GetComponent<CRTVolumeComponent>();
				}
				catch (Exception exception)
				{
					Debug.LogError("CRT filter wasn't able to retrieve CRTVolumeComponent from VolumeManager. Please make sure that CRTVolumeComponent is defined or disable use of VolumeComponent on CRTFilter settings. Refer to following error for more details.");
					Debug.LogException(exception);
				}
			}
			shaderMaterial.SetFloat(Shader.PropertyToID("p_resX"), pixelResolutionX);
			shaderMaterial.SetFloat(Shader.PropertyToID("p_resY"), pixelResolutionY);
			if (cRTVolumeComponent != null)
			{
				shaderMaterial.SetFloat(Shader.PropertyToID("p_screenBend"), (cRTVolumeComponent.screenBend.value == 0f) ? 1000f : (13f - cRTVolumeComponent.screenBend.value));
				shaderMaterial.SetFloat(Shader.PropertyToID("p_screenOverscan"), cRTVolumeComponent.screenOverscan.value * 0.025f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_blur"), cRTVolumeComponent.blur.value / 1000f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_smidge"), cRTVolumeComponent.smidge.value / 50f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedr"), cRTVolumeComponent.bleed.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedg"), (cRTVolumeComponent.bleed.value > 0f) ? 1 : 0);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedb"), (cRTVolumeComponent.bleed.value > 0f) ? 1 : 0);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_scanlinesStrength"), cRTVolumeComponent.scanlinesStrength.value / 10f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_apertureStrength"), cRTVolumeComponent.apertureStrength.value / 10f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlines"), cRTVolumeComponent.shadowlines.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlinesSpeed"), cRTVolumeComponent.shadowlinesSpeed.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlinesAlpha"), cRTVolumeComponent.shadowlinesAlpha.value * 0.2f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteSize"), cRTVolumeComponent.vignetteSize.value * 0.35f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteSmooth"), cRTVolumeComponent.vignetteSmooth.value * 0.1f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteRound"), 102f - cRTVolumeComponent.vignetteRound.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseSize"), cRTVolumeComponent.noiseSize.value * 20f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseAlpha"), cRTVolumeComponent.noiseAlpha.value * 0.2f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseSpeed"), cRTVolumeComponent.noiseSpeed.value * 0.0001f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_brightness"), cRTVolumeComponent.brightness.value - 1f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_contrast"), cRTVolumeComponent.contrast.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_gamma"), cRTVolumeComponent.gamma.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_red"), cRTVolumeComponent.red.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_green"), cRTVolumeComponent.green.value);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_blue"), cRTVolumeComponent.blue.value);
				shaderMaterial.SetVector(Shader.PropertyToID("p_redOffset"), cRTVolumeComponent.redOffset.value / 100f);
				shaderMaterial.SetVector(Shader.PropertyToID("p_greenOffset"), cRTVolumeComponent.greenOffset.value / 100f);
				shaderMaterial.SetVector(Shader.PropertyToID("p_blueOffset"), cRTVolumeComponent.blueOffset.value / 100f);
			}
			else
			{
				shaderMaterial.SetFloat(Shader.PropertyToID("p_screenBend"), (screenBend == 0f) ? 1000f : (13f - screenBend));
				shaderMaterial.SetFloat(Shader.PropertyToID("p_screenOverscan"), screenOverscan * 0.025f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_blur"), blur / 1000f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_smidge"), smidge / 50f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedr"), bleed);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedg"), (bleed > 0f) ? 1 : 0);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_bleedb"), (bleed > 0f) ? 1 : 0);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_scanlinesStrength"), scanlinesStrength / 10f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_apertureStrength"), apertureStrength / 10f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlines"), shadowlines);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlinesSpeed"), shadowlinesSpeed);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_shadowlinesAlpha"), shadowlinesAlpha * 0.2f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteSize"), vignetteSize * 0.35f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteSmooth"), vignetteSmooth * 0.1f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_vignetteRound"), 102f - vignetteRound);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseSize"), noiseSize * 20f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseAlpha"), noiseAlpha * 0.2f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_noiseSpeed"), noiseSpeed * 0.0001f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_brightness"), brightness - 1f);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_contrast"), contrast);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_gamma"), gamma);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_red"), red);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_green"), green);
				shaderMaterial.SetFloat(Shader.PropertyToID("p_blue"), blue);
				shaderMaterial.SetVector(Shader.PropertyToID("p_redOffset"), redOffset / 100f);
				shaderMaterial.SetVector(Shader.PropertyToID("p_greenOffset"), greenOffset / 100f);
				shaderMaterial.SetVector(Shader.PropertyToID("p_blueOffset"), blueOffset / 100f);
			}
			crtRenderPass.ConfigureInput(ScriptableRenderPassInput.Color);
			renderer.EnqueuePass(crtRenderPass);
		}
	}
}

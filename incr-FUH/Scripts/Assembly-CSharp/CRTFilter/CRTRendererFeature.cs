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
			hole = 6,
			custom = 7
		}

		private class CRTRenderPass : ScriptableRenderPass
		{
			private const string PROFTAG = "CRTFilter";

			private Material shaderMaterial;

			private RTHandle crtTexture;

			public CRTRenderPass(Material material)
			{
				shaderMaterial = material;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				RenderTextureDescriptor descriptor = cameraTextureDescriptor;
				descriptor.depthBufferBits = 0;
				RenderingUtils.ReAllocateIfNeeded(ref crtTexture, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_CRTTexture");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (!(shaderMaterial == null) && crtTexture != null)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("CRTFilter");
					shaderMaterial.SetFloat("m_time", Time.time);
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

		public RenderPassEvent injectionPoint = RenderPassEvent.BeforeRenderingPostProcessing;

		public Presets preset;

		[Range(0f, 640f)]
		public float pixelResolutionX = 320f;

		[Range(0f, 640f)]
		public float pixelResolutionY = 200f;

		[Header("Screen geometry")]
		[Range(0f, 10f)]
		public float screenBend = 4f;

		[Range(0f, 10f)]
		public float screenOverscan = 1f;

		[Range(0f, 10f)]
		public float vignetteSize = 5.3f;

		[Range(0f, 20f)]
		public float vignetteSmooth = 2f;

		[Range(2f, 50f)]
		public float vignetteRound = 25f;

		[Header("Blur effects")]
		[Range(0f, 10f)]
		public float blur;

		[Range(0f, 50f)]
		public float bleed;

		[Range(0f, 50f)]
		public float smidge;

		[Header("Scanlines and noise")]
		[Range(0f, 10f)]
		public float scanlinesStrength = 3f;

		[Range(0f, 10f)]
		public float apertureStrength = 3f;

		[Range(-50f, 50f)]
		public float shadowlines = 8f;

		[Range(-20f, 20f)]
		public float shadowlinesSpeed = -2f;

		[Range(0f, 1f)]
		public float shadowlinesAlpha = 0.05f;

		[Range(0f, 50f)]
		public float noiseSize = 75f;

		[Range(0f, 10f)]
		public float noiseSpeed = 0.02f;

		[Range(0f, 1f)]
		public float noiseAlpha = 0.05f;

		[Header("Image adjustments")]
		[Range(-2f, 2f)]
		public float brightness;

		[Range(-3f, 3f)]
		public float contrast = 1f;

		[Range(-3f, 3f)]
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

		public Vector3 newWhite = new Vector3(1f, 1f, 1f);

		public Vector3 newBlack = new Vector3(0f, 0f, 0f);

		private CRTRenderPass crtRenderPass;

		private Material shaderMaterial;

		public void OnValidate()
		{
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
				vignetteRound = 25f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				brightness = 0f;
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
				vignetteSize = 5.65f;
				vignetteSmooth = 2f;
				vignetteRound = 37f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 0f;
				break;
			case Presets.retro:
				screenBend = 0f;
				screenOverscan = 0f;
				blur = 0.5f;
				bleed = 1.1f;
				smidge = 14f;
				scanlinesStrength = 9f;
				apertureStrength = 1f;
				shadowlines = 0f;
				shadowlinesSpeed = 0f;
				shadowlinesAlpha = 0f;
				vignetteSize = 5.7f;
				vignetteSmooth = 4.3f;
				vignetteRound = 50f;
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
				vignetteRound = 30f;
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
				vignetteRound = 13f;
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
				vignetteRound = 15f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 1f;
				break;
			case Presets.hole:
				screenBend = 6.5f;
				screenOverscan = 0f;
				blur = 0.1f;
				bleed = 0f;
				smidge = 0f;
				scanlinesStrength = 5.18f;
				apertureStrength = 1.18f;
				shadowlines = 0f;
				shadowlinesSpeed = 0.5f;
				shadowlinesAlpha = 0.1f;
				vignetteSize = 5.7f;
				vignetteSmooth = 2.8f;
				vignetteRound = 30f;
				noiseSize = 0f;
				noiseAlpha = 0f;
				noiseSpeed = 0f;
				chromaticAberration = 10f;
				break;
			}
			if (chromaticAberration != 0f)
			{
				redOffset = new Vector2((0f - chromaticAberration) / 10f, chromaticAberration / 10f);
				blueOffset = new Vector2((0f - chromaticAberration) / 10f * 1.2f, chromaticAberration / 10f * 1.2f);
				greenOffset = new Vector2((0f - chromaticAberration) / 10f * 1.4f, chromaticAberration / 10f * 1.4f);
			}
		}

		public override void Create()
		{
			if (shaderMaterial == null)
			{
				shaderMaterial = CoreUtils.CreateEngineMaterial(shader);
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
			if (!(shaderMaterial == null) && crtRenderPass != null)
			{
				UpdateValues();
				shaderMaterial.SetVector("m_newWhite", newWhite);
				shaderMaterial.SetVector("m_newBlack", newBlack);
				crtRenderPass.ConfigureInput(ScriptableRenderPassInput.Color);
				renderer.EnqueuePass(crtRenderPass);
			}
		}

		public void UpdateValues()
		{
			if (!(shaderMaterial == null))
			{
				shaderMaterial.SetFloat("m_screenBend", (screenBend == 0f) ? 1000f : (13f - screenBend));
				shaderMaterial.SetFloat("m_screenOverscan", screenOverscan * 0.025f);
				shaderMaterial.SetFloat("m_blur", blur / 1000f);
				shaderMaterial.SetFloat("m_smidge", smidge / 50f);
				shaderMaterial.SetFloat("m_bleedr", bleed);
				shaderMaterial.SetFloat("m_bleedg", (bleed > 0f) ? 1 : 0);
				shaderMaterial.SetFloat("m_bleedb", (bleed > 0f) ? 1 : 0);
				shaderMaterial.SetFloat("m_resX", pixelResolutionX);
				shaderMaterial.SetFloat("m_resY", pixelResolutionY);
				shaderMaterial.SetFloat("m_scanlinesStrength", scanlinesStrength / 10f);
				shaderMaterial.SetFloat("m_apertureStrength", apertureStrength / 10f);
				shaderMaterial.SetFloat("m_shadowlines", shadowlines);
				shaderMaterial.SetFloat("m_shadowlinesSpeed", shadowlinesSpeed);
				shaderMaterial.SetFloat("m_shadowlinesAlpha", shadowlinesAlpha * 0.2f);
				shaderMaterial.SetFloat("m_vignetteSize", vignetteSize * 0.35f);
				shaderMaterial.SetFloat("m_vignetteSmooth", vignetteSmooth * 0.1f);
				shaderMaterial.SetFloat("m_vignetteRound", vignetteRound);
				shaderMaterial.SetFloat("m_noiseSize", noiseSize * 20f);
				shaderMaterial.SetFloat("m_noiseAlpha", noiseAlpha * 0.2f);
				shaderMaterial.SetFloat("m_noiseSpeed", noiseSpeed * 0.0001f);
				shaderMaterial.SetFloat("m_brightness", brightness);
				shaderMaterial.SetFloat("m_contrast", contrast);
				shaderMaterial.SetFloat("m_gamma", gamma);
				shaderMaterial.SetFloat("m_red", red);
				shaderMaterial.SetFloat("m_green", green);
				shaderMaterial.SetFloat("m_blue", blue);
				shaderMaterial.SetVector("m_redOffset", redOffset / 100f);
				shaderMaterial.SetVector("m_greenOffset", greenOffset / 100f);
				shaderMaterial.SetVector("m_blueOffset", blueOffset / 100f);
			}
		}

		public void UpdateNewWhite(Color newColor)
		{
			newWhite = new Vector3(newColor.r, newColor.g, newColor.b);
			if (!(shaderMaterial == null))
			{
				shaderMaterial.SetVector("m_newWhite", newWhite);
			}
		}

		public void UpdateNewBlack(Color newColor)
		{
			newBlack = new Vector3(newColor.r, newColor.g, newColor.b);
			if (!(shaderMaterial == null))
			{
				shaderMaterial.SetVector("m_newBlack", newBlack);
			}
		}
	}
}

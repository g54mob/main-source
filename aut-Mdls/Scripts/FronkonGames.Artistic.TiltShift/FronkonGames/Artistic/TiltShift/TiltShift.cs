using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal;

namespace FronkonGames.Artistic.TiltShift
{
	[DisallowMultipleRendererFeature("Tilt Shift")]
	public sealed class TiltShift : ScriptableRendererFeature
	{
		[DisallowMultipleRendererFeature(null)]
		private sealed class RenderPass : ScriptableRenderPass
		{
			private static class ShaderIDs
			{
				internal static readonly int Intensity = Shader.PropertyToID("_Intensity");

				internal static readonly int Angle = Shader.PropertyToID("_Angle");

				internal static readonly int Aperture = Shader.PropertyToID("_Aperture");

				internal static readonly int Offset = Shader.PropertyToID("_Offset");

				internal static readonly int Blur = Shader.PropertyToID("_Blur");

				internal static readonly int BlurCurve = Shader.PropertyToID("_BlurCurve");

				internal static readonly int Distortion = Shader.PropertyToID("_Distortion");

				internal static readonly int DistortionScale = Shader.PropertyToID("_DistortionScale");

				internal static readonly int FocusedBrightness = Shader.PropertyToID("_FocusedBrightness");

				internal static readonly int FocusedContrast = Shader.PropertyToID("_FocusedContrast");

				internal static readonly int FocusedGamma = Shader.PropertyToID("_FocusedGamma");

				internal static readonly int FocusedHue = Shader.PropertyToID("_FocusedHue");

				internal static readonly int FocusedSaturation = Shader.PropertyToID("_FocusedSaturation");

				internal static readonly int UnfocusedBrightness = Shader.PropertyToID("_UnfocusedBrightness");

				internal static readonly int UnfocusedContrast = Shader.PropertyToID("_UnfocusedContrast");

				internal static readonly int UnfocusedGamma = Shader.PropertyToID("_UnfocusedGamma");

				internal static readonly int UnfocusedHue = Shader.PropertyToID("_UnfocusedHue");

				internal static readonly int UnfocusedSaturation = Shader.PropertyToID("_UnfocusedSaturation");

				internal static readonly int Brightness = Shader.PropertyToID("_Brightness");

				internal static readonly int Contrast = Shader.PropertyToID("_Contrast");

				internal static readonly int Gamma = Shader.PropertyToID("_Gamma");

				internal static readonly int Hue = Shader.PropertyToID("_Hue");

				internal static readonly int Saturation = Shader.PropertyToID("_Saturation");
			}

			private static class Keywords
			{
				internal static readonly string QualityFast = "QUALITY_FAST";

				internal static readonly string QualityNormal = "QUALITY_NORMAL";

				internal static readonly string DebugView = "DEBUG_VIEW";
			}

			private readonly Settings settings;

			private TextureHandle renderTextureHandle0;

			private TextureHandle renderTextureHandle1;

			internal Material material { get; set; }

			public RenderPass(Settings settings)
			{
				this.settings = settings;
				base.profilingSampler = new ProfilingSampler("FronkonGames.Artistic.TiltShift");
			}

			~RenderPass()
			{
				material = null;
			}

			private void UpdateMaterial()
			{
				material.shaderKeywords = null;
				switch (settings.quality)
				{
				case Quality.Fast:
					material.EnableKeyword(Keywords.QualityFast);
					break;
				case Quality.Normal:
					material.EnableKeyword(Keywords.QualityNormal);
					break;
				}
				material.SetFloat(ShaderIDs.Intensity, settings.intensity);
				material.SetFloat(ShaderIDs.Angle, MathF.PI / 180f * settings.angle);
				material.SetFloat(ShaderIDs.Aperture, settings.aperture);
				material.SetFloat(ShaderIDs.Offset, settings.offset);
				material.SetFloat(ShaderIDs.BlurCurve, settings.blurCurve);
				material.SetFloat(ShaderIDs.Blur, settings.blur * (float)settings.quality);
				material.SetFloat(ShaderIDs.Distortion, settings.distortion);
				material.SetFloat(ShaderIDs.DistortionScale, settings.distortionScale);
				material.SetFloat(ShaderIDs.FocusedBrightness, settings.focusedBrightness);
				material.SetFloat(ShaderIDs.FocusedContrast, settings.focusedContrast);
				material.SetFloat(ShaderIDs.FocusedGamma, 1f / settings.focusedGamma);
				material.SetFloat(ShaderIDs.FocusedHue, settings.focusedHue);
				material.SetFloat(ShaderIDs.FocusedSaturation, settings.focusedSaturation);
				material.SetFloat(ShaderIDs.UnfocusedBrightness, settings.unfocusedBrightness);
				material.SetFloat(ShaderIDs.UnfocusedContrast, settings.unfocusedContrast);
				material.SetFloat(ShaderIDs.UnfocusedGamma, 1f / settings.unfocusedGamma);
				material.SetFloat(ShaderIDs.UnfocusedHue, settings.unfocusedHue);
				material.SetFloat(ShaderIDs.UnfocusedSaturation, settings.unfocusedSaturation);
				material.SetFloat(ShaderIDs.Brightness, settings.brightness);
				material.SetFloat(ShaderIDs.Contrast, settings.contrast);
				material.SetFloat(ShaderIDs.Gamma, 1f / settings.gamma);
				material.SetFloat(ShaderIDs.Hue, settings.hue);
				material.SetFloat(ShaderIDs.Saturation, settings.saturation);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null || settings.intensity == 0f)
				{
					return;
				}
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				if (!universalResourceData.isActiveTargetBackBuffer)
				{
					UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
					if ((universalCameraData.camera.cameraType != CameraType.SceneView || settings.affectSceneView) && universalCameraData.postProcessEnabled)
					{
						TextureHandle activeColorTexture = universalResourceData.activeColorTexture;
						TextureDesc desc = activeColorTexture.GetDescriptor(renderGraph);
						desc.colorFormat = ((QualitySettings.activeColorSpace == ColorSpace.Linear) ? GraphicsFormat.R8G8B8A8_SRGB : GraphicsFormat.R8G8B8A8_UNorm);
						TextureDesc desc2 = activeColorTexture.GetDescriptor(renderGraph);
						UpdateMaterial();
						renderTextureHandle0 = renderGraph.CreateTexture(in desc);
						renderTextureHandle1 = renderGraph.CreateTexture(in desc2);
						renderGraph.AddBlitPass(new RenderGraphUtils.BlitMaterialParameters(activeColorTexture, renderTextureHandle0, material, 0), "FronkonGames.Artistic.TiltShift.Pass0", "/builds/games/hvmodulus/modulus-production/Assets/FronkonGames/Artistic/TiltShift/Runtime/TiltShift.Pass.cs", 170);
						renderGraph.AddBlitPass(new RenderGraphUtils.BlitMaterialParameters(renderTextureHandle0, renderTextureHandle1, material, 1), "FronkonGames.Artistic.TiltShift.Pass1", "/builds/games/hvmodulus/modulus-production/Assets/FronkonGames/Artistic/TiltShift/Runtime/TiltShift.Pass.cs", 171);
						universalResourceData.cameraColor = renderTextureHandle1;
					}
				}
			}
		}

		public enum Quality
		{
			High = 1,
			Normal = 2,
			Fast = 4
		}

		[Serializable]
		public sealed class Settings
		{
			public float intensity = 1f;

			public Quality quality = Quality.High;

			public float angle;

			public float aperture = 0.5f;

			public float offset;

			public float blurCurve = 3f;

			public float blur = 1f;

			public float distortion = 5f;

			public float distortionScale = 1f;

			public bool debugView;

			public float focusedBrightness;

			public float focusedContrast = 1f;

			public float focusedGamma = 1f;

			public float focusedHue;

			public float focusedSaturation = 1f;

			public float unfocusedBrightness;

			public float unfocusedContrast = 1f;

			public float unfocusedGamma = 1f;

			public float unfocusedHue;

			public float unfocusedSaturation = 1f;

			public float brightness;

			public float contrast = 1f;

			public float gamma = 1f;

			public float hue;

			public float saturation = 1f;

			public bool affectSceneView;

			public RenderPassEvent whenToInsert = RenderPassEvent.BeforeRenderingTransparents;

			public Settings()
			{
				ResetDefaultValues();
			}

			public void ResetDefaultValues()
			{
				intensity = 1f;
				angle = 0f;
				aperture = 0.5f;
				offset = 0f;
				blurCurve = 3f;
				blur = 1f;
				distortion = 5f;
				distortionScale = 1f;
				focusedBrightness = 0f;
				focusedContrast = 1f;
				focusedGamma = 1f;
				focusedHue = 0f;
				focusedSaturation = 1f;
				unfocusedBrightness = 0f;
				unfocusedContrast = 1f;
				unfocusedGamma = 1f;
				unfocusedHue = 0f;
				unfocusedSaturation = 1f;
				debugView = false;
				brightness = 0f;
				contrast = 1f;
				gamma = 1f;
				hue = 0f;
				saturation = 1f;
				affectSceneView = false;
				whenToInsert = RenderPassEvent.BeforeRenderingTransparents;
			}
		}

		private const string RenderListFieldName = "m_RendererDataList";

		private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

		private static readonly TiltShift[] NoEffects = new TiltShift[0];

		public Settings settings = new Settings();

		private RenderPass renderPass;

		private Material material;

		public static TiltShift Instance
		{
			get
			{
				UniversalRenderPipelineAsset universalRenderPipelineAsset = (UniversalRenderPipelineAsset)GraphicsSettings.defaultRenderPipeline;
				if (universalRenderPipelineAsset != null)
				{
					ScriptableRendererData[] obj = (ScriptableRendererData[])universalRenderPipelineAsset.GetType().GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(universalRenderPipelineAsset);
					ScriptableRendererData scriptableRendererData = ((obj != null) ? obj[0] : null);
					for (int i = 0; i < scriptableRendererData.rendererFeatures.Count; i++)
					{
						if (scriptableRendererData.rendererFeatures[i] is TiltShift)
						{
							return scriptableRendererData.rendererFeatures[i] as TiltShift;
						}
					}
				}
				return null;
			}
		}

		private static TiltShift[] Instances
		{
			get
			{
				if (UniversalRenderPipeline.asset != null)
				{
					ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UniversalRenderPipeline.asset);
					List<TiltShift> list = new List<TiltShift>();
					for (int i = 0; i < array.Length; i++)
					{
						if (!(array[i] != null) || array[i].rendererFeatures.Count <= 0)
						{
							continue;
						}
						foreach (ScriptableRendererFeature rendererFeature in array[i].rendererFeatures)
						{
							if (rendererFeature is TiltShift)
							{
								list.Add(rendererFeature as TiltShift);
							}
						}
					}
					return list.ToArray();
				}
				return NoEffects;
			}
		}

		public static bool IsInRenderFeatures()
		{
			return Instance != null;
		}

		public static bool IsInAnyRenderFeatures()
		{
			return Instances.Length != 0;
		}

		public override void Create()
		{
			if (renderPass == null)
			{
				renderPass = new RenderPass(settings);
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (renderingData.cameraData.cameraType == CameraType.Preview || renderingData.cameraData.cameraType == CameraType.Reflection)
			{
				return;
			}
			renderPass.renderPassEvent = settings.whenToInsert;
			if (material == null)
			{
				string text = "Shaders/ArtisticTiltShift_URP";
				Shader shader = Resources.Load<Shader>(text);
				if (shader != null)
				{
					if (shader.isSupported)
					{
						material = CoreUtils.CreateEngineMaterial(shader);
					}
					else
					{
						Log.Warning("'" + text + ".shader' not supported");
					}
				}
			}
			renderPass.material = material;
			renderer.EnqueuePass(renderPass);
		}

		protected override void Dispose(bool disposing)
		{
			CoreUtils.Destroy(material);
		}
	}
}

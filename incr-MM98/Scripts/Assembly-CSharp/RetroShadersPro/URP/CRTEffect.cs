using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace RetroShadersPro.URP
{
	public class CRTEffect : ScriptableRendererFeature
	{
		private class CRTRenderPass : ScriptableRenderPass
		{
			private class CopyPassData
			{
				public TextureHandle inputTexture;

				public bool useBilinear;
			}

			private class MainPassData
			{
				public Material material;

				public TextureHandle inputTexture;
			}

			private class InterlacePassData
			{
				public TextureHandle inputTexture;

				public bool useBilinear;
			}

			private Material material;

			private RTHandle tempTexHandle;

			private RTHandle interlaceTexHandle;

			private int frameCounter;

			public CRTRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("CRT Effect");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("Retro Shaders Pro/Post Processing/CRT");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"Retro Shaders Pro/Post Processing/CRT\".");
				}
				else
				{
					material = new Material(shader);
				}
			}

			private static RenderTextureDescriptor GetCopyPassDescriptor(RenderTextureDescriptor descriptor)
			{
				descriptor.msaaSamples = 1;
				descriptor.depthBufferBits = 0;
				CRTSettings component = VolumeManager.instance.stack.GetComponent<CRTSettings>();
				float num = 1f;
				if (component.scaleParameters.value)
				{
					num = (float)component.verticalReferenceResolution.value / (float)descriptor.height;
				}
				int width = (int)Mathf.Max(4f, (float)descriptor.width / ((float)component.pixelSize.value / num));
				int height = (int)Mathf.Max(4f, (float)descriptor.height / ((float)component.pixelSize.value / num));
				descriptor.width = width;
				descriptor.height = height;
				return descriptor;
			}

			private static RenderTextureDescriptor GetInterlaceDescriptor(RenderTextureDescriptor descriptor)
			{
				descriptor.msaaSamples = 1;
				descriptor.depthBufferBits = 0;
				return descriptor;
			}

			public void CreateInterlacingTexture()
			{
				RenderingUtils.ReAllocateHandleIfNeeded(descriptor: GetInterlaceDescriptor(new RenderTextureDescriptor(Screen.width, Screen.height, RenderTextureFormat.Default, 0)), handle: ref interlaceTexHandle, filterMode: FilterMode.Point, wrapMode: TextureWrapMode.Repeat, anisoLevel: 1, mipMapBias: 0f, name: "_CRTInterlacingTexture");
			}

			[Obsolete]
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				ResetTarget();
				RenderingUtils.ReAllocateHandleIfNeeded(ref tempTexHandle, GetCopyPassDescriptor(cameraTextureDescriptor), FilterMode.Point, TextureWrapMode.Repeat, 1, 0f, "_CRTColorCopy");
				RenderingUtils.ReAllocateHandleIfNeeded(ref interlaceTexHandle, GetInterlaceDescriptor(cameraTextureDescriptor), FilterMode.Point, TextureWrapMode.Repeat, 1, 0f, "_CRTInterlacingTexture");
				RenderingUtils.ReAllocateIfNeeded(ref tempTexHandle, GetCopyPassDescriptor(cameraTextureDescriptor), FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_CRTColorCopy");
				RenderingUtils.ReAllocateIfNeeded(ref interlaceTexHandle, GetInterlaceDescriptor(cameraTextureDescriptor), FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_CRTInterlacingTexture");
				base.Configure(cmd, cameraTextureDescriptor);
			}

			private void SetMaterialProperties(RTHandle interlacingTexture, int targetHeight, Material material)
			{
				CRTSettings component = VolumeManager.instance.stack.GetComponent<CRTSettings>();
				base.renderPassEvent = component.renderPassEvent.value.Convert();
				Texture value = ((component.rgbTex.value == null) ? Texture2D.whiteTexture : component.rgbTex.value);
				Texture value2 = ((component.scanlineTex.value == null) ? Texture2D.whiteTexture : component.scanlineTex.value);
				Texture value3 = ((component.trackingTexture.value == null) ? Texture2D.grayTexture : component.trackingTexture.value);
				material.SetColor("_TintColor", component.tintColor.value);
				material.SetColor("_BackgroundColor", component.backgroundColor.value);
				material.SetFloat("_DistortionStrength", component.distortionStrength.value);
				material.SetFloat("_DistortionSmoothing", component.distortionSmoothing.value);
				material.SetTexture("_RGBTex", value);
				material.SetFloat("_RGBStrength", component.rgbStrength.value);
				material.SetTexture("_ScanlineTex", value2);
				material.SetFloat("_ScanlineStrength", component.scanlineStrength.value);
				material.SetFloat("_ScrollSpeed", component.scrollSpeed.value);
				material.SetFloat("_RandomWear", component.randomWear.value);
				material.SetFloat("_AberrationStrength", component.aberrationStrength.value);
				if (component.useTracking.value)
				{
					material.EnableKeyword("_TRACKING_ON");
					material.SetTexture("_TrackingTex", value3);
					material.SetFloat("_TrackingSize", component.trackingSize.value);
					material.SetFloat("_TrackingStrength", component.trackingStrength.value);
					material.SetFloat("_TrackingSpeed", component.trackingSpeed.value);
					material.SetFloat("_TrackingJitter", component.trackingJitter.value);
					material.SetFloat("_TrackingColorDamage", component.trackingColorDamage.value);
					material.SetFloat("_TrackingLinesThreshold", component.trackingLinesThreshold.value);
					material.SetColor("_TrackingLinesColor", component.trackingLinesColor.value);
				}
				else
				{
					material.DisableKeyword("_TRACKING_ON");
				}
				material.SetFloat("_Brightness", component.brightness.value);
				material.SetFloat("_Contrast", component.contrast.value);
				material.SetInteger("_Interlacing", frameCounter++ % 2);
				material.SetTexture("_InputTexture", interlacingTexture);
				if (component.scaleParameters.value)
				{
					float num = (float)component.verticalReferenceResolution.value / (float)targetHeight;
					material.SetInt("_Size", (int)((float)component.scanlineSize.value / num));
				}
				else
				{
					material.SetInt("_Size", component.scanlineSize.value);
				}
				if (component.enableInterlacing.value && frameCounter > 1)
				{
					material.EnableKeyword("_INTERLACING_ON");
				}
				else
				{
					material.DisableKeyword("_INTERLACING_ON");
				}
				if (component.forcePointFiltering.value)
				{
					material.EnableKeyword("_POINT_FILTERING_ON");
				}
				else
				{
					material.DisableKeyword("_POINT_FILTERING_ON");
				}
				if (component.aberrationStrength.value > 0.01f)
				{
					material.EnableKeyword("_CHROMATIC_ABERRATION_ON");
				}
				else
				{
					material.DisableKeyword("_CHROMATIC_ABERRATION_ON");
				}
				ColorRampMode colorRampMode = component.colorRampMode.value;
				if (component.colorRampTex.value == null)
				{
					colorRampMode = ColorRampMode.None;
				}
				switch (colorRampMode)
				{
				case ColorRampMode.GameAndWatch:
				case ColorRampMode.GB:
				case ColorRampMode.Greyscale:
				case ColorRampMode.CustomLuminance:
					material.SetTexture("_ColorRampTex", component.colorRampTex.value);
					material.EnableKeyword("_COLOR_RAMP_LUMINANCE");
					material.DisableKeyword("_COLOR_RAMP_RGB");
					material.DisableKeyword("_COLOR_RAMP_INTENSITY");
					material.DisableKeyword("_COLOR_RAMP_NONE");
					break;
				case ColorRampMode.GBA:
				case ColorRampMode.DS:
				case ColorRampMode.NES:
				case ColorRampMode.SNES:
				case ColorRampMode.MSX2:
				case ColorRampMode.IBMPS2:
				case ColorRampMode.Amstrad:
				case ColorRampMode.Teletext:
				case ColorRampMode.MasterSystem:
				case ColorRampMode.Genesis:
				case ColorRampMode.GameGear:
				case ColorRampMode.CustomRGB:
					material.SetTexture("_ColorRampTex", component.colorRampTex.value);
					material.DisableKeyword("_COLOR_RAMP_LUMINANCE");
					material.EnableKeyword("_COLOR_RAMP_RGB");
					material.DisableKeyword("_COLOR_RAMP_INTENSITY");
					material.DisableKeyword("_COLOR_RAMP_NONE");
					break;
				case ColorRampMode.ZXSpectrum:
				case ColorRampMode.CustomIntensity:
					material.SetTexture("_ColorRampTex", component.colorRampTex.value);
					material.DisableKeyword("_COLOR_RAMP_LUMINANCE");
					material.DisableKeyword("_COLOR_RAMP_RGB");
					material.EnableKeyword("_COLOR_RAMP_INTENSITY");
					material.DisableKeyword("_COLOR_RAMP_NONE");
					break;
				case ColorRampMode.None:
					material.DisableKeyword("_COLOR_RAMP_LUMINANCE");
					material.DisableKeyword("_COLOR_RAMP_RGB");
					material.DisableKeyword("_COLOR_RAMP_INTENSITY");
					material.EnableKeyword("_COLOR_RAMP_NONE");
					break;
				}
				Shader.SetGlobalInteger("_RetroPixelSize", component.pixelSize.value);
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				CRTSettings component = VolumeManager.instance.stack.GetComponent<CRTSettings>();
				if ((renderingData.cameraData.isSceneViewCamera && !component.showInSceneView.value) || renderingData.cameraData.isPreviewCamera)
				{
					return;
				}
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				SetMaterialProperties(interlaceTexHandle, cameraColorTargetHandle.rt.height, material);
				using (new ProfilingScope(commandBuffer, base.profilingSampler))
				{
					using (new ProfilingScope(commandBuffer, base.profilingSampler))
					{
						Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, tempTexHandle, 0f, !component.forcePointFiltering.value);
						Blitter.BlitCameraTexture(commandBuffer, tempTexHandle, cameraColorTargetHandle, material, 0);
						if (component.enableInterlacing.value)
						{
							Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, interlaceTexHandle, 0f, !component.forcePointFiltering.value);
						}
					}
				}
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				CommandBufferPool.Release(commandBuffer);
			}

			public void Dispose()
			{
				tempTexHandle?.Release();
			}

			private static void ExecuteCopyPass(RasterCommandBuffer cmd, RTHandle source, bool useBilinear)
			{
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), 0f, useBilinear);
			}

			private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle source, Material material)
			{
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			private static void ExecuteInterlacePass(RasterCommandBuffer cmd, RTHandle source, bool useBilinear)
			{
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), 0f, useBilinear);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				CRTSettings component = VolumeManager.instance.stack.GetComponent<CRTSettings>();
				if ((universalCameraData.isSceneViewCamera && !component.showInSceneView.value) || universalCameraData.isPreviewCamera)
				{
					return;
				}
				SetMaterialProperties(interlaceTexHandle, universalCameraData.cameraTargetDescriptor.height, material);
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				GetInterlaceDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle textureHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_CRTColorCopy", clear: false);
				TextureHandle tex = TextureHandle.nullHandle;
				if (interlaceTexHandle != null)
				{
					tex = renderGraph.ImportTexture(interlaceTexHandle);
				}
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("CRT_CopyColor", out passData, base.profilingSampler, "D:\\BiteMe\\mmo-98\\Assets\\3rd Party\\Retro Shaders Pro\\Scripts\\Shaders\\CRTEffect.cs", 399))
				{
					passData.inputTexture = universalResourceData.activeColorTexture;
					passData.useBilinear = !component.forcePointFiltering.value;
					rasterRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture);
					rasterRenderGraphBuilder.SetRenderAttachment(textureHandle, 0);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(CopyPassData data, RasterGraphContext context)
					{
						ExecuteCopyPass(context.cmd, data.inputTexture, data.useBilinear);
					});
				}
				MainPassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("CRT_MainPass", out passData2, base.profilingSampler, "D:\\BiteMe\\mmo-98\\Assets\\3rd Party\\Retro Shaders Pro\\Scripts\\Shaders\\CRTEffect.cs", 410))
				{
					passData2.material = material;
					passData2.inputTexture = textureHandle;
					rasterRenderGraphBuilder2.UseTexture(in textureHandle);
					if (tex.IsValid())
					{
						rasterRenderGraphBuilder2.UseTexture(in tex);
					}
					rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder2.SetRenderFunc(delegate(MainPassData data, RasterGraphContext context)
					{
						ExecuteMainPass(context.cmd, data.inputTexture, data.material);
					});
				}
				if (!component.enableInterlacing.value || !tex.IsValid())
				{
					return;
				}
				CopyPassData passData3;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<CopyPassData>("CRT_CopyInterlacingTexture", out passData3, base.profilingSampler, "D:\\BiteMe\\mmo-98\\Assets\\3rd Party\\Retro Shaders Pro\\Scripts\\Shaders\\CRTEffect.cs", 427);
				passData3.inputTexture = universalResourceData.activeColorTexture;
				passData3.useBilinear = !component.forcePointFiltering.value;
				rasterRenderGraphBuilder3.UseTexture(universalResourceData.activeColorTexture);
				rasterRenderGraphBuilder3.SetRenderAttachment(tex, 0);
				rasterRenderGraphBuilder3.SetRenderFunc(delegate(CopyPassData data, RasterGraphContext context)
				{
					ExecuteCopyPass(context.cmd, data.inputTexture, data.useBilinear);
				});
			}
		}

		private CRTRenderPass pass;

		public override void Create()
		{
			pass = new CRTRenderPass();
			base.name = "CRT";
			Shader.SetGlobalInteger("_RetroPixelSize", 1);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			CRTSettings component = VolumeManager.instance.stack.GetComponent<CRTSettings>();
			if (component != null && component.IsActive())
			{
				pass.CreateInterlacingTexture();
				renderer.EnqueuePass(pass);
			}
			if (component == null || !component.showInSceneView.value || !component.IsActive())
			{
				Shader.SetGlobalInteger("_RetroPixelSize", 1);
			}
		}

		protected override void Dispose(bool disposing)
		{
			pass.Dispose();
			base.Dispose(disposing);
			Shader.SetGlobalInteger("_RetroPixelSize", 1);
		}
	}
}

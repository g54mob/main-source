using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class TranslucentImageBlurRenderPass : ScriptableRenderPass
	{
		internal struct PassData
		{
			public TranslucentImageSource blurSource;

			public IBlurAlgorithm blurAlgorithm;

			public Vector2Int camPixelSize;

			public bool shouldUpdateBlur;

			public bool isPreviewing;
		}

		internal struct SRPassData
		{
			public bool canvasDisappearWorkaround;
		}

		public readonly struct PreviewExecutionData
		{
			public readonly TranslucentImageSource blurSource;

			public readonly RenderTargetIdentifier previewTarget;

			public readonly Material previewMaterial;

			public PreviewExecutionData(TranslucentImageSource blurSource, RenderTargetIdentifier previewTarget, Material previewMaterial)
			{
				this.blurSource = blurSource;
				this.previewTarget = previewTarget;
				this.previewMaterial = previewMaterial;
			}
		}

		private class BlurRGPassData
		{
			public TextureHandle sourceTex;

			public TextureHandle[] scratches;

			public TranslucentImageSource blurSource;

			public IBlurAlgorithm blurAlgorithm;
		}

		private class PreviewRGPassData
		{
			public TranslucentImageSource blurSource;

			public TextureHandle previewTarget;

			public Material previewMaterial;
		}

		private const string PROFILER_TAG = "Translucent Image Source";

		private readonly URPRendererInternal urpRendererInternal;

		private PassData currentPassData;

		private SRPassData currentSRPassData;

		private Material previewMaterial;

		private string[] scratchNames;

		private readonly Dictionary<RenderTexture, RTHandle> blurredScreenHdlDict = new Dictionary<RenderTexture, RTHandle>();

		public Material PreviewMaterial
		{
			get
			{
				if (!previewMaterial)
				{
					previewMaterial = CoreUtils.CreateEngineMaterial("Hidden/FillCrop_UniversalRP");
				}
				return previewMaterial;
			}
		}

		internal TranslucentImageBlurRenderPass(URPRendererInternal urpRendererInternal)
		{
			this.urpRendererInternal = urpRendererInternal;
			RenderGraphInit();
		}

		~TranslucentImageBlurRenderPass()
		{
			CoreUtils.Destroy(previewMaterial);
			RenderGraphDispose();
		}

		internal void SetupSRP(SRPassData srPassData)
		{
			currentSRPassData = srPassData;
		}

		internal void Setup(PassData passData)
		{
			currentPassData = passData;
			ConfigureInput(ScriptableRenderPassInput.Color);
			base.requiresIntermediateTexture = true;
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("Translucent Image Source");
			RenderTargetIdentifier backBuffer = urpRendererInternal.GetBackBuffer();
			TranslucentImageSource blurSource = currentPassData.blurSource;
			bool flag = currentSRPassData.canvasDisappearWorkaround && renderingData.cameraData.resolveFinalTarget;
			if (currentPassData.shouldUpdateBlur && blurSource.CompleteCull())
			{
				blurSource.ReallocateBlurTexIfNeeded(currentPassData.camPixelSize);
				BlurExecutor.BlurExecutionData data = new BlurExecutor.BlurExecutionData(backBuffer, blurSource, currentPassData.blurAlgorithm);
				BlurExecutor.ExecuteBlurWithTempTextures(commandBuffer, ref data);
				if (flag)
				{
					CoreUtils.SetRenderTarget(commandBuffer, BuiltinRenderTextureType.CameraTarget);
				}
			}
			if (currentPassData.isPreviewing)
			{
				RenderTargetIdentifier previewTarget = (flag ? ((RenderTargetIdentifier)BuiltinRenderTextureType.CameraTarget) : backBuffer);
				PreviewExecutionData data2 = new PreviewExecutionData(blurSource, previewTarget, PreviewMaterial);
				ExecutePreview(commandBuffer, ref data2);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public static void ExecutePreview(CommandBuffer cmd, ref PreviewExecutionData data)
		{
			TranslucentImageSource blurSource = data.blurSource;
			data.previewMaterial.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(blurSource.BlurRegion));
			Blitter.Blit(cmd, blurSource.BlurredScreen, data.previewTarget, data.previewMaterial, 0);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			TranslucentImageSource blurSource = currentPassData.blurSource;
			if (currentPassData.shouldUpdateBlur && blurSource.CompleteCull())
			{
				blurSource.ReallocateBlurTexIfNeeded(currentPassData.camPixelSize);
				RenderTexture blurredScreen = blurSource.BlurredScreen;
				blurredScreenHdlDict.TryGetValue(blurredScreen, out var value);
				if (value == null || value.rt != blurredScreen)
				{
					value?.Release();
					value = RTHandles.Alloc(blurredScreen);
					blurredScreenHdlDict[blurredScreen] = value;
				}
				BlurRGPassData passData;
				using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<BlurRGPassData>("Translucent Image Source", out passData, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\TranslucentImage\\Script\\URP\\Render Pass\\TranslucentImageBlurRenderPassRenderGraph.cs", 57);
				IBlurAlgorithm blurAlgorithm = currentPassData.blurAlgorithm;
				int scratchesCount = blurAlgorithm.GetScratchesCount();
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				passData.sourceTex = universalResourceData.activeColorTexture;
				passData.scratches = new TextureHandle[scratchesCount];
				passData.blurSource = blurSource;
				passData.blurAlgorithm = blurAlgorithm;
				unsafeRenderGraphBuilder.UseTexture(in passData.sourceTex);
				RenderTextureDescriptor descriptor = blurSource.BlurredScreen.descriptor;
				for (int i = 0; i < scratchesCount; i++)
				{
					blurAlgorithm.GetScratchDescriptor(i, ref descriptor);
					passData.scratches[i] = UniversalRenderer.CreateRenderGraphTexture(renderGraph, descriptor, scratchNames[i], clear: false, FilterMode.Bilinear);
					unsafeRenderGraphBuilder.UseTexture(in passData.scratches[i], AccessFlags.ReadWrite);
				}
				unsafeRenderGraphBuilder.UseTexture(renderGraph.ImportTexture(value), AccessFlags.Write);
				unsafeRenderGraphBuilder.SetRenderFunc(delegate(BlurRGPassData data, UnsafeGraphContext context)
				{
					int scratchesCount2 = data.blurAlgorithm.GetScratchesCount();
					for (int j = 0; j < scratchesCount2; j++)
					{
						data.blurAlgorithm.SetScratch(j, data.scratches[j]);
					}
					BlurExecutor.BlurExecutionData data2 = new BlurExecutor.BlurExecutionData(data.sourceTex, data.blurSource, data.blurAlgorithm);
					BlurExecutor.ExecuteBlur(CommandBufferHelpers.GetNativeCommandBuffer(context.cmd), ref data2);
				});
			}
			if (!currentPassData.isPreviewing)
			{
				return;
			}
			PreviewRGPassData passData2;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder2 = renderGraph.AddUnsafePass<PreviewRGPassData>("Translucent Image Source", out passData2, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\TranslucentImage\\Script\\URP\\Render Pass\\TranslucentImageBlurRenderPassRenderGraph.cs", 106);
			UniversalResourceData universalResourceData2 = frameData.Get<UniversalResourceData>();
			passData2.blurSource = blurSource;
			passData2.previewMaterial = PreviewMaterial;
			passData2.previewTarget = universalResourceData2.activeColorTexture;
			unsafeRenderGraphBuilder2.UseTexture(in passData2.previewTarget, AccessFlags.Write);
			unsafeRenderGraphBuilder2.SetRenderFunc(delegate(PreviewRGPassData data, UnsafeGraphContext context)
			{
				PreviewExecutionData data2 = new PreviewExecutionData(data.blurSource, data.previewTarget, data.previewMaterial);
				ExecutePreview(CommandBufferHelpers.GetNativeCommandBuffer(context.cmd), ref data2);
			});
		}

		private void RenderGraphInit()
		{
			scratchNames = new string[14];
			for (int i = 0; i < scratchNames.Length; i++)
			{
				scratchNames[i] = $"TI_intermediate_rt_{i}";
			}
		}

		private void RenderGraphDispose()
		{
			foreach (KeyValuePair<RenderTexture, RTHandle> item in blurredScreenHdlDict)
			{
				item.Deconstruct(out var _, out var value);
				value?.Release();
			}
		}
	}
}

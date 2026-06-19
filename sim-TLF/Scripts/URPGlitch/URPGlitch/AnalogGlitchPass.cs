using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace URPGlitch
{
	public class AnalogGlitchPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal TextureHandle source;

			internal Material material;
		}

		private const string k_AnalogPassName = "AnalogRenderPass";

		private static readonly int ScanLineJitterID = Shader.PropertyToID("_ScanLineJitter");

		private static readonly int VerticalJumpID = Shader.PropertyToID("_VerticalJump");

		private static readonly int HorizontalShakeID = Shader.PropertyToID("_HorizontalShake");

		private static readonly int ColorDriftID = Shader.PropertyToID("_ColorDrift");

		private Material analogGlitchMat;

		private RenderTextureDescriptor textureDescriptor;

		private RTHandle textureHandle;

		private float _verticalJumpTime;

		private static Vector4 scaleBias = new Vector4(1f, 1f, 0f, 0f);

		public AnalogGlitchPass(Shader shader)
		{
			if (shader != null)
			{
				analogGlitchMat = CoreUtils.CreateEngineMaterial(shader);
			}
			textureDescriptor = new RenderTextureDescriptor(Screen.width, Screen.height, RenderTextureFormat.Default, 0);
			base.requiresIntermediateTexture = true;
		}

		private void UpdateSettings()
		{
			if (analogGlitchMat == null)
			{
				Debug.LogError("update settings material null");
				return;
			}
			AnalogGlitchVolume component = VolumeManager.instance.stack.GetComponent<AnalogGlitchVolume>();
			float value = component.scanLineJitter.value;
			float value2 = component.verticalJump.value;
			float value3 = component.horizontalShake.value;
			float value4 = component.colorDrift.value;
			_verticalJumpTime += Time.deltaTime * value2 * 11.3f;
			float y = Mathf.Clamp01(1f - value * 1.2f);
			float x = 0.002f + Mathf.Pow(value, 3f) * 0.05f;
			analogGlitchMat.SetVector(ScanLineJitterID, new Vector2(x, y));
			Vector2 vector = new Vector2(value2, _verticalJumpTime);
			analogGlitchMat.SetVector(VerticalJumpID, vector);
			analogGlitchMat.SetFloat(HorizontalShakeID, value3 * 0.2f);
			Vector2 vector2 = new Vector2(value4 * 0.04f, Time.time * 606.11f);
			analogGlitchMat.SetVector(ColorDriftID, vector2);
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			textureDescriptor.width = cameraTextureDescriptor.width;
			textureDescriptor.height = cameraTextureDescriptor.height;
			RenderingUtils.ReAllocateIfNeeded(ref textureHandle, in textureDescriptor);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			bool postProcessEnabled = renderingData.cameraData.postProcessEnabled;
			bool isSceneViewCamera = renderingData.cameraData.isSceneViewCamera;
			if (!(!postProcessEnabled || isSceneViewCamera))
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.depthBufferBits = 0;
				UpdateSettings();
				Blit(commandBuffer, cameraColorTargetHandle, textureHandle);
				Blit(commandBuffer, textureHandle, cameraColorTargetHandle, analogGlitchMat);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		public void Dispose()
		{
			CoreUtils.Destroy(analogGlitchMat);
			if (textureHandle != null)
			{
				textureHandle.Release();
			}
		}

		private static void ExecutePass(PassData data, RasterGraphContext context, int pass)
		{
			Blitter.BlitTexture(context.cmd, data.source, scaleBias, data.material, pass);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			bool postProcessEnabled = frameData.Get<UniversalCameraData>().postProcessEnabled;
			bool isSceneViewCamera = frameData.Get<UniversalCameraData>().isSceneViewCamera;
			if (!postProcessEnabled || isSceneViewCamera)
			{
				return;
			}
			if (universalResourceData.isActiveTargetBackBuffer)
			{
				Debug.LogError("Skipping render pass. BlitAndSwapColorRendererFeature requires an intermediate ColorTexture, we can't use the BackBuffer as a texture input.");
				return;
			}
			TextureHandle activeColorTexture = universalResourceData.activeColorTexture;
			TextureDesc desc = renderGraph.GetTextureDesc(activeColorTexture);
			desc.name = "CameraColor-AnalogRenderPass";
			desc.clearBuffer = false;
			TextureHandle textureHandle = renderGraph.CreateTexture(in desc);
			UpdateSettings();
			PassData passData;
			using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("AnalogRenderPass", out passData, base.profilingSampler, ".\\Library\\PackageCache\\com.subbu.urp-glitch\\Runtime\\AnalogGlitch\\AnalogGlitchPass.cs", 138))
			{
				passData.source = activeColorTexture;
				passData.material = analogGlitchMat;
				rasterRenderGraphBuilder.UseTexture(in activeColorTexture);
				rasterRenderGraphBuilder.SetRenderAttachment(textureHandle, 0);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context, 0);
				});
			}
			universalResourceData.cameraColor = textureHandle;
		}
	}
}

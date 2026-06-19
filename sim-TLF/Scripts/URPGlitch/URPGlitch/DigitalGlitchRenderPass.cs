using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace URPGlitch
{
	public class DigitalGlitchRenderPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal TextureHandle src;
		}

		private class TextureData
		{
			internal TextureHandle src;

			internal TextureHandle dst;

			internal int mainTexID;

			internal int TrashTexID;

			internal TextureHandle mainTex;

			internal TextureHandle trashTex;

			internal Material material;
		}

		private const string k_DigitalPassName = "DigitalGlitch RenderPass";

		private static readonly int MainTexID = Shader.PropertyToID("_MainTex");

		private static readonly int NoiseTexID = Shader.PropertyToID("_NoiseTex");

		private static readonly int TrashTexID = Shader.PropertyToID("_TrashTex");

		private static readonly int IntensityID = Shader.PropertyToID("_Intensity");

		private readonly System.Random _random;

		private readonly Texture2D _noiseTexture;

		private Material material;

		private Material CompatMaterial;

		private RenderTextureDescriptor textureDescriptor;

		private RTHandle _mainFrame;

		private RTHandle _trashFrame1;

		private RTHandle _trashFrame2;

		private readonly DigitalGlitchVolume _volume;

		private static Vector4 scaleBias = new Vector4(1f, 1f, 0f, 0f);

		private Color randomColor
		{
			get
			{
				float r = (float)_random.NextDouble();
				float g = (float)_random.NextDouble();
				float b = (float)_random.NextDouble();
				float a = (float)_random.NextDouble();
				return new Color(r, g, b, a);
			}
		}

		public DigitalGlitchRenderPass(Shader shader, Shader compatShader)
		{
			if (shader != null)
			{
				material = CoreUtils.CreateEngineMaterial(shader);
			}
			if (compatShader != null)
			{
				CompatMaterial = CoreUtils.CreateEngineMaterial(compatShader);
			}
			base.requiresIntermediateTexture = true;
			textureDescriptor = new RenderTextureDescriptor(Screen.width, Screen.height, RenderTextureFormat.Default, 0);
			_random = new System.Random();
			_noiseTexture = new Texture2D(64, 32, TextureFormat.ARGB32, mipChain: false)
			{
				hideFlags = HideFlags.DontSave,
				wrapMode = TextureWrapMode.Clamp,
				filterMode = FilterMode.Point
			};
			VolumeStack stack = VolumeManager.instance.stack;
			if (stack != null)
			{
				_volume = stack.GetComponent<DigitalGlitchVolume>();
				UpdateNoiseTexture();
			}
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			if ((float)_random.NextDouble() > Mathf.Lerp(0.9f, 0.5f, _volume.intensity.value))
			{
				UpdateNoiseTexture();
			}
			textureDescriptor.width = cameraTextureDescriptor.width;
			textureDescriptor.height = cameraTextureDescriptor.height;
			RenderingUtils.ReAllocateIfNeeded(ref _mainFrame, in textureDescriptor);
			RenderingUtils.ReAllocateIfNeeded(ref _trashFrame1, in textureDescriptor);
			RenderingUtils.ReAllocateIfNeeded(ref _trashFrame2, in textureDescriptor);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			bool postProcessEnabled = renderingData.cameraData.postProcessEnabled;
			bool isSceneViewCamera = renderingData.cameraData.isSceneViewCamera;
			if (!(!postProcessEnabled || isSceneViewCamera))
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get("DigitalGlitch RenderPass");
				commandBuffer.Clear();
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.depthBufferBits = 0;
				commandBuffer.Blit(cameraColorTargetHandle, _mainFrame);
				int frameCount = Time.frameCount;
				if (frameCount % 13 == 0)
				{
					commandBuffer.Blit(cameraColorTargetHandle, _trashFrame1);
				}
				if (frameCount % 73 == 0)
				{
					commandBuffer.Blit(cameraColorTargetHandle, _trashFrame2);
				}
				float num = (float)_random.NextDouble();
				if (num > Mathf.Lerp(0.9f, 0.5f, _volume.intensity.value))
				{
					UpdateNoiseTexture();
				}
				RTHandle rTHandle = ((num > 0.5f) ? _trashFrame1 : _trashFrame2);
				CompatMaterial.SetFloat(IntensityID, _volume.intensity.value);
				CompatMaterial.SetTexture(NoiseTexID, _noiseTexture);
				CompatMaterial.SetTexture(MainTexID, _mainFrame);
				CompatMaterial.SetTexture(TrashTexID, rTHandle);
				commandBuffer.Blit(_mainFrame, cameraColorTargetHandle, CompatMaterial);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		private static void ExecutePass(PassData data, RasterGraphContext context)
		{
			Blitter.BlitTexture(context.cmd, data.src, scaleBias, 0f, bilinear: false);
		}

		private static void ExecutePass(TextureData data, RasterGraphContext context, int pass)
		{
			data.material.SetTexture(data.mainTexID, data.mainTex);
			data.material.SetTexture(data.TrashTexID, data.trashTex);
			Blitter.BlitTexture(context.cmd, data.src, scaleBias, data.material, pass);
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
			float num = (float)_random.NextDouble();
			if (num > Mathf.Lerp(0.9f, 0.5f, _volume.intensity.value))
			{
				UpdateNoiseTexture();
			}
			TextureHandle activeColorTexture = universalResourceData.activeColorTexture;
			TextureDesc textureDesc = renderGraph.GetTextureDesc(activeColorTexture);
			textureDesc.name = "CameraColor-DigitalGlitch RenderPass";
			textureDesc.clearBuffer = false;
			RenderTextureDescriptor cameraTargetDescriptor = frameData.Get<UniversalCameraData>().cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
			TextureHandle textureHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_MainFrame", clear: false);
			TextureHandle textureHandle2 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_TrashFrame1", clear: false);
			TextureHandle textureHandle3 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_TrashFrame2", clear: false);
			PassData passData;
			using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("DigitalGlitch RenderPass1", out passData, base.profilingSampler, ".\\Library\\PackageCache\\com.subbu.urp-glitch\\Runtime\\DigitalGlitch\\DigitalGlitchRenderPass.cs", 197))
			{
				passData.src = activeColorTexture;
				rasterRenderGraphBuilder.UseTexture(in activeColorTexture);
				rasterRenderGraphBuilder.SetRenderAttachment(textureHandle, 0);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context);
				});
			}
			int frameCount = Time.frameCount;
			if (frameCount % 13 == 0)
			{
				PassData passData2;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("DigitalGlitch RenderPass2", out passData2, base.profilingSampler, ".\\Library\\PackageCache\\com.subbu.urp-glitch\\Runtime\\DigitalGlitch\\DigitalGlitchRenderPass.cs", 207);
				passData2.src = activeColorTexture;
				rasterRenderGraphBuilder2.UseTexture(in activeColorTexture);
				rasterRenderGraphBuilder2.SetRenderAttachment(textureHandle2, 0);
				rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context);
				});
			}
			if (frameCount % 73 == 0)
			{
				PassData passData3;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<PassData>("DigitalGlitch RenderPass3", out passData3, base.profilingSampler, ".\\Library\\PackageCache\\com.subbu.urp-glitch\\Runtime\\DigitalGlitch\\DigitalGlitchRenderPass.cs", 217);
				passData3.src = activeColorTexture;
				rasterRenderGraphBuilder3.UseTexture(in activeColorTexture);
				rasterRenderGraphBuilder3.SetRenderAttachment(textureHandle3, 0);
				rasterRenderGraphBuilder3.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context);
				});
			}
			TextureHandle trashTex = ((num > 0.5f) ? textureHandle2 : textureHandle3);
			material.SetFloat(IntensityID, _volume.intensity.value);
			material.SetTexture(NoiseTexID, _noiseTexture);
			TextureData passData4;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder4 = renderGraph.AddRasterRenderPass<TextureData>("DigitalGlitch RenderPass4", out passData4, base.profilingSampler, ".\\Library\\PackageCache\\com.subbu.urp-glitch\\Runtime\\DigitalGlitch\\DigitalGlitchRenderPass.cs", 232);
			passData4.src = textureHandle;
			passData4.dst = activeColorTexture;
			passData4.material = material;
			passData4.mainTex = textureHandle;
			passData4.mainTexID = MainTexID;
			passData4.trashTex = trashTex;
			passData4.TrashTexID = TrashTexID;
			rasterRenderGraphBuilder4.UseTexture(in textureHandle);
			rasterRenderGraphBuilder4.UseTexture(in trashTex);
			rasterRenderGraphBuilder4.SetRenderAttachment(activeColorTexture, 0);
			rasterRenderGraphBuilder4.SetRenderFunc(delegate(TextureData data, RasterGraphContext context)
			{
				ExecutePass(data, context, 0);
			});
		}

		private void UpdateNoiseTexture()
		{
			Color color = randomColor;
			for (int i = 0; i < _noiseTexture.height; i++)
			{
				for (int j = 0; j < _noiseTexture.width; j++)
				{
					if ((float)_random.NextDouble() > 0.89f)
					{
						color = randomColor;
					}
					_noiseTexture.SetPixel(j, i, color);
				}
			}
			_noiseTexture.Apply();
		}

		public void Dispose()
		{
			CoreUtils.Destroy(material);
			CoreUtils.Destroy(_noiseTexture);
			if (_mainFrame != null)
			{
				_mainFrame.Release();
			}
			if (_trashFrame1 != null)
			{
				_trashFrame1.Release();
			}
			if (_trashFrame2 != null)
			{
				_trashFrame2.Release();
			}
		}
	}
}

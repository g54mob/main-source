using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class FancyDither : ScriptableRendererFeature
	{
		private class FancyDitherRenderPass : ScriptableRenderPass
		{
			private class CopyPassData
			{
				public TextureHandle inputTexture;
			}

			private class MainPassData
			{
				public Material material;

				public TextureHandle inputTexture;
			}

			private Material material;

			private RTHandle tempTexHandle;

			public FancyDitherRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("FancyDither");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/FancyDither");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/FancyDither\".");
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
				return descriptor;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				ResetTarget();
				RenderTextureDescriptor descriptor = GetCopyPassDescriptor(cameraTextureDescriptor);
				RenderingUtils.ReAllocateIfNeeded(ref tempTexHandle, in descriptor);
				base.Configure(cmd, cameraTextureDescriptor);
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (!renderingData.cameraData.isPreviewCamera)
				{
					if (material == null)
					{
						CreateMaterial();
					}
					CommandBuffer commandBuffer = CommandBufferPool.Get();
					FancyDitherSettings component = VolumeManager.instance.stack.GetComponent<FancyDitherSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					material.SetTexture("_NoiseTex", component.noiseTex.value ?? Texture2D.whiteTexture);
					material.SetFloat("_NoiseSize", component.noiseSize.value);
					material.SetFloat("_ThresholdOffset", component.thresholdOffset.value);
					material.SetFloat("_Blend", component.blendAmount.value);
					material.SetColor("_DarkColor", component.darkColor.value);
					material.SetColor("_LightColor", component.lightColor.value);
					RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
					using (new ProfilingScope(commandBuffer, base.profilingSampler))
					{
						Blit(commandBuffer, cameraColorTargetHandle, tempTexHandle);
						Blit(commandBuffer, tempTexHandle, cameraColorTargetHandle, material);
					}
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					CommandBufferPool.Release(commandBuffer);
				}
			}

			public void Dispose()
			{
				tempTexHandle?.Release();
			}

			private static void ExecuteCopyPass(RasterCommandBuffer cmd, RTHandle source)
			{
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), 0f, bilinear: false);
			}

			private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle source, Material material)
			{
				FancyDitherSettings component = VolumeManager.instance.stack.GetComponent<FancyDitherSettings>();
				material.SetTexture("_NoiseTex", component.noiseTex.value ?? Texture2D.whiteTexture);
				material.SetFloat("_NoiseSize", component.noiseSize.value);
				material.SetFloat("_ThresholdOffset", component.thresholdOffset.value);
				material.SetFloat("_Blend", component.blendAmount.value);
				material.SetColor("_DarkColor", component.darkColor.value);
				material.SetColor("_LightColor", component.lightColor.value);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				FancyDitherSettings component = VolumeManager.instance.stack.GetComponent<FancyDitherSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_FancyDitherColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("FancyDither_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\FancyDither.cs", 178))
				{
					passData.inputTexture = universalResourceData.activeColorTexture;
					rasterRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture);
					rasterRenderGraphBuilder.SetRenderAttachment(nullHandle, 0);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(CopyPassData data, RasterGraphContext context)
					{
						ExecuteCopyPass(context.cmd, data.inputTexture);
					});
				}
				MainPassData passData2;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("FancyDither_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\FancyDither.cs", 188);
				passData2.material = material;
				passData2.inputTexture = nullHandle;
				rasterRenderGraphBuilder2.UseTexture(in nullHandle);
				rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder2.SetRenderFunc(delegate(MainPassData data, RasterGraphContext context)
				{
					ExecuteMainPass(context.cmd, data.inputTexture, data.material);
				});
			}
		}

		private FancyDitherRenderPass pass;

		public override void Create()
		{
			pass = new FancyDitherRenderPass();
			base.name = "Fancy Dither";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			FancyDitherSettings component = VolumeManager.instance.stack.GetComponent<FancyDitherSettings>();
			if (component != null && component.IsActive())
			{
				pass.ConfigureInput(ScriptableRenderPassInput.Depth);
				pass.ConfigureInput(ScriptableRenderPassInput.Normal);
				renderer.EnqueuePass(pass);
			}
		}

		protected override void Dispose(bool disposing)
		{
			pass.Dispose();
			base.Dispose(disposing);
		}
	}
}

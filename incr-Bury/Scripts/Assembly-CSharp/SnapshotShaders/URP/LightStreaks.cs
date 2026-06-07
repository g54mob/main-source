using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class LightStreaks : ScriptableRendererFeature
	{
		private class LightStreaksRenderPass : ScriptableRenderPass
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

			private class CompositePassData
			{
				public Material material;

				public TextureHandle inputTexture;

				public TextureHandle blurTexture;
			}

			private Material material;

			private RTHandle tempTexHandle;

			private RTHandle blurTexHandle;

			private string profilerTag;

			public LightStreaksRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("LightStreaks");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/LightStreaks");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/Blur\".");
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

			private static RenderTextureDescriptor GetMainPassDescriptor(RenderTextureDescriptor descriptor, int downsampleAmount)
			{
				descriptor.msaaSamples = 1;
				descriptor.depthBufferBits = 0;
				descriptor.width /= downsampleAmount;
				descriptor.height /= downsampleAmount;
				return descriptor;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				ResetTarget();
				RenderTextureDescriptor descriptor = GetCopyPassDescriptor(cameraTextureDescriptor);
				RenderingUtils.ReAllocateIfNeeded(ref tempTexHandle, in descriptor);
				ResetTarget();
				LightStreaksSettings component = VolumeManager.instance.stack.GetComponent<LightStreaksSettings>();
				descriptor = GetMainPassDescriptor(cameraTextureDescriptor, component.downsampleAmount.value);
				RenderingUtils.ReAllocateIfNeeded(ref blurTexHandle, in descriptor);
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
					LightStreaksSettings component = VolumeManager.instance.stack.GetComponent<LightStreaksSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					material.SetInt("_KernelSize", component.strength.value);
					material.SetFloat("_Spread", (float)component.strength.value / 7.5f);
					material.SetFloat("_LuminanceThreshold", component.luminanceThreshold.value);
					RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
					using (new ProfilingScope(commandBuffer, new ProfilingSampler(profilerTag)))
					{
						Blit(commandBuffer, cameraColorTargetHandle, tempTexHandle);
						Blit(commandBuffer, cameraColorTargetHandle, blurTexHandle, material);
						material.SetTexture("_BlurTex", blurTexHandle);
						Blit(commandBuffer, tempTexHandle, cameraColorTargetHandle, material, 1);
					}
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					CommandBufferPool.Release(commandBuffer);
				}
			}

			public void Dispose()
			{
				blurTexHandle?.Release();
			}

			private static void ExecuteCopyPass(RasterCommandBuffer cmd, RTHandle source)
			{
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), 0f, bilinear: false);
			}

			private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle source, Material material)
			{
				LightStreaksSettings component = VolumeManager.instance.stack.GetComponent<LightStreaksSettings>();
				material.SetInt("_KernelSize", component.strength.value);
				material.SetFloat("_Spread", (float)component.strength.value / 7.5f);
				material.SetFloat("_LuminanceThreshold", component.luminanceThreshold.value);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			private static void ExecuteCompositePass(RasterCommandBuffer cmd, RTHandle source, RTHandle blurTex, Material material)
			{
				material.SetTexture("_BlurTex", blurTex);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 1);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				LightStreaksSettings component = VolumeManager.instance.stack.GetComponent<LightStreaksSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_LightStreaksColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("LightStreaks_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\LightStreaks.cs", 207))
				{
					passData.inputTexture = universalResourceData.activeColorTexture;
					rasterRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture);
					rasterRenderGraphBuilder.SetRenderAttachment(nullHandle, 0);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(CopyPassData data, RasterGraphContext context)
					{
						ExecuteCopyPass(context.cmd, data.inputTexture);
					});
				}
				RenderTextureDescriptor mainPassDescriptor = GetMainPassDescriptor(universalCameraData.cameraTargetDescriptor, component.downsampleAmount.value);
				TextureHandle nullHandle2 = TextureHandle.nullHandle;
				nullHandle2 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, mainPassDescriptor, "_LightStreaksBlurTex", clear: false);
				MainPassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("LightStreaks_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\LightStreaks.cs", 222))
				{
					passData2.material = material;
					passData2.inputTexture = universalResourceData.activeColorTexture;
					rasterRenderGraphBuilder2.UseTexture(universalResourceData.activeColorTexture);
					rasterRenderGraphBuilder2.SetRenderAttachment(nullHandle2, 0);
					rasterRenderGraphBuilder2.SetRenderFunc(delegate(MainPassData data, RasterGraphContext context)
					{
						ExecuteMainPass(context.cmd, data.inputTexture, data.material);
					});
				}
				CompositePassData passData3;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<CompositePassData>("LightStreaks_CompositePass", out passData3, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\LightStreaks.cs", 233);
				passData3.material = material;
				passData3.inputTexture = nullHandle;
				passData3.blurTexture = nullHandle2;
				rasterRenderGraphBuilder3.UseTexture(in nullHandle);
				rasterRenderGraphBuilder3.UseTexture(in nullHandle2);
				rasterRenderGraphBuilder3.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder3.SetRenderFunc(delegate(CompositePassData data, RasterGraphContext context)
				{
					ExecuteCompositePass(context.cmd, data.inputTexture, data.blurTexture, data.material);
				});
			}
		}

		private LightStreaksRenderPass pass;

		public override void Create()
		{
			pass = new LightStreaksRenderPass();
			base.name = "Light Streaks";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			LightStreaksSettings component = VolumeManager.instance.stack.GetComponent<LightStreaksSettings>();
			if (component != null && component.IsActive())
			{
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

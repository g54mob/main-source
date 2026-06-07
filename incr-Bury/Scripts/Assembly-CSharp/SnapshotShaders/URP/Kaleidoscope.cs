using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class Kaleidoscope : ScriptableRendererFeature
	{
		private class KaleidoscopeRenderPass : ScriptableRenderPass
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

			public KaleidoscopeRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("Kaleidoscope");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/Kaleidoscope");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/Kaleidoscope\".");
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
					KaleidoscopeSettings component = VolumeManager.instance.stack.GetComponent<KaleidoscopeSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					material.SetFloat("_SegmentCount", component.segmentCount.value);
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
				KaleidoscopeSettings component = VolumeManager.instance.stack.GetComponent<KaleidoscopeSettings>();
				material.SetFloat("_SegmentCount", component.segmentCount.value);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				KaleidoscopeSettings component = VolumeManager.instance.stack.GetComponent<KaleidoscopeSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_KaleidoscopeColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("Kaleidoscope_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Kaleidoscope.cs", 166))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("Kaleidoscope_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Kaleidoscope.cs", 176);
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

		private KaleidoscopeRenderPass pass;

		public override void Create()
		{
			pass = new KaleidoscopeRenderPass();
			base.name = "Kaleidoscope";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			KaleidoscopeSettings component = VolumeManager.instance.stack.GetComponent<KaleidoscopeSettings>();
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

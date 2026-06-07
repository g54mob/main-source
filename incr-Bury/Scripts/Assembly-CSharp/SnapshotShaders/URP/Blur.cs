using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class Blur : ScriptableRendererFeature
	{
		private class BlurRenderPass : ScriptableRenderPass
		{
			private class CopyPassData
			{
				public Material material;

				public TextureHandle inputTexture;
			}

			private class MainPassData
			{
				public Material material;

				public TextureHandle inputTexture;
			}

			private Material material;

			private RTHandle blurTexHandle;

			public BlurRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("Blur");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/Blur");
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

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				ResetTarget();
				RenderTextureDescriptor descriptor = GetCopyPassDescriptor(cameraTextureDescriptor);
				RenderingUtils.ReAllocateIfNeeded(ref blurTexHandle, in descriptor);
				base.Configure(cmd, cameraTextureDescriptor);
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (renderingData.cameraData.isPreviewCamera)
				{
					return;
				}
				if (material == null)
				{
					CreateMaterial();
				}
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				BlurSettings component = VolumeManager.instance.stack.GetComponent<BlurSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				if (component.strength.value > component.blurStepSize.value * 2)
				{
					material.SetInt("_KernelSize", component.strength.value);
					material.SetFloat("_Spread", (float)component.strength.value / 7.5f);
					material.SetInt("_BlurStepSize", component.blurStepSize.value);
					using (new ProfilingScope(commandBuffer, base.profilingSampler))
					{
						if (component.blurType.value == BlurType.Gaussian)
						{
							Blit(commandBuffer, cameraColorTargetHandle, blurTexHandle, material);
							Blit(commandBuffer, blurTexHandle, cameraColorTargetHandle, material, 1);
						}
						else if (component.blurType.value == BlurType.Box)
						{
							Blit(commandBuffer, cameraColorTargetHandle, blurTexHandle, material, 2);
							Blit(commandBuffer, blurTexHandle, cameraColorTargetHandle, material, 3);
						}
					}
				}
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				CommandBufferPool.Release(commandBuffer);
			}

			public void Dispose()
			{
				blurTexHandle?.Release();
			}

			private static void ExecuteCopyPass(RasterCommandBuffer cmd, RTHandle source, Material material)
			{
				BlurSettings component = VolumeManager.instance.stack.GetComponent<BlurSettings>();
				if (component.strength.value > component.blurStepSize.value * 2)
				{
					if (component.blurType.value == BlurType.Gaussian)
					{
						Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
					}
					else if (component.blurType.value == BlurType.Box)
					{
						Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 2);
					}
				}
			}

			private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle source, Material material)
			{
				BlurSettings component = VolumeManager.instance.stack.GetComponent<BlurSettings>();
				if (component.strength.value > component.blurStepSize.value * 2)
				{
					material.SetInt("_KernelSize", component.strength.value);
					material.SetFloat("_Spread", (float)component.strength.value / 7.5f);
					material.SetInt("_BlurStepSize", component.blurStepSize.value);
					if (component.blurType.value == BlurType.Gaussian)
					{
						Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 1);
					}
					else if (component.blurType.value == BlurType.Box)
					{
						Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 3);
					}
				}
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				BlurSettings component = VolumeManager.instance.stack.GetComponent<BlurSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_BlurColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("Blur_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Blur.cs", 206))
				{
					passData.material = material;
					passData.inputTexture = universalResourceData.activeColorTexture;
					rasterRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture);
					rasterRenderGraphBuilder.SetRenderAttachment(nullHandle, 0);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(CopyPassData data, RasterGraphContext context)
					{
						ExecuteCopyPass(context.cmd, data.inputTexture, data.material);
					});
				}
				MainPassData passData2;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("Blur_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Blur.cs", 217);
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

		private BlurRenderPass pass;

		public override void Create()
		{
			pass = new BlurRenderPass();
			base.name = "Blur";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			BlurSettings component = VolumeManager.instance.stack.GetComponent<BlurSettings>();
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

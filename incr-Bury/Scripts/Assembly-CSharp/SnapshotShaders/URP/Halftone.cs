using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class Halftone : ScriptableRendererFeature
	{
		private class HalftoneRenderPass : ScriptableRenderPass
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

			public HalftoneRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("Halftone");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/Halftone");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/Halftone\".");
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
					HalftoneSettings component = VolumeManager.instance.stack.GetComponent<HalftoneSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					if (component.useSceneColor.value)
					{
						material.EnableKeyword("USE_SCENE_TEXTURE_ON");
					}
					else
					{
						material.DisableKeyword("USE_SCENE_TEXTURE_ON");
					}
					material.SetTexture("_HalftoneTexture", component.halftoneTexture.value);
					material.SetFloat("_Softness", component.softness.value);
					material.SetFloat("_TextureSize", component.textureSize.value);
					material.SetVector("_MinMaxLuminance", component.minMaxLuminance.value);
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
				HalftoneSettings component = VolumeManager.instance.stack.GetComponent<HalftoneSettings>();
				if (component.useSceneColor.value)
				{
					material.EnableKeyword("USE_SCENE_TEXTURE_ON");
				}
				else
				{
					material.DisableKeyword("USE_SCENE_TEXTURE_ON");
				}
				material.SetTexture("_HalftoneTexture", component.halftoneTexture.value);
				material.SetFloat("_Softness", component.softness.value);
				material.SetFloat("_TextureSize", component.textureSize.value);
				material.SetVector("_MinMaxLuminance", component.minMaxLuminance.value);
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
				HalftoneSettings component = VolumeManager.instance.stack.GetComponent<HalftoneSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_HalftoneColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("Halftone_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Halftone.cs", 197))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("Halftone_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Halftone.cs", 207);
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

		private HalftoneRenderPass pass;

		public override void Create()
		{
			pass = new HalftoneRenderPass();
			base.name = "Halftone";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			HalftoneSettings component = VolumeManager.instance.stack.GetComponent<HalftoneSettings>();
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

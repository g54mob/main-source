using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class BasicDither : ScriptableRendererFeature
	{
		private class BasicDitherRenderPass : ScriptableRenderPass
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

			public BasicDitherRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("BasicDither");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/BasicDither");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/BasicDither\".");
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
					BasicDitherSettings component = VolumeManager.instance.stack.GetComponent<BasicDitherSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					material.SetTexture("_NoiseTex", component.noiseTex.value ?? Texture2D.whiteTexture);
					material.SetFloat("_NoiseSize", component.noiseSize.value);
					material.SetFloat("_ThresholdOffset", component.thresholdOffset.value);
					material.SetColor("_DarkColor", component.darkColor.value);
					material.SetColor("_LightColor", component.lightColor.value);
					if (component.useSceneColor.value)
					{
						material.EnableKeyword("USE_SCENE_TEXTURE_ON");
					}
					else
					{
						material.DisableKeyword("USE_SCENE_TEXTURE_ON");
					}
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
				BasicDitherSettings component = VolumeManager.instance.stack.GetComponent<BasicDitherSettings>();
				material.SetTexture("_NoiseTex", component.noiseTex.value ?? Texture2D.whiteTexture);
				material.SetFloat("_NoiseSize", component.noiseSize.value);
				material.SetFloat("_ThresholdOffset", component.thresholdOffset.value);
				material.SetColor("_DarkColor", component.darkColor.value);
				material.SetColor("_LightColor", component.lightColor.value);
				if (component.useSceneColor.value)
				{
					material.EnableKeyword("USE_SCENE_TEXTURE_ON");
				}
				else
				{
					material.DisableKeyword("USE_SCENE_TEXTURE_ON");
				}
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				BasicDitherSettings component = VolumeManager.instance.stack.GetComponent<BasicDitherSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_BasicDitherColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("BasicDither_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\BasicDither.cs", 192))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("BasicDither_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\BasicDither.cs", 202);
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

		private BasicDitherRenderPass pass;

		public override void Create()
		{
			pass = new BasicDitherRenderPass();
			base.name = "Basic Dither";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			BasicDitherSettings component = VolumeManager.instance.stack.GetComponent<BasicDitherSettings>();
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

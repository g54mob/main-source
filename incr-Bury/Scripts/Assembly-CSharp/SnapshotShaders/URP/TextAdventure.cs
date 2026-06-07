using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class TextAdventure : ScriptableRendererFeature
	{
		private class TextAdventureRenderPass : ScriptableRenderPass
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

			private Vector2Int pixelSize;

			public TextAdventureRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("TextAdventure");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/TextAdventure");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/TextAdventure\".");
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
				float num = VolumeManager.instance.stack.GetComponent<TextAdventureSettings>().characterSize.value;
				_ = (float)Screen.height / (float)Screen.width;
				Vector2Int vector2Int = new Vector2Int(Mathf.CeilToInt((float)Screen.width / num), Mathf.CeilToInt((float)Screen.height / num));
				descriptor.width = vector2Int.x;
				descriptor.height = vector2Int.y;
				return descriptor;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				ResetTarget();
				RenderTextureDescriptor descriptor = GetCopyPassDescriptor(cameraTextureDescriptor);
				pixelSize = new Vector2Int(descriptor.width, descriptor.height);
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
					TextAdventureSettings component = VolumeManager.instance.stack.GetComponent<TextAdventureSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					material.SetTexture("_CharacterAtlas", component.characterAtlas.value);
					material.SetInteger("_CharacterCount", component.characterCount.value);
					material.SetVector("_CharacterSize", (Vector2)pixelSize);
					material.SetColor("_BackgroundColor", component.backgroundColor.value);
					material.SetColor("_CharacterColor", component.characterColor.value);
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

			private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle source, Material material, Vector2Int pixelSize)
			{
				TextAdventureSettings component = VolumeManager.instance.stack.GetComponent<TextAdventureSettings>();
				material.SetTexture("_CharacterAtlas", component.characterAtlas.value);
				material.SetInteger("_CharacterCount", component.characterCount.value);
				material.SetVector("_CharacterSize", (Vector2)pixelSize);
				material.SetColor("_BackgroundColor", component.backgroundColor.value);
				material.SetColor("_CharacterColor", component.characterColor.value);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				TextAdventureSettings component = VolumeManager.instance.stack.GetComponent<TextAdventureSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				pixelSize = new Vector2Int(copyPassDescriptor.width, copyPassDescriptor.height);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_TextAdventureColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("TextAdventure_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\TextAdventure.cs", 187))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("TextAdventure_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\TextAdventure.cs", 197);
				passData2.material = material;
				passData2.inputTexture = nullHandle;
				rasterRenderGraphBuilder2.UseTexture(in nullHandle);
				rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder2.SetRenderFunc(delegate(MainPassData data, RasterGraphContext context)
				{
					ExecuteMainPass(context.cmd, data.inputTexture, data.material, pixelSize);
				});
			}
		}

		private TextAdventureRenderPass pass;

		public override void Create()
		{
			pass = new TextAdventureRenderPass();
			base.name = "Text Adventure";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			TextAdventureSettings component = VolumeManager.instance.stack.GetComponent<TextAdventureSettings>();
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

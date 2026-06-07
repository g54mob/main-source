using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	public class Synthwave : ScriptableRendererFeature
	{
		private class SynthwaveRenderPass : ScriptableRenderPass
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

			private static Dictionary<AxisMask, Vector3> axisMasks = new Dictionary<AxisMask, Vector3>
			{
				{
					AxisMask.XY,
					new Vector3(1f, 1f, 0f)
				},
				{
					AxisMask.XZ,
					new Vector3(1f, 0f, 1f)
				},
				{
					AxisMask.YZ,
					new Vector3(0f, 1f, 1f)
				},
				{
					AxisMask.XYZ,
					new Vector3(1f, 1f, 1f)
				}
			};

			public SynthwaveRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("Synthwave");
				base.requiresIntermediateTexture = true;
			}

			private void CreateMaterial()
			{
				Shader shader = Shader.Find("SnapshotProURP/Synthwave");
				if (shader == null)
				{
					Debug.LogError("Cannot find shader: \"SnapshotProURP/Synthwave\".");
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
					SynthwaveSettings component = VolumeManager.instance.stack.GetComponent<SynthwaveSettings>();
					base.renderPassEvent = component.renderPassEvent.value;
					if (component.useSceneColor.value)
					{
						material.EnableKeyword("USE_SCENE_TEXTURE_ON");
					}
					else
					{
						material.DisableKeyword("USE_SCENE_TEXTURE_ON");
						material.SetColor("_BackgroundColor", component.backgroundColor.value);
					}
					material.SetColor("_LineColor1", component.lineColor1.value);
					material.SetColor("_LineColor2", component.lineColor2.value);
					material.SetFloat("_LineColorMix", component.lineColorMix.value);
					material.SetFloat("_LineWidth", component.lineWidth.value);
					material.SetFloat("_LineFalloff", component.lineFalloff.value);
					material.SetVector("_GapWidth", component.gapWidth.value);
					material.SetVector("_Offset", component.offset.value);
					material.SetVector("_AxisMask", axisMasks[component.axisMask.value]);
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
				SynthwaveSettings component = VolumeManager.instance.stack.GetComponent<SynthwaveSettings>();
				if (component.useSceneColor.value)
				{
					material.EnableKeyword("USE_SCENE_TEXTURE_ON");
				}
				else
				{
					material.DisableKeyword("USE_SCENE_TEXTURE_ON");
					material.SetColor("_BackgroundColor", component.backgroundColor.value);
				}
				material.SetColor("_LineColor1", component.lineColor1.value);
				material.SetColor("_LineColor2", component.lineColor2.value);
				material.SetFloat("_LineColorMix", component.lineColorMix.value);
				material.SetFloat("_LineWidth", component.lineWidth.value);
				material.SetFloat("_LineFalloff", component.lineFalloff.value);
				material.SetVector("_GapWidth", component.gapWidth.value);
				material.SetVector("_Offset", component.offset.value);
				material.SetVector("_AxisMask", axisMasks[component.axisMask.value]);
				Blitter.BlitTexture(cmd, source, new Vector4(1f, 1f, 0f, 0f), material, 0);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				if (material == null)
				{
					CreateMaterial();
				}
				SynthwaveSettings component = VolumeManager.instance.stack.GetComponent<SynthwaveSettings>();
				base.renderPassEvent = component.renderPassEvent.value;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				_ = (UniversalRenderer)universalCameraData.renderer;
				RenderTextureDescriptor copyPassDescriptor = GetCopyPassDescriptor(universalCameraData.cameraTargetDescriptor);
				TextureHandle nullHandle = TextureHandle.nullHandle;
				nullHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, copyPassDescriptor, "_SynthwaveColorCopy", clear: false);
				CopyPassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyPassData>("Synthwave_CopyColor", out passData, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Synthwave.cs", 210))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<MainPassData>("Synthwave_MainPass", out passData2, base.profilingSampler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Snapshot Shaders Pro\\URP\\Scripts\\Synthwave.cs", 220);
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

		private SynthwaveRenderPass pass;

		public override void Create()
		{
			pass = new SynthwaveRenderPass();
			base.name = "Synthwave";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			SynthwaveSettings component = VolumeManager.instance.stack.GetComponent<SynthwaveSettings>();
			if (component != null && component.IsActive())
			{
				pass.ConfigureInput(ScriptableRenderPassInput.Depth);
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

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace EPOOutline
{
	public class URPOutlineFeature : ScriptableRendererFeature
	{
		private class SRPOutline : ScriptableRenderPass, IDisposable
		{
			private static FieldInfo nameId = typeof(RenderTargetIdentifier).GetField("m_NameID", BindingFlags.Instance | BindingFlags.NonPublic);

			private static List<Outlinable> temporaryOutlinables = new List<Outlinable>();

			public ScriptableRenderer Renderer;

			public Outliner Outliner;

			private OutlineParameters GraphParameters = new OutlineParameters(null);

			private OutlineParameters Parameters = new OutlineParameters(new BasicCommandBufferWrapper(null));

			private List<Outliner> outliners = new List<Outliner>();

			private UnsafeCommandBufferWrapper wrapper = new UnsafeCommandBufferWrapper();

			private Dictionary<RTHandle, TextureHandle> registeredHandles = new Dictionary<RTHandle, TextureHandle>();

			private void RegisterHandle(RTHandle handle, RenderGraph graph, IUnsafeRenderGraphBuilder builder, AccessFlags flags)
			{
				TextureHandle value = graph.ImportTexture(handle);
				builder.UseTexture(in value, flags);
				registeredHandles[handle] = value;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				MainRenderFunctionParameter passData;
				using (IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<MainRenderFunctionParameter>("EPO Outline", out passData, "D:\\Unity\\FishingIncremental\\Assets\\Plugins\\Easy performant outline\\Scripts\\URP support\\URPOutlineFeature.cs", 53))
				{
					registeredHandles.Clear();
					GraphParameters.RTHandlePool.ReleaseAll();
					passData.RenderTarget = universalResourceData.activeColorTexture;
					passData.DepthTarget = universalResourceData.activeDepthTexture;
					Outlinable.GetAllActiveOutlinables(GraphParameters.OutlinablesToRender);
					RendererFilteringUtility.Filter(universalCameraData.camera, GraphParameters);
					Outliner.UpdateSharedParameters(GraphParameters, universalCameraData.camera, universalCameraData.isSceneViewCamera, forceNative: false, forceHDR: false);
					GraphParameters.TargetWidth = universalCameraData.cameraTargetDescriptor.width;
					GraphParameters.TargetHeight = universalCameraData.cameraTargetDescriptor.height;
					(int, int) scaledSize = GraphParameters.ScaledSize;
					GraphParameters.ScaledBufferWidth = scaledSize.Item1;
					GraphParameters.ScaledBufferHeight = scaledSize.Item2;
					GraphParameters.Antialiasing = universalCameraData.cameraTargetDescriptor.msaaSamples;
					GraphParameters.Viewport = new Rect(0f, 0f, GraphParameters.TargetWidth, GraphParameters.TargetHeight);
					Outliner.ReplaceHandles(GraphParameters);
					unsafeRenderGraphBuilder.UseTexture(in passData.RenderTarget, AccessFlags.ReadWrite);
					unsafeRenderGraphBuilder.UseTexture(in passData.DepthTarget, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.Target, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.InfoTarget, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.PrimaryTarget, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.SecondaryTarget, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.PrimaryInfoBufferTarget, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					RegisterHandle(GraphParameters.Handles.SecondaryInfoBufferTarget, renderGraph, unsafeRenderGraphBuilder, AccessFlags.ReadWrite);
					foreach (KeyValuePair<Texture, RTHandle> item in GraphParameters.TextureHandleMap)
					{
						RegisterHandle(item.Value, renderGraph, unsafeRenderGraphBuilder, AccessFlags.Read);
					}
					wrapper.SetHandleMap(registeredHandles);
					unsafeRenderGraphBuilder.SetRenderFunc(delegate(MainRenderFunctionParameter data, UnsafeGraphContext ctx)
					{
						GraphParameters.Target = data.RenderTarget;
						GraphParameters.DepthTarget = data.DepthTarget;
						wrapper.SetCommandBuffer(ctx.cmd);
						GraphParameters.Buffer = wrapper;
						Setup(GraphParameters);
					});
				}
				BlitRenderFunctionParameter passData2;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<BlitRenderFunctionParameter>("EPO Blit", out passData2, "D:\\Unity\\FishingIncremental\\Assets\\Plugins\\Easy performant outline\\Scripts\\URP support\\URPOutlineFeature.cs", 107);
				rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0, AccessFlags.ReadWrite);
				rasterRenderGraphBuilder.AllowPassCulling(value: false);
				rasterRenderGraphBuilder.AllowGlobalStateModification(value: false);
				rasterRenderGraphBuilder.SetRenderFunc<BlitRenderFunctionParameter>(delegate
				{
				});
			}

			private bool IsDepthTextureAvailable(ScriptableRenderer renderer)
			{
				return renderer.cameraDepthTargetHandle.rt != null;
			}

			private RenderTargetIdentifier GetDepthTarget(ScriptableRenderer renderer)
			{
				return Renderer.cameraDepthTargetHandle;
			}

			private RenderTargetIdentifier GetColorTarget(ScriptableRenderer renderer)
			{
				return renderer.cameraColorTargetHandle;
			}

			private void Setup(OutlineParameters parameters)
			{
				if (Outliner.RenderingStrategy == OutlineRenderingStrategy.Default)
				{
					OutlineEffect.SetupOutline(parameters);
					parameters.BlitMesh = null;
					parameters.MeshPool.ReleaseAllMeshes();
					return;
				}
				temporaryOutlinables.Clear();
				temporaryOutlinables.AddRange(parameters.OutlinablesToRender);
				parameters.OutlinablesToRender.Clear();
				parameters.OutlinablesToRender.Add(null);
				foreach (Outlinable temporaryOutlinable in temporaryOutlinables)
				{
					parameters.OutlinablesToRender[0] = temporaryOutlinable;
					OutlineEffect.SetupOutline(parameters);
					parameters.BlitMesh = null;
				}
				parameters.MeshPool.ReleaseAllMeshes();
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				BasicCommandBufferWrapper basicCommandBufferWrapper = Parameters.Buffer as BasicCommandBufferWrapper;
				if (basicCommandBufferWrapper != null)
				{
					if (basicCommandBufferWrapper.UnderlyingBuffer == null)
					{
						basicCommandBufferWrapper.SetCommandBuffer(new CommandBuffer
						{
							name = "EPO"
						});
					}
					else
					{
						basicCommandBufferWrapper.UnderlyingBuffer.Clear();
					}
				}
				else
				{
					basicCommandBufferWrapper = null;
				}
				Outliner outliner = Outliner;
				if (!(outliner == null) && outliner.enabled)
				{
					Outlinable.GetAllActiveOutlinables(Parameters.OutlinablesToRender);
					Outliner.UpdateSharedParameters(Parameters, renderingData.cameraData.camera, renderingData.cameraData.isSceneViewCamera, forceNative: false, forceHDR: false);
					RendererFilteringUtility.Filter(renderingData.cameraData.camera, Parameters);
					Parameters.TargetWidth = renderingData.cameraData.cameraTargetDescriptor.width;
					Parameters.TargetHeight = renderingData.cameraData.cameraTargetDescriptor.height;
					Parameters.Viewport = new Rect(0f, 0f, Parameters.TargetWidth, Parameters.TargetHeight);
					(int, int) scaledSize = Parameters.ScaledSize;
					Parameters.ScaledBufferWidth = scaledSize.Item1;
					Parameters.ScaledBufferHeight = scaledSize.Item2;
					Parameters.Antialiasing = renderingData.cameraData.cameraTargetDescriptor.msaaSamples;
					Parameters.Target = OutlineEffect.HandleSystem.Alloc(RenderTargetUtility.ComposeTarget(Parameters, GetColorTarget(Renderer)));
					Parameters.DepthTarget = OutlineEffect.HandleSystem.Alloc(RenderTargetUtility.ComposeTarget(Parameters, (!IsDepthTextureAvailable(Renderer)) ? GetColorTarget(Renderer) : GetDepthTarget(Renderer)));
					Outliner.ReplaceHandles(Parameters);
					Setup(Parameters);
					if (basicCommandBufferWrapper != null)
					{
						context.ExecuteCommandBuffer(basicCommandBufferWrapper.UnderlyingBuffer);
					}
				}
			}

			public void Dispose()
			{
				Parameters?.Dispose();
				GraphParameters?.Dispose();
			}
		}

		private class Pool : IDisposable
		{
			private Stack<SRPOutline> outlines = new Stack<SRPOutline>();

			private List<SRPOutline> createdOutlines = new List<SRPOutline>();

			public SRPOutline Get()
			{
				if (outlines.Count != 0)
				{
					return outlines.Pop();
				}
				outlines.Push(new SRPOutline());
				createdOutlines.Add(outlines.Peek());
				return outlines.Pop();
			}

			public void ReleaseAll()
			{
				outlines.Clear();
				foreach (SRPOutline createdOutline in createdOutlines)
				{
					outlines.Push(createdOutline);
				}
			}

			public void Dispose()
			{
				foreach (SRPOutline createdOutline in createdOutlines)
				{
					createdOutline?.Dispose();
				}
			}
		}

		private GameObject lastSelectedCamera;

		private Pool outlinePool = new Pool();

		private List<Outliner> outliners = new List<Outliner>();

		private bool GetOutlinersToRenderWith(RenderingData renderingData, List<Outliner> outliners)
		{
			outliners.Clear();
			GameObject gameObject = renderingData.cameraData.camera.gameObject;
			gameObject.GetComponents(outliners);
			if (outliners.Count == 0)
			{
				return false;
			}
			bool num = outliners.Count > 0;
			if (num)
			{
				lastSelectedCamera = gameObject;
			}
			return num;
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!GetOutlinersToRenderWith(renderingData, outliners))
			{
				return;
			}
			foreach (Outliner outliner in outliners)
			{
				SRPOutline sRPOutline = outlinePool.Get();
				sRPOutline.Outliner = outliner;
				sRPOutline.Renderer = renderer;
				sRPOutline.renderPassEvent = ((outliner.RenderStage == RenderStage.AfterTransparents) ? RenderPassEvent.AfterRenderingTransparents : RenderPassEvent.AfterRenderingOpaques);
				renderer.EnqueuePass(sRPOutline);
			}
			outlinePool.ReleaseAll();
		}

		public override void Create()
		{
		}

		protected override void Dispose(bool disposing)
		{
			outlinePool?.Dispose();
		}
	}
}

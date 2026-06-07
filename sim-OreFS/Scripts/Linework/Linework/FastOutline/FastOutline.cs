using System;
using System.Collections.Generic;
using System.Linq;
using Linework.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.FastOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Fast Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Fast Outline renders outlines by rendering an extruded version of an object behind the original object.")]
	[HelpURL("https://linework.ameye.dev/outlines/fast-outline")]
	public class FastOutline : ScriptableRendererFeature
	{
		private class FastOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal RendererListHandle MaskRendererListHandle;

				internal readonly List<RendererListHandle> OutlineRendererListHandles = new List<RendererListHandle>();
			}

			private FastOutlineSettings settings;

			private Material mask;

			private Material outlineBase;

			private Material outlineInstancedBase;

			private Material clear;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			public FastOutlinePass()
			{
				base.profilingSampler = new ProfilingSampler("FastOutlinePass");
				maskSampler = new ProfilingSampler("Mask (Fast Outline)");
				outlineSampler = new ProfilingSampler("Outline (Fast Outline)");
			}

			public bool Setup(ref FastOutlineSettings fastOutlineSettings, ref Material maskMaterial, ref Material outlineMaterial, ref Material outlineInstancedMaterial, ref Material clearMaterial)
			{
				settings = fastOutlineSettings;
				mask = maskMaterial;
				outlineBase = outlineMaterial;
				outlineInstancedBase = outlineInstancedMaterial;
				clear = clearMaterial;
				base.renderPassEvent = (RenderPassEvent)fastOutlineSettings.InjectionPoint;
				foreach (Outline outline in settings.Outlines)
				{
					if (outline.material == null || outline.materialInstanced == null)
					{
						outline.AssignMaterials(outlineBase, outlineInstancedBase);
					}
				}
				foreach (Outline outline2 in settings.Outlines)
				{
					if (outline2.IsActive())
					{
						Material material = (outline2.gpuInstancing ? outline2.materialInstanced : outline2.material);
						var (value, value2) = RenderUtils.GetSrcDstBlend(outline2.blendMode);
						material.SetInt(CommonShaderPropertyId.BlendModeSource, value);
						material.SetInt(CommonShaderPropertyId.BlendModeDestination, value2);
						switch (outline2.maskingStrategy)
						{
						case MaskingStrategy.Stencil:
							material.SetFloat(CommonShaderPropertyId.CullMode, 0f);
							break;
						case MaskingStrategy.CullFrontFaces:
							material.SetFloat(CommonShaderPropertyId.CullMode, 1f);
							break;
						}
						material.SetColor(CommonShaderPropertyId.OutlineColor, outline2.color);
						material.SetColor(ShaderPropertyId.OutlineOccludedColor, (outline2.occlusion == Occlusion.WhenOccluded) ? outline2.color : outline2.occludedColor);
						material.SetFloat(ShaderPropertyId.OutlineWidth, outline2.width);
						if (outline2.extrusionMethod == ExtrusionMethod.ClipSpaceNormalVector)
						{
							material.SetFloat(ShaderPropertyId.OutlineWidth, outline2.width);
							material.SetFloat(ShaderPropertyId.MinOutlineWidth, outline2.minWidth);
						}
						else
						{
							material.SetFloat(ShaderPropertyId.OutlineWidth, outline2.width * 0.015f);
							material.SetFloat(ShaderPropertyId.MinOutlineWidth, outline2.minWidth * 0.015f);
						}
						if (outline2.enableOcclusion)
						{
							material.EnableKeyword("OCCLUSION");
						}
						else
						{
							material.DisableKeyword("OCCLUSION");
						}
						if (outline2.scaling == Scaling.ScaleWithDistance)
						{
							material.EnableKeyword("SCALE_WITH_DISTANCE");
						}
						else
						{
							material.DisableKeyword("SCALE_WITH_DISTANCE");
						}
						switch (outline2.occlusion)
						{
						case Occlusion.Always:
							material.SetFloat(CommonShaderPropertyId.ZTest, 8f);
							break;
						case Occlusion.WhenOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 7f);
							break;
						case Occlusion.WhenNotOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 4f);
							break;
						default:
							throw new ArgumentOutOfRangeException();
						}
					}
				}
				return settings.Outlines.Any(ShouldRenderOutline);
			}

			private static bool ShouldRenderStencilMask(Outline outline)
			{
				if (outline.IsActive())
				{
					if (outline.maskingStrategy != MaskingStrategy.Stencil)
					{
						return outline.occlusion != Occlusion.WhenNotOccluded;
					}
					return true;
				}
				return false;
			}

			private static bool ShouldRenderOutline(Outline outline)
			{
				return outline.IsActive();
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				PassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Mask (Fast Outline)", out passData, ".\\Packages\\dev.ameye.linework\\Runtime\\FastOutline\\FastOutline.cs", 133))
				{
					rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitMaskRendererList(renderGraph, frameData, ref passData);
					rasterRenderGraphBuilder.UseRendererList(in passData.MaskRendererListHandle);
					rasterRenderGraphBuilder.AllowPassCulling(value: false);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						context.cmd.DrawRendererList(data.MaskRendererListHandle);
					});
				}
				PassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Outline (Fast Outline)", out passData2, ".\\Packages\\dev.ameye.linework\\Runtime\\FastOutline\\FastOutline.cs", 148))
				{
					rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder2.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitOutlineRendererLists(renderGraph, frameData, ref passData2);
					foreach (RendererListHandle outlineRendererListHandle in passData2.OutlineRendererListHandles)
					{
						rasterRenderGraphBuilder2.UseRendererList(outlineRendererListHandle);
					}
					rasterRenderGraphBuilder2.AllowPassCulling(value: false);
					rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (RendererListHandle outlineRendererListHandle2 in data.OutlineRendererListHandles)
						{
							context.cmd.DrawRendererList(outlineRendererListHandle2);
						}
					});
				}
				RenderUtils.ClearStencil(renderGraph, universalResourceData, clear);
			}

			private void InitMaskRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				RenderQueueRange opaque = RenderQueueRange.opaque;
				RenderingLayerMask renderingLayerMask = settings.Outlines.Where(ShouldRenderStencilMask).Aggregate(default(RenderingLayerMask), (RenderingLayerMask current, Outline outline) => (int)current | (int)outline.RenderingLayer);
				FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, renderingLayerMask);
				DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
				drawingSettings.overrideMaterial = mask;
				RenderStateBlock renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
				BlendState defaultValue = BlendState.defaultValue;
				defaultValue.blendState0 = new RenderTargetBlendState((ColorWriteMask)0);
				renderStateBlock.blendState = defaultValue;
				StencilState defaultValue2 = StencilState.defaultValue;
				defaultValue2.enabled = true;
				defaultValue2.SetCompareFunction(CompareFunction.Always);
				defaultValue2.SetPassOperation(StencilOp.Replace);
				defaultValue2.SetFailOperation(StencilOp.Replace);
				defaultValue2.SetZFailOperation(StencilOp.Replace);
				renderStateBlock.mask |= RenderStateMask.Stencil;
				renderStateBlock.stencilReference = 1;
				renderStateBlock.stencilState = defaultValue2;
				RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref passData.MaskRendererListHandle);
			}

			private void InitOutlineRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.OutlineRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				RenderQueueRange opaque = RenderQueueRange.opaque;
				foreach (Outline outline in settings.Outlines)
				{
					if (!ShouldRenderOutline(outline))
					{
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					drawingSettings.overrideMaterial = (outline.gpuInstancing ? outline.materialInstanced : outline.material);
					drawingSettings.overrideMaterialPassIndex = (int)outline.extrusionMethod;
					drawingSettings.enableInstancing = outline.gpuInstancing;
					switch (outline.materialType)
					{
					case MaterialType.Basic:
						drawingSettings.overrideMaterial = (outline.gpuInstancing ? outline.materialInstanced : outline.material);
						drawingSettings.overrideMaterialPassIndex = (int)outline.extrusionMethod;
						drawingSettings.enableInstancing = outline.gpuInstancing;
						break;
					case MaterialType.Custom:
						if (outline.customMaterial != null)
						{
							drawingSettings.overrideMaterial = outline.customMaterial;
						}
						break;
					}
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, outline.RenderingLayer);
					RenderStateBlock renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					if (ShouldRenderStencilMask(outline))
					{
						StencilState defaultValue = StencilState.defaultValue;
						defaultValue.enabled = true;
						defaultValue.SetCompareFunction(CompareFunction.NotEqual);
						defaultValue.SetPassOperation(StencilOp.Zero);
						defaultValue.SetFailOperation(StencilOp.Keep);
						renderStateBlock.mask |= RenderStateMask.Stencil;
						renderStateBlock.stencilReference = 1;
						renderStateBlock.stencilState = defaultValue;
					}
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.OutlineRendererListHandles.Add(rendererListHandle);
				}
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
				ConfigureTarget(cameraDepthRTHandle);
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer, maskSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					SortingCriteria defaultOpaqueSortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
					RenderQueueRange opaque = RenderQueueRange.opaque;
					uint seed = 0u;
					seed = settings.Outlines.Where(ShouldRenderStencilMask).Aggregate(seed, (uint num, Outline outline) => num | (uint)outline.RenderingLayer);
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, seed);
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags);
					drawingSettings.overrideMaterial = mask;
					RenderStateBlock stateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					BlendState defaultValue = BlendState.defaultValue;
					defaultValue.blendState0 = new RenderTargetBlendState((ColorWriteMask)0);
					stateBlock.blendState = defaultValue;
					StencilState defaultValue2 = StencilState.defaultValue;
					defaultValue2.enabled = true;
					defaultValue2.SetCompareFunction(CompareFunction.Always);
					defaultValue2.SetPassOperation(StencilOp.Replace);
					defaultValue2.SetFailOperation(StencilOp.Replace);
					defaultValue2.SetZFailOperation(StencilOp.Replace);
					stateBlock.mask |= RenderStateMask.Stencil;
					stateBlock.stencilReference = 1;
					stateBlock.stencilState = defaultValue2;
					context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings, ref stateBlock);
				}
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
				CommandBuffer commandBuffer2 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer2, outlineSampler))
				{
					CoreUtils.SetRenderTarget(commandBuffer2, renderingData.cameraData.renderer.cameraColorTargetHandle, cameraDepthRTHandle);
					context.ExecuteCommandBuffer(commandBuffer2);
					commandBuffer2.Clear();
					SortingCriteria defaultOpaqueSortFlags2 = renderingData.cameraData.defaultOpaqueSortFlags;
					RenderQueueRange opaque2 = RenderQueueRange.opaque;
					foreach (Outline outline in settings.Outlines)
					{
						if (ShouldRenderOutline(outline))
						{
							DrawingSettings drawingSettings2 = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags2);
							drawingSettings2.overrideMaterial = outline.material;
							drawingSettings2.overrideMaterialPassIndex = (int)outline.extrusionMethod;
							drawingSettings2.perObjectData = PerObjectData.None;
							drawingSettings2.enableInstancing = false;
							FilteringSettings filteringSettings2 = new FilteringSettings(opaque2, -1, outline.RenderingLayer);
							RenderStateBlock stateBlock2 = new RenderStateBlock(RenderStateMask.Nothing);
							if (ShouldRenderStencilMask(outline))
							{
								StencilState defaultValue3 = StencilState.defaultValue;
								defaultValue3.enabled = true;
								defaultValue3.SetCompareFunction(CompareFunction.NotEqual);
								defaultValue3.SetPassOperation(StencilOp.Zero);
								defaultValue3.SetFailOperation(StencilOp.Keep);
								stateBlock2.mask |= RenderStateMask.Stencil;
								stateBlock2.stencilReference = 1;
								stateBlock2.stencilState = defaultValue3;
							}
							context.DrawRenderers(renderingData.cullResults, ref drawingSettings2, ref filteringSettings2, ref stateBlock2);
						}
					}
				}
				context.ExecuteCommandBuffer(commandBuffer2);
				CommandBufferPool.Release(commandBuffer2);
			}

			public void SetTarget(RTHandle depth)
			{
				cameraDepthRTHandle = depth;
			}

			public override void OnCameraCleanup(CommandBuffer cmd)
			{
				if (cmd == null)
				{
					throw new ArgumentNullException("cmd");
				}
				cameraDepthRTHandle = null;
			}

			public void Dispose()
			{
				settings = null;
			}
		}

		[SerializeField]
		private FastOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material outlineMaterial;

		private Material outlineInstancedMaterial;

		private Material clearMaterial;

		private FastOutlinePass fastOutlinePass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				FastOutlineSettings fastOutlineSettings = settings;
				fastOutlineSettings.OnSettingsChanged = (Action)Delegate.Combine(fastOutlineSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (fastOutlinePass == null)
				{
					fastOutlinePass = new FastOutlinePass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(settings == null) && renderingData.cameraData.cameraType != CameraType.Preview && renderingData.cameraData.cameraType != CameraType.Reflection && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView) && !UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				if (!CreateMaterials())
				{
					Debug.LogWarning("Not all required materials could be created. Fast Outline will not render.");
				}
				else if (fastOutlinePass.Setup(ref settings, ref maskMaterial, ref outlineMaterial, ref outlineInstancedMaterial, ref clearMaterial))
				{
					renderer.EnqueuePass(fastOutlinePass);
				}
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(settings == null) && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView))
			{
				fastOutlinePass.SetTarget(renderer.cameraDepthTargetHandle);
			}
		}

		protected override void Dispose(bool disposing)
		{
			fastOutlinePass?.Dispose();
			fastOutlinePass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			fastOutlinePass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(maskMaterial);
			CoreUtils.Destroy(outlineMaterial);
			CoreUtils.Destroy(outlineInstancedMaterial);
			CoreUtils.Destroy(clearMaterial);
		}

		private bool CreateMaterials()
		{
			if (maskMaterial == null)
			{
				maskMaterial = CoreUtils.CreateEngineMaterial(shaders.mask);
			}
			if (outlineMaterial == null)
			{
				outlineMaterial = CoreUtils.CreateEngineMaterial(shaders.outline);
			}
			if (outlineInstancedMaterial == null)
			{
				outlineInstancedMaterial = CoreUtils.CreateEngineMaterial(shaders.outlineInstanced);
			}
			if (clearMaterial == null)
			{
				clearMaterial = CoreUtils.CreateEngineMaterial(shaders.clear);
			}
			if (maskMaterial != null && outlineMaterial != null && outlineInstancedMaterial != null)
			{
				return clearMaterial != null;
			}
			return false;
		}
	}
}

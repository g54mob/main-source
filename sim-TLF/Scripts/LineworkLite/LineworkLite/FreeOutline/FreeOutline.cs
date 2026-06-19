using System;
using System.Collections.Generic;
using System.Linq;
using LineworkLite.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace LineworkLite.FreeOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Free Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Free Outline renders outlines by rendering an extruded version of an object behind the original object.")]
	[HelpURL("https://linework.ameye.dev/free-outline")]
	public class FreeOutline : ScriptableRendererFeature
	{
		private class FreeOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> maskRendererListHandles = new List<RendererListHandle>();

				internal readonly List<RendererListHandle> outlineRendererListHandles = new List<RendererListHandle>();
			}

			private FreeOutlineSettings settings;

			private Material mask;

			private Material outlineBase;

			private Material clear;

			public FreeOutlinePass()
			{
				base.profilingSampler = new ProfilingSampler("FreeOutlinePass");
			}

			public bool Setup(ref FreeOutlineSettings freeOutlineSettings, ref Material maskMaterial, ref Material outlineMaterial, ref Material clearMaterial)
			{
				settings = freeOutlineSettings;
				mask = maskMaterial;
				outlineBase = outlineMaterial;
				clear = clearMaterial;
				base.renderPassEvent = (RenderPassEvent)freeOutlineSettings.InjectionPoint;
				foreach (Outline outline in settings.Outlines)
				{
					if (outline.material == null)
					{
						outline.AssignMaterials(outlineBase);
					}
				}
				foreach (Outline outline2 in settings.Outlines)
				{
					if (outline2.IsActive())
					{
						Material material = outline2.material;
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
						if (outline2.scaleWithResolution)
						{
							material.EnableKeyword("SCALE_WITH_RESOLUTION");
						}
						else
						{
							material.DisableKeyword("SCALE_WITH_RESOLUTION");
						}
						switch (outline2.referenceResolution)
						{
						case Resolution._480:
							material.SetFloat(ShaderPropertyId.ReferenceResolution, 480f);
							break;
						case Resolution._720:
							material.SetFloat(ShaderPropertyId.ReferenceResolution, 720f);
							break;
						case Resolution._1080:
							material.SetFloat(ShaderPropertyId.ReferenceResolution, 1080f);
							break;
						case Resolution.Custom:
							material.SetFloat(ShaderPropertyId.ReferenceResolution, outline2.customResolution);
							break;
						}
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
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Mask (Free Outline)", out passData, ".\\Packages\\dev.ameye.linework-lite\\Runtime\\FreeOutline\\FreeOutline.cs", 158))
				{
					rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitMaskRendererList(renderGraph, frameData, ref passData);
					foreach (RendererListHandle maskRendererListHandle in passData.maskRendererListHandles)
					{
						rasterRenderGraphBuilder.UseRendererList(maskRendererListHandle);
					}
					rasterRenderGraphBuilder.AllowPassCulling(value: false);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (RendererListHandle maskRendererListHandle2 in data.maskRendererListHandles)
						{
							context.cmd.DrawRendererList(maskRendererListHandle2);
						}
					});
				}
				PassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Outline (Free Outline)", out passData2, ".\\Packages\\dev.ameye.linework-lite\\Runtime\\FreeOutline\\FreeOutline.cs", 182))
				{
					rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder2.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitOutlineRendererLists(renderGraph, frameData, ref passData2);
					foreach (RendererListHandle outlineRendererListHandle in passData2.outlineRendererListHandles)
					{
						rasterRenderGraphBuilder2.UseRendererList(outlineRendererListHandle);
					}
					rasterRenderGraphBuilder2.AllowPassCulling(value: false);
					rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (RendererListHandle outlineRendererListHandle2 in data.outlineRendererListHandles)
						{
							context.cmd.DrawRendererList(outlineRendererListHandle2);
						}
					});
				}
				RenderUtils.ClearStencil(renderGraph, universalResourceData, clear);
			}

			private void InitMaskRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.maskRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				foreach (Outline outline in settings.Outlines)
				{
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					drawingSettings.overrideMaterial = mask;
					FilteringSettings filteringSettings = new FilteringSettings(outline.renderQueue switch
					{
						OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
						OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
						OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
						_ => throw new ArgumentOutOfRangeException(), 
					}, outline.layerMask, outline.RenderingLayer);
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
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.maskRendererListHandles.Add(rendererListHandle);
				}
			}

			private void InitOutlineRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.outlineRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				foreach (Outline outline in settings.Outlines)
				{
					if (!ShouldRenderOutline(outline))
					{
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					switch (outline.materialType)
					{
					case MaterialType.Basic:
						drawingSettings.overrideMaterial = outline.material;
						drawingSettings.overrideMaterialPassIndex = (int)outline.extrusionMethod;
						drawingSettings.enableInstancing = false;
						break;
					case MaterialType.Custom:
						if (outline.customMaterial != null)
						{
							drawingSettings.overrideMaterial = outline.customMaterial;
						}
						break;
					}
					FilteringSettings filteringSettings = new FilteringSettings(outline.renderQueue switch
					{
						OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
						OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
						OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
						_ => throw new ArgumentOutOfRangeException(), 
					}, outline.layerMask, outline.RenderingLayer);
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
					passData.outlineRendererListHandles.Add(rendererListHandle);
				}
			}

			public void Dispose()
			{
				settings = null;
			}
		}

		[SerializeField]
		private FreeOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material outlineMaterial;

		private Material clearMaterial;

		private FreeOutlinePass freeOutlinePass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				FreeOutlineSettings freeOutlineSettings = settings;
				freeOutlineSettings.OnSettingsChanged = (Action)Delegate.Combine(freeOutlineSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (freeOutlinePass == null)
				{
					freeOutlinePass = new FreeOutlinePass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(settings == null) && freeOutlinePass != null && renderingData.cameraData.cameraType != CameraType.Preview && renderingData.cameraData.cameraType != CameraType.Reflection && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView) && !UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				if (!CreateMaterials())
				{
					Debug.LogWarning("Not all required materials could be created. Free Outline will not render.");
				}
				else if (freeOutlinePass.Setup(ref settings, ref maskMaterial, ref outlineMaterial, ref clearMaterial))
				{
					renderer.EnqueuePass(freeOutlinePass);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			freeOutlinePass?.Dispose();
			freeOutlinePass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			freeOutlinePass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(maskMaterial);
			CoreUtils.Destroy(outlineMaterial);
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
			if (clearMaterial == null)
			{
				clearMaterial = CoreUtils.CreateEngineMaterial(shaders.clear);
			}
			if (maskMaterial != null && outlineMaterial != null)
			{
				return clearMaterial != null;
			}
			return false;
		}
	}
}

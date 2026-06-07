using System;
using System.Collections.Generic;
using System.Linq;
using Linework.Common.Utils;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.WideOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Wide Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Wide Outline renders an outline by generating a signed distance field (SDF) for each object and then sampling it. This creates consistent outlines that smoothly follows the shape of an object.")]
	[HelpURL("https://linework.ameye.dev/wide-outline")]
	public class WideOutline : ScriptableRendererFeature
	{
		private class WideOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles = new List<RendererListHandle>();

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> SilhouetteRendererListHandles = new List<(RendererListHandle, bool)>();

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> InformationRendererListHandles = new List<(RendererListHandle, bool)>();
			}

			private WideOutlineSettings settings;

			private Material mask;

			private Material silhouetteBase;

			private Material silhouetteInstancedBase;

			private Material composite;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler silhouetteSampler;

			private readonly ProfilingSampler informationSampler;

			private readonly ProfilingSampler floodSampler;

			private readonly ProfilingSampler outlineSampler;

			private float maxwidth;

			private RTHandle cameraDepthRTHandle;

			private RTHandle silhouetteRTHandle;

			private RTHandle silhouetteDepthRTHandle;

			private RTHandle pingRTHandle;

			private RTHandle pongRTHandle;

			public WideOutlinePass()
			{
				base.profilingSampler = new ProfilingSampler("WideOutlinePass");
				maskSampler = new ProfilingSampler("Mask (Wide Outline)");
				silhouetteSampler = new ProfilingSampler("Silhouette (Wide Outline)");
				informationSampler = new ProfilingSampler("Information (Wide Outline)");
				floodSampler = new ProfilingSampler("Flood (Wide Outline)");
				outlineSampler = new ProfilingSampler("Outline (Wide Outline)");
			}

			public bool Setup(ref WideOutlineSettings wideOutlineSettings, ref Material maskMaterial, ref Material silhouetteMaterial, ref Material silhouetteInstancedMaterial, ref Material compositeMaterial, float renderScale)
			{
				settings = wideOutlineSettings;
				mask = maskMaterial;
				silhouetteBase = silhouetteMaterial;
				silhouetteInstancedBase = silhouetteInstancedMaterial;
				composite = compositeMaterial;
				base.renderPassEvent = (RenderPassEvent)wideOutlineSettings.InjectionPoint;
				foreach (Outline outline in settings.Outlines)
				{
					if (outline.silhouetteMaterial == null || outline.silhouetteMaterialInstanced == null || outline.informationMaterial == null || outline.informationMaterialInstanced == null)
					{
						outline.AssignMaterials(silhouetteBase, silhouetteInstancedBase);
					}
				}
				foreach (Outline outline2 in settings.Outlines)
				{
					if (!outline2.IsActive())
					{
						continue;
					}
					Material material = (outline2.gpuInstancing ? outline2.silhouetteMaterialInstanced : outline2.silhouetteMaterial);
					Material material2 = (outline2.gpuInstancing ? outline2.informationMaterialInstanced : outline2.informationMaterial);
					material.SetColor(CommonShaderPropertyId.OutlineColor, outline2.color);
					if (outline2.occlusion == WideOutlineOcclusion.AsMask)
					{
						material.SetColor(CommonShaderPropertyId.OutlineColor, Color.clear);
					}
					if (outline2.alphaCutout)
					{
						material.EnableKeyword("ALPHA_CUTOUT");
					}
					else
					{
						material.DisableKeyword("ALPHA_CUTOUT");
					}
					material.SetTexture(CommonShaderPropertyId.AlphaCutoutTexture, outline2.alphaCutoutTexture);
					material.SetFloat(CommonShaderPropertyId.AlphaCutoutThreshold, outline2.alphaCutoutThreshold);
					material.SetVector(CommonShaderPropertyId.AlphaCutoutUVTransform, outline2.alphaCutoutUVTransform);
					switch (outline2.cullingMode)
					{
					case CullingMode.Off:
						material.SetFloat(CommonShaderPropertyId.CullMode, 0f);
						break;
					case CullingMode.Back:
						material.SetFloat(CommonShaderPropertyId.CullMode, 2f);
						break;
					}
					if (settings.customDepthBuffer)
					{
						material.SetFloat(CommonShaderPropertyId.ZTest, 4f);
					}
					else
					{
						switch (outline2.occlusion)
						{
						case WideOutlineOcclusion.Always:
							material.SetFloat(CommonShaderPropertyId.ZTest, 8f);
							break;
						case WideOutlineOcclusion.WhenOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 5f);
							break;
						case WideOutlineOcclusion.WhenNotOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 4f);
							break;
						case WideOutlineOcclusion.AsMask:
							material.SetFloat(CommonShaderPropertyId.ZTest, 8f);
							break;
						default:
							throw new ArgumentOutOfRangeException();
						}
					}
					material.SetFloat(CommonShaderPropertyId.ZWrite, settings.customDepthBuffer ? 1f : 0f);
					if (settings.widthControl == WidthControl.PerOutline)
					{
						material2.EnableKeyword("INFORMATION_BUFFER");
					}
					else
					{
						material2.DisableKeyword("INFORMATION_BUFFER");
					}
					if (outline2.width > maxwidth)
					{
						maxwidth = outline2.width;
					}
					material2.SetVector(CommonShaderPropertyId.Information, new Vector4(outline2.width / 100f, 0f, 0f, 0f));
				}
				var (value, value2) = RenderUtils.GetSrcDstBlend(settings.blendMode);
				composite.SetInt(CommonShaderPropertyId.BlendModeSource, value);
				composite.SetInt(CommonShaderPropertyId.BlendModeDestination, value2);
				composite.SetColor(ShaderPropertyId.OutlineOccludedColor, settings.occludedColor);
				composite.SetFloat(ShaderPropertyId.OutlineWidth, settings.sharedWidth);
				composite.SetFloat(ShaderPropertyId.OutlineGap, settings.gap);
				composite.SetFloat(ShaderPropertyId.RenderScale, renderScale);
				if (settings.customDepthBuffer)
				{
					composite.EnableKeyword("CUSTOM_DEPTH");
				}
				else
				{
					composite.DisableKeyword("CUSTOM_DEPTH");
				}
				if (settings.widthControl == WidthControl.PerOutline)
				{
					composite.EnableKeyword("INFORMATION_BUFFER");
				}
				else
				{
					composite.DisableKeyword("INFORMATION_BUFFER");
				}
				if (settings.materialType == MaterialType.Custom && settings.customMaterial != null)
				{
					settings.customMaterial.SetFloat(ShaderPropertyId.OutlineWidth, settings.sharedWidth);
				}
				return settings.Outlines.Any(ShouldRenderOutline);
			}

			private static bool ShouldRenderOutline(Outline outline)
			{
				if (outline.IsActive())
				{
					return outline.occlusion != WideOutlineOcclusion.AsMask;
				}
				return false;
			}

			private static bool ShouldRenderStencilMask(Outline outline)
			{
				if (outline.IsActive())
				{
					return outline.occlusion == WideOutlineOcclusion.WhenOccluded;
				}
				return false;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
				if (universalResourceData.isActiveTargetBackBuffer)
				{
					return;
				}
				CreateRenderGraphTextures(renderGraph, universalResourceData, out var silhouetteHandle, out var silhouetteDepthHandle, out var informationHandle, out var pingHandle, out var pongHandle);
				if (!silhouetteHandle.IsValid() || !silhouetteDepthHandle.IsValid() || !informationHandle.IsValid() || !pingHandle.IsValid() || !pongHandle.IsValid())
				{
					return;
				}
				PassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Mask (Wide Outline)", out passData, "./Packages/dev.ameye.linework/Runtime/WideOutline/WideOutline.cs", 176))
				{
					rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitMaskRendererLists(renderGraph, frameData, ref passData);
					foreach (RendererListHandle maskRendererListHandle in passData.MaskRendererListHandles)
					{
						rasterRenderGraphBuilder.UseRendererList(maskRendererListHandle);
					}
					rasterRenderGraphBuilder.AllowPassCulling(value: true);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (RendererListHandle maskRendererListHandle2 in data.MaskRendererListHandles)
						{
							context.cmd.DrawRendererList(maskRendererListHandle2);
						}
					});
				}
				PassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Silhouette (Wide Outline)", out passData2, "./Packages/dev.ameye.linework/Runtime/WideOutline/WideOutline.cs", 200))
				{
					rasterRenderGraphBuilder2.SetRenderAttachment(silhouetteHandle, 0);
					rasterRenderGraphBuilder2.SetRenderAttachmentDepth(settings.customDepthBuffer ? silhouetteDepthHandle : universalResourceData.activeDepthTexture);
					rasterRenderGraphBuilder2.SetGlobalTextureAfterPass(in silhouetteHandle, ShaderPropertyId.SilhouetteBuffer);
					if (settings.customDepthBuffer)
					{
						rasterRenderGraphBuilder2.SetGlobalTextureAfterPass(in silhouetteDepthHandle, ShaderPropertyId.SilhouetteDepthBuffer);
					}
					InitSilhouetteRendererLists(renderGraph, frameData, ref passData2);
					foreach (var silhouetteRendererListHandle in passData2.SilhouetteRendererListHandles)
					{
						(RendererListHandle, bool) current = silhouetteRendererListHandle;
						rasterRenderGraphBuilder2.UseRendererList(in current.Item1);
					}
					rasterRenderGraphBuilder2.AllowGlobalStateModification(value: true);
					rasterRenderGraphBuilder2.AllowPassCulling(value: true);
					rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (var silhouetteRendererListHandle2 in data.SilhouetteRendererListHandles)
						{
							if (silhouetteRendererListHandle2.vertexAnimated)
							{
								context.cmd.EnableKeyword(in Keyword.OutlineColor);
							}
							context.cmd.DrawRendererList(silhouetteRendererListHandle2.handle);
							if (silhouetteRendererListHandle2.vertexAnimated)
							{
								context.cmd.DisableKeyword(in Keyword.OutlineColor);
							}
						}
					});
				}
				if (settings.widthControl == WidthControl.PerOutline)
				{
					PassData passData3;
					using IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<PassData>("Information (Wide Outline)", out passData3, "./Packages/dev.ameye.linework/Runtime/WideOutline/WideOutline.cs", 242);
					rasterRenderGraphBuilder3.SetRenderAttachment(informationHandle, 0);
					rasterRenderGraphBuilder3.SetGlobalTextureAfterPass(in informationHandle, ShaderPropertyId.InformationBuffer);
					InitInformationRendererList(renderGraph, frameData, ref passData3);
					foreach (var informationRendererListHandle in passData3.InformationRendererListHandles)
					{
						(RendererListHandle, bool) current2 = informationRendererListHandle;
						rasterRenderGraphBuilder3.UseRendererList(in current2.Item1);
					}
					rasterRenderGraphBuilder3.AllowGlobalStateModification(value: true);
					rasterRenderGraphBuilder3.AllowPassCulling(value: false);
					rasterRenderGraphBuilder3.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (var informationRendererListHandle2 in data.InformationRendererListHandles)
						{
							context.cmd.DrawRendererList(informationRendererListHandle2.handle);
						}
					});
				}
				PassData passData4;
				using (IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Flood (Wide Outline)", out passData4, "./Packages/dev.ameye.linework/Runtime/WideOutline/WideOutline.cs", 268))
				{
					unsafeRenderGraphBuilder.UseTexture(in silhouetteHandle);
					unsafeRenderGraphBuilder.UseTexture(in pingHandle, AccessFlags.ReadWrite);
					unsafeRenderGraphBuilder.UseTexture(in pongHandle, AccessFlags.ReadWrite);
					unsafeRenderGraphBuilder.AllowPassCulling(value: true);
					unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData _, UnsafeGraphContext context)
					{
						CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
						Blitter.BlitCameraTexture(nativeCommandBuffer, silhouetteHandle, pingHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, composite, 1);
						for (int num = Mathf.CeilToInt(Mathf.Log(((settings.widthControl == WidthControl.Shared) ? settings.sharedWidth : maxwidth) * cameraData.renderScale + 1f, 2f)) - 1; num >= 0; num--)
						{
							float num2 = Mathf.Pow(2f, num) + 0.5f;
							nativeCommandBuffer.SetGlobalVector(ShaderPropertyId.AxisWidthId, new Vector2(num2, 0f));
							Blitter.BlitCameraTexture(nativeCommandBuffer, pingHandle, pongHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, composite, 2);
							nativeCommandBuffer.SetGlobalVector(ShaderPropertyId.AxisWidthId, new Vector2(0f, num2));
							Blitter.BlitCameraTexture(nativeCommandBuffer, pongHandle, pingHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, composite, 2);
						}
					});
				}
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder4 = renderGraph.AddRasterRenderPass<PassData>("Outline (Wide Outline)", out passData4, "./Packages/dev.ameye.linework/Runtime/WideOutline/WideOutline.cs", 299);
				rasterRenderGraphBuilder4.UseTexture(in informationHandle);
				rasterRenderGraphBuilder4.UseTexture(in pingHandle);
				rasterRenderGraphBuilder4.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder4.SetRenderAttachmentDepth(settings.customDepthBuffer ? silhouetteDepthHandle : universalResourceData.activeDepthTexture);
				rasterRenderGraphBuilder4.AllowPassCulling(value: true);
				rasterRenderGraphBuilder4.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
				{
					switch (settings.materialType)
					{
					case MaterialType.Basic:
						Blitter.BlitTexture(context.cmd, pingHandle, Vector2.one, composite, 3);
						break;
					case MaterialType.Custom:
						if (settings.customMaterial != null)
						{
							Blitter.BlitTexture(context.cmd, pingHandle, Vector2.one, settings.customMaterial, 0);
						}
						break;
					}
				});
			}

			private void InitMaskRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.MaskRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				int num = 0;
				foreach (Outline outline in settings.Outlines)
				{
					if (!ShouldRenderStencilMask(outline))
					{
						num++;
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					drawingSettings.overrideMaterial = mask;
					drawingSettings.overrideShaderPassIndex = 0;
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
					defaultValue2.SetFailOperation(StencilOp.Keep);
					defaultValue2.SetZFailOperation(StencilOp.Keep);
					defaultValue2.writeMask = (byte)(1 << num);
					renderStateBlock.mask |= RenderStateMask.Stencil;
					renderStateBlock.stencilReference = 1 << num;
					renderStateBlock.stencilState = defaultValue2;
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.MaskRendererListHandles.Add(rendererListHandle);
				}
			}

			private void InitSilhouetteRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.SilhouetteRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				int num = 0;
				foreach (Outline outline in settings.Outlines)
				{
					if (!outline.IsActive())
					{
						num++;
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					if (!outline.vertexAnimation)
					{
						drawingSettings.overrideMaterial = (outline.gpuInstancing ? outline.silhouetteMaterialInstanced : outline.silhouetteMaterial);
						drawingSettings.overrideMaterialPassIndex = 0;
						drawingSettings.enableInstancing = outline.gpuInstancing;
					}
					FilteringSettings filteringSettings = new FilteringSettings(outline.renderQueue switch
					{
						OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
						OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
						OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
						_ => throw new ArgumentOutOfRangeException(), 
					}, outline.layerMask, outline.RenderingLayer);
					RenderStateBlock renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					StencilState defaultValue = StencilState.defaultValue;
					defaultValue.enabled = true;
					defaultValue.SetCompareFunction((outline.occlusion == WideOutlineOcclusion.WhenOccluded) ? CompareFunction.NotEqual : CompareFunction.Always);
					defaultValue.SetPassOperation(StencilOp.Replace);
					defaultValue.SetFailOperation(StencilOp.Keep);
					defaultValue.SetZFailOperation((!outline.closedLoop) ? StencilOp.Replace : StencilOp.Keep);
					defaultValue.readMask = (byte)(1 << num);
					defaultValue.writeMask = (byte)(1 << num);
					renderStateBlock.mask |= RenderStateMask.Stencil;
					renderStateBlock.stencilReference = 1 << num;
					renderStateBlock.stencilState = defaultValue;
					if (outline.vertexAnimation)
					{
						DepthState defaultValue2 = DepthState.defaultValue;
						switch (outline.occlusion)
						{
						case WideOutlineOcclusion.Always:
							defaultValue2.compareFunction = CompareFunction.Always;
							break;
						case WideOutlineOcclusion.WhenOccluded:
							defaultValue2.compareFunction = CompareFunction.Greater;
							break;
						case WideOutlineOcclusion.WhenNotOccluded:
							defaultValue2.compareFunction = CompareFunction.LessEqual;
							break;
						case WideOutlineOcclusion.AsMask:
							defaultValue2.compareFunction = CompareFunction.Always;
							break;
						}
						renderStateBlock.mask |= RenderStateMask.Depth;
						renderStateBlock.depthState = defaultValue2;
					}
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.SilhouetteRendererListHandles.Add((rendererListHandle, outline.vertexAnimation));
					num++;
				}
			}

			private void InitInformationRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.InformationRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				int num = 0;
				foreach (Outline outline in settings.Outlines)
				{
					if (!outline.IsActive())
					{
						num++;
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					if (!outline.vertexAnimation)
					{
						drawingSettings.overrideMaterial = (outline.gpuInstancing ? outline.informationMaterialInstanced : outline.informationMaterial);
						drawingSettings.overrideMaterialPassIndex = 0;
						drawingSettings.enableInstancing = outline.gpuInstancing;
					}
					FilteringSettings filteringSettings = new FilteringSettings(outline.renderQueue switch
					{
						OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
						OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
						OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
						_ => throw new ArgumentOutOfRangeException(), 
					}, outline.layerMask, outline.RenderingLayer);
					RenderStateBlock renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					StencilState defaultValue = StencilState.defaultValue;
					defaultValue.enabled = true;
					defaultValue.SetCompareFunction((outline.occlusion == WideOutlineOcclusion.WhenOccluded) ? CompareFunction.NotEqual : CompareFunction.Always);
					defaultValue.SetPassOperation(StencilOp.Replace);
					defaultValue.SetFailOperation(StencilOp.Keep);
					defaultValue.SetZFailOperation((!outline.closedLoop) ? StencilOp.Replace : StencilOp.Keep);
					defaultValue.readMask = (byte)(1 << num);
					defaultValue.writeMask = (byte)(1 << num);
					renderStateBlock.mask |= RenderStateMask.Stencil;
					renderStateBlock.stencilReference = 1 << num;
					renderStateBlock.stencilState = defaultValue;
					if (outline.vertexAnimation)
					{
						DepthState defaultValue2 = DepthState.defaultValue;
						switch (outline.occlusion)
						{
						case WideOutlineOcclusion.Always:
							defaultValue2.compareFunction = CompareFunction.Always;
							break;
						case WideOutlineOcclusion.WhenOccluded:
							defaultValue2.compareFunction = CompareFunction.Greater;
							break;
						case WideOutlineOcclusion.WhenNotOccluded:
							defaultValue2.compareFunction = CompareFunction.LessEqual;
							break;
						case WideOutlineOcclusion.AsMask:
							defaultValue2.compareFunction = CompareFunction.Always;
							break;
						}
						renderStateBlock.mask |= RenderStateMask.Depth;
						renderStateBlock.depthState = defaultValue2;
					}
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.InformationRendererListHandles.Add((rendererListHandle, outline.vertexAnimation));
					num++;
				}
			}

			private static void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalResourceData resourceData, out TextureHandle silhouetteHandle, out TextureHandle silhouetteDepthHandle, out TextureHandle informationHandle, out TextureHandle pingHandle, out TextureHandle pongHandle)
			{
				TextureDesc descriptor = resourceData.activeColorTexture.GetDescriptor(renderGraph);
				int width = (int)((float)descriptor.width * 1f);
				int height = (int)((float)descriptor.height * 1f);
				TextureDesc textureDesc = new TextureDesc(width, height);
				textureDesc.dimension = TextureDimension.Tex2D;
				textureDesc.msaaSamples = descriptor.msaaSamples;
				textureDesc.useMipMap = false;
				textureDesc.autoGenerateMips = false;
				TextureDesc desc = textureDesc;
				desc.name = "_SilhouetteBuffer";
				desc.colorFormat = GraphicsFormat.R8G8B8A8_UNorm;
				desc.depthBufferBits = DepthBits.None;
				silhouetteHandle = renderGraph.CreateTexture(in desc);
				desc.name = "_SilhouetteDepthBuffer";
				desc.colorFormat = GraphicsFormat.None;
				desc.depthBufferBits = DepthBits.Depth32;
				silhouetteDepthHandle = renderGraph.CreateTexture(in desc);
				desc.name = "_InformationBuffer";
				desc.colorFormat = (SystemInfo.IsFormatSupported(GraphicsFormat.R16_SNorm, GraphicsFormatUsage.Render) ? GraphicsFormat.R16_SNorm : GraphicsFormat.R16_SFloat);
				desc.depthBufferBits = DepthBits.None;
				informationHandle = renderGraph.CreateTexture(in desc);
				desc.name = "_PingBuffer";
				desc.colorFormat = (SystemInfo.IsFormatSupported(GraphicsFormat.R16G16_SNorm, GraphicsFormatUsage.Render) ? GraphicsFormat.R16G16_SNorm : GraphicsFormat.R32G32_SFloat);
				desc.depthBufferBits = DepthBits.None;
				pingHandle = renderGraph.CreateTexture(in desc);
				desc.name = "_PongBuffer";
				pongHandle = renderGraph.CreateTexture(in desc);
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
				ConfigureTarget(silhouetteRTHandle, settings.customDepthBuffer ? silhouetteDepthRTHandle : renderingData.cameraData.renderer.cameraDepthTargetHandle);
				ConfigureClear((!settings.customDepthBuffer) ? ClearFlag.Color : ClearFlag.All, Color.clear);
			}

			public void CreateHandles(RenderingData renderingData)
			{
				int width = (int)((float)renderingData.cameraData.cameraTargetDescriptor.width * 1f);
				int height = (int)((float)renderingData.cameraData.cameraTargetDescriptor.height * 1f);
				RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(width, height);
				renderTextureDescriptor.dimension = TextureDimension.Tex2D;
				renderTextureDescriptor.msaaSamples = 1;
				renderTextureDescriptor.sRGB = false;
				renderTextureDescriptor.useMipMap = false;
				renderTextureDescriptor.autoGenerateMips = false;
				renderTextureDescriptor.graphicsFormat = GraphicsFormat.R8G8B8A8_UNorm;
				renderTextureDescriptor.depthBufferBits = 0;
				renderTextureDescriptor.colorFormat = RenderTextureFormat.Default;
				RenderTextureDescriptor descriptor = renderTextureDescriptor;
				RenderingUtils.ReAllocateIfNeeded(ref silhouetteRTHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_SilhouetteBuffer");
				RenderTextureDescriptor descriptor2 = renderingData.cameraData.cameraTargetDescriptor;
				descriptor2.graphicsFormat = GraphicsFormat.None;
				descriptor2.depthBufferBits = 32;
				descriptor2.msaaSamples = 1;
				RenderingUtils.ReAllocateIfNeeded(ref silhouetteDepthRTHandle, in descriptor2, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_SilhouetteDepthBuffer");
				RenderTextureDescriptor descriptor3 = renderingData.cameraData.cameraTargetDescriptor;
				descriptor3.graphicsFormat = (SystemInfo.IsFormatSupported(GraphicsFormat.R16G16_SNorm, FormatUsage.Render) ? GraphicsFormat.R16G16_SNorm : GraphicsFormat.R32G32_SFloat);
				descriptor3.depthBufferBits = 0;
				descriptor3.msaaSamples = 1;
				RenderingUtils.ReAllocateIfNeeded(ref pingRTHandle, in descriptor3, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_PingBuffer");
				RenderingUtils.ReAllocateIfNeeded(ref pongRTHandle, in descriptor3, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_PongBuffer");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer, maskSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					SortingCriteria defaultOpaqueSortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
					int num = 0;
					foreach (Outline outline in settings.Outlines)
					{
						if (!ShouldRenderStencilMask(outline))
						{
							num++;
							continue;
						}
						RenderQueueRange value = outline.renderQueue switch
						{
							OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
							OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
							OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
							_ => throw new ArgumentOutOfRangeException(), 
						};
						DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags);
						drawingSettings.overrideMaterial = mask;
						FilteringSettings filteringSettings = new FilteringSettings(value, outline.layerMask, outline.RenderingLayer);
						RenderStateBlock stateBlock = new RenderStateBlock(RenderStateMask.Nothing);
						BlendState defaultValue = BlendState.defaultValue;
						defaultValue.blendState0 = new RenderTargetBlendState((ColorWriteMask)0);
						stateBlock.blendState = defaultValue;
						StencilState defaultValue2 = StencilState.defaultValue;
						defaultValue2.enabled = true;
						defaultValue2.SetCompareFunction(CompareFunction.Always);
						defaultValue2.SetPassOperation(StencilOp.Replace);
						defaultValue2.SetFailOperation(StencilOp.Keep);
						defaultValue2.SetZFailOperation(StencilOp.Keep);
						defaultValue2.writeMask = (byte)(1 << num);
						stateBlock.mask |= RenderStateMask.Stencil;
						stateBlock.stencilReference = 1 << num;
						stateBlock.stencilState = defaultValue2;
						context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings, ref stateBlock);
						num++;
					}
				}
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
				CommandBuffer commandBuffer2 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer2, silhouetteSampler))
				{
					CoreUtils.SetRenderTarget(commandBuffer2, silhouetteRTHandle, settings.customDepthBuffer ? silhouetteDepthRTHandle : renderingData.cameraData.renderer.cameraDepthTargetHandle);
					context.ExecuteCommandBuffer(commandBuffer2);
					commandBuffer2.Clear();
					SortingCriteria defaultOpaqueSortFlags2 = renderingData.cameraData.defaultOpaqueSortFlags;
					int num2 = 0;
					foreach (Outline outline2 in settings.Outlines)
					{
						if (!outline2.IsActive())
						{
							num2++;
							continue;
						}
						RenderQueueRange value2 = outline2.renderQueue switch
						{
							OutlineRenderQueue.Opaque => RenderQueueRange.opaque, 
							OutlineRenderQueue.Transparent => RenderQueueRange.transparent, 
							OutlineRenderQueue.OpaqueAndTransparent => RenderQueueRange.all, 
							_ => throw new ArgumentOutOfRangeException(), 
						};
						DrawingSettings drawingSettings2 = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags2);
						if (!outline2.vertexAnimation)
						{
							drawingSettings2.overrideMaterial = (outline2.gpuInstancing ? outline2.silhouetteMaterialInstanced : outline2.silhouetteMaterial);
							drawingSettings2.overrideMaterialPassIndex = 0;
							drawingSettings2.enableInstancing = outline2.gpuInstancing;
						}
						FilteringSettings filteringSettings2 = new FilteringSettings(value2, outline2.layerMask, outline2.RenderingLayer);
						RenderStateBlock stateBlock2 = new RenderStateBlock(RenderStateMask.Nothing);
						StencilState defaultValue3 = StencilState.defaultValue;
						defaultValue3.enabled = true;
						defaultValue3.SetCompareFunction((outline2.occlusion == WideOutlineOcclusion.WhenOccluded) ? CompareFunction.NotEqual : CompareFunction.Always);
						defaultValue3.SetPassOperation(StencilOp.Replace);
						defaultValue3.SetFailOperation(StencilOp.Keep);
						defaultValue3.SetZFailOperation((!outline2.closedLoop) ? StencilOp.Replace : StencilOp.Keep);
						defaultValue3.readMask = (byte)(1 << num2);
						defaultValue3.writeMask = (byte)(1 << num2);
						stateBlock2.mask |= RenderStateMask.Stencil;
						stateBlock2.stencilReference = 1 << num2;
						stateBlock2.stencilState = defaultValue3;
						if (outline2.vertexAnimation)
						{
							DepthState defaultValue4 = DepthState.defaultValue;
							switch (outline2.occlusion)
							{
							case WideOutlineOcclusion.Always:
								defaultValue4.compareFunction = CompareFunction.Always;
								break;
							case WideOutlineOcclusion.WhenOccluded:
								defaultValue4.compareFunction = CompareFunction.Greater;
								break;
							case WideOutlineOcclusion.WhenNotOccluded:
								defaultValue4.compareFunction = CompareFunction.LessEqual;
								break;
							case WideOutlineOcclusion.AsMask:
								defaultValue4.compareFunction = CompareFunction.Always;
								break;
							}
							stateBlock2.mask |= RenderStateMask.Depth;
							stateBlock2.depthState = defaultValue4;
						}
						BlendState defaultValue5 = BlendState.defaultValue;
						defaultValue5.blendState0 = new RenderTargetBlendState((ColorWriteMask)0);
						stateBlock2.blendState = defaultValue5;
						if (outline2.vertexAnimation)
						{
							commandBuffer2.EnableKeyword(in Keyword.OutlineColor);
						}
						context.ExecuteCommandBuffer(commandBuffer2);
						context.DrawRenderers(renderingData.cullResults, ref drawingSettings2, ref filteringSettings2, ref stateBlock2);
						if (outline2.vertexAnimation)
						{
							commandBuffer2.DisableKeyword(in Keyword.OutlineColor);
						}
						context.ExecuteCommandBuffer(commandBuffer2);
						num2++;
					}
				}
				if (settings.customDepthBuffer)
				{
					commandBuffer2.SetGlobalTexture(ShaderPropertyId.SilhouetteDepthBuffer, silhouetteDepthRTHandle.nameID);
				}
				commandBuffer2.SetGlobalTexture(ShaderPropertyId.SilhouetteBuffer, silhouetteRTHandle.nameID);
				context.ExecuteCommandBuffer(commandBuffer2);
				CommandBufferPool.Release(commandBuffer2);
				CommandBuffer commandBuffer3 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer3, floodSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer3);
					commandBuffer3.Clear();
					Blitter.BlitCameraTexture(commandBuffer3, silhouetteRTHandle, pingRTHandle, composite, 1);
					for (int num3 = Mathf.CeilToInt(Mathf.Log(settings.sharedWidth * renderingData.cameraData.renderScale + 1f, 2f)) - 1; num3 >= 0; num3--)
					{
						float num4 = Mathf.Pow(2f, num3) + 0.5f;
						commandBuffer3.SetGlobalVector(ShaderPropertyId.AxisWidthId, new Vector2(num4, 0f));
						Blitter.BlitCameraTexture(commandBuffer3, pingRTHandle, pongRTHandle, composite, 2);
						commandBuffer3.SetGlobalVector(ShaderPropertyId.AxisWidthId, new Vector2(0f, num4));
						Blitter.BlitCameraTexture(commandBuffer3, pongRTHandle, pingRTHandle, composite, 2);
					}
				}
				context.ExecuteCommandBuffer(commandBuffer3);
				CommandBufferPool.Release(commandBuffer3);
				CommandBuffer commandBuffer4 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer4, outlineSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer4);
					commandBuffer4.Clear();
					CoreUtils.SetRenderTarget(commandBuffer4, renderingData.cameraData.renderer.cameraColorTargetHandle, settings.customDepthBuffer ? silhouetteDepthRTHandle : cameraDepthRTHandle);
					Blitter.BlitTexture(commandBuffer4, pingRTHandle, Vector2.one, composite, 3);
				}
				context.ExecuteCommandBuffer(commandBuffer4);
				CommandBufferPool.Release(commandBuffer4);
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
				silhouetteRTHandle?.Release();
				silhouetteDepthRTHandle?.Release();
				pingRTHandle?.Release();
				pongRTHandle?.Release();
			}
		}

		[SerializeField]
		private WideOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material silhouetteMaterial;

		private Material silhouetteInstancedMaterial;

		private Material outlineMaterial;

		private WideOutlinePass wideOutlinePass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				WideOutlineSettings wideOutlineSettings = settings;
				wideOutlineSettings.OnSettingsChanged = (Action)Delegate.Combine(wideOutlineSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (wideOutlinePass == null)
				{
					wideOutlinePass = new WideOutlinePass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(settings == null) && wideOutlinePass != null && renderingData.cameraData.cameraType != CameraType.Preview && renderingData.cameraData.cameraType != CameraType.Reflection && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView) && !UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				if (!CreateMaterials())
				{
					Debug.LogWarning("Not all required materials could be created. Wide Outline will not render.");
				}
				else if (wideOutlinePass.Setup(ref settings, ref maskMaterial, ref silhouetteMaterial, ref silhouetteInstancedMaterial, ref outlineMaterial, renderingData.cameraData.renderScale))
				{
					renderer.EnqueuePass(wideOutlinePass);
				}
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(settings == null) && wideOutlinePass != null && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView))
			{
				CameraType cameraType = renderingData.cameraData.cameraType;
				if (cameraType != CameraType.Preview && cameraType != CameraType.Reflection)
				{
					wideOutlinePass.CreateHandles(renderingData);
					wideOutlinePass.ConfigureInput(ScriptableRenderPassInput.Color);
					wideOutlinePass.ConfigureInput(ScriptableRenderPassInput.Depth);
					wideOutlinePass.SetTarget(renderer.cameraDepthTargetHandle);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			wideOutlinePass?.Dispose();
			wideOutlinePass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			wideOutlinePass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(maskMaterial);
			CoreUtils.Destroy(silhouetteMaterial);
			CoreUtils.Destroy(silhouetteInstancedMaterial);
			CoreUtils.Destroy(outlineMaterial);
		}

		private bool CreateMaterials()
		{
			if (maskMaterial == null)
			{
				maskMaterial = CoreUtils.CreateEngineMaterial(shaders.mask);
			}
			if (silhouetteMaterial == null)
			{
				silhouetteMaterial = CoreUtils.CreateEngineMaterial(shaders.silhouette);
			}
			if (silhouetteInstancedMaterial == null)
			{
				silhouetteInstancedMaterial = CoreUtils.CreateEngineMaterial(shaders.silhouetteInstanced);
			}
			if (outlineMaterial == null)
			{
				outlineMaterial = CoreUtils.CreateEngineMaterial(shaders.outline);
			}
			if (maskMaterial != null && silhouetteMaterial != null && silhouetteInstancedMaterial != null)
			{
				return outlineMaterial != null;
			}
			return false;
		}
	}
}

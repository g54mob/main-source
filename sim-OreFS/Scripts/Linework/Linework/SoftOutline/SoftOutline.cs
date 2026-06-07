using System;
using System.Collections.Generic;
using System.Linq;
using Linework.Common.Utils;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.SoftOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Soft Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Soft Outline renders outlines by generating a silhouette of an object and applying a dilation/blur effect, resulting in smooth, soft-edged contours around objects.")]
	[HelpURL("https://linework.ameye.dev/outlines/soft-outline")]
	public class SoftOutline : ScriptableRendererFeature
	{
		private class SoftOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles = new List<RendererListHandle>();

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> SilhouetteRendererListHandles = new List<(RendererListHandle, bool)>();
			}

			private SoftOutlineSettings settings;

			private Material mask;

			private Material silhouetteBase;

			private Material silhouetteInstancedBase;

			private Material blur;

			private Material composite;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler silhouetteSampler;

			private readonly ProfilingSampler blurSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			private RTHandle silhouetteRTHandle;

			private RTHandle blurRTHandle;

			private RTHandle[] handles;

			public SoftOutlinePass()
			{
				base.profilingSampler = new ProfilingSampler("SoftOutlinePass");
				maskSampler = new ProfilingSampler("Mask (Soft Outline)");
				silhouetteSampler = new ProfilingSampler("Silhouette (Soft Outline)");
				blurSampler = new ProfilingSampler("Blur (Soft Outline)");
				outlineSampler = new ProfilingSampler("Outline (Soft Outline)");
			}

			public bool Setup(ref SoftOutlineSettings softOutlineSettings, ref Material maskMaterial, ref Material silhouetteMaterial, ref Material silhouetteInstancedMaterial, ref Material blurMaterial, ref Material compositeMaterial)
			{
				settings = softOutlineSettings;
				mask = maskMaterial;
				silhouetteBase = silhouetteMaterial;
				silhouetteInstancedBase = silhouetteInstancedMaterial;
				blur = blurMaterial;
				composite = compositeMaterial;
				base.renderPassEvent = (RenderPassEvent)softOutlineSettings.InjectionPoint;
				foreach (Outline outline in settings.Outlines)
				{
					if (outline.material == null || outline.materialInstanced == null)
					{
						outline.AssignMaterials(silhouetteBase, silhouetteInstancedBase);
					}
				}
				foreach (Outline outline2 in settings.Outlines)
				{
					if (outline2.IsActive())
					{
						Material material = (outline2.gpuInstancing ? outline2.materialInstanced : outline2.material);
						material.SetColor(CommonShaderPropertyId.OutlineColor, (settings.type == OutlineType.Hard) ? Color.white : outline2.color);
						if (outline2.occlusion == SoftOutlineOcclusion.AsMask)
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
						switch (outline2.cullingMode)
						{
						case CullingMode.Off:
							material.SetFloat(CommonShaderPropertyId.CullMode, 0f);
							break;
						case CullingMode.Back:
							material.SetFloat(CommonShaderPropertyId.CullMode, 2f);
							break;
						}
						switch (outline2.occlusion)
						{
						case SoftOutlineOcclusion.Always:
							material.SetFloat(CommonShaderPropertyId.ZTest, 8f);
							break;
						case SoftOutlineOcclusion.WhenOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 5f);
							break;
						case SoftOutlineOcclusion.WhenNotOccluded:
							material.SetFloat(CommonShaderPropertyId.ZTest, 4f);
							break;
						case SoftOutlineOcclusion.AsMask:
							material.SetFloat(CommonShaderPropertyId.ZTest, 8f);
							break;
						default:
							throw new ArgumentOutOfRangeException();
						}
					}
				}
				if (settings.scaleWithResolution)
				{
					blur.EnableKeyword("SCALE_WITH_RESOLUTION");
				}
				else
				{
					blur.DisableKeyword("SCALE_WITH_RESOLUTION");
				}
				switch (settings.referenceResolution)
				{
				case Linework.Common.Utils.Resolution._480:
					blur.SetFloat(CommonShaderPropertyId.ReferenceResolution, 480f);
					break;
				case Linework.Common.Utils.Resolution._720:
					blur.SetFloat(CommonShaderPropertyId.ReferenceResolution, 720f);
					break;
				case Linework.Common.Utils.Resolution._1080:
					blur.SetFloat(CommonShaderPropertyId.ReferenceResolution, 1080f);
					break;
				case Linework.Common.Utils.Resolution.Custom:
					blur.SetFloat(CommonShaderPropertyId.ReferenceResolution, settings.customResolution);
					break;
				}
				DilationMethod dilationMethod = settings.dilationMethod;
				if (dilationMethod == DilationMethod.Box || dilationMethod == DilationMethod.Gaussian || dilationMethod == DilationMethod.Dilate)
				{
					blur.SetInt(ShaderPropertyId.KernelSize, settings.kernelSize);
					blur.SetInt(ShaderPropertyId.Samples, settings.kernelSize * 2 + 1);
				}
				if (settings.dilationMethod == DilationMethod.Gaussian)
				{
					blur.SetFloat(ShaderPropertyId.KernelSpread, settings.blurSpread);
				}
				blur.SetFloat(ShaderPropertyId.OutlineHardness, settings.hardness);
				var (value, value2) = RenderUtils.GetSrcDstBlend(settings.blendMode);
				composite.SetInt(CommonShaderPropertyId.BlendModeSource, value);
				composite.SetInt(CommonShaderPropertyId.BlendModeDestination, value2);
				composite.SetColor(CommonShaderPropertyId.OutlineColor, settings.sharedColor);
				composite.SetFloat(ShaderPropertyId.OutlineHardness, settings.hardness);
				composite.SetFloat(ShaderPropertyId.OutlineIntensity, (settings.type == OutlineType.Hard) ? 1f : settings.intensity);
				if (settings.type == OutlineType.Hard)
				{
					composite.EnableKeyword("HARD_OUTLINE");
				}
				else
				{
					composite.DisableKeyword("HARD_OUTLINE");
				}
				return settings.Outlines.Any(ShouldRenderOutline);
			}

			private static bool ShouldRenderOutline(Outline outline)
			{
				if (outline.IsActive())
				{
					return outline.occlusion != SoftOutlineOcclusion.AsMask;
				}
				return false;
			}

			private static bool ShouldRenderStencilMask(Outline outline)
			{
				if (outline.IsActive())
				{
					return outline.occlusion == SoftOutlineOcclusion.WhenOccluded;
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
				CreateRenderGraphTextures(renderGraph, cameraData, out var silhouetteHandle, out var blurHandle);
				if (!silhouetteHandle.IsValid() || !blurHandle.IsValid())
				{
					return;
				}
				PassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Mask (Soft Outline)", out passData, ".\\Packages\\dev.ameye.linework\\Runtime\\SoftOutline\\SoftOutline.cs", 179))
				{
					rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					InitMaskRendererLists(renderGraph, frameData, ref passData);
					foreach (RendererListHandle maskRendererListHandle in passData.MaskRendererListHandles)
					{
						rasterRenderGraphBuilder.UseRendererList(maskRendererListHandle);
					}
					rasterRenderGraphBuilder.AllowPassCulling(value: false);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						foreach (RendererListHandle maskRendererListHandle2 in data.MaskRendererListHandles)
						{
							context.cmd.DrawRendererList(maskRendererListHandle2);
						}
					});
				}
				PassData passData2;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Silhouette (Soft Outline)", out passData2, ".\\Packages\\dev.ameye.linework\\Runtime\\SoftOutline\\SoftOutline.cs", 203))
				{
					rasterRenderGraphBuilder2.SetRenderAttachment(silhouetteHandle, 0);
					rasterRenderGraphBuilder2.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					rasterRenderGraphBuilder2.SetGlobalTextureAfterPass(in silhouetteHandle, ShaderPropertyId.SilhouetteBuffer);
					InitSilhouetteRendererLists(renderGraph, frameData, ref passData2);
					foreach (var silhouetteRendererListHandle in passData2.SilhouetteRendererListHandles)
					{
						(RendererListHandle, bool) current = silhouetteRendererListHandle;
						rasterRenderGraphBuilder2.UseRendererList(in current.Item1);
					}
					rasterRenderGraphBuilder2.AllowGlobalStateModification(value: true);
					rasterRenderGraphBuilder2.AllowPassCulling(value: false);
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
				PassData passData3;
				using (IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Blur (Soft Outline)", out passData3, ".\\Packages\\dev.ameye.linework\\Runtime\\SoftOutline\\SoftOutline.cs", 240))
				{
					unsafeRenderGraphBuilder.UseTexture(in silhouetteHandle);
					unsafeRenderGraphBuilder.UseTexture(in blurHandle, AccessFlags.Write);
					unsafeRenderGraphBuilder.AllowPassCulling(value: false);
					unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData _, UnsafeGraphContext context)
					{
						CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
						switch (settings.dilationMethod)
						{
						case DilationMethod.Box:
						case DilationMethod.Gaussian:
						case DilationMethod.Dilate:
							Blitter.BlitCameraTexture(nativeCommandBuffer, silhouetteHandle, blurHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, blur, 0);
							Blitter.BlitCameraTexture(nativeCommandBuffer, blurHandle, silhouetteHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, blur, 1);
							break;
						case DilationMethod.Kawase:
						{
							for (int i = 1; i < settings.blurPasses; i++)
							{
								blur.SetFloat(ShaderPropertyId.Offset, 0.5f + (float)i);
								Blitter.BlitCameraTexture(nativeCommandBuffer, silhouetteHandle, blurHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, blur, 0);
								TextureHandle textureHandle2 = blurHandle;
								TextureHandle textureHandle3 = silhouetteHandle;
								silhouetteHandle = textureHandle2;
								blurHandle = textureHandle3;
							}
							break;
						}
						}
					});
				}
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<PassData>("Outline (Soft Outline)", out passData3, ".\\Packages\\dev.ameye.linework\\Runtime\\SoftOutline\\SoftOutline.cs", 274);
				TextureHandle textureHandle;
				switch (settings.dilationMethod)
				{
				case DilationMethod.Box:
				case DilationMethod.Gaussian:
					textureHandle = silhouetteHandle;
					break;
				case DilationMethod.Kawase:
					textureHandle = blurHandle;
					break;
				default:
					textureHandle = silhouetteHandle;
					break;
				}
				TextureHandle source = textureHandle;
				rasterRenderGraphBuilder3.UseTexture(in source);
				rasterRenderGraphBuilder3.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder3.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
				rasterRenderGraphBuilder3.AllowPassCulling(value: false);
				rasterRenderGraphBuilder3.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
				{
					Blitter.BlitTexture(context.cmd, source, Vector2.one, composite, 0);
				});
			}

			private void InitMaskRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				passData.MaskRendererListHandles.Clear();
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				RenderQueueRange opaque = RenderQueueRange.opaque;
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
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, outline.RenderingLayer);
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
				RenderQueueRange opaque = RenderQueueRange.opaque;
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
						drawingSettings.overrideMaterial = (outline.gpuInstancing ? outline.materialInstanced : outline.material);
						drawingSettings.overrideMaterialPassIndex = 0;
						drawingSettings.enableInstancing = outline.gpuInstancing;
					}
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, outline.RenderingLayer);
					RenderStateBlock renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					StencilState defaultValue = StencilState.defaultValue;
					defaultValue.enabled = true;
					defaultValue.SetCompareFunction((outline.occlusion == SoftOutlineOcclusion.WhenOccluded) ? CompareFunction.NotEqual : CompareFunction.Always);
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
						case SoftOutlineOcclusion.Always:
							defaultValue2.compareFunction = CompareFunction.Always;
							break;
						case SoftOutlineOcclusion.WhenOccluded:
							defaultValue2.compareFunction = CompareFunction.Greater;
							break;
						case SoftOutlineOcclusion.WhenNotOccluded:
							defaultValue2.compareFunction = CompareFunction.LessEqual;
							break;
						case SoftOutlineOcclusion.AsMask:
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

			private void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalCameraData cameraData, out TextureHandle silhouetteHandle, out TextureHandle blurHandle)
			{
				int width = (int)((float)cameraData.cameraTargetDescriptor.width * 1f);
				int height = (int)((float)cameraData.cameraTargetDescriptor.height * 1f);
				RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(width, height);
				renderTextureDescriptor.dimension = TextureDimension.Tex2D;
				renderTextureDescriptor.msaaSamples = cameraData.cameraTargetDescriptor.msaaSamples;
				renderTextureDescriptor.sRGB = false;
				renderTextureDescriptor.useMipMap = false;
				renderTextureDescriptor.autoGenerateMips = false;
				renderTextureDescriptor.graphicsFormat = ((settings.dilationMethod == DilationMethod.Dilate) ? GraphicsFormat.R8G8B8A8_UNorm : ((settings.type == OutlineType.Hard) ? GraphicsFormat.R8_UNorm : GraphicsFormat.R8G8B8A8_UNorm));
				renderTextureDescriptor.depthBufferBits = 0;
				renderTextureDescriptor.colorFormat = RenderTextureFormat.Default;
				RenderTextureDescriptor desc = renderTextureDescriptor;
				silhouetteHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_SilhouetteBuffer", clear: false);
				blurHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_BlurBuffer", clear: false);
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
				RTHandle[] array = handles;
				if (array == null || array.Length != 2)
				{
					handles = new RTHandle[2];
				}
				handles[0] = silhouetteRTHandle;
				handles[1] = blurRTHandle;
				ConfigureTarget(handles, cameraDepthRTHandle);
				ConfigureClear(ClearFlag.Color, Color.clear);
			}

			public void CreateHandles(RenderingData renderingData)
			{
				int width = (int)((float)renderingData.cameraData.cameraTargetDescriptor.width * 1f);
				int height = (int)((float)renderingData.cameraData.cameraTargetDescriptor.height * 1f);
				RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(width, height);
				renderTextureDescriptor.dimension = TextureDimension.Tex2D;
				renderTextureDescriptor.msaaSamples = renderingData.cameraData.cameraTargetDescriptor.msaaSamples;
				renderTextureDescriptor.sRGB = false;
				renderTextureDescriptor.useMipMap = false;
				renderTextureDescriptor.autoGenerateMips = false;
				renderTextureDescriptor.graphicsFormat = ((settings.dilationMethod == DilationMethod.Dilate) ? GraphicsFormat.R8G8B8A8_UNorm : ((settings.type == OutlineType.Hard) ? GraphicsFormat.R8_UNorm : GraphicsFormat.R8G8B8A8_UNorm));
				renderTextureDescriptor.depthBufferBits = 0;
				renderTextureDescriptor.colorFormat = RenderTextureFormat.Default;
				RenderTextureDescriptor descriptor = renderTextureDescriptor;
				RenderingUtils.ReAllocateIfNeeded(ref silhouetteRTHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_SilhouetteBuffer");
				RenderingUtils.ReAllocateIfNeeded(ref blurRTHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_BlurBuffer");
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
					int num = 0;
					foreach (Outline outline in settings.Outlines)
					{
						if (!ShouldRenderStencilMask(outline))
						{
							num++;
							continue;
						}
						DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags);
						drawingSettings.overrideMaterial = mask;
						drawingSettings.overrideShaderPassIndex = 0;
						FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, outline.RenderingLayer);
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
					CoreUtils.SetRenderTarget(commandBuffer2, silhouetteRTHandle, renderingData.cameraData.renderer.cameraDepthTargetHandle);
					context.ExecuteCommandBuffer(commandBuffer2);
					commandBuffer2.Clear();
					SortingCriteria defaultOpaqueSortFlags2 = renderingData.cameraData.defaultOpaqueSortFlags;
					RenderQueueRange opaque2 = RenderQueueRange.opaque;
					int num2 = 0;
					foreach (Outline outline2 in settings.Outlines)
					{
						if (!outline2.IsActive())
						{
							num2++;
							continue;
						}
						DrawingSettings drawingSettings2 = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags2);
						drawingSettings2.overrideMaterial = (outline2.gpuInstancing ? outline2.materialInstanced : outline2.material);
						drawingSettings2.overrideShaderPassIndex = 0;
						drawingSettings2.enableInstancing = outline2.gpuInstancing;
						FilteringSettings filteringSettings2 = new FilteringSettings(opaque2, -1, outline2.RenderingLayer);
						RenderStateBlock stateBlock2 = new RenderStateBlock(RenderStateMask.Nothing);
						StencilState defaultValue3 = StencilState.defaultValue;
						defaultValue3.enabled = true;
						defaultValue3.SetCompareFunction((outline2.occlusion == SoftOutlineOcclusion.WhenOccluded) ? CompareFunction.NotEqual : CompareFunction.Always);
						defaultValue3.SetPassOperation(StencilOp.Replace);
						defaultValue3.SetFailOperation(StencilOp.Keep);
						defaultValue3.SetZFailOperation((!outline2.closedLoop) ? StencilOp.Replace : StencilOp.Keep);
						defaultValue3.writeMask = (byte)(1 << num2);
						stateBlock2.mask |= RenderStateMask.Stencil;
						stateBlock2.stencilReference = 1 << num2;
						stateBlock2.stencilState = defaultValue3;
						context.DrawRenderers(renderingData.cullResults, ref drawingSettings2, ref filteringSettings2, ref stateBlock2);
						num2++;
					}
				}
				commandBuffer2.SetGlobalTexture(ShaderPropertyId.SilhouetteBuffer, silhouetteRTHandle.nameID);
				context.ExecuteCommandBuffer(commandBuffer2);
				CommandBufferPool.Release(commandBuffer2);
				CommandBuffer commandBuffer3 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer3, blurSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer3);
					commandBuffer3.Clear();
					switch (settings.dilationMethod)
					{
					case DilationMethod.Box:
					case DilationMethod.Gaussian:
					case DilationMethod.Dilate:
						Blitter.BlitCameraTexture(commandBuffer3, silhouetteRTHandle, blurRTHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, blur, 0);
						Blitter.BlitCameraTexture(commandBuffer3, blurRTHandle, silhouetteRTHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, blur, 1);
						break;
					case DilationMethod.Kawase:
					{
						for (int i = 1; i < settings.blurPasses; i++)
						{
							blur.SetFloat(ShaderPropertyId.Offset, 0.5f + (float)i);
							Blitter.BlitCameraTexture(commandBuffer3, silhouetteRTHandle, blurRTHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, blur, 0);
							RTHandle rTHandle = blurRTHandle;
							RTHandle rTHandle2 = silhouetteRTHandle;
							silhouetteRTHandle = rTHandle;
							blurRTHandle = rTHandle2;
						}
						break;
					}
					}
				}
				context.ExecuteCommandBuffer(commandBuffer3);
				CommandBufferPool.Release(commandBuffer3);
				CommandBuffer commandBuffer4 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer4, outlineSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer4);
					commandBuffer4.Clear();
					RTHandle rTHandle2;
					switch (settings.dilationMethod)
					{
					case DilationMethod.Box:
					case DilationMethod.Gaussian:
						rTHandle2 = silhouetteRTHandle;
						break;
					case DilationMethod.Kawase:
						rTHandle2 = blurRTHandle;
						break;
					default:
						rTHandle2 = silhouetteRTHandle;
						break;
					}
					RTHandle source = rTHandle2;
					CoreUtils.SetRenderTarget(commandBuffer4, renderingData.cameraData.renderer.cameraColorTargetHandle, cameraDepthRTHandle);
					Blitter.BlitTexture(commandBuffer4, source, Vector2.one, composite, 0);
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
				blurRTHandle?.Release();
			}
		}

		[SerializeField]
		private SoftOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material silhouetteMaterial;

		private Material silhouetteInstancedMaterial;

		private Material blurMaterial;

		private Material outlineMaterial;

		private SoftOutlinePass softOutlinePass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				SoftOutlineSettings softOutlineSettings = settings;
				softOutlineSettings.OnSettingsChanged = (Action)Delegate.Combine(softOutlineSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (softOutlinePass == null)
				{
					softOutlinePass = new SoftOutlinePass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(settings == null) && renderingData.cameraData.cameraType != CameraType.Preview && renderingData.cameraData.cameraType != CameraType.Reflection && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView) && !UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				if (!CreateMaterials())
				{
					Debug.LogWarning("Not all required materials could be created. Soft Outline will not render.");
				}
				else if (softOutlinePass.Setup(ref settings, ref maskMaterial, ref silhouetteMaterial, ref silhouetteInstancedMaterial, ref blurMaterial, ref outlineMaterial))
				{
					renderer.EnqueuePass(softOutlinePass);
				}
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(settings == null) && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView))
			{
				softOutlinePass.CreateHandles(renderingData);
				softOutlinePass.SetTarget(renderer.cameraDepthTargetHandle);
			}
		}

		protected override void Dispose(bool disposing)
		{
			softOutlinePass?.Dispose();
			softOutlinePass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			softOutlinePass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(maskMaterial);
			CoreUtils.Destroy(silhouetteMaterial);
			CoreUtils.Destroy(silhouetteInstancedMaterial);
			CoreUtils.Destroy(blurMaterial);
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
			if (blurMaterial != null)
			{
				CoreUtils.Destroy(blurMaterial);
			}
			blurMaterial = settings.dilationMethod switch
			{
				DilationMethod.Box => CoreUtils.CreateEngineMaterial(shaders.boxBlur), 
				DilationMethod.Gaussian => CoreUtils.CreateEngineMaterial(shaders.gaussianBlur), 
				DilationMethod.Kawase => CoreUtils.CreateEngineMaterial(shaders.kawaseBlur), 
				DilationMethod.Dilate => CoreUtils.CreateEngineMaterial(shaders.dilate), 
				_ => blurMaterial, 
			};
			if (outlineMaterial == null)
			{
				outlineMaterial = CoreUtils.CreateEngineMaterial(shaders.outline);
			}
			if (maskMaterial != null && silhouetteMaterial != null && silhouetteInstancedMaterial != null && blurMaterial != null)
			{
				return outlineMaterial != null;
			}
			return false;
		}
	}
}

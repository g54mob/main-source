using System;
using Linework.Common.Utils;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.EdgeDetection
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Edge Detection")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Edge Detection renders outlines by detecting edges and discontinuities within the scene.")]
	[HelpURL("https://linework.ameye.dev/outlines/edge-detection")]
	public class EdgeDetection : ScriptableRendererFeature
	{
		private class EdgeDetectionPass : ScriptableRenderPass
		{
			private class PassData
			{
				internal RendererListHandle SectionRendererListHandle;
			}

			private EdgeDetectionSettings settings;

			private Material outline;

			private Material section;

			private readonly ProfilingSampler sectionSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			private RTHandle sectionRTHandle;

			private RTHandle[] handles;

			public EdgeDetectionPass()
			{
				base.profilingSampler = new ProfilingSampler("EdgeDetectionPass");
				sectionSampler = new ProfilingSampler("Section (Edge Detection)");
				outlineSampler = new ProfilingSampler("Outline (Edge Detection)");
			}

			public bool Setup(ref EdgeDetectionSettings edgeDetectionSettings, ref Material sectionMaterial, ref Material outlineMaterial)
			{
				settings = edgeDetectionSettings;
				section = sectionMaterial;
				outline = outlineMaterial;
				base.renderPassEvent = (RenderPassEvent)edgeDetectionSettings.InjectionPoint;
				if (settings.objectId)
				{
					section.EnableKeyword("OBJECT_ID");
				}
				else
				{
					section.DisableKeyword("OBJECT_ID");
				}
				if (settings.particles)
				{
					section.EnableKeyword("PARTICLES");
				}
				else
				{
					section.DisableKeyword("PARTICLES");
				}
				switch (edgeDetectionSettings.sectionMapInput)
				{
				case SectionMapInput.None:
				case SectionMapInput.Custom:
					section.DisableKeyword("INPUT_VERTEX_COLOR");
					section.DisableKeyword("INPUT_TEXTURE");
					break;
				case SectionMapInput.VertexColors:
					section.EnableKeyword("INPUT_VERTEX_COLOR");
					section.DisableKeyword("INPUT_TEXTURE");
					switch (edgeDetectionSettings.vertexColorChannel)
					{
					case Channel.R:
						section.EnableKeyword("VERTEX_COLOR_CHANNEL_R");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_G");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_B");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_A");
						break;
					case Channel.G:
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_R");
						section.EnableKeyword("VERTEX_COLOR_CHANNEL_G");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_B");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_A");
						break;
					case Channel.B:
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_R");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_G");
						section.EnableKeyword("VERTEX_COLOR_CHANNEL_B");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_A");
						break;
					case Channel.A:
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_R");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_G");
						section.DisableKeyword("VERTEX_COLOR_CHANNEL_B");
						section.EnableKeyword("VERTEX_COLOR_CHANNEL_A");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					break;
				case SectionMapInput.SectionTexture:
					section.DisableKeyword("INPUT_VERTEX_COLOR");
					section.EnableKeyword("INPUT_TEXTURE");
					section.SetTexture(ShaderPropertyId.SectionTexture, edgeDetectionSettings.sectionTexture);
					switch (edgeDetectionSettings.sectionTextureUvSet)
					{
					case UVSet.UV0:
						section.EnableKeyword("TEXTURE_UV_SET_UV0");
						section.DisableKeyword("TEXTURE_UV_SET_UV1");
						section.DisableKeyword("TEXTURE_UV_SET_UV2");
						section.DisableKeyword("TEXTURE_UV_SET_UV3");
						break;
					case UVSet.UV1:
						section.DisableKeyword("TEXTURE_UV_SET_UV0");
						section.EnableKeyword("TEXTURE_UV_SET_UV1");
						section.DisableKeyword("TEXTURE_UV_SET_UV2");
						section.DisableKeyword("TEXTURE_UV_SET_UV3");
						break;
					case UVSet.UV2:
						section.DisableKeyword("TEXTURE_UV_SET_UV0");
						section.DisableKeyword("TEXTURE_UV_SET_UV1");
						section.EnableKeyword("TEXTURE_UV_SET_UV2");
						section.DisableKeyword("TEXTURE_UV_SET_UV3");
						break;
					case UVSet.UV3:
						section.DisableKeyword("TEXTURE_UV_SET_UV0");
						section.DisableKeyword("TEXTURE_UV_SET_UV1");
						section.DisableKeyword("TEXTURE_UV_SET_UV2");
						section.EnableKeyword("TEXTURE_UV_SET_UV3");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					switch (edgeDetectionSettings.vertexColorChannel)
					{
					case Channel.R:
						section.EnableKeyword("TEXTURE_CHANNEL_R");
						section.DisableKeyword("TEXTURE_CHANNEL_G");
						section.DisableKeyword("TEXTURE_CHANNEL_B");
						section.DisableKeyword("TEXTURE_CHANNEL_A");
						break;
					case Channel.G:
						section.DisableKeyword("TEXTURE_CHANNEL_R");
						section.EnableKeyword("TEXTURE_CHANNEL_G");
						section.DisableKeyword("TEXTURE_CHANNEL_B");
						section.DisableKeyword("TEXTURE_CHANNEL_A");
						break;
					case Channel.B:
						section.DisableKeyword("TEXTURE_CHANNEL_R");
						section.DisableKeyword("TEXTURE_CHANNEL_G");
						section.EnableKeyword("TEXTURE_CHANNEL_B");
						section.DisableKeyword("TEXTURE_CHANNEL_A");
						break;
					case Channel.A:
						section.DisableKeyword("TEXTURE_CHANNEL_R");
						section.DisableKeyword("TEXTURE_CHANNEL_G");
						section.DisableKeyword("TEXTURE_CHANNEL_B");
						section.EnableKeyword("TEXTURE_CHANNEL_A");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				switch (edgeDetectionSettings.DebugView)
				{
				case DebugView.None:
					outline.DisableKeyword("DEBUG_SECTIONS");
					outline.DisableKeyword("DEBUG_DEPTH");
					outline.DisableKeyword("DEBUG_NORMALS");
					outline.DisableKeyword("DEBUG_LUMINANCE");
					break;
				case DebugView.Sections:
					outline.EnableKeyword("DEBUG_SECTIONS");
					outline.DisableKeyword("DEBUG_DEPTH");
					outline.DisableKeyword("DEBUG_NORMALS");
					outline.DisableKeyword("DEBUG_LUMINANCE");
					break;
				case DebugView.Depth:
					outline.DisableKeyword("DEBUG_SECTIONS");
					outline.EnableKeyword("DEBUG_DEPTH");
					outline.DisableKeyword("DEBUG_NORMALS");
					outline.DisableKeyword("DEBUG_LUMINANCE");
					break;
				case DebugView.Normals:
					outline.DisableKeyword("DEBUG_SECTIONS");
					outline.DisableKeyword("DEBUG_DEPTH");
					outline.EnableKeyword("DEBUG_NORMALS");
					outline.DisableKeyword("DEBUG_LUMINANCE");
					break;
				case DebugView.Luminance:
					outline.DisableKeyword("DEBUG_SECTIONS");
					outline.DisableKeyword("DEBUG_DEPTH");
					outline.DisableKeyword("DEBUG_NORMALS");
					outline.EnableKeyword("DEBUG_LUMINANCE");
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				if (edgeDetectionSettings.debugSectionsRaw)
				{
					outline.EnableKeyword("DEBUG_SECTIONS_RAW_VALUES");
				}
				else
				{
					outline.DisableKeyword("DEBUG_SECTIONS_RAW_VALUES");
				}
				if (edgeDetectionSettings.discontinuityInput.HasFlag(DiscontinuityInput.Depth))
				{
					outline.EnableKeyword("DEPTH");
				}
				else
				{
					outline.DisableKeyword("DEPTH");
				}
				if (edgeDetectionSettings.discontinuityInput.HasFlag(DiscontinuityInput.Normals))
				{
					outline.EnableKeyword("NORMALS");
				}
				else
				{
					outline.DisableKeyword("NORMALS");
				}
				if (edgeDetectionSettings.discontinuityInput.HasFlag(DiscontinuityInput.Luminance))
				{
					outline.EnableKeyword("LUMINANCE");
				}
				else
				{
					outline.DisableKeyword("LUMINANCE");
				}
				if (edgeDetectionSettings.discontinuityInput.HasFlag(DiscontinuityInput.Sections))
				{
					outline.EnableKeyword("SECTIONS");
				}
				else
				{
					outline.DisableKeyword("SECTIONS");
				}
				outline.SetFloat(ShaderPropertyId.DepthSensitivity, edgeDetectionSettings.depthSensitivity * 100f);
				outline.SetFloat(ShaderPropertyId.DepthDistanceModulation, edgeDetectionSettings.depthDistanceModulation * 10f);
				outline.SetFloat(ShaderPropertyId.GrazingAngleMaskPower, edgeDetectionSettings.grazingAngleMaskPower * 10f);
				outline.SetFloat(ShaderPropertyId.GrazingAngleMaskHardness, edgeDetectionSettings.grazingAngleMaskHardness);
				outline.SetFloat(ShaderPropertyId.NormalSensitivity, edgeDetectionSettings.normalSensitivity * 10f);
				outline.SetFloat(ShaderPropertyId.LuminanceSensitivity, edgeDetectionSettings.luminanceSensitivity * 20f);
				switch (edgeDetectionSettings.kernel)
				{
				case Kernel.RobertsCross:
					outline.EnableKeyword("OPERATOR_CROSS");
					outline.DisableKeyword("OPERATOR_SOBEL");
					break;
				case Kernel.Sobel:
					outline.DisableKeyword("OPERATOR_CROSS");
					outline.EnableKeyword("OPERATOR_SOBEL");
					break;
				}
				outline.SetFloat(ShaderPropertyId.OutlineThickness, edgeDetectionSettings.outlineThickness);
				if (edgeDetectionSettings.scaleWithResolution)
				{
					outline.EnableKeyword("SCALE_WITH_RESOLUTION");
				}
				else
				{
					outline.DisableKeyword("SCALE_WITH_RESOLUTION");
				}
				switch (edgeDetectionSettings.referenceResolution)
				{
				case Resolution._480:
					outline.SetFloat(ShaderPropertyId.ReferenceResolution, 480f);
					break;
				case Resolution._720:
					outline.SetFloat(ShaderPropertyId.ReferenceResolution, 720f);
					break;
				case Resolution._1080:
					outline.SetFloat(ShaderPropertyId.ReferenceResolution, 1080f);
					break;
				case Resolution.Custom:
					outline.SetFloat(ShaderPropertyId.ReferenceResolution, edgeDetectionSettings.customResolution);
					break;
				}
				if (edgeDetectionSettings.fadeInDistance)
				{
					outline.EnableKeyword("FADE_IN_DISTANCE");
				}
				else
				{
					outline.DisableKeyword("FADE_IN_DISTANCE");
				}
				outline.SetFloat(ShaderPropertyId.FadeStart, edgeDetectionSettings.fadeStart);
				outline.SetFloat(ShaderPropertyId.FadeDistance, edgeDetectionSettings.fadeDistance);
				outline.SetColor(ShaderPropertyId.FadeColor, edgeDetectionSettings.fadeColor);
				if (edgeDetectionSettings.sectionsMask)
				{
					outline.EnableKeyword("SECTIONS_MASK");
				}
				else
				{
					outline.DisableKeyword("SECTIONS_MASK");
				}
				if (edgeDetectionSettings.depthMask)
				{
					outline.EnableKeyword("DEPTH_MASK");
				}
				else
				{
					outline.DisableKeyword("DEPTH_MASK");
				}
				if (edgeDetectionSettings.normalsMask)
				{
					outline.EnableKeyword("NORMALS_MASK");
				}
				else
				{
					outline.DisableKeyword("NORMALS_MASK");
				}
				if (edgeDetectionSettings.luminanceMask)
				{
					outline.EnableKeyword("LUMINANCE_MASK");
				}
				else
				{
					outline.DisableKeyword("LUMINANCE_MASK");
				}
				outline.SetColor(ShaderPropertyId.BackgroundColor, edgeDetectionSettings.backgroundColor);
				outline.SetColor(CommonShaderPropertyId.OutlineColor, edgeDetectionSettings.outlineColor);
				outline.SetColor(ShaderPropertyId.OutlineColorShadow, edgeDetectionSettings.outlineColorShadow);
				if (edgeDetectionSettings.overrideColorInShadow)
				{
					outline.EnableKeyword("OVERRIDE_SHADOW");
				}
				else
				{
					outline.DisableKeyword("OVERRIDE_SHADOW");
				}
				outline.SetColor(ShaderPropertyId.FillColor, edgeDetectionSettings.fillColor);
				var (value, value2) = RenderUtils.GetSrcDstBlend(settings.blendMode);
				outline.SetInt(RenderUtils.BlendModeSourceProperty, value);
				outline.SetInt(RenderUtils.BlendModeDestinationProperty, value2);
				return true;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
				CreateRenderGraphTextures(renderGraph, cameraData, out var sectionHandle);
				PassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Section (Edge Detection)", out passData, ".\\Packages\\dev.ameye.linework\\Runtime\\EdgeDetection\\EdgeDetection.cs", 286))
				{
					rasterRenderGraphBuilder.SetRenderAttachment(sectionHandle, 0);
					rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
					rasterRenderGraphBuilder.SetGlobalTextureAfterPass(in sectionHandle, ShaderPropertyId.CameraSectioningTexture);
					InitSectionRendererList(renderGraph, frameData, ref passData);
					rasterRenderGraphBuilder.UseRendererList(in passData.SectionRendererListHandle);
					if (settings.sectionMapInput == SectionMapInput.Custom)
					{
						rasterRenderGraphBuilder.AllowGlobalStateModification(value: true);
					}
					rasterRenderGraphBuilder.AllowPassCulling(value: false);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						if (settings.sectionMapInput == SectionMapInput.Custom)
						{
							context.cmd.DisableKeyword(in Keyword.ScreenSpaceOcclusion);
							context.cmd.EnableKeyword(in Keyword.SectionPass);
						}
						context.cmd.DrawRendererList(data.SectionRendererListHandle);
						if (settings.sectionMapInput == SectionMapInput.Custom)
						{
							context.cmd.EnableKeyword(in Keyword.ScreenSpaceOcclusion);
							context.cmd.DisableKeyword(in Keyword.SectionPass);
						}
					});
				}
				PassData passData2;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Outline (Edge Detection)", out passData2, ".\\Packages\\dev.ameye.linework\\Runtime\\EdgeDetection\\EdgeDetection.cs", 325);
				rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder2.UseAllGlobalTextures(enable: true);
				rasterRenderGraphBuilder2.AllowPassCulling(value: false);
				rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
				{
					Blitter.BlitTexture(context.cmd, Vector2.one, outline, 0);
				});
			}

			private void InitSectionRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalLightData lightData = frameData.Get<UniversalLightData>();
				SortingCriteria defaultOpaqueSortFlags = universalCameraData.defaultOpaqueSortFlags;
				RenderQueueRange opaque = RenderQueueRange.opaque;
				DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
				FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, settings.SectionRenderingLayer);
				SectionMapInput sectionMapInput = settings.sectionMapInput;
				if (sectionMapInput == SectionMapInput.None || sectionMapInput == SectionMapInput.SectionTexture || sectionMapInput == SectionMapInput.VertexColors)
				{
					drawingSettings.overrideMaterial = section;
				}
				RenderUtils.CreateRendererListWithRenderStateBlock(renderStateBlock: new RenderStateBlock(RenderStateMask.Nothing), renderGraph: renderGraph, cullingResults: ref universalRenderingData.cullResults, drawingSettings: drawingSettings, filteringSettings: filteringSettings, rendererListHandle: ref passData.SectionRendererListHandle);
			}

			private void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalCameraData cameraData, out TextureHandle sectionHandle)
			{
				RenderTextureDescriptor cameraTargetDescriptor = cameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.graphicsFormat = GraphicsFormat.R16_UNorm;
				cameraTargetDescriptor.depthBufferBits = 0;
				cameraTargetDescriptor.msaaSamples = 1;
				sectionHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_SectionBuffer", clear: false);
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
				RTHandle[] array = handles;
				if (array == null || array.Length != 1)
				{
					handles = new RTHandle[1];
				}
				handles[0] = sectionRTHandle;
				ConfigureTarget(handles, cameraDepthRTHandle);
				ConfigureClear(ClearFlag.Color, Color.clear);
			}

			public void CreateHandles(RenderingData renderingData)
			{
				RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
				descriptor.graphicsFormat = GraphicsFormat.R8_UNorm;
				descriptor.depthBufferBits = 0;
				descriptor.msaaSamples = 1;
				RenderingUtils.ReAllocateIfNeeded(ref sectionRTHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_SectionBuffer");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer, sectionSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					SortingCriteria defaultOpaqueSortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
					RenderQueueRange opaque = RenderQueueRange.opaque;
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags);
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, settings.SectionRenderingLayer);
					SectionMapInput sectionMapInput = settings.sectionMapInput;
					if (sectionMapInput == SectionMapInput.None || sectionMapInput == SectionMapInput.SectionTexture || sectionMapInput == SectionMapInput.VertexColors)
					{
						drawingSettings.overrideMaterial = section;
					}
					RenderStateBlock stateBlock = new RenderStateBlock(RenderStateMask.Nothing);
					if (settings.sectionMapInput == SectionMapInput.Custom)
					{
						commandBuffer.DisableKeyword(in Keyword.ScreenSpaceOcclusion);
						commandBuffer.EnableKeyword(in Keyword.SectionPass);
					}
					context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings, ref stateBlock);
					if (settings.sectionMapInput == SectionMapInput.Custom)
					{
						commandBuffer.EnableKeyword(in Keyword.ScreenSpaceOcclusion);
						commandBuffer.DisableKeyword(in Keyword.SectionPass);
					}
				}
				commandBuffer.SetGlobalTexture(ShaderPropertyId.CameraSectioningTexture, sectionRTHandle.nameID);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
				CommandBuffer commandBuffer2 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer2, outlineSampler))
				{
					CoreUtils.SetRenderTarget(commandBuffer2, renderingData.cameraData.renderer.cameraColorTargetHandle);
					context.ExecuteCommandBuffer(commandBuffer2);
					commandBuffer2.Clear();
					Blitter.BlitTexture(commandBuffer2, Vector2.one, outline, 0);
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
				sectionRTHandle?.Release();
			}
		}

		[SerializeField]
		private EdgeDetectionSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material sectionMaterial;

		private Material outlineMaterial;

		private EdgeDetectionPass edgeDetectionPass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				EdgeDetectionSettings edgeDetectionSettings = settings;
				edgeDetectionSettings.OnSettingsChanged = (Action)Delegate.Combine(edgeDetectionSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (edgeDetectionPass == null)
				{
					edgeDetectionPass = new EdgeDetectionPass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (settings == null || renderingData.cameraData.cameraType == CameraType.Preview || renderingData.cameraData.cameraType == CameraType.Reflection || (renderingData.cameraData.cameraType == CameraType.SceneView && !settings.ShowInSceneView) || UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				return;
			}
			if (!CreateMaterials())
			{
				Debug.LogWarning("Not all required materials could be created. Edge Detection will not render.");
				return;
			}
			ScriptableRenderPassInput scriptableRenderPassInput = ScriptableRenderPassInput.None;
			if (settings.discontinuityInput.HasFlag(DiscontinuityInput.Depth))
			{
				scriptableRenderPassInput |= ScriptableRenderPassInput.Depth;
			}
			if (settings.discontinuityInput.HasFlag(DiscontinuityInput.Luminance))
			{
				scriptableRenderPassInput |= ScriptableRenderPassInput.Color;
			}
			if (settings.discontinuityInput.HasFlag(DiscontinuityInput.Normals))
			{
				scriptableRenderPassInput |= ScriptableRenderPassInput.Normal;
			}
			edgeDetectionPass.ConfigureInput(scriptableRenderPassInput);
			edgeDetectionPass.requiresIntermediateTexture = true;
			if (edgeDetectionPass.Setup(ref settings, ref sectionMaterial, ref outlineMaterial))
			{
				renderer.EnqueuePass(edgeDetectionPass);
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(settings == null) && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView))
			{
				edgeDetectionPass.CreateHandles(renderingData);
				edgeDetectionPass.SetTarget(renderer.cameraDepthTargetHandle);
			}
		}

		protected override void Dispose(bool disposing)
		{
			edgeDetectionPass?.Dispose();
			edgeDetectionPass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			edgeDetectionPass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(sectionMaterial);
			CoreUtils.Destroy(outlineMaterial);
		}

		private bool CreateMaterials()
		{
			if (sectionMaterial == null)
			{
				sectionMaterial = CoreUtils.CreateEngineMaterial(shaders.section);
			}
			if (outlineMaterial == null)
			{
				outlineMaterial = CoreUtils.CreateEngineMaterial(shaders.outline);
			}
			if (sectionMaterial != null)
			{
				return outlineMaterial != null;
			}
			return false;
		}
	}
}

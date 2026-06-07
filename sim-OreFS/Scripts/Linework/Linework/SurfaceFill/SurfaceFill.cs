using System;
using System.Collections.Generic;
using System.Linq;
using Linework.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.SurfaceFill
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Surface Fill")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Surface Fill renders fills by rendering an object with a fill material.")]
	[HelpURL("https://linework.ameye.dev/outlines/surface-fill")]
	public class SurfaceFill : ScriptableRendererFeature
	{
		private class SurfaceFillPass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles = new List<RendererListHandle>();
			}

			private SurfaceFillSettings settings;

			private Material mask;

			private Material fillBase;

			private RenderStateBlock fillRenderStateBlock;

			private int lastActiveFillIndex;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler fillSampler;

			private RTHandle cameraDepthRTHandle;

			public SurfaceFillPass()
			{
				base.profilingSampler = new ProfilingSampler("SurfaceFillPass");
				maskSampler = new ProfilingSampler("Mask (Surface Fill)");
				fillSampler = new ProfilingSampler("Fill (Surface Fill)");
			}

			public bool Setup(ref SurfaceFillSettings surfaceFillSettings, ref Material maskMaterial, ref Material fillMaterial)
			{
				settings = surfaceFillSettings;
				mask = maskMaterial;
				fillBase = fillMaterial;
				base.renderPassEvent = (RenderPassEvent)surfaceFillSettings.InjectionPoint;
				foreach (Fill fill in settings.Fills)
				{
					if (fill.material == null)
					{
						fill.AssignMaterial(fillBase);
					}
				}
				int num = 0;
				foreach (Fill fill2 in settings.Fills)
				{
					if (!fill2.IsActive())
					{
						num++;
						continue;
					}
					fill2.material.CopyPropertiesFromMaterial(fillBase);
					var (value, value2) = RenderUtils.GetSrcDstBlend(fill2.blendMode);
					fill2.material.SetInt(CommonShaderPropertyId.FullScreenColorBlendModeSource, value);
					fill2.material.SetInt(CommonShaderPropertyId.FullScreenColorBlendModeDestination, value2);
					mask.DisableKeyword("ALPHA_CUTOUT");
					switch (fill2.channel)
					{
					case Channel.R:
						fill2.material.EnableKeyword("CHANNEL_R");
						fill2.material.DisableKeyword("CHANNEL_G");
						fill2.material.DisableKeyword("CHANNEL_B");
						fill2.material.DisableKeyword("CHANNEL_A");
						break;
					case Channel.G:
						fill2.material.DisableKeyword("CHANNEL_R");
						fill2.material.EnableKeyword("CHANNEL_G");
						fill2.material.DisableKeyword("CHANNEL_B");
						fill2.material.DisableKeyword("CHANNEL_A");
						break;
					case Channel.B:
						fill2.material.DisableKeyword("CHANNEL_R");
						fill2.material.DisableKeyword("CHANNEL_G");
						fill2.material.EnableKeyword("CHANNEL_B");
						fill2.material.DisableKeyword("CHANNEL_A");
						break;
					case Channel.A:
						fill2.material.DisableKeyword("CHANNEL_R");
						fill2.material.DisableKeyword("CHANNEL_G");
						fill2.material.DisableKeyword("CHANNEL_B");
						fill2.material.EnableKeyword("CHANNEL_A");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					switch (fill2.pattern)
					{
					case Pattern.Solid:
						fill2.material.EnableKeyword("_PATTERN_SOLID");
						fill2.material.DisableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.DisableKeyword("_PATTERN_DOTS");
						fill2.material.DisableKeyword("_PATTERN_STRIPES");
						fill2.material.DisableKeyword("_PATTERN_GLOW");
						fill2.material.DisableKeyword("_PATTERN_TEXTURE");
						break;
					case Pattern.Checkerboard:
						fill2.material.DisableKeyword("_PATTERN_SOLID");
						fill2.material.EnableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.DisableKeyword("_PATTERN_DOTS");
						fill2.material.DisableKeyword("_PATTERN_STRIPES");
						fill2.material.DisableKeyword("_PATTERN_GLOW");
						fill2.material.DisableKeyword("_PATTERN_TEXTURE");
						break;
					case Pattern.Dots:
						fill2.material.DisableKeyword("_PATTERN_SOLID");
						fill2.material.DisableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.EnableKeyword("_PATTERN_DOTS");
						fill2.material.DisableKeyword("_PATTERN_STRIPES");
						fill2.material.DisableKeyword("_PATTERN_GLOW");
						fill2.material.DisableKeyword("_PATTERN_TEXTURE");
						break;
					case Pattern.Stripes:
						fill2.material.DisableKeyword("_PATTERN_SOLID");
						fill2.material.DisableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.DisableKeyword("_PATTERN_DOTS");
						fill2.material.EnableKeyword("_PATTERN_STRIPES");
						fill2.material.DisableKeyword("_PATTERN_GLOW");
						fill2.material.DisableKeyword("_PATTERN_TEXTURE");
						break;
					case Pattern.Glow:
						fill2.material.DisableKeyword("_PATTERN_SOLID");
						fill2.material.DisableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.DisableKeyword("_PATTERN_DOTS");
						fill2.material.DisableKeyword("_PATTERN_STRIPES");
						fill2.material.EnableKeyword("_PATTERN_GLOW");
						fill2.material.DisableKeyword("_PATTERN_TEXTURE");
						break;
					case Pattern.Texture:
						fill2.material.DisableKeyword("_PATTERN_SOLID");
						fill2.material.DisableKeyword("_PATTERN_CHECKERBOARD");
						fill2.material.DisableKeyword("_PATTERN_DOTS");
						fill2.material.DisableKeyword("_PATTERN_STRIPES");
						fill2.material.DisableKeyword("_PATTERN_GLOW");
						fill2.material.EnableKeyword("_PATTERN_TEXTURE");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					fill2.material.SetColor(ShaderPropertyId.PrimaryColor, fill2.primaryColor);
					fill2.material.SetColor(ShaderPropertyId.SecondaryColor, fill2.secondaryColor);
					fill2.material.SetFloat(ShaderPropertyId.FrequencyX, fill2.frequencyX);
					fill2.material.SetFloat(ShaderPropertyId.FrequencyY, fill2.frequencyY);
					fill2.material.SetFloat(ShaderPropertyId.Density, fill2.density);
					if (fill2.pattern == Pattern.Texture)
					{
						fill2.material.SetFloat(ShaderPropertyId.Rotation, fill2.rotation * 0.5f);
					}
					else
					{
						fill2.material.SetFloat(ShaderPropertyId.Rotation, fill2.rotation);
					}
					fill2.material.SetFloat(ShaderPropertyId.Direction, fill2.direction);
					fill2.material.SetFloat(ShaderPropertyId.Offset, fill2.offset);
					fill2.material.SetFloat(ShaderPropertyId.Softness, fill2.softness);
					fill2.material.SetFloat(ShaderPropertyId.Power, fill2.power);
					fill2.material.SetFloat(ShaderPropertyId.Width, fill2.width);
					fill2.material.SetFloat(ShaderPropertyId.Speed, fill2.speed);
					fill2.material.SetTexture(ShaderPropertyId.Texture, fill2.texture);
					fill2.material.SetFloat(ShaderPropertyId.Scale, fill2.scale);
					fill2.material.SetFloat(CommonShaderPropertyId.FullScreenStencilComparison, 3f);
					fill2.material.SetFloat(CommonShaderPropertyId.FullScreenStencilReference, 1 << num);
					fill2.material.SetFloat(CommonShaderPropertyId.FullScreenStencilReadMask, 1 << num);
					if (fill2.IsActive())
					{
						lastActiveFillIndex = num;
					}
					num++;
				}
				return settings.Fills.Any((Fill fill) => fill.IsActive());
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				PassData passData;
				using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Mask (Surface Fill)", out passData, ".\\Packages\\dev.ameye.linework\\Runtime\\SurfaceFill\\SurfaceFill.cs", 201))
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
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Fill (Surface Fill)", out passData2, ".\\Packages\\dev.ameye.linework\\Runtime\\SurfaceFill\\SurfaceFill.cs", 225);
				rasterRenderGraphBuilder2.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder2.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
				rasterRenderGraphBuilder2.AllowPassCulling(value: false);
				rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
				{
					int num = 0;
					foreach (Fill fill in settings.Fills)
					{
						if (!fill.IsActive())
						{
							num++;
						}
						else
						{
							if (num == lastActiveFillIndex)
							{
								fill.material.SetFloat(CommonShaderPropertyId.FullScreenStencilPass, 1f);
								fill.material.SetFloat(CommonShaderPropertyId.FullScreenStencilFail, 1f);
							}
							Blitter.BlitTexture(context.cmd, Vector2.one, fill.material, 0);
							num++;
						}
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
				RenderQueueRange opaque = RenderQueueRange.opaque;
				int num = 0;
				foreach (Fill fill in settings.Fills)
				{
					if (!fill.IsActive())
					{
						num++;
						continue;
					}
					DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, universalRenderingData, universalCameraData, lightData, defaultOpaqueSortFlags);
					drawingSettings.overrideMaterial = mask;
					FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, fill.RenderingLayer);
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
					renderStateBlock.mask |= RenderStateMask.Depth;
					renderStateBlock.depthState = fill.occlusion switch
					{
						Occlusion.Always => new DepthState(writeEnabled: false, CompareFunction.Always), 
						Occlusion.WhenOccluded => new DepthState(writeEnabled: false, CompareFunction.Greater), 
						Occlusion.WhenNotOccluded => new DepthState(writeEnabled: false, CompareFunction.LessEqual), 
						_ => throw new ArgumentOutOfRangeException(), 
					};
					RendererListHandle rendererListHandle = default(RendererListHandle);
					RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle);
					passData.MaskRendererListHandles.Add(rendererListHandle);
					if (fill.occlusion == Occlusion.WhenOccluded)
					{
						renderStateBlock.depthState = new DepthState(writeEnabled: false, CompareFunction.LessEqual);
						renderStateBlock.stencilReference = 0;
						defaultValue2.SetPassOperation(StencilOp.Replace);
						renderStateBlock.stencilState = defaultValue2;
						RendererListHandle rendererListHandle2 = default(RendererListHandle);
						RenderUtils.CreateRendererListWithRenderStateBlock(renderGraph, ref universalRenderingData.cullResults, drawingSettings, filteringSettings, renderStateBlock, ref rendererListHandle2);
						passData.MaskRendererListHandles.Add(rendererListHandle2);
					}
					num++;
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
					int num = 0;
					foreach (Fill fill in settings.Fills)
					{
						if (!fill.IsActive())
						{
							num++;
							continue;
						}
						DrawingSettings drawingSettings = RenderingUtils.CreateDrawingSettings(RenderUtils.DefaultShaderTagIds, ref renderingData, defaultOpaqueSortFlags);
						drawingSettings.overrideMaterial = mask;
						drawingSettings.overrideShaderPassIndex = 0;
						FilteringSettings filteringSettings = new FilteringSettings(opaque, -1, fill.RenderingLayer);
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
						stateBlock.mask |= RenderStateMask.Depth;
						stateBlock.depthState = fill.occlusion switch
						{
							Occlusion.Always => new DepthState(writeEnabled: false, CompareFunction.Always), 
							Occlusion.WhenOccluded => new DepthState(writeEnabled: false, CompareFunction.Greater), 
							Occlusion.WhenNotOccluded => new DepthState(writeEnabled: false, CompareFunction.LessEqual), 
							_ => throw new ArgumentOutOfRangeException(), 
						};
						context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings, ref stateBlock);
						if (fill.occlusion == Occlusion.WhenOccluded)
						{
							stateBlock.depthState = new DepthState(writeEnabled: false, CompareFunction.LessEqual);
							stateBlock.stencilReference = 0;
							defaultValue2.SetPassOperation(StencilOp.Replace);
							stateBlock.stencilState = defaultValue2;
							context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings, ref stateBlock);
						}
						num++;
					}
				}
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
				CommandBuffer commandBuffer2 = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer, fillSampler))
				{
					int num2 = 0;
					foreach (Fill fill2 in settings.Fills)
					{
						if (!fill2.IsActive())
						{
							num2++;
							continue;
						}
						if (num2 == lastActiveFillIndex)
						{
							fill2.material.SetFloat(CommonShaderPropertyId.FullScreenStencilPass, 1f);
							fill2.material.SetFloat(CommonShaderPropertyId.FullScreenStencilFail, 1f);
						}
						CoreUtils.SetRenderTarget(commandBuffer2, renderingData.cameraData.renderer.cameraColorTargetHandle, cameraDepthRTHandle);
						Blitter.BlitTexture(commandBuffer2, Vector2.one, fill2.material, 0);
						num2++;
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
		private SurfaceFillSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material fillMaterial;

		private SurfaceFillPass surfaceFillPass;

		public override void Create()
		{
			if (!(settings == null))
			{
				settings.OnSettingsChanged = null;
				SurfaceFillSettings surfaceFillSettings = settings;
				surfaceFillSettings.OnSettingsChanged = (Action)Delegate.Combine(surfaceFillSettings.OnSettingsChanged, new Action(Create));
				shaders = new ShaderResources().Load();
				if (surfaceFillPass == null)
				{
					surfaceFillPass = new SurfaceFillPass();
				}
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(settings == null) && renderingData.cameraData.cameraType != CameraType.Preview && renderingData.cameraData.cameraType != CameraType.Reflection && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView) && !UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
			{
				if (!CreateMaterials())
				{
					Debug.LogWarning("Not all required materials could be created. Surface Fill will not render.");
				}
				else if (surfaceFillPass.Setup(ref settings, ref maskMaterial, ref fillMaterial))
				{
					renderer.EnqueuePass(surfaceFillPass);
				}
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(settings == null) && (renderingData.cameraData.cameraType != CameraType.SceneView || settings.ShowInSceneView))
			{
				surfaceFillPass.ConfigureInput(ScriptableRenderPassInput.Color);
				surfaceFillPass.ConfigureInput(ScriptableRenderPassInput.Depth);
				surfaceFillPass.SetTarget(renderer.cameraDepthTargetHandle);
			}
		}

		protected override void Dispose(bool disposing)
		{
			surfaceFillPass?.Dispose();
			surfaceFillPass = null;
			DestroyMaterials();
		}

		private void OnDestroy()
		{
			settings = null;
			surfaceFillPass?.Dispose();
		}

		private void DestroyMaterials()
		{
			CoreUtils.Destroy(maskMaterial);
			CoreUtils.Destroy(fillMaterial);
		}

		private bool CreateMaterials()
		{
			if (maskMaterial == null)
			{
				maskMaterial = CoreUtils.CreateEngineMaterial(shaders.mask);
			}
			if (fillMaterial == null)
			{
				fillMaterial = CoreUtils.CreateEngineMaterial(shaders.fill);
			}
			if (maskMaterial != null)
			{
				return fillMaterial != null;
			}
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace HighlightPlus
{
	public class HighlightPlusRenderPassFeature : ScriptableRendererFeature
	{
		private class HighlightPass : ScriptableRenderPass
		{
			private class PassData
			{
				public Camera camera;

				public RTHandle colorTarget;

				public RTHandle depthTarget;

				public TextureHandle colorTexture;

				public TextureHandle depthTexture;

				public bool clearStencil;

				public CommandBuffer cmd;
			}

			private class DistanceComparer : IComparer<HighlightEffect>
			{
				public Vector3 camPos;

				public int Compare(HighlightEffect e1, HighlightEffect e2)
				{
					if (e1.sortingPriority < e2.sortingPriority)
					{
						return -1;
					}
					if (e1.sortingPriority > e2.sortingPriority)
					{
						return 1;
					}
					Vector3 position = e1.transform.position;
					float num = position.x - camPos.x;
					float num2 = position.y - camPos.y;
					float num3 = position.z - camPos.z;
					float num4 = num * num + num2 * num2 + num3 * num3 + e1.sortingOffset;
					Vector3 position2 = e2.transform.position;
					float num5 = position2.x - camPos.x;
					float num6 = position2.y - camPos.y;
					float num7 = position2.z - camPos.z;
					float num8 = num5 * num5 + num6 * num6 + num7 * num7 + e2.sortingOffset;
					if (num4 > num8)
					{
						return -1;
					}
					if (num4 < num8)
					{
						return 1;
					}
					return 0;
				}
			}

			private readonly PassData passData = new PassData();

			public bool usesCameraOverlay;

			private ScriptableRenderer renderer;

			private RenderTextureDescriptor cameraTextureDescriptor;

			private static DistanceComparer effectDistanceComparer = new DistanceComparer();

			private bool clearStencil;

			private static RenderTextureDescriptor sourceDesc;

			private static Material blockerOutlineAndGlowMat;

			private static Material blockerOverlayMat;

			private static Material blockerAllMat;

			public void Setup(HighlightPlusRenderPassFeature passFeature, ScriptableRenderer renderer)
			{
				base.renderPassEvent = passFeature.renderPassEvent;
				clearStencil = passFeature.clearStencil;
				this.renderer = renderer;
			}

			[Obsolete]
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				this.cameraTextureDescriptor = cameraTextureDescriptor;
				ConfigureInput(ScriptableRenderPassInput.Depth);
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				RTHandle cameraColorTargetHandle = renderer.cameraColorTargetHandle;
				RTHandle cameraDepthTargetHandle = renderer.cameraDepthTargetHandle;
				passData.clearStencil = clearStencil;
				passData.camera = renderingData.cameraData.camera;
				passData.colorTarget = cameraColorTargetHandle;
				passData.depthTarget = cameraDepthTargetHandle;
				sourceDesc = renderingData.cameraData.cameraTargetDescriptor;
				CommandBuffer commandBuffer = CommandBufferPool.Get("Highlight Plus");
				commandBuffer.Clear();
				passData.cmd = commandBuffer;
				ExecutePass(passData);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}

			private static void ExecutePass(PassData passData)
			{
				int count = HighlightEffect.effects.Count;
				HighlightEffect.effects.RemoveAll((HighlightEffect t) => t == null);
				count = HighlightEffect.effects.Count;
				if (count == 0)
				{
					return;
				}
				Camera camera = passData.camera;
				int num = 1 << camera.gameObject.layer;
				CameraType cameraType = camera.cameraType;
				if (!HighlightEffect.customSorting && ((cameraType == CameraType.Game && sortFrameCount++ % 10 == 0) || !Application.isPlaying))
				{
					effectDistanceComparer.camPos = camera.transform.position;
					HighlightEffect.effects.Sort(effectDistanceComparer);
				}
				bool flag = outlineAndGlowOccluders.Count > 0;
				for (int num2 = 0; num2 < count; num2++)
				{
					HighlightEffect highlightEffect = HighlightEffect.effects[num2];
					if ((!highlightEffect.ignoreObjectVisibility && !highlightEffect.isVisible) || !highlightEffect.isActiveAndEnabled || (cameraType == CameraType.Reflection && !highlightEffect.reflectionProbes) || ((int)highlightEffect.camerasLayerMask & num) == 0)
					{
						continue;
					}
					if (flag)
					{
						flag = false;
						foreach (HighlightEffectBlocker outlineAndGlowOccluder in outlineAndGlowOccluders)
						{
							if (!(outlineAndGlowOccluder != null) || !outlineAndGlowOccluder.isActiveAndEnabled)
							{
								continue;
							}
							int num3 = 0;
							if (outlineAndGlowOccluder.blockOutlineAndGlow)
							{
								num3 += 2;
							}
							if (outlineAndGlowOccluder.blockOverlay)
							{
								num3 += 4;
							}
							switch (num3)
							{
							case 2:
								if (blockerOutlineAndGlowMat == null)
								{
									blockerOutlineAndGlowMat = Resources.Load<Material>("HighlightPlus/HighlightBlockerOutlineAndGlow");
								}
								outlineAndGlowOccluder.BuildCommandBuffer(passData.cmd, blockerOutlineAndGlowMat);
								break;
							case 4:
								if (blockerOverlayMat == null)
								{
									blockerOverlayMat = Resources.Load<Material>("HighlightPlus/HighlightBlockerOverlay");
								}
								outlineAndGlowOccluder.BuildCommandBuffer(passData.cmd, blockerOverlayMat);
								break;
							case 6:
								if (blockerAllMat == null)
								{
									blockerAllMat = Resources.Load<Material>("HighlightPlus/HighlightUIMask");
								}
								outlineAndGlowOccluder.BuildCommandBuffer(passData.cmd, blockerAllMat);
								break;
							}
						}
					}
					highlightEffect.SetCommandBuffer(passData.cmd);
					highlightEffect.BuildCommandBuffer(passData.camera, passData.colorTarget, passData.depthTarget, passData.clearStencil, ref sourceDesc);
					passData.clearStencil = false;
				}
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				PassData passData;
				using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Highlight Plus Pass RG", out passData, "C:\\Users\\avgar\\dev\\SimplePlanes2\\SimplePlanesNext\\Assets\\Packages\\ThirdParty\\HighlightPlus\\Runtime\\Scripts\\HighlightPlusRenderPassFeature.cs", 184);
				unsafeRenderGraphBuilder.AllowPassCulling(value: false);
				passData.clearStencil = clearStencil;
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				passData.camera = universalCameraData.camera;
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				passData.colorTexture = universalResourceData.activeColorTexture;
				passData.depthTexture = universalResourceData.activeDepthTexture;
				unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture, AccessFlags.ReadWrite);
				unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeDepthTexture);
				unsafeRenderGraphBuilder.UseTexture(universalResourceData.cameraDepthTexture);
				ConfigureInput(ScriptableRenderPassInput.Depth);
				sourceDesc = universalCameraData.cameraTargetDescriptor;
				unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData passData2, UnsafeGraphContext context)
				{
					CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
					passData2.cmd = nativeCommandBuffer;
					passData2.colorTarget = passData2.colorTexture;
					passData2.depthTarget = passData2.depthTexture;
					ExecutePass(passData2);
				});
			}
		}

		private HighlightPass renderPass;

		public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;

		[Tooltip("Clears stencil buffer before rendering highlight effects. This option can solve compatibility issues with shaders that also use stencil buffers.")]
		public bool clearStencil;

		[Tooltip("If enabled, effects will be visible also in Edit mode (when not in Play mode).")]
		public bool previewInEditMode = true;

		[Tooltip("If enabled, effects will be visible also in Preview camera (preview camera shown when a camera is selected in Editor).")]
		public bool showInPreviewCamera = true;

		public static bool installed;

		public static bool showingInEditMode;

		public static List<HighlightEffectBlocker> outlineAndGlowOccluders = new List<HighlightEffectBlocker>();

		public static int sortFrameCount;

		private const string PREVIEW_CAMERA_NAME = "Preview Camera";

		private void OnDisable()
		{
			installed = false;
		}

		public override void Create()
		{
			renderPass = new HighlightPass();
			VRCheck.Init();
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			showingInEditMode = previewInEditMode;
			Camera camera = renderingData.cameraData.camera;
			if (renderingData.cameraData.renderType == CameraRenderType.Base)
			{
				renderPass.usesCameraOverlay = camera.GetUniversalAdditionalCameraData().cameraStack.Count > 0;
			}
			renderPass.Setup(this, renderer);
			renderer.EnqueuePass(renderPass);
			installed = true;
		}

		public static void RegisterBlocker(HighlightEffectBlocker occluder)
		{
			if (!outlineAndGlowOccluders.Contains(occluder))
			{
				outlineAndGlowOccluders.Add(occluder);
			}
		}

		public static void UnregisterBlocker(HighlightEffectBlocker occluder)
		{
			outlineAndGlowOccluders.Remove(occluder);
		}
	}
}

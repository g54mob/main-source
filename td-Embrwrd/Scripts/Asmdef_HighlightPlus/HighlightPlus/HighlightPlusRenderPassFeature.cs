using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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

				public bool clearStencil;

				public CommandBuffer cmd;
			}

			private class DistanceComparer : IComparer<HighlightEffect>
			{
				public Vector3 camPos;

				public int Compare(HighlightEffect e1, HighlightEffect e2)
				{
					return 0;
				}
			}

			private readonly PassData passData;

			public bool usesCameraOverlay;

			private ScriptableRenderer renderer;

			private RenderTextureDescriptor cameraTextureDescriptor;

			private static DistanceComparer effectDistanceComparer;

			private static Comparison<HighlightEffect> cachedEffectComparisonDelegate;

			private bool clearStencil;

			private static RenderTextureDescriptor sourceDesc;

			private static Material blockerOutlineAndGlowMat;

			private static Material blockerOverlayMat;

			private static Material blockerAllMat;

			public void Setup(HighlightPlusRenderPassFeature passFeature, ScriptableRenderer renderer)
			{
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			private static void ExecutePass(PassData passData)
			{
			}
		}

		private HighlightPass renderPass;

		public RenderPassEvent renderPassEvent;

		[Tooltip("Clears stencil buffer before rendering highlight effects. This option can solve compatibility issues with shaders that also use stencil buffers.")]
		public bool clearStencil;

		[Tooltip("If enabled, effects will be visible also in Edit mode (when not in Play mode).")]
		public bool previewInEditMode;

		[Tooltip("If enabled, effects will be visible also in Scene View.")]
		public bool showInSceneView;

		[Tooltip("If enabled, effects will be visible also in Preview camera (preview camera shown when a camera is selected in Editor).")]
		public bool showInPreviewCamera;

		public static bool installed;

		public static bool showingInEditMode;

		public static List<HighlightEffectBlocker> outlineAndGlowOccluders;

		public static int sortFrameCount;

		private const string PREVIEW_CAMERA_NAME = "Preview";

		private void OnDisable()
		{
		}

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public static void RegisterBlocker(HighlightEffectBlocker occluder)
		{
		}

		public static void UnregisterBlocker(HighlightEffectBlocker occluder)
		{
		}
	}
}

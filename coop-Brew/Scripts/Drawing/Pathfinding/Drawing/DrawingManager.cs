using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Pathfinding.Drawing
{
	[ExecuteAlways]
	[AddComponentMenu(null)]
	public class DrawingManager : MonoBehaviour
	{
		private struct GizmoDrawerGroup
		{
			public Type type;

			public ProfilerMarker profilerMarker;

			public List<IDrawGizmos> drawers;

			public bool enabled;
		}

		public DrawingData gizmos;

		private static List<GizmoDrawerGroup> gizmoDrawers;

		private static Dictionary<Type, int> gizmoDrawerIndices;

		private static DrawingManager _instance;

		private bool framePassed;

		private int lastFrameCount;

		private float lastFrameTime;

		private int lastFilterFrame;

		[SerializeField]
		private bool actuallyEnabled;

		private RedrawScope previousFrameRedrawScope;

		public static bool allowRenderToRenderTextures;

		public static bool drawToAllCameras;

		public static float lineWidthMultiplier;

		private CommandBuffer commandBuffer;

		[NonSerialized]
		private DetectedRenderPipeline detectedRenderPipeline;

		private HashSet<ScriptableRenderer> scriptableRenderersWithPass;

		private AlineURPRenderPassFeature renderPassFeature;

		private static readonly ProfilerMarker MarkerALINE;

		private static readonly ProfilerMarker MarkerCommandBuffer;

		private static readonly ProfilerMarker MarkerFrameTick;

		private static readonly ProfilerMarker MarkerFilterDestroyedObjects;

		internal static readonly ProfilerMarker MarkerRefreshSelectionCache;

		private static readonly ProfilerMarker MarkerGizmosAllowed;

		private static readonly ProfilerMarker MarkerDrawGizmos;

		private static readonly ProfilerMarker MarkerSubmitGizmos;

		private const float NO_DRAWING_TIMEOUT_SECS = 10f;

		public static DrawingManager instance => null;

		public static void Init()
		{
		}

		private void RefreshRenderPipelineMode()
		{
		}

		private void OnEnable()
		{
		}

		private void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
		}

		private void BeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
		{
		}

		private void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
		}

		private void OnDisable()
		{
		}

		private void OnEditorUpdate()
		{
		}

		private void Update()
		{
		}

		private void CleanupIfNoCameraRendered()
		{
		}

		internal void ExecuteCustomRenderPass(ScriptableRenderContext context, Camera camera)
		{
		}

		internal void ExecuteCustomRenderGraphPass(DrawingData.CommandBufferWrapper cmd, Camera camera)
		{
		}

		private void EndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
		}

		private void PostRender(Camera camera)
		{
		}

		private void CheckFrameTicking()
		{
		}

		internal void SubmitFrame(Camera camera, DrawingData.CommandBufferWrapper cmd, bool usingRenderPipeline)
		{
		}

		private bool ShouldDrawGizmos(UnityEngine.Object obj)
		{
			return false;
		}

		private static void RemoveDestroyedGizmoDrawers()
		{
		}

		private void Submit(Camera camera, DrawingData.CommandBufferWrapper cmd, bool usingRenderPipeline, bool allowCameraDefault)
		{
		}

		public static void Register(IDrawGizmos item)
		{
		}

		public static CommandBuilder GetBuilder(bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public static CommandBuilder GetBuilder(RedrawScope redrawScope, bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public static CommandBuilder GetBuilder(DrawingData.Hasher hasher, RedrawScope redrawScope = default(RedrawScope), bool renderInGame = false)
		{
			return default(CommandBuilder);
		}

		public static RedrawScope GetRedrawScope(GameObject associatedGameObject = null)
		{
			return default(RedrawScope);
		}
	}
}

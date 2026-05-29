using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Placemaker.TownRenderPipeline
{
	public class TRP : RenderPipeline
	{
		private TRPAsset asset;

		private CommandBuffer cmd;

		private List<Camera> cams;

		private Material shadowMat;

		private bool isAntialiasingSupported;

		public static int msaaCount;

		private static readonly ShaderTagId DEFAULT_TAG;

		private static readonly ShaderTagId DOOR_STENCIL_TAG;

		private static readonly ShaderTagId DOOR_HOLE_TAG;

		private static readonly ShaderTagId DOOR_COLOR_TAG;

		private static readonly ShaderTagId LATE_TAG;

		private static readonly ShaderTagId SHADOWS_TAG;

		public TRP(TRPAsset asset)
		{
		}

		protected override void Render(ScriptableRenderContext context, Camera[] cameras)
		{
		}

		private void RenderCamera(ref ScriptableRenderContext ctx, Camera cam)
		{
		}

		private void SkyboxClear(CommandBuffer cmd, Camera cam)
		{
		}

		private void SetupCameraAndCulling(ref ScriptableRenderContext ctx, Camera cam, out bool stereo, out CullingResults cullingResults)
		{
			stereo = default(bool);
			cullingResults = default(CullingResults);
		}

		private void DrawShadows(ref CullingResults cullingResults, ref ScriptableRenderContext ctx, Camera cam)
		{
		}

		private void DrawOpaque(ref CullingResults cullingResults, ref ScriptableRenderContext ctx, Camera cam)
		{
		}

		private void DrawLateOpaque(ref CullingResults cullingResults, ref ScriptableRenderContext ctx, Camera cam)
		{
		}

		private void DrawTransparent(ref CullingResults cullingResults, ref ScriptableRenderContext ctx, Camera cam)
		{
		}

		private void BeginCommandBuffer(string name)
		{
		}

		private void EndCommandBuffer(ref ScriptableRenderContext ctx)
		{
		}
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.Universal;

namespace CTS.Rendering
{
	public class RenderDepthPass : ScriptableRenderPass
	{
		private static readonly ShaderTagId DepthTagId = new ShaderTagId("DepthOnly");

		private static Queue<Camera> CameraPool = new Queue<Camera>();

		private static List<Camera> UsedCameras = new List<Camera>();

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			Matrix4x4 viewMatrix = renderingData.cameraData.GetViewMatrix();
			Matrix4x4 projectionMatrix = renderingData.cameraData.GetProjectionMatrix();
			CommandBuffer commandBuffer = CommandBufferPool.Get("DrawDepth");
			while (RenderDepthRequests.Requests.Count > 0)
			{
				DrawRequest(context, commandBuffer, renderingData.cullResults, RenderDepthRequests.Requests[0]);
				RenderDepthRequests.ClearRequest(0);
			}
			commandBuffer.SetViewProjectionMatrices(viewMatrix, projectionMatrix);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
			foreach (Camera usedCamera in UsedCameras)
			{
				if ((bool)usedCamera)
				{
					CameraPool.Enqueue(usedCamera);
				}
			}
			UsedCameras.Clear();
		}

		private void DrawRequest(ScriptableRenderContext context, CommandBuffer cmd, CullingResults cullingResults, RenderDepthRequest request)
		{
			Camera temporaryCamera = request.TemporaryCamera;
			if (temporaryCamera.TryGetCullingParameters(out var _))
			{
				RendererListDesc rendererListDesc = new RendererListDesc(DepthTagId, cullingResults, temporaryCamera);
				rendererListDesc.layerMask = request.LayerMask;
				rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
				RendererListDesc desc = rendererListDesc;
				RendererList rendererList = context.CreateRendererList(desc);
				cmd.SetViewProjectionMatrices(temporaryCamera.worldToCameraMatrix, temporaryCamera.projectionMatrix);
				CoreUtils.SetRenderTarget(cmd, request.RenderTarget, ClearFlag.Depth);
				CoreUtils.DrawRendererList(context, cmd, rendererList);
				UsedCameras.Add(request.TemporaryCamera);
				request.WasRendered = true;
			}
		}

		public static Camera GetCamera()
		{
			Camera camera = null;
			while (!camera && CameraPool.Count > 0)
			{
				camera = CameraPool.Dequeue();
			}
			if ((bool)camera)
			{
				return camera;
			}
			GameObject gameObject = new GameObject("PooledCamera");
			gameObject.SetActive(value: false);
			return gameObject.AddComponent<Camera>();
		}
	}
}

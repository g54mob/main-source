using UnityEngine;
using UnityEngine.XR;

namespace Coffee.UISoftMaskInternal
{
	internal static class CanvasExtensions
	{
		public static bool ShouldGammaToLinearInShader(this Canvas canvas)
		{
			if (QualitySettings.activeColorSpace == ColorSpace.Linear)
			{
				return canvas.vertexColorAlwaysGammaSpace;
			}
			return false;
		}

		public static bool ShouldGammaToLinearInMesh(this Canvas canvas)
		{
			if (QualitySettings.activeColorSpace == ColorSpace.Linear)
			{
				return !canvas.vertexColorAlwaysGammaSpace;
			}
			return false;
		}

		public static bool IsStereoCanvas(this Canvas canvas)
		{
			if (FrameCache.TryGet<bool>(canvas, "IsStereoCanvas", out var result))
			{
				return result;
			}
			result = canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay && canvas.worldCamera != null && XRSettings.enabled && !string.IsNullOrEmpty(XRSettings.loadedDeviceName);
			FrameCache.Set(canvas, "IsStereoCanvas", result);
			return result;
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vpMatrix)
		{
			canvas.GetViewProjectionMatrix(Camera.MonoOrStereoscopicEye.Mono, out vpMatrix);
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vpMatrix)
		{
			if (!FrameCache.TryGet<Matrix4x4>(canvas, "GetViewProjectionMatrix", out vpMatrix))
			{
				canvas.GetViewProjectionMatrix(eye, out var vMatrix, out var pMatrix);
				vpMatrix = vMatrix * pMatrix;
				FrameCache.Set(canvas, "GetViewProjectionMatrix", vpMatrix);
			}
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			canvas.GetViewProjectionMatrix(Camera.MonoOrStereoscopicEye.Mono, out vMatrix, out pMatrix);
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			if (FrameCache.TryGet<Matrix4x4>(canvas, "GetViewMatrix", (int)eye, out vMatrix) && FrameCache.TryGet<Matrix4x4>(canvas, "GetProjectionMatrix", (int)eye, out pMatrix))
			{
				return;
			}
			Canvas rootCanvas = canvas.rootCanvas;
			Camera worldCamera = rootCanvas.worldCamera;
			if ((bool)rootCanvas && rootCanvas.renderMode != RenderMode.ScreenSpaceOverlay && (bool)worldCamera)
			{
				if (eye == Camera.MonoOrStereoscopicEye.Mono)
				{
					vMatrix = worldCamera.worldToCameraMatrix;
					pMatrix = GL.GetGPUProjectionMatrix(worldCamera.projectionMatrix, renderIntoTexture: false);
				}
				else
				{
					pMatrix = worldCamera.GetStereoProjectionMatrix((Camera.StereoscopicEye)eye);
					vMatrix = worldCamera.GetStereoViewMatrix((Camera.StereoscopicEye)eye);
					pMatrix = GL.GetGPUProjectionMatrix(pMatrix, renderIntoTexture: false);
				}
			}
			else
			{
				Vector3 position = rootCanvas.transform.position;
				vMatrix = Matrix4x4.TRS(new Vector3(0f - position.x, 0f - position.y, -1000f), Quaternion.identity, new Vector3(1f, 1f, -1f));
				pMatrix = Matrix4x4.TRS(new Vector3(0f, 0f, -1f), Quaternion.identity, new Vector3(1f / position.x, 1f / position.y, -0.0002f));
			}
			FrameCache.Set(canvas, "GetViewMatrix", (int)eye, vMatrix);
			FrameCache.Set(canvas, "GetProjectionMatrix", (int)eye, pMatrix);
		}
	}
}

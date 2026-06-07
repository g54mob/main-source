using UnityEngine;
using UnityEngine.Rendering;

namespace Kamgam.SettingsGenerator
{
	public static class RenderUtils
	{
		public enum RenderPipe
		{
			BuiltIn = 0,
			URP = 1,
			HDRP = 2
		}

		private static Camera[] _tmpAllCameras = new Camera[10];

		public static RenderPipe GetCurrentRenderPipeline()
		{
			RenderPipelineAsset renderPipelineAsset = GraphicsSettings.currentRenderPipeline;
			if (renderPipelineAsset == null)
			{
				renderPipelineAsset = GraphicsSettings.defaultRenderPipeline;
			}
			if (renderPipelineAsset != null)
			{
				string name = renderPipelineAsset.GetType().Name;
				if (name == "UniversalRenderPipelineAsset")
				{
					return RenderPipe.URP;
				}
				if (name == "HDRenderPipelineAsset")
				{
					return RenderPipe.HDRP;
				}
			}
			return RenderPipe.BuiltIn;
		}

		public static int GetAllCameras(out Camera[] cameras)
		{
			int allCamerasCount = Camera.allCamerasCount;
			if (allCamerasCount > _tmpAllCameras.Length)
			{
				_tmpAllCameras = new Camera[allCamerasCount + 5];
			}
			Camera.GetAllCameras(_tmpAllCameras);
			for (int num = _tmpAllCameras.Length - 1; num >= 0; num--)
			{
				if (num >= allCamerasCount)
				{
					_tmpAllCameras[num] = null;
				}
			}
			cameras = _tmpAllCameras;
			return allCamerasCount;
		}

		public static Camera GetCurrentRenderingCamera(bool checkForMarker)
		{
			int num = 0;
			Camera[] cameras = null;
			if (checkForMarker)
			{
				num = GetAllCameras(out cameras);
				for (int num2 = cameras.Length - 1; num2 >= 0; num2--)
				{
					if (num2 >= num)
					{
						cameras[num2] = null;
					}
					else
					{
						Camera camera = cameras[num2];
						if (camera.TryGetComponent<SettingsMainCameraMarker>(out var _))
						{
							return camera;
						}
					}
				}
			}
			Camera camera2 = Camera.main;
			if (camera2 == null)
			{
				if (!checkForMarker)
				{
					num = GetAllCameras(out cameras);
				}
				float num3 = float.MinValue;
				for (int num4 = cameras.Length - 1; num4 >= 0; num4--)
				{
					if (num4 >= num)
					{
						cameras[num4] = null;
					}
					else
					{
						Camera camera3 = cameras[num4];
						if (camera3.isActiveAndEnabled && camera3.depth > num3 && camera3.targetTexture == null && camera3.rect.width >= 1f && camera3.rect.height >= 1f)
						{
							num3 = camera3.depth;
							camera2 = camera3;
						}
					}
				}
			}
			return camera2;
		}
	}
}

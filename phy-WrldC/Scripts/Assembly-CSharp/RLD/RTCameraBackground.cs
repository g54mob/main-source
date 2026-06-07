using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTCameraBackground : MonoSingleton<RTCameraBackground>
	{
		[SerializeField]
		private CameraBackgroundSettings _bkSettings = new CameraBackgroundSettings();

		[SerializeField]
		private List<Camera> _renderIgnoreCameras = new List<Camera>();

		private Dictionary<Camera, CameraBackgroundSettings> _cameraToBkSettings = new Dictionary<Camera, CameraBackgroundSettings>();

		public CameraBackgroundSettings Settings => _bkSettings;

		public void SetCameraBkSettings(Camera camera, CameraBackgroundSettings bkSettings)
		{
			if (bkSettings == null && _cameraToBkSettings.ContainsKey(camera))
			{
				_cameraToBkSettings.Remove(camera);
			}
			else if (!_cameraToBkSettings.ContainsKey(camera))
			{
				_cameraToBkSettings.Add(camera, bkSettings);
			}
			else
			{
				_cameraToBkSettings[camera] = bkSettings;
			}
		}

		public List<Camera> GetAllRenderIgnoreCameras()
		{
			return new List<Camera>(_renderIgnoreCameras);
		}

		public bool IsRenderIgnoreCamera(Camera camera)
		{
			return _renderIgnoreCameras.Contains(camera);
		}

		public void AddRenderIgnoreCamera(Camera camera)
		{
			if (!IsRenderIgnoreCamera(camera))
			{
				_renderIgnoreCameras.Add(camera);
			}
		}

		public void RemoveRenderIgnoreCamera(Camera camera)
		{
			_renderIgnoreCameras.Remove(camera);
		}

		public void Render_SystemCall()
		{
			Camera current = Camera.current;
			if (!IsRenderIgnoreCamera(current))
			{
				CameraBackgroundSettings cameraBackgroundSettings = _bkSettings;
				if (_cameraToBkSettings.ContainsKey(current))
				{
					cameraBackgroundSettings = _cameraToBkSettings[current];
				}
				if (cameraBackgroundSettings.IsVisible)
				{
					Transform transform = current.transform;
					QuadShape3D quadShape3D = new QuadShape3D();
					float frustumWidthFromDistance = current.GetFrustumWidthFromDistance(current.farClipPlane);
					float frustumHeightFromDistance = current.GetFrustumHeightFromDistance(current.farClipPlane);
					quadShape3D.Size = new Vector3(frustumWidthFromDistance + 0.01f, frustumHeightFromDistance + 0.01f, 1f);
					quadShape3D.Rotation = transform.rotation;
					quadShape3D.Center = transform.position + transform.forward * current.farClipPlane * 0.98f;
					Material linearGradientCameraBk = Singleton<MaterialPool>.Get.LinearGradientCameraBk;
					linearGradientCameraBk.SetColor("_FirstColor", cameraBackgroundSettings.FirstColor);
					linearGradientCameraBk.SetColor("_SecondColor", cameraBackgroundSettings.SecondColor);
					linearGradientCameraBk.SetFloat("_GradientOffset", cameraBackgroundSettings.GradientOffset);
					linearGradientCameraBk.SetFloat("_FarPlaneHeight", quadShape3D.Size.y);
					linearGradientCameraBk.SetPass(0);
					quadShape3D.RenderSolid();
				}
			}
		}
	}
}

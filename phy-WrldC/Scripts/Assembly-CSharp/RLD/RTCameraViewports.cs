using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTCameraViewports : Singleton<RTCameraViewports>
	{
		public delegate void CameraAddedHandler(Camera camera);

		public delegate void CameraRemovedHandler(Camera camera);

		public delegate void FocusCameraChangedHandler(Camera oldFocusCam, Camera newFocusCam);

		private List<Camera> _cameras = new List<Camera>();

		public Camera FocusCamera => MonoSingleton<RTFocusCamera>.Get.TargetCamera;

		public int NumCameras => _cameras.Count;

		public event CameraAddedHandler CameraAdded;

		public event CameraRemovedHandler CameraRemoved;

		public event FocusCameraChangedHandler FocusCameraChanged;

		public bool ContainsCamera(Camera camera)
		{
			return _cameras.Contains(camera);
		}

		public void AddCamera(Camera camera, Rect normViewRect)
		{
			if (camera != null && !ContainsCamera(camera))
			{
				_cameras.Add(camera);
				camera.rect = normViewRect;
				if (this.CameraAdded != null)
				{
					this.CameraAdded(camera);
				}
			}
		}

		public void AddCamera(Camera camera)
		{
			if (camera != null && !ContainsCamera(camera))
			{
				_cameras.Add(camera);
				if (this.CameraAdded != null)
				{
					this.CameraAdded(camera);
				}
			}
		}

		public void RemoveCamera(Camera camera)
		{
			if (!(camera == null))
			{
				_cameras.Remove(camera);
				if (this.CameraRemoved != null)
				{
					this.CameraRemoved(camera);
				}
			}
		}

		public void SetFocusCamera(int cameraIndex)
		{
			if (cameraIndex >= 0 && cameraIndex < NumCameras)
			{
				SetFocusCamera(_cameras[cameraIndex]);
			}
		}

		public void SetFocusCamera(Camera camera)
		{
			if (FocusCamera != camera && ContainsCamera(camera))
			{
				Camera focusCamera = FocusCamera;
				MonoSingleton<RTFocusCamera>.Get.SetTargetCamera(camera);
				if (this.FocusCameraChanged != null)
				{
					this.FocusCameraChanged(focusCamera, FocusCamera);
				}
			}
		}
	}
}

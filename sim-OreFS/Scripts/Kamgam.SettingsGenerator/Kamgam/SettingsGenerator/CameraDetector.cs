using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class CameraDetector : MonoBehaviour
	{
		public delegate void OnNewCameraFoundDelegate(Camera cam);

		public OnNewCameraFoundDelegate OnNewCameraFound;

		private static CameraDetector _instance;

		protected Camera[] _previousCameras = new Camera[10];

		protected Camera[] _cameras = new Camera[10];

		public static CameraDetector Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = new GameObject().AddComponent<CameraDetector>();
					_instance.name = _instance.GetType().ToString();
					Object.DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}

		public Camera[] Cameras => _cameras;

		private CameraDetector()
		{
		}

		private void Update()
		{
			for (int i = 0; i < _cameras.Length; i++)
			{
				_previousCameras[i] = _cameras[i];
				_cameras[i] = null;
			}
			increaseCapacity();
			Camera.GetAllCameras(_cameras);
			for (int j = 0; j < _cameras.Length; j++)
			{
				Camera camera = _cameras[j];
				if (camera != null && !contains(_previousCameras, camera))
				{
					OnNewCameraFound?.Invoke(camera);
				}
			}
		}

		protected void increaseCapacity()
		{
			if (_cameras.Length < Camera.allCamerasCount)
			{
				Camera[] array = new Camera[Camera.allCamerasCount];
				Camera[] array2 = new Camera[Camera.allCamerasCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = null;
					array2[i] = null;
				}
				for (int j = 0; j < _previousCameras.Length; j++)
				{
					array2[j] = _previousCameras[j];
				}
				_cameras = array;
				_previousCameras = array2;
			}
		}

		protected bool contains(Camera[] cameras, Camera cam)
		{
			for (int i = 0; i < cameras.Length; i++)
			{
				if (cameras[i] == cam)
				{
					return true;
				}
			}
			return false;
		}
	}
}

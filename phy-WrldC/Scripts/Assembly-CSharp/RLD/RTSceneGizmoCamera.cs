using UnityEngine;

namespace RLD
{
	public class RTSceneGizmoCamera : MonoBehaviour
	{
		private Camera _camera;

		private Transform _transform;

		private Vector3 _lookAtPoint = Vector3.zero;

		private float _fieldOfView = 60f;

		private float _orthoSize = 5f;

		private float _offsetFromFocusPt = 5f;

		private Camera _sceneCamera;

		private ISceneGizmoCamViewportUpdater _viewportUpdater;

		public Camera Camera => _camera;

		public Camera SceneCamera
		{
			get
			{
				return _sceneCamera;
			}
			set
			{
				if (value != null && _camera != null)
				{
					_sceneCamera = value;
					_camera.depth = _sceneCamera.depth + 1f;
				}
			}
		}

		public ISceneGizmoCamViewportUpdater ViewportUpdater
		{
			get
			{
				return _viewportUpdater;
			}
			set
			{
				if (value != null)
				{
					_viewportUpdater = value;
				}
			}
		}

		public Vector3 WorldPosition
		{
			get
			{
				return _transform.position;
			}
			set
			{
				_transform.position = value;
			}
		}

		public Quaternion WorldRotation
		{
			get
			{
				return _transform.rotation;
			}
			set
			{
				_transform.rotation = value;
			}
		}

		public Vector3 Right => _transform.right;

		public Vector3 Up => _transform.up;

		public Vector3 Look => _transform.forward;

		public Vector3 LookAtPoint => _lookAtPoint;

		public void Update_SystemCall()
		{
			WorldRotation = _sceneCamera.transform.rotation;
			WorldPosition = _lookAtPoint - Look * _offsetFromFocusPt;
			Camera.orthographic = _sceneCamera.orthographic;
			Camera.fieldOfView = _sceneCamera.fieldOfView;
			if (_viewportUpdater != null)
			{
				_viewportUpdater.Update(this);
			}
		}

		private void Awake()
		{
			_camera = base.gameObject.AddComponent<Camera>();
			_transform = _camera.transform;
		}

		private void Start()
		{
			_camera.cullingMask = 0;
			_camera.clearFlags = CameraClearFlags.Depth;
			_camera.renderingPath = RenderingPath.Forward;
			_camera.fieldOfView = _fieldOfView;
			_camera.orthographicSize = _orthoSize;
			_camera.allowHDR = false;
			if (MonoSingleton<RTCameraBackground>.Get != null)
			{
				MonoSingleton<RTCameraBackground>.Get.AddRenderIgnoreCamera(_camera);
			}
			MonoSingleton<RTSceneGrid>.Get.AddRenderIgnoreCamera(_camera);
			if (MonoSingleton<RTObjectSelection>.Get != null)
			{
				MonoSingleton<RTObjectSelection>.Get.AddRenderIgnoreCamera(_camera);
			}
		}
	}
}

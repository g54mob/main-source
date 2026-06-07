using System;
using Assets.Scripts.Flight.Cameras;
using UnityEngine;

namespace Assets.Scripts.XR
{
	public class XRCameraManagerScript : MonoBehaviour
	{
		public Camera _mainCamera;

		public Camera _planeCamera;

		private static XRCameraManagerScript _instance;

		private XRDeviceManager _deviceManger;

		[SerializeField]
		private GameObject _flatCameraRig;

		[SerializeField]
		private GameObject _xrCameraRig;

		private bool _xrCamerasEnabled;

		public static XRCameraManagerScript Instance
		{
			get
			{
				if (_instance == null)
				{
					Debug.LogError("XRCameraManagerScript singleton is null and cannot self-instantiate");
				}
				return _instance;
			}
			private set
			{
				if (_instance != null && value != null)
				{
					Debug.LogError("XRCameraManagerScript singleton has already been set");
				}
				_instance = value;
			}
		}

		public GameObject FlatCameraRig => _flatCameraRig;

		public Camera MainCamera => _mainCamera;

		public Camera PlaneCamera => _planeCamera;

		public bool XrCamerasEnabled
		{
			get
			{
				return _xrCamerasEnabled;
			}
			set
			{
				if (value != _xrCamerasEnabled)
				{
					SetXrCamerasEnabled(value);
				}
			}
		}

		public event Action<bool> OnXrCamerasEnabledChanged;

		protected virtual void Awake()
		{
			Instance = this;
			_deviceManger = Game.Instance.XRDeviceManager;
			if (Application.isEditor)
			{
				_ = _deviceManger.HmdActive;
			}
			_deviceManger.HmdActiveChanged += OnHmdActiveChanged;
			_deviceManger.HmdFailedToActivate += OnHmdFailedToActivate;
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
			_deviceManger.HmdActiveChanged -= OnHmdActiveChanged;
			_deviceManger.HmdFailedToActivate -= OnHmdFailedToActivate;
		}

		protected virtual void Start()
		{
			SetXrCamerasEnabled(xrCamerasEnabled: false);
			XrCamerasEnabled = _deviceManger.HmdActive;
		}

		private void OnHmdActiveChanged(bool active)
		{
			XrCamerasEnabled = active;
			if (!XrCamerasEnabled)
			{
				_deviceManger.SetXrActive(active: false);
			}
		}

		private void OnHmdFailedToActivate()
		{
			Debug.Log("HMD did not initialize in time...switching back to flat camera rig");
			_deviceManger.SetXrActive(active: false);
		}

		private void SetXrCamerasEnabled(bool xrCamerasEnabled)
		{
			_xrCamerasEnabled = xrCamerasEnabled;
			_xrCameraRig?.SetActive(xrCamerasEnabled);
			_flatCameraRig?.SetActive(!xrCamerasEnabled);
			if (!_xrCamerasEnabled && CameraManagerScript.Instance?.MainCamera != null)
			{
				CameraManagerScript.Instance.SetCameraFov(Game.Instance.Settings.Gameplay.Camera.FieldOfView);
			}
			this.OnXrCamerasEnabledChanged?.Invoke(xrCamerasEnabled);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Settings;
using Jundroo.Common.Events;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR;

namespace Assets.Scripts.XR
{
	public class XRDeviceManager : MonoBehaviour
	{
		public delegate void HmdBoolHandler(bool active);

		public delegate void HmdCustomOffsetChangedHandler(Pose? newOffset, Pose? oldOffset);

		public delegate void HmdVoidHandler();

		public delegate void XRDeviceConnectionHandler(InputDevice xrDevice);

		public const InputDeviceCharacteristics ControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller;

		public const InputDeviceCharacteristics HmdCharacteristics = InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice;

		public const InputDeviceCharacteristics LControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;

		public const float MaxHmdInitializationTime = 3f;

		public const InputDeviceCharacteristics RControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;

		private static XRDeviceManager _instance;

		private List<XRDisplaySubsystem> _displaySubsystems = new List<XRDisplaySubsystem>();

		private bool _headDisconnectedUnexpectedly;

		private InputDevice _hmd;

		private bool _hmdActive;

		private Pose? _hmdCustomOffset;

		private bool _initializingHmd;

		private float _initializingHmdstartTime;

		private List<XRInputSubsystem> _inputSubsystems = new List<XRInputSubsystem>();

		private bool _isDestroying;

		private InputDeviceCharacteristics? _lastControllerToDisconnect;

		private int _swapPreventionControllerCount;

		public static bool IsMockRuntime { get; private set; }

		public bool AutoSwitchSceneOnXRStateChanged { get; set; } = true;

		public List<XRDisplaySubsystem> DisplaySubsystems
		{
			get
			{
				SubsystemManager.GetSubsystems(_displaySubsystems);
				return _displaySubsystems;
			}
		}

		public bool HmdActive
		{
			get
			{
				return _hmdActive;
			}
			private set
			{
				bool hmdActive = _hmdActive;
				_hmdActive = value;
				IsMockRuntime = _hmdActive && OpenXRRuntime.name == "Unity Mock Runtime";
				if (hmdActive != _hmdActive)
				{
					this.HmdActiveChanged?.Invoke(_hmdActive);
				}
			}
		}

		public Pose? HmdCustomOffset
		{
			get
			{
				return _hmdCustomOffset;
			}
			private set
			{
				Pose? hmdCustomOffset = _hmdCustomOffset;
				_hmdCustomOffset = value;
				this.HmdCustomOffsetChanged?.Invoke(_hmdCustomOffset, hmdCustomOffset);
			}
		}

		public XRDisplaySubsystem PrimaryDisplaySubsystem => DisplaySubsystems?.FirstOrDefault();

		public IReadOnlyList<XRInputSubsystem> XRInputSubsystems
		{
			get
			{
				SubsystemManager.GetSubsystems(_inputSubsystems);
				return _inputSubsystems;
			}
		}

		public event HmdBoolHandler HmdActiveChanged;

		public event HmdCustomOffsetChangedHandler HmdCustomOffsetChanged;

		public event HmdVoidHandler HmdFailedToActivate;

		public event HmdBoolHandler HmdInitializationFinished;

		public event XRDeviceConnectionHandler XRControllersSwapping;

		public event XRDeviceConnectionHandler XRDeviceConnected;

		public event XRDeviceConnectionHandler XRDeviceDisconnected;

		public event EventHandler<EventArgs> XRPlatformViewReset;

		public static XRDeviceManager Create()
		{
			GameObject obj = new GameObject("XRDeviceManager");
			UnityEngine.Object.DontDestroyOnLoad(obj);
			XRDeviceManager xRDeviceManager = obj.AddComponent<XRDeviceManager>();
			xRDeviceManager.Initialize();
			return xRDeviceManager;
		}

		public void ApplyCustomOffsetToTransform(Transform offsetTrans)
		{
			Pose value = HmdCustomOffset.Value;
			offsetTrans.localPosition = value.position;
			offsetTrans.localRotation = value.rotation;
			HmdCustomOffset = new Pose(offsetTrans.localPosition, offsetTrans.localRotation);
		}

		public void ClearCustomOffset(Transform offsetTrans)
		{
			offsetTrans.localRotation = Quaternion.identity;
			offsetTrans.localPosition = Vector3.zero;
			HmdCustomOffset = new Pose(offsetTrans.localPosition, offsetTrans.localRotation);
		}

		public float GetDisplayRefreshRate(XRDisplaySubsystem displaySubsystem)
		{
			float displayRefreshRate = -1f;
			displaySubsystem?.TryGetDisplayRefreshRate(out displayRefreshRate);
			return displayRefreshRate;
		}

		public float GetPrimaryDisplayRefreshRate()
		{
			return GetDisplayRefreshRate(PrimaryDisplaySubsystem);
		}

		public void RecenterCustomOffset(Transform headsetTransform, Transform anchorTransform, Transform offsetTrans)
		{
			Quaternion rotation = Quaternion.FromToRotation(Vector3.ProjectOnPlane(headsetTransform.forward, anchorTransform.up), anchorTransform.forward) * offsetTrans.rotation;
			offsetTrans.rotation = rotation;
			Vector3 vector = anchorTransform.position - headsetTransform.position;
			offsetTrans.position += vector;
			HmdCustomOffset = new Pose(offsetTrans.localPosition, offsetTrans.localRotation);
		}

		public void SetXrActive(bool active)
		{
			SetXrActive(active, force: false, appClosing: false);
		}

		protected virtual void OnDestroy()
		{
			_isDestroying = true;
			SetXrActive(active: false, force: false, appClosing: true);
			SetDeviceConnectionCallbacks(subscribe: false);
			this.HmdActiveChanged = null;
			this.HmdFailedToActivate = null;
			this.XRDeviceConnected = null;
			this.XRDeviceDisconnected = null;
			this.HmdInitializationFinished = null;
			this.HmdCustomOffsetChanged = null;
			this.XRControllersSwapping = null;
		}

		protected virtual void Update()
		{
			if (_initializingHmd)
			{
				if (_initializingHmdstartTime < 0f)
				{
					_initializingHmdstartTime = Time.unscaledTime;
				}
				if (Time.unscaledTime - _initializingHmdstartTime > 3f)
				{
					_initializingHmd = false;
					SetXrActive(active: false, force: true, appClosing: false);
					this.HmdFailedToActivate?.Invoke();
					this.HmdInitializationFinished?.Invoke(active: false);
				}
			}
		}

		private void Initialize()
		{
			SetDeviceConnectionCallbacks(subscribe: true);
			List<InputDevice> list = new List<InputDevice>(3);
			InputDevices.GetDevices(list);
			foreach (InputDevice item in list)
			{
				OnDeviceConnected(item);
			}
			HmdActiveChanged += OnHmdActiveChanged;
			if (Game.Instance.Device.IsVRBuild && !Game.Instance.Device.IsVRExclusiveBuild)
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					UnityEngine.Object.Instantiate(Resources.Load("Flight/Gui/XRFlatOverlayMenu"));
				});
			}
		}

		private void OnBoundaryChanged(XRInputSubsystem inputSubsystem)
		{
			this.XRPlatformViewReset?.Invoke(inputSubsystem, EventArgs.Empty);
		}

		private void OnDeviceConnected(InputDevice xrDevice)
		{
			InputDeviceCharacteristics characteristics = xrDevice.characteristics;
			bool num = characteristics.HasFlag(InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice);
			if (characteristics.HasFlag(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller))
			{
				if (_swapPreventionControllerCount == 0 && characteristics == _lastControllerToDisconnect)
				{
					this.XRControllersSwapping?.Invoke(xrDevice);
					if (DebugSettings.XRControllerLogs)
					{
						Debug.LogError("Controller connected: Will result in a swap");
					}
				}
				else if (DebugSettings.XRControllerLogs)
				{
					Debug.Log("Controller connected: Will not result in a swap");
				}
				_swapPreventionControllerCount = Mathf.Clamp(_swapPreventionControllerCount + 1, 0, 2);
			}
			if (num)
			{
				if (_headDisconnectedUnexpectedly)
				{
					_headDisconnectedUnexpectedly = false;
					SetDeviceConnectionCallbacks(subscribe: false);
					SetXrActiveDirect(active: false);
					SetXrActiveDirect(active: true);
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
					{
						if (x == 0)
						{
							SetDeviceConnectionCallbacks(subscribe: true);
						}
					}, 2);
				}
				foreach (XRInputSubsystem xRInputSubsystem in XRInputSubsystems)
				{
					xRInputSubsystem.TrySetTrackingOriginMode(TrackingOriginModeFlags.Device);
					xRInputSubsystem.boundaryChanged += OnBoundaryChanged;
				}
				_initializingHmd = false;
				_hmd = xrDevice;
				HmdActive = true;
				this.HmdInitializationFinished?.Invoke(active: true);
			}
			this.XRDeviceConnected?.Invoke(xrDevice);
			if (DebugSettings.XRControllerLogs)
			{
				Debug.Log($"{Time.frameCount} - XR device connected: {xrDevice.name}");
			}
		}

		private void OnDeviceDisconnected(InputDevice xrDevice)
		{
			bool flag = xrDevice.subsystem != null;
			InputDeviceCharacteristics characteristics = xrDevice.characteristics;
			bool num = characteristics.HasFlag(InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice);
			bool flag2 = characteristics.HasFlag(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller);
			if (num)
			{
				foreach (XRInputSubsystem xRInputSubsystem in XRInputSubsystems)
				{
					xRInputSubsystem.boundaryChanged -= OnBoundaryChanged;
				}
				_headDisconnectedUnexpectedly = flag;
			}
			else if (flag2)
			{
				_swapPreventionControllerCount = Mathf.Clamp(_swapPreventionControllerCount - 1, 0, 2);
				_lastControllerToDisconnect = characteristics;
			}
			this.XRDeviceDisconnected?.Invoke(xrDevice);
			if (DebugSettings.XRControllerLogs)
			{
				Debug.Log($"{Time.frameCount} - XR device disconnected: {xrDevice.name}, unexpected: {flag}");
			}
		}

		private void OnHmdActiveChanged(bool active)
		{
			if (_isDestroying)
			{
				return;
			}
			Action action = delegate
			{
				if (!active)
				{
					bool fullScreenBackup = Screen.fullScreen;
					Screen.fullScreen = !Screen.fullScreen;
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(() => Screen.fullScreen = fullScreenBackup);
				}
			};
			bool flag = false;
			if (AutoSwitchSceneOnXRStateChanged && Game.Instance.SceneManager.CurrentScene != "Terrain")
			{
				flag = true;
				Game.Instance.SceneManager.LoadMenu(action);
			}
			Game.Instance.Settings.Quality.Physics.ApplyUnityPhysicsSettings();
			if (!flag)
			{
				action();
			}
		}

		private void SetDeviceConnectionCallbacks(bool subscribe)
		{
			if (subscribe)
			{
				InputDevices.deviceConnected += OnDeviceConnected;
				InputDevices.deviceDisconnected += OnDeviceDisconnected;
			}
			else
			{
				InputDevices.deviceConnected -= OnDeviceConnected;
				InputDevices.deviceDisconnected -= OnDeviceDisconnected;
			}
		}

		private void SetXrActive(bool active, bool force, bool appClosing)
		{
			if (_headDisconnectedUnexpectedly)
			{
				Debug.LogWarning($"SetXrActive({active}) was called after HMD unexpectdly disconnected");
				_headDisconnectedUnexpectedly = false;
			}
			if (!force && HmdActive == active)
			{
				return;
			}
			if (active)
			{
				SetXrActiveDirect(active);
				_initializingHmd = true;
				_initializingHmdstartTime = -1f;
			}
			else if (!Game.Instance.Device.IsVRExclusiveBuild || appClosing || force)
			{
				if (XRGeneralSettings.Instance.Manager.activeLoader != null)
				{
					SetXrActiveDirect(active);
					if (!appClosing)
					{
						HmdActive = false;
					}
				}
			}
			else
			{
				Debug.LogError("VR cannot be disabled in VR exclusive builds");
			}
		}

		private void SetXrActiveDirect(bool active)
		{
			if (active)
			{
				XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
				XRGeneralSettings.Instance.Manager.StartSubsystems();
			}
			else
			{
				XRGeneralSettings.Instance.Manager.StopSubsystems();
				XRGeneralSettings.Instance.Manager.DeinitializeLoader();
			}
		}

		[ContextMenu("Toggle XR")]
		private void ToggleXrInspectorWindow()
		{
			SetXrActive(!HmdActive);
		}
	}
}

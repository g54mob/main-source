using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Muna;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	[Tooltip("VideoKit camera manager for streaming video from camera devices.")]
	[HelpURL("https://videokit.ai/reference/videokitcameramanager")]
	[DisallowMultipleComponent]
	public sealed class VideoKitCameraManager : MonoBehaviour
	{
		[Flags]
		public enum Capabilities
		{
			Depth = 1,
			HumanTexture = 6
		}

		[Flags]
		public enum Facing
		{
			User = 2,
			World = 1
		}

		public enum Resolution
		{
			Default = 0,
			Lowest = 1,
			_640x480 = 2,
			[InspectorName("1280x720 (HD)")]
			_1280x720 = 3,
			[InspectorName("1920x1080 (Full HD)")]
			_1920x1080 = 4,
			[InspectorName("2560x1440 (2K)")]
			_2560x1440 = 6,
			[InspectorName("3840x2160 (4K)")]
			_3840x2160 = 5,
			Highest = 10
		}

		public enum FrameRate
		{
			Default = 0,
			Lowest = 1,
			_15 = 15,
			_30 = 30,
			_60 = 60,
			_120 = 120,
			_240 = 240
		}

		[Header("Configuration")]
		[Tooltip("Desired camera capabilities.")]
		public Capabilities capabilities;

		[Tooltip("Whether to start the camera preview as soon as the component awakes.")]
		public bool playOnAwake = true;

		[Header("Camera Selection")]
		[SerializeField]
		[Tooltip("Desired camera facing.")]
		private Facing _facing = Facing.User;

		[Tooltip("Whether the specified facing is required. When false, the camera manager will fallback to a default camera when a camera with the requested facing is not available.")]
		public bool facingRequired;

		[Header("Camera Settings")]
		[Tooltip("Desired camera resolution.")]
		public Resolution resolution = Resolution._1280x720;

		[Tooltip("Desired camera frame rate.")]
		public FrameRate frameRate = FrameRate._30;

		[Tooltip("Desired camera focus mode.")]
		public CameraDevice.FocusMode focusMode;

		[Tooltip("Desired camera exposure mode.")]
		public CameraDevice.ExposureMode exposureMode;

		private MediaDevice[]? devices;

		private MediaDevice? _device;

		internal const string HumanTextureTag = "@videokit/human-texture-2";

		public MediaDevice? device
		{
			get
			{
				return _device;
			}
			set
			{
				if (running)
				{
					_device.StopRunning();
					_device = value;
					if (_device != null)
					{
						StartRunning(_device, OnCameraBuffer);
					}
				}
				else
				{
					_device = value;
				}
			}
		}

		public Facing facing
		{
			get
			{
				return _facing;
			}
			set
			{
				if (_facing != value)
				{
					device = GetDefaultDevice(devices, _facing = value, facingRequired);
				}
			}
		}

		public bool running => _device?.running ?? false;

		public event Action<CameraDevice, PixelBuffer>? OnPixelBuffer;

		public async void StartRunning()
		{
			await StartRunningAsync();
		}

		public async Task StartRunningAsync()
		{
			if (!base.isActiveAndEnabled)
			{
				throw new InvalidOperationException("VideoKit: Camera manager failed to start running because component is disabled");
			}
			if (running)
			{
				return;
			}
			if (await CameraDevice.CheckPermissions() != MediaDevice.PermissionStatus.Authorized)
			{
				throw new InvalidOperationException("VideoKit: User did not grant camera permissions");
			}
			devices = await GetAllDevices();
			if (_device == null)
			{
				_device = GetDefaultDevice(devices, _facing, facingRequired);
			}
			if (_device == null)
			{
				throw new InvalidOperationException("VideoKit: Camera manager failed to start running because no camera device is available");
			}
			foreach (CameraDevice item in EnumerateCameraDevices(_device))
			{
				if (resolution != Resolution.Default)
				{
					item.previewResolution = GetResolutionFrameSize(resolution);
				}
				if (frameRate != FrameRate.Default)
				{
					item.frameRate = (float)frameRate;
				}
				if (item.IsFocusModeSupported(focusMode))
				{
					item.focusMode = focusMode;
				}
				if (item.IsExposureModeSupported(exposureMode))
				{
					item.exposureMode = exposureMode;
				}
			}
			global::Muna.Muna muna = VideoKitClient.Instance.muna;
			if (capabilities.HasFlag(Capabilities.HumanTexture))
			{
				try
				{
					await muna.Predictions.Create("@videokit/human-texture-2", new Dictionary<string, object>(), Acceleration.Auto, (IntPtr)0);
				}
				catch
				{
					string path = Path.Join(Application.persistentDataPath, "fxn", "predictors");
					if (Directory.Exists(path))
					{
						Directory.Delete(path, recursive: true);
					}
				}
				await muna.Predictions.Create("@videokit/human-texture-2", new Dictionary<string, object>(), Acceleration.Auto, (IntPtr)0);
			}
			StartRunning(_device, OnCameraBuffer);
			VideoKitEvents instance = VideoKitEvents.Instance;
			instance.onPause += OnPause;
			instance.onResume += OnResume;
			instance.onQuit += StopRunning;
		}

		public void StopRunning()
		{
			VideoKitEvents optionalInstance = VideoKitEvents.OptionalInstance;
			if (optionalInstance != null)
			{
				optionalInstance.onPause -= OnPause;
				optionalInstance.onResume -= OnResume;
				optionalInstance.onQuit -= StopRunning;
			}
			if (running)
			{
				_device?.StopRunning();
			}
		}

		private void Awake()
		{
			if (playOnAwake)
			{
				StartRunning();
			}
		}

		private static void StartRunning(MediaDevice device, Action<CameraDevice, PixelBuffer> handler)
		{
			CameraDevice cameraDevice = device as CameraDevice;
			if (cameraDevice != null)
			{
				cameraDevice.StartRunning(delegate(PixelBuffer pixelBuffer)
				{
					handler(cameraDevice, pixelBuffer);
				});
				return;
			}
			if (device is MultiCameraDevice multiCameraDevice)
			{
				multiCameraDevice.StartRunning(handler);
				return;
			}
			throw new InvalidOperationException($"Cannot start running because media device has unsupported type: {device.GetType()}");
		}

		private void OnCameraBuffer(CameraDevice cameraDevice, PixelBuffer pixelBuffer)
		{
			this.OnPixelBuffer?.Invoke(cameraDevice, pixelBuffer);
		}

		private void OnPause()
		{
			_device?.StopRunning();
		}

		private void OnResume()
		{
			if (_device != null)
			{
				StartRunning(_device, OnCameraBuffer);
			}
		}

		private void OnDestroy()
		{
			StopRunning();
		}

		internal static IEnumerable<CameraDevice> EnumerateCameraDevices(MediaDevice? device)
		{
			if (device is CameraDevice cameraDevice)
			{
				yield return cameraDevice;
			}
			else if (device is MultiCameraDevice multiCameraDevice)
			{
				CameraDevice[] cameras = multiCameraDevice.cameras;
				for (int i = 0; i < cameras.Length; i++)
				{
					yield return cameras[i];
				}
			}
		}

		internal static Facing GetCameraFacing(MediaDevice mediaDevice)
		{
			if (!(mediaDevice is CameraDevice cameraDevice))
			{
				if (mediaDevice is MultiCameraDevice multiCameraDevice)
				{
					return multiCameraDevice.cameras.Select(GetCameraFacing).Aggregate((Facing a, Facing b) => a | b);
				}
				return (Facing)0;
			}
			return (!cameraDevice.frontFacing) ? Facing.World : Facing.User;
		}

		private static async Task<MediaDevice[]> GetAllDevices()
		{
			CameraDevice[] cameraDevices = await CameraDevice.Discover();
			MultiCameraDevice[] second = await MultiCameraDevice.Discover();
			return cameraDevices.Cast<MediaDevice>().Concat(second).ToArray();
		}

		private static MediaDevice? GetDefaultDevice(MediaDevice[]? devices, Facing facing, bool facingRequired)
		{
			facing &= Facing.User | Facing.World;
			MediaDevice mediaDevice = (facingRequired ? null : devices?.FirstOrDefault());
			return devices?.FirstOrDefault((MediaDevice device) => GetCameraFacing(device).HasFlag(facing)) ?? mediaDevice;
		}

		private static (int width, int height) GetResolutionFrameSize(Resolution resolution)
		{
			return resolution switch
			{
				Resolution.Lowest => (width: 176, height: 144), 
				Resolution._640x480 => (width: 640, height: 480), 
				Resolution._1280x720 => (width: 1280, height: 720), 
				Resolution._1920x1080 => (width: 1920, height: 1080), 
				Resolution._2560x1440 => (width: 2560, height: 1440), 
				Resolution._3840x2160 => (width: 3840, height: 2160), 
				Resolution.Highest => (width: 5120, height: 2880), 
				_ => (width: 1280, height: 720), 
			};
		}
	}
}

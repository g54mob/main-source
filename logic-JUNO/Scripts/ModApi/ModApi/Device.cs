using UnityEngine;

namespace ModApi
{
	public class Device : IDevice
	{
		public static float Dpi { get; private set; }

		public static bool IsAndroidBuild { get; private set; }

		public static bool IsAndroidRuntime { get; private set; }

		public static bool IsDebugBuild { get; private set; }

		public static bool IsEducationBuild { get; private set; }

		public static bool IsFreemiumBuild { get; private set; }

		public static bool IsIosBuild { get; private set; }

		public static bool IsIosRuntime { get; private set; }

		public static bool IsLinuxBuild { get; private set; }

		public static bool IsLinuxRuntime { get; private set; }

		public static bool IsMobileBuild { get; private set; }

		public static bool IsMobileRuntime { get; private set; }

		public static bool IsMultiTouchEnabled { get; private set; }

		public static bool IsOsxBuild { get; private set; }

		public static bool IsOsxRuntime { get; private set; }

		public static bool IsTablet { get; private set; }

		public static bool IsTouchEnabled { get; private set; }

		public static bool IsUnityEditor { get; private set; }

		public static bool IsWindowsBuild { get; private set; }

		public static bool IsWindowsRuntime { get; private set; }

		public static string StoreId
		{
			get
			{
				_ = Application.isEditor;
				RuntimePlatform platform = Application.platform;
				if (platform != RuntimePlatform.OSXPlayer && platform != RuntimePlatform.IPhonePlayer)
				{
					_ = 11;
				}
				return "Steam";
			}
		}

		public string DeviceCaps => "Device Model: " + SystemInfo.deviceModel + "\nDeviceType: " + SystemInfo.deviceType.ToString() + "\nScreen Size: " + Screen.width + "x" + Screen.height + "\nResolution: " + Screen.currentResolution.width + "x" + Screen.currentResolution.height + "\nRefresh Rate: " + Screen.currentResolution.refreshRateRatio.value + "\nTarget Framerate: " + Application.targetFrameRate + "\nVSync Count: " + QualitySettings.vSyncCount + "\nFull Screen: " + Screen.fullScreen + "\nScreen DPI: " + Screen.dpi + "\nSafe Area: " + Screen.safeArea.ToString() + "\nGraphicsDeviceID: " + SystemInfo.graphicsDeviceID + "\nGraphicsDeviceName: " + SystemInfo.graphicsDeviceName + "\nGraphicsDeviceType: " + SystemInfo.graphicsDeviceType.ToString() + "\nGraphicsDeviceVendor: " + SystemInfo.graphicsDeviceVendor + "\nGraphicsDeviceVendorID: " + SystemInfo.graphicsDeviceVendorID + "\nGraphicsDeviceVersion: " + SystemInfo.graphicsDeviceVersion + "\nGraphicsMemorySize: " + SystemInfo.graphicsMemorySize + "\nGraphicsMultiThreaded: " + SystemInfo.graphicsMultiThreaded + "\nGraphicsShaderLevel: " + SystemInfo.graphicsShaderLevel + "\nMaxTextureSize: " + SystemInfo.maxTextureSize + "\nNpotSupport: " + SystemInfo.npotSupport.ToString() + "\nOperatingSystem: " + SystemInfo.operatingSystem + "\nProcessorCount: " + SystemInfo.processorCount + "\nProcessorFrequency: " + SystemInfo.processorFrequency + "\nProcessorType: " + SystemInfo.processorType + "\nSupportedRenderTargetCount: " + SystemInfo.supportedRenderTargetCount + "\nSupports2DTextureArrays: " + SystemInfo.supports2DArrayTextures + "\nSupports3DTextures: " + SystemInfo.supports3DTextures + "\nSupportsAccelerometer: " + SystemInfo.supportsAccelerometer + "\nSupportsAsyncGPUReadback: " + SystemInfo.supportsAsyncGPUReadback + "\nSupportsComputeShaders: " + SystemInfo.supportsComputeShaders + "\nSupportsGyroscope: " + SystemInfo.supportsGyroscope + "\nSupportsInstancing: " + SystemInfo.supportsInstancing + "\nSupportsLocationService: " + SystemInfo.supportsLocationService + "\nSupportsShadows: " + SystemInfo.supportsShadows + "\nSupportsSparseTextures: " + SystemInfo.supportsSparseTextures + "\nSupportsVibration: " + SystemInfo.supportsVibration + "\nSystemMemorySize: " + SystemInfo.systemMemorySize;

		public string DeviceId => SystemInfo.deviceUniqueIdentifier;

		public string DeviceModel => SystemInfo.deviceModel;

		public string DeviceName => SystemInfo.deviceName;

		float IDevice.Dpi => Dpi;

		bool IDevice.IsAndroidBuild => IsAndroidBuild;

		bool IDevice.IsAndroidRuntime => IsAndroidRuntime;

		bool IDevice.IsDebugBuild => IsDebugBuild;

		bool IDevice.IsEducationBuild => IsEducationBuild;

		bool IDevice.IsFreemiumBuild => IsFreemiumBuild;

		bool IDevice.IsIosBuild => IsIosBuild;

		bool IDevice.IsIosRuntime => IsIosRuntime;

		bool IDevice.IsLinuxBuild => IsLinuxBuild;

		bool IDevice.IsLinuxRuntime => IsLinuxRuntime;

		bool IDevice.IsMobileBuild => IsMobileBuild;

		bool IDevice.IsMobileRuntime => IsMobileRuntime;

		bool IDevice.IsMultiTouchEnabled => IsMultiTouchEnabled;

		bool IDevice.IsOsxBuild => IsOsxBuild;

		bool IDevice.IsOsxRuntime => IsOsxRuntime;

		bool IDevice.IsTablet => IsTablet;

		bool IDevice.IsTouchEnabled => IsTouchEnabled;

		bool IDevice.IsUnityEditor => IsUnityEditor;

		bool IDevice.IsWindowsBuild => IsWindowsBuild;

		bool IDevice.IsWindowsRuntime => IsWindowsRuntime;

		static Device()
		{
			IsTablet = IsTabletScreen();
			IsUnityEditor = false;
			IsMobileRuntime = Application.isMobilePlatform;
			IsMobileBuild = IsMobileRuntime;
			IsAndroidRuntime = Application.platform == RuntimePlatform.Android;
			IsAndroidBuild = IsAndroidRuntime;
			IsIosRuntime = Application.platform == RuntimePlatform.IPhonePlayer;
			IsIosBuild = IsIosRuntime;
			IsWindowsRuntime = Application.platform == RuntimePlatform.WindowsPlayer;
			IsWindowsBuild = IsWindowsRuntime;
			IsOsxRuntime = Application.platform == RuntimePlatform.OSXPlayer;
			IsOsxBuild = IsOsxRuntime;
			IsLinuxRuntime = Application.platform == RuntimePlatform.LinuxPlayer;
			IsLinuxBuild = IsLinuxRuntime;
			IsDebugBuild = false;
			IsEducationBuild = false;
			IsFreemiumBuild = false;
			IsTouchEnabled = UnityEngine.Input.touchSupported;
			IsMultiTouchEnabled = UnityEngine.Input.multiTouchEnabled && IsTouchEnabled;
			Dpi = Screen.dpi;
			if (Dpi <= 0f)
			{
				if (IsMobileBuild)
				{
					Dpi = 350f;
				}
				else
				{
					Dpi = 100f;
				}
			}
		}

		public static void EnableMobileBuildEmulation(bool isTablet)
		{
			IsMobileBuild = true;
			IsTablet = isTablet;
		}

		private static bool IsMobileResolution()
		{
			bool flag = (Screen.width == 1334 && Screen.height == 750) || (Screen.width == 2436 && Screen.height == 1125) || (Screen.width == 2532 && Screen.height == 1170) || (Screen.width == 2208 && Screen.height == 1242) || (Screen.width == 2688 && Screen.height == 1242);
			if (flag)
			{
				Debug.LogFormat("Detected Mobile Resolution: {0}x{1}", Screen.width, Screen.height);
			}
			return flag;
		}

		private static bool IsTabletScreen()
		{
			bool flag = false;
			float num = 0f;
			float num2 = 0f;
			if (Screen.dpi > 0f && SystemInfo.deviceType == DeviceType.Handheld)
			{
				num = (float)Screen.width / Screen.dpi;
				num2 = (float)Screen.height / Screen.dpi;
				flag = Mathf.Sqrt(num * num + num2 * num2) > 7f;
			}
			else if (Application.isEditor && ((Screen.width == 1024 && Screen.height == 768) || (Screen.width == 2732 && Screen.height == 2048) || (Screen.width == 2048 && Screen.height == 1536)))
			{
				flag = true;
			}
			if (flag)
			{
				Debug.LogFormat("Detected Tablet Screen: {0}\" x {1}\" and DPI is {2}", num, num2, Screen.dpi);
			}
			return flag;
		}
	}
}

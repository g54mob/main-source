using System;
using UnityEngine;

namespace Jundroo.Common.Platform
{
	public class Device : IDevice
	{
		public static IDevice CurrentDevice { get; private set; }

		public static float Dpi { get; private set; }

		public static DeviceFlags Flags { get; private set; }

		public static bool IsAndroidBuild { get; private set; }

		public static bool IsAndroidRuntime { get; private set; }

		public static bool IsAndroidVRBuild { get; private set; }

		public static bool IsDebugBuild { get; private set; }

		public static bool IsDemoBuild { get; private set; }

		public static bool IsEducationBuild { get; private set; }

		public static bool IsIosBuild { get; private set; }

		public static bool IsIosRuntime { get; private set; }

		public static bool IsLinuxBuild { get; private set; }

		public static bool IsLinuxRuntime { get; private set; }

		public static bool IsMobileBuild { get; private set; }

		public static bool IsMobileRuntime { get; private set; }

		public static bool IsMultiTouchEnabled { get; private set; }

		public static bool IsOculusQuest1 { get; }

		public static bool IsOculusQuestBuild { get; private set; }

		public static bool IsOsxBuild { get; private set; }

		public static bool IsOsxRuntime { get; private set; }

		public static bool IsPCVRExclusiveBuild { get; private set; }

		public static bool IsPicoXRBuild { get; private set; }

		public static bool IsTablet { get; private set; }

		public static bool IsTouchEnabled { get; private set; }

		public static bool IsUnityEditor { get; private set; }

		public static bool IsUnityEditorApplicationPaused => false;

		public static bool IsVRBuild { get; private set; }

		public static bool IsVRExclusiveBuild { get; private set; }

		public static bool IsWindowsBuild { get; private set; }

		public static bool IsWindowsRuntime { get; private set; }

		public string DeviceCaps => "Device Model: " + SystemInfo.deviceModel + "\nDeviceType: " + SystemInfo.deviceType.ToString() + "\nScreen Size: " + Screen.width + "x" + Screen.height + "\nResolution: " + Screen.currentResolution.width + "x" + Screen.currentResolution.height + "\nRefresh Rate: " + Screen.currentResolution.refreshRateRatio.value + "\nTarget Framerate: " + Application.targetFrameRate + "\nVSync Count: " + QualitySettings.vSyncCount + "\nFull Screen: " + Screen.fullScreen + "\nScreen DPI: " + Screen.dpi + "\nSafe Area: " + Screen.safeArea.ToString() + "\nGraphicsDeviceID: " + SystemInfo.graphicsDeviceID + "\nGraphicsDeviceName: " + SystemInfo.graphicsDeviceName + "\nGraphicsDeviceType: " + SystemInfo.graphicsDeviceType.ToString() + "\nGraphicsDeviceVendor: " + SystemInfo.graphicsDeviceVendor + "\nGraphicsDeviceVendorID: " + SystemInfo.graphicsDeviceVendorID + "\nGraphicsDeviceVersion: " + SystemInfo.graphicsDeviceVersion + "\nGraphicsMemorySize: " + SystemInfo.graphicsMemorySize + "\nGraphicsMultiThreaded: " + SystemInfo.graphicsMultiThreaded + "\nGraphicsShaderLevel: " + SystemInfo.graphicsShaderLevel + "\nMaxTextureSize: " + SystemInfo.maxTextureSize + "\nNpotSupport: " + SystemInfo.npotSupport.ToString() + "\nOperatingSystem: " + SystemInfo.operatingSystem + "\nProcessorCount: " + SystemInfo.processorCount + "\nProcessorFrequency: " + SystemInfo.processorFrequency + "\nProcessorType: " + SystemInfo.processorType + "\nSupportedRenderTargetCount: " + SystemInfo.supportedRenderTargetCount + "\nSupports2DTextureArrays: " + SystemInfo.supports2DArrayTextures + "\nSupports3DTextures: " + SystemInfo.supports3DTextures + "\nSupportsAccelerometer: " + SystemInfo.supportsAccelerometer + "\nSupportsAsyncGPUReadback: " + SystemInfo.supportsAsyncGPUReadback + "\nSupportsComputeShaders: " + SystemInfo.supportsComputeShaders + "\nSupportsGyroscope: " + SystemInfo.supportsGyroscope + "\nSupportsInstancing: " + SystemInfo.supportsInstancing + "\nSupportsLocationService: " + SystemInfo.supportsLocationService + "\nSupportsShadows: " + SystemInfo.supportsShadows + "\nSupportsSparseTextures: " + SystemInfo.supportsSparseTextures + "\nSupportsVibration: " + SystemInfo.supportsVibration + "\nSystemMemorySize: " + SystemInfo.systemMemorySize;

		public string DeviceId => SystemInfo.deviceUniqueIdentifier;

		public string DeviceModel => SystemInfo.deviceModel;

		public string DeviceName => SystemInfo.deviceName;

		float IDevice.Dpi => Dpi;

		DeviceFlags IDevice.Flags => Flags;

		bool IDevice.IsAndroidBuild => IsAndroidBuild;

		bool IDevice.IsAndroidRuntime => IsAndroidRuntime;

		bool IDevice.IsAndroidVRBuild => IsAndroidVRBuild;

		bool IDevice.IsDebugBuild => IsDebugBuild;

		bool IDevice.IsDemoBuild => IsDemoBuild;

		bool IDevice.IsDesktopBuild => !IsMobileBuild;

		bool IDevice.IsEducationBuild => IsEducationBuild;

		bool IDevice.IsIosBuild => IsIosBuild;

		bool IDevice.IsIosRuntime => IsIosRuntime;

		bool IDevice.IsLinuxBuild => IsLinuxBuild;

		bool IDevice.IsLinuxRuntime => IsLinuxRuntime;

		bool IDevice.IsMobileBuild => IsMobileBuild;

		bool IDevice.IsMobileRuntime => IsMobileRuntime;

		bool IDevice.IsMultiTouchEnabled => IsMultiTouchEnabled;

		bool IDevice.IsOculusQuest1 => IsOculusQuest1;

		bool IDevice.IsOculusQuestBuild => IsOculusQuestBuild;

		bool IDevice.IsOsxBuild => IsOsxBuild;

		bool IDevice.IsOsxRuntime => IsOsxRuntime;

		bool IDevice.IsPCVRExclusiveBuild => IsPCVRExclusiveBuild;

		bool IDevice.IsPicoXRBuild => IsPicoXRBuild;

		bool IDevice.IsTablet => IsTablet;

		bool IDevice.IsTouchEnabled => IsTouchEnabled;

		bool IDevice.IsUnityEditor => IsUnityEditor;

		bool IDevice.IsUnityEditorApplicationPaused => IsUnityEditorApplicationPaused;

		bool IDevice.IsVRBuild => IsVRBuild;

		bool IDevice.IsVRExclusiveBuild => IsVRExclusiveBuild;

		bool IDevice.IsWindowsBuild => IsWindowsBuild;

		bool IDevice.IsWindowsRuntime => IsWindowsRuntime;

		static Device()
		{
			CurrentDevice = new Device();
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
			IsDemoBuild = false;
			IsEducationBuild = false;
			IsOculusQuestBuild = false;
			IsPicoXRBuild = false;
			IsAndroidVRBuild = IsOculusQuestBuild || IsPicoXRBuild;
			IsVRBuild = true;
			IsPCVRExclusiveBuild = false;
			IsVRExclusiveBuild = IsAndroidVRBuild || IsPCVRExclusiveBuild;
			IsTouchEnabled = Input.touchSupported && IsMobileBuild;
			IsMultiTouchEnabled = Input.multiTouchEnabled && IsTouchEnabled;
			if (IsOculusQuestBuild)
			{
				IsOculusQuest1 = SystemInfo.systemMemorySize <= 4096;
			}
			Dpi = CalculateDpi();
			SetupDeviceFlags();
		}

		public static void AddDeviceFlags(DeviceFlags flags)
		{
			Flags |= flags;
		}

		public static void EnableMobileBuildEmulation(bool isTablet)
		{
			IsMobileBuild = true;
			IsTablet = isTablet;
		}

		public static string GetCurrentFlagsAsString()
		{
			string text = string.Empty;
			foreach (DeviceFlags value in Enum.GetValues(typeof(DeviceFlags)))
			{
				if (Flags.HasFlag(value))
				{
					text = text + value.ToString() + ",";
				}
			}
			return text.TrimEnd(',');
		}

		public static bool HasAnyFlag(DeviceFlags flags)
		{
			return (flags & Flags) > (DeviceFlags)0;
		}

		public static void ToggleTouchEnabled()
		{
			IsTouchEnabled = !IsTouchEnabled;
		}

		bool IDevice.HasAnyFlag(DeviceFlags flags)
		{
			return (flags & Flags) > (DeviceFlags)0;
		}

		void IDevice.ToggleTouchEnabled()
		{
			ToggleTouchEnabled();
		}

		private static float CalculateDpi()
		{
			float num = Screen.dpi;
			if (num <= 0f)
			{
				num = ((!IsMobileBuild) ? 100f : 350f);
			}
			return num;
		}

		private static int GetAndroidGpuModelNumber(string gpuName, string prefix)
		{
			int result = 0;
			try
			{
				string text = gpuName.Replace(prefix, string.Empty).Trim();
				string text2 = string.Empty;
				for (int i = 0; i < text.Length && char.IsNumber(text[i]); i++)
				{
					text2 += text[i];
				}
				int.TryParse(text2, out result);
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		private static DeviceFlags GetAndroidTiers(string gpuName, int gpuMemory, int shaderLevel, int maxRenderTargetCount)
		{
			DeviceFlags result = DeviceFlags.LowEnd | DeviceFlags.LowEndGraphics | DeviceFlags.LowEndProcessor;
			if (gpuName.StartsWith("Adreno (TM)"))
			{
				int androidGpuModelNumber = GetAndroidGpuModelNumber(gpuName, "Adreno (TM)");
				if (androidGpuModelNumber >= 640)
				{
					result = DeviceFlags.HighEnd | DeviceFlags.HighEndGraphics | DeviceFlags.HighEndProcessor;
				}
				else if (androidGpuModelNumber >= 530)
				{
					result = DeviceFlags.MidRange | DeviceFlags.MidRangeGraphics | DeviceFlags.MidRangeProcessor;
				}
			}
			else if (gpuName.StartsWith("Mali-G"))
			{
				int androidGpuModelNumber2 = GetAndroidGpuModelNumber(gpuName, "Mali-G");
				if (androidGpuModelNumber2 >= 76)
				{
					result = DeviceFlags.HighEnd | DeviceFlags.HighEndGraphics | DeviceFlags.HighEndProcessor;
				}
				else if (androidGpuModelNumber2 >= 71)
				{
					result = DeviceFlags.MidRange | DeviceFlags.MidRangeGraphics | DeviceFlags.MidRangeProcessor;
				}
			}
			return result;
		}

		private static DeviceFlags GetDeviceDesktopTiers(IDevice device)
		{
			DeviceFlags deviceFlags = DeviceFlags.Default;
			int num = SystemInfo.processorFrequency;
			int num2 = SystemInfo.processorCount;
			int num3 = SystemInfo.systemMemorySize;
			int num4;
			if (SystemInfo.graphicsDeviceVendorID == 4098)
			{
				num4 = ((SystemInfo.graphicsDeviceID == 5695) ? 1 : 0);
				if (num4 != 0)
				{
					deviceFlags = DeviceFlags.MidRangeProcessor;
					goto IL_0092;
				}
			}
			else
			{
				num4 = 0;
			}
			if (num <= 0)
			{
				num = 2500;
			}
			if (num2 <= 0)
			{
				num2 = 6;
			}
			if (num3 <= 0)
			{
				num3 = 8192;
			}
			deviceFlags = ((num >= 3000) ? ((num2 < 8 || num3 < 16000) ? DeviceFlags.MidRangeProcessor : DeviceFlags.HighEndProcessor) : ((num2 > 4 && num3 > 8200) ? DeviceFlags.MidRangeProcessor : DeviceFlags.LowEndProcessor));
			goto IL_0092;
			IL_0092:
			int num5 = SystemInfo.graphicsMemorySize;
			string text = SystemInfo.graphicsDeviceName ?? string.Empty;
			bool flag = text.StartsWith("Intel") && !text.StartsWith("Intel Arc") && !text.StartsWith("Intel® Arc");
			if (num4 != 0)
			{
				deviceFlags |= DeviceFlags.MidRangeGraphics;
			}
			else
			{
				if (num5 <= 0)
				{
					num5 = 4096;
				}
				deviceFlags = ((flag || num5 < 4000) ? (deviceFlags | DeviceFlags.LowEndGraphics) : ((num5 <= 6200) ? (deviceFlags | DeviceFlags.MidRangeGraphics) : (deviceFlags | DeviceFlags.HighEndGraphics)));
			}
			if (deviceFlags.HasFlag(DeviceFlags.HighEndProcessor) && deviceFlags.HasFlag(DeviceFlags.HighEndGraphics))
			{
				return deviceFlags | DeviceFlags.HighEnd;
			}
			if (!deviceFlags.HasFlag(DeviceFlags.LowEndProcessor) && !deviceFlags.HasFlag(DeviceFlags.LowEndGraphics))
			{
				return deviceFlags | DeviceFlags.MidRange;
			}
			return deviceFlags | DeviceFlags.LowEnd;
		}

		private static DeviceFlags GetDeviceMobileTiers(IDevice device)
		{
			if (device.IsIosBuild)
			{
				return DeviceFlags.LowEnd | DeviceFlags.LowEndGraphics | DeviceFlags.LowEndProcessor;
			}
			return GetAndroidTiers(SystemInfo.graphicsDeviceName, SystemInfo.graphicsMemorySize, SystemInfo.graphicsShaderLevel, SystemInfo.supportedRenderTargetCount);
		}

		private static bool IsMobileResolution()
		{
			bool flag = (Screen.width == 1334 && Screen.height == 750) || (Screen.width == 2436 && Screen.height == 1125) || (Screen.width == 2208 && Screen.height == 1242) || (Screen.width == 2688 && Screen.height == 1242);
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

		private static void SetupDeviceFlags()
		{
			Flags = DeviceFlags.Default;
			IDevice currentDevice = CurrentDevice;
			if (currentDevice.IsAndroidBuild)
			{
				Flags |= DeviceFlags.Android;
			}
			else if (currentDevice.IsIosBuild)
			{
				Flags |= DeviceFlags.IOS;
			}
			else if (currentDevice.IsWindowsBuild)
			{
				Flags |= DeviceFlags.Windows;
			}
			else if (currentDevice.IsOsxBuild)
			{
				Flags |= DeviceFlags.OSX;
			}
			if (currentDevice.IsMobileBuild)
			{
				Flags |= DeviceFlags.Mobile;
				if (SystemInfo.systemMemorySize <= 1024)
				{
					Flags |= DeviceFlags.LowRam;
				}
				Flags |= GetDeviceMobileTiers(currentDevice);
			}
			else
			{
				Flags |= DeviceFlags.Desktop;
				if (SystemInfo.systemMemorySize <= 4096)
				{
					Flags |= DeviceFlags.LowRam;
				}
				Flags |= GetDeviceDesktopTiers(currentDevice);
			}
			if (currentDevice.IsDebugBuild)
			{
				Flags |= DeviceFlags.DebugBuild;
			}
		}
	}
}

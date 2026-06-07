using System;
using UnityEngine;

namespace ModApi.Settings.Core
{
	public static class CurrentDevice
	{
		public static DeviceFlags Flags { get; private set; }

		static CurrentDevice()
		{
			Flags = DeviceFlags.Default;
			IDevice device = Game.Instance.Device;
			if (device.IsAndroidBuild)
			{
				Flags |= DeviceFlags.Android;
			}
			else if (device.IsIosBuild)
			{
				Flags |= DeviceFlags.IOS;
			}
			else if (device.IsWindowsBuild)
			{
				Flags |= DeviceFlags.Windows;
			}
			else if (device.IsOsxBuild)
			{
				Flags |= DeviceFlags.OSX;
			}
			if (device.IsMobileBuild)
			{
				Flags |= DeviceFlags.Mobile;
				if (SystemInfo.systemMemorySize <= 1024)
				{
					Flags |= DeviceFlags.LowRam;
				}
				Flags |= GetDeviceMobileTiers(device);
			}
			else
			{
				Flags |= DeviceFlags.Desktop;
				if (SystemInfo.systemMemorySize <= 4096)
				{
					Flags |= DeviceFlags.LowRam;
				}
				Flags |= GetDeviceDesktopTiers(device);
			}
			if (device.IsDebugBuild)
			{
				Flags |= DeviceFlags.DebugBuild;
			}
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

		private static DeviceFlags GetDeviceDesktopTiers(IDevice device)
		{
			DeviceFlags deviceFlags = DeviceFlags.Default;
			int num = SystemInfo.processorFrequency;
			int num2 = SystemInfo.processorCount;
			int num3 = SystemInfo.systemMemorySize;
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
			deviceFlags = ((num >= 3000) ? ((num2 < 8 || num3 < 8000) ? DeviceFlags.MidRangeProcessor : DeviceFlags.HighEndProcessor) : ((num2 > 4 && num3 > 4100) ? DeviceFlags.MidRangeProcessor : DeviceFlags.LowEndProcessor));
			int num4 = SystemInfo.graphicsMemorySize;
			bool flag = (SystemInfo.graphicsDeviceName ?? string.Empty).StartsWith("Intel");
			if (num4 <= 0)
			{
				num4 = 2048;
			}
			deviceFlags = (flag ? (deviceFlags | DeviceFlags.LowEndGraphics) : ((num4 < 3000) ? (deviceFlags | DeviceFlags.MidRangeGraphics) : (deviceFlags | DeviceFlags.HighEndGraphics)));
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
	}
}

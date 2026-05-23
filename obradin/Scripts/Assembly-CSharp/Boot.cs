using System;
using UnityEngine;

public class Boot
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void OnBeforeSceneLoadRuntimeMethod()
	{
		if (CommandLine.log)
		{
			Debug.unityLogger.logHandler = new CustomLogHandler();
		}
		Debug.Log(DateTime.Now.ToString("o"));
		Debug.LogFormat("Version {0}", new Version().ToString());
		Debug.LogFormat("Command {0}", CommandLine.all);
		LogSystemInfo();
	}

	private static void LogSystemInfo()
	{
		Debug.Log("--------------------------------------------------------------------");
		Debug.Log("System Info");
		Debug.Log("--------------------------------------------------------------------");
		SysInfo("BatteryLevel", SystemInfo.batteryLevel);
		SysInfo("BatteryStatus", SystemInfo.batteryStatus);
		SysInfo("CopyTextureSupport", SystemInfo.copyTextureSupport);
		SysInfo("DeviceModel", SystemInfo.deviceModel);
		SysInfo("DeviceName", SystemInfo.deviceName);
		SysInfo("DeviceType", SystemInfo.deviceType);
		SysInfo("DeviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier);
		SysInfo("GraphicsDeviceID", SystemInfo.graphicsDeviceID);
		SysInfo("GraphicsDeviceName", SystemInfo.graphicsDeviceName);
		SysInfo("GraphicsDeviceType", SystemInfo.graphicsDeviceType);
		SysInfo("GraphicsDeviceVendor", SystemInfo.graphicsDeviceVendor);
		SysInfo("GraphicsDeviceVendorID", SystemInfo.graphicsDeviceVendorID);
		SysInfo("GraphicsDeviceVersion", SystemInfo.graphicsDeviceVersion);
		SysInfo("GraphicsMemorySize", SystemInfo.graphicsMemorySize);
		SysInfo("GraphicsMultiThreaded", SystemInfo.graphicsMultiThreaded);
		SysInfo("GraphicsShaderLevel", SystemInfo.graphicsShaderLevel);
		SysInfo("GraphicsUVStartsAtTop", SystemInfo.graphicsUVStartsAtTop);
		SysInfo("MaxCubemapSize", SystemInfo.maxCubemapSize);
		SysInfo("MaxTextureSize", SystemInfo.maxTextureSize);
		SysInfo("NpotSupport", SystemInfo.npotSupport);
		SysInfo("OperatingSystem", SystemInfo.operatingSystem);
		SysInfo("OperatingSystemFamily", SystemInfo.operatingSystemFamily);
		SysInfo("ProcessorCount", SystemInfo.processorCount);
		SysInfo("ProcessorFrequency", SystemInfo.processorFrequency);
		SysInfo("ProcessorType", SystemInfo.processorType);
		SysInfo("SupportedRenderTargetCount", SystemInfo.supportedRenderTargetCount);
		SysInfo("Supports2DArrayTextures", SystemInfo.supports2DArrayTextures);
		SysInfo("Supports3DRenderTextures", SystemInfo.supports3DRenderTextures);
		SysInfo("Supports3DTextures", SystemInfo.supports3DTextures);
		SysInfo("SupportsAccelerometer", SystemInfo.supportsAccelerometer);
		SysInfo("SupportsAudio", SystemInfo.supportsAudio);
		SysInfo("SupportsComputeShaders", SystemInfo.supportsComputeShaders);
		SysInfo("SupportsCubemapArrayTextures", SystemInfo.supportsCubemapArrayTextures);
		SysInfo("SupportsGyroscope", SystemInfo.supportsGyroscope);
		SysInfo("SupportsImageEffects", SystemInfo.supportsImageEffects);
		SysInfo("SupportsInstancing", SystemInfo.supportsInstancing);
		SysInfo("SupportsLocationService", SystemInfo.supportsLocationService);
		SysInfo("SupportsMotionVectors", SystemInfo.supportsMotionVectors);
		SysInfo("SupportsRawShadowDepthSampling", SystemInfo.supportsRawShadowDepthSampling);
		SysInfo("SupportsRenderToCubemap", SystemInfo.supportsRenderToCubemap);
		SysInfo("SupportsShadows", SystemInfo.supportsShadows);
		SysInfo("SupportsSparseTextures", SystemInfo.supportsSparseTextures);
		SysInfo("SupportsVibration", SystemInfo.supportsVibration);
		SysInfo("SystemMemorySize", SystemInfo.systemMemorySize);
		SysInfo("UnsupportedIdentifier", "n/a");
		SysInfo("UsesReversedZBuffer", SystemInfo.usesReversedZBuffer);
		Debug.Log("--------------------------------------------------------------------");
	}

	private static void SysInfo(string name, object val)
	{
		Debug.LogFormat("{0}: {1}", name, val);
	}
}

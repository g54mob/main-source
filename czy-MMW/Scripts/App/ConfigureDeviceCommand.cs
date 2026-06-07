using Factory;
using UnityEngine;

public class ConfigureDeviceCommand : AppCommand
{
	private RuntimePlatform _platform;

	private int _screenWidth;

	private int _screenHeight;

	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	public void Initialize()
	{
		_platform = _hardwareCapabilities.Platform;
		_screenWidth = Screen.width;
		_screenHeight = Screen.height;
	}

	public override void Reset()
	{
		_platform = RuntimePlatform.OSXEditor;
		_screenWidth = 0;
		_screenHeight = 0;
	}

	public override bool Execute(IApp receiver)
	{
		_ = _hardwareCapabilities.Platform;
		return true;
	}

	private static bool IsPlatformStandalone(RuntimePlatform platform)
	{
		if (platform != RuntimePlatform.WindowsPlayer && platform != RuntimePlatform.OSXPlayer)
		{
			return platform == RuntimePlatform.LinuxPlayer;
		}
		return true;
	}
}

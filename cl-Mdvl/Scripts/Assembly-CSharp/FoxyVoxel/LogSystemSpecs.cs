using FoxyVoxel.Logging;
using UnityEngine;

namespace FoxyVoxel
{
	public class LogSystemSpecs : MonoBehaviour
	{
		private void Start()
		{
			Log.Info("CPU Model: " + SystemInfo.processorType, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("CPU Core Count: " + SystemInfo.processorCount, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("Total System Memory (MB): " + SystemInfo.systemMemorySize, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("Operating System: " + SystemInfo.operatingSystem, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("Graphics Device: " + SystemInfo.graphicsDeviceName, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("Graphics Device Version: " + SystemInfo.graphicsDeviceVersion, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
			Log.Info("Device Model: " + SystemInfo.deviceModel, "C:\\GIT\\dev\\Assets\\Scripts\\LogSystemSpecs.cs");
		}
	}
}

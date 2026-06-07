using System.Collections.Generic;
using Unity.Cloud.UserReporting.Plugin;
using UnityEngine;
using UnityEngine.XR;

public class UserReportingXRExtensions : MonoBehaviour
{
	private static bool XRIsPresent()
	{
		List<XRDisplaySubsystem> list = new List<XRDisplaySubsystem>();
		SubsystemManager.GetSubsystems(list);
		foreach (XRDisplaySubsystem item in list)
		{
			if (item.running)
			{
				return true;
			}
		}
		return false;
	}

	private void Start()
	{
		if (XRIsPresent())
		{
			UnityUserReporting.CurrentClient.AddDeviceMetadata("XRDeviceModel", XRSettings.loadedDeviceName);
		}
	}

	private void Update()
	{
		if (XRIsPresent())
		{
			if (XRStats.TryGetDroppedFrameCount(out var droppedFrameCount))
			{
				UnityUserReporting.CurrentClient.SampleMetric("XR.DroppedFrameCount", droppedFrameCount);
			}
			if (XRStats.TryGetFramePresentCount(out var framePresentCount))
			{
				UnityUserReporting.CurrentClient.SampleMetric("XR.FramePresentCount", framePresentCount);
			}
			if (XRStats.TryGetGPUTimeLastFrame(out var gpuTimeLastFrame))
			{
				UnityUserReporting.CurrentClient.SampleMetric("XR.GPUTimeLastFrame", gpuTimeLastFrame);
			}
		}
	}
}

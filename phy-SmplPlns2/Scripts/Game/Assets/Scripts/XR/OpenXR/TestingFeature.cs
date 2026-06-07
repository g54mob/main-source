using UnityEngine;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR.OpenXR.Features;

namespace Assets.Scripts.XR.OpenXR
{
	public class TestingFeature : OpenXRFeature
	{
		protected override bool OnInstanceCreate(ulong xrInstance)
		{
			Debug.Log("OpenXR instance create: v" + OpenXRRuntime.version + ", API " + OpenXRRuntime.apiVersion);
			Debug.Log("Avialable:\n" + string.Join("\n", OpenXRRuntime.GetAvailableExtensions()));
			Debug.Log("Enabled:\n" + string.Join("\n", OpenXRRuntime.GetEnabledExtensions()));
			return false;
		}
	}
}

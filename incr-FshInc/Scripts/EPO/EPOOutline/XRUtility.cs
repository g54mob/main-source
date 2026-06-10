using UnityEngine;
using UnityEngine.XR;

namespace EPOOutline
{
	public static class XRUtility
	{
		public static bool IsXRActive
		{
			get
			{
				if (XRSettings.enabled)
				{
					return XRSettings.isDeviceActive;
				}
				return false;
			}
		}

		public static RenderTextureDescriptor VRRenderTextureDescriptor => XRSettings.eyeTextureDesc;

		public static bool IsUsingVR(OutlineParameters parameters)
		{
			if (IsXRActive && !parameters.IsEditorCamera)
			{
				return parameters.EyeMask != StereoTargetEyeMask.None;
			}
			return false;
		}
	}
}

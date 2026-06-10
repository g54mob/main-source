using UnityEngine;
using UnityEngine.XR;

namespace Aura2API
{
	public static class XrHelpers
	{
		public static bool IsSinglePassStereo
		{
			get
			{
				if (XRSettings.enabled)
				{
					return XRSettings.eyeTextureDesc.vrUsage == VRTextureUsage.TwoEyes;
				}
				return false;
			}
		}
	}
}

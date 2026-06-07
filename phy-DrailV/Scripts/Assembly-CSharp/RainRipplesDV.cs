using UnityEngine;

public class RainRipplesDV : RainRipples
{
	public override VRTextureUsage GetVRUsageFromCamera(Camera camera)
	{
		if (!VRManager.IsVREnabled())
		{
			return VRTextureUsage.None;
		}
		return VRTextureUsage.TwoEyes;
	}
}

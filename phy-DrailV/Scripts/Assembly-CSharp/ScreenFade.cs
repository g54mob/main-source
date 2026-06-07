using UnityEngine;
using VRTK;

public class ScreenFade
{
	public static void Fade(Color color, float duration)
	{
		if (VRManager.IsVREnabled())
		{
			VRTK_SDK_Bridge.HeadsetFade(color, duration);
			return;
		}
		Camera main = Camera.main;
		if (!main)
		{
			return;
		}
		VRTK_ScreenFade vRTK_ScreenFade;
		if ((bool)VRTK_ScreenFade.instance)
		{
			if (VRTK_ScreenFade.instance.gameObject != main.gameObject)
			{
				Object.Destroy(VRTK_ScreenFade.instance);
				vRTK_ScreenFade = main.gameObject.AddComponent<VRTK_ScreenFade>();
			}
			else
			{
				vRTK_ScreenFade = VRTK_ScreenFade.instance;
			}
		}
		else
		{
			vRTK_ScreenFade = main.gameObject.AddComponent<VRTK_ScreenFade>();
		}
		vRTK_ScreenFade.StartFade(color, duration);
	}
}

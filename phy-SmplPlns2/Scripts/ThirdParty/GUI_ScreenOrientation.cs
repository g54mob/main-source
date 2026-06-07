using UnityEngine;

public class GUI_ScreenOrientation : MonoBehaviour
{
	private bool orientationMenuEnabled;

	private void OnGUI()
	{
		int width = Screen.width;
		float num = 4f;
		float num2 = 0f;
		float num3 = (float)width / num;
		float num4 = 40f;
		float num5 = 5f;
		num2 = 3f;
		if (GUI.Button(text: "Device Orientation = \n" + ((SystemInfo.deviceType != DeviceType.Handheld) ? "" : ("(" + Screen.orientation.ToString() + ")")), position: new Rect(num2 * num3 + num5, 0f + num5, num3 - 2f * num5, num4)))
		{
			orientationMenuEnabled = !orientationMenuEnabled;
		}
		if (orientationMenuEnabled && SystemInfo.deviceType == DeviceType.Handheld)
		{
			if (GUI.Button(new Rect(num2 * num3 + num5, 1f * num4 + 2f * num5, num3 - 2f * num5, num4), "Portrait Up"))
			{
				Screen.orientation = ScreenOrientation.Portrait;
				orientationMenuEnabled = false;
			}
			if (GUI.Button(new Rect(num2 * num3 + num5, 2f * num4 + 3f * num5, num3 - 2f * num5, num4), "Portrait Down"))
			{
				Screen.orientation = ScreenOrientation.PortraitUpsideDown;
				orientationMenuEnabled = false;
			}
			if (GUI.Button(new Rect(num2 * num3 + num5, 3f * num4 + 4f * num5, num3 - 2f * num5, num4), "Landscape Left"))
			{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
				orientationMenuEnabled = false;
			}
			if (GUI.Button(new Rect(num2 * num3 + num5, 4f * num4 + 5f * num5, num3 - 2f * num5, num4), "Landscape Right"))
			{
				Screen.orientation = ScreenOrientation.LandscapeRight;
				orientationMenuEnabled = false;
			}
		}
	}
}

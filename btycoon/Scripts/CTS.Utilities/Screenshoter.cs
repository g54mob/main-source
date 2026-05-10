using System;
using UnityEngine;

public class Screenshoter : MonoBehaviour
{
	public int scale;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			MonoBehaviour.print("screenshot" + DateTime.Now.ToBinary());
			ScreenCapture.CaptureScreenshot("Screenshots/screenshot" + DateTime.Now.ToBinary() + ".png", scale);
		}
	}
}

using System;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
	[SerializeField]
	private KeyCode screenShotKeyCode;

	[SerializeField]
	private string screenshotName;

	[SerializeField]
	private string folderName = "Screenshots";

	[SerializeField]
	private int superSize = 2;

	private void Update()
	{
		if (Application.isEditor && Input.GetKeyDown(screenShotKeyCode))
		{
			CaptureScreenshot();
		}
	}

	private void CaptureScreenshot()
	{
		string text = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + screenshotName + ".png";
		Debug.Log("Screenshot taken " + text);
		ScreenCapture.CaptureScreenshot(folderName + "/" + text, superSize);
	}
}

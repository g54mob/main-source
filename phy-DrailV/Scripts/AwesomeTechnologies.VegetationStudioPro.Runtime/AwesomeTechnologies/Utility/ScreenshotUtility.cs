using System;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[AwesomeTechnologiesScriptOrder(200)]
	public class ScreenshotUtility : MonoBehaviour
	{
		public void TakeScreenshot()
		{
			ScreenCapture.CaptureScreenshot(string.Concat("Screenshot_", Guid.NewGuid(), ".png"), 1);
		}

		private void LateUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				Debug.Log("screenshot");
				TakeScreenshot();
			}
		}
	}
}

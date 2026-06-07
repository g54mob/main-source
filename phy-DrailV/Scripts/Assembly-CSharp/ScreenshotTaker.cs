using System.Collections;
using System.IO;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem;
using DV.UI;
using DV.Utils;
using UnityEngine;

public class ScreenshotTaker : SingletonBehaviour<ScreenshotTaker>
{
	public KeyCode captureKey = KeyCode.F11;

	public int superSize = 2;

	public new static string AllowAutoCreate()
	{
		return "[screenshot taker]";
	}

	private void LateUpdate()
	{
		if (Input.GetKeyDown(captureKey))
		{
			TakeScreenshot();
		}
	}

	private void TakeScreenshot()
	{
		if (!Directory.Exists("Screenshots"))
		{
			Directory.CreateDirectory("Screenshots");
		}
		int num = 0;
		string text;
		do
		{
			text = "Screenshots/Screenshot_" + num + ".png";
			num++;
		}
		while (File.Exists(text));
		StartCoroutine(TakeScreenshotCoro(text, superSize));
	}

	private IEnumerator TakeScreenshotCoro(string filePath, int superSize)
	{
		yield return WaitFor.EndOfFrame;
		RenderTexture temporary = RenderTexture.GetTemporary(Screen.width * superSize, Screen.height * superSize, 32);
		TakeScreenshotWithoutUI(temporary);
		RenderTexture.active = temporary;
		Texture2D texture2D = new Texture2D(temporary.width, temporary.height, TextureFormat.RGB24, mipChain: false);
		texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
		texture2D.Apply();
		RenderTexture.ReleaseTemporary(temporary);
		File.WriteAllBytes(filePath, texture2D.EncodeToPNG());
		Debug.Log("Screenshot saved to " + Path.GetFullPath(filePath));
	}

	public static void TakeScreenshotWithoutUI(RenderTexture dest)
	{
		ACanvasController<CanvasController.ElementType> instance = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance;
		if ((bool)instance)
		{
			instance.mainCanvas.enabled = false;
		}
		if ((bool)PlayerManager.ActiveCamera)
		{
			if ((bool)SingletonBehaviour<RailwayMeshGenerator>.Instance)
			{
				SingletonBehaviour<RailwayMeshGenerator>.Instance.RenderSleepers();
			}
			if ((bool)VegetationStudioManager.Instance)
			{
				foreach (VegetationSystemPro vegetationSystem in VegetationStudioManager.Instance.VegetationSystemList)
				{
					vegetationSystem.LateUpdate();
				}
			}
			PlayerManager.ActiveCamera.targetTexture = dest;
			PlayerManager.ActiveCamera.Render();
			PlayerManager.ActiveCamera.targetTexture = null;
		}
		if ((bool)instance)
		{
			instance.mainCanvas.enabled = true;
		}
	}
}

using System.IO;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	[RequireComponent(typeof(Camera))]
	internal class ScreenshotScript : MonoBehaviour
	{
		private static void TakeScreenshot(Camera camera, string outputFilePath, int width = -1, int height = -1)
		{
			if (width == -1)
			{
				width = camera.pixelWidth;
			}
			if (height == -1)
			{
				height = camera.pixelHeight;
			}
			RenderTexture targetTexture = camera.targetTexture;
			camera.targetTexture = new RenderTexture(width, height, 24);
			camera.Render();
			RenderTexture.active = camera.targetTexture;
			Texture2D texture2D = new Texture2D(width, height);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			byte[] bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes(outputFilePath, bytes);
			camera.targetTexture = targetTexture;
		}
	}
}

using System.Collections;
using System.IO;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Persistent
{
	internal static class ScreenshotCapturer
	{
		public static IEnumerator TakeScreenshot(string _FilePath, int _Width)
		{
			yield return new WaitForEndOfFrame();
			int width = Screen.width;
			int height = Screen.height;
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			texture2D = Resize(texture2D, _Width, (int)((float)_Width / (float)texture2D.width * (float)texture2D.height));
			byte[] bytes = texture2D.EncodeToJPG();
			Object.Destroy(texture2D);
			File.WriteAllBytes(_FilePath, bytes);
		}

		private static Texture2D Resize(Texture2D _Texture, int _TargetWidth, int _TargetHeight)
		{
			RenderTexture dest = (RenderTexture.active = new RenderTexture(_TargetWidth, _TargetHeight, 24));
			Graphics.Blit(_Texture, dest);
			Texture2D texture2D = new Texture2D(_TargetWidth, _TargetHeight);
			texture2D.ReadPixels(new Rect(0f, 0f, _TargetWidth, _TargetHeight), 0, 0);
			texture2D.Apply();
			return texture2D;
		}
	}
}

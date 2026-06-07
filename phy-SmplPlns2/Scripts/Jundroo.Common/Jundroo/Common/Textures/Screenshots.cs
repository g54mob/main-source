using System;
using System.IO;
using Jundroo.Common.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Jundroo.Common.Textures
{
	public class Screenshots
	{
		public static Rect GetScreenShotSampleRect(float aspectRatio)
		{
			Rect result;
			if ((float)Screen.width / (float)Screen.height > aspectRatio)
			{
				int height = Screen.height;
				int num = (int)((float)height * aspectRatio);
				int num2 = (Screen.width - num) / 2;
				result = new Rect(num2, 0f, num, height);
			}
			else
			{
				int width = Screen.width;
				int num3 = (int)((float)width / aspectRatio);
				int num4 = (Screen.height - num3) / 2;
				result = new Rect(0f, num4, width, num3);
			}
			return result;
		}

		public static void TakeScreenShot(Vector2i resolution, Action<Texture2D> onScreenshotComplete)
		{
			TakeScreenShot(GetScreenShotSampleRect((float)resolution.x / (float)resolution.y), resolution, onScreenshotComplete);
		}

		public static void TakeScreenShot(Rect screenSampleRect, Vector2i resolution, Action<Texture2D> onScreenshotComplete)
		{
			Utilities.CompareFloats((float)resolution.x / (float)resolution.y, screenSampleRect.width / screenSampleRect.height, 0.1f);
			int upsampleSize = 1;
			if ((float)resolution.x != screenSampleRect.width && !Device.HasAnyFlag(DeviceFlags.LowRam))
			{
				upsampleSize = (int)((float)resolution.x / screenSampleRect.width) + 1;
				upsampleSize = Mathf.Clamp(upsampleSize, 1, 2);
			}
			string fileName = $"{Guid.NewGuid().ToString()}.png";
			string screenshotPath = CaptureScreenshot(fileName, upsampleSize);
			int numFramesToWait = 500;
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				try
				{
					if (File.Exists(screenshotPath))
					{
						Texture2D texture2D = new Texture2D(0, 0);
						texture2D.LoadImage(File.ReadAllBytes(screenshotPath));
						int num = (int)screenSampleRect.width * upsampleSize;
						int num2 = (int)screenSampleRect.height * upsampleSize;
						if (texture2D.width < num || texture2D.height < num2)
						{
							Debug.LogFormat("Texture was wrong size: {0}x{1}. Bailing and trying again.", texture2D.width, texture2D.height);
							return true;
						}
						TextureScale.Bilinear(texture2D, resolution.x, resolution.y, (int)screenSampleRect.x * upsampleSize, (int)screenSampleRect.y * upsampleSize, num, num2);
						File.Delete(screenshotPath);
						onScreenshotComplete(texture2D);
						return false;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				if (numFramesToWait <= 0)
				{
					Debug.LogFormat("Giving up. Unity failed to create the texture");
					onScreenshotComplete(null);
					return false;
				}
				numFramesToWait--;
				return true;
			});
		}

		private static string CaptureScreenshot(string fileName, int superSize)
		{
			string empty = string.Empty;
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
			{
				empty = FileIOUtility.CombinePaths(Project.PersistentDataPath, fileName);
				ScreenCapture.CaptureScreenshot(fileName, superSize);
			}
			else
			{
				empty = FileIOUtility.CombinePaths(Application.temporaryCachePath, fileName);
				ScreenCapture.CaptureScreenshot(empty, superSize);
			}
			return empty;
		}
	}
}

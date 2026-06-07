using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace OneUseScripts
{
	public class RectScreenShooter : MonoBehaviour
	{
		public static RectScreenShooter instance;

		[SerializeField]
		private RectTransform target;

		[InspectorButton("SaveTempScreenShot")]
		public bool takeScreenShot;

		private bool saveTempScreenShotFile;

		private Action<Texture2D> onCaptured;

		private bool hasInit;

		private void Awake()
		{
			instance = this;
			hasInit = true;
		}

		public void CaptureObject(RectTransform rt, Action<Texture2D> toCallAfterCapture = null, bool alsoSaveTempScreenshot = false)
		{
			target = rt;
			onCaptured = toCallAfterCapture;
			saveTempScreenShotFile = alsoSaveTempScreenshot;
			StartCoroutine(GrabUI());
		}

		private IEnumerator GrabUI()
		{
			if (!hasInit)
			{
				Awake();
			}
			Vector3[] array = new Vector3[4];
			Camera cam = UICamera.cam;
			target.GetWorldCorners(array);
			Vector2 vector = RectTransformUtility.WorldToScreenPoint(cam, array[0]) + Vector2.one;
			Vector2 vector2 = RectTransformUtility.WorldToScreenPoint(cam, array[2]) - Vector2.one;
			int height = Mathf.RoundToInt(vector2.y - vector.y);
			int width = Mathf.RoundToInt(vector2.x - vector.x);
			Rect rect = new Rect(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), width, height);
			yield return new WaitForEndOfFrame();
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
			texture2D.ReadPixels(rect, 0, 0, recalculateMipMaps: false);
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			if (saveTempScreenShotFile)
			{
				byte[] bytes = texture2D.EncodeToPNG();
				if (File.Exists(ScreenShotHandler.tempScreenshotPath))
				{
					File.Delete(ScreenShotHandler.tempScreenshotPath);
				}
				File.WriteAllBytes(ScreenShotHandler.tempScreenshotPath, bytes);
			}
			onCaptured?.Invoke(texture2D);
		}

		public void SaveTempScreenShot()
		{
			CaptureObject(target, null, alsoSaveTempScreenshot: true);
		}
	}
}

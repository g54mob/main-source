using UnityEngine;

namespace Kitchen
{
	[RequireComponent(typeof(Camera))]
	public class ScreenshotCamera : MonoBehaviour
	{
		public static Texture2D Screenshot;

		public static ScreenshotCamera PrimaryCamera;

		private bool ShouldTakeScreenshot;

		private void Awake()
		{
			PrimaryCamera = this;
		}

		private void LateUpdate()
		{
			if (ShouldTakeScreenshot)
			{
				ShouldTakeScreenshot = false;
				if (Screenshot != null)
				{
					Object.Destroy(Screenshot);
				}
				Camera component = GetComponent<Camera>();
				RenderTexture temporary = RenderTexture.GetTemporary(component.pixelWidth, component.pixelHeight, 0, RenderTextureFormat.ARGB32);
				RenderTexture targetTexture = component.targetTexture;
				RenderTexture.active = temporary;
				component.targetTexture = temporary;
				component.Render();
				component.targetTexture = targetTexture;
				Texture2D texture2D = new Texture2D(temporary.width, temporary.height);
				texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
				texture2D.Apply();
				RenderTexture.ReleaseTemporary(temporary);
				RenderTexture.active = targetTexture;
				Screenshot = texture2D;
			}
		}

		public void RequestScreenshot()
		{
			ShouldTakeScreenshot = true;
		}
	}
}

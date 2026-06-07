using System;
using System.IO;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{
	public int captureWidth = 1920;

	public int captureHeight = 1080;

	public string savePath = "Assets/CapturedImages/";

	private Camera cameraComponent;

	private void Start()
	{
		cameraComponent = GetComponent<Camera>();
	}

	public void CaptureScreenshot()
	{
		RenderTexture renderTexture = new RenderTexture(captureWidth, captureHeight, 24, RenderTextureFormat.ARGB32);
		cameraComponent.targetTexture = renderTexture;
		Texture2D texture2D = new Texture2D(captureWidth, captureHeight, TextureFormat.RGBA32, mipChain: false);
		cameraComponent.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, captureWidth, captureHeight), 0, 0);
		cameraComponent.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.Destroy(renderTexture);
		Color[] pixels = texture2D.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			if (pixels[i].g == 1f && pixels[i].r == 0f && pixels[i].b == 0f)
			{
				pixels[i] = Color.clear;
			}
		}
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		byte[] bytes = texture2D.EncodeToPNG();
		string path = "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
		string text = Path.Combine(savePath, path);
		File.WriteAllBytes(text, bytes);
		Debug.Log("Screenshot saved to: " + text);
	}

	public void CaptureScreenshot_WithAlpha()
	{
		RenderTexture renderTexture = new RenderTexture(captureWidth, captureHeight, 24, RenderTextureFormat.ARGB32);
		cameraComponent.targetTexture = renderTexture;
		cameraComponent.clearFlags = CameraClearFlags.Color;
		cameraComponent.backgroundColor = new Color(0f, 0f, 0f, 0f);
		Texture2D texture2D = new Texture2D(captureWidth, captureHeight, TextureFormat.RGBA32, mipChain: false);
		cameraComponent.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, captureWidth, captureHeight), 0, 0);
		texture2D.Apply();
		cameraComponent.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.Destroy(renderTexture);
		byte[] bytes = texture2D.EncodeToPNG();
		string path = "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
		string text = Path.Combine(savePath, path);
		File.WriteAllBytes(text, bytes);
		Debug.Log("Screenshot saved to: " + text);
	}

	public void CaptureScreenshot_ManualComposite()
	{
		int num = captureWidth;
		int num2 = captureHeight;
		RenderTexture renderTexture = new RenderTexture(num, num2, 24, RenderTextureFormat.ARGB32);
		Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false);
		Texture2D texture2D2 = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false);
		cameraComponent.targetTexture = renderTexture;
		cameraComponent.backgroundColor = Color.black;
		cameraComponent.clearFlags = CameraClearFlags.Color;
		cameraComponent.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
		cameraComponent.backgroundColor = Color.white;
		cameraComponent.clearFlags = CameraClearFlags.Color;
		cameraComponent.Render();
		RenderTexture.active = renderTexture;
		texture2D2.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
		cameraComponent.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.Destroy(renderTexture);
		Texture2D texture2D3 = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false);
		Color[] pixels = texture2D.GetPixels();
		Color[] pixels2 = texture2D2.GetPixels();
		Color[] array = new Color[pixels.Length];
		for (int i = 0; i < pixels.Length; i++)
		{
			Color color = pixels[i];
			Color color2 = pixels2[i];
			float value = 1f - (color2.r - color.r + color2.g - color.g + color2.b - color.b) / 3f;
			value = Mathf.Clamp01(value);
			Color color3 = ((value > 0f) ? (color / value) : Color.clear);
			color3.a = value;
			array[i] = color3;
		}
		texture2D3.SetPixels(array);
		texture2D3.Apply();
		byte[] bytes = texture2D3.EncodeToPNG();
		string path = "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
		string text = Path.Combine(savePath, path);
		File.WriteAllBytes(text, bytes);
		Debug.Log("Screenshot with transparency saved to: " + text);
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

public class ScreenRecorder : MonoBehaviour
{
	public enum Format
	{
		RAW = 0,
		JPG = 1,
		PNG = 2,
		PPM = 3
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public string filename;

		public byte[] fileHeader;

		public byte[] fileData;

		internal void _003CLateUpdate_003Eb__0()
		{
			FileStream fileStream = File.Create(filename);
			if (fileHeader != null)
			{
				fileStream.Write(fileHeader, 0, fileHeader.Length);
			}
			fileStream.Write(fileData, 0, fileData.Length);
			fileStream.Close();
			Debug.Log($"Wrote screenshot {filename} of size {fileData.Length}");
		}
	}

	public int captureWidth = 1920;

	public int captureHeight = 1080;

	public bool saveScreenshots;

	public KeyCode screenshotKey = KeyCode.K;

	public bool optimizeForManyScreenshots = true;

	public Format format = Format.PPM;

	public string folder;

	[SerializeField]
	private Camera mainCamera;

	[SerializeField]
	private List<GameObject> objectsToHide;

	private Rect rect;

	private RenderTexture renderTexture;

	private Texture2D screenShot;

	private int counter;

	private bool captureScreenshot;

	private bool captureVideo;

	public byte[] screenshotData;

	private string uniqueFilename(int width, int height)
	{
		string text = Path.Combine(Constants.persistentDataPath, folder);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string searchPattern = $"screen_{width}x{height}*.{format.ToString().ToLower()}";
		counter = Directory.GetFiles(text, searchPattern, SearchOption.TopDirectoryOnly).Length;
		string path = $"screen_{width}x{height}_{counter}.{format.ToString().ToLower()}";
		counter++;
		return Path.Combine(text, path);
	}

	public void CaptureScreenshot()
	{
		screenshotData = null;
		captureScreenshot = true;
	}

	public void CaptureScreenshotInstantly()
	{
		captureScreenshot = true;
		LateUpdate();
	}

	private void LateUpdate()
	{
		captureScreenshot |= Input.GetKeyDown(screenshotKey);
		if (!captureScreenshot && !captureVideo)
		{
			return;
		}
		try
		{
			_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass20_0();
			captureScreenshot = false;
			if (mainCamera == null)
			{
				Debug.LogError("ScreenRecorder - camera is null!");
				return;
			}
			bool flag = mainCamera.enabled;
			if (renderTexture == null)
			{
				rect = new Rect(0f, 0f, captureWidth, captureHeight);
				renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
				screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, mipChain: false);
			}
			mainCamera.enabled = true;
			mainCamera.targetTexture = renderTexture;
			List<GameObject> list = new List<GameObject>();
			foreach (GameObject item in objectsToHide)
			{
				if (item == null)
				{
					Debug.LogError("ScreenRecorder - object to hide is null!");
				}
				else if (item.activeInHierarchy)
				{
					list.Add(item);
					item.SetActive(value: false);
				}
			}
			mainCamera.Render();
			RenderTexture.active = renderTexture;
			screenShot.ReadPixels(rect, 0, 0);
			mainCamera.enabled = flag;
			mainCamera.targetTexture = null;
			foreach (GameObject item2 in list)
			{
				if (item2 == null)
				{
					Debug.LogError("ScreenRecorder - object to hide is null!");
				}
				else
				{
					item2.SetActive(value: true);
				}
			}
			RenderTexture.active = null;
			CS_0024_003C_003E8__locals17.filename = uniqueFilename((int)rect.width, (int)rect.height);
			CS_0024_003C_003E8__locals17.fileHeader = null;
			CS_0024_003C_003E8__locals17.fileData = null;
			if (format == Format.RAW)
			{
				CS_0024_003C_003E8__locals17.fileData = screenShot.GetRawTextureData();
			}
			else if (format == Format.PNG)
			{
				CS_0024_003C_003E8__locals17.fileData = ImageConversion.EncodeToPNG(screenShot);
			}
			else if (format == Format.JPG)
			{
				CS_0024_003C_003E8__locals17.fileData = ImageConversion.EncodeToJPG(screenShot);
			}
			else
			{
				string s = $"P6\n{rect.width} {rect.height}\n255\n";
				CS_0024_003C_003E8__locals17.fileHeader = Encoding.ASCII.GetBytes(s);
				CS_0024_003C_003E8__locals17.fileData = screenShot.GetRawTextureData();
			}
			screenshotData = CS_0024_003C_003E8__locals17.fileData;
			if (!saveScreenshots)
			{
				return;
			}
			new Thread((ThreadStart)delegate
			{
				FileStream fileStream = File.Create(CS_0024_003C_003E8__locals17.filename);
				if (CS_0024_003C_003E8__locals17.fileHeader != null)
				{
					fileStream.Write(CS_0024_003C_003E8__locals17.fileHeader, 0, CS_0024_003C_003E8__locals17.fileHeader.Length);
				}
				fileStream.Write(CS_0024_003C_003E8__locals17.fileData, 0, CS_0024_003C_003E8__locals17.fileData.Length);
				fileStream.Close();
				Debug.Log($"Wrote screenshot {CS_0024_003C_003E8__locals17.filename} of size {CS_0024_003C_003E8__locals17.fileData.Length}");
			}).Start();
			if (!optimizeForManyScreenshots)
			{
				UnityEngine.Object.Destroy(renderTexture);
				renderTexture = null;
				screenShot = null;
			}
		}
		catch (Exception arg)
		{
			Debug.LogError($"failed to record screenshot: {arg}");
			throw;
		}
	}
}

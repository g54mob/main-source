using System;
using System.IO;
using UnityEngine;

public class ScreenCap
{
	public const int videoFrameRate = 30;

	public const int numFramesToCapture = 300;

	public const float moveSpeedScale = 1f;

	public const float lookSpeedScale = 0.75f;

	public static RenderTexture sourceTarget;

	private static bool capturingFrame;

	private static bool capturingVideo;

	private static string videoDir;

	private static int videoFrameIndex;

	private static Texture2D saveTexture;

	private static string forceScreenshotFilename;

	private static bool videoCaptureEditor;

	private static string videoDirForEditor;

	private static int rawSuperSize = 1;

	public static bool capturing
	{
		get
		{
			return capturingFrame || capturingVideo;
		}
	}

	public static string rootDir
	{
		get
		{
			return Directory.GetCurrentDirectory() + ((!Application.isEditor) ? string.Empty : "/..") + "/Captures/";
		}
	}

	private static string videoFrameFilename
	{
		get
		{
			return videoDir + "Frame" + videoFrameIndex.ToString("D08") + ".png";
		}
	}

	private static string videoFrameFilenameForEditor
	{
		get
		{
			return videoDirForEditor + "Frame" + videoFrameIndex.ToString("D08") + ".png";
		}
	}

	private static string screenshotFilename
	{
		get
		{
			return (forceScreenshotFilename == null) ? (rootDir + "Screenshots/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".png") : forceScreenshotFilename;
		}
	}

	private void CreateMenu()
	{
		DebugMenu.Add("Capture", KeyCode.C);
		DebugMenu.Add("Capture/Video", KeyCode.V, StartVideoCapture);
	}

	private static void TakeScreenshotDefault()
	{
		TakeScreenshot();
	}

	private static void AttachToPostRender()
	{
		if (Application.isPlaying)
		{
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(WhenPostRender));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(WhenPostRender));
		}
		else
		{
			StepCapture();
		}
	}

	public static void TakeScreenshot(string forceScreenshotFilename_ = null, int rawSuperSize_ = 1)
	{
		forceScreenshotFilename = forceScreenshotFilename_;
		rawSuperSize = rawSuperSize_;
		capturingFrame = true;
		AttachToPostRender();
	}

	public static void CheckVideoToggle()
	{
		if (Input.GetKeyDown(KeyCode.KeypadMultiply))
		{
			ToggleVideoCapture();
		}
	}

	public static void ToggleVideoCapture()
	{
		if (capturingVideo)
		{
			StopVideoCapture();
		}
		else
		{
			StartVideoCapture();
		}
	}

	public static void StartVideoCapture()
	{
		StartVideoCapture(false);
	}

	public static void StartVideoCapture(bool captureEditor = false)
	{
		capturingVideo = true;
		videoFrameIndex = 0;
		Time.captureFramerate = 30;
		videoDir = rootDir + "Videos/Video-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "/";
		videoDirForEditor = rootDir + "Videos/Video-Editor-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "/";
		videoCaptureEditor = captureEditor;
		Debug.Log("Starting video capture: " + videoDir);
		AttachToPostRender();
	}

	public static void StopVideoCapture()
	{
		capturingVideo = false;
		Time.captureFramerate = 0;
		Debug.Log("Stopping video capture: " + videoDir);
	}

	private static void WhenPostRender(Camera cam)
	{
		if (cam == Camera.main)
		{
			StepCapture();
		}
		if (!capturingVideo && !capturingFrame)
		{
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(WhenPostRender));
		}
	}

	private static void StepCapture()
	{
		if (capturingFrame)
		{
			CreateDirectoryIfNecessary(screenshotFilename);
		}
		if (capturingVideo)
		{
			CreateDirectoryIfNecessary(videoFrameFilename);
		}
		if (sourceTarget != null)
		{
			RenderTexture renderTexture = sourceTarget;
			if (saveTexture == null || saveTexture.width != renderTexture.width || saveTexture.height != renderTexture.height)
			{
				if (saveTexture != null)
				{
					UnityEngine.Object.Destroy(saveTexture);
				}
				saveTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			saveTexture.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			RenderTexture.active = active;
			byte[] bytes = saveTexture.EncodeToPNG();
			if (capturingFrame)
			{
				Debug.Log("Saving screenshot: " + screenshotFilename);
				File.WriteAllBytes(screenshotFilename, bytes);
				capturingFrame = false;
			}
			if (capturingVideo)
			{
				File.WriteAllBytes(videoFrameFilename, bytes);
			}
			sourceTarget = null;
		}
		else
		{
			if (capturingFrame)
			{
				Debug.Log("Saving screenshot: " + screenshotFilename);
				ScreenCapture.CaptureScreenshot(screenshotFilename, rawSuperSize);
				capturingFrame = false;
			}
			if (capturingVideo)
			{
				ScreenCapture.CaptureScreenshot(videoFrameFilename, rawSuperSize);
			}
		}
		forceScreenshotFilename = null;
		if (capturingVideo)
		{
			videoFrameIndex++;
			if (videoFrameIndex >= 300)
			{
				StopVideoCapture();
			}
		}
	}

	private static void CreateDirectoryIfNecessary(string filename)
	{
		string directoryName = Path.GetDirectoryName(filename);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
	}
}

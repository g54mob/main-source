using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AmazingAssets.RenderMonster
{
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Amazing Assets/Render Monster")]
	public class RenderMonster : MonoBehaviour
	{
		public enum BEGIN_RECORDING
		{
			OnStart = 0,
			ByHotkey = 1,
			Manually = 2
		}

		public enum STOP_RECORDING
		{
			ByHotkey = 0,
			AfterNFrame = 1,
			AfterNSec = 2,
			Manually = 3
		}

		public string outputPath;

		public string filePrefix;

		public int superSize = 1;

		public BEGIN_RECORDING beginRecordingMode = BEGIN_RECORDING.ByHotkey;

		public STOP_RECORDING stopRecordingMode;

		public Key recordingHotkey = Key.F12;

		public int nFrame = 300;

		public int nSec = 10;

		public int fPS = 30;

		public Key screenshotHotkey = Key.F5;

		private bool isRecording;

		private int oldFPS;

		private int nFrameCounter;

		private string lastSavedFileName;

		private void Start()
		{
			if (beginRecordingMode == BEGIN_RECORDING.OnStart)
			{
				BeginRecording();
			}
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
			CaptureImageSequence();
			if (IsScreenShotHotKeyDown())
			{
				CaptureScreenshot();
			}
		}

		public void BeginRecording()
		{
			if (string.IsNullOrEmpty(outputPath))
			{
				Debug.LogError("Render Monster: Can not capture image sequence. Output directory is not defined.\n");
			}
			else if (!isRecording)
			{
				isRecording = true;
				if (!Directory.Exists(outputPath))
				{
					Directory.CreateDirectory(outputPath);
				}
				if (!Directory.Exists(outputPath))
				{
					Debug.Log("Render Monster: Can not capture image sequence. Directory '" + outputPath + "' does not exist.\n");
					isRecording = false;
					return;
				}
				Debug.Log("Render Monster: Begin Recording.\n");
				superSize = Mathf.Clamp(superSize, 1, 32);
				nFrameCounter = 0;
				oldFPS = Time.captureFramerate;
				Time.captureFramerate = fPS;
			}
		}

		public void StopRecording()
		{
			if (isRecording)
			{
				isRecording = false;
				Debug.Log("Render Monster: Stop Recording. (" + nFrameCounter + ") frames captured.\n");
				nFrameCounter = 0;
				Time.captureFramerate = oldFPS;
			}
		}

		public bool IsRecording()
		{
			return isRecording;
		}

		private void CaptureImageSequence()
		{
			if (isRecording)
			{
				if ((stopRecordingMode == STOP_RECORDING.ByHotkey && IsRecordingHotKeyDown()) || (stopRecordingMode == STOP_RECORDING.AfterNFrame && nFrameCounter > nFrame) || (stopRecordingMode == STOP_RECORDING.AfterNSec && nFrameCounter > nSec * fPS))
				{
					StopRecording();
				}
			}
			else if (beginRecordingMode == BEGIN_RECORDING.ByHotkey && IsRecordingHotKeyDown())
			{
				BeginRecording();
			}
			if (isRecording)
			{
				nFrameCounter++;
				ScreenCapture.CaptureScreenshot(GetSaveFileName(outputPath), superSize);
			}
		}

		public void CaptureScreenshot()
		{
			if (string.IsNullOrEmpty(outputPath))
			{
				Debug.LogError("Render Monster: Can not capture screenshot. Output directory is not defined.\n");
				return;
			}
			string path = Path.Combine(outputPath, "Screenshot");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (Directory.Exists(path))
			{
				string saveFileName = GetSaveFileName(path);
				ScreenCapture.CaptureScreenshot(saveFileName, superSize);
				Debug.Log("Render Monster: Screenshot saved at path.\n" + saveFileName + "\n");
			}
			else
			{
				Debug.LogError("Render Monster: Can not capture screenshot. Directory '" + outputPath + "' does not exist.\n");
			}
		}

		private bool IsRecordingHotKeyDown()
		{
			return Keyboard.current[recordingHotkey].wasPressedThisFrame;
		}

		private bool IsScreenShotHotKeyDown()
		{
			return Keyboard.current[screenshotHotkey].wasPressedThisFrame;
		}

		private string GetSaveFileName(string path)
		{
			lastSavedFileName = Path.Combine(path, (string.IsNullOrEmpty(filePrefix) ? string.Empty : (filePrefix + "_")) + Time.frameCount + ".png");
			return lastSavedFileName;
		}
	}
}

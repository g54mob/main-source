using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Dev.Scripts
{
	public class DevScreenshotScript : MonoBehaviour
	{
		private Camera _camera;

		[SerializeField]
		private int _resolutionHeight = 1440;

		[SerializeField]
		private int _resolutionWidth = 2560;

		[SerializeField]
		private InputActionProperty _screenshotAction;

		private bool _takeHighResolutionShot;

		public void TakeHighResShot()
		{
			_takeHighResolutionShot = true;
		}

		protected virtual void LateUpdate()
		{
			try
			{
				_takeHighResolutionShot |= Input.GetKeyDown(KeyCode.K);
				if (_takeHighResolutionShot)
				{
					RenderTexture renderTexture = new RenderTexture(_resolutionWidth, _resolutionHeight, 24);
					_camera.targetTexture = renderTexture;
					Texture2D texture2D = new Texture2D(_resolutionWidth, _resolutionHeight, TextureFormat.RGB24, mipChain: false);
					_camera.Render();
					RenderTexture.active = renderTexture;
					texture2D.ReadPixels(new Rect(0f, 0f, _resolutionWidth, _resolutionHeight), 0, 0);
					_camera.targetTexture = null;
					RenderTexture.active = null;
					UnityEngine.Object.Destroy(renderTexture);
					byte[] bytes = texture2D.EncodeToPNG();
					string text = ScreenShotName(_resolutionWidth, _resolutionHeight);
					File.WriteAllBytes(text, bytes);
					Debug.Log($"Took screenshot to: {text}");
					_takeHighResolutionShot = false;
				}
			}
			catch (Exception exception)
			{
				_takeHighResolutionShot = false;
				Debug.LogException(exception);
			}
		}

		protected virtual void Start()
		{
			_camera = GetComponent<Camera>();
			_screenshotAction.action.started += ScreenshotStarted;
		}

		private static string ScreenShotName(int width, int height)
		{
			string text = $"{Application.dataPath}/../../../Screenshots/";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text + string.Format("screen_{0}x{1}_{2}.png", width, height, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
		}

		private void ScreenshotStarted(InputAction.CallbackContext obj)
		{
			TakeHighResShot();
		}
	}
}

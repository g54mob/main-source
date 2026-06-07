using System;
using System.IO;
using System.IO.Compression;
using ManagementScripts;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace OneUseScripts
{
	public class ScreenShotHandler : MonoBehaviour
	{
		protected Camera cam;

		public bool isForScreenShotOnly = true;

		protected bool screenshotNextFrame;

		protected ZipArchive zipTo;

		protected Texture2D texTo;

		protected bool saveTempImg;

		[NonSerialized]
		public UnityEvent onScreeShotSaved = new UnityEvent();

		private UnityAction toCallOnScreenShot;

		protected Rect rect;

		protected bool hasInit;

		public bool useRender;

		[InspectorButton("SaveTempScreenShot")]
		public bool takeTemp;

		public static string tempScreenshotPath => Path.Combine(Application.persistentDataPath, "tempScreenshot.png");

		protected virtual void Awake()
		{
			cam = GetComponent<Camera>();
			if (isForScreenShotOnly)
			{
				base.gameObject.SetActive(value: false);
			}
			hasInit = true;
		}

		private void OnEnable()
		{
			RenderPipelineManager.endCameraRendering += OnRendering;
		}

		private void OnDisable()
		{
			RenderPipelineManager.endCameraRendering -= OnRendering;
		}

		private void OnRendering(ScriptableRenderContext arg1, Camera arg2)
		{
			if (!screenshotNextFrame || arg2 != cam)
			{
				return;
			}
			screenshotNextFrame = false;
			RenderTexture renderTexture = PrepareRenderTextureAndRect();
			Texture2D texture2D = (texTo ? texTo : new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, mipChain: false));
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();
			if (zipTo != null || saveTempImg)
			{
				byte[] array = texture2D.EncodeToPNG();
				if (zipTo != null)
				{
					SaveSystem.WriteFileToArchive(zipTo, "img.png", array);
				}
				else
				{
					if (File.Exists(tempScreenshotPath))
					{
						File.Delete(tempScreenshotPath);
					}
					File.WriteAllBytes(tempScreenshotPath, array);
				}
			}
			RenderTexture.ReleaseTemporary(renderTexture);
			cam.targetTexture = null;
			RenderTexture.active = null;
			zipTo = null;
			if (texTo == null)
			{
				UnityEngine.Object.DestroyImmediate(texture2D);
			}
			else
			{
				texTo = null;
			}
			if (isForScreenShotOnly)
			{
				base.gameObject.SetActive(value: false);
			}
			onScreeShotSaved.Invoke();
			if (toCallOnScreenShot != null)
			{
				toCallOnScreenShot();
				toCallOnScreenShot = null;
			}
		}

		protected virtual RenderTexture PrepareRenderTextureAndRect()
		{
			rect = new Rect(0f, 0f, 400f, 400f);
			return RenderTexture.GetTemporary(400, 400, 24, RenderTextureFormat.ARGB32);
		}

		protected void TakeScreenShot()
		{
			if (!hasInit)
			{
				Awake();
			}
			base.gameObject.SetActive(value: true);
			cam.clearFlags = CameraClearFlags.Color;
			cam.backgroundColor = UserSettings.BackgroundColor.val;
			RenderTexture renderTexture = PrepareRenderTextureAndRect();
			cam.targetTexture = renderTexture;
			RenderTexture.active = cam.targetTexture;
			cam.Render();
			Texture2D texture2D = (texTo ? texTo : new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, mipChain: false));
			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();
			if (zipTo != null || saveTempImg)
			{
				byte[] array = texture2D.EncodeToPNG();
				if (zipTo != null)
				{
					SaveSystem.WriteFileToArchive(zipTo, "img.png", array);
				}
				else
				{
					if (File.Exists(tempScreenshotPath))
					{
						File.Delete(tempScreenshotPath);
					}
					File.WriteAllBytes(tempScreenshotPath, array);
				}
			}
			RenderTexture.ReleaseTemporary(renderTexture);
			cam.targetTexture = null;
			RenderTexture.active = null;
			zipTo = null;
			if (texTo == null)
			{
				UnityEngine.Object.DestroyImmediate(texture2D);
			}
			else
			{
				texTo = null;
			}
			if (isForScreenShotOnly)
			{
				base.gameObject.SetActive(value: false);
			}
			onScreeShotSaved.Invoke();
			if (toCallOnScreenShot != null)
			{
				toCallOnScreenShot();
				toCallOnScreenShot = null;
			}
		}

		public void SaveScreenshotToZip(ZipArchive zip)
		{
			zipTo = zip;
			if (useRender)
			{
				base.gameObject.SetActive(value: true);
				screenshotNextFrame = true;
				cam.Render();
			}
			else
			{
				TakeScreenShot();
			}
		}

		public void SaveScreenshotToImage(Texture2D tex, bool saveAsTempFile = false, UnityAction callOnSaved = null)
		{
			toCallOnScreenShot = callOnSaved;
			saveTempImg = saveAsTempFile;
			texTo = tex;
			if (useRender)
			{
				base.gameObject.SetActive(value: true);
				screenshotNextFrame = true;
				cam.Render();
			}
			else
			{
				TakeScreenShot();
			}
		}

		public void SaveTempScreenShot()
		{
			saveTempImg = true;
			if (useRender)
			{
				base.gameObject.SetActive(value: true);
				screenshotNextFrame = true;
				cam.Render();
			}
			else
			{
				TakeScreenShot();
			}
		}

		private void OnDestroy()
		{
			if (File.Exists(tempScreenshotPath))
			{
				File.Delete(tempScreenshotPath);
			}
		}
	}
}

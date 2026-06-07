using System;
using Assets.Scripts.Input;
using Jundroo.Common.Textures;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Sharing
{
	public class ScreenshotDialogScript : DialogScript
	{
		public enum ScreenshotOrientation
		{
			Landscape = 0,
			Portrait = 1,
			Square = 2,
			None = 3
		}

		private static RenderTexture _backupCameraRenderTexture;

		private static RenderTexture _backupGlobalRenderTexture;

		private IScreenshotDialogHandler _handler;

		private float _initialFov;

		private ScreenshotOrientation _orientation;

		private bool _userInterfaceVisible = true;

		public float FieldOfView
		{
			get
			{
				return _handler?.SceneCamera.fieldOfView ?? 60f;
			}
			set
			{
				if (_handler != null)
				{
					_handler.SceneCamera.fieldOfView = value;
				}
			}
		}

		public override bool IsModal => false;

		public Action<Texture2D> OnScreenshotComplete { get; set; }

		public ScreenshotOrientation Orientation
		{
			get
			{
				return _orientation;
			}
			set
			{
				_orientation = value;
				UpdateOrientation();
			}
		}

		public bool RequireLandscapeOrientation { get; set; }

		public int ScreenshotHeight { get; private set; }

		public int ScreenshotWidth { get; private set; }

		public static Texture2D TakeScreenShotWithCamera(Camera camera, int width, int height, bool allowTransparency, Rect? sampleRect = null)
		{
			if (camera != null)
			{
				PrepareCamera(camera, width, height);
			}
			int width2;
			int height2;
			if (!sampleRect.HasValue)
			{
				sampleRect = new Rect(0f, 0f, width, height);
				width2 = width;
				height2 = height;
			}
			else
			{
				width2 = (int)sampleRect.Value.width;
				height2 = (int)sampleRect.Value.height;
			}
			TextureFormat textureFormat = ((!allowTransparency) ? TextureFormat.RGB24 : TextureFormat.ARGB32);
			Texture2D texture2D = new Texture2D(width2, height2, textureFormat, mipChain: false, linear: false);
			texture2D.ReadPixels(sampleRect.Value, 0, 0, recalculateMipMaps: false);
			texture2D.Apply();
			if (camera != null)
			{
				RestoreCameraSettings(camera);
			}
			return texture2D;
		}

		public override void Close()
		{
			Hide();
			SetSceneUIVisibility(visible: true);
			_handler?.OnScreenshotDialogActivated(activated: false);
			FieldOfView = _initialFov;
			base.Close();
		}

		public void Hide()
		{
			base.Widget.Hide();
		}

		public void Initialize(IScreenshotDialogHandler handler)
		{
			_handler = handler;
			_initialFov = FieldOfView;
			Orientation = ScreenshotOrientation.Landscape;
			Activate();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			AdjustGuides();
		}

		public void Show()
		{
			base.Widget.Show();
			AdjustGuides();
		}

		protected virtual void Awake()
		{
			ScreenshotWidth = 1024;
			ScreenshotHeight = 1024;
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				OnBackClicked(null);
			}
			else if (DebugInput.GetKeyDown(KeyCode.KeypadEnter))
			{
				OnScreenshotClicked(null);
			}
		}

		private static void PrepareCamera(Camera camera, int width, int height)
		{
			_backupGlobalRenderTexture = RenderTexture.active;
			_backupCameraRenderTexture = camera.targetTexture;
			RenderTexture renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB)
			{
				anisoLevel = 8
			};
			if (Game.Instance.Device.IsAndroidBuild)
			{
				renderTexture.antiAliasing = 1;
			}
			else
			{
				renderTexture.antiAliasing = 4;
			}
			camera.targetTexture = renderTexture;
			camera.Render();
			RenderTexture.active = renderTexture;
		}

		private static void RestoreCameraSettings(Camera camera)
		{
			RenderTexture.active = _backupGlobalRenderTexture;
			camera.targetTexture = _backupCameraRenderTexture;
		}

		private void Activate()
		{
			if (RequireLandscapeOrientation)
			{
				Orientation = ScreenshotOrientation.Landscape;
			}
			foreach (Widget item in base.Widget.FindWidgetsByClass("orientation"))
			{
				item.gameObject.SetActive(!RequireLandscapeOrientation);
			}
			UpdateOrientation();
			Show();
			SetSceneUIVisibility(visible: false);
			_handler?.OnScreenshotDialogActivated(activated: true);
		}

		private void AdjustGuides()
		{
			foreach (Widget item in base.Widget.FindWidgetsByClass("screenshot-guide"))
			{
				ScreenshotGuideScript screenshotGuideScript = item.gameObject.AddComponent<ScreenshotGuideScript>();
				if (item.HasClass("left-right"))
				{
					screenshotGuideScript.GuideType = ScreenshotGuideScript.ScreenshotGuideType.LeftRight;
				}
				else
				{
					screenshotGuideScript.GuideType = ScreenshotGuideScript.ScreenshotGuideType.TopBottom;
				}
				screenshotGuideScript.AspectRatio = (float)ScreenshotWidth / (float)ScreenshotHeight;
			}
		}

		private void OnBackClicked(Widget widget)
		{
			OnScreenshotComplete?.Invoke(null);
			Close();
		}

		private void OnFieldOfViewSliderChanged(float x)
		{
			UpdateFieldOfView(updateCamera: true);
		}

		private void OnLandscapeClicked(Widget widget)
		{
			SelectOrientation(ScreenshotOrientation.Landscape);
		}

		private void OnPortraitClicked(Widget widget)
		{
			SelectOrientation(ScreenshotOrientation.Portrait);
		}

		private void OnScreenshotClicked(Widget widget)
		{
			Vector2i resolution = new Vector2i(ScreenshotWidth, ScreenshotHeight);
			base.Widget.Visible = false;
			Screenshots.TakeScreenShot(resolution, delegate(Texture2D x)
			{
				OnScreenshotComplete?.Invoke(x);
				Close();
			});
		}

		private void OnSquareClicked(Widget widget)
		{
			SelectOrientation(ScreenshotOrientation.Square);
		}

		private void OnToggleUIClicked(Widget widget)
		{
			SetSceneUIVisibility(!_userInterfaceVisible);
			if (_userInterfaceVisible)
			{
				widget.AddClass("btn-primary");
			}
			else
			{
				widget.RemoveClass("btn-primary");
			}
		}

		private void SelectOrientation(ScreenshotOrientation orientation)
		{
			if (Orientation == orientation && Application.isEditor)
			{
				Orientation = ScreenshotOrientation.None;
			}
			else
			{
				Orientation = orientation;
			}
		}

		private void SetSceneUIVisibility(bool visible)
		{
			_userInterfaceVisible = visible;
			_handler?.SetSceneUIVisibility(visible);
		}

		private void UpdateFieldOfView(bool updateCamera)
		{
		}

		private void UpdateOrientation()
		{
			if (Orientation == ScreenshotOrientation.Landscape)
			{
				ScreenshotWidth = 1920;
				ScreenshotHeight = 1080;
			}
			else if (Orientation == ScreenshotOrientation.Portrait)
			{
				ScreenshotWidth = 1080;
				ScreenshotHeight = 1920;
			}
			else if (Orientation == ScreenshotOrientation.Square)
			{
				ScreenshotWidth = 1024;
				ScreenshotHeight = ScreenshotWidth;
			}
			else
			{
				ScreenshotWidth = Screen.width;
				ScreenshotHeight = Screen.height;
			}
			UpdateOrientationButton("orientation-landscape", Orientation == ScreenshotOrientation.Landscape);
			UpdateOrientationButton("orientation-portrait", Orientation == ScreenshotOrientation.Portrait);
			UpdateOrientationButton("orientation-square", Orientation == ScreenshotOrientation.Square);
			AdjustGuides();
		}

		private void UpdateOrientationButton(string buttonId, bool toggled)
		{
			Widget widget = base.Widget.FindWidget(buttonId);
			if (toggled)
			{
				widget.AddClass("btn-primary");
			}
			else
			{
				widget.RemoveClass("btn-primary");
			}
		}
	}
}

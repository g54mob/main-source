using System;
using Assets.Scripts.Design;
using Assets.Scripts.Input;
using Assets.Scripts.PlanetStudio;
using ModApi.Common.Textures;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Screenshot
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

		private DepthOfFieldEffect _depthOfFieldEffect;

		private DesignerScript _designerScript;

		private XmlLayout _layout;

		private GameObject _mainPanel;

		private ScreenshotOrientation _orientation = ScreenshotOrientation.Square;

		private SliderControl _sliderFov;

		private bool _userInterfaceVisible = true;

		public float FieldOfView
		{
			get
			{
				if (Game.InFlightScene)
				{
					return Game.Instance.FlightScene.ViewManager.GameView.GameCamera.FieldOfView;
				}
				if (Game.InDesignerScene)
				{
					return Game.Instance.Designer.DesignerCamera.FieldOfView;
				}
				return 0f;
			}
			set
			{
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.ViewManager.GameView.GameCamera.FieldOfView = value;
				}
				else if (Game.InDesignerScene)
				{
					Game.Instance.Designer.DesignerCamera.FieldOfView = value;
				}
			}
		}

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

		public bool RequireSquareOrientation { get; set; }

		public int ScreenshotHeight { get; private set; }

		public int ScreenshotWidth { get; private set; }

		public static ScreenshotDialogScript Create(Transform parent)
		{
			ScreenshotDialogScript dialog = Game.Instance.UserInterface.CreateDialog<ScreenshotDialogScript>(parent, registerWithUserInterface: false);
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Sharing/ScreenshotDialog", dialog, delegate(IXmlLayoutController x)
			{
				dialog.OnLayoutRebuilt((XmlLayout)x.XmlLayout);
			});
			if (Game.InDesignerScene)
			{
				dialog._designerScript = Game.Instance.Designer as DesignerScript;
			}
			return dialog;
		}

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

		public void Activate()
		{
			Game.Instance.UserInterface.RegisterDialog(this);
			base.AllowCameraZoom = true;
			if (RequireSquareOrientation)
			{
				Orientation = ScreenshotOrientation.Square;
			}
			foreach (XmlElement item in _layout.GetElementsByClass("orientation"))
			{
				item.gameObject.SetActive(!RequireSquareOrientation);
			}
			UpdateOrientation();
			Show();
			SetSceneUiVisibility(visible: false);
			if (_designerScript != null)
			{
				_designerScript.SelectTool(_designerScript.ScreenshotTool);
			}
		}

		public override void Close()
		{
			FieldOfView = Game.Instance.Settings.Game.General.FieldOfView.Value;
			base.Close();
			base.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void Deactivate()
		{
			_depthOfFieldEffect.Enabled = false;
			Game.Instance.UserInterface.UnregisterDialog(this);
			Hide();
			SetSceneUiVisibility(visible: true);
			if (_designerScript != null)
			{
				_designerScript.DeselectTool(_designerScript.ScreenshotTool);
			}
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Show()
		{
			_mainPanel.SetActive(value: true);
			AdjustGuides();
			base.gameObject.SetActive(value: true);
		}

		protected virtual void Awake()
		{
			ScreenshotWidth = 1024;
			ScreenshotHeight = 1024;
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

		private void AdjustGuides()
		{
			foreach (XmlElement item in _layout.GetElementsByClass("screenshot-guide"))
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

		private void OnBackClicked()
		{
			Hide();
			OnScreenshotComplete?.Invoke(null);
		}

		private void OnDepthOfFieldClicked()
		{
			_depthOfFieldEffect.Enabled = !_depthOfFieldEffect.Enabled;
		}

		private void OnFieldOfViewSliderChanged(float x)
		{
			UpdateFieldOfView(updateCamera: true);
		}

		private void OnLandscapeClicked()
		{
			SelectOrientation(ScreenshotOrientation.Landscape);
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_layout = xmlLayout;
			_mainPanel = xmlLayout.GetElementById("main-panel").gameObject;
			_depthOfFieldEffect = new DepthOfFieldEffect(xmlLayout);
			if (Game.InPlanetStudioScene)
			{
				xmlLayout.GetElementById("field-of-view-panel").SetActive(active: false);
			}
			else
			{
				_sliderFov = new SliderControl(xmlLayout.GetElementById("slider-field-of-view"));
				_sliderFov.Slider.minValue = 20f;
				_sliderFov.Slider.maxValue = 120f;
				_sliderFov.Slider.value = FieldOfView;
				_sliderFov.Slider.onValueChanged.AddListener(delegate(float x)
				{
					OnFieldOfViewSliderChanged(x);
				});
				UpdateFieldOfView(updateCamera: false);
			}
			AdjustGuides();
		}

		private void OnPortraitClicked()
		{
			SelectOrientation(ScreenshotOrientation.Portrait);
		}

		private void OnScreenshotClicked()
		{
			Screenshots.TakeScreenShot(new Vector2i(ScreenshotWidth, ScreenshotHeight), delegate(Texture2D x)
			{
				OnScreenshotComplete?.Invoke(x);
			});
			Hide();
		}

		private void OnSquareClicked()
		{
			SelectOrientation(ScreenshotOrientation.Square);
		}

		private void OnToggleUiClicked(XmlElement element)
		{
			SetSceneUiVisibility(!_userInterfaceVisible);
			if (_userInterfaceVisible)
			{
				element.AddClass("btn-primary");
			}
			else
			{
				element.RemoveClass("btn-primary");
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

		private void SetSceneUiVisibility(bool visible)
		{
			_userInterfaceVisible = visible;
			if (Game.InFlightScene)
			{
				Game.Instance.FlightScene.FlightSceneUI.Visible = visible;
				Game.Instance.FlightScene.ViewManager.MapViewManager.MapView.UiPanelsVisible = visible;
			}
			else if (Game.InDesignerScene)
			{
				(Game.Instance.Designer as DesignerScript).DesignerUiScript.Visible = visible;
			}
			else if (Game.InPlanetStudioScene)
			{
				PlanetStudioScript.Instance.PlanetStudioUI.Visible = visible;
			}
		}

		private void Update()
		{
			if (Game.Instance.Inputs.ToggleMapView.GetButtonDownIfEnabled())
			{
				Game.Instance.FlightScene.ViewManager.ToggleMapView();
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				OnBackClicked();
			}
			else if (DebugInput.GetKeyDown(KeyCode.KeypadEnter))
			{
				OnScreenshotClicked();
			}
			_depthOfFieldEffect.Update();
		}

		private void UpdateFieldOfView(bool updateCamera)
		{
			int num = (int)_sliderFov.Slider.value;
			_sliderFov.ValueText.text = string.Format("{0:n0}{1}", num, "°");
			if (updateCamera)
			{
				FieldOfView = num;
			}
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
			XmlElement elementById = _layout.GetElementById(buttonId);
			if (toggled)
			{
				elementById.AddClass("btn-primary");
			}
			else
			{
				elementById.RemoveClass("btn-primary");
			}
		}
	}
}

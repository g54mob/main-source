using Client;
using Factory;
using Motorways.Constants;
using UnityEngine;
using Utils;

namespace Motorways.Views
{
	public class PhotoScreen : OverlayBaseScreen
	{
		[SerializeField]
		private CanvasGroup _flash;

		[SerializeField]
		private Shader _photoModeCopyShader;

		private Material _photoModeCopyMaterial;

		private string _folderString = "";

		protected override OverlayScreenType overlayScreenType => OverlayScreenType.PhotoScreen;

		public override void Awake()
		{
			base.Awake();
			_photoModeCopyMaterial = new Material(_photoModeCopyShader);
		}

		public override void InitScreen(IScope gameScope, bool blocksGameInput)
		{
			base.InitScreen(gameScope, blocksGameInput);
			StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(_appScope, StringId.MiniMotorways);
			_folderString = standaloneLocString.ToString();
			_appScope.Release(standaloneLocString);
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_flash.alpha > 0f)
			{
				_flash.alpha = Mathf.Clamp01(_flash.alpha - deltaTime);
			}
		}

		public void OnTakePhoto()
		{
			_game.Scope.Get<NotificationView>().KillNotification();
			SetFrameLayer(LayerConstants.OverlayLayerId);
			base.nonPhotoLayer.alpha = 0f;
			_flash.alpha = 0f;
			GameObject gameObject = new GameObject();
			Camera camera = gameObject.AddComponent<Camera>();
			MiniMotorwaysRenderFeatureCameraMarker obj = gameObject.AddComponent<MiniMotorwaysRenderFeatureCameraMarker>();
			camera.CopyFrom(gameCamera.DefaultCamera);
			_canvas.worldCamera = camera;
			Camera worldCamera = _screenStack.FadeToBlackCanvas.worldCamera;
			_screenStack.FadeToBlackCanvas.worldCamera = camera;
			Vector2Int vector2Int = softwareCapabilities.ScreenshotDimensions;
			if (!Diagnostics.Verify(vector2Int.x > 0 && vector2Int.y > 0, "Screenshot Dimensions are invalid!"))
			{
				vector2Int = new Vector2Int(Screen.width, Screen.height);
			}
			RenderTexture temporary = RenderTexture.GetTemporary(vector2Int.x, vector2Int.y, 24, RenderTextureFormat.ARGB32);
			temporary.antiAliasing = _player.AntiAliasingMSAALevelForUniversalRenderPipeline;
			camera.targetTexture = temporary;
			camera.Render();
			Object.DestroyImmediate(obj);
			RenderTexture temporary2 = RenderTexture.GetTemporary(vector2Int.x, vector2Int.y, 24, RenderTextureFormat.ARGB32);
			temporary2.antiAliasing = _player.AntiAliasingMSAALevelForUniversalRenderPipeline;
			AuxiliaryGameCamera[] componentsInChildren = gameCamera.GetComponentsInChildren<AuxiliaryGameCamera>();
			foreach (AuxiliaryGameCamera auxiliaryGameCamera in componentsInChildren)
			{
				if (auxiliaryGameCamera.ShouldRenderInPhotosFromPhotoMode)
				{
					Camera component = auxiliaryGameCamera.GetComponent<Camera>();
					camera.Reset();
					camera.CopyFrom(component);
					camera.backgroundColor = Color.clear;
					camera.clearFlags = CameraClearFlags.Color;
					camera.targetTexture = temporary2;
					camera.Render();
					Graphics.Blit(temporary2, temporary, _photoModeCopyMaterial);
				}
			}
			RenderTexture.ReleaseTemporary(temporary2);
			_screenStack.FadeToBlackCanvas.worldCamera = worldCamera;
			_canvas.worldCamera = gameCamera.UICamera;
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			Texture2D texture2D = new Texture2D(temporary.width, temporary.height, TextureFormat.RGB24, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
			texture2D.Apply();
			if (!Diagnostics.Verify(!string.IsNullOrEmpty(_folderString), "Parent folder string isn't set!"))
			{
				_folderString = "Mini Motorways";
			}
			StringKey stringKey = _appScope.Get<StringKey>();
			stringKey.InitWithString(_game.MapDefinition.mapName);
			StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(_appScope, stringKey);
			StringId messageId;
			bool num = softwareCapabilities.SaveScreenshot(texture2D, standaloneLocString.ToString(), _folderString, out messageId);
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			base.nonPhotoLayer.alpha = 1f;
			if (num)
			{
				_flash.alpha = 1f;
			}
			SetFrameLayer(LayerConstants.UILayerId);
			Object.Destroy(gameObject);
			if (messageId != StringId.None)
			{
				_game.Scope.Get<NotificationView>().AddNotification(messageId);
			}
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			foreach (VehicleView view in _gameScope.Get<ViewClient>().GetViews<VehicleView>())
			{
				view.SkipHeadlightResponseTime = false;
			}
		}
	}
}

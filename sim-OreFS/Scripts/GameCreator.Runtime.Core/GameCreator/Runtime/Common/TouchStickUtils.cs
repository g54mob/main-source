using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common
{
	public static class TouchStickUtils
	{
		private const int SORT_ORDER = 9999;

		private static readonly Vector2 RESOLUTION = new Vector2(1920f, 1080f);

		private static readonly Vector2 ANCHOR_LEFT = new Vector2(0f, 0f);

		private static readonly Vector2 ANCHOR_MIDDLE = new Vector2(0.5f, 0.5f);

		private static readonly Vector2 ANCHOR_RIGHT = new Vector2(1f, 0f);

		private const float SURFACE_OFFSET = 275f;

		private const float SURFACE_SIZE = 250f;

		private const float STICK_SIZE = 100f;

		public static void CreateCanvas(GameObject instance)
		{
			Canvas canvas = instance.AddComponent<Canvas>();
			CanvasScaler canvasScaler = instance.AddComponent<CanvasScaler>();
			instance.AddComponent<GraphicRaycaster>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.sortingOrder = 9999;
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = RESOLUTION;
			canvasScaler.matchWidthOrHeight = 1f;
		}

		public static void CreateControlsLeft(GameObject instance)
		{
			CreateControls(instance, out var surfaceTransform, out var stickTransform);
			TouchStickLeft touchStickLeft = surfaceTransform.gameObject.AddComponent<TouchStickLeft>();
			touchStickLeft.Surface = surfaceTransform;
			touchStickLeft.Stick = stickTransform;
			touchStickLeft.Root = instance;
			surfaceTransform.pivot = ANCHOR_MIDDLE;
			surfaceTransform.anchorMin = ANCHOR_LEFT;
			surfaceTransform.anchorMax = ANCHOR_LEFT;
			surfaceTransform.anchoredPosition = new Vector2(275f, 275f);
			surfaceTransform.sizeDelta = new Vector2(250f, 250f);
			stickTransform.pivot = ANCHOR_MIDDLE;
			stickTransform.anchorMin = ANCHOR_MIDDLE;
			stickTransform.anchorMax = ANCHOR_MIDDLE;
			stickTransform.anchoredPosition = Vector2.zero;
			stickTransform.sizeDelta = new Vector2(100f, 100f);
		}

		public static void CreateControlsRight(GameObject instance)
		{
			CreateControls(instance, out var surfaceTransform, out var stickTransform);
			TouchStickRight touchStickRight = surfaceTransform.gameObject.AddComponent<TouchStickRight>();
			touchStickRight.Surface = surfaceTransform;
			touchStickRight.Stick = stickTransform;
			touchStickRight.Root = instance;
			surfaceTransform.pivot = ANCHOR_MIDDLE;
			surfaceTransform.anchorMin = ANCHOR_RIGHT;
			surfaceTransform.anchorMax = ANCHOR_RIGHT;
			surfaceTransform.anchoredPosition = new Vector2(-275f, 275f);
			surfaceTransform.sizeDelta = new Vector2(250f, 250f);
			stickTransform.pivot = ANCHOR_MIDDLE;
			stickTransform.anchorMin = ANCHOR_MIDDLE;
			stickTransform.anchorMax = ANCHOR_MIDDLE;
			stickTransform.anchoredPosition = Vector2.zero;
			stickTransform.sizeDelta = new Vector2(100f, 100f);
		}

		private static void CreateControls(GameObject instance, out RectTransform surfaceTransform, out RectTransform stickTransform)
		{
			GameObject gameObject = new GameObject("Surface");
			GameObject gameObject2 = new GameObject("Stick");
			gameObject.transform.SetParent(instance.transform);
			gameObject2.transform.SetParent(gameObject.transform);
			surfaceTransform = gameObject.AddComponent<RectTransform>();
			stickTransform = gameObject2.AddComponent<RectTransform>();
			Image image = gameObject.AddComponent<Image>();
			Image image2 = gameObject2.AddComponent<Image>();
			image.overrideSprite = TouchStickImageSurface.Value;
			image2.overrideSprite = TouchStickImageStick.Value;
		}
	}
}

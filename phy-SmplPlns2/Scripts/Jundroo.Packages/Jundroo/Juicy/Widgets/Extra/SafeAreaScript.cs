using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class SafeAreaScript : MonoBehaviour, ICanvasScaleChangeHandler
	{
		private struct Borders
		{
			public float Bottom;

			public float Left;

			public float Right;

			public float Top;
		}

		private RectTransform _rect;

		public bool IsEnabled { get; set; } = true;

		void ICanvasScaleChangeHandler.OnCanvasScaleChanged(float canvasScaleFactor)
		{
			RecalculateDimensions(canvasScaleFactor);
		}

		public void RecalculateDimensions(float? canvasScaleFactor = null)
		{
			float num = 1f;
			num = ((!canvasScaleFactor.HasValue) ? (GetComponentInParent<CanvasScaler>()?.scaleFactor ?? 1f) : canvasScaleFactor.Value);
			if (IsEnabled)
			{
				Borders safeAreaBorders = GetSafeAreaBorders();
				_rect.offsetMin = new Vector2(safeAreaBorders.Left / num, safeAreaBorders.Bottom / num);
				_rect.offsetMax = new Vector2((0f - safeAreaBorders.Right) / num, (0f - safeAreaBorders.Top) / num);
			}
			else
			{
				_rect.offsetMin = Vector2.zero;
				_rect.offsetMax = Vector2.zero;
			}
		}

		protected virtual void Awake()
		{
			_rect = GetComponent<RectTransform>();
		}

		protected virtual void Start()
		{
			RecalculateDimensions();
		}

		private static Borders GetSafeAreaBorders()
		{
			Rect rect = Screen.safeArea;
			if (Application.isEditor)
			{
				if (Screen.width == 2436 && Screen.height == 1125)
				{
					rect = new Rect(132f, 63f, 2172f, 1062f);
				}
				else if (Screen.width == 2532 && Screen.height == 1170)
				{
					rect = new Rect(141f, 63f, 2250f, 981f);
				}
			}
			return new Borders
			{
				Left = rect.xMin,
				Right = (float)Screen.width - rect.xMax,
				Top = (float)Screen.height - rect.yMax,
				Bottom = rect.yMin
			};
		}
	}
}

using UnityEngine;
using UnityEngine.Events;

namespace FuryStudios.FurySDK.Utils
{
	public class SafeArea : MonoBehaviour
	{
		private const float REFRESH_FREQUENCY = 1f;

		public UnityEvent onChange;

		public bool testing;

		public KeyCode testKey;

		public bool drawSafeArea;

		private RectTransform rectTransform;

		private Canvas parentCanvas;

		private float lastRefreshTime;

		private Rect currentSafeArea;

		private Rect previousSafeArea;

		private Rect previousCanvasScreenRect;

		private bool useDebugSafeArea;

		private int debugAreaIndex;

		private const int DEBUG_AREAS_COUNT = 5;

		private Material debugDrawMat;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void RefreshSafeArea()
		{
		}

		private void OnRenderObject()
		{
		}

		private static Rect GetViewportRect(Rect screenRect)
		{
			return default(Rect);
		}

		private Rect GetDebugSafeArea()
		{
			return default(Rect);
		}
	}
}

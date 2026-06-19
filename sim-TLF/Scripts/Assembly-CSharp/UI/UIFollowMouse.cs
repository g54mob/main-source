using UnityEngine;

namespace UI
{
	public class UIFollowMouse : MonoBehaviour
	{
		public float smooth = 10f;

		public Vector2 offset;

		private RectTransform rectTransform;

		private RectTransform parentRect;

		private Canvas canvas;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			parentRect = rectTransform.parent as RectTransform;
			canvas = GetComponentInParent<Canvas>();
		}

		private void Update()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, Input.mousePosition, (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera, out var localPoint);
			Vector2 vector = localPoint + offset;
			if (smooth <= 0f)
			{
				rectTransform.anchoredPosition = vector;
			}
			else
			{
				rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, vector, Time.deltaTime * smooth);
			}
		}
	}
}

using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class WindowResize : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		private enum ResizeableType
		{
			None = 0,
			Top = 1,
			Bottom = 2,
			Right = 4,
			Left = 8,
			LeftTop = 9,
			RightTop = 5,
			LeftBottom = 10,
			RightBottom = 6
		}

		[SerializeField]
		private RectTransform resizableArea;

		private float cursorScope;

		private float minWidth;

		private float minHeight;

		[SerializeField]
		private Texture2D cursorHorizonal;

		[SerializeField]
		private Texture2D cursorVertical;

		[SerializeField]
		private Texture2D cursorDiagonalLeft;

		[SerializeField]
		private Texture2D cursorDiagonalRight;

		[SerializeField]
		private Vector2 mCursorHotSpot;

		private ResizeableType curResizeableType;

		private RectTransform resizableRect;

		private Camera cachedEventCamera;

		private bool isPressed;

		private void Start()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		private void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
		{
		}

		private void UpdateCursor()
		{
		}

		private void LateUpdate()
		{
		}

		private ResizeableType GetCurResizeableType(Vector2 mousePosition, Camera eventCamera)
		{
			return default(ResizeableType);
		}

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}

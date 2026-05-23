using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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

		private float cursorScope = 20f;

		private float minWidth = 100f;

		private float minHeight = 100f;

		[SerializeField]
		private Texture2D cursorHorizonal;

		[SerializeField]
		private Texture2D cursorVertical;

		[SerializeField]
		private Texture2D cursorDiagonalLeft;

		[SerializeField]
		private Texture2D cursorDiagonalRight;

		[SerializeField]
		private Vector2 mCursorHotSpot = new Vector2(16f, 16f);

		private ResizeableType curResizeableType;

		private RectTransform resizableRect;

		private Camera cachedEventCamera;

		private bool isPressed;

		private void Start()
		{
			resizableRect = GetComponent<RectTransform>();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			cachedEventCamera = eventData.enterEventCamera;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			curResizeableType = GetCurResizeableType(eventData.position, eventData.pressEventCamera);
			isPressed = curResizeableType != ResizeableType.None;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isPressed = false;
		}

		private void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
		{
			if (Mouse.current != null)
			{
				Cursor.SetCursor(texture, hotspot, cursorMode);
			}
		}

		private void UpdateCursor()
		{
			if (curResizeableType == ResizeableType.None)
			{
				SetCursor(null, mCursorHotSpot, CursorMode.Auto);
			}
			else if (curResizeableType == ResizeableType.Left || curResizeableType == ResizeableType.Right)
			{
				SetCursor(cursorHorizonal, mCursorHotSpot, CursorMode.Auto);
			}
			else if (curResizeableType == ResizeableType.Top || curResizeableType == ResizeableType.Bottom)
			{
				SetCursor(cursorVertical, mCursorHotSpot, CursorMode.Auto);
			}
			else if (curResizeableType == ResizeableType.LeftTop || curResizeableType == ResizeableType.RightBottom)
			{
				SetCursor(cursorDiagonalLeft, mCursorHotSpot, CursorMode.Auto);
			}
			else if (curResizeableType == ResizeableType.RightTop || curResizeableType == ResizeableType.LeftBottom)
			{
				SetCursor(cursorDiagonalRight, mCursorHotSpot, CursorMode.Auto);
			}
		}

		private void LateUpdate()
		{
			if (cachedEventCamera == null)
			{
				SetCursor(null, mCursorHotSpot, CursorMode.Auto);
				return;
			}
			if (isPressed)
			{
				UpdateCursor();
				return;
			}
			Vector2 mousePosition = Mouse.current.position.ReadValue();
			curResizeableType = GetCurResizeableType(mousePosition, cachedEventCamera);
			UpdateCursor();
		}

		private ResizeableType GetCurResizeableType(Vector2 mousePosition, Camera eventCamera)
		{
			if (!RectTransformUtility.RectangleContainsScreenPoint(resizableArea, mousePosition, eventCamera))
			{
				return ResizeableType.None;
			}
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(resizableArea, mousePosition, eventCamera, out var localPoint))
			{
				return ResizeableType.None;
			}
			float width = resizableArea.rect.width;
			float height = resizableArea.rect.height;
			ResizeableType resizeableType = ResizeableType.None;
			if (width / 2f - Mathf.Abs(localPoint.x) <= cursorScope)
			{
				resizeableType = ((!(localPoint.x > 0f)) ? (resizeableType | ResizeableType.Left) : (resizeableType | ResizeableType.Right));
			}
			if (height / 2f - Mathf.Abs(localPoint.y) <= cursorScope)
			{
				resizeableType = ((!(localPoint.y > 0f)) ? (resizeableType | ResizeableType.Bottom) : (resizeableType | ResizeableType.Top));
			}
			return resizeableType;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!isPressed)
			{
				return;
			}
			Vector2 localPoint = Vector2.zero;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(resizableRect, eventData.position, eventData.enterEventCamera, out localPoint))
			{
				return;
			}
			float num = resizableArea.rect.width;
			float num2 = resizableArea.rect.height;
			float num3 = resizableArea.anchoredPosition3D.x;
			float num4 = resizableArea.anchoredPosition3D.y;
			if ((curResizeableType & ResizeableType.Top) != ResizeableType.None)
			{
				float num5 = localPoint.y - num2 / 2f;
				num2 += num5;
				if (num2 < minHeight)
				{
					num2 = minHeight;
				}
				else
				{
					num4 += num5 / 2f;
				}
			}
			if ((curResizeableType & ResizeableType.Bottom) != ResizeableType.None)
			{
				float num6 = 0f - (localPoint.y + num2 / 2f);
				num2 += num6;
				if (num2 < minHeight)
				{
					num2 = minHeight;
				}
				else
				{
					num4 -= num6 / 2f;
				}
			}
			if ((curResizeableType & ResizeableType.Right) != ResizeableType.None)
			{
				float num7 = localPoint.x - num / 2f;
				num += num7;
				if (num < minWidth)
				{
					num = minWidth;
				}
				else
				{
					num3 += num7 / 2f;
				}
			}
			if ((curResizeableType & ResizeableType.Left) != ResizeableType.None)
			{
				float num8 = 0f - (localPoint.x + num / 2f);
				num += num8;
				if (num < minWidth)
				{
					num = minWidth;
				}
				else
				{
					num3 -= num8 / 2f;
				}
			}
			resizableRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
			resizableRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
			Vector3 anchoredPosition3D = new Vector3(num3, num4, 0f);
			resizableRect.anchoredPosition3D = anchoredPosition3D;
		}
	}
}

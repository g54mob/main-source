using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class WindowResizeHandle : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler
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

		[SerializeField]
		private GameObject topHandle;

		[SerializeField]
		private GameObject bottomHandle;

		[SerializeField]
		private GameObject leftHandle;

		[SerializeField]
		private GameObject rightHandle;

		[SerializeField]
		private GameObject leftTopHandle;

		[SerializeField]
		private GameObject rightTopHandle;

		[SerializeField]
		private GameObject leftBottomHandle;

		[SerializeField]
		private GameObject rightBottomHandle;

		private ResizeableType curResizeableType;

		private RectTransform resizableRect;

		private float minWidth = 100f;

		private float minHeight = 100f;

		private void Start()
		{
			resizableRect = GetComponent<RectTransform>();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			GameObject pointerEnter = eventData.pointerEnter;
			if (!(pointerEnter == null))
			{
				curResizeableType = GetCurResizeableType(pointerEnter);
			}
		}

		private ResizeableType GetCurResizeableType(GameObject curDraggingObj)
		{
			ResizeableType result = ResizeableType.None;
			if (curDraggingObj == topHandle)
			{
				result = ResizeableType.Top;
			}
			else if (curDraggingObj == bottomHandle)
			{
				result = ResizeableType.Bottom;
			}
			else if (curDraggingObj == leftHandle)
			{
				result = ResizeableType.Left;
			}
			else if (curDraggingObj == rightHandle)
			{
				result = ResizeableType.Right;
			}
			else if (curDraggingObj == leftTopHandle)
			{
				result = ResizeableType.LeftTop;
			}
			else if (curDraggingObj == rightTopHandle)
			{
				result = ResizeableType.RightTop;
			}
			else if (curDraggingObj == leftBottomHandle)
			{
				result = ResizeableType.LeftBottom;
			}
			else if (curDraggingObj == rightBottomHandle)
			{
				result = ResizeableType.RightBottom;
			}
			return result;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (curResizeableType == ResizeableType.None)
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

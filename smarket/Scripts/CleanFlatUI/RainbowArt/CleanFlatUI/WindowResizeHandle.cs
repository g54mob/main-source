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

		private float minWidth;

		private float minHeight;

		private void Start()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		private ResizeableType GetCurResizeableType(GameObject curDraggingObj)
		{
			return default(ResizeableType);
		}

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}

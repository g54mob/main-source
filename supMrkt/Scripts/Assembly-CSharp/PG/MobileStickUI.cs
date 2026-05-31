using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PG
{
	public class MobileStickUI : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public Image StickIcon;

		public float MaxRadius;

		public float DeadZone;

		private Vector2 StickPos;

		private RectTransform StickImageRectTR;

		public Vector2 InputValue { get; private set; }

		public bool IsPressed { get; private set; }

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}
	}
}

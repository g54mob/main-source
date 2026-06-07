using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public abstract class TTouchStick : MonoBehaviour, ITouchStick, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		public virtual Vector2 Value { get; protected set; }

		public virtual GameObject Root { get; protected internal set; }

		protected internal virtual RectTransform Surface { get; set; }

		protected internal virtual RectTransform Stick { get; set; }

		protected void Start()
		{
			EventSystemManager.RequestEventSystem();
		}

		protected virtual void OnEnable()
		{
			Value = Vector2.zero;
			if (Stick != null)
			{
				Stick.anchoredPosition = Vector2.zero;
			}
		}

		protected virtual void OnDisable()
		{
			Value = Vector2.zero;
			if (Stick != null)
			{
				Stick.anchoredPosition = Vector2.zero;
			}
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!(Stick == null) && !(Surface == null))
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(Surface, eventData.position, eventData.pressEventCamera, out var localPoint);
				Vector2 sizeDelta = Surface.sizeDelta;
				Vector2 sizeDelta2 = Stick.sizeDelta;
				localPoint.x /= sizeDelta.x;
				localPoint.y /= sizeDelta.y;
				float x = Mathf.Lerp(localPoint.x * 2f + 1f, localPoint.x * 2f - 1f, Surface.pivot.x);
				float y = Mathf.Lerp(localPoint.y * 2f + 1f, localPoint.y * 2f - 1f, Surface.pivot.y);
				Value = Vector2.ClampMagnitude(new Vector2(x, y), 1f);
				Stick.anchoredPosition = new Vector2(Value.x * (sizeDelta.x / 2f - sizeDelta2.x / 2f), Value.y * (sizeDelta.y / 2f - sizeDelta2.y / 2f));
			}
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			Value = Vector2.zero;
			if (Stick != null)
			{
				Stick.anchoredPosition = Vector2.zero;
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			OnDrag(eventData);
		}
	}
}

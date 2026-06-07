using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Placemaker.Ui
{
	public class BaseButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
	{
		public enum State : byte
		{
			None = 0,
			Hover = 1,
			Pressed = 2,
			Disabled = 3
		}

		[SerializeField]
		public UnityEvent onClick;

		public bool pointerInside;

		public bool buttonDown;

		public float holdTime;

		public PointerEventData eventData;

		[SerializeField]
		private bool _disabled;

		public Action<State> onStateChange;

		public Action onClickAction;

		public Action<bool> onButtonDownChange;

		public State state;

		public float timeHeld => 0f;

		public bool disabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetState(State state)
		{
		}

		public void Subscribe(Action<State> onStateChangeFunc)
		{
		}

		public void PushState()
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		public void Click()
		{
		}

		public void SetHover(bool isActive)
		{
		}
	}
}

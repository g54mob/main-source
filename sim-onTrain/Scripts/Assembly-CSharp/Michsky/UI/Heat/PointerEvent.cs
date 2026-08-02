using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Michsky.UI.Heat
{
	public class PointerEvent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("Settings")]
		public bool addEventTrigger = true;

		[Header("Events")]
		[SerializeField]
		private UnityEvent onClick = new UnityEvent();

		[SerializeField]
		private UnityEvent onEnter = new UnityEvent();

		[SerializeField]
		private UnityEvent onExit = new UnityEvent();

		private void Awake()
		{
			if (addEventTrigger)
			{
				base.gameObject.AddComponent<EventTrigger>();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			onClick.Invoke();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			onEnter.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			onExit.Invoke();
		}
	}
}

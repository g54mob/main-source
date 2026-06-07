using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	public class MMOnPointer : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
	{
		[Tooltip("an event to trigger when the pointer enters the associated game object")]
		[Header("Pointer movement")]
		public UnityEvent PointerEnter;

		[Tooltip("an event to trigger when the pointer exits the associated game object")]
		public UnityEvent PointerExit;

		[Tooltip("an event to trigger when the pointer is pressed down on the associated game object")]
		[Header("Clicks")]
		public UnityEvent PointerDown;

		[Tooltip("an event to trigger when the pointer is pressed up on the associated game object")]
		public UnityEvent PointerUp;

		[Tooltip("an event to trigger when the pointer is clicked on the associated game object")]
		public UnityEvent PointerClick;

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

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}

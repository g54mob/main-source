using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UIScripts
{
	public class ChildItemHoverEvent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public UnityEvent<int, bool> onHover = new UnityEvent<int, bool>();

		private bool active;

		private bool hovering;

		private WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

		private Coroutine waiting;

		public void OnPointerEnter(PointerEventData eventData)
		{
			hovering = true;
			waiting = StartCoroutine(WaitForDelay());
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hovering = false;
			if (waiting != null)
			{
				StopCoroutine(waiting);
			}
			HoverExit();
		}

		private IEnumerator WaitForDelay()
		{
			yield return wait;
			if (hovering)
			{
				onHover.Invoke(base.transform.GetSiblingIndex(), arg1: true);
				active = true;
			}
		}

		private void HoverExit()
		{
			if (active)
			{
				onHover.Invoke(base.transform.GetSiblingIndex(), arg1: false);
			}
			active = false;
		}

		private void OnDisable()
		{
			HoverExit();
		}
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	public class EventTriggerFix : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		private EventTrigger tempTrigger;

		private bool onEnter;

		private void Awake()
		{
			tempTrigger = base.gameObject.GetComponent<EventTrigger>();
			tempTrigger.enabled = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			onEnter = true;
			tempTrigger.OnPointerEnter(eventData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			onEnter = false;
			StopCoroutine("WaitForPointerExit");
			StartCoroutine("WaitForPointerExit", eventData);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			tempTrigger.OnPointerClick(eventData);
		}

		private IEnumerator WaitForPointerExit(PointerEventData eventData)
		{
			yield return new WaitForSeconds(0.1f);
			if (!onEnter)
			{
				tempTrigger.OnPointerExit(eventData);
			}
		}
	}
}

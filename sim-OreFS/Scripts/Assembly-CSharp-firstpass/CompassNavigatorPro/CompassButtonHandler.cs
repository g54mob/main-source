using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace CompassNavigatorPro
{
	[AddComponentMenu("")]
	public class CompassButtonHandler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public UnityAction actionHandler;

		private Coroutine co;

		public void OnPointerDown(PointerEventData eventData)
		{
			if (co != null)
			{
				StopCoroutine(co);
			}
			co = StartCoroutine(ExecuteHandler());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (co != null)
			{
				StopCoroutine(co);
			}
		}

		private IEnumerator ExecuteHandler()
		{
			WaitForEndOfFrame w = new WaitForEndOfFrame();
			while (true)
			{
				actionHandler();
				yield return w;
			}
		}
	}
}

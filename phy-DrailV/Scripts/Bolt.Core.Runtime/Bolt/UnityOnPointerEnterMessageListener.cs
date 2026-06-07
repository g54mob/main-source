using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnPointerEnterMessageListener : MessageListener, IPointerEnterHandler, IEventSystemHandler
	{
		public void OnPointerEnter(PointerEventData eventData)
		{
			EventBus.Trigger("OnPointerEnter", base.gameObject, eventData);
		}
	}
}

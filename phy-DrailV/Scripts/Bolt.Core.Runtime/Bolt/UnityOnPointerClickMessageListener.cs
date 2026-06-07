using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnPointerClickMessageListener : MessageListener, IPointerClickHandler, IEventSystemHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			EventBus.Trigger("OnPointerClick", base.gameObject, eventData);
		}
	}
}

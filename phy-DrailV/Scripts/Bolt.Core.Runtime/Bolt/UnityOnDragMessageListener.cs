using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnDragMessageListener : MessageListener, IDragHandler, IEventSystemHandler
	{
		public void OnDrag(PointerEventData eventData)
		{
			EventBus.Trigger("OnDrag", base.gameObject, eventData);
		}
	}
}

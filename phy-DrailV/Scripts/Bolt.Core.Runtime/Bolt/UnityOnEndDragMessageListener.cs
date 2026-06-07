using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnEndDragMessageListener : MessageListener, IEndDragHandler, IEventSystemHandler
	{
		public void OnEndDrag(PointerEventData eventData)
		{
			EventBus.Trigger("OnEndDrag", base.gameObject, eventData);
		}
	}
}

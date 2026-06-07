using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnScrollMessageListener : MessageListener, IScrollHandler, IEventSystemHandler
	{
		public void OnScroll(PointerEventData eventData)
		{
			EventBus.Trigger("OnScroll", base.gameObject, eventData);
		}
	}
}

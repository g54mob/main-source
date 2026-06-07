using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnDropMessageListener : MessageListener, IDropHandler, IEventSystemHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			EventBus.Trigger("OnDrop", base.gameObject, eventData);
		}
	}
}

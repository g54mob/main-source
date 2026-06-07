using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnPointerUpMessageListener : MessageListener, IPointerUpHandler, IEventSystemHandler
	{
		public void OnPointerUp(PointerEventData eventData)
		{
			EventBus.Trigger("OnPointerUp", base.gameObject, eventData);
		}
	}
}

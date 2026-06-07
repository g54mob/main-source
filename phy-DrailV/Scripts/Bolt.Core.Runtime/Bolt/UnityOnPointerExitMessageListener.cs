using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnPointerExitMessageListener : MessageListener, IPointerExitHandler, IEventSystemHandler
	{
		public void OnPointerExit(PointerEventData eventData)
		{
			EventBus.Trigger("OnPointerExit", base.gameObject, eventData);
		}
	}
}

using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnCancelMessageListener : MessageListener, ICancelHandler, IEventSystemHandler
	{
		public void OnCancel(BaseEventData eventData)
		{
			EventBus.Trigger("OnCancel", base.gameObject, eventData);
		}
	}
}

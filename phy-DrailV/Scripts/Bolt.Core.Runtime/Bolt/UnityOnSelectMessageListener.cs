using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnSelectMessageListener : MessageListener, ISelectHandler, IEventSystemHandler
	{
		public void OnSelect(BaseEventData eventData)
		{
			EventBus.Trigger("OnSelect", base.gameObject, eventData);
		}
	}
}

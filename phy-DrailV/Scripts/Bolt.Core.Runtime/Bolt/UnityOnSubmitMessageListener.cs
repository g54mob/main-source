using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnSubmitMessageListener : MessageListener, ISubmitHandler, IEventSystemHandler
	{
		public void OnSubmit(BaseEventData eventData)
		{
			EventBus.Trigger("OnSubmit", base.gameObject, eventData);
		}
	}
}

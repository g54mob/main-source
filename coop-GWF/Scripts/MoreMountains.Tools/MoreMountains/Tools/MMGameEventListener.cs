using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	public class MMGameEventListener : MonoBehaviour, MMEventListener<MMGameEvent>, MMEventListenerBase
	{
		[Header("MMGameEvent")]
		[Tooltip("the name of the event you want to listen for")]
		public string EventName = "Load";

		[Tooltip("a UnityEvent hook you can use to call methods when the specified event gets triggered")]
		public UnityEvent OnMMGameEvent;

		public void OnMMEvent(MMGameEvent gameEvent)
		{
			if (gameEvent.EventName == EventName)
			{
				OnMMGameEvent?.Invoke();
			}
		}

		protected virtual void OnEnable()
		{
			this.MMEventStartListening();
		}

		protected virtual void OnDisable()
		{
			this.MMEventStopListening();
		}
	}
}

using System.Collections.Generic;

namespace Origin
{
	internal class EventHandlerT<EventType>
	{
		private List<EventCallbackT<EventType>> callbacks = new List<EventCallbackT<EventType>>();

		public bool HasCallbacks => callbacks.Count > 0;

		public void AddCallback(EventCallbackT<EventType> callback)
		{
			callbacks.Add(callback);
		}

		public void HandleEvent(EventType evnt)
		{
			foreach (EventCallbackT<EventType> callback in callbacks)
			{
				OriginSDK.sdk.AddCallback(new EventCallback<EventType>(callback, evnt));
			}
		}
	}
}

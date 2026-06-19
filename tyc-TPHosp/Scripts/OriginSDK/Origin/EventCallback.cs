namespace Origin
{
	internal class EventCallback<T> : ICallback
	{
		private EventCallbackT<T> eventCallback;

		private T payload;

		public EventCallback(EventCallbackT<T> callback, T data)
		{
			eventCallback = callback;
			payload = data;
		}

		public override void callback()
		{
			if (eventCallback != null)
			{
				eventCallback(payload);
			}
		}
	}
}

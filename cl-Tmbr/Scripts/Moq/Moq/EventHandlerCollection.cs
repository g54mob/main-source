using System;
using System.Collections.Generic;
using System.Reflection;

namespace Moq
{
	internal sealed class EventHandlerCollection
	{
		private readonly Dictionary<EventInfo, Delegate> eventHandlers;

		public EventHandlerCollection()
		{
			eventHandlers = new Dictionary<EventInfo, Delegate>();
		}

		public void Add(EventInfo @event, Delegate eventHandler)
		{
			lock (eventHandlers)
			{
				eventHandlers[@event] = Delegate.Combine(TryGet(@event), eventHandler);
			}
		}

		public void Clear()
		{
			lock (eventHandlers)
			{
				eventHandlers.Clear();
			}
		}

		public void Remove(EventInfo @event, Delegate eventHandler)
		{
			lock (eventHandlers)
			{
				eventHandlers[@event] = Delegate.Remove(TryGet(@event), eventHandler);
			}
		}

		public bool TryGet(EventInfo @event, out Delegate handlers)
		{
			lock (eventHandlers)
			{
				return eventHandlers.TryGetValue(@event, out handlers) && (object)handlers != null;
			}
		}

		private Delegate TryGet(EventInfo @event)
		{
			if (!eventHandlers.TryGetValue(@event, out Delegate value))
			{
				return null;
			}
			return value;
		}
	}
}

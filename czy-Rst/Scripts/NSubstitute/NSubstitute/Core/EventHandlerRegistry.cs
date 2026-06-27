using System;
using System.Collections.Generic;

namespace NSubstitute.Core
{
	public class EventHandlerRegistry : IEventHandlerRegistry
	{
		private readonly List<Tuple<string, List<object>>> _handlersForEvent = new List<Tuple<string, List<object>>>();

		public void Add(string eventName, object handler)
		{
			lock (_handlersForEvent)
			{
				Handlers(eventName).Add(handler);
			}
		}

		public void Remove(string eventName, object handler)
		{
			lock (_handlersForEvent)
			{
				Handlers(eventName).Remove(handler);
			}
		}

		public IEnumerable<object> GetHandlers(string eventName)
		{
			lock (_handlersForEvent)
			{
				return Handlers(eventName).ToArray();
			}
		}

		private List<object> Handlers(string eventName)
		{
			foreach (Tuple<string, List<object>> item in _handlersForEvent)
			{
				if (item.Item1 == eventName)
				{
					return item.Item2;
				}
			}
			Tuple<string, List<object>> tuple = Tuple.Create(eventName, new List<object>());
			_handlersForEvent.Add(tuple);
			return tuple.Item2;
		}
	}
}

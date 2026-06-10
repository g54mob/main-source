using System.Collections.Generic;

namespace NSMedieval.StatsSystem
{
	public class StatsEventController
	{
		public delegate void StatEventCallback(object stat = null);

		private class EventDelegate
		{
			public event StatEventCallback Callbacks;

			public void Invoke(object data)
			{
				this.Callbacks?.Invoke(data);
			}

			public void ClearCallbacks()
			{
				this.Callbacks = null;
			}
		}

		private class EventHolder
		{
			private Dictionary<StatEventType, EventDelegate> callbacks = new Dictionary<StatEventType, EventDelegate>();

			public void Invoke(StatEventType type, object data)
			{
				if (callbacks.ContainsKey(type))
				{
					callbacks[type].Invoke(data);
				}
			}

			public void RegisterCallback(StatEventType type, StatEventCallback method)
			{
				if (!callbacks.TryGetValue(type, out var value))
				{
					value = new EventDelegate();
					callbacks.Add(type, value);
				}
				else if (value == null)
				{
					value = new EventDelegate();
					callbacks[type] = value;
				}
				value.Callbacks += method;
			}

			public void RemoveCallback(StatEventCallback method)
			{
				foreach (EventDelegate value in callbacks.Values)
				{
					value.Callbacks -= method;
				}
			}

			public void ClearAllCallbacks()
			{
				foreach (EventDelegate value in callbacks.Values)
				{
					value.ClearCallbacks();
				}
				callbacks.Clear();
			}
		}

		private readonly Dictionary<StatType, EventHolder> eventCallbacks = new Dictionary<StatType, EventHolder>();

		public void RegisterListener(StatEventType eventType, StatEventCallback method)
		{
			RegisterListener(eventType, StatType.None, method);
		}

		public void RegisterListener(StatEventType eventType, StatType statType, StatEventCallback method)
		{
			if (!eventCallbacks.TryGetValue(statType, out var value))
			{
				value = new EventHolder();
				eventCallbacks.Add(statType, value);
			}
			value.RegisterCallback(eventType, method);
		}

		public void RemoveListener(StatEventCallback method)
		{
			foreach (EventHolder value in eventCallbacks.Values)
			{
				value.RemoveCallback(method);
			}
		}

		public void FireEvent(StatEventType eventType, object data)
		{
			if (eventCallbacks.TryGetValue(StatType.None, out var value))
			{
				value.Invoke(eventType, data);
			}
		}

		public void Dispose()
		{
			foreach (EventHolder value in eventCallbacks.Values)
			{
				value.ClearAllCallbacks();
			}
			eventCallbacks.Clear();
		}

		internal void FireStatEvent(StatEventType eventType, StatInstance instance)
		{
			StatType type = instance.Type;
			if (eventCallbacks.TryGetValue(type, out var value))
			{
				value.Invoke(eventType, instance);
			}
			if (eventCallbacks.TryGetValue(StatType.None, out value))
			{
				value.Invoke(eventType, instance);
			}
		}
	}
}

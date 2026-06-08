using System;
using System.Collections.Generic;

public class EventManager
{
	private class DefferedEventData
	{
		public GeneralEventType TheEventType { get; set; }

		public EventArgs Args { get; set; }

		public object Sender { get; set; }
	}

	public static EventManager Instance;

	private Dictionary<GeneralEventType, EventHandler<EventArgs>> _eventsPerTypeInstant;

	private Dictionary<GeneralEventType, EventHandler<EventArgs>> _eventsPerTypeDeferred;

	private static EventManager _instance;

	private List<DefferedEventData> _defferedEvents;

	private EventManager()
	{
		ResetAll();
	}

	public static void Initialize()
	{
		if (Instance == null)
		{
			Instance = new EventManager();
		}
	}

	public void ResetAll()
	{
		_eventsPerTypeInstant = new Dictionary<GeneralEventType, EventHandler<EventArgs>>();
		_eventsPerTypeDeferred = new Dictionary<GeneralEventType, EventHandler<EventArgs>>();
		_defferedEvents = new List<DefferedEventData>(50);
	}

	public void SubscribeInstant(GeneralEventType eventType, EventHandler<EventArgs> handler)
	{
		EventHandler<EventArgs> theEvent = null;
		if (_eventsPerTypeInstant.ContainsKey(eventType))
		{
			theEvent = _eventsPerTypeInstant[eventType];
		}
		theEvent = (EventHandler<EventArgs>)Delegate.Combine(theEvent, handler.MakeWeak(delegate(EventHandler<EventArgs> x)
		{
			theEvent = (EventHandler<EventArgs>)Delegate.Remove(theEvent, x);
		}));
		_eventsPerTypeInstant[eventType] = theEvent;
	}

	public void SubscribeDeferred(GeneralEventType eventType, EventHandler<EventArgs> handler)
	{
		EventHandler<EventArgs> theEvent = null;
		if (_eventsPerTypeDeferred.ContainsKey(eventType))
		{
			theEvent = _eventsPerTypeDeferred[eventType];
		}
		theEvent = (EventHandler<EventArgs>)Delegate.Combine(theEvent, handler.MakeWeak(delegate(EventHandler<EventArgs> x)
		{
			theEvent = (EventHandler<EventArgs>)Delegate.Remove(theEvent, x);
		}));
		_eventsPerTypeDeferred[eventType] = theEvent;
	}

	public void UnSubscribe(GeneralEventType eventType, EventHandler<EventArgs> handler)
	{
		if (_eventsPerTypeInstant.ContainsKey(eventType))
		{
			Dictionary<GeneralEventType, EventHandler<EventArgs>> eventsPerTypeInstant;
			Dictionary<GeneralEventType, EventHandler<EventArgs>> dictionary = (eventsPerTypeInstant = _eventsPerTypeInstant);
			GeneralEventType key2;
			GeneralEventType key = (key2 = eventType);
			EventHandler<EventArgs> source = eventsPerTypeInstant[key2];
			dictionary[key] = (EventHandler<EventArgs>)Delegate.Remove(source, handler);
		}
		if (_eventsPerTypeDeferred.ContainsKey(eventType))
		{
			Dictionary<GeneralEventType, EventHandler<EventArgs>> eventsPerTypeDeferred;
			Dictionary<GeneralEventType, EventHandler<EventArgs>> dictionary2 = (eventsPerTypeDeferred = _eventsPerTypeDeferred);
			GeneralEventType key2;
			GeneralEventType key3 = (key2 = eventType);
			EventHandler<EventArgs> source = eventsPerTypeDeferred[key2];
			dictionary2[key3] = (EventHandler<EventArgs>)Delegate.Remove(source, handler);
		}
	}

	public void Publish(GeneralEventType eventType)
	{
		Publish(eventType, new GeneralEventArgs(), null);
	}

	public void Publish(GeneralEventType eventType, EventArgs args)
	{
		Publish(eventType, args, null);
	}

	public void Publish(GeneralEventType eventType, EventArgs args, object sender)
	{
		sender = sender ?? this;
		if (_eventsPerTypeInstant.Count > 0 && _eventsPerTypeInstant.ContainsKey(eventType))
		{
			FireEventNow(eventType, args, sender, _eventsPerTypeInstant);
		}
		if (_eventsPerTypeDeferred.Count > 0 && _eventsPerTypeDeferred.ContainsKey(eventType))
		{
			_defferedEvents.Add(new DefferedEventData
			{
				TheEventType = eventType,
				Args = args,
				Sender = sender
			});
		}
	}

	private void FireEventNow(GeneralEventType eventType, EventArgs args, object sender, Dictionary<GeneralEventType, EventHandler<EventArgs>> eventDictionary)
	{
		EventHandler<EventArgs> value;
		if (eventDictionary.TryGetValue(eventType, out value) && value != null)
		{
			value(sender, args);
		}
	}

	public void Update()
	{
		int count = _defferedEvents.Count;
		for (int i = 0; i < count; i++)
		{
			FireEventNow(_defferedEvents[i].TheEventType, _defferedEvents[i].Args, _defferedEvents[i].Sender, _eventsPerTypeDeferred);
		}
		_defferedEvents.Clear();
	}
}

using System;

public class GenericGameEvent<T> : GameEvent where T : GenericGameEvent<T>, new()
{
	private static T _instance;

	protected GenericGameEvent()
		: base(GameEventType.None)
	{
	}

	protected static T ReturnInstance(GameEventType eventType)
	{
		if (_instance == null)
		{
			_instance = new T();
		}
		if (_instance.IsBeingDispatched)
		{
			throw new NotSupportedException("Trying to dispatch an event that is already being dispatch... whoops!!!");
		}
		_instance.EventType = eventType;
		return _instance;
	}
}

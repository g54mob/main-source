using System.Collections.Generic;
using Assets.Code.Events.Session_Events;
using UnityEngine.Events;

public class GameEventDispatcher
{
	private static GameEventDispatcher _instance;

	protected Dictionary<SessionEventType, UnitySessionEvent> SessionEvents = new Dictionary<SessionEventType, UnitySessionEvent>();

	protected Dictionary<GameEventType, UnityGameEvent> GameEvents = new Dictionary<GameEventType, UnityGameEvent>();

	public static GameEventDispatcher Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameEventDispatcher();
			}
			return _instance;
		}
	}

	public static void AddListener(GameEventType type, UnityAction<GameEvent> call)
	{
		if (Instance.GameEvents.TryGetValue(type, out var value))
		{
			value.AddListener(call);
			return;
		}
		value = new UnityGameEvent();
		value.AddListener(call);
		Instance.GameEvents.Add(type, value);
	}

	public static void RemoveListener(GameEventType type, UnityAction<GameEvent> call)
	{
		if (Instance.GameEvents.TryGetValue(type, out var value))
		{
			value.RemoveListener(call);
		}
	}

	public static void RemoveAllListeners(GameEventType type)
	{
		UnityGameEvent value = null;
		if (Instance.GameEvents.TryGetValue(type, out value))
		{
			value.RemoveAllListeners();
		}
	}

	public static void RemoveAllGameEventListeners()
	{
		if (Instance != null && Instance.GameEvents != null)
		{
			Dictionary<GameEventType, UnityGameEvent>.Enumerator enumerator = Instance.GameEvents.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.RemoveAllListeners();
			}
		}
	}

	public static void Dispatch(GameEvent gameEvent)
	{
		if (Instance.GameEvents.TryGetValue(gameEvent.EventType, out var value))
		{
			value.Invoke(gameEvent);
		}
	}

	public static void Dispatch(GameEventType gameEventType)
	{
		if (Instance.GameEvents.TryGetValue(gameEventType, out var value))
		{
			value.Invoke(null);
		}
	}

	public static void AddListener(SessionEventType type, UnityAction<SessionEventType, SessionEvent> call)
	{
		if (!Instance.SessionEvents.TryGetValue(type, out var value))
		{
			value = new UnitySessionEvent();
			Instance.SessionEvents.Add(type, value);
		}
		value.AddListener(call);
	}

	public static void RemoveListener(SessionEventType type, UnityAction<SessionEventType, SessionEvent> listener)
	{
		if (Instance.SessionEvents.TryGetValue(type, out var value))
		{
			value.RemoveListener(listener);
		}
	}

	public static void RemoveAllListeners(SessionEventType type)
	{
		if (Instance.SessionEvents.TryGetValue(type, out var value))
		{
			value.RemoveAllListeners();
		}
	}

	public static void Dispatch(SessionEvent sessionEvent)
	{
		if (Instance.SessionEvents.TryGetValue(sessionEvent.EventType, out var value))
		{
			value.Invoke(sessionEvent.EventType, sessionEvent);
		}
	}

	public static void Dispatch(SessionEventType type)
	{
		if (Instance.SessionEvents.TryGetValue(type, out var value))
		{
			value.Invoke(type, null);
		}
	}
}

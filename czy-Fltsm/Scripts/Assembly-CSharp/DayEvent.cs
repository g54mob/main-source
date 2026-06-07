using System.Collections.Generic;

public class DayEvent : GameEvent
{
	private static DayEvent _instance;

	public Day Day { get; private set; }

	public List<Day> Days { get; private set; } = new List<Day>();

	private DayEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static DayEvent Get(GameEventType eventType)
	{
		if (_instance == null)
		{
			_instance = new DayEvent(eventType);
		}
		else
		{
			_instance.EventType = eventType;
		}
		return _instance;
	}

	public static void Dispatch(GameEventType gameEventType, Day day, List<Day> days)
	{
		DayEvent dayEvent = Get(gameEventType);
		dayEvent.Day = day;
		dayEvent.Days.Clear();
		dayEvent.Days.AddRange(days);
		dayEvent.Dispatch();
	}
}

using System.Collections.Generic;

public class QuestEvent : GameEvent
{
	private static List<QuestEvent> _instances = new List<QuestEvent>();

	public Quest Quest { get; private set; }

	public IQuestObjective Objective { get; private set; }

	private QuestEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void DispatchQuestObjectiveUpdatedEvent(IQuestObjective objective)
	{
		GetInstance(GameEventType.QuestObjectiveUpdated, null, objective).Dispatch();
	}

	public static void Dispatch(GameEventType eventType, Quest quest)
	{
		GetInstance(eventType, quest).Dispatch();
	}

	public static void DispatchQuestStarted(Quest quest)
	{
		GetInstance(GameEventType.QuestStarted, quest).Dispatch();
	}

	public static void DispatchQuestUpdated(Quest quest)
	{
		GetInstance(GameEventType.QuestUpdated, quest).Dispatch();
	}

	public static void DispatchQuestCompleted(Quest quest)
	{
		GetInstance(GameEventType.QuestCompleted, quest).Dispatch();
	}

	public static void DispatchQuestAbandoned(Quest quest)
	{
		GetInstance(GameEventType.QuestAbandoned, quest).Dispatch();
	}

	public static void DispatchQuestFailed(Quest quest)
	{
		GetInstance(GameEventType.QuestFailed, quest).Dispatch();
	}

	private static QuestEvent GetInstance(GameEventType eventType, Quest quest, IQuestObjective objective = null)
	{
		QuestEvent questEvent = null;
		foreach (QuestEvent instance in _instances)
		{
			if (!instance.IsBeingDispatched)
			{
				questEvent = instance;
				break;
			}
		}
		if (questEvent == null)
		{
			questEvent = new QuestEvent(eventType);
			_instances.Add(questEvent);
		}
		questEvent.EventType = eventType;
		questEvent.Quest = quest;
		questEvent.Objective = objective;
		return questEvent;
	}
}

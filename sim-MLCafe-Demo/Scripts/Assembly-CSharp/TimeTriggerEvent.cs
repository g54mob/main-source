using System;
using UnityEngine.Events;

[Serializable]
public class TimeTriggerEvent
{
	public string name;

	public bool triggerOnce;

	public bool isTriggered;

	public GameDate triggerDate;

	public GameTime triggerTime;

	public UnityAction triggerAction;

	private bool daily;

	public TimeTriggerEvent(string name, bool triggerOnce, GameDate triggerDate, GameTime triggerTime, UnityAction triggerAction)
	{
		this.name = name;
		this.triggerOnce = triggerOnce;
		this.triggerDate = triggerDate;
		this.triggerTime = triggerTime;
		this.triggerAction = triggerAction;
		isTriggered = false;
	}

	public TimeTriggerEvent(string name, GameTime triggerTime, UnityAction triggerAction)
	{
		this.name = name;
		triggerOnce = true;
		triggerDate = GameDate.Create(0, 0, 0, 0);
		this.triggerTime = triggerTime;
		this.triggerAction = triggerAction;
		daily = true;
		isTriggered = false;
	}

	public TimeTriggerEvent(string name, bool triggerOnce, GameTime triggerTime, UnityAction triggerAction)
	{
		this.name = name;
		this.triggerOnce = triggerOnce;
		triggerDate = GameDate.Create(0, 0, 0, 0);
		this.triggerTime = triggerTime;
		this.triggerAction = triggerAction;
		daily = true;
		isTriggered = false;
	}

	public bool CheckTimeMoment(GameDate date, GameTime time)
	{
		if (daily)
		{
			return GameTime.IsSameTime(time, triggerTime);
		}
		if (!GameDate.IsSameDate(date, triggerDate) || !GameTime.IsSameTime(time, triggerTime))
		{
			return GameDate.IsPastTheDate(date, triggerDate);
		}
		return true;
	}

	public void Trigger()
	{
		if (!isTriggered)
		{
			triggerAction();
			isTriggered = true;
		}
	}
}

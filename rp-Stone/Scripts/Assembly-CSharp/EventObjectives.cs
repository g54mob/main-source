using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class EventObjectives
{
	private readonly int MAX_CONCURRENT_OBJECTIVES = 3;

	public List<EventObjectiveBase> allObjectives = new List<EventObjectiveBase>();

	public Dictionary<string, EventObjectiveBase> dictObjectives = new Dictionary<string, EventObjectiveBase>();

	public List<EventObjectiveBase> activeObjectives = new List<EventObjectiveBase>();

	private int spawnIndex;

	private int dailyObjectivesCompleted;

	private DateTime lastCompletedDate;

	private readonly int maxBonus = 120;

	private SafeInt bonusPoints;

	private DateTime bonusThreshold;

	public int maxDailyObjectives { get; set; }

	public EventObjectives(int maxDailyObjectives)
	{
		this.maxDailyObjectives = maxDailyObjectives;
	}

	public void Add(EventObjectiveBase objective)
	{
		if (dictObjectives.ContainsKey(objective.id))
		{
			Utils.LogIfEditor("Duplicate objective ID: " + objective.id + ". Incrementing it");
			objective.id += "+";
			Add(objective);
		}
		else
		{
			allObjectives.Add(objective);
			dictObjectives.Add(objective.id, objective);
		}
	}

	public void StartEvent()
	{
		FillObjectives();
	}

	public void FillObjectives()
	{
		if (HasDayChanged())
		{
			dailyObjectivesCompleted = 0;
		}
		int num = MAX_CONCURRENT_OBJECTIVES - activeObjectives.Count;
		while (num-- > 0)
		{
			SpawnObjective();
		}
	}

	public bool IsFull()
	{
		return activeObjectives.Count >= MAX_CONCURRENT_OBJECTIVES;
	}

	public void SpawnObjective()
	{
		if (dailyObjectivesCompleted + activeObjectives.Count < maxDailyObjectives)
		{
			int num = 12;
			EventObjectiveBase eventObjectiveBase = null;
			while ((eventObjectiveBase == null || (eventObjectiveBase.maxPlayCount > 0 && eventObjectiveBase.timesCompleted >= eventObjectiveBase.maxPlayCount) || !eventObjectiveBase.CheckConditions() || activeObjectives.Contains(eventObjectiveBase)) && num-- > 0)
			{
				eventObjectiveBase = allObjectives[spawnIndex];
				spawnIndex = (spawnIndex + 1) % allObjectives.Count;
			}
			if (eventObjectiveBase == null)
			{
				Debug.LogError("Failed to spawn objective.");
				return;
			}
			activeObjectives.Add(eventObjectiveBase);
			eventObjectiveBase.Init();
		}
	}

	public void CompleteObjective(string objectiveId)
	{
		EventObjectiveBase eventObjectiveBase = dictObjectives[objectiveId];
		activeObjectives.Remove(eventObjectiveBase);
		eventObjectiveBase.ResetProgress();
		eventObjectiveBase.End();
		if (eventObjectiveBase.maxPlayCount > 0)
		{
			eventObjectiveBase.timesCompleted++;
		}
		if (HasDayChanged())
		{
			dailyObjectivesCompleted = 1;
		}
		else
		{
			dailyObjectivesCompleted++;
		}
		lastCompletedDate = DateTime.Now;
		SpawnObjective();
		AddBonusCompletionPoints();
	}

	public bool IsObjectiveActive(string objectiveId)
	{
		for (int i = 0; i < activeObjectives.Count; i++)
		{
			if (activeObjectives[i].id == objectiveId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsPreventingLocationStatsUpdate()
	{
		for (int i = 0; i < activeObjectives.Count; i++)
		{
			if (activeObjectives[i].isPreventingLocationStatsUpdate)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasDayChanged()
	{
		DateTime now = DateTime.Now;
		if (lastCompletedDate.Day == now.Day && lastCompletedDate.Month == now.Month)
		{
			return lastCompletedDate.Year != now.Year;
		}
		return true;
	}

	public void AddBonusCompletionPoints()
	{
		DateTime now = DateTime.Now;
		if (bonusThreshold > now)
		{
			int value = (int)(bonusThreshold - now).TotalSeconds;
			bonusPoints += Mathf.Clamp(value, 0, maxBonus);
		}
		bonusThreshold = now + new TimeSpan(0, 0, maxBonus);
	}

	public int GetBonusCompletionPoints(int completedCount)
	{
		int value = bonusPoints.GetValue();
		int num = completedCount * maxBonus / 4;
		if (value > num)
		{
			return num;
		}
		return bonusPoints.GetValue();
	}

	public void ResetClock()
	{
		lastCompletedDate = DateTime.Now - new TimeSpan(1, 0, 0, 0);
	}

	public void ClearProgress()
	{
		spawnIndex = 0;
		dailyObjectivesCompleted = 0;
		for (int i = 0; i < allObjectives.Count; i++)
		{
			EventObjectiveBase eventObjectiveBase = allObjectives[i];
			eventObjectiveBase.ClearProgress();
			eventObjectiveBase.End();
		}
		activeObjectives.Clear();
		bonusPoints = new SafeInt(0);
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		spawnIndex = SlimJson.ParseInt(sjson, "spawn_i");
		dailyObjectivesCompleted = SlimJson.ParseInt(sjson, "cmpl");
		lastCompletedDate = SlimJson.ParseDateTime(sjson, "lcd");
		string[] array = SlimJson.ParseArray(sjson, "ids");
		for (int i = 0; i < allObjectives.Count; i++)
		{
			EventObjectiveBase eventObjectiveBase = allObjectives[i];
			string id = eventObjectiveBase.id;
			string text = SlimJson.Parse(sjson, id);
			if (text != null)
			{
				eventObjectiveBase.Parse(text);
			}
		}
		if (array != null)
		{
			foreach (string key in array)
			{
				EventObjectiveBase eventObjectiveBase2 = dictObjectives[key];
				activeObjectives.Add(eventObjectiveBase2);
				eventObjectiveBase2.Init();
			}
		}
		bonusPoints = new SafeInt(SlimJson.ParseInt(sjson, "bP"));
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		int count = activeObjectives.Count;
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			EventObjectiveBase eventObjectiveBase = activeObjectives[i];
			array[i] = eventObjectiveBase.id;
		}
		for (int j = 0; j < allObjectives.Count; j++)
		{
			EventObjectiveBase eventObjectiveBase2 = allObjectives[j];
			if (!eventObjectiveBase2.IsDefaultValues())
			{
				SlimJson.AddProperty(eventObjectiveBase2.id, eventObjectiveBase2.Serialize());
			}
		}
		SlimJson.AddProperty("spawn_i", spawnIndex);
		SlimJson.AddProperty("cmpl", dailyObjectivesCompleted);
		SlimJson.AddProperty("lcd", lastCompletedDate);
		SlimJson.AddProperty("ids", array);
		SlimJson.AddProperty("bP", bonusPoints.GetValue());
		return SlimJson.EndSerialization();
	}
}
